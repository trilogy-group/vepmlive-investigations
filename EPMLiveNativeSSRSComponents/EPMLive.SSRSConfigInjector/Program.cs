using System.IO;

namespace EPMLive.SSRSConfigInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportServerBasePath = "C:\\Program Files\\Microsoft SQL Server\\MSRS13.MSSQLSERVER";
            var libraryPath = "..\\..\\EPMLive.SSRSCustomAuthentication\\bin\\Debug\\EPMLive.SSRSCustomAuthentication.";
            
            if (File.Exists(libraryPath + "dll"))
            {
                var ssrsBinPath = Path.Combine(reportServerBasePath, "Reporting Services\\ReportServer\bin");
                File.Copy(libraryPath + "dll", Path.Combine(ssrsBinPath, libraryPath + "dll"));
                File.Copy(libraryPath + "dll", Path.Combine(ssrsBinPath, libraryPath + "pdb"));
            }

        }
    }
}