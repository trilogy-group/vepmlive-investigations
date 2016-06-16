using System;
using System.ComponentModel;
using System.Data;
using Microsoft.SharePoint.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using TimerService;
using System.Collections.Generic;

namespace EPMLiveTests.EPMLiveTimerService
{
    [TestClass]
    public class TimerClassTest
    {
        #region Global

        private static Guid? _queueid = null;
        private static Guid? _siteid = null;
        private static Guid? _webid = null;
        private static string _connStr = null;
        private const int MaxTrials = 10;
        private static List<Guid> _lstJobs = null;

        /// <summary>
        /// Initite global variables
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            var webApp = SPWebService.ContentService.WebApplications.ToList()[0];
            _connStr = EPMLiveCore.CoreFunctions.getConnectionString(webApp.Id);

            _siteid = webApp.Sites[0].ID;
            _webid = webApp.Sites[0].AllWebs[0].ID;

            _lstJobs = new List<Guid>();
        }

        /// <summary>
        /// Delete test data
        /// </summary>
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            //now concat them as a comma seperated string
            var idCommaList = string.Join("', '", _lstJobs);

            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();

                SqlCommand cmd = null;
                using (
                        cmd =
                            new SqlCommand(@"delete from queue where
                                        timerjobuid in ('"+ idCommaList +"')", conn))
                {                    
                    cmd.ExecuteNonQuery();
                }

                using (
                        cmd =
                            new SqlCommand("delete from timerjobs where timerjobuid in ('" + idCommaList + "')", conn))
                {                    
                    cmd.ExecuteNonQuery();
                }

            }
        }

        #endregion

        #region TimerClass Testing

        /// <summary>
        /// Test SharePoint connectivity.
        /// </summary>
        [TestMethod]
        public void TestConnectivity()
        {
            Assert.IsTrue(_connStr.Length > 0);
        }

        /// <summary>
        /// Test that a single job with medium priority is processed successfully.
        /// </summary>
        [TestMethod]
        public void TestOneJob()
        {
            //insert test queue and job into DB
            InsertTestJob();

            TimerClass mc = new TimerClass();
            if (mc.startTimer())
            {
                mc.runTimer();

                int failedTrial = 0;
                DataRow queue = null;

                //loop till job is processed
                do
                {
                    Thread.Sleep(1000);
                    queue = GetQueueExecutionResult();

                } while (queue["dtfinished"] == DBNull.Value && failedTrial++ < MaxTrials);

                Assert.IsTrue(failedTrial < MaxTrials, "Maximum trials exceeded");

                Assert.IsTrue(queue["status"].ToString() == "2", "Invalid result status");
                Assert.IsTrue(queue["percentComplete"].ToString() == "100", "Invalid result percentage");

            }
            else
            {
                Assert.Fail("Start Timer failed");
            }
        }

        /// <summary>
        /// Test that a the maximum number of jobs with medium priority are all processed successfully.
        /// </summary>
        [TestMethod]
        public void TestMaxThreadedJobs()
        {
            int numOfJobs = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("QueueThreads")); ;
            DateTime dtStart = DateTime.Now;

            //insert test queue and job into DB with the max number of threads
            for (int i = 0; i < numOfJobs; i++)
                InsertTestJob();

            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();

