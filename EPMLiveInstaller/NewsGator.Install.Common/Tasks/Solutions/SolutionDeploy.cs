﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using System.Collections.ObjectModel;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Tasks.Solutions
{
    /// <summary>
    /// Task to deploy a SharePoint solution
    /// </summary>
    public class SolutionDeploy : IInstallTask
    {
        public string Script
        {
            get
            {
                if (this.webApplications == null)
                    return string.Format(CultureInfo.InvariantCulture, "Install-SocialSitesSolution -SolutionName \"{0}\"", this.solutionName);
                else
                {
                    var webApps = "@(";
                    for (var i = 0; i < this.webApplications.Count; i++ )
                    {
                        if (i != 0)
                            webApps += ", ";
                        webApps += "\"" + webApplications[i] + "\"";
                    }
                    webApps += ")";
                    return string.Format(CultureInfo.InvariantCulture, "Install-SocialSitesSolution -SolutionName \"{0}\" -WebApplications {1}", this.solutionName, webApps);
                }
            }
        }

        private string solutionName { get; set; }
        private Collection<string> webApplications { get; set; }
        private bool forceDeploy { get; set; }
        private bool overrideCompatibility { get; set; }
        private string compatibilityLevel { get; set; }

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

        public SolutionDeploy(string solutionNameToDeploy) 
            : this (solutionNameToDeploy, null, false, null)
        { }

        public SolutionDeploy(string solutionNameToDeploy, string compatibilityLevel)
            : this(solutionNameToDeploy, null, false, compatibilityLevel)
        { }

        public SolutionDeploy(string solutionNameToDeploy, Collection<string> webApps)
            : this(solutionNameToDeploy, webApps, false, null)
        { }

        public SolutionDeploy(string solutionNameToDeploy, Collection<string> webApps, bool force)
            : this(solutionNameToDeploy, webApps, force, null)
        { }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public SolutionDeploy(string solutionNameToDeploy, Collection<string> webApps, bool force, string compatibilityLevel)
        {
            this.solutionName = solutionNameToDeploy;
            this.webApplications = webApps;
            this.forceDeploy = force;

            this.overrideCompatibility = !string.IsNullOrEmpty(compatibilityLevel);
            if (this.overrideCompatibility)
                this.compatibilityLevel = compatibilityLevel;
            
            // Timeout is 10 minutes multiplied by the number of servers in the farm
            var count = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count();
            this.Timeout = (count > 2 ? count : 3) * 1200000;

            if (this.webApplications != null && this.webApplications.Count > 2)
                this.Timeout = this.Timeout * this.webApplications.Count;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public OutputQueue Run()
        {
            var output = new OutputQueue();
            this.Status = TaskStatus.InProgress;

            var count = LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)).Count();
            double waitTimeout = (count > 2 ? count : 3) * 1200000;
            if (this.webApplications != null && this.webApplications.Count > 2)
                waitTimeout = waitTimeout * this.webApplications.Count;

            waitTimeout = waitTimeout * 0.9;

            try
            {
                var lastOperationEndTime = LocalFarm.Get().Solutions[this.solutionName].LastOperationEndTime;

                // Get Solution Details
                var solutionDetails = Constants.Solutions.All.Get().Where(p => p.SolutionName.Equals(this.solutionName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                // Ensure solution is on the farm
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_DeploySolution_CheckIfExists, this.solutionName));
                if (LocalFarm.Get().Solutions[this.solutionName] == null)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionNotAddedToFarm, this.solutionName));

                if (!this.forceDeploy)
                {
                    // Ensure solution is not already deployed
                    output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_DeploySolution_CheckIfDeployed, this.solutionName));
                    if (LocalFarm.Get().Solutions[this.solutionName].Deployed)
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionAlreadyDeployed, this.solutionName));
                }
                
                // Deploy solution
                if (!LocalFarm.Get().Solutions[this.solutionName].ContainsWebApplicationResource)
                {
                    output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_DeploySolution_DeployingToFarm, this.solutionName));

                    string command;
                    if (this.overrideCompatibility)
                        command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force -CompatibilityLevel \"{1}\"", this.solutionName, this.compatibilityLevel);
                    else if (LocalFarm.Get().BuildVersion.Major >= 15 && solutionDetails != null && !string.IsNullOrEmpty(solutionDetails.CompatibilityRange))
                        command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force -CompatibilityLevel \"{1}\"", this.solutionName, solutionDetails.CompatibilityRange);
                    else
                        command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force", this.solutionName);

                    output.Add(Utilities.Runspace.RunInPowerShell(command, true));

                    Utilities.Solutions.WaitForSolutionJob(this.solutionName, (int) waitTimeout);
                }
                else if (LocalFarm.Get().Solutions[this.solutionName].ContainsWebApplicationResource && this.webApplications != null && this.webApplications.Count > 0)
                {
                    var webApps = new Collection<SPWebApplication>();
                    var webAppsStrings = new Collection<string>();

                    foreach (var webAppUrl in this.webApplications)
                    {
                        var webApp = SPWebApplication.Lookup(new Uri(webAppUrl));
                        if (webApp != null)
                        {
                            if (this.forceDeploy || ((LocalFarm.Get().Solutions[this.solutionName].DeployedWebApplications == null)
                                || ((LocalFarm.Get().Solutions[this.solutionName].DeployedWebApplications != null) && (!LocalFarm.Get().Solutions[this.solutionName].DeployedWebApplications.Contains(webApp)))))
                            {
                                webApps.Add(webApp);
                                webAppsStrings.Add(webAppUrl);
                            }
                        }
                    }

                    if (webApps.Count > 0)
                    {
                        output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_DeploySolution_DeployingToFarm, this.solutionName));

                        foreach (var webAppUrl in webAppsStrings)
                        {
                            var command = string.Empty;
                            if (this.overrideCompatibility)
                                command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force -CompatibilityLevel \"{1}\" -WebApplication \"{2}\"", this.solutionName, this.compatibilityLevel, webAppUrl);
                            else if (LocalFarm.Get().BuildVersion.Major >= 15 && solutionDetails != null && !string.IsNullOrEmpty(solutionDetails.CompatibilityRange))
                                command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force -CompatibilityLevel \"{1}\" -WebApplication \"{2}\"", this.solutionName, solutionDetails.CompatibilityRange, webAppUrl);
                            else
                                command = string.Format(CultureInfo.InvariantCulture, "Install-SPSolution {0} -GACDeployment -Force -WebApplication \"{1}\"", this.solutionName, webAppUrl);

                            output.Add(Utilities.Runspace.RunInPowerShell(command, true));

                            Utilities.Solutions.WaitForSolutionJob(this.solutionName, (int) waitTimeout / webAppsStrings.Count);
                        }
                    }
                }

                // Ensure the solution was deployed and/or updated
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_UpdateSolution_EnsuringUpdated, this.solutionName));
                
                Func<bool> wait = () =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        complete = LocalFarm.Get().Solutions[this.solutionName].LastOperationEndTime != lastOperationEndTime;
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
                    success = Threading.WaitFor<bool>.Run(TimeSpan.FromMilliseconds(120000), wait);
                }
                catch { }

                if (!success)
                {
                    var result = LocalFarm.Get().Solutions[this.solutionName].LastOperationResult;
                    if (result != SPSolutionOperationResult.DeploymentSucceeded && result != SPSolutionOperationResult.NoOperationPerformed)
                    {
                        var lastOperation = string.Empty;
                        var lastOperationDetails = string.Empty;

                        if (LocalFarm.Get().Solutions[this.solutionName] != null)
                        {
                            lastOperation = Utilities.Solutions.GetOperationResultDescription(LocalFarm.Get().Solutions[this.solutionName].LastOperationResult);
                            lastOperationDetails = LocalFarm.Get().Solutions[this.solutionName].LastOperationDetails;
                        }

                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionDeploymentJobTimeout, this.solutionName, lastOperation, lastOperationDetails));
                    }
                }

                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_DeploySolution_Complete, this.solutionName));
                this.Status = TaskStatus.CompleteSuccess;
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.SolutionDeployException, this.solutionName, exception.Message), OutputType.Error, exception.ToString(), exception);
                this.Status = TaskStatus.CompleteFailed;
            }

            return output;
        }

        public string DisplayName
        {
            get
            {
                return string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskName_DeploySolution, this.solutionName);
            }
        }

        public TaskStatus Status { get; set; }

        public int Timeout { get; set; }
    }
}
