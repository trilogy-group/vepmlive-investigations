using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using AdmininfosCore = PortfolioEngineCore.Admininfos;

namespace PortfolioEngineCore.Tests.Admininfos
{
    [TestClass]
    public class AdmininfosTests
    {
        private const int SampleId = 100;
        private const string DummyString = "Dummy String";
        private const string ApplyUpdateOnEpgpLookupValuesMethod = "ApplyUpdateOnEpgpLookupValues";
        private const string CheckIfResourceExistsMethod = "CheckIfResourceExists";
        private const string DeleteDuplicatedWorkMethod = "DeleteDuplicatedWork";
        private const string InitializeIdMethod = "InitializeId";
        private const string InsertOnEpgLookupValueMethod = "InsertOnEpgLookupValue";
        private const string InsertOrUpdateEpgGroupsMethod = "InsertOrUpdateEpgGroups";
        private const string IsBUpdateOkMethod = "IsBUpdateOk";
        private const string GetNewLookupIdMethod = "GetNewLookupId";
        private const string GetNLookupIdMethod = "GetNLookupId";
        private const string UpdateAdminRecordMethod = "UpdateAdminRecord";

        private const string SampleCommand = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";
        private const string NoResourceMatchesSuppliedMessage = "No Resource matches supplied";
        private const string PiNotFoundMessage = "PI not found";
        private const string SLookupName = "Role Lookup";

        private int _id;
        private int _wresId;
        private string _extId;
        private string _sCommand;
        private string _sTitle;
        private SqlTransaction _transaction;

        private string _piExtId;
        private string _sErrorMessage;
        private int _nProjectId;

        private int _nLookupId;
        private Dictionary<int, PFELookup> _dicDepts;

        private string _basepath;
        private string _username;
        private string _pid;
        private string _company;
        private string _dbcnstring;
        private bool _bDebug;
        private SecurityLevels _secLevel;

        private PrivateObject _privateObject;
        private AdmininfosCore _admininfos;
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();

            _id = 10;
            _wresId = 20;
            _nLookupId = 30;
            _extId = DummyString;
            _sCommand = SampleCommand;
            _sTitle = DummyString;
            _sErrorMessage = DummyString;
            _transaction = new ShimSqlTransaction
            {
                Commit = () => { },
                DisposeBoolean = _bool => { },
                Rollback = () => { }
            };

            SetupFakes();

            _basepath = DummyString;
            _username = DummyString;
            _pid = DummyString;
            _company = "EPMLive";
            _dbcnstring = DummyString;
            _secLevel = SecurityLevels.BaseAdmin;
            _bDebug = true;
            _admininfos = new AdmininfosCore(_basepath, _username, _pid, _company, _dbcnstring, _secLevel, _bDebug);
            _privateObject = new PrivateObject(_admininfos);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeId_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            // Act
            _privateObject.Invoke(InitializeIdMethod, _transaction, _sCommand, _id);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InitializeId_ShouldGetNextIdValue_CloseConnection()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteReader = container => new ShimSqlDataReader
            {
                Read = () => false,
                Close = () => { }
            };

            ShimAdmininfos.AllInstances.GetNextIdValueIDataReader = (container, reader) => SampleId;

            var parameters = new object[]
            {
                _transaction,
                _sCommand,
                _id
            };

            // Act
            _privateObject.Invoke(InitializeIdMethod, parameters);

            // Assert
            Assert.IsTrue(parameters.Length >= 3);
            Assert.AreEqual(SampleId, parameters[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertOrUpdateEpgGroups_WhenTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            // Act
            _privateObject.Invoke(InsertOrUpdateEpgGroupsMethod, _transaction, _sCommand, _sTitle, _id);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InsertOrUpdateEpgGroups_WhenTransactionIsNotNull_ExecuteNonQuery()
        {
            // Arrange
            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = container => 0;

            // Act
            _privateObject.Invoke(InsertOrUpdateEpgGroupsMethod, _transaction, _sCommand, _sTitle, _id);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 2);
            Assert.AreEqual("@Id", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(_id, Convert.ToInt32(sqlCommand.Parameters[0].Value));
            Assert.AreEqual("@NewName", sqlCommand.Parameters[1].ParameterName);
            Assert.AreEqual(_sTitle, sqlCommand.Parameters[1].Value);
        }


        [TestMethod]
        public void CheckIfResourceExists_WhenExtIdLengthIsGreaterThanZero_ReturnsErrorMessage()
        {
            // Arrange
            var resultMessage = $"{NoResourceMatchesSuppliedMessage} ExtId";

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => "0";

            var parameters = new object[]
            {
                _extId,
                _wresId
            };

            // Act
            var errorMessage = _privateObject.Invoke(CheckIfResourceExistsMethod, parameters);

            // Assert
            Assert.AreEqual(resultMessage, errorMessage);
            Assert.IsTrue(parameters.Length >= 2);
            Assert.AreEqual(0, parameters[1]);
        }

        [TestMethod]
        public void CheckIfResourceExists_WhenExtIdLengthAndWresIdColumnAreGreaterThanZero_ReturnsErrorMessage()
        {
            // Arrange
            const string ResultMessage = "Supplied ExtId does not match supplied Id";

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => SampleId.ToString();

            var parameters = new object[]
            {
                _extId,
                _wresId
            };

            // Act
            var errorMessage =_privateObject.Invoke(CheckIfResourceExistsMethod, parameters);

            // Assert
            Assert.AreEqual(ResultMessage, errorMessage);
            Assert.IsTrue(parameters.Length >= 2);
            Assert.AreEqual(SampleId, parameters[1]);
        }

        [TestMethod]
        public void CheckIfResourceExists_WhenExtIdLengthIsZeroAndWresIdIsGreaterThanZero_ReturnsErrorMessage()
        {
            // Arrange
            var resultMessage = $"{NoResourceMatchesSuppliedMessage} Id";

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => false
                };
            };

            var parameters = new object[]
            {
                _extId = string.Empty,
                _wresId
            };

            // Act
            var errorMessage = _privateObject.Invoke(CheckIfResourceExistsMethod, parameters);

            // Assert
            Assert.AreEqual(resultMessage, errorMessage);
        }

