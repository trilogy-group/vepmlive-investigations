using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EPMLiveIntegration;

namespace EPMLiveCore.API.Integration
{
    public class SQL : EPMLiveIntegration.IIntegrator
    {
        private const string ColNameId = "ID";
        private const string ColNameSpid = "SPID";
        private const string PropKeyTable = "Table";
        private const string PropKeyIdColumn = "IDColumn";
        private const string PropKeyWhere = "Where";
        private const string PropKeyUserMapType = "UserMapType";
        private const string Apostrophe = "'";
        private const string DoubleApostrophe = "''";
        private const string PropKeyAvailableSyncOpts = "AvailableSynchOptions";

        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            Message = "";
            return true;
        }

        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            Message = "";
            return true;
        }


        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(Items, nameof(Items));

            const string deleteCommandTemplate = "DELETE FROM {0} WHERE {1}=@id";
            var tableName = WebProps.Properties[PropKeyTable];
            var idColumn = WebProps.Properties[PropKeyIdColumn];

            var table = new TransactionTable();

            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                foreach (DataRow dataRow in Items.Rows)
                {
                    try
                    {
                        using (var command = new SqlCommand(string.Format(deleteCommandTemplate, tableName, idColumn), connection))
                        {
                            command.Parameters.AddWithValue("@id", dataRow[ColNameId].ToString());
                            command.ExecuteNonQuery();
                        }

                        table.AddRow(dataRow[ColNameSpid].ToString(), dataRow[ColNameId].ToString(), TransactionType.DELETE);
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.ToString());
                        table.AddRow(dataRow[ColNameSpid].ToString(), dataRow[ColNameId].ToString(), TransactionType.FAILED);
                    }
                }
            }

            return table;
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(Items, nameof(Items));
            CheckArgumentForNull(Log, nameof(Log));

            const string queryTemplate = "SELECT * FROM {0} WHERE {1}=@id";
            var tableName = WebProps.Properties[PropKeyTable];
            var idColumn = WebProps.Properties[PropKeyIdColumn];
            var trans = new TransactionTable();

            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                foreach (DataRow drItem in Items.Rows)
                {
                    var currentId = drItem[ColNameId].ToString();
                    var spId = drItem[ColNameSpid].ToString();

                    try
                    {
                        if (currentId == string.Empty)
                        {
                            trans.AddRow(spId, InsertRow(WebProps, drItem, Log, connection), TransactionType.INSERT);
                        }
                        else
                        {
                            var dataSet = new DataSet();
                            using (var command = new SqlCommand(string.Format(queryTemplate, tableName, idColumn), connection))
                            {
                                command.Parameters.AddWithValue("@id", currentId);

                                using (var dataAdapter = new SqlDataAdapter(command))
                                {
                                    dataAdapter.Fill(dataSet);
                                }
                            }

                            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                            {
                                trans.AddRow(spId, UpdateRow(WebProps, drItem, Log, connection), TransactionType.UPDATE);
                            }
                            else
                            {
                                trans.AddRow(spId, InsertRow(WebProps, drItem, Log, connection), TransactionType.INSERT);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.ToString());
                        Log.LogMessage(ex.Message, IntegrationLogType.Error);
                        trans.AddRow(spId, currentId, TransactionType.FAILED);
                    }
                }
            }

            return trans;
        }

        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(ListName, nameof(ListName));

            const string queryTemplate = "select name from sys.columns where object_id = object_id('{0}')";
            var tableName = WebProps.Properties[PropKeyTable].ToString().Replace(Apostrophe, DoubleApostrophe);

            var columnsList = new List<ColumnProperty>();


            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                using (var command = new SqlCommand(string.Format(queryTemplate, tableName), connection))
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var colProperty = new ColumnProperty();
                        colProperty.ColumnName = dataReader.GetString(0);
                        colProperty.DiplayName = dataReader.GetString(0);
                        colProperty.DefaultListColumn = GetDefaultColumn(ListName, dataReader.GetString(0));
                        columnsList.Add(colProperty);
                    }
                }
            }

            return columnsList;
        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog Log, DataTable Items, DateTime LastSynch)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(Items, nameof(Items));

            var dataSet = new DataSet();

            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                var colsBuilder = new StringBuilder(WebProps.Properties[PropKeyIdColumn].ToString());

                var where = WebProps.Properties.ContainsKey(PropKeyWhere)
                    ? WebProps.Properties[PropKeyWhere].ToString()
                    : string.Empty;

                foreach (DataColumn dataColumn in Items.Columns)
                {
                    if (dataColumn.ColumnName != ColNameId)
                    {
                        colsBuilder.Append($",{dataColumn.ColumnName}");
                    }
                }

                var query = $"SELECT {colsBuilder} FROM {WebProps.Properties[PropKeyTable]}";
                if (where != string.Empty)
                {
                    query = $"{query} Where {where.Replace(Apostrophe, DoubleApostrophe)}";
                }

                using (var command = new SqlCommand(query, connection))
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataSet);
                }
            }

            if (dataSet.Tables.Count == 0)
            {
                throw new InvalidOperationException("No tables returned from query");
            }

            var idColumn = WebProps.Properties[PropKeyIdColumn].ToString();
            dataSet.Tables[0].Columns[idColumn].ColumnName = ColNameId;

            return dataSet.Tables[0];
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog Log, string ItemID, DataTable Items)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(ItemID, nameof(ItemID));
            CheckArgumentForNull(Items, nameof(Items));

            var tableName = WebProps.Properties["Table"];
            var idColumn = WebProps.Properties["IDColumn"];

            const string queryTemplate = "SELECT * FROM {0} WHERE {1} = '{2}'";

            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                var dataSet = new DataSet();

                using (var command = new SqlCommand(string.Format(queryTemplate, tableName, idColumn, ItemID), connection))
                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataSet);
                }

                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    var dataRow = dataSet.Tables[0].Rows[0];

                    var valuesArray = new ArrayList();
                    valuesArray.Add(ItemID);

                    foreach (DataColumn dataColumn in Items.Columns)
                    {
                        if (dataColumn.ColumnName != ColNameId)
                        {
                            if (dataRow[dataColumn.ColumnName] != null)
                            {
                                valuesArray.Add(dataRow[dataColumn.ColumnName].ToString());
                            }
                            else
                            {
                                valuesArray.Add(string.Empty);
                            }
                        }
                    }

                    Items.Rows.Add(valuesArray.OfType<string>().ToArray());
                }
            }

            return Items;
        }

        public Dictionary<String, String> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            CheckArgumentForNull(WebProps, nameof(WebProps));
            CheckArgumentForNull(Property, nameof(Property));

            var properties = new Dictionary<string, string>();

            using (var connection = GetConnection(WebProps.Properties))
            {
                connection.Open();

                switch (Property)
                {
                    case PropKeyTable:
                        using (var command = new SqlCommand("select name from sys.tables", connection))
                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                properties.Add(dataReader.GetString(0), dataReader.GetString(0));
                            }
                        }
                        break;
                    case PropKeyUserMapType:
                        properties.Add("Email", "Email Address");
                        break;
                    case PropKeyAvailableSyncOpts:
                        properties.Add("LI", "LI");
                        properties.Add("TI", "TI");
                        properties.Add("TO", "TO");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Property), "Unexpected value from Property argument");
                }
            }

            return properties;
        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                SqlConnection cn = GetConnection(WebProps.Properties);
                cn.Open();
                cn.Close();
                return true;
            }
            catch(Exception ex){
                Message = "Error: " + ex.Message;
                return false;
            }
        }




        private string GetDefaultColumn(string list, string column)
        {
            if(list == "Project Center")
            {
            }
            else if(list == "Issues")
            {
                switch(column)
                {
                    case "Name":
                        return "Title";
                    case "Start":
                        return "StartDate";
                    default:
                        return column;
                }
            }

            return "";
        }

        private SqlConnection GetConnection(Hashtable Properties)
        {
            return new SqlConnection("Server=" + Properties["Server"] + ";Database=" + Properties["Database"] + ";Trusted_Connection=True");
        }


        private string InsertRow(WebProperties WebProps, DataRow Item, IntegrationLog Log, SqlConnection cn)
        {
            

            string paramnames = "";
            string paramvalues = "";

            ArrayList arrparams = new ArrayList();
   
            foreach(DataColumn dc in Item.Table.Columns)
            {
                if(dc.ColumnName != "ID" && dc.ColumnName != "SPID")
                {
                    paramnames += dc.ColumnName + ",";
                    paramvalues += "@" + dc.ColumnName + ",";
                    if(Item[dc.ColumnName].ToString() == "")
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, DBNull.Value));
                    else
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, Item[dc.ColumnName].ToString()));
                }
            }

            try
            {
                if(WebProps.Properties["SPColumn"].ToString() != "")
                {
                    paramnames += WebProps.Properties["SPColumn"] + ",";
                    paramvalues += "@" + WebProps.Properties["SPColumn"] + ",";
                    arrparams.Add(new SqlParameter("@" + WebProps.Properties["SPColumn"], Item["SPID"].ToString()));
                }
            }
            catch { }

            string sql = "INSERT INTO " + WebProps.Properties["Table"] + "(" + paramnames.Trim(',') + ") OUTPUT Inserted." + WebProps.Properties["IDColumn"] + " VALUES (" + paramvalues.Trim(',') + ")";

            object result;
            using (var command = new SqlCommand(sql, cn))
            {
                command.Parameters.AddRange(arrparams.ToArray(typeof(SqlParameter)));
                result = command.ExecuteScalar();
            }

            return result.ToString();
        }

        private string UpdateRow(WebProperties WebProps, DataRow Item, IntegrationLog Log, SqlConnection cn)
        {
            string paramnames = "";

            ArrayList arrparams = new ArrayList();

            foreach(DataColumn dc in Item.Table.Columns)
            {
                if(dc.ColumnName != "ID" && dc.ColumnName != "SPID")
                {
                    paramnames += dc.ColumnName + " = @" + dc.ColumnName + ",";
                    if(Item[dc.ColumnName].ToString() == "")
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, DBNull.Value));
                    else
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, Item[dc.ColumnName].ToString()));

                }
            }

            try
            {
                if(WebProps.Properties["SPColumn"].ToString() != "")
                {
                    paramnames += WebProps.Properties["SPColumn"] + " = @" + WebProps.Properties["SPColumn"] + ",";
                    arrparams.Add(new SqlParameter("@" + WebProps.Properties["SPColumn"], Item["SPID"].ToString()));
                }
            }
            catch { }

            string sql = "UPDATE " + WebProps.Properties["Table"] + " Set " + paramnames.Trim(',') + " WHERE " + WebProps.Properties["IDColumn"] + " =@id";

            using (var command = new SqlCommand(sql, cn))
            {
                command.Parameters.AddRange(arrparams.ToArray(typeof(SqlParameter)));
                command.Parameters.AddWithValue("@id", Item[ColNameId].ToString());
                command.ExecuteScalar();
            }

            return Item[ColNameId].ToString();
        }

        private void CheckArgumentForNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
