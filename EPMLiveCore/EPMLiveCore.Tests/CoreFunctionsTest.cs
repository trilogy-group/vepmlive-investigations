using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class CoreFunctionsTest
    {
        private IDisposable _shimsContext;
        private AdoShims _adoShims;
        private SharepointShims _sharepointShims;

        private Guid _timerJobBuild;
        private int _defaultStatus;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _timerJobBuild = Guid.NewGuid();
            _defaultStatus = 1;
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void enqueue_SiteIsNull_Throw()
        {
            // Arrange
            SPSite site = null;

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, site);

            // Assert
            // ExpectedException - ArgumentNull
        }

        [TestMethod]
        public void enqueue_Always_RunsWithElevatedPriveleges()
        {
            // Arrange
            var isRunWithElevatedPriveleges = false;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action =>
            {
                isRunWithElevatedPriveleges = true;
            };

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            Assert.IsTrue(isRunWithElevatedPriveleges);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyManagesDatabaseConnection()
        {
            // Arrange
            const string connectionStringExpected = "test-connection-string";
            ShimCoreFunctions.getConnectionStringGuid = webApplicationId => connectionStringExpected;

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            Assert.AreEqual(1, _adoShims.ConnectionsCreated.Count);
            Assert.AreEqual(1, _adoShims.ConnectionsOpened.Count);
            Assert.AreEqual(1, _adoShims.ConnectionsDisposed.Count);
            Assert.IsTrue(_adoShims.IsConnectionCreated(connectionStringExpected));
            Assert.IsTrue(_adoShims.IsConnectionOpened(connectionStringExpected));
            Assert.IsTrue(_adoShims.IsConnectionDisposed(connectionStringExpected));
        }
    }
}
