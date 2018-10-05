using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml;
using EPMLiveCore.ApplicationStore;
using EPMLiveCore.WorkEngineSolutionStoreListSvc;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal partial class ApplicationInstaller
    {
        private XmlNode InstallFiles()
        {
            var parentMessageId = 0;

            if (bVerifyOnly)
            {
                parentMessageId = addMessage(0, "Checking Files", string.Empty, 0);
            }
            else
            {
                parentMessageId = addMessage(0, "Installing Files", string.Empty, 0);
            }

            var docFiles = new XmlDocument();
            docFiles.LoadXml("<Files/>");

            try
            {
                var ndFiles = appDef.ApplicationXml.FirstChild.SelectSingleNode("Files");

                var storeUrl = CoreFunctions.getFarmSetting("workenginestore");

                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

                var copy = new AppStore
                {
                    Credentials = CoreFunctions.GetStoreCreds(),
                    Url = storeUrl + "_vti_bin/appstore.asmx"
                };

                var ndItems = GetItem(storeUrl);

                float max = 0;

                foreach (XmlNode xmloNode in ndItems.ChildNodes)
                {
                    if (xmloNode.Name == "rs:data")
                    {
                        float.TryParse(xmloNode.Attributes["ItemCount"].Value, out max);
                        if (max > 0)
                        {
                            foreach (XmlNode ndChild in xmloNode.ChildNodes)
                            {
                                if (ndChild.Name == "z:row")
                                {
                                    ProcessNode(docFiles, ndFiles, ndChild);
                                }
                            }
                        }
                    }
                }

                InstallFilesProcessFolder(parentMessageId, 0, docFiles.FirstChild, max, copy, false);
            }
            catch (Exception ex)
            {
                addMessage(ErrorLevels.Error, "Installing Files", "Error: " + ex.Message, parentMessageId);
                Trace.WriteLine(ex.ToString());
            }

            return docFiles.FirstChild;
        }

        private void ProcessNode(XmlDocument docFiles, XmlNode ndFiles, XmlNode ndChild)
        {
            var lvFSObjType = new SPFieldLookupValue(ndChild.Attributes["ows_FSObjType"].Value);
            var lvFileRef = new SPFieldLookupValue(ndChild.Attributes["ows_FileRef"].Value);
            var lvFileLeafRef = new SPFieldLookupValue(ndChild.Attributes["ows_FileLeafRef"].Value);

            var title = string.Empty;
            try
            {
                title = ndChild.Attributes["ows_Title"].Value;
            }
            catch (Exception ex)
            {
                title = lvFileLeafRef.LookupValue;
                Trace.WriteLine(ex.ToString());
            }

            var remoteFile = lvFileRef.LookupValue;
            var fullFile = remoteFile.Replace(appDef.appurl + "/Files/", string.Empty);
            var fileName = Path.GetFileName(fullFile);
            var parentFolder = Path.GetDirectoryName(fullFile).Replace("\\", "/");

            if (Path.GetExtension(fileName) == ".txt")
            {
                if (title.Contains("."))
                {
                    fileName = title;
                }
            }

            fullFile = GetFullFile(remoteFile, fileName);

            var ndNew = AddNode(docFiles, ndFiles, lvFSObjType, remoteFile, fullFile, fileName);

            var ndParent = docFiles.FirstChild.SelectSingleNode("//File[@FullFile='" + parentFolder + "']");

            if (ndParent == null)
            {
                docFiles.FirstChild.AppendChild(ndNew);
            }
            else
            {
                ndParent.AppendChild(ndNew);
            }
        }

        private XmlNode GetItem(string storeUrl)
        {
            var listSvc = new Lists
            {
                Url = storeUrl + "_vti_bin/lists.asmx",
                Credentials = CoreFunctions.GetStoreCreds()
            };

            var xDoc = new XmlDocument();

            var ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", string.Empty);
            ndQuery.InnerXml = "<OrderBy><FieldRef Name='FileRef'/></OrderBy>";

            var ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", string.Empty);
            ndQueryOptions.InnerXml = $"<Folder>{appDef.appurl}/Files</Folder><ViewAttributes Scope=\"RecursiveAll\" />";

            var ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", string.Empty);
            ndViewFields.InnerXml = "<FieldRef Name='Title'/>";

            var ndItems = listSvc.GetListItems("Applications", null, ndQuery, ndViewFields, "10000", ndQueryOptions, null);
            return ndItems;
        }

        private static XmlNode AddNode(XmlDocument docFiles, XmlNode ndFiles, SPFieldLookupValue lvFSObjType, string remoteFile, string fullFile, string fileName)
        {
            var bOverwrite = false;

            var ndNew = docFiles.CreateNode(XmlNodeType.Element, "File", docFiles.NamespaceURI);
            XmlAttribute attr;
            AddAttribute(docFiles, fileName, "Name", ndNew);
            AddAttribute(docFiles, remoteFile, "RemoteFile", ndNew);

            try
            {
                bOverwrite = bool.Parse(ndFiles.SelectSingleNode($"File[@Path='{fullFile}']").Attributes["Overwrite"].Value);
                attr = docFiles.CreateAttribute("Overwrite");
                attr.Value = bOverwrite.ToString();
                ndNew.Attributes.Append(attr);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            try
            {
                attr = docFiles.CreateAttribute("NoDelete");
                attr.Value = ndFiles.SelectSingleNode($"File[@Path='{fullFile}']").Attributes["NoDelete"].Value;
                ndNew.Attributes.Append(attr);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            AddAttribute(docFiles, lvFSObjType.LookupValue, "Type", ndNew);
            AddAttribute(docFiles, fullFile, "FullFile", ndNew);
            return ndNew;
        }

        private string GetFullFile(string remoteFile, string fileName)
        {
            var fullFile = Path.GetDirectoryName(remoteFile.Replace(appDef.appurl + "/Files/", string.Empty)) + "/" + fileName;

            return fullFile.Replace("\\", "/").Trim('/'); ;
        }

        private static XmlAttribute AddAttribute(XmlDocument docFiles, string attrValue, string attrName,XmlNode ndNew)
        {
            var attr = docFiles.CreateAttribute(attrName);
            attr.Value = attrValue;
            ndNew.Attributes.Append(attr);
            return attr;
        }
    }
}