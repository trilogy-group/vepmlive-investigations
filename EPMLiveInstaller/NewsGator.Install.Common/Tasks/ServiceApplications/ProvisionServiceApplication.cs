using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using System.Globalization;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Tasks.ServiceApplications
{
    /// <summary>
    /// Task to provision a new Service Application.
    /// </summary>
    internal class ProvisionServiceApplication : IInstallTask
    {
        public string Script
        {
            get
            {
                var returnValue = string.Empty;
                switch (this.ServiceApplicationType)
                {
                    case Entities.Flags.ServiceApplicationType.Innovation:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "New-SocialSitesServiceApplication -Innovation -InnovationDatabaseName \"{0}\" -InnovationDatabaseServer \"{1}\" -InnovationDatabaseFailoverServer \"{2}\" -InnovationApplicationPoolName \"{3}\" -InnovationApplicationPoolUsername \"{4}\" -InnovationApplicationPoolPassword \"{5}\"", 
                            this.DatabaseName,
                            this.DatabaseServer,
                            this.DatabaseFailoverServer,
                            this.ApplicationPoolName,
                            this.ApplicationPoolUsername,
                            this.ApplicationPoolPassword) + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.InterComm:
                        returnValue = "New-SocialSitesServiceApplication -InterComm" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.Learning:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "New-SocialSitesServiceApplication -Enrich -EnrichGlobalKnowledgeBase \"{0}\" -EnrichApplicationPoolName \"{1}\" -EnrichApplicationPoolUsername \"{2}\" -EnrichApplicationPoolPassword \"{3}\"",
                            this.LearningGlobalKnowledgeBase,
                            this.ApplicationPoolName,
                            this.ApplicationPoolUsername,
                            this.ApplicationPoolPassword) + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.NewsStream:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "New-SocialSitesServiceApplication -News -NewsDatabaseName \"{0}\" -NewsDatabaseServer \"{1}\" -NewsDatabaseFailoverServer \"{2}\" -NewsApplicationPoolName \"{3}\" -NewsApplicationPoolUsername \"{4}\" -NewsApplicationPoolPassword \"{5}\"",
                            this.DatabaseName,
                            this.DatabaseServer,
                            this.DatabaseFailoverServer,
                            this.ApplicationPoolName,
                            this.ApplicationPoolUsername,
                            this.ApplicationPoolPassword) + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.SocialPlatform:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "New-SocialSitesServiceApplication -SocialPlatform -SocialDatabaseName \"{0}\" -SocialDatabaseServer \"{1}\" -SocialDatabaseFailoverServer \"{2}\" -SocialApplicationPoolName \"{3}\" -SocialApplicationPoolUsername \"{4}\" -SocialApplicationPoolPassword \"{5}\" -SocialLicenseKey \"{6}\" -SocialEmailListWebUrl \"{7}\" -SocialReportingDatabaseName \"{8}\" -SocialReportingDatabaseServer \"{9}\" -SocialReportingDatabaseFailoverServer \"{10}\"",
                            this.DatabaseName,
                            this.DatabaseServer,
                            this.DatabaseFailoverServer,
                            this.ApplicationPoolName,
                            this.ApplicationPoolUsername,
                            this.ApplicationPoolPassword,
                            this.LicenseKey,
                            this.EmailListLocation,
                            this.ReportDatabaseName,
                            this.ReportDatabaseServer,
                            this.ReportDatabaseFailoverServer) + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.VideoStream:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "New-SocialSitesServiceApplication -Video -VideoDatabaseName \"{0}\" -VideoDatabaseServer \"{1}\" -VideoDatabaseFailoverServer \"{2}\" -VideoApplicationPoolName \"{3}\" -VideoApplicationPoolUsername \"{4}\" -VideoApplicationPoolPassword \"{5}\" -VideoEncodingInputFolder \"{6}\" -VideoEncodingOutputFolder \"{7}\" -VideoStreamingServerFolder \"{8}\" -VideoUploadFolder \"{9}\" -VideoStreamingServerUrlDefaultZone \"{10}\" -VideoStreamingServerUrlCustomZone \"{11}\" -VideoStreamingServerUrlExtranetZone \"{12}\" -VideoStreamingServerUrlInternetZone \"{13}\" -VideoStreamingServerUrlIntranetZone \"{14}\"",
                            this.DatabaseName,
                            this.DatabaseServer,
                            this.DatabaseFailoverServer,
                            this.ApplicationPoolName,
                            this.ApplicationPoolUsername,
                            this.ApplicationPoolPassword,
                            this.VideoEncodingInputFolder,
                            this.VideoEncodingOutputFolder,
                            this.VideoStreamingServerFolder,
                            this.VideoUploadFolder,
                            this.VideoStreamingServerUrlDefaultZone,
                            this.VideoStreamingServerUrlCustomZone,
                            this.VideoStreamingServerUrlExtranetZone,
                            this.VideoStreamingServerUrlInternetZone,
                            this.VideoStreamingServerUrlIntranetZone) + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                }
                return returnValue;
            }
        }

        private string ServiceApplicationTypeName { get; set; }
        private ServiceApplicationType ServiceApplicationType { get; set; }
        private string DatabaseName { get; set; }
        private string DatabaseServer { get; set; }
        private string DatabaseFailoverServer { get; set; }
        private string ReportDatabaseName { get; set; }
        private string ReportDatabaseServer { get; set; }
        private string ReportDatabaseFailoverServer { get; set; }
        private string ApplicationPoolName { get; set; }
        private string ApplicationPoolUsername { get; set; }
        private string ApplicationPoolPassword { get; set; }
        private string LicenseKey { get; set; }
        private string EmailListLocation { get; set; }
        private string VideoEncodingInputFolder { get; set; }
        private string VideoEncodingOutputFolder { get; set; }
        private string VideoStreamingServerFolder { get; set; }
        private string VideoUploadFolder { get; set; }
        private string VideoStreamingServerUrlDefaultZone { get; set; }
        private string VideoStreamingServerUrlIntranetZone { get; set; }
        private string VideoStreamingServerUrlInternetZone { get; set; }
        private string VideoStreamingServerUrlCustomZone { get; set; }
        private string VideoStreamingServerUrlExtranetZone { get; set; }
        private string LearningGlobalKnowledgeBase { get; set; }

        private Guid instanceId = Guid.Empty;
        public Guid InstanceId
        {
            get
            {
                if (this.instanceId == Guid.Empty)
                    this.instanceId = Guid.NewGuid();
                return this.instanceId;
            }
        }

        private bool UseTimerJob = false;

        public ProvisionServiceApplication(ServiceApplicationType serviceApplicationType,
            string databaseName = null,
            string databaseServer = null,
            string databaseFailoverServer = null,
            string reportDatabaseName = null,
            string reportDatabaseServer = null,
            string reportDatabaseFailoverServer = null,
            string applicationPoolName = null,
            string applicationPoolUsername = null,
            string applicationPoolPassword = null,
            string licenseKey = null,
            string emailListLocation = null,
            string videoEncodingInputFolder = null,
            string videoEncodingOutputFolder = null,
            string videoStreamingServerFolder = null,
            string videoUploadFolder = null,
            string videoStreamingServerUrlDefaultZone = null,
            string videoStreamingServerUrlIntranetZone = null,
            string videoStreamingServerUrlInternetZone = null,
            string videoStreamingServerUrlCustomZone = null,
            string videoStreamingServerUrlExtranetZone = null,
            string learningGlobalKnowledgeBase = null,
            bool useTimerJob = false)
        {
            // 30 Minutes
            this.Timeout = 1800000;

            this.DatabaseName = databaseName;
            this.DatabaseServer = databaseServer;
            this.DatabaseFailoverServer = databaseFailoverServer;
            this.ReportDatabaseName = reportDatabaseName;
            this.ReportDatabaseServer = reportDatabaseServer;
            this.ReportDatabaseFailoverServer = reportDatabaseFailoverServer;
            this.ApplicationPoolName = applicationPoolName;
            this.ApplicationPoolPassword = applicationPoolPassword;
            this.ApplicationPoolUsername = applicationPoolUsername;
            this.LicenseKey = licenseKey;
            this.EmailListLocation = emailListLocation;
            this.VideoEncodingInputFolder = videoEncodingInputFolder;
            this.VideoEncodingOutputFolder = videoEncodingOutputFolder;
            this.VideoStreamingServerFolder = videoStreamingServerFolder;
            this.VideoStreamingServerUrlCustomZone = videoStreamingServerUrlCustomZone;
            this.VideoStreamingServerUrlDefaultZone = videoStreamingServerUrlDefaultZone;
            this.VideoStreamingServerUrlExtranetZone = videoStreamingServerUrlExtranetZone;
            this.VideoStreamingServerUrlInternetZone = videoStreamingServerUrlInternetZone;
            this.VideoStreamingServerUrlIntranetZone = videoStreamingServerUrlIntranetZone;
            this.VideoUploadFolder = videoUploadFolder;
            this.LearningGlobalKnowledgeBase = learningGlobalKnowledgeBase;
            this.UseTimerJob = useTimerJob;

            this.ServiceApplicationType = serviceApplicationType;
            switch (this.ServiceApplicationType)
            {
                case Entities.Flags.ServiceApplicationType.Innovation:
                    this.ServiceApplicationTypeName = UserDisplay.DatabaseInnovation;
                    break;
                case Entities.Flags.ServiceApplicationType.InterComm:
                    this.ServiceApplicationTypeName = UserDisplay.DatabaseInterComm;
                    break;
                case Entities.Flags.ServiceApplicationType.Learning:
                    this.ServiceApplicationTypeName = UserDisplay.DatabaseEnrich;
                    break;
                case Entities.Flags.ServiceApplicationType.NewsStream:
                    this.ServiceApplicationTypeName = UserDisplay.DatabaseNewsManager;
                    break;
                case Entities.Flags.ServiceApplicationType.SocialPlatform:
                    this.ServiceApplicationTypeName = UserDisplay.DatabasePlatform;
                    break;
                case Entities.Flags.ServiceApplicationType.VideoStream:
                    this.ServiceApplicationTypeName = UserDisplay.DatabaseVideo;
                    break;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_ProvisionServiceApplication, this.ServiceApplicationTypeName));

                var command = string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.ServiceApplication]::ProvisionNewsGatorServiceApplication([NewsGator.Install.Common.Entities.Flags.ServiceApplicationType]::{0}, \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", \"{11}\", \"{12}\", \"{13}\", \"{14}\", \"{15}\", \"{16}\", \"{17}\", \"{18}\", \"{19}\", \"{20}\", \"{21}\", ${22})",
                    this.ServiceApplicationType.ToString(),
                    this.DatabaseName,
                    this.DatabaseServer,
                    this.DatabaseFailoverServer,
                    this.ReportDatabaseName,
                    this.ReportDatabaseServer,
                    this.ReportDatabaseFailoverServer,
                    this.ApplicationPoolName,
                    this.ApplicationPoolUsername,
                    this.ApplicationPoolPassword,
                    this.LicenseKey,
                    this.EmailListLocation,
                    this.VideoEncodingInputFolder,
                    this.VideoEncodingOutputFolder,
                    this.VideoStreamingServerFolder,
                    this.VideoUploadFolder,
                    this.VideoStreamingServerUrlDefaultZone,
                    this.VideoStreamingServerUrlIntranetZone,
                    this.VideoStreamingServerUrlInternetZone,
                    this.VideoStreamingServerUrlCustomZone,
                    this.VideoStreamingServerUrlExtranetZone,
                    this.LearningGlobalKnowledgeBase,
                    this.UseTimerJob.ToString(CultureInfo.InvariantCulture));

                output.Add(Utilities.Runspace.RunInPowerShell(command));

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_ProvisionServiceApplication_Complete, this.ServiceApplicationTypeName));
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.ProvisionServiceApplicationException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_ProvisionServiceApplication, this.ServiceApplicationTypeName); }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
