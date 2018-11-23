using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Xml;
using Microsoft.SharePoint.WebControls;
using SysTrace = System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class SolutionStoreProxy : LayoutsPageBase
    {
        private string _data;
        private XMLDataManager _dataManager;
        private string _webSvcName;
        private string _webSvcMethod;
        private const string WebSvcName = "WebSvcName";
        private const string WebSvcMethod = "WebSvcMethod";

        private void InitializePropAndFlds()
        {
            _data = !string.IsNullOrWhiteSpace(Request.Params["data"]) ? Request.Params["data"] : string.Empty;

            if (!string.IsNullOrWhiteSpace(_data))
            {
                _dataManager = new XMLDataManager(_data);
                _webSvcName = _dataManager.GetPropVal(WebSvcName);
                _webSvcMethod = _dataManager.GetPropVal(WebSvcMethod);
            }

            XmlDataSimplifier.CompLevels = new List<string>();

            if (!string.IsNullOrWhiteSpace(_dataManager.GetPropVal("CompLevels")))
            {
                string[] levels = _dataManager.GetPropVal("CompLevels").Split(',');
                foreach (string level in levels)
                {
                    if (!string.IsNullOrWhiteSpace(level) &&
                        !XmlDataSimplifier.CompLevels.Contains(level))
                    {
                        XmlDataSimplifier.CompLevels.Add(level.Trim());
                    }
                }
            }
            else
            {
                XmlDataSimplifier.CompLevels.Add("99");
            }

            XmlDataSimplifier.SolutionType = _dataManager.GetPropVal("SolutionType");
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
                    ListGetListItemsInXml(true);
                    break;
                case "GetList":
                    ListGetListInXml(true);
                    break;
                case "GetListItemsInXML":
                    ListGetListItemsInXml();
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

        private void ListGetListItemsInXml(bool inJSON)
        {
            XmlNode data;
            if (!TryGetListItemsInXml(out data))
            {
                return;
            }

            Response.Write(!inJSON
                ? HttpUtility.HtmlEncode(data.OuterXml)
                : HttpUtility.HtmlEncode(JSONUtil.ConvertXmlToJson(XmlDataSimplifier.SimplifySPGetListItemsXml(data), string.Empty)));
        }

        private void ListGetListItemsInXml()
        {
            XmlNode data;
            if (!TryGetListItemsInXml(out data))
            {
                return;
            }

            Response.Write(XmlDataSimplifier.SimplifySPGetListItemsXml(data));
        }

        private bool TryGetListItemsInXml(out XmlNode data)
        {
            // link to web service documentation
            // http://msdn.microsoft.com/en-us/library/lists.lists.getlistitems%28v=office.12%29.aspx

            data = null;
            var listName = _dataManager.GetPropVal("ListName");
            var viewName = _dataManager.GetPropVal("ViewName");

            var xmlDoc = new XmlDocument();

            // create query param
            const string queryNodeName = "Query";
            var nodeQuery = xmlDoc.CreateNode(XmlNodeType.Element, queryNodeName, string.Empty);
            nodeQuery.InnerXml = _dataManager.GetPropVal(queryNodeName);

            // create view fields param
            const string viewFieldsName = "ViewFields";
            var nodeViewFields = xmlDoc.CreateNode(XmlNodeType.Element, viewFieldsName, string.Empty);
            nodeViewFields.InnerXml = _dataManager.GetPropVal(viewFieldsName);

            var rowLimit = _dataManager.GetPropVal("RowLimit");

            // create query options param
            const string queryOptionsName = "QueryOptions";
            var nodeQueryOptions = xmlDoc.CreateNode(XmlNodeType.Element, queryOptionsName, string.Empty);
            var queryOptions = _dataManager.GetPropVal(queryOptionsName);
            queryOptions = !string.IsNullOrWhiteSpace(queryOptions) ? queryOptions.Replace(@"\\", @"\") : string.Empty;
            nodeQueryOptions.InnerXml = !string.IsNullOrWhiteSpace(queryOptions) 
                ? queryOptions 
                : "<Folder>Solutions/" + CoreFunctions.GetAssemblyVersion() + "</Folder>";
            var webId = _dataManager.GetPropVal("WebID");

            using (var listSvc = new WorkEngineSolutionStoreListSvc.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                listSvc.Url = CoreFunctions.getFarmSetting("WorkEngineStore") + "_vti_bin/Lists.asmx";
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                        ((sender, certificate, chain, sslPolicyErrors) => true);

                    data = listSvc.GetListItems(listName, null, nodeQuery, null, rowLimit, nodeQueryOptions, null);
                }
                catch (Exception ex)
                {
                    SysTrace.WriteLine(ex);
                    Response.Write($"{{ error : \"{ex.Message}\" }}");
                    return false;
                }
            }

            return true;
        }

        private void ListGetListInXml(bool inJSON)
        {
            // link to web service documentation
            // http://msdn.microsoft.com/en-us/library/lists.lists.getlist%28v=office.12%29.aspx

            XmlNode data = null;
            var listName = _dataManager.GetPropVal("ListName");

            using (var listSvc = new WorkEngineSolutionStoreListSvc.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                listSvc.Url = CoreFunctions.getFarmSetting("WorkEngineStore") + "_vti_bin/Lists.asmx";

                try
                {
                    ServicePointManager.ServerCertificateValidationCallback =
                        ((sender, certificate, chain, sslPolicyErrors) => true);

                    data = listSvc.GetList(listName);
                }
                catch (Exception ex)
                {
                    SysTrace.WriteLine(ex);
                    Response.Write($"{{ error : \"{ex.Message}\" }}");
                    return;
                }
            }

            Response.Write(!inJSON
                ? HttpUtility.HtmlEncode(data.OuterXml)
                : HttpUtility.HtmlEncode(JSONUtil.ConvertXmlToJson(XmlDataSimplifier.SimplifySPGetListXml(data), string.Empty)));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializePropAndFlds();
            CallWorkEngineDotComSvc();
        }
    }
}
