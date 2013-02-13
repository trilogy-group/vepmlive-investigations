using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportingProxy
{
    internal class QueryExecutor : ReportingProxyBase
    {
        #region Constructors (1) 

        internal QueryExecutor(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (8) 

        // Private Methods (2) 

        /// <summary>
        ///     Executes the non query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="connectionType">Type of the connection.</param>
        /// <returns></returns>
        private void ExecuteNonQuery(string query, IEnumerable<KeyValuePair<string, object>> parameters,
                                     string connectionType)
        {
            object epmDataClass = GetEpmDataClass();

            SetProperty("Command", query, epmDataClass);
            SetProperty("CommandType", CommandType.Text, epmDataClass);

            KeyValuePair<string, object>[] valuePairs = parameters as KeyValuePair<string, object>[] ??
                                                        parameters.ToArray();
            if (valuePairs.Any())
            {
                var sqlParameters = (List<SqlParameter>) GetProperty("Params", epmDataClass);
                sqlParameters.AddRange(valuePairs.Select(pair => new SqlParameter(pair.Key, pair.Value)));

                SetProperty("Params", sqlParameters, epmDataClass);
            }

            MethodInfo executeNonQuery = GetMethod("ExecuteNonQuery", new[] {typeof (SqlConnection)}, epmDataClass);
            executeNonQuery.Invoke(epmDataClass, new[] {GetProperty(connectionType, epmDataClass)});

            GetMethod("Dispose", new Type[] {}, epmDataClass).Invoke(epmDataClass, null);
        }

        /// <summary>
        ///     Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="connectionType">Type of the connection.</param>
        /// <returns></returns>
        private DataTable ExecuteQuery(string query, IEnumerable<KeyValuePair<string, object>> parameters,
                                       CommandType commandType, string connectionType)
        {
            object epmDataClass = GetEpmDataClass();

            SetProperty("Command", query, epmDataClass);
            SetProperty("CommandType", commandType, epmDataClass);

            KeyValuePair<string, object>[] valuePairs = parameters as KeyValuePair<string, object>[] ??
                                                        parameters.ToArray();
            if (valuePairs.Any())
            {
                var sqlParameters = (List<SqlParameter>) GetProperty("Params", epmDataClass);
                sqlParameters.AddRange(valuePairs.Select(pair => new SqlParameter(pair.Key, pair.Value)));

                SetProperty("Params", sqlParameters, epmDataClass);
            }

            MethodInfo getTable = GetMethod("GetTable", new[] {typeof (SqlConnection)}, epmDataClass);
            var dataTable = (DataTable) getTable.Invoke(epmDataClass, new[] {GetProperty(connectionType, epmDataClass)});

            GetMethod("Dispose", new Type[] {}, epmDataClass).Invoke(epmDataClass, null);

            return dataTable;
        }

        // Internal Methods (6) 

        /// <summary>
        ///     Executes the epm live non query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal void ExecuteEpmLiveNonQuery(string query, IDictionary<string, object> parameters)
        {
            ExecuteNonQuery(query, parameters, "GetEPMLiveConnection");
        }

        /// <summary>
        ///     Executes the epm live query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal DataTable ExecuteEpmLiveQuery(string query, IDictionary<string, object> parameters)
        {
            return ExecuteQuery(query, parameters, CommandType.Text, "GetEPMLiveConnection");
        }

        /// <summary>
        ///     Executes the epm live stored proc.
        /// </summary>
        /// <param name="storedProcName">Name of the stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal DataTable ExecuteEpmLiveStoredProc(string storedProcName, IDictionary<string, object> parameters)
        {
            return ExecuteQuery(storedProcName, parameters, CommandType.StoredProcedure, "GetEPMLiveConnection");
        }

        /// <summary>
        ///     Executes the reporting DB non query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        internal void ExecuteReportingDBNonQuery(string query, IDictionary<string, object> parameters)
        {
            ExecuteNonQuery(query, parameters, "GetClientReportingConnection");
        }

        /// <summary>
        ///     Executes the reporting DB query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal DataTable ExecuteReportingDBQuery(string query, IDictionary<string, object> parameters)
        {
            return ExecuteQuery(query, parameters, CommandType.Text, "GetClientReportingConnection");
        }

        /// <summary>
        ///     Executes the reporting DB stored proc.
        /// </summary>
        /// <param name="storedProcName">Name of the stored proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        internal DataTable ExecuteReportingDBStoredProc(string storedProcName, IDictionary<string, object> parameters)
        {
            return ExecuteQuery(storedProcName, parameters, CommandType.StoredProcedure, "GetClientReportingConnection");
        }

        #endregion Methods 
    }
}