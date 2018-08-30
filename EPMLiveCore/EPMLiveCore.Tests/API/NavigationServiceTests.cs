using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq.Fakes;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Controls.Navigation.Providers.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.Infrastructure.Navigation.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class NavigationServiceTests
    {
        private IDisposable _shimObject;
        private NavigationService _testObj;
        private PrivateObject _privateObj;
        private PrivateType _privateType;
        private SPWeb _web;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com/";

        private const string LinkProvidersField = "_linkProviders";
        private const string ContextualMenusTag = "<ContextualMenus>";
        private const string CDataTag = "<![CDATA[";
        private const string ExceptionTag = "Exception";
        private const string SiteId = "57AE2E9B-1E0D-448C-83B0-417DD99EDCBA";
        private const string WebId = "F5DBB19B-0B55-4EFB-A000-DD768E3B5ADE";
        private const string ListId = "50DBAFD2-7083-4DDD-8BCB-48B325AE1188";
        private const string ReorderGuid = "EFFA3011-4F47-4072-B035-CC3E12DBA08A";
        private const string LPPFEPermissionCheckMethod = "LPPFEPermissionCheck";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObject = ShimsContext.Create();

            _web = new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    LoginNameGet = () => DummyString
                },
                SiteGet = () => new ShimSPSite
                {
                    IDGet = Guid.NewGuid
                },
                IDGet = Guid.NewGuid
            }.Instance;

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void InitConstructorSPWeb()
        {
            _testObj = new NavigationService(_web);
            _privateObj = new PrivateObject(_testObj);
            _privateType = new PrivateType(typeof(NavigationService));
        }

        private void InitConstructorProviderSPWeb()
        {
            var linkProviders = new Dictionary<string, INavLinkProvider> { [DummyString] = new ShimApplicationsLinkProvider().Instance };
            _testObj = new NavigationService(DummyString, _web);
            _privateObj = new PrivateObject(_testObj);
            _privateObj.SetFieldOrProperty(LinkProvidersField, linkProviders);
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPSite.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void GetContextualMenuItems_OnValidCall_ConfirmResult()
        {
            // Arrange
            var data = string.Empty;
            SetupForGetContextualMenuItems(out data);
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            ShimNavigationService.GetGeneralActionsBooleanSPListBooleanDictionaryOfStringStringOut =
                (bool usePopup, SPList list, bool bFancyForms, out Dictionary<string, string> dictionary) =>
                {
                    dictionary = null;
                    return new Tuple<string, string, string, string, bool>[] 
                    {
                        new Tuple<string, string, string, string, bool>(DummyString, DummyString, DummyString, DummyString, true)
                    };
                };

            ShimCoreFunctions.GetPlannerListSPWebSPListItem = (_, __) => new Dictionary<string, PlannerDefinition>
            {
                [DummyString] = new PlannerDefinition { commandPrefix = DummyString }
            };

            // Act
            var result = _testObj.GetContextualMenuItems(data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(ContextualMenusTag),
                () => result.ShouldContain(CDataTag));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenResourcesAndErrorOnCreateMenu_ConfirmResult()
        {
            // Arrange
            var data = string.Empty;
            const string Resources = "Resources";
            SetupForGetContextualMenuItems(out data);
            ShimSPList.AllInstances.TitleGet = _ => Resources;

            // Act
            var result = _testObj.GetContextualMenuItems(data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(ContextualMenusTag),
                () => result.ShouldContain(ExceptionTag));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenErrorOnCreateMenu_ConfirmResult()
        {
            // Arrange
            var data = string.Empty;
            SetupForGetContextualMenuItems(out data);
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            // Act
            var result = _testObj.GetContextualMenuItems(data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(ContextualMenusTag),
                () => result.ShouldContain(ExceptionTag));
        }

        private void SetupForGetContextualMenuItems(out string data)
        {
            data = $@"<Root>
                        <Params>
                            <SiteId>{SiteId}</SiteId>
                            <WebId>{WebId}</WebId>
                            <ListId>{ListId}</ListId>
                            <ItemId>{DummyInt}</ItemId>
                            <UserId>{DummyInt}</UserId>
                            <DebugMode>true</DebugMode>
                        </Params>
                      </Root>";

            InitConstructorSPWeb();

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb
            {
                UrlGet = () => DummyUrl,
                AllUsersGet = () => new ShimSPUserCollection
                {
                    GetByIDInt32 = x => new ShimSPUser
                    {
                        UserTokenGet = () => new ShimSPUserToken(),
                        LoginNameGet = () => DummyString,
                        NameGet = () => DummyString
                    }
                },
                ListsGet = () => new ShimSPListCollection
                {
                    GetListGuidBoolean = (x, y) => new ShimSPList
                    {
                        ParentWebGet = () => new ShimSPWeb
                        {
                            SiteGet = () => new ShimSPSite
                            {
                                FeaturesGet = () => new ShimSPFeatureCollection
                                {
                                    ItemGetGuid = z => new ShimSPFeature()
                                },
                                RootWebGet = () => new ShimSPWeb()
                            }
                        },
                        GetItemByIdInt32 = a => new ShimSPListItem
                        {
                            ParentListGet = () => new ShimSPList(),
                            ModerationInformationGet = () => new ShimSPModerationInformation
                            {
                                StatusGet = () => SPModerationStatusType.Approved
                            },
                            WebGet = () => new ShimSPWeb
                            {
                                IDGet = () => Guid.NewGuid()
                            },
                            ItemGetString = b => DummyString
                        }
                    }
                }
            };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };

            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;

            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimListCommands.GetGridGanttSettingsSPList = _ => new ShimGridGanttSettings();
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoRootElement_ThrowException()
        {
            // Arrange
            const string data = "<Test />";
            InitConstructorSPWeb();

            ShimXDocument.AllInstances.RootGet = _ => null;

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("Root element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoParamsElement_ThrowException()
        {
            // Arrange
            const string data = "<Root />";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoSiteIdElement_ThrowException()
        {
            // Arrange
            const string data = "<Root><Params></Params></Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params/SiteId element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenInvalidSiteId_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{DummyString}</SiteId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("(SiteId)"));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoWebIdElement_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params/WebId element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenInvalidWebId_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{DummyString}</WebId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("(WebId)"));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoListIdElement_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params/ListId element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenInvalidListId_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                                <ListId>{DummyString}</ListId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("(ListId)"));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoItemIdElement_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                                <ListId>{ListId}</ListId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params/ItemId element is missing."));
        }


        [TestMethod]
        public void GetContextualMenuItems_WhenInvalidItemId_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                                <ListId>{ListId}</ListId>
                                <ItemId>{DummyString}</ItemId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("(ItemId)"));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenNoUserIdElement_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                                <ListId>{ListId}</ListId>
                                <ItemId>{DummyInt}</ItemId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("GetContextualMenuItems/Params/UserId element is missing."));
        }

        [TestMethod]
        public void GetContextualMenuItems_WhenInvalidUserId_ThrowException()
        {
            // Arrange
            var data = $@"<Root>
                            <Params>
                                <SiteId>{SiteId}</SiteId>
                                <WebId>{WebId}</WebId>
                                <ListId>{ListId}</ListId>
                                <ItemId>{DummyInt}</ItemId>
                                <UserId>{DummyString}</UserId>
                            </Params>
                          </Root>";

            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.GetContextualMenuItems(data);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("(UserId)"));
        }
        
        [TestMethod]
        public void GetLinks_OnValidCall_ConfirmResults()
        {
            // Arrange
            InitConstructorProviderSPWeb();
            ShimApplicationsLinkProvider.AllInstances.GetLinks = _ => new List<INavObject> { new ShimNavLink().Instance };
            
            // Act
            var result = _testObj.GetLinks();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CDataTag),
                () => result.ShouldContain("NavLink"));
        }

        [TestMethod]
        public void RemoveNavigationLink_OnValidCall_ConfirmResult()
        {
            // Arrange
            var removed = false;
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimGenericLinkProvider.AllInstances.RemoveGuid = (_, __) => removed = true;
            InitConstructorSPWeb();

            // Act
            _testObj.RemoveNavigationLink(ReorderGuid);

            // Assert
            removed.ShouldBeTrue();
        }

        [TestMethod]
        public void RemoveNavigationLink_OnError_ThrowException()
        {
            // Arrange
            var removed = false;
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimGenericLinkProvider.AllInstances.RemoveGuid = (_, __) => removed = true;
            InitConstructorSPWeb();

            // Act
            Action action = () => _testObj.RemoveNavigationLink(DummyString);

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("[NavigationService:RemoveNavigationLink]"),
                () => removed.ShouldBeFalse());
        }

        [TestMethod]
        public void ReorderLinks_OnValidCall_ConfirmResult()
        {
            // Arrange
            var reordered = false;
            InitConstructorSPWeb();

            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimGenericLinkProvider.AllInstances.ReorderDictionaryOfGuidInt32 = (_, __) => reordered = true;

            // Act
            _testObj.ReorderLinks($"{ReorderGuid}:{DummyInt}");

            // Assert
            reordered.ShouldBeTrue();
        }

        [TestMethod]
        public void ReorderLinks_OnError_ThrowException()
        {
            // Arrange
            var reordered = false;
            InitConstructorSPWeb();

            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { throw new Exception();  };
            ShimGenericLinkProvider.AllInstances.ReorderDictionaryOfGuidInt32 = (_, __) => reordered = true;

            // Act
            Action action = () => _testObj.ReorderLinks($"{ReorderGuid}:{DummyInt}");

            // Assert
            var exception = Should.Throw<APIException>(action);
            this.ShouldSatisfyAllConditions(
                () => exception.ShouldNotBeNull(),
                () => exception.Message.ShouldContain("[NavigationService:ReorderLinks]"),
                () => reordered.ShouldBeFalse());
        }

        [TestMethod]
        public void LPPFEPermissionCheck_OnValidCall_ConfirmResult()
        {
            // Arrange
            var permissionsList = new List<SPBasePermissions>
            {
                SPBasePermissions.AddListItems,
                SPBasePermissions.EditListItems,
                SPBasePermissions.DeleteListItems
            };
            InitConstructorSPWeb();

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => true;
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb
            {
                CurrentUserGet = () => new ShimSPUser
                {
                    IDGet = () => DummyInt
                }
            };

            // Act, Assert
            foreach (var permission in permissionsList)
            {
                var result = _privateType.InvokeStatic(LPPFEPermissionCheckMethod, new ShimSPList().Instance, permission) as bool?;

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),
                    () => result.Value.ShouldBeTrue());
            }
        }
    }
}
