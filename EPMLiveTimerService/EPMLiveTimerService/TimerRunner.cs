using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
using Microsoft.SharePoint.Administration;
using System.IO;
using System.Data;
using Microsoft.SharePoint;

namespace TimerService
{
    public class TimerRunner
    {
        private static BackgroundWorker bw;
        private static BackgroundWorker bwSec;
        private static BackgroundWorker bwTimerJobs;
        private static BackgroundWorker bwNotificationsJobs;
        private static BackgroundWorker bwIntegrationJobs;
        private static BackgroundWorker bwActivity;

        public bool startTimer()
        {
            try
            {
                //=========================Run Main Queue
                bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bw.RunWorkerAsync();



                //=========================Run High Priority Queue
                bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                
                bw.DoWork += bw_HighDoWork;

                bw.RunWorkerAsync();


                //=========================Run TS Queue
                bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_TSDoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                //bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bw.RunWorkerAsync();


                //=========================Run Sec Queue
                bwSec = new BackgroundWorker();
                bwSec.WorkerReportsProgress = true;
                bwSec.WorkerSupportsCancellation = true;

                bwSec.DoWork += bw_SecDoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                //bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bwSec.RunWorkerAsync();

                //=======================Run Timer Enqueue Process
                bwTimerJobs = new BackgroundWorker();
                bwTimerJobs.WorkerReportsProgress = true;
                bwTimerJobs.WorkerSupportsCancellation = true;

                bwTimerJobs.DoWork += bwTimerJobs_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bwTimerJobs.RunWorkerCompleted += bwTimerJobs_RunWorkerCompleted;

                bwTimerJobs.RunWorkerAsync();


                //================Run Notifications
                bwNotificationsJobs = new BackgroundWorker();
                bwNotificationsJobs.WorkerReportsProgress = true;
                bwNotificationsJobs.WorkerSupportsCancellation = true;

                bwNotificationsJobs.DoWork += bwNotificationsJobs_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bwNotificationsJobs.RunWorkerCompleted += bwNotificationsJobs_RunWorkerCompleted;

                bwNotificationsJobs.RunWorkerAsync();

                ////================Run Activity
                //bwActivity = new BackgroundWorker();
                //bwActivity.WorkerReportsProgress = true;
                //bwActivity.WorkerSupportsCancellation = true;

                //bwActivity.DoWork += bwActivity_DoWork;
                ////bw.ProgressChanged += bw_ProgressChanged;
                ////bwActivity.RunWorkerCompleted += bwNotificationsJobs_RunWorkerCompleted;

                //bwActivity.RunWorkerAsync();


                //=========================Run Rollup Queue
                bwSec = new BackgroundWorker();
                bwSec.WorkerReportsProgress = true;
                bwSec.WorkerSupportsCancellation = true;

                bwSec.DoWork += bw_RollupDoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                //bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bwSec.RunWorkerAsync();

                //================Run Integrations
                bwIntegrationJobs = new BackgroundWorker();
                bwIntegrationJobs.WorkerReportsProgress = true;
                bwIntegrationJobs.WorkerSupportsCancellation = true;

                bwIntegrationJobs.DoWork += bwIntegrationJobs_DoWork;

                bwIntegrationJobs.RunWorkerAsync();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void bwIntegrationJobs_DoWork(object sender, DoWorkEventArgs e)
        {
            IntegrationClass mc = new IntegrationClass();
            if(mc.startTimer())
            {
                while(true)
                {
                    mc.runTimer();
                    if(bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 5;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }

        public bool timerRunning()
        {
            return bw.IsBusy;
        }

        public bool stopTimer()
        {
            try
            {
                bw.CancelAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            TimerClass mc = new TimerClass();
            if (mc.startTimer())
            {
                while (true)
                {
                    mc.runTimer();
                    if (bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 30;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }

        static void bw_HighDoWork(object sender, DoWorkEventArgs e)
        {
            HighTimerClass mc = new HighTimerClass();
            if(mc.startTimer())
            {
                while(true)
                {
                    mc.runTimer();
                    if(bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 30;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }

        static void bw_TSDoWork(object sender, DoWorkEventArgs e)
        {
            TimesheetTimerClass mc = new TimesheetTimerClass();
            if(mc.startTimer())
            {
                while(true)
                {
                    mc.runTimer();
                    if(bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 5;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }

        static void bw_SecDoWork(object sender, DoWorkEventArgs e)
        {
            SecurityClass mc = new SecurityClass();
            if(mc.startTimer())
            {
                while(true)
                {
                    mc.runTimer();
                    if(bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 2;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }

        static void bw_RollupDoWork(object sender, DoWorkEventArgs e)
        {
            RollupClass mc = new RollupClass();
            if (mc.startTimer())
            {
                while (true)
                {
                    mc.runTimer();
                    if (bw.CancellationPending)
                    {
                        mc.stopTimer();
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    int poll = 2;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 1000);
                }
            }
            else
            {
                e.Result = -1;
            }
        }


        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        static void bwTimerJobs_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (DateTime.Now.Minute == 0)
                {
                    foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if (sConn != "")
                        {
                            try
                            {
                                SqlConnection cn = new SqlConnection(sConn);
                                cn.Open();

                                SqlCommand cmd = new SqlCommand("spQueueTimerJobs", cn);
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();

                                cn.Close();
                            }
                            catch (Exception ex)
                            {
                                DateTime dt = DateTime.Now;

                                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_QUEUE_" + dt.Year + dt.Month + dt.Day + ".log", true);

                                swLog.WriteLine(DateTime.Now.ToString() + "\tERR\tQUEUE\t" + ex.Message);

                                swLog.Close();
                            }
                        }
                    }
                }
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                GC.Collect();
                Thread.Sleep(60000);
            }
        }

        static void bwTimerJobs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        static void bwActivity_DoWork(object sender, DoWorkEventArgs e)
        {
            int interval = 5;

            DateTime dt = DateTime.Now;

            StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true);

            swLog.WriteLine(DateTime.Now.ToString() + "\tINFO\tACTIVITY\tSTARTED");

            swLog.Close();

            while (true)
            {
                try
                {
                    foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if (sConn != "")
                        {
                            SqlConnection cn = new SqlConnection(sConn);
                            cn.Open();

                            SqlCommand cmd = new SqlCommand(@"select * from ActivityQueue where DATEDIFF(s, PostTime, GETDATE ()) > 10", cn);

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                try
                                {
                                    using (SPSite site = new SPSite(new Guid(dr["SiteId"].ToString())))
                                    {
                                        using (SPWeb web = site.OpenWeb(new Guid(dr["WebId"].ToString())))
                                        {

                                            SPList list = web.Lists[new Guid(dr["ListId"].ToString())];

                                            //Call Activity Add

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    dt = DateTime.Now;

                                    swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true);

                                    swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tACTIVITY\t" + ex.Message);

                                    swLog.Close();
                                }
                            }

                            cn.Close();
                        }
                    }

                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();

                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    dt = DateTime.Now;

                    swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true);

                    swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tACTIVITY\t" + ex.Message);

                    swLog.Close();
                }

            }
        }

        static void bwNotificationsJobs_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                try
                {
                    foreach(SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if(sConn != "")
                        {
                            try
                            {
                                SqlConnection cn = new SqlConnection(sConn);
                                cn.Open();

                                SqlCommand cmd = new SqlCommand("delete from PERSONALIZATIONS where FK in (select ID from NOTIFICATIONS where DATEADD(mm, 1, CreatedAt) < GETDATE())", cn);
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("delete from NOTIFICATIONS where DATEADD(mm, 1, CreatedAt) < GETDATE()", cn);
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("select * from vwNReadyEmails order by siteid", cn);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                SPSite site = null;
                                SPWeb web = null;

                                Guid siteid = Guid.Empty; ;

                                foreach(DataRow dr in ds.Tables[0].Rows)
                                {
                                    try
                                    {
                                        Guid newsiteid = new Guid(dr["siteid"].ToString());

                                        if(newsiteid != siteid)
                                        {
                                            if(site != null)
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

                                        if(toUser.Email != "")
                                        {
                                            if(dr["createdby"].ToString() == "1073741823")
                                                EmailSystem.SendFullEmail(body, subject, true, fromUser, toUser);
                                            else
                                                EmailSystem.SendFullEmail(body, subject, false, fromUser, toUser);
                                        }
                                    }
                                    catch(Exception ex)
                                    {
                                        DateTime dt = DateTime.Now;

                                        StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true);

                                        swLog.WriteLine(DateTime.Now.ToString() + "\tERR\tNOTIFICATIONS\t" + ex.Message);

                                        swLog.Close();
                                    }

                                    cmd = new SqlCommand("spNSetBit", cn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@FK", dr["FK"].ToString());
                                    cmd.Parameters.AddWithValue("@userid", dr["userid"].ToString());
                                    cmd.Parameters.AddWithValue("@index", 1);
                                    cmd.Parameters.AddWithValue("@val", 1);
                                    cmd.ExecuteNonQuery();
                                }

                                cn.Close();

                                if(site != null)
                                {
                                    web.Close();
                                    site.Close();
                                }
                            }
                            catch(Exception ex)
                            {
                                DateTime dt = DateTime.Now;

                                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true);

                                swLog.WriteLine(DateTime.Now.ToString() + "\tERRM\tNOTIFICATIONS\t" + ex.Message);

                                swLog.Close();
                            }
                        }

                    }
                    if(bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();

                    int poll = 1;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("NotificationInterval"));
                    }
                    catch { }
                    Thread.Sleep(poll * 60000);
                }
                catch(Exception ex)
                {
                    DateTime dt = DateTime.Now;

                    StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true);

                    swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tNOTIFICATIONS\t" + ex.Message);

                    swLog.Close();
                }
            }

        }

        static void bwNotificationsJobs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
