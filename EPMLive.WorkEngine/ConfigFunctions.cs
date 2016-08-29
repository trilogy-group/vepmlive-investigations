using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;

using System.Reflection;
using System.Resources;

using System.Xml;

using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;

using System.DirectoryServices;

namespace WorkEnginePPM
{

    public enum EPMLiveFeatureList { GridGantt, ResourcePlanner, WorkPlanner, Charting };

    public class ResourceStrings
    {
        private Hashtable hshResources = new Hashtable();
        private bool validLanguage = false;
        private string strError = "";
        public ResourceStrings(EPMLiveFeatureList feature, string lcid)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                Assembly assm = Assembly.GetExecutingAssembly();
                Stream stream = assm.GetManifestResourceStream("EPMLiveCore.LanguageFiles." + feature.ToString() + lcid + ".xml");
                if (stream == null)
                {
                    stream = assm.GetManifestResourceStream("EPMLiveCore.LanguageFiles." + feature.ToString() + "1033.xml");
                }
                StreamReader sr = new StreamReader(stream);
                doc.LoadXml(sr.ReadToEnd());
                foreach (XmlNode nd in doc.SelectNodes("/strings/string"))
                {
                    hshResources.Add(nd.Attributes["id"].Value, nd.InnerText);
                }
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
        }

        public string getLCName()
        {
            try
            {

            }
            catch { }
            return "Unknown Language";
        }

        public string lastError
        {
            get
            {
                return strError;
            }
        }

        public bool isValidLanguage
        {
            get
            {
                return validLanguage;
            }
        }

