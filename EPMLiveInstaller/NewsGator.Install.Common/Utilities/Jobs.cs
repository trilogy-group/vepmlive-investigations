using System;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Entities.SocialSites.ServiceApplications;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Entities.SocialSites;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.SharePoint;
using System.ServiceProcess;
using Microsoft.SharePoint.Utilities;
using System.Management;

namespace NewsGator.Install.Common.Utilities
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public static class Jobs
    {
        private const string _loadingProperty = "ng-loading";
        private const string JobName = "_ProfileSynchronizationJob";
        private const string SolutionName = "NewsGator.Install.Jobs.wsp";
        private const string RecycleJobName = "job-timer-recycle";
        private static Guid FeatureId = new Guid("7a5d7906-55e3-497f-bb4f-e8c4a1ba1e2f");
        private const string AdminServiceName = "SPAdminV4";

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputQueue.Add(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        internal static OutputQueue ExecuteAdminServiceJobs(int timeOut)
        {
            var output = new OutputQueue();

            try
            {
                Parallel.ForEach(LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)),
                server =>
                    {
                        ServiceController[] machineServices = ServiceController.GetServices(server.Address);

                        try
                        {
                            var service = machineServices.FirstOrDefault(s => s.ServiceName == AdminServiceName);
                            if (service != null)
                            {
                                output.Add(string.Format(CultureInfo.InvariantCulture, "Stopping {0} on {1}", AdminServiceName, server.Address));
                                if (service.Status == ServiceControllerStatus.Running && service.CanStop)
                                {
                                    service.Stop();
                                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(90));
                                }
                            }
                        }
                        catch (InvalidOperationException) { }
                        catch (Exception exception)
                        {
                            output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                        }

                        var command = string.Format(CultureInfo.InvariantCulture, @"{0} -o execadmsvcjobs", SPUtility.GetGenericSetupPath(@"bin\stsadm.exe"));

                        output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.RunningCommandOn, command, server.Address));

                        try
                        {
                            var processWMI = new Threading.ProcessWMI();
                            processWMI.ExecuteRemoteProcessWMI(server.Address, command, timeOut);
                        }
                        catch (Exception exception)
                        {
                            output.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ExceptionRunningCommandOn, command, server.Address, exception.Message), OutputType.Error, exception.ToString(), exception);
                        }                        

                        // Start Admin Service
                        machineServices = ServiceController.GetServices();

                        try
                        {
                            var service = machineServices.FirstOrDefault(s => s.ServiceName == AdminServiceName);
                            if (service != null)
                            {
                                output.Add(string.Format(CultureInfo.InvariantCulture, "Starting {0} on {1}", AdminServiceName, server.Address));
                                if (service.Status == ServiceControllerStatus.Stopped)
                                {
                                    service.Start();
                                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(90));
                                }
                            }
                        }
                        catch (InvalidOperationException) { }
                        catch (Exception exception)
                        {
                            output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                        }
                    });
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        private static OutputQueue ExecuteRecycleTimerJob(int timeout)
        {
            var output = new OutputQueue();

            try
            {
                var timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                var job = timerService.JobDefinitions.Where(p => (p.Name.IndexOf(RecycleJobName, StringComparison.OrdinalIgnoreCase) > -1)).First();

                var lastRun = job.LastRunTime;
                job.RunNow();

                Func<bool> wait = () =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        try
                        {
                            var waitTimerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                            var waitJob = waitTimerService.JobDefinitions.Where(p => (p.Name.IndexOf(RecycleJobName, StringComparison.OrdinalIgnoreCase) > -1)).First();

                            if (waitJob.LastRunTime > lastRun)
                                complete = true;

                            if (!complete)
                            {
                                Thread.Sleep(10000);
                            }
                        }
                        catch { }
                    }

                    return complete;
                };

                var success = Threading.WaitFor<bool>.Run(TimeSpan.FromMilliseconds(timeout / 2), wait);
                if (!success)
                    throw new System.TimeoutException();
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.TimerJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static OutputQueue ExecuteInstallerJob(string jobName, int timeout)
        {
            // Minimum 15 Minutes
            if (timeout < 900000)
                timeout = 900000;

            if (jobName.Equals(RecycleJobName, StringComparison.OrdinalIgnoreCase))
                return ExecuteRecycleTimerJob(timeout);

            var output = new OutputQueue();

            try
            {
                // Ensure NewsGator.Install.Jobs.wsp is deployed
                if (LocalFarm.Get().Solutions[SolutionName] == null
                    || !LocalFarm.Get().Solutions[SolutionName].Deployed)
                    throw new InvalidOperationException(NewsGator.Install.Resources.Exceptions.RestartServicesMissingSolution);

                if (LocalFarm.Get().FeatureDefinitions[FeatureId] == null)
                {
                    LocalFarm.Get().FeatureDefinitions.Add("NewsGator.Install.Jobs_InstallJobs\\Feature.xml", LocalFarm.Get().Solutions[SolutionName].Id, true);
                    Thread.Sleep(30000);
                }

                // Ensure Installer Jobs Farm Feature is activated
                if (SPWebService.AdministrationService.Features[FeatureId] == null)
                {
                    output.Add(NewsGator.Install.Resources.Tasks.TaskDetails_RestartServices_ActivatingFarmFeature);
                    SPWebService.AdministrationService.Features.Add(FeatureId);
                    Thread.Sleep(30000);
                }

                // Run the Restart Services timer job
                var timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                var jobIds = timerService.JobDefinitions.Where(p => (p.Name.IndexOf(jobName, StringComparison.OrdinalIgnoreCase) > -1)).Select(q => q.Id);

                if (jobIds == null || jobIds.Count() == 0)
                {
                    if (SPWebService.AdministrationService.Features[FeatureId] != null)
                    {
                        SPWebService.AdministrationService.Features.Remove(FeatureId);
                        Thread.Sleep(30000);
                    }

                    SPWebService.AdministrationService.Features.Add(FeatureId);
                    Thread.Sleep(30000);

                    timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                    jobIds = timerService.JobDefinitions.Where(p => (p.Name.IndexOf(jobName, StringComparison.OrdinalIgnoreCase) > -1)).Select(q => q.Id);

                    if (jobIds == null || jobIds.Count() == 0)
                    {
                        throw new InvalidOperationException(Exceptions.JobsNotFoundException);
                    }
                }

                var propertyIds = new Collection<string>();
                
                timerService = LocalFarm.Get().Services.Where(p => p is SPTimerService).First() as SPTimerService;
                foreach (var jobId in jobIds)
                {
                    var job = timerService.JobDefinitions.Where(p => p.Id == jobId).First();
                    var serverName = job.Server != null ? job.Server.Address : string.Empty;

                    try
                    {
                        output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskDetails_StartingJob, serverName));

                        var propertyId = "ng-run-" + jobId.ToString();

                        SPSecurity.RunWithElevatedPrivileges(() =>
                        {
                            if (!LocalFarm.Get().Properties.ContainsKey(propertyId))
                            {
                                LocalFarm.Get().Properties.Add(propertyId, propertyId);
                            }
                        });

                        propertyIds.Add(propertyId);
                    }
                    catch (Exception exception)
                    {
                        output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.TimerJobExceptionOn, serverName, exception.Message), OutputType.Error, exception.ToString(), exception);
                    }
                }

                LocalFarm.Get().TryUpdate();
                Thread.Sleep(10000);

                var timeoutTime = DateTime.Now.AddMilliseconds(timeout * 0.95);
                var complete = false;

                while (!complete)
                {
                    var jobRunning = false;

                    foreach (var propertyId in propertyIds)
                    {
                        try
                        {
                            if (LocalFarm.Get().Properties.ContainsKey(propertyId))
                                jobRunning = true;
                        }
                        catch { }
                    }

                    if (!jobRunning)
                        complete = true;

                    if (!complete)
                    {
                        if (DateTime.Now > timeoutTime)
                        {
                            throw new System.TimeoutException();
                        }
                        else
                        {
                            LocalFarm.Get().TryUpdate();
                            Thread.Sleep(10000);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.TimerJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
            }

            var keysToRemove = new List<string>();
            foreach (var propertyKey in LocalFarm.Get().Properties.Keys)
            {
                var key = propertyKey as string;
                if (!string.IsNullOrEmpty(key))
                    if (key.StartsWith("ng-run-", StringComparison.OrdinalIgnoreCase))
                        keysToRemove.Add(key);
            }
            foreach (var key in keysToRemove)
                LocalFarm.Get().Properties.Remove(key);

            LocalFarm.Get().TryUpdate();

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue DisableUserProfileJob()
        {
            var output = new OutputQueue();

            try
            {
                foreach (var service in LocalFarm.Get().Services)
                {
                    foreach (var job in service.JobDefinitions.Where(p => p.Name.EndsWith(JobName, StringComparison.OrdinalIgnoreCase)))
                    {
                        job.IsDisabled = true;
                        job.Update();
                    }
                }
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.DisableUserProfileJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue EnableUserProfileJob()
        {
            var output = new OutputQueue();

            try
            {
                foreach (var service in LocalFarm.Get().Services)
                {
                    foreach (var job in service.JobDefinitions.Where(p => p.Name.EndsWith(JobName, StringComparison.OrdinalIgnoreCase)))
                    {
                        job.IsDisabled = false;
                        job.Update();
                    }
                }
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.EnableUserProfileJobException, exception.Message), OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableNewsGatorJobs()
        {
            var outputQueue = new OutputQueue();

            try
            {
                DateTime? now = DateTime.Now;
                LocalFarm.Get().Properties[_loadingProperty] = now;
                LocalFarm.Get().TryUpdate();
                string serviceName = string.Empty;

                foreach (var service in LocalFarm.Get().Services)
                {                    
                    foreach (var serviceApp in service.Applications)
                    {
                        if (serviceApp == null)
                            continue;
                        try
                        {
                            var serviceType = serviceApp.GetType();                            

                            if ((SocialServiceApplication.ServiceApplicationType != null) && (serviceType == SocialServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceVerbose, service.DisplayName));
                                if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                    serviceName = serviceApp.DisplayName;
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                    serviceName = serviceType.FullName;
                                }

                                outputQueue.Add(DisableServiceJobs(serviceApp));
                                var ngsvc = PlatformService.Get();
                                if (ngsvc != null)
                                    outputQueue.Add(DisableJobs(ngsvc));
                            }
                            
                            if ((NewsManagerServiceApplication.ServiceApplicationType != null) && (serviceType == NewsManagerServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceVerbose, service.DisplayName));
                                if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                    serviceName = serviceApp.DisplayName;
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                    serviceName = serviceType.FullName;
                                }

                                outputQueue.Add(DisableServiceJobs(serviceApp));
                            }
                            
                            if ((VideoServiceApplication.ServiceApplicationType != null) && (serviceType == VideoServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceVerbose, service.DisplayName));
                                if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                    serviceName = serviceApp.DisplayName;
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                    serviceName = serviceType.FullName;
                                }

                                outputQueue.Add(DisableServiceJobs(serviceApp));
                            }
                            
                            if ((EnrichServiceApplication.ServiceApplicationType != null) && (serviceType == EnrichServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceVerbose, service.DisplayName));
                                if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                    serviceName = serviceApp.DisplayName;
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                    serviceName = serviceType.FullName;
                                }

                                outputQueue.Add(DisableServiceJobs(serviceApp));
                            }

                            if ((InterCommServiceApplication.ServiceApplicationType != null) && (serviceType == InterCommServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceVerbose, service.DisplayName));
                                if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                    serviceName = serviceApp.DisplayName;
                                }
                                else
                                {
                                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                    serviceName = serviceType.FullName;
                                }

                                outputQueue.Add(DisableServiceJobs(serviceApp));
                            }
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DisableJobsProcessingError, serviceName, exception.Message), OutputType.Error, null, exception);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DisableJobsError, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }
                
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableServiceJobs(SPServiceApplication serviceApp)
        {
            var outputQueue = new OutputQueue();
            var app = serviceApp as SPIisWebServiceApplication;
            if (app != null)
                if (app.Service != null)
                    outputQueue.Add(DisableJobs(app.Service));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableJobs(SPService service)
        {
            var outputQueue = new OutputQueue();

            if (service == null)
                return outputQueue;

            foreach (var job in service.JobDefinitions)
            {
                try
                {
                    outputQueue.Add(DisableJob(job));
                }
                catch (Exception exception)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DisableJobsUnableToDisableError, job.DisplayName, exception.Message), OutputType.Error, null, exception);                    
                }
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue DisableJob(SPJobDefinition job)
        {
            var outputQueue = new OutputQueue();

            if (job == null)
                return outputQueue;

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.DisableJob, string.IsNullOrEmpty(job.DisplayName) ? job.Name : job.DisplayName));

            try
            {
                job.IsDisabled = true;
                job.Update();
            }
            catch (SPUpdatedConcurrencyException)
            { }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.DisableJobsUnableToDisableError, job.DisplayName, exception.Message), OutputType.Error, null, exception);                    
            }
            
            outputQueue.Add(UserDisplay.DisableJobComplete);

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue EnableNewsGatorJobs()
        {
            var outputQueue = new OutputQueue();

            try
            {
                var farm = LocalFarm.Get();

                try
                {
                    if (farm.Properties.ContainsKey(_loadingProperty))
                    {
                        farm.Properties.Remove(_loadingProperty);
                        farm.TryUpdate();
                    }
                }
                catch { }

                foreach (var service in LocalFarm.Get().Services)
                {
                    foreach (var serviceApp in service.Applications)
                    {
                        if (serviceApp == null)
                            continue;

                        var serviceName = string.Empty;

                        try
                        {
                            var serviceType = serviceApp.GetType();

                            if (!string.IsNullOrEmpty(serviceApp.DisplayName))
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.EnableJobsProcessingServiceAppVerbose, serviceApp.DisplayName + " (" + serviceType.FullName + ")"));
                                serviceName = serviceApp.DisplayName;
                            }
                            else
                            {
                                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.EnableJobsProcessingServiceAppVerbose, "(" + serviceType.FullName + ")"));
                                serviceName = serviceType.FullName;
                            }

                            if ((SocialServiceApplication.ServiceApplicationType != null)
                                && (serviceType == SocialServiceApplication.ServiceApplicationType))
                            {
                                if (LocalFarm.Get().Id == serviceApp.Farm.Id)
                                {
                                    outputQueue.Add(EnableServiceJobs(serviceApp));
                                    var ngsvc = PlatformService.Get();
                                    if (ngsvc != null)
                                        outputQueue.Add(EnableJobs(ngsvc));
                                }
                            }

                            if ((farm.Solutions[NewsGator.Install.Common.Constants.Solutions.NewsStream.NewsGatorNewsManager.SolutionId] != null)
                                && (NewsManagerServiceApplication.ServiceApplicationType != null)
                                && (serviceType == NewsManagerServiceApplication.ServiceApplicationType))
                            {
                                outputQueue.Add(EnableServiceJobs(serviceApp));
                            }

                            if ((farm.Solutions[NewsGator.Install.Common.Constants.Solutions.VideoStream.NewsGatorVideoStreamApp.SolutionId] != null)
                                && (VideoServiceApplication.ServiceApplicationType != null)
                                && (serviceType == VideoServiceApplication.ServiceApplicationType))
                            {
                                if (LocalFarm.Get().Id == serviceApp.Farm.Id)
                                {
                                    outputQueue.Add(EnableServiceJobs(serviceApp));
                                }
                            }

                            if ((farm.Solutions[NewsGator.Install.Common.Constants.Solutions.Enrich.NewsGatorLearningPointApp.SolutionId] != null)
                                && (EnrichServiceApplication.ServiceApplicationType != null)
                                && (serviceType == EnrichServiceApplication.ServiceApplicationType))
                            {
                                if (LocalFarm.Get().Id == serviceApp.Farm.Id)
                                {
                                    outputQueue.Add(EnableServiceJobs(serviceApp));
                                }
                            }

                            if ((farm.Solutions[NewsGator.Install.Common.Constants.Solutions.InterComm.NewsGatorCorpComm.SolutionId] != null)
                                && (InterCommServiceApplication.ServiceApplicationType != null)
                                && (serviceType == InterCommServiceApplication.ServiceApplicationType))
                            {
                                if (LocalFarm.Get().Id == serviceApp.Farm.Id)
                                {
                                    outputQueue.Add(EnableServiceJobs(serviceApp));
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.EnableJobsProcessingError, serviceName, exception.Message), OutputType.Error, null, exception);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.EnableJobsError, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue EnableServiceJobs(SPServiceApplication serviceApp)
        {
            var outputQueue = new OutputQueue();

            var app = serviceApp as SPIisWebServiceApplication;
            if (app != null)
                if (app.Service != null)
                    outputQueue.Add(EnableJobs(app.Service));

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue EnableJobs(SPService service)
        {
            var outputQueue = new OutputQueue();
            
            if (service == null)
                return outputQueue;

            foreach (var job in service.JobDefinitions)
            {
                try
                {
                    outputQueue.Add(EnableJob(job));
                }
                catch (Exception exception)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.EnableJobsUnableToEnableError, job.DisplayName, exception.Message), OutputType.Error, null, exception);                    
                }
            }

            return outputQueue;
        }
                
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue EnableJob(SPJobDefinition job)
        {
            var outputQueue = new OutputQueue();

            if (job == null)
                return outputQueue;

            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.EnableJob, string.IsNullOrEmpty(job.DisplayName) ? job.Name : job.DisplayName));
            try
            {
                job.IsDisabled = false;
                job.Update();
            }
            catch (SPUpdatedConcurrencyException)
            { }
            outputQueue.Add(UserDisplay.EnableJobComplete);

            return outputQueue;
        }
    }
}
