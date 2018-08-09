using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Tasks.Solutions
{
    /// <summary>
    /// Taks to remove a SharePoint solution
    /// </summary>
    public class SolutionRemove : IInstallTask
    {
        public string Script
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Remove-SocialSitesSolution -SolutionName \"{0}\"", this.solutionToRemove);
            }
        }

        private string solutionToRemove { get; set; }
        private bool forceRemoval { get; set; }
        private bool retractSolution { get; set; }

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

        public SolutionRemove(string solutionName)
            : this(solutionName, false, false)
        { }

        public SolutionRemove(string solutionName, bool retract) 
            : this (solutionName, retract, false)
        { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public SolutionRemove(string solutionName, bool retract, bool force)
        {
            this.solutionToRemove = solutionName;
            this.forceRemoval = force;
            this.retractSolution = retract;

            // Timeout is 5 minutes multiplied by the number of servers in the farm
            var count = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count();
            this.Timeout = (count > 1 ? count : 2) * 300000;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            try
            {
                // Ensure solution is on the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveSolution_CheckIfExists, this.solutionToRemove));
                if (LocalFarm.Get().Solutions[this.solutionToRemove] == null)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionNotAddedToFarm, this.solutionToRemove));

                // Ensure solution is retracted                
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveSolution_EnsureRetracted, this.solutionToRemove));
                if (retractSolution && LocalFarm.Get().Solutions[this.solutionToRemove].Deployed)
                {
                    output.Add(Utilities.Features.DisableFeaturesForSolution(this.solutionToRemove, true));

                    if (!LocalFarm.Get().Solutions[this.solutionToRemove].ContainsWebApplicationResource)
                        LocalFarm.Get().Solutions[this.solutionToRemove].Retract(DateTime.Now);
                    else
                        LocalFarm.Get().Solutions[this.solutionToRemove].Retract(DateTime.Now, LocalFarm.Get().Solutions[this.solutionToRemove].DeployedWebApplications);

                    Utilities.Solutions.WaitForSolutionJob(this.solutionToRemove, this.Timeout / 2);
                }

                if (!forceRemoval && LocalFarm.Get().Solutions[this.solutionToRemove].Deployed)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionRemoveStillDeployed, this.solutionToRemove));
                }

                Thread.Sleep(60000);

                // Remove solution from the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveSolution, this.solutionToRemove));

                var command = string.Empty;
                if (forceRemoval)
                    command = string.Format(CultureInfo.InvariantCulture, "Remove-SPSolution {0} -Force -Confirm:$false", this.solutionToRemove);
                else
                    command = string.Format(CultureInfo.InvariantCulture, "Remove-SPSolution {0} -Confirm:$false", this.solutionToRemove);

                output.Add(Utilities.Runspace.RunInPowerShell(command, true));
                
                // Ensure the solution was removed
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveSolution_EnsureRemoved, this.solutionToRemove));
                Func<bool> wait = () =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        complete = LocalFarm.Get().Solutions[this.solutionToRemove] == null;
                        if (!complete)
                        {
                            LocalFarm.Get().TryUpdate();
                            Thread.Sleep(10000);
                        }
                    }

                    return complete;
                };

                var success = false;

                try
                {
                    success = Threading.WaitFor<bool>.Run(TimeSpan.FromMilliseconds(this.Timeout / 2), wait);
                }
                catch (TimeoutException)
                {
                    throw new TimeoutException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionRemoveTimeout, this.solutionToRemove));
                }

                this.Status = success ? TaskStatus.CompleteSuccess : TaskStatus.CompleteFailed;

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_RemoveSolution_Complete, this.solutionToRemove));
                this.Status = TaskStatus.CompleteSuccess;

                // For Video
                if (this.solutionToRemove.Equals(Constants.Solutions.VideoStream.NewsGatorVideoStreamApplication.SolutionName, StringComparison.OrdinalIgnoreCase))
                {
                    Assemblies.RemoveAssemblyFromGAC("Microsoft.Practices.SharePoint.Common");
                }
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionRemoveException, this.solutionToRemove, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_RemoveSolution, this.solutionToRemove);
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
