using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Reflection;

using Microsoft.SharePoint.WebPartPages;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;

namespace EPMLiveSynch
{
    public class SynchJob : EPMLiveCore.API.BaseJob
    {
        private SPWeb oFromWeb;
        private SPList oFromList;

        private string sLeftPadding = "";
        private bool bCreateNewList = false;
        private char[] chrCRSeparator = new char[] { '\r' };
        private char[] chrPipeSeparator = new char[] { '|' };
        private char[] chrColonSeparator = new char[] { ':' };
        private char[] chrCommaSeparator = new char[] { ',' };
        private string[] strHTML_BR_Separator = new string[] { "<br>" };
        private string sEPMLiveTemplateSyncItems;

        public SynchJob()
        {
        }

        public string EPMLiveTemplateSyncItems
        {
            get { return sEPMLiveTemplateSyncItems; }
            set { sEPMLiveTemplateSyncItems = value; }
        }

        public bool CreateNewList
        {
            get { return bCreateNewList; }
            set { bCreateNewList = value; }
        }

        public SPWeb FromWeb
        {
            get { return oFromWeb; }
            set { oFromWeb = value; }
        }

        public SqlConnection conn
        {
            get { return cn; }
            set { cn = value; }
        }

        public void execute(SPSite site, SPWeb web, string sListName)
        {
            percentInterval = 1;

            SPList oCurrList = web.Lists[base.ListUid];

            CreateNewList = false;
            try
            {
                string creatnew = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncCreateNew-" + System.IO.Path.GetDirectoryName(oCurrList.DefaultView.ServerRelativeUrl));
                if(creatnew == "")
                    CreateNewList = false;
                else
                    CreateNewList = bool.Parse(creatnew);
            }
            catch { }
            
            FromWeb = web;

            sListName = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncAltListName-" + System.IO.Path.GetDirectoryName(oCurrList.DefaultView.ServerRelativeUrl));
            if(sListName == "")
                sListName = oCurrList.Title;

            try
            {
                string sSiteGuid = web.Site.ID.ToString();
                oFromList = oCurrList;
                ListSyncher oListSyncher = new ListSyncher();
                oListSyncher.oFromList = oFromList;
                oListSyncher.FromWeb = oFromWeb;
                oListSyncher.ListName = sListName;
                oListSyncher.CreateNewList = this.CreateNewList;
                oListSyncher.SynchronizationType = SyncItemBaseType.SyncType.List;
                oListSyncher.bErrors = false;

                string sURL = FromWeb.ServerRelativeUrl;
                //LogHelper logHlpr = new LogHelper();

                if (oFromList != null)
                {
                    EPMLiveCore.CoreFunctions.setListSetting("TotalSettings", EPMLiveCore.CoreFunctions.getListSetting("TotalSettings", oFromList), oFromList);
                    EPMLiveCore.CoreFunctions.setListSetting("GeneralSettings", EPMLiveCore.CoreFunctions.getListSetting("GeneralSettings", oFromList), oFromList);
                    EPMLiveCore.CoreFunctions.setListSetting("DisplaySettings", EPMLiveCore.CoreFunctions.getListSetting("DisplaySettings", oFromList), oFromList);
                    EPMLiveCore.CoreFunctions.setListSetting("EnableResourcePlan", EPMLiveCore.CoreFunctions.getListSetting("EnableResourcePlan", oFromList), oFromList);
                }

                string dbCon = web.Site.ContentDatabase.DatabaseConnectionString;
                SqlConnection cnWss = new SqlConnection(dbCon);
                cnWss.Open();

                string siteurl = web.ServerRelativeUrl.Substring(1);

                string query = "";
                if (siteurl != "")
                    query = "SELECT   id from webs   WHERE     (FullUrl LIKE '" + siteurl + "/%')";
                else
                    query = "SELECT   id from webs   WHERE     (siteid = '" + web.Site.ID + "' and parentwebid is not null)";

                SqlCommand cmd = new SqlCommand(query, cnWss);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                cnWss.Close();


                totalCount = ds.Tables[0].Rows.Count;
                float webCount = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        using (SPWeb subWeb = web.Site.OpenWeb(new Guid(dr[0].ToString())))
                        {
                            if (subWeb.Properties.ContainsKey("EPMLiveAllowListSynch"))
                            {
                                bool bAllowListSynch = bool.Parse(subWeb.Properties["EPMLiveAllowListSynch"]);
                                if (bAllowListSynch)
                                {
                                    sErrors += "Web: " + subWeb.Title + " (" + subWeb.ServerRelativeUrl + ") - " + DateTime.Now.ToLongTimeString() + "<br>";

                                    subWeb.AllowUnsafeUpdates = true;

                                    oListSyncher.Results = "";
                                    
                                    oListSyncher.ToWeb = subWeb;
                                    subWeb.AllowUnsafeUpdates = true;
                                    uint LCID = subWeb.RegionalSettings.LocaleId;
                                    subWeb.RegionalSettings.LocaleId = web.RegionalSettings.LocaleId;
                                    subWeb.Update();
                                    
                                    oListSyncher.Sync();

                                    subWeb.AllowUnsafeUpdates = true;
                                    subWeb.RegionalSettings.LocaleId = LCID;
                                    subWeb.Update();

                                    sErrors += oListSyncher.Results;

                                    if(oListSyncher.bErrors)
                                        this.bErrors = true;
                                }
                            }
                            subWeb.Close();
                            subWeb.Dispose();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }
                    catch (Exception exc)
                    {
                        bErrors = true;
                        sErrors += "<br><br>General Error: " + exc.Message;
                    }
                    updateProgress(webCount++);
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<br><br>General Error: " + ex.Message;
            }
        }

        private object createObjectFromClassName(string sQualifiedClassName, object oParams)
        {
            try
            {
                Type tClassType;
                Assembly asm = Assembly.GetExecutingAssembly();
                string sAssemblyShortName = asm.FullName.Substring(0, asm.FullName.IndexOf(","));
                tClassType = asm.GetType(sAssemblyShortName + "." + sQualifiedClassName);
                if (tClassType != null)
                {
                    return System.Activator.CreateInstance(tClassType, oParams);
                }
                else
                {
                    throw new ApplicationException("Class " + sQualifiedClassName + " could not be loaded.");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        public string GetTemplateList(SPSite site)
        {
            string sTemplatesList = "";
            try
            {
                foreach (SPWeb subWeb in site.AllWebs)
                {
                    if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                    {
                        string sIDs = subWeb.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                        if (sIDs != null && sIDs.Contains(subWeb.ID.ToString()))
                        {
                            sTemplatesList += "|" + subWeb.Title + "`" + subWeb.ID.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return sTemplatesList;
        }
    }
}
