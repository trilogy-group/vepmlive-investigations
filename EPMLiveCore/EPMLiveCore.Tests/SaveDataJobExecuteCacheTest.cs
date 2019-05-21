using System;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
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
                var site = SaveDataJobExecuteCache.GetSiteFromCache(Guid.Empty, false, () =>
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
            var site = SaveDataJobExecuteCache.GetSiteFromCache(Guid.Empty, false, () => siteMock);
            site.ShouldBe(siteMock);

            site = SaveDataJobExecuteCache.GetSiteFromCache(Guid.Empty, true, () => siteMock);
            site.ShouldBe(siteMock);
        }

        [TestMethod]
        public void ShouldCallCallbackIfSiteOfDifferentId()
        {
            using (SaveDataJobExecuteCache.InitializeCache(new ShimSPSite()))
            {
                var siteId = Guid.NewGuid();
                var siteMock = new ShimSPSite { IDGet = () => siteId };
                var site = SaveDataJobExecuteCache.GetSiteFromCache(siteId, false, () => siteMock);
                site.ShouldBe(siteMock);

                site = SaveDataJobExecuteCache.GetSiteFromCache(siteId, true, () => siteMock);
                site.ShouldBe(siteMock);
            }
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
                var site = SaveDataJobExecuteCache.GetSiteFromCache(Guid.Empty, true, () =>
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
        public void ShouldReturnListFromPropertiesIfItIsNotFoundInCache()
        {
            var siteMock = new ShimSPSite();
            const string TestUrl = "test/url";
            var listMock = new ShimSPList();

            using (SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                var properties = new ShimSPItemEventProperties { RelativeWebUrlGet = () => TestUrl, ListGet = () => listMock };
                var list = SaveDataJobExecuteCache.GetList(properties);

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
            
            var listItemMock = new ShimSPListItem { IDGet = () => ItemId };
            var listItemCollection = new ShimSPListItemCollection { GetEnumerator = () => Enumerable.Repeat<SPListItem>(listItemMock, 1).GetEnumerator() };
            var listMock = new ShimSPList { GetItemsSPQuery = _ => listItemCollection, IDGet = () => listId };
            var listCollection = new ShimSPListCollection { ItemGetGuid = _ => listMock };

            const string TestUrl = "test/url";
            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl, ListsGet = () => listCollection };
            siteMock.OpenWebGuid = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                string preloadErrors;
                var preloadHasErrors =
                    cache.PreloadListItems(new[]
                    {
                        new SaveDataJobExecuteCache.ListItemInfo
                        {
                            WebId = webId.ToString(),
                            ListId = listId.ToString(),
                            ListItemId = ItemId.ToString()
                        }
                    }, out preloadErrors);

                preloadHasErrors.ShouldBe(false);
                preloadErrors.ShouldBe(string.Empty);

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

        [TestMethod]
        public void ShouldReturnListItemFromPropertiesIfListIsNotInCache()
        {
            var webId = Guid.NewGuid();
            var listId = Guid.NewGuid();
            var list2Id = Guid.NewGuid();
            const int ItemId = 1;

            var siteMock = new ShimSPSite();

            var listMock = new ShimSPList
            {
                GetItemsSPQuery = _ => new ShimSPListItemCollection { GetEnumerator = () => Enumerable.Empty<SPListItem>().GetEnumerator() },
                IDGet = () => listId
            };
            var listCollection = new ShimSPListCollection { ItemGetGuid = _ => listMock };

            const string TestUrl = "test/url";
            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl, ListsGet = () => listCollection };
            siteMock.OpenWebGuid = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                string preloadErrors;
                var preloadHasErrors = cache.PreloadListItems(new[]
                {
                    new SaveDataJobExecuteCache.ListItemInfo
                    {
                        WebId = webId.ToString(),
                        ListId = listId.ToString(),
                        ListItemId = ItemId.ToString()
                    }
                }, out preloadErrors);

                preloadHasErrors.ShouldBe(false);
                preloadErrors.ShouldBe(string.Empty);

                var listItemMock = new ShimSPListItem();
                var properties = new ShimSPItemEventProperties
                {
                    RelativeWebUrlGet = () => TestUrl,
                    ListIdGet = () => list2Id,
                    ListItemIdGet = () => ItemId,
                    ListItemGet = () => listItemMock
                };
                var listItem = SaveDataJobExecuteCache.GetListItem(properties);
                listItem.ShouldBe(listItemMock);
            }
        }

        [TestMethod]
        public void ShouldReloadListItemOnRequest()
        {
            var webId = Guid.NewGuid();
            var listId = Guid.NewGuid();
            const int ItemId = 1;

            var siteMock = new ShimSPSite();

            var listItemMock = new ShimSPListItem { IDGet = () => ItemId };
            var listItemMockNew = new ShimSPListItem { IDGet = () => ItemId };
            var listItemCollection = new ShimSPListItemCollection { GetEnumerator = () => Enumerable.Repeat<SPListItem>(listItemMock, 1).GetEnumerator() };
            var listMock = new ShimSPList
            {
                GetItemsSPQuery = _ => listItemCollection, IDGet = () => listId, GetItemByIdInt32 = _ => listItemMockNew
            };
            var listCollection = new ShimSPListCollection { ItemGetGuid = _ => listMock };

            const string TestUrl = "test/url";
            var webMock = new ShimSPWeb { ServerRelativeUrlGet = () => TestUrl, ListsGet = () => listCollection };
            siteMock.OpenWebGuid = guid => webMock;

            using (var cache = SaveDataJobExecuteCache.InitializeCache(siteMock))
            {
                string preloadErrors;
                var preloadHasErrors =
                    cache.PreloadListItems(new[]
                    {
                        new SaveDataJobExecuteCache.ListItemInfo
                        {
                            WebId = webId.ToString(),
                            ListId = listId.ToString(),
                            ListItemId = ItemId.ToString()
                        }
                    }, out preloadErrors);

                preloadHasErrors.ShouldBe(false);
                preloadErrors.ShouldBe(string.Empty);

                var listItem = SaveDataJobExecuteCache.Cache.GetListItem(TestUrl, listId, ItemId, refresh: true);
                listItem.ShouldBe(listItemMockNew);

                listItem = SaveDataJobExecuteCache.Cache.GetListItem(TestUrl, listId, ItemId);
                listItem.ShouldBe(listItemMockNew);
            }
        }
    }
}
