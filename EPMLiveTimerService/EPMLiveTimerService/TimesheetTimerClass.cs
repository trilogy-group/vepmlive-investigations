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
    class TimesheetTimerClass
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

            logMessage("INIT", "STMR", "Starting Timesheet Queue");

            int maxThreads = 5;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("TSQueueThreads"));
            }
            catch { }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting threads to: " + maxThreads);

            
            return true;
        }

        private void logMessage(string type, string module, string message)
        {
            lock (thisLock)
            {
                DateTime dt = DateTime.Now;

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TSLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

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
                            SqlConnection cn = new SqlConnection(sConn);
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("SELECT TOP " + maxThreads + " * from vwTSQueue where status=0 order by dtcreated asc", cn);
                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                RunnerData rd = new RunnerData();
                                rd.cn = sConn;
                                rd.dr = dr;
                                if (startProcess(rd))
                                {
                                    cmd = new SqlCommand("UPDATE TSqueue set status=1,dtstarted = GETDATE() where tsqueue_id=@id", cn);
                                    cmd.Parameters.AddWithValue("@id", dr["tsqueue_id"].ToString());
                                    cmd.ExecuteNonQuery();
                                }
                            }


                            cmd = new SqlCommand("delete from TSqueue where DateAdd(day, 1, dtfinished) < GETDATE()", cn);
                            cmd.ExecuteNonQuery();

                            cn.Close();


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
                bw_GenericJob(dr);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("could not be found"))
                {
                    SqlConnection cn = new SqlConnection(rd.cn);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM TSQUEUE WHERE TSQUEUE_ID=@id", cn);
                    cmd.Parameters.AddWithValue("@id", dr["TSQUEUE_ID"].ToString());
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    logMessage("ERR", "PROC", ex.Message);
                }
            }
        }

        static void bw_GenericJob(DataRow dr)
        {
            try
            {
                using(SPSite site = new SPSite(new Guid(dr["SITE_UID"].ToString())))
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
                        catch(Exception ex)
                        {
                            thisClass.GetField("bErrors").SetValue(classObject, true);
                            thisClass.GetField("sErrors").SetValue(classObject, "General Error: " + ex.Message);
                        }

                        m = thisClass.GetMethod("finishJob");
                        m.Invoke(classObject, new object[] { });
                    
                }
            }
            catch(Exception ex)
            {
                //TODO: Log Error
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
