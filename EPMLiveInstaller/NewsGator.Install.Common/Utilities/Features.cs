using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.Flags;
using Microsoft.SharePoint.Utilities;
using System.Collections.Generic;

namespace NewsGator.Install.Common.Utilities
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public static class Features
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public static OutputQueue ReactivateFeatures(string literalPath)
        {
            var outputQueue = new OutputQueue();

            try
            {
                // Social Installer
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.SocialPlatform.InstallerFeature));

                // Fix Search Feature
                outputQueue.Add(FixMissingFeatures(literalPath));

                // CA Dependency Injection
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature));

                // Enrich Type
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.Enrich.EnrichDependencyInjectionFeature));

                // VideoStream Type
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.VideoStream.VideoDependencyInjectionFeature));

                // Enrich Video Scenario
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature));

                // Innovation Type
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.Innovation.InnovationDependencyInjectionFeature));

                // Page Head Feature
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.SocialPlatform.PageHeadFeature));

                // Spotlight Jobs
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.Spotlight.SpotlightJobs));

                // Scorecard Features
                outputQueue.Add(ReactivateFarmFeature(Constants.Features.Scorecard.ScorecardFarm));
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ErrorReactivatingFeatures, exception.Message), OutputType.Error, string.Empty, exception);
            }
                    
            return outputQueue;
        }

        internal static OutputQueue FixMissingFeatures(string literalPath)
        {
            var outputQueue = new OutputQueue();
            bool throwInitializeException = false;

            try
            {
                outputQueue.Add(UserDisplay.InitializingSearchFeatures);

                // Check for Search BDC Feature
                if (LocalFarm.Get().FeatureDefinitions[new Guid("58e7e3f1-4ecc-4211-80c7-00497daaa2b9")] == null)
                {
                    var path = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\NewsGator.Core.Application_Search\Feature.xml", LocalFarm.Get().BuildVersion.Major);
                    if (string.IsNullOrEmpty(path) || !File.Exists(path))
                        path = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\NewsGator.Core.Application_Search\Feature.xml", 14);

                    if (string.IsNullOrEmpty(path) || !File.Exists(path))
                    {
                        throwInitializeException = true;

                        var versions = new Collection<int>() { 14 };
                        if (LocalFarm.Get().BuildVersion.Major >= 15)
                            versions.Add(LocalFarm.Get().BuildVersion.Major);

                        outputQueue.Add(ExtractFeature("NewsGator.Core.Application.wsp", literalPath, "NewsGator.Core.Application_Search", versions, new Collection<string>()
                        {
                            "Feature.xml", 
                            "SocialSitesData.bdcm",
                            "NewsGator.Core.Application.dll"
                        }));
                    }

                    if (string.IsNullOrEmpty(path) || !File.Exists(path))
                        throw new FileNotFoundException(path);

                    LocalFarm.Get().FeatureDefinitions.Add(@"NewsGator.Core.Application_Search\Feature.xml", new Guid("58e7e3f1-4ecc-4211-80c7-00497daaa2b9"), true);
                }

                // 2013 Specific Features
                if (LocalFarm.Get().BuildVersion.Major >= 15)
                {
                    var versions = new Collection<int>() { LocalFarm.Get().BuildVersion.Major };

                    // Check for Social Team Site feature
                    if (LocalFarm.Get().FeatureDefinitions[new Guid("0c6e0543-1728-4ffb-ba83-abac21f014ba")] == null)
                    {
                        var path = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\NewsGator.Application15_NewsGatorSocialTeamSite\Feature.xml", LocalFarm.Get().BuildVersion.Major);

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                        {
                            throwInitializeException = true;

                            outputQueue.Add(ExtractFeature("NewsGator.Application15.wsp", literalPath, "NewsGator.Application15_NewsGatorSocialTeamSite", versions, new Collection<string>()
                            {
                                "Feature.xml"
                            }));
                        }

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                            throw new FileNotFoundException(path);

                        LocalFarm.Get().FeatureDefinitions.Add(@"NewsGator.Application15_NewsGatorSocialTeamSite\Feature.xml", new Guid("0c6e0543-1728-4ffb-ba83-abac21f014ba"), true);
                    }

                    // Check for SkyDrive Integration feature
                    if (LocalFarm.Get().FeatureDefinitions[new Guid("cc601409-f1e8-435d-a81c-1fec0dfc2d72")] == null)
                    {
                        var path = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\NewsGator.Application15_NewsGatorOffice365SkyDriveIntegration\Feature.xml", LocalFarm.Get().BuildVersion.Major);

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                        {
                            throwInitializeException = true;

                            outputQueue.Add(ExtractFeature("NewsGator.Application15.wsp", literalPath, "NewsGator.Application15_NewsGatorOffice365SkyDriveIntegration", versions, new Collection<string>()
                            {
                                "Feature.xml"
                            }));
                        }

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                            throw new FileNotFoundException(path);

                        LocalFarm.Get().FeatureDefinitions.Add(@"NewsGator.Application15_NewsGatorOffice365SkyDriveIntegration\Feature.xml", new Guid("cc601409-f1e8-435d-a81c-1fec0dfc2d72"), true);
                    }

                    // Check for SkyDrive Upload feature
                    if (LocalFarm.Get().FeatureDefinitions[new Guid("21c72826-fb2b-4d22-8ed3-42016f796b45")] == null)
                    {
                        var path = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\NewsGator.Application15_NewsGatorOffice365SkyDriveUpload\Feature.xml", LocalFarm.Get().BuildVersion.Major);

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                        {
                            throwInitializeException = true;

                            outputQueue.Add(ExtractFeature("NewsGator.Application15.wsp", literalPath, "NewsGator.Application15_NewsGatorOffice365SkyDriveUpload", versions, new Collection<string>()
                            {
                                "Feature.xml"
                            }));
                        }

                        if (string.IsNullOrEmpty(path) || !File.Exists(path))
                            throw new FileNotFoundException(path);

                        LocalFarm.Get().FeatureDefinitions.Add(@"NewsGator.Application15_NewsGatorOffice365SkyDriveUpload\Feature.xml", new Guid("21c72826-fb2b-4d22-8ed3-42016f796b45"), true);
                    }
                }

                if (throwInitializeException)
                    throw new Exception("One or more features requires manual deployment on each SharePoint Server.  On each SharePoint Server, open the Sitrion Social Management Shell from the Sitrion Social install utility and run the Initialize-SocialSitesFeatures cmdlet.  For example: \"Initialize-SocialSitesFeatures -LiteralPath C:\\Solutions\".  This message will be repeated after running the cmdlet on each server, however it only needs to be run once per server.");
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ErrorFixingSearchFeature, exception.Message), OutputType.Error, string.Empty, exception);
            }

            return outputQueue;
        }

        internal static OutputQueue ExtractFeature(string solutionName, string literalPath, string featureFolder, Collection<int> spVersions, Collection<string> files)
        {
            var outputQueue = new OutputQueue();

            try
            {
                var solutionPath = Path.Combine(literalPath, solutionName);
                if (!File.Exists(solutionPath))
                    throw new FileNotFoundException(solutionPath);

                var tempPath = Path.Combine(literalPath, "extractTemp");
                if (Directory.Exists(tempPath))
                    Directory.Delete(tempPath, true);

                Directory.CreateDirectory(tempPath);
                var featureTempPath = Path.Combine(tempPath, featureFolder);

                var command = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\expand.exe";
                foreach (var file in files)
                {
                    var args = "\"" + solutionPath + "\" -f:" + file + " \"" + tempPath + "\"";
                    outputQueue.Add(Files.RunCommand(command, args));
                }

                SetFilePermissions(tempPath);

                foreach (var spVersion in spVersions)
                {
                    var featureDestination = Files.GetVersionedGenericSetupPath(@"TEMPLATE\FEATURES\" + featureFolder, spVersion);
                    if (Directory.Exists(featureDestination))
                        Directory.Delete(featureDestination, true);

                    CopyFilesRecursively(featureTempPath, featureDestination);
                }

                Directory.Delete(tempPath, true);
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ErrorFixingSearchFeature, exception.Message), OutputType.Error, string.Empty, exception);
            }

            return outputQueue;
        }

        private static void SetFilePermissions(string directory)
        {
            var dir = new DirectoryInfo(directory);
            SetFilePermissions(dir);
        }

        private static void SetFilePermissions(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
                File.SetAttributes(file.FullName, FileAttributes.Normal);

            foreach (var dir in directory.GetDirectories())
                SetFilePermissions(dir);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            var source = new DirectoryInfo(sourcePath);
            var target = new DirectoryInfo(targetPath);

            CopyFilesRecursively(source, target);
        }

        private static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            if (!target.Exists)
                target.Create();

            foreach (var dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));

            foreach (var file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static OutputQueue ReactivateFarmFeature(Guid featureId)
        {
            var outputQueue = new OutputQueue();

            try
            {
                var adminService = SPWebService.AdministrationService;
                var localFarm = LocalFarm.Get();

                if (localFarm.FeatureDefinitions[featureId] != null)
                {
                    outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.ReactivatingFeature, featureId.ToString()));

                    if (adminService.Features[featureId] != null)
                        adminService.Features.Remove(featureId);

                    adminService.Features.Add(featureId);
                }
            } 
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ErrorReactivatingFeature, featureId.ToString()), OutputType.Error, string.Empty, exception);
            }

            return outputQueue;
        }
                       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue UpgradeFeaturesAll(Collection<Guid> solutionIds)
        {
            var outputQueue = new OutputQueue();
            
            outputQueue.Add(UserDisplay.UpgradingFeatures);

            var solutions = Constants.Solutions.All.Get().OrderBy(p => p.InstallOrder);
            if (solutionIds != null && solutionIds.Any())
                solutions = solutions.Where(p => solutionIds.Any() ? solutionIds.Contains(p.SolutionId) : true).OrderBy(p => p.InstallOrder);    

            Collection<SocialSitesFeature> features = new Collection<SocialSitesFeature>();
            var farmDefinitions = LocalFarm.Get().FeatureDefinitions;
            foreach (var solution in solutions)
            {
                foreach (var featureDefinition in farmDefinitions)
                {
                    try
                    {
                        if (featureDefinition != null && featureDefinition.SolutionId != Guid.Empty && featureDefinition.SolutionId == solution.SolutionId)
                        {
                            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_GettingFeatureDefinition, featureDefinition.Id.ToString()));

                            features.Add(new SocialSitesFeature()
                            {
                                FeatureDefinitionVersion = featureDefinition.Version,
                                FeatureId = featureDefinition.Id,
                                FeatureName = featureDefinition.DisplayName,
                                FeatureScope = featureDefinition.Scope,
                                SolutionInstallOrder = solution.InstallOrder
                            });
                        }
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorGettingFeatureDefinition, featureDefinition.DisplayName), OutputType.Error, exception.ToString(), exception);
                    }
                }
            }

            outputQueue.Add(UpgradeFeatures(features));

            outputQueue.Add(UserDisplay.UpgradingFeaturesComplete);

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue RemoveOrphanedFeatures()
        {
            // NOTE: Supressing the error logging from this method as we just want to try to remove
            // orphaned features (just video for now) but not alert the admin if we are unable to

            // The purpose of this method is to remove features that we know we are about to orphan
            // in the upgrade process. 

            var outputQueue = new OutputQueue();

            var features = Constants.Features.Orphaned.GetOrphanedFeaturesToRemove();
            if (features == null || !features.Any())
                return outputQueue;

            features = features.Where(p => LocalFarm.Get().FeatureDefinitions[p.FeatureId] != null).ToCollection();
            if (features == null || !features.Any())
                return outputQueue;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                outputQueue.Add(UserDisplay.FeatureUpgrade_CheckingForOldFeatures);
                
                foreach (var feature in features)
                {
                    try
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_RemovingFeature, feature.FeatureId));
                        LocalFarm.Get().FeatureDefinitions.Remove(feature.FeatureId, true);
                    }
                    catch { }
                }
            });

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue UpgradeFeatures(Collection<SocialSitesFeature> features)
        {
            var outputQueue = new OutputQueue();

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                if (features == null || !features.Any())
                    return;

                var farmFeatures = features.Where(p => p.FeatureScope == SPFeatureScope.Farm).OrderBy(p => p.SolutionInstallOrder);
                var webAppFeatures = features.Where(p => p.FeatureScope == SPFeatureScope.WebApplication).OrderBy(p => p.SolutionInstallOrder);
                var siteFeatures = features.Where(p => p.FeatureScope == SPFeatureScope.Site).OrderBy(p => p.SolutionInstallOrder);
                var webFeatures = features.Where(p => p.FeatureScope == SPFeatureScope.Web).OrderBy(p => p.SolutionInstallOrder);                

                if (farmFeatures.Any())
                {
                    foreach (var farmFeature in farmFeatures)
                    {
                        try
                        {
                            if (SPWebService.AdministrationService.Features[farmFeature.FeatureId] != null)
                            {
                                if (outputQueue != null)
                                    outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_UpdatingFarmFeature, farmFeature.FeatureName, farmFeature.FeatureId.ToString()));
                                var farmExceptions = SPWebService.AdministrationService.Features[farmFeature.FeatureId].Upgrade(true);
                                if (farmExceptions != null)
                                    if (outputQueue != null)
                                    {
                                        foreach (var exception in farmExceptions)
                                        {
                                            if (exception != null && !string.IsNullOrEmpty(exception.Message))
                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.UpdatingFeatureError, farmFeature.FeatureName, farmFeature.FeatureId.ToString(), exception.Message), OutputType.Error, exception.ToString(), exception);                                                
                                        }
                                    }
                            }
                        }
                        catch (Exception exception)
                        {
                            if (outputQueue != null)
                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeatureOnFarm, farmFeature.FeatureId.ToString()), OutputType.Error, exception.ToString(), exception);
                        }
                    }
                }

                if (webAppFeatures.Any() || siteFeatures.Any() || webFeatures.Any())
                {
                    if (outputQueue != null)
                            outputQueue.Add(UserDisplay.FeatureUpgrade_GettingWebApplications);

                    var webApps = new Collection<SPWebApplication>();
                    if (SPWebService.AdministrationService.WebApplications != null)
                        webApps.AddRange(SPWebService.AdministrationService.WebApplications.Where(p => p.IisSettings.Count > 0));
                    if (SPWebService.ContentService.WebApplications != null)
                        webApps.AddRange(SPWebService.ContentService.WebApplications.Where(p => p.IisSettings.Count > 0));

                    foreach (var webApp in webApps)
                    {
                        if (webApp != null)
                        {
                            try
                            {
                                if (webAppFeatures.Any())
                                {
                                    foreach (var webAppFeature in webAppFeatures)
                                    {
                                        try
                                        {
                                            if (webApp.Features[webAppFeature.FeatureId] != null)
                                            {
                                                if (outputQueue != null)
                                                    outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_UpdatingWebAppFeature, webAppFeature.FeatureName, webAppFeature.FeatureId.ToString(), (webApp.DisplayName ?? webApp.Name)));
                                                var webAppExceptions = webApp.Features[webAppFeature.FeatureId].Upgrade(true);
                                                if (webAppExceptions != null)
                                                    if (outputQueue != null)
                                                    {
                                                        foreach (var exception in webAppExceptions)
                                                        {
                                                            if (exception != null && !string.IsNullOrEmpty(exception.Message))
                                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.UpdatingFeatureError, webAppFeature.FeatureName, webAppFeature.FeatureId.ToString(), exception.Message), OutputType.Error, exception.ToString(), exception);
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            if (outputQueue != null)
                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeatureOnWebApp, webAppFeature.FeatureId.ToString(), webApp.DisplayName), OutputType.Error, exception.ToString(), exception);
                                        }
                                    }
                                }

                                if (siteFeatures.Any())
                                {
                                    foreach (var siteFeature in siteFeatures)
                                    {
                                        try
                                        {
                                            var featureInstances = webApp.QueryFeatures(siteFeature.FeatureId);
                                            foreach (var featureInstance in featureInstances)
                                            {
                                                var site = featureInstance.Parent as SPSite;
                                                if (site != null)
                                                {
                                                    try
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_UpdatingSiteFeature, siteFeature.FeatureName, siteFeature.FeatureId.ToString(), site.Url));
                                                        var siteExceptions = featureInstance.Upgrade(true);
                                                        if (siteExceptions != null)
                                                            if (outputQueue != null)
                                                            {
                                                                foreach (var exception in siteExceptions)
                                                                {
                                                                    if (exception != null && !string.IsNullOrEmpty(exception.Message))
                                                                        outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.UpdatingFeatureError, siteFeature.FeatureName, siteFeature.FeatureId.ToString(), exception.Message), OutputType.Error, exception.ToString(), exception);
                                                                }
                                                            }
                                                    }
                                                    catch (UnauthorizedAccessException exception)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UpgradeFeatureSiteAccessError, site.Url, exception), OutputType.Warning);
                                                    }
                                                    catch (SPFeatureIsOrphanedException)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UpgradeFeatureOrphanedSiteVerbose, site.Url), OutputType.Warning);
                                                    }
                                                    catch (Exception exception)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeatureOnSite, siteFeature.FeatureId.ToString(), site.Url), OutputType.Error, exception.ToString(), exception);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            if (outputQueue != null)
                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeature, siteFeature.FeatureId.ToString()), OutputType.Error, exception.ToString(), exception);
                                        }
                                    }
                                }

                                if (webFeatures.Any())
                                {
                                    foreach (var webFeature in webFeatures)
                                    {
                                        try
                                        {
                                            var featureInstances = webApp.QueryFeatures(webFeature.FeatureId);
                                            foreach (var featureInstance in featureInstances)
                                            {
                                                var web = featureInstance.Parent as SPWeb;
                                                if (web != null)
                                                {
                                                    var allowUnsafeUpdatesState = web.AllowUnsafeUpdates;
                                                    if (!allowUnsafeUpdatesState)
                                                    {
                                                        web.AllowUnsafeUpdates = true;
                                                        web.Update();
                                                    }

                                                    var site = web.Site;
                                                    try
                                                    {
                                                        HttpContext newContext = null;
                                                        try
                                                        {
                                                            // Need to fake an SPContext for some web feature receivers to work correctly
                                                            if (HttpContext.Current == null)
                                                            {
                                                                var request = new HttpRequest("", web.Url, "");
                                                                newContext = new HttpContext(request, new HttpResponse(TextWriter.Null));
                                                                HttpContext.Current = newContext;
                                                            }
                                                            HttpContext.Current.Items["HttpHandlerSPWeb"] = web;

                                                            if (outputQueue != null)
                                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, UserDisplay.FeatureUpgrade_UpdatingWebFeature, webFeature.FeatureName, webFeature.FeatureId.ToString(), web.Url));
                                                            var webExceptions = featureInstance.Upgrade(true);
                                                            if (webExceptions != null)
                                                                if (outputQueue != null)
                                                                {
                                                                    foreach (var exception in webExceptions)
                                                                    {
                                                                        if (exception != null && !string.IsNullOrEmpty(exception.Message))
                                                                            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.UpdatingFeatureError, webFeature.FeatureName, webFeature.FeatureId.ToString(), exception.Message), OutputType.Error, exception.ToString(), exception);
                                                                    }
                                                                }
                                                        }
                                                        catch (Exception exception)
                                                        {
                                                            if (outputQueue != null)
                                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeatureOnWeb, webFeature.FeatureId.ToString(), web.Url), OutputType.Error, exception.ToString(), exception);
                                                        }
                                                        finally
                                                        {
                                                            if (newContext != null)
                                                                HttpContext.Current = null;

                                                            if (!allowUnsafeUpdatesState)
                                                            {
                                                                web.AllowUnsafeUpdates = false;
                                                                web.Update();
                                                            }
                                                        }
                                                    }
                                                    catch (UnauthorizedAccessException exception)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UpgradeFeatureSiteAccessError, site.Url, exception), OutputType.Warning);
                                                    }
                                                    catch (SPFeatureIsOrphanedException)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UpgradeFeatureOrphanedSiteVerbose, site.Url), OutputType.Warning);
                                                    }
                                                    catch (Exception exception)
                                                    {
                                                        if (outputQueue != null)
                                                            outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeatureOnSite, webFeature.FeatureId.ToString(), site.Url), OutputType.Error, exception.ToString(), exception);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            if (outputQueue != null)
                                                outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingFeature, webFeature.FeatureId.ToString()), OutputType.Error, exception.ToString(), exception);
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                if (outputQueue != null)
                                    outputQueue.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.WebApplicationError, webApp.DisplayName), OutputType.Error, exception.ToString(), exception);
                            }
                        }
                    }
                }
            });

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static bool IsFeatureEnabled(Guid featureId, SPWebApplication webApplication = null, SPSite site = null, SPWeb web = null)
        {
            if (webApplication != null)
            {
                if (webApplication.Features != null)
                    if (webApplication.Features[featureId] != null)
                        return true;
            }
            else if (site != null)
            {
                if (site.Features != null)
                    if (site.Features[featureId] != null)
                        return true;
            }
            else if (web != null)
            {
                if (web.Features != null)
                    if (web.Features[featureId] != null)
                        return true;
            }
            else
            {
                if (SPWebService.AdministrationService.Features[featureId] != null)
                    return true;
            }

            return false;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue EnableFeature(Guid featureId, string url, SPFeatureScope scope)
        {
            var outputQueue = new OutputQueue();

            SPSecurity.RunWithElevatedPrivileges(
            delegate()
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ActivatingFeatureVerbose, featureId, url));
                try
                {
                    using (var site = new SPSite(url))
                    {
                        if (site != null)
                        {
                            if (scope == SPFeatureScope.Site)
                            {
                                if (site.Features[featureId] == null)
                                {
                                    site.Features.Add(featureId, true);
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.FeatureActivatedVerbose, featureId, url));
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.FeatureAlreadyActivatedVerbose, featureId, url));
                                }
                            }
                            else
                            {
                                using (var web = site.OpenWeb())
                                {
                                    if (web.Features[featureId] == null)
                                    {
                                        web.Features.Add(featureId, true);
                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.FeatureActivatedVerbose, featureId, url));
                                    }
                                    else
                                    {
                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.FeatureAlreadyActivatedVerbose, featureId, url));
                                    }
                                }
                            }
                        }
                        else
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.FeatureSiteError, url), OutputType.Warning);
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.FeatureSiteError, url), OutputType.Warning);
                }
                catch (Exception exception)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.FeatureActivationError, featureId, url, exception.Message), OutputType.Error, exception.ToString(), exception);
                }
            });

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableFeaturesForAllSolutionSets(bool deleteFeature = false)
        {
            var outputQueue = new OutputQueue();

            var solutions = Constants.Solutions.All.Get();
            foreach (var solution in solutions)
            {
                outputQueue.Add(DisableFeaturesForSolution(solution, deleteFeature));
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableFeaturesForSolutionSet(SolutionSet solutionSet, bool deleteFeature = false)
        {
            var outputQueue = new OutputQueue();

            var solutions = Constants.Solutions.All.Get().Where(p => p.SolutionSet == solutionSet);
            foreach (var solution in solutions)
            {
                outputQueue.Add(DisableFeaturesForSolution(solution, deleteFeature));
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableFeaturesForSolution(string solutionName, bool deleteFeature = false)
        {
            var outputQueue = new OutputQueue();

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureForSolution, solutionName));
            var solution = LocalFarm.Get().Solutions[solutionName];
            if (solution != null)
            {
                var featureDefinitions = LocalFarm.Get().FeatureDefinitions.Where(p => p.SolutionId == solution.SolutionId);
                foreach (var featureDefinition in featureDefinitions)
                {
                    outputQueue.Add(DisableFeature(featureDefinition, deleteFeature));
                }
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureForSolutionComplete, solutionName));
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableFeaturesForSolution(SocialSitesSolution solution, bool deleteFeature = false)
        {
            var outputQueue = new OutputQueue();

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureForSolution, solution.SolutionName));
            var featureDefinitions = LocalFarm.Get().FeatureDefinitions.Where(p => p.SolutionId == solution.SolutionId);
            foreach (var featureDefinition in featureDefinitions)
            {
                outputQueue.Add(DisableFeature(featureDefinition, deleteFeature));
            }
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureForSolutionComplete, solution.SolutionName));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "deleteFeature"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableFeature(SPFeatureDefinition featureDefinition, bool deleteFeature = false)
        {
            var outputQueue = new OutputQueue();

            if (featureDefinition != null)
            {
                var webApplications = new Collection<SPWebApplication>();

                try
                {
                    switch (featureDefinition.Scope)
                    {
                        case SPFeatureScope.Farm:
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeature, UserDisplay.FeatureScopeFarm, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            if (SPWebService.AdministrationService.Features[featureDefinition.Id] != null)
                            {
                                SPWebService.AdministrationService.Features.Remove(featureDefinition.Id, true);
                            }
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureComplete, UserDisplay.FeatureScopeFarm, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            break;
                        case SPFeatureScope.WebApplication:
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeature, UserDisplay.FeatureScopeWebApplication, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            webApplications.AddRange(SPWebService.AdministrationService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            webApplications.AddRange(SPWebService.ContentService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            foreach (var webApplication in webApplications)
                            {
                                if (webApplication.Features[featureDefinition.Id] != null)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureOn, UserDisplay.FeatureScopeWebApplication, webApplication.Name, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                                    webApplication.Features.Remove(featureDefinition.Id, true);
                                }
                            }
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureComplete, UserDisplay.FeatureScopeWebApplication, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            break;
                        case SPFeatureScope.Site:
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeature, UserDisplay.FeatureScopeSite, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            webApplications.AddRange(SPWebService.AdministrationService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            webApplications.AddRange(SPWebService.ContentService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            foreach (var webApplication in webApplications)
                            {
                                if (webApplication.Sites != null)
                                {
                                    foreach (SPSite site in webApplication.Sites)
                                    {
                                        try
                                        {
                                            if (!SiteCollections.IsSiteLocked(site.ID))
                                            {
                                                if (site.Features[featureDefinition.Id] != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureOn, UserDisplay.FeatureScopeWebApplication, site.Url, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                                                    site.Features.Remove(featureDefinition.Id, true);
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorDisablingFeatureSite, (string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName), site.ID, exception.Message), OutputType.Error, exception.ToString(), exception);                    
                                        }
                                        finally
                                        {
                                            site.Dispose();
                                        }
                                    }
                                }
                            }
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureComplete, UserDisplay.FeatureScopeSite, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            break;
                        case SPFeatureScope.Web:
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeature, UserDisplay.FeatureScopeWeb, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            webApplications.AddRange(SPWebService.AdministrationService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            webApplications.AddRange(SPWebService.ContentService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                            foreach (var webApplication in webApplications)
                            {
                                if (webApplication.Sites != null)
                                {
                                    foreach (SPSite site in webApplication.Sites)
                                    {
                                        try
                                        {
                                            if (!SiteCollections.IsSiteLocked(site.ID))
                                            {
                                                foreach (SPWeb web in site.AllWebs)
                                                {
                                                    try
                                                    {
                                                        if (web != null)
                                                        {
                                                            if (web.Features[featureDefinition.Id] != null)
                                                            {
                                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureOn, UserDisplay.FeatureScopeWebApplication, web.Url, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                                                                web.Features.Remove(featureDefinition.Id, true);
                                                            }
                                                        }
                                                    }
                                                    catch (Exception exception)
                                                    {
                                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorDisablingFeatureWeb, (string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName), web.Url, exception.Message), OutputType.Error, exception.ToString(), exception);                    
                                                    }
                                                    finally
                                                    {
                                                        web.Dispose();
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorDisablingFeatureSite, (string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName), site.ID, exception.Message), OutputType.Error, exception.ToString(), exception);                    
                                        }
                                        finally
                                        {
                                            site.Dispose();
                                        }
                                    }
                                }
                            }
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableFeatureComplete, UserDisplay.FeatureScopeWeb, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                            break;
                    }

                    //if (deleteFeature)
                    //{
                    //    try
                    //    {
                    //        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DeleteFeature, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                    //        featureDefinition.Delete();
                    //        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DeleteFeatureComplete, string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName));
                    //    }
                    //    catch (Exception exception)
                    //    {
                    //        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorDeletingFeature, (string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName), exception.Message), OutputType.Error, exception.ToString(), exception);
                    //    }
                    //}

                }
                catch (Exception exception)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorDisablingFeature, (string.IsNullOrEmpty(featureDefinition.DisplayName) ? featureDefinition.Name : featureDefinition.DisplayName), exception.Message), OutputType.Error, exception.ToString(), exception);                    
                }
            }

            return outputQueue;
        }
    }
}
