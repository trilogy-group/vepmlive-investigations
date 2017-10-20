using EPMLive.SSRSConfigInjector.Resolver;
using System;
using System.Configuration;
using System.IO;
using System.Xml;

namespace EPMLive.SSRSConfigInjector
{
    public class Program
    {
        private static string reportServerBasePath = ConfigurationManager.AppSettings["ssrspath"];

        private static IPathResolver pathResolver = new PathResolver(reportServerBasePath);

        public static void Main(string[] args)
        {
            if(!Directory.Exists(reportServerBasePath))
            {
                throw new DirectoryNotFoundException($"{reportServerBasePath} not found.");
            }
            if (Convert.ToString(args[0]) == "restore")
            {
                RestoreBackup();
            }
            else if (Convert.ToString(args[0]) == "install")
            {
                if(args.Length != 2)
                {
                    throw new ArgumentNullException("Admin username not found.");
                }

                var validationKey = ConfigurationManager.AppSettings["validationkey"];
                var machineKey = ConfigurationManager.AppSettings["machinekey"];
                MakeBackup();
                CopyCustomAuthBinaries();
                ModifyReportServerConfig(Convert.ToString(args[1]));
                ModifyReportServerPolicyConfig();
                ModifyReportServerWebConfig(validationKey, machineKey);
                ModifyReportingServicesPortalConfig(validationKey, machineKey);
            }
        }

        private static void RestoreBackup()
        {
            RestoreFromBackup("rsreportserver.config", "rs");
            RestoreFromBackup("rssrvpolicy.config", "rs");
            RestoreFromBackup("web.config", "rs");
            RestoreFromBackup("Microsoft.ReportingServices.Portal.WebHost.exe.config", "wa");
        }

        private static void MakeBackup()
        {
            BackupFile("rsreportserver.config", "rs");
            BackupFile("rssrvpolicy.config", "rs");
            BackupFile("web.config", "rs");
            BackupFile("Microsoft.ReportingServices.Portal.WebHost.exe.config", "wa");
        }

        private static void BackupFile(string filename, string folderType)
        {
            if (folderType == "rs")
            {
                CopyFile(pathResolver.GetReportingServicePath(filename), pathResolver.GetReportingServicePath(filename + ".bkp"), false);
            }                
            else if (folderType == "wa")
            {
                CopyFile(pathResolver.GetReportWebAppPath(filename), pathResolver.GetReportWebAppPath(filename + ".bkp"), false);
            }
        }

        private static void RestoreFromBackup(string filename, string folderType)
        {
            if (folderType == "rs")
            {
                CopyFile(pathResolver.GetReportingServicePath(filename + ".bkp"), pathResolver.GetReportingServicePath(filename), true);
                File.Delete(pathResolver.GetReportingServicePath(filename + ".bkp"));
            }
            else if (folderType == "wa")
            {
                CopyFile(pathResolver.GetReportWebAppPath(filename + ".bkp"), pathResolver.GetReportWebAppPath(filename), true);
                File.Delete(pathResolver.GetReportWebAppPath(filename + ".bkp"));
            }            
        }

        private static void CopyCustomAuthBinaries()
        {
            var libraryPath = "EPMLive.SSRSCustomAuthentication.";

            if (File.Exists(libraryPath + "dll"))
            {
                var ssrsBinPath = Path.Combine(pathResolver.GetReportingServicePath(), "bin");
                File.Copy(libraryPath + "dll", Path.Combine(ssrsBinPath, libraryPath + "dll"), true);
                File.Copy(libraryPath + "pdb", Path.Combine(ssrsBinPath, libraryPath + "pdb"), true);
                File.Copy("Logon.aspx", Path.Combine(pathResolver.GetReportingServicePath(), "Logon.aspx"), true);
                Directory.CreateDirectory(Path.Combine(pathResolver.GetReportingServicePath(), "Javascript"));
                File.Copy(Path.Combine("Javascript", "easyXDM.min.js"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "easyXDM.min.js"), true);
                File.Copy(Path.Combine("Javascript", "easyxdm.swf"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "easyxdm.swf"), true);
                File.Copy(Path.Combine("Javascript", "easyXDM.Widgets.min.js"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "easyXDM.Widgets.min.js"), true);
                File.Copy(Path.Combine("Javascript", "jquery.soap.js"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "jquery.soap.js"), true);
                File.Copy(Path.Combine("Javascript", "json2.js"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "json2.js"), true);
                File.Copy(Path.Combine("Javascript", "name.html"), Path.Combine(pathResolver.GetReportingServicePath(), "Javascript", "name.html"), true);


            }
            else throw new FileNotFoundException("Unable to find custom binaries to copy.");
        }

        private static void ModifyReportingServicesPortalConfig(string validationKey, string machineKey)
        {
            var xmlDocument = GetXmlDocument(pathResolver.GetReportWebAppPath("Microsoft.ReportingServices.Portal.WebHost.exe.config"));

            var machineKeyEntryNode = xmlDocument.CreateDocumentFragment();
            machineKeyEntryNode.InnerXml = "<system.web><machineKey validationKey=\"" + validationKey + "\" decryptionKey=\"" + machineKey + "\" validation=\"AES\" decryption=\"AES\" /></system.web>";

            xmlDocument.SelectSingleNode("//configuration").AppendChild(machineKeyEntryNode);

            SaveXmlDocument(pathResolver.GetReportWebAppPath("Microsoft.ReportingServices.Portal.WebHost.exe.config"), xmlDocument);
        }

