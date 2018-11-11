using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Entities.Installer;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Prerequisites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static void ProcessPrerequisites(IEnumerable<SolutionSet> solutionSets, string literalPath, ref Collection<Prerequisite> prerequisites, Version versionInstalled,
            OutputManager writer)
        {


            //Parallel.ForEach(prerequisites, prerequisite =>
            foreach (var prerequisite in prerequisites)
            {
                var outputQueue = new OutputQueue(writer);
                try
                {
                    switch (prerequisite.Name)
                    {
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.FarmAdministrator:
                            {
                                bool passed = false;
                                outputQueue.Add(IsFarmAdministrator(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.LocalAdministrator:
                            {
                                bool passed = false;
                                outputQueue.Add(IsLocalAdministrator(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.MySite:
                            {
                                bool passed = false;
                                IsMySiteHostAvailable(out passed, outputQueue);
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.SupportedSharePointVersion:
                            {
                                bool passed = false;
                                outputQueue.Add(IsSupportedVersionOfSharePoint(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.UserProfileAccess:
                            {
                                bool passed = false;
                                outputQueue.Add(IsUserProfileServiceApplicationInvokable(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.UserProfileAdmin:
                            {
                                bool passed = false;
                                outputQueue.Add(IsUserProfileServiceApplicationAdministrator(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.UserProfileAvailable:
                            {
                                bool passed = false;
                                outputQueue.Add(IsUserProfileServiceApplicationAvailable(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.WebApplicationStarted:
                            {
                                bool passed = false;
                                outputQueue.Add(IsWebApplicationStarted(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.NewerVersionNotInstalled:
                            {
                                var passed = false;

                                if (versionInstalled == null)
                                    passed = true;
                                else if (versionInstalled <= BuildVersion.Version)
                                    passed = true;

                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.UpgradeVersion:
                            {
                                var upgradePassed = false;

                                if (versionInstalled == null)
                                    upgradePassed = true;
                                else if (versionInstalled >= new Version(2, 6))
                                    upgradePassed = true;

                                prerequisite.Status = upgradePassed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.ShellAdmin:
                            {
                                var passed = false;
                                outputQueue.Add(IsUserSPShellAdmin(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.ModuleVersions:
                            {
                                var passed = false;
                                outputQueue.Add(CheckModuleVersions(solutionSets, literalPath, out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.WMIAccessible:
                            {
                                var passed = false;
                                outputQueue.Add(IsWMIAvailable(out passed));
                                outputQueue.WriteQueuedOutput(writer);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                        case NewsGator.Install.Common.Entities.Installer.Prerequisites.Names.ServerRoleSupported:
                            {
                                var role = SPServer.LocalServerRole;
                                outputQueue.Add(string.Format(CultureInfo.InvariantCulture, UserDisplay.ServerRoleOutput, role.ToString()));
                                outputQueue.WriteQueuedOutput(writer);
                                var passed = Server.ValidSPServerRoleForDeployment(role);
                                prerequisite.Status = passed ? PrerequisiteStatus.Passed : PrerequisiteStatus.Failed;
                            }
                            break;
                    }

                }
                catch (Exception exception)
                {
                    outputQueue.Add(exception.Message, OutputType.Error, null, exception);
                    outputQueue.WriteQueuedOutput(writer);
                }
            }
            return;
        }

        internal static OutputQueue CheckModuleVersions(IEnumerable<SolutionSet> solutionSets, string literalPath, out bool versionsMatch)
        {
            var outputQueue = new OutputQueue();

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteModuleVersions));
            try
            {
                versionsMatch = true;

                var assemblyVersions = new Collection<SocialSitesWSPAssemblyVersion>();

                // Canada Modules
                if (solutionSets.Contains(SolutionSet.Enrich) || solutionSets.Contains(SolutionSet.VideoStream) || solutionSets.Contains(SolutionSet.Innovation))
                {
                    assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                    {
                        SolutionName = "NewsGator.CA.CommonAssemblies.App.wsp",
                        Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.CA.Common.dll", null }
                        },
                        IsCanadaModule = true
                    });

                    assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                    {
                        SolutionName = "NewsGator.LearningPoint.App.wsp",
                        Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.Learning.Application.dll", null }
                        },
                        IsCanadaModule = true
                    });

                    assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                    {
                        SolutionName = "NewsGator.Innovation.App.wsp",
                        Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.Innovation.Application.dll", null }
                        },
                        IsCanadaModule = true
                    });

                    assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                    {
                        SolutionName = "NewsGator.VideoStream.App.wsp",
                        Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.VideoStream.Application.dll", null }
                        },
                        IsCanadaModule = true
                    });
                }

                // Core Modules
                assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                {
                    SolutionName = "NewsGator.Core.wsp",
                    Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.Core.dll", null }
                        },
                    IsCanadaModule = false
                });

                assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                {
                    SolutionName = "NewsGator.NewsManager.wsp",
                    Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.NewsManager.dll", null }
                        },
                    IsCanadaModule = false
                });

                assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                {
                    SolutionName = "NewsGator.Social.IdeaModule.wsp",
                    Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.Social.IdeaModule.dll", null }
                        },
                    IsCanadaModule = false
                });

                assemblyVersions.Add(new SocialSitesWSPAssemblyVersion
                {
                    SolutionName = "NewsGator.Social.Spotlight.wsp",
                    Assemblies = new Dictionary<string, Version>()
                        {
                            { "NewsGator.Social.Spotlight.dll", null }
                        },
                    IsCanadaModule = false
                });

                outputQueue.Add(Assemblies.CheckWSPAssemblyVersions(ref assemblyVersions, literalPath));

                var coreVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.Core.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                if (coreVersion == null)
                    throw new InvalidOperationException(Exceptions.VersionCheckUnableToFindCore);

                var newsManagerVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.NewsManager.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                if (newsManagerVersion != null && newsManagerVersion != coreVersion)
                {
                    versionsMatch = false;
                    var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleNews));
                    outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                }

                var ideaVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.Social.IdeaModule.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                if (ideaVersion != null && ideaVersion != coreVersion)
                {
                    versionsMatch = false;
                    var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleIdeas));
                    outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                }

                var spotlightVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.Social.Spotlight.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                if (spotlightVersion != null && spotlightVersion != coreVersion)
                {
                    versionsMatch = false;
                    var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleSpotlight));
                    outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                }

                if (solutionSets.Contains(SolutionSet.Enrich) || solutionSets.Contains(SolutionSet.VideoStream) || solutionSets.Contains(SolutionSet.Innovation))
                {
                    var caCoreVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.CA.CommonAssemblies.App.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                    if (caCoreVersion == null)
                        throw new InvalidOperationException(Exceptions.VersionCheckUnableToFindCaCore);

                    var enrichVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.LearningPoint.App.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                    if (enrichVersion != null)
                    {
                        if (enrichVersion.Major != coreVersion.Major && enrichVersion.Minor != coreVersion.Minor)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleEnrich));
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                        else if (enrichVersion != caCoreVersion)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(Exceptions.VersionCheckCanadaModuleDoesntMatch);
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                    }

                    var innovationVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.Innovation.App.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                    if (innovationVersion != null)
                    {
                        if (innovationVersion.Major != coreVersion.Major && innovationVersion.Minor != coreVersion.Minor)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleInnovation));
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                        else if (innovationVersion != caCoreVersion)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(Exceptions.VersionCheckCanadaModuleDoesntMatch);
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                    }

                    var videoVersion = assemblyVersions.Where(p => p.SolutionName.Equals("NewsGator.VideoStream.App.wsp", StringComparison.OrdinalIgnoreCase)).First().Assemblies.First().Value;
                    if (videoVersion != null)
                    {
                        if (videoVersion.Major != coreVersion.Major && videoVersion.Minor != coreVersion.Minor)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Exceptions.VersionCheckModuleDoesntMatchCore, UserDisplay.ModuleVideo));
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                        else if (videoVersion != caCoreVersion)
                        {
                            versionsMatch = false;
                            var ex = new InvalidOperationException(Exceptions.VersionCheckCanadaModuleDoesntMatch);
                            outputQueue.Add(ex.Message, OutputType.Error, null, ex);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                versionsMatch = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteModuleVersions, versionsMatch ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsFarmAdministrator(out bool isFarmAdmin)
        {
            var outputQueue = new OutputQueue();

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteUserIsFarmAdmin));
            try
            {
                isFarmAdmin = LocalFarm.Get().CurrentUserIsAdministrator();
            }
            catch (Exception exception)
            {
                isFarmAdmin = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteUserIsFarmAdmin, isFarmAdmin ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsLocalAdministrator(out bool isLocalAdmin)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteUserIsLocalAdmin));
            try
            {
                var user = WindowsIdentity.GetCurrent();
                if (user == null)
                {
                    isLocalAdmin = false;
                    return outputQueue;
                }
                var principle = new WindowsPrincipal(user);
                isLocalAdmin = principle.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception exception)
            {
                isLocalAdmin = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteUserIsLocalAdmin, isLocalAdmin ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsSupportedVersionOfSharePoint(out bool isSupported)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteSharePointVersion));
            try
            {
                isSupported = false;
                var farm = LocalFarm.Get();
                switch (farm.BuildVersion.Major)
                {
                    case 14:
                        isSupported = farm.BuildVersion >= new Version(14, 0, 6029, 1000); // SharePoint 2010 SP1
                        break;
                    case 15:
                        isSupported = farm.BuildVersion >= new Version(15, 0, 4420, 1017); // SharePoint 2013 RTM
                        break;
                    case 16:
                        isSupported = farm.BuildVersion >= new Version(16, 0, 4306, 1001); // SharePoint 2016 Beta 2, TODO: Replace with RTM
                        break;
                }
            }
            catch (Exception exception)
            {
                isSupported = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteSharePointVersion, isSupported ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsWebApplicationStarted(out bool isRunning)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteWebApplicationServiceIsStarted));
            try
            {
                isRunning = false;
                var webServiceInstance = SPServer.Local.GetChild<SPWebServiceInstance>();
                if (webServiceInstance != null)
                    if (webServiceInstance.Status == SPObjectStatus.Online)
                        isRunning = true;
            }
            catch (Exception exception)
            {
                isRunning = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteWebApplicationServiceIsStarted, isRunning ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsMySiteHostAvailable(out bool isAvailable, OutputQueue outputQueue, string mySiteHostUrl = null)
        {
            if (outputQueue == null)
                outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteMySiteHostAvailable));
            isAvailable = false;
            try
            {
                if (string.IsNullOrEmpty(mySiteHostUrl))
                {
                    outputQueue.Add("SPWebService.ContentService");
                    if (SPWebService.ContentService != null)
                    {
                        outputQueue.Add("SPWebService.ContentService.WebApplications");
                        if (SPWebService.ContentService.WebApplications != null)
                        {
                            int i = 0;
                            foreach (SPWebApplication webApplication in SPWebService.ContentService.WebApplications)
                            {
                                if (isAvailable)
                                    break;

                                i++;
                                outputQueue.Add(string.Format("Processing webApplication {0} {1}", i, webApplication.Name));
                                if (webApplication.Sites != null)
                                {
                                    foreach (SPSite site in webApplication.Sites)
                                    {
                                        outputQueue.Add(string.Format("Processing SPSite {0}", site.Url));
                                        isAvailable = Features.IsFeatureEnabled(Constants.Features.SocialPlatform.SharePointMySiteHostFeature, null, site, null) ? true : isAvailable;

                                        // NEW CODE!!!
                                        if (isAvailable)
                                        {
                                            outputQueue.Add(string.Format("FOUND SharePointMySiteHostFeature at {0}.", site.Url));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, "using (var site = new SPSite({0}))", mySiteHostUrl));
                    using (var site = new SPSite(mySiteHostUrl))
                    {
                        outputQueue.Add("Features.IsFeatureEnabled");
                        isAvailable = Features.IsFeatureEnabled(Constants.Features.SocialPlatform.SharePointMySiteHostFeature, null, site, null);
                        outputQueue.Add("Features.IsFeatureEnabled=" + isAvailable.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteMySiteHostAvailable, isAvailable ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));

            return outputQueue;
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsUserProfileServiceApplicationAvailable(out bool isAvailable)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteUserProfileAvailable));
            try
            {
                SPIisWebServiceApplication app = null;
                outputQueue.Add(UserProfileService.GetUserProfileApplication(out app));
                isAvailable = app != null;
            }
            catch (Exception exception)
            {
                isAvailable = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteUserProfileAvailable, isAvailable ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsUserProfileServiceApplicationAdministrator(out bool isAdmin)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteUserProfileAdmin));
            try
            {
                outputQueue.Add(UserProfileService.UserIsAdministrator(out isAdmin));
            }
            catch (Exception exception)
            {
                isAdmin = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteUserProfileAdmin, isAdmin ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsUserProfileServiceApplicationInvokable(out bool isInvokable)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteUserProfileAccess));
            try
            {
                outputQueue.Add(UserProfileService.UserHasAccess(out isInvokable));
            }
            catch (Exception exception)
            {
                isInvokable = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteUserProfileAccess, isInvokable ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }

        internal static OutputQueue IsWMIAvailable(out bool isWMIAvailable)
        {
            var outputQueue = new OutputQueue();
            isWMIAvailable = true;

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteWMIAvailable));
            try
            {
                var farm = LocalFarm.Get();
                foreach (var server in farm.Servers.Where(f => Server.ValidSPServerRole(f.Role)))
                {
                    var machineServices = ServiceController.GetServices(server.Address);
                    if (null == machineServices || machineServices.Length == 0)
                    {
                        isWMIAvailable = false;
                        outputQueue.Add("Unable to list services on server.", OutputType.Error, "Unable to list services on server: " + server.Address);
                        break;
                    }

                    // var command = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "where.exe");
                    // https://fogbugz.corp.newsgator.com/default.asp?304837
                    // Removing specific path and providing parameter for the where command
                    var command = "where.exe iisreset.exe";
                    var processWMI = new Threading.ProcessWMI();
                    processWMI.ExecuteRemoteProcessWMI(server.Address, command, 15000);
                }
            }
            catch (Exception exception)
            {
                isWMIAvailable = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteWMIAvailable, isWMIAvailable ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue IsUserSPShellAdmin(out bool isShellAdmin)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisite, UserDisplay.PrerequisiteShellAdmin));
            try
            {
                var list = new List<string>();
                var farm = LocalFarm.Get();
                var database = (SPDatabase)Utilities.Reflection.GetPropertyValue(farm.GetType(), farm, "ConfigurationDatabase");
                if (database != null)
                {
                    var session = Utilities.Reflection.GetPropertyValue(database.GetType(), database, "SqlSession");
                    if (session != null)
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = @"select u.name 
                                into #tmpUsers
                                from dbo.sysmembers m 
                                inner join dbo.sysusers u 
                                on u.uid = m.memberuid 
                                inner join dbo.sysusers r on r.uid = m.groupuid 
                                where ((r.name = 'SharePoint_Shell_Access' OR r.name = 'db_owner') and r.issqlrole = 1)

                                INSERT INTO #tmpUsers (name)
                                SELECT name FROM sys.syslogins
                                WHERE sysadmin = 1 and hasaccess = 1

                                INSERT INTO #tmpUsers (sp.name)
                                SELECT sp.name
                                FROM sys.server_principals sp
                                JOIN sys.database_principals dp ON (sp.sid = dp.sid)
                                WHERE dp.name = 'dbo'

                                SELECT name from #tmpUsers
                                drop table #tmpUsers";
                            using (var reader = (SqlDataReader)Utilities.Reflection.ExecuteMethod(session.GetType(), session, "ExecuteReader", new Type[] { typeof(SqlCommand) }, new[] { command }))
                            {
                                while (reader.Read())
                                {
                                    object obj2 = reader["name"];
                                    if (DBNull.Value != obj2)
                                    {
                                        string str = obj2 as string;
                                        if (!string.IsNullOrEmpty(str))
                                        {
                                            list.Add(str);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var accountName = WindowsIdentity.GetCurrent().Name;

                isShellAdmin = false;
                foreach (var name in list)
                {
                    if (name.Equals(accountName, StringComparison.OrdinalIgnoreCase))
                    {
                        isShellAdmin = true;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                isShellAdmin = false;
                outputQueue.Add(exception.Message, OutputType.Error, null, exception);
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.CheckingPrerequisiteComplete, UserDisplay.PrerequisiteShellAdmin, isShellAdmin ? UserDisplay.CheckingPrerequisitePassed : UserDisplay.CheckingPrerequisiteFailed));
            return outputQueue;
        }
    }
}
