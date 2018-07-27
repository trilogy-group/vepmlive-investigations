using System;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics;
using System.Diagnostics.Fakes;
using EPMLiveEnterprise.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherLive = EPMLiveEnterprise.Publisher;
using ProjectEventArgs = Microsoft.Office.Project.Server.Events.ProjectPostPublishEventArgs;

namespace EPMLivePS.Tests
{
    [TestClass]
    public class PublisherTest
    {
        private static readonly Guid DummyGuid = new Guid();
        private const string DummyCommand = "Dummy Command";
        private const string DummyName = "Dummy Name";
        private const string DummyString = "Dummy String";
        private const string DummyUrl = "http://www.dmmy.com";

        private const string ProjectGuidParam = "@projectguid";
        private const string LogTextParam = "@logtext";
        private const string StatusParam = "@status";
        private const string ProjectNameParam = "@projectname";
        private const string PubTypeParam = "@pubtype";
        private const string TransUidParam = "@transuid";
        private const string WebGuidParam = "@webguid";
        private const string WebUrlParam = "@weburl";

        private string _errorType;
        private string _message;
        private string _pubtype;
        private string _wssUrl;
        private string _timesheetField;
        private string _url;
        private SPWeb _rootWeb;
        private SqlConnection _sqlConnection;
        private ProjectEventArgs _eventArgs;
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _sqlConnection = new SqlConnection();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void CreateWindowsEvent_ShouldCreateEventLog_ReturnsEventLog()
        {
            // Arrange
            ShimEventLog.ConstructorString = (_, logName) => new ShimEventLog();
            ShimEventLog.SourceExistsString = source => false;
            ShimEventLog.AllInstances.SourceSetString = (_, source) => { };
            ShimEventLog.AllInstances.MachineNameSetString = (_, machineName) => { };

            // Act
            var result = PublisherLive.CreateWindowsEvent(DummyName, DummyCommand);

            // Assert
            Assert.IsInstanceOfType(result, typeof(EventLog));
        }

        [TestMethod]
        public void InitializeTimesheetField_ShouldGetValueFromSqlDataReader_SetTimesheetField()
        {
            // Arrange
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = container => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = container => 0;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (container, position) => DummyString;

            // Act
            PublisherLive.InitializeTimesheetField(_sqlConnection, ref _timesheetField);

            // Assert
            Assert.AreEqual(_timesheetField, DummyString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertPublisherCheck_WhenSqlConnectionIsNull_ThrowsException()
        {
            // Arrange
            SetupFakesForConstructor();
            var publisherLive = new PublisherLive(null, null);
            _sqlConnection = null;

            // Act
            publisherLive.InsertPublisherCheck(_sqlConnection, DummyGuid, _rootWeb, _url);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InsertPublisherCheck_ShouldAddParameters_ExecuteReader()
        {
            // Arrange
            SetupFakesForConstructor();
            var publisherLive = new PublisherLive(null, null);

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteReader = container => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };

            ShimEventLog.AllInstances.Close = log => { };

            // Act
            publisherLive.InsertPublisherCheck(_sqlConnection, DummyGuid, _rootWeb, _url);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual(ProjectGuidParam, sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(DummyGuid, sqlCommand.Parameters[0].Value);
        }

        [TestMethod]
        public void ExecuteNonQueryOnPublisherCheck_ShouldFillAllParameters_ExecuteNonQuery()
        {
            // Arrange
            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;

            _eventArgs = new ProjectEventArgs
            {
                ProjectGuid = DummyGuid,
                ProjectName = DummyName
            };

            _pubtype = DummyCommand;
            _wssUrl = DummyUrl;

            // Act
            PublisherLive.ExecuteNonQueryOnPublisherCheck(_sqlConnection, _eventArgs, _pubtype, _wssUrl);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 4);
            Assert.AreEqual(ProjectGuidParam, sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(_eventArgs.ProjectGuid, sqlCommand.Parameters[0].Value);
            Assert.AreEqual(PubTypeParam, sqlCommand.Parameters[1].ParameterName);
            Assert.AreEqual(DummyCommand, sqlCommand.Parameters[1].Value);
            Assert.AreEqual(WebUrlParam, sqlCommand.Parameters[2].ParameterName);
            Assert.AreEqual(DummyUrl, sqlCommand.Parameters[2].Value);
            Assert.AreEqual(ProjectNameParam, sqlCommand.Parameters[3].ParameterName);
            Assert.AreEqual(_eventArgs.ProjectName, sqlCommand.Parameters[3].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteCommandWithProjectGuid_WhenSqlConnectionIsNull_ThrowsException()
        {
            // Arrange
            _sqlConnection = null;

            // Act
            PublisherLive.ExecuteCommandWithProjectGuid(_sqlConnection, DummyCommand, DummyGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteCommandWithProjectGuid_WhenCommandTextIsEmpty_ThrowsException()
        {
            // Arrange, Act
            PublisherLive.ExecuteCommandWithProjectGuid(_sqlConnection, string.Empty, DummyGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExecuteCommandWithProjectGuid_WhenCommandTextIsWhiteSpace_ThrowsException()
        {
            // Arrange, Act
            PublisherLive.ExecuteCommandWithProjectGuid(_sqlConnection, "   ", DummyGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void ExecuteCommandWithProjectGuid_ShouldFillParameter_ExecuteNonQuery()
        {
            // Arrange
            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;

            // Act
            PublisherLive.ExecuteCommandWithProjectGuid(_sqlConnection, DummyCommand, DummyGuid);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual(ProjectGuidParam, sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(DummyGuid, sqlCommand.Parameters[0].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        private void UpdatePublisherCheck_WhenSqlConnectionIsNull_ThrowsException()
        {
            // Arrange
            _sqlConnection = null;

            // Act
            PublisherLive.UpdatePublisherCheck(_sqlConnection, DummyGuid, _errorType, _message);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void UpdatePublisherCheck_ShouldFillParameter_ExecuteNonQuery()
        {
            // Arrange
            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;

            _errorType = "404";
            _message = "File not found";
            var logTextMessage = $"{_errorType}: {_message}";

            // Act
            PublisherLive.UpdatePublisherCheck(_sqlConnection, DummyGuid, _errorType, _message);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 2);
            Assert.AreEqual(ProjectGuidParam, sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(DummyGuid, sqlCommand.Parameters[0].Value);
            Assert.AreEqual(LogTextParam, sqlCommand.Parameters[1].ParameterName);
            Assert.AreEqual(logTextMessage, sqlCommand.Parameters[1].Value);
        }

        private static void SetupFakesForConstructor()
        {
            ShimPublisher.ConstructorPSContextInfoProjectPostPublishEventArgs = (publisher, info, arg3) => new ShimPublisher();
        }
    }
}
