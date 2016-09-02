using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EPMLiveWebParts.SSRS2006;
using EPMLiveWebParts.SSRS2005;
using System.Web.UI.HtmlControls;
using System.Reflection;
using Microsoft.SharePoint.Administration;

namespace EPMLiveWebParts
{
    [Guid("9237c225-fcc1-4571-9233-5a1e8c2e7018"), XmlRoot(Namespace = "ReportViewerWebPart")]
    public class ReportViewer : Microsoft.SharePoint.WebPartPages.WebPart
    {
        string ReportingServicesURL = "";
        string ReportsRootFolderName = "";
        bool Integrated;

        bool? bUseDefaults;
        private string sReportsFolderName = "";
        StringBuilder sbRptList = new StringBuilder("", 5000);
        ReportingService2006 srs2006;
        ReportingService2005 srs2005;
        private SPWeb web;
        private SPWeb curWeb;
        bool bIsTopList;
        bool bIsIntegratedMode;
        string strSRSUrl;
        string strReportsPath = "";
        TreeNode tnCurrNode = new TreeNode();
        TreeNodeCollection tncNodes = new TreeNodeCollection();
        TreeView tvReportView;
        SSRS2006.ReportParameter[] parametersSSRS2006 = null;
        SSRS2005.ReportParameter[] parametersSSRS2005 = null;

