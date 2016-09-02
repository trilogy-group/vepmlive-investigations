using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using EPMLiveCore;
using EPMLiveReportsAdmin.API;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class MyWorkReportData : ReportData, IDisposable
    {
        #region Constructors (3)

        public MyWorkReportData(Guid siteId, string name, string server, bool useSAccount, string username,
            string password)
            : base(siteId, name, server, useSAccount, username, password) { }

        public MyWorkReportData(Guid siteId, Guid webAppId) : base(siteId, webAppId) { }

        public MyWorkReportData(Guid siteId) : base(siteId) { }

        #endregion Constructors

        #region Methods (12)

        // Public Methods (5) 

        /// <summary>
        ///     Executes the epm live SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public DataTable ExecuteEpmLiveSql(string sql)
        {
            var dataTable = new DataTable();

            _cmdWithParams = new SqlCommand(sql, _DAO.GetEPMLiveConnection);
            dataTable.Load(_cmdWithParams.ExecuteReader());

            return dataTable;
        }

        /// <summary>
        ///     Executes the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public DataTable ExecuteSql(string sql)
        {
            var dataTable = new DataTable();

            _cmdWithParams = new SqlCommand(sql, _DAO.GetClientReportingConnection);
            dataTable.Load(_cmdWithParams.ExecuteReader());

            return dataTable;
        }

        /// <summary>
        ///     Gets the data.
        /// </summary>
        /// <param name="filterValues">The filter values.</param>
        /// <param name="reportingScope">The reporting scope.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public DataTable GetData(Dictionary<string, IEnumerable<object>> filterValues, ReportingScope reportingScope,
            SPWeb spWeb)
        {
            string sql = BuildSelectSql(filterValues, reportingScope, spWeb);

            _cmdWithParams = new SqlCommand(sql, _DAO.GetClientReportingConnection);

            var dataTable = new DataTable();
            dataTable.Load(_cmdWithParams.ExecuteReader());

            return dataTable;
        }

        /// <summary>
        ///     Gets the fields.
        /// </summary>
        /// <returns></returns>
        public List<string> GetFields()
        {
            var fields = new List<string>();

            string sql = string.Format(@"SELECT DISTINCT InternalName FROM RPTColumn WHERE RPTListId = N'{0}'",
                _DAO.GetListId("My Work"));

            _cmdWithParams = new SqlCommand(sql, _DAO.GetClientReportingConnection);

            SqlDataReader sqlDataReader = _cmdWithParams.ExecuteReader();

            while (sqlDataReader.Read())
            {
                fields.Add(sqlDataReader.GetString(sqlDataReader.GetOrdinal("InternalName")));
            }

            return fields;
        }

        /// <summary>
        ///     Inserts the SQL.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="listName">Name of the list.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="spListItem">The sp list item.</param>
        /// <param name="defaultColumns">The default columns.</param>
        /// <returns></returns>
        public string InsertSQL(string tableName, string listName, DataTable columns, SPListItem spListItem,
            ArrayList defaultColumns, ArrayList mandatoryHiddenFlds)
        {
            string sql = string.Empty;
            _cmdWithParams = null;

            SPFieldCollection spFieldCollection = spListItem.ParentList.Fields;

            if (spFieldCollection.ContainsFieldWithInternalName("AssignedTo"))
            {
                object fldAssignedTo = null;
                string valAssignedTo = null;

                try
                {
                    fldAssignedTo = spListItem["AssignedTo"];
                }
                catch { }

                if (fldAssignedTo != null)
                {
                    valAssignedTo = fldAssignedTo.ToString();
                }

                int totalAssignedToUsers = 0;
                SPFieldUserValueCollection spFieldUserValueCollection = null;
                if (!string.IsNullOrEmpty(valAssignedTo))
                {
                    spFieldUserValueCollection = new SPFieldUserValueCollection(spListItem.Web, valAssignedTo);
                    totalAssignedToUsers = spFieldUserValueCollection.Count;
                }

                object originalWork = spListItem["Work"];

                var stringBuilder = new StringBuilder();

                string allCols = AddColums(columns).Replace("'", string.Empty);

                var allUsers = new List<string>();

                try
                {
                    allUsers.AddRange(spFieldUserValueCollection.Select(userValue => userValue.User.Name));
                }
                catch { }
                                
                SPListItem item = spListItem;
                //item["AssignedTo"] = string.Format("-99;#{0}", string.Join(", ", allUsers.Distinct()));
                item["AssignedTo"] = "-99;#";

                string allValues =
                    AddColumnValues(item, columns, defaultColumns, mandatoryHiddenFlds, "insert", string.Join(", ", allUsers.Distinct()))
                        .Replace("'", string.Empty);

                AddMetaInfoCols(listName, item, ref allCols, ref allValues);

                stringBuilder.AppendLine(string.Format(@"INSERT INTO {0} {1} {2}", tableName, allCols, allValues));
                
                spListItem["AssignedTo"] = spFieldUserValueCollection;

                if (totalAssignedToUsers > 0 && spFieldCollection.ContainsFieldWithInternalName("Work"))
                {
                    object hours = null;
                    try
                    {
                        hours = double.Parse(originalWork.ToString()) / totalAssignedToUsers;
                    }
                    catch { }

                    foreach (SPFieldUserValue spFieldUserValue in spFieldUserValueCollection)
                    {
                        string rcols = AddColums(columns).Replace("'", string.Empty);

                        SPListItem listItem = spListItem;
                        listItem["Work"] = hours;
                        listItem["AssignedTo"] = spFieldUserValue;

                        string rvalues = AddColumnValues(listItem, columns, defaultColumns, mandatoryHiddenFlds,
                            "insert", string.Join(", ", allUsers.Distinct()))
                            .Replace("'", string.Empty);

                        AddMetaInfoCols(listName, listItem, ref rcols, ref rvalues);

                        stringBuilder.AppendLine(string.Format(@"INSERT INTO {0} {1} {2}", tableName, rcols, rvalues));
                    }

                    spListItem["Work"] = originalWork;
                    spListItem["AssignedTo"] = spFieldUserValueCollection;

                    sql = stringBuilder.ToString();
                }
                else
                {
                    sql = stringBuilder.ToString();
                }
            }

            if (_params.Count > 2000)
            {
                var stringBuilder = new StringBuilder();

                string[] stmts = sql.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                int totalParams = 0;

                foreach (string stmt in stmts)
                {
                    stringBuilder.AppendLine(stmt);
                    stringBuilder.AppendLine("!-x-x-x-x-x-!");
                }

                return stringBuilder.ToString();
            }

            return sql;
        }

        // Protected Methods (4) 

        /// <summary>
        ///     Adds the column values.
        /// </summary>
        /// <param name="spListItem">The sp list item.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="defaultColumns">The default columns.</param>
        /// <param name="operation">The operation.</param>
        /// <returns></returns>
        protected override string AddColumnValues(SPListItem spListItem, DataTable columns, ArrayList defaultColumns,
            ArrayList mandatoryHiddenFlds,
            string operation, string sAssignedToText)
        {
            string colValues = string.Empty;
            string columnName = string.Empty;
            string internalName = string.Empty;
            SqlParameter param = null;
            string floatParams = string.Empty;

            if (_cmdWithParams == null) _cmdWithParams = new SqlCommand();

            _params = _cmdWithParams.Parameters;

            string identifier = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

            if (operation == "insert")
            {
                colValues = " VALUES(";
            }

            try
            {
                foreach (DataRow row in columns.Rows)
                {
                    columnName = row["ColumnName"].ToString().Replace("'", string.Empty);
                    internalName = row["InternalName"].ToString().Replace("'", string.Empty);

                    if (defaultColumns.Contains(columnName.ToLower()))
                    {
                        param = PopulateDefaultColumnValue(columnName.ToLower().Replace("'", string.Empty), spListItem);
                    }
                    else if (mandatoryHiddenFlds.Contains(columnName.ToLower()))
                    {
                        param = PopulateMandatoryHiddenFldsColumnValue(columnName.ToLower().Replace("'", string.Empty),
                            spListItem);
                    }
                    else
                    {
                        if (spListItem.Fields.ContainsField(internalName))
                        {
                            SPField field;
                            if (!IsLookUpField(spListItem.ParentList.Title, columnName))
                            {
                                field = spListItem.Fields.GetFieldByInternalName(internalName);

                                param = GetParam(field, columnName);

                                param.ParameterName = string.Format("@{0}_{1}",
                                    field.InternalName.Replace("'", string.Empty),
                                    identifier);

                                if (field.Type != SPFieldType.Calculated)
                                {
                                    param.Value = field.Type != SPFieldType.DateTime
                                        ? (spListItem[field.InternalName] != null
                                            ? (object)spListItem[field.InternalName].ToString()
                                            : DBNull.Value)
                                        : (spListItem[field.InternalName] ?? DBNull.Value);
                                }
                                else
                                {
                                    try
                                    {
                                        param.Value = _DAO.GetCalculatedFieldValue(spListItem, (SPFieldCalculated)field);
                                    }
                                    catch (Exception)
                                    {
                                        param.Value = DBNull.Value;
                                    }
                                }
                            }
                            else
                            {
                                field = spListItem.Fields.GetFieldByInternalName(internalName);

                                param = GetParam(field, columnName);

                                param.ParameterName = string.Format("@{0}_{1}",
                                    columnName.Replace("'", string.Empty),
                                    identifier);

                                if (columnName.ToLower() == "assignedtotext")
                                {
                                    param.Value = sAssignedToText;
                                }
                                else if (columnName.ToLower().EndsWith("text") && spListItem[field.InternalName] != null)
                                {
                                    param.Value = AddLookUpFieldValues(spListItem[field.InternalName].ToString(), "text");
                                }
                                else if (spListItem[field.InternalName] != null)
                                {
                                    param.Value = AddLookUpFieldValues(spListItem[field.InternalName].ToString(), "id");
                                }
                                else
                                {
                                    param.Value = DBNull.Value;
                                }
                            }
                        }
                        else
                        {
                            param = new SqlParameter
                            {
                                ParameterName = string.Format("@{0}_{1}",
                                    columnName.Replace("'", string.Empty),
                                    identifier),
                                Value = DBNull.Value
                            };
                        }
                    }

                    if (columnName.ToLower().Equals("worktype")) param.Value = spListItem.ParentList.Title;
                    else if (columnName.ToLower().Equals("datasource")) param.Value = "1";

                    _params.Add(param);

                    if (param.SqlDbType == SqlDbType.Float)
                    {
                        floatParams = floatParams.Replace("'", string.Empty) +
                                      param.ParameterName.Replace("'", string.Empty) + "=" +
                                      param.Value.ToString().Replace("'", string.Empty) + "|";
                    }

                    switch (operation)
                    {
                        case "insert":
                            colValues = colValues.Replace("'", string.Empty) +
                                        param.ParameterName.Replace("'", string.Empty) + ",";
                            break;

                        case "update":
                            colValues = colValues + "[" + columnName.Replace("'", string.Empty) + "] = " +
                                        param.ParameterName.Replace("'", string.Empty) + ", ";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                param.Value = DBNull.Value;
                SPSecurity.RunWithElevatedPrivileges(() => LogError(internalName, ex, columnName));
            }

            colValues = colValues.Remove(colValues.LastIndexOf(",", StringComparison.Ordinal))
                .Replace("'", string.Empty);
            switch (operation)
            {
                case "insert":
                    colValues = colValues + ") ";
                    break;
            }

            return colValues;
        }

        /// <summary>
        ///     Builds the select SQL.
        /// </summary>
        /// <param name="filterValues">The filter values.</param>
        /// <param name="reportingScope">The reporting scope.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        protected string BuildSelectSql(Dictionary<string, IEnumerable<object>> filterValues,
            ReportingScope reportingScope, SPWeb spWeb)
        {
            var filters = new List<string>();

            switch (reportingScope)
            {
                case ReportingScope.Site:
                    filters.Add(string.Format("[SiteId] = N'{0}'", spWeb.Site.ID));
                    break;
                case ReportingScope.Web:
                    filters.Add(string.Format("[WebId] = N'{0}'", spWeb.ID));
                    break;
                case ReportingScope.Recursive:
                    filters.Add(
                        string.Format(
                            "([WebUrl] LIKE N'{0}%' OR [WebUrl] = N'{0}' OR [WebUrl] = N'/' AND [SiteId] = N'{1}')",
                            spWeb.SafeServerRelativeUrl(), spWeb.Site.ID));
                    break;
            }

            foreach (var keyValuePair in filterValues)
            {
                string columnName = keyValuePair.Key.Replace("'", string.Empty);

                if (columnName.ToLower().Equals("startdate") || columnName.ToLower().Equals("duedate")) continue;

                if (!keyValuePair.Value.Any())
                {
                    throw new Exception(string.Format("No filter values specified for {0}", columnName));
                }

                List<string> values;

                string columnType = GetColumnType(columnName).ToLower();

                if (columnType.Contains("int") || columnType.Contains("float") || columnType.Contains("decimal"))
                {
                    values = keyValuePair.Value.Distinct().Select(v => v.ToString().Replace("'", string.Empty)).ToList();
                }
                else
                {
                    values =
                        keyValuePair.Value.Distinct().Select(
                            v => string.Format("N'{0}'", v.ToString().Replace("'", string.Empty))).ToList();
                }

                if (values.Count == 0)
                {
                    throw new ApplicationException(string.Format("No valid filter values specified for the column: {0}",
                        columnName));
                }

                filters.Add(string.Format("[{0}] IN ({1})", columnName, string.Join(",", values.ToArray())));
            }

            var startDate = new DateTime(1800, 1, 1);
            var dueDate = new DateTime(9999, 12, 31);

            if (filterValues.ContainsKey("StartDate"))
            {
                object sDate = filterValues["StartDate"].FirstOrDefault();
                if (sDate != null)
                {
                    string value = sDate.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        DateTime date;
                        if (DateTime.TryParse(value, out date)) startDate = date;
                    }
                }
            }

            if (filterValues.ContainsKey("DueDate"))
            {
                object dDate = filterValues["DueDate"].FirstOrDefault();
                if (dDate != null)
                {
                    string value = dDate.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        DateTime date;
                        if (DateTime.TryParse(value, out date)) dueDate = date;
                    }
                }
            }

            startDate = startDate.Date;
            dueDate = dueDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            filters.Add(
                string.Format("([StartDate] <= '{0:yyyy-MM-dd HH:mm:ss}' AND [DueDate] >= '{1:yyyy-MM-dd HH:mm:ss}')",
                    dueDate, startDate));

            return string.Format(@"SELECT DISTINCT * FROM [LSTMyWork] WHERE {0}",
                string.Join(" AND ", filters.ToArray()));
        }

        /// <summary>
        ///     Determines whether [is look up field] [the specified list name].
        /// </summary>
        /// <param name="listName">Name of the list.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>
        ///     <c>true</c> if [is look up field] [the specified list name]; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsLookUpField(string listName, string columnName)
        {
            const string sql =
                "SELECT dbo.RPTColumn.SharePointType, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = @listName) AND (ColumnName=@colName)";

            _DAO.AddParam("@listName", "My Work");
            _DAO.AddParam("@colName", columnName);

            _DAO.Command = sql;

            object objType = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);

            return objType.ToString().ToLower().Equals("lookup") || objType.ToString().ToLower().Equals("user") ||
                   objType.ToString().ToLower().Equals("flookup");
        }

        /// <summary>
        ///     Populates the default column value.
        /// </summary>
        /// <param name="sColumn">The s column.</param>
        /// <param name="li">The li.</param>
        /// <returns></returns>
        protected override SqlParameter PopulateDefaultColumnValue(string sColumn, SPListItem li)
        {
            string identifier = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

            var param = new SqlParameter();
            switch (sColumn)
            {
                case "siteid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@siteid_" + identifier;
                    param.Value = li.ParentList.ParentWeb.Site.ID;
                    break;

                case "webid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@webid_" + identifier;
                    param.Value = li.ParentList.ParentWeb.ID;
                    break;

                case "listid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.UniqueIdentifier;
                    param.ParameterName = "@rptlistid_" + identifier;
                    param.Value = li.ParentList.ID;
                    break;

                case "itemid":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@itemid_" + identifier;
                    param.Value = li.ID;
                    break;

                case "weburl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 256;
                    param.ParameterName = "@weburl_" + identifier;
                    param.Value = li.ParentList.ParentWeb.ServerRelativeUrl;
                    break;
            }

            return param;
        }

        protected override SqlParameter PopulateMandatoryHiddenFldsColumnValue(string sColumn, SPListItem li)
        {
            string identifier = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            var param = new SqlParameter();
            string val = string.Empty;
            switch (sColumn)
            {
                case "commenters":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commenters_" + identifier;
                    try
                    {
                        val = li["Commenters"].ToString();
                        param.Value = val;
                    }
                    catch
                    {
                        param.Value = DBNull.Value;
                    }
                    break;

                case "commentcount":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Int;
                    param.ParameterName = "@commentcount_" + identifier;
                    try
                    {
                        val = li["CommentCount"].ToString();
                        param.Value = Convert.ToInt32(val);
                    }
                    catch
                    {
                        param.Value = DBNull.Value;
                    }
                    break;

                case "commentersread":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@commentersread_" + identifier;
                    try
                    {
                        val = li["CommentersRead"].ToString();
                        param.Value = val;
                    }
                    catch
                    {
                        param.Value = DBNull.Value;
                    }
                    break;

                case "workspaceurl":
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 8001;
                    param.ParameterName = "@workspaceurl_" + identifier;
                    try
                    {
                        val = li["WorkspaceUrl"].ToString();
                        param.Value = val;
                    }
                    catch
                    {
                        param.Value = DBNull.Value;
                    }
                    break;
            }
            return param;
        }

        // Private Methods (3) 

        /// <summary>
        ///     Adds the meta info cols.
        /// </summary>
        /// <param name="listName">Name of the list.</param>
        /// <param name="spListItem">The sp list item.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="values">The values.</param>
        private void AddMetaInfoCols(string listName, SPListItem spListItem, ref string cols, ref string values)
        {
            string identifier = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

            //cols = cols.Replace(")", ",[Commenters],[CommentersRead],[CommentCount],[WorkType],[DataSource])");
            //values = values.Replace(")",
            //                        string.Format(
            //                            ",@Commenters_{0},@CommentersRead_{0},@CommentCount_{0},@WorkType_{0},@DataSource_{0})",
            //                            identifier));

            cols = cols.Replace(")", ",[WorkType],[DataSource])");
            values = values.Replace(")",
                string.Format(
                    ",@WorkType_{0},@DataSource_{0})",
                    identifier));

            if (_cmdWithParams == null) _cmdWithParams = new SqlCommand();

            //foreach (string col in new[] {"Commenters", "CommentersRead", "CommentCount"})
            //{
            //    object value = DBNull.Value;

            //    if (spListItem.Fields.ContainsFieldWithInternalName(col) && spListItem[col] != null)
            //        value = spListItem[col].ToString();

            //    _cmdWithParams.Parameters.Add(new SqlParameter
            //                                      {
            //                                          ParameterName = string.Format("@{0}_{1}", col, identifier),
            //                                          Value = value
            //                                      });
            //}

            _cmdWithParams.Parameters.Add(new SqlParameter
            {
                ParameterName = string.Format("@WorkType_{0}", identifier),
                Value = listName
            });

            _cmdWithParams.Parameters.Add(new SqlParameter
            {
                ParameterName = string.Format("@DataSource_{0}", identifier),
                Value = 1
            });
        }

        /// <summary>
        ///     Gets the type of the column.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        private string GetColumnType(string columnName)
        {
            string sql =
                string.Format(
                    @"SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE (TABLE_NAME = N'LSTMyWork') AND (COLUMN_NAME = N'{0}')",
                    columnName);

            _cmdWithParams = new SqlCommand(sql, _DAO.GetClientReportingConnection);
            object columnType = _cmdWithParams.ExecuteScalar();

            if (columnType == null || columnType == DBNull.Value)
                throw new Exception(string.Format("Cannot find column: {0}", columnName));

            return (string)columnType;
        }

        /// <summary>
        ///     Logs the error.
        /// </summary>
        /// <param name="internalName">Name of the internal.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="columnName">Name of the column.</param>
        private void LogError(string internalName, Exception ex, string columnName)
        {
            if (!EventLog.SourceExists("EPMLive My Work Reporting GetColumnValue"))
            {
                EventLog.CreateEventSource("EPMLive My Work Reporting GetColumnValue", "EPM Live");
            }

            var errorLog = new EventLog("EPM Live", ".", "EPMLive My Work Reporting GetColumnValue") { MaximumKilobytes = 32768 };

            errorLog.WriteEntry(
                "Name: " + _siteName + " Url: " + _siteUrl + " ID: " + _siteId + " : " + ex.Message +
                " ColumnName: " + columnName + " InternalName: " + internalName, EventLogEntryType.Error, 9000);
        }

        #endregion Methods
    }
}