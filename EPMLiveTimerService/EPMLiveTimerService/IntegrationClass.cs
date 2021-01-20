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
    public class IntegrationClass : ProcessorBase
    {
        
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
                                using (SqlCommand cmd = new SqlCommand("spINTGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
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
                                                using (SqlCommand cmd1 = new SqlCommand("UPDATE INT_EVENTS set status=1 where INT_EVENT_ID=@id and status=0", cn))
                                                {
                                                    cmd1.Parameters.Clear();
                                                    cmd1.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }
                                                
                                            }
                                            processed++;
                                            token.ThrowIfCancellationRequested();
                                        }
                                        if (processed > 0) LogMessage("HTBT", "PRCS", "Queued " + processed + " jobs, running threads: " + RunningThreads);

                                        using (SqlCommand cmd2 = new SqlCommand("delete from INT_EVENTS where DateAdd(day, 1, EVENT_TIME) < GETDATE()", cn))
                                        {
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex) when (!(ex is OperationCanceledException))
                            {
                                LogMessage("ERR", "RUNT", ex.Message);
                            }
                        }

                    }

                }

            }
            catch (Exception ex) when (!(ex is OperationCanceledException))
            {
                LogMessage("ERR", "RUNT", ex.Message);
            }
        }
        
        protected override void DoWork(object rd)
        {
            DataRow dr = ((RunnerData)rd).dr;

            try
            {
                EPMLiveCore.API.Integration.IntegrationCore core = new EPMLiveCore.API.Integration.IntegrationCore(new Guid(dr["SITE_ID"].ToString()), new Guid(dr["WEB_ID"].ToString()));
                core.ExecuteEvent(dr);

                using (SqlConnection cn = new SqlConnection(((RunnerData)rd).cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM INT_EVENTS WHERE INT_EVENT_ID=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        //TODO: Remove line comment above
                    }
                    catch (Exception ex) { LogMessage("ERR", "PROCINT", ex.Message); }


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
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM INT_EVENTS WHERE INT_EVENT_ID=@id", cn))
                            {
                                cmd.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe) { LogMessage("ERR", "PROCINT", exe.Message); }
                    }
                }
                else
                {
                    LogMessage("ERR", "PROCINT", ex.Message);
                }
            }
        }
        
        protected override string LogName {
            get {
                return "INTLOG";
            }
        }
        protected override string ThreadsProperty {
            get {
                return "IntQueueThreads";
            }
        }
    }
}
