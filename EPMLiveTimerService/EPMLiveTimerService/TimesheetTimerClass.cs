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
using System.Configuration;

namespace TimerService
{
    class TimesheetTimerClass : ProcessorBase
    {
        public override void InitializeTask(CancellationToken token)
        {
            base.InitializeTask(token);

            SPWebApplicationCollection _webcolections = GetWebApplications();
            foreach (SPWebApplication webApp in _webcolections)
            {
                var sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                if (sConn != "")
                {
                    using (var cn = new SqlConnection(sConn))
                    {
                        try
                        {
                            cn.Open();
                            using (var cmd = new SqlCommand("update TSqueue set status = 0, queue = NULL where DATEDIFF(HH,DTSTARTED,getdate()) > 24 and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (var cmd1 = new SqlCommand("update TSqueue set status = 0, queue = NULL where (queue=@servername OR QUEUE like '%-'  + @servername) and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd1.Parameters.Clear();
                                cmd1.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe) { LogMessage("ERR", "RUN", exe.Message); }
                    }
                }
            }
        }

        public override void ProcessJobs()
        {
            try
            {
                SPWebApplicationCollection webApps = GetWebApplications();
                foreach (SPWebApplication webApp in webApps)
                {
                    int maxThreads = MaxThreads;
                    if (maxThreads <= 0)
                        continue;
                    string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                    if (sConn != "")
                    {
                        using (SqlConnection cn = new SqlConnection(sConn))
                        {
                            try
                            {
                                cn.Open();
                                int processed = 0;
                                using (SqlCommand cmd = new SqlCommand("spTSGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", maxThreads);

                                    DataSet ds = new DataSet();
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                    {
                                        da.Fill(ds);

                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {

                                            var rd = new RunnerData { cn = sConn, dr = dr };
                                            string queue = dr["queue"].ToString();
                                            int trial = 1;
                                            if (int.TryParse(queue.Substring(0,1), out trial))
                                            {
                                                trial++;
                                            }
                                            if (startProcess(rd, trial))
                                            {
                                                using (var cmd1 = new SqlCommand("UPDATE TSqueue set status=2,DTSTARTED=ISNULL(DTSTARTED,GETDATE()) where tsqueue_id=@id and status = 1", cn))
                                                {
                                                    cmd1.Parameters.AddWithValue("@id", dr["tsqueue_id"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }

                                            }
                                            processed++;
                                            token.ThrowIfCancellationRequested();
                                        }
                                    }
                                }
                                if (processed > 0)
                                    LogMessage("HTBT", "PRCS", "Requested " + maxThreads + " Queued " + processed + " jobs, running threads: " + RunningThreads);
                                else if (RunningThreads == 0)
                                {
                                    using (SqlCommand cmd = new SqlCommand(@";
                                                with oldestAborted as 
                                                (select TOP 1 * from tsqueue where status = 3 and resulttext like '%aborted%')
                                                update oldestAborted set status=0,queue=CAST((TRY_PARSE(SUBSTRING(QUEUE, 1, 1) AS INT) - 1) AS nvarchar(1)) + '-' +  @servername
                                                ", cn))
                                    {
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                using (var cmd1 = new SqlCommand("delete from TSqueue where DateAdd(day, 1, dtfinished) < GETDATE()", cn))
                                {
                                    cmd1.ExecuteNonQuery();
                                }

                            }
                            catch (Exception ex) when (!(ex is OperationCanceledException))
                            {
                                LogMessage("ERR", "RUNT", ex.ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                LogMessage("ERR", "RUN", ex.Message);
            }
        }

        protected override void DoWork(object rd)
        {
            DataRow dr = ((RunnerData)rd).dr;
            using (SPSite site = new SPSite(new Guid(dr["SITE_UID"].ToString())))
            {

                MethodInfo m;

                Assembly assemblyInstance = Assembly.Load(dr["NetAssembly"].ToString());
                Type thisClass = assemblyInstance.GetType(dr["NetClass"].ToString());
                object classObject = Activator.CreateInstance(thisClass);

                try
                {

                    thisClass.GetField("QueueUid").SetValue(classObject, new Guid(dr["TSQUEUE_ID"].ToString()));
                    thisClass.GetField("TSUID").SetValue(classObject, new Guid(dr["TS_UID"].ToString()));
                    thisClass.GetField("jobtype").SetValue(classObject, int.Parse(dr["jobtype_id"].ToString()));

                    try
                    {
                        thisClass.GetField("userid").SetValue(classObject, int.Parse(dr["userid"].ToString()));
                    }
                    catch { }

                    m = thisClass.GetMethod("initJob");
                    bool bInit = (bool)m.Invoke(classObject, new object[] { site });

                    try
                    {
                        m = thisClass.GetMethod("execute");
                        m.Invoke(classObject, new object[] { site, dr["JOBDATA"].ToString() });
                    }
                    catch (Exception ex)
                    {
                        thisClass.GetField("bErrors").SetValue(classObject, true);
                        thisClass.GetField("sErrors").SetValue(classObject, "General Error: " + ex.Message);
                    }
                    if ((bool)thisClass.GetField("bErrors").GetValue(classObject))
                    {
                        string error = (string)thisClass.GetField("sErrors").GetValue(classObject);
                        LogMessage("ERROR", "PROC", error);
                    }
                    LogMessage("PASS", "EXEC", "Job Successfully Finished");

                }
                catch (ThreadAbortException e)
                {
                    string queue = dr["queue"].ToString();
                    int trial = 1;
                    if (int.TryParse(queue.Substring(0, 1), out trial))
                    {
                        trial++;
                    }
                    thisClass.GetField("bErrors").SetValue(classObject, true);

                    thisClass.GetField("sErrors").SetValue(classObject, "Aborted after " + Timeout * trial + " minutes");
                    LogMessage("ERROR", "EXEC", "Job Gracefully Finished:" + e.StackTrace.Replace('\n','|'));
                }
                catch (Exception ex)
                {
                    LogMessage("ERR", "PROC", ex.Message);
                }
                finally
                {
                    m = thisClass.GetMethod("finishJob");
                    m.Invoke(classObject, new object[] { });
                }
            }
        }

        static int? timeout;
        protected override int Timeout
        {
            get
            {
                if (timeout == null)
                {
                    int configTimeout;
                    if (!int.TryParse(ConfigurationManager.AppSettings["TimesheetTimeout"], out configTimeout))
                    {
                        timeout = 10;
                    }
                    else
                    {
                        timeout = configTimeout;
                    }
                }
                return timeout.Value;
            }
        }
     

        protected override string LogName {
            get {
                return "TSLOG";
            }
        }
        protected override string ThreadsProperty {
            get {
                return "TSQueueThreads";
            }
        }
    }
}
