﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using System.Globalization;

namespace NewsGator.Install.Common.Tasks.Jobs
{
    /// <summary>
    /// Task to disable Social Sites timer jobs.
    /// </summary>
    internal class DisableJobs : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Disable-SocialSitesJobs";
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

        public DisableJobs()
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableJobs);

                output.Add(Utilities.Jobs.DisableNewsGatorJobs());

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_DisableJobs_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.DisableJobsException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_DisableJobs; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
