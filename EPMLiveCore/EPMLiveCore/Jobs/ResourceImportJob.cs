using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs
{
    public class ResourceImportJob : BaseJob
    {
        #region Fields (2) 

        private const string UPDATE_LOG_SQL =
            "UPDATE EPMLIVE_LOG SET resulttext = @Result WHERE timerjobuid = @TimerJobUId IF @@ROWCOUNT = 0 INSERT INTO EPMLIVE_LOG (timerjobuid, resulttext) VALUES(@TimerJobUId, @Result)";

        private bool _done;

        #endregion Fields 

        #region Methods (5) 

        // Public Methods (1) 

        /// <summary>
        ///     Executes the import job.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <param name="web">The web.</param>
        /// <param name="data">The data.</param>
        public void execute(SPSite site, SPWeb web, string data)
        {
            _done = false;

            totalCount = 2;

            var resourceImporter = new ResourceImporter(web, data);

            resourceImporter.ImportCompleted += ResourceImporterImportCompleted;
            resourceImporter.ImportProgressChanged += ResourceImporterImportProgressChanged;

            resourceImporter.ImportAsync();

            while (!_done)
            {
                Thread.Sleep(1000);
            }
        }

        // Private Methods (4) 

        private string BuildResult(int progressPercentage, string currentProcess,
                                   string log, IList<ProcessedResource> resources, bool hasError)
        {
            var result = new ResourceImportJobResult(progressPercentage, currentProcess,
                                                     log, hasError, resources);

            var memoryStream = new MemoryStream();

            var serializer = new DataContractJsonSerializer(typeof (ResourceImportJobResult));
            serializer.WriteObject(memoryStream, result);
            memoryStream.Position = 0;

            return new StreamReader(memoryStream).ReadToEnd();
        }

        private void ResourceImporterImportCompleted(object sender, ImportCompletedEventHandlerArgs args)
        {
            if (args.Error == null)
            {
                sErrors = BuildResult(100, "All resources have been imported. Check the log for details.", args.Result,
                                      args.Resources, false);
            }
            else
            {
                sErrors = BuildResult(100, "Unable to import resources. Check the log for more details.",
                                      args.Error.Message,
                                      args.Resources, true);
                bErrors = true;
            }

            UpdateProgress(totalCount);
            _done = true;
        }

        private void ResourceImporterImportProgressChanged(object sender, ImportProgressChangedEventHandlerArgs args)
        {
            var resourceImporterState = (ResourceImporterState) args.UserState;
            sErrors = BuildResult(args.ProgressPercentage,
                                  resourceImporterState.CurrentProcess,
                                  resourceImporterState.Log,
                                  resourceImporterState.Resources, false);

            UpdateProgress(resourceImporterState.Step);
        }

        private void UpdateProgress(float step)
        {
            updateProgress(step);

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() => cn.Open());

                var cmd = new SqlCommand(UPDATE_LOG_SQL, cn);
                cmd.Parameters.AddWithValue("@Result", sErrors);
                cmd.Parameters.AddWithValue("@TimerJobUId", JobUid);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch
            {
            }
        }

        #endregion Methods 
    }

    [DataContract]
    public class ResourceImportJobResult
    {
        #region Constructors (2) 

        public ResourceImportJobResult(int progressPercentage,
                                       string currentProcess, string log,
                                       bool hasError, IList<ProcessedResource> resources)
        {
            ProgressPercentage = progressPercentage;
            CurrentProcess = currentProcess;
            Log = log;
            HasError = hasError;
            Resources = resources;
        }

        private ResourceImportJobResult()
        {
        }

        #endregion Constructors 

        #region Properties (5) 

        [DataMember]
        public string CurrentProcess { get; set; }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public string Log { get; set; }

        [DataMember]
        public int ProgressPercentage { get; set; }

        [DataMember]
        public IList<ProcessedResource> Resources { get; set; }

        #endregion Properties 
    }
}