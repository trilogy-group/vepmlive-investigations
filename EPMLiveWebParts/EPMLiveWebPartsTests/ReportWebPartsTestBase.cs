using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Fakes;
using EPMLiveWebParts.Tests.Helpers;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPMLiveWebParts.Tests
{
    public abstract class ReportWebPartsTestBase<TReportTool> where TReportTool : WebPart, new()
    {
        protected static readonly string MethodPopulateTree = "PopulateTree";
        protected static readonly string MethodGet2006Parameters = "Get2006Parameters";
        protected static readonly string MethodGet2005Parameters = "Get2005Parameters";
        protected static readonly string TreeNodeFolderImage = "/_layouts/images/16fold.gif";
        protected static readonly string TreeNodeFileImage = "/_layouts/images/16doc.gif";
        protected static readonly string WebUrl = "www.weburl.com/SP";
        protected static readonly string ServerRelativeUrl = "/SP";
        protected static readonly string FieldWeb = "web";
        protected static readonly string FieldCurrentWeb = "curWeb";
        protected static readonly string FieldParametersSSRS2006 = "parametersSSRS2006";
        protected static readonly string FieldSrs2006 = "srs2006";
        protected static readonly string FieldSrs2005 = "srs2005";
        protected static readonly string FieldReportsFolderName = "_reportsFolderName";
        protected static readonly string FieldIsTopList = "isTopList";
        protected static readonly string FieldReportsRootFolderName = "ReportsRootFolderName";
        protected static readonly string FieldReportsPath = "_reportsPath";
        protected static readonly string FieldSRSUrl = "_srsUrl";
        protected static readonly string FieldUseDefaults = "_useDefaults";
        protected static readonly string RdlExtension = ".rdl";
        protected static readonly string ReportParamNameUrl = "URL";
        protected static readonly string ReportParamNameSiteId = "SiteId";
        protected static readonly string ReportParamNameWebId = "WebId";
        protected static readonly string ReportParamNameUserId = "UserId";
        protected static readonly string ReportParamNameUsername = "Username";
        protected static readonly string ReportParam2006Template = "&rp:{0}={1}";
        protected static readonly string ReportParam2005Template = "&{0}={1}";
        protected static readonly string Username = "Tsubasa";
        protected static readonly string ReportsRootFolderName = "ReportsRoot";
        protected static readonly int UserId = 10;
        protected static readonly Guid SpSiteId = Guid.NewGuid();
        protected static readonly Guid SpWebId = Guid.NewGuid();

        protected IDisposable _shimsContext;
        protected TReportTool _testEntity;
        protected PrivateObject _testEntityPrivate;
        protected PrivateObject _testEntityBasePrivate;
        protected SPWeb _webField;
        protected SPWeb _curWebField;
        protected SPContext _spContextCurrent;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            InitializeSharePoint();
            InitializeAspNet();
            InitializeTestEntity();
        }

        [TestCleanup]
        public virtual void TestCleanup()
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

        protected virtual void InitializeSharePoint()
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

        protected virtual void InitializeAspNet()
        {
            ShimHttpUtility.UrlEncodeString = url => url;
            ShimHttpUtility.HtmlEncodeString = url => url;

            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(id => id.Name).Returns(Username);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(pr => pr.Identity).Returns(mockIdentity.Object);

            var shimHttpContext = new ShimHttpContext();
            shimHttpContext.UserGet = () => mockPrincipal.Object;

            ShimHttpContext.CurrentGet = () => shimHttpContext.Instance;
        }

        protected virtual void InitializeTestEntity()
        {
            _testEntity = new  TReportTool();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _testEntityBasePrivate = new PrivateObject(_testEntity, new PrivateType(typeof(ReportWebPartBase)));

            _webField = _spContextCurrent.Web;
            _curWebField = _spContextCurrent.Web;
            _testEntityPrivate.SetField(FieldWeb, _webField);
            _testEntityPrivate.SetField(FieldCurrentWeb, _curWebField);
            _testEntityPrivate.SetField(FieldReportsRootFolderName, ReportsRootFolderName);
        }

        protected virtual ShimSPListItemCollection CreateShimSpListItemCollection(ICollection<SPListItem> folders)
        {
            if (folders == null)
            {
                throw new ArgumentNullException("folders");
            }

            var shimListItems = new ShimSPListItemCollection();
            shimListItems.GetEnumerator = () => folders.GetEnumerator();
            return shimListItems;
        }

        protected virtual ShimSPDocumentLibrary CreateShimSpDoc(IEnumerable<SPListItem> allItems)
        {
            if (allItems == null)
            {
                throw new ArgumentNullException("allItems");
            }

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

        protected virtual ICollection<SPListItem> CreateSpListItems(SPFileSystemObjectType objType, params SpListItemDefinition[] itemDefinitions)
        {
            if (itemDefinitions == null)
            {
                throw new ArgumentNullException("itemDefinitions");
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
