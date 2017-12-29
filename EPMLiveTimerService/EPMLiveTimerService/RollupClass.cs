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
    public class RollupClass : ProcessorBase
    {


        public override bool startTimer()
        {
            if (!base.startTimer())
                return false;

            logMessage("INIT", "STMR", "Clearing Queue");
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
                            using (var cmd = new SqlCommand("update rollupqueue set status = 0, queueserver=NULL  where DATEDIFF(HH,EVENTTIME,getdate()) > 24 and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (var cmd1 = new SqlCommand("update rollupqueue set status = 0, queueserver=NULL  where queueserver=@servername and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd1.Parameters.Clear();
                                cmd1.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        catch { return false; }
                    }
                }
            }

            return true;
        }


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

                                using (SqlCommand cmd = new SqlCommand("spRollupGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", MaxThreads);

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
                                                using (SqlCommand cmd1 = new SqlCommand("UPDATE ROLLUPQUEUE set status=2 where eventid=@id", cn))
                                                {
                                                    cmd1.Parameters.Clear();
                                                    cmd1.Parameters.AddWithValue("@id", dr["eventid"].ToString());
                                                    cmd1.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                logMessage("ERR", "RUNT", ex.ToString());
                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                logMessage("ERR", "RUNT", ex.ToString());
            }
        }

        protected override void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(200);
            RunnerData rd = (RunnerData)e.Argument;
            DataRow dr = rd.dr;

            try
            {
                using (SPSite site = new SPSite(new Guid(dr["SiteId"].ToString())))
                {
                    using (SPWeb web = site.OpenWeb(new Guid(dr["WebId"].ToString())))
                    {
                        EPMLiveCore.Jobs.RollupJob job = new EPMLiveCore.Jobs.RollupJob();
                        job.Execute(web, new Guid(dr["ListId"].ToString()), int.Parse(dr["ItemId"].ToString()));
                    }
                }

                using (SqlConnection cn = new SqlConnection(rd.cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("Update RollupQueue set Status = 3 where EventId=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["EventId"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        logMessage("ERR", "RUNT", ex.ToString());
                    }


                }
            }
            catch (Exception ex)
            {
                using (SqlConnection cn = new SqlConnection(rd.cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE RollupQueue SET ErrorLog=@log, Status = 3 where EventId=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["EventId"].ToString());
                            cmd.Parameters.AddWithValue("@log", ex.Message);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exe)
                    {
                        logMessage("ERR", "RUNT", exe.ToString());
                    }
                }
            }
        }


        protected override string LogName {
            get {
                return "ROLLUPLOG";
            }
        }
    }
}
