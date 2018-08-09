using NewsGator.Install.Common.Entities.Installer;
using NewsGator.Install.Common.Output;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.EnterpriseServices.Internal;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Assemblies
    {
        private static string[] AssemblyPrefixes = { "NewsGator.*", "SocialSites.*", "SharePoint.Ajax.*" };
        private static string[] GacDirectories = { @"{0}\assembly\gac_msil", @"{0}\microsoft.net\assembly\gac_msil" };

        internal static void RemoveAssemblyFromGAC(string assemblyToCheck)
        {
            try
            {                
                var assembliesToRemove = new Collection<string>();

                var gac35 = "c:\\windows\\assembly\\gac_msil";
                var gac40 = "c:\\windows\\microsoft.net\\assembly\\gac_msil";

                var gacSubFormat = "{0}\\{1}.dll";
                var gacFormat = "{0}\\{1}";
               
                var directory35 = string.Format(CultureInfo.InvariantCulture, gacFormat, gac35, assemblyToCheck);
                var directory40 = string.Format(CultureInfo.InvariantCulture, gacFormat, gac40, assemblyToCheck);

                foreach (var directory in new Collection<string> { directory35, directory40 })
                {
                    if (Directory.Exists(directory))
                    {
                        foreach (var subdirectory in Directory.GetDirectories(directory))
                        {
                            var fileToCheck = string.Format(CultureInfo.InvariantCulture, gacSubFormat, subdirectory, assemblyToCheck);
                            if (File.Exists(fileToCheck))
                            {
                                assembliesToRemove.Add(fileToCheck);
                            }
                        }
                    }
                }

                foreach (var assemblyToRemove in assembliesToRemove)
                {
                    try
                    {
                        var publish = new Publish();
                        publish.GacRemove(assemblyToRemove);
                    }
                    catch { }
                }
            }
            catch { }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue GetAssemblies(out Assembly[] assemblies)
        {
            var output = new OutputQueue();
            var assembliesToOutput = new Collection<Assembly>();

            try
            {
                var windir = Environment.GetEnvironmentVariable("SystemRoot");

                foreach (var gacLocation in GacDirectories)
                {
                    var gacPath = string.Format(CultureInfo.InvariantCulture, gacLocation, windir);
                    if (Directory.Exists(gacPath))
                    {
                        foreach (var prefix in AssemblyPrefixes)
                        {
                            var assemblyDirectories = Directory.GetDirectories(gacPath, prefix);
                            foreach (var assemblyDirectory in assemblyDirectories)
                            {
                                var versionDirectories = Directory.GetDirectories(assemblyDirectory);
                                foreach (var versionDirectory in versionDirectories)
                                {
                                    var assemblyFiles = Directory.GetFiles(versionDirectory, "*.dll");
                                    foreach (var assemblyFile in assemblyFiles)
                                    {
                                        if (File.Exists(assemblyFile))
                                        {
                                            try
                                            {
                                                assembliesToOutput.Add(Assembly.ReflectionOnlyLoadFrom(assemblyFile));
                                            }
                                            catch (Exception exception)
                                            {
                                                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
            }

            assemblies = assembliesToOutput.ToArray();
            return output;
        }

        /// <summary>
        /// Add the assemblies from each available WSP to the Global Assembly Cache on the local machine.
        /// </summary>
        /// <param name="literalPath"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputQueue.Add(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static OutputQueue RepairAssemblies(string literalPath)
        {
            var output = new OutputQueue();

            try
            {
                var tempPath = Path.Combine(literalPath, "temp");
                DirectoryInfo directory = null;
                if (!Directory.Exists(tempPath))
                    Directory.CreateDirectory(tempPath);
                directory = new DirectoryInfo(tempPath);

                var command = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\expand.exe";
                var wsps = Directory.GetFiles(literalPath, "*.wsp");
                foreach (var wsp in wsps)
                {
                    var args = "\"" + wsp + "\" -f:*.dll \"" + tempPath + "\"";
                    output.Add(Files.RunCommand(command, args));
                }

                var publish = new Publish();
                var assemblies = directory.GetFiles("*.dll");
                foreach (var assembly in assemblies)
                {
                    try
                    {
                        output.Add(string.Format(CultureInfo.InvariantCulture, "Adding \"{0}\" to the Global Assembly Cache.", assembly.Name));
                        publish.GacInstall(assembly.FullName);
                    }
                    catch (Exception exception)
                    {
                        output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
                    }
                }

                directory.Delete(true);
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
            }

            return output;
        }

        internal static OutputQueue CheckWSPAssemblyVersions(ref Collection<SocialSitesWSPAssemblyVersion> solutionVersions, string literalPath)
        {
            var output = new OutputQueue();
            if (solutionVersions == null)
                return output;

            var solutionNames = solutionVersions.Select(q => q.SolutionName);
            var solutionVersionsOutput = new Collection<SocialSitesWSPAssemblyVersion>();
            
            try
            {
                var tempPath = Path.Combine(literalPath, "temp");
                DirectoryInfo directory = null;
                if (!Directory.Exists(tempPath))
                    Directory.CreateDirectory(tempPath);
                directory = new DirectoryInfo(tempPath);

                var command = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\expand.exe";
                var wsps = new List<string>();
                var allWSPs = Directory.GetFiles(literalPath, "*.wsp");
                foreach (var wsp in allWSPs)
                {
                    string[] pathComponents;
                    if (wsp.IndexOf("\\", StringComparison.OrdinalIgnoreCase) != -1)
                        pathComponents = wsp.Split('\\');
                    else
                        pathComponents = new string[] { wsp };

                    if (pathComponents.Any(p => solutionNames.Contains(p, StringComparer.OrdinalIgnoreCase)))
                    {
                        wsps.Add(wsp);
                    }
                }
                
                foreach (var wsp in wsps)
                {
                    var args = "\"" + wsp + "\" -f:*.dll \"" + tempPath + "\"";
                    output.Add(Files.RunCommand(command, args));
                }

                foreach (var solutionVersion in solutionVersions)
                {
                    var outputVersion = solutionVersion;
                    var assemblyVersions = new Dictionary<string, Version>();

                    foreach (var assemblyVersionKey in outputVersion.Assemblies.Keys)
                    {
                        var filePath = Path.Combine(directory.FullName, assemblyVersionKey);
                        var version = Files.GetAssemblyFileVersion(filePath);
                        assemblyVersions.Add(assemblyVersionKey, version);
                    }

                    outputVersion.Assemblies = assemblyVersions;
                    solutionVersionsOutput.Add(outputVersion);
                }

                try
                {
                    directory.Delete(true);
                }
                catch { } // Don't Care
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, exception.ToString(), exception);
            }

            solutionVersions = solutionVersionsOutput;

            return output;
        }
    }
}
