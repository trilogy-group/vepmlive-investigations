using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Base
{
    using Fakes;

    [TestClass]
    public class CostsTests
    {
        private const string DummyString = "DummyString";
        private const string GetDetailValuesCostTypesAndCalendarsMethodName = "GetDetailValuesCostTypesAndCalendars";
        private static int ReadIntValueReturnValue = 1;
        private IDisposable shimContext;
        private ShimDBAccess dbaAccess;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            dbaAccess = new ShimDBAccess();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
        }

        private StatusEnum SelectDataByIdSuccess(SqlDb dba, string commandText, int id, StatusEnum statusError, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataByIdExpired(SqlDb dba, string commandText, int id, StatusEnum statusError, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSessionExpired;
        }

        private StatusEnum SelectDataStatusEnumSuccess(SqlDb sqlDb, SqlCommand sqlCommand, StatusEnum statusEnum, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private int ReadIntValueTrue(object objectValue, out bool isNull)
        {
            isNull = false;
            return ReadIntValueReturnValue;
        }

        private int ReadIntValueIsNull(object objectValue, out bool isNull)
        {
            isNull = true;
            return 0;
        }

        private StatusEnum SelectDataSuccess(SqlDb dba, string commandText, StatusEnum statusError, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private DateTime ReadDateValue(object objectValue, out bool isNull)
        {
            isNull = false;
            return DateTime.Now;
        }

        [TestMethod]
        public void SelectProjectIDByExtUID_OnSuccess_ReturnStatusSuccess()
        {
            // Arrange
            var projectId = 0;
            const int ExpectedId = 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = valueObject => ExpectedId;

            // Act
            var result = dbaEditCosts.SelectProjectIDByExtUID(dbaAccess, DummyString, out projectId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreEqual(ExpectedId, projectId);
        }

        [TestMethod]
        public void SelectProjectIDByExtUID_OnException_ReturnStatusError()
        {
            // Arrange
            var projectId = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = valueObject =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.SelectProjectIDByExtUID(dbaAccess, DummyString, out projectId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void SelectPIs_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectPIs(dbaAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectViews_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectViews(dbaAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCostTypesByView_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCostTypesByView(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCostType_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCostType(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCostTypeOperations_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCostTypeOperations(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectNamedRateItems_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectNamedRateItems(dbaAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectNamedRateValues_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectNamedRateValues(dbaAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCalendarPeriods_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCalendarPeriods(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCostCategories_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCostCategories(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectPIDetails_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectPIDetails(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectCostCustomFields_Should_ExecuteCorrectly()
        {
            // Arrange
            var dba = new ShimDBAccess().Instance;
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectCostCustomFields(dba, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectLookup_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectLookup(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectPeriodsRates_Should_ExecuteCorrectly()
        {
            // Arrange
            var dataTable = new DataTable();

            // Act
            var result = dbaEditCosts.SelectPeriodsRates(dbaAccess, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectPeriodsCostDetailsValues_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { },
            };

            // Act
            var result = dbaEditCosts.SelectPeriodsCostDetailsValues(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectPeriodsCostDetailsValues_OnException_ReturnsStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.SelectPeriodsCostDetailsValues(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void SelectPeriodsCostValues_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { },
            };

            // Act
            var result = dbaEditCosts.SelectPeriodsCostValues(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.IsNotNull(dataTable);
        }

        [TestMethod]
        public void SelectPeriodsCostValues_OnException_ReturnsStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.SelectPeriodsCostValues(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void DeleteCostDetailValues_OnSccess_ReturnsStatusSuccess()
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
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.DeleteCostDetailValues(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void DeleteCostDetailValues_OnException_ReturnsStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                },
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.DeleteCostDetailValues(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void InsertCostDetails_OnSccess_ReturnsStatusSuccess()
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
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.InsertCostDetails(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertCostDetails_OnException_ReturnsStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                },
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.InsertCostDetails(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void InsertCostDetailValues_OnSccess_ReturnsStatusSuccess()
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
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.InsertCostDetailValues(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void InsertCostDetailValues_OnException_ReturnsStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () =>
                {
                    throw new Exception();
                },
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.InsertCostDetailValues(dbaAccess, 1, 1, 1, dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void CheckoutPI_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.CheckoutPI(dbaAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void CheckoutPI_OnException_ReturnsStatusError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.CheckoutPI(dbaAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void CheckinPI_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.CheckinPI(dbaAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void CheckinPI_OnException_ReturnsStatusError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.CheckinPI(dbaAccess, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void DeleteCostDetails_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.DeleteCostDetails(dbaAccess, 1, 1, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostDetails_OnException_ReturnsStatusError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.DeleteCostDetails(dbaAccess, 1, 1, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void DeleteCostDetailsValues_OnSccess_ReturnsStatusSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaEditCosts.DeleteCostDetailsValues(dbaAccess, 1, 1, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, rowsAffected);
        }

        [TestMethod]
        public void DeleteCostDetailsValues_OnException_ReturnsStatusError()
        {
            // Arrange
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.DeleteCostDetailsValues(dbaAccess, 1, 1, 1, out rowsAffected);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(0, rowsAffected);
        }

        [TestMethod]
        public void GetProjectInfo_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dateStart = new DateTime();
            var dateFinish = new DateTime();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString,
                Close = () => { }
            };
            ShimSqlDb.ReadDateValueObjectBooleanOut = ReadDateValue;

            // Act
            var result = dbaEditCosts.GetProjectInfo(dbaAccess, 1, out dateStart, out dateFinish);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreEqual(DateTime.Now.Date, dateStart.Date);
            Assert.AreEqual(DateTime.Now.Date, dateFinish.Date);
        }

        [TestMethod]
        public void GetProjectInfo_OnException_ReturnsStatusEeror()
        {
            // Arrange
            var dateStart = new DateTime();
            var dateFinish = new DateTime();
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.GetProjectInfo(dbaAccess, 1, out dateStart, out dateFinish);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.AreEqual(DateTime.MinValue, dateStart.Date);
            Assert.AreEqual(DateTime.MinValue, dateFinish.Date);
        }

        [TestMethod]
        public void SelectViewCalendarInfo_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var calendarId = 0;
            var firstPeriod = 0;
            var lastPeriod = 0;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = ReadIntValueTrue;

            // Act
            var result = dbaEditCosts.SelectViewCalendarInfo(dbaAccess, 1, out calendarId, out firstPeriod, out lastPeriod);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreEqual(1, firstPeriod);
            Assert.AreEqual(1, lastPeriod);
        }

        [TestMethod]
        public void SelectViewCalendarInfo_SelectDataByIdStatusExpired_ReturnsStatusError()
        {
            // Arrange
            var calendarId = 0;
            var firstPeriod = 0;
            var lastPeriod = 0;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdExpired;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = ReadIntValueTrue;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSessionExpired;

            // Act
            var result = dbaEditCosts.SelectViewCalendarInfo(dbaAccess, 1, out calendarId, out firstPeriod, out lastPeriod);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSessionExpired, result);
        }

        [TestMethod]
        public void SelectViewCalendarInfo_OnException_ReturnsStatusError()
        {
            // Arrange
            var calendarId = 0;
            var firstPeriod = 0;
            var lastPeriod = 0;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = ReadIntValueTrue;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSessionExpired;
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.SelectViewCalendarInfo(dbaAccess, 1, out calendarId, out firstPeriod, out lastPeriod);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void GetDiscountRate_StatusError_Returns0()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdExpired;
            // Act
            var result = dbaEditCosts.GetDiscountRate(dbaAccess, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetDiscountRate_StatusSuccess_ReturnsDecimalValue()
        {
            // Arrange
            const decimal DecimalValue = 5.6M;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetInt32 = index => DecimalValue
                }
            };
            // Act
            var result = dbaEditCosts.GetDiscountRate(dbaAccess, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(DecimalValue, result);
        }

        [TestMethod]
        public void SelectCostCategoryData_OnSuccess_ReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { },
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Close = () => { }
            };

            // Act
            var result = dbaEditCosts.SelectCostCategoryData(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectCostCategoryData_OnException_ReturnStatusError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                LoadIDataReader = reader => { }
            }.Instance;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, sFunction, status, text, skipLog) => StatusEnum.rsServerError;

            // Act
            var result = dbaEditCosts.SelectCostCategoryData(dbaAccess, 1, 1, 1, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void UpdateCostDetailValuesWithNewDiscount_Should_ExecuteCorrectly()
        {
            // Arrange
            var queryExecuted = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                queryExecuted = true;
                return 1;
            };
            ShimdbaEditCosts.GetDetailValuesCostTypesAndCalendarsDBAccessInt32 =
                (dba, projectId) => new int[][] { new int[] { 1, 2 } };

            // Act
            dbaEditCosts.UpdateCostValuesAfterDiscountChanged(dbaAccess, 1, 1);

            // Assert
            Assert.IsTrue(queryExecuted);
        }

        [TestMethod]
        public void UpdateCostDetailValuesWithNewDiscount_OnException_HandleStatusError()
        {
            // Arrange
            var handleStatusError = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean = (_, severity, function, status, text, skipLog) =>
            {
                handleStatusError = true;
                return StatusEnum.rsServerError;
            };

            // Act
            dbaEditCosts.UpdateCostValuesAfterDiscountChanged(dbaAccess, 1, 1);

            // Assert
            Assert.IsTrue(handleStatusError);
        }

        [TestMethod]
        public void GetDetailValuesCostTypesAndCalendars_Should_ReturnValue()
        {
            // Arrange
            var privateType = new PrivateType(typeof(dbaEditCosts));
            ShimSqlDb.AllInstances.SelectDataSqlCommandStatusEnumDataTableOut = SelectDataStatusEnumSuccess;
            ShimDataTable.AllInstances.Select = _ => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetInt32 = i => 1
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetDetailValuesCostTypesAndCalendarsMethodName, dbaAccess.Instance, 1) as int[][];

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckCostTypeSecurity_IsNullReadAndIsNullEdit_ReturnsFalse()
        {
            // Arrange
            var costTypeEditMode = 0;
            var dba = dbaAccess.Instance;
            dba.UserWResID = 2;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { },
                ItemGetString = name => new object()
            };
            ShimSqlDb.ReadIntValueObject = valueObject => 1;
            ShimSqlDb.ReadIntValueObjectBooleanOut = ReadIntValueIsNull;

            // Act
            var result = dbaEditCosts.CheckCostTypeSecurity(dba, 1, ref costTypeEditMode);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCostTypeSecurity_CanEditAndCanRead0_ReturnsFalse()
        {
            // Arrange
            var costTypeEditMode = 0;
            var dba = dbaAccess.Instance;
            dba.UserWResID = 2;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { },
                ItemGetString = name => new object()
            };
            ReadIntValueReturnValue = 0;
            ShimSqlDb.ReadIntValueObject = valueObject => 1;
            ShimSqlDb.ReadIntValueObjectBooleanOut = ReadIntValueTrue;

            // Act
            var result = dbaEditCosts.CheckCostTypeSecurity(dba, 1, ref costTypeEditMode);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}
