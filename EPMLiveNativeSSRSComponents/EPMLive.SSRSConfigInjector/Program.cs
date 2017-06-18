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

        private static void ModifyReportServerConfig()
        {
            var fileName = ".\\..\\..\\Samples\\rsreportserver.config";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            AddAuthNode(xmlDocument);
            AddExistingUiNode(xmlDocument);
            AddExistingSecurityExtNode(xmlDocument);
            AddExistingAuthExtNode(xmlDocument);

            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(fileName, settings);
            xmlDocument.Save(writer);
        }

        private static void AddExistingAuthExtNode(XmlDocument xmlDocument)
        {
            var existingAuthExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Authentication/Extension[@Type='EPMLive.SSRSCustomAuthentication.AuthenticationExtension, EPMLive.SSRSCustomAuthentication']");
            if (existingAuthExtNode == null)
            {
                var authExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Authentication");
                authExtNode.RemoveAll();
                var fragment = xmlDocument.CreateDocumentFragment();
                fragment.InnerXml = "<Extension Name=\"Forms\" Type=\"EPMLive.SSRSCustomAuthentication.AuthenticationExtension, EPMLive.SSRSCustomAuthentication\"/>";
                authExtNode.AppendChild(fragment);
            }
        }

        private static void AddExistingSecurityExtNode(XmlDocument xmlDocument)
        {
            var existingsecurityExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Security/Extension[@Type='EPMLive.SSRSCustomAuthentication.AuthenticationExtension, EPMLive.SSRSCustomAuthentication']");
            if (existingsecurityExtNode == null)
            {
                var securityExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Security");
                securityExtNode.RemoveAll();
                var fragment = xmlDocument.CreateDocumentFragment();
                fragment.InnerXml = "<Extension Name=\"Forms\" Type=\"EPMLive.SSRSCustomAuthentication.AuthorizationExtension, EPMLive.SSRSCustomAuthentication\"><Configuration><AdminConfiguration><UserName>admin</UserName></AdminConfiguration></Configuration></Extension>";
                securityExtNode.AppendChild(fragment);
            }
        }

        private static void AddExistingUiNode(XmlDocument xmlDocument)
        {
            var existingCustomAuthUI = xmlDocument.SelectSingleNode("/Configuration/UI/CustomAuthenticationUI");
            if (existingCustomAuthUI == null)
            {
                var fragment = xmlDocument.CreateDocumentFragment();
                fragment.InnerXml = @"<CustomAuthenticationUI><UseSSL>False</UseSSL><PassThroughCookies><PassThroughCookie>sqlAuthCookie</PassThroughCookie></PassThroughCookies></CustomAuthenticationUI>";
                var uiNode = xmlDocument.SelectSingleNode("/Configuration/UI");
                uiNode.AppendChild(fragment);
            }
        }

        private static void AddAuthNode(XmlDocument xmlDocument)
        {
            var customNode = xmlDocument.CreateElement("Custom");
            var authenticationNode = xmlDocument.SelectSingleNode("/Configuration/Authentication/AuthenticationTypes");
            authenticationNode.RemoveAll();
            authenticationNode.AppendChild(customNode);
        }
    }
}