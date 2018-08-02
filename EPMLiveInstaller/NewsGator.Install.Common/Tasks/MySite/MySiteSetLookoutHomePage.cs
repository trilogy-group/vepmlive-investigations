using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using NewsGator.Install.Common.Output;

namespace NewsGator.Install.Common.Tasks.MySite
{
    /// <summary>
    /// Task to set Lookout as the home page of the My Site host.
    /// </summary>
    internal class MySiteSetLookoutHomePage : IInstallTask
    {
        public string Script
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Set-SocialSitesMySiteLookoutHomePage \"{0}\"", this.MySiteUrl);
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

        public MySiteSetLookoutHomePage(string mySiteHostUrl)
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteSetLookoutHomePage);

                output.Add(Utilities.Runspace.RunInPowerShell(
                    string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.Lookout]::SetLookoutAsMySiteHomePage(\"{0}\")", this.MySiteUrl)));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteSetLookoutHomePage_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.MySiteSetLookoutHomePageException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_MySiteSetLookoutHomePage; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
