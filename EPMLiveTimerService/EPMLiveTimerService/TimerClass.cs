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
    public class TimerClass
    {
        private Object thisLock = new Object();

        public struct RunnerData
        {
            public string cn;
            public DataRow dr;
        }

        public class WorkerThreads
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

        public WorkerThreads WorkingThreads
        {
            get { return workingThreads; }
            set { workingThreads = value; }
        }

        public bool startTimer()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS");
            }
            catch { }

            //try
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TEMP");
            //}
            //catch { }

            //try
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TEMP\\IMPORT");
            //}
            //catch { }

            logMessage("INIT", "STMR", "Starting Timer Service");

            int maxThreads = 0;
            try
            {
                maxThreads = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("QueueThreads"));
            }
            catch (Exception e)
            {
                logMessage("INIT", "GTERR", "Unable to read default thread value from Farm Settings");
                //logMessage("INIT", "GTERR", e.Message);
            }
            workingThreads = new WorkerThreads(maxThreads);

            logMessage("INIT", "STMR", "Setting threads to: " + maxThreads);

            logMessage("INIT", "STMR", "Clearing Queue");

            foreach (SPWebApplication webApp in SPWebService.ContentService.WebApplications)
            {
                var sConn = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);
                if (sConn != "")
                {
                    using (var cn = new SqlConnection(sConn))
                    {
                        cn.Open();
                        using (var cmd = new SqlCommand("update queue set status = 0, queueserver=NULL where status = 1 and DATEDIFF(HH,dtstarted,getdate()) > 24", cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd1 = new SqlCommand("update queue set status = 0, queueserver=NULL where status = 1 and queueserver=@servername", cn))
                        {
                            cmd1.Parameters.Clear();
                            cmd1.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                            cmd1.ExecuteNonQuery();
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

                StreamWriter swLog = new StreamWriter(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\LOGS\\TIMERLOG_" + dt.Year + dt.Month + dt.Day + ".log", true);

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
                                //using (SqlCommand cmd = new SqlCommand("SELECT TOP " + maxThreads + " queueuid,timerjobuid,siteguid,webguid,listguid,itemid,jobtype,jobdata,userid,netassembly,netclass,title,[key] from vwQueueTimer where status=0 and priority > 10 order by priority,dtcreated asc", cn))
                                using (SqlCommand cmd = new SqlCommand("spTimerGetQueue", cn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@servername", System.Environment.MachineName);
                                    cmd.Parameters.AddWithValue("@maxthreads", maxThreads);
                                    cmd.Parameters.AddWithValue("@minPriority", 10);
                                    cmd.Parameters.AddWithValue("@maxPriority", 99);

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
                                                using (SqlCommand cmd1 = new SqlCommand("UPDATE queue set status=1, dtstarted = GETDATE() where queueuid=@id", cn))
                                                {
                                                    cmd1.Parameters.Clear();
                                                    cmd1.Parameters.AddWithValue("@id", dr["queueuid"].ToString());
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
                logMessage("ERR", "RUNT", ex.ToString());
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
                    using (SqlConnection cn = new SqlConnection(rd.cn))
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM TIMERJOBS WHERE siteguid=@siteguid", cn))
                        {
                            cmd.Parameters.AddWithValue("@siteguid", dr["siteguid"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                        cn.Close();
                    }
                }
                else
                {
                    logMessage("ERR", "PROC", ex.Message);
                }
            }
        }

        static void bw_GenericJob(DataRow dr)
        {
            //try
            //{
            using (SPSite site = new SPSite(new Guid(dr["siteguid"].ToString())))
            {
                using (SPWeb web = site.OpenWeb(new Guid(dr["webguid"].ToString())))
                {
                    MethodInfo m;

                    Assembly assemblyInstance = Assembly.Load(dr["NetAssembly"].ToString());
                    Type thisClass = assemblyInstance.GetType(dr["NetClass"].ToString());
                    object classObject = Activator.CreateInstance(thisClass);

                    thisClass.GetField("JobUid").SetValue(classObject, new Guid(dr["timerjobuid"].ToString()));
                    thisClass.GetField("QueueUid").SetValue(classObject, new Guid(dr["queueuid"].ToString()));
                    thisClass.GetField("queuetype").SetValue(classObject, int.Parse(dr["jobtype"].ToString()));
                    try
                    {

                        thisClass.GetField("ListUid").SetValue(classObject, new Guid(dr["listguid"].ToString()));
                    }
                    catch { }
                    try
                    {
                        thisClass.GetField("ItemID").SetValue(classObject, int.Parse(dr["itemid"].ToString()));
                    }
                    catch { }

                    try
                    {
                        thisClass.GetField("userid").SetValue(classObject, int.Parse(dr["userid"].ToString()));
                    }
                    catch { }

                    try
                    {
                        thisClass.GetField("key").SetValue(classObject, dr["key"].ToString());
                    }
                    catch { }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(dr["jobdata"].ToString());
                        thisClass.GetField("DocData").SetValue(classObject, doc);
                    }
                    catch { }

                    m = thisClass.GetMethod("initJob");
                    bool bInit = (bool)m.Invoke(classObject, new object[] { site });

                    try
                    {

                        m = thisClass.GetMethod("execute");
                        m.Invoke(classObject, new object[] { site, web, dr["jobdata"].ToString() });

                    }
                    catch (Exception ex)
                    {
                        thisClass.GetField("bErrors").SetValue(classObject, true);
                        thisClass.GetField("sErrors").SetValue(classObject, "General Error: " + ex.Message);
                    }

                    m = thisClass.GetMethod("finishJob");
                    m.Invoke(classObject, new object[] { });
                }
            }
            //}
            //catch(Exception ex)
            //{
            //    if(ex.Message.Contains("could not be found"))
            //    {
            //        SqlConnection cn = new SqlConnection(rd.cn);
            //        cn.Open();
            //        SqlCommand cmd = new SqlCommand("DELETE FROM TIMERJOBS WHERE siteguid=@siteguid", cn);
            //        cmd.Parameters.AddWithValue("@siteguid", dr["siteguid"].ToString());
            //        cmd.ExecuteNonQuery();
            //        cn.Close();
            //    }
            //    else
            //    {
            //        logMessage("ERR", "PROC", ex.Message);
            //    }
            //}
        }



        //static void bw_processListSynch(DataRow dr)
        //{
        //    Syncher oSyncher = new Syncher();
        //    oSyncher.JobUid = new Guid(dr["timerjobuid"].ToString());
        //    oSyncher.QueueUid = new Guid(dr["queueuid"].ToString());
        //    oSyncher.queuetype = int.Parse(dr["jobtype"].ToString());

        //    using (SPSite site = new SPSite(new Guid(dr["siteguid"].ToString())))
        //    {
        //        using (SPWeb web = site.OpenWeb(new Guid(dr["webguid"].ToString())))
        //        {
        //            if (oSyncher.initJob(site))
        //            {
        //                try
        //                {
        //                    SPList list = web.Lists[new Guid(dr["listguid"].ToString())];

        //                    oSyncher.CreateNewList = false;
        //                    try
        //                    {
        //                        string creatnew = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncCreateNew-" + System.IO.Path.GetDirectoryName(list.DefaultView.ServerRelativeUrl));
        //                        if (creatnew == "")
        //                            oSyncher.CreateNewList = false;
        //                        else
        //                            oSyncher.CreateNewList = bool.Parse(creatnew);
        //                    }
        //                    catch { }
        //                    oSyncher.FromWeb = web;
        //                    string sList = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveSyncAltListName-" + System.IO.Path.GetDirectoryName(list.DefaultView.ServerRelativeUrl));
        //                    if (sList == "")
        //                        sList = list.Title;

        //                    oSyncher.execute(web, list, sList);
        //                }
        //                catch (Exception ex)
        //                {
        //                    oSyncher.bErrors = true;
        //                    oSyncher.sErrors = "General Error: " + ex.Message;
        //                }
        //                oSyncher.finishJob();
        //            }
        //        }
        //    }
        //}


        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void stopTimer()
        {
            logMessage("STOP", "STMR", "Stopped Timer Service");
        }
    }
}
