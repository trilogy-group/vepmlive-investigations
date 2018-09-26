using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Fakes;
using System.Globalization;
using System.Net.Fakes;
using System.Reflection;
using EPMLiveCore.Fakes;
using EPMLiveCore.SPUtilities.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    public partial class CoreFunctionsRemTests
    {
        private const string GetWebAppSettingMethodName = "getWebAppSetting";
        private const string SetWebAppSettingMethodName = "setWebAppSetting";
        private const string SetConnectionStringMethodName = "setConnectionString";
        private const string CreateSiteMethodName = "createSite";
        private const string AddGroupMethodName = "AddGroup";
        private const string WebExistsUnderParentWebMethodName = "WebExistsUnderParentWeb";
        private const string GetLicenseCountMethodName = "getLicenseCount";
        private const string CheckServerCountMethodName = "checkServerCount";
        private const string GetFeatureLicenseUserCountMethodName = "getFeatureLicenseUserCount";

        private void SetupShimsSplitTwo()
        {
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPWebService.ContentServiceGet = () => new ShimSPWebService()
            {
                WebApplicationsGet = () => new ShimSPWebApplicationCollection()
            };
            ShimSPPersistedObjectCollection<SPWebApplication>.AllInstances.ItemGetGuid = (_, _1) => new ShimSPWebApplication();
            ShimSPRoleAssignment.ConstructorSPPrincipal = (_, __) => new ShimSPRoleAssignment();
            ShimSPRoleAssignment.AllInstances.RoleDefinitionBindingsGet = _ => new ShimSPRoleDefinitionBindingCollection();
        }

        [TestMethod]
        public void GetWebAppSetting_WhenCalled_ReturnsString()
        {
            // Arrange
            const string setting = "setting";
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable()
            {
                [setting] = string.Empty
            };
            ShimConfigurationManager.AppSettingsGet = () => new NameValueCollection()
            {
                [setting] = DummyString
            };
            ShimCoreFunctions.setWebAppSettingGuidStringString = (_, key, value) =>
            {
                if (key.Equals(setting) && value.Equals(DummyString))
                {
                    methodHit = true;
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetWebAppSettingMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, setting });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void SetWebAppSetting_SettingsPresent_UpdatesApplication()
        {
            // Arrange
            const string setting = "setting";
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable()
            {
                [setting] = string.Empty
            };
            ShimSPWebApplication.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObject.Invoke(
                SetWebAppSettingMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, setting, DummyString });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void SetWebAppSetting_SettingsNotPresent_UpdatesApplication()
        {
            // Arrange
            const string setting = "setting";
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPWebApplication.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            privateObject.Invoke(
                SetWebAppSettingMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, setting, DummyString });

            // Assert
            methodHit.ShouldBeTrue();
        }

        [TestMethod]
        public void SetConnectionString_SettingsPresent_UpdatesApplication()
        {
            // Arrange
            const string setting = "epmlivecn";
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable()
            {
                [setting] = string.Empty
            };
            ShimSPWebApplication.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SetConnectionStringMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void SetConnectionString_SettingsNotPresent_UpdatesApplication()
        {
            // Arrange
            const string setting = "epmlivecn";
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPWebApplication.AllInstances.Update = _ =>
            {
                methodHit = true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SetConnectionStringMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { guid, DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateSite_UniqueTrue_Creates()
        {
            // Arrange
            const string title = "";
            const string description = "";
            const string url = "";
            const string template = "";
            const string user = "";
            const bool unique = true;
            const bool toplink = true;

            var validation = 0;
            var webExistsHit = 0;

            spWeb.Update = () =>
            {
                validation = validation + 1;
            };
            spWeb.RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
            {
                GetByIdInt32 = _ => new ShimSPRoleDefinition()
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => null;
            ShimCoreFunctions.WebExistsUnderParentWebSPWebString = (_, __) =>
            {
                webExistsHit = webExistsHit + 1;
                return webExistsHit <= 1;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => "111~111";
            ShimSecurity.AddBasicSecurityToWorkspaceSPWebStringSPUser = (_, _1, _2) => null;
            ShimSPListUtility.MapListsReportingSPWebFuncOfSPListBoolean = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPRoleAssignmentCollection.AllInstances.AddSPRoleAssignment = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();

            // Act
            var actual = (string)privateObject.Invoke(
                CreateSiteMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { title, description, url, template, user, unique, toplink, spWeb.Instance, guid, string.Empty, string.Empty, string.Empty });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"0:{DummyString}"),
                () => validation.ShouldBe(5));
        }

        [TestMethod]
        public void CreateSite_UniqueFalse_Creates()
        {
            // Arrange
            const string title = "";
            const string description = "";
            const string url = "";
            const string template = "";
            const string user = "";
            const bool unique = false;
            const bool toplink = true;

            var validation = 0;
            var webExistsHit = 0;

            spWeb.Update = () =>
            {
                validation = validation + 1;
            };
            spWeb.ResetRoleInheritance = () =>
            {
                validation = validation + 1;
            };
            spWeb.RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
            {
                GetByIdInt32 = _ => new ShimSPRoleDefinition()
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => null;
            ShimCoreFunctions.WebExistsUnderParentWebSPWebString = (_, __) =>
            {
                webExistsHit = webExistsHit + 1;
                return webExistsHit <= 1;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => "111~111";
            ShimSPListUtility.MapListsReportingSPWebFuncOfSPListBoolean = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();

            // Act
            var actual = (string)privateObject.Invoke(
                CreateSiteMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { title, description, url, template, user, unique, toplink, spWeb.Instance, guid, string.Empty, string.Empty, string.Empty });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"0:{DummyString}"),
                () => validation.ShouldBe(4));
        }

        [TestMethod]
        public void AddGroup_FirstTimeNull_ReturnsString()
        {
            // Arrange
            var expected = $"{DummyString} {DummyString}";

            ShimSPGroupCollection.AllInstances.ItemGetString = (_, __) => null;
            ShimSPGroupCollection.AllInstances.AddStringSPMemberSPUserString = (_, _1, _2, _3, _4) => { };

            // Act
            var actual = (string)privateObject.Invoke(
                AddGroupMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, DummyString, DummyString, null, spUser.Instance, DummyString });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void AddGroup_FirstTimeNotNull_ReturnsString()
        {
            // Arrange
            var expected = $"{DummyString} {DummyString} 9";
            var spGroup = new ShimSPGroup();
            var methodHit = 0;

            ShimSPGroupCollection.AllInstances.ItemGetString = (_, __) =>
            {
                methodHit = methodHit + 1;
                if (methodHit == 10)
                {
                    throw new Exception();
                }
                return spGroup;
            };
            ShimSPGroupCollection.AllInstances.AddStringSPMemberSPUserString = (_, _1, _2, _3, _4) => { };

            // Act
            var actual = (string)privateObject.Invoke(
                AddGroupMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, DummyString, DummyString, null, spUser.Instance, DummyString });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void WebExistsUnderParentWeb_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            ShimSPWebCollection.AllInstances.ItemGetString = (_, __) => spWeb;
            spWeb.ExistsGet = () => true;

            // Act
            var actual = (bool)privateObject.Invoke(
                WebExistsUnderParentWebMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, DummyString });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void GetLicenseCount_ExpirationNA_ReturnsInt()
        {
            // Arrange
            const string keyString = "EPMLiveKeys";
            const string expiration = "NA";
            const int serverCount = 111;
            const int featureId = 111;
            const int userCount = 0;

            var keys = $"\n{featureId}\n{userCount}\n\n{expiration}\n{serverCount}\t{DummyString}";
            var propertiesHit = 0;
            var hashTable = new Hashtable()
            {
                [keyString] = string.Empty
            };

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ =>
            {
                propertiesHit = propertiesHit + 1;

                if (propertiesHit > 1)
                {
                    hashTable[keyString] = keys;
                }

                return hashTable;
            };
            ShimCoreFunctions.farmEncodeString = input => DummyString;
            ShimCoreFunctions.DecryptStringString = (input, _) => input;
            ShimCoreFunctions.checkServerCountInt32BooleanOut = (int serverCountParam, out bool badservers) =>
            {
                badservers = false;
                return true;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                GetLicenseCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { featureId, true, true });

            // Assert
            actual.ShouldBe(-1);
        }

        [TestMethod]
        public void GetLicenseCount_ExpirationNotNA_ReturnsInt()
        {
            // Arrange
            const string keyString = "EPMLiveKeys";
            const int serverCount = 111;
            const int featureId = 111;
            const int userCount = 100;

            var expiration = DateTime.Now.AddDays(10).ToString(new CultureInfo(1033));
            var keys = $"\n{featureId}\n{userCount}\n\n{expiration}\n{serverCount}\t{DummyString}";
            var propertiesHit = 0;
            var hashTable = new Hashtable()
            {
                [keyString] = string.Empty
            };

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ =>
            {
                propertiesHit = propertiesHit + 1;

                if (propertiesHit > 1)
                {
                    hashTable[keyString] = keys;
                }

                return hashTable;
            };
            ShimCoreFunctions.farmEncodeString = input => DummyString;
            ShimCoreFunctions.DecryptStringString = (input, _) => input;
            ShimCoreFunctions.checkServerCountInt32BooleanOut = (int serverCountParam, out bool badservers) =>
            {
                badservers = false;
                return false;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                GetLicenseCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { featureId, true, true });

            // Assert
            actual.ShouldBe(userCount);
        }

        [TestMethod]
        public void CheckServerCount_FarmServersLessThanServerCount_ReturnsBoolean()
        {
            // Arrange
            const int serverCount = 10;

            var server = new ShimSPServer()
            {
                RoleGet = () => SPServerRole.WebFrontEnd
            };

            spFarm.ServersGet = () => new ShimSPServerCollection();
            ShimSPPersistedObjectCollection<SPServer>.AllInstances.GetEnumerator = _ => new List<SPServer>()
            {
                server,
                server
            }.GetEnumerator();

            // Act
            var actual = (bool)privateObject.Invoke(
                CheckServerCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { serverCount, true });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckServerCount_EPMServersGreaterThanServerCount_ReturnsBoolean()
        {
            // Arrange
            const int serverCount = 1;
            const string keyString = "EPMLiveServers";
            const string servers = "server1,server2,server3";

            var server = new ShimSPServer()
            {
                RoleGet = () => SPServerRole.WebFrontEnd
            };
            var hashTable = new Hashtable()
            {
                [keyString] = servers
            };

            spFarm.ServersGet = () => new ShimSPServerCollection();
            ShimSPPersistedObjectCollection<SPServer>.AllInstances.GetEnumerator = _ => new List<SPServer>()
            {
                server,
                server
            }.GetEnumerator();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (bool)privateObject.Invoke(
                CheckServerCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { serverCount, true });

            // Assert
            actual.ShouldBeFalse();
        }

        [TestMethod]
        public void CheckServerCount_EPMServersLessThanServerCount_ReturnsBoolean()
        {
            // Arrange
            const int serverCount = 3;
            const string keyString = "EPMLiveServers";
            const string servers = "server1,server2";
            const string serverName = "server2";

            var methodHit = false;
            var server = new ShimSPServer()
            {
                RoleGet = () => SPServerRole.WebFrontEnd
            };
            var hashTable = new Hashtable()
            {
                [keyString] = servers
            };

            spFarm.ServersGet = () => new ShimSPServerCollection();
            ShimSPPersistedObjectCollection<SPServer>.AllInstances.GetEnumerator = _ => new List<SPServer>()
            {
                server,
                server,
                server,
                server
            }.GetEnumerator();
            ShimDns.GetHostName = () =>
            {
                methodHit = true;
                return serverName;
            };
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (bool)privateObject.Invoke(
                CheckServerCountMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { serverCount, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void GetFeatureLicenseUserCount_CountNegative_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getLicenseCountInt32BooleanOutBooleanOut = (int checkFeatureId, out bool foundFeature, out bool badservers) =>
            {
                foundFeature = true;
                badservers = false;
                return -1;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetFeatureLicenseUserCountMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { 1 });

            // Assert
            actual.ShouldBe("Unlimited");
        }

        [TestMethod]
        public void GetFeatureLicenseUserCount_Exception_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getLicenseCountInt32BooleanOutBooleanOut = (int checkFeatureId, out bool foundFeature, out bool badservers) =>
            {
                throw new Exception();
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetFeatureLicenseUserCountMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { 1 });

            // Assert
            actual.ShouldBe("0");
        }

        [TestMethod]
        public void GetFeatureLicenseUserCount_CountOther_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getLicenseCountInt32BooleanOutBooleanOut = (int checkFeatureId, out bool foundFeature, out bool badservers) =>
            {
                foundFeature = true;
                badservers = false;
                return 10;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetFeatureLicenseUserCountMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { 1 });

            // Assert
            actual.ShouldBe("10");
        }
    }
}