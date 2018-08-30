using System;
using System.Data;
using EPMLiveAccountManagement.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class ActTests
    {
        private Act _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;
        private const string UserName = "domain\\username";
        private const string SystemUserName = "sharepoint\\system";
        private const string ActivationColumn = "activation";
        private const string LevelColumn = "Level";
        private const string FeaturesColumn = "Features";
        private const string UserLevelColumn = "userLevel";
        private const string ResLevelColumn = "ResLevel";
        private const string UserCountColumn = "UserCount";
        private const string QuantityColumn = "quantity";
        private const string _checkOnlineFeatureLicenseMethod = "CheckOnlineFeatureLicense";

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => Guid.Empty,
                    WebApplicationGet = () => new ShimSPWebApplication()
                    {
                        FeaturesGet = () => new ShimSPFeatureCollection()
                        {
                            ItemGetGuid = _ => null
                        }.Instance
                    }
                }.Instance
            }.Instance;

            _testObj = new Act(web);
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
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
            row = dTable.NewRow();
            row[LevelColumn] = levelValue;
            row[ResLevelColumn] = resLevelValue;
            row[FeaturesColumn] = features;
            row[UserCountColumn] = userCount;
            row[QuantityColumn] = quantity;
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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, ActFeature.ProjectServer, UserName, site);

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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actual = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var systemUserOutput = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, SystemUserName, site);

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
            var userLevelOutput = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actualSystemUser = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature1, SystemUserName, site);

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
            var actualUserr = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature2, UserName, site);

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
            var actualNotPurchased = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature2, UserName, site);

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
            var actualPurchased = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature1, UserName, site);

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
            var actualPurchased = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature1, UserName, site);

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
            var actualPurchased = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature1, UserName, site);

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
            var actualSystemUser = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, SystemUserName, site);

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
            var actualUserr = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actualUserr = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

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
            var actualUserr = (int)_privateObj.Invoke(_checkOnlineFeatureLicenseMethod, feature, UserName, site);

            // Assert
            Assert.AreEqual(-1, actualUserr);
        }
    }
}
