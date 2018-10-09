using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;
using AdmininfosCore = PortfolioEngineCore.Admininfos;

namespace PortfolioEngineCore.Tests.Admininfos
{
    [TestClass, ExcludeFromCodeCoverage]
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
        private const int DummyInt = 1;
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private static readonly NameValueCollection _queryString = new NameValueCollection();
        private static readonly HttpCookieCollection _cookies = new HttpCookieCollection();

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
            var errorMessage = _privateObject.Invoke(CheckIfResourceExistsMethod, parameters);

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
                {
                    1, new PFELookup
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

        [TestMethod]
        public void GetWResID_OnValidCall_ReturnInt()
        {
            // Arrange
            _privateObject.SetField("_userWResID", DummyInt);

            // Act
            var actualResult = _admininfos.GetWResID();

            // Assert
            actualResult.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void CanDeleteCostCategoryRole_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlDataReader.AllInstances.ItemGetString = (_, __) => DummyString;

            // Act
            var actualResult = _admininfos.CanDeleteCostCategoryRole(DummyInt, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void CanDeleteCostCategoryRolebyCCRId_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlDataReader.AllInstances.ItemGetString = (_, __) => DummyString;

            // Act
            var actualResult = _admininfos.CanDeleteCostCategoryRolebyCCRId(DummyInt, DummyInt, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void CanDeleteCostCategoryRolebyCCRId_OnReadIsFalse_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                return new ShimSqlDataReader
                {
                    Read = () => false
                };
            };

            // Act
            var actualResult = _admininfos.CanDeleteCostCategoryRolebyCCRId(DummyInt, DummyInt, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain("Role Id does not match CCR Id "));
        }

        [TestMethod]
        public void CanDeleteLookupValue_OnFieldId9105_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCanDeleteLookupValue(9105, DummyInt);
        }

        [TestMethod]
        public void CanDeleteLookupValue_OnFieldId9305_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCanDeleteLookupValue(9305, DummyInt);
        }

