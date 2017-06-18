using System;
using System.IO;
using System.Xml;

namespace EPMLive.SSRSConfigInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            //CopyCustomAuthBinaries();
            ModifyReportServerConfig();
            ModifyReportServerPolicyConfig();
            ModifyReportServerWebConfig();
            ModifyReportingServicesPortalConfig();
        }

        private static void CopyCustomAuthBinaries()
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

        private static void ModifyReportingServicesPortalConfig()
        {
            throw new NotImplementedException();
        }

        private static void ModifyReportServerWebConfig()
        {
            throw new NotImplementedException();
        }

        private static void ModifyReportServerPolicyConfig()
        {
            throw new NotImplementedException();
        }

        private static void ModifyReportServerConfig()
        {
            var fileName = ".\\..\\..\\Samples\\rsreportserver.config";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            var customNode = xmlDocument.CreateElement("Custom");
            var authenticationNode = xmlDocument.SelectSingleNode("/Configuration/Authentication/AuthenticationTypes");
            authenticationNode.RemoveAll();
            authenticationNode.AppendChild(customNode);
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(fileName, settings);
            xmlDocument.Save(writer);
        }
    }
}