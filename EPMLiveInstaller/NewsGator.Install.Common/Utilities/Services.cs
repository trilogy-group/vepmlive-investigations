using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputQueue.Add(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue RestartServices(int timeOut)
        {
            var output = new OutputQueue();

            try
            {
                Parallel.ForEach(LocalFarm.Get().Servers.Where(p => Server.ValidSPServerRole(p.Role)),
                server =>
                {
                    var services = new Collection<string>() { "SPTimerV4", "SPAdminV4", "FIMService" };
                    switch (LocalFarm.Get().BuildVersion.Major)
                    {
                        case 14:
                            services.Add("OSearch14");
                            services.Add("SPSearch4");
                            services.Add("WebAnalyticsService");
                            break;
                        case 15:
                            services.Add("OSearch15");
                            break;
                        case 16:
                            services.Add("OSearch16");
                            break;
                    }

                    ServiceController[] machineServices = ServiceController.GetServices(server.Address);

                    foreach (var serviceName in services)
                    {
                        try
                        {
                            var service = machineServices.FirstOrDefault(s => s.ServiceName == serviceName);
                            if (service != null)
                            {
                                output.Add(string.Format(CultureInfo.InvariantCulture, "Restarting {0} on {1}", serviceName, server.Address));
                                if (service.Status == ServiceControllerStatus.Running && service.CanStop)
                                {
                                    service.Stop();
                                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(90));
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
                    }

                    // Restart IIS
                    var command = string.Format(CultureInfo.InvariantCulture, @"{0} /restart", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "iisreset.exe"));
                    // var command = string.Format(CultureInfo.InvariantCulture, @"{0} /restart /noforce", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "iisreset.exe"));
                    // Removed /noforce

                    output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.RunningCommandOn, command, server.Address));

                    try
                    {
                        var processWMI = new Threading.ProcessWMI();
                        processWMI.ExecuteRemoteProcessWMI(server.Address, command, timeOut / 2);
                    }
                    catch (Exception exception)
                    {
                        output.Add(string.Format(CultureInfo.CurrentUICulture, Exceptions.ExceptionRunningCommandOn, command, server.Address, exception.Message), OutputType.Error, exception.ToString(), exception);
                    }  
                });
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }
    }
}
