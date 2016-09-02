using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.JsonUtilities;
using Microsoft.SharePoint.Utilities;
using System.Web;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.API
{
    internal class SolLibTemplatesManager
    {
        private const string TEMP_GAL_TITLE = "Template Gallery";
        private const string COL_TITLE = "Title";
        private const string COL_TEMPLATETYPE = "TemplateType";
        private const string COL_TEMPLATECATEGORY = "TemplateCategory";
        private const string COL_DESCRIPTION = "Description";
        private const string COL_MOREINFO = "MoreInfo";
        private const string COL_ACTIVE = "Active";
        private const string COL_URL = "URL";
        private const string COL_INCLUDE_CONTENT = "IncludeContent";
        private const string COL_ATTACHMENT = "Attachments";

        #region Read templates methods

        public static string ReturnAllLocalTemplatesInXML(string data)
        {
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;

            // param "data" should be
            // in XML format like below
            // ========================
            //<Data>
            //<Param key="Type"></Param>
            //</Data>

            StringBuilder result = new StringBuilder();
            XMLDataManager dataMgr = new XMLDataManager(data);
            string type = dataMgr.GetPropVal("Type");
            SPList tmpGalList = cWeb.Lists.TryGetList(TEMP_GAL_TITLE);

            if (tmpGalList != null)
            {
                SPQuery getAllItemsQuery = new SPQuery();
                getAllItemsQuery.Query = type.Equals("All Types", StringComparison.CurrentCultureIgnoreCase) ? BuildSPQueryToGetAll() : BuildSPQueryToGetByType(type);
                SPListItemCollection templates = tmpGalList.GetItems(getAllItemsQuery);
                XmlWriter writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings());

                writer.WriteStartElement("Templates");
                foreach (SPListItem template in templates)
                {
                    // if we are filtering by "type"
                    // skip the ones that doesn't match
                    // but show all types for "template"
                    string tempType = dataMgr.GetPropVal("TemplateType").Trim();

                    if (!string.IsNullOrEmpty(tempType) &&
                        !tempType.Equals("template", StringComparison.CurrentCultureIgnoreCase) &&
                        !tempType.Equals("workspace", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // the templatetype is not matching, skip this template
                        if (template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id] != null &&
                            !template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id].ToString().Equals(tempType, StringComparison.CurrentCultureIgnoreCase))
                        {
                            continue;
                        }
                    }

                    string url = new SPFieldUrlValue(template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id].ToString()).Url;
                    if (!string.IsNullOrEmpty(url) && ChildWebExists(cSite, url))
                    {
                        if (!bool.Parse(dataMgr.GetPropVal("CreateFromLiveTemp")))
                        {
                            string sTempName = string.Empty;
                            SPFieldUrlValue tempUrl = new SPFieldUrlValue(template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id].ToString());
                            string tempTitle = tempUrl.Url.Substring(tempUrl.Url.LastIndexOf("/") + 1);

                            List<SPWebTemplate> tList = (from t in cWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                                         where t.Name.EndsWith(tempTitle, StringComparison.CurrentCultureIgnoreCase)
                                                         select t).ToList<SPWebTemplate>();

                            if (!(tList.Count > 0))
                            {
                                continue;
                            }
                        }

                        // <Solution Id="<val>" DisplayInStore="<val>">
                        writer.WriteStartElement("Template");
                        writer.WriteAttributeString("Id", template.ID.ToString());
                        writer.WriteAttributeString("Active", template[tmpGalList.Fields.GetFieldByInternalName(COL_ACTIVE).Id].ToString());
                        writer.WriteAttributeString("IncludeContent", template[tmpGalList.Fields.GetFieldByInternalName(COL_INCLUDE_CONTENT).Id].ToString());

                        // <Title><![CDATA[<val>]]></Title>
                        writer.WriteStartElement("Title");
                        string title = string.Empty;
                        if (template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id] != null)
                        {
                            SPFieldUrlValue tempUrl = new SPFieldUrlValue(template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id].ToString());
                            title = tempUrl.Description ?? tempUrl.Url;
                        }
                        writer.WriteCData(title);
                        writer.WriteEndElement();

                        // <Description><![CDATA[<val>]]></Description>
                        writer.WriteStartElement("Description");
                        string description = string.Empty;

                        if (FieldExistsInList(tmpGalList, COL_DESCRIPTION) &&
                            template[tmpGalList.Fields.GetFieldByInternalName(COL_DESCRIPTION).Id] != null &&
                            !string.IsNullOrEmpty(template[tmpGalList.Fields.GetFieldByInternalName(COL_DESCRIPTION).Id].ToString()))
                        {
                            description = template[tmpGalList.Fields.GetFieldByInternalName(COL_DESCRIPTION).Id].ToString();
                        }
                        writer.WriteCData(description);
                        writer.WriteEndElement();

                        // <URL><![CDATA[<val>]]></URL>
                        writer.WriteStartElement("URL");
                        writer.WriteCData(template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id] != null ?
                            new SPFieldUrlValue(template[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id].ToString()).Url : string.Empty);
                        writer.WriteEndElement();

                        writer.WriteStartElement("TemplateType");
                        string templateType = string.Empty;

                        if (FieldExistsInList(tmpGalList, COL_TEMPLATETYPE) &&
                            template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id] != null &&
                            !string.IsNullOrEmpty(template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id].ToString()))
                        {
                            templateType = template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATETYPE).Id].ToString();
                        }
                        writer.WriteCData(templateType);
                        writer.WriteEndElement();

                        writer.WriteStartElement("TemplateCategories");
                        string templateCategories = string.Empty;

                        if (FieldExistsInList(tmpGalList, COL_TEMPLATECATEGORY) &&
                            (template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATECATEGORY).Id]) != null)
                        {
                            templateCategories = template[tmpGalList.Fields.GetFieldByInternalName(COL_TEMPLATECATEGORY).Id].ToString();
                        }

                        if (!string.IsNullOrEmpty(templateCategories))
                        {
                            SPFieldMultiChoiceValue types = new SPFieldMultiChoiceValue(templateCategories);
                            for (var x = 0; x < types.Count; x++)
                            {
                                writer.WriteStartElement("TemplateCategory");
                                writer.WriteCData(types[x]);
                                writer.WriteEndElement();
                            }
                        }
                        else
                        {
                            writer.WriteStartElement("TemplateCategory");
                            writer.WriteCData(templateCategories);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("AttachmentUrl");
                        string attachmentUrl = (template.Attachments != null && template.Attachments.Count > 0) ?
                            (template.Attachments.UrlPrefix + template.Attachments[0]).Trim() : (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/EPMLive/images/WESite.png";
                        writer.WriteCData(attachmentUrl);
                        writer.WriteEndElement();

                        // </Template>
                        writer.WriteEndElement();
                    }
                }

                // <Templates>
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }

            return result.ToString();
        }

        public static string ReturnAllSolutionGalleryTemplatesInXML(string data)
        {
            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;

            StringBuilder result = new StringBuilder();
            XMLDataManager dataMgr = new XMLDataManager(data);
            SPList solGallery = (SPDocumentLibrary)cWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);
            XmlWriter writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings());

            writer.WriteStartElement("Templates");
            List<SPWebTemplate> tempCollection = new List<SPWebTemplate>();
            int length = cWeb.GetAvailableWebTemplates(1033).Count;
            foreach (SPWebTemplate template in cWeb.GetAvailableWebTemplates(1033))
            {
                tempCollection.Add(template);
            }

            tempCollection.Sort(CompareSPWebTempByTitle);

            foreach (SPWebTemplate template in tempCollection)
            {
                if (!template.IsHidden)
                {
                    // <Solution Id="<val>" DisplayInStore="<val>">
                    writer.WriteStartElement("Template");
                    writer.WriteAttributeString("Id", template.ID.ToString());
                    writer.WriteAttributeString("Active", "True");
                    writer.WriteAttributeString("IncludeContent", "False");

                    // <Title><![CDATA[<val>]]></Title>
                    writer.WriteStartElement("Title");
                    string title = template.Title != null ? template.Title : string.Empty;
                    writer.WriteCData(title);
                    writer.WriteEndElement();

                    // <Description><![CDATA[<val>]]></Description>
                    writer.WriteStartElement("Description");
                    string description = template.Description != null ? template.Description : string.Empty;
                    writer.WriteCData(description);
                    writer.WriteEndElement();

                    // <URL><![CDATA[<val>]]></URL>
                    writer.WriteStartElement("URL");
                    writer.WriteCData("nan");
                    writer.WriteEndElement();

                    string tType = string.Empty;

                    writer.WriteStartElement("TemplateCategories");
                    string categories = template.DisplayCategory != null ? template.DisplayCategory : string.Empty;
                    if (!string.IsNullOrEmpty(categories))
                    {
                        SPFieldMultiChoiceValue types = new SPFieldMultiChoiceValue(categories);
                        for (var i = 0; i < types.Count; i++)
                        {
                            if (i == 0)
                            {
                                tType = types[i];
                            }
                            writer.WriteStartElement("TemplateCategory");
                            writer.WriteCData(types[i]);
                            writer.WriteEndElement();
                        }
                    }
                    else
                    {
                        writer.WriteStartElement("TemplateCategory");
                        writer.WriteCData(categories);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("TemplateType");
                    writer.WriteCData(tType);
                    writer.WriteEndElement();

                    writer.WriteStartElement("TemplateInternalName");
                    string templateInternalName = template.Name != null ? template.Name : string.Empty;
                    writer.WriteCData(templateInternalName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("AttachmentUrl");
                    string attachmentUrl = template.ImageUrl;
                    writer.WriteCData(attachmentUrl);
                    writer.WriteEndElement();

                    // </Template>
                    writer.WriteEndElement();
                }
            }

            // <Templates>
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();

            return result.ToString();
        }

        public static string ReturnAllLocalTemplatesInJSON(string data)
        {
            return JSONUtil.ConvertXmlToJson(ReturnAllLocalTemplatesInXML(data), "");
        }

        public static string ReturnAllSolutionGalleryTemplatesInJSON(string data)
        {
            return JSONUtil.ConvertXmlToJson(ReturnAllSolutionGalleryTemplatesInXML(data), "");
        }

        #endregion

        /// <summary>
        /// Create workspace(s) 
        /// </summary>
        /// <returns></returns>
        #region Create New Workspace Methods

        public static string CreateWorkspace(string data)
        {
            // param "data" should be
            // in XML format like below
            // ===========================
            //<Data>
            //<Param key="IsNew"></Param>
            //<Param key="IsTemplate"></Param>
            //<Param key="CreateNewFrom"></Param>
            //<Param key="SiteTitle"></Param>
            //<Param key="SiteURL"></Param>
            //<Param key="TemplateId"></Param>
            //<Param key="UniquePermission"></Param>
            //<Param key="inherittoplink"></Param>
            //<Param key="ParentWebUrl"></Param>
            //<Param key="ListGuid"></Param>
            //</Data>

            SPSite cSite = SPContext.Current.Site;
            SPWeb cWeb = SPContext.Current.Web;
            string xml = string.Empty;

            XMLDataManager dataMgr = new XMLDataManager(data);
            if (UserCanCreateSubSite(cSite, dataMgr.GetPropVal("ParentWebUrl")))
            {
                string sRetWebId = string.Empty;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite eSite = new SPSite(cWeb.Url))
                    {
                        using (SPWeb eWeb = eSite.OpenWeb())
                        {
                            sRetWebId = ExecuteCreateWorkspaceProcedures(dataMgr, cSite, cWeb, eSite, eWeb);
                            xml = BuildWebInfoXml(sRetWebId, dataMgr, cSite, cWeb, eSite, eWeb);
                        }
                    }
                });

                return xml;
            }
            else
            {
                throw new Exception("You don't have permission to create subsites on selected workspace, please select a different parent site.");
            }
        }

        private static string BuildWebInfoXml(string sRetWebId, XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            string listName = dataMgr.GetPropVal("RListName");
            if (string.IsNullOrEmpty(dataMgr.GetPropVal("RListName")))
            {
                listName = dataMgr.GetPropVal("ListName");
            }
            string itemID = string.Empty;
            string webID = string.Empty;
            StringBuilder resultWebXML = new StringBuilder();

            if (sRetWebId.IndexOf(',') != -1)
            {
                webID = sRetWebId.Split(',')[0];
                itemID = sRetWebId.Split(',')[1];
            }
            else
            {
                webID = sRetWebId;
            }

            SPWeb tWeb = cSite.OpenWeb(new Guid(webID));
            SPList newWebList = tWeb.Lists.TryGetList(listName);
            string projectEditFormUrl = string.Empty;

            if (newWebList != null)
            {
                if (bool.Parse(dataMgr.GetPropVal("IsNew")))
                {
                    projectEditFormUrl = newWebList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + newWebList.Items[0].ID;
                }
                else
                {
                    projectEditFormUrl = newWebList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + itemID;
                }
            }
            else
            {
                projectEditFormUrl = tWeb.ServerRelativeUrl;
            }

            string templateEditFormUrl = string.Empty;

            if (bool.Parse(dataMgr.GetPropVal("IsTemplate")))
            {
                SPList tempList = cWeb.Lists.TryGetList("Template Gallery");
                int itemId = int.Parse(dataMgr.GetPropVal("NewTempItemID"));
                SPListItem newItem = null;
                try
                {
                    newItem = tempList.GetItemById(itemId);
                }
                catch { }

                if ((tempList != null) && (newItem != null))
                {
                    templateEditFormUrl = tempList.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl + "?ID=" + itemId;
                }
                else
                {
                    templateEditFormUrl = tWeb.ServerRelativeUrl;
                }
            }

            resultWebXML.Append("<WebInfo>");
            resultWebXML.Append("<ID><![CDATA[" + tWeb.ID.ToString("B") + "]]></ID>");
            resultWebXML.Append("<ServerRelativeUrl>" + tWeb.ServerRelativeUrl + "</ServerRelativeUrl>");
            resultWebXML.Append("<ProjectEditFormUrl>" + projectEditFormUrl + "</ProjectEditFormUrl>");

            if (bool.Parse(dataMgr.GetPropVal("IsTemplate")))
            {
                resultWebXML.Append("<TemplateEditFormUrl>" + templateEditFormUrl + "</TemplateEditFormUrl>");
            }

            resultWebXML.Append("</WebInfo>");
            tWeb.Dispose();

            return resultWebXML.ToString();
        }

        private static string ExecuteCreateWorkspaceProcedures(XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            //string resultUrl = string.Empty;
            string sResultWebId = string.Empty;

            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;

            cSite.AllowUnsafeUpdates = true;
            cSite.RootWeb.AllowUnsafeUpdates = true;
            cWeb.AllowUnsafeUpdates = true;

            SPList templatesList = cWeb.Lists.TryGetList(TEMP_GAL_TITLE);
            List<string> tempSolutionNames = new List<string>();

            bool isNew = bool.Parse(dataMgr.GetPropVal("IsNew"));
            string createFrmToken = dataMgr.GetPropVal("CreateNewFrom").ToLower();

            switch (isNew)
            {
                case true:
                    try
                    {
                        string siteUrl = dataMgr.GetPropVal("SiteUrl");

                        if (!string.IsNullOrEmpty(siteUrl) && ChildWebExists(cSite, siteUrl))
                        {
                            throw new Exception("Site with url: " + siteUrl + " already exists!");
                        }

                        switch (createFrmToken)
                        {
                            case "onlinetemps":
                                sResultWebId = CreateNewWorkspaceFromOnlineTemps(tempSolutionNames, dataMgr, cSite, cWeb, cESite, cEWeb);
                                break;
                            case "installedtemps":
                                if (templatesList != null)
                                {
                                    SPListItem template = templatesList.GetItemById(Convert.ToInt32(dataMgr.GetPropVal("TemplateId")));
                                    sResultWebId = CreateNewWorkspaceFromInstalledTemps(tempSolutionNames, template, dataMgr, cSite, cWeb, cESite, cEWeb);
                                }
                                break;
                            case "existingworkspace":
                                sResultWebId = CreateNewWorkspaceFromExistingWorkspace(tempSolutionNames, dataMgr, cSite, cWeb, cESite, cEWeb);
                                break;
                            case "solutiongal":
                                sResultWebId = CreateNewWorkspaceFromSolutionGallery(dataMgr, cSite, cWeb, cESite, cEWeb);
                                break;
                            case "specifiedtemp":
                                // todo: create new workspace with specified temp name from web service call
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        if (createFrmToken != "solutiongal" &&
                            tempSolutionNames.Count > 0)
                        {
                            RemoveSolutionFromGallery(tempSolutionNames, cSite, cWeb, cESite, cEWeb);
                        }
                    }

                    //if (!string.IsNullOrEmpty(sResultWebId))
                    //{
                    //    RegisterAssignToEvent(new Guid(sResultWebId), cSite);
                    //}

                    break;

                case false:
                    sResultWebId = CreateProjectInExistingWorkspace(dataMgr, cSite, cWeb, cESite, cEWeb);
                    break;
            }

            return sResultWebId;
        }

        private static List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className, List<SPEventReceiverType> types)
        {
            List<SPEventReceiverDefinition> evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch
            {

            }

            return evts;
        }

        private static bool EnsureWebInitFeature(string sWebId, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            bool success = true;

            if (sWebId != null)
            {
                try
                {
                    bool workEngineListEventsFeatEnabled = false;

                    if (sWebId.Equals(cWeb.ID))
                    {
                        foreach (SPFeature feat in cWeb.Features)
                        {
                            if (feat.DefinitionId.Equals(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61")))
                            {
                                workEngineListEventsFeatEnabled = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        using (SPWeb w = cSite.OpenWeb(new Guid(sWebId)))
                        {
                            foreach (SPFeature feat in w.Features)
                            {
                                if (feat.DefinitionId.Equals(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61")))
                                {
                                    workEngineListEventsFeatEnabled = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!workEngineListEventsFeatEnabled)
                    {
                        using (SPWeb tempWeb = cESite.OpenWeb(new Guid(sWebId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Add(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Update();
                        }
                    }
                    else
                    {
                        using (SPWeb tempWeb = cESite.OpenWeb(new Guid(sWebId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Remove(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Features.Add(new Guid("f78dc45f-b6bb-4d59-8f45-c73bbcd28a61"));
                            tempWeb.Update();
                        }
                    }
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }

        private static string CreateNewWorkspaceFromOnlineTemps(List<string> tempSolNames, XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            //string rootFilePath = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/Solutions/" + dataMgr.GetPropVal("SolutionName");
            string rootFilePath = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "Solutions/" + CoreFunctions.GetAssemblyVersion() + "/" + dataMgr.GetPropVal("SolutionName");
            string sXML = string.Empty;
            // read feature.xml with WebClient class
            using (WebClient webClient = new WebClient())
            {
                webClient.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                byte[] fileBytes = null;
                fileBytes = webClient.DownloadData(rootFilePath + "/Feature.xml");
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                sXML = enc.GetString(fileBytes);
                fileBytes = null;
            }

            string tempName = string.Empty;

            InstallOnlineSolutionByFeatureXml(tempSolNames, sXML, rootFilePath, out tempName, cSite, cWeb, cESite, cEWeb);

            string originalSolName = tempName.Replace(".wsp", "");
            string SolNameWOSpace = originalSolName.Replace(" ", "");
            string sTempName = (from t in cEWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                where t.Name.EndsWith(originalSolName, StringComparison.CurrentCultureIgnoreCase) ||
                                      t.Name.EndsWith(SolNameWOSpace, StringComparison.CurrentCultureIgnoreCase)
                                select t).ToList<SPWebTemplate>()[0].Name;

            dataMgr.EditProp("TemplateName", sTempName);

            if (string.IsNullOrEmpty(dataMgr.GetPropVal("TemplateName")))
            {
                throw new ArgumentOutOfRangeException("Could not find template during workspace creation, please make sure template name matches .wsp file name. e.g., If temp Name = AppManagement, .wsp file name should = AppManagement.wsp");
            }

            return CreateNewWorkspace(dataMgr, cSite, cWeb, cESite, cEWeb);
        }

        private static void InstallOnlineSolutionByFeatureXml(List<string> tempSolNames, string xmlString, string rootFilePath, out string tempName, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            tempName = string.Empty;
            bool tempNameAssigned = false;

            XDocument featureXml = XDocument.Parse(xmlString);
            IEnumerable<XElement> files = featureXml.Root.Descendants("File");

            foreach (XElement file in files)
            {
                if (!tempNameAssigned)
                {
                    tempName = file.Attribute("Name").Value;
                    tempNameAssigned = true;
                }

                InstallFileByFileNode(tempSolNames, file, rootFilePath, cSite, cWeb, cESite, cEWeb);
            }
        }

        private static void InstallFileByFileNode(List<string> tempSolNames, XElement file, string rootFilePath, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;

            string tempSolGuid = Guid.NewGuid().ToString("N");
            byte[] fileBytes;
            SPList solGallery = null;

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");

                switch (file.Attribute("Type").Value)
                {
                    case "Solution":
                        fileBytes = client.DownloadData(rootFilePath + "/" + file.Attribute("Name").Value);
                        string fileDestination = (cWeb.Site.ServerRelativeUrl == "/" ? "" : cWeb.Site.ServerRelativeUrl) + "/_catalogs/solutions/" + tempSolGuid + ".wsp";
                        SPFile newSolutionfile = null;

                        cESite.CatchAccessDeniedException = false;
                        cESite.AllowUnsafeUpdates = true;
                        cESite.RootWeb.AllowUnsafeUpdates = true;
                        cEWeb.AllowUnsafeUpdates = true;
                        cEWeb.Update();

                        solGallery = (SPDocumentLibrary)cESite.GetCatalog(SPListTemplateType.SolutionCatalog);
                        newSolutionfile = solGallery.RootFolder.Files.Add(fileDestination, fileBytes);
                        SPUserSolution solution = cEWeb.Site.Solutions.Add(newSolutionfile.Item.ID);
                        EnsureSiteCollectionFeaturesActivated(solution, cESite);
                        cEWeb.Update();
                        tempSolNames.Add(tempSolGuid);
                        fileBytes = null;
                        break;
                    case "List":
                        break;
                    default:
                        break;
                }
            }

        }

        private static string CreateNewWorkspaceFromInstalledTemps(List<string> tempSolNames, SPListItem tempGalItem, XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;

            SPList tmpGalList = cWeb.Lists.TryGetList(TEMP_GAL_TITLE);
            dataMgr.EditProp("IncludeContent", tempGalItem[tmpGalList.Fields.GetFieldByInternalName(COL_INCLUDE_CONTENT).Id].ToString());

            string targetWebUrl = new SPFieldUrlValue(tempGalItem[tmpGalList.Fields.GetFieldByInternalName(COL_URL).Id].ToString()).Url;
            string relativeWebUrl = GetSiteRelativeWebUrl(targetWebUrl, cSite);
            string tempSolGuid = Guid.NewGuid().ToString("N");
            string sTempName = string.Empty;

            if (bool.Parse(dataMgr.GetPropVal("CreateFromLiveTemp")))
            {
                using (SPWeb web = cESite.OpenWeb(relativeWebUrl))
                {
                    cESite.CatchAccessDeniedException = false;
                    cESite.AllowUnsafeUpdates = true;
                    cESite.RootWeb.AllowUnsafeUpdates = true;
                    web.AllowUnsafeUpdates = true;

                    web.SaveAsTemplate(tempSolGuid, tempSolGuid, "", bool.Parse(dataMgr.GetPropVal("IncludeContent")));
                    tempSolNames.Add(tempSolGuid);

                    List<SPWebTemplate> tempL = (from t in cEWeb.Site.RootWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                                 where t.Name.Split('#')[1] == tempSolGuid
                                                 select t).ToList<SPWebTemplate>();

                    if (tempL.Count > 0)
                    {
                        sTempName = tempL[0].Name;
                    }
                }
            }
            else
            {

                List<SPWebTemplate> tempList = (from t in cEWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                                where t.Name.EndsWith(relativeWebUrl, StringComparison.CurrentCultureIgnoreCase)
                                                select t).ToList<SPWebTemplate>();

                if (tempList.Count > 0)
                {
                    sTempName = tempList[0].Name;
                }
            }

            dataMgr.EditProp("TemplateName", sTempName);

            return CreateNewWorkspace(dataMgr, cSite, cWeb, cESite, cEWeb);
        }

        private static string CreateNewWorkspaceFromSolutionGallery(XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            dataMgr.EditProp("TemplateName", dataMgr.GetPropVal("TemplateInternalName"));
            dataMgr.EditProp("ParentWebUrl", cWeb.ServerRelativeUrl);
            return CreateNewWorkspace(dataMgr, cSite, cWeb, cESite, cEWeb);
        }

        private static string CreateNewWorkspaceFromExistingWorkspace(List<string> tempSolNames, XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            string targetWebUrl = dataMgr.GetPropVal("TargetWebUrl");
            string tempSolGuid = Guid.NewGuid().ToString("N");

            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;
            string sTempName = string.Empty;

            using (SPWeb tempWeb = cESite.OpenWeb(targetWebUrl))
            {
                cESite.CatchAccessDeniedException = false;
                cESite.AllowUnsafeUpdates = true;
                cESite.RootWeb.AllowUnsafeUpdates = true;
                tempWeb.AllowUnsafeUpdates = true;

                tempWeb.SaveAsTemplate(tempSolGuid, tempSolGuid, "", bool.Parse(dataMgr.GetPropVal("IncludeContent")));
                tempSolNames.Add(tempSolGuid);

                List<SPWebTemplate> tempL = (from t in tempWeb.Site.RootWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                                             where t.Name.Split('#')[1] == tempSolGuid
                                             select t).ToList<SPWebTemplate>();

                if (tempL.Count > 0)
                {
                    sTempName = tempL[0].Name;
                }

                dataMgr.EditProp("TemplateName", sTempName);
            }


            return CreateNewWorkspace(dataMgr, cSite, cWeb, cESite, cEWeb);
        }

        private static string CreateProjectInExistingWorkspace(XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            string resultUrl = string.Empty;
            string sResultWebId;
            string itemID = string.Empty;

            SPWeb parentWeb;

            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;

            if (dataMgr.GetPropVal("ParentWebUrl").Equals(cWeb.ServerRelativeUrl, StringComparison.CurrentCultureIgnoreCase))
            {
                parentWeb = cWeb;
            }
            else
            {
                parentWeb = cSite.OpenWeb(dataMgr.GetPropVal("ParentWebUrl"));
                parentWeb.AllowUnsafeUpdates = true;
            }
            sResultWebId = parentWeb.ID.ToString();
            string listName = dataMgr.GetPropVal("RListName");
            if (string.IsNullOrEmpty(dataMgr.GetPropVal("RListName")))
            {
                listName = dataMgr.GetPropVal("ListName");
            }
            parentWeb.AllowUnsafeUpdates = true;
            SPList list = null;
            try
            {
                if (!string.IsNullOrEmpty(listName))
                {
                    list = parentWeb.Lists[listName];
                }
            }
            catch { }

            if (list != null)
            {
                SPListItem li = list.Items.Add();
                string title = dataMgr.GetPropVal("SiteTitle");
                string doNotDelRequest = dataMgr.GetPropVal("DoNotDelRequest");

                li["Title"] = title;
                li.Update();
                itemID = li.ID.ToString();


                // copyfrom contains the id of the old list item index
                // to copy data from
                if (!string.IsNullOrEmpty(dataMgr.GetPropVal("CopyFrom")))
                {
                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                    {
                        if (!FieldExistsInList(list, "ParentItem"))
                        {
                            cEWeb.AllowUnsafeUpdates = true;
                            SPList l = cEWeb.Lists[list.ID];
                            string pItemIntName = l.Fields.Add("ParentItem", SPFieldType.Text, false);
                            SPFieldText fText = l.Fields.GetFieldByInternalName(pItemIntName) as SPFieldText;
                            fText.Hidden = true;
                            fText.Update();
                            cEWeb.Update();
                        }
                    }

                    SPList tempL = parentWeb.Lists.GetList(list.ID, true);
                    SPListItem tempItem = tempL.GetItemById(li.ID);

                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                    {
                        tempItem["ParentItem"] = dataMgr.GetPropVal("SourceWebId") + "." + dataMgr.GetPropVal("ListGuid") + "." + dataMgr.GetPropVal("CopyFrom");
                        tempItem.Update();
                    }

                    int oldItemIndex = Convert.ToInt32(dataMgr.GetPropVal("CopyFrom"));
                    SPListItem newLi = li;
                    SPListItem oldLi = null;

                    SyncOldItemWithNewItem(cSite,
                                           dataMgr.GetPropVal("SourceWebUrl"),
                                           parentWeb,
                                           new Guid(dataMgr.GetPropVal("ListGuid")),
                                           oldLi,
                                           newLi,
                                           dataMgr.GetPropVal("CopyFrom"),
                                           list,
                                           doNotDelRequest);
                }
            }
            else
            {
                throw new ArgumentException("List " + listName + " does not exist at the lower level.");
            }

            if (parentWeb != null &&
                !parentWeb.ID.Equals(cWeb.ID))
            {
                parentWeb.Dispose();
            }

            return sResultWebId + ',' + itemID;
        }

        private static string CreateNewWorkspace(XMLDataManager dataMgr, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            string sResultWebId = string.Empty;
            string sResultWebUrl = string.Empty;
            cSite.CatchAccessDeniedException = false;
            cWeb.Site.CatchAccessDeniedException = false;
            SPWeb parentWeb;

            cWeb.Site.AllowUnsafeUpdates = true;
            cWeb.Site.RootWeb.AllowUnsafeUpdates = true;
            cWeb.AllowUnsafeUpdates = true;

            if (dataMgr.GetPropVal("ParentWebUrl").Equals(cWeb.ServerRelativeUrl, StringComparison.CurrentCultureIgnoreCase))
            {
                parentWeb = cWeb;
            }
            else
            {
                parentWeb = cSite.OpenWeb(dataMgr.GetPropVal("ParentWebUrl"));
            }

            string listName = dataMgr.GetPropVal("RListName");
            if (string.IsNullOrEmpty(dataMgr.GetPropVal("RListName")))
            {
                listName = dataMgr.GetPropVal("ListName");
            }

            string reqListName = dataMgr.GetPropVal("ReqListName");
            string doNotDelRequest = dataMgr.GetPropVal("DoNotDelRequest");

            string siteTitle = dataMgr.GetPropVal("SiteTitle");
            string siteUrl = dataMgr.GetPropVal("SiteUrl");
            string templateName = dataMgr.GetPropVal("TemplateName");
            string siteOwnerName = cWeb.CurrentUser.LoginName;
            bool uniquePermission = bool.Parse(dataMgr.GetPropVal("UniquePermission"));
            bool inheritTopLink = bool.Parse(dataMgr.GetPropVal("InheritTopLink"));

            Guid createdWebId = Guid.Empty;
            string sCreatedWebUrl;
            string sCreatedWebRelativeUrl;
            string sCreatedWebTitle;

            string err = string.Empty;

            if (parentWeb.DoesUserHavePermissions(cWeb.CurrentUser.LoginName, SPBasePermissions.ManageSubwebs))
            {
                if (dataMgr.GetPropVal("ParentWebUrl").Equals(cWeb.ServerRelativeUrl, StringComparison.CurrentCultureIgnoreCase))
                {
                    cESite.AllowUnsafeUpdates = true;
                    cESite.RootWeb.AllowUnsafeUpdates = true;
                    cEWeb.AllowUnsafeUpdates = true;
                    cEWeb.Update();

                    err = CoreFunctions.createSite(siteTitle, "", siteUrl, templateName, siteOwnerName, uniquePermission, inheritTopLink, cEWeb,
                        out createdWebId, out sCreatedWebUrl, out sCreatedWebRelativeUrl, out sCreatedWebTitle);
                }
                else
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite tSite = new SPSite(parentWeb.Url))
                        {
                            using (SPWeb tWeb = tSite.OpenWeb())
                            {
                                tWeb.AllowUnsafeUpdates = true;
                                tSite.AllowUnsafeUpdates = true;
                                tSite.RootWeb.AllowUnsafeUpdates = true;
                                tWeb.Update();

                                err = CoreFunctions.createSite(siteTitle, "", siteUrl, templateName, siteOwnerName, uniquePermission, inheritTopLink, tWeb,
                                        out createdWebId, out sCreatedWebUrl, out sCreatedWebRelativeUrl, out sCreatedWebTitle);
                            }
                        }
                    });
                }
            }
            else
            {
                throw new Exception("You do have have permission to create subsite on the parent web selected.");
            }

            SPList curList = null;
            if (!string.IsNullOrEmpty(listName))
            {
                try
                {
                    curList = parentWeb.Lists[listName];
                }
                catch { }
            }

            // try to recreate if error says we need to activate features
            if (err.Substring(0, 1) == "1")
            {
                if (err.StartsWith("The site template requires that the Feature") && err.EndsWith("be activated in the site collection."))
                {
                    int trys = 0;
                    while (err.StartsWith("The site template requires that the Feature") && err.EndsWith("be activated in the site collection.") && (trys < 5))
                    {
                        Guid neededFeatureId = new Guid(err.Substring(err.IndexOf("{") + 1).Split('}')[0]);
                        cSite.Features.Add(neededFeatureId, true);
                        err = CoreFunctions.createSite(siteTitle, "", siteUrl, templateName, siteOwnerName, uniquePermission, inheritTopLink, parentWeb,
                                out createdWebId, out sCreatedWebUrl, out sCreatedWebRelativeUrl, out sCreatedWebTitle);
                        trys++;
                    }
                }
            }

            if (err.Substring(0, 1) == "0")
            {
                SPListItem li = null;

                if (curList != null)
                {
                    using (SPWeb w = parentWeb.Webs[siteUrl])
                    {
                        sResultWebId = w.ID.ToString();
                        sResultWebUrl = w.Url;

                        string creatorId;
                        if (SPContext.Current.Web.CurrentUser.ID == 1073741823)
                        {
                            creatorId = "1";
                        }
                        else
                        {
                            creatorId = Convert.ToString(SPContext.Current.Web.CurrentUser.ID);
                        }
                        WorkspaceData.SendCompletedSignalsToDB(w.Site.ID, parentWeb, w.ID, w.ServerRelativeUrl, w.Title, creatorId, w.Description);
                        CacheStore.Current.RemoveCategory(new CacheStoreCategory(w).Navigation);
                        WorkspaceData.AddWsPermission(w.Site.ID, createdWebId);

                        EnsureWebInitFeature(sResultWebId, cSite, cWeb, cESite, cEWeb);

                        SPList list = null;
                        list = w.Lists.TryGetList(listName);

                        if (!string.IsNullOrEmpty(reqListName))
                        {
                            list = w.Lists.TryGetList(reqListName);
                        }

                        if (list != null)
                        {
                            SPField f = null;
                            try
                            {
                                f = list.Fields.GetFieldByInternalName("EPMLiveListConfig");
                            }
                            catch { }
                            if (f == null)
                            {
                                if (list.DoesUserHavePermissions(SPBasePermissions.ManageLists))
                                {
                                    try
                                    {
                                        list.ParentWeb.AllowUnsafeUpdates = true;
                                        f = new SPField(list.Fields, "EPMLiveConfigField", "EPMLiveListConfig");
                                        f.Hidden = true;
                                        list.Fields.Add(f);
                                        f.Update();
                                        list.Update();
                                    }
                                    catch { }
                                }
                            }

                            li = null;
                            var i = 1;
                            bool includeContent = Convert.ToBoolean(dataMgr.GetPropVal("IncludeContent"));

                            // if list already has items, copy data into the first item
                            if (list.Items.Count > 0)
                            {
                                foreach (SPListItem l in list.Items)
                                {
                                    li = l;
                                    string oldPName = l["Title"].ToString();
                                    l["Title"] = includeContent ? (i == 1) ? siteTitle : siteTitle + i.ToString() : siteTitle;
                                    l.SystemUpdate();
                                    string newName = l["Title"].ToString();
                                    RenameProjectFileByProjectItem(w, oldPName, newName);
                                    i++;
                                }

                                // copyfrom contains the id of the old list item index to copy data from
                                if (!string.IsNullOrEmpty(dataMgr.GetPropVal("CopyFrom")))
                                {
                                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                                    {
                                        if (!FieldExistsInList(list, "ParentItem"))
                                        {
                                            w.AllowUnsafeUpdates = true;
                                            SPList l = w.Lists[list.ID];
                                            string pItemIntName = l.Fields.Add("ParentItem", SPFieldType.Text, false);
                                            SPFieldText fText = l.Fields.GetFieldByInternalName(pItemIntName) as SPFieldText;
                                            fText.Hidden = true;
                                            fText.Update();
                                            w.Update();
                                        }
                                    }

                                    int oldItemIndex = Convert.ToInt32(dataMgr.GetPropVal("CopyFrom"));
                                    SPList tempL = w.Lists[list.ID];
                                    SPListItem newLi = tempL.Items[0];
                                    SPListItem oldLi = null;

                                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                                    {
                                        newLi["ParentItem"] = dataMgr.GetPropVal("SourceWebId") + "." + dataMgr.GetPropVal("ListGuid") + "." + dataMgr.GetPropVal("CopyFrom");
                                        newLi.Update();
                                    }


                                    SyncOldItemWithNewItem(cSite,
                                                           dataMgr.GetPropVal("SourceWebUrl"),
                                                           w,
                                                           new Guid(dataMgr.GetPropVal("ListGuid")),
                                                           oldLi,
                                                           newLi,
                                                           dataMgr.GetPropVal("CopyFrom"),
                                                           list,
                                                           doNotDelRequest);
                                }
                            }
                            // if the list does not have items, make an item and copy data into that
                            else
                            {
                                SPList nList = w.Lists.GetList(list.ID, true);
                                SPListItem nli = nList.Items.Add();

                                nli["Title"] = includeContent ? (i == 1) ? siteTitle : siteTitle + i++.ToString() : siteTitle;
                                nli.Update();

                                // copyfrom contains the id of the old list item index
                                // to copy data from
                                if (!string.IsNullOrEmpty(dataMgr.GetPropVal("CopyFrom")))
                                {
                                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                                    {
                                        if (!FieldExistsInList(nList, "ParentItem"))
                                        {
                                            w.AllowUnsafeUpdates = true;
                                            SPList l = w.Lists[nList.ID];
                                            string pItemIntName = l.Fields.Add("ParentItem", SPFieldType.Text, false);
                                            SPFieldText fText = l.Fields.GetFieldByInternalName(pItemIntName) as SPFieldText;
                                            fText.Hidden = true;
                                            fText.Update();
                                            w.Update();
                                        }
                                    }

                                    SPList tempL = w.Lists.GetList(list.ID, true);
                                    SPListItem tempItem = tempL.GetItemById(nli.ID);

                                    if (!string.IsNullOrEmpty(doNotDelRequest) && bool.Parse(doNotDelRequest))
                                    {
                                        tempItem["ParentItem"] = dataMgr.GetPropVal("SourceWebId") + "." + dataMgr.GetPropVal("ListGuid") + "." + dataMgr.GetPropVal("CopyFrom");
                                        tempItem.Update();
                                    }

                                    int oldItemIndex = Convert.ToInt32(dataMgr.GetPropVal("CopyFrom"));
                                    SPListItem newLi = nli;
                                    SPListItem oldLi = null;

                                    SyncOldItemWithNewItem(cSite,
                                                           dataMgr.GetPropVal("SourceWebUrl"),
                                                           w,
                                                           new Guid(dataMgr.GetPropVal("ListGuid")),
                                                           oldLi,
                                                           newLi,
                                                           dataMgr.GetPropVal("CopyFrom"),
                                                           list,
                                                           doNotDelRequest);
                                }
                            }
                        }
                        //if the list is empty, it needs to just not create item in list
                        else
                        {
                            //resultUrl = w.ServerRelativeUrl;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException(err);
            }

            if (string.IsNullOrEmpty(sResultWebId))
            {
                using (SPWeb tWeb = parentWeb.Webs[siteUrl])
                {
                    sResultWebId = tWeb.ID.ToString();
                }
            }

            // if we are creating templates, we need to 
            // create new template item and redirect to edit item form
            if (!string.IsNullOrEmpty(dataMgr.GetPropVal("IsTemplate")) &&
                bool.Parse(dataMgr.GetPropVal("IsTemplate")))
            {
                SPList list = cWeb.Lists[cWeb.Lists.TryGetList(TEMP_GAL_TITLE).ID];
                SPListItem newTempLink = list.Items.Add();
                newTempLink[list.Fields.GetFieldByInternalName("Description").Id] = dataMgr.GetPropVal("SiteTitle");
                SPFieldUrlValue urlValue = new SPFieldUrlValue();
                urlValue.Url = sResultWebUrl;

                urlValue.Description = dataMgr.GetPropVal("SiteTitle");
                newTempLink[list.Fields.GetFieldByInternalName("URL").Id] = urlValue;
                //newTempLink[list.Fields.GetFieldByInternalName("IncludeContent").Id] = !string.IsNullOrEmpty(dataMgr.GetPropVal("IncludeContent")) ? Convert.ToBoolean(dataMgr.GetPropVal("IncludeContent")) : false;
                newTempLink[list.Fields.GetFieldByInternalName("IncludeContent").Id] = true;
                newTempLink.Update();

                if (!string.IsNullOrEmpty(dataMgr.GetPropVal("CurrentTypes")) &&
                    FieldExistsInList(list, "TemplateType"))
                {
                    SPFieldChoice fldChoice = list.Fields.GetFieldByInternalName("TemplateType") as SPFieldChoice;
                    string rawVal = dataMgr.GetPropVal("CurrentTypes");
                    string[] types = rawVal.Split(',');

                    foreach (string type in types)
                    {
                        if (!string.IsNullOrEmpty(type.Trim()) &&
                            !fldChoice.Choices.Contains(type.Trim()))
                        {
                            SPList newList = cEWeb.Lists.TryGetList(TEMP_GAL_TITLE);
                            SPFieldChoice fChoice = newList.Fields.GetFieldByInternalName("TemplateType") as SPFieldChoice;
                            fChoice.Choices.Add(type.Trim());
                            fChoice.Update();
                        }
                    }

                    string sChoiceVal = string.Empty;
                    foreach (string type in types)
                    {
                        if (!string.IsNullOrEmpty(type))
                        {
                            sChoiceVal = type;
                        }
                    }

                    newTempLink[list.Fields.GetFieldByInternalName("TemplateType").Id] = sChoiceVal;
                    newTempLink.SystemUpdate();
                }

                newTempLink.Update();
                dataMgr.EditProp("NewTempItemID", newTempLink.ID.ToString());
            }

            if (parentWeb != null &&
                !parentWeb.ID.Equals(cWeb.ID))
            {
                parentWeb.Dispose();
            }

            return sResultWebId;
        }

        #endregion

        #region Helper Methods

        private static bool DeleteRequestItem(string sourceWebUrl, SPList requestList, SPListItem oldItem)
        {
            bool success = false;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite eS = new SPSite(sourceWebUrl))
                {
                    using (SPWeb eW = eS.OpenWeb())
                    {
                        eW.AllowUnsafeUpdates = true;
                        eW.Lists[requestList.ID].GetItemById(oldItem.ID).Delete();
                        eW.Lists[requestList.ID].Update();
                        success = true;
                    }
                }
            });

            return success;
        }

        private static bool EnsureFieldsInRequestItem(string sourceWebUrl, SPList requestList, SPWeb newWeb, SPListItem oldItem, SPListItem newItem)
        {
            bool success = false;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite eS = new SPSite(sourceWebUrl))
                {
                    using (SPWeb eW = eS.OpenWeb())
                    {
                        eW.AllowUnsafeUpdates = true;

                        if (!FieldExistsInList(requestList, "WorkspaceUrl"))
                        {
                            SPList newList = eW.Lists[requestList.ID];
                            string fldWorkspaceUrlIntName = newList.Fields.Add("WorkspaceUrl", SPFieldType.URL, false);
                            SPFieldUrl fldWorkspaceUrl = newList.Fields.GetFieldByInternalName(fldWorkspaceUrlIntName) as SPFieldUrl;
                            fldWorkspaceUrl.Hidden = true;
                            fldWorkspaceUrl.Update();
                        }

                        if (!FieldExistsInList(requestList, "ChildItem"))
                        {
                            SPList newList = eW.Lists[requestList.ID];
                            string fldChildItemIntName = newList.Fields.Add("ChildItem", SPFieldType.Text, false);
                            SPFieldText fldChildItem = newList.Fields.GetFieldByInternalName(fldChildItemIntName) as SPFieldText;
                            fldChildItem.Hidden = true;
                            fldChildItem.Update();
                        }

                        SPFieldUrlValue newVal = new SPFieldUrlValue();
                        newVal.Url = newWeb.ServerRelativeUrl;
                        newVal.Description = newVal.Url.Substring(newVal.Url.LastIndexOf("/") + 1);
                        SPList spList = eW.Lists[requestList.ID];
                        SPListItem item = spList.GetItemById(oldItem.ID);
                        item[spList.Fields.GetFieldByInternalName("WorkspaceUrl").Id] = newVal;
                        item[spList.Fields.GetFieldByInternalName("ChildItem").Id] = newWeb.ID.ToString() + "." + newItem.ParentList.ID.ToString() + "." + newItem.ID.ToString();

                        item.SystemUpdate();
                        success = true;
                    }
                }
            });

            return success;
        }

        private static void SyncOldItemWithNewItem(SPSite cSite, string sourceWebUrl, SPWeb newWeb, Guid originalListId, SPListItem oldItem,
                                                   SPListItem newItem, string originItemId, SPList destinationList, string doNotDelRequest)
        {
            using (SPWeb sourceWeb = cSite.OpenWeb(sourceWebUrl))
            {
                SPList originalRequestList = sourceWeb.Lists[originalListId];

                if (originalRequestList != null)
                {
                    oldItem = originalRequestList.GetItemById(Convert.ToInt32(originItemId));

                    foreach (SPField fld in originalRequestList.Fields)
                    {
                        if (fld.Reorderable)
                        {
                            if (destinationList.Fields.ContainsField(fld.InternalName))
                            {
                                if (fld.InternalName == "ParentItem")
                                {
                                    continue;
                                }

                                try
                                {
                                    if (destinationList.Fields.GetFieldByInternalName(fld.InternalName).Type == fld.Type)
                                    {
                                        try
                                        {
                                            newItem[fld.InternalName] = oldItem[fld.InternalName];
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                    }

                    newItem.Update();

                    if (!string.IsNullOrEmpty(doNotDelRequest) && !bool.Parse(doNotDelRequest))
                    {
                        DeleteRequestItem(sourceWeb.Url, originalRequestList, oldItem);
                    }
                    else
                    {
                        EnsureFieldsInRequestItem(sourceWeb.Url, originalRequestList, newWeb, oldItem, newItem);
                    }
                }
            }
        }

        private static void RenameProjectFileByProjectItem(SPWeb web, string oldName, string newName)
        {
            SPDocumentLibrary projectSchedule = (SPDocumentLibrary)web.Lists.TryGetList("Project Schedules");
            if (projectSchedule != null)
            {
                foreach (SPListItem item in projectSchedule.Items)
                {
                    if (Path.GetFileNameWithoutExtension(item["Name"].ToString()).Equals(oldName))
                    {
                        item.File.CheckOut();
                        item["Name"] = Path.ChangeExtension(newName, "mpp");
                        item.SystemUpdate();
                        item.File.CheckIn("");
                        break;
                    }
                }
            }

        }

        private static List<SPFeatureDefinition> GetFeatureDefinitionsInSolution(SPUserSolution solution, SPSite site)
        {
            List<SPFeatureDefinition> list = new List<SPFeatureDefinition>();

            foreach (SPFeatureDefinition definition in site.FeatureDefinitions)
            {
                if (definition.SolutionId.Equals(solution.SolutionId))
                {
                    list.Add(definition);
                }
            }
            return list;
        }

        private static SPGroup GetSiteGroup(SPWeb web, string name)
        {
            foreach (SPGroup group in web.SiteGroups)
                if (group.Name.ToLower() == name.ToLower())
                    return group;
            return null;
        }

        /// <summary>
        /// Stores all query building logic here. 
        /// </summary>
        /// <param name="function">type of function to return, use "default" to get all templates</param>
        /// <returns></returns>
        private static string BuildSPQueryToGetAll()
        {
            string query = string.Empty;
            // get all templates that should be displayed in store
            // order by Title, ASC
            query = "<Where><Eq><FieldRef Name='Active' /><Value Type='Bool'>True</Value></Eq></Where><OrderBy><FieldRef Name=\"Title0\" Ascending=\"True\" /></OrderBy>";
            return query;

        }

        private static string BuildSPQueryToGetByType(string type)
        {
            string query = string.Empty;
            query = "<Where><And><Eq><FieldRef Name='Active'/><Value Type='Bool'>True</Value></Eq><Eq><FieldRef Name='TemplateType' /><Value Type='Choice'>" + type + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Title0\" Ascending=\"True\" /></OrderBy>";
            return query;
        }

        private static XmlWriterSettings GetDefaultXMLWriterSettings()
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            ws.OmitXmlDeclaration = true;
            ws.NewLineOnAttributes = true;
            return ws;
        }

        private static void EnsureSiteCollectionFeaturesActivated(SPUserSolution solution, SPSite site)
        {
            SPUserSolutionCollection solutions = site.Solutions;
            List<SPFeatureDefinition> oListofFeatures = GetFeatureDefinitionsInSolution(solution, site);
            foreach (SPFeatureDefinition def in oListofFeatures)
            {
                if (((def.Scope == SPFeatureScope.Site) && def.ActivateOnDefault) && (site.Features[def.Id] == null))
                {
                    try
                    {
                        site.Features.Add(def.Id, false, SPFeatureDefinitionScope.Site);
                        //site.Features.Add(def.Id);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private static string GetSiteRelativeWebUrl(string targetWebUrl, SPSite cSite)
        {
            string retVal = targetWebUrl.Replace("default.aspx", "");

            if (retVal.StartsWith("/"))
            {
                retVal = cSite.MakeFullUrl(retVal);
            }

            // http://www.google.com
            // e.g., http://contoso.com/sites/testsite/default.aspx
            if (retVal.Contains(cSite.Url))
            {
                retVal = retVal.Replace(cSite.Url, "");
            }

            // e.g., /sites/testsite/
            if (retVal.EndsWith("/"))
            {
                retVal = retVal.Remove(retVal.LastIndexOf('/'));
            }

            if (retVal.StartsWith("/"))
            {
                retVal = retVal.Remove(retVal.IndexOf('/'), 1);
            }

            return retVal;
        }

        private static int CompareSPWebTempByTitle(SPWebTemplate x, SPWebTemplate y)
        {
            int retVal = -1;
            if (x == null && y == null)
            {
                retVal = 0;
            }
            else if (x != null && y == null)
            {
                retVal = 1;
            }
            else if (x == null & y != null)
            {
                retVal = -1;
            }
            else if (x != null && y != null)
            {
                retVal = x.Title.CompareTo(y.Title);
            }
            return retVal;
        }

        private static bool ChildWebExists(SPSite cSite, string childWebRelUrl)
        {
            bool exists = false;

            childWebRelUrl = GetSiteRelativeWebUrl(childWebRelUrl, cSite);

            try
            {
                using (SPWeb web = cSite.OpenWeb(childWebRelUrl))
                {
                    exists = web.Exists;
                }
            }
            catch { }

            return exists;
        }

        private static bool SolutionFileExists(SPSite cSite, string fileName)
        {
            bool exists = false;
            string sTempName = string.Empty;
            try
            {
                sTempName = (from t in cSite.RootWeb.GetAvailableWebTemplates(1033).OfType<SPWebTemplate>()
                             where t.Name.EndsWith(fileName, StringComparison.CurrentCultureIgnoreCase)
                             select t).ToList<SPWebTemplate>()[0].Name;
            }
            catch { }

            exists = !string.IsNullOrEmpty(sTempName);

            return exists;
        }

        private static bool UserCanCreateSubSite(SPSite cSite, string childWebRelUrl)
        {
            bool hasPerm = false;
            childWebRelUrl = GetSiteRelativeWebUrl(childWebRelUrl, cSite);
            try
            {
                using (SPWeb web = cSite.OpenWeb(childWebRelUrl))
                {
                    hasPerm = web.DoesUserHavePermissions(SPBasePermissions.ManageSubwebs);
                }
            }
            catch { }

            return hasPerm;
        }

        private static bool FieldExistsInList(SPList list, string fieldInternalName)
        {
            SPField testFld = null;

            try
            {
                testFld = list.Fields.GetFieldByInternalName(fieldInternalName);
            }
            catch (ArgumentException x)
            {
            }

            return (testFld != null);
        }

        private static void RemoveSolutionFromGallery(List<string> tempSolutionNames, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb)
        {
            // if we're not creating a temp or workspace from web.availabletemps, then remove the 
            // newly created and acivated templates
            cEWeb.Site.AllowUnsafeUpdates = true;
            cEWeb.Site.RootWeb.AllowUnsafeUpdates = true;
            cEWeb.AllowUnsafeUpdates = true;

            cEWeb.Site.CatchAccessDeniedException = false;

            SPList solGallery = (SPDocumentLibrary)cESite.GetCatalog(SPListTemplateType.SolutionCatalog);

            // deactivate solution(s) in solution gallery
            // =======================================
            List<SPUserSolution> delSols = new List<SPUserSolution>();

            delSols = (from s in cESite.Solutions.OfType<SPUserSolution>()
                       where !string.IsNullOrEmpty(s.Name) && tempSolutionNames.Contains(s.Name.Replace(".wsp", ""))
                       select s).ToList<SPUserSolution>();

            if (delSols.Count > 0)
            {
                foreach (SPUserSolution sol in delSols)
                {
                    cESite.Solutions.Remove(sol);
                }
            }
            // delete solution(s) from solution gallery
            // =====================================
            List<SPListItem> delItems = new List<SPListItem>();

            delItems = (from i in solGallery.Items.OfType<SPListItem>()
                        where tempSolutionNames.Contains(i.File.Name.Replace(".wsp", ""))
                        select i).ToList<SPListItem>();

            if (delItems.Count > 0)
            {
                foreach (SPListItem i in delItems)
                {
                    i.Delete();
                }
            }
        }

        #endregion

    }
}
