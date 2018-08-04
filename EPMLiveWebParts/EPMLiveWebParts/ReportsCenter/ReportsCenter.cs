using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveWebParts.SSRS2005;
using EPMLiveWebParts.SSRS2006;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    [Guid("10ff0c0e-6406-48d7-9226-48e739657307"), XmlRoot(Namespace = "ReportCenterWebPart")]
    public class ReportsCenter : ReportWebPartBase
    {
        private readonly StringBuilder sbRptList = new StringBuilder(5000);
        private string ReportingServicesURL = string.Empty;
        private bool Integrated;
        private bool bIsIntegratedMode;
        private TreeView tvReportView;

        public ReportsCenter()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Rollup Reports")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "IsTopList")]
        // The accessor for this property.
        public bool IsTopList
        {
            get
            {
                return isTopList;
            }
            set
            {
                isTopList = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Integrated Mode")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "IsIntegratedMode")]
        // The accessor for this property.
        public bool IsIntegratedMode
        {
            get
            {
                return bIsIntegratedMode;
            }
            set
            {
                bIsIntegratedMode = value;
            }
        }
        
        void ddl_DataBound(object sender, EventArgs e)
        {

        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web );
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (UseDefaults)
            {
                ReportingServicesURL = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

                try
                {
                    Integrated = bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsUseIntegrated"));
                }
                catch { }
            }
            else
            {
                ReportingServicesURL = PropSRSUrl;
                Integrated = IsIntegratedMode;
            }

            ReportsRootFolderName = PropReportsPath;
            if (ReportsRootFolderName == "")
                ReportsRootFolderName = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsRootFolder");


            if (ReportingServicesURL == null || ReportingServicesURL == "")
            {
                output.Write("ReportingServicesURL has not been set.");
            }
            else
            {
                string username = "";
                string password = "";
                EPMLiveCore.ReportAuth _chrono = SPContext.Current.Site.WebApplication.GetChild<EPMLiveCore.ReportAuth>("ReportAuth");
                if (_chrono != null)
                {
                    username = _chrono.Username;
                    password = EPMLiveCore.CoreFunctions.Decrypt(_chrono.Password, "KgtH(@C*&@Dhflosdf9f#&f");
                }

                /////////////////////////////////////////////////////////////////////
                //Code Here For Integrated Mode (If integrated checked, do the code below)
                /////////////////////////////////////////////////////////////////////
                if (Integrated)
                {
                    srs2006 = new ReportingService2006();
                    srs2006.UseDefaultCredentials = true;
                    string rptWS = ReportingServicesURL + "/ReportService2006.asmx";
                    srs2006.Url = rptWS;

                    try
                    {
                        curWeb = SPContext.Current.Web;
                        web = curWeb.Site.RootWeb;


                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite site = new SPSite(web.Url))
                            {
                                SPWebApplication app = site.WebApplication;
                                
                                if (password != "")
                                {
                                    srs2006.UseDefaultCredentials = false;
                                    if (username.Contains("\\"))
                                    {
                                        srs2006.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                                    }
                                    else
                                    {
                                        srs2006.Credentials = new NetworkCredential(username, password);
                                    }
                                }
                            }
                        });

                        output.WriteLine("<script language=\"javascript\">");
                        output.WriteLine("function openWindow(report){");
                        //output.WriteLine("window.open(\"" + ReportingServicesURL + "?" + System.Web.HttpUtility.UrlEncode(web.Url + "/Report Library" + ReportsFolderName + "/") + "\" + report + \"" + "&rs:Command=Render&URL=" + HttpUtility.UrlEncode(web.ServerRelativeUrl) + "\",\"Report\",\"toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes\");");
                        output.WriteLine("window.open(\"" + ReportingServicesURL + "?" + System.Web.HttpUtility.UrlEncode(web.Url + "/") + "\" + report + \"" + "&rs:Command=Render&URL=" + HttpUtility.UrlEncode(SPContext.Current.Web.ServerRelativeUrl) + "\",\"Report\",\"toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes\");");
                        output.WriteLine("}</script>");

                        if (tvReportView != null)
                        {
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
                            SPFolder reportFolder = doc.RootFolder;
                            string rootFolderURL = "Report Library" + this.ReportsFolderName;

                            foreach (SPListItem itemFolder in doc.Folders)
                            {
                                if (itemFolder.Url.ToLower() == rootFolderURL.ToLower())
                                {
                                    reportFolder = itemFolder.Folder;
                                    break;
                                }
                            }

                            if (reportFolder == doc.RootFolder)
                            {
                                throw new Exception("Folder '" + ReportsFolderName + "' does not exist.");
                            }

                            SPListItemCollection folderItems = doc.GetItemsInFolder(doc.DefaultView, reportFolder);

                            TreeNode tnTree = loadTree(folderItems, doc);
                            if (tnTree != null)
                            {
                                int iChildNodeCount = tnTree.ChildNodes.Count;
                                for (int i = 0; i < iChildNodeCount; i++)
                                {
                                    //It looks like we're adding the same node, but we're not
                                    //Each time you add a node, it removes it from tnTree
                                    tvReportView.Nodes.Add(tnTree.ChildNodes[0]);
                                }
                                tvReportView.DataBind();
                            }

                            tvReportView.RenderControl(output);
                        }

                    }
                    catch (Exception ex)
                    {
                        output.Write(ex.Message + ex.StackTrace);
                    }

                }
                else
                {
                    ///SSRS Output
                    try
                    {

                        web = SPContext.Current.Web;
                        srs2005 = new ReportingService2005();
                        srs2005.UseDefaultCredentials = true;
                        string rptWS = ReportingServicesURL + "/ReportService2005.asmx";
                        srs2005.Url = rptWS;

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite site = new SPSite(web.Url))
                            {
                                SPWebApplication app = site.WebApplication;
                                
                                if (password != "")
                                {
                                    srs2005.UseDefaultCredentials = false;
                                    if (username.Contains("\\"))
                                    {
                                        srs2005.Credentials = new NetworkCredential(username.Substring(username.IndexOf("\\") + 1), password, username.Substring(0, username.IndexOf("\\")));
                                    }
                                    else
                                    {
                                        srs2005.Credentials = new NetworkCredential(username, password);
                                    }
                                }
                            }
                        });

                        SSRS2005.CatalogItem[] items;
                        // Retrieve a list of all items from the report server database. 
                        try
                        {
                            items = srs2005.ListChildren(ReportsFolderName, true);
                            BuildTree(items);
                            output.Write(sbRptList.ToString());
                        }
                        catch (SoapException e)
                        {
                            output.Write("Soap Error: " + e.Detail.OuterXml);
                        }
                    }
                    catch
                    {
                        output.Write("Error connecting to Report Server");
                    }
                }
                //////////
            }
        }

        private void BuildTree(SSRS2005.CatalogItem[] catalogItems)
        {
            sbRptList.Append("<TABLE Summary=\"Links\" class=\"ms-summarycustombody\" style=\"margin-bottom: 2px;\"  cellpadding=0 cellspacing=0 border=0>");

            string currFolder = "";

            // list the reports in the root folder
            foreach (SSRS2005.CatalogItem item in catalogItems)
            {
                if (item.Type == SSRS2005.ItemTypeEnum.Report)
                {
                    if (currFolder == "" & item.Path == ReportsFolderName + "/" + item.Name)
                    {
                        AppendToRptList(item, false, false, "/_layouts/images/16doc.gif");
                    }
                }
            }

            foreach (SSRS2005.CatalogItem item in catalogItems)
            {
                if (item.Type == SSRS2005.ItemTypeEnum.Folder)
                {
                    currFolder = item.Name;
                    AppendToRptList(item, false, true, "/_layouts/images/16fold.gif");
                }
                else if (item.Type == SSRS2005.ItemTypeEnum.Report)
                {
                    string itemPath = item.Path.Substring(0, item.Path.Length - item.Name.Length);
                    if (currFolder != "" && itemPath.Contains(currFolder))
                    {
                        AppendToRptList(item, true, false, "/_layouts/images/16doc.gif");
                    }
                }
            }

            sbRptList.Append("</table>");

        }

        private TreeNode loadTree(SPListItemCollection listItems, SPDocumentLibrary doc)
        {
            // Create a top-level node to start things off
            TreeNode tn = new TreeNode("RootNode", "0");

            // Pass the new node by reference, nodes will be added as children
            PopulateTree(listItems, doc, tn);

            return tn;
        }

        protected override void PopulateTree(SPListItemCollection listItems, SPDocumentLibrary doc, TreeNode treeNode)
        {
            if (listItems == null)
            {
                throw new ArgumentNullException("listItems");
            }

            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }

            if (treeNode == null)
            {
                throw new ArgumentNullException("treeNode");
            }

            TreeNode tnAdd;
            foreach (SPListItem item in listItems)
            {
                try
                {
                    tnAdd = CreateTreeNode(item, doc);
                }
                catch (Exception ex)
                {
                    tnAdd = new TreeNode("Report Error", Guid.NewGuid().ToString());
                    tnAdd.ImageUrl = "/_layouts/images/16doc.gif";
                    tnAdd.Text = item.File.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" + HttpUtility.HtmlEncode(ex.Message) + "\">";
                    tnAdd.NavigateUrl = "";
                }

                if (tnAdd.ImageUrl != null && tnAdd.ImageUrl.Length > 0)
                {
                    treeNode.ChildNodes.Add(tnAdd);
                }
            }
        }

        protected override string GetFileNodeNavigationUrl(SPListItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            const string urlTemplate = "Javascript:window.open('{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={1}{2}&rv:HeaderArea=none','',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');void(0);";
            const string slash = "/";

            var relativeUrl = web.ServerRelativeUrl == slash ? string.Empty : web.ServerRelativeUrl;


            var urlParameters = Get2006Parameters(SPUrlUtility.CombineUrl(web.Url, item.Url));
            var navUrl = string.Format(urlTemplate,
                                       relativeUrl,
                                       HttpUtility.UrlEncode(string.Concat(relativeUrl, slash, item.Url)),
                                       urlParameters);

            return navUrl;
        }

        protected override string GetFileNodeErrorText(SPListItem item, Exception exception)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            const string textTemplate = "{0} <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"{1}\" border=\"0\">";

            var errorText = string.Format(textTemplate,
                                          item.Name,
                                          HttpUtility.HtmlEncode(string.Concat(exception.Message, exception.StackTrace)));

            return errorText;
        }

        private void AppendToRptList(SSRS2005.CatalogItem item, bool tab, bool isFldr, string imgURL)
        {

            sbRptList.Append("<TR>");
            if (tab)
            {
                sbRptList.Append("<TD style=\"padding-bottom: 2px\" class=\"ms-vb\">&nbsp;&nbsp;</TD><TD style=\"padding-bottom: 2px;padding-left: 2px;\" class=\"ms-vb\"><img src=\"");
                sbRptList.Append(imgURL);
                sbRptList.Append("\" alt=\"\" >&nbsp;&nbsp;");
            }
            else
            {
                sbRptList.Append("<TD style=\"padding-bottom: 2px\" class=\"ms-vb\"><img src=\"");
                sbRptList.Append(imgURL);
                sbRptList.Append("\" alt=\"\">&nbsp;</td><TD style=\"padding-bottom: 2px;padding-left: 2px;\" class=\"ms-vb\">");
            }

            if (isFldr)
            {
                sbRptList.Append("<B>" + item.Name + "</B>");
            }
            else
            {
                try
                {
                    var parameters = Get2005Parameters(item.Path);
                    sbRptList.Append("<A onfocus=\"OnLink(this)\" HREF=\"#\" onClick=\"Javascript:window.open('" + ReportingServicesURL + "?" + System.Web.HttpUtility.UrlEncode(item.Path) + parameters + "','',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');\">" + item.Name + "</A>");
                }
                catch (Exception ex)
                {
                    sbRptList.Append(item.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" + HttpUtility.HtmlEncode(ex.Message) + "\">");
                }
            }

            sbRptList.Append("</TD></TR>");

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //Controls.Clear();

            tvReportView = new TreeView();
            tvReportView.SkipLinkText = "";
            tvReportView.ImageSet = TreeViewImageSet.XPFileExplorer;
            tvReportView.ID = "tvReportLibrary";
            tvReportView.EnableClientScript = false;
            tvReportView.ShowExpandCollapse = false;

            tvReportView.ShowLines = false;
            tvReportView.NodeIndent = 20;

            tvReportView.NodeStyle.HorizontalPadding = Unit.Pixel(7);
            tvReportView.NodeStyle.ChildNodesPadding = Unit.Pixel(1);
            tvReportView.Attributes.Add("style", "padding-left:5px;padding-top:3px;");
            this.Controls.Add(tvReportView);

            //if (this.IsIntegratedMode)
            //{
            //    //Controls.Clear();

            //    web = SPContext.Current.Web.Site.RootWeb; //SPContext.Current.Web;
            //    SPDocumentLibrary doc;

            //    try
            //    {
            //        doc = (SPDocumentLibrary)web.Lists["Report Library"];
            //    }
            //    catch
            //    {
            //        lblErrMessage = new Label();
            //        lblErrMessage.ID = ClientID + "_errLabel";
            //        lblErrMessage.Text = "Document Library 'Report Library' does not exist.";
            //        this.Controls.Add(lblErrMessage);
            //        return;
            //        //throw new Exception("Document Library 'Report Library' does not exist.");                    
            //    }

            //    // Get the appropriate EPMLive folder
            //    SPFolder reportFolder;
            //    string rootFolderURL = doc.RootFolder.ServerRelativeUrl.ToString() + this.ReportsFolderName;

            //    try
            //    {
            //        reportFolder = doc.RootFolder.SubFolders[rootFolderURL];
            //    }
            //    catch
            //    {
            //        lblErrMessage = new Label();
            //        lblErrMessage.ID = ClientID + "_errLabel";
            //        lblErrMessage.Text = "Folder " + ReportsFolderName + " does not exist.";
            //        this.Controls.Add(lblErrMessage);
            //        return;
            //        //throw new Exception("Folder " + ReportsFolderName + " does not exist.");
            //    }

            //    SPListItemCollection folderItems = doc.GetItemsInFolder(doc.DefaultView, reportFolder);

            //    //tvReportView = new TreeView();
            //    //tvReportView.SkipLinkText = "";
            //    //tvReportView.ImageSet = TreeViewImageSet.XPFileExplorer;
            //    //tvReportView.ID = "tvReportLibrary";
            //    //tvReportView.EnableClientScript = false;
            //    //tvReportView.ShowExpandCollapse = false;

            //    //tvReportView.ShowLines = false;
            //    //tvReportView.NodeIndent = 20;                

            //    //tvReportView.NodeStyle.HorizontalPadding = Unit.Pixel(7);                
            //    //tvReportView.NodeStyle.ChildNodesPadding = Unit.Pixel(1);
            //    //tvReportView.Attributes.Add("style", "padding-left:5px;padding-top:3px;");

            //    TreeNode tnTree = loadTree(folderItems, doc);
            //    if (tnTree != null)
            //    {
            //        int iChildNodeCount = tnTree.ChildNodes.Count;
            //        for (int i = 0; i < iChildNodeCount; i++)
            //        {
            //            //It looks like we're adding the same node, but we're not
            //            //Each time you add a node, it removes it from tnTree
            //            tvReportView.Nodes.Add(tnTree.ChildNodes[0]);
            //        }
            //        tvReportView.DataBind();
            //    }                

            //    this.Controls.Add(tvReportView);
            //}
        }
    }
}
