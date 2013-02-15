using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PfEReporting
{
    class PfE_ReportingDB
    {
        public string sErrors = string.Empty;

        // get from app.config file
        //private string _connPE = ConfigurationManager.AppSettings["conn_SourceDB"];  // source
        //private string _connPT = ConfigurationManager.AppSettings["conn_TargetDB"];  // target
        private string _connPE = "";  // source
        private string _connPT = "";  // target

        // sql objects
        private const string CONST_SP_TABLE_LIST = "EPG_SP_RPT_DB_TABLES";
        // new joint tables
        private const string CONST_TBL_RESOURCES = "EPG_RPT_Resources";
        private const string CONST_TBL_PROJECTS = "EPG_RPT_Projects";
        // new table to handle multiple PfE databases (basepaths) to a single Reporting database
        private const string CONST_TBL_TABLES = "EPG_RPT_TABLES";
        // temp tables
        private const string CONST_TBL_TMP_PROJECTS = "EPG_RPT_ProjectsTMP";
        private const string CONST_TBL_TMP_PROJECTS_CUST = "EPG_RPT_ProjectsCustomTMP";
        private const string CONST_TBL_TMP_RESOURCES = "EPG_RPT_ResourcesTMP";
        private const string CONST_TBL_TMP_RESOURCES_CUST = "EPG_RPT_ResourcesCustomTMP";
        
        private LMR_SQLHelper data_PE;
        private LMR_SQLHelper data_PT;

        public DataTable ReportingDB_Build(string _connPE, string _connPT, string _basepathPE)
        {
            this._connPE = _connPE;
            this._connPT = _connPT;
            string sErrSrc = "ReportingDB_Build()";
            string sErrLoc = "Start";
            string sErrMsg = string.Empty;

            DataTable dtStatus = null;

            try
            {
                sErrLoc = "Initialize data layer";
                string sQuery = string.Empty;
                this.data_PE = new LMR_SQLHelper(this._connPE);
                this.data_PT = new LMR_SQLHelper(this._connPT);

                // *** status table   
                sErrLoc = "create status table";
                dtStatus = new DataTable();
                dtStatus.Columns.Add("TableName", typeof(string));
                dtStatus.Columns.Add("Status", typeof(string));

                sErrLoc = "get table suffix";
                string sTableSuffix = ReportingDB_GetTableSuffix(_basepathPE, CONST_TBL_TABLES);

                sErrLoc = "get tables to create";
                DataSet ds = data_PE.ExecuteDataset(CONST_SP_TABLE_LIST);
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    sErrLoc = "create table '" + dr[1].ToString() + "'";
                    string sTableName = dr[1].ToString();
                    if (!sTableName.EndsWith("TMP")) sTableName += sTableSuffix;
                    sErrMsg = ReportingDB_CreateTable(dr[0].ToString(), sTableName);
                    ReportingDB_StatusRow(dtStatus, sTableName, sErrMsg);
                }

                // join project and resources tables
                sErrLoc = "create projects table";
                sErrMsg = ReportingDB_CreateTable_Joint(CONST_TBL_TMP_PROJECTS, CONST_TBL_TMP_PROJECTS_CUST, CONST_TBL_PROJECTS + sTableSuffix);
                ReportingDB_StatusRow(dtStatus, CONST_TBL_PROJECTS + sTableSuffix, sErrMsg);
                sErrLoc = "create resources table";
                sErrMsg = ReportingDB_CreateTable_Joint(CONST_TBL_TMP_RESOURCES, CONST_TBL_TMP_RESOURCES_CUST, CONST_TBL_RESOURCES + sTableSuffix);
                ReportingDB_StatusRow(dtStatus, CONST_TBL_RESOURCES + sTableSuffix, sErrMsg);

                sErrLoc = "drop temp tables";
                ReportingDB_TableDelete(CONST_TBL_TMP_PROJECTS);
                ReportingDB_TableDelete(CONST_TBL_TMP_PROJECTS_CUST);
                ReportingDB_TableDelete(CONST_TBL_TMP_RESOURCES);
                ReportingDB_TableDelete(CONST_TBL_TMP_RESOURCES_CUST);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                ReportingDB_StatusRow(dtStatus, sErrSrc + " - " + sErrLoc, sErrMsg);
            }

            return dtStatus;
        }

        private string ReportingDB_CreateTable(string sSQLSource, string sSQLTarget)
        {
            string sErrMsg = string.Empty;

            try
            {
                string sQuery = string.Empty;

                // ****** delete existing table
                sQuery = "IF OBJECT_ID ('dbo." + sSQLTarget + "', 'U') IS NOT NULL DROP TABLE dbo." + sSQLTarget;
                data_PT.ExecuteNonQuery(CommandType.Text, sQuery);

                // ****** build table 
                DataSet ds = data_PE.ExecuteDataset(sSQLSource);
                // add column and initialize it
                DataTable dt = ds.Tables[0];
                sQuery = "create table dbo." + sSQLTarget + "("; //RowID	int IDENTITY(1,1) NOT NULL";

                int iCntr = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (iCntr == 0)
                    {
                        sQuery = sQuery + "[" + dc.ColumnName + "] " + GetSQLField(dc.DataType.ToString());
                        iCntr++;
                    }
                    else
                        sQuery = sQuery + ", [" + dc.ColumnName + "] " + GetSQLField(dc.DataType.ToString());
                }

                sQuery = sQuery + ")";
                DataSet dsADGroupsToSync = data_PT.ExecuteDataset(CommandType.Text, sQuery);

                // ***** insert bulk data      
                SqlBulkCopy objSBC = new SqlBulkCopy(this._connPT);
                objSBC.DestinationTableName = sSQLTarget;
                // Write the data to the SQL Server            
                objSBC.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }

            return sErrMsg;
        }

        private string ReportingDB_CreateTable_Joint(string sSQLSource1, string sSQLSource2, string sSQLTarget)
        {
            string sErrMsg = string.Empty;

            try
            {
                string sQuery = string.Empty;

                // ****** delete existing table
                ReportingDB_TableDelete(sSQLTarget);

                // ****** build table 
                if (sSQLTarget.Substring(0, CONST_TBL_PROJECTS.Length) == CONST_TBL_PROJECTS)
                { // projects
                    sQuery = " SELECT s1.*, s2.* " +
                             " FROM   dbo." + sSQLSource1 + " s1 INNER JOIN " +
                             " dbo." + sSQLSource2 + " s2 ON s1.ProjectID = s2.ProjectID ";
                }
                else
                { // resources
                    sQuery = " SELECT s1.*, s2.* " +
                             " FROM   dbo." + sSQLSource1 + " s1 INNER JOIN " +
                             " dbo." + sSQLSource2 + " s2 ON s1.ResourceID = s2.ResourceID ";
                }

                DataSet ds = data_PT.ExecuteDataset(CommandType.Text, sQuery);
                // add column and initialize it
                DataTable dt = ds.Tables[0];
                sQuery = "create table dbo." + sSQLTarget + "("; //RowID	int IDENTITY(1,1) NOT NULL";

                int iCntr = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (iCntr == 0)
                    {
                        sQuery = sQuery + "[" + dc.ColumnName + "] " + GetSQLField(dc.DataType.ToString());
                        iCntr++;
                    }
                    else
                        sQuery = sQuery + ", [" + dc.ColumnName + "] " + GetSQLField(dc.DataType.ToString());
                }

                sQuery = sQuery + ")";
                DataSet dsADGroupsToSync = data_PT.ExecuteDataset(CommandType.Text, sQuery);

                // ***** insert bulk data      
                SqlBulkCopy objSBC = new SqlBulkCopy(this._connPT);
                objSBC.DestinationTableName = sSQLTarget;
                // Write the data to the SQL Server            
                objSBC.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }

            return sErrMsg;
        }

        private string ReportingDB_TableDelete(string sSQLTarget)
        {
            string sErrMsg = string.Empty;

            try
            {
                string sQuery = string.Empty;

                // ****** delete existing table
                sQuery = "IF OBJECT_ID ('dbo." + sSQLTarget + "', 'U') IS NOT NULL DROP TABLE dbo." + sSQLTarget;
                data_PT.ExecuteNonQuery(CommandType.Text, sQuery);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }

            return sErrMsg;
        }

        // add row to status table
        private string ReportingDB_StatusRow(DataTable dt, string TargetTable, string ErrMsg)
        {
            string sErrMsg = string.Empty;
            DataRow drStatus = null;

            try
            {
                drStatus = dt.NewRow();
                drStatus[0] = TargetTable;
                if (ErrMsg.Length == 0)
                    drStatus[1] = "Created successfully!";
                else
                    drStatus[1] = "Error: " + ErrMsg;

                dt.Rows.Add(drStatus);
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }

            return sErrMsg;
        }
        
        private string ReportingDB_GetTableSuffix(string sBasepath, string sSQLTarget)
        {
            string sErrMsg = string.Empty;
            int tableindex = -1;

            try
            {
                string sQuery = string.Empty;

                // ****** make sure table exists
                sQuery = "IF OBJECT_ID ('dbo." + sSQLTarget + "', 'U') IS NULL CREATE TABLE dbo." + sSQLTarget + " (PFE_INDEX int NOT NULL,PFE_BASEPATH nvarchar(255) NOT NULL)";
                data_PT.ExecuteNonQuery(CommandType.Text, sQuery);

                SqlCommand sqlCommand;
                SqlDataReader reader;

                // ****** look for existing index for this basepath
                sQuery = " SELECT * From " + sSQLTarget + " Where PFE_BASEPATH='" + sBasepath + "'";
                sqlCommand = new SqlCommand(sQuery, data_PT.cn);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    tableindex = Convert.ToInt32(reader["PFE_INDEX"]);
                }
                reader.Close();

                if (tableindex < 0) 
                {
                    //   no entry found so create a new one
                    sQuery = " SELECT max(PFE_INDEX) as Max_Index From " + sSQLTarget;
                    sqlCommand = new SqlCommand(sQuery, data_PT.cn);
                    reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        int ordinal = reader.GetOrdinal("Max_Index");
                        if (!reader.IsDBNull(ordinal)) tableindex = Convert.ToInt32(reader["Max_Index"]) + 1;
                    }
                    reader.Close();

                    if (tableindex < 0) tableindex = 0;

                    sQuery = "INSERT Into " + sSQLTarget + "(PFE_INDEX,PFE_BASEPATH) Values (@index,@basepath)";
                    sqlCommand = new SqlCommand(sQuery, data_PT.cn);
                    sqlCommand.Parameters.AddWithValue("@index", tableindex);
                    sqlCommand.Parameters.AddWithValue("@basepath", sBasepath);
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }

            if (tableindex > 0) return string.Format("_{0:000}", tableindex);
            else return string.Empty;
        }

        private string GetSQLField(string sFieldType)
        {
            string sReturn = string.Empty;

            switch (sFieldType)
            {
                case "System.Int32":
                    sReturn = "Int";
                    break;

                case "System.String":
                    sReturn = "nvarchar(255)";
                    break;

                case "System.Decimal":
                    sReturn = "decimal(25, 2)";
                    break;

                case "System.DateTime":
                    sReturn = "DateTime";
                    break;

                default:
                    sReturn = "nvarchar(255)";
                    break;
            }

            return sReturn;
        }

    }
}
