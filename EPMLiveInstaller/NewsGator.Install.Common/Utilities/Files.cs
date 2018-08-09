using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Deployment.Compression;
using Microsoft.Deployment.Compression.Zip;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Utilities.NTFSStreams;
using NewsGator.Install.Resources;
using System.Security.Policy;
using NewsGator.Install.Common.Entities.SocialSites;
using NewsGator.Install.Common.Output;
using System.Security.Permissions;
using System.Security;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Files
    {
        private const string _manifestVersionTag = "SharePointProductVersion=\"15.0\"";
        private const string _ps1OutputFormat = "NewsGatorOperation_{0}.ps1";

        #region Public Methods
        internal static string OutputPowerShellFile (string content, string literalPath)
        {
            var executionPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ServiceApplicationConfiguration)).Location);
            if (executionPath.Contains("file:\\"))
                executionPath = executionPath.Replace("file:\\", "");
            if (!executionPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                executionPath += "\\";

            content = UserDisplay.ScriptOnlyCopyright + string.Format(CultureInfo.InvariantCulture, "Add-PSSnapIn Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue \\r\\nImport-Module \"{0}\\NewsGator.Install.Cmdlets.dll\" -ErrorAction SilentlyContinue \\r\\n", executionPath) + content;            
            content = content.Replace("\\r\\n", Environment.NewLine);

            var path = Path.Combine(literalPath, string.Format(System.Globalization.CultureInfo.InvariantCulture, _ps1OutputFormat, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss", CultureInfo.InvariantCulture)));
            File.WriteAllText(path, content);
            return path;
        }

        internal static string WriteInstallConfigFile(bool force = false, bool ngPSConfig = false)
        {
            var executionPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ServiceApplicationConfiguration)).Location);
            if (executionPath.Contains("file:\\"))
                executionPath = executionPath.Replace("file:\\", "");
            if (!executionPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                executionPath += "\\";

            return WriteConfigFile(LocalFarm.Get().BuildVersion.Major, executionPath, force, ngPSConfig);
        }

        internal static void CopyPowerShellExecutable()
        {
            var executionPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ServiceApplicationConfiguration)).Location);
            if (executionPath.Contains("file:\\"))
                executionPath = executionPath.Replace("file:\\", "");
            if (!executionPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                executionPath += "\\";

            var ngPSPath = executionPath + "NGPS.exe";
            if (!File.Exists(ngPSPath))
                File.Copy(@"C:\Windows\System32\WindowsPowerShell\v1.0\PowerShell.exe", ngPSPath);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal static string GetLicenseKeyFromFile()
        {
            var returnValue = string.Empty;

            try
            {
                var executionPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(ServiceApplicationConfiguration)).Location);
                if (executionPath.Contains("file:\\"))
                    executionPath = executionPath.Replace("file:\\", "");
                if (!executionPath.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                    executionPath += "\\";

                var filePath = executionPath + "license.key";
                if (File.Exists(filePath))
                    returnValue = File.ReadAllText(filePath);
            }
            catch // Don't Care
            { }

            return returnValue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue SolutionManifestVersion(SocialSitesSolution solution, string literalPath, out int majorVersion)
        {
            majorVersion = -1;
            var outputQueue = new OutputQueue();
            
            if (solution != null)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.SolutionManifestCheck, solution.SolutionName));
            
                try
                {
                    var filePath = Path.Combine(literalPath, solution.SolutionName);
                    var tempPath = Path.Combine(literalPath, "temp");
                    var manifestPath = Path.Combine(tempPath, "manifest.xml");
                    if (File.Exists(filePath))
                    {
                        DirectoryInfo directory = null;
                        if (!Directory.Exists(tempPath))
                            Directory.CreateDirectory(tempPath);
                        directory = new DirectoryInfo(tempPath);

                        if (File.Exists(manifestPath))
                        {
                            try
                            {
                                File.SetAttributes(manifestPath, FileAttributes.Normal);
                                File.Delete(manifestPath);
                            }
                            catch (IOException)
                            {
                                Thread.Sleep(100);
                                File.SetAttributes(manifestPath, FileAttributes.Normal);
                                File.Delete(manifestPath);
                            }
                        }

                        var command = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\expand.exe";
                        var args = "\"" + filePath + "\" -f:manifest.xml \"" + tempPath + "\"";
                        outputQueue.Add(RunCommand(command, args));

                        if (File.Exists(manifestPath))
                        {
                            var manifestContents = File.ReadAllText(manifestPath);
                            var manifestVersionTag = Regex.Unescape(_manifestVersionTag);
                            if (manifestContents.IndexOf(manifestVersionTag, 0, StringComparison.OrdinalIgnoreCase) > 0)
                                majorVersion = 15;
                            else
                                majorVersion = 14;

                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.SolutionManifestCheckComplete, solution.SolutionName, majorVersion.ToString(CultureInfo.InvariantCulture)));

                            try
                            {
                                File.SetAttributes(manifestPath, FileAttributes.Normal);
                                File.Delete(manifestPath);
                            }
                            catch (IOException)
                            {
                                Thread.Sleep(100);
                                File.SetAttributes(manifestPath, FileAttributes.Normal);
                                File.Delete(manifestPath);
                            }
                        }

                        directory.Delete(true);
                    }
                }
                catch (Exception exception)
                {
                    outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.SolutionManifestCheckError, solution.SolutionName, exception.Message), OutputType.Error, string.Empty, exception);
                }
            }

            return outputQueue;
        }

        internal static bool ValidDirectory(string literalPath)
        {
            return Directory.Exists(literalPath);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue UnblockFiles(string literalPath)
        {
            var outputQueue = new OutputQueue();
            var directory = new DirectoryInfo(literalPath);
            
            foreach (var subDirectory in directory.GetDirectories())
            {
                outputQueue.Add(UnblockFiles(subDirectory.FullName));
            }

            foreach (var file in directory.GetFiles())
            {
                if (!file.IsBlocked())
                    continue;
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.UnblockingFile, file.FullName));
                file.Unblock();                
            }

            return outputQueue;
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        internal static void CompressFile(string filePath, bool deleteOriginal = false)
        {
            if (File.Exists(filePath))
            {
                var compressedFilePath = filePath + ".zip";
                var zipFile = new ZipInfo(compressedFilePath);
                var files = new Collection<string>() { filePath };
                zipFile.PackFiles(null, files, null, CompressionLevel.Max, null);

                if (deleteOriginal && File.Exists(compressedFilePath))
                    File.Delete(filePath);
            }
        }

        /// <summary>
        /// Get the Assembly File Version from the GAC
        /// </summary>
        /// <param name="assemblyName">
        /// The name of the Assembly without the file extension.  For example: NewsGator.Core.
        /// </param>
        /// <returns></returns>
        internal static Version GetAssemblyVersion(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
                return null;

            if (assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                assemblyName = assemblyName.Substring(0, assemblyName.Length - 4);
            }

            Version returnValue = null;            
            var gacPath35 = "C:\\Windows\\Assembly\\GAC_MSIL\\" + assemblyName;
            var gacPath40 = "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\" + assemblyName;

            if (Directory.Exists(gacPath35))
            {
                var directory = new DirectoryInfo(gacPath35);
                if (directory.GetDirectories().Count() > 0)
                {
                    var pathName = directory.GetDirectories()[0].FullName;
                    if (!pathName.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                        pathName = pathName + "\\";

                    var filePath = new FileInfo(pathName + assemblyName + ".dll").FullName;
                    if (File.Exists(filePath))
                    {
                        returnValue = GetAssemblyFileVersion(filePath);
                    }
                }
            }

            if (returnValue == null)
            {
                if (Directory.Exists(gacPath40))
                {
                    var directory = new DirectoryInfo(gacPath40);
                    if (directory.GetDirectories().Count() > 0)
                    {
                        var pathName = directory.GetDirectories()[0].FullName;
                        if (!pathName.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                            pathName = pathName + "\\";

                        var filePath = new FileInfo(pathName + assemblyName + ".dll").FullName;
                        if (File.Exists(filePath))
                        {
                            returnValue = GetAssemblyFileVersion(filePath);
                        }
                    }
                }
            }

            return returnValue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom")]
        internal static Assembly GetAssemblyFromGACFile(string assemblyName)
        {
            if (string.IsNullOrEmpty(assemblyName))
                return null;

            var evidence = AppDomain.CurrentDomain.Evidence;

            if (assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                assemblyName = assemblyName.Substring(0, assemblyName.Length - 4);
            }

            Assembly returnValue = null;
            var gacPath35 = "C:\\Windows\\Assembly\\GAC_MSIL\\" + assemblyName;
            var gacPath40 = "C:\\Windows\\Microsoft.NET\\assembly\\GAC_MSIL\\" + assemblyName;

            if (Directory.Exists(gacPath35))
            {
                var directory = new DirectoryInfo(gacPath35);
                if (directory.GetDirectories().Count() > 0)
                {
                    var pathName = directory.GetDirectories()[0].FullName;
                    if (!pathName.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                        pathName = pathName + "\\";

                    var filePath = new FileInfo(pathName + assemblyName + ".dll").FullName;
                    if (File.Exists(filePath))
                    {
                        returnValue = Assembly.LoadFrom(filePath, evidence);
                    }
                }
            }

            if (returnValue == null)
            {
                if (Directory.Exists(gacPath40))
                {
                    var directory = new DirectoryInfo(gacPath40);
                    if (directory.GetDirectories().Count() > 0)
                    {
                        var pathName = directory.GetDirectories()[0].FullName;
                        if (!pathName.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                            pathName = pathName + "\\";

                        var filePath = new FileInfo(pathName + assemblyName + ".dll").FullName;
                        if (File.Exists(filePath))
                        {
                            returnValue = Assembly.LoadFrom(filePath, evidence);
                        }
                    }
                }
            }

            return returnValue;
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue RunCommand(string fileName, string args, string workingDirectory = null)
        {
            var outputQueue = new OutputQueue();
            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.RunningCommand, fileName, args));

            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = fileName,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            if (!string.IsNullOrEmpty(args))
                startInfo.Arguments = args;
            if (!string.IsNullOrEmpty(workingDirectory))
                startInfo.WorkingDirectory = workingDirectory;

            var commandOutput = new Collection<string>();
            var process = new Process();
            try
            {
                process.StartInfo = startInfo;
                process.OutputDataReceived += (o, e) =>
                {
                    if (e.Data != null)
                        if (!string.IsNullOrEmpty(e.Data.Trim()))
                        {
                            outputQueue.Add(e.Data);
                        }
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            finally
            {
                process.Close();
            }

            foreach (var output in commandOutput)
            {
                if (output.StartsWith("ERROR", StringComparison.OrdinalIgnoreCase))
                    outputQueue.Add(output, OutputType.Error);
                else if (output.StartsWith("WARNING", StringComparison.OrdinalIgnoreCase))
                    outputQueue.Add(output, OutputType.Warning);
                else
                    outputQueue.Add(output);
            }

            outputQueue.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.RunningCommandComplete, fileName, args));

            return outputQueue;
        }
                
        internal static string GetVersionedGenericSetupPath(string strSubdir, int desiredPathVersion)
        {
            if (desiredPathVersion == 14)
                return SPUtility.GetGenericSetupPath(strSubdir);

            try
            {
                if (desiredPathVersion == 0)
                {
                    return GetGenericSetupPathNoFallback(strSubdir);
                }
                string genericSetupPathBase = GetGenericSetupPathBase();
                return string.Concat(new object[] { genericSetupPathBase, desiredPathVersion.ToString(CultureInfo.InvariantCulture), Path.DirectorySeparatorChar, strSubdir });
            }
            catch
            {
                return SPUtility.GetGenericSetupPath(strSubdir);
            }
        }
        #endregion

        #region Private Methods
        private static bool s_genericSetupPathInitialized;
        private static string s_strRegLoc;
        private static string s_genericSetupPathBase;
        private static int s_genericSetupPathVersion;

        private static string GetGenericSetupPathBase()
        {
            InitGenericSetupPath();
            return s_genericSetupPathBase;
        }

        private static string GetGenericSetupPathNoFallback(string relativePath)
        {
            InitGenericSetupPath();
            if (s_strRegLoc != null)
            {
                return (s_strRegLoc + relativePath);
            }
            return null;
        }

        private static readonly string VKEY_FPSEVer15 = (@"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\" + 15 + ".0");
        private static readonly string VKEY_FPSEVer16 = (@"SOFTWARE\Microsoft\Shared Tools\Web Server Extensions\" + 16 + ".0");

        private static void InitGenericSetupPath()
        {
            if (!s_genericSetupPathInitialized)
            {
                var localMachineRegistryValue = GetLocalMachineRegistryValue(VKEY_FPSEVer16, "Location");
                if (string.IsNullOrEmpty(localMachineRegistryValue))
                    localMachineRegistryValue = GetLocalMachineRegistryValue(VKEY_FPSEVer15, "Location");

                if (!string.IsNullOrEmpty(localMachineRegistryValue))
                {
                    s_strRegLoc = (localMachineRegistryValue[localMachineRegistryValue.Length - 1] == Path.DirectorySeparatorChar) ? localMachineRegistryValue : (localMachineRegistryValue + Path.DirectorySeparatorChar);
                    int length = s_strRegLoc.Length;
                    if (((length >= 4) && char.IsDigit(s_strRegLoc[length - 2])) && (char.IsDigit(s_strRegLoc[length - 3]) && (Path.DirectorySeparatorChar == s_strRegLoc[length - 4])))
                    {
                        s_genericSetupPathBase = s_strRegLoc.Substring(0, length - 3);
                        s_genericSetupPathVersion = Convert.ToInt32(s_strRegLoc.Substring(length - 3, 2), CultureInfo.InvariantCulture);
                    }
                }
            }
            s_genericSetupPathInitialized = true;
        }

        private static string GetLocalMachineRegistryValue(string path, string keyName)
        {
            return GetLocalMachineRegistryValue<string>(path, keyName, null);
        }

        [RegistryPermission(SecurityAction.Assert, Read = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Shared Tools\Web Server Extensions")]
        private static T GetLocalMachineRegistryValue<T>(string path, string keyName, T defaultValue)
        {
            T local;
            try
            {                
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
                {
                    if (key == null)
                    {
                        return defaultValue;
                    }
                    object obj2 = key.GetValue(keyName);
                    if (obj2 is T)
                    {
                        return (T)obj2;
                    }
                    local = defaultValue;
                }                
            }
            catch (Exception)
            {
                throw;
            }
            return local;
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal static Version GetAssemblyFileVersion(string filePath)
        {
            try
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(filePath);
                var versionString = fileVersionInfo.FileVersion;

                if (!string.IsNullOrEmpty(versionString))
                    return new Version(versionString);
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return null;
        }

        internal static string GetTemporaryDirectory(Guid installId)
        {
            var directory = System.IO.Path.GetTempPath();
            if (!directory.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                directory += "\\";
            directory += "NewsGatorSocialSites" + installId.ToString();

            return directory;
        }

        private static string WriteConfigFile(int version, string path, bool force = false, bool ngPSConfig = false)
        {
            if (!path.EndsWith("\\", StringComparison.OrdinalIgnoreCase))
                path += "\\";
            var installConfig = path + (ngPSConfig ? "NGPS.exe.config" : "Install.exe.config");

            if (!File.Exists(installConfig) || force)
            {
                string config;
                switch (version)
                {
                    case 16:
                        config = Config.ExecutableConfig2016;
                        break;
                    case 15:
                        config = Config.ExecutableConfig2013;
                        break;
                    default:
                        config = Config.ExecutableConfig2010;
                        break;
                }

                File.WriteAllText(installConfig, config, UTF8Encoding.UTF8);
            }

            return installConfig;
        }
        #endregion
    }
}
