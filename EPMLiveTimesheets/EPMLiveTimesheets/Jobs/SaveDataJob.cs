using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections;
using EPMLiveCore;
using EPMLiveCore.API;

namespace TimeSheets
{
    class SaveDataJob : BaseJob
    {
        private string NonUpdatingColumns = "Project,AssignedTo";
        SPList WorkList;

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

                //bool SaveAndSubmit = false;
                //try
                //{
                //    SaveAndSubmit = bool.Parse(docTimesheet.FirstChild.Attributes["SaveAndSubmit"].Value);
                //}
                //catch { }

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
                        cmd = new SqlCommand("update TSQUEUE set percentcomplete=1 where TSQUEUE_ID=@QueueUid", cn);
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        cmd.ExecuteNonQuery();

                        TimesheetSettings settings = new TimesheetSettings(site.RootWeb);

                        DataSet dsItems = new DataSet();

                        SPUser editUser = site.RootWeb.AllUsers.GetByID(base.userid);

                        cmd = new SqlCommand("SELECT * FROM TSITEM WHERE TS_UID=@tsuid", cn);
                        cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dsItems);
                        DataTable dtItems = dsItems.Tables[0];

                        XmlNodeList ndItems = docTimesheet.FirstChild.SelectNodes("Item");

                        float percent = 0;
                        float count = 0;
                        float total = ndItems.Count;

                        cmd = new SqlCommand("update TSQUEUE set percentcomplete=2 where TSQUEUE_ID=@QueueUid", cn);
                        cmd.Parameters.AddWithValue("@queueuid", QueueUid);
                        cmd.ExecuteNonQuery();

                        foreach (XmlNode ndItem in ndItems)
                        {
                            string worktype = "";

                            try
                            {
                                worktype = ndItem.Attributes["WorkTypeField"].Value;
                            }
                            catch { }

                            ProcessItemRow(ndItem, ref dtItems, cn, site, settings, liveHours, worktype == settings.NonWorkList);

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

                        if (liveHours)
                            sErrors += processActualWork(cn, TSUID.ToString(), site, true, false);
                    }
                }
                else
                {
                    bErrors = true;
                    sErrors = "Timesheet does not exist";
                }

                cn.Close();

            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors = "Error: " + ex.Message;
            }
        }

        private void ProcessItemRow(XmlNode ndRow, ref DataTable dtItems, SqlConnection cn, SPSite site, TimesheetSettings settings, bool liveHours, bool bSkipSP)
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
                                                li = list.GetItemById(int.Parse(itemid));
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


                                                //PROCESS LI

                                                if (iGetAttribute(ndRow, "Edited") == "1")
                                                {
                                                    GridGanttSettings gSettings = new GridGanttSettings(list);
                                                    Dictionary<string, Dictionary<string, string>> fieldProperties = ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);
                                                    if (ndRow.Attributes != null)
                                                    {
                                                        foreach (XmlAttribute attr in ndRow.Attributes)
                                                        {
                                                            if (!NonUpdatingColumns.Contains(attr.Name))
                                                            {
                                                                SPField spField = li.Fields.TryGetFieldByStaticName(attr.Name);
                                                                if (spField != null)
                                                                {
                                                                    if (EditableFieldDisplay.isEditable(li, spField, fieldProperties))
                                                                    {
                                                                        string newValue = iGetAttribute(ndRow, spField.InternalName);

                                                                        switch (spField.Type)
                                                                        {
                                                                            case SPFieldType.Choice:
                                                                            case SPFieldType.Text:
                                                                                if (Convert.ToString(li[spField.InternalName]) != newValue)
                                                                                {
                                                                                    li[spField.InternalName] = newValue;
                                                                                }
                                                                                break;
                                                                            case SPFieldType.Boolean:
                                                                                if (!String.IsNullOrEmpty(newValue))
                                                                                {
                                                                                    Boolean newBooleanValue = Convert.ToBoolean(newValue);
                                                                                    if (Convert.ToBoolean(li[spField.InternalName]) != newBooleanValue)
                                                                                    {
                                                                                        li[spField.InternalName] = newBooleanValue;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.Currency:
                                                                                if (!String.IsNullOrEmpty(newValue))
                                                                                {
                                                                                    Double newCurrencyValue = Convert.ToDouble(newValue);
                                                                                    if (Convert.ToDouble(li[spField.InternalName]) != newCurrencyValue)
                                                                                    {
                                                                                        li[spField.InternalName] = newCurrencyValue;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.Number:
                                                                                if (!String.IsNullOrEmpty(newValue))
                                                                                {
                                                                                    Double newDoubleValue = Convert.ToDouble(newValue);
                                                                                    if (Convert.ToDouble(li[spField.InternalName]) != newDoubleValue)
                                                                                    {
                                                                                        if (((SPFieldNumber)spField).ShowAsPercentage)
                                                                                        {
                                                                                            newDoubleValue = newDoubleValue / 100;
                                                                                        }
                                                                                        li[spField.InternalName] = newDoubleValue;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.DateTime:
                                                                                if (!String.IsNullOrEmpty(newValue))
                                                                                {
                                                                                    DateTime newDateTimeValue = Convert.ToDateTime(newValue);
                                                                                    if (Convert.ToDateTime(li[spField.InternalName]) != newDateTimeValue)
                                                                                    {
                                                                                        li[spField.InternalName] = newDateTimeValue;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.Integer:
                                                                                if (!String.IsNullOrEmpty(newValue))
                                                                                {
                                                                                    Int64 newInt64Value = Convert.ToInt64(newValue);
                                                                                    if (Convert.ToInt64(li[spField.InternalName]) != newInt64Value)
                                                                                    {
                                                                                        li[spField.InternalName] = newInt64Value;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.User:
                                                                            case SPFieldType.Lookup:
                                                                                var spFieldLookup = (SPFieldLookup)spField;
                                                                                if (spFieldLookup != null && !string.IsNullOrEmpty(spFieldLookup.LookupList))
                                                                                {
                                                                                    SPList spLookuplist = web.Lists[new Guid(spFieldLookup.LookupList)];
                                                                                    if (spLookuplist != null)
                                                                                    {
                                                                                        SPFieldLookupValueCollection spFLVCIds = new SPFieldLookupValueCollection();

                                                                                        foreach (string itemId in newValue.Split(';'))
                                                                                        {
                                                                                            Int32 newInt32IdValue;
                                                                                            if (Int32.TryParse(itemId, out newInt32IdValue))
                                                                                            {
                                                                                                spFLVCIds.Add(new SPFieldLookupValue(newInt32IdValue.ToString()));
                                                                                            }
                                                                                        }

                                                                                        li[spField.InternalName] = spFLVCIds;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case SPFieldType.MultiChoice:
                                                                                SPFieldMultiChoiceValue spFMCVIds = new SPFieldMultiChoiceValue();
                                                                                foreach (string itemId in newValue.Split(';'))
                                                                                {
                                                                                    spFMCVIds.Add(itemId);
                                                                                }
                                                                                li[spField.InternalName] = spFMCVIds;
                                                                                break;
                                                                            default:
                                                                                break;
                                                                        }
                                                                    }

                                                                }
                                                            }

                                                        }
                                                    }
                                                }

                                                if (liveHours)
                                                    processLiveHours(li, list.ID);

                                                li.Update();

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

                    cn.Close();
                }
            }
            catch { }
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

        private static string iGetAttribute(XmlNode nd, string attribute)
        {
            try
            {
                return nd.Attributes[attribute].Value;
            }
            catch { }
            return "";
        }
    }
}
