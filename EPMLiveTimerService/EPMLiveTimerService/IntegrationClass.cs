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
        
        public override void runTimer()
        {
            try
            {
                SPWebApplicationCollection _webcolections = GetWebApplications();
                foreach (SPWebApplication webApp in _webcolections)
                {
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

                                        foreach (DataRow dr in ds.Tables[0].Rows)
                                        {
                                            RunnerData rd = new RunnerData();
                                            rd.cn = sConn;
                                            rd.dr = dr;
                                            if (startProcess(rd))
                                            {
                                                using (SqlCommand cmd1 = new SqlCommand("UPDATE INT_EVENTS set status=1 where INT_EVENT_ID=@id", cn))
                                                {
                                                    cmd1.Parameters.Clear();
                                                    cmd1.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }
                                            }
                                        }


                                        using (SqlCommand cmd2 = new SqlCommand("delete from INT_EVENTS where DateAdd(day, 1, EVENT_TIME) < GETDATE()", cn))
                                        {
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                logMessage("ERR", "RUNT", ex.Message);
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
            Thread.Sleep(2000);
            RunnerData rd = (RunnerData)e.Argument;
            DataRow dr = rd.dr;

            try
            {
                EPMLiveCore.API.Integration.IntegrationCore core = new EPMLiveCore.API.Integration.IntegrationCore(new Guid(dr["SITE_ID"].ToString()), new Guid(dr["WEB_ID"].ToString()));
                core.ExecuteEvent(dr);

                using (SqlConnection cn = new SqlConnection(rd.cn))
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
                    catch (Exception ex) { logMessage("ERR", "PROCINT", ex.Message); }


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
                            using (SqlCommand cmd = new SqlCommand("DELETE FROM INT_EVENTS WHERE INT_EVENT_ID=@id", cn))
                            {
                                cmd.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe) { logMessage("ERR", "PROCINT", exe.Message); }
                    }
                }
                else
                {
                    logMessage("ERR", "PROCINT", ex.Message);
                }
            }
        }
        
        protected override string LogName {
            get {
                return "INTLOG";
            }
        }
    }
}
