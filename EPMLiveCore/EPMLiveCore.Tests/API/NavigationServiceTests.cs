using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Controls.Navigation.Providers.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.Infrastructure.Navigation.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Workflow;
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
            _privateObj.SetFieldOrProperty("_linkProviders", linkProviders);
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
            var data = $@"<Root>
                            <Params>
                                <SiteId>57AE2E9B-1E0D-448C-83B0-417DD99EDCBA</SiteId>
                                <WebId>F5DBB19B-0B55-4EFB-A000-DD768E3B5ADE</WebId>
                                <ListId>50DBAFD2-7083-4DDD-8BCB-48B325AE1188</ListId>
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
                        TitleGet = () => DummyString
                    }
                }
            };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };

            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;

            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimListCommands.GetGridGanttSettingsSPList = _ => new ShimGridGanttSettings();

            ShimNavigationService.GetGeneralActionsBooleanSPListBooleanDictionaryOfStringStringOut =
                (bool usePopup, SPList list, bool bFancyForms, out Dictionary<string, string> dictionary) =>
                {
                    dictionary = null;
                    return new Tuple<string, string, string, string, bool>[] 
                    {
                        new Tuple<string, string, string, string, bool>(DummyString, DummyString, DummyString, DummyString, true)
                    };
                };

            // Act
            var result = _testObj.GetContextualMenuItems(data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain("<ContextualMenus>"),
                () => result.ShouldContain("<![CDATA["));
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
                () => result.ShouldContain("<![CDATA["),
                () => result.ShouldContain("NavLink"));
        }

        [TestMethod]
        public void RemoveNavigationLink_OnValidCall_ConfirmResult()
        {
            // Arrange
            var removed = false;
            var guid = "EFFA3011-4F47-4072-B035-CC3E12DBA08A";
            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimGenericLinkProvider.AllInstances.RemoveGuid = (_, __) => removed = true;
            InitConstructorSPWeb();

            // Act
            _testObj.RemoveNavigationLink(guid);

            // Assert
            removed.ShouldBeTrue();
        }

        [TestMethod]
        public void ReorderLinks_OnValidCall_ConfirmResult()
        {
            // Arrange
            var reordered = false;
            var guid = "EFFA3011-4F47-4072-B035-CC3E12DBA08A";
            InitConstructorSPWeb();

            ShimGenericLinkProvider.ConstructorGuidGuidString = (_, __, ___, ____) => { };
            ShimGenericLinkProvider.AllInstances.ReorderDictionaryOfGuidInt32 = (_, __) => reordered = true;

            // Act
            _testObj.ReorderLinks($"{guid}:{DummyInt}");

            // Assert
            reordered.ShouldBeTrue();
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
                var result = _privateType.InvokeStatic("LPPFEPermissionCheck", new ShimSPList().Instance, permission) as bool?;

                result.ShouldSatisfyAllConditions(
                    () => result.ShouldNotBeNull(),
                    () => result.Value.ShouldBeTrue());
            }
        }
    }
}
