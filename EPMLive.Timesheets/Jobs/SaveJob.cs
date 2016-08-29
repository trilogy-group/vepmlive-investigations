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
    public class SaveJob : BaseJob
    {

        SPList WorkList;
        private bool Editable = false;
        private string NonUpdatingColumns = "Project,AssignedTo";
        StringBuilder sbErrors = null;
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

        private void ProcessTimesheetHours(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPWeb web, string period)
        {

            ArrayList arrPeriods = null;
            try
            {
                arrPeriods = TimesheetAPI.GetPeriodDaysArray(cn, settings, web, period);
                foreach (XmlNode ndDate in ndRow.SelectNodes("Hours/Date"))
                {
                    DateTime dt = DateTime.Parse(ndDate.Attributes["Value"].Value);

                    if (arrPeriods.Contains(dt))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM TSITEMHOURS where TS_ITEM_UID=@id and TS_ITEM_DATE=@dt", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@dt", dt);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd1 = new SqlCommand("DELETE FROM TSNOTES where TS_ITEM_UID=@id and TS_ITEM_DATE=@dt", cn))
                        {
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.Parameters.AddWithValue("@dt", dt);
                            cmd1.ExecuteNonQuery();
                        }

                        foreach (XmlNode ndTime in ndDate.SelectNodes("Time"))
                        {
                            string hours = iGetAttribute(ndTime, "Hours");
                            string type = "0";
                            try
                            {
                                type = ndTime.Attributes["Type"].Value;
                            }
                            catch { }

                            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_HOURS, TS_ITEM_TYPE_ID) VALUES (@id,@dt,@hours,@type)", cn))
                            {
                                cmd2.Parameters.AddWithValue("@id", id);
                                cmd2.Parameters.AddWithValue("@dt", dt);
                                cmd2.Parameters.AddWithValue("@hours", hours);
                                cmd2.Parameters.AddWithValue("@type", type);
                                cmd2.ExecuteNonQuery();
                            }

                        }

                        XmlNode ndNotes = ndDate.SelectSingleNode("Notes");
                        if (ndNotes != null)
                        {
                            using (SqlCommand cmd3 = new SqlCommand("INSERT INTO TSNOTES (TS_ITEM_UID, TS_ITEM_DATE, TS_ITEM_NOTES) VALUES (@id,@dt,@notes)", cn))
                            {
                                cmd3.Parameters.AddWithValue("@id", id);
                                cmd3.Parameters.AddWithValue("@dt", dt);
                                cmd3.Parameters.AddWithValue("@notes", System.Web.HttpUtility.UrlDecode(ndNotes.InnerText));
                                cmd3.ExecuteNonQuery();
                            }
                        }

                    }
                }
            }
            finally
            {
                arrPeriods = null;
            }


        }

        private void ProcessListFields(string id, XmlNode ndRow, SqlConnection cn, TimesheetSettings settings, SPListItem li, bool recurse, SPList list)
        {
            ArrayList fields = null;
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

                        fields = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(list.ParentWeb.Site.RootWeb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)).Split(','));

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
                fields = null;
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
                                    using (SPWeb web = site.OpenWeb(new Guid(webid)))
                                    {
                                        SPListItem li = null;

                                        SPList list = null;

                                        try
                                        {
                                            list = web.Lists[new Guid(listid)];

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
                                                    // Added the check to fix for EPML-5618
                                                    if (list.Fields.ContainsField("Project"))
                                                    {
                                                        SPFieldLookupValue lv = new SPFieldLookupValue(li[list.Fields.GetFieldByInternalName("Project").Id].ToString());
                                                        projectid = lv.LookupId;
                                                        project = lv.LookupValue;
                                                    }
                                                    else
                                                    {
                                                        projectid = li.ID;
                                                        project = li.Title;
                                                    }
                                                }
                                                catch { }

                                                if (drItem.Length > 0)
                                                {
                                                    using (SqlCommand cmd = new SqlCommand("UPDATE TSITEM set Title = @title, project=@project, project_id=@projectid where ts_item_uid=@uid", cn))
                                                    {
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

                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        SPFieldLookup fieldlookup = (SPFieldLookup)list.Fields.GetFieldByInternalName("Project");
                                                        projectlist = fieldlookup.LookupList;
                                                    }
                                                    catch { }

                                                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_ID,ITEM_TYPE,TITLE, PROJECT,PROJECT_ID, LIST,PROJECT_LIST_UID,ASSIGNEDTOID) VALUES(@tsuid,@uid,@webid,@listid,@itemid,@itemtype,@title,@project,@projectid,@list,@projectlistid,@assignedtoid)", cn))
                                                    {
                                                        cmd.Parameters.AddWithValue("@tsuid", TSUID);
                                                        cmd.Parameters.AddWithValue("@uid", id);
                                                        cmd.Parameters.AddWithValue("@webid", web.ID);
                                                        cmd.Parameters.AddWithValue("@listid", list.ID);
                                                        cmd.Parameters.AddWithValue("@itemid", li.ID);
                                                        cmd.Parameters.AddWithValue("@title", li["Title"].ToString());
                                                        cmd.Parameters.AddWithValue("@list", list.Title);
                                                        cmd.Parameters.AddWithValue("@itemtype", itemtypeid);
                                                        cmd.Parameters.AddWithValue("@assignedtoid", assignedtoid);

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
                                            sbErrors.Append("Item (" + id + ") Error: " + ex.Message);
                                        }
                                        finally
                                        {
                                            li = null;
                                            list = null;
                                        }

                                    }

                                }
                                catch { }
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
                    sbErrors.Append("Item (" + id + ") Error x2: " + ex.Message);
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

                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                    cn.Open();
                });

                using (SqlCommand cmd = new SqlCommand("SELECT     dbo.TSUSER.USER_ID FROM         dbo.TSUSER INNER JOIN dbo.TSTIMESHEET ON dbo.TSUSER.TSUSERUID = dbo.TSTIMESHEET.TSUSER_UID WHERE TS_UID=@tsuid", cn))
                {
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
                                            drts.Close();
                                        }
                                        ndItems = docTimesheet.FirstChild.SelectNodes("Item");

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
                                                using (SqlCommand cmd4 = new SqlCommand("update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid", cn))
                                                {
                                                    cmd4.Parameters.AddWithValue("@queueuid", QueueUid);
                                                    cmd4.Parameters.AddWithValue("@pct", pct);
                                                    cmd4.ExecuteNonQuery();
                                                }

                                                percent = pct;
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

                    cn.Close();

                    if (SaveAndSubmit)
                        TimesheetAPI.SubmitTimesheet("<Timesheet ID=\"" + base.TSUID + "\" />", site.RootWeb);
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("Error: " + ex.Message);
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




    }
}
