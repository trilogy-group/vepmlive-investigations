using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Xml;
using System.Linq;
using EPMLiveCore;
using EPMLiveCore.PfeData;
using System.Data.Common;
using System.Collections.Concurrent;

namespace TimeSheets
{
    public class SPRunWithoutEventsFiringEventReceiver : SPItemEventReceiver
    {
        #region Methods
        public void DisableEvents()
        {
            this.EventFiringEnabled = false;
        }

        public void EnableEvents()
        {
            this.EventFiringEnabled = true;
        }
        #endregion
    }
    public static class SPUtilities
    {
        public delegate void RunWithoutEventsFiringDelegate();

        public static void RunWithoutEventsFiring(RunWithoutEventsFiringDelegate code)
        {
            SPRunWithoutEventsFiringEventReceiver eventReceiver = new SPRunWithoutEventsFiringEventReceiver();
            try
            {
                eventReceiver.DisableEvents();
                code();
            }
            finally
            {
                eventReceiver.EnableEvents();
            }
        }
    }

    public class SharedFunctions
    {
        private const string DefaultDateFormat = "yyyy-MM-dd";
        private const string PfeProjectSQL = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @projectID";
        private const string ResourceSQL = "Select EXTID from LSTResourcepool where SharePointAccountID = @UID";
        private const string PeriodSQL = "Select TP.PERIOD_START, TP.PERIOD_END from TSTIMESHEET TS left join TSPERIOD TP on TS.PERIOD_ID= TP.PERIOD_ID and ts.Site_UID = tp.Site_ID where TS.TS_UID= @TS_UID";
        public static bool canUserImpersonate(string curuser, string iuser, SPWeb web, out string resName)
        {
            resName = "";
            bool impersonate = false;
            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
            //using (SPSite site = new SPSite(resUrl))
            using (SPSite site = new SPSite(resUrl))
            {
                //using (SPWeb rweb = site.OpenWeb())
                using (SPWeb rweb = site.OpenWeb())
                {
                    SPList rlist = rweb.Lists["Resources"];
                    SPUser u = rweb.SiteUsers[curuser];

                    SPQuery query = new SPQuery();
                    query.Query = "<Where><Eq><FieldRef Name=\"TimesheetDelegates\" LookupId='True'/><Value Type=\"User\">" + u.ID + "</Value></Eq></Where><OrderBy><FieldRef Name=\"Title\"/></OrderBy>";

                    SPListItemCollection lic = rlist.GetItems(query);

                    if (lic.Count > 0)
                    {
                        foreach (SPListItem li in lic)
                        {
                            try
                            {
                                SPFieldUserValue uv = new SPFieldUserValue(web, li["SharePointAccount"].ToString());
                                if (System.Web.HttpUtility.UrlDecode(iuser).ToLower() == uv.User.LoginName.ToLower())
                                {
                                    impersonate = true;
                                    resName = uv.User.Name;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            return impersonate;
        }
        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();


        public static string processActualWork(SqlConnection cn, string tsuid, SPSite site, bool bApprovalScreen, bool bApproved)
        {
            string error = "";
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //using (SPSite site = new SPSite(s.ID, s.SystemAccount.UserToken))
            {
                string sql = "SELECT * FROM vwTSItemHoursByTS where ts_uid=@ts_uid order by web_uid,list_uid";
                //if(!bApprovalScreen)
                //    sql = "SELECT * FROM vwTSItemHoursByMyTS where ts_uid=@ts_uid order by web_uid,list_uid";


                //SqlCommand cmd = new SqlCommand("spTSGetProjectsHours", cn);
                //cmd.Parameters.AddWithValue("@TSUID", tsuid);
                //cmd.Parameters.AddWithValue("@approved", bApproved);
                //cmd.CommandType = CommandType.StoredProcedure;
                //DataSet dsProjects = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dsProjects);

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                SqlDataReader dr = cmd.ExecuteReader();

                Guid webGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPList iList = null;
                while (dr.Read())
                {
                    try
                    {
                        Guid wGuid = new Guid(dr["WEB_UID"].ToString());
                        Guid lGuid = new Guid(dr["LIST_UID"].ToString());

                        if (webGuid != wGuid)
                        {
                            try
                            {
                                if (iWeb != null)
                                {
                                    iWeb.Close();
                                    iWeb = site.OpenWeb(wGuid);
                                }
                                else
                                    iWeb = site.OpenWeb(wGuid);
                                webGuid = iWeb.ID;
                            }
                            catch { }
                        }
                        if (iWeb != null)
                        {
                            if (listGuid != lGuid)
                            {
                                iList = iWeb.Lists[lGuid];
                                listGuid = iList.ID;
                            }
                            string itemId = dr["ITEM_ID"].ToString();
                            lock (_locks.GetOrAdd(itemId, _ => new object()))
                            {
                                iWeb.AllowUnsafeUpdates = true;
                                SPListItem li = null;
                                try
                                {
                                    li = iList.GetItemById(int.Parse(dr["ITEM_ID"].ToString()));
                                }
                                catch { }
                                if (li != null)
                                {
                                    //If the project server feature is not active and it is in approval mode then process actual work.
                                    if (iWeb.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] == null && bApprovalScreen)
                                    {
                                        SPField f = null;
                                        try
                                        {
                                            f = iList.Fields.GetFieldByInternalName("TimesheetHours");
                                        }
                                        catch { }
                                        if (f != null)
                                        {
                                            SPUtilities.RunWithoutEventsFiring(delegate ()
                                            {
                                                li[f.Id] = dr["TotalHours"].ToString();

                                                li.Update();
                                            });
                                            //processProject(dsProjects, wGuid, iWeb);

                                        }
                                    }
                                    else
                                    {
                                        SPField f = null;
                                        try
                                        {
                                            f = iList.Fields.GetFieldByInternalName("TimesheetHours");
                                        }
                                        catch { }
                                        if (f != null)
                                        {
                                            string taskuid = "";
                                            try
                                            {
                                                taskuid = li["taskuid"].ToString();
                                            }
                                            catch { }
                                            //if the item has a taskuid (Meaning this item is a Project Task)
                                            if (taskuid != "" && taskuid.Contains("."))
                                            {
                                                string login = "";
                                                try
                                                {
                                                    SPFieldUserValueCollection uvc = (SPFieldUserValueCollection)li[iList.Fields.GetFieldByInternalName("AssignedTo").Id];
                                                    if (uvc.Count > 0)
                                                    {
                                                        login = uvc[0].User.LoginName.ToLower();
                                                    }
                                                }
                                                catch { }
                                                if (login != "")//if we found a user
                                                {
                                                    if (login == SPContext.Current.Web.CurrentUser.LoginName.ToLower())
                                                    {
                                                        SPUtilities.RunWithoutEventsFiring(delegate ()
                                                        {
                                                            li[f.Id] = dr["SubmittedHours"].ToString();
                                                            li.Update();
                                                        });
                                                        //processProject(dsProjects, wGuid, iWeb);
                                                    }
                                                }
                                            }
                                            else if (bApprovalScreen)//otherwise it must be in approval mode
                                            {
                                                SPUtilities.RunWithoutEventsFiring(delegate ()
                                                {
                                                    li[f.Id] = dr["TotalHours"].ToString();
                                                    li.Update();
                                                });
                                                //processProject(dsProjects, wGuid, iWeb);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception exception)
                    {
                        error += "Error: " + exception.Message + "<br>SharePoint User: " + iWeb.CurrentUser.Name + "<br><br><br>";
                    }
                }

                dr.Close();
            }
            //});\
            return error + processProjectWork(cn, tsuid, site, bApprovalScreen, bApprovalScreen);
        }

        public static string processProjectWork(SqlConnection cn, string tsuid, SPSite site, bool bApprovalScreen, bool bApproved)
        {
            string error = "";
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //using (SPSite site = new SPSite(s.ID, s.SystemAccount.UserToken))
            {
                //string sql = "SELECT * FROM vwTSItemHoursByTS where ts_uid=@ts_uid order by web_uid,list_uid";
                //if(!bApprovalScreen)
                //    sql = "SELECT * FROM vwTSItemHoursByMyTS where ts_uid=@ts_uid order by web_uid,list_uid";


                SqlCommand cmd = new SqlCommand("spTSGetProjectsHours", cn);
                cmd.Parameters.AddWithValue("@TSUID", tsuid);
                cmd.Parameters.AddWithValue("@approved", bApproved);
                cmd.CommandType = CommandType.StoredProcedure;
                DataSet dsProjects = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsProjects);

                //cmd = new SqlCommand(sql, cn);
                //cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                //SqlDataReader dr = cmd.ExecuteReader();

                Guid webGuid = new Guid();
                Guid listGuid = new Guid();
                SPWeb iWeb = null;
                SPList iList = null;

                foreach (DataRow drProject in dsProjects.Tables[0].Rows)
                {
                    try
                    {
                        if (drProject["PROJECT_LIST_UID"].ToString() != "")
                        {
                            Guid wGuid = new Guid(drProject["WEB_UID"].ToString());
                            Guid lGuid = new Guid(drProject["PROJECT_LIST_UID"].ToString());

                            if (webGuid != wGuid)
                            {
                                try
                                {
                                    if (iWeb != null)
                                    {
                                        iWeb.Close();
                                        iWeb = site.OpenWeb(wGuid);
                                    }
                                    else
                                        iWeb = site.OpenWeb(wGuid);
                                    webGuid = iWeb.ID;
                                }
                                catch { }
                            }
                            if (iWeb != null)
                            {
                                if (listGuid != lGuid)
                                {
                                    iList = iWeb.Lists[lGuid];
                                    listGuid = iList.ID;
                                }
                                string project = drProject["Project_id"].ToString();
                                if (project != "0")
                                {
                                    lock (_locks.GetOrAdd(project, _ => new object()))
                                    {
                                        iWeb.AllowUnsafeUpdates = true;
                                        try
                                        {
                                            SPListItem liProject = iList.GetItemById(int.Parse(project));
                                            liProject["TimesheetHours"] = drProject["Hours"].ToString();
                                            liProject.SystemUpdate();
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        error += "Error: " + exception.Message + "<br>SharePoint User: " + iWeb.CurrentUser.Name + "<br><br><br>";
                    }
                }

            }
            //});\
            return error;
        }


        public static SPList getProjectCenterList(SPList taskList)
        {
            try
            {
                SPField pField = taskList.Fields.GetFieldByInternalName("Project");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(pField.SchemaXml);

                string listid = doc.FirstChild.Attributes["List"].Value;

                return taskList.ParentWeb.Lists[new Guid(listid)];
            }
            catch { }
            return null;
        }

        public static void processProject(DataSet dsProjects, Guid wGuid, SPWeb iWeb)
        {
            DataRow[] drProjects = dsProjects.Tables[0].Select("WEB_UID='" + wGuid + "'");
            if (drProjects.Length > 0)
            {
                foreach (DataRow drProject in drProjects)
                {
                    SPList projectCenter = null;
                    try
                    {
                        Guid pcGuid = new Guid(drProject["PROJECT_LIST_UID"].ToString());
                        if (projectCenter == null || pcGuid != projectCenter.ID)
                            projectCenter = iWeb.Lists[pcGuid];

                        string project = drProject["Project_id"].ToString();

                        if (project != "0")
                        {
                            lock (_locks.GetOrAdd(project, _ => new object()))
                            {
                                try
                                {
                                    SPListItem liProject = projectCenter.GetItemById(int.Parse(project));
                                    liProject["TimesheetHours"] = drProject["Hours"].ToString();
                                    liProject.SystemUpdate();
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        static void GetPeriodDates(SqlConnection cn, string tsuid, out string prdStart, out string prdEnd)
        {
            try
            {
                prdStart = "";
                prdEnd = "";
                using (SqlCommand cmd = new SqlCommand(PeriodSQL, cn))
                {
                    cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            DateTime periodStart;
                            if (DateTime.TryParse(dr["PERIOD_START"].ToString(), out periodStart))
                            {
                                prdStart = periodStart.ToString(DefaultDateFormat);
                            }
                            DateTime periodEnd;
                            if (DateTime.TryParse(dr["PERIOD_END"].ToString(), out periodEnd))
                            {
                                prdEnd = periodEnd.ToString(DefaultDateFormat);
                            }
                        }
                    }
                }

            }
            catch
            {
                prdStart = "";
                prdEnd = "";
            }

        }
        static void GetResourcesEXTID(string rptConnectionstring, SPWeb web, string username, out string extid)
        {
            try
            {
                extid = "";
                using (SqlConnection cn = new SqlConnection(rptConnectionstring))
                {
                    cn.Open();
                    var user = web.AllUsers[username];
                    using (SqlCommand cmd = new SqlCommand(ResourceSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@UID", user.ID);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                extid = Convert.ToString(dr["EXTID"]);
                            }
                        }
                    }
                }
            }
            catch
            {
                extid = "";
            }

        }
        static void GetProjectEXTID(string basepath, SPWeb web, string projectid, out int projectextid)
        {
            try
            {
                projectextid = 0;
                var connectionString = Utilities.GetPFEDBConnectionString(basepath);
                // convert sql connection string to proper format
                var connectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = connectionString };
                connectionStringBuilder.Remove("Provider");
                connectionStringBuilder.Add("Application Name", "EPMLiveCore TimeSheet");
                connectionString = connectionStringBuilder.ToString();
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(PfeProjectSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@projectID", projectid);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                projectextid = dr.GetInt32(0);
                            }
                        }
                    }
                }


            }
            catch
            {
                projectextid = 0;
            }

        }
        public static string GetStandardRates(SqlConnection cn, string tsuid, SPWeb web, string username, string projectid = null)
        {
            string rate = string.Empty;
            try
            {


                string prdStart = string.Empty;
                string prdEnd = string.Empty;
                string extid = string.Empty;
                int projectextid = 0;
                string basePath = CoreFunctions.getConfigSetting(web, "epkbasepath");
                string rptConnectionstring = CoreFunctions.getReportingConnectionString(web.Site.WebApplication.Id, web.Site.ID);
                GetResourcesEXTID(rptConnectionstring, web, username, out extid);

                if (!string.IsNullOrEmpty(projectid))
                {
                    GetProjectEXTID(basePath, web, projectid, out projectextid);
                    ProjectResourceRateRepository repo = new ProjectResourceRateRepository();
                    var pferates = repo.GetRates(web, projectextid, Convert.ToInt32(extid)).FirstOrDefault();
                    if (pferates != null && pferates.Rate > 0)
                    {
                        rate = web.Locale.NumberFormat.CurrencySymbol + Convert.ToString(pferates.Rate);
                    }
                }
                if (string.IsNullOrEmpty(rate))
                {
                    GetPeriodDates(cn, tsuid, out prdStart, out prdEnd);


                    if (!string.IsNullOrEmpty(prdStart) && !string.IsNullOrEmpty(prdEnd) && !string.IsNullOrEmpty(extid))
                    {
                        DataSet dsrates = Utilities.GetRoleRates(basePath, username, prdStart, prdEnd, extid);
                        if (dsrates.Tables[0].Rows.Count > 0)
                        {
                            rate = web.Locale.NumberFormat.CurrencySymbol + Convert.ToString(dsrates.Tables[0].Rows[0]["BC_RATE"]);
                        }
                    }
                }
                if (string.IsNullOrEmpty(rate))
                {
                    DataSet dsResMeta = new DataSet();
                    using (SqlCommand cmd = new SqlCommand("Select ColumnName,ColumnValue FROM TSRESMETA where TS_UID = @TS_UID", cn))
                    {
                        cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsResMeta);
                        if (dsResMeta.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow drMeta in dsResMeta.Tables[0].Rows)
                            {
                                if (Convert.ToString(drMeta["ColumnName"]).ToLower() == "standardrate")
                                {
                                    rate = Convert.ToString(drMeta["ColumnValue"]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch { rate = string.Empty; }
            return rate;
        }
        static internal void processResources(SqlConnection cn, string tsuid, SPWeb web, string username)
        {
            string rate = GetStandardRates(cn, tsuid, web, username);
            SqlCommand cmd = new SqlCommand("DELETE FROM TSRESMETA where TS_UID = @TS_UID", cn);
            cmd.Parameters.AddWithValue("@TS_UID", tsuid);
            cmd.ExecuteNonQuery();

            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);

            if (resUrl != "")
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        SPWeb resWeb = null;

                        using (SPSite tempSite = new SPSite(resUrl))
                        {

                            resWeb = tempSite.OpenWeb();

                            if (resWeb != null)
                            {

                                SPList list = resWeb.Lists["Resources"];

                                string[] fields = EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)).Split(',');

                                SPUser user = web.AllUsers[username];

                                SPQuery query = new SPQuery();
                                query.Query = "<Where><Eq><FieldRef Name=\"SharePointAccount\" /><Value Type=\"User\">" + user.Name + "</Value></Eq></Where>";

                                SPListItem li = list.GetItems(query)[0];

                                foreach (string field in fields)
                                {
                                    SPField f = null;
                                    string val = "";
                                    try
                                    {
                                        f = list.Fields.GetFieldByInternalName(field);
                                        if (field.ToLower() == "standardrate")
                                        {
                                            if (!string.IsNullOrEmpty(rate))
                                            {
                                                val = rate;
                                            }
                                            else
                                            {
                                                val = f.GetFieldValueAsText(li[f.Id]);
                                            }
                                        }
                                        else
                                        {
                                            val = f.GetFieldValueAsText(li[f.Id]);
                                        }
                                    }
                                    catch { }
                                    if (f != null)
                                    {
                                        cmd = new SqlCommand("INSERT INTO TSRESMETA (TS_UID,UserName,ColumnName,DisplayName,ColumnValue) VALUES (@TS_UID,@username,@ColumnName,@DisplayName,@ColumnValue)", cn);
                                        cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                                        cmd.Parameters.AddWithValue("@ColumnName", field);
                                        cmd.Parameters.AddWithValue("@UserName", username);
                                        cmd.Parameters.AddWithValue("@DisplayName", f.Title);
                                        cmd.Parameters.AddWithValue("@ColumnValue", val);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                if (SPContext.Current != null && resWeb.ID != SPContext.Current.Web.ID)
                                    resWeb.Close();

                            }
                        }
                    });
                }
                catch { }
            }
        }

        public static void processMeta(SPWeb iWeb, SPList iList, SPListItem li, Guid newTS, string project, SqlConnection cn, SPList pList)
        {
            string[] fields = EPMLiveCore.CoreFunctions.getConfigSetting(iWeb.Site.RootWeb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(iList.DefaultView == null ? iList.DefaultViewUrl : iList.DefaultView.Url)).Split(',');

            SqlCommand cmd = new SqlCommand("DELETE FROM TSMETA WHERE TS_ITEM_UID = @TS_ITEM_UID", cn);
            cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("UPDATE tsitem set title = @title,PROJECT_LIST_UID=@projectlistuid where ts_item_uid=@itemuid", cn);
            cmd.Parameters.AddWithValue("@itemuid", newTS);
            cmd.Parameters.AddWithValue("@title", li.Title);
            if (pList != null)
                cmd.Parameters.AddWithValue("@projectlistuid", pList.ID);
            else
                cmd.Parameters.AddWithValue("@projectlistuid", DBNull.Value);
            cmd.ExecuteNonQuery();

            foreach (string field in fields)
            {
                SPField f = null;
                string val = "";
                try
                {
                    f = iList.Fields.GetFieldByInternalName(field);
                    switch (f.Type)
                    {
                        case SPFieldType.DateTime:
                            val = f.GetFieldValueAsText(((DateTime)li[f.Id]).ToUniversalTime());
                            break;
                        default:
                            val = f.GetFieldValueAsText(li[f.Id]);
                            break;
                    };

                }
                catch { }
                if (f != null)
                {
                    cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@TS_ITEM_UID,@ColumnName,@DisplayName,@ColumnValue,@ListName)", cn);
                    cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
                    cmd.Parameters.AddWithValue("@ColumnName", field);
                    cmd.Parameters.AddWithValue("@DisplayName", f.Title);
                    cmd.Parameters.AddWithValue("@ColumnValue", val);
                    cmd.Parameters.AddWithValue("@ListName", li.ParentList.Title);
                    cmd.ExecuteNonQuery();
                }
            }

            if (pList != null && project != "")
            {
                fields = EPMLiveCore.CoreFunctions.getConfigSetting(iWeb.Site.RootWeb, "EPMLiveTSFields-Lists\\" + pList.Title).Split(',');

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + project + "</Value></Eq></Where>";

                SPListItemCollection lic = pList.GetItems(query);
                if (lic.Count > 0)
                {
                    foreach (string field in fields)
                    {
                        SPField f = null;
                        string val = "";
                        try
                        {
                            f = pList.Fields.GetFieldByInternalName(field);
                            val = f.GetFieldValueAsText(lic[0][f.Id]);
                        }
                        catch { }
                        if (f != null)
                        {
                            try
                            {
                                cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@TS_ITEM_UID,@ColumnName,@DisplayName,@ColumnValue,@ListName)", cn);
                                cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
                                cmd.Parameters.AddWithValue("@ColumnName", field);
                                cmd.Parameters.AddWithValue("@DisplayName", f.Title);
                                cmd.Parameters.AddWithValue("@ColumnValue", val);
                                cmd.Parameters.AddWithValue("@ListName", pList.Title);
                                cmd.ExecuteNonQuery();
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        public static string getTimeEditorDiv(string editEvents, string sFullGridId, SqlConnection cn, SPWeb web, out string firsteditorbox)
        {
            firsteditorbox = "";
            StringBuilder sb = new StringBuilder();

            string disabled = "";
            if (editEvents != "true")
                disabled = "disabled=\"true\"";

            sb.Append("<div id=\"timeeditorgrid" + sFullGridId + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:215px; Z-Index:99;\">");
            sb.Append("<Table>");
            sb.Append("<tr><td class=\"ms-descriptiontext\"><b><div id=\"timeeditortitle" + sFullGridId + "\" class=\"ms-descriptiontext\"></div></td></tr>");
            sb.Append("<tr><td class=\"ms-descriptiontext\"><b><div id=\"timeeditordate" + sFullGridId + "\" class=\"ms-descriptiontext\"></div></td></tr>");
            sb.Append("</table>");
            sb.Append("<div id=\"timeeditor" + sFullGridId + "\" style=\"width: 188; background-color: #FFFFFF; border: 1px solid #808080; padding:5px;\" class=\"ms-descriptiontext\">");

            sb.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">");
            SqlCommand cmd = new SqlCommand("SELECT tstype_id,tstype_name from TSTYPE where site_uid=@site_id", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@site_id", SPContext.Current.Site.ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    sb.Append("<tr><td class=\"ms-descriptiontext\">" + dr.GetString(1) + "</td><td align=\"right\"><input class=\"ms-input\" size=\"5\" type=\"text\" id=\"timeeditor-" + sFullGridId + "-" + dr.GetInt32(0).ToString() + "\" " + disabled + " onkeypress=\"return numberOnly" + sFullGridId + "(event)\"></td></tr>");
                }
                firsteditorbox = "timeeditor-" + sFullGridId + "-1";
            }
            else
            {
                firsteditorbox = "timeeditor-" + sFullGridId + "-0";
                sb.Append("<tr><td class=\"ms-descriptiontext\">Work</td><td align=\"right\"><input class=\"ms-input\" size=\"5\" type=\"text\" id=\"timeeditor-" + sFullGridId + "-0\" " + disabled + " onkeypress=\"return numberOnly" + sFullGridId + "(event)\"></td></tr>");
            }
            dr.Close();

            if (EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowNotes").ToLower() == "true")
            {
                sb.Append("<tr><td class=\"ms-descriptiontext\" colspan=\"2\">&nbsp;</td></tr>");
                sb.Append("<tr><td class=\"ms-descriptiontext\" colspan=\"2\">Notes</td></tr>");
                sb.Append("<tr><td  class=\"ms-descriptiontext\" colspan=\"2\"><textarea class=\"ms-input\" id=\"timeeditor-" + sFullGridId + "-N\" rows=\"3\" cols=\"25\" " + disabled + "></textarea></td></tr>");
            }

            sb.Append("</table>");
            sb.Append("</div>");
            sb.Append("<table border=\"0\" width=\"188\"><tr><td align=\"right\">");
            sb.Append("<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            sb.Append("</td></tr></table>");
            sb.Append("</div>");

            return sb.ToString();
        }
    }
}
