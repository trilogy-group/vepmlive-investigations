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
using System.Xml;

namespace TimerService
{
    public class TimerClass : ProcessorBase
    {
        bool highPriority = false;
		bool queueJobs = true;

        public TimerClass(bool highPriority, bool queueJobs = true)
        {
            this.highPriority = highPriority;
			this.queueJobs = queueJobs;
        }

        
        public override bool InitializeTask(CancellationToken token)
        {
            if (!base.InitializeTask(token))
                return false;

            LogMessage("INIT", "STMR", "Clearing Queue");
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
                            using (var cmd = new SqlCommand("update queue set status = 0, queueserver=NULL where status = 1 and DATEDIFF(HH,dtstarted,getdate()) > 24", cn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (var cmd1 = new SqlCommand("update queue set status = 0, queueserver=NULL where status = 1 and queueserver=@servername", cn))
                            {
                                cmd1.Parameters.Clear();
                                cmd1.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        catch
                        {
                            return false;
                        }

                    }
                }
            }

            return true;
        }
        DateTime lastRun = DateTime.Now;
        public override void RunTask()
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
                                if (queueJobs)
                                {
                                    DateTime newRun = DateTime.Now;
                                    if (newRun.Minute < lastRun.Minute)
                                    {
                                        using (SqlCommand cmd = new SqlCommand("spQueueTimerJobs", cn))
                                        {
                                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    lastRun = newRun.AddHours(1).AddMinutes(-newRun.Minute - 1);
                                }
                                
                                using (SqlCommand cmd = new SqlCommand("spTimerGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", maxThreads);
                                    cmd.Parameters.AddWithValue("@minPriority", highPriority? 0:10);
                                    cmd.Parameters.AddWithValue("@maxPriority", highPriority? 10:99);

                                    DataSet ds = new DataSet();
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                    {
                                        da.Fill(ds);
                                        int processed = 0;
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            RunnerData rd = new RunnerData();
                                            rd.cn = sConn;
                                            rd.dr = dr;
                                            
                                            if (startProcess(rd))
                                            {
                                                using (SqlCommand cmd1 = new SqlCommand("UPDATE queue set status=1, dtstarted = GETDATE() where queueuid=@id and status = 0", cn))
                                                {
                                                    cmd1.Parameters.Clear();
                                                    cmd1.Parameters.AddWithValue("@id", dr["queueuid"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }
                                            }
                                            processed++;
                                            token.ThrowIfCancellationRequested();
                                        }
                                        if (processed > 0) LogMessage("HTBT", "PRCS", "Queued " + processed + " jobs, running threads: " + RunningThreads);
                                    }
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
                LogMessage("ERR", "RUNT", ex.ToString());
            }
        }

        protected override void DoWork(object rd)
        {
            DataRow dr = ((RunnerData)rd).dr;

            try
            {
                using (SPSite site = new SPSite(new Guid(dr["siteguid"].ToString())))
                {
                    using (SPWeb web = site.OpenWeb(new Guid(dr["webguid"].ToString())))
                    {
                        MethodInfo m;

                        Assembly assemblyInstance = Assembly.Load(dr["NetAssembly"].ToString());
                        Type thisClass = assemblyInstance.GetType(dr["NetClass"].ToString());
                        object classObject = Activator.CreateInstance(thisClass);

                        thisClass.GetField("JobUid").SetValue(classObject, new Guid(dr["timerjobuid"].ToString()));
                        thisClass.GetField("QueueUid").SetValue(classObject, new Guid(dr["queueuid"].ToString()));
                        thisClass.GetField("queuetype").SetValue(classObject, int.Parse(dr["jobtype"].ToString()));
                        try
                        {

                            thisClass.GetField("ListUid").SetValue(classObject, new Guid(dr["listguid"].ToString()));
                        }
                        catch { }
                        try
                        {
                            thisClass.GetField("ItemID").SetValue(classObject, int.Parse(dr["itemid"].ToString()));
                        }
                        catch { }

                        try
                        {
                            thisClass.GetField("userid").SetValue(classObject, int.Parse(dr["userid"].ToString()));
                        }
                        catch { }

                        try
                        {
                            thisClass.GetField("key").SetValue(classObject, dr["key"].ToString());
                        }
                        catch { }

                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(dr["jobdata"].ToString());
                            thisClass.GetField("DocData").SetValue(classObject, doc);
                        }
                        catch { }

                        m = thisClass.GetMethod("initJob"); 
                        bool bInit = (bool)m.Invoke(classObject, new object[] { site });

                        try
                        {

                            m = thisClass.GetMethod("execute");
                            m.Invoke(classObject, new object[] { site, web, dr["jobdata"].ToString() });

                        }
                        catch (Exception ex)
                        {
                            thisClass.GetField("bErrors").SetValue(classObject, true);
                            thisClass.GetField("sErrors").SetValue(classObject, "General Error: " + ex.Message);
                        }

                        m = thisClass.GetMethod("finishJob");
                        m.Invoke(classObject, new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("could not be found"))
                {
                    using (SqlConnection cn = new SqlConnection(((RunnerData)rd).cn))
                    {
                        try
                        {
                            cn.Open();
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM TIMERJOBS WHERE siteguid=@siteguid", cn))
                            {
                                cmd.Parameters.AddWithValue("@siteguid", dr["siteguid"].ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe)
                        {
                            LogMessage("ERR", "PROC", exe.Message);
                        }
                    }
                }
                else
                {
                    LogMessage("ERR", "PROC", ex.Message);
                }
            }
        }

        protected override string LogName {
            get {
                return highPriority ? "HTIMERLOG" : "TIMERLOG";
            }
        }
        protected override string ThreadsProperty {
            get {
                return highPriority ? "HighQueueThreads" : "QueueThreads";
            }
        }

    }
}
