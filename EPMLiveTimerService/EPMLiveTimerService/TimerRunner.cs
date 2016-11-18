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
        private static BackgroundWorker bw1;
        private static BackgroundWorker bw2;
        private static BackgroundWorker bwSec;
        private static BackgroundWorker bwTimerJobs;
        private static BackgroundWorker bwNotificationsJobs;
        private static BackgroundWorker bwIntegrationJobs;
        private static AutoResetEvent _autoResetEvent;
        //private static BackgroundWorker bwActivity;  //Not in Use

        public bool startTimer()
        {
            try
            {
                _autoResetEvent = new AutoResetEvent(false);
                //=========================Run Main Queue
                bw1 = new BackgroundWorker();
                bw1.WorkerReportsProgress = true;
                bw1.WorkerSupportsCancellation = true;

                bw1.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bw1.RunWorkerCompleted += bw_RunWorkerCompleted;

                bw1.RunWorkerAsync();
                _autoResetEvent.Set();
                Thread.Sleep(1000);

                //=========================Run High Priority Queue
                bw2 = new BackgroundWorker();
                bw2.WorkerReportsProgress = true;
                bw2.WorkerSupportsCancellation = true;

                bw2.DoWork += bw_HighDoWork;

                bw2.RunWorkerAsync();
                _autoResetEvent.Set();
                Thread.Sleep(1000);

                //=========================Run TS Queue
                bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_TSDoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                //bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bw.RunWorkerAsync();
                _autoResetEvent.Set();
                Thread.Sleep(1000);

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
                _autoResetEvent.Set();
                Thread.Sleep(1000);
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
                    int poll = 5;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    _autoResetEvent.Set();
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
                bw1.CancelAsync();
                bw2.CancelAsync();
                bwSec.CancelAsync();
                bwTimerJobs.CancelAsync();
                bwNotificationsJobs.CancelAsync();
                bwIntegrationJobs.CancelAsync();
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
                    if (bw1.CancellationPending)
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
                    _autoResetEvent.Set();
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
            if (mc.startTimer())
            {
                while (true)
                {
                    mc.runTimer();
                    if (bw2.CancellationPending)
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
                    _autoResetEvent.Set();
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
                    int poll = 5;
                    try
                    {
                        poll = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("PollingInterval"));
                    }
                    catch { }
                    _autoResetEvent.Set();
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
                    _autoResetEvent.Set();
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
                    _autoResetEvent.Set();
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
                    SPWebApplicationCollection _webapplications = GetWebApplications();
                    foreach (SPWebApplication webApp in _webapplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if (sConn != "")
                        {
                            try
                            {
                                using (SqlConnection cn = new SqlConnection(sConn))
                                {
                                    try
                                    {
                                        cn.Open();

                                        using (SqlCommand cmd = new SqlCommand("spQueueTimerJobs", cn))
                                        {
                                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    catch { e.Cancel = true; }
                                }
                            }
                            catch (Exception ex)
                            {
                                DateTime dt = DateTime.Now;

                                using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_QUEUE_" + dt.Year + dt.Month + dt.Day + ".log", true))
                                {
                                    swLog.WriteLine(DateTime.Now.ToString() + "\tERR\tQUEUE\t" + ex.Message);
                                }
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
                _autoResetEvent.Set();
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

            using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true))
            {
                swLog.WriteLine(DateTime.Now.ToString() + "\tINFO\tACTIVITY\tSTARTED");
            }
            while (true)
            {
                try
                {
                    SPWebApplicationCollection _webapplications = GetWebApplications();
                    foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if (sConn != "")
                        {
                            using (SqlConnection cn = new SqlConnection(sConn))
                            {
                                try
                                {
                                    cn.Open();

                                    using (SqlCommand cmd = new SqlCommand(@"select * from ActivityQueue where DATEDIFF(s, PostTime, GETDATE ()) > 10", cn))
                                    {
                                        DataSet ds = new DataSet();
                                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                        {
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

                                                    using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true))
                                                    {

                                                        swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tACTIVITY\t" + ex.Message);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { e.Cancel = true; }
                            }
                        }
                    }

                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    GC.Collect();
                    _autoResetEvent.Set();
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    dt = DateTime.Now;

                    using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ACTIVITY_" + dt.Year + dt.Month + dt.Day + ".log", true))
                    {
                        swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tACTIVITY\t" + ex.Message);
                    }
                    
                }

            }
        }

        static void bwNotificationsJobs_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
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
                                    DateTime dt = DateTime.Now;

                                    using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true))
                                    {

                                        swLog.WriteLine(DateTime.Now.ToString() + "\tERRM\tNOTIFICATIONS\t" + ex.Message);
                                    }
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
                    if (bw.CancellationPending)
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
                    _autoResetEvent.Set();
                    Thread.Sleep(poll * 60000);
                }
                catch (Exception ex)
                {
                    DateTime dt = DateTime.Now;

                    using (StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_NOTIFICATIONS_" + dt.Year + dt.Month + dt.Day + ".log", true))
                    {

                        swLog.WriteLine(DateTime.Now.ToString() + "\tERRO\tNOTIFICATIONS\t" + ex.Message);
                    }
                }
            }

        }
        public static SPWebApplicationCollection GetWebApplications()
        {
            return SPWebService.ContentService.WebApplications;
        }
        static void bwNotificationsJobs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
