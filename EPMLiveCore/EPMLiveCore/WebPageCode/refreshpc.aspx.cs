using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class refreshpc : System.Web.UI.Page
    {
        SPList projectCenter;
        Hashtable hCurrentProjectCenter;
        bool debug = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            {
                SPWeb oldWeb = SPContext.Current.Web;

                try
                {
                    debug = bool.Parse(Request["debug"]);
                }
                catch { }


                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    using (SPSite procSite = new SPSite(site.ID))
                    {
                        using (SPWeb web = procSite.OpenWeb(oldWeb.ServerRelativeUrl))
                        {
                            hCurrentProjectCenter = new Hashtable();
                            web.AllowUnsafeUpdates = true;
                            web.Site.CatchAccessDeniedException = false;
                            try
                            {
                                projectCenter = web.Lists[new Guid(Request["ListId"])];

                                foreach (SPListItem li in projectCenter.Items)
                                {
                                    string url = li[projectCenter.Fields.GetFieldByInternalName("URL").Id].ToString();
                                    url = url.Replace(", ", "\n");
                                    url = url.Split('\n')[0];
                                    try
                                    {
                                        hCurrentProjectCenter.Add(url, li);
                                    }
                                    catch(Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                                }

                                processWeb(web);

                                foreach (DictionaryEntry entry in hCurrentProjectCenter)
                                {
                                    try
                                    {
                                        SPListItem li = (SPListItem)entry.Value;
                                        li.Delete();
                                    }
                                    catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                                    projectCenter.Update();
                                }
                            }
                            catch (Exception ex)
                            {
                                Response.Write("Error in Main: " + ex.Message);
                            }
                        }
                    }

                });
            }
            if (!debug)
                Response.Redirect(HttpContext.Current.Request.UrlReferrer.ToString());
        }
        private void processWeb(SPWeb web)
        {
            if (!web.IsRootWeb)
            {
                try
                {
                    SPList pCenter = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];
                    web.AllowUnsafeUpdates = true;
                    foreach (SPListItem li in pCenter.Items)
                    {
                        string url = li.Web.Url + "/" + pCenter.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + li.ID + "&Source=" + Server.UrlEncode(projectCenter.ParentWeb.Url + "/" + projectCenter.Views[0].Url);
                        if (!hCurrentProjectCenter.Contains(url))
                        {
                            try
                            {
                                SPListItem newLi = projectCenter.Items.Add();
                                newLi["URL"] = url + ", " + li.Title;
                                newLi["SiteURL"] = web.Url + ", " + web.Title;
                                foreach (SPField f in projectCenter.Fields)
                                {
                                    if (!f.Hidden && !f.Sealed && !f.ReadOnlyField && f.Type != SPFieldType.Attachments && f.Type != SPFieldType.URL)
                                    {
                                        try
                                        {
                                            switch (f.InternalName)
                                            {
                                                case "StartDate":
                                                    newLi[f.InternalName] = li["Start"].ToString();
                                                    break;
                                                case "DueDate":
                                                    newLi[f.InternalName] = li["Finish"].ToString();
                                                    break;
                                                default:
                                                    if (li[f.InternalName] != null)
                                                    {
                                                        string val = li[f.InternalName].ToString();
                                                        float i = 0;
                                                        switch (f.Type)
                                                        {
                                                            case SPFieldType.Currency:
                                                                try
                                                                {
                                                                    if (float.TryParse(val, out i))
                                                                    {
                                                                        newLi[f.InternalName] = val;
                                                                    }
                                                                }
                                                                catch { }
                                                                break;
                                                            case SPFieldType.Number:
                                                                try
                                                                {
                                                                    if (float.TryParse(val, out i))
                                                                    {
                                                                        newLi[f.InternalName] = val;
                                                                    }
                                                                }
                                                                catch { }
                                                                break;
                                                            default:
                                                                newLi[f.InternalName] = val;
                                                                break;
                                                        };
                                                    }
                                                    break;
                                            }
                                        }
                                        catch { }
                                        //Response.Write(f.InternalName + " " + f.Type + " " + li["Start"].ToString() + "<br>");
                                    }
                                    if (f.TypeDisplayName == "Total Rollup")
                                    {
                                        newLi[f.InternalName] = getListItemCount(web, f.GetCustomProperty("ListName").ToString(), f.GetCustomProperty("ListQuery").ToString(), li.Title);
                                    }

                                }
                                newLi.Update();
                            }
                            catch (Exception ex)
                            {
                                Response.Write("Error Adding Project (" + li.Title + "): " + ex.Message + ex.StackTrace + "<br><br>");
                            }
                        }
                        else
                        {
                            try
                            {
                                SPListItem liOld = (SPListItem)hCurrentProjectCenter[url];
                                liOld["SiteURL"] = web.Url + ", " + web.Title;
                                foreach (SPField f in projectCenter.Fields)
                                {
                                    if (!f.Hidden && !f.Sealed && !f.ReadOnlyField && f.Type != SPFieldType.Attachments && f.Type != SPFieldType.URL)
                                    {
                                        try
                                        {
                                            string data = "";
                                            switch (f.InternalName)
                                            {
                                                case "StartDate":
                                                    data = li["Start"].ToString();
                                                    break;
                                                case "DueDate":
                                                    data = li["Finish"].ToString();
                                                    break;
                                                default:
                                                    data = li[f.InternalName].ToString();
                                                    break;
                                            }
                                            try
                                            {
                                                string tData = data.Replace(";#", "\n");
                                                if (tData.Split('\n').Length > 1)
                                                {
                                                    if (tData.Split('\n')[0] == "float" || tData.Split('\n')[0] == "string" || tData.Split('\n')[0] == "boolean" || tData.Split('\n')[0] == "datetime")
                                                        data = tData.Split('\n')[1];
                                                }
                                            }
                                            catch { }
                                            liOld[f.InternalName] = data;
                                        }
                                        catch { }
                                    }
                                    if (f.TypeDisplayName == "Total Rollup")
                                    {
                                        liOld[f.InternalName] = getListItemCount(web, f.GetCustomProperty("ListName").ToString(), f.GetCustomProperty("ListQuery").ToString(), li.Title);
                                    }
                                }
                                liOld.Update();

                                hCurrentProjectCenter.Remove(url);
                            }
                            catch { }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("LI: " + ex.Message + ex.StackTrace + "<br><br>");
                }
            }

            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    processWeb(w);
                }
                catch (Exception ex) { LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.Event, TraceSeverity.Medium, ex.ToString()); }
                finally { if (w != null) w.Dispose(); }
            }
        }

        private int getListItemCount(SPWeb web, string list, string query, string project)
        {
            try
            {
                SPList tList = null;
                try
                {
                    tList = web.Lists[list];
                    if (tList.Fields.GetFieldByInternalName("Project") == null)
                        return 0;
                }
                catch { return 0; }
                if (query != "")
                {
                    query = "<And>" + query + "<Eq><FieldRef Name='Project'/><Value Type='Lookup'>" + project + "</Value></Eq></And>";
                }
                else
                    query = "<Eq><FieldRef Name='Project'/><Value Type='Lookup'>" + project + "</Value></Eq>";

                SPQuery q = new SPQuery();
                q.Query = "<Where>" + query + "</Where>";

                return tList.GetItems(q).Count;
            }
            catch (Exception ex)
            {
                Response.Write("ERR ROLLUP List(" + list + ") Site (" + web.Url + "): " + ex.Message + " " + HttpUtility.HtmlEncode(query) + "<br>");
            }
            return 0;
        }
    }
}