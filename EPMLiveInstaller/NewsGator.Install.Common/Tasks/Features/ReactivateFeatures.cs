using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using System.Globalization;
using System.Collections.ObjectModel;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Tasks.Features
{
    /// <summary>
    /// Task to reactivate farm features.
    /// </summary>
    internal class ReactivateFeatures : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Initialize-SocialSitesFeatures";
            }
        }

        private string literalPath { get; set; }

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

        public ReactivateFeatures(string literalPath)
        {
            this.literalPath = literalPath;

            // Timeout is 5 minutes multiplied by the number of servers in the farm
            this.Timeout = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count() * 300000;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_ReactivateFeatures);

                output.Add(Utilities.Runspace.RunInPowerShell("[Newsgator.Install.Common.Utilities.Features]::ReactivateFeatures(\"" + this.literalPath + "\")"));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_ReactivateFeatures_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.ReactivateFeaturesException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_ReactivateFeatures; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
