using EPMLiveCore.API;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace EPMLiveCore.Jobs
{
    public class ResourceImportJob : BaseJob
    {
        #region Fields (2)

        private const string UPDATE_LOG_SQL = "UPDATE EPMLIVE_LOG SET resulttext = @ResultText WHERE timerjobuid = @TimerJobUId IF @@ROWCOUNT = 0 INSERT INTO EPMLIVE_LOG (timerjobuid, resulttext) VALUES(@TimerJobUId, @ResultText)";
        private const string GET_JOBQUEUE_STATUS = "SELECT status from vwQueueTimerLog where timerjobuid=@timerjobuid";

        private bool _done;

        private ResourceImporter resourceImporter;

        #endregion Fields

        #region Method

        // Public Methods (1) 

        /// <summary>
        ///     Executes the import job.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="web">The web.</param>
        /// <param name="data">The data.</param>
        public void execute(SPSite site, SPWeb web, string data)
        {
            try
            {
                _done = false;

                totalCount = 2;

                resourceImporter = new ResourceImporter(web, data, false);

                resourceImporter.ImportCompleted += ResourceImportCompleted;
                resourceImporter.ImportProgressChanged += ResourceImportProgressChanged;

                resourceImporter.ImportAsync();

                while (!_done)
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }

        }

        #endregion Methods

        #region Resource Import Progress Events

        private void ResourceImportProgressChanged(object sender, ImportProgressChangedEventHandlerArgs args)
        {
            try
            {
                sErrors = BuildResult(args.UserState);
                UpdateProgress(args.UserState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResourceImportCompleted(object sender, ImportCompletedEventHandlerArgs args)
        {
            try
            {
                sErrors = BuildResult(args.UserState);
                UpdateProgress(args.UserState);
                _done = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateProgress(object userState)
        {
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
                    if (!resourceImporter.IsImportCancelled)
                    {
                        IsImportCancelled(JobUid);
                    }
                    ResourceImportResult dSMResult = (ResourceImportResult)userState;
                    totalCount = dSMResult.TotalRecords == 0 ? 1 : dSMResult.TotalRecords;
                    updateProgress(dSMResult.ProcessedRecords);
                    SPSecurity.RunWithElevatedPrivileges(() => cn.Open());
                    using (var cmd = new SqlCommand(UPDATE_LOG_SQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@ResultText", sErrors);
                        cmd.Parameters.AddWithValue("@TimerJobUId", JobUid);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex) { sErrors = ex.Message; }
            }
        }

        private string BuildResult(object dSMResult)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(ResourceImportResult));
                serializer.WriteObject(memoryStream, dSMResult);
                memoryStream.Position = 0;
                return new StreamReader(memoryStream).ReadToEnd();
            }
        }

        private void IsImportCancelled(Guid jobUid)
        {
            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(() => cn.Open());
                    using (SqlCommand cmd = new SqlCommand(GET_JOBQUEUE_STATUS, cn))
                    {
                        cmd.Parameters.AddWithValue("@timerjobuid", JobUid);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr.GetInt32(0) == 2)
                                {
                                    resourceImporter.IsImportCancelled = true;
                                }
                            }
                            dr.Close();
                        }

                    }
                }
                catch (Exception ex) { sErrors = ex.Message; }
            }

        }

        #endregion
    }

    [DataContract]
    public class ResourceImportResult
    {
        public ResourceImportResult()
        {
            Log = new ResourceImportLog();
        }

        [DataMember]
        public String CurrentProcess { get; set; }
        [DataMember]
        public Int32 TotalRecords { get; set; }
        [DataMember]
        public Int32 PercentComplete { get; set; }
        [DataMember]
        public Int32 ProcessedRecords { get; set; }
        [DataMember]
        public Int32 SuccessRecords { get; set; }
        [DataMember]
        public Int32 FailedRecords { get; set; }
        [DataMember]
        public ResourceImportLog Log { get; set; }
    }
    [DataContract]
    public class ResourceImportLog
    {
        public ResourceImportLog()
        {
            Messages = new List<ResourceImportMessage>();
        }
        [DataMember]
        public Int32 InfoCount { get; set; }
        [DataMember]
        public Int32 WarningCount { get; set; }
        [DataMember]
        public Int32 ErrorCount { get; set; }
        [DataMember]
        public List<ResourceImportMessage> Messages { get; set; }
    }
    [DataContract]
    public class ResourceImportMessage
    {
        public ResourceImportMessage() { }
        [DataMember]
        public Int32 Kind { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public String Message { get; set; }
    }
}