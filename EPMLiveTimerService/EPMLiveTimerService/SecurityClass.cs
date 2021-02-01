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
    public class SecurityClass : ProcessorBase
    {


        public override void InitializeTask(CancellationToken token)
        {
            base.InitializeTask(token);
              
            //EPML-5787
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
                            using (var cmd = new SqlCommand("update ITEMSEC set status = 0, queue=NULL where DATEDIFF(HH,dtadded,getdate()) > 24 and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                            using (var cmd1 = new SqlCommand("update ITEMSEC set status = 0, queue=NULL  where queue=@servername and (status = 1 OR STATUS = 2)", cn))
                            {
                                cmd1.Parameters.Clear();
                                cmd1.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        catch (Exception exe) { LogMessage("ERR", "Starttimer", exe.Message); }
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
                        using (var cn = new SqlConnection(sConn))
                        {
                            try
                            {
                                cn.Open();

                                using (var cmd = new SqlCommand("spSecGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", maxThreads);

                                    var ds = new DataSet();
                                    using (var da = new SqlDataAdapter(cmd))
                                    {
                                        da.Fill(ds);
                                        if (ds.Tables.Count > 0)
                                        {
                                            int processed = 0;
                                            foreach (DataRow dr in ds.Tables[0].Rows)
                                            {
                                                var rd = new RunnerData { cn = sConn, dr = dr };
                                               
                                                if (startProcess(rd))
                                                {
                                                    using (var cmd1 = new SqlCommand("UPDATE ITEMSEC set status=2 where ITEM_SEC_ID=@id and status = 1", cn))
                                                    {
                                                        cmd1.Parameters.Clear();
                                                        cmd1.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
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
                            }
                            catch (Exception ex) when (!(ex is OperationCanceledException))
                            { LogMessage("ERR", "RUN", ex.Message); }



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

            try
            {
                var secJob = new EPMLiveCore.Jobs.SecurityUpdate();
                var listUid = new Guid(dr["LIST_ID"].ToString());
                int itemID = int.Parse(dr["ITEM_ID"].ToString());
                int userid = int.Parse(dr["USER_ID"].ToString());

                using (var site = new SPSite(new Guid(dr["SITE_ID"].ToString())))
                {
                    using (SPWeb web = site.OpenWeb(new Guid(dr["WEB_ID"].ToString())))
                    {
                        secJob.execute(site, web, listUid, itemID, userid, string.Empty);
                    }
                }


                using (var cn = new SqlConnection(((RunnerData)rd).cn))
                {
                    try
                    {
                        cn.Open();
                        using (var cmd = new SqlCommand("Update ITEMSEC set status=3, finishdate = GETDATE() where ITEM_SEC_ID=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exe) { LogMessage("ERR", "RUN", exe.Message); }


                }
            }
            catch (Exception ex)
            {
                using (var cn = new SqlConnection(((RunnerData)rd).cn))
                {
                    try
                    {
                        cn.Open();
                        using (var cmd = new SqlCommand("UPDATE ITEMSEC SET resulttext=@resulttext, Status = 3, finishdate=GETDATE() where ITEM_SEC_ID=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                            cmd.Parameters.AddWithValue("@resulttext", ex.Message);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exe) { LogMessage("ERR", "RUN", exe.Message); }
                }
            }


        }
        protected override string LogName {
            get {
                return "SECLOG";
            }
        }
        protected override string ThreadsProperty {
            get {
                return "SecQueueThreads";
            }
        }

    }
}
