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
    class SecurityClass
    {
        private Object thisLock = new Object();
        private static Object qLock = new Object();

        public struct RunnerData
        {
            public string cn;
            public DataRow dr;
            public int index;
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

            public int add(BackgroundWorker newBw)
            {
                lock (qLock)
                {
                    for (int i = 0; i < _maxThreads; i++)
                    {
                        if (_arrWorkers[i] == null)
                        {
                            _arrWorkers[i] = newBw;
                            return i;
                        }
                    }
                }
                return -1;
            }

            public int remainingThreads()
            {
                int counter = 0;
                lock (qLock)
                {
                    foreach (BackgroundWorker bw in _arrWorkers)
                    {
                        if (bw == null)
                            counter++;
                    }
                }
                return counter;
            }

            public void remove(int i)
            {
                lock (qLock)
                {
                    _arrWorkers[i] = null;
                }
            }

            public void cleanup()
            {
                for (int i = 0; i < _maxThreads; i++)
                    if (_arrWorkers[i] != null)
                        if (!((BackgroundWorker)_arrWorkers[i]).IsBusy)
                            _arrWorkers[i] = null;
            }
        }

        private static WorkerThreads workingThreads;

        public bool startTimer()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            logMessage("INIT", "STMR", "Starting Security Queue");

            int maxThreads = 5;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("SecQueueThreads"));
            }
            catch (Exception e)
            {
                logMessage("INIT", "GTERR", e.Message);
            }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting Security Threads to: " + maxThreads);

            //EPML-5787
            logMessage("INIT", "STMR", "Clearing Queue");

            foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
            {
                string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                if (sConn != "")
                {
                    using (SqlConnection cn = new SqlConnection(sConn))
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("update ITEMSEC set status = 0, queue=NULL  where status = 1 OR STATUS = 2", cn))
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

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\SECLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

                swLog.WriteLine(DateTime.Now.ToString() + "\t" + type + "\t" + module + "\t" + message);

                swLog.Close();
            }
        }

        //private void logMessageinDatabase(string itemsecid, string message, SqlConnection cn)
        //{
        //    SqlCommand cmd = new SqlCommand("UPDATE ITEMSEC SET STATUS = 2,resulttext = @errortext where ITEM_SEC_ID=@id", cn);
        //    cmd.Parameters.AddWithValue("@errortext", message);
        //    cmd.Parameters.AddWithValue("@id", itemsecid);
        //    cmd.ExecuteNonQuery();
        //}

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
                            using (var cn = new SqlConnection(sConn))
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
                                            foreach (DataRow dr in ds.Tables[0].Rows)
                                            {
                                                var rd = new RunnerData {cn = sConn, dr = dr};
                                                if (startProcess(rd))
                                                {
                                                    using (var cmd1 = new SqlCommand("UPDATE ITEMSEC set status=2 where ITEM_SEC_ID=@id", cn))
                                                    {
                                                        cmd1.Parameters.Clear();
                                                        cmd1.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                                                        cmd1.ExecuteNonQuery();
                                                    }
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
                logMessage("ERR", "RUN", ex.Message);
            }
        }

        //public bool startProcess(DataRow dr, SqlConnection cn)
        public bool startProcess(RunnerData dr)
        {
            try
            {
                var bw = new BackgroundWorker {WorkerReportsProgress = true, WorkerSupportsCancellation = true};

                bw.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                //bw.RunWorkerCompleted += bw_RunWorkerCompleted;

                bw.RunWorkerAsync(dr);

                workingThreads.add(bw);

                //RunnerData d = new RunnerData();
                //d.cn = cn.ConnectionString;
                //d.dr = dr;
                //d.index = workingThreads.add(bw);

                //if (d.index > -1)
                //{
                //    using (SqlCommand cmd = new SqlCommand("UPDATE ITEMSEC SET STATUS = 1 where ITEM_SEC_ID=@id", cn))
                //    {
                //        cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                //        cmd.ExecuteNonQuery();
                //    }

                //    bw.RunWorkerAsync(d);

                //}

                return true;
            }
            catch (Exception ex)
            {
                logMessage("ERR", "STPR", ex.Message);
                //logMessageinDatabase(dr["ITEM_SEC_ID"].ToString(), ex.Message, cn);
                return false;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            var rd = (RunnerData)e.Argument;
            DataRow dr = rd.dr;

            try
            {
                //try
                //{
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
                //}
                //catch (Exception ex)
                //{
                //    logMessageinDatabase(dr["ITEM_SEC_ID"].ToString(), ex.Message, cn);
                //}

                using (var cn = new SqlConnection(rd.cn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("Update ITEMSEC set status=3, finishdate = GETDATE() where ITEM_SEC_ID=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                using (var cn = new SqlConnection(rd.cn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("UPDATE ITEMSEC SET resulttext=@resulttext, Status = 3, finishdate=GETDATE() where ITEM_SEC_ID=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                        cmd.Parameters.AddWithValue("@resulttext", ex.Message);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }
            }

            //workingThreads.remove(rd.index);
        }


        //static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //}

        public void stopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }
    }
}
