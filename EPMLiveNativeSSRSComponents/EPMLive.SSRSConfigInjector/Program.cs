using System;
using System.IO;
using System.Xml;

namespace EPMLive.SSRSConfigInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationKey = "9347D98F2686891ECEFB2065F1DF9F5228888B4322D6784A57E38F8A85BF711D";
            var machineKey = "96179BBFEBC4746C988483F8F30762A5EF0B77E08AF10B455953FA1284757A1E";
            var reportServerBasePath = "C:\\Program Files\\Microsoft SQL Server\\MSRS13.MSSQLSERVER";
            var libraryPath = "..\\..\\EPMLive.SSRSCustomAuthentication\\bin\\Debug\\EPMLive.SSRSCustomAuthentication.";

            CopyCustomAuthBinaries(libraryPath, reportServerBasePath);
            ModifyReportServerConfig();
            ModifyReportServerPolicyConfig(reportServerBasePath);
            ModifyReportServerWebConfig(validationKey, machineKey);
            ModifyReportingServicesPortalConfig(validationKey, machineKey);
        }

        private static void CopyCustomAuthBinaries(string libraryPath, string reportServerBasePath)
        {
            if (File.Exists(libraryPath + "dll"))
            {
                var ssrsBinPath = Path.Combine(reportServerBasePath, "Reporting Services\\ReportServer\bin");
                File.Copy(libraryPath + "dll", Path.Combine(ssrsBinPath, libraryPath + "dll"));
                File.Copy(libraryPath + "dll", Path.Combine(ssrsBinPath, libraryPath + "pdb"));
            }
        }

        private static void ModifyReportingServicesPortalConfig(string validationKey, string machineKey)
        {
            var xmlDocument = GetXmlDocument("Microsoft.ReportingServices.Portal.WebHost.exe.config");

            var machineKeyEntryNode = xmlDocument.CreateDocumentFragment();
            machineKeyEntryNode.InnerXml = "<system.web><machineKey validationKey=\"" + validationKey + "\" decryptionKey=\"" + machineKey + "\" validation=\"AES\" decryption=\"AES\" /></system.web>";

            xmlDocument.SelectSingleNode("//configuration").AppendChild(machineKeyEntryNode);

            SaveXmlDocument("Microsoft.ReportingServices.Portal.WebHost.exe.config", xmlDocument);
        }

        private static void ModifyReportServerWebConfig(string validationKey, string machineKey)
        {
            var xmlDocument = GetXmlDocument("web.config");

            var authNode = xmlDocument.SelectSingleNode("//configuration/system.web/authentication");
            authNode.Attributes["mode"].Value = "Forms";
            var fragement = xmlDocument.CreateDocumentFragment();
            fragement.InnerXml = "<forms loginUrl=\"Logon.aspx\" name=\"sqlAuthCookie\" timeout=\"60\" path=\"/\"></forms>";
            authNode.AppendChild(fragement);

            var authorizeNode = xmlDocument.CreateDocumentFragment();
            authNode.InnerXml = "<authorization><deny users=\"?\"/></authorization>";
            xmlDocument.SelectSingleNode("//configuration/system.web").InsertAfter(authorizeNode, authNode);

            var identityNode = xmlDocument.SelectSingleNode("//configuration/system.web/identity");
            identityNode.Attributes["impersonate"].Value = "false";

            var machineKeyEntryNode = xmlDocument.CreateDocumentFragment();
            machineKeyEntryNode.InnerXml = "<machineKey validationKey=\"" + validationKey + "\" decryptionKey=\"" + machineKey + "\" validation=\"AES\" decryption=\"AES\" />";

            xmlDocument.SelectSingleNode("//configuration/system.web").AppendChild(machineKeyEntryNode);

            SaveXmlDocument("web.config", xmlDocument);
        }

        private static void ModifyReportServerPolicyConfig(string reportServerBasePath)
        {
            var binary = Path.Combine(reportServerBasePath, "Reporting Services\\ReportServer\\bin", "EPMLive.SSRSCustomAuthentication.dll");
            var xmlDocument = GetXmlDocument("rssrvpolicy.config");

            var fragment = xmlDocument.CreateDocumentFragment();
            fragment.InnerXml = "<CodeGroup class=\"UnionCodeGroup\" version=\"1\" Name=\"SecurityExtensionCodeGroup\" Description=\"Code group for the sample security extension\" PermissionSetName=\"FullTrust\"><IMembershipCondition class=\"UrlMembershipCondition\" version=\"1\" Url=\"" + binary + "\" /></CodeGroup>";

            var codegenNode = xmlDocument.SelectSingleNode("//CodeGroup/IMembershipCondition[@Url='$CodeGen$/*']");
            codegenNode.ParentNode.ParentNode.InsertAfter(fragment, codegenNode.ParentNode);

            SaveXmlDocument("rssrvpolicy.config", xmlDocument);
        }

        private static void SaveXmlDocument(string fileName, XmlDocument xmlDocument)
        {
            fileName = ".\\..\\..\\Samples\\" + fileName;
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(fileName, settings);
            xmlDocument.Save(writer);
        }

        private static XmlDocument GetXmlDocument(string fileName)
        {
            fileName = ".\\..\\..\\Samples\\" + fileName;
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return xmlDocument;
        }

        private static void ModifyReportServerConfig()
        {
            var xmlDocument = GetXmlDocument("rsreportserver.config");

            AddAuthNode(xmlDocument);
            AddExistingUiNode(xmlDocument);
            AddExistingSecurityExtNode(xmlDocument);
            AddExistingAuthExtNode(xmlDocument);

            SaveXmlDocument("rsreportserver.config", xmlDocument);
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