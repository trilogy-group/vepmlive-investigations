using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections;

namespace TimeSheets
{
    public class SaveJob : BaseJob
    {

        SPList WorkList;
        private bool Editable = false;

        private static string iGetAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }

        private static string iGetValue(SPListItem li, string field)
        {
            try
            {
                SPField f = li.ParentList.Fields.GetFieldByInternalName(field);

                switch (f.Type)
                {
                    case SPFieldType.Number:
                    case SPFieldType.Currency:
                        return li[f.Id].ToString();
                    default:
                        return f.GetFieldValueAsText(li[f.Id].ToString());
                }
            }
            catch { }

            return "";
        }

        private void ProcessTimesheetHours(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPWeb web, string period)
        {

            ArrayList arrPeriods = TimesheetAPI.GetPeriodDaysArray(cn, settings, web, period);

            foreach (XmlNode ndDate in ndRow.SelectNodes("Hours/Date"))
            {
                DateTime dt = DateTime.Parse(ndDate.Attributes["Value"].Value);

                if (arrPeriods.Contains(dt))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM TSITEMHOURS where TS_ITEM_UID=@id and TS_ITEM_DATE=@dt", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM TSNOTES where TS_ITEM_UID=@id and TS_ITEM_DATE=@dt", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.ExecuteNonQuery();

                    foreach (XmlNode ndTime in ndDate.SelectNodes("Time"))
                    {
                        string hours = iGetAttribute(ndTime, "Hours");
                        string type = "0";
                        try
                        {
                            type = ndTime.Attributes["Type"].Value;
                        }
                        catch { }

                        cmd = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID) VALUES (@id,@dt,@hours,@type)", cn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@dt", dt);
                        cmd.Parameters.AddWithValue("@hours", hours);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.ExecuteNonQuery();

                    }

