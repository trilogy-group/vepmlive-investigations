using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;
using EPMLiveCore;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Web;

namespace EPMLiveCore
{
    public partial class MoreInformation : LayoutsPageBase
    {
        private int _tempId;
        private bool _isOnline;
        private string _solutionType;
        private string _templateType;

        private const string SOL_LIB_TITLE = "Template Gallery";

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageFields();
            LoadPageContentByTempId();
        }

        private void ManageFields()
        {
            if (!string.IsNullOrEmpty(Request.Params["tempId"]))
            {
                _tempId = Convert.ToInt32(Request.Params["tempId"]);
            }

            if (!string.IsNullOrEmpty(Request.Params["isonline"]))
            {
                _isOnline = Convert.ToBoolean(Request.Params["isonline"]);
            }

            if (!string.IsNullOrEmpty(Request.Params["soltype"]))
            {
                _solutionType = Request.Params["soltype"];
            }

            if (!string.IsNullOrEmpty(Request.Params["templatetype"]))
            {
                _templateType = Request.Params["templatetype"];
            }
        }

        private void LoadPageContentByTempId()
        {
            pnlContent.Controls.Clear();

            if (_isOnline)
            {
                PullMoreInfoFromOnline();
            }
            else
            {
                PullMoreInfoFromTempGal();
            }

        }

        private void PullMoreInfoFromTempGal()
        {
            string _templateResourceUrl = string.Empty;
            string _untranslatedGalleryToken = string.Empty;
            Guid lockedWeb = CoreFunctions.getLockedWeb(Web);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite tSite = new SPSite(SPContext.Current.Site.Url))
                {
                    using (SPWeb tWeb = tSite.AllWebs[lockedWeb])
                    {
                        _untranslatedGalleryToken = CoreFunctions.getConfigSetting(tWeb, "EPMLiveTemplateGalleryURL", false, true);
                        switch (_untranslatedGalleryToken)
                        {
                            case "{Site}":
                                _templateResourceUrl = SPContext.Current.Web.ServerRelativeUrl;
                                break;
                            case "{site}":
                                _templateResourceUrl = SPContext.Current.Web.ServerRelativeUrl;
                                break;
                            case "{Root}":
                                _templateResourceUrl = CoreFunctions.getConfigSetting(tWeb, "EPMLiveTemplateGalleryURL", true, true);
                                break;
                            case "{root}":
                                _templateResourceUrl = CoreFunctions.getConfigSetting(tWeb, "EPMLiveTemplateGalleryURL", true, true);
                                break;
                        }
                    }

                    using (SPWeb sourceWeb = tSite.OpenWeb(_templateResourceUrl))
                    {
                        SPList list = sourceWeb.Lists.TryGetList(SOL_LIB_TITLE);
                        SPListItem item = list.GetItemById(_tempId);
                        string moreInfo = item["MoreInfo"] != null ? item["MoreInfo"].ToString() : string.Empty;
                        if (moreInfo != null)
                        {
                            pnlContent.Controls.Add(new LiteralControl(moreInfo));
                        }
                    }
                }
            });
        }

        private void PullMoreInfoFromOnline()
        {
            System.Xml.XmlNode data = null;

            XmlDocument xDoc = new XmlDocument();

            // create query param
            XmlNode ndQuery = xDoc.CreateNode(XmlNodeType.Element, "Query", "");

            if (_solutionType.Equals("sitecollection", StringComparison.CurrentCultureIgnoreCase))
            {
                ndQuery.InnerXml = "<Where><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">SiteCollection</Value></Eq></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>";
            }
            else
            {
                if(_templateType.ToLower() == "template")
                {
                    _templateType = "project";
                }
                //ndQuery.InnerXml = "<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + _solutionType + "</Value></Eq></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>";
                ndQuery.InnerXml = "<Where><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><And><Eq><FieldRef Name=\"SolutionType\" /><Value Type=\"Choice\">" + _solutionType + "</Value></Eq><Eq><FieldRef Name=\"TemplateType\" /><Value Type=\"MultiChoice\">" + _templateType + "</Value></Eq></And></And></Where><OrderBy><FieldRef Name=\"Title\" Ascending=\"True\" /></OrderBy>";
            }

            // create query options param
            XmlNode ndQueryOptions = xDoc.CreateNode(XmlNodeType.Element, "QueryOptions", "");
            //ndQueryOptions.InnerXml = "<queryOptions xmlns:SOAPSDK9=\"http://schemas.microsoft.com/sharepoint/soap/\" ><QueryOptions/></queryOptions>";
            ndQueryOptions.InnerXml = "<Folder>Solutions/" + CoreFunctions.GetAssemblyVersion() + "</Folder>";
            using (WorkEngineSolutionStoreListSvc.Lists listSvc = new WorkEngineSolutionStoreListSvc.Lists())
            {
                // TODO: write a function to get user name and password 
                listSvc.Credentials = new NetworkCredential("Solution1", @"J@(Djkhldk2", "EPM");
                //listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                listSvc.Url = EPMLiveCore.CoreFunctions.getFarmSetting("WorkEngineStore") + "/_vti_bin/Lists.asmx";
                data = listSvc.GetListItems("Solutions", null, ndQuery, null, "10000", ndQueryOptions, null);
            }

            XmlDocument dataXml = new XmlDocument();
            dataXml.LoadXml(data.OuterXml);

            foreach (XmlNode nd in data.FirstChild.NextSibling.ChildNodes)
            {
                if (nd.NodeType.Equals(XmlNodeType.Element) &&
                    nd.Attributes["ows_ID"] != null &&
                    Convert.ToInt32(nd.Attributes["ows_ID"].Value) == _tempId &&
                    nd.Attributes["ows_MetaInfo"] != null &&
                    !string.IsNullOrEmpty(nd.Attributes["ows_MetaInfo"].Value))
                {
                    string[] metaInfos = nd.Attributes["ows_MetaInfo"].Value.Split('\n');
                    foreach (string info in metaInfos)
                    {
                        string header = info.Split('|')[0];
                        if (header == "MoreInfo:SW")
                        {
                            pnlContent.Controls.Add(new LiteralControl(HttpUtility.HtmlDecode(info.Split('|')[1]
                                                                                                        .Replace("\r", "")
                                                                                                        .Replace("\n", "")
                                //.Replace("\"", "\\\"")
                                                                                                        .Replace("\r\n", "")
                                                                                                        .Replace("\\r\\n", "")
                                                                                                        .Replace(@"/MoreInfoImages/", @"https://store.workengine.com/MoreInfoImages/")
                                                                                                        )));
                            break;
                        }
                    }
                    break;
                }
            }

            //IEnumerable<XElement> temps = dataXml.Root.Descendants("
        }
    }
}
