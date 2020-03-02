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
    class TimesheetTimerClass : ProcessorBase
    {
        public override bool InitializeTask(CancellationToken token)
        {
            if (!base.InitializeTask(token))
                return false;

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

            return true;
        }

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

                                using (SqlCommand cmd = new SqlCommand("spTSGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", maxThreads);

                                    DataSet ds = new DataSet();
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                    {
                                        da.Fill(ds);
                                        int processed = 0;
                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {

                                            var rd = new RunnerData { cn = sConn, dr = dr };
                                            
                                            if (startProcess(rd))
                                            {
                                                using (var cmd1 = new SqlCommand("UPDATE TSqueue set status=2 where tsqueue_id=@id and status = 1", cn))
                                                {
                                                    cmd1.Parameters.AddWithValue("@id", dr["tsqueue_id"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }
                                                
                                            }
                                            processed++;
                                            token.ThrowIfCancellationRequested();
                                        }
                                        if (processed > 0) LogMessage("HTBT", "PRCS", "Processed " + processed + " jobs");
                                    }

                                    using (var cmd1 = new SqlCommand("delete from TSqueue where DateAdd(day, 1, dtfinished) < GETDATE()", cn))
                                    {
                                        cmd1.ExecuteNonQuery();
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
                LogMessage("ERR", "RUN", ex.Message);
            }
        }

        protected override void DoWork(RunnerData rd)
        {
            DataRow dr = rd.dr;

            try
            {
                using (SPSite site = new SPSite(new Guid(dr["SITE_UID"].ToString())))
                {

                    MethodInfo m;

                    Assembly assemblyInstance = Assembly.Load(dr["NetAssembly"].ToString());
                    Type thisClass = assemblyInstance.GetType(dr["NetClass"].ToString());
                    object classObject = Activator.CreateInstance(thisClass);

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
						LogMessage("ERR", "PROC", error);
					}

					m = thisClass.GetMethod("finishJob");
                    m.Invoke(classObject, new object[] { });

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("could not be found"))
                {
                    using (SqlConnection cn = new SqlConnection(rd.cn))
                    {
                        try
                        {
                            cn.Open();
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM TSQUEUE WHERE TSQUEUE_ID=@id", cn))
                            {
                                cmd.Parameters.AddWithValue("@id", dr["TSQUEUE_ID"].ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe) { LogMessage("ERR", "PROC", exe.Message); }
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
