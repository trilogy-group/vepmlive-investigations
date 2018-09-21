using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using EPMLiveCore;
using Microsoft.SharePoint;
using SysTrace = System.Diagnostics.Trace;

namespace EPMLiveEnterprise
{
    public partial class runenterprisesynch : System.Web.UI.Page
    {
        private const string QueryTimerLog = "select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and jobtype=9";
        private const string QueryGetStatus = "select status from queue where timerjobuid=@timerjobuid";
        private const string QueryReadConfigValue = "select config_value from econfig where config_name='ConnectedURLs'";
        private const string CmdTextInsertTimerJobs = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid) VALUES (@timerjobuid, @siteguid, 9, 'Project Server Field Synch', 5, @webguid)";
        private const string CmdTextDeleteEpmLiveLog = "delete from epmlive_log where timerjobuid=@timerjobuid";
        private const string CmdTextDeleteQueue = "DELETE FROM QUEUE where timerjobuid = @timerjobuid ";
        private const string CmdTextInsertQueue = "INSERT INTO QUEUE (timerjobuid, status, percentcomplete, dtstarted) VALUES (@timerjobuid, @status, 0, getdate()) ";
        private const string CmdTextInsertLogTemplate = "insert into epmlive_log (timerjobuid,result,resulttext) VALUES (@timerjobuid,'{0}',@resulttext)";
        private const string CmdTextUpdateQueue = "UPDATE queue set percentComplete=0,status=2,dtfinished=GETDATE() where timerjobuid=@timerjobuid";
        private const string CmdTextUpdatePercentageTemplate = "UPDATE queue set percentComplete={0} where timerjobuid='{1}'";
        private const string SqlParamSiteGuid = "@siteguid";
        private const string SqlParamWebGuid = "@webguid";
        private const string SqlParamTimerJobUid = "@timerjobuid";
        private const string SqlParamResultText = "@resulttext";
        private const string SqlParamStatus = "@status";
        private const int DefaultStatus = 2;
        private const char CarriageReturn = '\r';
        private const char NewLine = '\n';
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = SPContext.Current.Web.CurrentUser.LoginName;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    

                    //string[] sParams = new string[2] { , Request["siteid"] };

                    Thread timerThread = new Thread(RunThread);
                    timerThread.Name = "Timer Thread";
                    timerThread.Priority = ThreadPriority.Normal;
                    timerThread.IsBackground = true;
                    timerThread.Start(SPContext.Current.Site.ID.ToString() + "|" + SPContext.Current.Site.WebApplication.Id.ToString() + "|" + SPContext.Current.Web.ID.ToString() + "|" + username); 