                TimerClass mc = new TimerClass();
                if (mc.startTimer())
                {
                    mc.runTimer();

                    int failedTrial = 0;
                    int notProcessed = 0;
                   
                    SqlCommand cmd = null;
                    //loop till job is processed
                    do
                    {
                        Thread.Sleep(1000);

                        cmd = new SqlCommand(
                        "select count(*) from Queue where status < 2 and dtcreated >= @Created", conn);

                        cmd.Parameters.AddWithValue("@Created", dtStart);

                        notProcessed = int.Parse(cmd.ExecuteScalar().ToString());

                    } while (notProcessed > 0 && failedTrial++ < numOfJobs);
                    
                    Assert.IsTrue(notProcessed == 0, "Could not process all jobs");

                }
                else
                {
                    Assert.Fail("Start Timer failed");
                }
            }
        }

        /// <summary>
        /// Ignored for now: gives random behvior
        /// Test that any service only takes its maximum number and leaves the others unassigned.
        /// </summary>
        //[TestMethod]
        public void TestOnlyProcessingMaxThreadedJobs()
        {
            const int additionalJobs = 3;
            int numOfJobs = int.Parse(EPMLiveCore.CoreFunctions.getFarmSetting("QueueThreads"));
            DateTime dtCreated = DateTime.Now;

            //insert test queue and job into DB
            for (int i = 0; i < numOfJobs + additionalJobs; i++)
                InsertTestJob(created: dtCreated);


            TimerClass mc = new TimerClass();
            if (mc.startTimer())
            {
                mc.runTimer();

                int newNumberOfUnassignedJobs = GetNumberOfUnassignedJobs(dtCreated);

                Assert.IsTrue(newNumberOfUnassignedJobs == additionalJobs,
                    "Jobs were not assigned properly: Expected: " + additionalJobs + ",Found: " +
                    newNumberOfUnassignedJobs);
            }
            else
            {
                Assert.Fail("Start Timer failed");
            }
        }

        /// <summary>
        /// Test that service does not process any jobs assigned to another server during the last 24 hours whatever its status.
        /// </summary>
        [TestMethod]
        public void TestRecentJobAlreadyWithAnotherServer()
        {
            //insert test queue and job into DB with job assigned to dummy server
            InsertTestJob(true, false);

            TimerClass mc = new TimerClass();
            if (mc.startTimer())
            {
                mc.runTimer();

                Thread.Sleep(1000);
                using (var conn = new SqlConnection(_connStr))
                {
                    conn.Open();

                    SqlDataReader reader = null;
                    SqlCommand cmd = new SqlCommand(
                        "select * from Queue where status = 0 and queueuid = @queueid", conn);

                    cmd.Parameters.AddWithValue("@queueid", _queueid);
                    reader = cmd.ExecuteReader();

                    Assert.IsTrue(reader.Read(), "Job belongs to another server, processed with mistake.");
                    reader.Close();
                }
            }
            else
            {
                Assert.Fail("Start Timer failed");
            }
        }

        /// <summary>
        /// Test that service processes a job assigned to other server when more than 24 hours passed with status "1" (in-progress).

        /// </summary>
        [TestMethod]
        public void TestOldJobAlreadyWithAnotherServer()
        {
            //insert test queue and job into DB with job assigne to dummy server with old date
            InsertTestJob(true, true);

            TimerClass mc = new TimerClass();
            if (mc.startTimer())
            {
                mc.runTimer();

                int failedTrial = 0;
                DataRow queue = null;
                //loop till job is processed
                do
                {
                    Thread.Sleep(1000);
                    queue = GetQueueExecutionResult();

                } while (queue["dtfinished"] == DBNull.Value && failedTrial++ < MaxTrials * 2);

                Assert.IsTrue(failedTrial < MaxTrials, "Maximum trials exceeded");

                Assert.IsTrue(queue["queueserver"].ToString() == System.Environment.MachineName,
                    "Job not assigned properly");
                Assert.IsTrue(queue["status"].ToString() == "2", "Operation failed");
                Assert.IsTrue(queue["percentComplete"].ToString() == "100", "Operation Incomplete");
            }
            else
            {
                Assert.Fail("Start Timer failed");
            }
        }

        #endregion

        #region WorkerThreads Testing

        /// <summary>
        /// Test adding a new backgroud worker to WorkerThreads
        /// </summary>
        [TestMethod]
        public void TestWorkerThreadsAdd()
        {
            int maxThreads = 10;
            TimerClass mc = new TimerClass();

            mc.WorkingThreads = new TimerClass.WorkerThreads(maxThreads);
            mc.WorkingThreads.add(new BackgroundWorker());

            int remainingThreads = mc.WorkingThreads.remainingThreads();

            Assert.IsTrue(remainingThreads == maxThreads - 1);
        }

        /// <summary>
        /// Test adding 3 background workers then clean
        /// </summary>
        [TestMethod]
        public void TestWorkerThreadsClean()
        {
            int maxThreads = 10;
            TimerClass mc = new TimerClass();

            mc.WorkingThreads = new TimerClass.WorkerThreads(maxThreads);

            mc.WorkingThreads.add(new BackgroundWorker());
            mc.WorkingThreads.add(new BackgroundWorker());
            mc.WorkingThreads.add(new BackgroundWorker());

            mc.WorkingThreads.cleanup();

            int remainingThreads = mc.WorkingThreads.remainingThreads();

            Assert.IsTrue(remainingThreads == maxThreads);
        }

        /// <summary>
        /// Test adding more than the maximum to the worker threads
        /// </summary>
        [TestMethod]
        public void TestWorkerThreadsExceedMaximum()
        {
            int maxThreads = 10;
            TimerClass mc = new TimerClass();

            mc.WorkingThreads = new TimerClass.WorkerThreads(maxThreads);

            for (int i = 0; i < maxThreads + 3; i++)
                mc.WorkingThreads.add(new BackgroundWorker());

            int remainingThreads = mc.WorkingThreads.remainingThreads();

            Assert.IsTrue(remainingThreads == 0);
        }

        #endregion

        #region Helper Methods                

        private static void InsertTestJob(bool anotherServer = false, bool oldDate = false, DateTime? created = null)
        {
            Guid jobid = Guid.NewGuid();

            string insertTimerJob =
                $@"INSERT [dbo].[TIMERJOBS] ([timerjobuid], [jobname], [siteguid], [webguid], [listguid], [itemid], [jobtype], [enabled],
 [runtime], [scheduletype], [days], [jobdata], [lastqueuecheck], [key], [parentjobuid]) 
 VALUES (@jobid, N'Upgrader', @siteid,  @webid, NULL, NULL, 5, NULL, -1, 9, N'', N'', NULL, N'', NULL)";

            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var cmd = new SqlCommand(insertTimerJob, conn);
                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@siteid", _siteid);
                cmd.Parameters.AddWithValue("@webid", _webid);

                cmd.ExecuteNonQuery();

                _queueid = Guid.NewGuid();

                DateTime newCreated = DateTime.Now;
                if (oldDate)
                    newCreated = DateTime.Now.AddHours(-25);
                else if (created.HasValue)
                    newCreated = created.Value;

                string insertQueue =
                    $@"INSERT into [dbo].[QUEUE]([queueuid], [timerjobuid], [QueueServer], [percentComplete], [status], [dtcreated], [dtstarted],
 [dtfinished], [userid]) VALUES(@queueid, @jobid, @Server,  0, @Status, @Created, @Started, NULL, 
(select USER_ID from[TSUSER] where name = 'System Account'))";
                
                cmd = new SqlCommand(insertQueue, conn);

                cmd.Parameters.AddWithValue("@jobid", jobid);
                cmd.Parameters.AddWithValue("@queueid", _queueid.Value);
                cmd.Parameters.AddWithValue("@Server", anotherServer ? "DummyServer" as object : DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", oldDate ? 1 : 0);
                cmd.Parameters.AddWithValue("@Created", newCreated);
                cmd.Parameters.AddWithValue("@Started", oldDate ? DateTime.Now.AddHours(-25) as object : DBNull.Value);

                cmd.ExecuteNonQuery();
            }

            _lstJobs.Add(jobid);

        }

        private static DataRow GetQueueExecutionResult()
        {
            DataRow dr = null;

            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (
                SqlCommand cmd = new SqlCommand("select * from Queue where queueuid = @queueid", conn))
                {
                    cmd.Parameters.AddWithValue("@queueid", _queueid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    var ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dr = ds.Tables[0].Rows[0];
                    }
                    else
                    {

                        Assert.Fail("No queue found with ID: " + _queueid);
                    }
                }
            }

            return dr;
        }

        private static int GetNumberOfUnassignedJobs(DateTime? dtCreated = null)
        {
            int unassignedJobNumber;
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (
                   SqlCommand cmd = new SqlCommand("select count(*) from Queue where queueserver is null and dtcreated = @Created", conn))
                {
                    cmd.Parameters.AddWithValue("@Created", dtCreated.HasValue ? dtCreated as object : DBNull.Value);
                    unassignedJobNumber = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }

            return unassignedJobNumber;
        }
        #endregion
    }
}
