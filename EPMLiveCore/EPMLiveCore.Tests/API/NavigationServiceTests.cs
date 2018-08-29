using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API
{
    [TestClass, ExcludeFromCodeCoverage]
    public class NavigationServiceTests
    {
        private IDisposable _shimObject;
        private NavigationService _testObj;
        private SPWeb _web;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com/";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimObject = ShimsContext.Create();

            _web = new ShimSPWeb().Instance;

            _testObj = new NavigationService(_web);

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
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
                        TitleGet = () => "Resource",
                        ParentWebGet = () => new ShimSPWeb()
                    }
                }
            };
            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };

            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimListCommands.GetGridGanttSettingsSPList = _ => new ShimGridGanttSettings();

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            // Act
            var result = _testObj.GetContextualMenuItems(data);

            // Assert
        }
    }
}
