using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Tests.Helpers;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI.WebControls;
using Shouldly;

namespace EPMLiveWebParts.Tests
{
    [TestClass]
    public class ReportViewerTest
    {
        private const string MethodPopulateTree = "populateTree";
        private const string TreeNodeFolderImage = "/_layouts/images/16fold.gif";
        private const string TreeNodeFileImage = "/_layouts/images/16doc.gif";
        private const string WebUrl = "www.weburl.com/SP";
        private const string ServerRelativeUrl = "/SP";
        private const string FieldWeb = "web";
        private const string RdlExtension = ".rdl";
        private IDisposable _shimsContext;
        private ReportViewer _testEntity;
        private PrivateObject _testEntityPrivate;
        private SPWeb _web;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new ReportViewer();
            _testEntityPrivate = new PrivateObject(_testEntity);

            var shimSpWeb = new ShimSPWeb();
            shimSpWeb.UrlGet = () => WebUrl;
            shimSpWeb.ServerRelativeUrlGet = () => ServerRelativeUrl;

            _web = shimSpWeb.Instance;
            _testEntityPrivate.SetField(FieldWeb, _web);

            ShimHttpUtility.UrlEncodeString = url => url;
            ShimHttpUtility.HtmlEncodeString = url => url;
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

            ShimReportViewer.AllInstances.RSString = (instance, url) => url;

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
                    var expectedNavigateUrl = string.Format("Javascript:frameview(\"{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={0}/{1}{2}&rv:HeaderArea=none\");",
                                                            ServerRelativeUrl,
                                                            file01.Url,
                                                            string.Format("{0}/{1}",
                                                            _web.Url, file01.Url));
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
