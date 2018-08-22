using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DBAccessTests
    {
        private IDisposable _shimObject;
        private DBAccess _testObj;
        private PrivateObject _privateObj;
        private bool _isOpened;
        private bool _isDisposed;
        private bool _logInvoked;
        private bool _nonQueryExecuted;
        private bool _transactionStarted;
        private bool _commited;
        private bool _rollback;

        private const string DummyString = "DummyString";
        private const string DummyDate = "2001-01-01";
        private const string DummyDouble = "10.5";
        private const string DummyDecimal = "12.6";
        private const string DummyBool = "true";
        private const string InvalidDate = "1000-00-00";
        private const int DummyInt = 1;

        [SetUp]
        public void TestInitialize()
        {
            _isOpened = false;
            _isDisposed = false;
            _logInvoked = false;
            _nonQueryExecuted = false;
            _transactionStarted = false;
            _commited = false;
            _rollback = false;
            _shimObject = ShimsContext.Create();
            _testObj = new DBAccess(DummyString);
            _privateObj = new PrivateObject(_testObj);

            ShimsSetup();
        }

        [TearDown]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void ShimsSetup()
        {
            ShimSqlConnection.Constructor = _ => { };
            ShimSqlConnection.AllInstances.Open = _ => _isOpened = true;
            ShimSqlConnection.AllInstances.ConnectionStringGet = _ => DummyString;
            ShimSqlConnection.AllInstances.ConnectionStringSetString = (_, __) => { };
            ShimSqlConnection.AllInstances.Close = _ => _isOpened = false;
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, __) => _isDisposed = true;
            ShimSqlConnection.AllInstances.BeginTransaction = _ =>
            {
                _transactionStarted = true;
                return new ShimSqlTransaction();
            };

            ShimSqlTransaction.AllInstances.Commit = _ => _commited = true;
            ShimSqlTransaction.AllInstances.Rollback = _ => _rollback = true;

            ShimDbConnectionStringBuilder.Constructor = _ => new ShimDbConnectionStringBuilder();
            ShimDbConnectionStringBuilder.AllInstances.ConnectionStringSetString = (_, __) => { };
            ShimDbConnectionStringBuilder.AllInstances.ToString01 = _ => DummyString;

            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = (s) => DummyInt
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _nonQueryExecuted = true;
                return DummyInt;
            };

            ShimDataTable.AllInstances.LoadIDataReader = (_, __) => { };

            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimDbDataReader.AllInstances.Dispose = _ => { };

            ShimEventLog.WriteEntryStringStringEventLogEntryType = (_, _1, _2) => _logInvoked = true;
        }

        [Test]
        public void Constructor_WithSqlConnection_ConfirmResult()
        {
            // Arrange
            var sqlConnection = new ShimSqlConnection().Instance;

            // Act
            var result = new DBAccess(DummyString, sqlConnection);

            // Assert
            result.Connection.ShouldBe(sqlConnection);
        }

        [Test]
        public void Open_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = _testObj.Open();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _isOpened.ShouldBeTrue(),
                () => result.ShouldBe(StatusEnum.rsSuccess));
        }

        [Test]
        public void Open_WhenConnectionStringIsEmpty_ConfirmResult()
        {
            // Arrange
            ShimDbConnectionStringBuilder.AllInstances.ToString01 = _ => string.Empty;

            // Act
            var result = _testObj.Open();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _isOpened.ShouldBeFalse(),
                () => _logInvoked.ShouldBeTrue(),
                () => result.ShouldBe(StatusEnum.rsSuccess));
        }

        [Test]
        public void Dispose_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            _testObj.Open();

            // Act
            _testObj.Dispose();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _isOpened.ShouldBeFalse(),
                () => _isDisposed.ShouldBeTrue());
        }

        [Test]
        public void SelectData_WhenCommandString_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;

            // Act
            var result = _testObj.SelectData(DummyString, StatusEnum.rsDBTableNotFound, out dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull());
        }

        [Test]
        public void SelectData_WhenSqlCommand_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;

            // Act
            var result = _testObj.SelectData(new ShimSqlCommand().Instance, StatusEnum.rsDBTableNotFound, out dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull());
        }

        [Test]
        public void SelectDataById_OnValidCall_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;

            // Act
            var result = _testObj.SelectDataById(DummyString, DummyInt, StatusEnum.rsDBTableNotFound, out dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull());
        }

        [Test]
        public void SelectDataByName_OnValidCall_ConfirmResult()
        {
            // Arrange
            DataTable dataTable;

            // Act
            var result = _testObj.SelectDataByName(DummyString, DummyString, StatusEnum.rsDBTableNotFound, out dataTable);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull());
        }

        [Test]
        public void DeleteDataById_OnValidCall_ConfirmResult()
        {
            // Arrange
            int rowsAffected;

            // Act
            var result = _testObj.DeleteDataById(DummyString, DummyInt, StatusEnum.rsDBTableNotFound, out rowsAffected);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => rowsAffected.ShouldBe(DummyInt));
        }

        [Test]
        public void DeleteData_OnValidCall_ConfirmResult()
        {
            // Arrange
            int rowsAffected;

            // Act
            var result = _testObj.DeleteData(DummyString, StatusEnum.rsDBTableNotFound, out rowsAffected);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => rowsAffected.ShouldBe(DummyInt));
        }

        [Test]
        public void ExecuteReader_StringCommand_ConfirmResult()
        {
            // Arrange
            SqlDataReader dataReader;

            // Act
            var result = _testObj.ExecuteReader(DummyString, StatusEnum.rsDBTableNotFound, out dataReader);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataReader.ShouldNotBeNull());
        }

        [Test]
        public void ExecuteReader_SqlCommand_ConfirmResult()
        {
            // Arrange
            SqlDataReader dataReader;

            // Act
            var result = _testObj.ExecuteReader(new ShimSqlCommand().Instance, StatusEnum.rsDBTableNotFound, out dataReader);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataReader.ShouldNotBeNull());
        }

        [Test]
        public void ExecuteNonQuery_OnValidCall_ConfirmResult()
        {
            // Arrange
            int rowsAffected;

            // Act
            var result = _testObj.ExecuteNonQuery(DummyString, StatusEnum.rsDBTableNotFound, out rowsAffected);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => rowsAffected.ShouldBe(DummyInt));
        }

        [Test]
        public void HandleException_OnValidCall_ConfirmResult()
        {
            // Arrange
            Exception exception;
            try
            {
                throw new Exception(DummyString);
            }
            catch (Exception x)
            {
                exception = x;
            }

            // Act
            var result = _testObj.HandleException(DummyString, StatusEnum.rsDBConnectFailed, exception);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _logInvoked.ShouldBeTrue(),
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => _nonQueryExecuted.ShouldBeTrue());
        }

        [Test]
        public void WriteImmTrace_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            _testObj.WriteImmTrace(DummyString, DummyString, DummyString, DummyString);

            // Assert
            _nonQueryExecuted.ShouldBeTrue();
        }

        [Test]
        public void BeginTransaction_OnValidCall_ConfirmResult()
        {
            // Arrange
            _testObj.Open();

            // Act
            _testObj.BeginTransaction();

            // Assert
            _transactionStarted.ShouldBeTrue();
        }

        [Test]
        public void CommitTransaction_OnValidCall_ConfirmResult()
        {
            // Arrange
            _testObj.Open();
            _testObj.BeginTransaction();

            // Act
            _testObj.CommitTransaction();

            // Assert
            _commited.ShouldBeTrue();
        }

        [Test]
        public void RollbackTransaction_OnValidCall_ConfirmResult()
        {
            // Arrange
            _testObj.Open();
            _testObj.BeginTransaction();

            // Act
            _testObj.RollbackTransaction();

            // Assert
            _rollback.ShouldBeTrue();
        }

        [Test]
        public void ReadDateValue_WithObject_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDateValue(DummyDate);

            // Assert
            result.ShouldBe(Convert.ToDateTime(DummyDate));
        }

        [Test]
        public void ReadDateValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDateValue(DBNull.Value);

            // Assert
            result.ShouldBe(Convert.ToDateTime(DateTime.MinValue));
        }

        [Test]
        public void ReadDateValue_WithDBNullAndBoolean_ReturnBoolean()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDateValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DateTime.MinValue),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadDateValue_WithInvalidDateAndBoolean_ReturnBoolean()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDateValue(InvalidDate, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DateTime.Parse("1901-01-01")),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadDateValue_WithObjectAndBoolean_ReturnBoolean()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDateValue(DummyDate, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(Convert.ToDateTime(DummyDate)),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadNullableDateValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadNullableDateValue(DummyDate);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(Convert.ToDateTime(DummyDate)));
        }

        [Test]
        public void ReadNullableDateValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadNullableDateValue(DBNull.Value);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull());
        }

        [Test]
        public void ReadStringValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadStringValue(DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyString));
        }

        [Test]
        public void ReadStringValue_WithBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadStringValue(DummyString, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyString),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadStringValue_WithDBNull_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadStringValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeEmpty(),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadDoubleValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDoubleValue(DummyDouble);

            // Assert
            result.ShouldBe(10.5);
        }

        [Test]
        public void ReadDoubleValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDoubleValue(DBNull.Value);

            // Assert
            result.ShouldBe(0.0);
        }

        [Test]
        public void ReadDoubleValue_WithBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDoubleValue(DummyDouble, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(10.5),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadDoubleValue_WithDBNullAndBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDoubleValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0.0),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadDecimalValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDecimalValue(DummyDecimal);

            // Assert
            result.ShouldBe(12.6M);
        }

        [Test]
        public void ReadDecimalValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadDecimalValue(DBNull.Value);

            // Assert
            result.ShouldBe(0.0M);
        }

        [Test]
        public void ReadDecimalValue_WithBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDecimalValue(DummyDecimal, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(12.6M),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadDecimalValue_WithDBNullAndBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadDecimalValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0.0M),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadBoolValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadBoolValue(DummyBool);

            // Assert
            result.ShouldBeTrue();
        }

        [Test]
        public void ReadBoolValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadBoolValue(DBNull.Value);

            // Assert
            result.ShouldBeFalse();
        }

        [Test]
        public void ReadBoolValue_WithBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadBoolValue(DummyBool, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadBoolValue_WithDBNullAndBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadBoolValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadIntValue_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadIntValue(DummyInt.ToString());

            // Assert
            result.ShouldBe(DummyInt);
        }

        [Test]
        public void ReadIntValue_WithDBNull_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadIntValue(DBNull.Value);

            // Assert
            result.ShouldBe(0);
        }

        [Test]
        public void ReadIntValue_WithInvalidInt_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.ReadIntValue(DummyString);

            // Assert
            result.ShouldBe(0);
        }

        [Test]
        public void ReadIntValue_WithBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadIntValue(DummyInt.ToString(), out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyInt),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadIntValue_WithDBNullAndBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadIntValue(DBNull.Value, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => bIsNull.ShouldBeTrue());
        }

        [Test]
        public void ReadIntValue_WithInValidIntAndBoolean_ConfirmResult()
        {
            // Arrange
            bool bIsNull;

            // Act
            var result = SqlDb.ReadIntValue(DummyString, out bIsNull);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => bIsNull.ShouldBeFalse());
        }

        [Test]
        public void ReadGuidValue_OnValidCall_ConfirmResult()
        {
            // Arrange
            var guid = "0A9B9B37-C81D-4E86-853C-22101DC8FB04";

            // Act
            var result = SqlDb.ReadGuidValue(guid);

            // Assert
            result.ShouldBe(new Guid(guid));
        }

        [Test]
        public void PrepareText_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.PrepareText(DummyString);

            // Assert
            result.ShouldBe($"'{DummyString}'");
        }

        [Test]
        public void GetLastIdentityValue_OnValidCall_ConfirmResult()
        {
            // Arrange
            int lAutoNumber;

            // Act
            var result = _testObj.GetLastIdentityValue(out lAutoNumber);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => lAutoNumber.ShouldBe(DummyInt));
        }

        [Test]
        public void FormatAdminError_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = SqlDb.FormatAdminError(DummyString, DummyString, DummyString);

            // Assert
            result.ShouldContain(DummyString);
        }
    }
}