        [TestMethod]
        public void CheckIfResourceExists_WhenExtIdLengthIsZeroAndWresIdIsZero_ReturnsErrorMessage()
        {
            // Arrange
            var resultMessage = $"{NoResourceMatchesSuppliedMessage} Id";

            var parameters = new object[]
            {
                _extId = string.Empty,
                _wresId = 0
            };

            // Act
            var errorMessage = _privateObject.Invoke(CheckIfResourceExistsMethod, parameters);

            // Assert
            Assert.AreEqual(resultMessage, errorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertOnEpgLookupValue_WhenDicDeptsIsNull_ThrowsException()
        {
            // Arrange
            _dicDepts = null;

            var parameters = new object[]
            {
                _dicDepts, _transaction, _nLookupId
            };

            // Act
            _privateObject.Invoke(InsertOnEpgLookupValueMethod, parameters);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertOnEpgLookupValue_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            var parameters = new object[]
            {
                _dicDepts, _transaction, _nLookupId
            };

            // Act
            _privateObject.Invoke(InsertOnEpgLookupValueMethod, parameters);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InsertOnEpgLookupValue_WhenBFlagIsFalse_ThrowsException()
        {
            // Arrange
            _dicDepts = new Dictionary<int, PFELookup>
            {
                { 1, new PFELookup
                    {
                        bflag = false,
                        ID = 10,
                        level = 20,
                        name = DummyString, 
                        fullname = DummyString,
                        ExtId = "30"
                    }
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => SampleId;

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };

            var parameters = new object[]
            {
                _dicDepts, _transaction, _nLookupId
            };

            // Act
            _privateObject.Invoke(InsertOnEpgLookupValueMethod, parameters);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 6);
            Assert.AreEqual("@LV_lookupuid", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(_nLookupId, Convert.ToInt32(sqlCommand.Parameters[0].Value));
            Assert.AreEqual("@LV_level", sqlCommand.Parameters[1].ParameterName);
            Assert.AreEqual(20, sqlCommand.Parameters[1].Value);
            Assert.AreEqual("@LV_id", sqlCommand.Parameters[2].ParameterName);
            Assert.AreEqual(10, sqlCommand.Parameters[2].Value);
            Assert.AreEqual("@LV_value", sqlCommand.Parameters[3].ParameterName);
            Assert.AreEqual(DummyString, sqlCommand.Parameters[3].Value);
            Assert.AreEqual("@LV_fullvalue", sqlCommand.Parameters[4].ParameterName);
            Assert.AreEqual(DummyString, sqlCommand.Parameters[4].Value);
            Assert.AreEqual("@LV_extid", sqlCommand.Parameters[5].ParameterName);
            Assert.AreEqual("30", sqlCommand.Parameters[5].Value);
        }

        [TestMethod]
        public void ApplyUpdateOnEpgpLookupValues_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            var dataTable = GetDataTableForEpgpLookupValues();
            dataTable.Rows[0]["LV_EXT_UID"] = 50;

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };

            var parameters = new object[]
            {
                _transaction, dataTable
            };

            // Act
            _privateObject.Invoke(ApplyUpdateOnEpgpLookupValuesMethod, parameters);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 6);
            Assert.AreEqual("@LV_uid", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual("@LV_level", sqlCommand.Parameters[1].ParameterName);
            Assert.AreEqual("@LV_id", sqlCommand.Parameters[2].ParameterName);
            Assert.AreEqual("@LV_value", sqlCommand.Parameters[3].ParameterName);
            Assert.AreEqual("@LV_fullvalue", sqlCommand.Parameters[4].ParameterName);
            Assert.AreEqual("@LV_extid", sqlCommand.Parameters[5].ParameterName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteDuplicatedWork_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            var parameters = new object[]
            {
                _transaction, _sCommand, SampleId
            };

            // Act
            _privateObject.Invoke(DeleteDuplicatedWorkMethod, parameters);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void DeleteDuplicatedWork_WhenSqlTransactionIsNotNull_ExecuteNonQuery()
        {
            // Arrange
            var sqlCommand = new SqlCommand();
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { sqlCommand = container; };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = container => 1;

            var parameters = new object[]
            {
                _transaction, _sCommand, SampleId
            };

            // Act
            _privateObject.Invoke(DeleteDuplicatedWorkMethod, parameters);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual("@ProjectID", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(SampleId, Convert.ToInt32(sqlCommand.Parameters[0].Value));
        }

        [TestMethod]
        public void IsBUpdateOk_WhenProjectIdGreaterThanZero_ReturnsTrue()
        {
            // Arrange
            _piExtId = "0";
            _nLookupId = 0;

            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => SampleId;

            var parameters = new object[]
            {
                _piExtId, _sErrorMessage, _nProjectId
            };

            // Act
            var result = (bool)_privateObject.Invoke(IsBUpdateOkMethod, parameters);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(parameters.Length >= 2);
            Assert.AreEqual(DummyString, parameters[1]);
        }

        [TestMethod]
        public void IsBUpdateOk_WhenProjectIdIsZero_ReturnsFalse()
        {
            // Arrange
            _piExtId = "0";
            _nLookupId = 0;

            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => false
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => SampleId;

            var parameters = new object[]
            {
                _piExtId, _sErrorMessage, _nProjectId
            };

            // Act
            var result = (bool)_privateObject.Invoke(IsBUpdateOkMethod, parameters);

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(parameters.Length >= 2);
            Assert.AreEqual(PiNotFoundMessage, parameters[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateAdminRecord_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            var parameters = new object[]
            {
                _transaction, SampleId
            };

            // Act
            _privateObject.Invoke(UpdateAdminRecordMethod, parameters);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void UpdateAdminRecord_ShouldCreateSqlCommand_ExecuteNonQuery()
        {
            // Arrange
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = container =>
            {
                sqlCommand = container;
                return 10;
            };

            var parameters = new object[]
            {
                _transaction, SampleId
            };

            // Act
            _privateObject.Invoke(UpdateAdminRecordMethod, parameters);

            // Assert
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual("@LookupUID", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(SampleId, Convert.ToInt32(sqlCommand.Parameters[0].Value));
        }

        [TestMethod]
        public void GetNewLookupId_ShouldSetNewId_ReturnsInteger()
        {
            // Arrange
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };

            var sqlCommand = new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                sqlCommand = command;

                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.ItemGetString = (container, column) => SampleId;

            // Act
            var newId = (int)_privateObject.Invoke(GetNewLookupIdMethod, _transaction);

            // Assert
            Assert.AreEqual(SampleId, newId);
            Assert.IsTrue(sqlCommand.Parameters.Count >= 1);
            Assert.AreEqual("@Name", sqlCommand.Parameters[0].ParameterName);
            Assert.AreEqual(SLookupName, sqlCommand.Parameters[0].Value);
        }

        [TestMethod]
        public void GetNLookupId_ShouldSetLookupUid_ReturnsInteger()
        {
            // Arrange
            ShimSqlCommand.ConstructorStringSqlConnection = (container, command, connString) => { };

            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => true
                };
            };

            ShimSqlDataReader.AllInstances.GetOrdinalString = (container, column) => SampleId;

            // Act
            var nLookupUid = (int)_privateObject.Invoke(GetNLookupIdMethod, _transaction);

            // Assert
            Assert.AreEqual(0, nLookupUid);
        }

        private static DataTable GetDataTableForEpgpLookupValues()
        {
            var table = new DataTable();
            table.Columns.Add("LV_UID", typeof(int));
            table.Columns.Add("LV_LEVEL", typeof(int));
            table.Columns.Add("LV_ID", typeof(int));
            table.Columns.Add("LV_VALUE");
            table.Columns.Add("LV_FULLVALUE");
            table.Columns.Add("LV_EXT_UID");

            var row = table.NewRow();
            row["LV_UID"] = 10;
            row["LV_LEVEL"] = 20;
            row["LV_ID"] = 30;
            row["LV_VALUE"] = DummyString;
            row["LV_FULLVALUE"] = DummyString;
            row["LV_EXT_UID"] = "40";
            table.Rows.Add(row);

            return table;
        }

        private static void SetupFakes()
        {
            ShimSqlConnection.ConstructorString = (instance, _string) => { };
            ShimSqlConnection.AllInstances.Open = connection => new ShimSqlConnection(connection);
            ShimSqlConnection.AllInstances.Close = connection => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (_, command, connString) => { };
            ShimSqlDataReader.AllInstances.Close = reader => { };

            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (admininfos, a, b, c, d, e, f, g) 
                => new ShimAdmininfos(admininfos);
        }
    }
}
