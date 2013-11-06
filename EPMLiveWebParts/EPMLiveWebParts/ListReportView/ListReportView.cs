using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml.Serialization;
using Microsoft.SharePoint.WebPartPages;
using System.Xml;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using EPMLiveWebParts.SSRS2005;
using EPMLiveWebParts.SSRS2006;


namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:ReportViewWebpart runat=server></{0}:ReportViewWebpart>")]
    [Guid("F27DF1AA-4D78-43F0-AE48-F61BAF42E10F")]
    [XmlRoot(Namespace = "ListReportView")]
    public class ListReportView : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private string _viewLists;
        private bool _expandView;
        private string _sortNames;
        private string _selectedListName = string.Empty;
        string _reportingServicesUrl = "";
        string _reportsRootFolderName = "";
        bool _isIntegrated;

        private string sReportsFolderName = "";
        StringBuilder sbRptList = new StringBuilder("", 5000);
        ReportingService2005 srs2005;
        ReportingService2006 srs2006;
        private SPWeb web;
        private SPWeb curWeb;


        bool? bUseDefaults;
        bool? bIsTopList;
        bool bIsIntegratedMode;
        string strSRSUrl;
        string strReportsPath = "";

        TreeNode tnCurrNode = new TreeNode();
        TreeNodeCollection tncNodes = new TreeNodeCollection();
        TreeView tvReportView;
        SSRS2006.ReportParameter[] parametersSSRS2006 = null;
        SSRS2005.ReportParameter[] parametersSSRS2005 = null;
        public ListReportView()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        [Category("Report View Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("List names")]
        [Description("List of lists to display views for.")]
        [Browsable(false)]
        public string ViewLists
        {
            get
            {
                return _viewLists;
            }
            set
            {
                _viewLists = value;
            }
        }

        [Category("Report View Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Expand view")]
        [Description("Sets whether the views are expanded")]
        [Browsable(false)]
        public bool ExpandView
        {
            get
            {
                return _expandView;
            }
            set
            {
                _expandView = value;
            }
        }

        [Category("Report View Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Concat List internal and display names")]
        [Description("Sorted list names to display views for.")]
        [Browsable(false)]
        public string DisplayListNames
        {
            get
            {
                return _sortNames;
            }
            set
            {
                _sortNames = value;
            }
        }

        [Category("Report View Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Selected List internal and display names")]
        [Description("Selected list names to display views for.")]
        [Browsable(false)]
        public string SelectedListNames
        {
            get
            {
                return _selectedListName;
            }
            set
            {
                _selectedListName = value;
            }
        }


        public string ReportsFolderName
        {
            get
            {
                if (sReportsFolderName == "")
                {
                    if (bIsTopList.HasValue && bIsTopList.Value)
                    {
                        sReportsFolderName = _reportsRootFolderName + "/epmlivetl";
                    }
                    else
                    {
                        sReportsFolderName = _reportsRootFolderName + "/epmlive";
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
        [Browsable(false)]
        [XmlElement(ElementName = "PropReportsPath")]
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
        [Browsable(false)]
        [XmlElement(ElementName = "IsTopList")]
        public bool? IsTopList
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
        [Browsable(false)]
        [XmlElement(ElementName = "UseDefaults")]
        public bool UseDefaults
        {
            get
            {
                if (bUseDefaults == null)
                {
                    return PropSRSUrl == "" && PropReportsPath == "";
                }

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
        [Browsable(false)]
        [ReadOnly(false)]
        [XmlElement(ElementName = "PropSRSUrl")]
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
        [Browsable(false)]
        [ReadOnly(false)]
        [XmlElement(ElementName = "IsIntegratedMode")]
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            tvReportView = new TreeView();
            tvReportView.SkipLinkText = "";
            tvReportView.ImageSet = TreeViewImageSet.XPFileExplorer;
            tvReportView.ID = "tvListReportTreeView";
            tvReportView.EnableClientScript = false;
            tvReportView.ShowExpandCollapse = true;
            tvReportView.ExpandDepth = 0;
            tvReportView.ShowLines = false;
            tvReportView.NodeIndent = 20;
            tvReportView.NodeStyle.HorizontalPadding = Unit.Pixel(7);
            tvReportView.NodeStyle.ChildNodesPadding = Unit.Pixel(1);
            tvReportView.Attributes.Add("style", "padding-left:5px;padding-top:3px;");
            Controls.Add(tvReportView);

            if (string.IsNullOrEmpty(Width)) Width = "300px";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js", false);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            output.Write(RenderHTML());
        }

        private string RenderHTML()
        {
            SPWeb cWeb = SPContext.Current.Web;
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css\"/>");
            htmlBuilder.Append("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css\"/>");
            htmlBuilder.Append("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/ReportViewer.css\"/>");

            htmlBuilder.Append("<script>_css_prefix=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/\"; </script>");
            htmlBuilder.Append("<script src=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/ReportViewWebpart.js\"></script>");

            htmlBuilder.Append("<div id=\"grid" + this.UniqueID + "\" style=\"display:none;margin-top:10px\"  ></div>\r\n\r\n");
            htmlBuilder.Append("<div  width=\"100%\" id=\"loadinggrid" + this.UniqueID + "\" >");
            htmlBuilder.Append("<img src=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/15/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            htmlBuilder.Append("</div>");

            htmlBuilder.Append("<div id=\"gridSsrs" + this.UniqueID + "\"  style=\"display:none\" ></div>\r\n\r\n");
            htmlBuilder.Append("<div  width=\"100%\" id=\"loadinggridSsrs" + this.UniqueID + "\" style=\"padding-top:20px;\">");
            htmlBuilder.Append("<img src=\"" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/15/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading SSRS Items...");
            htmlBuilder.Append("</div>");

            htmlBuilder.Append("<script>");

            htmlBuilder.Append("var gridReportView = new dhtmlXGridObject('grid" + this.UniqueID + "');");
            htmlBuilder.Append("gridReportView.setImagePath('" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/imgs/');");
            htmlBuilder.Append("gridReportView.setImageSize(1,1);");
            htmlBuilder.Append("gridReportView.setSkin('myworkspace');");
            htmlBuilder.Append("gridReportView.attachEvent('onXLE',clearLoader);");
            htmlBuilder.Append("gridReportView.enableAutoHeight(true);");
            htmlBuilder.Append("gridReportView.enableAlterCss('', '');");
            htmlBuilder.Append("gridReportView.setNoHeader(true);");
            htmlBuilder.Append("gridReportView.enableTreeCellEdit(false);");
            htmlBuilder.Append("gridReportView.init();");

            htmlBuilder.Append("gridReportView.attachEvent(\"onRowSelect\",function(rowId, cellIndex){");
            htmlBuilder.Append("var viewTitle = gridReportView.getUserData(rowId, \"ViewTitle\");");
            htmlBuilder.Append("var viewUrl = gridReportView.getUserData(rowId, \"ViewRelativeUrl\");");
            htmlBuilder.Append("OpenViewInModal(viewTitle, viewUrl,rowId,cellIndex);");
            htmlBuilder.Append("});");

            htmlBuilder.Append("var gridReportViewSsrs = new dhtmlXGridObject('gridSsrs" + this.UniqueID + "');");
            htmlBuilder.Append("gridReportViewSsrs.setImagePath('" + (cWeb.ServerRelativeUrl == "/" ? "" : cWeb.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/imgs/');");
            htmlBuilder.Append("gridReportViewSsrs.setImageSize(1,1);");
            htmlBuilder.Append("gridReportViewSsrs.setSkin('myworkspace');");
            htmlBuilder.Append("gridReportViewSsrs.attachEvent('onXLE',clearLoaderSsrs);");
            htmlBuilder.Append("gridReportViewSsrs.enableAutoHeight(true);");
            htmlBuilder.Append("gridReportViewSsrs.enableAlterCss('', '');");
            htmlBuilder.Append("gridReportViewSsrs.setNoHeader(true);");
            htmlBuilder.Append("gridReportViewSsrs.enableTreeCellEdit(false);");
            htmlBuilder.Append("gridReportViewSsrs.init();");

            htmlBuilder.Append("gridReportViewSsrs.attachEvent(\"onRowSelect\",function(rowId, cellIndex){");
            htmlBuilder.Append("var viewTitle = gridReportViewSsrs.getUserData(rowId, \"ViewTitle\");");
            htmlBuilder.Append("var viewUrl = gridReportViewSsrs.getUserData(rowId, \"ViewRelativeUrl\");");
            htmlBuilder.Append("OpenViewInModal(viewTitle, viewUrl,rowId,cellIndex);");
            htmlBuilder.Append("});");

            htmlBuilder.Append("function clearLoader(id)");
            htmlBuilder.Append("{");

            htmlBuilder.Append("document.getElementById('grid" + this.UniqueID + "').style.display ='';");
            htmlBuilder.Append("document.getElementById('loadinggrid" + this.UniqueID + "').style.display = 'none';");
            if (ExpandView)
            {
                htmlBuilder.Append("gridReportView.expandAll();");
            }
            htmlBuilder.Append("};");

            htmlBuilder.Append("function clearLoaderSsrs(id)");
            htmlBuilder.Append("{");
            htmlBuilder.Append("document.getElementById('gridSsrs" + this.UniqueID + "').style.display = '';");
            htmlBuilder.Append("document.getElementById('loadinggridSsrs" + this.UniqueID + "').style.display = 'none';");
            if (ExpandView)
            {
                htmlBuilder.Append("gridReportViewSsrs.expandAll();");
            }
            htmlBuilder.Append("};");

            htmlBuilder.AppendLine("function loadReport(){");
            htmlBuilder.AppendFormat("var url='{0}';", cWeb.Url + "/_layouts/epmlive/getlistreportitems.aspx");
            htmlBuilder.AppendFormat("var data='data={0}';", BuildGridPostParameters(false));
            htmlBuilder.AppendLine("dhtmlxAjax.post(url, data, handleAjaxPost);");
            htmlBuilder.Append("};");

            htmlBuilder.AppendLine("function handleAjaxPost(loader)");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("if(loader.xmlDoc.responseText!=null)");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("var dataXml =loader.xmlDoc.responseText;");
            htmlBuilder.AppendLine("gridReportView.loadXMLString(dataXml);");
            htmlBuilder.AppendLine("}");
            htmlBuilder.AppendLine("else");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("alert(\"Response contains no XML\");");
            htmlBuilder.AppendLine("}");
            htmlBuilder.AppendLine("}");

            htmlBuilder.AppendLine("function loadReportSsrs(){");

            htmlBuilder.AppendFormat("var url='{0}';", cWeb.Url + "/_layouts/epmlive/getlistreportitems.aspx");
            htmlBuilder.AppendFormat("var data='data={0}';", BuildGridPostParameters(true));
            htmlBuilder.AppendLine("dhtmlxAjax.post(url, data, handleAjaxPostSsrs);");
            htmlBuilder.Append("};");

            htmlBuilder.AppendLine("function handleAjaxPostSsrs(loader)");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("if(loader.xmlDoc.responseText!=null)");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("var dataXml =loader.xmlDoc.responseText;");
            htmlBuilder.AppendLine("gridReportViewSsrs.loadXMLString(dataXml);");

            htmlBuilder.AppendLine("}");
            htmlBuilder.AppendLine("else");
            htmlBuilder.AppendLine("{");
            htmlBuilder.AppendLine("alert(\"Response contains no XML\");");
            htmlBuilder.AppendLine("}");
            htmlBuilder.AppendLine("}");

            htmlBuilder.Append("_spBodyOnLoadFunctionNames.push(\"loadReport\");");
            htmlBuilder.Append("_spBodyOnLoadFunctionNames.push(\"loadReportSsrs\");");
            htmlBuilder.Append("</script>");

            return htmlBuilder.ToString();
        }

        private string BuildGridPostParameters(bool isSsrs)
        {
            if (UseDefaults)
            {
                _reportingServicesUrl = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

                try
                {
                    _isIntegrated = bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsUseIntegrated"));
                    bIsIntegratedMode = _isIntegrated;
                }
                catch { }
            }
            else
            {
                _reportingServicesUrl = PropSRSUrl;
                _isIntegrated = IsIntegratedMode;
            }

            var postParameters = new StringBuilder();
            postParameters.AppendFormat("DisplayListNames^{0}\n", DisplayListNames);
            postParameters.AppendFormat("ViewLists^{0}\n", ViewLists);
            postParameters.AppendFormat("ReportsRootFolderName^{0}\n", _reportsRootFolderName);
            postParameters.AppendFormat("ReportingServicesUrl^{0}\n", _reportingServicesUrl);
            postParameters.AppendFormat("ReportsFolderName^{0}\n", ReportsFolderName);
            postParameters.AppendFormat("Integrated^{0}\n", _isIntegrated);
            postParameters.AppendFormat("IsSSRS^{0}\n", isSsrs);

            var parametersAsBytes = Encoding.ASCII.GetBytes(postParameters.ToString());
            return Convert.ToBase64String(parametersAsBytes);
        }

        private string BuildQueryParam()
        {
            StringBuilder qsBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(ViewLists))
            {
                string[] lists = ViewLists.Split('\n');
                foreach (string list in lists)
                {
                    if (!string.IsNullOrEmpty(list))
                    {
                        qsBuilder.Append(list + "|");
                    }
                }
            }

            string retVal = qsBuilder.ToString();
            if (retVal.EndsWith("|"))
            {
                retVal = retVal.Remove(retVal.LastIndexOf('|'));
            }

            return retVal;
        }

        public override ToolPart[] GetToolParts()
        {
            ToolPart[] toolparts = new ToolPart[4];

            toolparts[0] = new WebPartToolPart();
            toolparts[1] = new ListReportViewToolPart();
            toolparts[1].ChromeState = PartChromeState.Minimized;
            toolparts[2] = new ReportingServicesToolPart();
            toolparts[2].ChromeState = PartChromeState.Minimized;
            toolparts[3] = new CustomPropertyToolPart();

            return toolparts;
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
                    this.DisplayListNames = string.Empty;
                    this.SelectedListNames = string.Empty;
                }
            }

            return oNames;
        }

        private SPFolder GetParentFolder(SPListItem itemToFind, SPFolder folder)
        {
            SPQuery query = new SPQuery();
            query.Folder = folder;
            SPListItemCollection items = itemToFind.ParentList.GetItems(query);
            foreach (SPListItem item in items)
            {
                if (item.ID == itemToFind.ID)
                {
                    return (folder);
                }
                if (item.Folder != null)
                {
                    SPFolder resultFolder = GetParentFolder(itemToFind, item.Folder);
                    if (resultFolder != null)
                    {
                        return (resultFolder);
                    }
                }
            }
            return (null);
        }

        private ArrayList GetNonFolderItems(SPList list)
        {
            ArrayList fileList = new ArrayList(list.RootFolder.Files);
            IComparer compFiles = new SPFilesComparer();
            fileList.Sort(compFiles);

            return fileList;
        }

        void TraverseListFolder(SPFolder folder, XmlDocument doc, XmlNode mainNode)
        {
            SPQuery qry = new SPQuery();
            qry.Folder = folder;
            qry.Query = "<OrderBy><FieldRef Name=\"Title\" /></OrderBy>";

            try
            {
                SPWeb web = SPContext.Current.Web;
                SPListItemCollection ic = web.Lists[folder.ParentListId].GetItems(qry);
                foreach (SPListItem subitem in ic)
                {
                    SPFile oFile = subitem.File;

                    if (subitem.Folder != null)
                    {
                        AddDocuments(subitem.Folder, doc, mainNode);
                    }
                }
            }
            catch { }

        }
        
        private void AddDocuments(SPFolder folder, XmlDocument doc, XmlNode parentNode)
        {
            XmlNode ndView;
            XmlNode ndCell;

            if (folder != null)
            {
                ndView = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
                ndCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                ndCell.InnerText = "<img align=\"absmiddle\" src=\"/_layouts/images/16fold.gif\"/> <label>" + folder.Name + "</label>";
                ndView.AppendChild(ndCell);

                if (folder.Files.Count > 0)
                {
                    ArrayList fileList = new ArrayList(folder.Files);
                    IComparer compFiles = new SPFilesComparer();
                    fileList.Sort(compFiles);

                    for (int i = 0; i < fileList.Count; i++)
                    {
                        SPFile file = (SPFile)(fileList[i]);

                        if (file != null)
                        {
                            XmlNode ndDoc = doc.CreateNode(XmlNodeType.Element, "row", doc.NamespaceURI);
                            XmlNode ndUserdata = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            XmlAttribute attrName = doc.CreateAttribute("name");
                            attrName.Value = "ViewTitle";
                            ndUserdata.Attributes.Append(attrName);
                            ndUserdata.InnerText = file.Item.DisplayName;

                            XmlNode ndUserdata2 = doc.CreateNode(XmlNodeType.Element, "userdata", doc.NamespaceURI);
                            XmlAttribute attrName2 = doc.CreateAttribute("name");
                            attrName2.Value = "ViewRelativeUrl";
                            ndUserdata2.Attributes.Append(attrName2);
                            ndUserdata2.InnerText = file.ServerRelativeUrl;

                            ndCell = doc.CreateNode(XmlNodeType.Element, "cell", doc.NamespaceURI);
                            ndCell.InnerText = "<img align=\"absmiddle\"   src=\"/_layouts/IMAGES/" + file.IconUrl + "\"/> <a href=\"#\">" + file.Item.DisplayName + "</a>";
                            ndDoc.AppendChild(ndUserdata);
                            ndDoc.AppendChild(ndUserdata2);
                            ndDoc.AppendChild(ndCell);
                            ndView.AppendChild(ndDoc);
                        }
                    }
                    parentNode.AppendChild(ndView);
                }
                if (folder.SubFolders.Count > 0)
                {
                    foreach (SPFolder subFolder in folder.SubFolders)
                    {
                        AddDocuments(subFolder, doc, ndView);
                    }
                }
            }
        }

        private class SPFilesComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return new CaseInsensitiveComparer().Compare(((SPFile)x).Name, ((SPFile)y).Name);
            }
        }
    }
}