                    XmlNode ndNotes = ndDate.SelectSingleNode("Notes");
                    if (ndNotes != null)
                    {
                        cmd = new SqlCommand("INSERT INTO TSNOTES (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES) VALUES (@id,@dt,@notes)", cn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@dt", dt);
                        cmd.Parameters.AddWithValue("@notes", System.Web.HttpUtility.UrlDecode(ndNotes.InnerText));
                        cmd.ExecuteNonQuery();
                    }

                }
            }

        }

        private void ProcessListFields(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPListItem li, bool recurse, SPList list)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TSMETA where TS_ITEM_UID=@uid and ListName = @list", cn);
            cmd.Parameters.AddWithValue("@uid", id);
            cmd.Parameters.AddWithValue("@list", list.Title);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            ArrayList fields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb.Site.RootWeb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)).Split(','));

            foreach (string field in fields)
            {
                if (field == "")
                    continue;

                string newValue = iGetValue(li, field);

                if (newValue != "")
                {
                    SPField oField = null;
                    try
                    {
                        oField = list.Fields.GetFieldByInternalName(field);
                    }
                    catch { }

                    if (oField != null)
                    {

                        DataRow[] drTs = ds.Tables[0].Select("ColumnName='" + field + "'");

                        if (drTs.Length > 0)
                        {
                            cmd = new SqlCommand("UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid", cn);
                            cmd.Parameters.AddWithValue("@val", newValue);
                            cmd.Parameters.AddWithValue("@muid", drTs[0]["TSMETA_UID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,@list)", cn);
                            cmd.Parameters.AddWithValue("@uid", id);
                            cmd.Parameters.AddWithValue("@col", field);
                            cmd.Parameters.AddWithValue("@disp", oField.Title);
                            cmd.Parameters.AddWithValue("@val", newValue);
                            cmd.Parameters.AddWithValue("@list", list.Title);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    cmd = new SqlCommand("DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName=@list", cn);
                    cmd.Parameters.AddWithValue("@uid", id);
                    cmd.Parameters.AddWithValue("@col", field);
                    cmd.Parameters.AddWithValue("@list", list.Title);
                    cmd.ExecuteNonQuery();
                }
            }

            if (recurse)
            {

                try
                {
                    SPFieldLookup ProjectField = (SPFieldLookup)list.Fields.GetFieldByInternalName("Project");

                    SPFieldLookupValue lv = new SPFieldLookupValue(li[ProjectField.Id].ToString());


                    SPList pList = list.ParentWeb.Lists[new Guid(ProjectField.LookupList)];
                    SPListItem pLi = pList.GetItemById(lv.LookupId);

                    ProcessListFields(id, ndRow, cn, settings, pLi, false, pList);
                }
                catch { }
            }
        }

        private void ProcessTimesheetFields(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM TSMETA where TS_ITEM_UID=@uid and ListName='MYTS'", cn);
            cmd.Parameters.AddWithValue("@uid", id);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            foreach (string field in settings.TimesheetFields)
            {
                string newValue = iGetAttribute(ndRow, field);

                if (newValue != "")
                {
                    SPField oField = null;
                    try
                    {
                        oField = WorkList.Fields.GetFieldByInternalName(field);
                    }
                    catch { }

                    if (oField != null)
                    {

                        DataRow[] drTs = ds.Tables[0].Select("ColumnName='" + field + "'");

                        if (drTs.Length > 0)
                        {
                            cmd = new SqlCommand("UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid", cn);
                            cmd.Parameters.AddWithValue("@val", newValue);
                            cmd.Parameters.AddWithValue("@muid", drTs[0]["TSMETA_UID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,'MYTS')", cn);
                            cmd.Parameters.AddWithValue("@uid", id);
                            cmd.Parameters.AddWithValue("@col", field);
                            cmd.Parameters.AddWithValue("@disp", oField.Title);
                            cmd.Parameters.AddWithValue("@val", newValue);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    cmd = new SqlCommand("DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName='MYTS'", cn);
                    cmd.Parameters.AddWithValue("@uid", id);
                    cmd.Parameters.AddWithValue("@col", field);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ProcessItemRow(XmlNode ndRow, ref DataTable dtItems, SqlConnection cn, SPSite site, TimesheetSettings settings, string period, bool liveHours, bool bSkipSP)
        {
            string id = iGetAttribute(ndRow, "UID");

            if (id != "")
            {
                DataRow[] drItem = dtItems.Select("TS_ITEM_UID='" + id + "'");

                try
                {
                    string webid = iGetAttribute(ndRow, "WebID");
                    string listid = iGetAttribute(ndRow, "ListID");
                    string itemid = iGetAttribute(ndRow, "ItemID");

                    string itemtypeid = iGetAttribute(ndRow, "ItemTypeID");

                    if (itemtypeid == "")
                        itemtypeid = "1";

                    if (webid != "")
                    {
                        if (listid != "")
                        {
                            if (itemid != "")
                            {


                                try
                                {

                                    using (SPWeb web = site.OpenWeb(new Guid(webid)))
                                    {
                                        SPListItem li = null;

                                        SPList list = web.Lists[new Guid(listid)];

                                        try
                                        {
                                            try
                                            {
                                                li = list.Items.GetItemById(int.Parse(itemid));
                                            }
                                            catch { }

                                            if (li != null)
                                            {
                                                int projectid = 0;
                                                string project = "";
                                                string projectlist = "";
                                                try
                                                {
                                                    SPFieldLookupValue lv = new SPFieldLookupValue(li[list.Fields.GetFieldByInternalName("Project").Id].ToString());
                                                    projectid = lv.LookupId;
                                                    project = lv.LookupValue;
                                                }
                                                catch { }



                                                if (drItem.Length > 0)
                                                {
                                                    SqlCommand cmd = new SqlCommand("UPDATE TSITEM set Title = @title, project=@project, project_id=@projectid where ts_item_uid=@uid", cn);
                                                    cmd.Parameters.AddWithValue("@uid", id);
                                                    cmd.Parameters.AddWithValue("@title", li["Title"].ToString());
                                                    if (projectid == 0)
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", DBNull.Value);
                                                        cmd.Parameters.AddWithValue("@projectid", DBNull.Value);
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", project);
                                                        cmd.Parameters.AddWithValue("@projectid", projectid);
                                                    }
                                                    cmd.ExecuteNonQuery();

                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        SPFieldLookup fieldlookup = (SPFieldLookup)list.Fields.GetFieldByInternalName("Project");
                                                        projectlist = fieldlookup.LookupList;
                                                    }
                                                    catch { }

                                                    SqlCommand cmd = new SqlCommand("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_ID,ITEM_TYPE,TITLE, PROJECT,PROJECT_ID, LIST,PROJECT_LIST_UID) VALUES(@tsuid,@uid,@webid,@listid,@itemid,@itemtype,@title,@project,@projectid,@list,@projectlistid)", cn);
                                                    cmd.Parameters.AddWithValue("@tsuid", TSUID);
                                                    cmd.Parameters.AddWithValue("@uid", id);
                                                    cmd.Parameters.AddWithValue("@webid", web.ID);
                                                    cmd.Parameters.AddWithValue("@listid", list.ID);
                                                    cmd.Parameters.AddWithValue("@itemid", li.ID);
                                                    cmd.Parameters.AddWithValue("@title", li["Title"].ToString());
                                                    cmd.Parameters.AddWithValue("@list", list.Title);
                                                    cmd.Parameters.AddWithValue("@itemtype", itemtypeid);

                                                    if (projectlist == "")
                                                        cmd.Parameters.AddWithValue("@projectlistid", DBNull.Value);
                                                    else
                                                        cmd.Parameters.AddWithValue("@projectlistid", projectlist);

                                                    if (projectid == 0)
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", DBNull.Value);
                                                        cmd.Parameters.AddWithValue("@projectid", DBNull.Value);
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", project);
                                                        cmd.Parameters.AddWithValue("@projectid", projectid);
                                                    }
                                                    cmd.ExecuteNonQuery();
                                                }

                                                ProcessTimesheetHours(id, ndRow, cn, settings, web, period);

                                                if (!bSkipSP)
                                                {
                                                    if (WorkList != null)
                                                        ProcessTimesheetFields(id, ndRow, cn, settings);

                                                    if (Editable)
                                                    {
                                                        //PROCESS LI
                                                    }

                                                    ProcessListFields(id, ndRow, cn, settings, li, true, list);

                                                    if (liveHours)
                                                        processLiveHours(li, list.ID);

                                                    if (Editable)
                                                        li.Update();
                                                    else
                                                        li.SystemUpdate();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            bErrors = true;
                                            sErrors += "Item (" + id + ") Error: " + ex.Message;
                                        }


                                    }

                                }
                                catch { }



                            }
                            else
                            {
                                bErrors = true;
                                sErrors += "Item (" + id + ") missing item id";
                            }
                        }
                        else
                        {
                            bErrors = true;
                            sErrors += "Item (" + id + ") missing list id";
                        }
                    }
                    else
                    {
                        bErrors = true;
                        sErrors += "Item (" + id + ") missing web id";
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors += "Item (" + id + ") Error x2: " + ex.Message;
                }
                if (drItem.Length > 0)
                {
                    dtItems.Rows.Remove(drItem[0]);
                }
            }
            else
            {
                bErrors = true;
                sErrors += "Could not get id for item";
            }
        }

        public void execute(SPSite site, string data)
        {
            try
            {
                try
                {
                    WorkList = site.RootWeb.Lists["My Work"];
                }
                catch { }

                XmlDocument docTimesheet = new XmlDocument();
                docTimesheet.LoadXml(data);

                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("SELECT     dbo.TSUSER.USER_ID FROM         dbo.TSUSER INNER JOIN dbo.TSTIMESHEET ON dbo.TSUSER.TSUSERUID = dbo.TSTIMESHEET.TSUSER_UID WHERE TS_UID=@tsuid", cn);
                cmd.Parameters.AddWithValue("@tsuid", base.TSUID);

                SqlDataReader dr = cmd.ExecuteReader();

                int userid = 0;

                if (dr.Read())
                {
                    userid = dr.GetInt32(0);
                }
                dr.Close();

                try
                {
                    if (docTimesheet.FirstChild.Attributes["Editable"].Value == "1")
                        Editable = true;
                }
                catch { }

                bool SaveAndSubmit = false;
                try
                {
                    SaveAndSubmit = bool.Parse(docTimesheet.FirstChild.Attributes["SaveAndSubmit"].Value);
                }
                catch { }

                bool liveHours = false;

                bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSLiveHours"), out liveHours);

                if (userid != 0)
                {
                    SPUser user = TimesheetAPI.GetUser(site.RootWeb, userid.ToString());

                    if (user.ID != userid)
                    {
                        bErrors = true;
                        sErrors = "You do not have access to edit that timesheet.";
                    }
                    else
                    {
                        TimesheetSettings settings = new TimesheetSettings(site.RootWeb);

                        DataSet dsItems = new DataSet();

                        SPUser editUser = site.RootWeb.AllUsers.GetByID(base.userid);

                        cmd = new SqlCommand("UPDATE TSTIMESHEET SET LASTMODIFIEDBYU=@uname, LASTMODIFIEDBYN=@name where TS_UID=@tsuid", cn);
                        cmd.Parameters.AddWithValue("@uname", editUser.LoginName);
                        cmd.Parameters.AddWithValue("@name", editUser.Name);
                        cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT * FROM TSITEM WHERE TS_UID=@tsuid", cn);
                        cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsItems);
                        DataTable dtItems = dsItems.Tables[0];

                        string period = "";

                        cmd = new SqlCommand("SELECT period_id FROM TSTIMESHEET WHERE TS_UID=@tsuid", cn);
                        cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                        SqlDataReader drts = cmd.ExecuteReader();
                        if (drts.Read())
                        {
                            period = drts.GetInt32(0).ToString();
                        }
                        drts.Close();

                        XmlNodeList ndItems = docTimesheet.FirstChild.SelectNodes("Item");

                        float percent = 0;
                        float count = 0;
                        float total = ndItems.Count;

                        foreach (XmlNode ndItem in ndItems)
                        {
                            string worktype = "";

                            try
                            {
                                worktype = ndItem.Attributes["WorkTypeField"].Value;
                            }
                            catch { }

                            ProcessItemRow(ndItem, ref dtItems, cn, site, settings, period, liveHours, worktype == settings.NonWorkList);

                            count++;
                            float pct = count / total * 98;

                            if (pct >= percent + 10)
                            {
                                cmd = new SqlCommand("update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid", cn);
                                cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                                cmd.Parameters.AddWithValue("@pct", pct);
                                cmd.ExecuteNonQuery();

                                percent = pct;
                            }
                        }

                        cmd = new SqlCommand("update TSQUEUE set percentcomplete=98 where TSQUEUE_ID=@QueueUid", cn);
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        cmd.ExecuteNonQuery();

                        foreach (DataRow drDelItem in dtItems.Rows)
                        {
                            cmd = new SqlCommand("DELETE FROM TSITEM where TS_ITEM_UID=@uid", cn);
                            cmd.Parameters.AddWithValue("@uid", drDelItem["TS_ITEM_UID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        
                        if (liveHours)
                            sErrors += processActualWork(cn, TSUID.ToString(), site, true, false);

                        cmd = new SqlCommand("update TSQUEUE set percentcomplete=99 where TSQUEUE_ID=@QueueUid", cn);
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        cmd.ExecuteNonQuery();

                        SharedFunctions.processResources(cn, TSUID.ToString(), site.RootWeb, user.LoginName);
                    }
                }
                else
                {
                    bErrors = true;
                    sErrors = "Timesheet does not exist";
                }
                cn.Close();

                if (SaveAndSubmit)
                    TimesheetAPI.SubmitTimesheet("<Timesheet ID=\"" + base.TSUID + "\" />", site.RootWeb);
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "Error: " + ex.Message;
            }
        }

        public static string processActualWork(SqlConnection cn, string tsuid, SPSite site, bool bApprovalScreen, bool bApproved)
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
                /*while (dr.Read())
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
                                        li[f.Id] = dr["TotalHours"].ToString();

                                        li.Update();

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
                                                    li[f.Id] = dr["SubmittedHours"].ToString();
                                                    li.Update();
                                                    //processProject(dsProjects, wGuid, iWeb);
                                                }
                                            }
                                        }
                                        else if (bApprovalScreen)//otherwise it must be in approval mode
                                        {
                                            li[f.Id] = dr["TotalHours"].ToString();
                                            li.Update();
                                            //processProject(dsProjects, wGuid, iWeb);
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
                */
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
                                iWeb.AllowUnsafeUpdates = true;
                                string project = drProject["Project_id"].ToString();
                                if (project != "0")
                                {
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
                    catch (Exception exception)
                    {
                        error += "Error: " + exception.Message + "<br>SharePoint User: " + iWeb.CurrentUser.Name + "<br><br><br>";
                    }
                }

            }
            //});\
            return error;
        }

        private void processLiveHours(SPListItem li, Guid listguid)
        {

            double hours = 0;
            try
            {

                if (li != null)
                {
                    cn.Open();
                    SqlCommand cmdHours = new SqlCommand("select cast(sum(hours) as float) from vwTSHoursByTask where list_uid=@listuid and item_id = @itemid", cn);
                    cmdHours.Parameters.AddWithValue("@listuid", listguid);
                    cmdHours.Parameters.AddWithValue("@itemid", li.ID);
                    SqlDataReader dr1 = cmdHours.ExecuteReader();
                    if (dr1.Read())
                        if (!dr1.IsDBNull(0))
                            hours = dr1.GetDouble(0);
                    dr1.Close();

                    li["TimesheetHours"] = hours;
                    li.SystemUpdate();
                    cn.Close();
                }
            }
            catch { }
        }
    }
}
