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
        private string _spQuery;
        private string _filterFieldName;
        private string _useWbs;
        private string _listTitlePattern;
        private IList<string> _groupByFieldNames;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            _timerJobBuild = Guid.NewGuid();
            _defaultStatus = 1;

            _spQuery = string.Empty;
            _filterFieldName = string.Empty;
            _useWbs = string.Empty;
            _listTitlePattern = string.Empty;
            _groupByFieldNames = new List<string>();
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
            const string connectionStringExpected = @"Data Source=(local)\SQLExpress;Initial Catalog=MyDatabase;";
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

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesQueueStatusCommand()
        {
            // Arrange
            const string commandTextExpected = "select status from queue where timerjobuid=@timerjobuid";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsDataReaderCreatedForCommand(commandTextExpected);
            _adoShims.IsDataReaderDisposedForCommand(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesDeleteFromQueueCommand()
        {
            // Arrange
            const string commandTextExpected = "DELETE FROM QUEUE where timerjobuid = @timerjobuid ";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesDeleteFromLogCommand()
        {
            // Arrange
            const string commandTextExpected = "DELETE FROM EPMLIVE_LOG where timerjobuid = @timerjobuid ";
            const string commandParameterExpected = "@timerjobuid";

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(1, command.Parameters.Count);
            Assert.AreEqual(commandParameterExpected, command.Parameters[0].ParameterName);
        }

        [TestMethod]
        public void enqueue_Always_CorrectlyMangesAndExecutesInsertIntoQueueCommand()
        {
            // Arrange
            const string commandTextExpected = @"INSERT INTO QUEUE (timerjobuid, status, percentcomplete, userid) 
                                                                  VALUES (@timerjobuid, @status, 0, @userid) ";
            var commandParametersExpected = new[] { "@timerjobuid", "@status", "@userid" };

            // Act
            CoreFunctions.enqueue(_timerJobBuild, _defaultStatus, _sharepointShims.SiteShim);

            // Assert
            _adoShims.IsCommandCreated(commandTextExpected);
            _adoShims.IsCommandDisposed(commandTextExpected);
            _adoShims.IsCommandExecuted(commandTextExpected);

            var command = _adoShims.CommandsCreated.Single(pred => pred.CommandText == commandTextExpected);
            Assert.AreEqual(commandParametersExpected.Length, command.Parameters.Count);
            Assert.IsTrue(commandParametersExpected.All(pred => command.Parameters.Contains(pred)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "web")]
        public void getSiteItems_WebParameterNull_Throws()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                null,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "view")]
        public void getSiteItems_ViewParameterNull_Throws()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                null,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        public void getSiteItems_Always_ConnectionIsManagedCorrectly()
        {
            // Arrange, Act
            CoreFunctions.getSiteItems(
                _sharepointShims.WebShim,
                _sharepointShims.ViewShim,
                _spQuery,
                _filterFieldName,
                _useWbs,
                _listTitlePattern,
                _groupByFieldNames);

            // Assert
            _adoShims.IsConnectionManagedCorrectly(SharepointShims.DatabaseConnectionString);
        }
    }
}
