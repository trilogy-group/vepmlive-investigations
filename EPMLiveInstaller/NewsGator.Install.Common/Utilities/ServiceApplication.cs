using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Entities.SocialSites.ServiceApplicationProxies;
using NewsGator.Install.Common.Entities.SocialSites.ServiceApplications;
using NewsGator.Install.Common.Entities.SocialSites.ServiceConfigurations;
using NewsGator.Install.Common.Entities.SocialSites.ServiceInstances;
using NewsGator.Install.Common.Entities.SocialSites.ServiceProxies;
using NewsGator.Install.Common.Entities.SocialSites.Services;
using NewsGator.Install.Common.Entities.SocialSites.ServiceSetupInformation;
using NewsGator.Install.Resources;
using System.Globalization;
using NewsGator.Install.Common.Tasks;
using Microsoft.SharePoint.Upgrade;
using System.Data.SqlClient;
using System.Data;

namespace NewsGator.Install.Common.Utilities
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
    public static class ServiceApplication
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static SPIisWebServiceApplication FindServiceInstanceWhereOrDefault(Func<SPServiceApplication, bool> whereClause)
        {
            return (from svc in LocalFarm.Get().Services from serviceApp in svc.Applications where whereClause(serviceApp) select serviceApp as SPIisWebServiceApplication).FirstOrDefault();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue UpdateNotificationProviders()
        {
            var outputQueue = new OutputQueue();

            var socialSitesServiceApplicationType = SocialServiceApplication.ServiceApplicationType;
            if (socialSitesServiceApplicationType == null)
                outputQueue.Add(Exceptions.MissingSocialServiceApplicationTypesError, OutputType.Error);

            if (socialSitesServiceApplicationType != null)
            {
                foreach (var svc in LocalFarm.Get().Services)
                {
                    foreach (var serviceApp in svc.Applications)
                    {
                        try
                        {
                            if (serviceApp.GetType() == socialSitesServiceApplicationType)
                            {
                                outputQueue.Add(UserDisplay.UpgradeSocialNotifications);
                                try
                                {
                                    Utilities.Reflection.ExecuteMethod(socialSitesServiceApplicationType, serviceApp, "UpgradeNotifications", new Type[] { }, null);
                                }
                                catch (Exception exception)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeNotifications", exception.Message), OutputType.Error, null, exception);
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeNotifications", exception.Message), OutputType.Error, null, exception);
                        }
                    }
                }
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "16#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Username"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "KnowledgeBase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "20#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "17#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "21#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "19#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "18#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue ProvisionNewsGatorServiceApplication(
            ServiceApplicationType serviceApplicationType,
            string databaseName,
            string databaseServer,
            string databaseFailoverServer,
            string reportDatabaseName,
            string reportDatabaseServer,
            string reportDatabaseFailoverServer,
            string applicationPoolName,
            string applicationPoolUsername,
            string applicationPoolPassword,
            string licenseKey,
            string emailListLocation,
            string videoEncodingInputFolder,
            string videoEncodingOutputFolder,
            string videoStreamingServerFolder,
            string videoUploadFolder,
            string videoStreamingServerUrlDefaultZone,
            string videoStreamingServerUrlIntranetZone,
            string videoStreamingServerUrlInternetZone,
            string videoStreamingServerUrlCustomZone,
            string videoStreamingServerUrlExtranetZone,
            string learningGlobalKnowledgeBase,
            bool useTimerJob)
        {
            var outputQueue = new OutputQueue();

            SPIisWebServiceApplicationPool appPool = null;
            try
            {
                if (!string.IsNullOrEmpty(applicationPoolName))
                {
                    outputQueue.Add(ApplicationPools.GetOrCreateApplicationPool(applicationPoolName, applicationPoolUsername, applicationPoolPassword, out appPool));
                }
            }
            catch (Exception exception)
            {
                appPool = null;
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UnableToCreateServiceAppPool, applicationPoolName, exception.Message), OutputType.Error, null, exception);
            }

            outputQueue.Add(ProvisionNewsGatorServiceApplication(
                serviceApplicationType,
                databaseName,
                databaseServer,
                databaseFailoverServer,
                reportDatabaseName,
                reportDatabaseServer,
                reportDatabaseFailoverServer,
                appPool,
                licenseKey,
                emailListLocation,
                videoEncodingInputFolder,
                videoEncodingOutputFolder,
                videoStreamingServerFolder,
                videoUploadFolder,
                videoStreamingServerUrlDefaultZone,
                videoStreamingServerUrlIntranetZone,
                videoStreamingServerUrlInternetZone,
                videoStreamingServerUrlCustomZone,
                videoStreamingServerUrlExtranetZone,
                learningGlobalKnowledgeBase,
                useTimerJob));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "14#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "KnowledgeBase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "18#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "15#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "19#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "17#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "16#")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust"), CLSCompliant(false)]
        public static OutputQueue ProvisionNewsGatorServiceApplication(
            ServiceApplicationType serviceApplicationType,
            string databaseName = null,
            string databaseServer = null,
            string databaseFailoverServer = null,
            string reportDatabaseName = null,
            string reportDatabaseServer = null,
            string reportDatabaseFailoverServer = null,
            SPIisWebServiceApplicationPool applicationPool = null,
            string licenseKey = null,
            string emailListLocation = null,
            string videoEncodingInputFolder = null,
            string videoEncodingOutputFolder = null,
            string videoStreamingServerFolder = null,
            string videoUploadFolder = null,
            string videoStreamingServerUrlDefaultZone = null,
            string videoStreamingServerUrlIntranetZone = null,
            string videoStreamingServerUrlInternetZone = null,
            string videoStreamingServerUrlCustomZone = null,
            string videoStreamingServerUrlExtranetZone = null,
            string learningGlobalKnowledgeBase = null,
            bool useTimerJob = false)
        {
            var outputQueue = new OutputQueue();
            try
            {
                IInstallTask taskToRun = null;
                outputQueue.Add(UserDisplay.ProvisionServiceApplicationStart);
                var farm = LocalFarm.Get();
                var adminService = SPWebService.AdministrationService;
                databaseServer = string.IsNullOrEmpty(databaseServer) ? new SPWebApplicationBuilder(farm).DatabaseServer : databaseServer;
                reportDatabaseServer = string.IsNullOrEmpty(reportDatabaseServer) ? databaseServer : reportDatabaseServer;
                Type serviceType = null;
                Type serviceInstanceType = null;
                Type serviceProxyType = null;
                Type serviceApplicationObjectType = null;
                var serviceName = string.Empty;

                if (applicationPool == null)
                {

                    outputQueue.Add(UserDisplay.ApplicationPoolNotSpecified, OutputType.Warning);
                    applicationPool = farm.GetObject("SharePoint Web Services System", Guid.Empty, typeof(SPIisWebServiceApplicationPool)) as SPIisWebServiceApplicationPool;
                }

                switch (serviceApplicationType)
                {
                    case ServiceApplicationType.SocialPlatform:
                        {
                            databaseName = string.IsNullOrEmpty(databaseName) ? "NewsGator_PlatformServices" : databaseName;
                            reportDatabaseName = string.IsNullOrEmpty(reportDatabaseName) ? "NewsGator_Reporting" : reportDatabaseName;
                            serviceName = "NewsGator Social Platform Services";

                            var coreSolution = farm.Solutions[Constants.Solutions.SocialPlatform.NewsGatorCore.SolutionId];
                            var coreApplicationSolution = farm.Solutions[Constants.Solutions.SocialPlatform.NewsGatorCoreApplication.SolutionId];
                            if (coreSolution == null || coreApplicationSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorCoreWspSolutionIsNotInstalledCann, OutputType.Error);
                                return outputQueue;
                            }
                            if (!coreSolution.Deployed || !coreApplicationSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorCoreWspSolutionIsNotDeployedCanno, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = SocialService.ServiceType;
                            serviceInstanceType = SocialServiceInstance.ServiceInstanceType;
                            serviceProxyType = SocialServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = SocialServiceApplication.ServiceApplicationType;

                            if (adminService.Features[Constants.Features.SocialPlatform.InstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.SocialPlatform.InstallerFeature);
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.SocialPlatform.InstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }
                        }
                        break;
                    case ServiceApplicationType.NewsStream:
                        {
                            databaseName = string.IsNullOrEmpty(databaseName) ? "NewsGator_NewsManager" : databaseName;
                            serviceName = "NewsGator News Stream Services";

                            var nmSolution = farm.Solutions[Constants.Solutions.NewsStream.NewsGatorNewsManager.SolutionId];
                            if (nmSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorNewsManagerWspSolutionIsNotInstal, OutputType.Error);
                                return outputQueue;
                            }
                            if (!nmSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorNewsManagerWspSolutionIsNotDeploy, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = NewsManagerService.ServiceType;
                            serviceInstanceType = NewsManagerServiceInstance.ServiceInstanceType;
                            serviceProxyType = NewsManagerServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = NewsManagerServiceApplication.ServiceApplicationType;

                            if (adminService.Features[Constants.Features.NewsStream.NewsManagerInstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.NewsStream.NewsManagerInstallerFeature);
                                }
                                catch (Exception exception)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.NewsStream.NewsManagerInstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                        }
                        break;
                    case ServiceApplicationType.VideoStream:
                        {
                            databaseName = string.IsNullOrEmpty(databaseName) ? "NewsGator_Videos" : databaseName;
                            serviceName = "NewsGator Video Stream Services";

                            var videoSolution = farm.Solutions[Constants.Solutions.VideoStream.NewsGatorVideoStreamApp.SolutionId];
                            if (videoSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorVideoStreamAppWspSolutionIsNotIns, OutputType.Error);
                                return outputQueue;
                            }
                            if (!videoSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorVideoStreamAppWspSolutionIsNotDep, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = VideoService.ServiceType;
                            serviceInstanceType = VideoServiceInstance.ServiceInstanceType;
                            serviceProxyType = VideoServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = VideoServiceApplication.ServiceApplicationType;

                            var videoRestart = false;

                            if (adminService.Features[Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature);
                                    videoRestart = true;
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (adminService.Features[Constants.Features.VideoStream.VideoDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.VideoStream.VideoDependencyInjectionFeature);
                                    videoRestart = true;
                                }
                                catch (Exception exception)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.VideoStream.VideoDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (farm.Solutions[Constants.Solutions.EnrichVideoScenarios.NewsGatorLearningVideoScenariosApp.SolutionId] != null)
                            {
                                if (adminService.Features[Constants.Features.Enrich.EnrichDependencyInjectionFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.Enrich.EnrichDependencyInjectionFeature);
                                        videoRestart = true;
                                    }
                                    catch (Exception exception)
                                    {
                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Enrich.EnrichDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                                if (adminService.Features[Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature);
                                        videoRestart = true;
                                    }
                                    catch (Exception exception)
                                    {
                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                            }

                            if (videoRestart)
                            {
                                taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                            }

                            if (adminService.Features[Constants.Features.VideoStream.VideoInstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.VideoStream.VideoInstallerFeature);
                                }
                                catch (Exception exception)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.VideoStream.VideoInstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (farm.Solutions[Constants.Solutions.EnrichVideoScenarios.NewsGatorLearningVideoScenariosApp.SolutionId] != null)
                            {
                                if (adminService.Features[Constants.Features.Enrich.EnrichInstallerFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.Enrich.EnrichInstallerFeature);
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Enrich.EnrichInstallerFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                                if (adminService.Features[Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature);
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                            }
                        }
                        break;
                    case ServiceApplicationType.Learning:
                        {
                            serviceName = "NewsGator Enrich Services";

                            var learningSolution = farm.Solutions[Constants.Solutions.Enrich.NewsGatorLearningPointApp.SolutionId];
                            if (learningSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorEnrichWspSolutionIsNotIns, OutputType.Error);
                                return outputQueue;
                            }
                            if (!learningSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorEnrichWspSolutionIsNotDep, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = EnrichService.ServiceType;
                            serviceInstanceType = EnrichServiceInstance.ServiceInstanceType;
                            serviceProxyType = EnrichServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = EnrichServiceApplication.ServiceApplicationType;

                            var enrichRestart = false;

                            if (adminService.Features[Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature);
                                    enrichRestart = true;
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (adminService.Features[Constants.Features.Enrich.EnrichDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.Enrich.EnrichDependencyInjectionFeature);
                                    enrichRestart = true;
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Enrich.EnrichDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (farm.Solutions[Constants.Solutions.EnrichVideoScenarios.NewsGatorLearningVideoScenariosApp.SolutionId] != null)
                            {
                                if (adminService.Features[Constants.Features.VideoStream.VideoDependencyInjectionFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.VideoStream.VideoDependencyInjectionFeature);
                                        enrichRestart = true;
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.VideoStream.VideoDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }

                                if (adminService.Features[Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature);
                                        enrichRestart = true;
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                            }

                            if (enrichRestart)
                            {
                                taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                            }

                            if (adminService.Features[Constants.Features.Enrich.EnrichInstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.Enrich.EnrichInstallerFeature);
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Enrich.EnrichInstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (farm.Solutions[Constants.Solutions.EnrichVideoScenarios.NewsGatorLearningVideoScenariosApp.SolutionId] != null)
                            {
                                if (adminService.Features[Constants.Features.VideoStream.VideoInstallerFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.VideoStream.VideoInstallerFeature);
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.VideoStream.VideoInstallerFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                                if (adminService.Features[Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature] == null)
                                {
                                    try
                                    {
                                        adminService.Features.Add(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature);
                                    }
                                    catch (Exception exception)
                                    {

                                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosInstallerFeature, exception.ToString()), OutputType.Warning);
                                    }
                                }
                            }
                        }
                        break;
                    case ServiceApplicationType.InterComm:
                        {
                            serviceName = "NewsGator Internal Communications Services";

                            var icSolution = farm.Solutions[Constants.Solutions.InterComm.NewsGatorCorpComm.SolutionId];
                            if (icSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorInterCommWspSolutionIsNotInstal, OutputType.Error);
                                return outputQueue;
                            }
                            if (!icSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorInterCommWspSolutionIsNotDeploy, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = InterCommService.ServiceType;
                            serviceInstanceType = InterCommServiceInstance.ServiceInstanceType;
                            serviceProxyType = InterCommServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = InterCommServiceApplication.ServiceApplicationType;

                            if (adminService.Features[Constants.Features.InterComm.InterCommInstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.InterComm.InterCommInstallerFeature);
                                }
                                catch (Exception exception)
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.InterComm.InterCommInstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }
                        }
                        break;
                    case ServiceApplicationType.Innovation:
                        {
                            databaseName = string.IsNullOrEmpty(databaseName) ? "NewsGator_Innovation" : databaseName;
                            serviceName = "NewsGator Innovation Services";

                            var innovationSolution = farm.Solutions[Constants.Solutions.Innovation.NewsGatorInnovationApp.SolutionId];
                            if (innovationSolution == null)
                            {
                                outputQueue.Add(Exceptions.NewsGatorInnovationAppWspSolutionIsNotIns, OutputType.Error);
                                return outputQueue;
                            }
                            if (!innovationSolution.Deployed)
                            {
                                outputQueue.Add(Exceptions.NewsGatorInnovationAppWspSolutionIsNotDep, OutputType.Error);
                                return outputQueue;
                            }

                            serviceType = InnovationService.ServiceType;
                            serviceInstanceType = InnovationServiceInstance.ServiceInstanceType;
                            serviceProxyType = InnovationServiceProxy.ServiceProxyType;
                            serviceApplicationObjectType = InnovationServiceApplication.ServiceApplicationType;

                            var innovationRestart = false;

                            if (adminService.Features[Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature);
                                    innovationRestart = true;
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.CanadaCommon.CommonAssembliesDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (adminService.Features[Constants.Features.Innovation.InnovationDependencyInjectionFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.Innovation.InnovationDependencyInjectionFeature);
                                    innovationRestart = true;
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Innovation.InnovationDependencyInjectionFeature, exception.ToString()), OutputType.Warning);
                                }
                            }

                            if (innovationRestart)
                            {
                                taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                            }

                            if (adminService.Features[Constants.Features.Innovation.InnovationInstallerFeature] == null)
                            {
                                try
                                {
                                    adminService.Features.Add(Constants.Features.Innovation.InnovationInstallerFeature);
                                }
                                catch (Exception exception)
                                {

                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorWhileAddingFeature, Constants.Features.Innovation.InnovationInstallerFeature, exception.ToString()), OutputType.Warning);
                                }
                            }
                        }
                        break;
                }

                var databaseOptions = SPDatabaseParameterOptions.None;
                SPDatabaseParameters databaseParameters = null;
                SPDatabaseParameters reportingDatabaseParameters = null;
                string nullString = null;

                if (serviceApplicationType != ServiceApplicationType.Learning && serviceApplicationType != ServiceApplicationType.InterComm)
                {
                    if (string.IsNullOrEmpty(databaseFailoverServer))
                    {
                        databaseParameters = SPDatabaseParameters.CreateParameters(databaseName, databaseServer, databaseOptions);
                        if (!string.IsNullOrEmpty(reportDatabaseName))
                            reportingDatabaseParameters = SPDatabaseParameters.CreateParameters(reportDatabaseName, reportDatabaseServer, databaseOptions);
                    }
                    else
                    {
                        databaseParameters = SPDatabaseParameters.CreateParameters(databaseName, databaseServer, null, nullString, databaseFailoverServer, databaseOptions);
                        if (!string.IsNullOrEmpty(reportDatabaseName))
                        {
                            if (string.IsNullOrEmpty(reportDatabaseFailoverServer))
                                reportingDatabaseParameters = SPDatabaseParameters.CreateParameters(reportDatabaseName, reportDatabaseServer, databaseOptions);
                            else
                                reportingDatabaseParameters = SPDatabaseParameters.CreateParameters(reportDatabaseName, reportDatabaseServer, null, nullString, reportDatabaseFailoverServer, databaseOptions);
                        }
                    }
                }

                //outputQueue.Add(Services.EnsureTimerAllServers());

                outputQueue.Add(UserDisplay.EnsuringServiceExists);
                SPPersistedObject service = Service.Get(serviceType);
                if (service == null)
                {
                    outputQueue.Add(UserDisplay.ServiceDoesNotExistAttemptingToCreate);
                    service = (SPPersistedObject)Activator.CreateInstance(serviceType, farm);
                    service.Status = SPObjectStatus.Online;
                    service.Provision();
                    service.Update();
                }

                outputQueue.Add(UserDisplay.EnsuringServiceInstanceExists);
                foreach (var server in farm.Servers)
                {
                    if (!Server.ValidSPServerRole(server.Role))
                        continue;

                    SPPersistedObject serverServiceInstance = ServiceInstance.Get(server, serviceInstanceType);

                    if (serverServiceInstance == null)
                    {
                        serverServiceInstance = (SPPersistedObject)Activator.CreateInstance(serviceInstanceType, server, service);
                        serverServiceInstance.Update(true);
                    }

                    if (serverServiceInstance.Status != SPObjectStatus.Online && server.Id == SPServer.Local.Id)
                    {
                        serverServiceInstance.Provision();
                    }
                }

                outputQueue.Add(UserDisplay.EnsuringServiceProxyExists);
                SPPersistedObject serviceProxy = null;
                switch (serviceApplicationType)
                {
                    case ServiceApplicationType.SocialPlatform:
                        serviceProxy = SocialServiceProxy.Get(farm.ServiceProxies);
                        break;
                    case ServiceApplicationType.NewsStream:
                        serviceProxy = NewsManagerServiceProxy.Get(farm.ServiceProxies);
                        break;
                    case ServiceApplicationType.VideoStream:
                        serviceProxy = VideoServiceProxy.Get(farm.ServiceProxies);
                        break;
                    case ServiceApplicationType.Learning:
                        serviceProxy = EnrichServiceProxy.Get(farm.ServiceProxies);
                        break;
                    case ServiceApplicationType.InterComm:
                        serviceProxy = InterCommServiceProxy.Get(farm.ServiceProxies);
                        break;
                    case ServiceApplicationType.Innovation:
                        serviceProxy = InnovationServiceProxy.Get(farm.ServiceProxies);
                        break;
                }

                if (serviceProxy == null)
                {

                    outputQueue.Add(UserDisplay.ServiceProxyDoesNotExistAttemptingToCreate);
                    serviceProxy = (SPPersistedObject)Activator.CreateInstance(serviceProxyType, farm);
                    serviceProxy.Provision();
                    serviceProxy.Update(true);
                }

                //taskToRun = new Tasks.Services.RestartServices() as IInstallTask;
                //outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));

                outputQueue.Add(UserDisplay.CreatingService);
                SPPersistedObject app = null;
                switch (serviceApplicationType)
                {
                    case ServiceApplicationType.SocialPlatform:
                        app = SocialServiceApplication.Create(serviceName, service, applicationPool, databaseParameters, reportingDatabaseParameters);
                        break;
                    case ServiceApplicationType.NewsStream:
                        app = NewsManagerServiceApplication.Create(serviceName, service, applicationPool, databaseParameters);
                        break;
                    case ServiceApplicationType.VideoStream:
                        app = VideoServiceApplication.Create(serviceName, service, applicationPool, databaseParameters);
                        break;
                    case ServiceApplicationType.Learning:
                        app = EnrichServiceApplication.Create(serviceName, service, applicationPool);
                        break;
                    case ServiceApplicationType.InterComm:
                        app = InterCommServiceApplication.Create(serviceName, service, applicationPool);
                        break;
                    case ServiceApplicationType.Innovation:
                        app = InnovationServiceApplication.Create(serviceName, service, applicationPool, databaseParameters);
                        break;
                }

                try
                {
                    //taskToRun = new Tasks.Services.RestartServices() as IInstallTask;
                    //outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                    //outputQueue.Add(Services.EnsureTimerAllServers());

                    outputQueue.Add(UserDisplay.ProvisioningServiceApplication);
                    app.Provision();
                    app.Update(true);

                    outputQueue.Add(UserDisplay.ServiceApplicationProvisioned);
                }
                catch (SPUpdatedConcurrencyException)
                {
                    taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                    outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                    //outputQueue.Add(Services.EnsureTimerAllServers());
                    if (app != null)
                    {

                        outputQueue.Add(UserDisplay.ProvisioningServiceApplication);
                        app.Provision();
                        app.Update(true);

                        outputQueue.Add(UserDisplay.ServiceApplicationProvisioned);
                    }
                }

                if (serviceApplicationType == ServiceApplicationType.SocialPlatform)
                {
                    if (!string.IsNullOrEmpty(emailListLocation))
                    {
                        try
                        {

                            outputQueue.Add(UserDisplay.ProvisioningEmailHandler);
                            Reflection.ExecuteMethod(serviceApplicationObjectType, app, "ProvisionEmailWeb", new Type[] { typeof(String) }, new object[] { emailListLocation });
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ProvisioningEmailHandlerError, exception.Message), OutputType.Error, null, exception);
                        }
                    }

                    try
                    {
                        outputQueue.Add(UserDisplay.ProvisionNewsgatorCustomUserProfileProperties);
                        Reflection.ExecuteMethod(serviceApplicationObjectType, app, "ProvisionNewsgatorCustomUserProfileProperties", new Type[] { }, null);
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ProvisionNewsgatorCustomUserProfilePropertiesError, exception.Message), OutputType.Error, null, exception);
                    }

                    try
                    {

                        outputQueue.Add(UserDisplay.ProvisioningActivityTemplates);
                        Reflection.ExecuteMethod(serviceApplicationObjectType, app, "ProvisionApplicationTemplates", new Type[] { }, null);

                        {
                            if ((bool)Reflection.GetPropertyValue(serviceApplicationObjectType, app, "ActivitiesProvisioned"))
                                outputQueue.Add(UserDisplay.ActivitiesProvisioned);
                            else
                                outputQueue.Add(UserDisplay.ActivitiesNotProvisioned, OutputType.Warning);
                        }
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ActivitiesError, exception.Message), OutputType.Error, null, exception);
                    }

                    try
                    {
                        outputQueue.Add(UserDisplay.SecuritySocialDatabase);
                        Reflection.ExecuteMethod(serviceApplicationObjectType, app, "ProvisionSocialDBSecurity", new Type[] { }, null);
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.SecuritySocialDatabaseError, exception.Message), OutputType.Error, null, exception);
                    }

                    try
                    {
                        outputQueue.Add(UserDisplay.SecurityReportDatabase);
                        Reflection.ExecuteMethod(serviceApplicationObjectType, app, "ProvisionReportDBSecurity", new Type[] { }, null);
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.SecurityReportDatabaseError, exception.Message), OutputType.Error, null, exception);
                    }

                    outputQueue.Add(UserDisplay.ServiceProvisioningComplete);

                    var db = new Database();
                    var connStr = Reflection.GetPropertyValue(serviceApplicationObjectType, app, "DatabaseConnection").ToString();
                    var rConnStr = Reflection.GetPropertyValue(serviceApplicationObjectType, app, "ReportDatabaseConnection").ToString();

                    outputQueue.Add(UserDisplay.CheckingServicesDatabaseVersion);
                    var verStr = db.GetDatabaseVersion(connStr);
                    var version = new Version(!string.IsNullOrEmpty(verStr) ? verStr : "1.0.0.0");
                    if (version < BuildVersion.Version)
                    {
                        try
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.SocialDatabaseNotUpgraded, version, BuildVersion.Version));
                            SPDatabase ssDB = Reflection.GetPropertyValue(serviceApplicationObjectType, app, "SocialDatabase") as SPDatabase;
                            ssDB.Upgrade();
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.SocialDatabaseUpgradeError, exception.Message), OutputType.Error, null, exception);
                        }
                    }


                    outputQueue.Add(UserDisplay.CheckingReportingDatabaseVersion);
                    verStr = db.GetDatabaseVersion(rConnStr);
                    version = new Version(!string.IsNullOrEmpty(verStr) ? verStr : "1.0.0.0");
                    if (version < BuildVersion.Version)
                    {
                        try
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ReportingDatabaseNotUpgraded, version, BuildVersion.Version));
                            SPDatabase srDB = Reflection.GetPropertyValue(serviceApplicationObjectType, app, "ReportDatabase") as SPDatabase;
                            srDB.Upgrade();
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ReportingDatabaseUpgradeError, exception.Message), OutputType.Error, null, exception);
                        }
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(licenseKey))
                            Reflection.ExecuteMethod(serviceApplicationObjectType, app, "SetLicenseKey", new Type[] { typeof(string) }, new object[] { licenseKey });
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.LicenseKeyError, exception.Message), OutputType.Error, null, exception);
                    }
                }

                if (serviceApplicationType == ServiceApplicationType.VideoStream)
                {
                    var config = Activator.CreateInstance(VideoServiceConfiguration.ServiceConfigurationType);

                    Reflection.SetPropertyValue(config, "EncodingInputFolder", videoEncodingInputFolder);
                    Reflection.SetPropertyValue(config, "EncodingOutputFolder", videoEncodingOutputFolder);
                    Reflection.SetPropertyValue(config, "StreamingServerFolder", videoStreamingServerFolder);
                    Reflection.SetPropertyValue(config, "UploadFolder", videoUploadFolder);
                    Reflection.SetPropertyValue(config, "StreamingServerUrlDefaultZone", videoStreamingServerUrlDefaultZone);
                    Reflection.SetPropertyValue(config, "StreamingServerUrlCustomZone", videoStreamingServerUrlCustomZone);
                    Reflection.SetPropertyValue(config, "StreamingServerUrlExtranetZone", videoStreamingServerUrlExtranetZone);
                    Reflection.SetPropertyValue(config, "StreamingServerUrlInternetZone", videoStreamingServerUrlInternetZone);
                    Reflection.SetPropertyValue(config, "StreamingServerUrlIntranetZone", videoStreamingServerUrlIntranetZone);

                    var videoDb = (SPDatabase)Reflection.GetPropertyValue(serviceApplicationObjectType, app, "Database");
                    Reflection.SetPropertyValue(config, "ServiceAppConnectionString", videoDb.DatabaseConnectionString);

                    var repo = VideoSetupInformation.GetConfigRepository();
                    Reflection.ExecuteMethod(repo.GetType(), repo, "Set",
                                            new[] { VideoServiceConfiguration.ServiceConfigurationType },
                                            new[] { config });

                }

                if (serviceApplicationType == ServiceApplicationType.Learning)
                {
                    var config = Activator.CreateInstance(EnrichServiceConfiguration.ServiceConfigurationType);

                    Reflection.SetPropertyValue(config, "GlobalCommunityUrl", learningGlobalKnowledgeBase);
                    var repo = EnrichSetupInformation.GetConfigRepository();
                    Reflection.ExecuteMethod(repo.GetType(), repo, "Set",
                                            new[] { EnrichServiceConfiguration.ServiceConfigurationType },
                                            new[] { config });

                }

                if (serviceApplicationType == ServiceApplicationType.Innovation)
                {
                    var config = Activator.CreateInstance(InnovationServiceConfiguration.ServiceConfigurationType);

                    var innovationDb = (SPDatabase)Reflection.GetPropertyValue(serviceApplicationObjectType, app, "Database");
                    Reflection.SetPropertyValue(config, "ServiceAppConnectionString", innovationDb.DatabaseConnectionString);

                    var repo = InnovationSetupInformation.GetConfigRepository();
                    Reflection.ExecuteMethod(repo.GetType(), repo, "Set",
                                            new[] { InnovationServiceConfiguration.ServiceConfigurationType },
                                            new[] { config });


                }


                outputQueue.Add(UserDisplay.AttemptingToCreateServiceApplicationProxy);
                switch (serviceApplicationType)
                {
                    case ServiceApplicationType.SocialPlatform:
                        {
                            var serviceApplication = SocialServiceApplication.FindInstance();
                            var serviceProxyLocal = SocialServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApplication.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(SocialServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                var serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(SocialServiceApplicationProxy.ServiceApplicationProxyType, serviceName + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                    case ServiceApplicationType.NewsStream:
                        {
                            var serviceApp = NewsManagerServiceApplication.FindInstance();
                            var serviceProxyLocal = NewsManagerServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApp.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(NewsManagerServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                SPServiceApplicationProxy serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(NewsManagerServiceApplicationProxy.ServiceApplicationProxyType, serviceApp.Name + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                    case ServiceApplicationType.VideoStream:
                        {
                            var serviceApp = VideoServiceApplication.FindInstance();
                            var serviceProxyLocal = VideoServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApp.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(VideoServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                var serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(VideoServiceApplicationProxy.ServiceApplicationProxyType, serviceApp.Name + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                    case ServiceApplicationType.Learning:
                        {
                            var serviceApp = EnrichServiceApplication.FindInstance();
                            var serviceProxyLocal = EnrichServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApp.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(EnrichServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                var serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(EnrichServiceApplicationProxy.ServiceApplicationProxyType, serviceApp.Name + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                    case ServiceApplicationType.InterComm:
                        {
                            var serviceApp = InterCommServiceApplication.FindInstance();
                            var serviceProxyLocal = InterCommServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApp.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(InterCommServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                var serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(InterCommServiceApplicationProxy.ServiceApplicationProxyType, serviceApp.Name + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                    case ServiceApplicationType.Innovation:
                        {
                            var serviceApp = InnovationServiceApplication.FindInstance();
                            var serviceProxyLocal = InnovationServiceProxy.Get(LocalFarm.Get().ServiceProxies) as SPIisWebServiceProxy;
                            var serviceAppUri = serviceApp.Uri;

                            SPServiceApplicationProxy proxy = null;
                            try
                            {
                                proxy = SPServiceContext.Current.GetDefaultProxy(InnovationServiceApplicationProxy.ServiceApplicationProxyType);
                            }
                            catch
                            {
                                proxy = null;
                            }

                            if (proxy == null)
                            {
                                var serviceAppProxy =
                                    (SPServiceApplicationProxy)Activator.CreateInstance(InnovationServiceApplicationProxy.ServiceApplicationProxyType, serviceApp.Name + " Proxy", serviceProxyLocal, serviceAppUri);
                                serviceAppProxy.Provision();

                                SPServiceApplicationProxyGroup.Default.Add(serviceAppProxy);
                                SPServiceApplicationProxyGroup.Default.Update();
                            }
                        }
                        break;
                }


                outputQueue.Add(UserDisplay.ServiceApplicationProxyProvisioned);
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorProvisioningServiceApplication, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue RemoveNewsGatorServiceApplication(ServiceApplicationType serviceApplicationType, bool deleteDatabases)
        {
            var outputQueue = new OutputQueue();

            try
            {
                Type serviceApplicationObjectType = null;
                Type serviceInstanceObjectType = null;
                Type serviceObjectType = null;
                var serviceApplicationObjectTypeName = string.Empty;

                switch (serviceApplicationType)
                {
                    case ServiceApplicationType.SocialPlatform:
                        serviceApplicationObjectType = SocialServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = SocialServiceInstance.ServiceInstanceType;
                        serviceObjectType = SocialService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationSocial;
                        break;
                    case ServiceApplicationType.NewsStream:
                        serviceApplicationObjectType = NewsManagerServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = EnrichServiceInstance.ServiceInstanceType;
                        serviceObjectType = NewsManagerService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationNews;
                        break;
                    case ServiceApplicationType.Learning:
                        serviceApplicationObjectType = EnrichServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = EnrichServiceInstance.ServiceInstanceType;
                        serviceObjectType = EnrichService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationEnrich;
                        break;
                    case ServiceApplicationType.VideoStream:
                        serviceApplicationObjectType = VideoServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = VideoServiceInstance.ServiceInstanceType;
                        serviceObjectType = VideoService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationVideo;
                        break;
                    case ServiceApplicationType.InterComm:
                        serviceApplicationObjectType = InterCommServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = InterCommServiceInstance.ServiceInstanceType;
                        serviceObjectType = InterCommService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationInterComm;
                        break;
                    case ServiceApplicationType.Innovation:
                        serviceApplicationObjectType = InnovationServiceApplication.ServiceApplicationType;
                        serviceInstanceObjectType = InnovationServiceInstance.ServiceInstanceType;
                        serviceObjectType = InnovationService.ServiceType;
                        serviceApplicationObjectTypeName = UserDisplay.ServiceApplicationInnovation;
                        break;
                    default:
                        serviceApplicationObjectType = null;
                        serviceInstanceObjectType = null;
                        serviceObjectType = null;
                        serviceApplicationObjectTypeName = UserDisplay.NotSpecified;
                        break;
                }

                if (serviceApplicationObjectType == null)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.WarningRemovingServiceApplicationTypeMissing, serviceApplicationObjectTypeName), OutputType.Warning);
                    return outputQueue;
                }
                else
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ServiceApplicationRemoving, serviceApplicationObjectTypeName));
                    outputQueue.Add(UserDisplay.GettingCurrentServiceContext);

                    var mossContext = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, new SPSiteSubscriptionIdentifier(Guid.Empty));
                    using (var scope = new SPServiceContextScope(mossContext))
                    {
                        foreach (var svc in LocalFarm.Get().Services)
                        {
                            foreach (var serviceApp in svc.Applications)
                            {
                                if (serviceApp.GetType() == serviceApplicationObjectType)
                                {
                                    if (serviceApplicationType == ServiceApplicationType.SocialPlatform)
                                    {
                                        outputQueue.Add(UserDisplay.LocatingServiceApplicationProxy);
                                        foreach (SPServiceProxy proxy in LocalFarm.Get().ServiceProxies)
                                        {
                                            foreach (SPServiceApplicationProxy proxy2 in proxy.ApplicationProxies)
                                            {
                                                if (!serviceApp.IsConnected(proxy2))
                                                    continue;
                                                outputQueue.Add(UserDisplay.DeletingServiceApplicationProxy);
                                                proxy2.Unprovision(deleteDatabases);
                                                proxy2.Delete();
                                                outputQueue.Add(UserDisplay.DeletingServiceApplicationProxyComplete);
                                            }
                                        }
                                        outputQueue.Add(UserDisplay.DeletingServiceApplication);
                                        try
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningUserProfileEmailNotificationProperty);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnprovisionUserProfileEmailNotificationProperty", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningUserProfileEmailNotificationProperty, exception.Message), OutputType.Error, string.Empty, exception);
                                            }
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningUserProfileDigestEmailProperty);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnprovisionUserProfileDigestEmailProperty", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningUserProfileDigestEmailProperty, exception.Message), OutputType.Error, string.Empty, exception);
                                            }
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningEmailWeb);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnProvisionEmailWeb", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningEmailWeb, exception.Message), OutputType.Error, string.Empty, exception);
                                            }

                                            var app = serviceApp as SPIisWebServiceApplication;
                                            foreach (SPIisWebServiceEndpoint ep in app.Endpoints)
                                            {
                                                ep.Delete();
                                            }

                                            serviceApp.Unprovision(deleteDatabases);
                                            serviceApp.Delete();
                                        }
                                        catch (SPUpdatedConcurrencyException)
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningUserProfileEmailNotificationProperty);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnprovisionUserProfileEmailNotificationProperty", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningUserProfileEmailNotificationProperty, exception.Message), OutputType.Error, string.Empty, exception);
                                            }
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningUserProfileDigestEmailProperty);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnprovisionUserProfileDigestEmailProperty", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningUserProfileDigestEmailProperty, exception.Message), OutputType.Error, string.Empty, exception);
                                            }
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UnprovisioningEmailWeb);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UnProvisionEmailWeb", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUnprovisioningEmailWeb, exception.Message), OutputType.Error, string.Empty, exception);
                                            }

                                            var app = serviceApp as SPIisWebServiceApplication;
                                            foreach (SPIisWebServiceEndpoint ep in app.Endpoints)
                                            {
                                                ep.Delete();
                                            }

                                            serviceApp.Unprovision(deleteDatabases);
                                            serviceApp.Delete();
                                        }
                                        outputQueue.Add(UserDisplay.DeletingServiceApplicationComplete);
                                    }
                                    else
                                    {
                                        outputQueue.Add(UserDisplay.LocatingServiceApplicationProxy);
                                        foreach (SPServiceProxy proxy in LocalFarm.Get().ServiceProxies)
                                        {
                                            foreach (SPServiceApplicationProxy proxy2 in proxy.ApplicationProxies)
                                            {
                                                if (serviceApp.IsConnected(proxy2))
                                                {
                                                    outputQueue.Add(UserDisplay.DeletingServiceApplicationProxy);
                                                    proxy2.Unprovision(deleteDatabases);
                                                    proxy2.Delete();
                                                    outputQueue.Add(UserDisplay.DeletingServiceApplicationProxyComplete);
                                                }
                                            }
                                        }
                                        outputQueue.Add(UserDisplay.DeletingServiceApplication);
                                        try
                                        {
                                            var app = serviceApp as SPIisWebServiceApplication;
                                            foreach (SPIisWebServiceEndpoint ep in app.Endpoints)
                                            {
                                                ep.Delete();
                                            }

                                            serviceApp.Unprovision(deleteDatabases);
                                            serviceApp.Delete();
                                        }
                                        catch (SPUpdatedConcurrencyException)
                                        {
                                            var app = serviceApp as SPIisWebServiceApplication;
                                            foreach (SPIisWebServiceEndpoint ep in app.Endpoints)
                                            {
                                                ep.Delete();
                                            }

                                            serviceApp.Unprovision(deleteDatabases);
                                            serviceApp.Delete();
                                        }
                                        outputQueue.Add(UserDisplay.DeletingServiceApplicationComplete);
                                    }
                                }
                            }
                        }

                        SPPersistedObject serviceProxy = null;
                        switch (serviceApplicationType)
                        {
                            case ServiceApplicationType.SocialPlatform:
                                serviceProxy = SocialServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                            case ServiceApplicationType.NewsStream:
                                serviceProxy = NewsManagerServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                            case ServiceApplicationType.Learning:
                                serviceProxy = EnrichServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                            case ServiceApplicationType.VideoStream:
                                serviceProxy = VideoServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                            case ServiceApplicationType.InterComm:
                                serviceProxy = InterCommServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                            case ServiceApplicationType.Innovation:
                                serviceProxy = InnovationServiceProxy.Get(LocalFarm.Get().ServiceProxies);
                                break;
                        }
                        if (serviceProxy != null)
                        {
                            outputQueue.Add(UserDisplay.DeletingServiceProxy);
                            serviceProxy.Delete();
                            outputQueue.Add(UserDisplay.DeletingServiceProxyComplete);
                        }

                        if (serviceInstanceObjectType != null)
                        {
                            foreach (var server in LocalFarm.Get().Servers)
                            {
                                var serverSvcInstance = ServiceInstance.Get(server, serviceInstanceObjectType);
                                if (serverSvcInstance != null)
                                {
                                    outputQueue.Add(UserDisplay.DeletingServiceInstance);
                                    serverSvcInstance.Delete();
                                    outputQueue.Add(UserDisplay.DeletingServiceInstanceComplete);
                                }
                            }
                        }

                        if (serviceApplicationType == ServiceApplicationType.SocialPlatform)
                        {
                            foreach (var serverSvcInstance in LocalFarm.Get().Servers.Select(server => ServiceInstance.Get(server, PlatformServiceInstance.NewsGatorPlatformServiceInstanceType)).Where(serverSvcInstance => serverSvcInstance != null))
                            {
                                outputQueue.Add(UserDisplay.DeletingServiceInstance);
                                serverSvcInstance.Delete();
                                outputQueue.Add(UserDisplay.DeletingServiceInstanceComplete);
                            }
                        }

                        if (serviceObjectType != null)
                        {
                            var service = Service.Get(serviceObjectType) as SPIisWebService;
                            if (service != null)
                            {
                                outputQueue.Add(UserDisplay.DeletingWebServiceInstance);
                                foreach (var instance in service.Instances)
                                {
                                    instance.Delete();
                                }
                                service.Delete();
                                outputQueue.Add(UserDisplay.DeletingWebServiceInstanceComplete);
                            }
                        }

                        if (serviceApplicationType == ServiceApplicationType.SocialPlatform)
                        {
                            SPIisWebService service = Service.Get(PlatformService.NewsGatorPlatformServiceType) as SPIisWebService;
                            if (service != null)
                            {
                                outputQueue.Add(UserDisplay.DeletingWebServiceInstance);
                                foreach (var instance in service.Instances)
                                {
                                    instance.Delete();
                                }
                                service.Delete();
                                outputQueue.Add(UserDisplay.DeletingWebServiceInstanceComplete);
                            }
                        }
                    }
                }

                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.ServiceApplicationRemovingComplete, serviceApplicationObjectTypeName));
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRemovingServiceApplication, exception.Message), OutputType.Error, string.Empty, exception);
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue RemoveAllNewsGatorServiceApplications(bool deleteDatabases = false)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(UserDisplay.ServiceApplicationRemovingAll);

            // Removing Social Platform Service Application            
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.SocialPlatform, deleteDatabases));

            // Removing News Manager Service Application
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.NewsStream, deleteDatabases));

            // Removing Video Service Application
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.VideoStream, deleteDatabases));

            // Removing Enrich Service Application
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.Learning, deleteDatabases));

            // Removing Innovation Service Application
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.Innovation, deleteDatabases));

            // Removing InterComm Service Application
            outputQueue.Add(RemoveNewsGatorServiceApplication(ServiceApplicationType.InterComm, deleteDatabases));

            outputQueue.Add(UserDisplay.ServiceApplicationRemovingAllComplete);

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue UpdateNewsGatorServiceApplication(ServiceApplicationType serviceApplicationType, bool useTimerJob)
        {
            var outputQueue = new OutputQueue();

            Type typeServiceApplication = null;
            Type typeServiceApplicationProxy = null;
            var proxyOutput = string.Empty;
            var serviceAppOutput = string.Empty;

            try
            {
                outputQueue.Add(UserDisplay.UpgradeGettingServiceApplicationTypes);

                try
                {
                    switch (serviceApplicationType)
                    {
                        case ServiceApplicationType.SocialPlatform:
                            typeServiceApplicationProxy = SocialServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = SocialServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeSocialProxy;
                            serviceAppOutput = UserDisplay.DatabaseNameSocial;
                            break;
                        case ServiceApplicationType.NewsStream:
                            typeServiceApplicationProxy = NewsManagerServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = NewsManagerServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeNewsProxy;
                            serviceAppOutput = UserDisplay.DatabaseNameNews;
                            break;
                        case ServiceApplicationType.Learning:
                            typeServiceApplicationProxy = EnrichServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = EnrichServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeEnrichProxy;
                            serviceAppOutput = UserDisplay.DatabaseNameEnrich;
                            break;
                        case ServiceApplicationType.VideoStream:
                            typeServiceApplicationProxy = VideoServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = VideoServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeVideoProxy;
                            serviceAppOutput = UserDisplay.DatabaseNameVideo;
                            break;
                        case ServiceApplicationType.InterComm:
                            typeServiceApplicationProxy = InterCommServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = InterCommServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeInterCommProxy;
                            serviceAppOutput = UserDisplay.DatabaseInterComm;
                            break;
                        case ServiceApplicationType.Innovation:
                            typeServiceApplicationProxy = InnovationServiceApplicationProxy.ServiceApplicationProxyType;
                            typeServiceApplication = InnovationServiceApplication.ServiceApplicationType;
                            proxyOutput = UserDisplay.UpgradeInnovationProxy;
                            serviceAppOutput = UserDisplay.DatabaseInnovation;
                            break;
                    }

                    if (typeServiceApplicationProxy == null || typeServiceApplication == null)
                        throw new ArgumentNullException(Exceptions.MissingSocialServiceApplicationTypesError);
                }
                catch (Exception exception)
                {
                    typeServiceApplicationProxy = null;
                    typeServiceApplication = null;

                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseWarning, UserDisplay.DatabasePlatform), OutputType.Error, null, exception);
                    return outputQueue;
                }

                if (serviceApplicationType == ServiceApplicationType.NewsStream)
                {
                    try
                    {
                        UpdateNewsManagerObjectTypes();
                        var taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                        outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));
                    }
                    catch (Exception exception)
                    {
                        outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.UpdateNewsManagerObjectsException, exception.Message), OutputType.Error, exception.ToString(), exception);
                    }
                }

                outputQueue.Add(UserDisplay.UpgradeGettingServiceApplications);

                foreach (var svc in LocalFarm.Get().Services)
                {
                    foreach (var serviceApp in svc.Applications)
                    {
                        if (serviceApp.GetType() == typeServiceApplication)
                        {
                            using (var contextScope = new SPServiceContextScope(SPServiceContext.GetContext(serviceApp.ServiceApplicationProxyGroup, new SPSiteSubscriptionIdentifier(Guid.Empty))))
                            {
                                if (serviceApp.ServiceApplicationProxyGroup != null)
                                {
                                    outputQueue.Add(UserDisplay.UpgradeGettingServiceApplicationProxies);

                                    foreach (var proxy in serviceApp.ServiceApplicationProxyGroup.Proxies)
                                    {
                                        try
                                        {
                                            if (proxy.GetType() == typeServiceApplicationProxy)
                                            {
                                                outputQueue.Add(proxyOutput);

                                                Utilities.Reflection.ExecuteMethod(proxy.GetType(), proxy, "Upgrade", new Type[] { }, null);
                                            }
                                        }
                                        catch (InvalidOperationException) // Catching "The global session cannot be used to perform an upgrade operation."
                                        {
                                            try
                                            {
                                                var session = new SPUpgradeSession();
                                                Utilities.Reflection.ExecuteMethod(session.GetType(), session, "Upgrade", new[] { typeof(object), typeof(bool) }, new object[] { proxy, false });
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingProxyVerbose,
                                                                         serviceAppOutput, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            if (outputQueue != null)
                                            {
                                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingProxyVerbose,
                                                                     serviceAppOutput, exception.Message), OutputType.Error, null, exception);
                                            }
                                        }
                                    }
                                }

                                switch (serviceApplicationType)
                                {
                                    case ServiceApplicationType.SocialPlatform:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeSocialApp);

                                                outputQueue.Add(UserDisplay.UpgradeSocialSolutions);
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpgradeNGSolutions", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeNGSolutions", exception.Message), OutputType.Error, null, exception);
                                                }

                                                outputQueue.Add(UserDisplay.UpgradeSocialJobs);
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpgradeJobs", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeJobs", exception.Message), OutputType.Error, null, exception);
                                                }

                                                outputQueue.Add(UserDisplay.UpgradeSocialProxies);
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpgradeProxies", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeProxies", exception.Message), OutputType.Error, null, exception);
                                                }

                                                outputQueue.Add(UserDisplay.UpgradeSocialNotifications);
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpgradeNotifications", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpgradeNotifications", exception.Message), OutputType.Error, null, exception);
                                                }

                                                try
                                                {
                                                    bool workIsAlreadyDone = false;
                                                    object booleanPropertyValueAsObject = null;

                                                    booleanPropertyValueAsObject = Utilities.Reflection.GetPropertyValue(serviceApp.GetType(), serviceApp, "ActivitiesProvisioned");

                                                    if (booleanPropertyValueAsObject != null)
                                                    {
                                                        workIsAlreadyDone = (bool)booleanPropertyValueAsObject;
                                                    }

                                                    if (!workIsAlreadyDone)
                                                    {
                                                        outputQueue.Add(UserDisplay.ProvisioningActivityTemplates);
                                                        Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "ProvisionApplicationTemplates", new Type[] { }, null);
                                                    }
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "ProvisionApplicationTemplates", exception.Message), OutputType.Error, null, exception);
                                                }

                                                outputQueue.Add(UserDisplay.UpgradeUserProfileProperties);
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "ProvisionNewsgatorCustomUserProfileProperties", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "ProvisionNewsgatorCustomUserProfileProperties", exception.Message), OutputType.Error, null, exception);
                                                }

                                                Utilities.Reflection.SetPropertyValue(serviceApp, "UserProfilePropertyDefaultsSet", false);

                                                outputQueue.Add(UserDisplay.UpgradeSocialDatabases);
                                                var db = new Database();
                                                var connStr = Utilities.Reflection.GetPropertyValue(serviceApp.GetType(), serviceApp, "DatabaseConnection").ToString();
                                                var rConnStr = Utilities.Reflection.GetPropertyValue(serviceApp.GetType(), serviceApp, "ReportDatabaseConnection").ToString();

                                                var verStr = db.GetDatabaseVersion(connStr);
                                                var version = new Version(!string.IsNullOrEmpty(verStr) ? verStr : "1.0.0.0");
                                                if (version < BuildVersion.Version)
                                                {
                                                    SPDatabase ssDB = Utilities.Reflection.GetPropertyValue(serviceApp.GetType(), serviceApp, "SocialDatabase") as SPDatabase;
                                                    ssDB.Upgrade();
                                                }

                                                verStr = db.GetDatabaseVersion(rConnStr);
                                                version = new Version(!string.IsNullOrEmpty(verStr) ? verStr : "1.0.0.0");
                                                if (version < BuildVersion.Version)
                                                {
                                                    SPDatabase srDB = Utilities.Reflection.GetPropertyValue(serviceApp.GetType(), serviceApp, "ReportDatabase") as SPDatabase;
                                                    srDB.Upgrade();
                                                }

                                                // Convert the block Lookout 360 settings from Web Application Properties to features activated on the Web Applications
                                                try
                                                {
                                                    Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpdateLookout360Settings", new Type[] { }, null);
                                                }
                                                catch (Exception exception)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRunningUpdateMethod, "UpdateLookout360Settings", exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseWarning, UserDisplay.DatabasePlatform), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                    case ServiceApplicationType.NewsStream:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeNewsApp);

                                                Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "MaintainDatabase", new Type[] { }, null);
                                                Utilities.Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "UpgradeJobs", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseVerbose, UserDisplay.DatabaseNewsManager, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                    case ServiceApplicationType.Learning:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeEnrichApp);

                                                var adminService = SPWebService.AdministrationService;

                                                if (adminService.Features[Constants.Features.Enrich.EnrichDependencyInjectionFeature] != null)
                                                {
                                                    adminService.Features.Remove(Constants.Features.Enrich.EnrichDependencyInjectionFeature, true);
                                                    adminService.Features.Add(Constants.Features.Enrich.EnrichDependencyInjectionFeature, true);
                                                }

                                                if (adminService.Features[Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature] != null)
                                                {
                                                    adminService.Features.Remove(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature, true);
                                                    adminService.Features.Add(Constants.Features.EnrichVideoScenarios.EnrichVideoScenariosDependencyInjectionFeature, true);
                                                }

                                                var taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));

                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "ExecuteUpgrade", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseVerbose, UserDisplay.DatabaseEnrich, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                    case ServiceApplicationType.VideoStream:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeVideoApp);

                                                var adminService = SPWebService.AdministrationService;
                                                if (adminService.Features[Constants.Features.VideoStream.VideoDependencyInjectionFeature] != null)
                                                    adminService.Features.Remove(Constants.Features.VideoStream.VideoDependencyInjectionFeature, true);

                                                adminService.Features.Add(Constants.Features.VideoStream.VideoDependencyInjectionFeature, true);

                                                var taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));

                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "ExecuteUpgrade", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseVerbose, UserDisplay.DatabaseVideo, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                    case ServiceApplicationType.InterComm:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeInterCommApp);
                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "MaintainDatabases", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseVerbose, UserDisplay.DatabaseInterComm, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                    case ServiceApplicationType.Innovation:
                                        {
                                            try
                                            {
                                                outputQueue.Add(UserDisplay.UpgradeInnovationApp);

                                                var adminService = SPWebService.AdministrationService;
                                                if (adminService.Features[Constants.Features.Innovation.InnovationDependencyInjectionFeature] != null)
                                                    adminService.Features.Remove(Constants.Features.Innovation.InnovationDependencyInjectionFeature, true);

                                                adminService.Features.Add(Constants.Features.Innovation.InnovationDependencyInjectionFeature, true);

                                                var taskToRun = new Tasks.Services.RestartServices(useTimerJob) as IInstallTask;
                                                outputQueue.Add(TaskExtensions.RunTask(ref taskToRun));

                                                Reflection.ExecuteMethod(serviceApp.GetType(), serviceApp, "ExecuteUpgrade", new Type[] { }, null);
                                            }
                                            catch (Exception exception)
                                            {
                                                if (outputQueue != null)
                                                {
                                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseVerbose, UserDisplay.DatabaseInnovation, exception.Message), OutputType.Error, null, exception);
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (outputQueue != null)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorUpdatingDatabaseWarning, UserDisplay.DatabasePlatform), OutputType.Error, null, exception);
                }
            }

            return outputQueue;
        }

        private static void UpdateNewsManagerObjectTypes()
        {
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
                        command.CommandText = @"UPDATE [dbo].[Objects]
SET Properties = REPLACE(Properties, 'NewsGator.NewsManager, Version=1.0.0.0', 'NewsGator.NewsManager.Application, Version=1.0.0.0')
WHERE Properties LIKE '%NewsGator.NewsManager, Version=1.0.0.0%'";
                        Utilities.Reflection.ExecuteMethod(session.GetType(), session, "ExecuteNonQuery", new Type[] { typeof(SqlCommand) }, new[] { command });
                    }
                }
            }
        }
    }
}
