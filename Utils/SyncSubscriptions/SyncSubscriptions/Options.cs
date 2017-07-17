using CommandLine;
using CommandLine.Text;

namespace SyncSubscriptions
{
    public class Options
    {
        [Option('m', Required = true,
              HelpText = "Running Mode. B = Backup of Subscriptions on integrated server | R = Restore subscriptions on native server.")]
        public string Mode { get; set; }

        [Option('s', Required = true,
              HelpText = "URL to SSRS server.")]
        public string URL { get; set; }

        [Option('u', Required = true,
          HelpText = "SSRS Username.")]
        public string Username { get; set; }

        [Option('p', Required = true,
          HelpText = "SSRS Password.")]
        public string Password { get; set; }

        [Option('a', Required = true,
          HelpText = "SSRS Authentication Mode. Values allowed: W = WindowsAuthentication | F = FormsBasedAuthentication")]
        public string AuthMode { get; set; }        

        [Option('w', Required = false,
          HelpText = "WebApplication URL. Should be informed when running on backup (B) mode only.")]
        public string WebApplicationURL { get; set; }

        [Option('b', Required = false,
          HelpText = "Path for a folder where backup files will be placed. Default value: /Backup. If path does not exists, then it will be automatically created. ")]
        public string BackupPath { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
