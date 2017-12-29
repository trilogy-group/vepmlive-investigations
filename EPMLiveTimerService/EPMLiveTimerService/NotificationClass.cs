using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;

namespace TimerService
{
    public class NotificationClass : ProcessorBase
    {
        public override void runTimer()
        {
            try
            {
                SPWebApplicationCollection _webapplication = GetWebApplications();
                foreach (SPWebApplication webApp in _webapplication)
                {
                    SPSite site = null;
                    SPWeb web = null;
                    DataSet ds = new DataSet();
                    string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                    if (sConn != "")
                    {
                        using (SqlConnection cn = new SqlConnection(sConn))
                        {
                            try
                            {

                                cn.Open();

                                using (SqlCommand cmd = new SqlCommand("delete from PERSONALIZATIONS where FK in (select ID from NOTIFICATIONS where DATEADD(mm, 1, CreatedAt) < GETDATE())", cn))
                                {
                                    cmd.ExecuteNonQuery();
                                }

                                using (SqlCommand cmd1 = new SqlCommand("delete from NOTIFICATIONS where DATEADD(mm, 1, CreatedAt) < GETDATE()", cn))
                                {
                                    cmd1.ExecuteNonQuery();
                                }

                                //using (SqlCommand cmd2 = new SqlCommand("select * from vwNReadyEmails order by siteid", cn))
                                using (var cmd2 = new SqlCommand("spNotificationGetQueue", cn))
                                {
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@servername", System.Environment.MachineName);

                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd2))
                                    {
                                        da.Fill(ds);

                                        Guid siteid = Guid.Empty; ;

                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            try
                                            {
                                                Guid newsiteid = new Guid(dr["siteid"].ToString());

                                                if (newsiteid != siteid)
                                                {
                                                    if (site != null)
                                                    {
                                                        web.Close();
                                                        site.Close();
                                                    }
                                                    site = new SPSite(newsiteid);
                                                    web = site.OpenWeb();
                                                }

                                                string body = dr["Message"].ToString();
                                                string subject = dr["Title"].ToString();

                                                SPUser fromUser = web.SiteUsers.GetByID(int.Parse(dr["createdby"].ToString()));
                                                SPUser toUser = web.SiteUsers.GetByID(int.Parse(dr["userid"].ToString()));

                                                if (toUser.Email != "")
                                                {
                                                    if (dr["createdby"].ToString() == "1073741823")
                                                        EmailSystem.SendFullEmail(body, subject, true, fromUser, toUser);
                                                    else
                                                        EmailSystem.SendFullEmail(body, subject, false, fromUser, toUser);
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                DateTime dt = DateTime.Now;

                                                using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true))
                                                {

                                                    swLog.WriteLine(DateTime.Now.ToString() + "\tERR\tNOTIFICATIONS\t" + ex.Message);
                                                }
                                            }

                                            using (SqlCommand cmd3 = new SqlCommand("spNSetBit", cn))
                                            {
                                                cmd3.CommandType = CommandType.StoredProcedure;
                                                cmd3.Parameters.AddWithValue("@FK", dr["FK"].ToString());
                                                cmd3.Parameters.AddWithValue("@userid", dr["userid"].ToString());
                                                cmd3.Parameters.AddWithValue("@index", 1);
                                                cmd3.Parameters.AddWithValue("@val", 1);
                                                cmd3.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                logMessage("ERR", "RUNT", ex.Message);
                            }
                            finally
                            {
                                if (site != null)
                                {
                                    web.Close();
                                    site.Close();
                                }
                                ds.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logMessage("ERR", "RUNT", ex.Message);
            }
        }

        protected override void bw_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        protected override string LogName {
            get {
                return "TIMERLOG_NOTIFICATIONS";
            }
        }
    }
}
