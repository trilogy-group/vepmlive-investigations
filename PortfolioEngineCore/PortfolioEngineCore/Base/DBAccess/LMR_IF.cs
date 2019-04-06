using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class LMR_IF
    {
        private static string m_sLastError = string.Empty;
        private static string m_sLastStackTrace = string.Empty;

        public static string LastError
        {
            get { return m_sLastError; }
        }

        public static string LastStackTrace
        {
            get { return m_sLastStackTrace; }
        }

        public static DataTable getPortfolioFields(DBAccess dba, int type)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("epkField");
            dataTable.Columns.Add("epkFieldId");
            dataTable.Columns.Add("epkFieldType");

            //epkFieldType:
            //0 = No Data Synch
            //1 = EPK to SharePoint (Cost Totals + Calcs)
            //2 = SharePoint to EPK (Portfolio Fields)
            //3 = Both Directions

            var command = new SqlCommand("EPG_SP_ReadFieldsForWE", dba.Connection);
            command.Parameters.AddWithValue("SelectMode", type);
            command.CommandType = CommandType.StoredProcedure;
            dba.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var nFieldID = (int)reader["FIELD_ID"];
                var sFieldName = (string)reader["FIELD_NAME"];
                dataTable.Rows.Add(sFieldName, nFieldID, type);
            }
            reader.Close();
            dba.Close();
            return dataTable;
        }

        public static bool saveResourceFieldMappings(DBAccess dba, DataTable dt)
        {
            var result = false;
            SqlTransaction transaction = null;
            try
            {
                dba.Open();
                transaction = dba.Connection.BeginTransaction();
                var command = "DELETE EPG_WE_MAPPING WHERE WEM_ENTITY = 10";
                var sqlCommand = new SqlCommand(command, dba.Connection, transaction);
                var rowsAffected = sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();

                command = "INSERT INTO EPG_WE_MAPPING "
                    + " (WEM_UID,WEM_ENTITY,WEM_EPK_FIELD_ID,WEM_WE_FIELD_ID,WEM_WE_NAME) "
                    + " VALUES(@WEM_UID,@WEM_ENTITY,@WEM_EPK_FIELD_ID,@WEM_WE_FIELD_ID,@WEM_WE_NAME)";

                sqlCommand = new SqlCommand(command, dba.Connection, transaction);

                var uId = sqlCommand.Parameters.Add("@WEM_UID", SqlDbType.Int);
                sqlCommand.Parameters.Add("@WEM_ENTITY", SqlDbType.Int).Value = 10;
                var epkId = sqlCommand.Parameters.Add("@WEM_EPK_FIELD_ID", SqlDbType.Int);
                var weId = sqlCommand.Parameters.Add("@WEM_WE_FIELD_ID", SqlDbType.Int);
                var weName = sqlCommand.Parameters.Add("@WEM_WE_NAME", SqlDbType.VarChar, 255);

                var lUid = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    uId.Value = ++lUid;
                    epkId.Value = dr["EPKID"];
                    weId.Value = dr["WEID"];
                    weName.Value = dr["WEName"];
                    sqlCommand.ExecuteNonQuery();
                }
                transaction.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                m_sLastError = ex.Message;
                m_sLastStackTrace = ex.StackTrace;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (dba != null)
                {
                    dba.Close();
                }
            }
            return result;
        }

        public static DataTable getResourceFields(DBAccess dba)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("epkField");
            dataTable.Columns.Add("epkFieldId");

            var sqlCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", dba.Connection);
            sqlCommand.Parameters.AddWithValue("SelectMode", 0);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            dba.Open();

            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var nFieldID = (int)reader["FIELD_ID"];
                var sFieldName = (string)reader["FIELD_NAME"];

                if (nFieldID >= 20000)
                {
                    dataTable.Rows.Add(sFieldName, nFieldID);
                }
            }

            reader.Close();
            dba.Close();

            return dataTable;
        }

        public static DataTable getTaskFields(DBAccess dba)
        {
            var dt = new DataTable();
            dt.Columns.Add("epkField");
            dt.Columns.Add("epkFieldId");
            dt.Columns.Add("epkFieldType");

            //epkFieldType:
            //0 = No Data Synch
            //1 = EPK to SharePoint
            //2 = SharePoint to EPK
            //3 = Both Directions

            //// BUGBUG TODO: EPK Code to get WI fields

            var sqlCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", dba.Connection);
            sqlCommand.Parameters.AddWithValue("SelectMode", 3);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            dba.Open();

            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var fieldId = (int)reader["FIELD_ID"];
                var fieldName = (string)reader["FIELD_NAME"];

                dt.Rows.Add(fieldName, fieldId, 3);
            }
            reader.Close();
            dba.Close();

            return dt;
        }

        public static DataTable getPortfolioViews(DBAccess dba)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("epkView");
            dataTable.Columns.Add("epkViewId");

            var sqlCommand = new SqlCommand("EPG_SP_ReadViewsForWE", dba.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            dba.Open();

            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var viewUid = (int)reader["VIEW_UID"];
                var viewName = (string)reader["VIEW_NAME"];
                dataTable.Rows.Add(viewName, viewUid);
            }
            reader.Close();
            dba.Close();

            return dataTable;
        }

        public static DataTable getCostViews(DBAccess dba)
        {
            // TODO: EPK Code to get Portfolio Views

            var dataTable = new DataTable();
            dataTable.Columns.Add("costView");
            dataTable.Columns.Add("costViewId");

            var sqlCommand = new SqlCommand("PPM_SP_ReadCostViewsForWE", dba.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            dba.Open();

            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var viewUId = (int)reader["VIEW_UID"];
                var viewName = (string)reader["VIEW_NAME"];
                dataTable.Rows.Add(viewName, viewUId);
            }
            reader.Close();
            dba.Close();

            return dataTable;
        }
    }
}