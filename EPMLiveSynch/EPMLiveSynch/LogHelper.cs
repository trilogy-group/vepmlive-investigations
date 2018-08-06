using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text;

namespace EPMLiveSynch
{
    public class LogHelper : IDisposable
    {
        private const string DtLoggedColumn = "dtLogged";
        private const string ResultColumn = "result";
        private const string ResultTextColumn = "resulttext";

        private const string ListGuidParam = "@listguid";

        private SPWeb currWeb;
        private string sConn = null;
        private string sSource = "";
        private string sAction = "";

        public LogHelper()
        {
        }

        public void Dispose()
        {
        }

        public SPWeb CurrWeb
        {
            get { return currWeb; }
            set { currWeb = value; }
        }

        public string Source
        {
            get { return sSource; }
            set { sSource = value; }
        }

        public string Action
        {
            get { return sAction; }
            set { sAction = value; }
        }

        public string ConnectionString
        {
            get { return sConn; }
            set { sConn = value; }
        }

        //public bool LogResult(string sSiteGuid, string sURL, string sAction, string sResult, string sResults)
        //{
        //    string sConn = null;
        //    try
        //    {
        //        sConn = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id );
        //    }
        //    catch (Exception ex) 
        //    {
        //        return false;
        //    }

        //    if (sConn != null)
        //    {
        //        try
        //        {
        //            SPSecurity.RunWithElevatedPrivileges(delegate()
        //            {
        //                SqlConnection cn = new SqlConnection();
        //                cn.ConnectionString = sConn;
        //                cn.Open();

        //                SqlCommand cmd = new SqlCommand();
        //                cmd.CommandText = "Select result From EPMLive_Log Where source = '" + sSiteGuid + sURL + "' And UPPER(action) = '" + sAction.ToUpper() + "'";
        //                cmd.Connection = cn;
        //                SqlDataReader rdr;
        //                rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows == true)
        //                {
        //                    cmd.CommandText = "Update EPMLive_Log Set dtLogged = @dtLogged, result = '" + sResult + "', logText = '" + sResults + "' Where source = '" + sSiteGuid + sURL + "' And UPPER(action) = '" + sAction.ToUpper() + "'";
        //                }
        //                else
        //                {
        //                    cmd.CommandText = "Insert Into EPMLive_Log (dtLogged, source, action, result, logText) Values (@dtLogged, '" + sSiteGuid + sURL + "','" + sAction.ToLower() + "','" + sResult + "','" + sResults + "')";
        //                }
        //                rdr.Close();
        //                cmd.Parameters.AddWithValue("@dtLogged", DateTime.Now.ToUniversalTime());
        //                cmd.ExecuteNonQuery();
        //                cmd.Dispose();
        //                cn.Close();
        //                cn.Dispose();
        //            });

        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }

        //    return false;

        //}

        public string GetLastResult
        {
            get
            {
                string sRet = "";
                DataTable dt = new DataTable();
                dt.Columns.Add("action");
                dt.Columns.Add("dtLogged");

                try
                {
                    sConn = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
                }
                catch (Exception ex)
                {
                    sRet = "Error: " + ex.Message;
                    return sRet;
                }

                if (sConn != null)
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            sRet = InitializeResults(dt, sConn, sRet, sSource);
                        });

                    }
                    catch (Exception ex)
                    {
                        sRet = "Error: " + ex.Message;
                    }
                }
                else
                {
                    sRet = "Error: Database connection failed.";
                }

                dt.Dispose();

                return sRet;
            }
        }

        public string InitializeResults(DataTable dataTable, string connectionString, string resultString, object source)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException(nameof(dataTable));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("Select Top 1 result, dtLogged From vwqueuetimerlog Where listguid=@listguid and jobtype=4", connection))
                {
                    command.Parameters.AddWithValue(ListGuidParam, source);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dataTable.Rows.Add(reader[ResultColumn].ToString(), reader[DtLoggedColumn].ToString());
                            }

                            var sLogDateTime = dataTable.Rows[0].ItemArray[1].ToString();
                            resultString = $"{dataTable.Rows[0].ItemArray[0]}.  Log time: {sLogDateTime}";
                        }
                    }
                }
            }

            return resultString;
        }

        public string GetLastResultLogText
        {
            get
            {
                string sRet = "";
                DataTable dt = new DataTable();
                dt.Columns.Add("logText");

                try
                {
                    sConn = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
                }
                catch (Exception ex)
                {
                    sRet = "Error: " + ex.Message;
                    return sRet;
                }

                if (sConn != null)
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            sRet = InitializeResultText(dt, sConn, sRet, sSource);
                        });

                    }
                    catch (Exception ex)
                    {
                        sRet = "Error: " + ex.Message;
                    }
                }
                else
                {
                    sRet = "Error: Database connection failed.";
                }

                dt.Dispose();

                return sRet;
            }
        }

        public string InitializeResultText(DataTable dataTable, string connectionString, string resultString, object source)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException(nameof(dataTable));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("Select Top 1 resulttext From vwqueuetimerlog Where listguid=@listguid and jobtype=4", connection))
                {
                    command.Parameters.AddWithValue(ListGuidParam, source);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                dataTable.Rows.Add(reader[ResultTextColumn].ToString());
                            }

                            resultString = dataTable.Rows[0].ItemArray[0].ToString();
                        }
                    }
                }
            }

            return resultString;
        }

        public string DeleteLastResult()
        {
            string sRet = "";

            try
            {
                sConn = EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
            }
            catch (Exception ex)
            {
                sRet = "Error: " + ex.Message;
            }

            if (sConn != null)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        DeleteLogBySourceAndAction(sConn, sSource, sAction);
                    });

                }
                catch (Exception ex)
                {
                    sRet = "Error: " + ex.Message;
                }
            }
            else
            {
                sRet = "Error: Database connection failed.";
            }

            return sRet;
        }

        public void DeleteLogBySourceAndAction(string connectionString, string source, string action)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrWhiteSpace(action))
            {
                throw new ArgumentNullException(nameof(action));
            }

            var commandText = $"Delete From EPMLive_Log Where source = '{source}' And UPPER(action) = '{action}'";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public string FirstLetterUCase(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
    }
}
