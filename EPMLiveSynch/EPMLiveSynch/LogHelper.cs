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
                            SqlConnection cn = new SqlConnection();
                            cn.ConnectionString = sConn;
                            cn.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Select Top 1 result, dtLogged From vwqueuetimerlog Where listguid=@listguid and jobtype=4";
                            cmd.Parameters.AddWithValue("@listguid", sSource);
                            cmd.Connection = cn;
                            SqlDataReader rdr;
                            rdr = cmd.ExecuteReader();

                            if (rdr.HasRows == true)
                            {
                                while (rdr.Read())
                                {
                                    dt.Rows.Add(new string[] { rdr["result"].ToString(), rdr["dtLogged"].ToString() });
                                }

                                
                                string sLogDateTime = dt.Rows[0].ItemArray[1].ToString();
                                //if (sLogDateTime != "")
                                //{
                                //    DateTime dtLogDateTime = DateTime.Parse(sLogDateTime);
                                //    System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(currWeb.Locale.LCID);
                                //    IFormatProvider culture = new System.Globalization.CultureInfo(cInfo.Name, true);

                                //    sLogDateTime = dtLogDateTime.ToLocalTime().GetDateTimeFormats(culture)[72]; //dt.ToShortDateString() + " " + dt.ToShortTimeString();
                                //}
                                sRet = dt.Rows[0].ItemArray[0].ToString() + ".  Log time: " + sLogDateTime;
                                
                            }

                            cmd.Dispose();
                            cn.Close();
                            cn.Dispose();
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
                            SqlConnection cn = new SqlConnection();
                            cn.ConnectionString = sConn;
                            cn.Open();

                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Select Top 1 resulttext From vwqueuetimerlog Where listguid=@listguid and jobtype=4";
                            cmd.Parameters.AddWithValue("@listguid", sSource);
                            cmd.Connection = cn;
                            SqlDataReader rdr;
                            rdr = cmd.ExecuteReader();

                            if (rdr.HasRows == true)
                            {
                                while (rdr.Read())
                                {
                                    dt.Rows.Add(new string[] { rdr["resulttext"].ToString() });
                                }

                                sRet = dt.Rows[0].ItemArray[0].ToString();
                            }

                            cmd.Dispose();
                            cn.Close();
                            cn.Dispose();
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
                        SqlConnection cn = new SqlConnection();
                        cn.ConnectionString = sConn;
                        cn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "Delete From EPMLive_Log Where source = '" + sSource + "' And UPPER(action) = '" + sAction + "'";
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        cn.Close();
                        cn.Dispose();
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

        public string FirstLetterUCase(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
    }
}
