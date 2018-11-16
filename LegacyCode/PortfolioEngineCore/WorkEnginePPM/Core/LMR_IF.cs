using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;

namespace WorkEnginePPM
{
    public class LMR_IF
    {
        private static string m_sConnectionString = "";
        private static string m_sLastError = "";
        private static string m_sLastStackTrace = "";

        public static string LastError
        {
            get { return m_sLastError; }
        }

        public static string LastStackTrace
        {
            get { return m_sLastStackTrace; }
        }

        public static void Reset()
        {
            m_sConnectionString = "";
        }

        private static void Initialize()
        {
            m_sLastError = "";
            m_sLastStackTrace = "";
            //if (m_sConnectionString.Length > 0)
            //    return;
            HttpContext context = HttpContext.Current;
            var dbConnectionStringBuilder = new DbConnectionStringBuilder { ConnectionString = WebAdmin.GetConnectionString(context) };
            dbConnectionStringBuilder.Remove("Provider");

            m_sConnectionString = dbConnectionStringBuilder.ToString();
        }

        public static DataTable getPortfolioFields(int type)
        {
            Initialize();
            DataTable dt = new DataTable();
            dt.Columns.Add("epkField");
            dt.Columns.Add("epkFieldId");
            dt.Columns.Add("epkFieldType");
            //epkFieldType:
            //0 = No Data Synch
            //1 = EPK to SharePoint (Cost Totals + Calcs)
            //2 = SharePoint to EPK (Portfolio Fields)
            //3 = Both Directions

            SqlConnection conn = new SqlConnection(m_sConnectionString);
            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", conn);
            oCommand.Parameters.AddWithValue("SelectMode", type);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                int nFieldID = (int)reader["FIELD_ID"];
                string sFieldName = (string)reader["FIELD_NAME"];
                //int nFieldFormat = (int)reader["FIELD_FORMAT"];
                dt.Rows.Add(new object[] { sFieldName, nFieldID, type });
            }
            reader.Close();
            conn.Close();
            conn.Dispose();

            return dt;
        }