                    data = "Success";
                }
                catch (Exception ex)
                {
                    data = "Error: " + ex.Message;
                }
            });
        }

        void RunThread(object args)
        {
            if (args == null || !(args is string))
            {
                throw new ArgumentException($"{args} argument is not a valid string value", nameof(args));
            }

            var argsArray = ((string)args).Split('|');

            if (argsArray.Length < 4)
            {
                throw new ArgumentException(
                    $"{args} argument must contain 4 values seperated with | char (Pattern: siteGuid|webAppGuid|web|username)",
                    nameof(args));
            }

            var siteGuidValue = argsArray[0];
            var webAppGuidValue = argsArray[1];
            var webGuidValue = argsArray[2];
            var username = argsArray[3];

            var connectionString = CoreFunctions.getConnectionString(new Guid(webAppGuidValue));

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Guid timerJobGuid;

                if (!TryGetTimerJobGuid(connection, siteGuidValue, webGuidValue, out timerJobGuid))
                {
                    return;
                }

                DeleteEpmLiveLog(connection, timerJobGuid);

                var status = GetStatus(connection, timerJobGuid);
                if (status == DefaultStatus)
                {
                    ReCreateQueueData(connection, timerJobGuid);
                }

                ProcessSites(connection, siteGuidValue, username, timerJobGuid);
                UpdateQueue(connection, timerJobGuid);
            }
        }

        private bool TryGetTimerJobGuid(SqlConnection connection, string siteGuidValue, string webGuidValue, out Guid timerJobGuid)
        {
            var timerJobGuidBuffer = default(Guid?);

            using (var command = new SqlCommand(QueryTimerLog, connection))
            {
                command.Parameters.AddWithValue(SqlParamSiteGuid, siteGuidValue);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(3) && dataReader.GetInt32(3) != DefaultStatus)
                        {
                            timerJobGuid = Guid.Empty;
                            return false;
                        }

                        timerJobGuidBuffer = dataReader.GetGuid(0);
                    }
                }

                if (!timerJobGuidBuffer.HasValue)
                {
                    timerJobGuidBuffer = Guid.NewGuid();

                    using (var insertCommand = new SqlCommand(CmdTextInsertTimerJobs, connection))
                    {
                        insertCommand.Parameters.AddWithValue(SqlParamSiteGuid, siteGuidValue);
                        insertCommand.Parameters.AddWithValue(SqlParamWebGuid, webGuidValue);
                        insertCommand.Parameters.AddWithValue(SqlParamTimerJobUid, timerJobGuidBuffer.Value);
                        insertCommand.ExecuteNonQuery();
                    }
                }

                timerJobGuid = timerJobGuidBuffer.Value;
                return true;
            }
        }

        private void DeleteEpmLiveLog(SqlConnection connection, Guid tjGuid)
        {
            using (var command = new SqlCommand(CmdTextDeleteEpmLiveLog, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, tjGuid);
                command.ExecuteNonQuery();
            }
        }

        private int GetStatus(SqlConnection connection, Guid timerJobGuid)
        {
            using (var command = new SqlCommand(QueryGetStatus, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, timerJobGuid);

                using (var dataReader = command.ExecuteReader())
                {
                    return dataReader.Read()
                        ? dataReader.GetInt32(0)
                        : DefaultStatus;
                }
            }
        }

        private void ReCreateQueueData(SqlConnection connection, Guid timerJobGuid)
        {
            using (var command = new SqlCommand(CmdTextDeleteQueue, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, timerJobGuid);
                command.ExecuteNonQuery();
            }

            using (var command = new SqlCommand(CmdTextInsertQueue, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, timerJobGuid);
                command.Parameters.AddWithValue(SqlParamStatus, 1);
                command.ExecuteNonQuery();
            }
        }

        private void ProcessSites(SqlConnection connection, string siteGuidValue, string username, Guid timerJobGuid)
        {
            var outputBuilder = new StringBuilder();

            try
            {
                var siteCount = 1;
                var sitesArray = GetSitesArray(connection);

                if (sitesArray?.Length > 0)
                {
                    siteCount += sitesArray.Length;
                }

                using (var site = new SPSite(new Guid(siteGuidValue)))
                {
                    var result = ProcessSite(site, siteCount, connection, timerJobGuid, siteGuidValue, username, 0);
                    outputBuilder.Append(result);
                }

                if (sitesArray != null)
                {
                    var siteCounter = 1;

                    foreach (var siteUrl in sitesArray)
                    {
                        using (SPSite site = new SPSite(siteUrl))
                        {
                            var pctFactor = (double)siteCounter / siteCount;
                            var result = ProcessSite(site, siteCount, connection, timerJobGuid, siteGuidValue, username, pctFactor);
                            outputBuilder.Append(result);
                        }
                        siteCounter++;
                    }
                }

                SaveLog(connection, true, timerJobGuid, outputBuilder.ToString());
            }
            catch (Exception ex)
            {
                SysTrace.TraceError(ex.ToString());
                SaveLog(connection, false, timerJobGuid, $"{outputBuilder}<br><br>Error: {ex.Message}");
            }
        }

        private string[] GetSitesArray(SqlConnection connection)
        {
            var sitesArray = default(string[]);

            using (var command = new SqlCommand(QueryReadConfigValue, connection))
            using (var dataReader = command.ExecuteReader())
            {
                var sites = string.Empty;

                if (dataReader.Read())
                {
                    sites = dataReader.GetString(0);
                }

                if (sites != string.Empty)
                {
                    sitesArray = sites.Replace(string.Concat(CarriageReturn, NewLine), NewLine.ToString())
                                      .Split(NewLine);
                }
            }

            return sitesArray;
        }

        private string ProcessSite(
            SPSite site,
            int siteCount,
            SqlConnection connection,
            Guid timerJobGuid,
            string siteGuidValue,
            string username,
            double percentageFactor)
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.Append($"Site: {site.RootWeb.Title} ({site.Url})<br>");

            var counter = 0d;
            var percent = 0d;
            var totalWebs = (double)site.AllWebs.Count;

            foreach (SPWeb web in site.AllWebs)
            {
                resultBuilder.Append($"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web: {web.Title} ({web.Url})<br>");

                var projWorkspaceSync = new ProjectWorkspaceSynch(new Guid(siteGuidValue), web.Url, Guid.Empty, username);
                projWorkspaceSync.processProjectCenter();
                projWorkspaceSync.processTaskCenter();
                counter++;

                var newPercent = (counter / totalWebs / siteCount + percentageFactor) * 100;
                if (newPercent >= percent + 5)
                {
                    percent = newPercent;

                    var commandText = string.Format(CmdTextUpdatePercentageTemplate, newPercent, timerJobGuid);
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            return resultBuilder.ToString();
        }

        private void SaveLog(SqlConnection connection, bool isSuccess, Guid tjGuid, string message)
        {
            var errorStatus = isSuccess ? "No Errors" : "Errors";
            var commandText = string.Format(CmdTextInsertLogTemplate, errorStatus);

            using (var command = new SqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, tjGuid);
                command.Parameters.AddWithValue(SqlParamResultText, message);
                command.ExecuteNonQuery();
            }
        }

        private void UpdateQueue(SqlConnection connection, Guid tjGuid)
        {
            using (var command = new SqlCommand(CmdTextUpdateQueue, connection))
            {
                command.Parameters.AddWithValue(SqlParamTimerJobUid, tjGuid);
                command.ExecuteNonQuery();
            }
        }
    }
}