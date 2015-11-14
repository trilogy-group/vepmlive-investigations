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
    class RollupClass
    {
        private Object thisLock = new Object();

        public struct RunnerData
        {
            public string cn;
            public DataRow dr;
        }

        private class WorkerThreads
        {
            private BackgroundWorker[] _arrWorkers;
            private int _maxThreads;

            public WorkerThreads(int maxThreads)
            {
                _maxThreads = maxThreads;
                _arrWorkers = new BackgroundWorker[maxThreads];
            }

            public bool add(BackgroundWorker newBw)
            {
                for (int i = 0; i < _maxThreads;i++ )
                {
                    if (_arrWorkers[i] == null)
                    {
                        _arrWorkers[i] = newBw;
                        return true;
                    }
                }
                return false;
            }

            public int remainingThreads()
            {
                int counter = 0;
                foreach (BackgroundWorker bw in _arrWorkers)
                {
                    if (bw == null)
                        counter++;
                }
                return counter;
            }

            public void cleanup()
            {
                for (int i = 0; i < _maxThreads; i++)
                    if (_arrWorkers[i] != null)
                        if (!((BackgroundWorker)_arrWorkers[i]).IsBusy)
                            _arrWorkers[i] = null;
            }
        }

        private WorkerThreads workingThreads;

        public bool startTimer()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            logMessage("INIT", "STMR", "Starting Rollup Queue");

            int maxThreads = 5;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("RollupQueueThreads"));
            }
            catch (Exception e)
            {
                logMessage("INIT", "GTERR", e.Message);
            }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting threads to: " + maxThreads);

            logMessage("INIT", "STMR", "Clearing Queue");

            foreach(SPWebApplication webApp in SPWebService.ContentService.WebApplications)
            {
                string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                if(sConn != "")
                {
                    using (SqlConnection cn = new SqlConnection(sConn))
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("update rollupqueue set status = 0,queueserver=NULL  where status = 1 OR STATUS = 2", cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                }
            }

            return true;
        }

        private void logMessage(string type, string module, string message)
        {
            lock (thisLock)
            {
                DateTime dt = DateTime.Now;

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\ROLLUPLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

                swLog.WriteLine(DateTime.Now.ToString() + "\t" + type + "\t" + module + "\t" + message);

                swLog.Close();
            }
        }

        public void runTimer()
        {
            try
            {
                workingThreads.cleanup();
                int maxThreads = workingThreads.remainingThreads();
                if (maxThreads > 0)
                {

                    foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if (sConn != "")
                        {
                            using (SqlConnection cn = new SqlConnection(sConn))
                            {
                                cn.Open();

                                using (SqlCommand cmd = new SqlCommand("spRollupGetQueue", cn))
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
                                cn.Close();
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

        public bool startProcess(RunnerData dr)
        {
            try
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_DoWork;

                bw.RunWorkerAsync(dr);

                workingThreads.add(bw);

                return true;
            }
            catch (Exception ex)
            {
                logMessage("ERR", "STPR", ex.Message);
                return false;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
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
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("Update RollupQueue set Status = 3 where EventId=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", dr["EventId"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                using (SqlConnection cn = new SqlConnection(rd.cn))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE RollupQueue SET ErrorLog=@log, Status = 3 where EventId=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", dr["EventId"].ToString());
                        cmd.Parameters.AddWithValue("@log", ex.Message);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
        }

        
        public void stopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Rollup Queue");
        }
    }
}
