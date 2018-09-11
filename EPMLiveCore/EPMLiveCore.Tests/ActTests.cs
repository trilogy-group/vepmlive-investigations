using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using EPMLiveAccountManagement.Fakes;
using EPMLiveCore.ActLicensing.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ActTests
    {
        private Act testObj;
        private PrivateObject privateObj;
        private IDisposable shimsContext;
        private ShimSPSite spSite;
        private ShimSPWeb spWeb;
        private Guid guid;
        private Dictionary<int, string> featureNameV2;
        private Dictionary<int, string> featureNameV1;
        private const string ConnectionString = "ConnectionString";
        private const string DummyString = "DummyString";
        private const string Url = "http://sampleurl.com";
        private const string UserName = "domain\\username";
        private const string SystemUserName = "sharepoint\\system";
        private const string ActivationColumn = "activation";
        private const string LevelColumn = "Level";
        private const string FeaturesColumn = "Features";
        private const string LevelNameColumn = "LevelName";
        private const string MaxUsersColumn = "MaxUsers";
        private const string UserLevelColumn = "userLevel";
        private const string ResLevelColumn = "ResLevel";
        private const string UserCountColumn = "UserCount";
        private const string QuantityColumn = "quantity";
        private const string OwnerUsername = "OwnerUsername";
        private const string CheckOnlineFeatureLicenseMethod = "CheckOnlineFeatureLicense";
        private const string TranslateStatusMethodName = "translateStatus";
        private const string SetUserActivationMethodName = "SetUserActivation";
        private const string CheckOnsiteFeatureLicenseMethodName = "CheckOnsiteFeatureLicense";
        private const string CheckFeatureLicenseMethodName = "CheckFeatureLicense";
        private const string SetUserLevelV3MethodName = "SetUserLevelV3";
        private const string GetLevelsFromSiteMethodName = "GetLevelsFromSite";
        private const string GetFarmFeatureUsersMethodName = "GetFarmFeatureUsers";
        private const string GetFeatureUsersMethodName = "GetFeatureUsers";
        private const string GetActivatedLevelsMethodName = "GetActivatedLevels";
        private const string GetFeatureNameV2MethodName = "GetFeatureNameV2";
        private const string GetFeatureNameMethodName = "GetFeatureName";
        private const string GetAllAvailableLevelsMethodName = "GetAllAvailableLevels";

        [TestInitialize]
        public void SetUp()
        {
            SetupShims();

            testObj = new Act(spWeb.Instance);
            privateObj = new PrivateObject(testObj);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimCoreFunctions.GetRealUserNameStringSPSite = (_, __) => UserName;
            ShimLicensing.AllInstances.SetUserLevelStringInt32 = (_, _1, feature) => feature;
            ShimSettings.getConnectionStringByWebAppString = _ => ConnectionString;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader()
            {
                Read = () => true,
                GetStringInt32 = index =>
                {
                    if (index == 13)
                    {
                        return OwnerUsername;
                    }

                    return string.Empty;
                },
                Close = () => { }
            };
            ShimSqlConnection.ConstructorString = (_, __) => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => spWeb
            };
            ShimSPPersistedObject.AllInstances.FarmGet = _ => new ShimSPFarm()
            {
                Update = () => { }
            };
            ShimSPPersistedObject.AllInstances.GetChildOf1String<UserManager>((_, _1) => null);
            ShimSPPersistedObject.AllInstances.Update = _ => { };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPAdministrationWebApplication.LocalGet = () => new ShimSPAdministrationWebApplication();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPWebApplication.AllInstances.SitesGet = _ => new ShimSPSiteCollection()
            {
                ItemGetInt32 = index => spSite
            };

            var userPairs = new KeyValuePair<int, UserLevel>(
                1,
                new UserLevel()
                {
                    id = 1,
                    levels = new int[]
                    {
                        (int)ActFeature.Reporting
                    }
                });
            ShimUserLevels.AllInstances.GetEnumerator = _ => new List<KeyValuePair<int, UserLevel>>()
            {
                userPairs
            }.GetEnumerator();
        }

        private void SetupVariables()
        {
            guid = Guid.NewGuid();

            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                UrlGet = () => Url,
                WebApplicationGet = () => new ShimSPWebApplication()
                {
                    FeaturesGet = () => new ShimSPFeatureCollection()
                    {
                        ItemGetGuid = _ => new ShimSPFeature()
                    }
                }
            };

            spWeb = new ShimSPWeb()
            {
                SiteGet = () => spSite,
                CurrentUserGet = () => new ShimSPUser()
                {
                    LoginNameGet = () => UserName
                }
            };

            featureNameV2 = new Dictionary<int, string>()
            {
                [1] = "Team Member",
                [2] = "Project Manager",
                [3] = "Full User",
                [1000] = "Unknown User Type"
            };

            featureNameV1 = new Dictionary<int, string>()
            {
                [0] = "WebPart Base",
                [1] = "Work Planner",
                [2] = "Resource Planner",
                [3] = "Timesheets",
                [4] = "Enterprise Base",
                [5] = "Reporting",
                [6] = "Agile Planner",
                [7] = "PortfolioEngine Core",
                [8] = "MyWork WebPart",
                [9] = "Communities and Applications",
                [1000] = "Unknown Feature"
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        private DataSet CreateDataSet(int activationType, int levelValue, int resLevelValue, int userCount, int quantity, string features, int userLevel)
        {
            var dSet = new DataSet();

            var dTable = new DataTable();
            dTable.Columns.Add(ActivationColumn, typeof(int));
            var row = dTable.NewRow();
            row[ActivationColumn] = activationType;
            dTable.Rows.Add(row);
            dSet.Tables.Add(dTable);

            dTable = new DataTable();
            dTable.Columns.Add(LevelColumn, typeof(int));
            dTable.Columns.Add(ResLevelColumn, typeof(int));
            dTable.Columns.Add(FeaturesColumn, typeof(string));
            dTable.Columns.Add(UserCountColumn, typeof(int));
            dTable.Columns.Add(QuantityColumn, typeof(int));
            dTable.Columns.Add(MaxUsersColumn, typeof(int));
            dTable.Columns.Add(LevelNameColumn, typeof(string));
            row = dTable.NewRow();
            row[LevelColumn] = levelValue;
            row[ResLevelColumn] = resLevelValue;
            row[FeaturesColumn] = features;
            row[UserCountColumn] = userCount;
            row[QuantityColumn] = quantity;
            row[MaxUsersColumn] = quantity;
            row[LevelNameColumn] = LevelNameColumn;
            dTable.Rows.Add(row);
            dSet.Tables.Add(dTable);

            dTable = new DataTable();
            dTable.Columns.Add(UserLevelColumn, typeof(int));
            row = dTable.NewRow();
            row[UserLevelColumn] = userLevel;
            dTable.Rows.Add(row);
            dSet.Tables.Add(dTable);

            return dSet;
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType0_Returns7()
        {
            // Arrange
            const int activationType = 0;
            const int expectedOutput = 7;

            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, 0, 0, 0, 0, string.Empty, 0);

            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, ActFeature.ProjectServer, UserName, site);

            // Assert
            Assert.AreEqual(expectedOutput, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1TeamMember_Returns6()
        {
            // Arrange
            const int expected = 6;
            const int userLevel = 5;
            const int levelValue = 1;

            var feature = (ActFeature)3;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1TeamMember_Returns5()
        {
            // Arrange
            const int expected = 5;
            const int userLevel = 5;
            const int levelValue = 1;

            var feature = (ActFeature)7;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1ProjectManager_Returns6()
        {
            // Arrange
            const int expected = 6;
            const int userLevel = 5;
            const int levelValue = 2;

            var feature = (ActFeature)3;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1ProjectManager_Returns5()
        {
            // Arrange
            const int expected = 5;
            const int userLevel = 5;
            const int levelValue = 2;

            var feature = (ActFeature)7;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1FullUser_Returns6()
        {
            // Arrange
            const int expected = 6;
            const int userLevel = 5;
            const int levelValue = 4;

            var feature = (ActFeature)7;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actual = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1SystemUser_Returns0()
        {
            // Arrange
            const int userLevel = 5;
            const int levelValue = 4;

            var feature = (ActFeature)1;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var systemUserOutput = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, SystemUserName, site);

            // Assert
            Assert.AreEqual(0, systemUserOutput);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type1UserLevel1_Returns0()
        {
            // Arrange
            const int userLevel = 1;
            const int levelValue = 4;

            var feature = (ActFeature)1;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(1, levelValue, 0, 0, 0, string.Empty, 1);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var userLevelOutput = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(0, userLevelOutput);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type3SystemUser_Returns0()
        {
            // Arrange
            const int activationType = 3;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 9999;

            var feature1 = (ActFeature)0;
            var feature2 = (ActFeature)5;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualSystemUser = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature1, SystemUserName, site);

            // Assert
            Assert.AreEqual(0, actualSystemUser);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type3InvalidUer_Returns0()
        {
            // Arrange
            const int activationType = 3;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 9999;

            var feature1 = (ActFeature)0;
            var feature2 = (ActFeature)5;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualUserr = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature2, UserName, site);

            // Assert
            Assert.AreEqual(0, actualUserr);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType3_Returns5()
        {
            // Arrange
            const int activationType = 3;
            const string features1 = "8,9";
            const string features2 = "0,1,2,3,4";
            const int userLevel = 5;
            const int quantity = 10;

            var feature1 = (ActFeature)0;
            var feature2 = (ActFeature)5;
            var site = new ShimSPSite().Instance;

            var dSet = CreateDataSet(activationType, 0, userLevel, (quantity - 1), quantity, features1, userLevel);

            var row = dSet.Tables[1].NewRow();
            row[ResLevelColumn] = 1;
            row[UserCountColumn] = quantity - 1;
            row[QuantityColumn] = quantity;
            row[FeaturesColumn] = features2;
            dSet.Tables[1].Rows.Add(row);

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => dSet;
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualNotPurchased = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature2, UserName, site);

            // Assert
            Assert.AreEqual(5, actualNotPurchased);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType3_Returns6()
        {
            // Arrange
            const int activationType = 3;
            const string features1 = "8,9";
            const string features2 = "0,1,2,3,4";
            const int userLevel = 5;
            const int quantity = 10;

            var feature1 = (ActFeature)0;
            var feature2 = (ActFeature)5;
            var site = new ShimSPSite().Instance;

            var dSet = CreateDataSet(activationType, 0, userLevel, (quantity - 1), quantity, features1, userLevel);

            var row = dSet.Tables[1].NewRow();
            row[ResLevelColumn] = 1;
            row[UserCountColumn] = quantity - 1;
            row[QuantityColumn] = quantity;
            row[FeaturesColumn] = features2;
            dSet.Tables[1].Rows.Add(row);

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => dSet;
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualPurchased = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature1, UserName, site);

            // Assert
            Assert.AreEqual(6, actualPurchased);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType3_HasAccess()
        {
            // Arrange
            const int activationType = 3;
            const string features = "0,1,2,3,4";
            const int resLevel = 5;
            const int userLevel = 5;
            const int quantity = 10;

            var feature1 = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, 0, resLevel, (quantity - 1), quantity, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualPurchased = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature1, UserName, site);

            // Assert
            Assert.AreEqual(0, actualPurchased);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType3_Returns2()
        {
            // Arrange
            const int activationType = 3;
            const string features = "0,1,2,3,4";
            const int resLevel = 5;
            const int userLevel = 5;
            const int quantity = 10;

            var feature1 = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, 0, resLevel, (quantity + 1), quantity, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualPurchased = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature1, UserName, site);

            // Assert
            Assert.AreEqual(2, actualPurchased);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type2SystemUser_Returns0()
        {
            // Arrange
            const int activationType = 2;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 1;

            var feature = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualSystemUser = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, SystemUserName, site);

            // Assert
            Assert.AreEqual(0, actualSystemUser);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_Type2NoAccess_Returns0()
        {
            // Arrange
            const int activationType = 2;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 1;

            var feature = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualUserr = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(0, actualUserr);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_ActivationType2_Returns6()
        {
            // Arrange
            const int activationType = 2;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 5;

            var feature = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualUserr = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(6, actualUserr);
        }

        [TestMethod]
        public void CheckOnlineFeatureLicense_InvalidActivationType_ReturnsNegative()
        {
            // Arrange
            const int activationType = 5;
            const string features = "0,1,2,3,4";
            const int levelValue = 1;
            const int userLevel = 5;

            var feature = (ActFeature)0;
            var site = new ShimSPSite().Instance;

            ShimAccountManagement.GetActivationInfoGuidString = (_, __) => CreateDataSet(activationType, levelValue, 0, 0, 0, features, userLevel);
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;

            // Act
            var actualUserr = (int)privateObj.Invoke(CheckOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(-1, actualUserr);
        }

        [TestMethod]
        public void TranslateStatus_Status1_ReturnsString()
        {
            // Arrange
            const int status = 1;
            const string expected = "This feature has not been activated.";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status2_ReturnsString()
        {
            // Arrange
            const int status = 2;
            const string expected = "Too many users activated for this feature.";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status3_ReturnsString()
        {
            // Arrange
            const int status = 3;
            const string expected = "Server not licensed.";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_StatusNegative1_ReturnsString()
        {
            // Arrange
            const int status = -1;
            const string expected = "Unable to retrieve activation status.";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status5_ReturnsString()
        {
            // Arrange
            const int status = 5;
            const string expected = "You have not purchased this feature";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status6_ReturnsString()
        {
            // Arrange
            const int status = 6;
            const string expected = "You have not been given access to this feature";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status7_ReturnsString()
        {
            // Arrange
            const int status = 7;
            const string expected = "You trial has expired";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status8_ReturnsString()
        {
            // Arrange
            const int status = 8;
            const string expected = "The EPM Live Core Feature is not activated";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_Status1000_ReturnsString()
        {
            // Arrange
            const int status = 1000;
            const string expected = "Custom Text";

            privateObj.SetFieldOrProperty("bLatestError", BindingFlags.Instance | BindingFlags.Public, expected);

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void TranslateStatus_InvalidStatus_ReturnsString()
        {
            // Arrange
            const int status = 100;
            const string expected = "General license failure.";

            // Act
            var actual = (string)privateObj.Invoke(
                TranslateStatusMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { status });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void SetUserActivation_WhenCalled_ReturnsInt()
        {
            // Arrange
            const int feature = 1;
            const string userName = "username";

            // Act
            var actual = (int)privateObj.Invoke(
                SetUserActivationMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, userName, spSite.Instance });

            // Assert
            actual.ShouldBe(feature);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation2_Returns0()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 2;
                var result = new SortedList();
                result.Add((int)feature, 0);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(0);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation2SystemUser_Returns0()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 2;
                var result = new SortedList();
                result.Add((int)feature, 1);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, SystemUserName, spSite.Instance });

            // Assert
            actual.ShouldBe(0);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation2NotSystemUser_Returns0()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 2;
                var result = new SortedList();
                result.Add((int)feature, 1);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe((int)feature);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation3SystemUser_Returns0()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 3;
                var result = new SortedList();
                result.Add(1, 1);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, SystemUserName, spSite.Instance });

            // Assert
            actual.ShouldBe(0);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation3NotSystemUser_Returns2()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 3;
                var result = new SortedList();
                result.Add(1, 0);
                return result;
            };
            ShimAct.AllInstances.GetFeatureUsersInt32 = (_, _1) => new ArrayList()
            {
                $"{UserName}:1"
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(2);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation3NotSystemUser_Returns0()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 3;
                var result = new SortedList();
                result.Add(1, 2);
                return result;
            };
            ShimAct.AllInstances.GetFeatureUsersInt32 = (_, _1) => new ArrayList()
            {
                $"{UserName}:1"
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(0);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation3NotSystemUser_Returns6()
        {
            // Arrange
            var feature = ActFeature.Reporting;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 3;
                var result = new SortedList();
                result.Add(1, 2);
                return result;
            };
            ShimAct.AllInstances.GetFeatureUsersInt32 = (_, _1) => new ArrayList()
            {
                $"{UserName}:2"
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(6);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_Activation3NotSystemUser_Returns5()
        {
            // Arrange
            var feature = ActFeature.WebParts;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 3;
                var result = new SortedList();
                result.Add(1, 2);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(5);
        }

        [TestMethod]
        public void CheckOnsiteFeatureLicense_InvalidActivation_Returns1()
        {
            // Arrange
            var feature = ActFeature.WebParts;

            ShimAct.GetAllAvailableLevelsInt32Out = (out int activationType) =>
            {
                activationType = 5;
                var result = new SortedList();
                result.Add(1, 2);
                return result;
            };

            // Act
            var actual = (int)privateObj.Invoke(
                CheckOnsiteFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { feature, UserName, spSite.Instance });

            // Assert
            actual.ShouldBe(1);
        }

        [TestMethod]
        public void CheckFeatureLicense_IsOnlineTrue_ReturnsInt()
        {
            // Arrange
            const int expected = 10;

            ShimAct.AllInstances.CheckOnlineFeatureLicenseActFeatureStringSPSite = (_, _1, _2, _3) => expected;

            // Act
            var actual = (int)privateObj.Invoke(
                CheckFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { ActFeature.AgilePlanner });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void CheckFeatureLicense_IsOnlineFalse_ReturnsInt()
        {
            // Arrange
            const int expected = 10;

            ShimAct.AllInstances.CheckOnsiteFeatureLicenseActFeatureStringSPSite = (_, _1, _2, _3) => expected;

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);

            // Act
            var actual = (int)privateObj.Invoke(
                CheckFeatureLicenseMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { ActFeature.AgilePlanner });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void SetUserLevelV3_IsOnlineTrue_SetsUserLevel()
        {
            // Arrange
            const int expected = 10;

            var actualLevel = -1;
            ShimAccountManagement.SetAccountUserLevelGuidStringInt32 = (_, _1, level) =>
            {
                actualLevel = level;
                return true;
            };

            // Act
            privateObj.Invoke(
                SetUserLevelV3MethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { UserName, expected });

            // Act
            actualLevel.ShouldBe(expected);
        }

        [TestMethod]
        public void SetUserLevelV3_IsOnlineFalse_SetsUserLevel()
        {
            // Arrange
            const int expectedLevel = 10;
            const string customError = "ErrorMessage";

            var expectedUserName = $"{UserName}:{expectedLevel}";
            var expectedMessage = $"Error setting level: {customError}";
            var actualUserName = string.Empty;
            var actualMessage = string.Empty;
            var levels = new ArrayList()
            {
                new ActLevel()
                {
                    id = expectedLevel,
                    availableactivations = 1,
                    isUserInLevel = false
                }
            };
            ShimAct.AllInstances.GetLevelsFromSiteInt32OutString = (Act instance, out int actType, string userName) =>
            {
                actType = 3;
                return levels;
            };
            ShimAct.AllInstances.SetUserActivationInt32StringSPSite = (_, _1, userName, _3) =>
            {
                actualUserName = userName;
                return 1;
            };

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);
            privateObj.SetFieldOrProperty("bLatestError", BindingFlags.Instance | BindingFlags.Public, customError);

            // Act
            try
            {
                privateObj.Invoke(
                    SetUserLevelV3MethodName,
                    BindingFlags.Instance | BindingFlags.Public,
                    new object[] { UserName, expectedLevel });
            }
            catch (Exception exception)
            {
                actualMessage = exception.Message;
            }

            // Act
            actualUserName.ShouldSatisfyAllConditions(
                () => actualUserName.ShouldBe(expectedUserName),
                () => actualMessage.ShouldBe(expectedMessage));
        }

        [TestMethod]
        public void GetLevelsFromSite_IsOnlineActivation1Level2_ReturnsArray()
        {
            // Arrange
            var activationType = 1;
            var level = 2;
            var dSet = CreateDataSet(activationType, level, 0, 5, 10, string.Empty, 1);

            ShimAccountManagement.GetActivationInfoGuidString = (_, _1) => dSet;

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe("No Access"),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeFalse(),
                () => ((ActLevel)actual[1]).name.ShouldBe("WorkEngine"),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeTrue());
        }

        [TestMethod]
        public void GetLevelsFromSite_IsOnlineActivation1Level4_ReturnsArray()
        {
            // Arrange
            var activationType = 1;
            var level = 4;
            var dSet = CreateDataSet(activationType, level, 0, 5, 10, string.Empty, 0);

            ShimAccountManagement.GetActivationInfoGuidString = (_, _1) => dSet;

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe("No Access"),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeTrue(),
                () => ((ActLevel)actual[1]).name.ShouldBe("PortfolioEngine"),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeFalse());
        }

        [TestMethod]
        public void GetLevelsFromSite_IsOnlineActivation2_ReturnsArray()
        {
            // Arrange
            var activationType = 2;
            var level = 2;
            var dSet = CreateDataSet(activationType, level, 0, 5, 10, string.Empty, 1);

            ShimAccountManagement.GetActivationInfoGuidString = (_, _1) => dSet;

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe("No Access"),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeFalse(),
                () => ((ActLevel)actual[1]).name.ShouldBe("Trial User"),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeTrue());
        }

        [TestMethod]
        public void GetLevelsFromSite_IsOnlineActivation3_ReturnsArray()
        {
            // Arrange
            var activationType = 3;
            var level = 2;
            var dSet = CreateDataSet(activationType, level, level, 5, 10, string.Empty, level);

            ShimAccountManagement.GetActivationInfoGuidString = (_, _1) => dSet;

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe("No Access"),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeTrue(),
                () => ((ActLevel)actual[1]).name.ShouldBe(LevelNameColumn),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(5),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeTrue());
        }

        [TestMethod]
        public void GetLevelsFromSite_IsNotOnlineActivation1_ReturnsArray()
        {
            // Arrange
            var activationType = 1;
            var sortedList = new SortedList();
            sortedList.Add(1, 10);
            sortedList.Add(2, 10);

            ShimAct.GetAllAvailableLevelsInt32Out = (out int outValue) =>
            {
                outValue = activationType;
                return sortedList;
            };
            ShimAct.AllInstances.GetFeatureUsersInt32 = (_, key) =>
            {
                var result = new ArrayList();
                if (key == 1)
                {
                    result.Add(UserName);
                }
                else
                {
                    result.Add(SystemUserName);
                }
                return result;
            };
            ShimAct.GetFeatureNameString = _ => DummyString;

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe(DummyString),
                () => ((ActLevel)actual[0]).totalactivations.ShouldBe(10),
                () => ((ActLevel)actual[0]).availableactivations.ShouldBe(1),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeTrue(),
                () => ((ActLevel)actual[1]).name.ShouldBe(DummyString),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(10),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(9),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeFalse());
        }

        [TestMethod]
        public void GetLevelsFromSite_IsNotOnlineActivation3_ReturnsArray()
        {
            // Arrange
            const string name1 = "Team Members";
            const string name2 = "Project Manager";

            var activationType = 3;
            var sortedList = new SortedList();
            sortedList.Add(1, 10);
            sortedList.Add(2, 10);
            var arrayList = new ArrayList();
            arrayList.Add($"{UserName}:1");
            arrayList.Add($"{SystemUserName}:1");

            ShimAct.GetAllAvailableLevelsInt32Out = (out int outValue) =>
            {
                outValue = activationType;
                return sortedList;
            };
            ShimAct.AllInstances.GetFeatureUsersInt32 = (_, key) =>
            {
                return arrayList;
            };
            ShimUserLevels.AllInstances.GetEnumerator = _ => new List<KeyValuePair<int, UserLevel>>()
            {
                new KeyValuePair<int, UserLevel>(1, new UserLevel()
                {
                    name = name1,
                    id = 1,
                    levels = new int[] { 0, 3, 4, 8 }
                }),
                new KeyValuePair<int, UserLevel>(2, new UserLevel()
                {
                    name = name2,
                    id = 2,
                    levels = new int[] { 0, 1, 2, 3, 4, 5, 6, 8, 9 }
                })
            }.GetEnumerator();

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetLevelsFromSiteMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { activationType, UserName });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => ((ActLevel)actual[0]).name.ShouldBe(name1),
                () => ((ActLevel)actual[0]).totalactivations.ShouldBe(10),
                () => ((ActLevel)actual[0]).availableactivations.ShouldBe(1),
                () => ((ActLevel)actual[0]).isUserInLevel.ShouldBeTrue(),
                () => ((ActLevel)actual[1]).name.ShouldBe(name2),
                () => ((ActLevel)actual[1]).totalactivations.ShouldBe(10),
                () => ((ActLevel)actual[1]).availableactivations.ShouldBe(10),
                () => ((ActLevel)actual[1]).isUserInLevel.ShouldBeFalse());
        }

        [TestMethod]
        public void GetFarmFeatureUsers_WhenCalled_ReturnsArrayList()
        {
            // Arrange and Act
            var actual = (ArrayList)privateObj.Invoke(
                GetFarmFeatureUsersMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { 1 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.Count.ShouldBe(1),
                () => actual[0].ToString().ShouldBe(string.Empty));
        }

        [TestMethod]
        public void GetFeatureUsers_WhenCalled_ReturnsArrayList()
        {
            // Arrange
            ShimAct.AllInstances.GetFarmFeatureUsersInt32 = (_, _1) => new ArrayList()
            {
                string.Empty
            };

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetFeatureUsersMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { 1 });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.Count.ShouldBe(0));
        }

        [TestMethod]
        public void GetActivatedLevels_IsOnlineTrue_ReturnsArrayList()
        {
            // Arrange
            var expected = new ArrayList()
            {
                UserName,
                SystemUserName
            };

            ShimAccountManagement.GetActivatedFeaturesGuid = _ => expected;

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetActivatedLevelsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(expected.Count),
                () => actual[0].ToString().ShouldBe(expected[0].ToString()),
                () => actual[1].ToString().ShouldBe(expected[1].ToString()));
        }

        [TestMethod]
        public void GetActivatedLevels_IsOnlineFalseType3_ReturnsArrayList()
        {
            // Arrange
            var sortedList = new SortedList();
            sortedList.Add(1, 10);
            sortedList.Add(2, 10);

            ShimAct.GetAllAvailableLevelsInt32Out = (out int type) =>
            {
                type = 3;
                return sortedList;
            };
            ShimUserLevels.AllInstances.GetEnumerator = _ => new List<KeyValuePair<int, UserLevel>>()
            {
                new KeyValuePair<int, UserLevel>(1, new UserLevel()
                {
                    name = UserName,
                    id = 1,
                    levels = new int[] { 0, 3, 4, 8 }
                }),
                new KeyValuePair<int, UserLevel>(2, new UserLevel()
                {
                    name = SystemUserName,
                    id = 2,
                    levels = new int[] { 0, 1, 2, 3, 4, 5, 6, 8, 9 }
                })
            }.GetEnumerator();

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetActivatedLevelsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(9),
                () => actual[0].ToString().ShouldBe(0.ToString()),
                () => actual[3].ToString().ShouldBe(8.ToString()),
                () => actual[6].ToString().ShouldBe(5.ToString()));
        }

        [TestMethod]
        public void GetActivatedLevels_IsOnlineFalseTypeNot3_ReturnsArrayList()
        {
            // Arrange
            var sortedList = new SortedList();
            sortedList.Add(1, 10);
            sortedList.Add(2, 10);

            ShimAct.GetAllAvailableLevelsInt32Out = (out int type) =>
            {
                type = 5;
                return sortedList;
            };

            privateObj.SetFieldOrProperty("_bIsOnline", BindingFlags.Instance | BindingFlags.NonPublic, false);

            // Act
            var actual = (ArrayList)privateObj.Invoke(
                GetActivatedLevelsMethodName,
                BindingFlags.Instance | BindingFlags.Public,
                new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[0].ToString().ShouldBe(1.ToString()),
                () => actual[1].ToString().ShouldBe(2.ToString()));
        }

        [TestMethod]
        public void GetFeatureNameV2_FeatureId1_ReturnsString()
        {
            // Arrange
            const int featureid = 1;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameV2MethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV2[featureid]);
        }

        [TestMethod]
        public void GetFeatureNameV2_FeatureId2_ReturnsString()
        {
            // Arrange
            const int featureid = 2;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameV2MethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV2[featureid]);
        }

        [TestMethod]
        public void GetFeatureNameV2_FeatureId3_ReturnsString()
        {
            // Arrange
            const int featureid = 3;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameV2MethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV2[featureid]);
        }

        [TestMethod]
        public void GetFeatureNameV2_FeatureIdOther_ReturnsString()
        {
            // Arrange
            const int featureid = 10;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameV2MethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV2[1000]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId0_ReturnsString()
        {
            // Arrange
            const int featureid = 0;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId1_ReturnsString()
        {
            // Arrange
            const int featureid = 1;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId2_ReturnsString()
        {
            // Arrange
            const int featureid = 2;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId3_ReturnsString()
        {
            // Arrange
            const int featureid = 3;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId4_ReturnsString()
        {
            // Arrange
            const int featureid = 4;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId5_ReturnsString()
        {
            // Arrange
            const int featureid = 5;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId6_ReturnsString()
        {
            // Arrange
            const int featureid = 6;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId7_ReturnsString()
        {
            // Arrange
            const int featureid = 7;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId8_ReturnsString()
        {
            // Arrange
            const int featureid = 8;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureId9_ReturnsString()
        {
            // Arrange
            const int featureid = 9;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[featureid]);
        }

        [TestMethod]
        public void GetFeatureName_FeatureIdOther_ReturnsString()
        {
            // Arrange
            const int featureid = 10;

            // Act
            var actual = (string)privateObj.Invoke(
                GetFeatureNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { featureid.ToString() });

            // Assert
            actual.ShouldBe(featureNameV1[1000]);
        }

        [TestMethod]
        public void GetAllAvailableLevels_AllFeaturestype2ExpiredNA_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 2;
            var expireDate = "NA";
            var feature = $"*2\n\n\n1:10,1:10\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }

        [TestMethod]
        public void GetAllAvailableLevels_AllFeaturestype2Expired_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 2;
            var culture = new CultureInfo(1033);
            var expireDate = DateTime.Now.AddDays(2).ToString(culture.DateTimeFormat.LongDatePattern);
            var feature = $"*2\n\n\n1:10,1:10\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }

        [TestMethod]
        public void GetAllAvailableLevels_AllFeaturestype3ExpiredNA_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 3;
            var expireDate = "NA";
            var feature = $"*3\n\n\n1:10,1:10\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }

        [TestMethod]
        public void GetAllAvailableLevels_AllFeaturestype3Expired_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 3;
            var culture = new CultureInfo(1033);
            var expireDate = DateTime.Now.AddDays(2).ToString(culture.DateTimeFormat.LongDatePattern);
            var feature = $"*3\n\n\n1:10,1:10\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }

        [TestMethod]
        public void GetAllAvailableLevels_Type1ExpiredNA_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 1;
            var expireDate = "NA";
            var feature = $"11\n1,1\n10\n\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }

        [TestMethod]
        public void GetAllAvailableLevels_Type1Expired_ReturnsSortedList()
        {
            // Arrange
            const string EPMLiveKeys = "EPMLiveKeys";
            const string value = "value";
            const string stringValue = "sValue";

            var output = $"{value}\t{stringValue}";
            var activationType = 1;
            var culture = new CultureInfo(1033);
            var expireDate = DateTime.Now.AddDays(2).ToString(culture.DateTimeFormat.LongDatePattern);
            var feature = $"11\n1,1\n10\n\n{expireDate}";

            var hashTable = new Hashtable();
            hashTable.Add(EPMLiveKeys, output);

            ShimAct.farmEncodeString = _ => stringValue;
            ShimCoreFunctions.DecryptStringString = (_, __) => feature;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => hashTable;

            // Act
            var actual = (SortedList)privateObj.Invoke(
                GetAllAvailableLevelsMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { activationType });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[1].ToString().ShouldBe(20.ToString()));
        }
    }
}