        public static bool saveResourceFieldMappings(GridView gridView)
        {
            Initialize();
            bool b = false;
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand oCommand = null;
            string sCommand = "";
            try
            {
                conn = new SqlConnection(m_sConnectionString);
                conn.Open();
                transaction = conn.BeginTransaction();
                sCommand = "DELETE EPG_WE_MAPPING WHERE WEM_ENTITY = 10";
                oCommand = new SqlCommand(sCommand, conn, transaction);
                int lRowsAffected = oCommand.ExecuteNonQuery();
                oCommand.Dispose();

                sCommand =
                      "INSERT INTO EPG_WE_MAPPING "
                    + " (WEM_UID,WEM_ENTITY,WEM_EPK_FIELD_ID,WEM_WE_FIELD_ID,WEM_WE_NAME) "
                    + " VALUES(@WEM_UID,@WEM_ENTITY,@WEM_EPK_FIELD_ID,@WEM_WE_FIELD_ID,@WEM_WE_NAME)";

                oCommand = new SqlCommand(sCommand, conn, transaction);

                SqlParameter pUID = oCommand.Parameters.Add("@WEM_UID", SqlDbType.Int);
                oCommand.Parameters.Add("@WEM_ENTITY", SqlDbType.Int).Value = 10;
                SqlParameter pEPKID = oCommand.Parameters.Add("@WEM_EPK_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEID = oCommand.Parameters.Add("@WEM_WE_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEName = oCommand.Parameters.Add("@WEM_WE_NAME", SqlDbType.VarChar, 255);

                int lUID = 0;
                foreach (GridViewRow gvr in gridView.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                        if (ddl.SelectedValue != "")
                        {
                            pUID.Value = ++lUID;
                            int nID = 0;
                            Int32.TryParse(gvr.Cells[2].Text, out nID);
                            pEPKID.Value = nID;
                            pWEID.Value = 0;
                            pWEName.Value = ddl.SelectedValue;
                            lRowsAffected = oCommand.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
                b = true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                m_sLastError = ex.Message;
                m_sLastStackTrace = ex.StackTrace;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return b;
        }

        public static bool saveTaskFieldMappings(GridView gridView)
        {
            return saveFieldMappings(gridView, 30);
        }

        private static bool saveFieldMappings(GridView gridView, int nEntity)
        {
            Initialize();
            bool b = false;
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand oCommand = null;
            string sCommand = "";
            try
            {
                conn = new SqlConnection(m_sConnectionString);
                conn.Open();
                transaction = conn.BeginTransaction();
                sCommand = "DELETE EPG_WE_MAPPING WHERE WEM_ENTITY = " + nEntity.ToString();
                oCommand = new SqlCommand(sCommand, conn, transaction);
                int lRowsAffected = oCommand.ExecuteNonQuery();
                oCommand.Dispose();

                sCommand =
                      "INSERT INTO EPG_WE_MAPPING "
                    + " (WEM_UID,WEM_ENTITY,WEM_EPK_FIELD_ID,WEM_WE_FIELD_ID,WEM_WE_NAME) "
                    + " VALUES(@WEM_UID,@WEM_ENTITY,@WEM_EPK_FIELD_ID,@WEM_WE_FIELD_ID,@WEM_WE_NAM)";

                oCommand = new SqlCommand(sCommand, conn, transaction);

                SqlParameter pUID = oCommand.Parameters.Add("@WEM_UID", SqlDbType.Int);
                oCommand.Parameters.Add("@WEM_ENTITY", SqlDbType.Int).Value = nEntity;
                SqlParameter pEPKID = oCommand.Parameters.Add("@WEM_EPK_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEID = oCommand.Parameters.Add("@WEM_WE_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEName = oCommand.Parameters.Add("@WEM_WE_NAME", SqlDbType.VarChar, 255);

                int lUID = 0;
                foreach (GridViewRow gvr in gridView.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                        if (ddl.SelectedValue != "")
                        {
                            pUID.Value = ++lUID;
                            int nID = 0;
                            Int32.TryParse(gvr.Cells[2].Text, out nID);
                            pEPKID.Value = nID;
                            pWEID.Value = 0;
                            pWEName.Value = ddl.SelectedValue;
                            lRowsAffected = oCommand.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
                b = true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                m_sLastError = ex.Message;
                m_sLastStackTrace = ex.StackTrace;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return b;
        }

        public static bool savePortfolioFieldMappings(GridView gridView, int mode)
        {
            //1 = EPK to SharePoint (Cost Totals)
            //2 = SharePoint to EPK (Portfolio Fields)
            Initialize();
            
            int nEntity = 0;
            bool b = false;
            if (mode == 1)
                nEntity = 20;
            else if (mode == 2)
                nEntity = 21;
            else
                return b;

            
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand oCommand = null;
            string sCommand = "";
            try
            {
                conn = new SqlConnection(m_sConnectionString);
                conn.Open();
                transaction = conn.BeginTransaction();
                sCommand = "DELETE EPG_WE_MAPPING WHERE WEM_ENTITY = " + nEntity.ToString();
                oCommand = new SqlCommand(sCommand, conn, transaction);
                int lRowsAffected = oCommand.ExecuteNonQuery();
                oCommand.Dispose();

                sCommand =
                      "INSERT INTO EPG_WE_MAPPING "
                    + " (WEM_UID,WEM_ENTITY,WEM_EPK_FIELD_ID,WEM_WE_FIELD_ID,WEM_WE_NAME) "
                    + " VALUES(@WEM_UID,@WEM_ENTITY,@WEM_EPK_FIELD_ID,@WEM_WE_FIELD_ID,@WEM_WE_NAME)";

                oCommand = new SqlCommand(sCommand, conn, transaction);

                SqlParameter pUID = oCommand.Parameters.Add("@WEM_UID", SqlDbType.Int);
                oCommand.Parameters.Add("@WEM_ENTITY", SqlDbType.Int).Value = nEntity;
                SqlParameter pEPKID = oCommand.Parameters.Add("@WEM_EPK_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEID = oCommand.Parameters.Add("@WEM_WE_FIELD_ID", SqlDbType.Int);
                SqlParameter pWEName = oCommand.Parameters.Add("@WEM_WE_NAME", SqlDbType.VarChar, 255);

                int lUID = 0;
                foreach (GridViewRow gvr in gridView.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddl = (DropDownList)gvr.Cells[1].FindControl("ddlSPField");
                        if (ddl.SelectedValue != "")
                        {
                            pUID.Value = ++lUID;
                            int nID = 0;
                            Int32.TryParse(gvr.Cells[2].Text, out nID);
                            pEPKID.Value = nID;
                            pWEID.Value = 0;
                            pWEName.Value = ddl.SelectedValue;
                            lRowsAffected = oCommand.ExecuteNonQuery();
                        }
                    }
                }
                transaction.Commit();
                b = true;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                m_sLastError = ex.Message;
                m_sLastStackTrace = ex.StackTrace;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return b;
        }

        public static DataTable getResourceFields()
        {
            Initialize();
            DataTable dt = new DataTable();
            dt.Columns.Add("epkField");
            dt.Columns.Add("epkFieldId");

            SqlConnection conn = new SqlConnection(m_sConnectionString);
            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", conn);
            oCommand.Parameters.AddWithValue("SelectMode", 0);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                int nFieldID = (int)reader["FIELD_ID"];
                string sFieldName = (string)reader["FIELD_NAME"];
                //int nFieldFormat = (int)reader["FIELD_FORMAT"];

                // only custom fields in V43
                if (nFieldID >= 20000)
                  dt.Rows.Add(new object[] { sFieldName, nFieldID });
            }

            reader.Close();
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public static DataTable getTaskFields()
        {
            Initialize();
            DataTable dt = new DataTable();
            dt.Columns.Add("epkField");
            dt.Columns.Add("epkFieldId");
            dt.Columns.Add("epkFieldType");
            //epkFieldType:
            //0 = No Data Synch
            //1 = EPK to SharePoint
            //2 = SharePoint to EPK
            //3 = Both Directions

            //// BUGBUG TODO: EPK Code to get WI fields
            //dt.Rows.Add(new object[] { "Start", 1, 1 });
            //dt.Rows.Add(new object[] { "Finish", 2, 1 });

            SqlConnection conn = new SqlConnection(m_sConnectionString);
            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", conn);
            oCommand.Parameters.AddWithValue("SelectMode", 3);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                int nFieldID = (int)reader["FIELD_ID"];
                string sFieldName = (string)reader["FIELD_NAME"];
                //int nFieldFormat = (int)reader["FIELD_FORMAT"];
                dt.Rows.Add(new object[] { sFieldName, nFieldID, 3 });
            }
            reader.Close();
            conn.Close();
            conn.Dispose();

            return dt;
        }

        public static DataTable getPortfolioViews()
        {
            Initialize();
            DataTable dt = new DataTable();
            dt.Columns.Add("epkView");
            dt.Columns.Add("epkViewId");

            SqlConnection conn = new SqlConnection(m_sConnectionString);
            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadViewsForWE", conn);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                int nViewUID = (int)reader["VIEW_UID"];
                string sViewName = (string)reader["VIEW_NAME"];
                dt.Rows.Add(new object[] { sViewName, nViewUID });
            }
            reader.Close();
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public static DataTable getCostViews()
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("costView");
            //dt.Columns.Add("costViewId");

            ////TODO: EPK Code to get Portfolio Views

            //dt.Rows.Add(new object[] { "cView 1", 1 });
            //dt.Rows.Add(new object[] { "cView 2", 2 });
            //dt.Rows.Add(new object[] { "cExecutive Summary", 3 });

            //return dt;
            Initialize();
            DataTable dt = new DataTable();
            dt.Columns.Add("costView");
            dt.Columns.Add("costViewId");

            SqlConnection conn = new SqlConnection(m_sConnectionString);
            SqlCommand oCommand = new SqlCommand("PPM_SP_ReadCostViewsForWE", conn);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();

            SqlDataReader reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                int nViewUID = (int)reader["VIEW_UID"];
                string sViewName = (string)reader["VIEW_NAME"];
                dt.Rows.Add(new object[] { sViewName, nViewUID });
            }
            reader.Close();
            conn.Close();
            conn.Dispose();

            return dt;
        }

        public static bool ExecuteProcess(string sContext, string sXMLRequest, out XmlNode xNode)
        {
            xNode = null;
            return ExecuteProcessEx("", sContext, sXMLRequest, out xNode);
            return false;
        }

        public static bool ExecuteProcessEx(string sURL, string sContext, string sXMLRequest, out XmlNode xNode)
        {
            m_sLastError = "";
            m_sLastStackTrace = "";
            xNode = null;
            bool b = true;
            Integration integration = new Integration();
            xNode = integration.execute(sContext, sXMLRequest);
            integration = null;
            return b;
        }
    }
}