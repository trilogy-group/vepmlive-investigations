using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace EPMLiveCore
{

    public partial class SolutionStoreProxy : LayoutsPageBase
    {
        private string _data;
        private XMLDataManager _dataManager;
        private string _webSvcName;
        private string _webSvcMethod;
        private List<string> _compLevels;
        private string _solutionType;

        private const string WEB_SVC_NAME = "WebSvcName";
        private const string WEB_SVC_METHOD = "WebSvcMethod";

        private void InitializePropAndFlds()
        {
            _data = !string.IsNullOrEmpty(Request.Params["data"]) ? Request.Params["data"] : string.Empty;

            if (!string.IsNullOrEmpty(_data))
            {
                _dataManager = new XMLDataManager(_data);
                _webSvcName = _dataManager.GetPropVal(WEB_SVC_NAME);
                _webSvcMethod = _dataManager.GetPropVal(WEB_SVC_METHOD);
            }

            _compLevels = new List<string>();

            if (!string.IsNullOrEmpty(_dataManager.GetPropVal("CompLevels")))
            {
                string[] levels = _dataManager.GetPropVal("CompLevels").Split(',');
                foreach (string level in levels)
                {
                    if (!string.IsNullOrEmpty(level) &&
                        !_compLevels.Contains(level))
                    {
                        _compLevels.Add(level.Trim());
                    }
                }
            }
            else
            {
                _compLevels.Add("99");
            }

            _solutionType = _dataManager.GetPropVal("SolutionType");
        }

        private void CallWorkEngineDotComSvc()
        {
            switch (_webSvcName)
            {
                case "List":
                    CallWorkEngineListSvc();
                    break;
                case "Copy":
                    CallWorkEngineCopySvc();
                    break;
                case "Custom":

                    break;
                default:
                    break;
            }
        }

        private void CallWorkEngineListSvc()
        {
            switch (_webSvcMethod)
            {
                case "GetListItems":
                    List_GetListItems_InJSON();
                    break;
                case "GetList":
                    List_GetList_InJSON();
                    break;
                case "GetListItemsInXML":
                    List_GetListItems_InXml();
                    break;
                default:
                    break;
            }
        }

        private void CallWorkEngineCopySvc()
        {
            switch (_webSvcMethod)
            {
                case "CopyItem":

                    break;
                default:
                    break;
            }
        }

        #region List web service methods

        private void List_GetListItems_InXml(bool inJSON)
        {
            // link to web service documentation
            // http://msdn.microsoft.com/en-us/library/lists.lists.getlistitems%28v=office.12%29.aspx

            System.Xml.XmlNode data = null;
            string listName = _dataManager.GetPropVal("ListName");
            string viewName = _dataManager.GetPropVal("ViewName");

            XmlDocument xDoc = new XmlDocument();

            // create query param
            XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");
            ndQuery.InnerXml = _dataManager.GetPropVal("Query");

            // create view fields param
            XmlNode ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
            ndViewFields.InnerXml = _dataManager.GetPropVal("ViewFields");

            string rowLimit = _dataManager.GetPropVal("RowLimit");

            // create query options param
            XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            string queryOptions = _dataManager.GetPropVal("QueryOptions");
            queryOptions = !string.IsNullOrEmpty(queryOptions) ? queryOptions.Replace(@"\\", @"\") : string.Empty;
            //ndQueryOptions.InnerXml = !string.IsNullOrEmpty(queryOptions) ? queryOptions : "<queryOptions xmlns:SOAPSDK9=\"http://schemas.microsoft.com/sharepoint/soap/\" ><QueryOptions/></queryOptions>";

            ndQueryOptions.InnerXml = !string.IsNullOrEmpty(queryOptions) ? queryOptions : "<Folder>Solutions/" + CoreFunctions.GetAssemblyVersion() + "</Folder>";
            string webId = _dataManager.GetPropVal("WebID");

            using (var listSvc = new DevStoreSolutionStore.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    ((sender, certificate, chain, sslPolicyErrors) => true);

                    data = listSvc.GetListItems(listName, null, ndQuery, null, rowLimit, ndQueryOptions, null);
                }
                catch (Exception x)
                {
                    Response.Write("{ error : \"" + x.Message + "\" }");
                    return;
                }
            }

            if (!inJSON)
            {
                Response.Write(HttpUtility.HtmlEncode(data.OuterXml));
            }
            else
            {
                Response.Write(HttpUtility.HtmlEncode(JSONUtil.ConvertXmlToJson(SimplifySPGetListItemsXml(data), "")));
            }
        }

        private void List_GetListItems_InXml()
        {
            // link to web service documentation
            // http://msdn.microsoft.com/en-us/library/lists.lists.getlistitems%28v=office.12%29.aspx

            System.Xml.XmlNode data = null;
            string listName = _dataManager.GetPropVal("ListName");
            string viewName = _dataManager.GetPropVal("ViewName");

            XmlDocument xDoc = new XmlDocument();

            // create query param
            XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");
            ndQuery.InnerXml = _dataManager.GetPropVal("Query");

            // create view fields param
            XmlNode ndViewFields = xDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");
            ndViewFields.InnerXml = _dataManager.GetPropVal("ViewFields");

            string rowLimit = _dataManager.GetPropVal("RowLimit");

            // create query options param
            XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            string queryOptions = _dataManager.GetPropVal("QueryOptions");
            queryOptions = !string.IsNullOrEmpty(queryOptions) ? queryOptions.Replace(@"\\", @"\") : string.Empty;
            //ndQueryOptions.InnerXml = !string.IsNullOrEmpty(queryOptions) ? queryOptions : "<queryOptions xmlns:SOAPSDK9=\"http://schemas.microsoft.com/sharepoint/soap/\" ><QueryOptions/></queryOptions>";

            ndQueryOptions.InnerXml = !string.IsNullOrEmpty(queryOptions) ? queryOptions : "<Folder>Solutions/" + CoreFunctions.GetAssemblyVersion() + "</Folder>";
            string webId = _dataManager.GetPropVal("WebID");

            using (var listSvc = new DevStoreSolutionStore.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    ((sender, certificate, chain, sslPolicyErrors) => true);

                    data = listSvc.GetListItems(listName, null, ndQuery, null, rowLimit, ndQueryOptions, null);
                }
                catch (Exception x)
                {
                    Response.Write("{ error : \"" + x.Message + "\" }");
                    return;
                }
            }

            Response.Write(SimplifySPGetListItemsXml(data));
        }

        private void List_GetList_InXml(bool inJSON)
        {
            // link to web service documentation
            // http://msdn.microsoft.com/en-us/library/lists.lists.getlist%28v=office.12%29.aspx

            System.Xml.XmlNode data = null;
            string listName = _dataManager.GetPropVal("ListName");

            using (var listSvc = new DevStoreSolutionStore.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";

                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    ((sender, certificate, chain, sslPolicyErrors) => true);

                    data = listSvc.GetList(listName);
                }
                catch (Exception x)
                {
                    Response.Write("{ error : \"" + x.Message + "\" }");
                    return;
                }
            }

            if (!inJSON)
            {
                Response.Write(HttpUtility.HtmlEncode(data.OuterXml));
            }
            else
            {
                Response.Write(HttpUtility.HtmlEncode(JSONUtil.ConvertXmlToJson(SimplifySPGetListXml(data), "")));
            }
        }

        private void List_GetList_InJSON()
        {
            List_GetList_InXml(true);
        }

        private void List_GetListItems_InJSON()
        {
            List_GetListItems_InXml(true);
        }

        #endregion

        private string SimplifySPGetListItemsXml(XmlNode data)
        {
            StringBuilder result = new StringBuilder();
            SPWeb currentWeb = SPContext.Current.Web;
            XmlWriter writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings());
            writer.WriteStartElement("Templates");
            string rawMetaInfo = string.Empty;

            foreach (XmlNode nd in data.FirstChild.NextSibling.ChildNodes)
            {
                if (nd.NodeType != XmlNodeType.Whitespace)
                {
                    // grab metainfo string and parse needed information
                    rawMetaInfo = nd.Attributes["ows_MetaInfo"].Value;
                    List<string> infos = new List<string>(rawMetaInfo.Split(new string[] { "\r\n" }, StringSplitOptions.None));

                    if (!string.IsNullOrEmpty(_solutionType) && !_solutionType.Equals("SiteCollection", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // This is the value from solution store
                        // "Compatible Site Collection Templates"
                        string rawSiteTemplates = (from s in infos
                                                   where s.StartsWith("SiteTemplates")
                                                   select s).SingleOrDefault();

                        string siteTemplates = !string.IsNullOrEmpty(rawSiteTemplates) ? rawSiteTemplates.Split('|')[1] : string.Empty;

                        if (!string.IsNullOrEmpty(nd.Attributes["ows_SiteTemplates"].Value))
                        {
                            siteTemplates = nd.Attributes["ows_SiteTemplates"].Value;
                        }

                        // if siteTemplates value is blank,
                        // bring back all templates
                        bool isCompatible = true;

                        if (string.IsNullOrEmpty(siteTemplates))
                        {
                            siteTemplates = "99";
                        }

                        isCompatible = false;

                        string[] templateCompLevels = siteTemplates.Split(',');
                        foreach (string level in templateCompLevels)
                        {
                            if (_compLevels.Contains(level.Trim()))
                            {
                                isCompatible = true;
                                break;
                            }
                        }

                        // if not compatible, 
                        // skip this template
                        if (!isCompatible)
                        {
                            continue;
                        }
                    }

                    string rawDescription = (from s in infos
                                             where s.StartsWith("Description")
                                             select s).SingleOrDefault();

                    string description = !string.IsNullOrEmpty(rawDescription) ? rawDescription.Split('|')[1] : string.Empty;

                    string rawTempCategory = (from s in infos
                                              where s.StartsWith("TemplateCategory")
                                              select s).SingleOrDefault();

                    string tempCategory = !string.IsNullOrEmpty(rawTempCategory) ? rawTempCategory.Split('|')[1] : string.Empty;

                    string rawSalesInfo = (from s in infos
                                           where s.StartsWith("SalesInfo")
                                           select s).SingleOrDefault();

                    string salesInfo = !string.IsNullOrEmpty(rawSalesInfo) ? rawSalesInfo.Split('|')[1] : string.Empty;



                    // <Solution Id="<val>" DisplayInStore="<val>">
                    writer.WriteStartElement("Template");
                    writer.WriteAttributeString("Id", nd.Attributes["ows_ID"].Value);
                    writer.WriteAttributeString("Active", nd.Attributes["ows_Visible"].Value);
                    writer.WriteAttributeString("IncludeContent", "false");

                    // <Title><![CDATA[<val>]]></Title>
                    writer.WriteStartElement("Title");
                    string title = nd.Attributes["ows_LinkFilename"] != null ? nd.Attributes["ows_LinkFilename"].Value : string.Empty;
                    writer.WriteCData(title);
                    writer.WriteEndElement();

                    // <Description><![CDATA[<val>]]></Description>
                    writer.WriteStartElement("Description");
                    description = !string.IsNullOrEmpty(description) ? description : string.Empty;
                    writer.WriteCData(description);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Levels");
                    string levels = nd.Attributes["ows_Level"] != null ? nd.Attributes["ows_Level"].Value : string.Empty;
                    writer.WriteCData(levels);
                    writer.WriteEndElement();

                    writer.WriteStartElement("SalesInfo");
                    writer.WriteCData(salesInfo);
                    writer.WriteEndElement();

                    try
                    {
                        string rawTypesVal = string.Empty;
                        rawTypesVal = nd.Attributes["ows_TemplateType"].Value;
                        writer.WriteStartElement("TemplateType");
                        //if (!string.IsNullOrEmpty(rawTypesVal))
                        //{
                        //    SPFieldMultiChoiceValue typeVals = new SPFieldMultiChoiceValue(nd.Attributes["ows_TemplateType"].Value);
                        //    StringBuilder sbTypeVals = new StringBuilder();
                        //    for (int iTypeIndex = 0; iTypeIndex < typeVals.Count; iTypeIndex++)
                        //    {
                        //        sbTypeVals.Append(typeVals[iTypeIndex] + ",");
                        //    }
                        //    string sTypes = sbTypeVals.ToString();
                        //    sTypes = sTypes.Remove(sTypes.LastIndexOf(","));
                        //    writer.WriteCData(sTypes);
                        //}
                        writer.WriteCData(rawTypesVal);
                        writer.WriteEndElement();
                    }
                    catch
                    { }

                    writer.WriteStartElement("TemplateCategory");
                    tempCategory = !string.IsNullOrEmpty(tempCategory) ? tempCategory : string.Empty;
                    writer.WriteCData(tempCategory);
                    writer.WriteEndElement();

                    writer.WriteStartElement("ImageUrl");
                    string imageUrl = nd.Attributes["ows_Icon"] != null ? nd.Attributes["ows_Icon"].Value : string.Empty;
                    imageUrl = !string.IsNullOrEmpty(imageUrl) ? imageUrl.Trim() : (currentWeb.ServerRelativeUrl == "/" ? "" : currentWeb.ServerRelativeUrl) + "/_layouts/EPMLive/images/blanktemplate.png";
                    writer.WriteCData(imageUrl);
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

        private string SimplifySPGetListXml(XmlNode data)
        {
            StringBuilder result = new StringBuilder();
            SPWeb currentWeb = SPContext.Current.Web;
            XmlWriter writer = XmlWriter.Create(result, GetDefaultXMLWriterSettings());
            writer.WriteStartElement("FilterFields");

            var filterFields = from f in data.FirstChild.ChildNodes.Cast<XmlNode>()
                               where f.Attributes["DisplayName"].Value == "Template Type" || f.Attributes["DisplayName"].Value == "Template Category"
                               select f;

            foreach (XmlNode nd in filterFields)
            {
                if (nd.NodeType != XmlNodeType.Whitespace)
                {
                    // <Solution Id="<val>" DisplayInStore="<val>">
                    writer.WriteStartElement("Filter");
                    writer.WriteAttributeString("DisplayName", nd.Attributes["DisplayName"].Value);
                    writer.WriteAttributeString("StaticName", nd.Attributes["StaticName"].Value);

                    writer.WriteStartElement("Choices");
                    StringBuilder choices = new StringBuilder();
                    foreach (XmlNode element in nd.ChildNodes)
                    {
                        if (element.Name.Equals("Choices", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (XmlNode child in element.ChildNodes)
                            {
                                choices.Append(child.InnerText + ";#");
                            }
                            break;
                        }
                    }

                    writer.WriteCData(choices.ToString());
                    writer.WriteEndElement();

                    // </Filter>
                    writer.WriteEndElement();
                }

            }
            // <FilterFields>
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();

            return result.ToString();
        }

        private XmlWriterSettings GetDefaultXMLWriterSettings()
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.Indent = true;
            ws.OmitXmlDeclaration = true;
            ws.NewLineOnAttributes = true;
            return ws;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePropAndFlds();
            CallWorkEngineDotComSvc();
        }
    }

    
}
