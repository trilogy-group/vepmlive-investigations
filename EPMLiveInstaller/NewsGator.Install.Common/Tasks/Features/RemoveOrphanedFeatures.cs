﻿using System;
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
    /// Task to remove orphaned features.
    /// </summary>
    internal class RemoveOrphanedFeatures : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Remove-SocialSitesOrphanedFeatures";
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

        public RemoveOrphanedFeatures()
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
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_RemoveOrphanedFeatures);

                output.Add(Utilities.Runspace.RunInPowerShell("[Newsgator.Install.Common.Utilities.Features]::RemoveOrphanedFeatures()"));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_RemoveOrphanedFeatures_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.RemoveOrphanedFeaturesException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_RemoveOrphanedFeatures; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
