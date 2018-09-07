using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class CostTypesTests
    {
        private const string DummyString = "DummyString";
        private const string CostTypeName = "CT_NAME";
        private IDisposable shimContext;
        private DBAccess dbAccess;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            dbAccess = new ShimDBAccess();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, function, status, text, skipLog) => StatusEnum.rsServerError;
            ShimSqlDb.ReadIntValueObject = objectValue => 1;
            ShimSqlDb.ReadStringValueObject = objectValue => DummyString;
            ShimSqlDb.AllInstances.ConnectionGet = _ => new ShimSqlConnection
            {
                BeginTransaction = () => new ShimSqlTransaction
                {
                    Commit = () => { }
                }
            };
        }

        [TestMethod]
        public void SelectCalendars_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCalendars(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypeFormula_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypeFormula(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCustomFieldsCost_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCustomFields_Cost(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypePostOptions_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypePostOptions(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostCategories_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostCategories(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCustomFieldForCostType_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCustomFieldForCostType(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectInitializedCostTypeCustomFields_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectInitializedCostTypeCustomFields(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypeCustomField_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypeCustomField(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTotalsInfo_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTotalsInfo(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypesForCalc_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypesForCalc(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostType_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostType(dbAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypeCustomFields_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypeCustomFields(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectBudgetTotalList_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectBudgetTotalList(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostTypes_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataStatusSuccess;

            // Act
            var result = dbaCostTypes.SelectCostTypes(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsAutoPostEnabledOnRatePerProjectChange_DBAccessNull_ThrowsException()
        {
            // Arrange, Act
            var result = dbaCostTypes.IsAutoPostEnabledOnRatePerProjectChange(null, 1);

            // Assert
            // Expect an Exception
        }

        [TestMethod]
        public void IsAutoPostEnabledOnRatePerProjectChange_StatusSuccess_ReturnsTrue()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataSqlCommandStatusEnumDataTableOut = SelectDataSqlCommandStatusSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetInt32 = index => 1
                }
            };

            // Act
            var result = dbaCostTypes.IsAutoPostEnabledOnRatePerProjectChange(dbAccess, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsAutoPostEnabledOnRatePerProjectChange_StatusNotSuccess_ReturnsFalse()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataSqlCommandStatusEnumDataTableOut = SelectDataSqlCommandStatusError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetInt32 = index => 1
                }
            };

            // Act
            var result = dbaCostTypes.IsAutoPostEnabledOnRatePerProjectChange(dbAccess, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteAvailableCostTypeCategories_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteAvailableCostTypeCategories(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteAvailableCostTypeCategories_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteAvailableCostTypeCategories(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostTypeCustomField_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteCostTypeCustomField(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void DeleteCostTypeCustomField_OnException_ReturnsStatusEnumCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteCostTypeCustomField(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void DeleteCostTypeFormula_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteCostTypeFormula(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostTypeFormula_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteCostTypeFormula(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostTotals_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteCostTotals(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostTotals_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteCostTotals(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCTCustomFields_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteCTCustomFields(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCTCustomFields_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteCTCustomFields(dbAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(0, rowsAffected);
        }

        [TestMethod]
        public void InsertAvailableCostTypeCategories_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.InsertAvailableCostTypeCategories(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertAvailableCostTypeCategories_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = dbaCostTypes.InsertAvailableCostTypeCategories(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void InsertCostTotals_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.InsertCostTotals(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertCostTotals_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = dbaCostTypes.InsertCostTotals(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void InsertCostCustomFields_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.InsertCostCustomFields(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertCostCustomFields_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = dbaCostTypes.InsertCostCustomFields(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void InsertCostTypeFormula_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.InsertCostTypeFormula(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertCostTypeFormula_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = dbaCostTypes.InsertCostTypeFormula(dbAccess, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void DeleteCostType_CanDeleteCostTypeFalse_ReturnsSqlDbStatus()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaCostTypes.CanDeleteCostTypeDBAccessInt32StringOut = CanDeleteCostStatusError;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSessionExpired;

            // Act
            var result = dbaCostTypes.DeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSessionExpired, result);
        }

        [TestMethod]
        public void DeleteCostType_DeleteMessageNotEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaCostTypes.CanDeleteCostTypeDBAccessInt32StringOut = CanDeleteCostStatusSuccessWithMessage;

            // Act
            var result = dbaCostTypes.DeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void DeleteCostType_DataTableEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaCostTypes.CanDeleteCostTypeDBAccessInt32StringOut = CanDeleteCostStatusSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0
            };

            // Act
            var result = dbaCostTypes.DeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void DeleteCostType_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaCostTypes.CanDeleteCostTypeDBAccessInt32StringOut = CanDeleteCostStatusSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.DeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void DeleteCostType_OnException_ReturnsStatusError()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaCostTypes.CanDeleteCostTypeDBAccessInt32StringOut = CanDeleteCostStatusSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdStatusSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.DeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void CanDeleteCostType_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { },
                Read = () => ++count <= 1,
                ItemGetString = name => DummyString
            };

            // Act
            var result = dbaCostTypes.CanDeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void CanDeleteCostType_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.CanDeleteCostType(dbAccess, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
        }

        [TestMethod]
        public void UpdateCostTotalsInfo_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTotalsInfo(dbAccess, 1, dataTable, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateCostTotalsInfo_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTotalsInfo(dbAccess, 1, dataTable, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
        }

        [TestMethod]
        public void UpdateCostTypeCustomFieldInfo_FieldNameEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeCustomFieldInfo(dbAccess, 1, string.Empty,
                DummyString, 1, 1, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeCustomFieldInfo_LookupIdZero_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeCustomFieldInfo(dbAccess, 1, DummyString,
                DummyString, 0, 1, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeCustomFieldInfo_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeCustomFieldInfo(dbAccess, 1, DummyString,
                DummyString, 1, 1, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateCostTypeCustomFieldInfo_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.UpdateCostTypeCustomFieldInfo(dbAccess, 1, DummyString,
                DummyString, 1, 1, 1, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
        }

        [TestMethod]
        public void UpdateCostTypeSecurityInfo_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var csStruct = new ShimCStruct
            {
                GetListString = name => new List<CStruct>
                {
                    new ShimCStruct
                    {
                        GetIntAttrString = attributeName => 1
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeSecurityInfo(dbAccess, 1, csStruct, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateCostTypeSecurityInfo_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var csStruct = new ShimCStruct
            {
                GetListString = name =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = dbaCostTypes.UpdateCostTypeSecurityInfo(dbAccess, 1, csStruct, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_NameEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var ctId = 1;
            var availCCs = new ShimCStruct();
            var cfs = new ShimCStruct();
            var reply = string.Empty;

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, string.Empty,
                1, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_ExistingIdDifferentFromCTId_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var ctId = 10;
            var availCCs = new ShimCStruct();
            var cfs = new ShimCStruct();
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSucces;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                1, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_ValidateAndSaveCostTypeWithReplyNotEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var ctId = 1;
            var availCCs = new ShimCStruct();
            var cfs = new ShimCStruct();
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSucces;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeFormula;

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                3, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_CTIdEqualsZero_ReturnsSuccess()
        {
            // Arrange
            var ctId = 0;
            var availCCs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>()
            };
            var cfs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>()
            };
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeFormulaEmptyResult;
            ShimSqlDb.AllInstances.GetLastIdentityValueInt32Out = GetLastIdentityValueZero;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                3, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsTrue(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_CTIdEquals1_ReturnsSuccess()
        {
            // Arrange
            var ctId = 1;
            var availCCs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>
                {
                    new ShimCStruct
                    {
                        GetIntAttrString = attrName => 1
                    }
                }
            };
            var cfs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>
                {
                    new ShimCStruct
                    {
                        GetIntAttrString = attrName => 1
                    }
                }
            };
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeFormulaEmptyResult;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                1, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateCostTypeInfo_EditModeCalculated_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var ctId = 1;
            var availCCs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>
                {
                    new ShimCStruct
                    {
                        GetIntAttrString = attrName => 1
                    }
                }
            };
            var cfs = new ShimCStruct
            {
                GetListString = name => new List<CStruct>
                {
                    new ShimCStruct
                    {
                        GetIntAttrString = attrName => 1
                    }
                }
            };
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeFormulaEmptyResult;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeFormulaConditional;

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                3, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdateCostTypeInfo_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var ctId = 1;
            var availCCs = new ShimCStruct();
            var cfs = new ShimCStruct();
            var reply = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSucces;
            ShimDataTable.AllInstances.RowsGet = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.UpdateCostTypeInfo(dbAccess, ref ctId, DummyString,
                3, 1, 1, 1, availCCs, cfs, DummyString, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdatePostOptionsInfo_lEMode_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { },
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = objectValue => 1;

            // Act
            var result = dbaCostTypes.UpdatePostOptionsInfo(dbAccess, 1, DummyString, true, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
            Assert.IsFalse(string.IsNullOrEmpty(reply));
        }

        [TestMethod]
        public void UpdatePostOptionsInfo_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            const string Calendar = "1,2";
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { },
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = objectValue => 41;

            // Act
            var result = dbaCostTypes.UpdatePostOptionsInfo(dbAccess, 1, Calendar, true, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdatePostOptionsInfo_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            const string Calendar = "1,2";
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostTypes.UpdatePostOptionsInfo(dbAccess, 1, Calendar, true, out reply);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsRequestCannotBeCompleted, result);
        }

        [TestMethod]
        public void ValidateAndSaveCostTypeFormula_FormulaEmpty_ReturnsEmptyValue()
        {
            // Arrange
            var formula = string.Empty;

            // Act
            var result = dbaCostTypes.ValidateAndSaveCostTypeFormula(dbAccess, 1, ref formula, true);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void ValidateAndSaveCostTypeFormula_CorrectFormula_ReturnsEmptyValue()
        {
            // Arrange
            var formula = $"{DummyString}+1-3+{DummyString}";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { }
            };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            return name == CostTypeName ? DummyString : "1";
                        }
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.ValidateAndSaveCostTypeFormula(dbAccess, 1, ref formula, true);

            // Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void ValidateAndSaveCostTypeFormula_TooManyOperatorsFormula_ReturnsErrorMessage()
        {
            // Arrange
            var formula = $"+-{DummyString}";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { }
            };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            return name == CostTypeName ? DummyString : "1";
                        }
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.ValidateAndSaveCostTypeFormula(dbAccess, 1, ref formula, true);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void ValidateAndSaveCostTypeFormula_UnkownCostType_ReturnsErrorMessage()
        {
            // Arrange
            var formula = $"{DummyString}+{DummyString}{DummyString}";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { }
            };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => name == CostTypeName ? DummyString : "1"
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCostTypes.ValidateAndSaveCostTypeFormula(dbAccess, 1, ref formula, true);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataStatusSuccess(SqlDb sqlDb, string text, StatusEnum statusError, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByIdStatusSuccess(SqlDb sqlDb, string text, int id, StatusEnum arg4, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSqlCommandStatusSuccess(SqlDb sqldb, SqlCommand sqlCommand, StatusEnum statusEnum, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSqlCommandStatusError(SqlDb sqldb, SqlCommand sqlCommand, StatusEnum statusEnum, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsServerError;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteCostStatusSuccessWithMessage(DBAccess dbAccess, int id, out string message)
        {
            message = DummyString;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteCostStatusSuccess(DBAccess dbAccess, int id, out string message)
        {
            message = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteCostStatusError(DBAccess dbAccess, int id, out string message)
        {
            message = string.Empty;
            return StatusEnum.rsServerError;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private bool GetLastIdentityValueZero(SqlDb sqlDb, out int ctId)
        {
            ctId = 0;
            return true;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private string ValidateAndSaveCostTypeFormulaEmptyResult(DBAccess dba, int nFieldId, ref string sFormula, bool bSave)
        {
            sFormula = DummyString;
            return string.Empty;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private string ValidateAndSaveCostTypeFormula(DBAccess dba, int nFieldId, ref string sFormula, bool bSave)
        {
            sFormula = DummyString;
            return DummyString;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private string ValidateAndSaveCostTypeFormulaConditional(DBAccess dba, int nFieldId, ref string sFormula, bool bSave)
        {
            sFormula = DummyString;
            return bSave ? DummyString : string.Empty;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        /// 
        private StatusEnum SelectDataByNameSucces(SqlDb sqlDb, string text, string name, StatusEnum statusOnException, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// These methods are fakes and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameError(SqlDb sqlDb, string text, string name, StatusEnum statusOnException, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsEVCalcError;
        }
    }
}