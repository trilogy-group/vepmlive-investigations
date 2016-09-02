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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace TimeSheets
{
    public partial class savetimesheet : System.Web.UI.Page
    {
        protected string output;
        protected bool useResourcePool;
        private Hashtable hshResources = new Hashtable();
        private string processedTsItems = "";
        private SqlConnection cn;
        string tsuid = "";
        bool timeeditor = false;
        private string[] strFields;
        //SPList pList = null;
        private Guid nonworklist = new Guid();
        string username = SPContext.Current.Web.CurrentUser.LoginName;
        string resName = SPContext.Current.Web.CurrentUser.Name;
        bool impFailed = false;
        string[] dayDefs;

        bool liveHours = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid webGuid = new Guid();
            Guid siteGuid = new Guid();
            Guid listGuid = new Guid();
            SPWeb iWeb = null;
            SPSite iSite = null;
            SPList iList = null;
            SPList pList = null;

            byte[] encodedDataAsBytes = System.Convert.FromBase64String(Request["columns"]);

            strFields = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes).Split('\n');

            if (Request["ids"] != null)
            {
                Response.ContentType = "text/xml";
                Response.ContentEncoding = System.Text.Encoding.UTF8;

                string[] ids = Request["ids"].Split(',');

                output = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data>";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();
                    try
                    {
                        nonworklist = SPContext.Current.Web.Site.RootWeb.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPMLiveTSNonWork")].ID;
                    }
                    catch { }

                    string requestedUser = Page.Request["duser"];

                    if (requestedUser != null && requestedUser != "")
                    {
                        if (SharedFunctions.canUserImpersonate(username, requestedUser, SPContext.Current.Site.RootWeb, out resName))
                        {
                            username = requestedUser;
                        }
                        else
                            impFailed = true;
                    }

                    dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveDaySettings").Split('|');
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSLiveHours"), out liveHours);
                });
                if (impFailed)
                {
                    output += "<action type='error100'>Unable to impersonate for: " + Request["duser"] + "</action>";
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("SELECT tstype_id,tstype_name from TSTYPE where site_uid=@site_id", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@site_id", SPContext.Current.Site.ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        timeeditor = true;
                    }
                    dr.Close();
                    if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPMLiveTSAllowNotes").ToLower() == "true")
                        timeeditor = true;

                    if (cn.State == ConnectionState.Open)
                    {
                        foreach (string id in ids)
                        {
                            if (id != "")
                            {
                                string strWebId = "";
                                string strListId = "";
                                string strSiteId = "";
                                try
                                {
                                    strWebId = Request[id + "_webid"].ToString();
                                }
                                catch { }
                                try
                                {
                                    strListId = Request[id + "_listid"].ToString();
                                }
                                catch { }
                                try
                                {
                                    strSiteId = Request[id + "_siteid"].ToString();
                                }
                                catch { }
                                if (strWebId != "" && strListId != "" && strSiteId != "")
                                {
                                    try
                                    {
                                        Guid wGuid = new Guid(strWebId);
                                        Guid lGuid = new Guid(strListId);
                                        Guid sGuid = new Guid(strSiteId);
                                        if (siteGuid != sGuid)
                                        {
                                            if (iWeb != null)
                                            {
                                                iWeb.Close();
                                                iWeb = null;
                                                iSite.Close();
                                            }
                                            iSite = new SPSite(sGuid);
                                            siteGuid = iSite.ID;
                                        }
                                        if (webGuid != wGuid)
                                        {
                                            if (iWeb != null)
                                            {
                                                iWeb.Close();
                                                iWeb = iSite.OpenWeb(wGuid);
                                            }
                                            else
                                                iWeb = iSite.OpenWeb(wGuid);
                                            webGuid = iWeb.ID;
                                        }
                                        if (listGuid != lGuid)
                                        {
                                            iList = iWeb.Lists[lGuid];
                                            pList = SharedFunctions.getProjectCenterList(iList);
                                            listGuid = iList.ID;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        output += "<action type='error100'>Item: " + Request[id + "_title"].ToString() + " Message: " + ex.Message + "</action>";
                                    }
                                    if (iWeb != null)
                                    {
                                        string status = "";
                                        try
                                        {
                                            status = Request[id + "_!nativeeditor_status"].ToString();
                                        }
                                        catch { }

                                        processItem(id, iWeb, iList, pList);

                                        if(liveHours)
                                        {
                                            
                                            processLiveHours(id, listGuid, iList);
                                        }

                                        if (status != "deleted" && bool.Parse(Request["edit"]))
                                            processWssItem(id, iWeb, iList);

                                    }
                                }
                            }
                        }
                    }

                    SqlCommand cmd1 = new SqlCommand("UPDATE TSTIMESHEET set approval_status=0,lastmodifiedbyu=@u,lastmodifiedbyn=@n where ts_uid=@TS_UID", cn);
                    cmd1.Parameters.AddWithValue("@TS_UID", tsuid);
                    cmd1.Parameters.AddWithValue("@u", SPContext.Current.Web.CurrentUser.LoginName);
                    cmd1.Parameters.AddWithValue("@n", SPContext.Current.Web.CurrentUser.Name);
                    cmd1.ExecuteNonQuery();

                    SharedFunctions.processResources(cn, tsuid, SPContext.Current.Web, username);
                }
                cn.Close();

                output += "<action type='settsuid' tsuid='" + tsuid + "'/>";

                output += "</data>";
            }
        }

        private void processLiveHours(string id, Guid listGuid, SPList list)
        {
            SPListItem li = null;
            double hours = 0;
            try
            {
                string itemid = "";
                try
                {
                    itemid = Request[id + "_itemid"].ToString();
                }
                catch { }

                if (id != "0")
                {
                    li = list.GetItemById(int.Parse(itemid));
                }

                if (li != null)
                {
                    SqlCommand cmdHours = new SqlCommand("select cast(sum(hours) as float) from vwTSHoursByTask where list_uid=@listuid and item_id = @itemid", cn);
                    cmdHours.Parameters.AddWithValue("@listuid", listGuid);
                    cmdHours.Parameters.AddWithValue("@itemid", itemid);
                    SqlDataReader dr1 = cmdHours.ExecuteReader();
                    if (dr1.Read())
                        if (!dr1.IsDBNull(0))
                            hours = dr1.GetDouble(0);
                    dr1.Close();

                    if(li.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                    {
                        li["TimesheetHours"] = hours;

                        list.ParentWeb.AllowUnsafeUpdates = true;

                        li.SystemUpdate();
                    }
                    else
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using(SPSite s = new SPSite(list.ParentWeb.Site.ID))
                            {
                                using(SPWeb w = s.OpenWeb(list.ParentWeb.ID))
                                {
                                    SPList l = w.Lists[listGuid];
                                    SPListItem i = l.GetItemById(li.ID);

                                    i["TimesheetHours"] = hours;

                                    w.AllowUnsafeUpdates = true;

                                    i.SystemUpdate();
                                }
                            }
                        });
                    }
                }
            }
            catch { }
        }

        private void processWssItem(string gr_id, SPWeb web, SPList list)
        {
            if (list.Title == EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTSNonWork"))
            {
                output += "<action type='updatewss' sid='" + gr_id + "' tid='" + gr_id + "'/>";
                return;
            }
            web.AllowUnsafeUpdates = true;
            web.Site.CatchAccessDeniedException = false;
            string status = "";
            string title = "";
            string id = "";
            try
            {
                status = Request[gr_id + "_!nativeeditor_status"].ToString();
            }
            catch { }
            try
            {
                title = Request[gr_id + "_title"].ToString();
            }
            catch { }
            try
            {
                id = Request[gr_id + "_itemid"].ToString();
            }
            catch { }

            int counter = 2;
            string curField = "";
            try
            {
                SPListItem li = null;
                bool added = false;
                try
                {
                    if (id != "0")
                    {
                        li = list.GetItemById(int.Parse(id));
                    }
                }
                catch { }
                if (status != "deleted")
                {
                    foreach (string strField in strFields)
                    {
                        curField = strField;
                        string columnName = gr_id + "_c" + counter.ToString();
                        if (list.Fields.ContainsField(strField))
                        {
                            SPField field = list.Fields.GetFieldByInternalName(strField);
                            curField = field.Title;
                            if (field.InternalName == "Title")
                            {
                            }
                            else
                            {

                                string val = Request[columnName].ToString();
                                if (!field.ReadOnlyField && (field.ShowInEditForm == null || field.ShowInEditForm.Value))
                                {
                                    if (val == "")
                                    {
                                        li[field.Id] = null;
                                    }
                                    else
                                    {
                                        switch (field.Type)
                                        {
                                            case SPFieldType.Calculated:
                                                break;
                                            case SPFieldType.User:
                                                if (field.TypeAsString == "UserMulti")
                                                {
                                                    string[] sUsers = val.Split('\n');
                                                    SPFieldUserValueCollection uvc = new SPFieldUserValueCollection();
                                                    for (int i = 0; i < sUsers.Length; i = i + 2)
                                                    {
                                                        int iGroup = 0;
                                                        if (int.TryParse(sUsers[i], out iGroup))
                                                        {
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, sUsers[i] + ";#" + sUsers[i + 1]);
                                                            uvc.Add(uv);
                                                        }
                                                        else
                                                        {
                                                            SPUser u = web.AllUsers[sUsers[i]];
                                                            SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                            uvc.Add(uv);
                                                        }
                                                    }
                                                    li[field.Id] = uvc;
                                                }
                                                else
                                                {
                                                    string[] sUsers = val.Split('\n');
                                                    if (sUsers.Length > 0)
                                                    {
                                                        SPUser u = web.AllUsers[sUsers[0]];
                                                        SPFieldUserValue uv = new SPFieldUserValue(web, u.ID + ";#" + u.Name);
                                                        li[field.Id] = uv;
                                                    }
                                                }
                                                break;
                                            case SPFieldType.Number:
                                                if (field.SchemaXml.Contains("Percentage=\"TRUE\""))
                                                {
                                                    try
                                                    {
                                                        double fval = double.Parse(val.Replace("%", "")) / 100;
                                                        val = fval.ToString();
                                                    }
                                                    catch { }
                                                }
                                                double fVal = 0;
                                                if (double.TryParse(val, out fVal))
                                                    li[field.Id] = fVal;
                                                else
                                                    li[field.Id] = null;
                                                break;
                                            case SPFieldType.Lookup:
                                                li[strField] = val.Replace("\n", ";#");
                                                break;
                                            case SPFieldType.MultiChoice:
                                                string[] choices = val.Split('\n');
                                                val = ";#";
                                                foreach (string choice in choices)
                                                {
                                                    val += choice.Replace(";#", "\n").Split('\n')[0] + ";#";
                                                }
                                                li[strField] = val;
                                                break;
                                            case SPFieldType.URL:
                                                break;
                                            case SPFieldType.DateTime:
                                                DateTime dt = DateTime.Parse(val);
                                                li[strField] = dt;
                                                break;
                                            case SPFieldType.Choice:
                                                if (val != "")
                                                    li[strField] = val.Replace(";#", "\n").Split('\n')[0];
                                                else
                                                    val = null;
                                                break;
                                            default:
                                                li[strField] = val;
                                                break;
                                        };
                                    }

                                }
                            }
                        }
                        counter++;
                    }
                    curField = "";
                    li.Update();
                    //arrItems.Add(li.ParentList.ParentWeb.ID + "." + li.ParentList.ID + "." + li.ID, new string[1] { null });
                    //queueAllItems.Enqueue(li);
                    //hshSaveGroups.Add("." + li.ParentList.ID + "." + li.ID, gr_id);

                    //if(added)
                    //    output += "<action type='update' sid='" + gr_id + "' tid='." + li.ParentList.ID + "." + li.ID + "'/>";
                    //else
                    output += "<action type='updatewss' sid='" + gr_id + "' tid='" + gr_id + "'/>";
                }
            }
            catch (Exception ex)
            {
                if (curField != "")
                    output += "<action type='error100' sid='" + gr_id + "'><![CDATA[Field: " + curField + "<br>Error: " + ex.Message + "]]></action>";
                else
                    output += "<action type='error100' sid='" + gr_id + "'><![CDATA[" + ex.Message + "]]></action>";
            }


        }

        /*private void processMeta(SPWeb iWeb, SPList iList, SPListItem li, Guid newTS, string project)
        {
            string[] fields = EPMLiveCore.CoreFunctions.getConfigSetting(iWeb.Site.RootWeb, "EPMLiveTSFields-" + System.IO.Path.GetDirectoryName(iList.DefaultView.Url)).Split(',');

            foreach (string field in fields)
            {
                SPField f = null;
                string val = "";
                try
                {
                    f = iList.Fields.GetFieldByInternalName(field);
                    val = f.GetFieldValueAsText(li[f.Id]);
                }
                catch { }
                if (f != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@TS_ITEM_UID,@ColumnName,@DisplayName,@ColumnValue,@ListName)", cn);
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
                fields = EPMLiveCore.CoreFunctions.getConfigSetting(iWeb.Site.RootWeb, "EPMLiveTSFields-Lists\\Project Center").Split(',');

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
                                SqlCommand cmd = new SqlCommand("INSERT INTO TSMETA (TS_ITEM_UID,ColumnName,DisplayName,ColumnValue,ListName) VALUES (@TS_ITEM_UID,@ColumnName,@DisplayName,@ColumnValue,@ListName)", cn);
                                cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
                                cmd.Parameters.AddWithValue("@ColumnName", field);
                                cmd.Parameters.AddWithValue("@DisplayName", f.Title);
                                cmd.Parameters.AddWithValue("@ColumnValue", val);
                                cmd.Parameters.AddWithValue("@ListName", "Project Center");
                                cmd.ExecuteNonQuery();
                            }
                            catch { }
                        }
                    }
                }
            }
        }*/

        private void processItem(string gr_id, SPWeb iWeb, SPList iList, SPList pList)
        {
            string status = "";
            string tsitemuid = "";
            string firstdate = "";
            string datecount = "";
            string fieldcount = "";
            string itemid = "";
            string listid = "";
            string webid = "";
            string siteid = "";
            string title = "";

            if(tsuid == "")
                tsuid = Request["tsuid"];

            try
            {
                status = Request[gr_id + "_!nativeeditor_status"].ToString();
            }
            catch { }
            try
            {
                tsitemuid = Request[gr_id + "_tsitemuid"].ToString();
            }
            catch { }
            try
            {
                firstdate = Request[gr_id + "_firstdate"].ToString();
            }
            catch { }
            try
            {
                datecount = Request[gr_id + "_datecount"].ToString();
            }
            catch { }
            try
            {
                fieldcount = Request[gr_id + "_fieldcount"].ToString();
            }
            catch { }
            try
            {
                itemid = Request[gr_id + "_itemid"].ToString();
            }
            catch { }
            try
            {
                listid = Request[gr_id + "_listid"].ToString();
            }
            catch { }
            try
            {
                webid = Request[gr_id + "_webid"].ToString();
            }
            catch { }
            try
            {
                siteid = Request[gr_id + "_siteid"].ToString();
            }
            catch { }
            try
            {
                title = Request[gr_id + "_title"].ToString();
            }
            catch { }
            if (itemid == "")
            {
                output += "<action type='update' sid='" + gr_id + "'/>";
            }
            else
            {
                if (status == "deleted")
                {
                    if (tsitemuid != "")
                    {
                        SqlCommand cmd = new SqlCommand("DELETE from tsitemhours where ts_item_uid=@itemuid", cn);
                        cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE from tsitem where ts_item_uid=@itemuid", cn);
                        cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                        cmd.ExecuteNonQuery();
                    }
                    output += "<action type='delete' sid='" + gr_id + "'/>";
                }
                else
                {
                    if (tsitemuid != "")
                    {
                        processedTsItems += "," + tsitemuid;
                        try
                        {
                            DateTime dtStart = DateTime.Parse(firstdate);
                            int intFieldCount = int.Parse(fieldcount) + 1;
                            int intDateCount = int.Parse(datecount);
                            SqlCommand cmd;

                            SPListItem li = iList.GetItemById(int.Parse(itemid));

                            cmd = new SqlCommand("UPDATE tsitem set title = @title, approval_status = 0,project_list_uid=@projectlistuid where ts_item_uid=@itemuid", cn);
                            cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                            cmd.Parameters.AddWithValue("@title", li.Title);
                            if(pList!=null)
                                cmd.Parameters.AddWithValue("@projectlistuid", pList.ID);
                            else
                                cmd.Parameters.AddWithValue("@projectlistuid", DBNull.Value);

                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("DELETE from tsitemhours where ts_item_uid=@itemuid", cn);
                            cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                            cmd.ExecuteNonQuery();

                            cmd = new SqlCommand("DELETE from tsnotes where ts_item_uid=@itemuid", cn);
                            cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                            cmd.ExecuteNonQuery();

                            int daycounter = 0;

                            for (int i = 0; i < intDateCount; i++)
                            {
                                try
                                {
                                    string showday = "";
                                    try
                                    {
                                        showday = dayDefs[((int)dtStart.AddDays(daycounter).DayOfWeek) * 3];
                                    }
                                    catch { }
                                    //if (dtStart.AddDays(i).DayOfWeek != DayOfWeek.Sunday && dtStart.AddDays(i).DayOfWeek != DayOfWeek.Saturday)
                                    if (showday == "True")
                                    {
                                        string fieldData = Request[gr_id + "_c" + (intFieldCount + i + 1).ToString()];
                                        if (timeeditor)
                                        {
                                            string[] strFieldData = fieldData.Split('|');
                                            for (int j = 0; j < strFieldData.Length; j += 2)
                                            {
                                                if (strFieldData[j] == "N")
                                                {
                                                    if (strFieldData[j + 1] != "")
                                                    {
                                                        cmd = new SqlCommand("INSERT INTO TSNOTES (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_NOTES) VALUES (@itemuid,@itemdate,@notes)", cn);
                                                        cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                                                        cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                                        cmd.Parameters.AddWithValue("@notes", strFieldData[j + 1]);
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }
                                                else
                                                {
                                                    if (strFieldData[j + 1] != "0")
                                                    {
                                                        cmd = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,@type)", cn);
                                                        cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                                                        cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                                        cmd.Parameters.AddWithValue("@hours", strFieldData[j + 1]);
                                                        cmd.Parameters.AddWithValue("@type", strFieldData[j]);
                                                        cmd.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (fieldData != "0")
                                            {
                                                cmd = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,0)", cn);
                                                cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                                                cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                                cmd.Parameters.AddWithValue("@hours", fieldData.Split(',')[0]);
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                    daycounter++;
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            DateTime dtStart = DateTime.Parse(firstdate);
                            int intFieldCount = int.Parse(fieldcount);
                            int intDateCount = int.Parse(datecount);

                            Guid newTS = Guid.NewGuid();
                            tsitemuid = newTS.ToString();
                            processedTsItems += "," + newTS.ToString();
                            if (tsuid == "")
                            {
                                tsuid = Guid.NewGuid().ToString();
                                SqlCommand cmd1 = new SqlCommand("INSERT INTO TSTIMESHEET (TS_UID,USERNAME,PERIOD_ID,SITE_UID,resourcename) VALUES (@TS_UID,@USERNAME,@PERIOD_ID,@SITE_UID,@resourcename)", cn);
                                cmd1.Parameters.AddWithValue("@TS_UID", tsuid);
                                cmd1.Parameters.AddWithValue("@USERNAME", username);
                                cmd1.Parameters.AddWithValue("@resourcename", resName);
                                cmd1.Parameters.AddWithValue("@PERIOD_ID", Request["period"]);
                                cmd1.Parameters.AddWithValue("@SITE_UID", siteid);

                                cmd1.ExecuteNonQuery();
                            }

                            SPListItem li = iList.GetItemById(int.Parse(itemid));
                            SPField pField = null;
                            string project = "";
                            string project_id = "0";
                            try
                            {
                                pField = li.ParentList.Fields.GetFieldByInternalName("Project");
                            }
                            catch { }
                            if (pField != null && pList != null)
                            {
                                try
                                {
                                    SPFieldLookupValue lv = new SPFieldLookupValue(li["Project"].ToString());
                                    project = lv.LookupValue;
                                    project_id = lv.LookupId.ToString();
                                    if (project == null)
                                    {
                                        project = "";
                                        project_id = "0";
                                    }
                                }
                                catch { }
                            }
                            int itemtype = 1;
                            if (nonworklist == iList.ID)
                                itemtype = 2;

                            SqlCommand cmd = new SqlCommand("INSERT INTO TSITEM (TS_UID,TS_ITEM_UID,WEB_UID,LIST_UID,ITEM_TYPE,ITEM_ID,TITLE,PROJECT,PROJECT_ID,LIST,PROJECT_LIST_UID) VALUES (@TS_UID,@TS_ITEM_UID,@WEB_UID,@LIST_UID,@ITEM_TYPE,@ITEM_ID,@TITLE,@PROJECT,@PROJECT_ID,@LIST,@projectlistuid)", cn);
                            cmd.Parameters.AddWithValue("@TS_UID", tsuid);
                            cmd.Parameters.AddWithValue("@TS_ITEM_UID", newTS);
                            cmd.Parameters.AddWithValue("@WEB_UID", webid);
                            cmd.Parameters.AddWithValue("@LIST_UID", listid);
                            cmd.Parameters.AddWithValue("@ITEM_TYPE", itemtype);
                            cmd.Parameters.AddWithValue("@ITEM_ID", itemid);
                            cmd.Parameters.AddWithValue("@TITLE", title);
                            cmd.Parameters.AddWithValue("@PROJECT", project);
                            cmd.Parameters.AddWithValue("@PROJECT_ID", project_id);
                            cmd.Parameters.AddWithValue("@LIST", li.ParentList.Title);
                            if (pList != null)
                                cmd.Parameters.AddWithValue("@projectlistuid", pList.ID);
                            else
                                cmd.Parameters.AddWithValue("@projectlistuid", DBNull.Value);
                            cmd.ExecuteNonQuery();

                            if(pField != null)
                                SharedFunctions.processMeta(iWeb, iList, li, newTS, project, cn, pList);
                            int daycounter = 0;
                            for (int i = 0; i < intDateCount; i++)
                            {
                                string showday = "";
                                try
                                {
                                    showday = dayDefs[((int)dtStart.AddDays(daycounter).DayOfWeek) * 3];
                                }
                                catch { }
                                //if (dtStart.AddDays(i).DayOfWeek != DayOfWeek.Sunday && dtStart.AddDays(i).DayOfWeek != DayOfWeek.Saturday)
                                if (showday == "True")
                                {
                                    string fieldData = Request[gr_id + "_c" + (intFieldCount + i + 2).ToString()];
                                    if (timeeditor)
                                    {
                                        string[] strFieldData = fieldData.Split('|');
                                        for (int j = 0; j < strFieldData.Length; j += 2)
                                        {
                                            if (strFieldData[j] == "N")
                                            {
                                                if (strFieldData[j + 1] != "")
                                                {
                                                    cmd = new SqlCommand("INSERT INTO TSNOTES (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_NOTES) VALUES (@itemuid,@itemdate,@notes)", cn);
                                                    cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                                                    cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                                    cmd.Parameters.AddWithValue("@notes", strFieldData[j + 1]);
                                                    cmd.ExecuteNonQuery();
                                                }
                                            }
                                            else
                                            {
                                                if (strFieldData[j + 1] != "0")
                                                {
                                                    cmd = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,@type)", cn);
                                                    cmd.Parameters.AddWithValue("@itemuid", tsitemuid);
                                                    cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                                    cmd.Parameters.AddWithValue("@hours", strFieldData[j + 1]);
                                                    cmd.Parameters.AddWithValue("@type", strFieldData[j]);
                                                    cmd.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (fieldData != "0")
                                        {
                                            cmd = new SqlCommand("INSERT INTO TSITEMHOURS (TS_ITEM_UID,TS_ITEM_DATE,TS_ITEM_HOURS,TS_ITEM_TYPE_ID) VALUES (@itemuid,@itemdate,@hours,0)", cn);
                                            cmd.Parameters.AddWithValue("@itemuid", newTS);
                                            cmd.Parameters.AddWithValue("@itemdate", dtStart.AddDays(daycounter));
                                            cmd.Parameters.AddWithValue("@hours", fieldData);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    i--;
                                }
                                daycounter++;
                            }
                        }
                        catch { }
                    }
                    output += "<action type='updateitem' sid='" + gr_id + "' tid='" + gr_id + "' tsitemuid='" + tsitemuid + "'/>";
                }
            }
        }
        
    }
}