        public string getSetting(string resourceName)
        {
            try
            {
                return hshResources[resourceName].ToString();
            }
            catch
            {

            }
            return "";
        }
    }

    public enum QueueType { ResPlan = 1, TimeFix, Notifications, AdminListSynch, ReportingCleanup, ReportingSettings, AdminTemplateSynch, ReportingSnapshot }

    public class ConfigFunctions
    {

        static string saltValue = "f53fNDH@";
        static string hashAlgorithm = "SHA1";
        static int passwordIterations = 2;
        static string initVector = "77B2c3D4e1F3g7R1";
        static int keySize = 256;

        public static string GetCleanUsername(SPWeb web)
        {
            string username = string.Empty;
            //Added code for the Cost Planner Integration - EPML-5327
            if (web.CurrentUser == null)
                username = "sharepoint\\system";
            else
                username = web.CurrentUser.LoginName;
            if (username.ToLower() == "sharepoint\\system")
            {
                username = web.Site.WebApplication.ApplicationPool.Username;
            }
            else
            {
                if (username.Contains("\\"))
                    username = EPMLiveCore.CoreFunctions.GetJustUsername(username);
                else
                    username = EPMLiveCore.CoreFunctions.GetRealUserName(username, web.Site);
            }

            return username;
        }

        public static string GetCleanUsername(SPWeb web, string username)
        {
            if (username.ToLower() == "sharepoint\\system")
            {
                username = web.Site.WebApplication.ApplicationPool.Username;
            }
            else
            {
                if (username.Contains("\\"))
                    username = EPMLiveCore.CoreFunctions.GetJustUsername(username);
                else
                    username = EPMLiveCore.CoreFunctions.GetRealUserName(username, web.Site);
            }

            return username;
        }


        private static string getDomain()
        {
            string retVal = string.Empty;
            string domain = string.Empty;
            try
            {
                domain = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().ToString();
            }
            catch { }
            if (domain != string.Empty)
            {
                if (domain.Contains("."))
                {
                    string[] DCvals = domain.Split(".".ToCharArray()[0]);
                    foreach (string val in DCvals)
                    {
                        retVal = retVal + "DC=" + val + ",";
                    }
                    retVal = retVal.Remove(retVal.LastIndexOf(","));
                }
            }

            return retVal;
        }

        public static DirectoryEntry getUserFromAD(string username)
        {
            DirectoryEntry deUser = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                if (username.IndexOf("\\") > 0)
                    username = username.Substring(username.IndexOf("\\") + 1);

                string domain = getDomain();
                if (domain != string.Empty)
                {
                    DirectoryEntry de = new DirectoryEntry();
                    de.Path = "LDAP://" + domain;
                    de.AuthenticationType = AuthenticationTypes.Secure;

                    DirectorySearcher deSearch = new DirectorySearcher();

                    deSearch.SearchRoot = de;
                    deSearch.Filter = "(&(objectClass=user) (samAccountName=" + username + "))";

                    SearchResultCollection results = deSearch.FindAll();

                    if (results.Count > 0)
                    {
                        SearchResult sr = results[0];
                        deUser = sr.GetDirectoryEntry();
                    }
                }
            });

            return deUser;
        }

        public static string getUserString(string usernames, SPWeb web, string sPrefix)
        {
            string[] users = usernames.Split(',');

            string sUsernameString = "";

            foreach (string username in users)
            {
                if (username != "")
                {
                    SPUser oUser = null;
                    try
                    {
                        oUser = web.SiteUsers[sPrefix + username];
                    }
                    catch { }
                    if (oUser == null && username != "")
                    {
                        DirectoryEntry de = getUserFromAD(username);
                        if (de != null)
                        {
                            string email = "";
                            try
                            {
                                email = de.Properties["mail"].Value.ToString();
                            }
                            catch { }

                            web.SiteUsers.Add(username, email, de.Properties["displayName"].Value.ToString(), "");
                            oUser = web.SiteUsers[username];
                        }
                    }

                    sUsernameString += ";#" + oUser.ID + ";#" + oUser.Name;
                }
            }

            if (sUsernameString.Length > 1)
                sUsernameString = sUsernameString.Substring(2);

            return sUsernameString;
        }




        public static SPField getRealField(SPField field)
        {
            try
            {
                if (field.Type == SPFieldType.Computed)
                {
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(field.SchemaXml);

                        string parentField = "";
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != "")
                        {
                            try
                            {
                                field = field.ParentList.Fields.GetFieldByInternalName(parentField);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return field;
        }

        public static DataTable getSiteItems(SPWeb web, SPView view, string spquery, string filterfield, string usewbs, string rlist, string[] arrGroupFields)
        {
            DataTable dt = null;
            string lists = "";
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                //using (SPSite s = SPContext.Current.Site)
                {
                    string dbCon = web.Site.ContentDatabase.DatabaseConnectionString;
                    cn = new SqlConnection(dbCon);
                    cn.Open();
                }
            });

            if (cn.State == ConnectionState.Open)
            {

                try
                {
                    string siteurl = web.ServerRelativeUrl.Substring(1);

                    ArrayList arr = new ArrayList();
                    string dqFields = "";
                    foreach (string field in view.ViewFields)
                    {
                        SPField f = getRealField(view.ParentList.Fields.GetFieldByInternalName(field));
                        arr.Add(f.InternalName.ToLower());
                        dqFields += "<FieldRef Name='" + f.InternalName + "' Nullable='TRUE'/>";
                    }
                    foreach (string groupby in arrGroupFields)
                    {
                        if (!arr.Contains(groupby.ToLower()))
                        {
                            arr.Add(groupby.ToLower());
                            dqFields += "<FieldRef Name='" + groupby + "' Nullable='TRUE'/>";
                        }
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<Where>" + spquery + "</Where>");
                    XmlNode nl = doc.FirstChild.SelectSingleNode("//OrderBy");
                    if (nl != null)
                    {
                        foreach (XmlNode nd in nl.ChildNodes)
                        {
                            string fname = nd.Attributes["Name"].Value;
                            if (!arr.Contains(fname.ToLower()))
                            {
                                arr.Add(fname.ToLower());
                                dqFields += "<FieldRef Name='" + fname + "' Nullable='TRUE'/>";
                            }
                        }
                    }

                    if (!arr.Contains("title") && view.ParentList.Fields.ContainsField("Title"))
                    {
                        dqFields += "<FieldRef Name='Title' Nullable='TRUE'/>";
                    }
                    if (!arr.Contains("created"))
                    {
                        dqFields += "<FieldRef Name='Created'/>";
                    }
                    if (!arr.Contains("_moderationstatus"))
                    {
                        dqFields += "<FieldRef Name='_ModerationStatus' Nullable='TRUE'/>";
                    }
                    if (filterfield != null && filterfield != "")
                    {
                        if (!arr.Contains(filterfield.ToLower()))
                        {
                            dqFields += "<FieldRef Name='" + filterfield + "' Nullable='TRUE'/>";
                        }
                    }
                    if (usewbs != null && usewbs != "")
                    {
                        if (!arr.Contains(usewbs.ToLower()))
                        {
                            dqFields += "<FieldRef Name='" + usewbs + "' Nullable='TRUE'/>";
                        }
                    }
                    if (!arr.Contains("list"))
                    {
                        dqFields += "<FieldRef Name='List' Nullable='TRUE'/>";
                    }

                    try
                    {
                        lists = "";
                        string query = "";
                        if (rlist != "")
                        {
                            if (siteurl == "")
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                            else
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";

                            SqlCommand cmd = new SqlCommand(query, cn);
                            //cmd.Parameters.AddWithValue("@rlist", rlist);
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                            }
                            dr.Close();
                        }
                        else
                        {
                            lists = "<List ID='" + view.ParentList.ID + "'/>";
                        }


                        if (lists != "")
                        {
                            SPSiteDataQuery dq = new SPSiteDataQuery();
                            dq.Lists = "<Lists MaxListLimit='0'>" + lists + "</Lists>";
                            dq.Query = spquery;
                            dq.QueryThrottleMode = SPQueryThrottleOption.Override;
                            if (rlist != "")
                                dq.Webs = "<Webs Scope='Recursive'/>";

                            dq.ViewFields = dqFields;
                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(delegate()
                                {
                                    dt = web.GetSiteData(dq);
                                });
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Error getting site data: " + ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error getting site data lists: " + ex.Message);
                    }

                    cn.Close();
                }
                catch { }
                cn.Close();
            }

            return dt;
        }

        private static string addTeam(SPListItem li, SPItemEventDataCollection properties)
        {
            DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<Resources><Columns>EXTID</Columns></Resources>", li.ParentList.ParentWeb);

            string team = "";

            try
            {
                string users = "";
                if (properties["AssignedTo"] == null)
                    users = li[li.ParentList.Fields.GetFieldByInternalName("AssignedTo").Id].ToString();
                else
                    users = properties["AssignedTo"].ToString();

                SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(li.ParentList.ParentWeb, users);

                foreach (SPFieldUserValue uv in uvc)
                {
                    try
                    {
                        DataRow[] dr = dtResources.Select("SPID='" + uv.LookupId + "'");
                        if (dr.Length > 0)
                        {
                            if (dr[0]["EXTID"].ToString() != "")
                            {
                                team += "," + dr[0]["EXTID"].ToString();
                            }
                        }
                    }
                    catch { }
                }

                team = team.Trim(',');
            }
            catch { }

            if (team != "")
                return "<Team>" + team + "</Team>";
            else
                return "<Team></Team>";

        }

        public static string getItemXml(SPListItem li, Hashtable hshFields, SPItemEventDataCollection properties, SPWeb web)
        {
            SPList list = li.ParentList;

            string xml = "<Item EXTID=\"" + list.ParentWeb.ID + "." + list.ID + "." + li.ID + "\" ListID=\"" + li.ParentList.Title + "\">";
            string title = li.Title;
            try
            {
                if (properties["Title"] != null)
                    title = properties["Title"].ToString();
            }
            catch { }

            xml += "<Title><![CDATA[" + title + "]]></Title>";
            xml += addTeam(li, properties);

            foreach (DictionaryEntry field in hshFields)
            {
                string spfield = field.Value.ToString();
                string epkfield = field.Key.ToString();
                SPField oField = null;
                try
                {
                    oField = list.Fields.GetFieldByInternalName(spfield);
                }
                catch { }

                if (oField != null)
                {
                    try
                    {
                        string val = "";
                        try
                        {
                            val = oField.GetFieldValue(li[oField.Id].ToString()).ToString();
                        }
                        catch { }
                        if (oField.Type == SPFieldType.Lookup)
                        {
                            if (properties[spfield] != null)
                            {
                                try
                                {
                                    SPList lookUpList = web.Lists[new Guid(((SPFieldLookup)oField).LookupList)];
                                    val = lookUpList.GetItemById(Convert.ToInt32(properties[spfield])).Title;
                                }
                                catch
                                {
                                    val = oField.GetFieldValueAsText(li[oField.Id].ToString()).ToString();
                                }
                            }
                            else
                            {
                                val = oField.GetFieldValueAsText(li[oField.Id].ToString()).ToString();
                            }
                        }
                        else if (oField.Type == SPFieldType.DateTime)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                {
                                    if (properties[spfield].ToString() != "")
                                    {

                                        try
                                        {
                                            val = DateTime.Parse(properties[spfield].ToString()).ToUniversalTime().ToString("s");
                                        }
                                        catch
                                        {
                                            val = DateTime.ParseExact(properties[spfield].ToString(), "yyyy-M-dTH:m:sZ", new System.Globalization.CultureInfo(web.Locale.LCID).DateTimeFormat).ToUniversalTime().ToString("s");
                                        }
                                    }
                                    else
                                        val = "";
                                }
                                else
                                    val = ((DateTime)li[oField.Id]).ToUniversalTime().ToString("s");
                            }
                            catch { }
                        }
                        else if (oField.Type == SPFieldType.User)
                        {
                            SPFieldUser uf = (SPFieldUser)li.Fields.GetFieldByInternalName(spfield);
                            try
                            {
                                if (properties[spfield] != null)
                                    val = properties[spfield].ToString();
                            }
                            catch { }
                            string newval = "";
                            try
                            {
                                if (uf.AllowMultipleValues)
                                {
                                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(web, val);
                                    foreach (SPFieldUserValue uv in uvc)
                                    {
                                        newval += "," + EPMLiveCore.CoreFunctions.GetRealUserName(uv.User.LoginName, web.Site);
                                    }
                                }
                                else
                                {
                                    SPFieldUserValue uv = new SPFieldUserValue(web, val);
                                    newval = EPMLiveCore.CoreFunctions.GetRealUserName(uv.User.LoginName, web.Site);
                                }
                            }
                            catch
                            {
                                try
                                {
                                    newval = EPMLiveCore.CoreFunctions.GetRealUserName(web.AllUsers[oField.GetFieldValueAsText(properties[spfield].ToString())].LoginName, web.Site);
                                }
                                catch { }
                            }
                            val = newval.Trim(',');
                        }
                        else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = properties[spfield].ToString();
                            }
                            catch { }
                        }
                        else if (oField.Type == SPFieldType.Boolean)
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = properties[spfield].ToString();
                            }
                            catch { }

                            if (val == "True")
                                val = "1";
                            else
                                val = "0";
                        }
                        else if (oField.Type == SPFieldType.Calculated)
                        {
                            val = oField.GetFieldValueAsText(val);
                        }
                        else
                        {
                            try
                            {
                                if (properties[spfield] != null)
                                    val = oField.GetFieldValue(properties[spfield].ToString()).ToString();
                            }
                            catch { }
                        }
                        xml += "<Field Name=\"" + epkfield + "\"><![CDATA[" + val + "]]></Field>";
                    }
                    catch { }
                }
            }

            xml += "</Item>";

            return xml;
        }

        private static string getMenuFromAssembly(string assembly, string aclass)
        {
            AssemblyName asm = new AssemblyName(assembly);
            Assembly u = Assembly.Load(asm);
            Type t = u.GetType(aclass);

            if (t != null)
            {
                MethodInfo m = t.GetMethod("GetMenu");
                if (m != null)
                {
                    //if (parameters.Length >= 1)
                    //{
                    //    //object[] myparam = new object[1];
                    //    //myparam[0] = parameters;
                    //    return (string)m.Invoke(null, null);
                    //}
                    //else
                    return (string)m.Invoke(null, null);
                }
            }
            Exception ex = new Exception("method/class not found");
            throw ex;
        }

        public static string getFarmSetting(string setting)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPFarm farm = SPFarm.Local;
                    cn = farm.Properties[setting].ToString();
                }
                catch { }
            });
            if (cn == "")
            {
                switch (setting)
                {
                    case "PollingInterval":
                        cn = "10";
                        break;
                    case "QueueThreads":
                        cn = "5";
                        break;
                };
            }
            return cn;
        }

        public static string setFarmSetting(string setting, string value)
        {
            string cn = "";
            try
            {
                SPFarm farm = SPFarm.Local;

                if (farm.Properties.ContainsKey(setting))
                    farm.Properties[setting] = value;
                else if (value.Length > 0)
                    farm.Properties.Add(setting, value);
                farm.Update();
            }
            catch { }
            return cn;
        }

        public static string getWebAppSetting(Guid gWebApp, string setting)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                    cn = webapp.Properties[setting].ToString();
                }
                catch { }
                if (cn == "")
                {
                    try
                    {
                        cn = System.Configuration.ConfigurationManager.AppSettings[setting];
                        if (cn != "")
                            setWebAppSetting(gWebApp, setting, cn);

                    }
                    catch { }
                }
            });
            return cn;
        }

        public static void setWebAppSetting(Guid gWebApp, string setting, string value)
        {
            try
            {
                SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                if (webapp.Properties.ContainsKey(setting))
                    webapp.Properties[setting] = value;
                else if (value.Length > 0)
                    webapp.Properties.Add(setting, value);
                webapp.Update();
            }
            catch { }
        }
        public static string getListSetting(SPList list, string setting)
        {
            if (list == null)
                return "";

            SPField f = null;
            try
            {
                f = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
            }
            catch { }
            if (f == null)
            {
                if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                {
                    try
                    {
                        list.ParentWeb.AllowUnsafeUpdates = true;
                        f = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                        f.Hidden = true;
                        list.Fields.Add(f);
                        f.Update();
                        list.Update();
                    }
                    catch { }
                }
                switch (setting)
                {
                    case "TotalSettings":
                        return getConfigSetting(list.ParentWeb, "epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url));
                    case "GeneralSettings":
                        return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-GridSettings");
                    case "DisplaySettings":
                        return getConfigSetting(list.ParentWeb, String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url)));
                    case "EnableResourcePlan":
                        return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-EnableResPlan");
                    default:
                        return "";
                };
            }
            else
            {
                try
                {

                    string val = "";
                    switch (setting)
                    {
                        case "TotalSettings":
                            val = f.GetCustomProperty(setting).ToString();
                            break;
                        case "GeneralSettings":
                            val = f.GetCustomProperty(setting).ToString();
                            break;
                        case "DisplaySettings":
                            val = f.GetCustomProperty(setting).ToString();
                            break;
                        case "EnableResourcePlan":
                            val = f.GetCustomProperty(setting).ToString();
                            break;
                    }
                    if (val == "")
                    {
                        switch (setting)
                        {
                            case "TotalSettings":
                                return getConfigSetting(list.ParentWeb, "epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url));
                            case "GeneralSettings":
                                return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-GridSettings");
                            case "DisplaySettings":
                                return getConfigSetting(list.ParentWeb, String.Format("DisplaySetting{0}", System.IO.Path.GetDirectoryName(list.DefaultView.Url)));
                            case "EnableResourcePlan":
                                return getConfigSetting(list.ParentWeb, System.IO.Path.GetDirectoryName(list.DefaultView.Url) + "-EnableResPlan");
                            default:
                                return "";
                        };
                    }
                    else
                        return val;
                }
                catch { }
            }
            return "";
        }
        public static string getConnectionString(Guid gWebApp)
        {
            string cn = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                    cn = webapp.Properties["epmlivecn"].ToString();
                }
                catch { }
                if (cn == "")
                {
                    try
                    {
                        string sError = "";
                        cn = System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString;
                        if (cn != "")
                            setConnectionString(gWebApp, cn, out sError);

                    }
                    catch { }
                }
            });
            return cn;
        }

        public static bool setConnectionString(Guid gWebApp, string cn, out string sError)
        {
            sError = "";
            try
            {
                SPWebApplication webapp = SPWebService.ContentService.WebApplications[gWebApp];
                if (webapp.Properties.ContainsKey("epmlivecn"))
                    webapp.Properties["epmlivecn"] = cn;
                else if (cn.Length > 0)
                    webapp.Properties.Add("epmlivecn", cn);
                webapp.Update();
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            return true;
        }



        public static void setConfigSetting(SPWeb web, string setting, string value)
        {
            if (value == "")
            {
                if (web.Properties.ContainsKey(setting))
                    web.Properties[setting] = null;
            }
            else
            {

                if (web.Properties.ContainsKey(setting))
                    web.Properties[setting] = value;
                else if (value.Length > 0)
                    web.Properties.Add(setting, value);
            }
            web.Properties.Update();
            //SPList list = null;
            //try
            //{
            //    list = web.Lists["EPMLiveConfig"];
            //}
            //catch { }

            //if (list == null)
            //{
            //    Guid lGuid = web.Lists.Add("EPMLiveConfig", "", SPListTemplateType.GenericList);
            //    list = web.Lists[lGuid];
            //    list.Hidden = true;
            //    list.Fields.Add("Value", SPFieldType.Text, true);
            //    list.Update();
            //}

            //if (list != null)
            //{
            //    SPQuery query = new SPQuery();
            //    query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + setting + "</Value></Eq></Where>";

            //    try
            //    {
            //        SPListItemCollection liCol = list.GetItems(query);
            //        if (liCol.Count <= 0)
            //        {
            //            SPListItem li = list.Items.Add();
            //            li["Title"] = setting;
            //            li["Value"] = value;
            //            li.Update();
            //        }
            //        else
            //        {
            //            SPListItem li = liCol[0];
            //            li["Value"] = value;
            //            li.Update();
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        private static Guid iGetLockedWeb(SPWeb web)
        {
            if (web == null)
                return Guid.Empty;

            Guid lweb = iGetLockedWeb(web.ParentWeb);

            if (lweb == Guid.Empty)
                if (getConfigSetting(web, "EPMLiveLockConfig") == "True")
                    return web.ID;


            return lweb;

            //if (ParentWeb == null)
            //    return Guid.Empty;
            //if (getConfigSetting(ParentWeb, "EPMLiveLockConfig") == "True")
            //    return ParentWeb.ID;
            //else if (ParentWeb.ParentWeb == null)
            //    return Guid.Empty;
            //else
            //    return getLockedWeb(ParentWeb.ParentWeb);

        }

        public static Guid getLockedWeb(SPWeb web)
        {
            Guid lWeb = iGetLockedWeb(web);
            if (lWeb == Guid.Empty)
                lWeb = web.ID;
            return lWeb;
        }

        public static string getConfigSetting(SPWeb web, string setting, bool translateUrl, bool isRelative)
        {
            string val = iGetConfigSetting(web, setting, translateUrl, isRelative);

            if (val == "")
            {
                switch (setting)
                {
                    case "EPMLiveClients":
                        return "E6824613-A011-42e5-AB7E-0A747B3D4DCD";
                    case "EPMLiveTSTimesheetHours":
                        return "Number15";
                    case "EPMLiveTSFlag":
                        return "Flag15";
                    case "EPMLiveTSAllowUnassigned":
                        return "True";
                    case "EPMLiveDaySettings":
                        return "false|0|24|true|0|24|true|0|24|true|0|24|true|0|24|true|0|24|false|0|24";
                    case "EPMLiveTSUseCurrent":
                        return "True";

                    case "EPMLiveWPProjectCenter":
                        return "Project Center";
                    case "EPMLiveWPTaskCenter":
                        return "Task Center";
                    case "EPMLiveWPEnable":
                        return "True";
                    case "EPMLiveWPUseResPool":
                        return "True";

                    case "EPMLiveAgileProjectCenter":
                        return "Project Center";
                    case "EPMLiveAgileTaskCenter":
                        return "Task Center";
                    case "EPMLiveAgileUseResPool":
                        return "True";

                    case "EPMLiveResourcePool":
                        return "Resources";

                    case "epmlivepub-useres":
                        return "True";

                    case "ReportsAuthMode":
                        return "Windows";

                    case "EPMLivePublisherProjectCenter":
                        return "Project Center";
                    case "EPMLivePublisherTaskCenter":
                        return "Task Center";

                    case "EPMLivePSWebAppProjectCenter":
                        return "Project Center";
                    case "EPMLivePSWebAppTaskCenter":
                        return "Task Center";
                    case "EPMLivePSWebAppEnable":
                        return "True";
                };
            }

            return val;
        }

        public static string getConfigSetting(SPWeb web, string setting)
        {
            return getConfigSetting(web, setting, true, true);

        }

        public static string getLockConfigSetting(SPWeb web, string setting, bool isRelative)
        {
            Guid lockWeb = getLockedWeb(web);
            string val = "";
            if (lockWeb != Guid.Empty && lockWeb != web.ID)
            {
                using (SPSite site = SPContext.Current.Site)
                {
                    using (SPWeb w = site.OpenWeb(lockWeb))
                    {
                        val = getConfigSetting(w, setting, true, isRelative);
                    }
                }
            }
            else
            {
                val = getConfigSetting(web, setting, true, isRelative);
            }
            return val;
        }

        private static string iGetConfigSetting(SPWeb web, string setting, bool translateUrl, bool isRelative)
        {
            string prop = "";
            if (setting.Contains("URL") || setting == "EPMLiveUseResourcePool")
            {
                Guid lockWeb = getLockedWeb(web);
                if (lockWeb != Guid.Empty)
                {
                    Guid siteId = web.Site.ID;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite site = new SPSite(siteId))
                        {
                            SPWeb rweb = site.OpenWeb(lockWeb);
                            if (rweb.Properties.ContainsKey(setting))
                                prop = rweb.Properties[setting];

                            if (translateUrl)
                            {
                                if (isRelative)
                                    prop = prop.Replace("{Site}", rweb.ServerRelativeUrl);
                                else
                                    prop = prop.Replace("{Site}", rweb.Url);
                            }

                            rweb.Close();
                        }
                    });
                }
                else
                {
                    if (web.Properties.ContainsKey(setting))
                    {
                        prop = web.Properties[setting];
                        if (translateUrl)
                        {
                            if (isRelative)
                                prop = prop.Replace("{Site}", web.ServerRelativeUrl);
                            else
                                prop = prop.Replace("{Site}", web.Url);
                        }
                    }
                }
            }
            else
                if (web.Properties.ContainsKey(setting))
                    prop = web.Properties[setting];

            return prop;

        }



        public static string farmEncode(string code)
        {
            string computer = SPFarm.Local.Id.ToString();
            string actCode = "";
            int counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }

        public static string computerCode(string code)
        {
            string computer = System.Net.Dns.GetHostName();
            string actCode = "";
            int counter = 0;
            for (int i = 0; i < code.Length; i++)
            {
                if (counter + 1 >= computer.Length)
                    counter = 0;
                actCode = actCode + (computer[counter++] ^ code[i]);
            }
            return actCode;
        }

        public static string Encrypt(string plainText, string passPhrase)
        {

            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch { return ""; }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes("77B2c3D4e1F3g7R1");
                byte[] saltValueBytes = Encoding.ASCII.GetBytes("f53fNDH@");
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                "SHA1",
                                                                2);

                byte[] keyBytes = password.GetBytes(256 / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
                return plainText;
            }
            catch { return ""; }
        }

        public static void deleteKey(string key)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPWeb web = SPContext.Current.Web)
                {
                    web.AllowUnsafeUpdates = true;
                    SPSite site = web.Site;
                    SPFarm farm = site.WebApplication.Farm;

                    string newkeys = "";
                    try
                    {
                        string[] keys = farm.Properties["EPMLiveKeys"].ToString().Split('\t');

                        for (int i = 0; i < keys.Length; i = i + 2)
                        {
                            if (keys[i] != key)
                            {
                                newkeys += "\t" + keys[i] + "\t" + keys[i + 1];
                            }
                        }

                        if (newkeys.Length > 1)
                            newkeys = newkeys.Substring(1);

                        farm.Properties["EPMLiveKeys"] = newkeys;
                        farm.Update();
                    }
                    catch { }
                }
            });
        }

        //private static void doDelete(string key,SPIisSettings iis)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(iis.Path + "\\bin\\EPMLive.lic");
        //        foreach (XmlNode nd in doc.FirstChild.ChildNodes)
        //        {
        //            try
        //            {
        //                string val = nd.Attributes["value"].Value;
        //                if (val.Trim() == key.Trim())
        //                {
        //                    doc.FirstChild.RemoveChild(nd);
        //                }
        //            }
        //            catch { }
        //        }
        //        StreamWriter sw = new StreamWriter(iis.Path + "\\bin\\EPMLive.lic", false);
        //        sw.Write(doc.OuterXml);
        //        sw.Close();
        //    }
        //    catch { }
        //}

        public static string[] featureList()
        {
            ArrayList list = new ArrayList();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    string keys = "";
                    try
                    {
                        keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                    }
                    catch { }

                    if (keys == "")
                    {
                        try
                        {
                            keys = SPFarm.Local.Properties["EPMLiveKeys"].ToString();
                        }
                        catch { }
                    }
                    if (keys != "")
                    {
                        string[] arrKeys = keys.Split('\t');
                        for (int i = 0; i < arrKeys.Length; i = i + 2)
                        {
                            if (arrKeys[i] != "")
                            {
                                string val = arrKeys[i];
                                string s = arrKeys[i + 1];
                                if (farmEncode(val) == s)
                                {
                                    if (!list.Contains(val))
                                        list.Add(val);
                                }
                            }
                        }
                    }



                    //foreach (XmlNode nd in doc.FirstChild.ChildNodes)
                    //{
                    //    try
                    //    {
                    //        string val = nd.Attributes["value"].Value;
                    //        string s = nd.InnerText;
                    //        if (EPMLiveCore.CoreFunctions.computerCode(val) == s)
                    //        {
                    //            if(!list.Contains(val))
                    //                list.Add(val);
                    //        }
                    //    }
                    //    catch { }
                    //}
                }
                catch
                {

                }
            });
            return (string[])list.ToArray(typeof(string));
        }

        public static void enqueue(Guid timerjobuid, int defaultstatus)
        {
            using (SPSite site = SPContext.Current.Site)
            {
                enqueue(timerjobuid, defaultstatus, site);
            }
        }

        public static void enqueue(Guid timerjobuid, int defaultstatus, SPSite site)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(getConnectionString(site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand("select status from queue where timerjobuid=@timerjobuid", cn);
                cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                SqlDataReader dr = cmd.ExecuteReader();

                int status = 2;

                if (dr.Read())
                {
                    status = dr.GetInt32(0);
                }

                dr.Close();

                if (status == 2)
                {
                    cmd = new SqlCommand("DELETE FROM QUEUE where timerjobuid = @timerjobuid ", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO QUEUE (timerjobuid, status, percentcomplete) VALUES (@timerjobuid, @status, 0) ", cn);
                    cmd.Parameters.AddWithValue("@timerjobuid", timerjobuid);
                    cmd.Parameters.AddWithValue("@status", defaultstatus);
                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            });
        }
    }
}
