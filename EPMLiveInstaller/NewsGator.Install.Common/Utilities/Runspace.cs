using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using System.IO;
using Microsoft.SharePoint.Administration;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Globalization;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Utilities
{
    public static class Runspace
    {
        #region Setup Executable and Config
        private static string NGPSFileName = "NGPS.exe";
        private static string NGPSConfigFileName = "NGPS.exe.config";

        private static string PowerShellPath()
        {
            return Path.Combine(Environment.SystemDirectory, "WindowsPowerShell\\v1.0\\PowerShell.exe");
        }

        private static string ExecutionPath()
        {
            return Path.GetDirectoryName(typeof(NewsGator.Install.Common.Utilities.Runspace).Assembly.Location);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        private static string PowerShellVersion()
        {
            return LocalFarm.Get().BuildVersion.Major == 14 ? "2" : "3";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        private static string ExecutableConfig()
        {
            switch(LocalFarm.Get().BuildVersion.Major)
            {
                case 16:
                    return Config.ExecutableConfig2016;
                case 15:
                    return Config.ExecutableConfig2013;
                default:
                    return Config.ExecutableConfig2010;
            }
        }

        public static OutputQueue EnsurePowerShellExecutable()
        {
            var output = new OutputQueue();

            var psFile = Path.Combine(ExecutionPath(), NGPSFileName);
            var psConfigFile = Path.Combine(ExecutionPath(), NGPSConfigFileName);

            if (!File.Exists(psFile))
            {
                output.Add(NewsGator.Install.Resources.UserDisplay.PowerShell_CopyExecutable);
                File.Copy(PowerShellPath(), psFile);
            }

            if (!File.Exists(psConfigFile))
            {
                output.Add(NewsGator.Install.Resources.UserDisplay.PowerShell_WritingConfigurationFile);
                File.WriteAllText(psConfigFile, ExecutableConfig(), UTF8Encoding.UTF8);
            }

            return output;
        }
        #endregion

        #region Run PowerShell
        
        private const string FormatLoad = "[System.Reflection.Assembly]::LoadFrom(\"{0}\") | Out-Null; ";
        private const string AddSharePointSnapIn = "Add-PSSnapIn Microsoft.SharePoint.PowerShell -ErrorAction SilentlyContinue | Out-Null; ";
        private const string FormatCommand = "$outputQueue = {0}; ";
        private const string FormatNGPS = ".\\NGPS.exe -Version {0} -EncodedCommand {1}";
        private const string FormatCD = "Set-Location \"{0}\" | Out-Null; ";
        private const string OutputSubCmd = "$content = $outputQueue.Serialize(); Set-Content -Path .\\NGPSOutput.temp -Value $content -Encoding UTF8 -Force; ";
        private const string OutputCmd = "Write-Output $outputQueue; ";
        private const string Prefix = "OUTPUTQUEUE::";

        public static OutputQueue RunInPowerShell(string command)
        {
            return RunInPowerShell(command, false);
        }

        /// <summary>
        /// Run the specific method in a new PowerShell process.
        /// </summary>
        /// <param name="command">Include just the method and its parameters, the output will be hanlded by this method.  The method must return an OutputQueue object.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NGPSOutput"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "NewsGator.Install.Common.Output.OutputQueue.Add(System.String)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Add-PSSnapIn"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ErrorAction"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "SilentlyContinue"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "outputQueue"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "LoadFrom"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2116:AptcaMethodsShouldOnlyCallAptcaMethods"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "sp"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue RunInPowerShell(string command, bool spCmdlet)
        {
            var output = new OutputQueue();

            output.Add(EnsurePowerShellExecutable());

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                var ps = runspace.CreatePipeline();

                var assembly = Path.Combine(ExecutionPath(), "NewsGator.Install.Common.dll");
                var commandToRun = string.Format(CultureInfo.InvariantCulture, FormatLoad, assembly);
                commandToRun += AddSharePointSnapIn;
                commandToRun += string.Format(CultureInfo.InvariantCulture, FormatCD, ExecutionPath());
                if (spCmdlet)
                    commandToRun += command + "; ";
                else
                {
                    commandToRun += string.Format(CultureInfo.InvariantCulture, FormatCommand, command);
                    commandToRun += OutputSubCmd;
                }

#if DEBUG
                output.Add(commandToRun);
#endif

                var encoded = Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(commandToRun));
                ps.Commands.AddScript(string.Format(CultureInfo.InvariantCulture, FormatLoad, assembly));
                ps.Commands.AddScript(string.Format(CultureInfo.InvariantCulture, FormatCD, ExecutionPath()));
                ps.Commands.AddScript(string.Format(CultureInfo.InvariantCulture, FormatCommand, string.Format(CultureInfo.InvariantCulture, FormatNGPS, PowerShellVersion(), encoded)));                
                ps.Commands.AddScript(OutputCmd);

#if DEBUG
                foreach (var cmd in ps.Commands)
                {
                    if (cmd.IsScript)
                        output.Add(cmd.CommandText);
                }
#endif

                var cmdOutput = ps.Invoke();
                var outputQueueString = string.Empty;

#if DEBUG
                var debugOutput = string.Empty;
                if (cmdOutput != null)
                {
                    for (var i = 0; i < cmdOutput.Count; i++)
                    {
                        if (cmdOutput[i] != null)
                        {
                            var outputString = cmdOutput[i].BaseObject.ToString().Trim();
                            if (!string.IsNullOrEmpty(outputString))
                                debugOutput += outputString;
                        }
                    }
                }

                output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.PSOutput, command, debugOutput));
#endif 

                if (spCmdlet)
                {
                    if (cmdOutput != null)
                    {
                        for (var i = 0; i < cmdOutput.Count; i++)
                        {
                            if (cmdOutput[i] != null)
                            {
                                var outputString = cmdOutput[i].BaseObject.ToString().Trim();
                                if (!string.IsNullOrEmpty(outputString))
                                    outputQueueString += outputString;
                            }
                        }
                    }

                    output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.PSOutput, command, outputQueueString));
                }
                else
                {
                    var tempFilePath = Path.Combine(ExecutionPath(), "NGPSOutput.temp");

                    if (File.Exists(tempFilePath))
                    {
                        var tempContent = File.ReadAllText(tempFilePath, UTF8Encoding.UTF8);
                        try
                        {
                            var queue = new OutputQueue();
                            queue.Add(queue.Deserialize(tempContent));
                            output.Add(queue);
                        }
                        catch (Exception exception)
                        {
                            exception.Data.Add("NGDescription", tempContent);
                            output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.DeserializationError, exception.Message), OutputType.Error, exception.ToString(), exception);
                        }
                        File.Delete(tempFilePath);
                    }
                    else
                    {
                        var getRemaining = false;

                        if (cmdOutput != null)
                        {
                            for (var i = 0; i < cmdOutput.Count; i++)
                            {
                                if (cmdOutput[i] != null)
                                {
                                    if (!getRemaining)
                                    {
                                        if (cmdOutput[i].BaseObject.ToString().IndexOf(Prefix, StringComparison.OrdinalIgnoreCase) > -1)
                                        {
                                            outputQueueString = cmdOutput[i].BaseObject.ToString().Trim();
                                            getRemaining = true;
                                        }
                                    }
                                    else
                                    {
                                        outputQueueString += cmdOutput[i].BaseObject.ToString().Trim();
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(outputQueueString))
                        {
                            try
                            {
                                var queue = new OutputQueue();
                                queue.DecodeAndAdd(outputQueueString);
                                output.Add(queue);
                            }
                            catch (Exception exception)
                            {
                                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.DeserializationError, exception.Message), OutputType.Error, exception.ToString(), exception);
                            }
                        }

                        if (!getRemaining)
                        {
                            var unexpectedOutput = string.Empty;
                            for (var i = 0; i < cmdOutput.Count; i++)
                            {
                                if (cmdOutput[i] != null)
                                {
                                    if (i == 0)
                                    {
                                        unexpectedOutput = string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Exceptions.RunspaceUnexpectedOutput, cmdOutput[i].BaseObject.ToString().Trim());
                                    }
                                    else
                                    {
                                        unexpectedOutput += Environment.NewLine + cmdOutput[i].BaseObject.ToString().Trim();
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(unexpectedOutput))
                                output.Add(unexpectedOutput, OutputType.Warning);
                        }
                    }
                }

#if DEBUG
                output.Add(string.Format(CultureInfo.CurrentUICulture, UserDisplay.PSOutput, command, outputQueueString));
#endif
            }

            return output;
        }
        #endregion
    }
}
