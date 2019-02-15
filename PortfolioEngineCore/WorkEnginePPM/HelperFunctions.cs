using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Runtime.Caching;
using EPMLiveCore.Helpers;
using CoreEditableFieldDisplay = EPMLiveCore.EditableFieldDisplay;

namespace WorkEnginePPM
{
    public class HelperFunctions
    {

        public static string AddXml(SPListItem li, ArrayList arrResourceExtIds)
        {

            string Start = "";
            string Finish = "";
            string Work = "";
            try
            {
                Start = ((DateTime)li["StartDate"]).ToString("s");
            }
            catch { }
            try
            {
                Finish = ((DateTime)li["DueDate"]).ToString("s");
            }
            catch { }
            try
            {
                if ((bool)li["Summary"])
                    Work = "0";
                else
                    Work = (float.Parse(li["Work"].ToString()) / arrResourceExtIds.Count).ToString();
            }
            catch { }

            if(!string.IsNullOrEmpty(Start) && !string.IsNullOrEmpty(Finish) && !string.IsNullOrEmpty(Work))
            {

                StringBuilder sendValue = new StringBuilder();
                sendValue.Append(@"<Item Id=""" + li.ParentList.ID + "." + li.ID + @""">");

                foreach(string res in arrResourceExtIds)
                {
                    sendValue.Append("<Resource Id=\"" + res + "\" StartDate=\"" + Start + "\" FinishDate=\"" + Finish + "\" Hours=\"" + Work + "\" />");
                }

                sendValue.Append(@"</Item>");

                return sendValue.ToString();
            }
            return "";
        }

        public static string getSessionInfo(Page page)
        {
            HttpCookie cok = page.Request.Cookies.Get("EPKSessionInfo");
            StringBuilder sb = new StringBuilder();

            if(cok != null)
            {
                if(cok["Username"] != "")
                {
                    cok.Expires = DateTime.Now.AddMinutes(30);
                    sb.Append("document.all(\"EPKDisplay\").HandleData(\"SetUserName\", \"" + cok["Username"] + "\");");
                    sb.Append("document.all(\"EPKDisplay\").HandleData(\"SetPassword\", \"" + cok["Password"] + "\");");
                    sb.Append("document.all(\"EPKDisplay\").HandleData(\"SetDomain\", \"" + cok["Domain"] + "\");");
                }
            }

            return sb.ToString();
        }

        public static string outputEPKControl(string sEpkurl, string sControl, string sParams, string resizable, Page page, string subPage = "", bool bTest = false)
        {
            string url = (SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : SPContext.Current.Web.ServerRelativeUrl;
            string sCABVersion = "45,0,0,900";
            string sCABRootUrl = ".";
            if(sControl == "WE_LMRPort.LMR_WE")
                sCABRootUrl = "/_layouts/ppm";
            //string sCABRootUrl = sEpkurl;
            return Properties.Resources.txtEPKWebpart.Replace("***EPKURL***", sCABRootUrl).Replace("***CONTROL***", sControl).Replace("***PAGE***", subPage).Replace("***PARAMS***", sParams).Replace("***TestMode***", bTest ? "Yes" : "No").Replace("***RESIZE***", resizable).Replace("***WEBURL***", url).Replace("***SessionInfo***", getSessionInfo(page)).Replace("***CABVERSION***", sCABVersion);
        }

        public static bool UseNonActiveXControl(string sControl, SPList list)
        {
            string s = "";

            SPWeb web = SPContext.Current.Web;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(web.Site.ID))
                {
                    string non = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_nonactivexs");
                    if(non == "")
                        non = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKnonactivexs");

                    s = "|" + non + "|";
                }
            });

            if (s.Length > 2)
            {
                if (s.Contains("|" + sControl + "|"))
                    return true;
            }
            return false;
        }

        public static string getProjectNameFromUID(string id)
        {
            string sProjectName = "";
            SPSecurity.RunWithElevatedPrivileges(delegate(){
                try
                {
                    string []sProjectUidArray = id.Split('.');
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (SPWeb web = site.OpenWeb(new Guid(sProjectUidArray[0])))
                        {
                            SPList list = web.Lists[new Guid(sProjectUidArray[1])];
                            SPListItem li = list.GetItemById(int.Parse(sProjectUidArray[2]));
                            sProjectName = li.Title;
                        }
                    }
                }
                catch { }
            });
            return sProjectName;
        }

        private static void prepareItemList(SPList list)
        {
            list.ParentWeb.AllowUnsafeUpdates = true;
            if (!list.Fields.ContainsField("ExternalID"))
            {
                list.Fields.Add("ExternalID", SPFieldType.Text, false);
                SPField f = list.Fields["ExternalID"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }
        }


        public static string processResourceDisable(XmlNode nd, SPList resList, out bool errors)
        {
            string message = "";
            string id = nd.Attributes["ID"].Value;

            try
            {

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='MAPID'/><Value Type='Text'>" + id + "</Value></Eq></Where>";

                SPListItemCollection lic = resList.GetItems(query);

                SPListItem liRes = null;
                if (lic.Count > 0)
                {

                    liRes = lic[0];

                    liRes["Disabled"] = true;

                    liRes.Update();
                }

                errors = false;
                message = "<Resource ID=\"" + id + "\" Error=\"0\"/>";
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Resource ID=\"" + id + "\" Error=\"102\"><![CDATA[Error Processing Resource: " + ex.Message + "]]></Resource>";
            }

            return message;
        }

        

        public static void prepareResList(SPList list)
        {
            if (!list.Fields.ContainsField("MAPID"))
            {
                list.Fields.Add("MAPID", SPFieldType.Text, false);
                SPField f = list.Fields["MAPID"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }

            if (!list.Fields.ContainsField("Disabled"))
            {
                list.Fields.Add("Disabled", SPFieldType.Text, false);
                SPField f = list.Fields["Disabled"];
                f.Hidden = true;
                f.Update();
                list.Update();
            }
        }

        public static string processResource(XmlNode nd, SPList resList, Hashtable hshFields, ref bool errors, string sPrefix)
        {
            string message = "";
            string id = nd.Attributes["ID"].Value;
            string sExtra = "";

            try
            {
                string title = nd.SelectSingleNode("Field[@ID=3000]").Attributes["Value"].Value;
                string username = "";
                string inactive = "";
                string generic = "";

                try
                {
                    username = nd.SelectSingleNode("Field[@ID=3014]").Attributes["Value"].Value;
                }
                catch { }
                try
                {
                    inactive = nd.SelectSingleNode("Field[@ID=3002]").Attributes["Value"].Value;
                }
                catch { }
                try
                {
                    generic = nd.SelectSingleNode("Field[@ID=3006]").Attributes["Value"].Value;
                }
                catch { }

                if (inactive == "1")
                    return processResourceDisable(nd, resList, out errors);

                SPPrincipal user = null;
                try
                {
                    if (generic == "1")
                        user = resList.ParentWeb.SiteGroups[title];
                    else
                        user = resList.ParentWeb.SiteUsers[sPrefix + username];
                }
                catch { }

                sExtra = "1";
                if (user == null && username != "")
                {
                    //DirectoryEntry de = ConfigFunctions.getUserFromAD(username);
                    sExtra = "1.1";
                    //if (de != null)
                    {
                        string email = "";
                        try
                        {
                            email = nd.SelectSingleNode("Field[@ID=3011]").Attributes["Value"].Value;
                            //email = de.Properties["mail"].Value.ToString();
                        }
                        catch { }

                        sExtra = "1.2";
                        string sDisplayName = "";
                        try
                        {
                            sDisplayName = title;// de.Properties["displayName"].Value.ToString();
                        }
                        catch
                        {
                            sDisplayName = username;
                        }
                        sExtra = "1.3";
                        resList.ParentWeb.SiteUsers.Add(sPrefix + username, email, sDisplayName, "");
                        sExtra = "1.4";
                        user = resList.ParentWeb.SiteUsers[sPrefix + username];
                    }
                }
                sExtra = "2";
                if (generic == "1" && user == null)
                {
                    resList.ParentWeb.SiteGroups.Add(title, resList.ParentWeb.CurrentUser, resList.ParentWeb.CurrentUser, "");
                    user = resList.ParentWeb.SiteGroups[title];
                }

                sExtra = "3";
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='MAPID'/><Value Type='Text'>" + id + "</Value></Eq></Where>";

                SPListItemCollection lic = resList.GetItems(query);
                sExtra = "4";

                if (lic.Count == 0 && user != null)
                {
                    try
                    {
                        query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='SharePointAccount' LookupId='True'/><Value Type='Lookup'>" + user.ID + "</Value></Eq></Where>";

                        lic = resList.GetItems(query);
                    }
                    catch { }
                }

                SPListItem liRes = null;
                if (lic.Count == 0)
                {
                    liRes = resList.Items.Add();
                }
                else
                {
                    liRes = lic[0];
                }
                sExtra = "5";

                string sRealUserName = "";
                if (liRes != null)
                {
                    sExtra = "6";
                    liRes["Title"] = title;
                    liRes["MAPID"] = id;
                    liRes["Disabled"] = false;
                    if (user != null)
                        liRes["SharePointAccount"] = user.ID;

                    foreach (XmlNode ndField in nd.SelectNodes("Field"))
                    {
                        string fld = ndField.Attributes["ID"].Value;
                        string val = ndField.Attributes["Value"].Value;

                        if (hshFields.Contains(fld))
                        {
                            string sfld = hshFields[fld].ToString();
                            if (resList.Fields.ContainsField(sfld))
                            {
                                SPField field = resList.Fields.GetFieldByInternalName(sfld);
                                if (field.Type == SPFieldType.User)
                                {
                                    liRes[sfld] = ConfigFunctions.getUserString(val, resList.ParentWeb, sPrefix);
                                }
                                else
                                    liRes[sfld] = val;
                            }
                        }
                    }

                    liRes.Update();
                    sExtra = "7";


                    if (liRes["SharePointAccount"] != null)
                    {
                        string sSPAccount = liRes["SharePointAccount"].ToString();
                        SPFieldUserValue uv = new SPFieldUserValue(resList.ParentWeb, sSPAccount);
                        sExtra = "8";
                        if (uv != null && uv.User != null && resList.ParentWeb.Site != null)
                            sRealUserName = EPMLiveCore.CoreFunctions.GetRealUserName(uv.User.LoginName, resList.ParentWeb.Site);
                        sExtra = "9";
                    }
                }

                errors = false;
                if (sRealUserName != "")
                    message = "<Resource ID=\"" + id + "\" Error=\"0\"><RealName><![CDATA[" + sRealUserName + "]]></RealName></Resource>";
                else
                    message = "<Resource ID=\"" + id + "\" Error=\"0\"/>";
            }
            catch (Exception ex)
            {
                errors = true;
                message = "<Resource ID=\"" + id + "\" Error=\"102\"><![CDATA[Error Processing Resource: " + ex.Message + "; Extra info: " + sExtra + "]]></Resource>";
            }

            return message;
        }

        public static string processPortfolioItem(SPWeb web, SPList list, string itemid, DataRow[] fields, string externalid, out bool errors)
        {
            Hashtable hshFields = new Hashtable();

            string sfields = "";

            sfields = EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "epk" + list.Title.Replace(" ", "") + "_fields");

            if(sfields == "")
                sfields = ConfigFunctions.getLockConfigSetting(web, "EPKPortfolioFields", false);

            if(sfields != "")
            {
                foreach(string field in sfields.Split('|'))
                {
                    string[] spField = field.Split(',');
                    if(spField[2] == "1" || spField[2] == "3")
                        hshFields.Add(spField[0], spField[1]);
                }
            }

            if(!hshFields.Contains("9900"))
                hshFields.Add("9900", "Title");

            string message = "";
            try
            {
                prepareItemList(list);

                SPListItem li = list.GetItemById(int.Parse(itemid));
                bool updated = false;

                foreach (DataRow dr in fields)
                {
                    string fname = dr["ID"].ToString();
                    string val = dr["Value"].ToString();

                    if(fname == "Team")
                    {
                        try
                        {
                            DataTable dtRes = GetResourcePool(web);

                            string[] sTeams = val.Split(',');

                            SPFieldUserValueCollection uvc = new SPFieldUserValueCollection();
                            try
                            {
                                uvc = new SPFieldUserValueCollection(web, li["AssignedTo"].ToString());
                            }
                            catch { }
                            foreach(string sTeam in sTeams)
                            {
                                try
                                {
                                    DataRow[] drRes = dtRes.Select("EXTID='" + sTeam + "'");
                                    SPUser u = web.AllUsers.GetByID(int.Parse(drRes[0]["SPID"].ToString()));
                                    SPFieldUserValue uv = new SPFieldUserValue(web, u.ID, u.Name);
                                    if (!uvc.Any(l => l.LookupId == uv.LookupId))
                                    {
                                        uvc.Add(uv);
                                        updated = true;
                                    }
                                }
                                catch { }
                            }

                            li["AssignedTo"] = uvc;
                        }
                        catch(Exception ex)
                        {
                        }
                    }
                    else if(hshFields.Contains(fname))
                    {
                        string sfld = hshFields[fname].ToString();
                        if(list.Fields.ContainsField(sfld))
                        {
                            if (!(li[sfld] == null && val == null || (li[sfld] != null && li[sfld].ToString() == val)
                                || (li[sfld] != null && li[sfld].ToString() == "False" && val == "0")
                                || (li[sfld] != null && li[sfld].ToString() == "True" && val == "1")
                                ))
                            {
                                li[sfld] = val;
                                updated = true;
                            }
                        }
                    }
                }

                if ((li["ExternalID"] == null && externalid != null)
                    || (li["ExternalID"] != null && li["ExternalID"].ToString() != externalid))
                {
                    li["ExternalID"] = externalid;
                    updated = true;
                }

                //using (SPWeb web = SPContext.Current.Web)
                {
                    web.AllowUnsafeUpdates = true;

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        if(updated)
                            li.SystemUpdate();
                    });

                    web.AllowUnsafeUpdates = false;
                }

                errors = false;
                message = "<Item ID=\"" + itemid + "\" Error=\"0\"/>";
            }
            catch(Exception ex)
            {
                errors = true;
                message = "<Item ID=\"" + itemid + "\" Error=\"102\"><![CDATA[Error Processing Item: " + ex.Message + "]]></Item>";
            }

            return message;
        }

        public static DataTable GetResourcePool(SPWeb web)
        {
            var memoryCache = MemoryCache.Default;

            if (!memoryCache.Contains("ResPoolDt_" + web.ID))
            {
                var expiration = DateTimeOffset.UtcNow.AddMinutes(20);
                var ResPoolDt = EPMLiveCore.API.APITeam.GetResourcePool("<Data><Columns>EXTID</Columns></Data>", web);

                memoryCache.Add("ResPoolDt_" + web.ID, ResPoolDt, expiration);
            }

            return memoryCache.Get("ResPoolDt_" + web.ID, null) as DataTable;

        }

        public static bool IsEditable(SPListItem listItem, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            try
            {
                Guard.ArgumentIsNotNull(fieldProperties, nameof(fieldProperties));
                Guard.ArgumentIsNotNull(field, nameof(field));

                const string EditKey = "Edit";
                const string EditableKey = "Editable";
                const string DisplaySettingsNever = "never";

                if (!fieldProperties[field.InternalName].ContainsKey(EditKey))
                {
                    return true;
                }

                var displaySettings = fieldProperties[field.InternalName][EditKey];
                var renderField = RenderField(listItem, field, displaySettings);

                if (!renderField)
                {
                    return false;
                }

                displaySettings = fieldProperties[field.InternalName][EditableKey];

                if (displaySettings.Split(";".ToCharArray())[0].Equals(DisplaySettingsNever, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                return RenderField(listItem, field, displaySettings);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            return true;
        }

        private static bool RenderField(SPListItem listItem, SPField field, string displaySettings)
        {
            const string SemiColon = ";";
            var renderField = true;

            if (displaySettings.Split(SemiColon.ToCharArray())[0].Equals("where", StringComparison.OrdinalIgnoreCase))
            {
                var whereField = displaySettings.Split(SemiColon.ToCharArray())[1];
                var conditionField = string.Empty;
                string condition;
                var groupField = string.Empty;
                var valueCondition = string.Empty;

                if (whereField.Equals("[Me]"))
                {
                    condition = displaySettings.Split(SemiColon.ToCharArray())[2];
                    groupField = displaySettings.Split(SemiColon.ToCharArray())[3];
                }
                else
                {
                    conditionField = displaySettings.Split(SemiColon.ToCharArray())[2];
                    condition = displaySettings.Split(SemiColon.ToCharArray())[3];
                    valueCondition = displaySettings.Split(SemiColon.ToCharArray())[4];
                }

                renderField = CoreEditableFieldDisplay.RenderField(
                    field,
                    whereField,
                    conditionField,
                    condition,
                    groupField,
                    valueCondition,
                    listItem);
            }

            return renderField;
        }
    }
}
