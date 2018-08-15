using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
        private DirectoryShims _directoryShims;

        private Guid _timerJobBuild;
        private int _defaultStatus;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _directoryShims = DirectoryShims.ShimDirectoryCalls();

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
        [ExpectedException(typeof(ArgumentNullException), "userName")]
        public void getUserFromAD_UserNameNull_Throws()
        {
            // Arrange
            string username = null;

            // Act
            CoreFunctions.getUserFromAD(username);

            // Assert
            // ExpectedException: ArgumentNullException
        }

        [TestMethod]
        public void getUserFromAD_NameNotEmpty_CorretlyManagesDirectoryEntry()
        {
            // Arrange
            const string userName = "test";

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, _directoryShims.DirectoryEntriesDisposed.Count);
            Assert.AreEqual(AuthenticationTypes.Secure, _directoryShims.DirectoryEntriesDisposed[0].AuthenticationType);
            Assert.IsTrue(_directoryShims.DirectoryEntriesDisposed[0].Path.StartsWith("LDAP://"));
        }

        [TestMethod]
        public void getUserFromAD_NameNotEmpty_DirectorySearcherEntry()
        {
            // Arrange
            const string userName = "test";

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, _directoryShims.DirectorySearchersDisposed.Count);
            Assert.AreEqual(_directoryShims.DirectoryEntriesDisposed[0], _directoryShims.DirectorySearchersDisposed[0].SearchRoot);
            Assert.AreEqual($"(&(objectClass=user) (cn={userName}))", _directoryShims.DirectorySearchersDisposed[0].Filter);
        }
    }
}
