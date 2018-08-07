using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Utilities;
using System.Globalization;
using Microsoft.SharePoint.Administration;

namespace NewsGator.Install.Common.Tasks.Features
{
    /// <summary>
    /// Task to disable all Social Sites features
    /// </summary>
    internal class DisableFeatures : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Disable-SocialSitesFeatures";
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

        public DisableFeatures()
        {
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableFeatures);

                output.Add(Utilities.Receivers.RemoveEventReceivers());
                output.Add(Utilities.Features.DisableFeaturesForAllSolutionSets(false));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableFeatures_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.DisableFeaturesException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_DisableFeatures; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
