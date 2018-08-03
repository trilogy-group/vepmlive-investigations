using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using System.Web.Fakes;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Tests.Helpers;
using EPMLiveWebParts.SSRS2006.Fakes;
using EPMLiveWebParts.SSRS2006;
using System.Security.Principal;
using Moq;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    public class ReportsCenterTest
    {
        private const string MethodPopulateTree = "populateTree";
        private const string TreeNodeFolderImage = "/_layouts/images/16fold.gif";
        private const string TreeNodeFileImage = "/_layouts/images/16doc.gif";
        private const string WebUrl = "www.weburl.com/SP";
        private const string ServerRelativeUrl = "/SP";
        private const string FieldWeb = "web";
        private const string FieldCurrentWeb = "curWeb";
        private const string FieldParametersSSRS2006 = "parametersSSRS2006";
        private const string RdlExtension = ".rdl";
        private const string ReportParamNameUrl = "URL";
        private const string ReportParamNameSiteId = "SiteId";
        private const string ReportParamNameWebId = "WebId";
        private const string ReportParamNameUserId = "UserId";
        private const string ReportParamNameUsername = "Username";
        private const string ReportParamTemplate = "&rp:{0}={1}";
        private const string Username = "Tsubasa";
        private const int UserId = 10;
        private static readonly Guid SpSiteId = Guid.NewGuid();
        private static readonly Guid SpWebId = Guid.NewGuid();
        private IDisposable _shimsContext;
        private ReportsCenter _testEntity;
        private PrivateObject _testEntityPrivate;
        private SPWeb _webField;
        private SPWeb _curWebField;
        private SPContext _spContextCurrent;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            InitializeSharePoint();
            InitializeAspNet();

            _testEntity = new ReportsCenter();
            _testEntityPrivate = new PrivateObject(_testEntity);

            _webField = _spContextCurrent.Web;
            _curWebField = _spContextCurrent.Web;
            _testEntityPrivate.SetField(FieldWeb, _webField);
            _testEntityPrivate.SetField(FieldCurrentWeb, _curWebField);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_shimsContext != null)
            {
                _shimsContext.Dispose();
            }

            if (_testEntity != null)
            {
                _testEntity.Dispose();
            }
        }

        [TestMethod]
        public void PopulateTree_IfListItemIsFolder_CallsPopulateTreeRecursively()
        {
            // Arrange
            var folder01 = new SpListItemDefinition()
            {
                Name = "Folder01 Name",
                Title = "Folder01 Title",
                Url = string.Empty,
                UniqueId = Guid.NewGuid()
            };

            var file01 = new SpListItemDefinition()
            {
                Name = "File01.rdl",
                Title = "File01 Title",
                Url = "File01Url",
                UniqueId = Guid.NewGuid()
            };

            var file02 = new SpListItemDefinition()
            {
                Name = "File02.rdl",
                Title = string.Empty,
                Url = "File02Url",
                UniqueId = Guid.NewGuid()
            };

            var folders = CreateSpListItems(SPFileSystemObjectType.Folder, folder01);
            var files = CreateSpListItems(SPFileSystemObjectType.File, file01, file02);
            var allItems = folders.Concat(files);

            ShimReportsCenter.AllInstances.RSString = (instance, url) => url;

            var shimListItems = CreateShimSpListItemCollection(folders);
            var shimSpDoc = CreateShimSpDoc(allItems);
            var treeNode = new TreeNode();

            // Act
            _testEntityPrivate.Invoke(MethodPopulateTree, shimListItems.Instance, shimSpDoc.Instance, treeNode);

            // Assert
            treeNode.ShouldSatisfyAllConditions(
                () => treeNode.ChildNodes.Count.ShouldBe(1),
                () =>
                {
                    var folderNode = treeNode.ChildNodes[0];
                    folderNode.Text.ShouldBe(string.Format("<b>{0}</b>", folder01.Title));
                    folderNode.SelectAction = TreeNodeSelectAction.None;
                    folderNode.ImageUrl.ShouldBe(TreeNodeFolderImage);
                },
                () => treeNode.ChildNodes[0].ChildNodes.Count.ShouldBe(2),
                () =>
                {
                    var expectedNavigateUrl = string.Format("Javascript:window.open('{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={0}/{1}{2}&rv:HeaderArea=none','',config='toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');void(0);",
                                                            ServerRelativeUrl,
                                                            file01.Url,
                                                            string.Format("{0}/{1}",
                                                            _webField.Url, file01.Url));
                    var file01Node = treeNode.ChildNodes[0].ChildNodes[0];
                    file01Node.Text.ShouldBe(file01.Title);
                    file01Node.ImageUrl.ShouldBe(TreeNodeFileImage);
                    file01Node.NavigateUrl.ShouldBe(expectedNavigateUrl);
                },
                () =>
                {
                    var file02Node = treeNode.ChildNodes[0].ChildNodes[1];
                    file02Node.Text.ShouldBe(file02.Name.Replace(RdlExtension, string.Empty));
                    file02Node.ImageUrl.ShouldBe(TreeNodeFileImage);
                });
        }

        [TestMethod]
        public void PopulateTree_IfExceptionOccurs_AddsErrorTreeNode()
        {
            // Arrange
            var item01 = new SpListItemDefinition()
            {
                Name = "ItemName",
                Title = "ItemTitle",
                Url = string.Empty,
                UniqueId = Guid.NewGuid()
            };

            var files = CreateSpListItems(SPFileSystemObjectType.Folder, item01);

            ShimReportsCenter.AllInstances.RSString = (instance, url) => url;

            var shimListItems = CreateShimSpListItemCollection(files);
            var shimSpDoc = CreateShimSpDoc(files);
            var treeNode = new TreeNode();

            const string exceptionMessage = "Error raised";
            shimSpDoc.GetItemsInFolderSPViewSPFolder = (_, __) =>
            {
                throw new InvalidOperationException(exceptionMessage);
            };

            var expectedNodeText = string.Format("{0} <img src=\"/_layouts/epmlive/images/warning.png\" alt=\"{1}\">",
                                                 item01.Name,
                                                 exceptionMessage);

            // Act
            _testEntityPrivate.Invoke(MethodPopulateTree, shimListItems.Instance, shimSpDoc.Instance, treeNode);

            // Assert
            treeNode.ShouldSatisfyAllConditions(
                () => treeNode.ChildNodes.Count.ShouldBe(1),
                () => treeNode.ChildNodes[0].ImageUrl.ShouldBe(TreeNodeFileImage),
                () => treeNode.ChildNodes[0].Text.ShouldBe(expectedNodeText),
                () => treeNode.ChildNodes[0].NavigateUrl.ShouldBeEmpty());
        }

        [TestMethod]
        public void Rs_WhenCalled_ReturnsParameters()
        {
            // Arrange
            var reportParameters = new ReportParameter[]
            {
                new ReportParameter() { Name = ReportParamNameUrl, Prompt = string.Empty },
                new ReportParameter() { Name = ReportParamNameSiteId, Prompt = string.Empty },
                new ReportParameter() { Name = ReportParamNameWebId, Prompt = string.Empty },
                new ReportParameter() { Name = ReportParamNameUserId, Prompt = string.Empty },
                new ReportParameter() { Name = ReportParamNameUsername, Prompt = string.Empty }
            };

            ShimReportingService2006.AllInstances.GetReportParametersStringStringParameterValueArrayDataSourceCredentialsArray =
                (instance, url, a, b, c) => reportParameters;

            var expectedParametersString = string.Concat(
                string.Format(ReportParamTemplate, ReportParamNameUrl, _curWebField.ServerRelativeUrl),
                string.Format(ReportParamTemplate, ReportParamNameSiteId, _spContextCurrent.Site.ID),
                string.Format(ReportParamTemplate, ReportParamNameWebId, _spContextCurrent.Web.ID),
                string.Format(ReportParamTemplate, ReportParamNameUserId, UserId),
                string.Format(ReportParamTemplate, ReportParamNameUrl, Username));

            // Act


        }

        private void InitializeSharePoint()
        {
            var shimSpSite = new ShimSPSite() { IDGet = () => SpSiteId };
            var shimSpWeb = new ShimSPWeb()
            {
                IDGet = () => SpWebId,
                UrlGet = () => WebUrl,
                ServerRelativeUrlGet = () => ServerRelativeUrl,
                CurrentUserGet = () => new ShimSPUser()
                {
                    IDGet = () => UserId
                }
            };

            var shimSpContext = new ShimSPContext()
            {
                SiteGet = () => shimSpSite,
                WebGet = () => shimSpWeb
            };

            ShimSPContext.CurrentGet = () => shimSpContext;
            _spContextCurrent = shimSpContext.Instance;
        }

        private void InitializeAspNet()
        {
            ShimHttpUtility.UrlEncodeString = url => url;
            ShimHttpUtility.HtmlEncodeString = url => url;

            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(id => id.Name).Returns(Username);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(pr => pr.Identity).Returns(mockIdentity.Object);

            var shimHttpContext = new ShimHttpContext();
            shimHttpContext.UserGet = () => mockPrincipal.Object;
        }

        private ShimSPListItemCollection CreateShimSpListItemCollection(ICollection<SPListItem> folders)
        {
            var shimListItems = new ShimSPListItemCollection();
            shimListItems.GetEnumerator = () => folders.GetEnumerator();
            return shimListItems;
        }

        private ShimSPDocumentLibrary CreateShimSpDoc(IEnumerable<SPListItem> allItems)
        {
            var shimSpDoc = new ShimSPDocumentLibrary();
            var shimSpDocBase = new ShimSPList(shimSpDoc.Instance);
            shimSpDocBase.GetItemByUniqueIdGuid = uid => allItems.FirstOrDefault(item => item.UniqueId == uid);

            var shimItemsInFolder = new ShimSPListItemCollection();
            shimSpDoc.GetItemsInFolderSPViewSPFolder = (_, __) =>
            {
                var files = allItems.Where(item => item.FileSystemObjectType == SPFileSystemObjectType.File);
                shimItemsInFolder.CountGet = () => files.Count();
                shimItemsInFolder.GetEnumerator = () => files.GetEnumerator();

                return shimItemsInFolder.Instance;
            };

            return shimSpDoc;
        }

        private ICollection<SPListItem> CreateSpListItems(SPFileSystemObjectType objType, params SpListItemDefinition[] itemDefinitions)
        {
            if (itemDefinitions == null)
            {
                throw new ArgumentNullException(nameof(itemDefinitions));
            }

            var items = new List<SPListItem>();
            foreach (var definition in itemDefinitions)
            {
                var shimListItem = new ShimSPListItem()
                {
                    NameGet = () => definition.Name,
                    TitleGet = () => definition.Title,
                    UniqueIdGet = () => definition.UniqueId,
                    UrlGet = () => definition.Url,
                    FileSystemObjectTypeGet = () => objType,
                    FileGet = () =>
                    {
                        var shimFile = new ShimSPFile();
                        shimFile.NameGet = () => definition.Name;
                        return shimFile.Instance;
                    }
                };

                items.Add(shimListItem.Instance);
            }

            return items;
        }
    }
}
