using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using NewsGator.Install.Common.Output;

namespace NewsGator.Install.Common.Tasks.MySite
{
    /// <summary>
    /// Task to enable Lookout on the My Site host.
    /// </summary>
    internal class MySiteEnableLookout : IInstallTask
    {
        public string Script
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Enable-SocialSitesMySiteLookout \"{0}\"", this.MySiteUrl);
            }
        }

        private string MySiteUrl { get; set; }

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

        public MySiteEnableLookout(string mySiteHostUrl)
        {
            this.MySiteUrl = mySiteHostUrl;
            this.Timeout = 600000;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteEnableLookout);

                output.Add(Utilities.Runspace.RunInPowerShell(
                    string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.Lookout]::EnableLookoutFeature(\"{0}\")", this.MySiteUrl)));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteEnableLookout_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.MySiteEnableLookoutException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_MySiteEnableLookout; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
