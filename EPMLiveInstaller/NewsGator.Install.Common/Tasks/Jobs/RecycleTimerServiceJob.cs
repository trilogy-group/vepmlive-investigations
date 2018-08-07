using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Utilities;
using System.Collections.Generic;

namespace NewsGator.Install.Common.Tasks.Jobs
{
    /// <summary>
    /// Task to execute the Timer Service Recycle SharePoint job
    /// </summary>
    internal class RecycleTimerServiceJob : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Restart-SocialSitesTimerService";
            }
        }

        private const string JobName = "job-timer-recycle";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public RecycleTimerServiceJob()
        {
            // 25 Minutes
            this.Timeout = 1500000;            
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_ExecuteTimerServiceJob);

                var cmdOutput = Utilities.Runspace.RunInPowerShell(string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.Jobs]::ExecuteInstallerJob(\"{0}\", {1})", JobName, this.Timeout.ToString(CultureInfo.InvariantCulture)));
                
                if (cmdOutput.Items.Any(p => p.Type == OutputType.Error))
                    this.Status = TaskStatus.CompleteFailed;
                else
                    this.Status = TaskStatus.CompleteSuccess; 
                
                output.Add(cmdOutput);
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_ExecuteTimerServiceJobComplete);
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.ExecuteTimerRecycleJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return NewsGator.Install.Resources.Tasks.TaskName_ExecuteTimerServiceJob;
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
