using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveSynch.Tests
{
    [TestClass]
    public class LogHelperTest
    {
        private readonly LogHelper LogHelper = new LogHelper();
        private const string DummyString = "Dummy String";
        private const string DtLoggedColumn = "dtLogged";
        private const string ResultColumn = "result";

        private DataTable _dataTable;
        private Guid _sourceGuid;
        private string _connectionString;
        private string _actionString;
        private string _resultString;
        private string _sourceString;

        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _connectionString = DummyString;
            _sourceGuid = Guid.NewGuid();

            _actionString = "Action String";
            _sourceString = "Source String";

            _dataTable = new DataTable
            {
                Columns = { DtLoggedColumn, ResultColumn },
                Rows =
                {
                    { "10", "100" }
                }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeResults_WhenDataTableIsNull_ThrowsException()
        {
            // Arrange
            _dataTable = null;

            // Act
            LogHelper.InitializeResults(_dataTable, _connectionString, _resultString, _sourceGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeResults_WhenConnectionStringIsEmpty_ThrowsException()
        {
            // Arrange
            _connectionString = "  ";

            // Act
            LogHelper.InitializeResults(_dataTable, _connectionString, _resultString, _sourceGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InitializeResults_ShouldSetResultString_ReturnsString()
        {
            // Arrange
            bool? readerResult = null;

            SetupFakesForData();

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                sqlCommand = command;

                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        readerResult = readerResult == null;
                        return readerResult.Value;
                    },
                    HasRowsGet = () => true
                };
            };
            
            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => column.Equals(DtLoggedColumn) ? 20 : 200;

            // Act
            var resultString = LogHelper.InitializeResults(_dataTable, _connectionString, _resultString, _sourceGuid) as string;

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual("@listguid", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(_sourceGuid, sqlCommand.Parameters[0].Value);

            var expectedResult = GetResultsMessage(_dataTable);
            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeResultText_WhenDataTableIsNull_ThrowsException()
        {
            // Arrange
            _dataTable = null;

            // Act
            LogHelper.InitializeResultText(_dataTable, _connectionString, _resultString, _sourceGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeResultText_WhenConnectionStringIsEmpty_ThrowsException()
        {
            // Arrange
            _connectionString = "  ";

            // Act
            LogHelper.InitializeResultText(_dataTable, _connectionString, _resultString, _sourceGuid);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InitializeResultText_ShouldSetResultString_ReturnsString()
        {
            // Arrange
            bool? readerResult = null;

            SetupFakesForData();

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                sqlCommand = command;

                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        readerResult = readerResult == null;
                        return readerResult.Value;
                    },
                    HasRowsGet = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => column.Equals(DtLoggedColumn) ? 20 : 200;

            // Act
            var resultString = LogHelper.InitializeResultText(_dataTable, _connectionString, _resultString, _sourceGuid) as string;

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual("@listguid", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(_sourceGuid, sqlCommand.Parameters[0].Value);

            var expectedResult = GetResultsTextMessage(_dataTable);
            Assert.AreEqual(expectedResult, resultString);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteLogBySourceAndAction_WhenConnectionStringIsEmpty_ThrowsException()
        {
            // Arrange
            _connectionString = string.Empty;

            // Act
            LogHelper.DeleteLogBySourceAndAction(_connectionString, _sourceString, _actionString);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteLogBySourceAndAction_WhenSourceIsEmpty_ThrowsException()
        {
            // Arrange
            _sourceString = string.Empty;

            // Act
            LogHelper.DeleteLogBySourceAndAction(_connectionString, _sourceString, _actionString);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteLogBySourceAndAction_WhenActionIsEmpty_ThrowsException()
        {
            // Arrange
            _actionString = string.Empty;

            // Act
            LogHelper.DeleteLogBySourceAndAction(_connectionString, _sourceString, _actionString);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void DeleteLogBySourceAndAction_ShouldExecuteSqlCommmand_ExecuteNonQuery()
        {
            // Arrange
            SetupFakesForData();

            var commandtext = string.Empty;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, command, connString) => { commandtext = command; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;

            // Act
            LogHelper.DeleteLogBySourceAndAction(_connectionString, _sourceString, _actionString);

            // Assert
            var expectedCommand = GetDeleteCommand(_sourceString, _actionString);
            Assert.AreEqual(expectedCommand, commandtext);
        }

        private static string GetResultsMessage(DataTable dataTable)
        {
            var sLogDateTime = dataTable.Rows[0].ItemArray[1].ToString();
            return $"{dataTable.Rows[0].ItemArray[0]}.  Log time: {sLogDateTime}";
        }

        private static string GetResultsTextMessage(DataTable dataTable)
        {
            return dataTable.Rows[0].ItemArray[0].ToString();
        }

        private static string GetDeleteCommand(string source, string action)
        {
            return $"Delete From EPMLive_Log Where source = '{source}' And UPPER(action) = '{action}'";
        }

        private void SetupFakesForData()
        {
            ShimSqlConnection.ConstructorString = (instance, _string) => { };
            ShimSqlConnection.AllInstances.Open = connection => new ShimSqlConnection(connection);
            ShimSqlConnection.AllInstances.Close = connection => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (_, command, connString) => { };
            ShimSqlDataReader.AllInstances.Close = reader => { };
        }
    }
}
