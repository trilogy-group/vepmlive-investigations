using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Web;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections;
using EPMLiveCore;
using EPMLiveCore.API;
using System.Diagnostics;

namespace TimeSheets
{
    public class SaveJob : BaseJob
    {

        SPList WorkList;
        private bool Editable = false;
        private string NonUpdatingColumns = "Project,AssignedTo";
        private string ListProjectCenter = "Project Center";
        StringBuilder sbErrors = null;

        private const string TsItemHoursDeleteSql = "DELETE FROM TSITEMHOURS WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE IN ({0})";
        private const string TsItemHoursInsertSql = "INSERT INTO TSITEMHOURS (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID) VALUES ";
        private const string TsItemHoursUpdateSql = "UPDATE TSITEMHOURS SET TS_ITEM_HOURS=@hours, TS_ITEM_TYPE_ID=@type WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE=@dt";
        private const string TsItemNotesDeleteSql = "DELETE FROM TSNOTES WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE IN ({0})";
        private const string TsItemNotesInsertSql = "INSERT INTO TSNOTES (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES) VALUES ";
        private const string TsItemNotesUpdateSql = "UPDATE TSNOTES SET TS_ITEM_NOTES=@notes WHERE TS_ITEM_UID=@id AND TS_ITEM_DATE=@dt";
        private const string TsItemHoursSelectSql = "SELECT TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID FROM TSITEMHOURS WHERE TS_ITEM_UID IN ({0})";
        private const string TsItemNotesSelectSql = "SELECT TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES FROM TSNOTES WHERE TS_ITEM_UID IN ({0})";

        private const string TsItemUidColumnName = "TS_ITEM_UID";
        private const string TsItemDateColumnName = "TS_ITEM_DATE";
        private const string TsItemHoursColumnName = "TS_ITEM_HOURS";
        private const string TsItemTypeIdColumnName = "TS_ITEM_TYPE_ID";
        private const string TsItemNotesColumnName = "TS_ITEM_NOTES";
        private const string UidAttribute = "UID";
        private const string HoursDateXPath = "Hours/Date";
        private const string ValueAttribute = "Value";
        private const string TimeXPath = "Time";
        private const string HoursAttribute = "Hours";
        private const string TypeAttribute = "Type";
        private const string TypeDefaultValue = "0";
        private const string NotesXPath = "Notes";

