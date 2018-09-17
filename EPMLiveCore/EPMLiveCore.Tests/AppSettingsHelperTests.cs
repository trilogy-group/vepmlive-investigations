using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Reflection;
using System.Resources.Fakes;
using EPMLiveCore.Controls.Navigation.Providers.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
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
        private const string GetRealIndexMethodName = "GetRealIndex";
        private const string CreateChildNodeMethodName = "CreateChildNode";
        private const string CreateParentNodeMethodName = "CreateParentNode";
        private const string EditNodeByIdMethodName = "EditNodeById";
        private const string DeleteNodeMethodName = "DeleteNode";
        private const string IsUrlInternalMethodName = "IsUrlInternal";
        private const string UpdateNodeOrderMethodName = "UpdateNodeOrder";
        private const string MoveNodeMethodName = "MoveNode";
        private const string GetCleanUrlMethodName = "GetCleanUrl";

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
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) => DummyString;
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
            ShimUri.UnescapeDataStringString = input => input;
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
                },
                UrlGet = () => DummyString
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

            // Act
            var actual = (bool)privateObj.Invoke(AppListExistsMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void AppIdExists_WhenCalled_ReturnsTrue()
        {
            // Arrange

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
            ShimSPListItem.AllInstances.TitleGet = _ => title;

            privateObj.SetFieldOrProperty(CurrentAppIdPropertyName, BindingFlags.Instance | BindingFlags.Public, 111);

            // Act
            var actual = (string)privateObj.Invoke(GetCurrentAppTitleMethodName, BindingFlags.Instance | BindingFlags.Public);

            // Assert
            actual.ShouldBe(title);
        }

        [TestMethod]
        public void GetRealIndex_TopNav_ReturnsInt()
        {
            // Arrange
            const int expected = 111;
            const int position = 0;
            const string navType = "topnav";

            TopNav = $"{expected}:text,{expected + 1}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    ParentIdGet = () => expected,
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                },
            };
            ShimSPNavigationNodeCollection.AllInstances.CountGet = _ => 1;
            ShimSPNavigationNodeCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPNavigationNode()
            {
                IdGet = () => expected
            };

            // Act
            var actual = (int)privateObj.Invoke(
                GetRealIndexMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, position, expected, navType });

            // Assert
            actual.ShouldBe(position);
        }

        [TestMethod]
        public void GetRealIndex_QuickLaunch_ReturnsInt()
        {
            // Arrange
            const int expected = 111;
            const int position = 0;
            const string navType = "quiklnch";

            QuickLaunch = $"{expected}:text,{expected + 1}:text";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    ParentIdGet = () => expected,
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                },
            };
            ShimSPNavigationNodeCollection.AllInstances.CountGet = _ => 1;
            ShimSPNavigationNodeCollection.AllInstances.ItemGetInt32 = (_, __) => new ShimSPNavigationNode()
            {
                IdGet = () => expected
            };

            // Act
            var actual = (int)privateObj.Invoke(
                GetRealIndexMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { expected, position, expected, navType });

            // Assert
            actual.ShouldBe(position);
        }

        [TestMethod]
        public void CreateChildNode_TopNavNodeType_CreatesChildNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "topnav";
            const int headingNodeId = 111;
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = false;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                        {
                            IdGet = () => expectedId
                        }
                    }
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppTopNavInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = true;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit && true;
            };
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveCategoryString = _ => { }
            };

            // Act
            privateObj.Invoke(
                CreateChildNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, headingNodeId, isExternal, spUser });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateChildNode_QuickLaunchNodeType_CreatesChildNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "quiklnch";
            const int headingNodeId = 111;
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = false;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                        {
                            IdGet = () => expectedId
                        }
                    }
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppQuickLaunchInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = true;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit && true;
            };
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveCategoryString = _ => { }
            };

            // Act
            privateObj.Invoke(
                CreateChildNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, headingNodeId, isExternal, spUser });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateParentNode_TopNavNodeTypeAppIdPositiveNavIDPositive_CreatesParentNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "topnav";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddSPNavigationNodeSPNavigationNode = (_, __) => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () =>
                        {
                            methodHit = methodHit + 1;
                        }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppTopNavInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = methodHit + 1;
                }
            };
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => 1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(4);
        }

        [TestMethod]
        public void CreateParentNode_TopNavNodeTypeAppIdPositiveNavIDNegative_CreatesParentNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "topnav";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () =>
                        {
                            methodHit = methodHit + 1;
                        }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppTopNavInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = methodHit + 1;
                }
            };
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(4);
        }

        [TestMethod]
        public void CreateParentNode_TopNavNodeTypeAppIdNegativeNavIDNegative_CreatesParentNode()
        {
            // Arrange
            const int appId = -1;
            const string nodeType = "topnav";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () =>
                        {
                            methodHit = methodHit + 1;
                        }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(3);
        }

        [TestMethod]
        public void CreateParentNode_QuickLaunchNodeTypeAppIdPositiveNavIDPositive_CreatesParentNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "quiklnch";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                QuickLaunchGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddSPNavigationNodeSPNavigationNode = (_, __) => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () => { }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppQuickLaunchInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = methodHit + 1;
                }
            };
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => 1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(3);
        }

        [TestMethod]
        public void CreateParentNode_QuickLaunchNodeTypeAppIdPositiveNavIDNegative_CreatesParentNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "quiklnch";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                QuickLaunchGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () =>
                        {
                            methodHit = methodHit + 1;
                        }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.AddAppQuickLaunchInt32Int32 = (_, _1, id) =>
            {
                if (id == expectedId)
                {
                    methodHit = methodHit + 1;
                }
            };
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(4);
        }

        [TestMethod]
        public void CreateParentNode_QuickLaunchTypeAppIdNegativeNavIDNegative_CreatesParentNode()
        {
            // Arrange
            const int appId = -1;
            const string nodeType = "quiklnch";
            const string title = "title";
            const string url = "url";
            const bool isExternal = true;
            const int expectedId = 1111;

            var spUser = new ShimSPUser().Instance;
            var methodHit = 0;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                QuickLaunchGet = () => new ShimSPNavigationNodeCollection()
                {
                    AddAsLastSPNavigationNode = _ => new ShimSPNavigationNode()
                    {
                        IdGet = () => expectedId,
                        Update = () =>
                        {
                            methodHit = methodHit + 1;
                        }
                    }
                },
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id
                },
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimCacheStore.CurrentGet = () => new ShimCacheStore()
            {
                RemoveSafelyStringStringString = (_, _1, _2) =>
                {
                    methodHit = methodHit + 1;
                }
            };
            spWeb.Update = () =>
            {
                methodHit = methodHit + 1;
            };

            // Act
            privateObj.Invoke(
                CreateParentNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, title, url, isExternal, spUser });

            // Assert
            methodHit.ShouldBe(3);
        }

        [TestMethod]
        public void EditNodeById_TopNavNodeType_EditsNode()
        {
            const int newParentNodeId = 111;
            const int oldParentNodeId = 10;
            const int nodeId = 11;
            const string title = "title";
            const string url = "url";
            const int appId = -1;
            const string nodeType = "TopNav";
            const int expectedId = 1111;
            const int expected = 111;

            var spUser = new ShimSPUser()
            {
                LoginNameGet = () => string.Empty
            }.Instance;
            var validationCount = 0;
            var actual = default(string);

            TopNav = $"{nodeId}:text,{expected}:text,{expected + 1}:text,{expected + 2}";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    Update = () => { },
                    ParentIdGet = () =>
                    {
                        if (id == nodeId)
                        {
                            return oldParentNodeId;
                        }

                        return 1;
                    },
                    ParentGet = () => new ShimSPNavigationNode()
                    {
                        IdGet = () =>
                        {
                            if (id == nodeId)
                            {
                                return oldParentNodeId;
                            }

                            return 1;
                        },
                        ChildrenGet = () => new ShimSPNavigationNodeCollection()
                        {
                            DeleteSPNavigationNode = node =>
                            {
                                if (node.Id == nodeId && id == nodeId)
                                {
                                    validationCount = validationCount + 1;
                                }
                            }
                        },
                    },
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        AddAsLastSPNavigationNode = node =>
                        {
                            if (node.Id == nodeId && id == newParentNodeId)
                            {
                                validationCount = validationCount + 1;
                            }
                            return new ShimSPNavigationNode()
                            {
                                IdGet = () => expectedId
                            };
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimAppSettingsHelper.AllInstances.IsUrlInternalString = (_, __) => true;
            spWeb.Update = () =>
            {
                validationCount = validationCount + 1;
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                validationCount = validationCount + 1;
            };
            ShimSPListItem.AllInstances.ItemSetStringObject = (_, key, value) =>
            {
                if (key == nodeType)
                {
                    validationCount = validationCount + 1;
                    actual = value.ToString();
                }
            };
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, _1, _2, _3) => new ShimGenericLinkProvider();
            ShimGenericLinkProvider.AllInstances.ClearCacheBoolean = (_, _1) =>
            {
                validationCount = validationCount + 1;
            };

            // Act
            privateObj.Invoke(
                EditNodeByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { newParentNodeId, nodeId, title, url, appId, nodeType, spUser });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => validationCount.ShouldBe(6),
                () => actual.ShouldBe($"{expected}:text,{expected + 1}:text,{expected + 2}:,{expectedId}"));
        }

        [TestMethod]
        public void EditNodeById_QuickLaunchNodeType_EditsNode()
        {
            const int newParentNodeId = 111;
            const int oldParentNodeId = 10;
            const int nodeId = 11;
            const string title = "title";
            const string url = "url";
            const int appId = -1;
            const string nodeType = "QuickLaunch";
            const int expectedId = 1111;
            const int expected = 111;

            var spUser = new ShimSPUser()
            {
                LoginNameGet = () => string.Empty
            }.Instance;
            var validationCount = 0;
            var actual = default(string);

            QuickLaunch = $"{nodeId}:text,{expected}:text,{expected + 1}:text,{expected + 2}";

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    Update = () => { },
                    ParentIdGet = () =>
                    {
                        if (id == nodeId)
                        {
                            return oldParentNodeId;
                        }

                        return 1;
                    },
                    ParentGet = () => new ShimSPNavigationNode()
                    {
                        IdGet = () =>
                        {
                            if (id == nodeId)
                            {
                                return oldParentNodeId;
                            }

                            return 1;
                        },
                        ChildrenGet = () => new ShimSPNavigationNodeCollection()
                        {
                            DeleteSPNavigationNode = node =>
                            {
                                if (node.Id == nodeId && id == nodeId)
                                {
                                    validationCount = validationCount + 1;
                                }
                            }
                        },
                    },
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        AddAsLastSPNavigationNode = node =>
                        {
                            if (node.Id == nodeId && id == newParentNodeId)
                            {
                                validationCount = validationCount + 1;
                            }
                            return new ShimSPNavigationNode()
                            {
                                IdGet = () => expectedId
                            };
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetCleanUrlString = (_, input) => input;
            ShimAppSettingsHelper.AllInstances.GetAppTopNavLastNodeIdInt32 = (_, __) => -1;
            ShimAppSettingsHelper.AllInstances.IsUrlInternalString = (_, __) => true;
            spWeb.Update = () =>
            {
                validationCount = validationCount + 1;
            };
            ShimSPListItem.AllInstances.Update = _ =>
            {
                validationCount = validationCount + 1;
            };
            ShimSPListItem.AllInstances.ItemSetStringObject = (_, key, value) =>
            {
                if (key == nodeType)
                {
                    validationCount = validationCount + 1;
                    actual = value.ToString();
                }
            };
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, _1, _2, _3) => new ShimGenericLinkProvider();
            ShimGenericLinkProvider.AllInstances.ClearCacheBoolean = (_, _1) =>
            {
                validationCount = validationCount + 1;
            };

            // Act
            privateObj.Invoke(
                EditNodeByIdMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { newParentNodeId, nodeId, title, url, appId, nodeType, spUser });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => validationCount.ShouldBe(6),
                () => actual.ShouldBe($"{expected}:text,{expected + 1}:text,{expected + 2}:,{expectedId}"));
        }

        [TestMethod]
        public void DeleteNode_TopNavNodeType_Deletes()
        {
            // Arrange
            const int appId = 1;
            const int nodeId = 111;
            const string nodeType = "topnav";

            var validationCount = 0;
            var origUser = new ShimSPUser()
            {
                LoginNameGet = () => string.Empty
            }.Instance;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    Delete = () =>
                    {
                        validationCount = validationCount + 1;
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.DeleteAppTopNavInt32Int32 = (_, _1, input) =>
            {
                if (input == nodeId)
                {
                    validationCount = validationCount + 1;
                }
            };
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, _1, _2, _3) => new ShimGenericLinkProvider();
            ShimGenericLinkProvider.AllInstances.ClearCacheBoolean = (_, _1) =>
            {
                validationCount = validationCount + 1;
            };

            // Act
            privateObj.Invoke(
                DeleteNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeId, nodeType, origUser });

            // Assert
            validationCount.ShouldBe(3);
        }

        [TestMethod]
        public void DeleteNode_QuickLaunchNodeType_Deletes()
        {
            // Arrange
            const int appId = 1;
            const int nodeId = 111;
            const string nodeType = "quiklnch";

            var validationCount = 0;
            var origUser = new ShimSPUser()
            {
                LoginNameGet = () => string.Empty
            }.Instance;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = id => new ShimSPNavigationNode()
                {
                    IdGet = () => id,
                    Delete = () =>
                    {
                        validationCount = validationCount + 1;
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.DeleteAppQuickLaunchInt32Int32 = (_, _1, input) =>
            {
                if (input == nodeId)
                {
                    validationCount = validationCount + 1;
                }
            };
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, _1, _2, _3) => new ShimGenericLinkProvider();
            ShimGenericLinkProvider.AllInstances.ClearCacheBoolean = (_, _1) =>
            {
                validationCount = validationCount + 1;
            };

            // Act
            privateObj.Invoke(
                DeleteNodeMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeId, nodeType, origUser });

            // Assert
            validationCount.ShouldBe(3);
        }

        [TestMethod]
        public void IsUrlInternal_HttpUrl_ReturnsBoolean()
        {
            // Arrange
            const string url = "https://sampleurl.com";

            // Act
            var actual = (bool)privateObj.Invoke(
                IsUrlInternalMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { url });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void IsUrlInternal_NotHttpUrlWithoutSPWebUrl_ReturnsBoolean()
        {
            // Arrange
            const string url = "/sampleurl.com";

            // Act
            var actual = (bool)privateObj.Invoke(
                IsUrlInternalMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { url });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void IsUrlInternal_HttpUrlWithSPWebUrl_ReturnsBoolean()
        {
            // Arrange
            var url = $"https://{DummyString}.com";

            // Act
            var actual = (bool)privateObj.Invoke(
                IsUrlInternalMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { url });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateNodeOrder_WhenCalled_UpdatesNodeOrder()
        {
            // Arrange
            const int appId = -1;
            const string nodeType = "topnav";
            const string moveInfos = "Info1,Info2;;Info3,Info4";

            var origUser = new ShimSPUser().Instance;
            var actual = new List<string>();
            var methodHit = 0;

            ShimAppSettingsHelper.AllInstances.MoveNodeInt32StringStringArray = (_, _1, _2, input) =>
            {
                methodHit = methodHit + 1;
                actual.AddRange(input);
            };

            // Act
            privateObj.Invoke(
                UpdateNodeOrderMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { appId, nodeType, moveInfos, origUser });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => methodHit.ShouldBe(2),
                () => actual.Count.ShouldBe(4),
                () => actual[0].ShouldBe("Info1"),
                () => actual[1].ShouldBe("Info2"),
                () => actual[2].ShouldBe("Info3"),
                () => actual[3].ShouldBe("Info4"));
        }

        [TestMethod]
        public void MoveNode_NewIndexZero_MovesNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "TopNav";

            var movementInfo = new string[] { "10", "1", "0" };
            var methodHit = false;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        CountGet = () => 5,
                        ItemGetInt32 = index => new ShimSPNavigationNode()
                        {
                            MoveToFirstSPNavigationNodeCollection = _1 =>
                            {
                                methodHit = true;
                            },
                            MoveToLastSPNavigationNodeCollection = _1 => { },
                            MoveSPNavigationNodeCollectionSPNavigationNode = (_1, _2) => { }
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetRealIndexInt32Int32Int32String = (instance, _, position, _1, _2) => position;

            // Act
            privateObj.Invoke(
                MoveNodeMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { appId, nodeType, movementInfo });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void MoveNode_NewIndexIsLastIndex_MovesNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "TopNav";

            var movementInfo = new string[] { "10", "0", "1" };
            var methodHit = false;

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        CountGet = () => 2,
                        ItemGetInt32 = index => new ShimSPNavigationNode()
                        {
                            MoveToFirstSPNavigationNodeCollection = _1 => { },
                            MoveToLastSPNavigationNodeCollection = _1 =>
                            {
                                methodHit = true;
                            },
                            MoveSPNavigationNodeCollectionSPNavigationNode = (_1, _2) => { }
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetRealIndexInt32Int32Int32String = (instance, _, position, _1, _2) => position;

            // Act
            privateObj.Invoke(
                MoveNodeMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { appId, nodeType, movementInfo });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void MoveNode_NewIndexIsLessThanOldIndex_MovesNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "TopNav";

            var movementInfo = new string[] { "10", "3", "2" };
            var methodHit = false;
            var actual = default(SPNavigationNode);

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        CountGet = () => 5,
                        ItemGetInt32 = index => new ShimSPNavigationNode()
                        {
                            IdGet = () => index,
                            MoveToFirstSPNavigationNodeCollection = _1 => { },
                            MoveToLastSPNavigationNodeCollection = _1 => { },
                            MoveSPNavigationNodeCollectionSPNavigationNode = (_1, node) =>
                            {
                                actual = node;
                                methodHit = true;
                            }
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetRealIndexInt32Int32Int32String = (instance, _, position, _1, _2) => position;

            // Act
            privateObj.Invoke(
                MoveNodeMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { appId, nodeType, movementInfo });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Id.ShouldBe(1),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void MoveNode_NewIndexIsGreaterThanOldIndex_MovesNode()
        {
            // Arrange
            const int appId = 1;
            const string nodeType = "TopNav";

            var movementInfo = new string[] { "10", "1", "2" };
            var methodHit = false;
            var actual = default(SPNavigationNode);

            spWeb.NavigationGet = () => new ShimSPNavigation()
            {
                GetNodeByIdInt32 = _ => new ShimSPNavigationNode()
                {
                    ChildrenGet = () => new ShimSPNavigationNodeCollection()
                    {
                        CountGet = () => 5,
                        ItemGetInt32 = index => new ShimSPNavigationNode()
                        {
                            IdGet = () => index,
                            MoveToFirstSPNavigationNodeCollection = _1 => { },
                            MoveToLastSPNavigationNodeCollection = _1 => { },
                            MoveSPNavigationNodeCollectionSPNavigationNode = (_1, node) =>
                            {
                                actual = node;
                                methodHit = true;
                            }
                        }
                    }
                }
            };
            ShimAppSettingsHelper.AllInstances.GetRealIndexInt32Int32Int32String = (instance, _, position, _1, _2) => position;

            // Act
            privateObj.Invoke(
                MoveNodeMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { appId, nodeType, movementInfo });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Id.ShouldBe(2),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCleanUrl_EmptyString_ReturnsString()
        {
            // Arrange
            var url = string.Empty;

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe(url);
        }

        [TestMethod]
        public void GetCleanUrl_HttpUrl_ReturnsString()
        {
            // Arrange
            var url = "http://sampleurl.com";

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe(url);
        }

        [TestMethod]
        public void GetCleanUrl_SitesUrl_ReturnsString()
        {
            // Arrange
            var url = "sites";

            spWeb.ServerRelativeUrlGet = () => "Not/";

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe($"/{url}");
        }

        [TestMethod]
        public void GetCleanUrl_UrlStartsWithTitle_ReturnsString()
        {
            // Arrange
            var url = "Notsites";

            spWeb.ServerRelativeUrlGet = () => "Not/";
            spWeb.TitleGet = () => url;

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe($"/sites/{url}");
        }

        [TestMethod]
        public void GetCleanUrl_UrlNotStartsWithTitle_IsTop_ReturnsString()
        {
            // Arrange
            var url = "Notsites";

            spWeb.ServerRelativeUrlGet = () => "/";
            spWeb.TitleGet = () => "NotUrl";

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe($"/{url}");
        }

        [TestMethod]
        public void GetCleanUrl_UrlNotStartsWithTitle_IsNotTop_ReturnsString()
        {
            // Arrange
            var url = "notsites";
            const string myPath = "mypath";

            spWeb.ServerRelativeUrlGet = () => myPath;
            spWeb.TitleGet = () => "NotUrl";

            // Act
            var actual = (string)privateObj.Invoke(
                GetCleanUrlMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { url });

            // Assert
            actual.ShouldBe($"{myPath}/{url}");
        }
    }
}
