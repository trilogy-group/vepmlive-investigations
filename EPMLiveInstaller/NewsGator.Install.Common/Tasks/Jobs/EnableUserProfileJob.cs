using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using System.Globalization;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Tasks.Jobs
{
    /// <summary>
    /// Task to enable the User Profile Synchronization Management job
    /// </summary>
    internal class EnableUserProfileJob : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Enable-SocialSitesUserProfileJob";
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

        public EnableUserProfileJob()
        {
            this.Timeout = 600000;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_EnableUserProfileJob);

                output.Add(Utilities.Runspace.RunInPowerShell("[Newsgator.Install.Common.Utilities.Jobs]::EnableUserProfileJob()"));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_EnableUserProfileJob_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.EnableUserProfileJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_EnableUserProfileJob; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
