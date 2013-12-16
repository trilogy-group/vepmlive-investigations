using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using EPMLiveReportsAdmin.Properties;
using Microsoft.SharePoint;
using System.Diagnostics;
using EPMLiveCore;
using System.Text;

namespace EPMLiveReportsAdmin
{
    public class ReportData
    {
        protected readonly string _epmLiveCs;
        protected SqlParameterCollection _params;
        protected SqlCommand _cmdWithParams;
        protected readonly Guid _siteId;
        protected EPMData _DAO;
        protected string _siteName;
        protected string _siteUrl;

        string _sqlError;
        public void CreateTextFile(string sPath)
        {
            _DAO.CreateTextFile(sPath);
        }

        public string SiteName
        {
            get { return _siteName; }
        }

        public bool EPMLiveConOpen
        {
            get { return _DAO.EPMLiveConOpen; }
        }

        public string UserName
        {
            get { return _DAO.UserName; }
            set { _DAO.UserName = value; }
        }

        public string Password
        {
            get { return _DAO.Password; }
            set { _DAO.Password = value; }
        }

        public bool UseSqlAccount
        {
            get { return _DAO.UseSqlAccount; }
            set { _DAO.UseSqlAccount = value; }
        }

        public string SiteUrl
        {
            get { return _siteUrl; }
        }

        public void WriteToFile(string sText)
        {
            _DAO.WriteToFile(sText);
        }

