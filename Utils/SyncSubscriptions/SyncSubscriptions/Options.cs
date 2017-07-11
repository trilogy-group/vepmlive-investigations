using CommandLine;
using CommandLine.Text;

namespace SyncSubscriptions
{
    public class Options
    {
        [Option("iu", Required = true,
              HelpText = "URL to SSRS running as integrated mode.")]
        public string IntegratedURL { get; set; }

        [Option("in", Required = true,
          HelpText = "SSRS Username (integrated mode).")]
        public string IntegratedUsername { get; set; }

        [Option("ip", Required = true,
          HelpText = "SSRS Password (integrated mode).")]
        public string IntegratedPassword { get; set; }

        [Option("ia", Required = true,
          HelpText = "SSRS Authentication Mode (integrated mode). Values allowed: W = WindowsAuthentication | F = FormsBasedAuthentication")]
        public string IntegratedAuthMode { get; set; }

        [Option("nu", Required = true,
          HelpText = "URL to SSRS running as native mode.")]
        public string NativeURL { get; set; }

        [Option("nn", Required = true,
          HelpText = "SSRS Username (native mode).")]
        public string NativeUsername { get; set; }

        [Option("np", Required = true,
          HelpText = "SSRS Password (native mode).")]
        public string NativePassword { get; set; }

        [Option("na", Required = true,
          HelpText = "SSRS Authentication Mode (native mode). Values allowed: W = WindowsAuthentication | F = FormsBasedAuthentication")]
        public string NativeAuthMode { get; set; }

        [Option("wu", Required = true,
          HelpText = "WebApplication URL.")]
        public string WebApplicationURL { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
