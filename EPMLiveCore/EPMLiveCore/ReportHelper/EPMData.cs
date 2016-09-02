using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public class EPMData : IDisposable
    {
        private readonly Guid _siteID;
        private readonly Guid _webAppId;
        private Guid _webId;

        private string _DefaultLists;
        private string _command;
        private CommandType _commandType = CommandType.Text;
        private SqlConnection _conClientReporting;
        private SqlConnection _conEPMLive;
        private SqlConnection _conMaster;

        private string _databaseName;
        private string _databaseServer;

        private DataTable _dtStatusLog;
        private bool _epmLiveConOpen;
        private string _masterCs;
        private List<SqlParameter> _params = new List<SqlParameter>();
        private string _password;
        private string _remoteCs;
        private string _sTextFilePath;
        private string _siteName;
        private string _siteUrl;
        private string _sqlError;
        private bool _sqlErrorOccurred;
        private bool _useSAccount;
        private string _username;

        public EPMData(Guid siteID)
        {
            _siteID = siteID;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var spSite = new SPSite(siteID))
                {
                    OpenEPMLiveConnection = CoreFunctions.getConnectionString(spSite.WebApplication.Id);
                    using (SPWeb rootweb = spSite.OpenWeb())
                    {
                        _siteUrl = rootweb.ServerRelativeUrl;
                        _siteName = rootweb.Name;
                        _webId = rootweb.ID;
                    }
                }
            });


            //OpenEPMLiveConnection = ConfigurationManager.ConnectionStrings["epmlive"].ToString();
            if (_epmLiveConOpen)
            {
                PopulateInstanceFromData();
                PopulateConnectionStrings();
            }
        }

        public EPMData(bool tmp, Guid siteID, Guid webId)
        {
            _siteID = siteID;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var spSite = new SPSite(siteID))
                {
                    OpenEPMLiveConnection = CoreFunctions.getConnectionString(spSite.WebApplication.Id);
                    using (SPWeb rootweb = spSite.OpenWeb(webId))
                    {
                        _siteUrl = rootweb.ServerRelativeUrl;
                        _siteName = rootweb.Name;
                        _webId = rootweb.ID;
                    }
                }
            });


            //OpenEPMLiveConnection = ConfigurationManager.ConnectionStrings["epmlive"].ToString();
            if (_epmLiveConOpen)
            {
                PopulateInstanceFromData();
                PopulateConnectionStrings();
            }
        }

        public EPMData(Guid siteID, Guid webAppId)
        {
            _siteID = siteID;
            _webAppId = webAppId;
            using (var spSite = new SPSite(siteID))
            {
                OpenEPMLiveConnection = CoreFunctions.getConnectionString(webAppId);
                using (SPWeb rootweb = spSite.OpenWeb())
                {
                    {
                        _siteUrl = rootweb.ServerRelativeUrl;
                        _siteName = rootweb.Name;
                        _webId = rootweb.ID;
                    }
                }
            }

            //OpenEPMLiveConnection = ConfigurationManager.ConnectionStrings["epmlive"].ToString();
            if (_epmLiveConOpen)
            {
                PopulateInstanceFromData();
                PopulateConnectionStrings();
            }
        }


        public EPMData(Guid siteID, Guid webAppId, bool deleteDb)
        {
            _siteID = siteID;
            _webAppId = webAppId;
            OpenEPMLiveConnection = CoreFunctions.getConnectionString(webAppId);
            if (_epmLiveConOpen)
            {
                PopulateInstanceFromData();
                PopulateConnectionStrings();
            }
        }

        public EPMData(Guid siteID, string sDbName, string sServerName, bool useSAccount, string username,
            string password)
        {
            _siteID = siteID;
            _databaseName = sDbName;
            _databaseServer = sServerName;
            _useSAccount = useSAccount;
            _username = username;
            _password = password;

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var spSite = new SPSite(siteID))
                {
                    OpenEPMLiveConnection = CoreFunctions.getConnectionString(spSite.WebApplication.Id);
                    _webId = spSite.OpenWeb().ID;
                }
            });


            if (_epmLiveConOpen)
            {
                PopulateConnectionStrings();
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public bool UseSqlAccount
        {
            get
            {
                return _useSAccount;
            }
            set
            {
                _useSAccount = value;
            }
        }

        public Guid SiteId
        {
            get
            {
                return _siteID;
            }
        }

        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }

        public bool EPMLiveConOpen
        {
            get
            {
                return _epmLiveConOpen;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return _commandType;
            }
            set
            {
                _commandType = value;
            }
        }

        public List<SqlParameter> Params
        {
            get
            {
                return _params;
            }
            set
            {
                _params = value;
            }
        }

        public string SqlError
        {
            get
            {
                return _sqlError;
            }
        }

        public bool SqlErrorOccurred
        {
            get
            {
                return _sqlErrorOccurred;
            }
        }

        public string SiteName
        {
            get
            {
                return _siteName;
            }
        }

        public string SiteUrl
        {
            get
            {
                return _siteUrl;
            }
        }

        /// <summary>
        /// </summary>
        public SqlConnection GetEPMLiveConnection
        {
            get
            {
                if (_conEPMLive.State == ConnectionState.Open)
                    return _conEPMLive;
                try
                {
                    _conEPMLive.Open();
                    _epmLiveConOpen = true;
                }
                catch (Exception ex)
                {
                    _epmLiveConOpen = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - GetEPMLiveConnection"))
                            EventLog.CreateEventSource("EPMLive Reporting - GetEPMLiveConnection", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting GetEPMLiveConnection");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(
                            "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                            ex.Message + ex.StackTrace, EventLogEntryType.Error, 2040);
                    });
                }
                return _conEPMLive;
            }
        }

        /// <summary>
        /// </summary>
        public SqlConnection GetClientReportingConnection
        {
            get
            {
                if (_conClientReporting != null && _conClientReporting.State == ConnectionState.Open)
                    return _conClientReporting;
                try
                {
                    OpenClientReportingConnection = _remoteCs;
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - GetClientReportingConnection"))
                            EventLog.CreateEventSource("EPMLive Reporting - GetClientReportingConnection", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting GetClientReportingConnection");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(
                            "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                            ex.Message + ex.StackTrace, EventLogEntryType.Error, 2040);
                    });
                }
                return _conClientReporting;
            }
        }

        /// <summary>
        /// </summary>
        public SqlConnection GetMasterDbConnection
        {
            get
            {
                if (_conMaster != null && _conMaster.State == ConnectionState.Open)
                    return _conMaster;
                try
                {
                    OpenMasterDbConnection = _masterCs;
                }
                catch (Exception ex)
                {
                    _sqlError = ex.Message;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - GetMasterDbConnection"))
                            EventLog.CreateEventSource("EPMLive Reporting - GetMasterDbConnection", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting GetMasterDbConnection");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(
                            "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                            ex.Message + ex.StackTrace, EventLogEntryType.Error, 2020);
                    });
                }
                return _conMaster;
            }
        }

        /// <summary>
        /// </summary>
        public string OpenEPMLiveConnection
        {
            set
            {
                _conEPMLive = new SqlConnection(value);
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (_conEPMLive.State == ConnectionState.Closed)
                        {
                            _conEPMLive.Open();
                            _epmLiveConOpen = true;
                        }
                    });
                }
                catch (Exception ex)
                {
                    _epmLiveConOpen = false;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - OpenEPMLiveConnection"))
                            EventLog.CreateEventSource("EPMLive Reporting - OpenEPMLiveConnection", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting OpenEPMLiveConnection");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(
                            "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                            ex.Message + ex.StackTrace, EventLogEntryType.Error, 2010);
                    });
                }
            }
        }

        /// <summary>
        /// </summary>
        public string OpenClientReportingConnection
        {
            set
            {
                _conClientReporting = new SqlConnection(value);
                try
                {
                    if (_databaseName != null && _databaseName != string.Empty)
                    {
                        if (!_useSAccount)
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate
                            {
                                if (_conClientReporting.State == ConnectionState.Closed)
                                {
                                    _conClientReporting.Open();
                                }
                            });
                        }
                        else
                        {
                            if (_conClientReporting.State == ConnectionState.Closed)
                            {
                                _conClientReporting.Open();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_databaseName != null && _databaseName != string.Empty)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            if (!EventLog.SourceExists("EPMLive Reporting - OpenClientReportingConnection"))
                                EventLog.CreateEventSource("EPMLive Reporting - OpenClientReportingConnection",
                                    "EPM Live");

                            var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting OpenClientReportingConnection");
                            myLog.MaximumKilobytes = 32768;
                            myLog.WriteEntry(
                                "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                                ex.Message + ex.StackTrace, EventLogEntryType.Error, 2010);
                        });
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public string OpenMasterDbConnection
        {
            set
            {
                _conMaster = new SqlConnection(value);
                try
                {
                    if (!_useSAccount)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate
                        {
                            if (_conMaster.State == ConnectionState.Closed)
                            {
                                _conMaster.Open();
                            }
                        });
                    }
                    else
                    {
                        if (_conMaster.State == ConnectionState.Closed)
                        {
                            _conMaster.Open();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _sqlError = ex.Message;
                    if (_masterCs != null && _masterCs != string.Empty)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            if (!EventLog.SourceExists("EPMLive Reporting - OpenMasterDbConnection"))
                                EventLog.CreateEventSource("EPMLive Reporting - OpenMasterDbConnection", "EPM Live");

                            var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting OpenMasterDbConnection");
                            myLog.MaximumKilobytes = 32768;
                            myLog.WriteEntry(
                                "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " +
                                ex.Message + ex.StackTrace, EventLogEntryType.Error, 2030);
                        });
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public string remoteCs
        {
            get
            {
                return _remoteCs;
            }
        }

        /// <summary>
        /// </summary>
        public string masterCs
        {
            get
            {
                return _masterCs;
            }
        }

        /// <summary>
        /// </summary>
        public string remoteDbName
        {
            get
            {
                return _databaseName;
            }
        }

        /// <summary>
        /// </summary>
        public string remoteServerName
        {
            get
            {
                return _databaseServer;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conEPMLive != null)
                {
                    if (_conEPMLive.State == ConnectionState.Open)
                    {
                        _conEPMLive.Close();
                    }
                }
            });
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conClientReporting != null)
                {
                    if (_conClientReporting.State == ConnectionState.Open)
                    {
                        _conClientReporting.Close();
                    }
                }
            });
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conMaster != null)
                {
                    if (_conMaster.State == ConnectionState.Open)
                    {
                        _conMaster.Close();
                    }
                }
            });
        }

        #endregion

        public string DefaultLists(SPWeb rootWeb)
        {
            return GetDefaultLists(rootWeb);
        }

        public string DefaultLists()
        {
            return _DefaultLists;
        }

        public void CreateTextFile(string sPath)
        {
            try
            {
                StreamWriter SW;
                SW = File.CreateText(sPath);
                _sTextFilePath = sPath;
                SW.Close();
            }
            catch (Exception ex) { }
        }

        public void WriteToFile(string sText)
        {
            try
            {
                if (_sTextFilePath != null || _sTextFilePath != string.Empty)
                {
                    TextWriter tw = new StreamWriter(_sTextFilePath);

                    // write a line of text to the file
                    tw.WriteLine(sText);

                    // close the stream
                    tw.Close();
                }
            }
            catch (Exception ex) { }
        }

        public bool DeleteWork(Guid listid, int itemid)
        {
            //List specific
            if (itemid != -1)
            {
                Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId AND itemid=@itemId";
                AddParam("@siteId", _siteID);
                AddParam("@listId", listid);
                AddParam("@itemId", itemid);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            else if (listid != Guid.Empty)
            {
                Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId";
                AddParam("@siteId", _siteID);
                AddParam("@listId", listid);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            else
            {
                //Delete ALL work for ALL lists
                Command = "DELETE RPTWork WHERE siteId=@siteID";
                AddParam("@siteID", _siteID);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            return true;
        }

        //public bool DeleteWorkWithExceptions(Guid listid, int itemid, List<Guid> exceptionListIds)
        //{
        //    //List specific
        //    if (itemid != -1)
        //    {
        //        Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId AND itemid=@itemId";
        //        AddParam("@siteId", _siteID);
        //        AddParam("@listId", listid);
        //        AddParam("@itemId", itemid);
        //        ExecuteNonQuery(GetClientReportingConnection);
        //    }
        //    else if (listid != Guid.Empty)
        //    {
        //        Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId";
        //        AddParam("@siteId", _siteID);
        //        AddParam("@listId", listid);
        //        ExecuteNonQuery(GetClientReportingConnection);
        //    }
        //    else if (exceptionListIds.Count > 0)
        //    {
        //        //Delete ALL work except for exception lists
        //        Command = "DELETE RPTWork WHERE siteId=@siteId";
        //        AddParam("@siteId", _siteID);
        //        int index = 0;
        //        foreach (Guid id in exceptionListIds)
        //        {
        //            AddParam("@listid" + index.ToString(), id);
        //            Command += (" AND listid <> @listid" + index.ToString());
        //            index++;
        //        }

        //        ExecuteNonQuery(GetClientReportingConnection);
        //    }
        //    else
        //    {
        //        //Delete ALL work for ALL lists
        //        Command = "DELETE RPTWork WHERE siteId=@siteID";
        //        AddParam("@siteID", _siteID);
        //        ExecuteNonQuery(GetClientReportingConnection);
        //    }
        //    return true;
        //}

        public bool MapLists(List<Guid> sListNames, Guid webId)
        {
            bool blnPassed = false;
            char[] splitter = ",".ToCharArray();
            //Array lists = sListNames.Split(splitter[0]);
            var fields = new ListItemCollection();
            var spSite = new SPSite(_siteID);
            SPList spList = null;
            bool isReportingV2Enabled = false;

            using (spSite)
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    try
                    {
                        isReportingV2Enabled = Convert.ToBoolean(CoreFunctions.getConfigSetting(spWeb.Site.OpenWeb(), "reportingV2"));
                    }
                    catch (Exception)
                    {
                        isReportingV2Enabled = false;
                    }

                    foreach (Guid listId in sListNames)
                    {
                        try
                        {
                            spList = null;
                            spList = spWeb.Lists[listId];
                        }
                        catch { }

                        if (spList != null && !ListMappedAlready(spList.ID))
                        {
                            fields = GetListFields(spList);
                            var oMapList = new ReportBiz(_siteID, spWeb.ID, isReportingV2Enabled);
                            oMapList.CreateListBiz(spList.ID, spWeb.ID, fields);
                        }
                    }
                }
            }

            try
            {
                //FOREIGN IMPLEMENTATION -- START
                var DAO = new EPMData(_siteID);
                var rb = new ReportBiz(_siteID);
                rb.UpdateForeignKeys(DAO);
                DAO.Dispose();
                // -- END
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                        EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                    myLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 1);
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 4001);
                });
                blnPassed = false;
            }

            return blnPassed;
        }

        public bool MapDefaultLists(string sListNames)
        {
            bool blnPassed = false;
            char[] splitter = ",".ToCharArray();
            Array lists = sListNames.Split(splitter[0]);
            var fields = new ListItemCollection();
            var spSite = new SPSite(_siteID);
            SPList spList = null;

            using (spSite)
            {
                using (SPWeb spWeb = spSite.OpenWeb())
                {
                    foreach (string list in lists)
                    {
                        try
                        {
                            spList = null;
                            spList = spWeb.Lists[list];
                        }
                        catch (Exception ex)
                        {
                            //Add Logging here...
                        }

                        if (spList != null && !ListMappedAlready(spList.Title, _siteID))
                        {
                            fields = GetListFields(spList);
                            var oMapList = new ReportBiz(_siteID);
                            oMapList.CreateListBiz(spList.ID, fields);
                        }
                    }
                }
            }


            try
            {
                //FOREIGN IMPLEMENTATION -- START
                var DAO = new EPMData(_siteID);
                var rb = new ReportBiz(_siteID);
                rb.UpdateForeignKeys(DAO);
                DAO.Dispose();
                // -- END
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - UpdateForeignKeys"))
                        EventLog.CreateEventSource("EPMLive Reporting - UpdateForeignKeys", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting - UpdateForeignKeys");
                    myLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 1);
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 4001);
                });
                blnPassed = false;
            }

            return blnPassed;
        }

        public void SetListIcon(Dictionary<String, String> listIconsToBeSet)
        {
            try
            {
                foreach (KeyValuePair<String, String> listIconDetails in listIconsToBeSet)
                {
                    _command = "INSERT INTO ReportListIDs VALUES(@Id,@ListIcon)";
                    AddParam("@Id", listIconDetails.Key.ToString());
                    AddParam("@ListIcon", listIconDetails.Value.ToString());
                    ExecuteNonQuery(GetClientReportingConnection);
                }
            }
            catch { }
        }

        private ListItemCollection GetListFields(SPList spList)
        {
            var fields = new ListItemCollection();
            ListItem listField;
            var ListDefaults = new ListBiz(spList.ID, _siteID);

            foreach (SPField field in spList.Fields)
            {
                try
                {
                    //Adding contenttype field specifically.
                    if (field.InternalName.ToLower() == "contenttype")
                    {
                        listField = new ListItem();
                        listField.Text = field.Title;
                        listField.Value = field.Id.ToString();
                        fields.Add(listField);
                        continue;
                    }

                    //Adding contenttype field specifically.
                    if (field.InternalName.ToLower() == "extid")
                    {
                        listField = new ListItem();
                        listField.Text = field.Title;
                        listField.Value = field.Id.ToString();
                        fields.Add(listField);
                        continue;
                    }

                    if (!field.Hidden
                        && field.Type != SPFieldType.Computed
                        )
                    {
                        listField = new ListItem();
                        listField.Text = field.Title;
                        listField.Value = field.Id.ToString();
                        fields.Add(listField);
                    }
                }
                catch (Exception ex) { }
            }

            return fields;
        }

        public bool DeleteExistingTSData()
        {
            //Get TIMESHEET safe table name -- START
            string name = string.Empty;
            if (GetTableCount() == 0)
            {
                name = "RPTTSData";
            }
            else
            {
                name = "RPTTSData" + GetTableCount();
            }
            // -- END


            //DELETE TIMESHEET DATA -- START
            string script =
                string.Format(
                    @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U')) DROP TABLE [{0}]",
                    name.Replace("'", "''")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //string script = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[@tableName]') AND type in (N'U')) DROP TABLE [@tableName]";
            //AddParam("@tableName", name);
            Command = script;
            // -- END

            return ExecuteNonQuery(_conClientReporting);
        }


        public bool RefreshDefaultLists(string sListNames)
        {
            try
            {
                using (var site = new SPSite(_siteID))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        Guid timerjobuid = Guid.NewGuid();
                        Command =
                            "INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, scheduletype, webguid, timerjobuid) VALUES (@siteguid, 5, 'Reporting Refresh All', 2, @webguid, @timerjobuid)";
                        AddParam("@siteguid", site.ID);
                        AddParam("@webguid", web.ID.ToString());
                        AddParam("@timerjobuid", timerjobuid);
                        ExecuteNonQuery(GetEPMLiveConnection);

                        if (timerjobuid != Guid.Empty)
                            CoreFunctions.enqueue(timerjobuid, 0, site);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogStatus(string.Empty, sListNames, "List data cleanup not completed due errors." + ex.Message,
                    ex.StackTrace, 2, 3, string.Empty);
                return false;
            }
        }

        private string GetDefaultLists(SPWeb rootWeb)
        {
            if (string.IsNullOrEmpty(_DefaultLists))
            {
                // ORIGINAL CODE
                //_DefaultLists = CoreFunctions.getConfigSetting(rootWeb, "EPMLiveFixLists").Replace("\r\n", ",");
                // get lists that have reporting events

                const string sAssembly =
                    "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
                const string sClass = "EPMLiveReportsAdmin.ListEvents";

                var dLists = new List<string>();
                foreach (SPList l in from SPList l in rootWeb.Lists
                                     let e = (from SPEventReceiverDefinition erd in l.EventReceivers
                                              where erd.Assembly == sAssembly && erd.Class == sClass
                                              select erd).ToList()
                                     where e.Count > 0
                                     where !dLists.Contains(l.Title)
                                     select l)
                {
                    dLists.Add(l.Title);
                }

                _DefaultLists = string.Join(",", dLists);
            }

            string resourceList =
                CoreFunctions.getConfigSetting(rootWeb, "EPMLiveResourcePool").Replace("\r\n", ",").ToString();
            if (resourceList != string.Empty)
            {
                _DefaultLists = _DefaultLists + "," + resourceList;
                //EPMLiveCore.CoreFunctions.getWebAppSetting[""]
                //EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "EPMLiveFixLists").Replace("\r\n",",")
            }

            //Adding User Information List && Team
            _DefaultLists = _DefaultLists + "," + "User Information List" + ","
                            + "Team" + ","
                            + "Holidays" + ","
                            + "Holiday Schedules" + ","
                            + "My Work" + ","
                            + "Work Hours" + ","
                            + "Time Off";


            return _DefaultLists;
        }

        public void AddParam(string name, object value)
        {
            _params.Add(new SqlParameter(name, value));
        }

        public static bool CheckConnection(string cs)
        {
            bool success = true;
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    var staticCn = new SqlConnection(cs);
                    try
                    {
                        staticCn.Open();
                    }
                    catch (SqlException ex)
                    {
                        Trace.Write(ex.Message);
                        success = false;
                    }
                    finally
                    {
                        staticCn.Close();
                    }
                });
            return success;
        }

        public object ExecuteScalar(SqlConnection con)
        {
            try
            {
                object value;
                using (
                    var command = new SqlCommand { CommandType = _commandType, CommandText = _command, Connection = con })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(_params.ToArray());
                    value = command.ExecuteScalar();
                }
                return value;
            }
            catch (SqlException ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - ExecuteScalar"))
                        EventLog.CreateEventSource("EPMLive Reporting - ExecuteScalar", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting ExecuteScalar");
                    myLog.MaximumKilobytes = 32768;
                    string cmdDetails = "Command: " + _command;
                    string cmdParams = " Params: ";

                    foreach (SqlParameter param in _params)
                    {
                        if (param.Value != DBNull.Value)
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value:" + param.Value.ToString() +
                                        "],";
                        }
                        else
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value: Null],";
                        }
                    }

                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        cmdDetails + cmdParams, EventLogEntryType.Error, 2050);
                });
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                _command = null;
                _params.Clear();
                _commandType = CommandType.Text;
            }
        }

        public bool ExecuteNonQuery(SqlConnection con)
        {
            try
            {
                using (
                    var command = new SqlCommand
                    {
                        CommandType = _commandType,
                        CommandText = (_command),
                        Connection = con
                    })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(_params.ToArray());
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - ExecuteNonQuery"))
                        EventLog.CreateEventSource("EPMLive Reporting - ExecuteNonQuery", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting ExecuteNonQuery");
                    string cmdDetails = "Command: " + _command;
                    string cmdParams = " Params: ";

                    foreach (SqlParameter param in _params)
                    {
                        if (param.Value != DBNull.Value)
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value:" + param.Value.ToString() +
                                        "],";
                        }
                        else
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value: Null],";
                        }
                    }

                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        cmdDetails + cmdParams, EventLogEntryType.Error, 2050);
                });
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                _command = null;
                _params.Clear();
                _commandType = CommandType.Text;
            }
            return true;
        }

        public bool ExecuteNonQuery(SqlCommand command, SqlParameterCollection paramCollection, SqlConnection con)
        {
            string sql = command.CommandText;
            var sqlCommand = new SqlCommand(command.CommandText);
            bool isDocumenttypeProcessing = false;
            try
            {

                //EPML-4329 : Added check for document type and if title is null then title will be same as file name.
                try
                {
                    if (Convert.ToString(command.Parameters["@ContentType"].Value).ToLower().Equals("document"))
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(command.Parameters["@Title"].Value)))
                            command.Parameters["@Title"].Value = command.Parameters["@FileLeafRef"].Value;
                        isDocumenttypeProcessing = true;
                    }
                }
                catch { }

                if (command.Parameters.Count > 2000 || isDocumenttypeProcessing)
                {
                    var parameters = new List<SqlParameter>();
                    foreach (object parameter in command.Parameters)
                    {
                        parameters.Add((SqlParameter)parameter);
                    }

                    foreach (SqlParameter sqlParameter in parameters)
                    {
                        if (sql.Contains(sqlParameter.ParameterName))
                        {
                            sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                        }
                    }

                    sqlCommand.CommandTimeout = 3600; // 1hour
                    sqlCommand.Connection = con;
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Connection = con;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //Add Error Handling HERE
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - ExecuteNonQuery"))
                        EventLog.CreateEventSource("EPMLive Reporting - ExecuteNonQuery", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting ExecuteNonQuery");
                    myLog.MaximumKilobytes = 32768;
                    string cmdDetails = "Command: " + sql;
                    string cmdParams = " Params: ";

                    foreach (SqlParameter param in paramCollection)
                    {
                        if (param.Value != DBNull.Value)
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value:" + param.Value.ToString() +
                                        "],";
                        }
                        else
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value: Null],";
                        }
                    }

                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        cmdDetails + cmdParams, EventLogEntryType.Error, 2050);
                });
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                command.Dispose();
                sqlCommand.Dispose();
            }

            return true;
        }

        public DataRow GetRow(SqlConnection con)
        {
            DataTable table = GetTable(con);
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }

        public DataTable GetTable(SqlConnection con)
        {
            return GetTable(con, false);
        }

        public DataTable GetTable(SqlConnection con, bool getFullSchema)
        {
            try
            {
                SqlDataAdapter da;
                using (
                    var command = new SqlCommand { CommandType = _commandType, CommandText = _command, Connection = con })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(_params.ToArray());
                    da = new SqlDataAdapter(command);
                }
                var dt = new DataTable();
                if (getFullSchema)
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.Fill(dt);
                da.Dispose();
                return dt;
            }
            catch (SqlException ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - GetTable"))
                        EventLog.CreateEventSource("EPMLive Reporting - GetTable", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting GetTable");
                    myLog.MaximumKilobytes = 32768;

                    string cmdDetails = "Command: " + _command;
                    string cmdParams = " Params: ";
                    foreach (SqlParameter param in _params)
                    {
                        if (param.Value != DBNull.Value)
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value:" + param.Value.ToString() +
                                        "],";
                        }
                        else
                        {
                            cmdParams = cmdParams + "[Name:" + param.ParameterName + " Value: Null],";
                        }
                    }

                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        cmdDetails + cmdParams, EventLogEntryType.Error, 2050);
                });

                _sqlErrorOccurred = true;
                _sqlError = ex.Message;


                return null;
            }
            finally
            {
                _command = null;
                _params.Clear();
                _commandType = CommandType.Text;
            }
        }

        public DataRow GetSite()
        {
            //string sql = "'select * from @tableName where siteid = @SiteId'";
            //Command = "DECLARE @tableName sysname SET @tableName = '" + Resources.ReportingDatabaseTable + "' exec(" + sql + ")";
            //AddParam("@tableName", Resources.ReportingDatabaseTable);

            DataTable dt;
            Command = string.Format("select * from [{0}] where siteid = @SiteId",
                Resources.ReportingDatabaseTable.Replace("'", ""));
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            AddParam("@SiteId", _siteID);
            dt = GetTable(GetEPMLiveConnection);

            if (dt == null || dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        private void PopulateInstanceFromData()
        {
            DataRow siteDataRow = GetSite();
            if (siteDataRow == null)
                return;
            _databaseName = siteDataRow["DatabaseName"].ToString().Replace("'", "");
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            _databaseServer = siteDataRow["DatabaseServer"].ToString().Replace("'", "");
            // - CAT.NET false-positive: All single quotes are escaped/removed.

            if (siteDataRow["SAccount"] == DBNull.Value)
            {
                _useSAccount = false;
            }
            else
            {
                _useSAccount = (bool)siteDataRow["SAccount"];
            }

            if (_useSAccount)
            {
                _username = siteDataRow["Username"].ToString().Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                _password = siteDataRow["Password"].ToString().Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        private void PopulateConnectionStrings()
        {
            if (!_useSAccount)
            {
                _remoteCs =
                    string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", _databaseServer,
                        _databaseName).Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                _masterCs =
                    string.Format("Data Source={0};Initial Catalog=master;Integrated Security=SSPI", _databaseServer)
                        .Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
            else
            {
                _remoteCs =
                    string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", _databaseServer,
                        _databaseName, _username, Decrypt(_password)).Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                _masterCs =
                    string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", _databaseServer,
                        "master", _username, Decrypt(_password)).Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        public DataRow SAccountInfo()
        {
            //Command = "SELECT * RPTDatabases WHERE WebApplicationId = @webAppId";
            //AddParam("@webAppId",_webAppId);

            Command = "SELECT * FROM RPTDatabases WHERE SiteId = @siteId";
            AddParam("@siteId", _siteID);

            DataTable dt = GetTable(GetEPMLiveConnection);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public static DataRow SAccountInfo(Guid siteId, Guid webAppId)
        {
            try
            {
                var cmd = new SqlCommand();
                var con = new SqlConnection(CoreFunctions.getConnectionString(webAppId));
                con.Open();
                //cmd.CommandText = "SELECT * FROM RPTDatabases WHERE WebApplicationId = @webAppId";
                //cmd.Parameters.AddWithValue("@webAppId", webAppId);

                cmd.CommandText = "SELECT * FROM RPTDatabases WHERE SiteId = @siteId";
                cmd.Parameters.AddWithValue("@siteId", siteId);

                cmd.Connection = con;
                DataTable dt = GetTable(cmd);
                con.Close();

                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DataTable GetTable(SqlCommand cmd)
        {
            SqlDataAdapter da;
            var dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                da.Dispose();
            }
            catch (Exception ex) { }
            finally { }

            return dt;
        }

        /// <summary>
        ///     Returns the value of an calculated field as an object type. Return type can be NULL.
        /// </summary>
        /// <param name="li">
        ///     The corresponding list item for the list field/column.
        /// </param>
        /// <param name="field">
        ///     The calculated field whose value you want.
        /// </param>
        /// <returns>
        ///     An object type.
        /// </returns>
        public object GetCalculatedFieldValue(SPListItem li, SPFieldCalculated field)
        {
            object oValue = DBNull.Value;
            string sResultType = field.GetProperty("ResultType").ToLower();

            //for testing purposes...start
            //string sfieldValue = field.GetFieldValueAsText(li[field.InternalName]);
            //..end


            //REFACTOR -- Start
            //string sfieldValue = li[field.InternalName].ToString();

            //if (sfieldValue != "")
            //{
            //    sfieldValue = sfieldValue.Replace(";#", "\n").Split('\n')[1];
            //}

            //return sfieldValue;
            //END

            System.Globalization.NumberFormatInfo nInfo = System.Globalization.CultureInfo.GetCultureInfo(field.CurrencyLocaleId).NumberFormat;
            switch (sResultType)
            {
                case "currency":
                    if (
                        field.GetFieldValueAsText(li[field.InternalName])
                            .Replace(nInfo.CurrencySymbol, "")
                            .Replace("#VALUE!", "")
                            .Replace("<(", "")
                            .Replace(")>", "")
                            .Replace("%", "")
                            .Replace("(", "-")
                            .Replace(")", "") != string.Empty)
                    {
                        oValue =
                            float.Parse(
                                field.GetFieldValueAsText(li[field.InternalName])
                                    .Replace(nInfo.CurrencySymbol, "")
                                    .Replace("#VALUE!", "")
                                    .Replace("<(", "")
                                    .Replace(")>", "")
                                    .Replace("%", "")
                                    .Replace("(", "-")
                                    .Replace(")", ""));
                    }
                    else
                    {
                        oValue = DBNull.Value;
                    }
                    break;

                case "number":
                    if (
                        field.GetFieldValueAsText(li[field.InternalName])
                            .Replace("$", "")
                            .Replace("#VALUE!", "")
                            .Replace("<(", "")
                            .Replace(")>", "")
                            .Replace("%", "")
                            .Replace("(", "-")
                            .Replace(")", "") != string.Empty)
                    {
                        oValue =
                            float.Parse(
                                field.GetFieldValueAsText(li[field.InternalName])
                                    .Replace("$", "")
                                    .Replace("#VALUE!", "")
                                    .Replace("<(", "")
                                    .Replace(")>", "")
                                    .Replace("%", "")
                                    .Replace("(", "-")
                                    .Replace(")", ""));
                    }
                    else
                    {
                        oValue = DBNull.Value;
                    }
                    break;

                case "datetime":
                    try
                    {
                        oValue = DateTime.Parse(field.GetFieldValueAsText(li[field.InternalName]));
                    }
                    catch (Exception ex)
                    {
                        oValue = DBNull.Value;
                    }
                    break;

                case "boolean":
                    try
                    {
                        oValue = bool.Parse(field.GetFieldValueAsText(li[field.InternalName]));
                    }
                    catch (Exception ex)
                    {
                        oValue = DBNull.Value;
                    }
                    break;

                default:

                    //Used for debugging purposes only.
                    if (li[field.InternalName] != null)
                    {
                        string sValue = li[field.InternalName].ToString();
                    }
                    //end

                    if (li[field.InternalName].ToString().Contains("#"))
                    {
                        oValue =
                            li[field.InternalName].ToString()
                                .Substring(li[field.InternalName].ToString().IndexOf("#"))
                                .Replace("#", "");
                    }
                    else
                    {
                        oValue = field.GetFieldValueAsText(li[field.InternalName]);
                    }
                    break;
            }
            return oValue;
        }

        public void GetSnapshotQueueStatus(out int status, out string listguid, out int pctComplete, out bool queued)
        {
            DataTable dt;
            Command = " SELECT * FROM vwQueueTimerLog WHERE siteguid=@siteId and jobtype=7 and (NOT(status=2))";
            AddParam("@siteId", _siteID);

            dt = GetTable(GetEPMLiveConnection);

            if (dt != null && dt.Rows.Count > 0)
            {
                status = (int)dt.Rows[0]["status"];
                listguid = dt.Rows[0]["listguid"].ToString();
                try
                {
                    pctComplete = (int)dt.Rows[0]["percentComplete"];
                }
                catch (Exception ex)
                {
                    pctComplete = 0;
                }
                queued = true;
            }
            else
            {
                status = 0;
                listguid = string.Empty;
                pctComplete = 0;
                queued = false;
            }
        }

        public void GetCleanupQueueStatus(out int status, out string listguid, out int pctComplete, out bool queued)
        {
            DataTable dt;
            //Command = "SELECT dbo.QUEUE.status, dbo.QUEUE.percentComplete, dbo.TIMERJOBS.listguid, dbo.TIMERJOBS.jobtype, dbo.TIMERJOBS.lastqueuecheck FROM dbo.QUEUE RIGHT OUTER JOIN dbo.TIMERJOBS ON dbo.QUEUE.timerjobuid = dbo.TIMERJOBS.timerjobuid WHERE (dbo.TIMERJOBS.jobtype = 5) AND (dbo.TIMERJOBS.lastqueuecheck IS NULL) AND dbo.TIMERJOBS.siteguid =@siteId";
            Command = " SELECT * FROM vwQueueTimerLog WHERE siteguid=@siteId and jobtype=6 and (NOT(status=2))";
            AddParam("@siteId", _siteID);

            dt = GetTable(GetEPMLiveConnection);

            if (dt != null && dt.Rows.Count > 0)
            {
                status = (int)dt.Rows[0]["status"];
                listguid = dt.Rows[0]["listguid"].ToString();
                try
                {
                    pctComplete = (int)dt.Rows[0]["percentComplete"];
                }
                catch (Exception ex)
                {
                    pctComplete = 0;
                }
                queued = true;
            }
            else
            {
                status = 0;
                listguid = string.Empty;
                pctComplete = 0;
                queued = false;
            }
        }

        public bool BulkInsert(DataSet dsLists, SqlConnection con, bool blnLogStatus)
        {
            var sbcOptions = new SqlBulkCopyOptions();
            bool blnSuccess = false;
            ;
            string sListName = string.Empty;
            SqlTransaction tx = null;

            try
            {
                foreach (DataTable dtList in dsLists.Tables)
                {
                    tx = con.BeginTransaction();
                    using (var sbc = new SqlBulkCopy(con, sbcOptions, tx))
                    {
                        try
                        {
                            //Clear list name
                            sListName = string.Empty;

                            //Init. list name
                            sListName = dtList.TableName.ToLower().Replace("lst", "");

                            //Datatable name MUST be the SAME as the sqltable name.
                            sbc.DestinationTableName = dtList.TableName;

                            //Recommended MAX batchsize is 500 to avoid timeout issues.
                            sbc.BatchSize = 500;

                            //Mapping columns
                            foreach (DataColumn column in dtList.Columns)
                            {
                                sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                            }

                            // Number of records after which client has to be notified about its status                
                            sbc.NotifyAfter = dtList.Rows.Count;

                            // Finally write to server                
                            sbc.WriteToServer(dtList);
                            sbc.Close();

                            tx.Commit();
                            tx.Dispose();
                        }
                        catch (Exception ex)
                        {
                            tx.Dispose();
                            //Log status
                            LogStatus(string.Empty, string.Empty, string.Format("Bulk Insert {0} Refresh not completed due errors. {1} ", dtList.TableName, ex.Message.Replace("'", "")),
                                ex.StackTrace.Replace("'", ""), 2, 3, string.Empty);
                            // - CAT.NET false-positive: All single quotes are escaped/removed.
                        }
                    }
                }
                blnSuccess = true;
            }
            catch (Exception ex)
            {
                //tx can be null on error
                try
                {
                    tx.Rollback();
                    tx.Dispose();
                }
                catch (Exception ex1) { }
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
            return blnSuccess;
        }

        public bool BulkInsert(DataSet dsLists, SqlConnection con, Guid timerjobguid)
        {
            var sbcOptions = new SqlBulkCopyOptions();
            bool blnSuccess = false;
            ;
            string sListName = string.Empty;

            SqlTransaction tx = null;

            try
            {
                foreach (DataTable dtList in dsLists.Tables)
                {
                    tx = con.BeginTransaction();
                    using (var sbc = new SqlBulkCopy(con, sbcOptions, tx))
                    {
                        try
                        {

                            //Datatable name MUST be the SAME as the sqltable name.
                            sbc.DestinationTableName = "[" + dtList.TableName + "]";

                            //Recommended MAX batchsize is 500 to avoid timeout issues.
                            sbc.BatchSize = 500;

                            //Mapping columns
                            foreach (DataColumn column in dtList.Columns)
                            {
                                sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                            }

                            // Number of records after which client has to be notified about its status                
                            sbc.NotifyAfter = dtList.Rows.Count;

                            // Finally write to server                
                            sbc.WriteToServer(dtList);
                            sbc.Close();

                            tx.Commit();
                            tx.Dispose();
                        }
                        catch (Exception ex)
                        {
                            tx.Dispose();
                            LogStatus(string.Empty, string.Empty, string.Format("Bulk Insert {0} Refresh not completed due errors. {1} ", dtList.TableName, ex.Message.Replace("'", "")),
                                ex.StackTrace.Replace("'", ""), 2, 3, timerjobguid.ToString());
                            // - CAT.NET false-positive: All single quotes are escaped/removed.
                        }
                    }
                }
                blnSuccess = true;
            }
            catch (Exception ex)
            {
                //tx can be null on error
                try
                {
                    tx.Rollback();
                    tx.Dispose();
                }
                catch (Exception ex1) { }
                LogStatus(string.Empty, string.Empty, string.Format("Bulk Insert Refresh not completed due errors. {0} ", ex.Message.Replace("'", "")),
                    ex.StackTrace.Replace("'", ""), 2, 3, timerjobguid.ToString());
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
            return blnSuccess;
        }

        public string GetAllListIDs()
        {
            string sListIDs = string.Empty;
            var lListIDs = new List<string>();

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var s = new SPSite(_siteID))
                {
                    using (SPWeb w = s.OpenWeb(_webId))
                    {
                        foreach (SPList l in w.Lists)
                        {
                            List<SPEventReceiverDefinition> evts = GetListEvents(l,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.ListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (evts.Count > 0 && !lListIDs.Contains(l.ID.ToString()))
                            {
                                lListIDs.Add(l.ID.ToString());
                                continue;
                            }

                            List<SPEventReceiverDefinition> mwEvts = GetListEvents(l,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.MyWorkListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (mwEvts.Count > 0 && !lListIDs.Contains(l.ID.ToString()))
                            {
                                lListIDs.Add(l.ID.ToString());
                            }
                        }

                        if (w != null)
                        {
                            w.Dispose();
                        }
                    }
                }
            });

            sListIDs = string.Join(", ", lListIDs.ToArray());

            return sListIDs;
        }

        public string GetListNames()
        {
            string sLists = string.Empty;
            var lLists = new List<string>();
            //Command = "SELECT ListName FROM RPTList WHERE SiteId ='" + _siteID + "'";
            //Command = "SELECT ListName FROM RPTList WHERE SiteId =@siteId";
            //AddParam("@siteId", _siteID);
            //DataTable dtLists = GetTable(GetClientReportingConnection);

            //if (dtLists != null && dtLists.Rows.Count > 0)
            //{
            //    foreach (DataRow list in dtLists.Rows)
            //    {
            //        sLists = sLists + list["ListName"].ToString() + ",";
            //    }
            //}

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var s = new SPSite(_siteID))
                {
                    foreach (SPWeb w in s.AllWebs)
                    {
                        foreach (SPList l in w.Lists)
                        {
                            List<SPEventReceiverDefinition> evts = GetListEvents(l,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.ListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (evts.Count > 0 && !lLists.Contains(l.Title))
                            {
                                lLists.Add(l.Title);
                                continue;
                            }

                            List<SPEventReceiverDefinition> mwEvts = GetListEvents(l,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.MyWorkListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (mwEvts.Count > 0 && !lLists.Contains(l.Title))
                            {
                                lLists.Add(l.Title);
                            }
                        }

                        if (w != null)
                        {
                            w.Dispose();
                        }
                    }
                }
            });

            sLists = string.Join(",", lLists.ToArray());

            return sLists;
        }

        private List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className,
            List<SPEventReceiverType> types)
        {
            var evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch { }

            return evts;
        }

        public bool LogStatus(string RPTListID, string sListName, string sShortMsg, string sLongMsg, int iLevel,
            int iType, string timerjobguid)
        {
            bool blnStatus = false;
            try
            {
                _command =
                    "INSERT INTO RPTLog VALUES(@RPTList,@ListName,@ShortMsg,@LongMsg,@Level,@Type,getdate(),@timerjobguid)";

                if (RPTListID != string.Empty)
                {
                    var lguid = new Guid(RPTListID);
                    AddParam("@RPTList", RPTListID);
                }
                else
                {
                    AddParam("@RPTList", DBNull.Value);
                }

                AddParam("@ListName", sListName);
                AddParam("@ShortMsg", sShortMsg);
                AddParam("@LongMsg", sLongMsg);
                AddParam("@Level", iLevel);
                AddParam("@Type", iType);

                if (timerjobguid != null && timerjobguid != string.Empty)
                {
                    var jobguid = new Guid(timerjobguid);
                    AddParam("@timerjobguid", jobguid);
                }
                else
                {
                    AddParam("@timerjobguid", DBNull.Value);
                }

                ExecuteNonQuery(GetClientReportingConnection);

                blnStatus = true;
            }
            catch (Exception ex)
            {
                AddParam("@RPTList", DBNull.Value);
                AddParam("@ListName", DBNull.Value);
                AddParam("@ShortMsg", ex.Message);
                AddParam("@LongMsg", ex.StackTrace);
                AddParam("@Level", 2);
                AddParam("@Type", 8);

                ExecuteNonQuery(GetClientReportingConnection);
            }
            return blnStatus;
        }

        public void InitializeStatusLog()
        {
            _dtStatusLog = new DataTable();
            _dtStatusLog.Columns.Add("RPTListID", Type.GetType("System.Guid"));
            _dtStatusLog.Columns.Add("ListName");
            _dtStatusLog.Columns.Add("ShortMessage");
            _dtStatusLog.Columns.Add("LongMessage");
            _dtStatusLog.Columns.Add("Level", Type.GetType("System.Int32"));
            _dtStatusLog.Columns.Add("Type", Type.GetType("System.Int32"));
            _dtStatusLog.Columns.Add("Timestamp", Type.GetType("System.DateTime"));
        }

        public void InitializeStatusLog(DataTable dtStatusLog)
        {
            _dtStatusLog = dtStatusLog;
        }

        public bool LogRefreshStatus(Guid RPTListID, string listName, Guid timerjobguid, string webName, string message,
            int level)
        {
            return LogStatus(RPTListID.ToString(), listName, message, string.Empty, level, 3, timerjobguid.ToString());
        }

        /// <summary>
        /// </summary>
        /// <param name="timerjobguid"></param>
        /// <returns></returns>
        public DataTable GetSnapshotResults(Guid timerjobguid)
        {
            //_command = "SELECT * FROM RPTLog WHERE timerjobguid='" + timerjobguid + "'"; - CAT.NET
            _command = "SELECT * FROM RPTLog WHERE timerjobguid=@uid";
            AddParam("@uid", timerjobguid);
            return GetTable(GetClientReportingConnection);
        }

        /// <summary>
        /// </summary>
        /// <param name="timerjobguid"></param>
        /// <param name="siteId"></param>
        /// <param name="sLists"></param>
        /// <returns></returns>
        public bool SnapshotLists(Guid timerjobguid, Guid siteId, string sListIDs)
        {
            bool status = true;
            try
            {
                if (sListIDs != string.Empty)
                {
                    Command = "spRPTLists";
                    CommandType = CommandType.StoredProcedure;
                    AddParam("@siteID", siteId);
                    AddParam("@ListIDs", sListIDs);
                    AddParam("@Enabled", true);
                    AddParam("@timerjobguid", timerjobguid);
                    ExecuteNonQuery(GetClientReportingConnection);

                    if (_sqlErrorOccurred)
                    {
                        LogStatus(string.Empty, string.Empty, "Snapshot Error", SqlError.Replace("'", ""), 2, 2,
                            timerjobguid.ToString().Replace("'", ""));
                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }
                }
            }
            catch (Exception ex)
            {
                LogStatus(string.Empty, string.Empty, "Snapshot Error",
                    "Error:" + ex.Message.Replace("'", "") + " -- " + ex.StackTrace.Replace("'", ""), 2, 2,
                    timerjobguid.ToString().Replace("'", ""));
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                status = false;
            }
            return status;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataTable GetStatusLog()
        {
            return _dtStatusLog;
        }

        //Module Added On: 3/20/2011
        public SqlConnection GetSpecificReportingDbConnection(Guid siteId)
        {
            try
            {
                DataTable dt;
                Command = "Select * FROM RPTDatabases Where siteId = @siteId";
                AddParam("@siteId", siteId);
                dt = GetTable(GetEPMLiveConnection);
                var useSA = (bool)dt.Rows[0]["SAccount"];
                string conStr = string.Empty;
                if (useSA)
                {
                    conStr = "Data Source=" + dt.Rows[0]["DatabaseServer"].ToString() + " ;Initial Catalog=" +
                             dt.Rows[0]["DatabaseName"].ToString() + ";User Id=" + dt.Rows[0]["UserName"].ToString() +
                             ";Password=" + Decrypt(dt.Rows[0]["Password"].ToString()) + ";";
                }
                else
                {
                    conStr = "Data Source=" + dt.Rows[0]["DatabaseServer"].ToString() + ";Initial Catalog=" +
                             dt.Rows[0]["DatabaseName"].ToString() + ";Integrated Security=SSPI;";
                }

                var con = new SqlConnection(conStr);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - GetClientReportingConnection(Guid siteId)"))
                        EventLog.CreateEventSource("EPMLive Reporting - GetClientReportingConnection(Guid siteId)",
                            "EPM Live");

                    var myLog = new EventLog("EPM Live", ".",
                        "EPMLive Reporting GetClientReportingConnection(Guid siteId)");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteID.ToString() + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 2040);
                });
            }
            return _conClientReporting;
        }

        /// <summary>
        /// </summary>
        /// <param name="sListNames"></param>
        /// <returns></returns>
        public bool DeleteAllItemsDB(string sListNames, bool refreshAll)
        {
            string sSQL = string.Empty;
            char[] splitter = ",".ToCharArray();
            string[] tableNames;
            string[] listNames;
            string[] listIds;

            try
            {
                if (sListNames.Contains(","))
                {
                    listNames = sListNames.Split(splitter[0]);
                }
                else
                {
                    listNames = new string[1];
                    listNames[0] = sListNames;
                }

                tableNames = new string[listNames.Length];
                int iListCounter = 0;
                while (iListCounter < listNames.Length)
                {
                    Guid lstId = GetListId(Convert.ToString(listNames[iListCounter]), _webId);//GetTableName(listNames[iListCounter]);
                    tableNames[iListCounter] = GetTableName(lstId);
                    iListCounter++;
                }

                foreach (string sTableName in tableNames)
                {
                    if (sTableName != null)
                    {
                        if (!refreshAll && sTableName == "LSTMyWork")
                        {
                            continue;
                        }

                        if (TableExists(sTableName, GetClientReportingConnection))
                        {
                            sSQL = sSQL + " DELETE [" + sTableName.Replace("'", "") + "] WHERE SiteId =@siteID";
                            // - CAT.NET false-positive: All single quotes are escaped/removed.
                        }
                    }
                }
                AddParam("@siteID", _siteID);
                Command = sSQL;
                if (!string.IsNullOrEmpty(Command))
                {
                    ExecuteNonQuery(GetClientReportingConnection);
                }

                //DELETE WORK -- START
                listIds = new string[listNames.Length];
                iListCounter = 0;
                while (iListCounter < listNames.Length)
                {
                    listIds[iListCounter] = GetListId(Convert.ToString(listNames[iListCounter]), _webId).ToString();
                    sSQL = sSQL + " DELETE FROM RPTWork WHERE SiteId=@siteId AND ListId='" +
                           listIds[iListCounter].Replace("'", "") + "'";
                    iListCounter++;
                }

                iListCounter = 0; //updated/added during CAT.NET fix iteration
                //foreach (string sTableName in tableNames)
                //{
                //    sSQL = sSQL + " DELETE FROM RPTWork WHERE SiteId=@siteId AND ListId='" +
                //           listIds[iListCounter].Replace("'", "") + "'";
                //    // - CAT.NET false-positive: All single quotes are escaped/removed.
                //}
                AddParam("@siteId", _siteID);
                Command = sSQL;
                return ExecuteNonQuery(GetClientReportingConnection);
                // -- END
            }
            catch (Exception ex)
            {
                LogStatus(string.Empty, sListNames,
                    "Batch delete not completed due errors." + ex.Message.Replace("'", ""),
                    ex.StackTrace.Replace("'", ""), 2, 3, string.Empty);
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="tableNameRoot"></param>
        /// <returns></returns>
        public DataTable GetTableNames(string tableNameRoot)
        {
            Command =
                string.Format(
                    "select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '{0}%' order by TABLE_NAME desc ",
                    tableNameRoot.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //Command = "select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '[@tableName]%' order by TABLE_NAME desc ";
            //AddParam("@tableName", tableNameRoot);
            return GetTable(GetClientReportingConnection);
        }

        public bool TableExists(string tableName, SqlConnection cn)
        {
            bool exists = false;
            try
            {
                var cmd =
                    new SqlCommand(
                        "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = '" +
                        tableName + "')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END", cn);
                exists = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
            catch { }

            return exists;
        }

        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetSafeTableName(string tableName)
        {
            DataTable dt = GetTableNames(tableName);
            if (dt.Rows.Count == 0)
            {
                return tableName;
            }
            else
            {
                //foreach (DataRow row in dt.Rows)
                //{
                //    var suffix = row["TABLE_NAME"].ToString().Replace(tableName, "");
                //    int index;
                //    var success = int.TryParse(suffix, out index);
                //    if (!success)
                //        continue;
                //    return tableName + ++index;
                //}
                //return tableName + "1";

                tableName = tableName + GetTableCount().ToString();
                return tableName;
            }

            //Previous Implementation...commmented out on 3.22.2010 xjh
            //foreach (DataRow row in dt.Rows)
            //{
            //    var suffix = row["TABLE_NAME"].ToString().Replace(tableName, "");
            //    int index;
            //    var success = int.TryParse(suffix, out index);
            //    if (!success)
            //        continue;
            //    return tableName + ++index;
            //}
            //return tableName + "1";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public int GetTableCount()
        {
            int iTableCount = 0;
            //Command = "SELECT TableCount FROM RPTSettings WHERE SiteID='" + _siteID.ToString() + "'"; - CAT.NET
            Command = "SELECT TableCount FROM RPTSettings WHERE SiteID=@siteId";
            AddParam("@siteId", _siteID);
            iTableCount = (int)ExecuteScalar(GetClientReportingConnection);
            return iTableCount;
        }

        //public string UpdateListNames(string sListNames)
        //{
        //    string sSQL = string.Empty;
        //    char[] splitter = ",".ToCharArray();
        //    string listNamesOUT = null;
        //    string[] listNamesIN = null;
        //    string sListName = string.Empty;
        //    Guid RPTListID = Guid.Empty;
        //    try
        //    {
        //        //ListNames IN -- START
        //        if (sListNames.Contains(","))
        //        {
        //            listNamesIN = sListNames.Split(splitter[0]);
        //        }
        //        else
        //        {
        //            listNamesIN = new string[1];
        //            listNamesIN[0] = sListNames;
        //        }
        //        // -- END
        //        //listNamesOUT = new string[listNamesIN.Length];
        //        int iListCounter = 0;
        //        using (SPSite site = new SPSite(_siteID))
        //        {
        //            using (SPWeb web = site.OpenWeb())
        //            {
        //                while (iListCounter < listNamesIN.Length)
        //                {
        //                    RPTListID = GetListId(listNamesIN[iListCounter]);
        //                    sListName = web.Lists[RPTListID].Title;
        //                    if (sListName.Trim().ToLower() != listNamesIN[iListCounter].Trim().ToLower())
        //                    {
        //                        if (UpdateListName(RPTListID, sListName))
        //                        {
        //                            listNamesOUT = listNamesOUT + "," + sListName;
        //                        }
        //                        else
        //                        {
        //                            LogStatus(string.Empty, sListNames, "Error updating listname. For list:" + listNamesIN[iListCounter].Replace("'", ""), _sqlError, 2, 3, string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
        //                        }
        //                    }
        //                    else
        //                    {
        //                        listNamesOUT = listNamesOUT + "," + listNamesIN[iListCounter];
        //                    }
        //                    iListCounter++;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogStatus(string.Empty, sListNames, "Error processing UpdateListNames() -- " + ex.Message.Replace("'", ""), ex.StackTrace.Replace("'", ""), 2, 3, string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
        //    }
        //    if (listNamesOUT.IndexOf(",") == 0)
        //    {
        //        listNamesOUT = listNamesOUT.Remove(0, 1);
        //    }
        //    return listNamesOUT;
        //}
        /// <summary>
        /// </summary>
        /// <param name="sListNames"></param>
        /// <returns></returns>
        /// <summary>
        /// </summary>
        /// <param name="RPTListID"></param>
        /// <param name="sListName"></param>
        /// <returns></returns>
        private bool UpdateListName(Guid RPTListID, string sListName)
        {
            Command = "UPDATE RPTList SET ListName = @listName WHERE RPTListID=@rptListID";
            AddParam("@listName", sListName);
            AddParam("@rptListID", RPTListID);
            return ExecuteNonQuery(GetClientReportingConnection);
        }

        /// <summary>
        /// </summary>
        /// <param name="sListName"></param>
        /// <returns></returns>
        public Guid GetListId(string sListName)
        {
            using (var site = new SPSite(_siteID))
            {
                using (SPWeb spWeb = site.OpenWeb())
                {
                    try
                    {
                        return spWeb.Lists[sListName].ID;
                    }
                    catch (Exception ex)
                    {
                        var listID = new Guid();
                        return listID;
                    }
                }
            }
        }

        public Guid GetListId(string sListName, Guid webId)
        {
            using (var site = new SPSite(_siteID))
            {
                using (SPWeb spWeb = site.OpenWeb(webId))
                {
                    try
                    {
                        return spWeb.Lists[sListName].ID;
                    }
                    catch (Exception ex)
                    {
                        var listID = new Guid();
                        return listID;
                    }
                }
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="listName"></param>
        /// <returns></returns>
        public string GetTableName(Guid listId)
        {
            try
            {
                object objTableName = null;
                Command = "SELECT TableName FROM " + Resources.ReportingListTable.Replace("'", "") +
                          " WHERE RPTListId=@RPTListId AND SiteId=@siteID";
                AddParam("@RPTListId", listId);
                AddParam("@siteID", _siteID);
                objTableName = ExecuteScalar(GetClientReportingConnection);
                return objTableName.ToString();
            }
            catch { }
            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="listName"></param>
        /// <returns></returns>
        public string GetTableName(string listName)
        {
            object objTableName = null;
            Command = "SELECT TableName FROM " + Resources.ReportingListTable.Replace("'", "") +
                      " WHERE ListName=@listName AND SiteId=@siteID";
            AddParam("@listName", listName);
            AddParam("@siteID", _siteID);
            objTableName = ExecuteScalar(GetClientReportingConnection);
            return objTableName.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string GetListName(string tableName)
        {
            object objTableName = null;
            Command = "SELECT ListName FROM " + Resources.ReportingListTable.Replace("'", "") + " WHERE TableName='" +
                      tableName.Replace("'", "") + "' AND SiteId=@siteID";
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            AddParam("@siteID", _siteID);
            objTableName = ExecuteScalar(GetClientReportingConnection);
            return objTableName.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="sMessage"></param>
        /// <returns></returns>
        public bool RefreshTimesheets(out string sMessage, Guid jobUid)
        {
            var oTimeSheet = new ReportBiz(_siteID);
            return oTimeSheet.RefreshTimesheet(out sMessage, jobUid);
        }

        /// <summary>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool SaveWork(SPListItem item)
        {
            bool blnWorkSaved = true;
            bool hasWork = false, hasAssignedTo = false, hasStartDate = false, hasDueDate = false;
            try
            {
                if (ItemHasValue(item, "Work"))
                {
                    hasWork = true;
                }

                if (ItemHasValue(item, "AssignedTo"))
                {
                    hasAssignedTo = true;
                }

                if (ItemHasValue(item, "StartDate"))
                {
                    hasStartDate = true;
                }

                if (ItemHasValue(item, "DueDate"))
                {
                    hasDueDate = true;
                }

                if (hasWork && hasAssignedTo && hasStartDate && hasDueDate)
                {
                    Guid listId = item.ParentList.ID;
                    string sWork = Convert.ToString(item["Work"]);
                    string sAssignedTo = ReportData.AddLookUpFieldValues(Convert.ToString(item["AssignedTo"]), "id");
                    object startDate = DateTime.Parse(Convert.ToString(item["StartDate"]));
                    object dueDate = DateTime.Parse(Convert.ToString(item["DueDate"]));
                    if (!ProcessAssignments(sWork, sAssignedTo, startDate, dueDate, listId, _siteID, item.ID,
                            item.ParentList.Title))
                    {
                        LogStatus(string.Empty, string.Empty, "SaveWork() failed.", SqlError.Replace("'", ""), 2, 3,
                            string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
                        blnWorkSaved = false;
                    }
                }
                // don't do anything if missing value
                // NOTE: Discussed with JB and we are assumeing values are missing because user intended to NOT submit work
            }
            catch (Exception ex)
            {
                LogStatus(string.Empty, string.Empty, "SaveWork() failed.", ex.Message.Replace("'", ""), 2, 3,
                    string.Empty); // - CAT.NET false-positive: All single quotes are escaped/removed.
                blnWorkSaved = false;
            }

            return blnWorkSaved;
        }

        /// <summary>
        /// </summary>
        /// <param name="sWork"></param>
        /// <param name="sAssignedTo"></param>
        /// <param name="StartDate"></param>
        /// <param name="DueDate"></param>
        /// <param name="ListID"></param>
        /// <param name="SiteID"></param>
        /// <param name="ItemID"></param>
        /// <param name="sListName"></param>
        /// <returns></returns>
        public bool ProcessAssignments(string sWork, string sAssignedTo, object StartDate, object DueDate, Guid ListID,
            Guid SiteID, int ItemID, string sListName)
        {
            bool blnProcess = true;
            object objResults = null;


            Command = "spRPTProcessAssignments";
            CommandType = CommandType.StoredProcedure;
            AddParam("@Work", sWork);
            AddParam("@AssignedTo", sAssignedTo);
            AddParam("@Start", StartDate);
            AddParam("@Finish", DueDate);
            AddParam("@ListID", ListID);
            AddParam("@SiteID", SiteID);
            AddParam("@ItemID", ItemID);

            //Need to implement further. Need to check result for status/errors
            objResults = ExecuteScalar(GetClientReportingConnection);
            return blnProcess;
        }

        private int GetDbVersion()
        {
            int version = 2005;
            string sql =
                "DECLARE @version int, @versionString nvarchar(100) SET @version = CONVERT(int,SUBSTRING(CONVERT(nvarchar(100),SERVERPROPERTY('productversion')),1,1))" +
                "SET @versionString = CONVERT(nvarchar(100),SERVERPROPERTY('productversion')) SELECT @version";
            try
            {
                Command = sql;
                version = (int)ExecuteScalar(GetClientReportingConnection);

                if (version == 1)
                    version = 2010;
                else
                    version = 2005;
            }
            catch (Exception ex) { }
            return version;
        }

        /// <summary>
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="webId"></param>
        /// <param name="serverName"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="un"></param>
        /// <param name="pw"></param>
        /// <param name="useSA"></param>
        /// <param name="dbExists"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool MapDataBase(Guid siteId, Guid webId, string serverName, string dataBaseName, string un, string pw,
            bool useSA, bool dbExists, out string status)
        {
            Guid webAppId = webId;
            Guid selectedSiteId = siteId;
            ReportBiz rb = null;
            Dictionary<string, string> databases;

            try
            {
                rb = new ReportBiz(siteId, webAppId);
                databases = rb.GetDatabaseMappings();
            }
            catch (Exception ex)
            {
                status = "Unable to establish connection. Check all configuration settings.";
                return false;
            }

            status = "Processed successfully.";
            if (databases.ContainsKey(siteId.ToString()))
            {
                string db;
                databases.TryGetValue(siteId.ToString(), out db);
                status = "This site is already mapped to a database. " + db;
                return false;
            }

            string dbServer;
            string dbName;
            dbServer = serverName;
            dbName = dataBaseName;
            if (dbServer.Trim().Length == 0 || dbName.Trim().Length == 0)
            {
                status = "Please enter a server and a name for the new database.";
                return false;
            }
            else
            {
                var reportData = new ReportData(
                    new Guid(siteId.ToString()),
                    dbName,
                    dbServer, useSA, un, Encrypt(pw));
                if (!reportData.CheckServerConnection())
                {
                    status = reportData.GetError();
                    if (status == "")
                    {
                        status = "Unable to open Master database.";
                    }
                    return false;
                }

                if (!dbExists)
                {
                    if (reportData.DatabaseExists())
                    {
                        status =
                            "The database already exists. If this is an existing valid EPM Reporting database, please check 'Existing' and select it from the list above.";
                        return false;
                    }
                    if (!reportData.CreateDatabase())
                    {
                        status = reportData.GetError();
                        if (status == "")
                        {
                            status = "Unable to create database.";
                        }
                        return false;
                    }
                    if (!reportData.InitializeDatabase())
                    {
                        status = reportData.GetError();
                        if (status == "")
                        {
                            status = "Error initializing database.";
                        }
                        return false;
                    }
                }


                if (dbExists)
                {
                    if (!reportData.DatabaseExists())
                    {
                        status = "Database " + dbName + " does not exist.";
                        return false;
                    }

                    if (!reportData.IsReportingDB())
                    {
                        status = string.Format("Invalid database.");
                        return false;
                    }
                }

                if (useSA && un != string.Empty && pw != string.Empty)
                {
                    reportData.UserName = un;
                    reportData.Password = Encrypt(pw);
                    reportData.UseSqlAccount = true;
                }
                else
                {
                    if (!useSA)
                    {
                        reportData.UseSqlAccount = false;
                    }
                    else
                    {
                        status = "Invalid username or password.";
                        return false;
                    }
                }

                if (reportData.InsertDbEntry())
                {
                    EPMData DAO;
                    if (useSA)
                    {
                        DAO = new EPMData(new Guid(siteId.ToString()), dbName, serverName, true, un, Encrypt(pw));
                    }
                    else
                    {
                        DAO = new EPMData(new Guid(siteId.ToString()));
                    }

                    string defaultLists = string.Empty;
                    using (var spSite = new SPSite(new Guid(siteId.ToString())))
                    {
                        defaultLists = DAO.DefaultLists(spSite.RootWeb);
                    }

                    //Grant user db access if needed.
                    DAO.GrantUserDbAccess();

                    //Add RPTSettings entry 
                    string sResult;
                    DAO.UpdateRPTSettings(string.Empty, 0, out sResult);

                    //Map default lists
                    DAO.MapDefaultLists(defaultLists);

                    //Refresh all lists data to sql table
                    DAO.RefreshDefaultLists(defaultLists);

                    DAO.Dispose();
                }
                reportData.Dispose();
            }
            return true;
        }

        private bool GrantUserDbAccess()
        {
            string un = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var site = new SPSite(_siteID))
                {
                    un = site.WebApplication.ApplicationPool.Username;
                }
            });

            string sql;
            int version = GetDbVersion();
            if (version == 2005)
            {
                sql =
                    "BEGIN BEGIN TRANSACTION BEGIN TRY IF NOT EXISTS (select * from sys.sysusers where name=@userName)";
                sql = sql + " exec sp_grantdbaccess @userName, @userName";
                sql = sql + " exec sp_addrolemember db_owner,@userName";
                sql = sql + " COMMIT TRANSACTION END TRY BEGIN CATCH BEGIN ROLLBACK TRANSACTION; END END CATCH END";

                //sql = string.Format("BEGIN BEGIN TRANSACTION BEGIN TRY IF NOT EXISTS (select * from sys.sysusers where name='{0}')", un);- CAT.NET
                //sql = sql + string.Format(" exec sp_grantdbaccess '{0}', '{0}'", un);
                //sql = sql + string.Format(" exec sp_addrolemember db_owner,'{0}'", un);
                //sql = sql + " COMMIT TRANSACTION END TRY BEGIN CATCH BEGIN ROLLBACK TRANSACTION; END END CATCH END";
            }
            else
            {
                sql = "IF NOT EXISTS (select * from sys.sysusers where name=@userName) " +
                      "BEGIN TRAN T1 BEGIN TRY exec('CREATE USER [@userName]') exec sp_addrolemember db_owner,@userName COMMIT TRAN T1 END TRY BEGIN CATCH ROLLBACK TRAN T1  PRINT ERROR_MESSAGE() END CATCH";

                //sql = string.Format("IF NOT EXISTS (select * from sys.sysusers where name='{0}') " +
                //      "BEGIN TRAN T1 BEGIN TRY exec('CREATE USER [{0}]') exec sp_addrolemember db_owner,'{0}' COMMIT TRAN T1 END TRY BEGIN CATCH ROLLBACK TRAN T1  PRINT ERROR_MESSAGE() END CATCH", un);- CAT.NET
            }

            Command = sql;
            AddParam("@userName", un);
            return ExecuteNonQuery(GetClientReportingConnection);
        }

        //private bool GrantUserDbAccess()
        //{
        //    string un = string.Empty;
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        SPSite site = new SPSite(_siteID);
        //        un = site.WebApplication.ApplicationPool.Username;
        //    });

        //    string sql = string.Format("BEGIN BEGIN TRANSACTION BEGIN TRY IF NOT EXISTS (select * from sys.sysusers where name='{0}')", un);
        //    sql = sql + string.Format(" exec sp_grantdbaccess '{0}', '{0}'",un);
        //    sql = sql + string.Format(" exec sp_addrolemember db_owner,'{0}'",un);
        //    sql = sql + " COMMIT TRANSACTION END TRY BEGIN CATCH BEGIN ROLLBACK TRANSACTION; END END CATCH END";

        //    Command = sql;
        //    return ExecuteNonQuery(GetClientReportingConnection);
        //}

        /// <summary>
        /// </summary>
        /// <param name="sListName"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public bool ListMappedAlready(Guid listId)
        {
            //Command = string.Format("SELECT COUNT(*) as ListCount FROM RPTList WHERE siteId='{0}' AND ListName='{1}'", _siteID, sListName); - CAT.NET
            Command = "SELECT COUNT(*) as ListCount FROM RPTList WHERE RPTListId=@RPTListId";
            AddParam("@RPTListId", listId);
            object oResult = ExecuteScalar(GetClientReportingConnection);

            if (oResult != null && (int)oResult != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sListName"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public bool ListMappedAlready(string sListName, Guid siteId)
        {
            //Command = string.Format("SELECT COUNT(*) as ListCount FROM RPTList WHERE siteId='{0}' AND ListName='{1}'", _siteID, sListName); - CAT.NET
            Command = "SELECT COUNT(*) as ListCount FROM RPTList WHERE siteId=@siteId AND ListName=@listName";
            AddParam("@siteId", _siteID);
            AddParam("@listName", sListName);
            object oResult = ExecuteScalar(GetClientReportingConnection);

            if (oResult != null && (int)oResult != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="nonWorkingDays"></param>
        /// <param name="workHrs"></param>
        /// <param name="sResult"></param>
        /// <returns></returns>
        public bool UpdateRPTSettings(string nonWorkingDays, int workHrs, out string sResult)
        {
            Command = "SELECT ISNULL(COUNT(*),0) as SiteCount FROM RPTSettings WHERE SiteID=@siteID";
            AddParam("@siteID", _siteID);
            string webName;
            string webUrl;

            object oResult = ExecuteScalar(GetClientReportingConnection);

            if ((int)oResult == 0)
            {
                Command = "INSERT INTO RPTSettings VALUES(@siteID,@nonWorkingDays,@workHrs,@SiteName,@SiteUrl)";
            }
            else
            {
                Command =
                    "UPDATE RPTSettings SET NonWorkingDays=@nonWorkingDays, WorkHours=@workHrs WHERE SiteID=@siteID";
            }

            using (var site = new SPSite(_siteID))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    webName = web.Title;
                    webUrl = web.ServerRelativeUrl;
                }
            }

            AddParam("@siteID", _siteID);
            AddParam("@nonWorkingDays", nonWorkingDays);
            AddParam("@workHrs", workHrs);
            AddParam("@SiteName", webName);
            AddParam("@SiteUrl", webUrl);

            if (SqlErrorOccurred)
            {
                sResult = _sqlError;
            }
            else
            {
                sResult = "success";
            }
            return ExecuteNonQuery(GetClientReportingConnection);
        }

        /// <summary>
        ///     Encrypts string value using the HASH MD5 cryptoservice provider.
        /// </summary>
        /// <param name="Plaintext"></param>
        /// <returns></returns>
        public static string Encrypt(string Plaintext)
        {
            var Buffer = new byte[0];
            string Key = "EPMLIVE";
            var DES = new TripleDESCryptoServiceProvider();
            var hashMD5 = new MD5CryptoServiceProvider();
            DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            Buffer = ASCIIEncoding.ASCII.GetBytes(Plaintext);

            string TripleDES = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            return TripleDES;
        }

        /// <summary>
        ///     Decrpyts string value using key.
        /// </summary>
        /// <param name="base64Text"></param>
        /// <returns></returns>
        public static string Decrypt(string base64Text)
        {
            try
            {
                var Buffer = new byte[0];
                string Key = "EPMLIVE";
                var DES = new TripleDESCryptoServiceProvider();
                var hashMD5 = new MD5CryptoServiceProvider();
                DES.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                DES.Mode = CipherMode.ECB;
                ICryptoTransform DESDecrypt = DES.CreateDecryptor();
                Buffer = Convert.FromBase64String(base64Text);

                string DecTripleDES =
                    ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return DecTripleDES;
            }
            catch (Exception ex)
            {
                return base64Text;
            }
        }

        #region HELPER METHODS

        private bool ItemHasValue(SPListItem item, string fldName)
        {
            string test = string.Empty;
            try
            {
                test = Convert.ToString(item[fldName]);
            }
            catch { }

            return !string.IsNullOrEmpty(test);
        }

        #endregion

        //Modules created by xjh -- end
    }
}