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
    /// Task to update a Service Application.
    /// </summary>
    internal class UpdateServiceApplication : IInstallTask
    {
        public string Script
        {
            get
            {
                var returnValue = string.Empty;
                switch (this.ServiceApplicationType)
                {
                    case Entities.Flags.ServiceApplicationType.Innovation:
                        returnValue = "Update-SocialSitesServiceApplication -Innovation" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.InterComm:
                        returnValue = "Update-SocialSitesServiceApplication -InterComm" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.Learning:
                        returnValue = "Update-SocialSitesServiceApplication -Enrich" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.NewsStream:
                        returnValue = "Update-SocialSitesServiceApplication -News" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.SocialPlatform:
                        returnValue = "Update-SocialSitesServiceApplication -SocialPlatform" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                    case Entities.Flags.ServiceApplicationType.VideoStream:
                        returnValue = "Update-SocialSitesServiceApplication -Video" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
                        break;
                }
                return returnValue;
            }
        }

        private string ServiceApplicationTypeName { get; set; }
        private ServiceApplicationType ServiceApplicationType { get; set; }
        private bool UseTimerJob = false;

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

        public UpdateServiceApplication(ServiceApplicationType serviceApplicationType)
        {
            // 30 Minutes
            this.Timeout = 1800000;

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

        public UpdateServiceApplication(ServiceApplicationType serviceApplicationType, bool useTimerJob)
        {
            this.UseTimerJob = useTimerJob;
            this.Timeout = 1800000;

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
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_UpdateServiceApplication, this.ServiceApplicationTypeName));

                var command = string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.ServiceApplication]::UpdateNewsGatorServiceApplication([NewsGator.Install.Common.Entities.Flags.ServiceApplicationType]::{0}, ${1})",
                    this.ServiceApplicationType.ToString(),
                    this.UseTimerJob.ToString(CultureInfo.InvariantCulture));

                output.Add(Utilities.Runspace.RunInPowerShell(command));

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_UpdateServiceApplication_Complete, this.ServiceApplicationTypeName));
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.UpdateServiceApplicationException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_UpdateServiceApplication, this.ServiceApplicationTypeName); }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
