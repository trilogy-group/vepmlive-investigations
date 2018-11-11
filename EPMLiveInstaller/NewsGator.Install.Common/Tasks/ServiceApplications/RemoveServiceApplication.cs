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
    /// Task to remove a Service Application.
    /// </summary>
    internal class RemoveServiceApplication : IInstallTask
    {
        private string ServiceApplicationTypeName { get; set; }
        private ServiceApplicationType ServiceApplicationType { get; set; }
        private bool DeleteDatabases { get; set; }

        public string Script
        {
            get
            {
                var returnValue = string.Empty;
                switch (this.ServiceApplicationType)
                {
                    case Entities.Flags.ServiceApplicationType.Innovation:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -Innovation -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                    case Entities.Flags.ServiceApplicationType.InterComm:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -InterComm -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                    case Entities.Flags.ServiceApplicationType.Learning:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -Enrich -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                    case Entities.Flags.ServiceApplicationType.NewsStream:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -News -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                    case Entities.Flags.ServiceApplicationType.SocialPlatform:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -SocialPlatform -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                    case Entities.Flags.ServiceApplicationType.VideoStream:
                        returnValue = string.Format(CultureInfo.InvariantCulture,
                            "Remove-SocialSitesServiceApplication -Video -DeleteDatabase ${0}", this.DeleteDatabases.ToString(CultureInfo.InvariantCulture));
                        break;
                }
                return returnValue;
            }
        }

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

        public RemoveServiceApplication(ServiceApplicationType serviceApplicationType,
            bool deleteDatabases = false)
        {
            // 20 Minutes
            this.Timeout = 1200000;

            this.DeleteDatabases = deleteDatabases;

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveServiceApplication, this.ServiceApplicationTypeName));

                var command = string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.ServiceApplication]::RemoveNewsGatorServiceApplication([NewsGator.Install.Common.Entities.Flags.ServiceApplicationType]::{0}, ${1})",
                    this.ServiceApplicationType.ToString(),
                    this.DeleteDatabases.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());

                output.Add(Utilities.Runspace.RunInPowerShell(command));

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveServiceApplication_Complete, this.ServiceApplicationTypeName));
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.RemoveServiceApplicationException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_RemoveServiceApplication, this.ServiceApplicationTypeName); }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