        public ReportViewer()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        public string ReportsFolderName
        {
            get
            {
                if (sReportsFolderName == "")
                {
                    if (bIsTopList)
                    {
                        sReportsFolderName = ReportsRootFolderName + "/epmlivetl";
                    }
                    else
                    {
                        sReportsFolderName = ReportsRootFolderName + "/epmlive";
                    }
                }

                return sReportsFolderName;
            }
        }


        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Reports Path")]
        [Description("Use this option if your reports are not installed in the root directory. Path must start with a '/'")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropReportsPath")]

        // The accessor for this property.
        public string PropReportsPath
        {
            get
            {
                if (strReportsPath == null)
                    return "";
                return strReportsPath;
            }
            set
            {
                strReportsPath = value;
            }
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
                return bIsTopList;
            }
            set
            {
                bIsTopList = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Use Application Defaults")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "UseDefaults")]
        // The accessor for this property.
        public bool UseDefaults
        {
            get
            {
                if (bUseDefaults == null)
                {
                    if (PropSRSUrl == "" && PropReportsPath == "")
                        return true;
                    else
                        return false;
                }
                else
                    return bUseDefaults.Value;
            }
            set
            {
                bUseDefaults = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("SQL Reporting Services URL")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropSRSUrl")]
        // The accessor for this property.
        public string PropSRSUrl
        {
            get
            {
                if (strSRSUrl == null)
                    return "";
                return strSRSUrl;
            }
            set
            {
                strSRSUrl = value;
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
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
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

                srs2005 = new ReportingService2005();
                srs2005.UseDefaultCredentials = true;
                string rptWS = ReportingServicesURL + "/ReportService2005.asmx";
                srs2005.Url = rptWS;

                /////////////////////////////////////////////////////////////////////
                //Code Here For Integrated Mode (If integrated checked, do the code below)
                /////////////////////////////////////////////////////////////////////
                if (Integrated)
                {
                    srs2006 = new ReportingService2006();
                    srs2006.UseDefaultCredentials = true;
                    rptWS = ReportingServicesURL + "/ReportService2006.asmx";
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
                                if (username != "")
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

                            output.WriteLine("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" height=\"100%\" ><tr><td id=\"coltohide\" style=\"vertical-align:top\" width=\"250\" height=\"100%\"><img src=\"/_layouts/images/blank.gif\" height=\"1\" width=\"250\">");

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
                            output.WriteLine("</td><td bgcolor=\"#D9D9D9\" onMouseOver=\"this.bgColor='#BBC4D9'\" onMouseOut=\"this.bgColor='#D9D9D9'\" width=\"10px\" height=\"100%\" onclick=\"show_hide_column1();\" align=\"center\">");
                            output.WriteLine("<img src=\"/_layouts/images/blank.gif\" height=\"1\" width=\"12\"><img src=\"/_layouts/epmlive/images/arrow.gif\" alt=\"\">");
                        }
                    }
                    catch (Exception ex)
                    {
                        output.Write(ex.Message);
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else
                {
                    ///SSRS Output
                    try
                    {
                        web = SPContext.Current.Web;

                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            using (SPSite site = new SPSite(web.Url))
                            {
                                SPWebApplication app = site.WebApplication;

                                if (username != "")
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
                        //CatalogItem[] items;

                        // Retrieve a list of all items from the report server database. 
                        try
                        {
                            items = srs2005.ListChildren(ReportsFolderName, true);
                            //items = srs2005.ListChildren(ReportsFolderName);
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

                output.WriteLine("</td><td width=\"100%\" height=\"100%\">");
                output.WriteLine("<iframe  id=\"Frameviewer\"  frameborder=\"0\"  vspace=\"0\"  hspace=\"0\"  marginwidth=\"0\" src=\"\"  marginheight=\"0\"");
                output.WriteLine("width=\"100%\"  scrolling=\"yes\"  height=\"100%\">");
                output.WriteLine("</iframe>");
                output.WriteLine("</td></tr></table>");
                output.WriteLine("<script>");
                //output.WriteLine("function show_hide_column1(td) {");
                //output.WriteLine("if(td.previousSibling.style.display==\"none\"){td.previousSibling.style.display = \"\";}");
                //output.WriteLine("else{td.previousSibling.style.display = \"none\";}}");
                output.WriteLine("function show_hide_column1() {");
                output.WriteLine("if(document.getElementById('coltohide').style.display==\"none\"){document.getElementById('coltohide').style.display=\"\";}");
                output.WriteLine("else{document.getElementById('coltohide').style.display=\"none\";}}");
                output.WriteLine("</script>");
                output.WriteLine("<script language=\"javascript\">");
                output.WriteLine("function frameview(link){");
                output.WriteLine("document.getElementById('Frameviewer').src=link;");
                output.WriteLine("document.getElementById('coltohide').style.display=\"none\";");
                output.WriteLine("}");
                output.WriteLine("</script>");
            }
        }
        private void BuildTree(SSRS2005.CatalogItem[] catalogItems)
        {
            sbRptList.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" height=\"100%\" ><tr><td id=\"coltohide\" style=\"vertical-align:top\" width=\"250\" height=\"100%\"><img src=\"/_layouts/images/blank.gif\" height=\"1\" width=\"250\">");
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
            //sbRptList.Append("</td><td bgcolor=\"#D9D9D9\" onMouseOver=\"this.bgColor='#BBC4D9'\" onMouseOut=\"this.bgColor='#D9D9D9'\" width=\"10px\" height=\"100%\" onclick=\"show_hide_column1(this);\"\">");
            sbRptList.Append("</td><td bgcolor=\"#D9D9D9\" onMouseOver=\"this.bgColor='#BBC4D9'\" onMouseOut=\"this.bgColor='#D9D9D9'\" width=\"10px\" height=\"100%\" onclick=\"show_hide_column1();\" align=\"center\">");
            sbRptList.Append("<img src=\"/_layouts/images/blank.gif\" height=\"1\" width=\"12\"><img src=\"/_layouts/epmlive/images/arrow.gif\" alt=\"\">");
            //sbRptList.Append("</div>");
        }

        private TreeNode loadTree(SPListItemCollection listItems, SPDocumentLibrary doc)
        {
            // Create a top-level node to start things off
            TreeNode tn = new TreeNode("RootNode", "0");
            // Pass the new node by reference, nodes will be added as children
            populateTree(listItems, doc, ref tn);
            return tn;
        }

        private string RSNOIM(string url)
        {

            parametersSSRS2005 = srs2005.GetReportParameters(url, null, true, null, null);
            string parameters = "";
            foreach (SSRS2005.ReportParameter rp in parametersSSRS2005)
            {
                if (rp.Prompt == "")
                {
                    switch (rp.Name)
                    {
                        case "URL":
                            parameters += "&URL=" + HttpUtility.UrlEncode(web.ServerRelativeUrl);
                            break;
                        case "SiteId":
                            parameters += "&SiteId=" + SPContext.Current.Site.ID;
                            break;
                        case "WebId":
                            parameters += "&WebId=" + SPContext.Current.Web.ID;
                            break;
                        case "UserId":
                            parameters += "&UserId=" + SPContext.Current.Web.CurrentUser.ID;
                            break;
                        case "Username":
                            parameters += "&Username=" + HttpContext.Current.User.Identity.Name;
                            break;
                    };
                }
            }
            return (parameters);
        }

        private string RS(string url)
        {
            parametersSSRS2006 = srs2006.GetReportParameters(url, null, null, null);
            string parameters = "";
            foreach (SSRS2006.ReportParameter rp in parametersSSRS2006)
            {
                if (rp.Prompt == "")
                {
                    switch (rp.Name)
                    {
                        case "URL":
                            parameters += "&rp:URL=" + HttpUtility.UrlEncode(curWeb.ServerRelativeUrl);
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
                    };
                }
            }
            return (parameters);
        }

        private void populateTree(SPListItemCollection listItems, SPDocumentLibrary doc, ref TreeNode tn)
        {


            TreeNode tnAdd = null;
            foreach (SPListItem item in listItems)
            {
                tnAdd = new TreeNode(item.Name, item.UniqueId.ToString());
                try
                {
                    // Find out if the item has a title and use it
                    SPListItem spListItem = doc.GetItemByUniqueId(item.UniqueId);
                    if (spListItem.Title.Length > 0)
                    {
                        tnAdd.Text = spListItem.Title;
                    }
                }
                catch { }

                if (item.FileSystemObjectType == SPFileSystemObjectType.Folder)
                {

                    tnAdd.Text = "<b>" + tnAdd.Text + "</b>";
                    tnAdd.SelectAction = TreeNodeSelectAction.None;
                    tnAdd.ImageUrl = "/_layouts/images/16fold.gif";

                    SPListItemCollection folderItems = doc.GetItemsInFolder(doc.DefaultView, item.Folder);
                    if (folderItems.Count > 0)
                    {
                        populateTree(folderItems, doc, ref tnAdd);
                    }
                }
                else if (item.FileSystemObjectType == SPFileSystemObjectType.File && item.File.Name.ToLower().EndsWith("rdl"))
                {
                    if (tnAdd.Text.ToLower().EndsWith(".rdl"))
                    {
                        tnAdd.Text = tnAdd.Text.Substring(0, tnAdd.Text.Length - 4);
                    }
                    tnAdd.ImageUrl = "/_layouts/images/16doc.gif";
                    /////
                    ////////// im
                    ///////////

                    try
                    {
                        string URLIM = RS(Microsoft.SharePoint.Utilities.SPUrlUtility.CombineUrl(web.Url, item.Url));
                        tnAdd.NavigateUrl = "Javascript:frameview(\"" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl=" + System.Web.HttpUtility.UrlEncode(((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/" + item.Url) + URLIM + "&rv:HeaderArea=none\");";
                    }
                    catch (Exception ex)
                    {
                        tnAdd.Text = item.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" + HttpUtility.HtmlEncode(ex.Message) + "\" style=\"vertical-align: middle;\">";
                    }


                    //('" + ReportingServicesURL + "?" + System.Web.HttpUtility.UrlEncode(item.Path) + parameters + "');\">" + item.Name + "</A>");
                }
                if (tnAdd.ImageUrl != null && tnAdd.ImageUrl.Length > 0)
                {
                    tn.ChildNodes.Add(tnAdd);
                }
            }
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
                    string parameters = RSNOIM(item.Path);
                    sbRptList.Append("<A HREF=\"#\" onClick=\"frameview('" + ReportingServicesURL + "?" + System.Web.HttpUtility.UrlEncode(item.Path) + parameters + "');\">" + item.Name + "</A>");
                }
                catch (Exception ex)
                {
                    sbRptList.Append(item.Name + " <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"" + HttpUtility.HtmlEncode(ex.Message) + "\" style=\"vertical-align: middle;\">");
                }

            }
            sbRptList.Append("</TD></TR>");
        }

        #region Overriden Methods

        protected override void OnInit(EventArgs e)
        {
            

            base.OnInit(e);
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
        }
        #endregion
    }
}