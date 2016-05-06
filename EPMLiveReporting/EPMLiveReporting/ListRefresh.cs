using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using EPMLiveCore;
using Microsoft.SharePoint;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin
{
    public class RefreshLists
    {
        private readonly ReportData _DAO;
        private readonly string _sListNames;

        private readonly SPWeb _web;
        private string[] _ArrayListNames;
        private ArrayList _ArrayListTableNames;
        private ArrayList _arrayListdefaultColumns;
        private DataSet _dsLists;
        private DataSet _dsMyWorkLists;
        private string _sTableName;
        private Guid _siteID;

        public RefreshLists(SPWeb web, string sListNames)
        {
            //Init. DAO
            _web = web;
            _DAO = new ReportData(web.Site.ID);
            _sListNames = sListNames;
            Initialize(web, sListNames);
        }

        public RefreshLists() { }

        private void Initialize(SPWeb web, string sListNames)
        {
            char[] splitter = ",".ToCharArray();


            //Check list of lists
            if (sListNames != string.Empty)
            {
                if (sListNames.Contains(",")) //Has multiple lists
                {
                    _ArrayListNames = sListNames.Split(splitter);
                }
                else //Single list
                {
                    _ArrayListNames = new string[1];
                    _ArrayListNames[0] = sListNames;
                }
            }
            else
            {
                LoadLists();
            }

            //Init. ArrayList of siteId's and tableNames
            _ArrayListTableNames = new ArrayList();

            //Init. list dataset
            _dsLists = new DataSet();
            _dsMyWorkLists = new DataSet();

            //Init. default columns
            PopulateDefaultColumns();
        }

        public void StartRefresh(Guid timerjobguid, out DataTable dtResults, bool refreshAll)
        {
            DataTable dt = InitializeResultsDT(_sListNames, refreshAll);
            string _errorListName = string.Empty;
            try
            {
                SPList spList = null;
                string sSiteIdListName = string.Empty;
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (_web)
                    {
                        if (refreshAll)
                        {
                            // we need to refresh work hours 
                            // and resources first because 
                            // SPProcessAssignments depends on data in LSTWorkHours and LSTResources

                            #region refresh work hours list

                            SPList lworkhours = _web.Lists.TryGetList("Work Hours");

                            //if (lworkhours == null)
                            //{  
                            //    _DAO.LogStatus(
                            //        string.Empty, 
                            //        string.Empty, 
                            //        "Work Hours list does not exist at web: " + _web.ID + ".", 
                            //        "Work Hours list does not exist at web: " + _web.ID + ".", 
                            //        2, 
                            //        3, 
                            //        timerjobguid.ToString()); 
                            //}

                            // if a reporting list
                            if (lworkhours != null && IsReportingList("Work Hours"))
                            {
                                try
                                {
                                    _errorListName = "Work Hours";
                                    //Clear out dataset
                                    _dsLists = new DataSet();
                                    _dsMyWorkLists = new DataSet();

                                    spList = null;
                                    _sTableName = _DAO.GetTableName(lworkhours.ID);
                                    _siteID = _web.ID;
                                    //Add sSiteIdListName string to array, that will be used to create dyn. sql to do a batch delete
                                    _ArrayListTableNames.Add(_sTableName);
                                    //throw new System.InvalidOperationException("exeception handling test");
                                    bool error;
                                    string sErrMsg;
                                    AddItems(timerjobguid, lworkhours.Title, out error, out sErrMsg);
                                    //Add all current list items to the database (from the corresponding sharepoint list)
                                    if (error)
                                    {
                                        DataRow[] dr = dt.Select("ListName='" + lworkhours.Title + "'");
                                        if (sErrMsg.ToLower().Contains("does not exist at site with url"))
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                      "List not present.";
                                            }
                                        }
                                        else
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + sErrMsg;
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErrMsg;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    DataRow[] dr = dt.Select("ListName='" + lworkhours.Title + "'");
                                    if (ex.Message.ToLower().Contains("does not exist at site with url")) { }
                                    else
                                    {
                                        if (dr[0]["ResultText"] == null)
                                        {
                                            dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                        }
                                        else
                                        {
                                            dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                        }
                                    }
                                }

                                if (_dsLists.Tables.Count > 0)
                                {
                                    _DAO.InsertAllItemsDB(_dsLists, timerjobguid);
                                }
                            }

                            #endregion // refresh work hours list

                            #region refresh resources list

                            SPList lResource = _web.Lists.TryGetList("Resources");
                            //if (lResource == null)
                            //{
                            //    _DAO.LogStatus(
                            //        string.Empty,
                            //        string.Empty,
                            //        "Resources list does not exist at web: " + _web.ID + ".",
                            //        "Resources list does not exist at web: " + _web.ID + ".",
                            //        2,
                            //        3,
                            //        timerjobguid.ToString()); 
                            //}
                            // if a reporting list
                            if (lResource != null && IsReportingList("Resources"))
                            {
                                try
                                {
                                    _errorListName = "Resources";
                                    //Clear out dataset
                                    _dsLists = new DataSet();
                                    _dsMyWorkLists = new DataSet();

                                    spList = null;
                                    _sTableName = _DAO.GetTableName(lResource.Title);
                                    _siteID = _web.ID;
                                    //Add sSiteIdListName string to array, that will be used to create dyn. sql to do a batch delete
                                    _ArrayListTableNames.Add(_sTableName);
                                    //throw new System.InvalidOperationException("exeception handling test");
                                    bool error;
                                    string sErrMsg;
                                    AddItems(timerjobguid, lResource.Title, out error, out sErrMsg);
                                    //Add all current list items to the database (from the corresponding sharepoint list)
                                    if (error)
                                    {
                                        DataRow[] dr = dt.Select("ListName='" + lResource.Title + "'");
                                        if (sErrMsg.ToLower().Contains("does not exist at site with url"))
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                      "List not present.";
                                            }
                                        }
                                        else
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + sErrMsg;
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErrMsg;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    DataRow[] dr = dt.Select("ListName='" + lResource.Title + "'");
                                    if (ex.Message.ToLower().Contains("does not exist at site with url")) { }
                                    else
                                    {
                                        if (dr[0]["ResultText"] == null)
                                        {
                                            dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                        }
                                        else
                                        {
                                            dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                        }
                                    }
                                }

                                if (_dsLists.Tables.Count > 0)
                                {
                                    _DAO.InsertAllItemsDB(_dsLists, timerjobguid);
                                }
                            }

                            #endregion // refresh work hours list

                            #region refresh all

                            var allLists =
                                new List<string>(_sListNames.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries));
                            var allSpLists = new List<SPList>();
                            foreach (string l in allLists)
                            {
                                SPList list = _web.Lists.TryGetList(l);

                                if (list != null)
                                {
                                    allSpLists.Add(list);
                                }

                                if (list == null ||
                                    list.Title == "Work Hours" ||
                                    list.Title == "Resources")
                                {
                                    continue;
                                }

                                _errorListName = list.Title;

                                //Clear out dataset
                                _dsLists = new DataSet();
                                _dsMyWorkLists = new DataSet();

                                // if a mywork list
                                var settings = new GridGanttSettings(list);
                                if (settings.EnableWorkList)
                                {
                                    try
                                    {
                                        _sTableName = "LSTMyWork";
                                        _siteID = _web.ID;
                                        bool error;
                                        string sErrMsg;
                                        AddItems_MyWork(timerjobguid, list.Title, list.ID, out error, out sErrMsg);
                                        if (error)
                                        {
                                            DataRow[] dr = dt.Select("ListName='" + list.Title + "'");
                                            if (sErrMsg.ToLower().Contains("does not exist at site with url"))
                                            {
                                                if (dr[0]["ResultText"] == null)
                                                {
                                                    dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                                }
                                                else
                                                {
                                                    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                          "List not present.";
                                                }
                                            }
                                            else
                                            {
                                                if (dr[0]["ResultText"] == null)
                                                {
                                                    dr[0]["ResultText"] = "&nbsp;" + sErrMsg;
                                                }
                                                else
                                                {
                                                    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErrMsg;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        DataRow[] dr = dt.Select("ListName='" + list.Title + "'");
                                        if (ex.Message.ToLower().Contains("does not exist at site with url")) { }
                                        else
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                            }
                                        }
                                    }

                                    if (_dsMyWorkLists.Tables.Count > 0)
                                    {
                                        _DAO.InsertAllItemsDB(_dsMyWorkLists, timerjobguid);
                                    }
                                }

                                // if a reporting list
                                if (IsReportingList(list.Title))
                                {
                                    try
                                    {
                                        spList = null;
                                        _sTableName = _DAO.GetTableName(list.ID);
                                        _siteID = _web.ID;
                                        //Add sSiteIdListName string to array, that will be used to create dyn. sql to do a batch delete
                                        _ArrayListTableNames.Add(_sTableName);
                                        //throw new System.InvalidOperationException("exeception handling test");
                                        bool error;
                                        string sErrMsg;
                                        AddItems(timerjobguid, list.Title, out error, out sErrMsg);
                                        //Add all current list items to the database (from the corresponding sharepoint list)
                                        if (error)
                                        {
                                            DataRow[] dr = dt.Select("ListName='" + list.Title + "'");
                                            if (sErrMsg.ToLower().Contains("does not exist at site with url"))
                                            {
                                                if (dr[0]["ResultText"] == null)
                                                {
                                                    dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                                }
                                                else
                                                {
                                                    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                          "List not present.";
                                                }
                                            }
                                            else
                                            {
                                                if (dr[0]["ResultText"] == null)
                                                {
                                                    dr[0]["ResultText"] = "&nbsp;" + sErrMsg;
                                                }
                                                else
                                                {
                                                    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErrMsg;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        DataRow[] dr = dt.Select("ListName='" + list.Title + "'");
                                        if (ex.Message.ToLower().Contains("does not exist at site with url")) { }
                                        else
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                            }
                                        }
                                    }

                                    if (_dsLists.Tables.Count > 0)
                                    {
                                        _DAO.InsertAllItemsDB(_dsLists, timerjobguid);
                                    }
                                }
                            }

                            #endregion // refresh all lists

                            #region refresh security groups for all lists

                            try
                            {
                                ProcessSecurity.ProcessSecurityOnRefreshAll(_web, allSpLists,
                                    _DAO.GetClientReportingConnection());
                                _DAO.LogStatus(
                                    string.Empty,
                                    string.Empty,
                                    "ProcessSecurity processed successfully on refresh all for web: " + _web.Title,
                                    "ProcessSecurity processed successfully on refresh all for web: " + _web.Title,
                                    0,
                                    1,
                                    timerjobguid.ToString());
                            }
                            catch (Exception ex)
                            {
                                _DAO.LogStatus(
                                    string.Empty,
                                    string.Empty,
                                    "ProcessSecurity failed on refresh all.",
                                    ex.Message,
                                    2,
                                    3,
                                    timerjobguid.ToString());
                            }

                            #endregion
                        }
                        else
                        {
                            #region refreshing individual lists

                            //loop thru all lists
                            foreach (string sListName in _ArrayListNames)
                            {
                                try
                                {
                                    _errorListName = sListName;

                                    //set to null
                                    spList = null;

                                    //Init. list
                                    spList = _web.Lists[sListName];

                                    //Init. list sqltable name
                                    _sTableName = _DAO.GetTableName(spList.ID);//_DAO.GetTableName(sListName);

                                    //Init. web id
                                    _siteID = _web.ID;

                                    //Add sSiteIdListName string to array, that will be used to create dyn. sql to do a batch delete
                                    _ArrayListTableNames.Add(_sTableName);

                                    //Delete items in LSTMyWork associated to this list, then re-add
                                    var settings = new GridGanttSettings(spList);
                                    if (settings.EnableWorkList)
                                    {
                                        _DAO.DeleteMyWork(spList.ID);

                                        try
                                        {
                                            _sTableName = "LSTMyWork";
                                            _siteID = _web.ID;
                                            bool bError;
                                            string sErr;
                                            AddItems_MyWork(timerjobguid, spList.Title, spList.ID, out bError, out sErr);
                                            if (bError)
                                            {
                                                DataRow[] dr = dt.Select("ListName='" + spList.Title + "'");
                                                if (sErr.ToLower().Contains("does not exist at site with url"))
                                                {
                                                    if (dr[0]["ResultText"] == null)
                                                    {
                                                        dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                                    }
                                                    else
                                                    {
                                                        dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                              "List not present.";
                                                    }
                                                }
                                                else
                                                {
                                                    if (dr[0]["ResultText"] == null)
                                                    {
                                                        dr[0]["ResultText"] = "&nbsp;" + sErr;
                                                    }
                                                    else
                                                    {
                                                        dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErr;
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            DataRow[] dr = dt.Select("ListName='" + spList.Title + "'");
                                            if (ex.Message.ToLower().Contains("does not exist at site with url")) { }
                                            else
                                            {
                                                if (dr[0]["ResultText"] == null)
                                                {
                                                    dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                                }
                                                else
                                                {
                                                    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                                }
                                            }
                                        }

                                        if (_dsMyWorkLists.Tables.Count > 0)
                                        {
                                            _DAO.InsertAllItemsDB(_dsMyWorkLists, timerjobguid);
                                        }
                                    }

                                    //throw new System.InvalidOperationException("exeception handling test");

                                    bool error;
                                    string sErrMsg;
                                    _sTableName = _DAO.GetTableName(spList.ID);
                                    AddItems(timerjobguid, sListName, out error, out sErrMsg);

                                    //Add all current list items to the database (from the corresponding sharepoint list)
                                    //AddItems(timerjobguid,sListName);

                                    if (error)
                                    {
                                        DataRow[] dr = dt.Select("ListName='" + sListName + "'");
                                        if (sErrMsg.ToLower().Contains("does not exist at site with url"))
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" +
                                                                      "List not present.";
                                            }
                                        }
                                        else
                                        {
                                            if (dr[0]["ResultText"] == null)
                                            {
                                                dr[0]["ResultText"] = "&nbsp;" + sErrMsg;
                                            }
                                            else
                                            {
                                                dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + sErrMsg;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    DataRow[] dr = dt.Select("ListName='" + sListName + "'");
                                    if (ex.Message.ToLower().Contains("does not exist at site with url"))
                                    {
                                        //DO NOTHING...
                                        //if (dr[0]["ResultText"] == null)
                                        //{
                                        //    dr[0]["ResultText"] = "&nbsp;" + "List not present.";
                                        //}
                                        //else
                                        //{
                                        //    dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + "List not present.";
                                        //}
                                    }
                                    else
                                    {
                                        if (dr[0]["ResultText"] == null)
                                        {
                                            dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                        }
                                        else
                                        {
                                            dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                        }
                                    }
                                }

                                #region refresh security groups for list

                                try
                                {
                                    if (spList != null)
                                    {
                                        ProcessSecurity.ProcessSecurityOnListRefresh(_web, spList,
                                            _DAO.GetClientReportingConnection());
                                        _DAO.LogStatus(
                                            string.Empty,
                                            string.Empty,
                                            "ProcessSecurity processed successfully on list: " + spList.Title +
                                            " in web: " + _web.Title,
                                            "ProcessSecurity processed successfully on list: " + spList.Title +
                                            " in web: " + _web.Title,
                                            0,
                                            1,
                                            timerjobguid.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    DataRow[] dr = dt.Select("ListName='" + sListName + "'");
                                    if (dr[0]["ResultText"] == null)
                                    {
                                        dr[0]["ResultText"] = "&nbsp;" + ex.Message;
                                    }
                                    else
                                    {
                                        dr[0]["ResultText"] = dr[0]["ResultText"] + "&nbsp;" + ex.Message;
                                    }
                                }

                                #endregion
                            }

                            if (_dsLists.Tables.Count > 0)
                            {
                                _DAO.InsertAllItemsDB(_dsLists, timerjobguid);
                            }

                            #endregion
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                _DAO.LogStatus(string.Empty, string.Empty,
                    "Refresh not completed due to error. Web: " + _web.Title + ". List: " + _errorListName + ". Error: " +
                    ex.Message, ex.StackTrace, 2, 3, timerjobguid.ToString());
            }

            _DAO.Dispose();
            dtResults = dt;
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

        private void LoadLists()
        {
            DataTable tbl = _DAO.GetListMappings();
            int iIndex = 0;
            _ArrayListNames = new string[tbl.Rows.Count];
            foreach (DataRow row in tbl.Rows)
            {
                _ArrayListNames[iIndex] = row["ListName"].ToString();
                iIndex++;
            }
        }

        private void AddItems(Guid timerjobguid, string sListName, out bool error, out string sErrMsg)
        {
            //init. list datatable
            DataTable dtList = _DAO.ListItemsDataTable(timerjobguid, _sTableName, _web, sListName,
                _arrayListdefaultColumns, out error, out sErrMsg);
            //Assign sql tablename to list
            dtList.TableName = _sTableName;
            //add list to dslists 
            _dsLists.Tables.Add(dtList);
        }

        private void AddItems_MyWork(Guid timerjobguid, string sListName, Guid listId, out bool error, out string sErrMsg)
        {
            //init. list datatable
            DataTable dtList = _DAO.MyWorkListItemsDataTable(timerjobguid, _sTableName, _web, sListName,
                _arrayListdefaultColumns, listId, out error, out sErrMsg);

            //Assign sql tablename to list
            dtList.TableName = _sTableName;

            //add list to _dsMyWorkLists 
            _dsMyWorkLists.Tables.Add(dtList);
        }

        public void AppendStatus(string webName, string webUrl, DataTable dtListResults, DataTable dtWebResults)
        {
            DataRow[] drWebListResult = null;
            string sMessage = string.Empty;

            //Loop thru all lists
            foreach (DataRow dr in dtListResults.Rows)
            {
                //Select list results from web results by LISTNAME
                drWebListResult = dtWebResults.Select("ListName='" + dr["ListName"] + "'");
                sMessage = string.Empty;

                //Checking for any existing error messages for this list from another web.
                if (dr["ResultText"] != null && dr["ResultText"].ToString() != string.Empty)
                {
                    //Initialize current error messages for this list.
                    sMessage = dr["ResultText"].ToString();
                }

                //Check for any list errors (records will ONLY be added to dtWebResults unless there is an error
                if (drWebListResult != null && drWebListResult.Length > 0)
                {
                    if (drWebListResult[0]["ResultText"] != null &&
                        drWebListResult[0]["ResultText"].ToString() != string.Empty)
                    {
                        //Adding check here for "Value Does Not Fall Within Expected Range" = List Not Present and is NOT an Level2 Error.
                        if (!drWebListResult[0]["ResultText"].ToString().ToLower().Contains("list not present"))
                        {
                            if (sMessage != string.Empty)
                            {
                                sMessage = sMessage + "Processing Web: " + webName + " (" + webUrl +
                                           ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Failed:<font style='color:red'>" +
                                           drWebListResult[0]["ResultText"] + "</font><br/>";
                            }
                            else
                            {
                                sMessage = "Processing Web: " + webName + " (" + webUrl +
                                           ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Failed:<font style='color:red'>" +
                                           drWebListResult[0]["ResultText"] + "</font><br/>";
                            }
                        }
                        else
                        {
                            if (sMessage != string.Empty)
                            {
                                sMessage = sMessage + "Processing Web: " + webName + " (" + webUrl +
                                           ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List not present. <br/>";
                            }
                            else
                            {
                                sMessage = "Processing Web: " + webName + " (" + webUrl +
                                           ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List not present. <br/>";
                            }
                        }
                    }
                    else
                    {
                        if (sMessage != string.Empty)
                        {
                            sMessage = sMessage + "Processing Web: " + webName + " (" + webUrl +
                                       ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; success.<br/>";
                        }
                        else
                        {
                            sMessage = "Processing Web: " + webName + " (" + webUrl +
                                       ") <br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; success.<br/>";
                        }
                    }
                    // -- END
                }

                //Update list results message
                dr["ResultText"] = sMessage;
            }
        }

        public bool SaveResults(DataTable dtResults, Guid timerjobguid)
        {
            var dtResultsFinal = new DataTable();
            dtResultsFinal.Columns.Add("RPTListId", Type.GetType("System.Guid"));
            dtResultsFinal.Columns.Add("ListName");
            dtResultsFinal.Columns.Add("ShortMessage");
            dtResultsFinal.Columns.Add("LongMessage");
            dtResultsFinal.Columns.Add("Level", Type.GetType("System.Int32"));
            dtResultsFinal.Columns.Add("Type", Type.GetType("System.Int32"));
            dtResultsFinal.Columns.Add("Timestamp", Type.GetType("System.DateTime"));
            dtResultsFinal.Columns.Add("timerjobguid", Type.GetType("System.Guid"));

            foreach (DataRow row in dtResults.Rows)
            {
                int iLevel = GetLevel((string) row["ResultText"]);
                string shortMessage = string.Empty;
                if (iLevel == 2)
                {
                    shortMessage = "Processed with errors.";
                }
                else
                {
                    shortMessage = "Processed successfully without errors.";
                }
                DataRow resultsFinalRow = dtResultsFinal.NewRow();
                resultsFinalRow["Level"] = iLevel;
                Guid guid = _DAO.GetListId(row["ListName"].ToString());
                if (guid != Guid.Empty)
                {
                    resultsFinalRow["RPTListId"] = guid;
                }
                resultsFinalRow["ListName"] = row["ListName"];
                resultsFinalRow["ShortMessage"] = shortMessage;
                resultsFinalRow["LongMessage"] = row["ResultText"];
                resultsFinalRow["Type"] = 3;
                resultsFinalRow["Timestamp"] = DateTime.Now;
                resultsFinalRow["timerjobguid"] = timerjobguid;
                dtResultsFinal.Rows.Add(resultsFinalRow);
            }

            var ds = new DataSet();
            dtResultsFinal.TableName = "RPTLog";
            ds.Tables.Add(dtResultsFinal);
            _DAO.BulkInsert(ds, _DAO.GetClientReportingConnection(), timerjobguid);
            _DAO.Dispose();
            return true;
        }

        private int GetLevel(string error)
        {
            if (error.ToLower().Contains("failed"))
            {
                return 2;
            }
            return 0;
        }

        public DataTable InitializeResultsDT(string sListNames, bool refreshAll)
        {
            DataRow dr;
            var ListResults = new DataTable();
            List<string> arrayListNames = null;
            ListResults.Columns.Add("ListName");
            ListResults.Columns.Add("ResultText");
            char[] splitter = ",".ToCharArray();


            //Check list of lists
            if (sListNames != string.Empty)
            {
                if (sListNames.Contains(",")) //Has multiple lists
                {
                    arrayListNames = new List<string>(sListNames.Split(splitter));
                }
                else //Single list
                {
                    arrayListNames = new List<string> {sListNames};
                }
            }

            if (refreshAll)
            {
                if (!arrayListNames.Contains("Work Hours"))
                {
                    arrayListNames.Add("Work Hours");
                }

                if (!arrayListNames.Contains("Resources"))
                {
                    arrayListNames.Add("Resources");
                }
            }

            foreach (string list in arrayListNames)
            {
                dr = ListResults.NewRow();
                dr["ListName"] = list;
                ListResults.Rows.Add(dr);
            }

            return ListResults;
        }

        private void PopulateDefaultColumns()
        {
            _arrayListdefaultColumns = new ArrayList();
            if (!_arrayListdefaultColumns.Contains("siteid"))
                _arrayListdefaultColumns.Add("siteid");
            if (!_arrayListdefaultColumns.Contains("webid"))
                _arrayListdefaultColumns.Add("webid");
            if (!_arrayListdefaultColumns.Contains("listid"))
                _arrayListdefaultColumns.Add("listid");
            if (!_arrayListdefaultColumns.Contains("itemid"))
                _arrayListdefaultColumns.Add("itemid");
            if (!_arrayListdefaultColumns.Contains("weburl"))
                _arrayListdefaultColumns.Add("weburl");
        }
    }
}