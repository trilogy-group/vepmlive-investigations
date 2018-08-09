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
    /// Task to update features.
    /// </summary>
    internal class UpdateFeatures : IInstallTask
    {
        public string Script
        {
            get
            {
                return "Update-SocialSitesFeatures";
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

        private Collection<Guid> SolutionIds { get; set; }

        public UpdateFeatures(Collection<Guid> solutionsIds)
        {
            this.SolutionIds = solutionsIds;

            // Timeout is 5 minutes multiplied by the number of servers in the farm
            this.Timeout = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count() * 300000;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "SolutionIds"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_UpdateFeatures);

                if (this.SolutionIds == null || this.SolutionIds.Count == 0)
                    throw new InvalidOperationException("SolutionIds");

                var solutionsString = string.Empty;
                for (var i = 0; i < this.SolutionIds.Count; i++)
                {
                    if (i == 0)
                        solutionsString = "\"" + this.SolutionIds[i].ToString() + "\"";
                    else
                        solutionsString += ", \"" + this.SolutionIds[i].ToString() + "\"";
                }

                var parameter = string.Format(CultureInfo.InvariantCulture, "([System.Collections.ObjectModel.Collection``1[[System.Guid]]] ([GUID[]] ({0})))", solutionsString);
                var command = string.Format(CultureInfo.InvariantCulture, "[Newsgator.Install.Common.Utilities.Features]::UpgradeFeaturesAll({0})", parameter);

                output.Add(Utilities.Runspace.RunInPowerShell(command));

                output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_UpdateFeatures_Complete);
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.UpdateFeaturesException, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get { return NewsGator.Install.Resources.Tasks.TaskName_UpdateFeatures; }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
