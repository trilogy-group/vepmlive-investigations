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
                for(int i = 0; i < _maxThreads; i++)
                {
                    if(_arrWorkers[i] == null)
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
                foreach(BackgroundWorker bw in _arrWorkers)
                {
                    if(bw == null)
                        counter++;
                }
                return counter;
            }

            public void cleanup()
            {
                for(int i = 0; i < _maxThreads; i++)
                    if(_arrWorkers[i] != null)
                        if(!((BackgroundWorker)_arrWorkers[i]).IsBusy)
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

            logMessage("INIT", "STMR", "Starting Security Queue");

            int maxThreads = 5;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("SecQueueThreads"));
            }
            catch { }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting Security Threads to: " + maxThreads);


            return true;
        }

        private void logMessage(string type, string module, string message)
        {
            lock(thisLock)
            {
                DateTime dt = DateTime.Now;

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\SECLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

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
                if(maxThreads > 0)
                {

                    foreach(SPWebApplication webApp in SPWebService.ContentService.WebApplications)
                    {
                        string sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                        if(sConn != "")
                        {
                            SqlConnection cn = new SqlConnection(sConn);
                            cn.Open();
                            
                            SqlCommand cmd = new SqlCommand("spSecGetQueue", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                            cmd.Parameters.AddWithValue("@maxthreads", maxThreads);

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);

                            foreach(DataRow dr in ds.Tables[0].Rows)
                            {
                                try
                                {
                                    EPMLiveCore.Jobs.SecurityUpdate sec = new EPMLiveCore.Jobs.SecurityUpdate();
                                    Guid ListUid = new Guid(dr["LIST_ID"].ToString());
                                    int ItemID = int.Parse(dr["ITEM_ID"].ToString());
                                    int userid = int.Parse(dr["USER_ID"].ToString());

                                    using(SPSite site = new SPSite(new Guid(dr["SITE_ID"].ToString())))
                                    {
                                        using(SPWeb web = site.OpenWeb(new Guid(dr["WEB_ID"].ToString())))
                                        {
                                            sec.execute(site, web, ListUid, ItemID, userid, "");
                                        }
                                    }

                                }
                                catch { }

                                cmd = new SqlCommand("delete from ITEMSEC where ITEM_SEC_ID=@id", cn);
                                cmd.Parameters.AddWithValue("@id", dr["ITEM_SEC_ID"].ToString());
                                cmd.ExecuteNonQuery();
                            }

                            cn.Close();
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                logMessage("ERR", "RUN", ex.Message);
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
