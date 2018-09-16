using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AppSettingsHelperTests
    {
        private AppSettingsHelper testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;
        private Guid guid;
        private ShimSPSite spSite;
        private ShimSPWeb spWeb;
        private ShimSPList spList;
        private ShimSqlDataReader sqlDataReader;
        private string TopNav;
        private string QuickLaunch;
        private bool visible;
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string ConnectionString = "ConnectionString";
        private const string DummyString = "DummyString";
        private const string CurrentAppIdPropertyName = "CurrentAppId";
        private const string GetMyCurrentAppIdMethodName = "GetMyCurrentAppId";
        private const string AppListExistsMethodName = "AppListExists";
        private const string AppIdExistsMethodName = "AppIdExists";
        private const string GetDefaultCommunityMethodName = "GetDefaultCommunity";
        private const string VerifyCookieIdMethodName = "VerifyCookieId";
        private const string SetCurrentAppIdMethodName = "SetCurrentAppId";
        private const string TryGetGlobalNodesByAppIdMethodName = "TryGetGlobalNodesByAppId";
        private const string TryGetMyAppGlobalNodesMethodName = "TryGetMyAppGlobalNodes";
        private const string TryGetMyGlobalNavsForSiteMapProviderMethodName = "TryGetMyGlobalNavsForSiteMapProvider";
        private const string TryGetAppGlobalNodesByIdMethodName = "TryGetAppGlobalNodesById";
        private const string TryGetRootChildTopNavIdsByAppIdMethodName = "TryGetRootChildTopNavIdsByAppId";
        private const string TryGetTopNavIdsByAppIdMethodName = "TryGetTopNavIdsByAppId";
        private const string TryGetMyAppTopNavIdsMethodName = "TryGetMyAppTopNavIds";
        private const string TryGetRootChildQuickLaunchIdsByAppIdMethodName = "TryGetRootChildQuickLaunchIdsByAppId";
        private const string TryGetQuickLaunchIdsByAppIdMethodName = "TryGetQuickLaunchIdsByAppId";
        private const string TryGetMyAppQuickLaunchIdsMethodName = "TryGetMyAppQuickLaunchIds";
        private const string TryGetTopNavNodeCollectionByIdMethodName = "TryGetTopNavNodeCollectionById";
        private const string RecursiveFindNavNodeByIdMethodName = "RecursiveFindNavNodeById";
        private const string RecursiveFindNavNodeByTitleMethodName = "RecursiveFindNavNodeByTitle";
        private const string TryGetQuickLaunchNodeCollectionByIdMethodName = "TryGetQuickLaunchNodeCollectionById";
        private const string GetAppTopNavLastNodeIdMethodName = "GetAppTopNavLastNodeId";
        private const string AddAppTopNavMethodName = "AddAppTopNav";
        private const string DeleteAppTopNavMethodName = "DeleteAppTopNav";
        private const string GetAppQuickLaunchLastNodeIdMethodName = "GetAppQuickLaunchLastNodeId";
        private const string AddAppQuickLaunchMethodName = "AddAppQuickLaunch";
        private const string DeleteAppQuickLaunchMethodName = "DeleteAppQuickLaunch";
        private const string GetCurrentAppTitleMethodName = "GetCurrentAppTitle";

        [TestInitialize]
        public void Setup()
        {
            SetupConstructorFakes();

            testObj = new AppSettingsHelper();
            privateObj = new PrivateObject(testObj);

            SetupShims();
        }

        private void SetupShims()
        {
            shimsContext?.Dispose();
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => sqlDataReader;
            ShimCoreFunctions.getConnectionStringGuid = _ => ConnectionString;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => spSite,
                WebGet = () => spWeb
            };
            ShimSPContext.GetContextSPWeb = _ => new ShimSPContext();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
        }

        private void SetupVariables()
        {
            guid = new Guid(GuidString);
            visible = false;
            sqlDataReader = new ShimSqlDataReader();
            spSite = new ShimSPSite()
            {
                IDGet = () => guid
            };
            spList = new ShimSPList()
            {
                GetItemByIdInt32 = _ => new ShimSPListItem()
                {
                    ItemGetString = key =>
                    {
                        var result = string.Empty;
                        switch (key)
                        {
                            case "Visible":
                                result = visible.ToString();
                                break;
                            case "TopNav":
                                result = TopNav;
                                break;
                            case "QuickLaunch":
                                result = QuickLaunch;
                                break;
                        }
                        return result;
                    }
                },
                GetItemsSPQuery = _ => new ShimSPListItemCollection(),
                ItemsGet = () => new ShimSPListItemCollection()
            };
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                CurrentUserGet = () => new ShimSPUser()
                {
                    IDGet = () => 111
                },
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = _ => spList
                }
            };
        }

        private void SetupConstructorFakes()
        {
            shimsContext = ShimsContext.Create();
            ShimAppSettingsHelper.AllInstances.GetMyCurrentAppId = _ => { };
        }

        [TestMethod]
        public void GetMyCurrentAppId_WhenCalled_GetsCurrentAppId()
        {
            // Arrange
            const int expected = 111;
            var readCount = 0;

            sqlDataReader.Read = () =>
            {
                readCount = readCount + 1;
                return readCount <= 1;
            };
            sqlDataReader.ItemGetInt32 = index => 111;

            ShimAppSettingsHelper.AllInstances.SetCurrentAppIdInt32 = (_, __) => { };
            ShimAppSettingsHelper.AllInstances.GetDefaultCommunitySPList = (_, __) => new ShimSPListItem()
            {
                IDGet = () => expected
            };

            // Act
            privateObj.Invoke(GetMyCurrentAppIdMethodName, BindingFlags.Instance | BindingFlags.Public);
            var actual = (int)privateObj.GetFieldOrProperty(CurrentAppIdPropertyName);

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void AppListExists_WhenCalled_ReturnsTrue()
        {
            // Arrange
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (bool)privateObj.Invoke(AppListExistsMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void AppIdExists_WhenCalled_ReturnsTrue()
        {
            // Arrange
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (bool)privateObj.Invoke(AppIdExistsMethodName, BindingFlags.Instance | BindingFlags.Public, new object[] { 1 });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void GetDefaultCommunity_Count1_ReturnsTrue()
        {
            // Arrange
            const int expected = 111;

            ShimSPListItemCollection.AllInstances.CountGet = _ => 1;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPListItem()
            {
                IDGet = () => expected
            };

            // Act
            var actual = (SPListItem)privateObj.Invoke(
                GetDefaultCommunityMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { spList.Instance });

            // Assert
            actual.ID.ShouldBe(expected);
        }

        [TestMethod]
        public void GetDefaultCommunity_CountNot1_ReturnsTrue()
        {
            // Arrange
            const int expected = 111;

            ShimSPListItemCollection.AllInstances.CountGet = _ => expected;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPListItem()
            {
                IDGet = () => expected
            };

            // Act
            var actual = (SPListItem)privateObj.Invoke(
                GetDefaultCommunityMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { spList.Instance });

            // Assert
            actual.ID.ShouldBe(expected);
        }

        [TestMethod]
        public void VerifyCookieId_Count1_SetsId()
        {
            // Arrange
            const int expected = 111;

            ShimAppSettingsHelper.AllInstances.SetCurrentAppIdInt32 = (_, __) => { };
            ShimSPListItemCollection.AllInstances.CountGet = _ => 1;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPListItem()
            {
                IDGet = () => expected
            };

            // Act
            privateObj.Invoke(VerifyCookieIdMethodName, BindingFlags.Instance | BindingFlags.Public);
            var actual = (int)privateObj.GetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void VerifyCookieId_CountNot1_SetsId()
        {
            // Arrange
            const int expected = 111;

            ShimAppSettingsHelper.AllInstances.SetCurrentAppIdInt32 = (_, __) => { };
            ShimSPListItemCollection.AllInstances.CountGet = _ => expected;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPListItem()
            {
                IDGet = () => expected
            };

            // Act
            privateObj.Invoke(VerifyCookieIdMethodName, BindingFlags.Instance | BindingFlags.Public);
            var actual = (int)privateObj.GetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void SetCurrentAppId_WhenCalled_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var methodCount = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                methodCount = methodCount + 1;
                return 1;
            };

            // Act
            privateObj.Invoke(
                SetCurrentAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });
            var actual = (int)privateObj.GetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => methodCount.ShouldBe(2));
        }

        [TestMethod]
        public void TryGetGlobalNodesByAppId_ListNull_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            ShimAppSettingsHelper.AllInstances.TryGetTopNavIdsByAppIdInt32 = (_, input) => null;
            ShimAppSettingsHelper.AllInstances.TryGetQuickLaunchIdsByAppIdInt32 = (_, input) => null;

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetGlobalNodesByAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldBeNull();
        }

        [TestMethod]
        public void TryGetGlobalNodesByAppId_ListNotNull_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;
            var actual = default(Exception);

            ShimAppSettingsHelper.AllInstances.TryGetTopNavIdsByAppIdInt32 = (_, input) => new List<int>
            {
                input
            };
            ShimAppSettingsHelper.AllInstances.TryGetQuickLaunchIdsByAppIdInt32 = (_, input) => new List<int>
            {
                input
            };

            // Act
            try
            {
                var result = (List<int>)privateObj.Invoke(
                    TryGetGlobalNodesByAppIdMethodName,
                    BindingFlags.Instance | BindingFlags.Public,
                    new object[] { expected });
            }
            catch (NullReferenceException ex)
            {
                actual = ex;
            }

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void TryGetMyAppGlobalNodes_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            ShimAppSettingsHelper.AllInstances.TryGetMyAppTopNavIds = _ => new List<int>
            {
                expected
            };
            ShimAppSettingsHelper.AllInstances.TryGetMyAppQuickLaunchIds = _ => new List<int>
            {
                expected
            };

            // Act
            var actual = (List<int>)privateObj.Invoke(TryGetMyAppGlobalNodesMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetMyGlobalNavsForSiteMapProvider_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            TopNav = $"{expected}:text,{expected + 1}:text";
            QuickLaunch = $"{expected},{expected + 1}";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection(),
                QuickLaunchGet = () => new ShimSPNavigationNodeCollection()
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();

            // Act
            var actual = (List<int>)privateObj.Invoke(TryGetMyGlobalNavsForSiteMapProviderMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetAppGlobalNodesById_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            ShimAppSettingsHelper.AllInstances.TryGetTopNavIdsByAppIdInt32 = (_, __) => new List<int>
            {
                expected
            };
            ShimAppSettingsHelper.AllInstances.TryGetQuickLaunchIdsByAppIdInt32 = (_, __) => new List<int>
            {
                expected
            };

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetAppGlobalNodesByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetRootChildTopNavIdsByAppId_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            TopNav = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                {
                    ParentGet = () => new ShimSPNavigationNode()
                    {
                        IdGet = () => expected
                    }
                },
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ParentIdGet = () => expected
                },
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetRootChildTopNavIdsByAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetTopNavIdsByAppId_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            TopNav = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetTopNavIdsByAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetMyAppTopNavIds_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            TopNav = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (List<int>)privateObj.Invoke(TryGetMyAppTopNavIdsMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetRootChildQuickLaunchIdsByAppId_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            QuickLaunch = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ParentIdGet = () => 1025
                },
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetRootChildQuickLaunchIdsByAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetQuickLaunchIdsByAppId_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            QuickLaunch = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (List<int>)privateObj.Invoke(
                TryGetQuickLaunchIdsByAppIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetMyAppQuickLaunchIds_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            QuickLaunch = $"{expected}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;

            // Act
            var actual = (List<int>)privateObj.Invoke(TryGetMyAppQuickLaunchIdsMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ShouldBe(expected),
                () => actual[1].ShouldBe(expected));
        }

        [TestMethod]
        public void TryGetTopNavNodeCollectionById_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                },
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected + 1
                }
            }.GetEnumerator();
            ShimAppSettingsHelper.AllInstances.TryGetTopNavIdsByAppIdInt32 = (_, __) => new List<int>()
            {
                expected
            };

            // Act
            var actual = (List<SPNavigationNode>)privateObj.Invoke(
                TryGetTopNavNodeCollectionByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[0].Id.ShouldBe(expected));
        }

        [TestMethod]
        public void RecursiveFindNavNodeById_IdEqual_ReturnsNode()
        {
            // Arrange
            const int id = 111;
            const string parentTitle = "parentTitle";
            const string childTitle = "childTitle";

            var node = new ShimSPNavigationNode()
            {
                IdGet = () => id + 1,
                TitleGet = () => parentTitle,
                ChildrenGet = () => new ShimSPNavigationNodeCollection()
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    TitleGet = () => childTitle
                }
            }.GetEnumerator();

            // Act
            var actual = (SPNavigationNode)privateObj.Invoke(
                RecursiveFindNavNodeByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { node.Instance, id });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Id.ShouldBe(id),
                () => actual.Title.ShouldBe(childTitle));

        }

        [TestMethod]
        public void RecursiveFindNavNodeById_IdNotEqual_ReturnsNode()
        {
            // Arrange
            const int id = 111;
            const string parentTitle = "parentTitle";
            const string childTitle = "childTitle";

            var node = new ShimSPNavigationNode()
            {
                IdGet = () => id + 1,
                TitleGet = () => parentTitle,
                ChildrenGet = () => new ShimSPNavigationNodeCollection()
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    TitleGet = () => childTitle
                }
            }.GetEnumerator();

            // Act
            var actual = (SPNavigationNode)privateObj.Invoke(
                RecursiveFindNavNodeByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { node.Instance, id + 1 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Id.ShouldBe(id + 1),
                () => actual.Title.ShouldBe(parentTitle));
        }

        [TestMethod]
        public void RecursiveFindNavNodeByTitle_IdEqual_ReturnsNode()
        {
            /// Arrange
            const string parentTitle = "parentTitle";
            const string childTitle = "childTitle";

            var node = new ShimSPNavigationNode()
            {
                TitleGet = () => parentTitle,
                ChildrenGet = () => new ShimSPNavigationNodeCollection()
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    TitleGet = () => childTitle
                }
            }.GetEnumerator();

            // Act
            var actual = (SPNavigationNode)privateObj.Invoke(
                RecursiveFindNavNodeByTitleMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { node.Instance, parentTitle });

            // Assert
            actual.Title.ShouldBe(parentTitle);
        }

        [TestMethod]
        public void RecursiveFindNavNodeByTitle_IdNotEqual_ReturnsNode()
        {
            // Arrange
            const string parentTitle = "parentTitle";
            const string childTitle = "childTitle";

            var node = new ShimSPNavigationNode()
            {
                TitleGet = () => parentTitle,
                ChildrenGet = () => new ShimSPNavigationNodeCollection()
            };

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    TitleGet = () => childTitle
                }
            }.GetEnumerator();

            // Act
            var actual = (SPNavigationNode)privateObj.Invoke(
                RecursiveFindNavNodeByTitleMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { node.Instance, childTitle });

            // Assert
            actual.Title.ShouldBe(childTitle);
        }

        [TestMethod]
        public void TryGetQuickLaunchNodeCollectionById_WhenCalled_ReturnsIntList()
        {
            // Arrange
            const int expected = 111;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                QuickLaunchGet = () => new ShimSPNavigationNodeCollection()
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                },
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected + 1
                }
            }.GetEnumerator();
            ShimAppSettingsHelper.AllInstances.TryGetQuickLaunchIdsByAppIdInt32 = (_, __) => new List<int>()
            {
                expected
            };

            // Act
            var actual = (List<SPNavigationNode>)privateObj.Invoke(
                TryGetQuickLaunchNodeCollectionByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[0].Id.ShouldBe(expected));
        }

        [TestMethod]
        public void GetAppTopNavLastNodeId_WhenCalled_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            TopNav = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                {
                    ParentGet = () => new ShimSPNavigationNode()
                    {
                        IdGet = () => expected
                    }
                },
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ParentIdGet = () => expected
                },
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();

            // Act
            var actual = (int)privateObj.Invoke(
                GetAppTopNavLastNodeIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldBe(expected + 1);
        }

        [TestMethod]
        public void AddAppTopNav_NavIdPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            TopNav = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                AddAppTopNavMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(TopNav),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void AddAppTopNav_NavIdNotPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            TopNav = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                AddAppTopNavMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected + 2 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{expected - 1},{expected},{expected + 1},{expected + 2}"),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteAppTopNav_NavIdPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            TopNav = $"{expected},{expected + 1},{expected - 1}";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                DeleteAppTopNavMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{expected + 1},{expected - 1}"),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteAppTopNav_NavIdNotPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            TopNav = $"{expected + 1},{expected - 1},{expected}";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                DeleteAppTopNavMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected + 2, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(TopNav),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void GetAppQuickLaunchLastNodeId_WhenCalled_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            QuickLaunch = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ParentIdGet = () => 1025
                },
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();

            // Act
            var actual = (int)privateObj.Invoke(
                GetAppQuickLaunchLastNodeIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected });

            // Assert
            actual.ShouldBe(expected + 1);
        }

        [TestMethod]
        public void AddAppQuickLaunch_NavIdPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            QuickLaunch = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                AddAppQuickLaunchMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(QuickLaunch),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void AddAppQuickLaunch_NavIdNotPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            QuickLaunch = $"{expected + 1}:text,{expected - 1}:text,{expected}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                AddAppQuickLaunchMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected + 2 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{expected - 1},{expected},{expected + 1},{expected + 2}"),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteAppQuickLaunch_NavIdPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            QuickLaunch = $"{expected},{expected + 1},{expected - 1}";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                DeleteAppQuickLaunchMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{expected + 1},{expected - 1}"),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteAppQuickLaunch_NavIdNotPresent_ReturnsInt()
        {
            // Arrange
            const int expected = 111;

            var actual = default(string);
            var methodHit = false;

            QuickLaunch = $"{expected + 1},{expected - 1},{expected}";

            spWeb.NavigationGet = () => new ShimSPNavigation();
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode>()
            {
                new ShimSPNavigationNode()
                {
                    IdGet = () => expected
                }
            }.GetEnumerator();
            ShimSPListItem.AllInstances.ItemSetStringObject = (intance, key, value) =>
            {
                actual = value.ToString();
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObj.Invoke(
                DeleteAppQuickLaunchMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected + 2, expected });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(QuickLaunch),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCurrentAppTitle_CurrentAppIdNegativeOne_ReturnsString()
        {
            // Arrange
            const string title = "Title";

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPListItem.AllInstances.TitleGet = _ => title;

            privateObj.SetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public, -1);

            // Act
            var actual = (string)privateObj.Invoke(GetCurrentAppTitleMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetCurrentAppTitle_VisibleFalse_ReturnsString()
        {
            // Arrange
            const string title = "Title";

            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPListItem.AllInstances.TitleGet = _ => title;

            privateObj.SetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public, 111);

            // Act
            var actual = (string)privateObj.Invoke(GetCurrentAppTitleMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetCurrentAppTitle_VisibleTrue_ReturnsString()
        {
            // Arrange
            const string title = "Title";

            visible = true;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
            ShimSPListItem.AllInstances.TitleGet = _ => title;

            privateObj.SetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public, 111);

            // Act
            var actual = (string)privateObj.Invoke(GetCurrentAppTitleMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(title);
        }
    }
}
