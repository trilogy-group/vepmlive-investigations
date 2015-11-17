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
    class IntegrationClass
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
                for (int i = 0; i < _maxThreads; i++)
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

            logMessage("INIT", "STMR", "Starting Integration Queue");

            int maxThreads = 0;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("IntQueueThreads"));
            }
            catch (Exception e)
            {
                logMessage("INIT", "GTERR", "Unable to read thread value from Farm Settings");
                //logMessage("INIT", "GTERR", e.Message);
            }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting Integration Threads to: " + maxThreads);


            return true;
        }

        private void logMessage(string type, string module, string message)
        {
            lock (thisLock)
            {
                DateTime dt = DateTime.Now;

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\INTLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

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

        public bool startProcess(RunnerData dr)
        {
            try
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;

                bw.DoWork += bw_DoWork;
                //bw.ProgressChanged += bw_ProgressChanged;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;

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
            Thread.Sleep(2000);
            RunnerData rd = (RunnerData)e.Argument;
            DataRow dr = rd.dr;

            try
            {
                EPMLiveCore.API.Integration.IntegrationCore core = new EPMLiveCore.API.Integration.IntegrationCore(new Guid(dr["SITE_ID"].ToString()), new Guid(dr["WEB_ID"].ToString()));
                core.ExecuteEvent(dr);

                using (SqlConnection cn = new SqlConnection(rd.cn))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM INT_EVENTS WHERE INT_EVENT_ID=@id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                    //TODO: Remove line comment above
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("could not be found"))
                {
                    using (SqlConnection cn = new SqlConnection(rd.cn))
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM INT_EVENTS WHERE INT_EVENT_ID=@id", cn))
                        {
                            cmd.Parameters.AddWithValue("@id", dr["INT_EVENT_ID"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                }
                else
                {
                    logMessage("ERR", "PROCINT", ex.Message);
                }
            }
        }




        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void stopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }
    }
}
