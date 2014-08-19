using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ListMappings : LayoutsPageBase, IPostBackEventHandler
    {
        //protected GridView GridView1;
        //protected MenuItemTemplate MenuItemTemplate1;
        //protected MenuItemTemplate MenuItemTemplate2;
        protected ToolBarButton AddList;
        protected SPMenuField ListOptions;
        private string[] _ArrayListNames;
        //protected Panel pnlActionsMenu;
        //protected Panel pnlSettingsMenu;

        private EPMData _DAO;

        private string _RFlistguid;
        private int _RFpctComplete;
        private bool _RFqueued;
        private int _RFstatus;

        private string _SSlistguid;
        private int _SSpctComplete;
        private bool _SSqueued;
        private int _SSstatus;
        protected HiddenField hdnUserId;
        private bool reportingV2Enabled;
        protected ToolBar toolbar;
        protected string version;

        private bool IsListCleanUpEnabled;

        public void RaisePostBackEvent(string sAction)
        {
            string param = sAction.Remove(sAction.LastIndexOf("_"));
            sAction = sAction.Substring(sAction.LastIndexOf("_") + 1);
            switch (sAction)
            {
                case "cleanup":
                    CleanupLists(param);
                    break;

                case "snapshot":
                    SnapshotLists(param);
                    break;

                case "delete":
                    var reportBiz = new ReportBiz(SPContext.Current.Site.ID, SPContext.Current.Web.ID,
                        reportingV2Enabled);
                    var listId = new Guid(param);
                    _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
                    _DAO.AddParam("@RPTListID", param);
                    string sTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
                    DataTable refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
                    if (refTables.Rows.Count == 0)
                    {
                        reportBiz.GetListBiz(new Guid(param)).Delete();
                    }
                    else
                    {
                        SPUtility.Redirect("epmlive/ListMappings.aspx?delete=true&id=" + param + "&name=" + sTableName,
                            SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                    }
                    break;
            }
            SPUtility.Redirect("epmlive/ListMappings.aspx?", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    reportingV2Enabled =
                        Convert.ToBoolean(CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "reportingV2"));
                }
                catch (Exception)
                {
                    reportingV2Enabled = false;
                    SPContext.Current.Site.RootWeb.AllowUnsafeUpdates = true;
                    CoreFunctions.setConfigSetting(SPContext.Current.Site.RootWeb, "reportingV2", "false");
                }

                try
                {
                    IsListCleanUpEnabled =
                     Convert.ToBoolean(CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "epmlivelistcleanup"));
                    if (IsListCleanUpEnabled)
                    {
                        MenuItemTemplate1.Visible = true;
                    }
                }
                catch (Exception)
                {
                    IsListCleanUpEnabled = false;
                    SPContext.Current.Site.RootWeb.AllowUnsafeUpdates = true;
                    CoreFunctions.setConfigSetting(SPContext.Current.Site.RootWeb, "epmlivelistcleanup", "false");
                }

                _DAO = new EPMData(SPContext.Current.Site.ID);
                var rb = new ReportBiz(SPContext.Current.Site.ID, SPContext.Current.Web.ID, reportingV2Enabled);

                if (!rb.SiteExists())
                {
                    string msg =
                        "<p>This site is not currently configured to allow list mapping. A Site Collection Administrator must first map this site to a database.</p>";
                    lblError.Text = msg;
                    lblError.Visible = true;
                    BuildMenu(false);
                    return;
                }

                InitQueueStatus();
                BuildMenu(true);
                FillData();


                if (Request.QueryString["delete"] != null)
                {
                    ShowAlert();
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
        }

        protected void ShowAlert()
        {
            var reportBiz = new ReportBiz(SPContext.Current.Site.ID);
            var listId = new Guid(Request.QueryString["id"]);

            _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
            _DAO.AddParam("@RPTListID", listId);

            string sTableName = Request.QueryString["name"];
            DataTable refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
            string sLists = GetRefLists(refTables);

            string redirectURL = SPContext.Current.Site.ServerRelativeUrl;
            if (!redirectURL.EndsWith("/"))
            {
                redirectURL = redirectURL + "/";
            }

            redirectURL = redirectURL + "_layouts/epmlive/ListMappings.aspx";
            string sAlert =
                "<script language='javascript' type='text/javascript'> if (confirm('Before this list can be deleted the following lists must be deleted first: " +
                sLists + "'))"
                + "{ window.location.href ='" + redirectURL + "'; }" +
                "else { window.location.href = '" + redirectURL + "';}  </script>";
            ClientScript.RegisterStartupScript(GetType(), "EPMLiveWarning", sAlert);
        }

        protected void InitQueueStatus()
        {
            _DAO.GetCleanupQueueStatus(out _RFstatus, out _RFlistguid, out _RFpctComplete, out _RFqueued);
            _DAO.GetSnapshotQueueStatus(out _SSstatus, out _SSlistguid, out _SSpctComplete, out _SSqueued);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            var cn = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate { cn.Open(); });

            try
            {
                if (web.CurrentUser.IsSiteAdmin)
                {
                    var cmd =
                        new SqlCommand(
                            "SELECT ClientUsername, ClientPassword, DatabaseServer, DatabaseName from RPTDATABASES where SiteId=@SiteId",
                            cn);
                    cmd.Parameters.AddWithValue("@SiteId", web.Site.ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            string sCn = "Data Source=" + dr.GetString(2) + ";Initial Catalog=" + dr.GetString(3);


                            string sText = "<br><br><b>Reporting Database Information:</b><br>";
                            sText += "<b>Server:</b> " + dr.GetString(2) + "<br>";
                            sText += "<b>Database:</b> " + dr.GetString(3) + "<br>";
                            sText += "<b>Username:</b> " + dr.GetString(0) + "<br>";
                            sText += "<b>Password:</b> " + dr.GetString(1) + "<br>";
                            sText += "<b>Full Connection String: </b>" + sCn + "<br>";

                            lblAccountInfo.Visible = true;
                            lblAccountInfo.Text = sText;
                        }
                    }
                }
            }
            catch { }
            try
            {
                cn.Close();
            }
            catch { }
        }

        private void LoadLists(DataTable tbl)
        {
            int iIndex = 0;
            _ArrayListNames = new string[tbl.Rows.Count];
            foreach (DataRow row in tbl.Rows)
            {
                _ArrayListNames[iIndex] = row["ListName"].ToString();
                iIndex++;
            }
        }

        private bool IsReportingList(string sListName)
        {
            bool isRep = false;
            foreach (string s in _ArrayListNames)
            {
                if (s.Equals(sListName, StringComparison.CurrentCultureIgnoreCase))
                {
                    isRep = true;
                    break;
                }
            }
            return isRep;
        }

        private void FillData()
        {
            string reportingListIDs = string.Empty;
            Guid siteId = SPContext.Current.Site.ID;
            SPWeb spweb = null;
            var rd = new ReportData(siteId);
            var daoEPMData = new EPMData(siteId);
            LoadLists(rd.GetListMappings());
            using (var spSite = new SPSite(siteId))
            {
                if (reportingV2Enabled)
                    spweb = SPContext.Current.Web;
                else
                    spweb = spSite.OpenWeb();
            }

            string defaultLists = daoEPMData.DefaultLists(spweb);
            string _DefaultLists = CoreFunctions.getConfigSetting(spweb, "EPMLiveFixLists").Replace("\r\n", ",");

            var dtReportData = new DataTable();
            using (var spSite = new SPSite(siteId))
            {
                SPListCollection lists = spweb.Lists;
                foreach (SPList list in lists)
                {
                    if ((!list.Hidden && IsReportingList(list.Title)) || defaultLists.Contains(list.Title) ||
                        _DefaultLists.Contains(list.Title))
                    {
                        reportingListIDs += "'" + list.ID + "',";
                    }
                }

                if (!string.IsNullOrEmpty(reportingListIDs))
                    reportingListIDs = reportingListIDs.Substring(0, reportingListIDs.Length - 1);

                DataView mappings = rd.GetListMappings(reportingListIDs).DefaultView;
                GridView1.DataSource = mappings;
                GridView1.DataBind();
                rd.Dispose();
            }
        }

        protected void AddList_Click(object sender, EventArgs e)
        {
            SPUtility.Redirect("/epmlive/SetupListMapping.aspx", SPRedirectFlags.RelativeToLayoutsPage,
                HttpContext.Current);
        }

        private string GetRefLists(DataTable refTables)
        {
            string sRefLists = string.Empty;
            foreach (DataRow table in refTables.Rows)
            {
                if (!table["oObjName"].ToString().ToLower().Contains("snapshot"))
                {
                    sRefLists = sRefLists + _DAO.GetListName(table["oObjName"].ToString()) + ",";
                }
            }

            sRefLists = sRefLists.Remove(sRefLists.LastIndexOf(","));
            return sRefLists;
        }

        protected void SnapshotLists(string sLists)
        {
            //PROD -- START
            using (SPSite site = SPContext.Current.Site)
            {
                using (SPWeb web = SPContext.Current.Web)
                {
                    Guid listId = _DAO.GetListId(sLists, web.ID);
                    _DAO.Command =
                        "select timerjobuid from timerjobs where siteguid=@siteguid and listguid = @listguid and jobtype=7";
                    _DAO.AddParam("@siteguid", site.ID.ToString());
                    _DAO.AddParam("@listguid", listId.ToString());
                    object oResult = _DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);

                    Guid timerjobuid = Guid.Empty;
                    if (oResult != null)
                    {
                        timerjobuid = (Guid)oResult;
                    }
                    else
                    {
                        timerjobuid = Guid.NewGuid();
                        _DAO.Command =
                            "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, jobdata) VALUES (@timerjobuid, @siteguid, 7, 'Reporting Snapshot', 0, @webguid, @listguid, @jobdata)";
                        _DAO.AddParam("@siteguid", site.ID.ToString());
                        _DAO.AddParam("@webguid", web.ID.ToString());
                        _DAO.AddParam("@listguid", listId.ToString());
                        _DAO.AddParam("@jobdata", sLists);
                        _DAO.AddParam("@timerjobuid", timerjobuid);
                        _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                    }

                    if (timerjobuid != Guid.Empty)
                        CoreFunctions.enqueue(timerjobuid, 0);
                }
            }
            //END
        }

        protected void CleanupLists(string sLists)
        {
            //Prod -- Start
            using (SPSite site = SPContext.Current.Site)
            {
                using (SPWeb web = SPContext.Current.Web)
                {
                    Guid listID = _DAO.GetListId(sLists, web.ID);

                    //DELETE WORK
                    _DAO.DeleteWork(listID, -1);
                    //END

                    _DAO.Command =
                        "select timerjobuid from timerjobs where siteguid=@siteguid and listguid = @listguid and jobtype=6";
                    _DAO.AddParam("@siteguid", site.ID.ToString());
                    _DAO.AddParam("@listguid", listID.ToString());
                    object oResult = _DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);

                    Guid timerjobuid = Guid.Empty;

                    if (oResult != null)
                    {
                        timerjobuid = (Guid)oResult;
                    }
                    else
                    {
                        timerjobuid = Guid.NewGuid();
                        _DAO.Command =
                            "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, listguid, jobdata) VALUES (@timerjobuid, @siteguid, 6, 'List Data Cleanup', 0, @webguid, @listguid, @jobdata)";
                        _DAO.AddParam("@siteguid", site.ID.ToString());
                        _DAO.AddParam("@webguid", web.ID.ToString());
                        _DAO.AddParam("@listguid", listID.ToString());
                        _DAO.AddParam("@jobdata", sLists);
                        _DAO.AddParam("@timerjobuid", timerjobuid);
                        _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                    }

                    if (timerjobuid != Guid.Empty)
                        CoreFunctions.enqueue(timerjobuid, 0);
                }
            }
            //--End
        }

        private void BuildMenu(bool enabled)
        {
            var actionsMenu = new EPMMenu("Actions");
            actionsMenu.Items.Add(new EPMMenuItem("epm01_AddList", "/_layouts/images/newitem.gif",
                "javascript:location.href='setuplistmapping.aspx'; return false", "Add List", "100", enabled));
            if (!_SSqueued)
            {
                actionsMenu.Items.Add(new EPMMenuItem("epm02_SnapshotAll", "images/EPMSnapshot.gif",
                    "submit('SnapshotAll'); return false", "Snapshot All", "100", enabled));
            }

            if (!_RFqueued && IsListCleanUpEnabled)
            {
                //actionsMenu.Items.Add(new EPMMenuItem("epm03_CleanupAll", "images/EPMRefresh.gif", "submit('CleanupAll'); return false", "Cleanup All", "100", enabled));
                actionsMenu.Items.Add(
                    new EPMMenuItem(
                        "epm03_CleanupAll",
                        "images/EPMRefresh.gif",
                        "VerifyThenSubmit(); return false;",
                        "Cleanup All",
                        "100",
                        enabled));
            }
            actionsMenu.Render(pnlActionsMenu);

            var settingsMenu = new EPMMenu("Settings");
            settingsMenu.Items.Add(new EPMMenuItem("epm11_Snapshots", "images/EPMSnapshot.gif",
                "javascript:location.href='allsnapshots.aspx'; return false", "Snapshot Management", "200", enabled));
            settingsMenu.Items.Add(new EPMMenuItem("epm12_Schedule", "/_layouts/images/calendar.gif",
                "javascript:location.href='allschedules.aspx'; return false", "Refresh Schedule", "200", enabled));
            settingsMenu.Render(pnlSettingsMenu);
        }

        //protected string ShowRefresh(string listId)
        //{
        //    if (_RFlistguid == listId.ToString())
        //    {
        //        return "false";
        //    }
        //    else
        //    {
        //        return "true";
        //    }
        //}

        protected string ShowSnapshot(string listId)
        {
            if (_SSlistguid == listId)
            {
                return "false";
            }
            return "true";
        }

        protected string GetIconLink(int type)
        {
            string iconLink = string.Empty;
            int itm;
            object typeMax = Eval(string.Format("Type{0}Max", type));
            object typeLatest = Eval(string.Format("Type{0}Latest", type));

            bool success = int.TryParse(typeMax.ToString(), out itm);

            switch (type)
            {
                case 1:
                    iconLink = (!success || itm < 0)
                        ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                        : string.Format(
                            "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                            "Black",
                            Eval("RPTListId"),
                            type,
                            typeMax);
                    break;

                case 2:
                    if (!_SSqueued)
                    {
                        iconLink = (!success || itm < 0)
                            ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                            : string.Format(
                                "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                "Black",
                                Eval("RPTListId"),
                                type,
                                typeLatest);
                    }
                    else if (_SSlistguid == null || _SSlistguid == string.Empty) // Snapshot All
                    {
                        switch (_SSstatus)
                        {
                            case 0:
                                iconLink = "Queued";
                                break;

                            case 1:
                                iconLink = "Processing(" + _SSpctComplete + "% complete)";
                                ;
                                break;

                            case 2:
                                iconLink = (!success || itm < 0)
                                    ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                    : string.Format(
                                        "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                        "Black",
                                        Eval("RPTListId"),
                                        type,
                                        typeLatest);
                                break;
                        }
                    }
                    else
                    {
                        string listguid = Eval("RPTListId").ToString(); //Snapshot specific list 
                        if (_SSlistguid == listguid)
                        {
                            switch (_SSstatus)
                            {
                                case 0:
                                    iconLink = "Queued";
                                    break;

                                case 1:
                                    iconLink = "Processing(" + _SSpctComplete + "% complete)";
                                    ;
                                    break;

                                case 2:
                                    iconLink = (!success || itm < 0)
                                        ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                        : string.Format(
                                            "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                            "Black",
                                            Eval("RPTListId"),
                                            type,
                                            typeLatest);
                                    break;
                            }
                        }
                        else
                        {
                            iconLink = (!success || itm < 0)
                                ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                : string.Format(
                                    "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                    "Black",
                                    Eval("RPTListId"),
                                    type,
                                    typeLatest);
                        }
                    }
                    break;

                case 3:
                    if (!_RFqueued)
                    {
                        iconLink = (!success || itm < 0)
                            ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                            : string.Format(
                                "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                "Black",
                                Eval("RPTListId"),
                                type,
                                typeLatest);
                    }
                    else if (_RFlistguid == null || _RFlistguid == string.Empty) // Snapshot All
                    {
                        switch (_RFstatus)
                        {
                            case 0:
                                iconLink = "Queued";
                                break;

                            case 1:
                                iconLink = "Processing(" + _RFpctComplete + "% complete)";
                                ;
                                break;

                            case 2:
                                iconLink = (!success || itm < 0)
                                    ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                    : string.Format(
                                        "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                        "Black",
                                        Eval("RPTListId"),
                                        type,
                                        typeLatest);
                                break;
                        }
                    }
                    else
                    {
                        string listguid = Eval("RPTListId").ToString(); //Snapshot specific list 
                        if (_RFlistguid == listguid)
                        {
                            switch (_RFstatus)
                            {
                                case 0:
                                    iconLink = "Queued";
                                    break;

                                case 1:
                                    iconLink = "Processing(" + _RFpctComplete + "% complete)";
                                    ;
                                    break;

                                case 2:
                                    iconLink = (!success || itm < 0)
                                        ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                        : string.Format(
                                            "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                            "Black",
                                            Eval("RPTListId"),
                                            type,
                                            typeLatest);
                                    break;
                            }
                        }
                        else
                        {
                            iconLink = (!success || itm < 0)
                                ? "<img src='images/iconOK.gif' alt='OK' style='border:0' />"
                                : string.Format(
                                    "<a style='color:{0}' href='ReportLog.aspx?ListId={1}&LogType={2}'><img src='images/icon{3}.png' alt='Level{3}' style='border:0' /></a>",
                                    "Black",
                                    Eval("RPTListId"),
                                    type,
                                    typeLatest);
                        }
                    }
                    break;
            }

            if (iconLink.ToLower().Contains("images/iconok.gif"))
            {
                iconLink = string.Empty;
            }

            if (_RFqueued && Eval("RPTListId").ToString() == _RFlistguid)
            {
                MenuItemTemplate1.Visible = false;
            }

            if (_SSqueued && Eval("RPTListId").ToString() == _RFlistguid)
            {
                MenuItemTemplate2.Visible = false;
            }

            return iconLink;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}