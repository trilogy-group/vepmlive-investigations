using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Utilities;
using System.Collections.Generic;

namespace NewsGator.Install.Common.Tasks.WebApplications
{
    /// <summary>
    /// Task to ensure SharePoint web applications in IIS are running using the timer job in the NewsGator.Install.Jobs.wsp solution
    /// </summary>
    public class EnsureWebApplications : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Start-SocialSitesWebApplicationPools" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
            }
        }

        private const string JobName = "ng-install-ensurepools";

        private bool UseTimerJob = false;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public EnsureWebApplications()
        {
            // Timeout is 5 minutes multiplied by the number of servers in the farm
            this.Timeout = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count() * 300000;            
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public EnsureWebApplications(bool useTimerJob)
        {
            this.UseTimerJob = useTimerJob;
            this.Timeout = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count() * 300000;
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_EnsureWebApps);

                if (this.UseTimerJob)
                {
                    var cmdOutput = Utilities.Runspace.RunInPowerShell(string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.Jobs]::ExecuteInstallerJob(\"{0}\", {1})", JobName, this.Timeout.ToString(CultureInfo.InvariantCulture)));

                    if (cmdOutput.Items.Any(p => p.Type == OutputType.Error))
                        this.Status = TaskStatus.CompleteFailed;
                    else
                        this.Status = TaskStatus.CompleteSuccess;

                    output.Add(cmdOutput);
                }
                else
                {
                    output.Add(Utilities.WebApplications.EnsureApplicationPools());
                }

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_EnsureWebAppsComplete);
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.WebAppEnsureException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return NewsGator.Install.Resources.Tasks.TaskName_EnsureWebApps;
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
