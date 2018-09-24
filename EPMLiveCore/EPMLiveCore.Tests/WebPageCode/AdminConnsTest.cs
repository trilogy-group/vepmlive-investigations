using System;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass]
    public class AdminConnsTest
    {
        private const string GetVersionSql = "SELECT TOP 1 VERSION FROM VERSIONS order by dtInstalled DESC";
        private const string TestConnectionString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
        private const string WebAppId = "D4A8A5A3-5C26-45D0-876C-AC2B4FB86DAA";
        private const string InsertVersionSql = "INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())";
        private const string txtConnStringField = "txtConnString";
        private const string LblStatusDynField = "lblStatusDyn";
        private const string LblVersionField = "lblVersion";
        private const string BtnUpgradeField = "btnUpgrade";
        private const string WebApplicationSelector1Field = "WebApplicationSelector1";
        private const string GetConnSettingsMethod = "GetConnSettings";
        private const string BtnUpgradeClickMethod = "btnUpgrade_Click";
        private const string ConnectionTestMethod = "ConnectionTest";

        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        private adminconns _testObj;
        private PrivateObject _privateObj;
        private StubWebApplicationSelector _webAppSelector;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _testObj = new adminconns();
            _privateObj = new PrivateObject(_testObj);

            ShimCoreFunctions.getConnectionStringGuid = (guid) => TestConnectionString;

            var webApp = new ShimSPWebApplication();
            var persistedObject = new ShimSPPersistedObject(webApp);
            persistedObject.IdGet = () => Guid.Parse(WebAppId);
            _webAppSelector = new StubWebApplicationSelector
            {
                GetItem01 = () => webApp
            };
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetConnSettings_ExecutesQuery()
        {
            // Arrange
            _privateObj.SetField(txtConnStringField, new TextBox());
            _privateObj.SetField(LblStatusDynField, new Label());
            _privateObj.SetField(LblVersionField, new Label());
            _privateObj.SetField(BtnUpgradeField, new Button());
            _privateObj.SetField(WebApplicationSelector1Field, _webAppSelector);

            // Act
            _privateObj.Invoke(GetConnSettingsMethod);

            // Assert
            Assert.IsTrue(_adoShims.IsConnectionCreated(TestConnectionString));
            Assert.IsTrue(_adoShims.IsConnectionDisposed(TestConnectionString));
            Assert.IsTrue(_adoShims.IsCommandManagedCorrectly(GetVersionSql));
            Assert.IsTrue(_adoShims.IsDataReaderCreatedForCommand(GetVersionSql));
            Assert.IsTrue(_adoShims.IsDataReaderDisposedForCommand(GetVersionSql));
        }

        [TestMethod]
        public void btnUpgrade_Click_ExecutesNonQueries()
        {
            // Arrange
            _privateObj.SetField(WebApplicationSelector1Field, _webAppSelector);
            ShimPage.AllInstances.ResponseGet = (instance) => new ShimHttpResponse();
            var args = new object[] { null, null };

            // Act
            _privateObj.Invoke(BtnUpgradeClickMethod, args);

            // Assert
            Assert.IsTrue(_adoShims.IsConnectionCreated(TestConnectionString));
            Assert.IsTrue(_adoShims.IsConnectionDisposed(TestConnectionString));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._0Tables01));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._0Tables01));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._0Tables02));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._0Tables02));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._1Views01));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._1Views01));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._2SPs01));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._2SPs01));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._9Data01));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._9Data01));
            Assert.IsTrue(_adoShims.IsCommandCreated(Properties.Resources._9Data02));
            Assert.IsTrue(_adoShims.IsCommandDisposed(Properties.Resources._9Data02));
            Assert.IsTrue(_adoShims.IsCommandCreated(InsertVersionSql));
            Assert.IsTrue(_adoShims.IsCommandDisposed(InsertVersionSql));
        }

        [TestMethod]
        public void ConnectionTest_OpensConnection()
        {
            // Arrange
            var args = new object[] { TestConnectionString };

            // Act
            var actual = _privateObj.Invoke(ConnectionTestMethod, args);

            // Assert
            Assert.AreEqual(false, actual);
            Assert.IsTrue(_adoShims.IsConnectionCreated(string.Empty));
            Assert.IsTrue(_adoShims.IsConnectionDisposed(string.Empty));
        }
    }
}