        private readonly Dictionary<string, List<TsItemHour>> _jobItemHours = new Dictionary<string, List<TsItemHour>>();
        private readonly Dictionary<string, List<TsItemHour>> _dbItemHours = new Dictionary<string, List<TsItemHour>>();
        private readonly Dictionary<string, List<TsItemNote>> _jobItemNotes = new Dictionary<string, List<TsItemNote>>();
        private readonly Dictionary<string, List<TsItemNote>> _dbItemNotes = new Dictionary<string, List<TsItemNote>>();
        private readonly Dictionary<string, List<DateTime>> _jobItemDates = new Dictionary<string, List<DateTime>>();

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
                    case SPFieldType.DateTime:
                        return li[f.Id].ToString();
                    default:
                        return f.GetFieldValueAsText(li[f.Id].ToString());
                }
            }
            catch { }

            return "";
        }

        private static string ReaderGetValue(SqlDataReader reader, string columnName)
        {
            return reader[columnName] == DBNull.Value
                   ? string.Empty
                   : reader[columnName].ToString();
        }

        private void ProcessTimesheetHours(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPWeb web, string period)
        {

            ArrayList arrPeriods = null;
            try
            {
                arrPeriods = TimesheetAPI.GetPeriodDaysArray(cn, settings, web, period);

                ProcessItemHours(id, cn, arrPeriods);
                ProcessItemNotes(id, cn, arrPeriods);
            }
            finally
            {
                arrPeriods = null;
            }
        }

        private void ProcessListFields(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPListItem li, bool recurse, SPList list)
        {
            DataSet ds = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TSMETA where TS_ITEM_UID=@uid and ListName = @list", cn))
                {
                    cmd.Parameters.AddWithValue("@uid", id);
                    cmd.Parameters.AddWithValue("@list", list.Title);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);

                        var fields = GetProjectListFields(list);

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
                                        using (SqlCommand cmd1 = new SqlCommand("UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid", cn))
                                        {
                                            cmd1.Parameters.AddWithValue("@val", newValue);
                                            cmd1.Parameters.AddWithValue("@muid", drTs[0]["TSMETA_UID"].ToString());
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,@list)", cn))
                                        {
                                            cmd2.Parameters.AddWithValue("@uid", id);
                                            cmd2.Parameters.AddWithValue("@col", field);
                                            cmd2.Parameters.AddWithValue("@disp", oField.Title);
                                            cmd2.Parameters.AddWithValue("@val", newValue);
                                            cmd2.Parameters.AddWithValue("@list", list.Title);
                                            cmd2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                using (SqlCommand cmd3 = new SqlCommand("DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName=@list", cn))
                                {
                                    cmd3.Parameters.AddWithValue("@uid", id);
                                    cmd3.Parameters.AddWithValue("@col", field);
                                    cmd3.Parameters.AddWithValue("@list", list.Title);
                                    cmd3.ExecuteNonQuery();
                                }
                            }
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
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }

        }

        private void ProcessTimesheetFields(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings)
        {
            DataSet ds = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TSMETA where TS_ITEM_UID=@uid and ListName='MYTS'", cn))
                {
                    cmd.Parameters.AddWithValue("@uid", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
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
                                        using (SqlCommand cmd1 = new SqlCommand("UPDATE TSMETA SET ColumnValue=@val where TSMETA_UID=@muid", cn))
                                        {
                                            cmd1.Parameters.AddWithValue("@val", newValue);
                                            cmd1.Parameters.AddWithValue("@muid", drTs[0]["TSMETA_UID"].ToString());
                                            cmd1.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@uid,@col,@disp,@val,'MYTS')", cn))
                                        {
                                            cmd2.Parameters.AddWithValue("@uid", id);
                                            cmd2.Parameters.AddWithValue("@col", field);
                                            cmd2.Parameters.AddWithValue("@disp", oField.Title);
                                            cmd2.Parameters.AddWithValue("@val", newValue);
                                            cmd2.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                using (SqlCommand cmd3 = new SqlCommand("DELETE FROM TSMETA WHERE TS_ITEM_UID=@uid and ColumnName=@col and ListName='MYTS'", cn))
                                {
                                    cmd3.Parameters.AddWithValue("@uid", id);
                                    cmd3.Parameters.AddWithValue("@col", field);
                                    cmd3.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (ds != null)
                    ds.Dispose();
            }

        }

        private void ProcessItemRow(XmlNode ndRow, ref DataTable dtItems, SqlConnection cn, SPSite site, ExecuteCache cache, TimesheetSettings settings, string period, string username, bool liveHours, bool bSkipSP)
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
                    string assignedtoid = iGetAttribute(ndRow, "AssignedToID");

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
                                    var web = cache.GetWeb(webid);
                                    SPListItem li = null;
                                    SPList list = null;

                                    try
                                    {
                                        list = web.Lists[new Guid(listid)];
                                        try
                                        {
                                            li = cache.GetListItem(webid, listid, itemid);
                                        }
                                        catch
                                        {
                                        }

                                        // Checking if any customer is using custom projectcenter
                                        string projectListName = string.Empty;
                                        projectListName = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveCustomProjectList");
                                        if (!string.IsNullOrEmpty(projectListName))
                                        {
                                            ListProjectCenter = projectListName;
                                        }

                                        if (li != null)
                                        {
                                            int projectid = 0;
                                            string project = "";
                                            string projectlist = "";
                                            try
                                            {
                                                // Added the check to fix for EPML-5618
                                                if (list.Fields.ContainsField("Project"))
                                                {
                                                    SPFieldLookupValue lv =
                                                        new SPFieldLookupValue(li[list.Fields.GetFieldByInternalName("Project").Id].ToString());
                                                    projectid = lv.LookupId;
                                                    project = lv.LookupValue;
                                                }
                                                else
                                                {
                                                    projectid = li.ID;
                                                    project = li.Title;
                                                }
                                            }
                                            catch
                                            {
                                            }

                                            if (drItem.Length > 0)
                                            {
                                                string rate = SharedFunctions.GetStandardRates(cn, base.TSUID.ToString(), site.RootWeb, username,
                                                    $"{webid}.{web.Lists[ListProjectCenter].ID}.{projectid}");
                                                using (SqlCommand cmd = new SqlCommand(
                                                    "UPDATE TSITEM set Title = @title, project=@project, project_id=@projectid,rate=@rate where ts_item_uid=@uid",
                                                    cn))
                                                {
                                                    cmd.Parameters.AddWithValue("@uid", id);
                                                    cmd.Parameters.AddWithValue("@title",
                                                        li["Title"] == null ? string.Empty : li["Title"].ToString());
                                                    if (projectid == 0)
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", DBNull.Value);
                                                        cmd.Parameters.AddWithValue("@projectid", DBNull.Value);
                                                        cmd.Parameters.AddWithValue("@rate", DBNull.Value);
                                                    }
                                                    else
                                                    {
                                                        cmd.Parameters.AddWithValue("@project", project);
                                                        cmd.Parameters.AddWithValue("@projectid", projectid);
                                                        cmd.Parameters.AddWithValue("@rate", rate);
                                                    }

                                                    cmd.ExecuteNonQuery();
                                                }

                                            }
                                            else
                                            {
                                                try
                                                {
                                                    SPFieldLookup fieldlookup = (SPFieldLookup)list.Fields.GetFieldByInternalName("Project");
                                                    projectlist = fieldlookup.LookupList;

                                                    LogEvent("ProcessItemRow",
                                                        string.Format("Adding item id: {0} to TS: {1}, user id: {2}, assigned To: {3}", li.ID, TSUID,
                                                            assignedtoid, userid),
                                                        site.Url, EventLogEntryType.Information);
                                                }
                                                catch
                                                {
                                                }

                                                using (SqlCommand itemInsertCmd = new SqlCommand(
                                                    @"INSERT INTO TSITEM SELECT DISTINCT TS_UID, case when TS_UID=@currenttsuid then @uidcurrent else NEWID() end,
                                                            @webid,@listid,@itemtype,@itemid,@title,@project,@projectid,@list,0,@projectlistid,@assignedtoid,@rate 
                                                            FROM TSTIMESHEET INNER JOIN TSUSER ON TSTIMESHEET.TSUSER_UID = TSUSER.TSUSERUID 
                                                            WHERE TS_UID=@currenttsuid OR (TS_UID NOT IN (SELECT TS_UID FROM TSITEM WHERE ITEM_ID=@itemid AND ITEM_TYPE = @worktype) 
                                                            AND PERIOD_ID > @currentperiodid AND SUBMITTED = 0 AND TSTIMESHEET.SITE_UID=@siteid AND TSUSEr.USER_ID=@userid)",
                                                    cn))
                                                {
                                                    itemInsertCmd.Parameters.AddWithValue("@currenttsuid", TSUID);
                                                    itemInsertCmd.Parameters.AddWithValue("@currentperiodid", period);
                                                    itemInsertCmd.Parameters.AddWithValue("@userid", userid);
                                                    itemInsertCmd.Parameters.AddWithValue("@siteid", site.ID);
                                                    itemInsertCmd.Parameters.AddWithValue("@worktype", itemtypeid);
                                                    itemInsertCmd.Parameters.AddWithValue("@uidcurrent", id);
                                                    itemInsertCmd.Parameters.AddWithValue("@webid", web.ID);
                                                    itemInsertCmd.Parameters.AddWithValue("@listid", list.ID);
                                                    itemInsertCmd.Parameters.AddWithValue("@itemid", li.ID);
                                                    itemInsertCmd.Parameters.AddWithValue("@title",
                                                        li["Title"] == null ? string.Empty : li["Title"].ToString());
                                                    itemInsertCmd.Parameters.AddWithValue("@list", list.Title);
                                                    itemInsertCmd.Parameters.AddWithValue("@itemtype", itemtypeid);
                                                    itemInsertCmd.Parameters.AddWithValue("@assignedtoid", assignedtoid);
                                                    string rate = SharedFunctions.GetStandardRates(cn, base.TSUID.ToString(), site.RootWeb, username,
                                                        $"{webid}.{web.Lists[ListProjectCenter].ID}.{projectid}");
                                                    itemInsertCmd.Parameters.AddWithValue("@rate", rate);
                                                    if (projectlist == "")
                                                        itemInsertCmd.Parameters.AddWithValue("@projectlistid", DBNull.Value);
                                                    else
                                                        itemInsertCmd.Parameters.AddWithValue("@projectlistid", projectlist);

                                                    if (projectid == 0)
                                                    {
                                                        itemInsertCmd.Parameters.AddWithValue("@project", DBNull.Value);
                                                        itemInsertCmd.Parameters.AddWithValue("@projectid", DBNull.Value);
                                                    }
                                                    else
                                                    {
                                                        itemInsertCmd.Parameters.AddWithValue("@project", project);
                                                        itemInsertCmd.Parameters.AddWithValue("@projectid", projectid);
                                                    }

                                                    itemInsertCmd.ExecuteNonQuery();
                                                }
                                            }

                                            ProcessTimesheetHours(id, ndRow, cn, settings, web, period);

                                            if (!bSkipSP)
                                            {
                                                if (WorkList != null)
                                                    ProcessTimesheetFields(id, ndRow, cn, settings);

                                                /*if (Editable)
                                                {
                                                    //PROCESS LI
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


                                                        li.SystemUpdate();
                                                    }


                                                }*/

                                                ProcessListFields(id, ndRow, cn, settings, li, true, list);

                                                //if (liveHours)
                                                //    processLiveHours(li, list.ID);

                                                //if (Editable)
                                                //    li.Update();
                                                //else
                                                //    li.SystemUpdate();

                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        bErrors = true;
                                        sbErrors.Append("Item (" + id + ") Error: " + ex.ToString());
                                    }
                                    finally
                                    {
                                        li = null;
                                        list = null;
                                    }

                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                bErrors = true;
                                sbErrors.Append("Item (" + id + ") missing item id");
                            }
                        }
                        else
                        {
                            bErrors = true;
                            sbErrors.Append("Item (" + id + ") missing list id");
                        }
                    }
                    else
                    {
                        bErrors = true;
                        sbErrors.Append("Item (" + id + ") missing web id");
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("Item (" + id + ") Error x2: " + ex.ToString());
                }
                if (drItem.Length > 0)
                {
                    dtItems.Rows.Remove(drItem[0]);
                }
            }
            else
            {
                bErrors = true;
                sbErrors.Append("Could not get id for item");
            }
        }

        public void execute(SPSite site, string data)
        {
            sbErrors = new StringBuilder();
            SPUser user = null;
            TimesheetSettings settings = null;
            DataSet dsItems = null;
            SPUser editUser = null;
            XmlNodeList ndItems = null;
            try
            {
                try
                {
                    WorkList = site.RootWeb.Lists["My Work"];
                }
                catch { }

                XmlDocument docTimesheet = new XmlDocument();
                docTimesheet.LoadXml(data);
                WebAppId = site.WebApplication.Id;
                using (SqlConnection cn = CreateConnection())
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT   dbo.TSUSER.USER_ID,dbo.TSUSER.USERNAME FROM         dbo.TSUSER INNER JOIN dbo.TSTIMESHEET ON dbo.TSUSER.TSUSERUID = dbo.TSTIMESHEET.TSUSER_UID WHERE TS_UID=@tsuid", cn))
                        {
                            cmd.Parameters.AddWithValue("@tsuid", base.TSUID);
                            string username = string.Empty;
                            int userid = 0;
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    userid = dr.GetInt32(0);
                                    username = dr.GetString(1);
                                }

                            }
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
                                user = TimesheetAPI.GetUser(site.RootWeb, userid.ToString());

                                if (user.ID != userid)
                                {
                                    bErrors = true;
                                    sbErrors.Append("You do not have access to edit that timesheet.");
                                }
                                else
                                {
                                    settings = new TimesheetSettings(site.RootWeb);

                                    dsItems = new DataSet();

                                    editUser = site.RootWeb.AllUsers.GetByID(base.userid);

                                    using (SqlCommand cmd1 = new SqlCommand("UPDATE TSTIMESHEET SET LASTMODIFIEDBYU=@uname, LASTMODIFIEDBYN=@name where TS_UID=@tsuid", cn))
                                    {
                                        cmd1.Parameters.AddWithValue("@uname", editUser.LoginName);
                                        cmd1.Parameters.AddWithValue("@name", editUser.Name);
                                        cmd1.Parameters.AddWithValue("@tsuid", base.TSUID);
                                        cmd1.ExecuteNonQuery();

                                        using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM TSITEM WHERE TS_UID=@tsuid", cn))
                                        {
                                            cmd2.Parameters.AddWithValue("@tsuid", base.TSUID);
                                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                                            da.Fill(dsItems);
                                            DataTable dtItems = dsItems.Tables[0];

                                            string period = "";

                                            using (SqlCommand cmd3 = new SqlCommand("SELECT period_id FROM TSTIMESHEET WHERE TS_UID=@tsuid", cn))
                                            {
                                                cmd3.Parameters.AddWithValue("@tsuid", base.TSUID);
                                                using (SqlDataReader drts = cmd3.ExecuteReader())
                                                {
                                                    if (drts.Read())
                                                    {
                                                        period = drts.GetInt32(0).ToString();
                                                    }

                                                }
                                                ndItems = docTimesheet.FirstChild.SelectNodes("Item");

                                                float percent = 0;
                                                float count = 0;
                                                float total = ndItems.Count;

                                                LoadJobItems(ndItems);
                                                LoadDbItems(cn);

                                                using (var cache = new ExecuteCache(site))
                                                {
                                                    string preloadErrors;
                                                    var preloadHasErrors =
                                                        cache.PreloadListItems(ndItems.Cast<XmlNode>().Select(i =>
                                                            new SaveDataJobExecuteCache.ListItemInfo
                                                            {
                                                                WebId = iGetAttribute(i, "WebID"),
                                                                ListId = iGetAttribute(i, "ListID"),
                                                                ListItemId = iGetAttribute(i, "ItemID")
                                                            }), out preloadErrors);
                                                    if (preloadHasErrors)
                                                    {
                                                        bErrors = true;
                                                        sbErrors.Append(preloadErrors);
                                                    }

                                                    foreach (XmlNode ndItem in ndItems)
                                                    {
                                                        string worktype = "";

                                                        try
                                                        {
                                                            worktype = ndItem.Attributes["WorkTypeField"].Value;
                                                        }
                                                        catch
                                                        {
                                                        }

                                                        ProcessItemRow(ndItem, ref dtItems, cn, site, cache, settings, period, username, liveHours,
                                                            worktype == settings.NonWorkList);

                                                        count++;
                                                        float pct = count / total * 98;

                                                        if (pct >= percent + 10)
                                                        {
                                                            using (SqlCommand cmd4 = new SqlCommand(
                                                                "update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid", cn))
                                                            {
                                                                cmd4.Parameters.AddWithValue("@queueuid", QueueUid);
                                                                cmd4.Parameters.AddWithValue("@pct", pct);
                                                                cmd4.ExecuteNonQuery();
                                                            }

                                                            percent = pct;
                                                        }
                                                    }
                                                }

                                                using (SqlCommand cmd5 = new SqlCommand("update TSQUEUE set percentcomplete=98 where TSQUEUE_ID=@QueueUid", cn))
                                                {
                                                    cmd5.Parameters.AddWithValue("@queueuid", QueueUid);
                                                    cmd5.ExecuteNonQuery();
                                                }

                                                foreach (DataRow drDelItem in dtItems.Rows)
                                                {
                                                    using (SqlCommand cmd6 = new SqlCommand("DELETE FROM TSITEM where TS_ITEM_UID=@uid", cn))
                                                    {
                                                        cmd6.Parameters.AddWithValue("@uid", drDelItem["TS_ITEM_UID"].ToString());
                                                        cmd6.ExecuteNonQuery();
                                                    }
                                                }

                                                //if (liveHours)
                                                //    sErrors += processActualWork(cn, TSUID.ToString(), site, true, false);

                                                using (SqlCommand cmd7 = new SqlCommand("update TSQUEUE set percentcomplete=99 where TSQUEUE_ID=@QueueUid", cn))
                                                {
                                                    cmd7.Parameters.AddWithValue("@queueuid", QueueUid);
                                                    cmd7.ExecuteNonQuery();
                                                }
                                                SharedFunctions.processResources(cn, TSUID.ToString(), site.RootWeb, user.LoginName);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bErrors = true;
                                sbErrors.Append("Timesheet does not exist");
                            }
                            if (liveHours)
                            {
                                using (SqlCommand cmd8 = new SqlCommand("INSERT INTO TSQUEUE (TS_UID, STATUS, JOBTYPE_ID, USERID, JOBDATA) VALUES (@tsuid, 0, 32, @userid, @jobdata)", cn))
                                {
                                    cmd8.Parameters.AddWithValue("@tsuid", TSUID);
                                    cmd8.Parameters.AddWithValue("@userid", userid);
                                    cmd8.Parameters.AddWithValue("@jobdata", data);
                                    cmd8.ExecuteNonQuery();
                                }
                            }
                            if (SaveAndSubmit)
                                TimesheetAPI.SubmitTimesheet("<Timesheet ID=\"" + base.TSUID + "\" />", site.RootWeb);
                        }
                    }
                    catch (Exception e)
                    {
                        bErrors = true;
                        sbErrors.Append("Error: " + e.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("Error: " + ex.ToString());
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                user = null;
                settings = null;
                editUser = null;
                ndItems = null;
                if (dsItems != null)
                    dsItems = null;
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

        public class TsItemHour
        {
            public TsItemHour(string id, DateTime date, string hours, string type)
            {
                Id = id;
                Date = date;
                Hours = hours;
                Type = type;
            }

            public string Id { get; }
            public DateTime Date { get; }
            public string Hours { get; }
            public string Type { get; }
        }

        public class TsItemNote
        {
            public TsItemNote(string id, DateTime date, string notes)
            {
                Id = id;
                Date = date;
                Notes = notes;
            }

            public string Id { get; }
            public DateTime Date { get; }
            public string Notes { get; }
        }

        public sealed class ExecuteCache : IDisposable
        {
            private readonly SPSite _site;
            private readonly Dictionary<string, SPWeb> _websCache = new Dictionary<string, SPWeb>();

            /// <summary>
            /// Mapping of tuples of Web ID and List ID to SPListItemCollection
            /// </summary>
            private readonly Dictionary<Tuple<string, string>, SPListItemCollection> _itemsCache = new Dictionary<Tuple<string, string>, SPListItemCollection>();

            public ExecuteCache(SPSite site)
            {
                _site = site;
            }

            public SPWeb GetWeb(string id)
            {
                SPWeb result;
                id = id.ToUpperInvariant();
                if (!_websCache.TryGetValue(id, out result))
                {
                    result = _site.OpenWeb(new Guid(id));
                    _websCache.Add(id, result);
                }

                return result;
            }

            /// <summary>
            /// Bulk loading of list items
            /// </summary>
            /// <param name="items">Triples of Web ID, List ID and Item ID</param>
            /// <param name="errors"></param>
            /// <returns>Tuple of error presence flag and error message</returns>
            public bool PreloadListItems(IEnumerable<SaveDataJobExecuteCache.ListItemInfo> items, out string errors)
            {
                var groupByLists = items
                    .Where(i => !string.IsNullOrEmpty(i.WebId) && !string.IsNullOrEmpty(i.ListId) && !string.IsNullOrEmpty(i.ListItemId))
                    .GroupBy(i => CreateItemCacheKey(i.WebId, i.ListId), i => i.ListItemId);
                var anyError = false;
                var errorsBuilder = new StringBuilder();
                foreach (var listInfo in groupByLists)
                {
                    try
                    {
                        var web = GetWeb(listInfo.Key.Item1);
                        var list = web.Lists[new Guid(listInfo.Key.Item2)];
                        var query = new SPQuery();
                        query.RowLimit = (uint)listInfo.Count();
                        var values = string.Join(string.Empty, listInfo.Select(itemId => $"<Value Type='Counter'>{itemId}</Value>"));
                        query.Query = $"<Where><In><FieldRef Name='ID' /><Values>{values}</Values></In></Where>";
                        var fields = new[] { "ID", "Title", "Project" }
                            .Concat(GetProjectListFields(list))
                            .ToArray();
                        query.ViewFields = string.Join(string.Empty, fields.Select(name => $"<FieldRef Name='{name}'/>"));
                        query.MeetingInstanceId = -2; // It is part of SPList.GetItemById() implementation and so kept here
                        _itemsCache.Add(listInfo.Key, list.GetItems(query));
                    }
                    catch (Exception ex)
                    {
                        anyError = true;
                        errorsBuilder.Append($"Items ({string.Join(", ", listInfo)}) Error: {ex}");
                    }
                }

                errors = errorsBuilder.ToString();
                return anyError;
            }

            public SPListItem GetListItem(string webId, string listId, string itemId)
            {
                return _itemsCache[CreateItemCacheKey(webId, listId)].GetItemById(int.Parse(itemId));
            }

            private static Tuple<string, string> CreateItemCacheKey(string webId, string listId)
            {
                return Tuple.Create(webId.ToUpperInvariant(), listId.ToUpperInvariant());
            }

            void IDisposable.Dispose()
            {
                foreach (var web in _websCache.Values)
                {
                    web.Dispose();
                }
            }
        }

        private static string[] GetProjectListFields(SPList list)
        {
            return CoreFunctions
                .getConfigSetting(list.ParentWeb.Site.RootWeb,
                    "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(list.DefaultView == null
                        ? list.DefaultViewUrl
                        : list.DefaultView.Url))
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        }

        private void DeleteItemHours(string id, SqlConnection connection, List<TsItemHour> items)
        {
            var dates = items.Select(item => item.Date)
                             .Distinct()
                             .ToArray();

            var parameters = string.Join(",", Enumerable.Range(0, dates.Length).Select(i => $"@dt{i}"));

            using (var cmd = new SqlCommand(string.Format(TsItemHoursDeleteSql, parameters), connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                for (var i = 0; i < dates.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@dt{i}", dates[i]);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateItemHours(string id, SqlConnection connection, List<TsItemHour> items)
        {
            foreach (var tsItemHour in items)
            {
                using (var cmd = new SqlCommand(TsItemHoursUpdateSql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dt", tsItemHour.Date);
                    cmd.Parameters.AddWithValue("@hours", tsItemHour.Hours);
                    cmd.Parameters.AddWithValue("@type", tsItemHour.Type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertItemHours(string id, SqlConnection connection, List<TsItemHour> items)
        {
			if (!items.Any())
				return;
			StringBuilder insertStatement = new StringBuilder(TsItemHoursInsertSql);

			using (var cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandTimeout = 0;
				int itemIndex = 0;
				foreach (var tsItemHour in items)
				{
					insertStatement.Append(string.Format("(@id{0}, @dt{0}, @hours{0}, @type{0}),", itemIndex));
	
					cmd.Parameters.AddWithValue("@id" + itemIndex, id);
					cmd.Parameters.AddWithValue("@dt" + itemIndex, tsItemHour.Date);
					cmd.Parameters.AddWithValue("@hours" + itemIndex, tsItemHour.Hours);
					cmd.Parameters.AddWithValue("@type" + itemIndex, tsItemHour.Type);
					itemIndex++;
				}
				cmd.CommandText = insertStatement.ToString().TrimEnd(',');
				cmd.ExecuteNonQuery();
			}
        }

        private void DeleteItemNotes(string id, SqlConnection connection, List<TsItemNote> items)
        {
            var dates = items.Select(item => item.Date)
                             .Distinct()
                             .ToArray();

            var parameters = string.Join(",", Enumerable.Range(0, dates.Length).Select(i => $"@dt{i}"));

            using (var cmd = new SqlCommand(string.Format(TsItemNotesDeleteSql, parameters), connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                for (var i = 0; i < dates.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@dt{i}", items[i].Date);
                }

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateItemNotes(string id, SqlConnection connection, List<TsItemNote> items)
        {
            foreach (var tsItemNote in items)
            {
                using (var cmd = new SqlCommand(TsItemNotesUpdateSql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dt", tsItemNote.Date);
                    cmd.Parameters.AddWithValue("@notes", tsItemNote.Notes);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertItemNotes(string id, SqlConnection connection, List<TsItemNote> items)
        {
			if (!items.Any())
				return;
			StringBuilder insertStatement = new StringBuilder(TsItemNotesInsertSql);

			using (var cmd = new SqlCommand())
			{
				cmd.Connection = connection;
				cmd.CommandTimeout = 0;
				int itemIndex = 0;
				foreach (var tsItemNote in items)
				{
					insertStatement.Append(string.Format("(@id{0}, @dt{0}, @notes{0}),", itemIndex));

					cmd.Parameters.AddWithValue("@id" + itemIndex, id);
					cmd.Parameters.AddWithValue("@dt" + itemIndex, tsItemNote.Date);
					cmd.Parameters.AddWithValue("@notes" + itemIndex, tsItemNote.Notes);
					itemIndex++;
				}
				cmd.CommandText = insertStatement.ToString().TrimEnd(',');
				cmd.ExecuteNonQuery();
			}
        }

        private void ProcessItemHours(string id, SqlConnection connection, ArrayList arrPeriods)
        {
            var jobItems = _jobItemHours.ContainsKey(id) 
                ? _jobItemHours[id] 
                : new List<TsItemHour>();
            var dbItems = _dbItemHours.ContainsKey(id) 
                ? _dbItemHours[id] 
                : new List<TsItemHour>();
            var dates = _jobItemDates.ContainsKey(id) 
                ? _jobItemDates[id] 
                : new List<DateTime>();
            
            dbItems.RemoveAll(item => !arrPeriods.Contains(item.Date));

            var itemsToInsert = new List<TsItemHour>();
            var itemsToUpdate = new List<TsItemHour>();
            foreach (var date in dates.Distinct())
            {
                if (!arrPeriods.Contains(date))
                {
                    continue;
                }

                var jobItemsDate = jobItems.Where(item => item.Date == date)
                                           .ToArray();

                if (!jobItemsDate.Any())
                {
                    continue;
                }

                if (jobItemsDate.Length > 1)
                {
                    itemsToInsert.AddRange(jobItemsDate);
                    continue;
                }

                var dbItemsDate = dbItems.Where(item => item.Date == date)
                                         .ToArray();

                if (dbItemsDate.Length == 1)
                {
                    var dbItem = dbItemsDate.First();
                    var jobItem = jobItemsDate.First();
                    if (dbItem.Hours != jobItem.Hours 
                        || dbItem.Type != jobItem.Type)
                    {
                        itemsToUpdate.Add(jobItem);
                    }
                    dbItems.Remove(dbItem);
                }
                else
                {
                    itemsToInsert.AddRange(jobItemsDate);
                }
            }
            
            if (dbItems.Any())
            {
                DeleteItemHours(id, connection, dbItems);
            }

            if (itemsToUpdate.Any())
            {
                UpdateItemHours(id, connection, itemsToUpdate);
            }

            if (itemsToInsert.Any())
            {
                InsertItemHours(id, connection, itemsToInsert);
            }
        }

        private void ProcessItemNotes(string id, SqlConnection connection, ArrayList arrPeriods)
        {
            var jobNotes = _jobItemNotes.ContainsKey(id) 
                ? _jobItemNotes[id] 
                : new List<TsItemNote>();
            var dbNotes = _dbItemNotes.ContainsKey(id) 
                ? _dbItemNotes[id] 
                : new List<TsItemNote>();
            var dates = _jobItemDates.ContainsKey(id) 
                ? _jobItemDates[id] 
                : new List<DateTime>();

            dbNotes.RemoveAll(item => !arrPeriods.Contains(item.Date));

            var itemsToInsert = new List<TsItemNote>();
            var itemsToUpdate = new List<TsItemNote>();
            foreach (var date in dates.Distinct())
            {
                if (!arrPeriods.Contains(date))
                {
                    continue;
                }
                
                var jobNotesDate = jobNotes.Where(item => item.Date == date)
                                           .ToArray();

                if (!jobNotesDate.Any())
                {
                    continue;
                }

                var jobNote = jobNotesDate.First();

                var dbNotesDate = dbNotes.Where(item => item.Date == date)
                                         .ToArray();

                if (dbNotesDate.Length == 1)
                {
                    var dbNote = dbNotesDate.First();
                    if (dbNote.Notes != jobNote.Notes)
                    {
                        itemsToUpdate.Add(jobNote);
                    }
                    dbNotes.Remove(dbNote);
                }
                else
                {
                    itemsToInsert.Add(jobNote);
                }
            }
            
            if (dbNotes.Any())
            {
                DeleteItemNotes(id, connection, dbNotes);
            }

            if (itemsToUpdate.Any())
            {
                UpdateItemNotes(id, connection, itemsToUpdate);
            }

            if (itemsToInsert.Any())
            {
                InsertItemNotes(id, connection, itemsToInsert);
            }
        }

        private void LoadJobItems(XmlNodeList ndItems)
        {
            foreach (XmlNode ndItem in ndItems)
            {
                var id = iGetAttribute(ndItem, UidAttribute);

                if (!_jobItemHours.ContainsKey(id))
                {
                    _jobItemHours.Add(id, new List<TsItemHour>());
                }

                if (!_jobItemNotes.ContainsKey(id))
                {
                    _jobItemNotes.Add(id, new List<TsItemNote>());
                }

                if (!_jobItemDates.ContainsKey((id)))
                {
                    _jobItemDates.Add(id, new List<DateTime>());
                }

                var itemHours = _jobItemHours[id];
                var itemNotes = _jobItemNotes[id];
                var itemDates = _jobItemDates[id];
                
                foreach (XmlNode ndDate in ndItem.SelectNodes(HoursDateXPath))
                {
                    DateTime date;
                    if (!DateTime.TryParse(iGetAttribute(ndDate, ValueAttribute), out date))
                    {
                        continue;
                    }
                    
                    itemDates.Add(date);

                    foreach (XmlNode ndTime in ndDate.SelectNodes(TimeXPath))
                    {
                        var hours = iGetAttribute(ndTime, HoursAttribute);
                        var type = iGetAttribute(ndTime, TypeAttribute);

                        if (string.IsNullOrWhiteSpace(type))
                        {
                            type = TypeDefaultValue;
                        }

                        itemHours.Add(new TsItemHour(id, date, hours, type));
                    }

                    var ndNotes = ndDate.SelectSingleNode(NotesXPath);
                    if (ndNotes != null)
                    {
                        var notes = HttpUtility.UrlDecode(ndNotes.InnerText);
                        itemNotes.Add(new TsItemNote(id, date, notes));
                    }
                }
            }
        }

        private void LoadDbItems(SqlConnection connection)
        {
            if (!_jobItemDates.Any())
            {
                return;
            }

            var ids = string.Join(",", _jobItemDates.Keys.Select(key => $"'{key}'"));

            using (var cmd = new SqlCommand(string.Format(TsItemHoursSelectSql, ids), connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = ReaderGetValue(reader, TsItemUidColumnName);
                        DateTime date;
                        if (!DateTime.TryParse(ReaderGetValue(reader, TsItemDateColumnName), out date))
                        {
                            continue;
                        }

                        if (_jobItemDates[id].Contains(date))
                        {
                            var hours = ReaderGetValue(reader, TsItemHoursColumnName);
                            var type = ReaderGetValue(reader, TsItemTypeIdColumnName);

                            if (!_dbItemHours.ContainsKey(id))
                            {
                                _dbItemHours.Add(id, new List<TsItemHour>());
                            }

                            _dbItemHours[id].Add(new TsItemHour(id, date, hours, type));
                        }
                    }
                }
            }

            using (var cmd = new SqlCommand(string.Format(TsItemNotesSelectSql, ids), connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = ReaderGetValue(reader, TsItemUidColumnName);
                        DateTime date;
                        if (!DateTime.TryParse(ReaderGetValue(reader, TsItemDateColumnName), out date))
                        {
                            continue;
                        }

                        if (_jobItemDates[id].Contains(date))
                        {
                            var notes = ReaderGetValue(reader, TsItemNotesColumnName);

                            if (!_dbItemNotes.ContainsKey(id))
                            {
                                _dbItemNotes.Add(id, new List<TsItemNote>());
                            }

                            _dbItemNotes[id].Add(new TsItemNote(id, date, notes));
                        }
                    }
                }
            }
        }

        private void LogEvent(string eventSource, string message, string siteName, EventLogEntryType type = EventLogEntryType.Information)
        {
            if (!EventLog.SourceExists(eventSource))
                EventLog.CreateEventSource(eventSource, "EPM Live");

            var eventLog = new EventLog("EPM Live", ".", eventSource) { MaximumKilobytes = 32768 };

            eventLog.WriteEntry(
                string.Format($"Name: {siteName}, Source: {eventSource}: {message}"), type);
        }
    }
}


