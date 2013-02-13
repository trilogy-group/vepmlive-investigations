using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EPMLiveCore;
using EPMLiveWebParts.SSRS2006;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    public partial class getlistreportitems : Page
    {
        private string _displayListNames;
        private string _viewLists;
        private string _reportsRootFolderName;
        private string _reportingServicesUrl;
        private bool _isIntegrated;
        private string _reportsFolderName;
        private ReportingService2006 _srs2006;
        private bool _isSsrs;

        //TODO: This should probably be a handler and not a web form so we dont have the overhead of the page lifecycle.
        protected override void OnLoad(EventArgs e)
        {
            var encryptedData = Request["data"];
            populateFieldsFromEncryptedData(encryptedData);

            Response.ContentType = "text\\xml";
            Response.Write(_isSsrs ? GetXmlForReportItems() : GetXmlForNonReportItems());
        }

        private void populateFieldsFromEncryptedData(string base64EncryptedData)
        {
            var decryptedData = Convert.FromBase64String(base64EncryptedData);
            var parameters = Encoding.ASCII.GetString(decryptedData).Split('\n');
            var parameterHash = new Hashtable();
            foreach (var parameterKeyValue in parameters)
            {
                var parameter = parameterKeyValue.Split('^');

                if (!string.IsNullOrEmpty(parameter[0]))
                {
                    parameterHash.Add(parameter[0], parameter[1]);
                }
            }

            _displayListNames = parameterHash["DisplayListNames"].ToString();
            _viewLists = parameterHash["ViewLists"].ToString();
            _reportsRootFolderName = parameterHash["ReportsRootFolderName"].ToString();
            _reportingServicesUrl = parameterHash["ReportingServicesUrl"].ToString();
            _reportsFolderName = parameterHash["ReportsFolderName"].ToString();
            var isSsrsAsString = parameterHash["IsSSRS"].ToString();
            _isSsrs = !string.IsNullOrEmpty(isSsrsAsString) && bool.Parse(isSsrsAsString); 
            var isIntegratedAsString = parameterHash["Integrated"].ToString();
            _isIntegrated = !string.IsNullOrEmpty(isIntegratedAsString) && bool.Parse(isIntegratedAsString);
        }

        private string GetXmlForReportItems()
        {
            var cSite = SPContext.Current.Site;
            GetListNamesInHashtable(_displayListNames);
            TreeNode reportNode = null;
            GetSSRSReportTree(ref reportNode);

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<rows></rows>");
            var mainNode = xmlDocument.ChildNodes[0];

            var headNode = CreateHeadNode(mainNode, xmlDocument);

            CreateColumnNode(headNode, xmlDocument);

            if (reportNode != null)
            {
                var newListNode = xmlDocument.CreateNode(XmlNodeType.Element, "row", xmlDocument.NamespaceURI);
                var newListNodeCell = xmlDocument.CreateNode(XmlNodeType.Element, "cell", xmlDocument.NamespaceURI);
                newListNodeCell.InnerText = "<img align=\"absmiddle\" src=\"" + cSite.MakeFullUrl("/_layouts/images/itdl.png") + "\" style=\"display:inline;margin:0px 8px 0px 0px;\" />Reporting Services Reports";
                newListNode.AppendChild(newListNodeCell);

                foreach (TreeNode child in reportNode.ChildNodes)
                {
                    AddSSRSReportLinks(child, xmlDocument, newListNode);
                }

                mainNode.AppendChild(newListNode);
            }

           
            return xmlDocument.OuterXml;
        }

        protected string GetXmlForNonReportItems()
        {
            var cSite = SPContext.Current.Site;
            var cWeb = SPContext.Current.Web;
            var oListNames = GetListNamesInHashtable(_displayListNames);
            TreeNode reportNode = null;

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<rows></rows>");
            var mainNode = xmlDocument.ChildNodes[0];

            var headNode = CreateHeadNode(mainNode, xmlDocument);

            CreateColumnNode(headNode, xmlDocument);

            // build out the rows
            if (!string.IsNullOrEmpty(_viewLists))
            {
                var lists = _viewLists.Split('|');
                foreach (var listTitle in lists)
                {
                    if (string.IsNullOrEmpty(listTitle))
                    {
                        continue;
                    }

                    var tempList = cWeb.Lists.TryGetList(listTitle);

                    if (tempList == null || !tempList.DoesUserHavePermissions(SPBasePermissions.ViewListItems))
                        continue;
                    if (tempList.Title == "Report Library")
                        continue;
                    var newListNode = xmlDocument.CreateNode(XmlNodeType.Element, "row", xmlDocument.NamespaceURI);
                    var newListNodeCell = xmlDocument.CreateNode(XmlNodeType.Element, "cell", xmlDocument.NamespaceURI);

                    var sTitle = oListNames.ContainsKey(tempList.Title) ? oListNames[tempList.Title].ToString() : tempList.Title;

                    newListNodeCell.InnerText = "<img align=\"absmiddle\" src=\"" + cSite.MakeFullUrl(tempList.ImageUrl) + "\" style=\"display:inline;margin:0px 8px 0px 0px;\" />" + sTitle;
                    newListNode.AppendChild(newListNodeCell);
                    foreach (SPView spView in tempList.Views)
                    {
                        if (string.IsNullOrEmpty(spView.Title)) continue;
                        if (!ViewShouldBeIncludedInResults(spView)) continue;
                        var ndView = xmlDocument.CreateNode(XmlNodeType.Element, "row", xmlDocument.NamespaceURI);
                        // create <userdata name="ViewTitle"> ... </userdata>
                        var ndUserdata = xmlDocument.CreateNode(XmlNodeType.Element, "userdata", xmlDocument.NamespaceURI);
                        var attrName = xmlDocument.CreateAttribute("name");
                        attrName.Value = "ViewTitle";
                        if (ndUserdata.Attributes != null) ndUserdata.Attributes.Append(attrName);
                        ndUserdata.InnerText = spView.Title;

                        // create <userdata name="ViewRelativeUrl"> ... </userdata>
                        var ndUserdata2 = xmlDocument.CreateNode(XmlNodeType.Element, "userdata", xmlDocument.NamespaceURI);
                        var attrName2 = xmlDocument.CreateAttribute("name");
                        attrName2.Value = "ViewRelativeUrl";
                        if (ndUserdata2.Attributes != null) ndUserdata2.Attributes.Append(attrName2);
                        ndUserdata2.InnerText = spView.ServerRelativeUrl;

                        var ndCell = xmlDocument.CreateNode(XmlNodeType.Element, "cell", xmlDocument.NamespaceURI);
                        ndCell.InnerText = "<img align=\"absmiddle\"  src=\"/_layouts/epmlive/DHTML/xgrid/imgs/iReportsLibrary.png\"/> <a href=\"#\">" + spView.Title + "</a>";

                        ndView.AppendChild(ndUserdata);
                        ndView.AppendChild(ndUserdata2);
                        ndView.AppendChild(ndCell);
                        newListNode.AppendChild(ndView);
                    }

                    mainNode.AppendChild(newListNode);
                }
            }

            return xmlDocument.OuterXml;
        }

        private static bool ViewShouldBeIncludedInResults(SPView spView)
        {
            return spView.Title.ToLower() != "assetlibtemp";
        }

        private static void CreateColumnNode(XmlNode headNode, XmlDocument xmlDocument)
        {
            var attrType = xmlDocument.CreateAttribute("type");
            attrType.Value = "tree";
            var attrWidth = xmlDocument.CreateAttribute("width");
            attrWidth.Value = "*";
            var newNode = xmlDocument.CreateNode(XmlNodeType.Element, "column", xmlDocument.NamespaceURI);
            if (newNode.Attributes != null)
            {
                newNode.Attributes.Append(attrType);
                newNode.Attributes.Append(attrWidth);
            }

            newNode.InnerText = "";
            headNode.AppendChild(newNode);
        }

        private static XmlNode CreateHeadNode(XmlNode mainNode, XmlDocument xmlDocument)
        {
            var headNode = xmlDocument.CreateNode(XmlNodeType.Element, "head", xmlDocument.NamespaceURI);
            var ndSettings = xmlDocument.CreateNode(XmlNodeType.Element, "settings", xmlDocument.NamespaceURI);
            var ndColwith = xmlDocument.CreateNode(XmlNodeType.Element, "colwidth", xmlDocument.NamespaceURI);
            ndColwith.InnerText = "%";
            ndSettings.AppendChild(ndColwith);
            headNode.AppendChild(ndSettings);
            mainNode.AppendChild(headNode);
            return headNode;
        }

        public Hashtable GetListNamesInHashtable(string sortListName)
        {
            Hashtable oNames = null;
            if (!string.IsNullOrEmpty(sortListName))
            {
                oNames = new Hashtable();
                try
                {
                    foreach (string concatName in sortListName.Split('|'))
                    {
                        string[] keyValaues = Regex.Split(concatName, "::");
                        if (!oNames.ContainsKey(keyValaues[0]))
                            oNames.Add(keyValaues[0], keyValaues[1]);
                    }
                }
                catch
                {
                    oNames = null;
                }
            }

            return oNames;
        }

        public void GetSSRSReportTree(ref TreeNode node)
        {
            if (_reportsRootFolderName == "")
            {
                _reportsRootFolderName = CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsRootFolder");
            }

            if (string.IsNullOrEmpty(_reportingServicesUrl)) return;
            
            var username = "";
            var password = "";
            var chrono = SPContext.Current.Site.WebApplication.GetChild<ReportAuth>("ReportAuth");
            if (chrono != null)
            {
                username = chrono.Username;
                password = CoreFunctions.Decrypt(chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
            }

            if (!_isIntegrated) return;

            _srs2006 = new ReportingService2006 {UseDefaultCredentials = true};
            var rptWs = _reportingServicesUrl + "/ReportService2006.asmx";
            _srs2006.Url = rptWs;

            var curWeb = SPContext.Current.Web;
            var web = curWeb.Site.RootWeb;

            SPSecurity.RunWithElevatedPrivileges(delegate
                                                        {
                                                                if (password == "") return;
                                                                _srs2006.UseDefaultCredentials = false;
                                                                if (username.Contains("\\"))
                                                                {
                                                                    _srs2006.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                                                                }
                                                                else
                                                                {
                                                                    _srs2006.Credentials = new NetworkCredential(username, password);
                                                                }
                                                        });


            SPDocumentLibrary doc;

            try
            {
                doc = (SPDocumentLibrary)web.Lists["Report Library"];
            }
            catch
            {
                throw new Exception("Document Library 'Report Library' does not exist.");
            }

            // Get the appropriate EPMLive folder
            var reportFolder = doc.RootFolder;
            var rootFolderUrl = "Report Library" + _reportsFolderName;

            foreach (SPListItem itemFolder in doc.Folders)
            {
                if (itemFolder.Url.ToLower() != rootFolderUrl.ToLower()) continue;
                reportFolder = itemFolder.Folder;
                break;
            }

            if (reportFolder == doc.RootFolder)
            {
                throw new Exception("Folder '" + _reportsFolderName + "' does not exist.");
            }

            var folderItems = doc.GetItemsInFolder(doc.DefaultView, reportFolder);

            var tnTree = LoadTreeForSsrs(folderItems, doc);
            node = tnTree;
        }

        private static void AddSSRSReportLinks(TreeNode node, XmlDocument doc, XmlNode parentNode)
        {
            if (node.SelectAction.ToString() != TreeNodeSelectAction.None.ToString()) return;
            
            var ndView = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);

            var ndCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
            ndCell.InnerText = "<img align=\"absmiddle\" src=\"/_layouts/images/16fold.gif\"/> <label>" + node.Text + "</label>";
            ndView.AppendChild(ndCell);

            if (node.ChildNodes.Count <= 0) return;
            
            foreach (TreeNode subNode in node.ChildNodes)
            {
                if (subNode.SelectAction == TreeNodeSelectAction.None) AddSSRSReportLinks(subNode, doc, ndView);
                if (string.IsNullOrEmpty(subNode.Text) || string.IsNullOrEmpty(subNode.NavigateUrl)) continue;
                var ndDoc = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
                // create <userdata name="ViewTitle"> ... </userdata>
                var ndUserdata = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                var attrName = doc.CreateAttribute("name");
                attrName.Value = "ViewTitle";
                if (ndUserdata.Attributes != null) ndUserdata.Attributes.Append(attrName);
                ndUserdata.InnerText = subNode.Text;

                // create <userdata name="ViewRelativeUrl"> ... </userdata>
                var ndUserdata2 = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                var attrName2 = doc.CreateAttribute("name");
                attrName2.Value = "ViewRelativeUrl";
                if (ndUserdata2.Attributes != null) ndUserdata2.Attributes.Append(attrName2);
                ndUserdata2.InnerText = subNode.NavigateUrl;

                ndCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                ndCell.InnerText = "<img align=\"absmiddle\" src=\"/_layouts/epmlive/DHTML/xgrid/imgs/16doc.gif\"/> <a href=\"#\">" + subNode.Text + "</a>";
                ndDoc.AppendChild(ndUserdata);
                ndDoc.AppendChild(ndUserdata2);
                ndDoc.AppendChild(ndCell);
                ndView.AppendChild(ndDoc);
            }
            parentNode.AppendChild(ndView);
        }

        private TreeNode LoadTreeForSsrs(SPListItemCollection listItems, SPDocumentLibrary doc)
        {
            // Create a top-level node to start things off
            var tn = new TreeNode("RootNode", "0");

            // Pass the new node by reference, nodes will be added as children
            PopulateTree(listItems, doc, ref tn);

            return tn;
        }

        private void PopulateTree(SPListItemCollection listItems, SPDocumentLibrary doc, ref TreeNode tn)
        {
            var credentials = GetCredentials();
            
            foreach (SPListItem item in listItems)
            {
                TreeNode tnAdd;
                try
                {
                    tnAdd = new TreeNode(item.Name, item.UniqueId.ToString());

                    // Find out if the item has a title and use it
                    var spListItem = doc.GetItemByUniqueId(item.UniqueId);
                    if (spListItem.Title.Length > 0)
                    {
                        tnAdd.Text = spListItem.Title;
                    }

                    if (item.FileSystemObjectType == SPFileSystemObjectType.Folder)
                    {
                        tnAdd.SelectAction = TreeNodeSelectAction.None;
                        tnAdd.ImageUrl = "/_layouts/images/16fold.gif";

                        var folderItems = doc.GetItemsInFolder(doc.DefaultView, item.Folder);
                        if (folderItems.Count > 0)
                        {
                            PopulateTree(folderItems, doc, ref tnAdd);
                        }
                    }
                    else if (item.FileSystemObjectType == SPFileSystemObjectType.File && item.File.Name.ToLower().EndsWith("rdl"))
                    {
                        if (tnAdd.Text.ToLower().EndsWith(".rdl"))
                        {
                            tnAdd.Text = tnAdd.Text.Substring(0, tnAdd.Text.Length - 4);
                        }
                        tnAdd.ImageUrl = "/_layouts/images/16doc.gif";

                        try
                        {
                            var web = SPContext.Current.Web.Site.RootWeb;
                            var urlim = getReportParameters(Microsoft.SharePoint.Utilities.SPUrlUtility.CombineUrl(web.Url, item.Url));
                            var sServerReelativeUrl = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

                            tnAdd.NavigateUrl = sServerReelativeUrl +
                                "/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl=" +
                               sServerReelativeUrl + "/" + item.Url + urlim + "&rv:HeaderArea=none";
                        }
                        catch (Exception ex)
                        {
                            tnAdd.Text = item.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" + HttpUtility.HtmlEncode(ex.Message + ex.StackTrace) + "\" border=\"0\">";
                        }
                    }
                }
                catch (Exception ex)
                {
                    tnAdd = new TreeNode("Report Error", Guid.NewGuid().ToString())
                                {
                                    ImageUrl = "/_layouts/images/16doc.gif",
                                    Text = item.File.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" +
                                           HttpUtility.HtmlEncode(ex.Message) + "\">",
                                    NavigateUrl = ""
                                };
                }

                if (!string.IsNullOrEmpty(tnAdd.ImageUrl))
                {
                    tn.ChildNodes.Add(tnAdd);
                }
            }
        }

        private string getReportParameters(string url)
        {
            var parameters = "";

            var parametersSSRS2006 = _srs2006.GetReportParameters(url, null, null, null);

            foreach (var rp in parametersSSRS2006)
            {
                if (rp.Prompt != "") continue;
                
                switch (rp.Name)
                {
                    case "URL":
                        parameters += "&rp:URL=" + HttpUtility.UrlEncode(SPContext.Current.Web.ServerRelativeUrl);
                        break;
                    case "SiteId":
                        parameters += "&rp:SiteId=" + SPContext.Current.Site.ID;
                        break;
                    case "WebId":
                        parameters += "&rp:WebId=" + SPContext.Current.Web.ID;
                        break;
                    case "UserId":
                        parameters += "&rp:UserId=" + SPContext.Current.Web.CurrentUser.ID;
                        break;
                    case "Username":
                        parameters += "&rp:Username=" + HttpContext.Current.User.Identity.Name;
                        break;
                }
            }
            return (parameters);
        }

        private static NetworkCredential GetCredentials()
        {
            var username = "";
            var password = "";
            var storedAuthSettings = SPContext.Current.Site.WebApplication.GetChild<ReportAuth>("ReportAuth");
            if (storedAuthSettings != null)
            {
                username = storedAuthSettings.Username;
                password = CoreFunctions.Decrypt(storedAuthSettings.Password, "KgtH(@C*&@Dhflosdf9f#&f"); //TODO: This password should be placed somewhere central and not scattered around in code.
            }
            
            NetworkCredential credential;

            if (username.Contains("\\"))
            {
                credential = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
            }
            else
            {
                credential = new NetworkCredential(username, password);
            }

            return credential;
        }
    }
}