        public ReportData(Guid siteId, Guid webAppId)
        {
            _siteId = siteId;
            DataRow SAccountInfo = null;
            _epmLiveCs = EPMLiveCore.CoreFunctions.getConnectionString(webAppId);
            SAccountInfo = EPMData.SAccountInfo(siteId, webAppId);

            if (SAccountInfo != null)
            {
                try
                {
                    bool useSA = false;
                    useSA = (bool)SAccountInfo["SAccount"];
                    if (useSA) //Use SQL Account
                    {
                        _DAO = new EPMData(_siteId, SAccountInfo["DatabaseName"].ToString().Replace("'", ""), SAccountInfo["DatabaseServer"].ToString().Replace("'", ""), true, SAccountInfo["Username"].ToString().Replace("'", ""), EPMData.Decrypt(SAccountInfo["Password"].ToString()).Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                    else //Use System Account
                    {
                        _DAO = new EPMData(_siteId, webAppId, true);
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                }
                catch (Exception ex)
                {
                    _DAO = new EPMData(_siteId, webAppId, true);
                    _siteName = _DAO.SiteName;
                    _siteUrl = _DAO.SiteUrl;
                }
            }
            else
            {
                _DAO = new EPMData(_siteId, webAppId, true);
                _siteName = _DAO.SiteName;
                _siteUrl = _DAO.SiteUrl;
            }
        }

        public bool DeleteExistingTSData()
        {
            return _DAO.DeleteExistingTSData();
        }

        public ReportData(Guid siteId)
        {
            _siteId = siteId;
            DataRow SAccountInfo = null;

            using (SPSite site = new SPSite(siteId))
            {
                _epmLiveCs = EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id);
                SAccountInfo = EPMData.SAccountInfo(siteId, site.WebApplication.Id);
                //if(string.IsNullOrEmpty(_epmLiveCs))
                //_epmLiveCs = ConfigurationManager.ConnectionStrings["epmlive"].ConnectionString.ToString();
            }

            if (SAccountInfo != null)
            {
                try
                {
                    bool useSA = false;
                    useSA = (bool)SAccountInfo["SAccount"];
                    if (useSA) //Use SQL Account
                    {
                        _DAO = new EPMData(_siteId, SAccountInfo["DatabaseName"].ToString().Replace("'", ""), SAccountInfo["DatabaseServer"].ToString().Replace("'", ""), true, SAccountInfo["Username"].ToString().Replace("'", ""), EPMData.Decrypt(SAccountInfo["Password"].ToString()).Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                    else //Use System Account
                    {
                        _DAO = new EPMData(_siteId);
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                }
                catch (Exception ex)
                {
                    _DAO = new EPMData(_siteId);
                    _siteName = _DAO.SiteName;
                    _siteUrl = _DAO.SiteUrl;
                }
            }
            else
            {
                _DAO = new EPMData(_siteId);
                _siteName = _DAO.SiteName;
                _siteUrl = _DAO.SiteUrl;
            }
        }

        public ReportData(Guid siteId, string name, string server, bool useSAccount, string username, string password)
        {
            _siteId = siteId;
            _DAO = new EPMData(_siteId, name, server, useSAccount, username, password);
        }

        public DataRow GetSite()
        {
            DataTable dt;
            _DAO.Command = string.Format("select * from [{0}] where siteid = @SiteId", Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select * from [@tableName] where siteid = @SiteId";
            //_DAO.AddParam("@tableName", Resources.DatabaseTable);
            _DAO.AddParam("@SiteId", _siteId);
            dt = _DAO.GetTable(_DAO.GetEPMLiveConnection);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }

        public string Command
        {
            get { return _DAO.Command; }
            set { _DAO.Command = value; }
        }

        public bool ExecuteNonQuery(SqlConnection con)
        {
            return _DAO.ExecuteNonQuery(con);
        }

        public bool CheckServerConnection()
        {
            bool passed = false;
            passed = _DAO.GetMasterDbConnection.State == ConnectionState.Open;
            _sqlError = _DAO.SqlError;
            return passed;
        }

        public bool DatabaseExists()
        {
            _DAO.Command = string.Format("select db_id('{0}')", _DAO.remoteDbName.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select db_id(@dbName)";
            //_DAO.AddParam("@dbName", _DAO.remoteDbName);
            return (_DAO.ExecuteScalar(_DAO.GetMasterDbConnection) != DBNull.Value);
        }

        public bool IsReportingDB()
        {
            string sql = string.Format("IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='{0}') SELECT 'tablename exists' ELSE SELECT 'tablename does not exist'", Resources.SettingsTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //string sql = "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME=@tableName) SELECT 'tablename exists' ELSE SELECT 'tablename does not exist'";
            _DAO.Command = sql;
            //_DAO.AddParam("@tableName", Resources.SettingsTable);
            string exists = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
            if (exists.ToLower() == "tablename exists")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TableExists(string tableName)
        {
            _DAO.Command = string.Format("select object_id('{0}', 'U')", tableName.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select object_id(@tableName, 'U')";
            //_DAO.AddParam("@tableName", tableName);
            return (_DAO.ExecuteScalar(_DAO.GetClientReportingConnection) != DBNull.Value);
        }

        public bool ProcedureExists(string procName)
        {
            _DAO.Command = string.Format("select object_id('{0}', 'P')", procName.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select object_id(@spName, 'P')";
            //_DAO.AddParam("@spName", procName);
            return (_DAO.ExecuteScalar(_DAO.GetClientReportingConnection) != DBNull.Value);
        }

        public string GetError()
        {
            return _sqlError;
        }

        public bool CreateDatabase()
        {
            _DAO.Command = string.Format("create database {0}", _DAO.remoteDbName.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "create database @dbName";
            //_DAO.AddParam("@dbName", _DAO.remoteDbName);
            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }
            return _DAO.ExecuteNonQuery(_DAO.GetMasterDbConnection);
        }

        //public bool DeleteDatabase()
        //{
        //    _DAO.Command = string.Format(@"IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') DROP DATABASE [{0}]", _DAO.ToString().Replace("'","")); //- CAT.NET
        //    //_DAO.Command = "IF EXISTS (SELECT name FROM sys.databases WHERE name = @db) DROP DATABASE [@db]";
        //    //_DAO.AddParam("@db", _DAO);
        //    return _DAO.ExecuteNonQuery(_DAO.GetMasterDbConnection);
        //}

        public DataTable GetTableNames(string tableNameRoot)
        {
            _DAO.Command = string.Format("select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '{0}%' order by TABLE_NAME desc ", tableNameRoot.Replace("'", ""));  // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '[@tableName]%' order by TABLE_NAME desc ";
            //_DAO.AddParam("@tableName", tableNameRoot);
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public string GetSafeTableName(string tableName)
        {
            int iTableCount = GetTableCount();
            if (iTableCount == 0)
            {
                return tableName;
            }
            else
            {
                tableName = tableName + iTableCount.ToString();
                return tableName;
            }
        }

        public int GetTableCount()
        {
            int iTableCount = 0;
            //_DAO.Command = "SELECT TableCount FROM RPTSettings WHERE SiteID='" + _siteId.ToString() + "'"; - CAT.NET
            _DAO.Command = "SELECT TableCount FROM RPTSettings WHERE SiteID=@siteId";
            _DAO.AddParam("@siteId", _siteId);
            iTableCount = (int)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return iTableCount;
        }

        public bool CreateTable(string name, List<ColumnDef> columnDefs)
        {
            string message;
            return CreateTable(name, columnDefs, false, out message);
        }

        public bool CreateTable(string name, List<ColumnDef> columnDefs, bool dropIfExists, out string message)
        {

            if (!dropIfExists && TableExists(name))
            {
                message = "Table already exists.";
                return false;
            }

            var columns = new List<string>();
            foreach (var columnDef in columnDefs)
            {
                columns.Add(columnDef.ToString());
            }

            string script;
            if (name.ToLower().Contains("rpttsdata"))
            {
                script = string.Format(@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))
                    DROP TABLE [{0}]
                create table [{0}]({1},
                CONSTRAINT [PK_{0}] 
                PRIMARY KEY CLUSTERED ([rpttsduid] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]", name, string.Join(", ", columns.ToArray()));
            }
            else if (name.ToLower().Equals("lstmyworksnapshot"))
            {
                foreach (KeyValuePair<string, string> col in new Dictionary<string, string>
                                                 {
                                                     {"[WorkType]", "[NVarChar](256) NOT NULL"},
                                                     {"[DataSource]", "[Int] NULL"},
                                                     {"[Commenters]", "[NVarChar](MAX) NULL"},
                                                     {"[CommentersRead]", "[NVarChar](MAX) NULL"},
                                                     {"[CommentCount]", "[Int] NULL"}
                                                 }.Where(col => !columns.Exists(c => c.ToLower().StartsWith(col.Key.ToLower()))))
                {
                    columns.Add(col.Key + col.Value);
                }

                script = string.Format(@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))
                    DROP TABLE [{0}]

                create table [{0}]({1})ON [PRIMARY]

                CREATE CLUSTERED INDEX [IX_SiteId_WebId_ListId_ItemId] ON [{0}] 
                (
	                [SiteId] ASC,
	                [WebId] ASC,
	                [ListId] ASC,
	                [ItemId] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, 
                DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]", name, string.Join(", ", columns.ToArray()));
            }
            else if (name.ToLower().EndsWith("snapshot"))
            {
                script = string.Format(@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))
                    DROP TABLE [{0}]

                create table [{0}]({1},  
                CONSTRAINT [PK_{0}] 
                PRIMARY KEY CLUSTERED ([PeriodId] ASC, [WebId] ASC,[ItemId] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]
                ALTER TABLE [dbo].[{0}]  WITH NOCHECK ADD  CONSTRAINT [FK_EPM_{0}_RPTPeriod] FOREIGN KEY([PeriodId])
                REFERENCES [dbo].[RPTPeriods] ([PeriodId])
                NOT FOR REPLICATION                
                ALTER TABLE [dbo].[{0}] NOCHECK CONSTRAINT [FK_EPM_{0}_RPTPeriod]
                ", name, string.Join(", ", columns.ToArray()));
            }
            else if (name.ToLower().Equals("lstmywork"))
            {
                foreach (KeyValuePair<string, string> col in new Dictionary<string, string>
                                                 {
                                                     {"[WorkType]", "[NVarChar](256) NOT NULL"},
                                                     {"[DataSource]", "[Int] NULL"},
                                                     {"[Commenters]", "[NVarChar](MAX) NULL"},
                                                     {"[CommentersRead]", "[NVarChar](MAX) NULL"},
                                                     {"[CommentCount]", "[Int] NULL"}
                                                 }.Where(col => !columns.Exists(c => c.ToLower().StartsWith(col.Key.ToLower()))))
                {
                    columns.Add(col.Key + col.Value);
                }

                script = string.Format(@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))
                    DROP TABLE [{0}]

                create table [{0}]({1})ON [PRIMARY]

                CREATE CLUSTERED INDEX [IX_SiteId_WebId_ListId_ItemId] ON [{0}] 
                (
	                [SiteId] ASC,
	                [WebId] ASC,
	                [ListId] ASC,
	                [ItemId] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, 
                DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]", name, string.Join(", ", columns.ToArray()));
            }
            else
            {
                script = string.Format(@"
                IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U'))
                    DROP TABLE [{0}]

                create table [{0}]({1},  
                CONSTRAINT [PK_{0}] 
                PRIMARY KEY CLUSTERED ([WebId] ASC,[ItemId] ASC)
                WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
                IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, 
                ALLOW_PAGE_LOCKS  = ON) 
                )ON [PRIMARY]", name, string.Join(", ", columns.ToArray()));
            }


            _DAO.Command = script;
            if (!_DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection))
            {
                message = "Error creating table: " + _DAO.SqlError;
                return false;
            }

            message = string.Format("Table [{0}] successfully created.", name);
            return true;
        }

        public bool DeleteTable(string name)
        {
            _DAO.Command = string.Format(@"IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U')) DROP TABLE [{0}] ", name.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[@tableName]') AND type in (N'U')) DROP TABLE [@tableName] ";
            //_DAO.AddParam("@tableName", name);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool AddColumns(string table, List<ColumnDef> columns)
        {
            //ALTER TABLE dbo.LSTActions ADD
            //    NewColumn nvarchar(50) NULL,
            //    NewColumn2 int NULL

            if (columns.Count == 0)
                return true;

            //var epmData = new EPMData(_remoteCs);
            string addcols = "";
            foreach (ColumnDef columnDef in columns)
            {
                if (addcols.Length > 0)
                    addcols += ", ";
                addcols += columnDef.ToString();
            }
            //epmData.Command = string.Format(@"ALTER TABLE [{0}] ADD {1}", table, addcols);
            _DAO.Command = string.Format(@"ALTER TABLE [{0}] ADD {1}", table.Replace("'", ""), addcols.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "ALTER TABLE [@table] ADD {@cols}";
            //_DAO.AddParam("@tableName", table);
            //_DAO.AddParam("@cols", addcols);

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteColumns(string table, List<ColumnDef> columns)
        {
            if (columns.Count == 0)
                return true;

            //var epmData = new EPMData(_remoteCs);
            string addcols = "";
            foreach (ColumnDef columnDef in columns)
            {
                //if (!columnDef.IsLookup)
                //{
                if (addcols.Length > 0)
                    addcols += ", ";
                addcols += "[" + columnDef.SqlColumnName + "]";
                //}
                //else
                //{
                //    if (addcols.Length > 0)
                //        addcols += ", ";
                //    addcols += ("[" + columnDef.SqlColumnName + "ID], [" + columnDef.SqlColumnName + "Text]");
                //}
            }

            _DAO.Command = string.Format(@"ALTER TABLE [{0}] DROP COLUMN {1}", table.Replace("'", ""), addcols.Replace("'", ""));  // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "ALTER TABLE [@tableName] DROP COLUMN @cols";
            //_DAO.AddParam("@tableName", table);
            //_DAO.AddParam("@cols", addcols);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool InsertDbEntry()
        {
            string url;
            Guid webApplicationId;
            using (var site = new SPSite(_siteId))
            {
                url = site.Url;
                webApplicationId = site.WebApplication.Id;
            }

            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@WebApplicationId", webApplicationId);
            _DAO.AddParam("@Url", url);
            _DAO.AddParam("@Server", _DAO.remoteServerName);
            _DAO.AddParam("@Database", _DAO.remoteDbName);
            _DAO.AddParam("@useSAccount", _DAO.UseSqlAccount);

            if (!_DAO.UseSqlAccount)
            {
                _DAO.Command = string.Format(
                    @"insert into [{0}]([SiteId],[WebApplicationId],[Url],[DatabaseServer],[DatabaseName], [SAccount]) 
                                      values(@SiteId,@WebApplicationId,@Url,@Server,@Database,@useSAccount)",
                    Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
            else
            {
                _DAO.AddParam("@username", _DAO.UserName);
                _DAO.AddParam("@password", _DAO.Password);
                _DAO.Command = string.Format(
                    @"insert into [{0}]([SiteId],[WebApplicationId],[Url],[DatabaseServer],[DatabaseName], [SAccount], [UserName], [Password]) 
                                      values(@SiteId,@WebApplicationId,@Url,@Server,@Database,@useSAccount,@username,@password)",
                    Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            }

            return _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }

        public bool DeleteDbEntry()
        {
            _DAO.Command = string.Format("delete from [{0}] where SiteId = @SiteId", Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }


        //Module Added On: 3/20/2011
        public string GetDbVersion(Guid siteId)
        {
            string version = string.Empty;
            SqlConnection con = _DAO.GetSpecificReportingDbConnection(siteId);

            if (con != null && con.State == ConnectionState.Open)
            {
                _DAO.Command = "SELECT Version, [Installed On] FROM Version";
                DataTable dt = _DAO.GetTable(con);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "[Installed On] ASC";
                    version = dt.Rows[0]["Version"].ToString();
                }
                else
                {
                    version = "Unable to get version. Table may not exist.";
                }
                con.Close();
                con.Dispose();
            }
            else
            {
                version = "Unable to connect to database.";
            }
            return version;
        }

        public DataTable GetDbMappings()
        {
            _DAO.Command = string.Format("select distinct * from [{0}]", Resources.DatabaseTable.Replace("'", ""));  // - CAT.NET false-positive: All single quotes are escaped/removed.
            return _DAO.GetTable(_DAO.GetEPMLiveConnection);
        }

        public int GetExistingDbCount()
        {
            _DAO.Command = string.Format(@"select COUNT(r1.SiteId) from [{0}] r1 inner join [{0}] r2 on r1.DatabaseName = r2.DatabaseName and r1.DatabaseServer = r2.DatabaseServer where r2.SiteId = @SiteId", Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            _DAO.AddParam("@SiteId", _siteId);
            return (int)_DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);
        }

        public DataTable GetDistinctDbMappings()
        {
            _DAO.Command = string.Format("select distinct databaseserver, databasename from [{0}]", Resources.DatabaseTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.   
            return _DAO.GetTable(_DAO.GetEPMLiveConnection);
        }

        public DataTable GetListMappings()
        {
            _DAO.Command = string.Format("select * from [{0}] where siteId = @SiteId", Resources.ListSummaryView.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select * from [@viewName] where siteId = @SiteId";
            //_DAO.AddParam("@viewName", Resources.ListSummaryView);
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public DataRow GetListMapping(Guid listId)
        {
            _DAO.Command = "select * from [" + Resources.ListSummaryView.Replace("'", "") + "] where siteId = @SiteId and rptlistId = @rptListId"; // - CAT.NET false-positive: All single quotes are escaped/removed.
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@rptListId", listId);
            return _DAO.GetRow(_DAO.GetClientReportingConnection);
        }

        public bool InitializeDatabase()
        {
            bool success = false;
            //string sVersion = "''" +  System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "''";
            //string sVersion = "''" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "''";
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sVersion = "''" + fvi.FileVersion + "''";

            //_DAO.AddParam("@version", sVersion);
            _DAO.Command = Resources.InitDatabaseCreateTables.Replace("@version", sVersion);
            success = _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);

            if (success) //IF success -- Creating DB tables
            {
                _DAO.Command = Resources.InitDatabaseCreateProcedures;

                if (_DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection)) //IF success -- Creating stored procs
                {
                    success = true;
                }
                else
                {
                    _sqlError = _DAO.SqlError;
                    success = false;
                }
            }
            else
            {
                _sqlError = _DAO.SqlError;
                success = false;
            }
            return success;
        }

        public bool InsertList(Guid listId, string tableName, string tableNameSnapshot, bool resourceList)
        {
            //SPList list = null;
            //SPSite spSite = new SPSite(_siteId);

            //using (var web = spSite.RootWeb)
            //{
            //    list = web.Lists[listId];
            //}

            SPList list = null;
            using (var site = new SPSite(_siteId))
            {
                foreach (SPWeb web in site.AllWebs)
                {
                    try
                    {
                        list = web.Lists[listId];
                    }
                    catch { }
                    finally
                    {
                        if (web != null)
                        {
                            web.Dispose();
                        }
                    }

                    if (list != null)
                    {
                        break;
                    }
                }
            }

            _DAO.Command = string.Format(@"
                            IF NOT EXISTS (SELECT 1 FROM RPTList WHERE [ListName] = @ListName)
                            BEGIN
                                INSERT INTO [{0}]
                                   ([RPTListId]
                                   ,[ListName]
                                   ,[SiteId]
                                   ,[TableName]
                                   ,[TableNameSnapshot]
                                   ,[System]
                                   ,[ResourceList])
                                VALUES
                                   (@RPTListId, 
                                    @ListName,
                                    @SiteId,
                                    @TableName,
                                    @TableNameSnapshot,
                                    @System,
                                    @ResourceList)
                           END
                            ", Resources.ListTable);

            _DAO.AddParam("@RPTListId", list.ID);
            _DAO.AddParam("@ListName", list.Title);
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@TableName", tableName);
            _DAO.AddParam("@TableNameSnapshot", tableNameSnapshot);
            _DAO.AddParam("@System", false);
            _DAO.AddParam("@ResourceList", resourceList);

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool UpdateList(Guid listId, bool resourceList)
        {
            SPList list;
            Guid siteId;
            SPWeb web = null;
            try
            {
                web = SPContext.Current.Site.OpenWeb();
            }
            catch { }

            if (web != null)
            {
                siteId = web.Site.ID;
                list = web.Lists[listId];
            }
            else
            {
                using (SPSite s = new SPSite(_siteId))
                {
                    using (SPWeb w = s.OpenWeb())
                    {
                        list = w.Lists[listId];
                    }
                }
            }

            _DAO.AddParam("@RPTListId", list.ID);
            _DAO.AddParam("@ResourceList", resourceList);
            _DAO.Command = string.Format(@"
                                UPDATE [{0}]
                                       SET [ResourceList] = @ResourceList
                                WHERE 
                                       RPTListId = @RPTListId
                            ", Resources.ListTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            if (web != null)
            {
                web.Close();
                web.Dispose();
            }

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);

        }

        public bool DeleteList(Guid listId)
        {
            _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId ", Resources.ListTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "delete from [@tableName] where [RPTListId] = @RPTListId ";
            _DAO.AddParam("@RPTListId", listId);
            //_DAO.AddParam("@tableName", Resources.ListTable);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteAllListColumns(Guid listId)
        {
            //_DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId ", Resources.ColumnTable); - CAT.NET
            //_DAO.AddParam("@tableName", Resources.ColumnTable);
            _DAO.Command = string.Format("delete from [@tableName] where [RPTListId] = @RPTListId ", Resources.ColumnTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            _DAO.AddParam("@RPTListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteListColumns(Guid listId, List<ColumnDef> columns)
        {
            bool success = true;
            foreach (ColumnDef column in columns)
            {
                //if (column.ColumnType == SPFieldType.Lookup || column.ColumnType == SPFieldType.User)
                //{
                //    _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId and ColumnName = @ColumnName ", Resources.ColumnTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.               
                //    _DAO.AddParam("@RPTListId", listId);
                //    _DAO.AddParam("@ColumnName", column.SqlColumnName + "ID");
                //    success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);

                //    _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId and ColumnName = @ColumnName ", Resources.ColumnTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.               
                //    _DAO.AddParam("@RPTListId", listId);
                //    _DAO.AddParam("@ColumnName", column.SqlColumnName + "Text");
                //    success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
                //}
                //else
                //{
                _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId and ColumnName = @ColumnName ", Resources.ColumnTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.               
                _DAO.AddParam("@RPTListId", listId);
                _DAO.AddParam("@ColumnName", column.SqlColumnName);
                success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
                //_DAO.AddParam("@tableName", Resources.ColumnTable);
                //_DAO.Command = "delete from [@tableName] where [RPTListId] = @RPTListId and ColumnName = @ColumnName ";
                //}
            }
            return success;
        }

        public bool DeleteWork(Guid listid, int itemid)
        {
            //List specific
            return _DAO.DeleteWork(listid, itemid);
        }

        public bool DeleteWork(Guid listId)
        {
            _DAO.Command = string.Format("delete from [{0}] where [ListId] = @ListId ", Resources.WorkTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "delete from [@tableName] where [ListId] = @ListId ";
            _DAO.AddParam("@ListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteMyWork(Guid listid)
        {
            _DAO.Command = "Delete from [LSTMyWork] where [SiteId] = @SiteId AND [ListId] = @ListId";
            _DAO.AddParam("@ListId", listid);
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool InsertListColumns(Guid listId, List<ColumnDef> columns)
        {
            bool success = true;
            foreach (ColumnDef column in columns)
            {
                _DAO.AddParam("@RPTListId", listId);
                _DAO.AddParam("@ColumnName", column.SqlColumnName);
                _DAO.AddParam("@ColumnType", column.SqlColumnType.ToString());
                _DAO.AddParam("@ColumnSize", column.SqlColumnSize);
                _DAO.AddParam("@SharePointSize", column.ColumnType.ToString());
                _DAO.AddParam("@InternalName", column.InternalName);
                _DAO.AddParam("@DisplayName", column.DisplayName);
                _DAO.Command = string.Format(
                    @"
                        insert into [{0}]
                               ([RPTListId]
                               ,[ColumnName]
                               ,[ColumnType]
                               ,[ColumnSize]
                               ,[SharePointType]
                               ,[InternalName]
                               ,[DisplayName]
                                )
                         values
                               ( @RPTListId, @ColumnName, @ColumnType, @ColumnSize, @SharePointSize, @InternalName, @DisplayName )
                    ", Resources.ColumnTable);
                success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
            }
            return success;
        }

        public bool InsertLog(Guid listId, string listName, string ShortMessage, string LongMessage, int type)
        {
            return _DAO.LogStatus(listId.ToString(), listName, ShortMessage, LongMessage, type, 1, string.Empty);
        }

        public DataTable GetLog(Guid listId, int minimumLevel)
        {
            _DAO.Command = string.Format("select * from [{0}] where [Type] >= @Level and [RPTListId] = @RPTListId order by TimeStamp desc ", Resources.LogTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select * from [@tableName] where [Type] >= @Level and [RPTListId] = @RPTListId order by TimeStamp desc ";
            //_DAO.AddParam("@tableName", Resources.LogTable);
            _DAO.AddParam("@RPTListId", listId);
            _DAO.AddParam("@Level", minimumLevel);
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public int GetMaximumLogLevel(Guid listId)
        {
            _DAO.Command = string.Format("select * from [{0}] where [RPTListId] = @RPTListId ", Resources.ListSummaryView.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "select * from [@viewName] where [RPTListId] = @RPTListId ";
            //_DAO.AddParam("@viewName", Resources.ListSummaryView);
            _DAO.AddParam("@RPTListId", listId);
            return (int)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
        }

        public bool DeleteLog(Guid listId)
        {
            _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId ", Resources.LogTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "delete from [@tableName] where [RPTListId] = @RPTListId ";
            //_DAO.AddParam("@tableName", Resources.LogTable);
            _DAO.AddParam("@RPTListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteLog(Guid listId, int logType)
        {
            _DAO.Command = string.Format("delete from [{0}] where [RPTListId] = @RPTListId and [Type] = @LogType", Resources.LogTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "delete from [@tableName] where [RPTListId] = @RPTListId and [Type] = @LogType";
            _DAO.AddParam("@RPTListId", listId);
            _DAO.AddParam("@LogType", logType);
            //_DAO.AddParam("@tableName", Resources.LogTable);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public string GetTableNameSnapshot(Guid listId)
        {
            object objTableName = null;
            _DAO.Command = string.Format("SELECT TableNameSnapshot FROM [{0}] WHERE RPTListId= @RPTListId", Resources.ListTable.Replace("'", "")); // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "SELECT TableNameSnapshot FROM [@tableName] WHERE RPTListId= @RPTListId";
            _DAO.AddParam("@RPTListId", listId);
            //_DAO.AddParam("@tableName", Resources.ListTable);
            objTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return objTableName.ToString();
        }

        public DataTable GetTSAllDataWithSchema()
        {
            _DAO.AddParam("@siteuid", _siteId);
            _DAO.Command = "spTSAllData";
            _DAO.CommandType = CommandType.StoredProcedure;
            return _DAO.GetTable(_DAO.GetEPMLiveConnection, true);
        }

        public bool InsertTSAllData(DataTable table, out string message)
        {
            DataSet ds = new DataSet();
            table.TableName = Resources.TimesheetTable;
            ds.Tables.Add(table);
            _DAO.BulkInsert(ds, _DAO.GetClientReportingConnection, false);
            message = "Success assumed";
            return true;
        }

        //Modules created by XJH -- START
        public string GetTableName(string listName)
        {
            object objTableName = null;
            _DAO.Command = "SELECT TableName FROM " + Resources.ListTable.Replace("'", "") + " WHERE ListName=@listName AND SiteId=@siteId"; // - CAT.NET false-positive: All single quotes are escaped/removed.
            //_DAO.Command = "SELECT TableName FROM @tableName WHERE ListName=@listName AND SiteId=@siteId";
            //_DAO.AddParam("@tableName", Resources.ListTable);
            _DAO.AddParam("@listName", listName);
            _DAO.AddParam("@siteId", _siteId);
            objTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return (objTableName != null) ? objTableName.ToString() : string.Empty;
        }

        public virtual string InsertSQL(string sTableName, DataTable dtColumns, SPListItem li, ArrayList arrayList_defaultColumns, ArrayList mandatoryHiddenFlds)
        {
            string sSQL = "INSERT INTO " + sTableName.Replace("'", "") + AddColums(li, dtColumns).Replace("'", "") + AddColumnValues(li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, "insert").Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.
            return sSQL;
        }

        public virtual string UpdateSQL(string sTableName, DataTable dtColumns, SPListItem li, ArrayList arrayList_defaultColumns, ArrayList mandatoryHiddenFlds)
        {
            string sSQL = "UPDATE " + sTableName.Replace("'", "") + " SET " + AddColumnValues(li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, "update").Replace("'", "") + " WHERE listid='" + li.ParentList.ID.ToString().Replace("'", "") + "' AND itemid=" + li.ID.ToString().Replace("'", "") + " " +
                          "IF @@ROWCOUNT = 0 " +
                              "INSERT INTO " + sTableName.Replace("'", "") + AddColums(li, dtColumns).Replace("'", "") + AddColumnValues(li, dtColumns, arrayList_defaultColumns, mandatoryHiddenFlds, "insert").Replace("'", "");

            //string sSQL = "IF EXISTS (SELECT * FROM " + sTableName.Replace("'", "") + "WHERE listid='" + li.ParentList.ID.ToString().Replace("'", "") + "' AND itemid=" + li.ID.ToString().Replace("'", "") + ")" +
            //                "UPDATE " + sTableName.Replace("'", "") + " SET " + AddColumnValues(li, dtColumns, arrayList_defaultColumns, "update").Replace("'", "") + " WHERE listid='" + li.ParentList.ID.ToString().Replace("'", "") + "' AND itemid=" + li.ID.ToString().Replace("'", "") + // - CAT.NET false-positive: All single quotes are escaped/removed.
            //              "ELSE" +
            //                "INSERT INTO " + sTableName.Replace("'", "") + AddColums(dtColumns).Replace("'", "") + AddColumnValues(li, dtColumns, arrayList_defaultColumns, "insert").Replace("'", "");

            return sSQL;
        }

        public string DeleteSQL(string sTableName, Guid listid, int itemid)
        {
            string sSQL = "DELETE FROM " + sTableName.Replace("'", "") + " WHERE listid='" + listid.ToString().Replace("'", "") + "' AND itemid=" + itemid.ToString().Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.
            return sSQL;
        }

        public DataTable GetListColumns(string sListName)
        {

            string sSQL = "SELECT dbo.RPTColumn.*, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = @listName) AND dbo.RPTList.SiteId=@siteId";
            _DAO.Command = sSQL;
            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@siteId", _siteId);
            var dtColumns = _DAO.GetTable(_DAO.GetClientReportingConnection);
            return dtColumns;
        }

        public void VerifyListColumns(DataTable columns, string tableName)
        {
            bool colExists = true;
            foreach (DataRow col in columns.Rows)
            {
                string colName = col["ColumnName"].ToString();
                string sSQL = "IF (COL_LENGTH ('" + tableName + "', '" + colName + "') IS NOT NULL) BEGIN SELECT 'True' AS [Result] END ELSE BEGIN SELECT 'False' AS [Result] END";
                _DAO.Command = sSQL;
                colExists = bool.Parse(_DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString());

                if (!colExists)
                {
                    throw new Exception("Column mismatch error: Column " + colName + " exists in RPTColumns table but not in " + tableName + ".");
                }
            }
        }

        public DataTable GetListColumns(Guid listuid)
        {

            //string sSQL = "SELECT dbo.RPTColumn.*, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.RPTListId = '" + listuid.ToString() + "')"; - CAT.NET
            string sSQL = "SELECT dbo.RPTColumn.*, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.RPTListId = @listId)"; // - CAT.NET false-positive: All single quotes are escaped/removed.
            _DAO.Command = sSQL;
            _DAO.AddParam("@listId", listuid);
            var dtColumns = _DAO.GetTable(_DAO.GetClientReportingConnection);
            return dtColumns;
        }

        public bool ListReportsWork(string sTableName)
        {
            _DAO.Command = "SELECT ResourceList FROM " + Resources.ListTable.Replace("'", "") + " WHERE TableName='" + sTableName.Replace("'", "") + "'"; // - CAT.NET false-positive: All single quotes are escaped/removed.
            return (bool)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
        }

        public void Dispose()
        {
            _DAO.Dispose();
        }

        public bool BulkInsert(DataSet dsLists, SqlConnection con, Guid timerjobguid)
        {
            return _DAO.BulkInsert(dsLists, con, timerjobguid);
        }

        public void ReportError(Guid listid, string sListName, string sErrMsg, string sSection, int iErrType)
        {
            string sql = "INSERT INTO " + Resources.LogTable.Replace("'", "") + " VALUES(@RPTListID,@ListName,@ShortMsg,@LongMsg,@ErrorType,@Level,@TimeStamp,@timerjobguid)";
            _DAO.Command = sql;

            _DAO.AddParam("@RPTListID", listid);
            _DAO.AddParam("@ListName", sListName);
            _DAO.AddParam("@ShortMsg", sSection + "--" + sErrMsg);
            if (_DAO.SqlError != null)
            {
                _DAO.AddParam("@LongMsg", _DAO.SqlError);
            }
            else
            {
                _DAO.AddParam("@LongMsg", DBNull.Value);
            }
            _DAO.AddParam("@ErrorType", iErrType);
            _DAO.AddParam("@Level", 1);
            _DAO.AddParam("@TimeStamp", DateTime.Now);
            _DAO.AddParam("@timerjobguid", DBNull.Value);
            _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public void GetMappedFields()
        {
            throw new NotImplementedException();
        }

        public bool LogStatus(string RPTListID, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType)
        {
            return _DAO.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, string.Empty);
        }

        public bool ProcessAssignments(string sWork, string sAssignedTo, object StartDate, object DueDate, Guid ListID, Guid SiteID, int ItemID, string sListName)
        {
            bool blnProcess = true;
            object objResults = null;

            _DAO.Command = "spRPTProcessAssignments";
            _DAO.CommandType = CommandType.StoredProcedure;

            if (sWork != string.Empty)
            {
                _DAO.AddParam("@Work", sWork);
            }
            else
            {
                _DAO.AddParam("@Work", DBNull.Value);
            }

            if (sAssignedTo != string.Empty)
            {
                _DAO.AddParam("@AssignedTo", sAssignedTo);
            }
            else
            {
                _DAO.AddParam("@AssignedTo", DBNull.Value);
            }

            _DAO.AddParam("@Start", StartDate);
            _DAO.AddParam("@Finish", DueDate);
            _DAO.AddParam("@ListID", ListID);
            _DAO.AddParam("@SiteID", SiteID);
            _DAO.AddParam("@ItemID", ItemID);

            //Need to implement further. Need to check result for status/errors
            objResults = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);

            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }

            return blnProcess;
        }

        public bool InsertListItem(string sSQL)
        {
            bool passed = false;
            _cmdWithParams.CommandText = sSQL;
            passed = _DAO.ExecuteNonQuery(_cmdWithParams, _params, _DAO.GetClientReportingConnection);
            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }
            return passed;
        }

        public bool UpdateListItem(string sSQL)
        {
            bool passed = false;
            _cmdWithParams.CommandText = sSQL;
            passed = _DAO.ExecuteNonQuery(_cmdWithParams, _params, _DAO.GetClientReportingConnection);
            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }
            return passed;
        }

        public bool DeleteListItem(string sSQL)
        {
            _DAO.Command = sSQL;
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        protected string AddColums(DataTable dt)
        {
            string sColums = " (";

            foreach (DataRow row in dt.Rows)
            {
                if (row["SharePointType"] != "Lookup")
                {
                    sColums = sColums + "[" + row["ColumnName"].ToString().Replace("'", "") + "],"; // - CAT.NET false-positive: All single quotes are escaped/removed.
                }
                else
                {
                    sColums = sColums + "[" + row["ColumnName"].ToString().Replace("'", "") + "ID], [" + row["ColumnName"].ToString().Replace("'", "") + "Text],"; // - CAT.NET false-positive: All single quotes are escaped/removed.
                }
            }

            sColums = sColums.Remove(sColums.Length - 1);
            sColums = sColums + ") ";
            return sColums;
        }

        protected string AddColums(SPListItem item, DataTable dt)
        {
            string sColums = " (";
            string sColumnName = string.Empty;
            string sInternalName = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                sColumnName = row["ColumnName"].ToString().Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.
                sInternalName = row["InternalName"].ToString().Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.

                if (item.Fields.ContainsField(sInternalName) ||
                    sColumnName == "SiteId" ||
                    sColumnName == "WebId" ||
                    sColumnName == "ListId" ||
                    sColumnName == "ItemId" ||
                    sColumnName == "WebUrl" ||
                    sColumnName == "Commenters" ||
                    sColumnName == "CommentersRead" ||
                    sColumnName == "CommentCount" ||
                    sColumnName == "WorkspaceUrl")
                {
                    if (row["SharePointType"] != "Lookup")
                    {
                        sColums = sColums + "[" + row["ColumnName"].ToString().Replace("'", "") + "],";
                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }
                    else
                    {
                        sColums = sColums + "[" + row["ColumnName"].ToString().Replace("'", "") + "ID], [" +
                                  row["ColumnName"].ToString().Replace("'", "") + "Text],";
                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }
                }
            }

            sColums = sColums.Remove(sColums.Length - 1);
            sColums = sColums + ") ";
            return sColums;
        }


        protected virtual bool IsLookUpField(string sListName, string sColumnName)
        {
            object objType = null;
            bool blnLookup = false;
            //string sSQL = "SELECT dbo.RPTColumn.SharePointType, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = '" + sListName + "') AND (ColumnName='" + sColumnName + "')"; - CAT.NET
            string sSQL = "SELECT dbo.RPTColumn.SharePointType, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = @listName) AND (ColumnName=@colName)";
            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@colName", sColumnName);
            _DAO.Command = sSQL;
            objType = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            if (objType.ToString().ToLower() == "lookup" || objType.ToString().ToLower() == "user" || objType.ToString().ToLower() == "multichoice" || objType.ToString().ToLower() == "flookup")
            {
                blnLookup = true;
            }
            return blnLookup;
        }

        public static string AddLookUpFieldValues(string sValue, string sValueType)
        {
            string sReturnValue = string.Empty;
            sValue = System.Web.HttpUtility.HtmlDecode(sValue);
            SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(sValue);
            foreach (SPFieldLookupValue lv in lvc)
            {
                switch (sValueType)
                {
                    case "id":
                        sReturnValue += lv.LookupId.ToString() + ",";
                        break;
                    case "text":
                        sReturnValue += lv.LookupValue.ToString() + ",";
                        break;
                };
            }

            if (sReturnValue == string.Empty && sValueType.ToLower() == "text") //Means lvc conversion failed.
            {
                try
                {
                    if (sValue.Contains(";#"))
                    {
                        char[] splitter = ",".ToCharArray();
                        sValue = sValue.Replace(";#", ",");
                        string[] arrVals = sValue.Split(splitter);

                        foreach (string val in arrVals)
                        {
                            if (val != string.Empty)
                            {
                                sReturnValue = sReturnValue + val + ",";
                            }
                        }

                        if (sReturnValue.IndexOf(",") == 0)
                        {
                            sReturnValue.Remove(0, 1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting AddLookUpFieldValue"))
                            EventLog.CreateEventSource("EPMLive Reporting AddLookUpFieldValue", "EPM Live");

                        EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting AddLookUpFieldValue");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + " -- Stack: " + ex.StackTrace, EventLogEntryType.Error, 9000);
                    });
                }
            }

            //Remove last ","
            if (sReturnValue.Contains(","))
            {
                sReturnValue = sReturnValue.Remove(sReturnValue.LastIndexOf(","));
            }
            return sReturnValue;
        }

        public static string AddMultiChoiceValues(string sValue, string sValueType)
        {
            string sReturnValue = string.Empty;

            try
            {
                SPFieldMultiChoiceValue mcv = new SPFieldMultiChoiceValue(sValue);
                for (int i = 0; i < mcv.Count; i++)
                {
                    switch (sValueType)
                    {
                        case "text":
                            sReturnValue += mcv[i].ToString() + ",";
                            break;
                    };
                }
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (!EventLog.SourceExists("EPMLive Reporting AddMultiChoiceValues"))
                        EventLog.CreateEventSource("EPMLive Reporting AddMultiChoiceValues", "EPM Live");

                    EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting AddMultiChoiceValues");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(ex.Message + " -- Stack: " + ex.StackTrace, EventLogEntryType.Error, 9000);
                });
            }

            //Remove last ","
            if (sReturnValue.Contains(","))
            {
                sReturnValue = sReturnValue.Remove(sReturnValue.LastIndexOf(","));
            }
            return sReturnValue;
        }

        protected virtual string AddColumnValues(SPListItem li, DataTable dtColumns, ArrayList arrayList_defaultColumns, ArrayList mandatoryHiddenFlds, string sAction)
        {
            string sColValues = string.Empty;
            string sColumnName = string.Empty;
            string sInternalName = string.Empty;
            SPField field = null;
            SqlParameter param = null;
            string floatParams = string.Empty;
            _cmdWithParams = new SqlCommand();
            _params = _cmdWithParams.Parameters;

            //Format sql text prefix
            if (sAction == "insert")
            {
                sColValues = " VALUES(";
            }

            try
            {
                //Create and add parameters for each table column.
                foreach (DataRow row in dtColumns.Rows)
                {
                    sColumnName = row["ColumnName"].ToString().Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.
                    sInternalName = row["InternalName"].ToString().Replace("'", ""); // - CAT.NET false-positive: All single quotes are escaped/removed.

                    //Check for Default Colunms
                    if (arrayList_defaultColumns.Contains(sColumnName.ToLower()))
                    {
                        param = PopulateDefaultColumnValue(sColumnName.ToLower().Replace("'", ""), li); // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }
                    else if (mandatoryHiddenFlds.Contains(sColumnName.ToLower()))
                    {
                        param = PopulateMandatoryHiddenFldsColumnValue(sColumnName.ToLower().Replace("'", ""), li); // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }
                    else
                    {
                        //Check for field on list
                        if (li.Fields.ContainsField(sInternalName))
                        {
                            //Check for lookupfield type
                            if (!IsLookUpField(li.ParentList.Title, sColumnName))
                            {
                                //Init. item field
                                field = li.Fields.GetFieldByInternalName(sInternalName);

                                //Init. field type
                                param = GetParam(field, sColumnName);

                                //Init. field parameter name
                                param.ParameterName = "@" + field.InternalName.Replace("'", "");

                                //Init. field parameter value
                                if (field.Type != SPFieldType.Calculated)
                                {
                                    object lookupVal = null;
                                    try
                                    {
                                        lookupVal = li[field.InternalName];
                                    }
                                    catch { }

                                    if (lookupVal != null)
                                    {
                                        param.Value = lookupVal.ToString();
                                    }
                                    else
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        param.Value = _DAO.GetCalculatedFieldValue(li, (SPFieldCalculated)field);
                                    }
                                    catch (Exception ex)
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                }


                            }
                            else //Is lookup field and is processed differently.
                            {
                                //Init. item field
                                field = li.Fields.GetFieldByInternalName(sInternalName);

                                //Init. sql parameter
                                param = GetParam(field, sColumnName);

                                //Init. field parameter name
                                param.ParameterName = "@" + sColumnName.Replace("'", "");

                                object lookupVal = null;
                                try
                                {
                                    lookupVal = li[field.InternalName];
                                }
                                catch { }


                                if (field is SPFieldMultiChoice)
                                {
                                    //Determine whether it's the "text" or "id" lookup field
                                    if (sColumnName.ToLower().EndsWith("text") && lookupVal != null) //Means it's the "text" lookup field
                                    {
                                        param.Value = AddMultiChoiceValues(lookupVal.ToString(), "text");
                                    }
                                    else if (lookupVal != null) //Means it's the "id" lookup field
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                }
                                else
                                {
                                    //Determine whether it's the "text" or "id" lookup field
                                    if (sColumnName.ToLower().EndsWith("text") && lookupVal != null) //Means it's the "text" lookup field
                                    {
                                        param.Value = AddLookUpFieldValues(lookupVal.ToString(), "text");
                                    }
                                    else if (lookupVal != null) //Means it's the "id" lookup field
                                    {
                                        param.Value = AddLookUpFieldValues(lookupVal.ToString(), "id");
                                    }
                                    else
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                field =
                                    li.ParentList.ParentWeb.Site.RootWeb.Lists[li.ParentList.Title].Fields.
                                        GetFieldByInternalName(sInternalName);
                            }
                            catch
                            { }

                            if (field != null)
                            {
                                param = GetParam(field, sColumnName);
                                param.Value = DBNull.Value;
                                param.ParameterName = "@" + sInternalName.Replace("'", "");
                                // - CAT.NET false-positive: All single quotes are escaped/removed.
                            }
                        }
                    }

                    //Add parameter to collection
                    _params.Add(param);
                    if (param.SqlDbType == SqlDbType.Float)
                    {
                        floatParams = floatParams.Replace("'", "") + param.ParameterName.Replace("'", "") + "=" + param.Value.ToString().Replace("'", "") + "|"; // - CAT.NET false-positive: All single quotes are escaped/removed.
                    }

                    switch (sAction)
                    {
                        case "insert":
                            //Add parameter to sql command text script                
                            sColValues = sColValues.Replace("'", "") + param.ParameterName.Replace("'", "") + ","; // - CAT.NET false-positive: All single quotes are escaped/removed.
                            break;

                        case "update":
                            sColValues = sColValues + "[" + sColumnName.Replace("'", "") + "] = " + param.ParameterName.Replace("'", "") + ", "; // - CAT.NET false-positive: All single quotes are escaped/removed.
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                param.Value = DBNull.Value;
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (!EventLog.SourceExists("EPMLive Reporting GetColumnValue"))
                        EventLog.CreateEventSource("EPMLive Reporting GetColumnValue", "EPM Live");

                    EventLog myLog = new EventLog("EPM Live", ".", "EPMLive Reporting GetColumnValue");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry("Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteId.ToString() + " : " + ex.Message + " ColumnName: " + sColumnName + " InternalName: " + sInternalName, EventLogEntryType.Error, 9000);
                });
            }

            //Remove "," after last parameter in sql script (ie @p1,@p2,@p3,)
            sColValues = sColValues.Remove(sColValues.LastIndexOf(",")).Replace("'", "");
            switch (sAction)
            {
                case "insert":
                    //Add closing ")" to sql 
                    sColValues = sColValues + ") ";
                    break;
            }

            //ex. string Values(@p1,@p2,@p3)
            return sColValues;
        }

        public string RemoveTags(string sValue, SPField field)
        {
            string sVal = field.GetFieldValueAsText(sValue);
            return sVal;
        }

        public Guid GetListId(string sListName)
        {
            //_DAO.Command = "SELECT RPTListID FROM RPTList WHERE ListName='" + sListName + "' AND siteId='" + _siteId + "'"; - CAT.NET
            _DAO.Command = "SELECT RPTListID FROM RPTList WHERE ListName=@listName AND siteId=@siteId";
            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@siteId", _siteId);
            object val = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return (val != null) ? (Guid)val : Guid.Empty;
        }

        protected virtual SqlParameter PopulateDefaultColumnValue(string sColumn, SPListItem li)
        {
            SqlParameter param = new SqlParameter();
            switch (sColumn)
            {
                case "siteid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@siteid";
                    param.Value = li.ParentList.ParentWeb.Site.ID;
                    break;

                case "webid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@webid";
                    param.Value = li.ParentList.ParentWeb.ID;
                    break;

                case "listid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@rptlistid";
                    param.Value = li.ParentList.ID;
                    break;

                case "itemid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@itemid";
                    param.Value = li.ID;
                    break;

                case "weburl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.ParameterName = "@weburl";
                    param.Value = li.ParentList.ParentWeb.ServerRelativeUrl;
                    break;
            }
            return param;
        }

        protected virtual SqlParameter PopulateMandatoryHiddenFldsColumnValue(string sColumn, SPListItem li)
        {
            SqlParameter param = new SqlParameter();
            var val = string.Empty;

            switch (sColumn)
            {
                case "commenters":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commenters";                   
                    try
                    {
                        val = li["Commenters"].ToString();
                        param.Value = val;
                    }
                    catch { param.Value = DBNull.Value; }
                    break;

                case "commentcount":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@commentcount";
                    try
                    {
                        val = li["CommentCount"].ToString();
                        param.Value = Convert.ToInt32(val); 
                    }
                    catch { param.Value = DBNull.Value; }
                    break;

                case "commentersread":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commentersread";
                    try
                    {
                        val = li["CommentersRead"].ToString();
                        param.Value = val;
                    }
                    catch { param.Value = DBNull.Value; }
                    break;

                case "workspaceurl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@workspaceurl";
                    try
                    {
                        val = li["WorkspaceUrl"].ToString();
                        param.Value = val;
                    }
                    catch { param.Value = DBNull.Value; }
                    break;
            }
            return param;
        }

        public static SqlParameter GetParam(SPField field, string sColumnName)
        {
            SqlParameter param = new SqlParameter();
            SPFieldType type = field.Type;
            string sType = field.TypeAsString.ToLower();

            switch (type)
            {
                case SPFieldType.Integer:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Lookup:
                    if (sColumnName.ToLower().EndsWith("id") && sType != "lookupmulti")
                    {
                        param.SqlDbType = SqlDbType.Int;
                    }
                    else
                    {
                        param.SqlDbType = SqlDbType.NVarChar;
                        param.Size = 256;
                    }

                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.User:
                    if (sColumnName.ToLower().EndsWith("id") && sType != "usermulti")
                    {
                        param.SqlDbType = SqlDbType.Int;
                    }
                    else
                    {
                        param.SqlDbType = SqlDbType.NVarChar;
                        param.Size = 256;
                    }

                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Text:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Note:
                    param.SqlDbType = SqlDbType.NText;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.MultiChoice:
                    if (sColumnName.ToLower().EndsWith("id"))
                    {
                        param.SqlDbType = SqlDbType.Int;
                    }
                    else
                    {
                        param.SqlDbType = SqlDbType.NVarChar;
                        param.Size = 256;
                    }

                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Number:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Currency:
                    param.SqlDbType = SqlDbType.Float;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Boolean:
                    param.SqlDbType = SqlDbType.Bit;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.DateTime:
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Calculated:
                    string sResultType = field.GetProperty("ResultType").ToLower();
                    switch (sResultType)
                    {
                        case "currency":
                            param.SqlDbType = SqlDbType.Float;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "number":
                            param.SqlDbType = SqlDbType.Float;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "datetime":
                            param.SqlDbType = SqlDbType.DateTime;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "boolean":
                            param.SqlDbType = SqlDbType.Bit;
                            param.Direction = ParameterDirection.Input;
                            break;

                        case "text":
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 256;
                            break;
                    }
                    break;

                case SPFieldType.Guid:
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.Counter:
                    param.SqlDbType = SqlDbType.Int;
                    param.Direction = ParameterDirection.Input;
                    break;

                case SPFieldType.URL:
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    break;

                default:
                    switch (sType)
                    {
                        case "totalrollup":
                            param.SqlDbType = SqlDbType.Float;
                            break;

                        default:
                            param.SqlDbType = SqlDbType.NVarChar;
                            param.Size = 256;
                            break;
                    }
                    break;
            }
            return param;
        }

        public bool InsertAllItemsDB(DataSet dsLists, Guid timerjobguid)
        {
            bool blnPassed = _DAO.BulkInsert(dsLists, _DAO.GetClientReportingConnection, timerjobguid);
            return blnPassed;
        }

        public SqlConnection GetClientReportingConnection()
        {
            return _DAO.GetClientReportingConnection;
        }

        protected object GetDefaultColumnValue(string sColumn, SPListItem li, out bool blnGuid)
        {
            object oValue = null;
            blnGuid = false;

            switch (sColumn)
            {
                case "siteid":
                    oValue = li.ParentList.ParentWeb.Site.ID;
                    blnGuid = true;
                    break;

                case "webid":
                    oValue = li.ParentList.ParentWeb.ID;
                    blnGuid = true;
                    break;

                case "rptlistid":
                    oValue = li.ParentList.ID;
                    blnGuid = true;
                    break;
                //Old implementation will be removed.
                case "listid":
                    oValue = li.ParentList.ID;
                    blnGuid = true;
                    break;

                case "itemid":
                    oValue = li.ID;
                    break;

                case "weburl":
                    oValue = li.ParentList.ParentWeb.ServerRelativeUrl;
                    break;
            }
            return oValue;
        }

        public DataTable ListItemsDataTable(Guid timerjobguid, string sTableName, SPWeb spWeb, string sListName, ArrayList _arrayListDefaultColumns, out bool error, out string errMsg)
        {
            DataTable dtItems = new DataTable();
            DataTable dtColumns = GetListColumns(sListName);
            SPList spList = null;
            DataRow itemRow;
            SPField field;
            string sType;
            string errItemTitle = string.Empty;
            string errItemID = string.Empty;
            string errColumnName = string.Empty;

            error = false;
            errMsg = string.Empty;

            try
            {
                // verify the columns in RPTColumns exist in LST<xxx> tables.
                VerifyListColumns(dtColumns, sTableName);

                //LOAD LIST COLUMNS --- START
                foreach (DataRow row in dtColumns.Rows)
                {
                    //Checking for column type in db, then setting appropiate column type
                    sType = row["ColumnType"].ToString().ToLower();
                    switch (sType)
                    {
                        case "uniqueidentifier":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Guid"));
                            break;

                        case "int":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Decimal"));
                            break;

                        case "datetime":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.DateTime"));
                            break;

                        case "float":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Decimal"));
                            break;

                        default:
                            dtItems.Columns.Add(row["ColumnName"].ToString());
                            break;
                    }
                } // END


                spList = spWeb.Lists[sListName];
                foreach (SPListItem item in spList.Items)
                {
                    // set item info for logging
                    errItemID = item.ID.ToString();
                    errItemTitle = item.Title;

                    itemRow = dtItems.NewRow();
                    foreach (DataRow column in dtColumns.Rows)
                    {
                        errColumnName = column["ColumnName"].ToString();
                        if (spList.Fields.ContainsField(column["internalname"].ToString()))
                        {
                            if (column["SharepointType"].ToString().ToLower() == "lookup" || column["SharepointType"].ToString().ToLower() == "user" || column["SharepointType"].ToString().ToLower() == "multichoice")
                            {
                                if (column["ColumnName"].ToString().ToLower().EndsWith("text"))
                                {
                                    if (ItemHasValue(item, column["internalname"].ToString()))
                                    //if (item[column["internalname"].ToString()] != null)
                                    {
                                        itemRow[column["ColumnName"].ToString()] = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "text");
                                    }
                                    else
                                    {
                                        itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                    }
                                }
                                else if (column["ColumnName"].ToString().ToLower().EndsWith("id"))
                                {
                                    if (ItemHasValue(item, column["internalname"].ToString()))
                                    //if (item[column["internalname"].ToString()] != null)
                                    {
                                        int iResult;
                                        string sInt = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "id");
                                        if (int.TryParse(sInt, out iResult))
                                        {
                                            itemRow[column["ColumnName"].ToString()] = sInt;
                                        }
                                    }
                                    else
                                    {
                                        itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                    }
                                }
                            }
                            else
                            {
                                if (!_arrayListDefaultColumns.Contains(column["ColumnName"].ToString().ToLower()))
                                {
                                    field = item.Fields.GetFieldByInternalName(column["columnname"].ToString());
                                    if (ItemHasValue(item, field.InternalName))
                                    //if (item[field.InternalName] != null)
                                    {
                                        try
                                        {
                                            if (field.Type != SPFieldType.Calculated)
                                            {
                                                itemRow[column["ColumnName"].ToString()] = item[field.InternalName];
                                            }
                                            else
                                            {
                                                itemRow[column["ColumnName"].ToString()] = _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                        }
                                    }
                                    else
                                    {
                                        itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool blnGuid;
                            object obj;
                            obj = GetDefaultColumnValue(column["ColumnName"].ToString().ToLower(), item, out blnGuid);
                            if (blnGuid && obj != null)
                            {
                                Guid id = (Guid)obj;
                                itemRow[column["ColumnName"].ToString()] = id;
                            }
                            else if (obj != null)
                            {
                                itemRow[column["ColumnName"].ToString()] = obj;
                            }
                        }
                    }
                    dtItems.Rows.Add(itemRow);
                }
            }
            catch (Exception ex)
            {
                //DataRow[] dr = dtResults.Select("ListName='" + sListName + "'");

                //if (dr[0]["ResultText"] == null)
                //{
                //    dr[0]["ResultText"] = ex.Message;
                //}
                //else
                //{
                //    dr[0]["ResultText"] = dr[0]["ResultText"] + ", Error:" + ex.Message.ToString();
                //}                

                //dtItems = null;
                //Guid tjb = Guid.NewGuid();                
                //_DAO.LogStatus(_DAO.GetListId(spList.Title).ToString(), spList.Title, spWeb.Name + " (" + spWeb.ServerRelativeUrl + ") - Processed with errors.", ex.Message + " -- Stack: " + ex.StackTrace, 2, 3, tjb.ToString());
                //_DAO.LogStatus(_DAO.GetListId(sListName).ToString(), sListName, "Error on Refresh.", ex.Message, 2, 3, timerjobguid.ToString());            
                error = true;
                errMsg = ex.Message + "[LOCATION INFO] - ItemTitle: " + errItemTitle + ", ItemId: " + errItemID + ", ColumnName: " + errColumnName + ".";

            }
            return dtItems;
        }

        public DataTable MyWorkListItemsDataTable(Guid timerjobguid, string sTableName, SPWeb spWeb, string sListName, ArrayList _arrayListDefaultColumns, out bool error, out string errMsg)
        {
            DataTable dtItems = new DataTable();
            DataTable dtColumns = GetListColumns("My Work");
            dtColumns = AddMetaInfoCols(dtColumns);
            SPList spList = null;
            DataRow itemRow;
            SPField field;
            string sType;
            string errItemTitle = string.Empty;
            string errItemID = string.Empty;
            string errColumnName = string.Empty;

            error = false;
            errMsg = string.Empty;

            try
            {
                // verify the columns in RPTColumns exist in LST<xxx> tables.
                VerifyListColumns(dtColumns, sTableName);

                //LOAD LIST COLUMNS --- START
                foreach (DataRow row in dtColumns.Rows)
                {
                    //Checking for column type in db, then setting appropiate column type
                    sType = row["ColumnType"].ToString().ToLower();
                    switch (sType)
                    {
                        case "uniqueidentifier":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Guid"));
                            break;

                        case "int":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Decimal"));
                            break;

                        case "datetime":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.DateTime"));
                            break;

                        case "float":
                            dtItems.Columns.Add(row["ColumnName"].ToString(), Type.GetType("System.Decimal"));
                            break;

                        default:
                            dtItems.Columns.Add(row["ColumnName"].ToString());
                            break;
                    }
                } // END


                spList = spWeb.Lists[sListName];
                foreach (SPListItem item in spList.Items)
                {
                    // set item info for logging
                    errItemID = item.ID.ToString();
                    errItemTitle = item.Title;

                    SPFieldCollection spFieldCollection = item.ParentList.Fields;

                    if (spFieldCollection.ContainsFieldWithInternalName("AssignedTo") && item["AssignedTo"] != null)
                    {
                        var spFieldUserValueCollection = new SPFieldUserValueCollection(item.Web,
                                                                                        item["AssignedTo"].ToString());

                        int totalAssignedToUsers = spFieldUserValueCollection.Count;

                        if (spFieldCollection.ContainsFieldWithInternalName("Work"))
                        {
                            var stringBuilder = new StringBuilder();
                            var originalWork = item["Work"] == null ? DBNull.Value : item["Work"];
                            var originalUser = item["AssignedTo"].ToString();
                            item["AssignedTo"] = "-99;#";

                            #region Adding Summary Row

                            itemRow = dtItems.NewRow();
                            itemRow["Work"] = originalWork;
                            itemRow["WorkType"] = sListName;
                            itemRow["DataSource"] = 1;

                            foreach (DataRow column in dtColumns.Rows)
                            {
                                errColumnName = column["ColumnName"].ToString();
                                if (spList.Fields.ContainsField(column["internalname"].ToString()) &&
                                    spList.Fields.GetFieldByInternalName(column["internalname"].ToString()).Type.ToString().ToLower() == column["SharepointType"].ToString().ToLower())
                                {
                                    if (column["SharepointType"].ToString().ToLower() == "lookup" || column["SharepointType"].ToString().ToLower() == "user" || column["SharepointType"].ToString().ToLower() == "multichoice")
                                    {

                                        if (column["ColumnName"].ToString().ToLower().EndsWith("text"))
                                        {
                                            if (ItemHasValue(item, column["internalname"].ToString()))
                                            //if (item[column["internalname"].ToString()] != null)
                                            {
                                                itemRow[column["ColumnName"].ToString()] = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "text");
                                            }
                                            else
                                            {
                                                itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                            }
                                        }
                                        else if (column["ColumnName"].ToString().ToLower().EndsWith("id"))
                                        {
                                            if (ItemHasValue(item, column["internalname"].ToString()))
                                            //if (item[column["internalname"].ToString()] != null)
                                            {
                                                itemRow[column["ColumnName"].ToString()] = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "id");
                                            }
                                            else
                                            {
                                                itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!_arrayListDefaultColumns.Contains(column["ColumnName"].ToString().ToLower()))
                                        {
                                            field = item.Fields.GetFieldByInternalName(column["columnname"].ToString());
                                            if (ItemHasValue(item, field.InternalName))
                                            //if (item[field.InternalName] != null)
                                            {
                                                try
                                                {
                                                    if (field.Type != SPFieldType.Calculated)
                                                    {
                                                        itemRow[column["ColumnName"].ToString()] = item[field.InternalName];
                                                    }
                                                    else
                                                    {
                                                        itemRow[column["ColumnName"].ToString()] = _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                                }
                                            }
                                            else
                                            {
                                                itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool blnGuid;
                                    object obj;
                                    obj = GetDefaultColumnValue(column["ColumnName"].ToString().ToLower(), item, out blnGuid);
                                    if (blnGuid && obj != null)
                                    {
                                        Guid id = (Guid)obj;
                                        itemRow[column["ColumnName"].ToString()] = id;
                                    }
                                    else if (obj != null)
                                    {
                                        itemRow[column["ColumnName"].ToString()] = obj;
                                    }
                                }

                                //AddMetaInfoCols(listName, listItem, ref rcols, ref rvalues);
                            }
                            dtItems.Rows.Add(itemRow);

                            #endregion

                            double tempHours, hours;

                            if (double.TryParse(originalWork.ToString(), out tempHours))
                            {
                                hours = tempHours / totalAssignedToUsers;
                            }
                            else
                            {
                                hours = 0.0;
                            }

                            foreach (SPFieldUserValue spFieldUserValue in spFieldUserValueCollection)
                            {
                                itemRow = dtItems.NewRow();
                                item["Work"] = hours;
                                item["AssignedTo"] = spFieldUserValue;
                                string columnName = string.Empty;
                                string internalName = string.Empty;

                                itemRow["WorkType"] = sListName;
                                itemRow["DataSource"] = 1;

                                foreach (DataRow column in dtColumns.Rows)
                                {
                                    if (spList.Fields.ContainsField(column["internalname"].ToString()) &&
                                        spList.Fields.GetFieldByInternalName(column["internalname"].ToString()).Type.ToString().ToLower() == column["SharepointType"].ToString().ToLower())
                                    {
                                        if (column["SharepointType"].ToString().ToLower() == "lookup" || column["SharepointType"].ToString().ToLower() == "user" || column["SharepointType"].ToString().ToLower() == "multichoice")
                                        {
                                            if (column["ColumnName"].ToString().ToLower().EndsWith("text"))
                                            {
                                                if (ItemHasValue(item, column["internalname"].ToString()))
                                                //if (item[column["internalname"].ToString()] != null)
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "text");
                                                }
                                                else
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                                }
                                            }
                                            else if (column["ColumnName"].ToString().ToLower().EndsWith("id"))
                                            {
                                                if (ItemHasValue(item, column["internalname"].ToString()))
                                                //if (item[column["internalname"].ToString()] != null)
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = AddLookUpFieldValues(item[column["internalname"].ToString()].ToString(), "id");
                                                }
                                                else
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (!_arrayListDefaultColumns.Contains(column["ColumnName"].ToString().ToLower()))
                                            {
                                                field = item.Fields.GetFieldByInternalName(column["columnname"].ToString());
                                                if (ItemHasValue(item, field.InternalName))
                                                //if (item[field.InternalName] != null)
                                                {
                                                    try
                                                    {
                                                        if (field.Type != SPFieldType.Calculated)
                                                        {
                                                            itemRow[column["ColumnName"].ToString()] = item[field.InternalName];
                                                        }
                                                        else
                                                        {
                                                            itemRow[column["ColumnName"].ToString()] = _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                                    }
                                                }
                                                else
                                                {
                                                    itemRow[column["ColumnName"].ToString()] = DBNull.Value;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bool blnGuid;
                                        object obj;
                                        obj = GetDefaultColumnValue(column["ColumnName"].ToString().ToLower(), item, out blnGuid);
                                        if (blnGuid && obj != null)
                                        {
                                            Guid id = (Guid)obj;
                                            itemRow[column["ColumnName"].ToString()] = id;
                                        }
                                        else if (obj != null)
                                        {
                                            itemRow[column["ColumnName"].ToString()] = obj;
                                        }
                                    }

                                    //AddMetaInfoCols(listName, listItem, ref rcols, ref rvalues);
                                }
                                dtItems.Rows.Add(itemRow);
                            }

                            item["Work"] = originalWork;
                            item["AssignedTo"] = spFieldUserValueCollection;
                        }

                        if (ListReportsWork(sTableName))
                        {
                            _DAO.SaveWork(item);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //DataRow[] dr = dtResults.Select("ListName='" + sListName + "'");

                //if (dr[0]["ResultText"] == null)
                //{
                //    dr[0]["ResultText"] = ex.Message;
                //}
                //else
                //{
                //    dr[0]["ResultText"] = dr[0]["ResultText"] + ", Error:" + ex.Message.ToString();
                //}                

                //dtItems = null;
                //Guid tjb = Guid.NewGuid();                
                //_DAO.LogStatus(_DAO.GetListId(spList.Title).ToString(), spList.Title, spWeb.Name + " (" + spWeb.ServerRelativeUrl + ") - Processed with errors.", ex.Message + " -- Stack: " + ex.StackTrace, 2, 3, tjb.ToString());
                //_DAO.LogStatus(_DAO.GetListId(sListName).ToString(), sListName, "Error on Refresh.", ex.Message, 2, 3, timerjobguid.ToString());            
                error = true;
                errMsg = ex.Message + "[LOCATION INFO] - ItemTitle: " + errItemTitle + ", ItemId: " + errItemID + ", ColumnName: " + errColumnName + ".";

            }
            return dtItems;
        }

        private DataTable AddMetaInfoCols(DataTable dt)
        {
            DataTable result = dt;
            if (result != null)
            {
                string listId = dt.Rows[0]["RPTListId"].ToString();

                List<DataRow> dataSourceRows = (from DataRow r in dt.Rows
                                                where r["ColumnName"].ToString() == "DataSource"
                                                select r).ToList<DataRow>();

                if (dataSourceRows.Count == 0)
                {
                    result.Rows.Add(listId, "DataSource", "NVarChar", "8001", "Integer", "DataSource", "DataSource");
                }

                List<DataRow> worktypeRows = (from DataRow r in dt.Rows
                                              where r["ColumnName"].ToString() == "WorkType"
                                              select r).ToList<DataRow>();

                if (worktypeRows.Count == 0)
                {
                    result.Rows.Add(listId, "WorkType", "NVarChar", "256", "Text", "WorkType", "WorkType");
                }

                List<DataRow> commentersRows = (from DataRow r in dt.Rows
                                                where r["ColumnName"].ToString() == "Commenters"
                                                select r).ToList<DataRow>();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "Commenters", "NVarChar", "8001", "Text", "Commenters", "Commenters");
                }

                List<DataRow> commentersReadRows = (from DataRow r in dt.Rows
                                                    where r["ColumnName"].ToString() == "CommentersRead"
                                                    select r).ToList<DataRow>();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "CommentersRead", "NVarChar", "8001", "Text", "CommentersRead", "CommentersRead");
                }

                List<DataRow> commentersCountRows = (from DataRow r in dt.Rows
                                                     where r["ColumnName"].ToString() == "CommentCount"
                                                     select r).ToList<DataRow>();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "CommentCount", "NVarChar", "0", "Integer", "CommentCount", "CommentCount");
                }
            }

            return result;
        }

        public bool SnapshotLists(string listName)
        {
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@Listnames", listName);
            _DAO.AddParam("@Enabled", true);
            _DAO.Command = "spRPTLists";
            _DAO.CommandType = CommandType.StoredProcedure;
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public void InitializeStatusLog()
        {
            _DAO.InitializeStatusLog();
        }

        public bool LogStatus(Guid RPTListID, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType)
        {
            return _DAO.LogStatus(RPTListID.ToString(), sListName, sShortMsg, sLongMsg, iLevel, iType, string.Empty);
        }

        public bool LogStatus(string RPTListID, string sListName, string sShortMsg, string sLongMsg, int iLevel, int iType, string timerjobguid)
        {
            return _DAO.LogStatus(RPTListID, sListName, sShortMsg, sLongMsg, iLevel, iType, timerjobguid);
        }

        public DataTable GetStatusLog()
        {
            return _DAO.GetStatusLog();
        }

        private bool ItemHasValue(SPListItem item, string colName)
        {
            string test = string.Empty;
            try
            {
                test = item[colName].ToString();
            }
            catch { }

            return !string.IsNullOrEmpty(test);
        }
        // -- END

    }
}
