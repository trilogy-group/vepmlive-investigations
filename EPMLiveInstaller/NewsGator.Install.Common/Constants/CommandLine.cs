using System;
using System.Collections.ObjectModel;
using System.Linq;
using NewsGator.Install.Common.Entities.Installer;

namespace NewsGator.Install.Common.Constants
{
    /// <summary>
    /// Command Line parameters available to Install.exe
    /// </summary>
    internal static class CommandLine
    {
        internal static Collection<string> Parameters
        {
            get
            {
                return new Collection<string>
	                {
                    ParameterLauncher,
                    ParameterCheckPrerequisites,
                    ParameterInstall,
                    ParameterUninstall,
                    ParameterConfigurationExplorer,
                    ParameterConsumingFarm,
                    ParameterIgnoreMissingModules,
                    ParameterScriptOnly,
                    ParameterSkipPrerequisiteCheck,
                    ParameterLogLocation,
                    ParameterUseTimerJobs
                };
            }
        }

        internal const string ParameterLauncher = @"-Launcher";
        internal const string ParameterCheckPrerequisites = @"-CheckPrerequisites";
        internal const string ParameterInstall = @"-Install";
        internal const string ParameterUninstall = @"-Uninstall";
        internal const string ParameterConfigurationExplorer = @"-ConfigurationExplorer";
        internal const string ParameterConsumingFarm = @"-ConsumingFarm";
        internal const string ParameterIgnoreMissingModules = @"-IgnoreMissingModules";
        internal const string ParameterScriptOnly = @"-ScriptOnly";
        internal const string ParameterSkipPrerequisiteCheck = @"-SkipPrerequisiteCheck";
        internal const string ParameterLogLocation = @"-LogLocation";
        internal const string ParameterUseTimerJobs = @"-UseTimerJobs";

        internal static Collection<CommandLineParameter> ProcessCommandLineArgs(string[] commandLineArgs)
        {
            if (commandLineArgs == null || commandLineArgs.Length == 0)
                return null;

            var parameters = new Collection<CommandLineParameter>();
            var indexesToSkip = new Collection<int>();

            for (var i = 0; i < commandLineArgs.Length; i++)
            {
                if (!indexesToSkip.Contains(i))
                {
                    var arg = commandLineArgs[i];
                    var valid = Parameters.Contains(arg, StringComparer.OrdinalIgnoreCase);
                    var value = string.Empty;

                    if (arg.Equals(ParameterLogLocation, StringComparison.OrdinalIgnoreCase))
                        if (commandLineArgs.Length > (i + 1))
                        {
                            value = commandLineArgs[i + 1];
                            indexesToSkip.Add(i + 1);
                        }

                    parameters.Add(new CommandLineParameter()
                    {
                        Name = arg,
                        Valid = valid,
                        Value = value
                    });
                }
            }

            return parameters;
        }
    }
}
