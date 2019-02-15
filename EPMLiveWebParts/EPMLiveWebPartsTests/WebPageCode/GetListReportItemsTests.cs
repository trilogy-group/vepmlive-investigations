using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.Services.Protocols.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveCore.Fakes;
using EPMLiveCore.SSRS2010;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass]
    public class GetListReportItemsTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string DummyPassword = "123456";
        private const string Username = "Username";
        private const string ExampleUrl = "http://example.com";
        private const string FooUrl = "http://foo.com";
        private const string RootNode = "RootNode";
        private const string ReportImage = "/_layouts/images/16doc.gif";
        private const string TypeReport = "Report";
        private const string TypeFolder = "Folder";
        private const string TypeTextXml = "text\\xml";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodGetItemsNativeMode = "GetItemsNativeMode";
        private getlistreportitems _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _parametersBuilder;
        private StringBuilder _responseBuilder;
        private string _resultContentType;
        private static readonly Guid DefaultSiteId = Guid.NewGuid();

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new getlistreportitems();
            _privateObject = new PrivateObject(_testObject);

            _parametersBuilder = new StringBuilder();
            _responseBuilder = new StringBuilder();

            SetupSPContext();

            ShimCoreFunctions.getWebAppSettingGuidString = (_, config) =>
            {
                switch (config)
                {
                    case "ReportingServicesURL":
                        return ExampleUrl;
                    case "ReportsWindowsAuthentication":
                        return bool.TrueString;
                    default:
                        return DummyPassword;
                }
            };
            ShimCoreFunctions.DecryptStringString = (_, config) => DummyPassword;
            ShimSoapHttpClientProtocol.AllInstances.InvokeStringObjectArray =
                (a, b, c) => new object[]
                {
                    new CatalogItem[]
                    {
                        new CatalogItem()
                    }
                };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void OnLoad_IsSsrs_FillsResponse()
        {
            // Arrange
            SetupPageRequest(true, false);

            // Act
            _privateObject.Invoke(MethodOnLoad, new object[] { EventArgs.Empty });

            // Assert
            var result = _responseBuilder.ToString();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<rows><head><settings><colwidth>%</colwidth></settings><column type=\"tree\" width=\"*\"></column></head>"),
                () => result.ShouldContainWithoutWhitespace("<row><cell>&lt;img align=\"absmiddle\" src=\"http://example.com/_layouts/images/itdl.png\" style=\"display:inline;margin:0px 8px 0px 0px;\" /&gt;Reporting Services Reports</cell><row>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\" src=\"/_layouts/images/16fold.gif\"/&gt; &lt;label&gt;DummyString&lt;/label&gt;</cell>"),
                () => result.ShouldContainWithoutWhitespace("<row><userdata name=\"ViewTitle\">DummyString</userdata>"),
                () => result.ShouldContainWithoutWhitespace($"<userdata name=\"ViewRelativeUrl\">http://example.com/_layouts/epmlive/SSRSNativeReportViewer.aspx?itemurl=/{DefaultSiteId}/Report+LibraryDummyString&amp;weburl = http%3a%2f%2fexample.com</userdata>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\" src=\"/_layouts/epmlive/DHTML/xgrid/imgs/16doc.gif\"/&gt; &lt;a href=\"#\"&gt;DummyString&lt;/a&gt;</cell></row></row></row></rows>"));
        }

        [TestMethod]
        public void OnLoad_IsSsrsIntegrated_FillsResponse()
        {
            // Arrange
            SetupPageRequest(true, true);

            // Act
            _privateObject.Invoke(MethodOnLoad, new object[] { EventArgs.Empty });

            // Assert
            var result = _responseBuilder.ToString();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<rows><head><settings><colwidth>%</colwidth></settings><column type=\"tree\" width=\"*\"></column></head>"),
                () => result.ShouldContainWithoutWhitespace("<row><cell>&lt;img align=\"absmiddle\" src=\"http://example.com/_layouts/images/itdl.png\" style=\"display:inline;margin:0px 8px 0px 0px;\" /&gt;Reporting Services Reports</cell><row>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\" src=\"/_layouts/images/16fold.gif\"/&gt; &lt;label&gt;DummyString&lt;/label&gt;</cell>"),
                () => result.ShouldContainWithoutWhitespace("<row><userdata name=\"ViewTitle\">DummyString</userdata>"),
                () => result.ShouldContainWithoutWhitespace("<userdata name=\"ViewRelativeUrl\">http://example.com/_layouts/epmlive/SSRSReportRedirect.aspx?weburl=http%3a%2f%2fexample.com&amp;itemurl=Report+LibraryDummyString</userdata>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\" src=\"/_layouts/epmlive/DHTML/xgrid/imgs/16doc.gif\"/&gt; &lt;a href=\"#\"&gt;DummyString&lt;/a&gt;</cell></row></row></row></rows>"));
        }

        [TestMethod]
        public void OnLoad_NotSsrs_FillsResponse()
        {
            // Arrange
            SetupPageRequest(false, false);

            // Act
            _privateObject.Invoke(MethodOnLoad, new object[] { EventArgs.Empty });

            // Assert
            var result = _responseBuilder.ToString();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<rows><head><settings><colwidth>%</colwidth></settings><column type=\"tree\" width=\"*\"></column></head>"),
                () => result.ShouldContainWithoutWhitespace("<row><cell>&lt;img align=\"absmiddle\" src=\"http://example.com\" style=\"display:inline;margin:0px 8px 0px 0px;\" /&gt;DummyString</cell>"),
                () => result.ShouldContainWithoutWhitespace("<row><userdata name=\"ViewTitle\">DummyString</userdata><userdata name=\"ViewRelativeUrl\"></userdata>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\"  src=\"/_layouts/epmlive/DHTML/xgrid/imgs/iReportsLibrary.png\"/&gt; &lt;a href=\"#\"&gt;DummyString&lt;/a&gt;</cell></row></row></rows>"));
        }

        [TestMethod]
        public void OnLoad_NotSsrsIntegrated_FillsResponse()
        {
            // Arrange
            SetupPageRequest(false, true);

            // Act
            _privateObject.Invoke(MethodOnLoad, new object[] { EventArgs.Empty });

            // Assert
            var result = _responseBuilder.ToString();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<rows><head><settings><colwidth>%</colwidth></settings><column type=\"tree\" width=\"*\"></column></head>"),
                () => result.ShouldContainWithoutWhitespace("<row><cell>&lt;img align=\"absmiddle\" src=\"http://example.com\" style=\"display:inline;margin:0px 8px 0px 0px;\" /&gt;DummyString</cell>"),
                () => result.ShouldContainWithoutWhitespace("<row><userdata name=\"ViewTitle\">DummyString</userdata><userdata name=\"ViewRelativeUrl\"></userdata>"),
                () => result.ShouldContainWithoutWhitespace("<cell>&lt;img align=\"absmiddle\"  src=\"/_layouts/epmlive/DHTML/xgrid/imgs/iReportsLibrary.png\"/&gt; &lt;a href=\"#\"&gt;DummyString&lt;/a&gt;</cell></row></row></rows>"));
        }

        [TestMethod]
        public void GetItemsNativeMode_EmptyCatalog_ReturnsDefaultTree()
        {
            // Arrange
            var parameters = new object[] { new TreeNode(), new ShimSPWeb().Instance };

            // Act
            _privateObject.Invoke(MethodGetItemsNativeMode, parameters);

            // Assert
            var node = parameters.First() as TreeNode;
            node.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => node.Text.ShouldBe(RootNode),
                () =>
                {
                    node.ChildNodes.Count.ShouldBe(1);
                    AssertDefaultTreeNode(node.ChildNodes[0]);
                });
        }

        [TestMethod]
        public void GetItemsNativeMode_Report_ReturnsDefaultTree()
        {
            // Arrange
            ShimSoapHttpClientProtocol.AllInstances.InvokeStringObjectArray =
                (a, b, c) => GetCatalogItems();

            var parameters = new object[] { new TreeNode(), new ShimSPWeb().Instance };

            // Act
            _privateObject.Invoke(MethodGetItemsNativeMode, parameters);

            // Assert
            var node = parameters.First() as TreeNode;
            node.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => node.Text.ShouldBe(RootNode),
                () =>
                {
                    node.ChildNodes.Count.ShouldBe(1);
                    var childNode = node.ChildNodes[0];
                    childNode.ShouldSatisfyAllConditions(
                        () => childNode.SelectAction.ShouldBe(TreeNodeSelectAction.None),
                        () => childNode.ImageUrl.ShouldBe("/_layouts/images/16fold.gif"),
                        () =>
                        {
                            childNode.ChildNodes.Count.ShouldBe(1);
                            var lastNode = childNode.ChildNodes[0];
                            lastNode.ShouldSatisfyAllConditions(
                                () => lastNode.Text.ShouldBe(DummyString),
                                () => lastNode.ImageUrl.ShouldBe(ReportImage),
                                () => lastNode.NavigateUrl.ShouldContainWithoutWhitespace($"{ExampleUrl}/_layouts/epmlive/SSRSNativeReportViewer.aspx?itemurl="),
                                () => lastNode.NavigateUrl.ShouldContainWithoutWhitespace($"&weburl = {HttpUtility.UrlEncode(ExampleUrl)}"));
                        });
                });
        }

        private object[] GetCatalogItems()
        {
            return new object[]
            {
                new CatalogItem[]
                {
                    new CatalogItem
                    {
                        Name = DummyString,
                        ID = One,
                        TypeName = TypeFolder,
                        Path = DummyString
                    },
                    new CatalogItem
                    {
                        Name = DummyString,
                        ID = One,
                        TypeName = TypeReport,
                        Path = $"{DummyString}/{DummyString}"
                    }
                }
            };
        }

        private void SetupSPContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPSite.AllInstances.MakeFullUrlString = (_, complement) => $"{ExampleUrl}{complement}";
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.IDGet = _ => DefaultSiteId;

            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "/";
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;

            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPDocumentLibrary().Instance;

            var systemObjectType = SPFileSystemObjectType.File;
            var fileItem = new ShimSPListItem
            {
                NameGet = () => DummyString,
                TitleGet = () => DummyString,
                UniqueIdGet = () => Guid.NewGuid(),
                UrlGet = () => $"Report Library{DummyString}",
                FolderGet = () => new ShimSPFolder(),
                FileGet = () => new ShimSPFile(),
                FileSystemObjectTypeGet = () => systemObjectType
            };
            var items = new SPListItem[] { fileItem };
            var itemCollection = new ShimSPListItemCollection();
            itemCollection.Bind(items);
            ShimSPList.AllInstances.FoldersGet = _ => itemCollection;
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder();
            ShimSPList.AllInstances.GetItemByUniqueIdGuid = (_, __) => fileItem;
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection().Bind(new SPView[] { new ShimSPView() });

            ShimSPListItem.AllInstances.UrlGet = _ => FooUrl;

            ShimSPView.AllInstances.TitleGet = _ => DummyString;

            ShimSPDocumentLibrary.AllInstances.GetItemsInFolderSPViewSPFolder = (a, b, c) =>
            {
                systemObjectType = SwitchType(systemObjectType);
                return itemCollection;
            };

            ShimSPFile.AllInstances.NameGet = _ => $"{DummyString}.rdl";

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPPersistedObject.AllInstances.GetChildOf1String((_, __) => new ReportAuth
            {
                Username = Username,
                Password = DummyPassword
            });
        }

        private SPFileSystemObjectType SwitchType(SPFileSystemObjectType currentType)
        {
            return currentType == SPFileSystemObjectType.File
                ? SPFileSystemObjectType.Folder
                : SPFileSystemObjectType.File;
        }

        private void SetupPageRequest(bool isSsrs, bool isIntegrated)
        {
            var data = GetPageParameters(isSsrs, isIntegrated);
            var encryptedData = Convert.ToBase64String(Encoding.ASCII.GetBytes(data));

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();

            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => encryptedData;
            ShimHttpResponse.AllInstances.ContentTypeSetString = (_, type) => _resultContentType = type;
            ShimHttpResponse.AllInstances.WriteString = (_, content) => _responseBuilder.Append(content);
        }

        private string GetPageParameters(bool isSsrs, bool isIntegrated)
        {
            AddToParameters("DisplayListNames", "key::value|anotherkey::value");
            AddToParameters("ViewLists", "_viewLists");
            AddToParameters("ReportsRootFolderName", string.Empty);
            AddToParameters("ReportingServicesUrl", "_reportingServicesUrl");
            AddToParameters("ReportsFolderName", "_reportsFolderName");
            AddToParameters("IsSSRS", isSsrs.ToString());
            AddToParameters("Integrated", isIntegrated.ToString());
            return _parametersBuilder.ToString();
        }

        private void AddToParameters(string key, string value)
        {
            if (_parametersBuilder == null)
            {
                _parametersBuilder = new StringBuilder();
            }

            _parametersBuilder.AppendLine($"{key}^{value}");
        }

        private void AssertDefaultTreeNode(TreeNode node)
        {
            node.ShouldNotBeNull();
            node.ShouldSatisfyAllConditions(
                () => node.ImageUrl.ShouldBe(ReportImage),
                () => node.Text.ShouldContain(" <img src=\"/_layouts/epmlive/images/warning.png\" alt=\""),
                () => node.NavigateUrl.ShouldBe(string.Empty),
                () => node.ChildNodes.Count.ShouldBe(0));

        }
    }
}
