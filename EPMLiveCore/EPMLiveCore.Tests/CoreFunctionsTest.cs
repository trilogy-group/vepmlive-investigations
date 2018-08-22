using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Fakes;
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
        private IOShims _ioShims;
        private CryptographyShims _cryptographyShims;

        private Guid _timerJobBuild;
        private int _defaultStatus;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _ioShims = IOShims.ShimIOCalls();
            _cryptographyShims = CryptographyShims.ShimCryptographyCalls();

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
            ShimCoreFunctions.getDomain = () => string.Empty;
            var directoryShims = DirectoryShims.ShimDirectoryCalls();

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, directoryShims.DirectoryEntriesDisposed.Count);
            Assert.AreEqual(AuthenticationTypes.Secure, directoryShims.DirectoryEntriesDisposed[0].AuthenticationType);
            Assert.IsTrue(directoryShims.DirectoryEntriesDisposed[0].Path.StartsWith("LDAP://"));
        }

        [TestMethod]
        public void getUserFromAD_NameNotEmpty_DirectorySearcherEntry()
        {
            // Arrange
            const string userName = "test";
            ShimCoreFunctions.getDomain = () => string.Empty;
            var directoryShims = DirectoryShims.ShimDirectoryCalls();

            // Act
            CoreFunctions.getUserFromAD(userName);

            // Assert
            Assert.AreEqual(1, directoryShims.DirectorySearchersDisposed.Count);
            Assert.AreEqual(directoryShims.DirectoryEntriesDisposed[0], directoryShims.DirectorySearchersDisposed[0].SearchRoot);
            Assert.AreEqual($"(&(objectClass=user) (cn={userName}))", directoryShims.DirectorySearchersDisposed[0].Filter);
        }

        [TestMethod]
        public void Encrypt_ExeptionThrown_EmptyStringReturned()
        {
            // Arrange
            ShimRijndaelManaged.Constructor = instance => new InvalidOperationException("test");

            // Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Encrypt_Always_PasswordDeriveBytesManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DeriveBytesCreated.Count);
            Assert.IsTrue(_cryptographyShims.DeriveBytesCreated.All(pred => pred is PasswordDeriveBytes));
            Assert.IsTrue(_cryptographyShims.CheckIfAllDeriveBytesDisposed());
        }

        [TestMethod]
        public void Encrypt_Always_RijndaelManagedManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.RijndaelManagedCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllRijindaelManagedDisposed());
        }

        [TestMethod]
        public void Encrypt_Always_CryptoStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsCreated.OfType<CryptoStream>().Any());
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<CryptoStream>().Any());
        }

        [TestMethod]
        public void Encrypt_Always_MemoryStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<MemoryStream>().Any());
        }

        [TestMethod]
        public void Encrypt_Always_EncryptorManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Encrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.EncryptorsCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllEncryptorsDisposed());
        }

        [TestMethod]
        public void Decrypt_ExeptionThrown_EmptyStringReturned()
        {
            // Arrange
            ShimRijndaelManaged.Constructor = instance => new InvalidOperationException("test");

            // Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Decrypt_Always_PasswordDeriveBytesManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DeriveBytesCreated.Count);
            Assert.IsTrue(_cryptographyShims.DeriveBytesCreated.All(pred => pred is PasswordDeriveBytes));
            Assert.IsTrue(_cryptographyShims.CheckIfAllDeriveBytesDisposed());
        }

        [TestMethod]
        public void Decrypt_Always_RijndaelManagedManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.RijndaelManagedCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllRijindaelManagedDisposed());
        }

        [TestMethod]
        public void Decrypt_Always_CryptoStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsCreated.OfType<CryptoStream>().Any());
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<CryptoStream>().Any());
        }

        [TestMethod]
        public void Decrypt_Always_MemoryStreamManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.IsTrue(_ioShims.StreamsDisposed.OfType<MemoryStream>().Any());
        }

        [TestMethod]
        public void Decrypt_Always_EncryptorManagedCorrectly()
        {
            // Arrange, Act
            var result = CoreFunctions.Decrypt(string.Empty, string.Empty);

            // Assert
            Assert.AreEqual(1, _cryptographyShims.DecryptorsCreated.Count);
            Assert.IsTrue(_cryptographyShims.CheckIfAllEncryptorsDisposed());
        }
    }
}
