using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class SaveDataJobExecuteCacheTest
    {
        private IDisposable _shimsContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void CacheShouldBeNullByDefault()
        {
            SaveDataJobExecuteCache.Cache.ShouldBeNull();
        }

        [TestMethod]
        public void ShouldInitializeCacheAndClearOnDispose()
        {
            var siteMock = new ShimSPSite();
            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                cache.ShouldSatisfyAllConditions(
                    () => cache.ShouldNotBeNull(),
                    () => cache.ShouldBe(SaveDataJobExecuteCache.Cache),
                    () => cache.Site.ShouldBe(siteMock));
            }

            SaveDataJobExecuteCache.Cache.ShouldBeNull();
        }

        [TestMethod]
        public void ShouldReturnOriginalSiteForNonElevated()
        {
            var siteMock = new ShimSPSite();
            using (SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var site = SaveDataJobExecuteCache.GetSiteFromCache(false, () =>
                {
                    Assert.Fail();
                    return null;
                });

                site.ShouldBe(siteMock);
            }
        }

        [TestMethod]
        public void ShouldCallCallbackIfNoCache()
        {
            var siteMock = new ShimSPSite();
            var site = SaveDataJobExecuteCache.GetSiteFromCache(false, () => siteMock);
            site.ShouldBe(siteMock);

            site = SaveDataJobExecuteCache.GetSiteFromCache(true, () => siteMock);
            site.ShouldBe(siteMock);
        }

        [TestMethod]
        public void ShouldReturnElevatedOnRequest()
        {
            var siteMock = new ShimSPSite();
            ShimSPSite siteMockElevated = null;
            ShimSPSite.ConstructorGuid = (site, guid) => { siteMockElevated = new ShimSPSite(site); };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = cb => cb();
            using (SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var site = SaveDataJobExecuteCache.GetSiteFromCache(true, () =>
                {
                    Assert.Fail();
                    return null;
                });

                site.ShouldSatisfyAllConditions(
                    () => site.ShouldNotBeNull(),
                    () => site.ShouldBe(siteMockElevated),
                    () => site.ShouldNotBe(siteMock));
            }
        }

        [TestMethod]
        public void ShouldDisposeSiteIfNotCached()
        {
            var siteMock = new ShimSPSite();
            var disposed = false;
            siteMock.Dispose = () => disposed = true;

            SaveDataJobExecuteCache.DisposeSite(siteMock);

            disposed.ShouldBe(true);
        }

        [TestMethod]
        public void ShouldNotDisposeCachedSite()
        {
            var siteMock = new ShimSPSite();
            var disposed = false;
            siteMock.Dispose = () => disposed = true;

            using (SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                SaveDataJobExecuteCache.DisposeSite(siteMock);
            }

            disposed.ShouldBe(false);
        }

        [TestMethod]
        public void ShouldReturnCachedWeb()
        {
            var siteMock = new ShimSPSite();
            const string TestUrl = "test/url";
            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl };
            siteMock.OpenWebGuid  = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var properties = new ShimSPItemEventProperties { RelativeWebUrlGet = () => TestUrl };
                var webById = cache.GetWeb(Guid.Empty.ToString());
                var web = SaveDataJobExecuteCache.GetWeb(properties);

                web.ShouldBe(webById);
            }
        }

        [TestMethod]
        public void ShouldReturnWebFromPropertiesIfNoCache()
        {
            var webMock = new ShimSPWeb();

            var properties = new ShimSPItemEventProperties { WebGet = () => webMock };
            var web = SaveDataJobExecuteCache.GetWeb(properties);

            web.ShouldBe(webMock);
        }

        [TestMethod]
        public void ShouldReturnCachedList()
        {
            var siteMock = new ShimSPSite();
            const string TestUrl = "test/url";
            var listMock = new ShimSPList();
            var listCollection = new ShimSPListCollection { ItemGetGuid = _ => listMock };

            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl, ListsGet = () => listCollection };
            siteMock.OpenWebGuid = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var properties = new ShimSPItemEventProperties { RelativeWebUrlGet = () => TestUrl };
                var webById = cache.GetWeb(Guid.Empty.ToString());
                var list = SaveDataJobExecuteCache.GetList(properties);

                webById.ShouldNotBeNull();
                list.ShouldBe(listMock);
            }
        }

        [TestMethod]
        public void ShouldReturnListFromPropertiesIfNoCache()
        {
            var listMock = new ShimSPList();

            var properties = new ShimSPItemEventProperties { ListGet = () => listMock };
            var list = SaveDataJobExecuteCache.GetList(properties);

            list.ShouldBe(listMock);
        }

        [TestMethod]
        public void ShouldReturnListItemFromPropertiesIfNoCache()
        {
            var listItemMock = new ShimSPListItem();

            var properties = new ShimSPItemEventProperties { ListItemGet = () => listItemMock };
            var listItem = SaveDataJobExecuteCache.GetListItem(properties);

            listItem.ShouldBe(listItemMock);
        }

        [TestMethod]
        public void ShouldReturnListItemFromCache()
        {
            var webId = Guid.NewGuid();
            var listId = Guid.NewGuid();
            const int ItemId = 1;

            var siteMock = new ShimSPSite();
            
            var listItemMock = new ShimSPListItem();
            var listItemCollection = new ShimSPListItemCollection { GetItemByIdInt32 = _ => listItemMock };
            var listMock = new ShimSPList { GetItemsSPQuery = _ => listItemCollection, IDGet = () => listId };
            var listCollection = new ShimSPListCollection { ItemGetGuid = _ => listMock };

            const string TestUrl = "test/url";
            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl, ListsGet = () => listCollection };
            siteMock.OpenWebGuid = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var result = cache.PreloadListItems(new[]
                {
                    new SaveDataJobExecuteCache.ListItemInfo
                    {
                        WebId = webId.ToString(),
                        ListId = listId.ToString(),
                        ListItemId = ItemId.ToString()
                    }
                });

                result.Item1.ShouldBe(false);

                var properties = new ShimSPItemEventProperties
                {
                    RelativeWebUrlGet = () => TestUrl, 
                    ListIdGet = () => listId, 
                    ListItemIdGet = () => ItemId
                };
                var listItem = SaveDataJobExecuteCache.GetListItem(properties);
                listItem.ShouldBe(listItemMock);
            }
        }
    }
}
