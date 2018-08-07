using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Tasks.Solutions
{
    /// <summary>
    /// Task to add a SharePoint solution
    /// </summary>
    public class SolutionAdd : IInstallTask
    {
        public string Script
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Add-SocialSitesSolution -SolutionName \"{0}\" -LiteralPath \"{1}\"", this.solutionName, this.solutionPath);
            }
        }

        private string solutionName { get; set; }
        private string solutionPath { get; set; }

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
        public SolutionAdd(string fileName, string filePath)
        {
            this.solutionName = fileName;
            this.solutionPath = filePath;
            
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
                // Ensure solution is not already on the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_AddSolution_CheckIfExists, this.solutionName));
                if (LocalFarm.Get().Solutions[this.solutionName] != null)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionAlreadyAddedToFarm, this.solutionName));

                // Get the file path
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_AddSolution_CheckPath, this.solutionName));
                var path = Path.Combine(this.solutionPath, this.solutionName);

                // Ensure the file exists
                if (!File.Exists(path))
                    throw new FileNotFoundException(path);

                // Add the solution to the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_AddSolution, this.solutionName));
                LocalFarm.Get().Solutions.Add(path);

                // Ensure the solution was added to the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_AddSolution_EnsureAdded, this.solutionName));

                Func<bool> wait = () =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        complete = LocalFarm.Get().Solutions[this.solutionName] != null;
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
                    throw new TimeoutException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionAddTimeout, this.solutionName));
                }

                this.Status = success ? TaskStatus.CompleteSuccess : TaskStatus.CompleteFailed;

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_AddSolution_Complete, this.solutionName));
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionAddException, this.solutionName, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_AddSolution, this.solutionName);
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
