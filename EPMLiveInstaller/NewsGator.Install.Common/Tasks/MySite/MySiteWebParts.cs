using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using NewsGator.Install.Common.Output;

namespace NewsGator.Install.Common.Tasks.MySite
{
    /// <summary>
    /// Task to enable Social Sites web parts on the My Site host.
    /// </summary>
    internal class MySiteWebParts : IInstallTask
    {
        public string Script
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Enable-SocialSitesMySiteWebParts \"{0}\"", this.MySiteUrl);
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

        public MySiteWebParts(string mySiteHostUrl)
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteWebParts);

                output.Add(Utilities.Runspace.RunInPowerShell(
                    string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.MySite]::EnableMySiteWebPartsFeature(\"{0}\")", this.MySiteUrl)));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_MySiteWebParts_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.MySiteWebPartsException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_MySiteWebParts; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