        private static void ModifyReportServerWebConfig(string validationKey, string machineKey)
        {
            var xmlDocument = GetXmlDocument(pathResolver.GetReportingServicePath("web.config"));

            var authNode = xmlDocument.SelectSingleNode("//configuration/system.web/authentication");
            authNode.Attributes["mode"].Value = "Forms";
            var fragement = xmlDocument.CreateDocumentFragment();
            fragement.InnerXml = "<forms loginUrl=\"Logon.aspx\" name=\"sqlAuthCookie\" timeout=\"60\" path=\"/\"></forms>";
            authNode.AppendChild(fragement);

            var authorizeNode = xmlDocument.CreateDocumentFragment();
            authorizeNode.InnerXml = "<authorization><deny users=\"?\"/></authorization>";
            xmlDocument.SelectSingleNode("//configuration/system.web").InsertAfter(authorizeNode, authNode);

            var identityNode = xmlDocument.SelectSingleNode("//configuration/system.web/identity");
            identityNode.Attributes["impersonate"].Value = "false";

            var machineKeyEntryNode = xmlDocument.CreateDocumentFragment();
            machineKeyEntryNode.InnerXml = "<machineKey validationKey=\"" + validationKey + "\" decryptionKey=\"" + machineKey + "\" validation=\"AES\" decryption=\"AES\" />";

            xmlDocument.SelectSingleNode("//configuration/system.web").AppendChild(machineKeyEntryNode);

            var configNode = xmlDocument.SelectSingleNode("//configuration");

            var asmxFragment = xmlDocument.CreateDocumentFragment();
            asmxFragment.InnerXml = @"<location path=""ReportService2010.asmx""><system.web><authorization><allow users=""*""/></authorization></system.web></location>";
            configNode.AppendChild(asmxFragment);

            var javascriptFragment = xmlDocument.CreateDocumentFragment();
            javascriptFragment.InnerXml = @"<location path=""Javascript""><system.web><authorization><allow users=""*""/></authorization></system.web></location>";
            configNode.AppendChild(javascriptFragment);

            SaveXmlDocument(pathResolver.GetReportingServicePath("web.config"), xmlDocument);
        }

        private static void ModifyReportServerPolicyConfig()
        {
            var binary = Path.Combine(pathResolver.GetReportingServicePath(), "bin", "EPMLive.SSRSCustomAuthentication.dll");
            var xmlDocument = GetXmlDocument(pathResolver.GetReportingServicePath("rssrvpolicy.config"));

            var fragment = xmlDocument.CreateDocumentFragment();
            fragment.InnerXml = "<CodeGroup class=\"UnionCodeGroup\" version=\"1\" Name=\"SecurityExtensionCodeGroup\" Description=\"Code group for the sample security extension\" PermissionSetName=\"FullTrust\"><IMembershipCondition class=\"UrlMembershipCondition\" version=\"1\" Url=\"" + binary + "\" /></CodeGroup>";

            var codegenNode = xmlDocument.SelectSingleNode("//CodeGroup/IMembershipCondition[@Url='$CodeGen$/*']");
            codegenNode.ParentNode.ParentNode.InsertAfter(fragment, codegenNode.ParentNode);

            SaveXmlDocument(pathResolver.GetReportingServicePath("rssrvpolicy.config"), xmlDocument);
        }

        private static void SaveXmlDocument(string fileName, XmlDocument xmlDocument)
        {
            var settings = new XmlWriterSettings { Indent = true };
            var writer = XmlWriter.Create(fileName, settings);
            xmlDocument.Save(writer);
        }

        private static XmlDocument GetXmlDocument(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return xmlDocument;
        }

        private static void ModifyReportServerConfig(string adminUsername)
        {
            var xmlDocument = GetXmlDocument(pathResolver.GetReportingServicePath("rsreportserver.config"));

            AddAuthNode(xmlDocument);
            AddExistingUiNode(xmlDocument);
            AddExistingSecurityExtNode(xmlDocument, adminUsername);
            AddExistingAuthExtNode(xmlDocument);
           
            SaveXmlDocument(pathResolver.GetReportingServicePath("rsreportserver.config"), xmlDocument);
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

        private static void AddExistingSecurityExtNode(XmlDocument xmlDocument, string adminusername)
        {
            var existingsecurityExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Security/Extension[@Type='EPMLive.SSRSCustomAuthentication.AuthenticationExtension, EPMLive.SSRSCustomAuthentication']");
            if (existingsecurityExtNode == null)
            {
                var securityExtNode = xmlDocument.SelectSingleNode("/Configuration/Extensions/Security");
                securityExtNode.RemoveAll();
                var fragment = xmlDocument.CreateDocumentFragment();
                fragment.InnerXml = $"<Extension Name=\"Forms\" Type=\"EPMLive.SSRSCustomAuthentication.AuthorizationExtension, EPMLive.SSRSCustomAuthentication\"><Configuration><AdminConfiguration><UserName>{adminusername}</UserName></AdminConfiguration></Configuration></Extension>";
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

       

        private static void CopyFile(string sourceFilename, string destFilename, bool restore)
        {
            if (File.Exists(destFilename) && !restore)
            {
                throw new IOException(destFilename + " already exists, please delete manually and re-run the program.");
            }

            using (var inputFile = new FileStream(
                    sourceFilename,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite))
            {
                using (var outputFile = new FileStream(destFilename, FileMode.Create))
                {
                    var buffer = new byte[0x10000];
                    int bytes;

                    while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytes);
                    }
                }
            }
        }
    }
}