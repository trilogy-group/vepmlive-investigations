using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Diagnostics;
using System.Management;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Installer;
using NewsGator.Install.Resources;
using System.IO;
using NewsGator.Install.Common.Tasks;
using NewsGator.Install.Common.Constants.Solutions;

namespace NewsGator.Install.Common.Utilities
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
    internal class Setup : IDisposable
    {
        #region Properties and Constants
        private bool _disposed = false;
        //private Collection<SPIisWebServiceApplicationPool> _applicationPools = new Collection<SPIisWebServiceApplicationPool>();
        
        internal OutputManager OutputManager { get; set; }
        internal InstallSource InstallSource { get; set; }
        internal InstallMethod InstallMethod { get; set; }
        internal bool IsConsumingFarm { get; set; }
        internal Guid InstallId { get; set; }
        internal Version SharePointBuild { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string SocialEmailListWebUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string SocialMySiteWebUrl { get; set; }
        internal string SocialDatabaseName { get; set; }
        internal string SocialDatabaseServer { get; set; }
        internal string SocialDatabaseFailoverServer { get; set; }
        internal string SocialReportingDatabaseName { get; set; }
        internal string SocialReportingDatabaseServer { get; set; }
        internal string SocialReportingDatabaseFailoverServer { get; set; }
        internal SPIisWebServiceApplicationPool SocialApplicationPool { get; set; }
        internal string SocialApplicationPoolName { get; set; }
        internal string SocialApplicationPoolUsername { get; set; }
        internal string SocialApplicationPoolPassword { get; set; }
        internal string SocialLicenseKey { get; set; }
        internal bool SocialReplaceMySiteWebParts { get; set; }
        internal bool SocialEnableLookout { get; set; }
        internal bool SocialMakeLookoutMySiteHomePage { get; set; }
        internal string VideoEncodingInputFolder { get; set; }
        internal string VideoEncodingOutputFolder { get; set; }
        internal string VideoStreamingServerFolder { get; set; }
        internal string VideoUploadFolder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string VideoStreamingServerUrlDefaultZone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string VideoStreamingServerUrlIntranetZone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string VideoStreamingServerUrlInternetZone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string VideoStreamingServerUrlCustomZone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        internal string VideoStreamingServerUrlExtranetZone { get; set; }
        internal string VideoDatabaseName { get; set; }
        internal string VideoDatabaseServer { get; set; }
        internal string VideoDatabaseFailoverServer { get; set; }
        internal SPIisWebServiceApplicationPool VideoApplicationPool { get; set; }
        internal string VideoApplicationPoolName { get; set; }
        internal string VideoApplicationPoolUsername { get; set; }
        internal string VideoApplicationPoolPassword { get; set; }
        internal string EnrichGlobalKnowledgeBase { get; set; }

        internal SPIisWebServiceApplicationPool EnrichApplicationPool { get; set; }
        internal string EnrichApplicationPoolName { get; set; }
        internal string EnrichApplicationPoolUsername { get; set; }
        internal string EnrichApplicationPoolPassword { get; set; }
        internal string NewsDatabaseName { get; set; }
        internal string NewsDatabaseServer { get; set; }
        internal string NewsDatabaseFailoverServer { get; set; }
        internal SPIisWebServiceApplicationPool NewsApplicationPool { get; set; }
        internal string NewsApplicationPoolName { get; set; }
        internal string NewsApplicationPoolUsername { get; set; }
        internal string NewsApplicationPoolPassword { get; set; }

        internal SPIisWebServiceApplicationPool InterCommApplicationPool { get; set; }
        internal string InterCommApplicationPoolName { get; set; }
        internal string InterCommApplicationPoolUsername { get; set; }
        internal string InterCommApplicationPoolPassword { get; set; }

        internal string InnovationDatabaseName { get; set; }
        internal string InnovationDatabaseServer { get; set; }
        internal string InnovationDatabaseFailoverServer { get; set; }
        internal SPIisWebServiceApplicationPool InnovationApplicationPool { get; set; }
        internal string InnovationApplicationPoolName { get; set; }
        internal string InnovationApplicationPoolUsername { get; set; }
        internal string InnovationApplicationPoolPassword { get; set; }

        internal bool DeleteDatabases { get; set; }

        internal bool ProvisionSocialServiceApplication { get; set; }
        internal bool ProvisionNewsServiceApplication { get; set; }
        internal bool ProvisionEnrichServiceApplication { get; set; }
        internal bool ProvisionVideoServiceApplication { get; set; }
        internal bool ProvisionInterCommServiceApplication { get; set; }
        internal bool ProvisionInnovationServiceApplication { get; set; }

        internal Collection<string> WebApplications { get; set; }
        internal bool AllWebApplications { get; set; }

        internal Collection<SolutionSet> SolutionSets { get; set; }
        internal Collection<SocialSitesSolution> Solutions { get; set; }
        internal bool SolutionAssemblyVersionsValid { get; set; }

        internal string LiteralPath { get; set; }

        internal Collection<Prerequisite> Prerequisites { get; set; }

        internal Version VersionInstalled { get; set; }

        internal EventHandler OnTaskUpdate { get; set; }
        internal bool TasksInitialized { get; set; }
        internal Collection<IInstallTask> Tasks { get; set; }

        private bool IgnoreMissingModulesOnUpgrade = false;

        private const string InstallSolutionName = "NewsGator.Install.Jobs.wsp";
        private bool ScriptOnly = false;
        private bool UseTimerJobs = false;
        #endregion

        #region Constructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal Setup(OutputManager outputManager, InstallSource installSource, InstallMethod installMethod, string literalPath, bool isConsumingFarm = false, bool ignoreMissingModules = false, bool scriptOnly = false, bool useTimerJobs = false)
        {
            #region Set Output Manager
            this.OutputManager = outputManager;
            this.IgnoreMissingModulesOnUpgrade = ignoreMissingModules;
            #endregion

            #region Set Properties and Defaults
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.ProgressStarting, 0);
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.ProgressInProgress, 10);
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CreatingSetupInstance, 20);

            this.Tasks = new Collection<IInstallTask>();
            this.TasksInitialized = false;
            this.InstallMethod = installMethod;
            this.InstallSource = installSource;
            this.IsConsumingFarm = isConsumingFarm;
            this.ScriptOnly = scriptOnly;
            this.UseTimerJobs = useTimerJobs;
            this.InstallId = Guid.NewGuid();
            try
            {
                Environment.SetEnvironmentVariable("NewsGatorInstallId", this.InstallId.ToString());
            }
            catch { }

            try
            {
                this.SharePointBuild = LocalFarm.Get().BuildVersion;
            }
            catch
            {
                var exception = new InvalidOperationException(Exceptions.NoFarmError);
                this.OutputManager.WriteError(exception.Message, exception, true);
            }

            //this.StopIis = false;
            this.DeleteDatabases = false;

            if (this.IsConsumingFarm)
                this.Prerequisites = Entities.Installer.Prerequisites.Get().Where(p => (p.RequiredForConsumingFarmInstall) || (!p.RequiredForConsumingFarmInstall && !p.RequiredForInstall)).ToCollection();
            else
                this.Prerequisites = Entities.Installer.Prerequisites.Get();

            this.Solutions = Constants.Solutions.All.Get();

            //switch (this.InstallMethod)
            //{
            //    case InstallMethod.Install:
            //        this._numberOfTasks = this.IsConsumingFarm ? 20 : 29;
            //        break;
            //    case InstallMethod.Uninstall:
            //        this._numberOfTasks = 15;
            //        break;
            //    case InstallMethod.Update:
            //        this._numberOfTasks = this.IsConsumingFarm ? 21 : 30;
            //        break;
            //}

            //this._progressPerTask = (this._numberOfTasks > 0) ? (int)Math.Round((double)(100 / this._numberOfTasks)) : 1;

            if (this.InstallMethod == InstallMethod.Install)
            {
                var licenseKey = Files.GetLicenseKeyFromFile();
                if (!string.IsNullOrEmpty(licenseKey))
                    this.SocialLicenseKey = licenseKey;
            }
            #endregion

            #region Check Solutions Path
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CheckingSolutionPath, 30);
            this.LiteralPath = literalPath;
            if (!this.LiteralPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                this.LiteralPath = this.LiteralPath + "\\";
            if (!Files.ValidDirectory(this.LiteralPath))
            {
                var exception = new FileNotFoundException(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DirectoryDoesNotExist, this.LiteralPath));
                this.OutputManager.WriteError(exception.Message, exception, true);
            }
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CheckingSolutionPathComplete, 40);
            #endregion

            #region Unblock Files If Necessary
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.UnblockingFiles, 50);
            try
            {
                Files.UnblockFiles(literalPath).WriteQueuedOutput(this.OutputManager);
            }
            catch (Exception exception)
            {
                this.OutputManager.WriteError(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorAttemptingToUnblockFiles, exception.Message), exception, true);
            }
            try
            {
                Files.UnblockFiles(Path.GetDirectoryName(typeof(Setup).Assembly.Location)).WriteQueuedOutput(this.OutputManager);
            }
            catch (Exception exception)
            {
                this.OutputManager.WriteError(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorAttemptingToUnblockFiles, exception.Message), exception, true);
            }
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.UnblockingFilesComplete, 60);
            #endregion

            #region Check Available Solutions and Solution Sets
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CheckingSolutionFiles, 70);
            try
            {
                var solutionsToProcess = this.Solutions;
                Utilities.Solutions.ProcessSolutionsStatus(ref solutionsToProcess, this.LiteralPath, (this.IgnoreMissingModulesOnUpgrade || this.InstallMethod == Entities.Flags.InstallMethod.Uninstall)).WriteQueuedOutput(this.OutputManager);
                this.Solutions = solutionsToProcess;

                var solutionSets = this.SolutionSets;
                Utilities.Solutions.ProcessSolutionSetsStatus(ref solutionSets, this.Solutions);
                this.SolutionSets = solutionSets;

                if ((this.InstallMethod == InstallMethod.Install) && (this.Solutions.Any(p => p.IsInstalled && p.SolutionId != Constants.Solutions.SocialPlatform.NewsGatorInstallJobs.SolutionId)))
                    this.InstallMethod = InstallMethod.Update;
            }
            catch (Exception exception)
            {
                this.OutputManager.WriteError(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorProcessingSolutionFiles, exception.Message), exception, true);
            }
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CheckingSolutionPathComplete, 80);
            #endregion

            #region Get Installed Version
            try
            {
                var instance = new Entities.SocialSites.SocialSitesInstance();                
                
                if (instance != null)
                {
                    if (!string.IsNullOrEmpty(instance.Version))
                        this.VersionInstalled = new Version(instance.Version);
                    else
                        this.VersionInstalled = null;
                }
            }
            catch
            {
                this.VersionInstalled = null;
            }

            if (this.VersionInstalled == null)
            {
                var version = Utilities.Files.GetAssemblyVersion("NewsGator.Core.Application");

                if (version != null)
                    this.VersionInstalled = version;
            }
            #endregion

            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.CreatingSetupInstanceComplete, 90);
            this.OutputManager.WriteProgress(UserDisplay.ProgressInitializingSetup, UserDisplay.ProgressComplete, 100);
        }
        #endregion

        #region Methods
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal void CheckPrerequisites()
        {
            if (this._disposed)
                throw new ObjectDisposedException(Exceptions.DisposedError);

            this.OutputManager.WriteProgress(UserDisplay.ProgressCheckingPrerequisites, UserDisplay.ProgressStarting, 0);
            this.OutputManager.WriteProgress(UserDisplay.ProgressCheckingPrerequisites, UserDisplay.ProgressInProgress, 0);

            if (this.Prerequisites != null)
            {
                var preReqs = this.Prerequisites;
                Utilities.Prerequisites.ProcessPrerequisites(this.SolutionSets, this.LiteralPath, ref preReqs, this.VersionInstalled, this.OutputManager);//.WriteQueuedOutput(this.OutputManager);
                this.Prerequisites = preReqs;
            }

            this.OutputManager.WriteProgress(UserDisplay.ProgressCheckingPrerequisites, UserDisplay.ProgressComplete, 100);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputManager.WriteVerbose(System.String,System.Boolean,System.Nullable<System.DateTime>)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal void RunSetup()
        {
            if (this._disposed)
                throw new ObjectDisposedException(Exceptions.DisposedError);

            var startTime = DateTime.Now;

            #region Log Versions
            if (this.VersionInstalled != null)
                this.OutputManager.WriteVerbose(string.Format(CultureInfo.CurrentCulture, UserDisplay.VersionPrevious, this.VersionInstalled.ToString()));

            if (this.InstallMethod != Entities.Flags.InstallMethod.Uninstall)
                this.OutputManager.WriteVerbose(string.Format(CultureInfo.CurrentCulture, UserDisplay.VersionInstalling, BuildVersion.Version.ToString()));
            #endregion

            #region Get Web Applications
            this.OutputManager.WriteProgress(UserDisplay.ProgressGetWebApplications, UserDisplay.ProgressInProgress);
            // If no Web Applications are specified for Install methods, set AllWebApplications to true
            if ((!this.AllWebApplications) && ((this.WebApplications == null) || (this.WebApplications.Count() == 0)))
            {
                if (this.InstallMethod == InstallMethod.Install)
                    this.AllWebApplications = true;
            }

            if (this.InstallMethod == InstallMethod.Uninstall)
                this.AllWebApplications = true;

            if (this.WebApplications == null)
                this.WebApplications = new Collection<string>();

            // Add Central Admin
            this.WebApplications.AddRange(SPWebService.AdministrationService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0).Select(p => p.GetResponseUri(SPUrlZone.Default).AbsoluteUri));

            // Add Content Web Applications
            if (this.AllWebApplications)
            {
                this.WebApplications.AddRange(SPWebService.ContentService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0).Select(p => p.GetResponseUri(SPUrlZone.Default).AbsoluteUri));
            }

            if (this.InstallMethod == InstallMethod.Update)
            {
                // Get Web Applications Core is Installed To For New Modules
                var farmSolution = LocalFarm.Get().Solutions[Constants.Solutions.SocialPlatform.NewsGatorCore.SolutionId];
                if (farmSolution != null
                    && farmSolution.Deployed
                    && farmSolution.DeployedWebApplications != null)
                {
                    foreach (var webApp in farmSolution.DeployedWebApplications)
                    {
                        if (!this.WebApplications.Contains(webApp.GetResponseUri(SPUrlZone.Default).AbsoluteUri))
                            this.WebApplications.Add(webApp.GetResponseUri(SPUrlZone.Default).AbsoluteUri);
                    }
                }
            }
            #endregion

            this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_BuildingList, UserDisplay.ProgressInProgress);
            #region Build Task Collection

            if (this.UseTimerJobs)
            {
                // Remove NewsGator.Install.Jobs.wsp if already exists
                if (LocalFarm.Get().Solutions[InstallSolutionName] != null)
                {
                    this.Tasks.Add(new Tasks.Solutions.SolutionRemove(InstallSolutionName, false, true));

                    // Execute SharePoint Recycle Timer Service job
                    this.Tasks.Add(new Tasks.Jobs.RecycleTimerServiceJob());
                }

                // Add NewsGator.Install.Jobs.wsp
                this.Tasks.Add(new Tasks.Solutions.SolutionAdd(InstallSolutionName,
                    Path.GetDirectoryName(typeof(Setup).Assembly.Location)));

                // Deploy NewsGator.Install.Jobs.wsp
                this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(InstallSolutionName));
            }

            // Execute SharePoint Recycle Timer Service job
            //this.Tasks.Add(new Tasks.Jobs.RecycleTimerServiceJob());

            // Disable Just-in-Time Debugger
            this.Tasks.Add(new Tasks.Debugger.DisableDebugger());

            // Restart Services
            //this.Tasks.Add(new Tasks.Services.RestartServices());

            // Ensure Application Pools
            //this.Tasks.Add(new Tasks.WebApplications.EnsureWebApplications());

            // Disable Web Applications
            this.Tasks.Add(new Tasks.WebApplications.DisableWebApplications(this.UseTimerJobs));

            // Disable Jobs
            this.Tasks.Add(new Tasks.Jobs.DisableJobs());
            this.Tasks.Add(new Tasks.Jobs.DisableUserProfileJob());

            // Restart Services
            this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

            #region Install / Update
            if ((this.InstallMethod == InstallMethod.Install)
                || (this.InstallMethod == InstallMethod.Update))
            {
                if (this.InstallMethod == InstallMethod.Update)
                {
                    // Remove Orphaned Features
                    this.Tasks.Add(new Tasks.Features.RemoveOrphanedFeatures());
                }                

                // Remove Core Solutions
                var coreSolutionsToRemove = this.Solutions.Where(p =>                    
                    (p.IsInstalled)
                    && (p.SolutionSet == SolutionSet.SocialPlatform)
                    && (p.MinimumVersion <= this.SharePointBuild.Major)
                    && (p.RetractBeforeUpgrade || p.RemoveIfFoundOnFarm)).OrderBy(p => p.InstallOrder);
                foreach (var solution in coreSolutionsToRemove.OrderBy(p => p.InstallOrder))
                {
                    this.Tasks.Add(new Tasks.Solutions.SolutionRemove(solution.SolutionName, false, true));
                }

                // Add Core Solutions
                var coreSolutionsToAdd = this.Solutions.Where(p =>
                    (p.IsWspAvailable)
                    && (!p.Ignore)
                    && (p.SolutionSet == SolutionSet.SocialPlatform)
                    && (p.MinimumVersion <= this.SharePointBuild.Major)
                    && (!p.IsInstalled || p.RetractBeforeUpgrade)).OrderBy(p => p.InstallOrder);
                foreach (var solution in coreSolutionsToAdd.OrderBy(p => p.InstallOrder))
                {
                    this.Tasks.Add(new Tasks.Solutions.SolutionAdd(solution.SolutionName, this.LiteralPath));
                }

                // Update Core Solutions
                var coreSolutionsToUpdate = this.Solutions.Where(p =>
                    (p.IsWspAvailable)
                    && (!p.Ignore)
                    && (p.SolutionSet == SolutionSet.SocialPlatform)
                    && (p.MinimumVersion <= this.SharePointBuild.Major)
                    && (p.IsInstalled)
                    && (!p.RetractBeforeUpgrade)).OrderBy(p => p.InstallOrder);
                foreach (var solution in coreSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                {
                    this.Tasks.Add(new Tasks.Solutions.SolutionUpdate(solution.SolutionName, this.LiteralPath, this.WebApplications));
                }

                // Restart Services
                this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

                if (coreSolutionsToAdd.Any() || this.InstallMethod == Entities.Flags.InstallMethod.Update)
                {
                    // Deploy Core Solutions
                    foreach (var solution in coreSolutionsToAdd.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications));
                    }

                    // Deploy Updated Solutions
                    foreach (var solution in coreSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications, true));
                    }

                    // Restart Services
                    this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));
                }

                if (!this.IsConsumingFarm)
                {
                    // Provision Core Service Application
                    if(this.ProvisionSocialServiceApplication)
                    {
                        this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.SocialPlatform,
                                    this.SocialDatabaseName,
                                    this.SocialDatabaseServer,
                                    this.SocialDatabaseFailoverServer,
                                    this.SocialReportingDatabaseName,
                                    this.SocialReportingDatabaseServer,
                                    this.SocialReportingDatabaseFailoverServer,
                                    this.SocialApplicationPoolName,
                                    this.SocialApplicationPoolUsername,
                                    this.SocialApplicationPoolPassword,
                                    this.SocialLicenseKey,
                                    this.SocialEmailListWebUrl,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    this.UseTimerJobs));

                        // Restart Services
                        //this.Tasks.Add(new Tasks.Services.RestartServices());
                    }
                    else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)// Update Core Service Application
                    {
                        this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.SocialPlatform, this.UseTimerJobs));

                        // Restart Services
                        //this.Tasks.Add(new Tasks.Services.RestartServices());
                    }
                }
                                
                // Module Tasks
                var moduleTasks = false;
                if (this.SolutionSets.Contains(SolutionSet.CanadaCommon)
                    || this.SolutionSets.Contains(SolutionSet.Enrich)
                    || this.SolutionSets.Contains(SolutionSet.EnrichVideoScenarios)
                    || this.SolutionSets.Contains(SolutionSet.IdeaStream)
                    || this.SolutionSets.Contains(SolutionSet.Innovation)
                    || this.SolutionSets.Contains(SolutionSet.InterComm)
                    || this.SolutionSets.Contains(SolutionSet.NewsStream)
                    || this.SolutionSets.Contains(SolutionSet.PivotViewer)
                    || this.SolutionSets.Contains(SolutionSet.Scorecard)
                    || this.SolutionSets.Contains(SolutionSet.Spotlight)
                    || this.SolutionSets.Contains(SolutionSet.VideoScreenCast)
                    || this.SolutionSets.Contains(SolutionSet.VideoStream))
                {
                    moduleTasks = true;

                    if (this.SolutionSets.Contains(SolutionSet.VideoStream))
                    {
                        // Update Old Video Solution if Found
                        foreach (var videoSolution in this.Solutions.Where(p => p.IsInstalled && p.IsWspAvailable && p.SolutionId == Constants.Solutions.VideoStream.NewsGatorVideoStreamApplication.SolutionId))
                        {
                            this.Tasks.Add(new Tasks.Solutions.SolutionUpdate(videoSolution.SolutionName, this.LiteralPath, this.WebApplications));
                        }
                    }

                    // Remove Module Solutions
                    var moduleSolutionsToRemove = this.Solutions.Where(p =>
                        (p.IsInstalled)
                        && (p.SolutionSet != SolutionSet.SocialPlatform)
                        && (p.SolutionSet != SolutionSet.Unknown)
                        && (p.SolutionSet != SolutionSet.None)
                        && (this.SolutionSets.Contains(p.SolutionSet))
                        && (p.MinimumVersion <= this.SharePointBuild.Major)
                        && (p.RetractBeforeUpgrade || p.RemoveIfFoundOnFarm)).OrderBy(p => p.InstallOrder);
                    foreach (var solution in moduleSolutionsToRemove.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionRemove(solution.SolutionName, false, true));
                    }

                    // Add Module Solutions
                    var moduleSolutionsToAdd = this.Solutions.Where(p =>
                        (p.IsWspAvailable)
                        && (!p.Ignore)
                        && (p.SolutionSet != SolutionSet.SocialPlatform)
                        && (p.SolutionSet != SolutionSet.Unknown)
                        && (p.SolutionSet != SolutionSet.None)
                        && (this.SolutionSets.Contains(p.SolutionSet))
                        && (p.MinimumVersion <= this.SharePointBuild.Major)
                        && (!p.IsInstalled || p.RetractBeforeUpgrade)).OrderBy(p => p.InstallOrder);
                    foreach (var solution in moduleSolutionsToAdd.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionAdd(solution.SolutionName, this.LiteralPath));
                    }

                    // Update Module Solutions
                    var moduleSolutionsToUpdate = this.Solutions.Where(p =>
                        (p.IsWspAvailable)
                        && (!p.Ignore)
                        && (p.SolutionSet != SolutionSet.SocialPlatform)
                        && (p.SolutionSet != SolutionSet.Unknown)
                        && (p.SolutionSet != SolutionSet.None)
                        && (this.SolutionSets.Contains(p.SolutionSet))
                        && (p.MinimumVersion <= this.SharePointBuild.Major)
                        && (p.IsInstalled)
                        && (!p.RetractBeforeUpgrade)).OrderBy(p => p.InstallOrder);
                    foreach (var solution in moduleSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionUpdate(solution.SolutionName, this.LiteralPath, this.WebApplications));
                    }

                    // Restart Services
                    this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

                    if (moduleSolutionsToAdd.Any() || this.InstallMethod == Entities.Flags.InstallMethod.Update)
                    {
                        // Deploy Module Solutions
                        foreach (var solution in moduleSolutionsToAdd.OrderBy(p => p.InstallOrder))
                        {
                            this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications));
                        }

                        // Deploy Updated Module Solutions
                        foreach (var solution in moduleSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                        {
                            this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications, true));
                        }

                        // Restart Services
                        this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));
                    }
                }

                // Reactivate Features
                this.Tasks.Add(new Tasks.Features.ReactivateFeatures(this.LiteralPath));

                // Restart Services
                this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

                // Unknown Solutions
                if (this.Solutions.Any(p => p.IsWspAvailable &&
                    (p.SolutionSet == SolutionSet.Unknown || p.SolutionSet == SolutionSet.None)))
                {
                    // Add Unknown Solutions
                    var unknownSolutionsToAdd = this.Solutions.Where(p =>
                        (p.IsWspAvailable)
                        && (p.SolutionSet == SolutionSet.Unknown || p.SolutionSet == SolutionSet.None)
                        && (p.MinimumVersion <= this.SharePointBuild.Major)
                        && (!p.IsInstalled)).OrderBy(p => p.InstallOrder);
                    foreach (var solution in unknownSolutionsToAdd.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionAdd(solution.SolutionName, this.LiteralPath));
                    }

                    // Update Module Solutions
                    var unknownSolutionsToUpdate = this.Solutions.Where(p =>
                        (p.IsWspAvailable)                        
                        && (p.SolutionSet == SolutionSet.Unknown || p.SolutionSet == SolutionSet.None)
                        && (p.MinimumVersion <= this.SharePointBuild.Major)
                        && (p.IsInstalled)).OrderBy(p => p.InstallOrder);
                    foreach (var solution in unknownSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                    {
                        this.Tasks.Add(new Tasks.Solutions.SolutionUpdate(solution.SolutionName, this.LiteralPath, this.WebApplications));
                    }

                    // Restart Services
                    this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

                    if (unknownSolutionsToAdd.Any() || this.InstallMethod == Entities.Flags.InstallMethod.Update)
                    {
                        // Deploy Module Solutions
                        foreach (var solution in unknownSolutionsToAdd.OrderBy(p => p.InstallOrder))
                        {
                            this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications));
                        }

                        // Deploy Updated Solutions
                        foreach (var solution in unknownSolutionsToUpdate.OrderBy(p => p.InstallOrder))
                        {
                            this.Tasks.Add(new Tasks.Solutions.SolutionDeploy(solution.SolutionName, this.WebApplications, true));
                        }

                        // Restart Services
                        this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));
                    }
                }

                if (moduleTasks && !this.IsConsumingFarm)
                {
                    //var moduleServiceAppTasks = false;

                    // Enrich
                    if (this.SolutionSets.Contains(SolutionSet.Enrich))
                    {
                        //moduleServiceAppTasks = true;
                        if (this.ProvisionEnrichServiceApplication)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.Learning,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.EnrichApplicationPoolName,
                                        this.EnrichApplicationPoolUsername,
                                        this.EnrichApplicationPoolPassword,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.EnrichGlobalKnowledgeBase,
                                        this.UseTimerJobs));
                        }
                        else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.Learning, this.UseTimerJobs));
                        }
                    }

                    // Innovation
                    if (this.SolutionSets.Contains(SolutionSet.Innovation))
                    {
                        //moduleServiceAppTasks = true;
                        if (this.ProvisionInnovationServiceApplication)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.Innovation,
                                        this.InnovationDatabaseName,
                                        this.InnovationDatabaseServer,
                                        this.InnovationDatabaseFailoverServer,
                                        null,
                                        null,
                                        null,
                                        this.InnovationApplicationPoolName,
                                        this.InnovationApplicationPoolUsername,
                                        this.InnovationApplicationPoolPassword,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.UseTimerJobs));
                        }
                        else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.Innovation, this.UseTimerJobs));
                        }
                    }

                    // InterComm
                    if (this.SolutionSets.Contains(SolutionSet.InterComm))
                    {
                        //moduleServiceAppTasks = true;
                        if (this.ProvisionInterCommServiceApplication)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.InterComm,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.InterCommApplicationPoolName,
                                        this.InterCommApplicationPoolUsername,
                                        this.InterCommApplicationPoolPassword,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.UseTimerJobs));
                        }
                        else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.InterComm, this.UseTimerJobs));
                        }
                    }

                    // News Manager
                    if (this.SolutionSets.Contains(SolutionSet.NewsStream))
                    {
                        //moduleServiceAppTasks = true;
                        if (this.ProvisionNewsServiceApplication)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.NewsStream,
                                        this.NewsDatabaseName,
                                        this.NewsDatabaseServer,
                                        this.NewsDatabaseFailoverServer,
                                        null,
                                        null,
                                        null,
                                        this.NewsApplicationPoolName,
                                        this.NewsApplicationPoolUsername,
                                        this.NewsApplicationPoolPassword,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        this.UseTimerJobs));
                        }
                        else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.NewsStream, this.UseTimerJobs));
                        }
                    }

                    // Video
                    if (this.SolutionSets.Contains(SolutionSet.VideoStream))
                    {
                        //moduleServiceAppTasks = true;
                        if (this.ProvisionVideoServiceApplication)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.ProvisionServiceApplication(ServiceApplicationType.VideoStream,
                                        this.VideoDatabaseName,
                                        this.VideoDatabaseServer,
                                        this.VideoDatabaseFailoverServer,
                                        null,
                                        null,
                                        null,
                                        this.VideoApplicationPoolName,
                                        this.VideoApplicationPoolUsername,
                                        this.VideoApplicationPoolPassword,
                                        null,
                                        null,
                                        this.VideoEncodingInputFolder,
                                        this.VideoEncodingOutputFolder,
                                        this.VideoStreamingServerFolder,
                                        this.VideoUploadFolder,
                                        this.VideoStreamingServerUrlDefaultZone,
                                        this.VideoStreamingServerUrlIntranetZone,
                                        this.VideoStreamingServerUrlInternetZone,
                                        this.VideoStreamingServerUrlCustomZone,
                                        this.VideoStreamingServerUrlExtranetZone,
                                        null,
                                        this.UseTimerJobs));
                        }
                        else if (this.InstallMethod == Entities.Flags.InstallMethod.Update)
                        {
                            this.Tasks.Add(new Tasks.ServiceApplications.UpdateServiceApplication(ServiceApplicationType.VideoStream, this.UseTimerJobs));
                        }
                    }

                    //if (moduleServiceAppTasks)
                    //{
                    //    // Restart Services
                    //    this.Tasks.Add(new Tasks.Services.RestartServices());
                    //}
                }

                // My Site Tasks               
                if (this.InstallMethod == InstallMethod.Install)
                {
                    if (string.IsNullOrEmpty(this.SocialMySiteWebUrl))
                        this.SocialMySiteWebUrl = MySite.FindMySiteUrl();

                    if (!string.IsNullOrEmpty(this.SocialMySiteWebUrl))
                    {
                        // Enable web parts feature
                        this.Tasks.Add(new Tasks.MySite.MySiteWebParts(this.SocialMySiteWebUrl));

                        // Replace Newsfeed web parts
                        if (this.SocialReplaceMySiteWebParts)
                            this.Tasks.Add(new Tasks.MySite.MySiteNewsFeedPage(this.SocialMySiteWebUrl));

                        if (this.SocialEnableLookout)
                        {
                            // Enable Lookout
                            this.Tasks.Add(new Tasks.MySite.MySiteEnableLookout(this.SocialMySiteWebUrl));

                            // Set Lookout as Home Page
                            if (this.SocialMakeLookoutMySiteHomePage)
                                this.Tasks.Add(new Tasks.MySite.MySiteSetLookoutHomePage(this.SocialMySiteWebUrl));
                        }
                    }
                }

                // Upgrade Features
                if (this.InstallMethod == InstallMethod.Update)
                {
                    var solutionIds = this.Solutions.Where(p =>
                        (this.SolutionSets.Contains(p.SolutionSet) || p.SolutionSet == SolutionSet.None || p.SolutionSet == SolutionSet.Unknown || p.SolutionSet == SolutionSet.SocialPlatform)
                        && (p.IsWspAvailable)
                        && (!p.Ignore)
                        && (!p.RemoveIfFoundOnFarm)
                        && (p.MinimumVersion <= this.SharePointBuild.Major)).OrderBy(q => q.InstallOrder).Select(r => r.SolutionId).ToCollection();

                    if (solutionIds != null)
                    {
                        this.Tasks.Add(new Tasks.Features.UpdateFeatures(solutionIds));

                        // Restart Services
                        this.Tasks.Add(new Tasks.Services.RestartServices());
                    }
                }

                // Copy Application Bin Content
                this.Tasks.Add(new Tasks.WebApplications.CopyAppBinContent(this.UseTimerJobs));

                // Enable NewsGator Jobs
                this.Tasks.Add(new Tasks.Jobs.EnableJobs());
            }
            #endregion

            #region Uninstall
            if (this.InstallMethod == InstallMethod.Uninstall)
            {
                // Remove Service Applications 
                this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.SocialPlatform, this.DeleteDatabases));

                if (this.Solutions.Any(p => p.IsInstalled && p.SolutionSet == SolutionSet.Enrich))
                    this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.Learning, this.DeleteDatabases));

                if (this.Solutions.Any(p => p.IsInstalled && p.SolutionSet == SolutionSet.Innovation))
                    this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.Innovation, this.DeleteDatabases));

                if (this.Solutions.Any(p => p.IsInstalled && p.SolutionSet == SolutionSet.InterComm))
                    this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.InterComm, this.DeleteDatabases));

                if (this.Solutions.Any(p => p.IsInstalled && p.SolutionSet == SolutionSet.NewsStream))
                    this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.NewsStream, this.DeleteDatabases));

                if (this.Solutions.Any(p => p.IsInstalled && p.SolutionSet == SolutionSet.VideoStream))
                    this.Tasks.Add(new Tasks.ServiceApplications.RemoveServiceApplication(ServiceApplicationType.VideoStream, this.DeleteDatabases));

                // Disable Features & Event Receivers
                this.Tasks.Add(new Tasks.Features.DisableFeatures());

                // Restart Services
                this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));
                
                // Remove Solutions
                var solutionsToRemove = this.Solutions.Where(p => p.IsInstalled && p.SolutionId != SocialPlatform.NewsGatorInstallJobs.SolutionId);
                foreach (var solution in solutionsToRemove)
                {
                    this.Tasks.Add(new Tasks.Solutions.SolutionRemove(solution.SolutionName, false, true));
                }

                // Restart Services
                this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));
            }
            #endregion

            // Enable Web Applications
            this.Tasks.Add(new Tasks.WebApplications.EnableWebApplications(this.UseTimerJobs));

            // Ensure Application Pools
            this.Tasks.Add(new Tasks.WebApplications.EnsureWebApplications(this.UseTimerJobs));

            // Enable User Profile Job
            this.Tasks.Add(new Tasks.Jobs.EnableUserProfileJob());

            // Enable Just-in-Time Debugger
            this.Tasks.Add(new Tasks.Debugger.EnableDebugger());

            // Restart Services
            this.Tasks.Add(new Tasks.Services.RestartServices(this.UseTimerJobs));

            if (this.UseTimerJobs)
            {
                // Remove NewsGator.Install.Jobs.wsp
                this.Tasks.Add(new Tasks.Solutions.SolutionRemove(InstallSolutionName, true, true));
            }

            if (this.OnTaskUpdate != null)
                OnTaskUpdate(this, new TaskUpdateEventArgs(this.Tasks));
            #endregion
            this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_BuildingList_Complete, UserDisplay.ProgressComplete);

            if (this.ScriptOnly)
            {
                var outputString = string.Empty;
                foreach (var task in this.Tasks)
                {
                    outputString += string.Format(CultureInfo.CurrentUICulture, UserDisplay.SummaryLineFormat, task.Script);
                }

                this.OutputManager.WriteVerbose(string.Format(CultureInfo.CurrentUICulture, UserDisplay.ScriptOutput, outputString));
                this.OutputManager.WriteWarning(UserDisplay.ScriptOutputMessage);

                var outputFile = Files.OutputPowerShellFile(outputString, this.LiteralPath);

                this.OutputManager.WriteWarning(string.Format(CultureInfo.CurrentUICulture, UserDisplay.ScriptOutputFile, outputFile));
            }
            else
            {
                this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_RunningTasks, UserDisplay.ProgressInProgress);
                #region Run Tasks
                decimal tasksRun = 0;
                decimal taskCount = this.Tasks.Count;
                int percent = 0;
                foreach (var taskToRun in this.Tasks)
                {
                    var task = taskToRun;

                    if (this.OnTaskUpdate != null)
                        this.OnTaskUpdate(this, new TaskUpdateEventArgs(task.InstanceId, TaskStatus.InProgress));

                    this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_RunningTasks, string.Format(CultureInfo.CurrentUICulture, Resources.Tasks.TaskOperations_RunTask, task.DisplayName), percent);

                    TaskExtensions.RunTask(ref task).WriteQueuedOutput(this.OutputManager);

                    if (task.Status == TaskStatus.CompleteFailed)
                    {
                        this.OutputManager.WriteVerbose(Resources.Tasks.TaskFailed_Retrying);
                        var restartTask = new Tasks.Services.RestartServices(this.UseTimerJobs) as IInstallTask;
                        TaskExtensions.RunTask(ref restartTask).WriteQueuedOutput(this.OutputManager);

                        TaskExtensions.RunTask(ref task).WriteQueuedOutput(this.OutputManager);
                    }

                    tasksRun++;
                    percent = (int)Math.Round((tasksRun / taskCount) * 100);

                    this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_RunningTasks_Complete, string.Format(CultureInfo.CurrentUICulture, Resources.Tasks.TaskOperations_RunTask, task.DisplayName), percent);

                    if (this.OnTaskUpdate != null)
                        this.OnTaskUpdate(this, new TaskUpdateEventArgs(task.InstanceId, task.Status));
                }
                #endregion
                this.OutputManager.WriteProgress(Resources.Tasks.TaskOperations_RunningTasks, UserDisplay.ProgressComplete);
            }

            var timeElasped = (DateTime.Now - startTime).TotalMinutes;

            this.OutputManager.WriteVerbose(string.Format(CultureInfo.InvariantCulture, "Operation Took {0} Minutes to Complete.", timeElasped.ToString(CultureInfo.InvariantCulture)));
        }
        #endregion

        #region Destructor
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //GC.Collect();            
        }

        ~Setup()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            this._disposed = true;

            if (disposing)
            {
                this.IsConsumingFarm = false;
                this.OutputManager = null;
                this.AllWebApplications = false;
                this.EnrichApplicationPoolName = null;
                this.EnrichApplicationPoolPassword = null;
                this.EnrichApplicationPoolUsername = null;
                this.InterCommApplicationPoolName = null;
                this.InterCommApplicationPoolPassword = null;
                this.InterCommApplicationPoolUsername = null;
                this.EnrichGlobalKnowledgeBase = null;
                this.InstallMethod = InstallMethod.Unknown;
                this.InstallSource = InstallSource.Unknown;
                this.LiteralPath = null;
                this.Prerequisites = null;
                this.SocialApplicationPoolName = null;
                this.SocialApplicationPoolPassword = null;
                this.SocialApplicationPoolUsername = null;
                this.SocialDatabaseFailoverServer = null;
                this.SocialDatabaseName = null;
                this.SocialDatabaseServer = null;
                this.SocialEmailListWebUrl = null;
                this.SocialLicenseKey = null;
                this.SocialMySiteWebUrl = null;
                this.SocialReplaceMySiteWebParts = false;
                this.SocialReportingDatabaseName = null;
                this.Solutions = null;
                this.SolutionSets = null;
                this.VideoApplicationPoolName = null;
                this.VideoApplicationPoolPassword = null;
                this.VideoApplicationPoolUsername = null;
                this.VideoDatabaseFailoverServer = null;
                this.VideoDatabaseName = null;
                this.VideoDatabaseServer = null;
                this.VideoEncodingInputFolder = null;
                this.VideoEncodingOutputFolder = null;
                this.VideoStreamingServerFolder = null;
                this.VideoStreamingServerUrlCustomZone = null;
                this.VideoStreamingServerUrlDefaultZone = null;
                this.VideoStreamingServerUrlExtranetZone = null;
                this.VideoStreamingServerUrlInternetZone = null;
                this.VideoStreamingServerUrlIntranetZone = null;
                this.VideoUploadFolder = null;
                this.InnovationApplicationPoolName = null;
                this.InnovationApplicationPoolPassword = null;
                this.InnovationApplicationPoolUsername = null;
                this.InnovationDatabaseFailoverServer = null;
                this.InnovationDatabaseName = null;
                this.InnovationDatabaseServer = null;
                this.WebApplications = null;
                this.Tasks = null;
            }
        }
        #endregion
    }
}