        [TestMethod]
        public void CanDeleteLookupValue_OnFieldId11801_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCanDeleteLookupValue(11801, DummyInt);
        }

        [TestMethod]
        public void CanDeleteLookupValue_OnFieldId20001_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCanDeleteLookupValue(20001, 101);
        }

        [TestMethod]
        public void CanDeleteLookupValue_OnFieldId20001AndTableId201_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestCanDeleteLookupValue(20001, 201);
        }

        [TestMethod]
        public void CanDeleteLookupValueasCC_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            var nRoleUID = 0;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlDataReader.AllInstances.ItemGetString = (_, _2) => DummyInt;

            // Act
            var actualResult = _admininfos.CanDeleteLookupValueasCC(DummyInt, out result, out nRoleUID);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => nRoleUID.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void CanDeleteLookupValueasCC_OnRoleIdIsZero_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            var nRoleUID = 0;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlDataReader.AllInstances.ItemGetString = (_, _2) => 0;

            // Act
            var actualResult = _admininfos.CanDeleteLookupValueasCC(DummyInt, out result, out nRoleUID);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain("Can't find Cost Category Role"),
                () => nRoleUID.ShouldBe(0));
        }

        [TestMethod]
        public void CanDeleteWorkSchedule_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());

            // Act
            var actualResult = _admininfos.CanDeleteWorkSchedule(DummyInt, out result);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void CanDeleteHolidaySchedule_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());

            // Act
            var actualResult = _admininfos.CanDeleteHolidaySchedule(DummyInt, out result);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void DeleteDepartments_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var readCount = 0;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (readCount < 3)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("LV_UID"))
                {
                    return DummyInt;
                }

                if (name.Equals("LV_LEVEL"))
                {
                    return 2;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeleteDepartments(DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteHolidaySchedule_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteHolidaySchedule(DummyInt, DummyString);
        }

        [TestMethod]
        public void DeleteHolidaySchedule_OnGroupNameIsEmpty_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteHolidaySchedule(DummyInt, string.Empty);
        }

        [TestMethod]
        public void DeleteHolidaySchedule_OnDeletehsUIDIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteHolidaySchedule(0, DummyString);
        }

        [TestMethod]
        public void DeleteListWork_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteListWork(DummyInt);
        }

        [TestMethod]
        public void DeleteListWork_OnProjectIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteListWork(0);
        }

        [TestMethod]
        public void DeletePIListWork_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeletePIListWork(DummyInt);
        }

        [TestMethod]
        public void DeletePIListWork_OnProjectIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeletePIListWork(0);
        }

        [TestMethod]
        public void DeleteLookup_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var readCount = 0;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (readCount < 3)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("LV_UID"))
                {
                    return DummyInt;
                }

                if (name.Equals("LV_LEVEL"))
                {
                    return 2;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeleteLookup(DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeletePersonalItem_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));

            // Act
            var actualResult = _admininfos.DeletePersonalItem(DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteResourceTimeoff_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteResourceTimeoff(string.Empty, DummyInt);
        }

        [TestMethod]
        public void DeleteResourceTimeoff_OnValidCallAndRowsIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteResourceTimeoff(string.Empty, 0);
        }

        [TestMethod]
        public void DeleteResourceTimeoff_OnErrorMessage_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteResourceTimeoff(DummyString, DummyInt);
        }

        [TestMethod]
        public void DeleteRole_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimAdmininfos.AllInstances.DeleteLookupInt32 = (_, _2) => true;

            // Act
            var actualResult = _admininfos.DeleteRole(DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteCCRole_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));

            // Act
            var actualResult = _admininfos.DeleteCCRole(DummyInt);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void CountRoleCategories_OnValidCall_ReturnInt()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));

            // Act
            var actualResult = _admininfos.CountRoleCategories(DummyInt);

            // Assert
            actualResult.ShouldBe(0);
        }

        [TestMethod]
        public void DeleteWorkSchedule_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteWorkSchedule(DummyInt, DummyString);
        }

        [TestMethod]
        public void DeleteWorkSchedule_OnGroupNameIsEmpty_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteWorkSchedule(DummyInt, string.Empty);
        }

        [TestMethod]
        public void DeleteWorkSchedule_OnWorkScheduleIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestDeleteWorkSchedule(0, DummyString);
        }

        [TestMethod]
        public void GetCostCategoryRoles_OnValidCall_ReturnListOfCostCategory()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("CA_UID", typeof(int));
                dt.Columns.Add("CA_ROLE", typeof(int));
                dt.Columns.Add("CA_NAME", typeof(string));
                dt.Columns.Add("CA_LEVEL", typeof(int));
                dt.Rows.Add(DummyInt, 0, DummyString, DummyInt);
                dt.Rows.Add(DummyInt, 0, DummyString, 2);
                dt.Rows.Add(DummyInt, DummyInt, DummyString, 2);
            };

            // Act
            var actualResult = _admininfos.GetCostCategoryRoles();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeEmpty(),
                () => actualResult[0].Name.ShouldContain(DummyString),
                () => actualResult[0].CostCategories.ShouldNotBeEmpty(),
                () => actualResult[0].CostCategories[0].Name.ShouldContain(DummyString));
        }

        [TestMethod]
        public void UpdateCategoriesFromRoles_OnMajorCategoryLookupIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateCategoriesFromRoles(0);
        }

        [TestMethod]
        public void UpdateCategoriesFromRoles_OnMajorCategoryLookupIsOne_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateCategoriesFromRoles(DummyInt);
        }

        [TestMethod]
        public void UpdateDepartments_OnDeptLookupIDIsZero_ThrowException()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 0;

            // Act, Assert
            Should.Throw<PFEException>(() => _admininfos.UpdateDepartments(DummyString, out result));
        }

        [TestMethod]
        public void UpdateDepartments_OnDeptLookupIDIsZeroAndUpdateIsFalse_ThrowException()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("LV_UID", typeof(int));
                dt.Columns.Add("LV_ID", typeof(int));
                dt.Columns.Add("LV_VALUE", typeof(string));
                dt.Columns.Add("LV_LEVEL", typeof(int));
                dt.Columns.Add("LV_EXT_UID", typeof(string));
                dt.Columns.Add("LV_FULLVALUE", typeof(string));
                dt.Rows.Add(DummyInt, 0, DummyString, DummyInt, DummyString, DummyString);
                dt.Rows.Add(0, 0, DummyString, 2, DummyString, DummyString);
            };
            ShimAdmininfos.AllInstances.GetLookupCStructStringDictionaryOfInt32PFELookupInt32Int32RefString = (AdmininfosCore admininfos,
                CStruct items, string itemname, Dictionary<int, PFELookup> lookups, int level, ref int id, string fullname) =>
            {
                lookups.Add(DummyInt, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt}
                });
                lookups.Add(0, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = true,
                    name = DummyString
                });
            };

            // Act, Assert
            Should.Throw<PFEException>(() => _admininfos.UpdateDepartments(DummyString, out result));
        }

        [TestMethod]
        public void UpdateDepartments_OnMajorCategoryLookupIsOne_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("LV_UID", typeof(int));
                dt.Columns.Add("LV_ID", typeof(int));
                dt.Columns.Add("LV_VALUE", typeof(string));
                dt.Columns.Add("LV_LEVEL", typeof(int));
                dt.Columns.Add("LV_EXT_UID", typeof(string));
                dt.Columns.Add("LV_FULLVALUE", typeof(string));
                dt.Rows.Add(DummyInt, 0, DummyString, DummyInt, DummyString, DummyString);
            };
            ShimAdmininfos.AllInstances.GetLookupCStructStringDictionaryOfInt32PFELookupInt32Int32RefString = (AdmininfosCore admininfos,
                CStruct items, string itemname, Dictionary<int, PFELookup> lookups, int level, ref int id, string fullname) =>
            {
                lookups.Add(DummyInt, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false
                });
            };
            ShimDataRow.AllInstances.RowStateGet = _ => DataRowState.Modified;

            // Act
            var actualResult = _admininfos.UpdateDepartments(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => result.ShouldContain("<Data><Department Id=\"1\" DataId=\"\" /></Data>"));
        }

        [TestMethod]
        public void UpdateHolidaySchedule_OnIdIsOne_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateHolidaySchedule(DummyInt, "1");
        }

        [TestMethod]
        public void UpdateHolidaySchedule_OnIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateHolidaySchedule(0, string.Empty);
        }

        [TestMethod]
        public void UpdateListWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date") || name.Equals("StartDate") || name.Equals("FinishDate"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("MaxId"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) => { };
            ShimAdmininfos.AllInstances.IsBUpdateOkStringStringRefInt32Ref =
                (AdmininfosCore admininfos, string s, ref string ref1, ref int ref2) => true;
            ShimAllWorkhours.AllInstances.ProrateInt32Int32DateTimeDateTimeDouble = (_, _2, _3, _4, _5, _6) => true;
            var firstTimeCall = true;
            ShimAllWorkhours.AllInstances.GetworkInt32DoubleOut = (AllWorkhours workhours, int i, out double hours) =>
            {
                hours = DummyInt;
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return true;
                }

                return false;
            };
            ShimAdmininfos.AllInstances.GetAutoPostsStringInt32MdArray2Ref = (AdmininfosCore admininfos, string s, ref int[,] posts) =>
            {
                posts[0, 0] = DummyInt;
                return true;
            };
            ShimAdmininfos.AllInstances.PostCostValuesForScheduledWork = _ => true;

            // Act
            var actualResult = _admininfos.UpdateListWork(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain(
                    $"<Data><Project Status=\"1\" ExtId=\"{DummyString}\"><![CDATA[These Resources are not defined: 0]]></Project></Data>"));
        }

        [TestMethod]
        public void UpdatePersonalItems_OnKeyIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdatePersonalItems(0);
        }

        [TestMethod]
        public void UpdatePersonalItems_OnKeyIsOne_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdatePersonalItems(DummyInt);
        }

        [TestMethod]
        public void UpdateResourceTimeoff_OnValidCall_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateResourceTimeoff(string.Empty);
        }

        [TestMethod]
        public void UpdateResourceTimeoff_OnErrorMessage_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateResourceTimeoff(DummyString);
        }

        [TestMethod]
        public void UpdateRoles_OnLookupUIDIsZero_ThrowException()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimAdmininfos.AllInstances.GetNLookupIdSqlTransaction = (_, _2) => 0;
            ShimAdmininfos.AllInstances.GetNewLookupIdSqlTransaction = (_, _2) => 0;

            // Act, Assert
            Should.Throw<PFEException>(() => _admininfos.UpdateRoles(DummyString, out result));
        }

        [TestMethod]
        public void UpdateRoles_OnRoleIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateRoles(0);
        }

        [TestMethod]
        public void UpdateRoles_OnRoleIdIsOne_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateRoles(DummyInt);
        }

        [TestMethod]
        public void UpdateRoles_OLD_OnLookupUIDIsZero_ThrowException()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimAdmininfos.AllInstances.GetNLookupIdSqlTransaction = (_, _2) => 0;
            ShimAdmininfos.AllInstances.GetNewLookupIdSqlTransaction = (_, _2) => 0;

            // Act, Assert
            Should.Throw<PFEException>(() => _admininfos.UpdateRoles_OLD(DummyString, out result));
        }

        [TestMethod]
        public void UpdateRoles_OLD_OnKeyIsZero_ThrowException()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("LV_UID", typeof(int));
                dt.Columns.Add("LV_ID", typeof(int));
                dt.Columns.Add("LV_VALUE", typeof(string));
                dt.Columns.Add("LV_LEVEL", typeof(int));
                dt.Columns.Add("LV_EXT_UID", typeof(int));
                dt.Columns.Add("LV_FULLVALUE", typeof(string));
                dt.Rows.Add(DummyInt, DummyInt, DummyString, DummyInt, DummyInt, DummyString);
            };
            ShimAdmininfos.AllInstances.GetLookupCStructStringDictionaryOfInt32PFELookupInt32Int32RefString = (AdmininfosCore admininfos,
                CStruct items, string itemname, Dictionary<int, PFELookup> lookups, int level, ref int id, string fullname) =>
            {
                lookups.Add(0, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 2,
                    UID_real = 0
                });
            };

            // Act, Assert
            Should.Throw<PFEException>(() => _admininfos.UpdateRoles_OLD(DummyString, out result));
        }

        [TestMethod]
        public void UpdateRoles_OLD_OnKeyIsOne_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("LV_UID", typeof(int));
                dt.Columns.Add("LV_ID", typeof(int));
                dt.Columns.Add("LV_VALUE", typeof(string));
                dt.Columns.Add("LV_LEVEL", typeof(int));
                dt.Columns.Add("LV_EXT_UID", typeof(string));
                dt.Columns.Add("LV_FULLVALUE", typeof(string));
                dt.Rows.Add(DummyInt, DummyInt, DummyString, DummyInt, DummyString, DummyString);
            };
            ShimAdmininfos.AllInstances.GetLookupCStructStringDictionaryOfInt32PFELookupInt32Int32RefString = (AdmininfosCore admininfos,
                CStruct items, string itemname, Dictionary<int, PFELookup> lookups, int level, ref int id, string fullname) =>
            {
                lookups.Add(2, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 3,
                    UID_real = DummyInt,
                    ExtId = DummyString,
                    fullname = DummyString
                });

                lookups.Add(3, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 3,
                    UID_real = 0,
                    name = DummyString,
                    ExtId = DummyString,
                    fullname = DummyString
                });

                lookups.Add(DummyInt, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 2,
                    UID_real = 0,
                    ExtId = DummyString,
                    fullname = DummyString
                });
            };
            ShimDataRow.AllInstances.RowStateGet = _ => DataRowState.Modified;

            // Act
            var actualResult = _admininfos.UpdateRoles_OLD(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => result.ShouldContain("<Data><Role Id=\"0\" DataId=\"\" /><Role Id=\"0\" DataId=\"\" /><Role Id=\"1\" DataId=\"\" /></Data>"));
        }

        [TestMethod]
        public void UpdateScheduledWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date") || name.Equals("StartDate") || name.Equals("FinishDate"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("MaxId"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) => { };
            ShimAdmininfos.AllInstances.IsBUpdateOkStringStringRefInt32Ref =
                (AdmininfosCore admininfos, string s, ref string ref1, ref int ref2) => true;
            ShimAllWorkhours.AllInstances.ProrateInt32Int32DateTimeDateTimeDouble = (_, _2, _3, _4, _5, _6) => true;
            var firstTimeCall = true;
            ShimAllWorkhours.AllInstances.GetworkInt32DoubleOut = (AllWorkhours workhours, int i, out double hours) =>
            {
                hours = DummyInt;
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return true;
                }

                return false;
            };
            ShimAdmininfos.AllInstances.GetAutoPostsStringInt32MdArray2Ref = (AdmininfosCore admininfos, string s, ref int[,] posts) =>
            {
                posts[0, 0] = DummyInt;
                return true;
            };
            ShimAdmininfos.AllInstances.PostCostValuesForScheduledWork = _ => true;

            // Act
            var actualResult = _admininfos.UpdateScheduledWork(2, DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain(
                    $"<Data><Project Status=\"1\" ExtId=\"{DummyString}\"><![CDATA[These Resources are not defined: 0]]></Project></Data>"));
        }

        [TestMethod]
        public void GetCCRs_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date") || name.Equals("StartDate") || name.Equals("FinishDate"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("CA_LEVEL"))
                {
                    return 2;
                }

                if (name.Equals("CA_ROLE"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) => { };
            ShimAdmininfos.AllInstances.IsBUpdateOkStringStringRefInt32Ref =
                (AdmininfosCore admininfos, string s, ref string ref1, ref int ref2) => true;
            ShimAllWorkhours.AllInstances.ProrateInt32Int32DateTimeDateTimeDouble = (_, _2, _3, _4, _5, _6) => true;
            var firstTimeCall = true;
            ShimAllWorkhours.AllInstances.GetworkInt32DoubleOut = (AllWorkhours workhours, int i, out double hours) =>
            {
                hours = DummyInt;
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return true;
                }

                return false;
            };
            ShimAdmininfos.AllInstances.GetAutoPostsStringInt32MdArray2Ref = (AdmininfosCore admininfos, string s, ref int[,] posts) =>
            {
                posts[0, 0] = DummyInt;
                return true;
            };
            ShimAdmininfos.AllInstances.PostCostValuesForScheduledWork = _ => true;

            // Act
            var actualResult = _admininfos.GetCCRs();

            // Assert
            actualResult.ShouldContain(
                $"<Data><Role Id=\"1\" CCRId=\"0\" Title=\"{DummyString}\" ExtId=\"{DummyString}\" CCRName=\"{DummyString}\" /></Data>");
        }

        [TestMethod]
        public void GetDepts_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date") || name.Equals("StartDate") || name.Equals("FinishDate"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("CA_LEVEL"))
                {
                    return 2;
                }

                if (name.Equals("CODE_UID"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) => { };
            ShimAdmininfos.AllInstances.IsBUpdateOkStringStringRefInt32Ref =
                (AdmininfosCore admininfos, string s, ref string ref1, ref int ref2) => true;
            ShimAllWorkhours.AllInstances.ProrateInt32Int32DateTimeDateTimeDouble = (_, _2, _3, _4, _5, _6) => true;
            var firstTimeCall = true;
            ShimAllWorkhours.AllInstances.GetworkInt32DoubleOut = (AllWorkhours workhours, int i, out double hours) =>
            {
                hours = DummyInt;
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return true;
                }

                return false;
            };
            ShimAdmininfos.AllInstances.GetAutoPostsStringInt32MdArray2Ref = (AdmininfosCore admininfos, string s, ref int[,] posts) =>
            {
                posts[0, 0] = DummyInt;
                return true;
            };
            ShimAdmininfos.AllInstances.PostCostValuesForScheduledWork = _ => true;

            // Act
            var actualResult = _admininfos.GetDepts();

            // Assert
            actualResult.ShouldContain($"<Data><Department Id=\"0\" Level=\"0\" Title=\"{DummyString}\" ExtId=\"{DummyString}\" /></Data>");
        }

        [TestMethod]
        public void GetWHs_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date") || name.Equals("StartDate") || name.Equals("FinishDate"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyString;
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) => { };
            ShimAdmininfos.AllInstances.IsBUpdateOkStringStringRefInt32Ref =
                (AdmininfosCore admininfos, string s, ref string ref1, ref int ref2) => true;
            ShimAllWorkhours.AllInstances.ProrateInt32Int32DateTimeDateTimeDouble = (_, _2, _3, _4, _5, _6) => true;
            var firstTimeCall = true;
            ShimAllWorkhours.AllInstances.GetworkInt32DoubleOut = (AllWorkhours workhours, int i, out double hours) =>
            {
                hours = DummyInt;
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return true;
                }

                return false;
            };
            ShimAdmininfos.AllInstances.GetAutoPostsStringInt32MdArray2Ref = (AdmininfosCore admininfos, string s, ref int[,] posts) =>
            {
                posts[0, 0] = DummyInt;
                return true;
            };
            ShimAdmininfos.AllInstances.PostCostValuesForScheduledWork = _ => true;

            // Act
            var actualResult = _admininfos.GetWHs();

            // Assert
            actualResult.ShouldContain(
                $"<Data><WorkSchedule Id=\"0\" Title=\"{DummyString}\" Monday=\"0\" Tuesday=\"0\" Wednesday=\"0\" Thursday=\"0\" Friday=\"0\" Saturday=\"0\" Sunday=\"0\" Default=\"1\" /></Data>");
        }

        [TestMethod]
        public void GetHOLs_OnValidCall_ReturnString()
        {
            // Arrange
            var dateTimeNow = DateTime.Now;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_DEF_FTE_HOL") || name.Equals("GROUP_ID") || name.Equals("NWH_HOURS"))
                {
                    return DummyInt;
                }

                if (name.Equals("NWH_DATE"))
                {
                    return dateTimeNow;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.GetHOLs();

            // Assert
            actualResult.ShouldContain(
                $"<Data><HolidaySchedule Id=\"1\" Title=\"{DummyString}\" Default=\"1\"><Holiday Title=\"{DummyString}\" Hours=\"0.01\" Date=\"{dateTimeNow:yyyy-MM-ddTHH:mm:ss}\" /></HolidaySchedule></Data>");
        }

        [TestMethod]
        public void GetPersonalItems_OnValidCall_ReturnString()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));

            // Act
            var actualResult = _admininfos.GetPersonalItems();

            // Assert
            actualResult.ShouldContain($"<Data><Item Id=\"0\" Title=\"{DummyString}\" /></Data>");
        }

        [TestMethod]
        public void GetPersonalItems_OnValidCall_AddToDictionary()
        {
            // Arrange
            var items = new Dictionary<int, PFELookup>();
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};

            // Act
            _privateObject.Invoke("GetPersonalItems", new ShimCStruct().Instance, DummyString, items);

            // Assert
            items.ShouldSatisfyAllConditions(
                () => items.Count.ShouldBe(1),
                () => items[1].ShouldNotBeNull(),
                () => items[1].name.ShouldContain(DummyString));
        }

        [TestMethod]
        public void UpdateWorkSchedule_OnIdIsOne_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateWorkSchedule(DummyInt, "1");
        }

        [TestMethod]
        public void UpdateWorkSchedule_OnIdIsZero_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestUpdateWorkSchedule(0, string.Empty);
        }

        [TestMethod]
        public void GetAutoPosts_OnScheduledWork_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestGetAutoPosts("SCHEDULEDWORK");
        }

        [TestMethod]
        public void GetAutoPosts_OnTimeSheets_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestGetAutoPosts("TIMESHEETS");
        }

        [TestMethod]
        public void GetAutoPosts_OnResourcePlans_ReturnBoolean()
        {
            // Arrange, Act, Assert
            TestGetAutoPosts("RESOURCEPLANS");
        }

        [TestMethod]
        public void PostCostValuesForScheduledWork_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_PFECN", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => DummyString;
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimPfeJob.AllInstances.QueueIDbRepositoryIMessageQueueString = (_, _2, _3, _4) => DummyInt;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;

            // Act
            var actualResult = _privateObject.Invoke("PostCostValuesForScheduledWork") as bool?;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.HasValue.ShouldBeTrue(),
                () => actualResult.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void PostCostValues_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var result = string.Empty;
            var postInstruction = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimdbaCostValues.PostCostValuesDBAccessStringStringOutStringOut = (DBAccess access, string s, out string out1, out string out2) =>
            {
                out1 = DummyString;
                out2 = DummyString;
                return true;
            };

            // Act
            var actualResult = _admininfos.PostCostValues(DummyString, out result, out postInstruction);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => result.ShouldContain(DummyString),
                () => postInstruction.ShouldContain(DummyString));
        }

        private void TestGetAutoPosts(string dataType)
        {
            // Arrange
            var items = new int[33, 32];
            SetupShimsForSqlClient();
            _privateObject.SetField("_PFECN", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyInt;

            // Act
            var actualResult = _privateObject.Invoke("GetAutoPosts", dataType, items) as bool?;

            // Assert
            items.ShouldSatisfyAllConditions(
                () => actualResult.HasValue.ShouldBeTrue(),
                () => actualResult.Value.ShouldBeTrue(),
                () => items[0, 0].ShouldBe(DummyInt),
                () => items[0, 1].ShouldBe(DummyInt));
        }

        private void TestUpdateWorkSchedule(int id, string sDefault)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                if (name.Equals("Default"))
                {
                    return sDefault;
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) =>
            {
                if (name.Equals("Id"))
                {
                    return id;
                }

                return DummyInt;
            };
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_DEF_FTE_WH"))
                {
                    return 2;
                }

                if (name.Equals("MaxId"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimAdminFunctions.CalcRPAllAvailabilitiesDBAccess = _ => true;
            ShimAdminFunctions.CalcAllDefaultFTEsDBAccess = _ => true;

            // Act
            var actualResult = _admininfos.UpdateWorkSchedule(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () =>
                {
                    if (id.Equals(DummyInt))
                    {
                        result.ShouldContain(
                            $"<WorkSchedule DataId=\"{DummyString}\" Id=\"{id}\"><Result Status=\"0\" /></WorkSchedule>");
                    }
                    else
                    {
                        result.ShouldContain(
                            $"<WorkSchedule DataId=\"{DummyString}\" Id=\"2\"><Result Status=\"0\" /></WorkSchedule>");
                    }
                });
        }

        private void TestUpdateRoles(int nFoundRoleID)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimUtilities.GetInt32SafelySqlDataReaderString = (_, _2) => nFoundRoleID;

            // Act
            var actualResult = _admininfos.UpdateRoles(DummyString, out result);

            // Assert
            actualResult.ShouldBeTrue();
        }

        private void TestUpdatePersonalItems(int key)
        {
            // Arrange
            var result = string.Empty;
            var error = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_RPE_DEPT_CODE") || name.Equals("NewID") || name.Equals("ADM_MC_LOOKUP"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimDataTable.AllInstances.LoadIDataReader = (dt, __) =>
            {
                dt.Columns.Add("NWI_SEQ", typeof(int));
                dt.Columns.Add("NWI_ID", typeof(int));
                dt.Columns.Add("NWI_NAME", typeof(string));
                dt.Columns.Add("NWI_LEVEL", typeof(int));
                dt.Columns.Add("NWI_IS_ITEM", typeof(int));
                dt.Columns.Add("NWI_CHARGENUMBER", typeof(string));
                dt.Columns.Add("NWI_CHARGESTATUS", typeof(string));
                dt.Rows.Add(DummyInt, DummyInt, DummyString, DummyInt, DummyInt, DummyString, DummyString);
            };
            ShimAdmininfos.AllInstances.GetPersonalItemsCStructStringDictionaryOfInt32PFELookup = (_, _2, _3, lookups) =>
            {
                lookups.Add(2, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 3
                });

                lookups.Add(key, new PFELookup
                {
                    Managers = new List<int> {DummyInt},
                    Executives = new List<int> {DummyInt},
                    bflag = false,
                    ID = 2
                });
            };
            ShimDataRow.AllInstances.RowStateGet = _ => DataRowState.Modified;

            // Act
            var actualResult = _admininfos.UpdatePersonalItems(DummyString, out result, out error);

            // Assert
            if (key.Equals(DummyInt))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain("<Data><Item Id=\"1\" DataId=\"\" /><Item Id=\"1\" DataId=\"\" /></Data>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => result.ShouldContain("<Data />"));
            }
        }

        private void TestUpdateResourceTimeoff(string errorMessage)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimAdmininfos.AllInstances.CheckIfResourceExistsStringInt32Ref = (AdmininfosCore admininfos, string s, ref int id) => errorMessage;
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 25;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimAllWorkhours.AllInstances.InitializeDataTableDataTable = (_, _2, _3) => { };
            ShimDataTable.AllInstances.LoadIDataReader = (_, _2) => { };
            ShimWorkhours.AllInstances.workhoursDateTime = (_, _2) => 2600;

            // Act
            var actualResult = _admininfos.UpdateResourceTimeoff(DummyString, out result);

            // Assert
            if (!string.IsNullOrEmpty(errorMessage))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => result.ShouldContain(
                        $"<Resource Id=\"1\" DataId=\"{DummyString}\" ExtId=\"{DummyString}\"><Result Status=\"1\"><![CDATA[{DummyString}]]></Result></Resource>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<Resource Id=\"1\" DataId=\"{DummyString}\" ExtId=\"{DummyString}\"><Category Id=\"1\" ExtId=\"{DummyString}\"><Result Status=\"0\"><![CDATA[Hours adjusted for this category, rows inserted for this category = 1]]></Result></Category></Resource>"));
            }
        }

        private void TestUpdateHolidaySchedule(int id, string sDefault)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                if (name.Equals("Default"))
                {
                    return sDefault;
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetDoubleAttrStringDouble = (_, _2, _3) => 0;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) =>
            {
                if (name.Equals("Id"))
                {
                    return id;
                }

                return DummyInt;
            };
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("GROUP_ID") || name.Equals("ADM_DEF_FTE_HOL"))
                {
                    return id;
                }

                if (name.Equals("MaxId"))
                {
                    return DummyInt;
                }

                if (name.Equals("GROUP_NAME"))
                {
                    return "Test";
                }

                return DummyString;
            };
            ShimAdminFunctions.CalcRPAllAvailabilitiesDBAccess = _ => true;
            ShimAdminFunctions.CalcAllDefaultFTEsDBAccess = _ => true;

            // Act
            var actualResult = _admininfos.UpdateHolidaySchedule(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () =>
                {
                    if (id.Equals(DummyInt))
                    {
                        result.ShouldContain(
                            $"<HolidaySchedule DataId=\"{DummyString}\" Id=\"{id}\"><Result Status=\"0\" /></HolidaySchedule>");
                    }
                    else
                    {
                        result.ShouldContain(
                            $"<HolidaySchedule DataId=\"{DummyString}\" Id=\"2\"><Result Status=\"0\" /></HolidaySchedule>");
                    }
                });
        }

        private void TestUpdateCategoriesFromRoles(int majorCategoryLookup)
        {
            // Arrange
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("ADM_MC_LOOKUP") || name.Equals("CountCategories"))
                {
                    return majorCategoryLookup;
                }

                if (name.Equals("CA_LEVEL") || name.Equals("CA_UID") || name.Equals("BC_UID"))
                {
                    return DummyInt;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.UpdateCategoriesFromRoles();

            // Assert
            actualResult.ShouldBeTrue();
        }

        private void TestDeleteWorkSchedule(int workScheduleId, string groupName)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, __) => workScheduleId;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("GROUP_NAME"))
                {
                    return groupName;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeleteWorkSchedule(DummyString, out result);

            // Assert
            if (workScheduleId.Equals(0))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<WorkSchedule DataId=\"{DummyString}\"><Result Status=\"1\"><![CDATA[No Work Schedule PFE Id]]></Result></WorkSchedule>"));
            }
            else if (!string.IsNullOrEmpty(groupName))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<WorkSchedule DataId=\"{DummyString}\" Id=\"1\"><Result Status=\"1\"><![CDATA[Group with selected Id: {DummyString}  is not a Work Schedule]]></Result></WorkSchedule>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<WorkSchedule DataId=\"{DummyString}\" Id=\"1\"><Result Status=\"0\" /></WorkSchedule>"));
            }
        }

        private void TestDeleteResourceTimeoff(string errorMessage, int nrows)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimAdmininfos.AllInstances.CheckIfResourceExistsStringInt32Ref = (AdmininfosCore admininfos, string s, ref int id) => errorMessage;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => nrows;
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) =>
            {
                if (name.Equals("Date"))
                {
                    return DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }

                return DummyString;
            };
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => DummyInt;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};

            // Act
            var actualResult = _admininfos.DeleteResourceTimeoff(DummyString, out result);

            // Assert
            if (!string.IsNullOrEmpty(errorMessage))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => result.ShouldContain(
                        $"<Resource Id=\"1\" DataId=\"{DummyString}\" ExtId=\"{DummyString}\"><Result Status=\"1\"><![CDATA[{DummyString}]]></Result></Resource>"));
            }
            else if (nrows.Equals(DummyInt))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<Resource Id=\"1\" DataId=\"{DummyString}\" ExtId=\"{DummyString}\"><Category Id=\"1\" ExtId=\"{DummyString}\"><Result Status=\"0\" /></Category></Resource>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<Resource Id=\"1\" DataId=\"{DummyString}\" ExtId=\"{DummyString}\"><Category Id=\"1\" ExtId=\"{DummyString}\"><Result Status=\"1\"><![CDATA[Rows deleted for this category = 0]]></Result></Category></Resource>"));
            }
        }

        private void TestDeletePIListWork(int projectId)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _2) => DummyString;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("PROJECT_ID"))
                {
                    return projectId;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeletePIListWork(DummyString, out result);

            // Assert
            if (projectId.Equals(0))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => result.ShouldContain(
                        $"<Data><Project Status=\"1\" ExtId=\"{DummyString}\"><![CDATA[PI not found]]></Project></Data>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<Data><Project Status=\"0\" ExtId=\"{DummyString}\"><![CDATA[Work rows deleted = 1]]></Project></Data>"));
            }
        }

        private void TestDeleteListWork(int projectId)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _2) => DummyString;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new CStruct()};
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("PROJECT_ID"))
                {
                    return projectId;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeleteListWork(DummyString, out result);

            // Assert
            if (projectId.Equals(0))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeFalse(),
                    () => result.ShouldContain(
                        $"<Data><Project Status=\"1\" ExtId=\"{DummyString}\"><![CDATA[PI not found]]></Project></Data>"));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeTrue(),
                    () => result.ShouldContain(
                        $"<Data><Project Status=\"0\" ExtId=\"{DummyString}\"><![CDATA[Work rows deleted = 1]]></Project></Data>"));
            }
        }

        private void TestDeleteHolidaySchedule(int deletehsUID, string groupName)
        {
            // Arrange
            var result = string.Empty;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            _privateObject.SetField("_dba", new DBAccess(DummyString));
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _2) => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) =>
            {
                if (name.Equals("Id"))
                {
                    return deletehsUID;
                }

                return DummyInt;
            };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("GROUP_NAME"))
                {
                    return groupName;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.DeleteHolidaySchedule(DummyString, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () =>
                {
                    if (deletehsUID.Equals(0))
                    {
                        result.ShouldContain(
                            $"<HolidaySchedule DataId=\"{DummyString}\"><Result Status=\"1\"><![CDATA[No Holiday Schedule PFE Id]]></Result></HolidaySchedule>");
                    }
                    else if (string.IsNullOrEmpty(groupName))
                    {
                        result.ShouldContain(
                            $"<HolidaySchedule DataId=\"{DummyString}\" Id=\"1\"><Result Status=\"0\" /></HolidaySchedule>");
                    }
                    else
                    {
                        result.ShouldContain(
                            $"<HolidaySchedule DataId=\"{DummyString}\" Id=\"1\"><Result Status=\"1\"><![CDATA[Group with selected Id: {DummyString}  is not a Holiday Schedule]]></Result></HolidaySchedule>");
                    }
                },
                () => actualResult.ShouldBeTrue());
        }

        private void TestCanDeleteLookupValue(int fieldId, int tableId)
        {
            // Arrange
            var result = string.Empty;
            var readCount = 0;
            SetupShimsForSqlClient();
            _privateObject.SetField("_sqlConnection", new SqlConnection());
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (readCount < 3)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name.Equals("LV_UID"))
                {
                    return DummyInt;
                }

                if (name.Equals("Field_ID"))
                {
                    return fieldId;
                }

                if (name.Equals("Table_ID"))
                {
                    return tableId;
                }

                if (name.Equals("LV_LEVEL"))
                {
                    return 2;
                }

                return DummyString;
            };

            // Act
            var actualResult = _admininfos.CanDeleteLookupValue(DummyInt, out result);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => result.ShouldContain(DummyString));
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

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.NewGuid();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, _2) => DummyString;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
            ShimSqlTransaction.AllInstances.Commit = _ => { };
            ShimSqlTransaction.AllInstances.Rollback = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction();
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
        }
    }
}

