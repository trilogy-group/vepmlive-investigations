using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveWebParts.SSRS2005;
using EPMLiveWebParts.SSRS2006;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using SpWebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    public abstract class ReportWebPartBase : SpWebPart
    {
        private const string ReportParamNameUrl = "URL";
        private const string ReportParamNameSiteId = "SiteId";
        private const string ReportParamNameWebId = "WebId";
        private const string ReportParamNameUserId = "UserId";
        private const string ReportParamNameUsername = "Username";
        private const string ParamTemplate2006 = "&rp:{0}={1}";
        private const string ParamTemplate2005 = "&{0}={1}";
        private const string TreeNodeFolderImage = "/_layouts/images/16fold.gif";
        private const string TreeNodeFileImage = "/_layouts/images/16doc.gif";
        private const string ReportsFolderTopListValue = "/epmlivetl";
        private const string ReportsFolderValue = "/epmlive";
        private const string BoldTextTemplate = "<b>{0}</b>";
        private const string RdlFileExtension = ".rdl";
        private const int FileExtensionLength = 4;

        private string _reportsFolderName = string.Empty;
        private string _reportsPath = string.Empty;
        private bool? _useDefaults;
        private string _srsUrl;
        protected string ReportsRootFolderName = string.Empty;
        protected ReportingService2005 srs2005;
        protected ReportingService2006 srs2006;
        protected SPWeb web;
        protected SPWeb curWeb;
        protected bool isTopList;

        protected abstract void PopulateTree(SPListItemCollection listItems, SPDocumentLibrary doc, TreeNode treeNode);
        protected abstract string GetFileNodeNavigationUrl(SPListItem item);
        protected abstract string GetFileNodeErrorText(SPListItem item, Exception exception);

        public string ReportsFolderName
        {
            get
            {
                if (_reportsFolderName == string.Empty)
                {
                    if (isTopList)
                    {
                        _reportsFolderName = string.Concat(ReportsRootFolderName, ReportsFolderTopListValue);
                    }
                    else
                    {
                        _reportsFolderName = string.Concat(ReportsRootFolderName, ReportsFolderValue);
                    }
                }

                return _reportsFolderName;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Reports Path")]
        [Description("Use this option if your reports are not installed in the root directory. Path must start with a '/'")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropReportsPath")]
        public string PropReportsPath
        {
            get
            {
                if (_reportsPath == null)
                {
                    return string.Empty;
                }

                return _reportsPath;
            }
            set
            {
                _reportsPath = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Use Application Defaults")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "UseDefaults")]
        public bool UseDefaults
        {
            get
            {
                if (_useDefaults == null)
                {
                    return PropSRSUrl == string.Empty && PropReportsPath == string.Empty;
                }
                else
                {
                    return _useDefaults.Value;
                }
            }
            set
            {
                _useDefaults = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("SQL Reporting Services URL")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropSRSUrl")]
        public string PropSRSUrl
        {
            get
            {
                return _srsUrl == null ? string.Empty : _srsUrl;
            }
            set
            {
                _srsUrl = value;
            }
        }

        protected string Get2006Parameters(string url)
        {
            var parameters2006 = srs2006.GetReportParameters(url, null, null, null);
            var builder = new StringBuilder();

            foreach (var param in parameters2006)
            {
                if (param.Prompt == string.Empty)
                {
                    AppendParamValue(builder, param.Name, ParamTemplate2006);
                }
            }

            return builder.ToString();
        }

        protected string Get2005Parameters(string url)
        {
            var parameters2005 = srs2005.GetReportParameters(url, null, true, null, null);
            var builder = new StringBuilder();

            foreach (var param in parameters2005)
            {
                if (param.Prompt == string.Empty)
                {
                    AppendParamValue(builder, param.Name, ParamTemplate2005);
                }
            }

            return builder.ToString();
        }

        private void AppendParamValue(StringBuilder paramBuilder, string parameterName, string parameterTemplate)
        {
            if (paramBuilder == null)
            {
                throw new ArgumentNullException("paramBuilder");
            }

            switch (parameterName)
            {
                case ReportParamNameUrl:
                    paramBuilder.AppendFormat(parameterTemplate, ReportParamNameUrl, HttpUtility.UrlEncode(curWeb.ServerRelativeUrl));
                    break;
                case ReportParamNameSiteId:
                    paramBuilder.AppendFormat(parameterTemplate, ReportParamNameSiteId, SPContext.Current.Site.ID);
                    break;
                case ReportParamNameWebId:
                    paramBuilder.AppendFormat(parameterTemplate, ReportParamNameWebId, SPContext.Current.Web.ID);
                    break;
                case ReportParamNameUserId:
                    paramBuilder.AppendFormat(parameterTemplate, ReportParamNameUserId, SPContext.Current.Web.CurrentUser.ID);
                    break;
                case ReportParamNameUsername:
                    paramBuilder.AppendFormat(parameterTemplate, ReportParamNameUsername, HttpContext.Current.User.Identity.Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Unexpected value: {0}", parameterName));
            }
        }

        protected TreeNode CreateTreeNode(SPListItem item, SPDocumentLibrary doc)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }

            var node = new TreeNode(item.Name, item.UniqueId.ToString());
            var spListItem = doc.GetItemByUniqueId(item.UniqueId);

            if (!string.IsNullOrWhiteSpace(spListItem.Title))
            {
                node.Text = spListItem.Title;
            }

            if (item.FileSystemObjectType == SPFileSystemObjectType.Folder)
            {
                node.Text = string.Format(BoldTextTemplate, node.Text);
                node.SelectAction = TreeNodeSelectAction.None;
                node.ImageUrl = TreeNodeFolderImage;

                var folderItems = doc.GetItemsInFolder(doc.DefaultView, item.Folder);
                if (folderItems.Count > 0)
                {
                    PopulateTree(folderItems, doc, node);
                }
            }
            else if (item.FileSystemObjectType == SPFileSystemObjectType.File &&
                     item.File.Name.EndsWith(RdlFileExtension, StringComparison.OrdinalIgnoreCase))
            {
                if (node.Text.EndsWith(RdlFileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    node.Text = node.Text.Substring(0, node.Text.Length - FileExtensionLength);
                }

                node.ImageUrl = TreeNodeFileImage;

                try
                {
                    node.NavigateUrl = GetFileNodeNavigationUrl(item);
                }
                catch (Exception ex)
                {
                    node.Text = GetFileNodeErrorText(item, ex);
                    Trace.TraceError(ex.ToString());
                }
            }

            return node;
        }
    }
}