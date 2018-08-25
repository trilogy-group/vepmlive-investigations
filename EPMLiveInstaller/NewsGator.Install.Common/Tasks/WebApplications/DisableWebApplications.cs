﻿using System;
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
    /// Task to disable SharePoint web applications in IIS using the timer job in the NewsGator.Install.Jobs.wsp solution
    /// </summary>
    public class DisableWebApplications : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Disable-SocialSitesWebApplications" + (this.UseTimerJob ? " -UseTimerJob" : string.Empty);
            }
        }

        private const string JobName = "ng-install-disablewebapps";

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public DisableWebApplications()
        {
            // 15 Minutes
            this.Timeout = 900000;
        }

        public DisableWebApplications(bool useTimerJob)
        {
            this.Timeout = 900000;
            this.UseTimerJob = useTimerJob;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableWebApps);

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
                    Utilities.WebApplications.DisableWebApplications(string.Empty);
                }

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableWebAppsComplete);
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.WebAppDisableException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return NewsGator.Install.Resources.Tasks.TaskName_DisableWebApps;
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}