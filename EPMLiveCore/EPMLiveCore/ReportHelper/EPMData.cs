using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public class EPMData : IDisposable
    {
        private readonly Guid _webAppId;
        private Guid _webId;

        private const int RetentionDays = 1;
        private const int MaxKilobytes = 32768;

        private const int OpenEpmLiveConnectionEvent = 2010;
        private const int GetMasterDbConnectionEvent = 2020;
        private const int OpenMasterDbConnectionEvent = 2030;
        private const int GetEpmLiveConnectionEvent = 2040;
        private const int ExecuteScalarEvent = 2050;
        private const int UpdateForeignKeyEvent = 4001;

        private const string DotDelimiter = ".";
        private const string HashSign = "#";
        private const string Hyphen = "-";
        private const string Apostrophe = "'";
        private const string DoubleApostrophe = "''";
        private const string DollarSign = "$";
        private const string EpmLiveKey = "EPM Live";
        private const string EpmLiveReportingKey = "EPMLive Reporting";
        private const string ExecuteScalarKey = "ExecuteScalar";
        private const string ExecuteNonQueryKey = "ExecuteNonQuery";
        private const string GetTableKey = "GetTable";
        private const string GetClientReportingConnectionKey = "GetClientReportingConnection";
        private const string GetClientReportingConnectionSiteIdKey = "GetClientReportingConnection(Guid siteId)";
        private const string GetEpmLiveConnectionKey = "GetEPMLiveConnection";
        private const string GetMasterDbConnectionKey = "GetMasterDbConnection";
        private const string OpenEpmLiveConnectionKey = "OpenEPMLiveConnection";
        private const string OpenClientReportingConnectionKey = "OpenClientReportingConnection";
        private const string OpenMasterDbConnectionKey = "OpenMasterDbConnection";
        private const string UpdateForeignKeysKey = "UpdateForeignKeys";
        private const string FieldTypeCurrency = "currency";
        private const string FieldTypeNumber = "number";
        private const string FieldTypeDateTime = "datetime";
        private const string FieldTypeBool = "boolean";
        private string _DefaultLists;
        private SqlConnection _conClientReporting;
        private SqlConnection _conEPMLive;
        private SqlConnection _conMaster;

        private string _databaseName;
        private string _databaseServer;

        private DataTable _dtStatusLog;
        private bool _epmLiveConOpen;
        private string _masterCs;
        private string _remoteCs;
        private string _sTextFilePath;
        private string _siteName;
        private string _siteUrl;
        private string _sqlError;
        private bool _sqlErrorOccurred;

        public EPMData(Guid siteID)
        {
            SiteId = siteID;
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
            SiteId = siteID;
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
            SiteId = siteID;
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
            SiteId = siteID;
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
            SiteId = siteID;
            _databaseName = sDbName;
            _databaseServer = sServerName;
            UseSqlAccount = useSAccount;
            UserName = username;
            Password = password;

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

        public Guid SiteId { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSqlAccount { get; set; }
        public string Command { get; set; }
        public CommandType CommandType { get; set; } = CommandType.Text;
        public List<SqlParameter> Params { get; set; } = new List<SqlParameter>();
        public bool EPMLiveConOpen => _epmLiveConOpen;
        public string SqlError => _sqlError;
        public bool SqlErrorOccurred => _sqlErrorOccurred;
        public string SiteName => _siteName;
        public string SiteUrl => _siteUrl;
        public string remoteCs => _remoteCs;
        public string masterCs => _masterCs;
        public string remoteDbName => _databaseName;
        public string remoteServerName => _databaseServer;

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
                        var eventMessage = CreateEventMessage(ex);
                        LogWindowsEvents(EpmLiveKey, GetEpmLiveConnectionKey, eventMessage, false, GetEpmLiveConnectionEvent);
                    });
                }
                return _conEPMLive;
            }
        }

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
                        var eventMessage = CreateEventMessage(ex);
                        LogWindowsEvents(EpmLiveKey, GetClientReportingConnectionKey, eventMessage, false, GetEpmLiveConnectionEvent);
                    });
                }
                return _conClientReporting;
            }
        }

        private string CreateEventMessage(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            return $"Name: {_siteName} Url: {_siteUrl} ID: {SiteId} : {exception.Message}{exception.StackTrace}";
        }

        private string CreateEventMessageWithParams(Exception exception, string command, IEnumerable<SqlParameter> parameters)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var cmdDetails = $"Command: {command}";
            var cmdParams = " Params: ";

            foreach (var param in parameters)
            {
                cmdParams = param.Value != DBNull.Value 
                    ? $"{cmdParams}[Name:{param.ParameterName} Value:{param.Value}]," 
                    : $"{cmdParams}[Name:{param.ParameterName} Value: Null],";
            }

            return $"Name: {_siteName} Url: {_siteUrl}  ID: {SiteId} : {exception.Message}{cmdDetails}{cmdParams}";
        }

        private void LogWindowsEvents(string logName, string source, string eventMessage, bool modifyOverflowPolicy, int eventId)
        {
            var fullSource = $"{EpmLiveReportingKey} - {source}";

            if (!EventLog.SourceExists(fullSource))
            {
                EventLog.CreateEventSource(fullSource, logName);
            }

            using (var eventLog = new EventLog(logName))
            {
                eventLog.Source = $"{EpmLiveReportingKey} {source}";
                eventLog.MaximumKilobytes = MaxKilobytes;
                eventLog.MachineName = DotDelimiter;

                if (modifyOverflowPolicy)
                {
                    eventLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, RetentionDays);
                }

                eventLog.WriteEntry(eventMessage, EventLogEntryType.Error, eventId);
            }
        }

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
                        var eventMessage = CreateEventMessage(ex);
                        LogWindowsEvents(EpmLiveKey, GetMasterDbConnectionKey, eventMessage, false, GetMasterDbConnectionEvent);
                    });
                }
                return _conMaster;
            }
        }

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
                        var eventMessage = CreateEventMessage(ex);
                        LogWindowsEvents(EpmLiveKey, OpenEpmLiveConnectionKey, eventMessage, false, OpenEpmLiveConnectionEvent);
                    });
                }
            }
        }

        public string OpenClientReportingConnection
        {
            set
            {
                _conClientReporting = new SqlConnection(value);
                try
                {
                    if (_databaseName != null && _databaseName != string.Empty)
                    {
                        if (!UseSqlAccount)
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
                            var eventMessage = CreateEventMessage(ex);
                            LogWindowsEvents(EpmLiveKey, OpenClientReportingConnectionKey, eventMessage, false, OpenEpmLiveConnectionEvent);
                        });
                    }
                }
            }
        }

        public string OpenMasterDbConnection
        {
            set
            {
                _conMaster = new SqlConnection(value);
                try
                {
                    if (!UseSqlAccount)
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
                            var eventMessage = CreateEventMessage(ex);
                            LogWindowsEvents(EpmLiveKey, OpenMasterDbConnectionKey, eventMessage, false, OpenMasterDbConnectionEvent);
                        });
                    }
                }
            }
        }

        public void Dispose()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conEPMLive != null && _conEPMLive.State == ConnectionState.Open)
                {
                    _conEPMLive.Dispose();
                }
            });
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conClientReporting != null && _conClientReporting.State == ConnectionState.Open)
                {
                    _conClientReporting.Dispose();
                }
            });
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                if (_conMaster != null && _conMaster.State == ConnectionState.Open)
                {
                    _conMaster.Dispose();
                }
            });
        }

        public string DefaultLists(SPWeb rootWeb) => GetDefaultLists(rootWeb);

        public string DefaultLists() => _DefaultLists;

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
                WriteTextFile(_sTextFilePath, sText);
            }
            catch (Exception exception)
            {
                Trace.TraceError("Exception suppressed: {0}", exception);
            }
        }

        private void WriteTextFile(string path, string text)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(text);
            }
        }

        public bool DeleteWork(Guid listid, int itemid)
        {
            //List specific
            if (itemid != -1)
            {
                Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId AND itemid=@itemId";
                AddParam("@siteId", SiteId);
                AddParam("@listId", listid);
                AddParam("@itemId", itemid);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            else if (listid != Guid.Empty)
            {
                Command = "DELETE RPTWork WHERE siteId=@siteId AND listid=@listId";
                AddParam("@siteId", SiteId);
                AddParam("@listId", listid);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            else
            {
                //Delete ALL work for ALL lists
                Command = "DELETE RPTWork WHERE siteId=@siteID";
                AddParam("@siteID", SiteId);
                ExecuteNonQuery(GetClientReportingConnection);
            }
            return true;
        }

        public bool MapLists(ICollection<Guid> sListNames, Guid webId)
        {
            CheckArgumentForNull(sListNames, nameof(sListNames));

            bool blnPassed = false;
            var fields = new ListItemCollection();
            var spSite = new SPSite(SiteId);
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
                            spList = spWeb.Lists[listId];
                        }
                        catch { }

                        if (spList != null && !ListMappedAlready(spList.ID))
                        {
                            fields = GetListFields(spList);
                            var oMapList = new ReportBiz(SiteId, spWeb.ID, isReportingV2Enabled);
                            oMapList.CreateListBiz(spList.ID, spWeb.ID, fields);
                        }
                    }
                }
            }

            try
            {
                //FOREIGN IMPLEMENTATION -- START
                var DAO = new EPMData(SiteId);
                var rb = new ReportBiz(SiteId);
                rb.UpdateForeignKeys(DAO);
                DAO.Dispose();
                // -- END
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate ()
                {
                    var eventMessage = CreateEventMessage(ex);
                    LogWindowsEvents(EpmLiveKey, UpdateForeignKeysKey, eventMessage, true, UpdateForeignKeyEvent);
                });
                blnPassed = false;
            }

            return blnPassed;
        }

        public bool MapDefaultLists(string sListNames)
        {
            CheckArgumentForNull(sListNames, nameof(sListNames));

            bool blnPassed = false;
            char[] splitter = ",".ToCharArray();
            Array lists = sListNames.Split(splitter[0]);
            var fields = new ListItemCollection();
            var spSite = new SPSite(SiteId);
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

                        if (spList != null && !ListMappedAlready(spList.Title, SiteId))
                        {
                            fields = GetListFields(spList);
                            var oMapList = new ReportBiz(SiteId);
                            oMapList.CreateListBiz(spList.ID, fields);
                        }
                    }
                }
            }


            try
            {
                //FOREIGN IMPLEMENTATION -- START
                var DAO = new EPMData(SiteId);
                var rb = new ReportBiz(SiteId);
                rb.UpdateForeignKeys(DAO);
                DAO.Dispose();
                // -- END
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    var eventMessage = CreateEventMessage(ex);
                    LogWindowsEvents(EpmLiveKey, UpdateForeignKeysKey, eventMessage, true, UpdateForeignKeyEvent);
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
                    Command = "INSERT INTO ReportListIDs VALUES(@Id,@ListIcon)";
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

            foreach (SPField field in spList.Fields)
            {
                try
                {
                    if (field.InternalName.Equals("contenttype", StringComparison.OrdinalIgnoreCase))
                    {
                        listField = new ListItem();
                        listField.Text = field.Title;
                        listField.Value = field.Id.ToString();
                        fields.Add(listField);
                        continue;
                    }

                    if (field.InternalName.Equals("extid", StringComparison.OrdinalIgnoreCase))
                    {
                        listField = new ListItem();
                        listField.Text = field.Title;
                        listField.Value = field.Id.ToString();
                        fields.Add(listField);
                        continue;
                    }

                    if (!field.Hidden && field.Type != SPFieldType.Computed)
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
            var name = GetTableCount() == 0
                ? "RPTTSData"
                : $"RPTTSData{GetTableCount()}";

            Command = string.Format(
                @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U')) DROP TABLE [{0}]",
                name.Replace(Apostrophe, DoubleApostrophe));

            return ExecuteNonQuery(_conClientReporting);
        }

        public bool RefreshDefaultLists(string sListNames)
        {
            try
            {
                using (var site = new SPSite(SiteId))
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
                const string sAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
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

            var resourceList = CoreFunctions.getConfigSetting(rootWeb, "EPMLiveResourcePool").Replace("\r\n", ",");
            if (resourceList != string.Empty)
            {
                _DefaultLists = _DefaultLists + "," + resourceList;
            }

            _DefaultLists += ",User Information List,Team,Holidays,Holiday Schedules,My Work,Work Hours,Time Off";

            return _DefaultLists;
        }

        public void AddParam(string name, object value)
        {
            Params.Add(new SqlParameter(name, value));
        }

        public static bool CheckConnection(string cs)
        {
            bool success = true;
            SPSecurity.RunWithElevatedPrivileges(() => { success = TryToConnect(cs); });
            return success;
        }

        public static bool TryToConnect(string connectionString)
        {
            var success = true;

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    Trace.Write(ex.Message);
                    success = false;
                }
            }

            return success;
        }

        public object ExecuteScalar(SqlConnection con)
        {
            try
            {
                object value;
                using (var command = new SqlCommand { CommandType = CommandType, CommandText = Command, Connection = con })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(Params.ToArray());
                    value = command.ExecuteScalar();
                }
                return value;
            }
            catch (SqlException ex)
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    var eventMessage = CreateEventMessageWithParams(ex, Command, Params);
                    LogWindowsEvents(EpmLiveKey, ExecuteScalarKey, eventMessage, false, ExecuteScalarEvent);
                });
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                Command = null;
                Params.Clear();
                CommandType = CommandType.Text;
            }
        }

        public bool ExecuteNonQuery(SqlConnection con)
        {
            try
            {
                using (var command = new SqlCommand
                {
                    CommandType = CommandType,
                    CommandText = (Command),
                    Connection = con
                })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(Params.ToArray());
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    var eventMessage = CreateEventMessageWithParams(ex, Command, Params);
                    LogWindowsEvents(EpmLiveKey, ExecuteNonQueryKey, eventMessage, false, ExecuteScalarEvent);
                });
                _sqlErrorOccurred = true;
                _sqlError = ex.Message;
                return false;
            }
            finally
            {
                Command = null;
                Params.Clear();
                CommandType = CommandType.Text;
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
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    if (!EventLog.SourceExists("EPMLive Reporting - ExecuteNonQuery"))
                        EventLog.CreateEventSource("EPMLive Reporting - ExecuteNonQuery", "EPM Live");

                    using (var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting ExecuteNonQuery"))
                    {
                        myLog.MaximumKilobytes = 32768;
                        var cmdDetails = new StringBuilder($"Command: {sql}");
                        var cmdParams = new StringBuilder(" Params: ");

                        foreach (SqlParameter param in paramCollection)
                        {
                            if (param.Value != DBNull.Value)
                            {
                                cmdParams.Append($"[Name:{param.ParameterName} Value:{param.Value}],");
                            }
                            else
                            {
                                cmdParams.Append($"[Name:{param.ParameterName} Value: Null],");
                            }
                        }

                        myLog.WriteEntry($"Name: {_siteName} Url: {_siteUrl} ID: {SiteId} : {ex.Message}{cmdDetails}{cmdParams}",
                                         EventLogEntryType.Error, 2050);
                    }
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
                    var command = new SqlCommand { CommandType = CommandType, CommandText = Command, Connection = con })
                {
                    command.CommandTimeout = 3600; // 1hour
                    command.Parameters.AddRange(Params.ToArray());
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
                    var eventMessage = CreateEventMessageWithParams(ex, Command, Params);
                    LogWindowsEvents(EpmLiveKey, GetTableKey, eventMessage, false, ExecuteScalarEvent);
                });

                _sqlErrorOccurred = true;
                _sqlError = ex.Message;


                return null;
            }
            finally
            {
                Command = null;
                Params.Clear();
                CommandType = CommandType.Text;
            }
        }

        public DataRow GetSite()
        {
            DataTable dt;
            Command = string.Format("select * from [{0}] where siteid = @SiteId", Resources.ReportingDatabaseTable.Replace("'", ""));
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            AddParam("@SiteId", SiteId);
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
                UseSqlAccount = false;
            }
            else
            {
                UseSqlAccount = (bool)siteDataRow["SAccount"];
            }

            if (UseSqlAccount)
            {
                UserName = siteDataRow["Username"].ToString().Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                Password = siteDataRow["Password"].ToString().Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        private void PopulateConnectionStrings()
        {
            if (!UseSqlAccount)
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
                        _databaseName, UserName, Decrypt(Password)).Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                _masterCs =
                    string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};", _databaseServer,
                        "master", UserName, Decrypt(Password)).Replace("'", "");
                // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        public DataRow SAccountInfo()
        {
            Command = "SELECT * FROM RPTDatabases WHERE SiteId = @siteId";
            AddParam("@siteId", SiteId);

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
                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(webAppId)))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT * FROM RPTDatabases WHERE SiteId = @siteId", connection))
                    {
                        command.Parameters.AddWithValue("@siteId", siteId);

                        var dataTable = GetTable(command);
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0];
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static DataTable GetTable(SqlCommand cmd)
        {
            var dataAdapter = default(SqlDataAdapter);
            var dataTable = new DataTable();

            try
            {
                dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            finally
            {
                dataAdapter?.Dispose();
            }

            return dataTable;
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
            CheckArgumentForNull(li, nameof(li));
            CheckArgumentForNull(field, nameof(field));

            string resultType = field.GetProperty("ResultType").ToLower();

            var cultureInfo = CultureInfo.GetCultureInfo(field.CurrencyLocaleId).NumberFormat;
            var fieldRawValue = li[field.InternalName].ToString();
            var fieldValue = field.GetFieldValueAsText(li[field.InternalName]);

            switch (resultType)
            {
                case FieldTypeCurrency:
                case FieldTypeNumber:

                    float floatValue;
                    var currencySymbol = resultType == FieldTypeCurrency
                        ? cultureInfo.CurrencySymbol
                        : DollarSign;
                    var cleanValue = ClearSpecialChars(fieldValue, currencySymbol);

                    return !string.IsNullOrWhiteSpace(cleanValue) && float.TryParse(cleanValue, out floatValue)
                        ? (object)floatValue
                        : DBNull.Value;

                case FieldTypeDateTime:
                    DateTime dateTimeValue;
                    return DateTime.TryParse(fieldValue, out dateTimeValue)
                        ? (object)dateTimeValue
                        : DBNull.Value;

                case FieldTypeBool:
                    bool boolValue;
                    return bool.TryParse(fieldValue, out boolValue)
                        ? (object)boolValue
                        : DBNull.Value;

                default:
                    return fieldRawValue.Contains(HashSign)
                        ? fieldRawValue.Substring(fieldRawValue.IndexOf(HashSign)).Replace(HashSign, string.Empty)
                        : fieldValue;
            }
        }

        private string ClearSpecialChars(string text, string currencySymbol)
        {
            return text.Replace(currencySymbol, string.Empty)
                       .Replace("#VALUE!", string.Empty)
                       .Replace("<(", string.Empty)
                       .Replace(")>", string.Empty)
                       .Replace("%", string.Empty)
                       .Replace("(", Hyphen)
                       .Replace(")", string.Empty);
        }

        private void CheckArgumentForNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public void GetSnapshotQueueStatus(out int status, out string listguid, out int pctComplete, out bool queued)
        {
            DataTable dt;
            Command = " SELECT * FROM vwQueueTimerLog WHERE siteguid=@siteId and jobtype=7 and (NOT(status=2))";
            AddParam("@siteId", SiteId);

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
            AddParam("@siteId", SiteId);

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

        public bool BulkInsert(DataSet dsLists, bool blnLogStatus, out string message)
        {
            var sbcOptions = new SqlBulkCopyOptions();
            bool blnSuccess = false;
            string sListName = string.Empty;
            SqlTransaction tx = null;
            message = string.Empty;
            using (SqlConnection cn = new SqlConnection(_remoteCs))
            {
                try
                {
                    cn.Open();
                    foreach (DataTable dtList in dsLists.Tables)
                    {
                        tx = cn.BeginTransaction();
                        using (var sbc = new SqlBulkCopy(cn, sbcOptions, tx))
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
                                tx.Commit();
                                blnSuccess = true;
                            }
                            catch (Exception ex)
                            {
                                blnSuccess = false;
                                tx.Rollback();
                                message = string.Format("Bulk Insert {0} Refresh not completed due errors. {1} ", dtList.TableName, ex.Message.ToString());
                                //Log status
                                LogStatus(string.Empty, string.Empty, message,
                                    ex.ToString().Replace("'", ""), 2, 3, string.Empty);
                                // - CAT.NET false-positive: All single quotes are escaped/removed.
                            }
                            finally
                            {
                                if (tx != null)
                                    tx.Dispose();
                                if (sbc != null)
                                    sbc.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    blnSuccess = false;
                    message = string.Format("Bulk Insert Refresh not completed due errors. {0} ", ex.Message.Replace("'", ""));
                    LogStatus(string.Empty, string.Empty, message,
                                      ex.ToString().Replace("'", ""), 2, 3, string.Empty);
                }
            }
            return blnSuccess;
        }

        public bool BulkInsert(DataSet dsLists, Guid timerjobguid)
        {
            var sbcOptions = new SqlBulkCopyOptions();
            bool blnSuccess = false;
            string sListName = string.Empty;
            SqlTransaction tx = null;
            using (SqlConnection cn = new SqlConnection(_remoteCs))
            {
                try
                {
                    cn.Open();
                    foreach (DataTable dtList in dsLists.Tables)
                    {
                        tx = cn.BeginTransaction();
                        using (var sbc = new SqlBulkCopy(cn, sbcOptions, tx))
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
                                tx.Commit();
                                blnSuccess = true;
                            }
                            catch (Exception ex)
                            {
                                blnSuccess = false;
                                tx.Rollback();
                                LogStatus(string.Empty, string.Empty, string.Format("Bulk Insert {0} Refresh not completed due errors. {1} ", dtList.TableName, ex.Message.Replace("'", "")),
                                    ex.ToString().Replace("'", ""), 2, 3, timerjobguid.ToString());
                                // - CAT.NET false-positive: All single quotes are escaped/removed.
                            }
                            finally
                            {
                                tx?.Dispose();
                                sbc?.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    blnSuccess = false;

                    LogStatus(string.Empty, string.Empty, string.Format("Bulk Insert  Refresh not completed due errors. {0} ", ex.Message.Replace("'", "")),
                                    ex.ToString().Replace("'", ""), 2, 3, timerjobguid.ToString());

                }
            }
            return blnSuccess;
        }

        public string GetAllListIDs()
        {
            string sListIDs = string.Empty;
            var lListIDs = new List<string>();

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var site = new SPSite(SiteId))
                {
                    using (SPWeb web = site.OpenWeb(_webId))
                    {
                        foreach (SPList list in web.Lists)
                        {
                            var events = GetListEvents(list,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.ListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (events.Count > 0 && !lListIDs.Contains(list.ID.ToString()))
                            {
                                lListIDs.Add(list.ID.ToString());
                                continue;
                            }

                            var mwEvents = GetListEvents(list,
                                "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                "EPMLiveReportsAdmin.MyWorkListEvents",
                                new List<SPEventReceiverType>
                                {
                                    SPEventReceiverType.ItemAdded,
                                    SPEventReceiverType.ItemUpdated,
                                    SPEventReceiverType.ItemDeleting
                                });

                            if (mwEvents.Count > 0 && !lListIDs.Contains(list.ID.ToString()))
                            {
                                lListIDs.Add(list.ID.ToString());
                            }
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

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var site = new SPSite(SiteId))
                {
                    foreach (SPWeb web in site.AllWebs)
                    {
                        using (web)
                        {
                            foreach (SPList list in web.Lists)
                            {
                                var events = GetListEvents(list,
                                    "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                    "EPMLiveReportsAdmin.ListEvents",
                                    new List<SPEventReceiverType>
                                    {
                                        SPEventReceiverType.ItemAdded,
                                        SPEventReceiverType.ItemUpdated,
                                        SPEventReceiverType.ItemDeleting
                                    });

                                if (events.Count > 0 && !lLists.Contains(list.Title))
                                {
                                    lLists.Add(list.Title);
                                    continue;
                                }

                                var mwEvents = GetListEvents(list,
                                    "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050",
                                    "EPMLiveReportsAdmin.MyWorkListEvents",
                                    new List<SPEventReceiverType>
                                    {
                                        SPEventReceiverType.ItemAdded,
                                        SPEventReceiverType.ItemUpdated,
                                        SPEventReceiverType.ItemDeleting
                                    });

                                if (mwEvents.Count > 0 && !lLists.Contains(list.Title))
                                {
                                    lLists.Add(list.Title);
                                }
                            }
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
                Command = "INSERT INTO RPTLog VALUES(@RPTList,@ListName,@ShortMsg,@LongMsg,@Level,@Type,getdate(),@timerjobguid)";

                if (RPTListID != string.Empty)
                {
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

        public DataTable GetSnapshotResults(Guid timerjobguid)
        {
            Command = "SELECT * FROM RPTLog WHERE timerjobguid=@uid";
            AddParam("@uid", timerjobguid);
            return GetTable(GetClientReportingConnection);
        }

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

        public DataTable GetStatusLog()
        {
            return _dtStatusLog;
        }

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
                    var eventMessage = CreateEventMessage(ex);
                    LogWindowsEvents(EpmLiveKey, GetClientReportingConnectionSiteIdKey, eventMessage, false, GetEpmLiveConnectionEvent);
                });
            }
            return _conClientReporting;
        }

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
                AddParam("@siteID", SiteId);
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

                AddParam("@siteId", SiteId);
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

        public DataTable GetTableNames(string tableNameRoot)
        {
            Command = string.Format(
                "select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '{0}%' order by TABLE_NAME desc ",
                tableNameRoot.Replace(Apostrophe, string.Empty)); 
            return GetTable(GetClientReportingConnection);
        }

        public bool TableExists(string tableName, SqlConnection connection)
        {
            CheckArgumentForNull(tableName, nameof(tableName));
            CheckArgumentForNull(connection, nameof(connection));

            var exists = false;
            var command = default(SqlCommand);
            try
            {
                command = new SqlCommand(
                    "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = '"
                    + tableName + "')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END", connection);
                exists = Convert.ToInt32(command.ExecuteScalar()) == 1;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            finally
            {
                command?.Dispose();
            }

            return exists;
        }

        public string GetSafeTableName(string tableName)
        {
            DataTable dt = GetTableNames(tableName);
            if (dt.Rows.Count == 0)
            {
                return tableName;
            }
            else
            {
                tableName = tableName + GetTableCount().ToString();
                return tableName;
            }
        }

        public int GetTableCount()
        {
            int iTableCount = 0;
            Command = "SELECT TableCount FROM RPTSettings WHERE SiteID=@siteId";
            AddParam("@siteId", SiteId);
            iTableCount = (int)ExecuteScalar(GetClientReportingConnection);
            return iTableCount;
        }

        public Guid GetListId(string sListName)
        {
            using (var site = new SPSite(SiteId))
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
            using (var site = new SPSite(SiteId))
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

        public string GetTableName(Guid listId)
        {
            try
            {
                object objTableName = null;
                Command = "SELECT TableName FROM " + Resources.ReportingListTable.Replace("'", "") +
                          " WHERE RPTListId=@RPTListId AND SiteId=@siteID";
                AddParam("@RPTListId", listId);
                AddParam("@siteID", SiteId);
                objTableName = ExecuteScalar(GetClientReportingConnection);
                return objTableName.ToString();
            }
            catch { }
            return null;
        }

        public string GetTableName(string listName)
        {
            object objTableName = null;
            Command = "SELECT TableName FROM " + Resources.ReportingListTable.Replace("'", "") +
                      " WHERE ListName=@listName AND SiteId=@siteID";
            AddParam("@listName", listName);
            AddParam("@siteID", SiteId);
            objTableName = ExecuteScalar(GetClientReportingConnection);
            return objTableName.ToString();
        }
        
        public string GetListName(string tableName)
        {
            object objTableName = null;
            Command = "SELECT ListName FROM " + Resources.ReportingListTable.Replace("'", "") + " WHERE TableName='" +
                      tableName.Replace("'", "") + "' AND SiteId=@siteID";
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            AddParam("@siteID", SiteId);
            objTableName = ExecuteScalar(GetClientReportingConnection);
            return objTableName.ToString();
        }

        public bool RefreshTimesheets(out string sMessage, Guid jobUid, bool consolidationdone)
        {
            var oTimeSheet = new ReportBiz(SiteId);
            return (consolidationdone ? oTimeSheet.RefreshTimesheetInstant(out sMessage, jobUid) : oTimeSheet.RefreshTimesheet(out sMessage, jobUid));
        }

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
                    if (!ProcessAssignments(sWork, sAssignedTo, startDate, dueDate, listId, SiteId, item.ID,
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

        public bool MapDataBase(Guid siteId, Guid webId, string serverName, string dataBaseName, string un, string pw,
            bool useSA, bool dbExists, out string status)
        {
            Guid webAppId = webId;
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
                using (var site = new SPSite(SiteId))
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
            }
            else
            {
                sql = "IF NOT EXISTS (select * from sys.sysusers where name=@userName) " +
                      "BEGIN TRAN T1 BEGIN TRY exec('CREATE USER [@userName]') exec sp_addrolemember db_owner,@userName COMMIT TRAN T1 END TRY BEGIN CATCH ROLLBACK TRAN T1  PRINT ERROR_MESSAGE() END CATCH";
            }

            Command = sql;
            AddParam("@userName", un);
            return ExecuteNonQuery(GetClientReportingConnection);
        }

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
        
        public bool ListMappedAlready(string sListName, Guid siteId)
        {
            //Command = string.Format("SELECT COUNT(*) as ListCount FROM RPTList WHERE siteId='{0}' AND ListName='{1}'", _siteID, sListName); - CAT.NET
            Command = "SELECT COUNT(*) as ListCount FROM RPTList WHERE siteId=@siteId AND ListName=@listName";
            AddParam("@siteId", SiteId);
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

        public bool UpdateRPTSettings(string nonWorkingDays, int workHrs, out string sResult)
        {
            LogStatus("", "", "Reporting Refresh UpdateRPTSettings", string.Format("SELECT ISNULL(COUNT(*),0) as SiteCount FROM RPTSettings WHERE SiteID={0}", SiteId), 2, 3, "");
            Command = "SELECT ISNULL(COUNT(*),0) as SiteCount FROM RPTSettings WHERE SiteID=@siteID";
            //
            AddParam("@siteID", SiteId);
            string webName;
            string webUrl;

            object oResult = ExecuteScalar(GetClientReportingConnection);
            using (var site = new SPSite(SiteId))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    webName = web.Title;
                    webUrl = web.ServerRelativeUrl;
                }
            }

            if ((int)oResult == 0)
            {
                LogStatus("", "", "Reporting Refresh UpdateRPTSettings", string.Format("INSERT INTO RPTSettings VALUES({0},{1},{2},{3},{4})", SiteId, nonWorkingDays, workHrs, SiteName, SiteUrl), 2, 3, "");
                Command = "INSERT INTO RPTSettings VALUES(@siteID,@nonWorkingDays,@workHrs,@SiteName,@SiteUrl)";
            }
            else
            {
                LogStatus("", "", "Reporting Refresh UpdateRPTSettings",  string.Format("UPDATE RPTSettings SET NonWorkingDays={0}, WorkHours={1} WHERE SiteID={2}", nonWorkingDays, workHrs, SiteId), 2, 3, "");
                Command =
                    "UPDATE RPTSettings SET NonWorkingDays=@nonWorkingDays, WorkHours=@workHrs WHERE SiteID=@siteID";
            }

            AddParam("@siteID", SiteId);
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
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public static string Encrypt(string plaintext)
        {
            const string Key = "EPMLIVE";
            var buffer = new byte[0];

            using (var cryptoProvider = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = cryptoProvider.ComputeHash(Encoding.ASCII.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        buffer = Encoding.ASCII.GetBytes(plaintext);

                        return Convert.ToBase64String(transform.TransformFinalBlock(buffer, 0, buffer.Length));
                    }
                }
            }
        }

        /// <summary>
        ///     Decrpyts string value using key.
        /// </summary>
        /// <param name="base64Text"></param>
        /// <returns></returns>
        public static string Decrypt(string base64Text)
        {
            const string Key = "EPMLIVE";
            var buffer = new byte[0];

            try
            {
                using (var tDes = new TripleDESCryptoServiceProvider())
                {
                    using (var cryptoProvider = new MD5CryptoServiceProvider())
                    {
                        tDes.Key = cryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key));
                        tDes.Mode = CipherMode.ECB;

                        var DESDecrypt = tDes.CreateDecryptor();
                        buffer = Convert.FromBase64String(base64Text);

                        return ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
                    }
                }
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