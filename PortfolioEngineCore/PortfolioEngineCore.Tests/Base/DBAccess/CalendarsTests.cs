using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Base
{
    using System.Data;
    using System.Data.Fakes;
    using System.Data.SqlClient.Fakes;
    using Fakes;
    using PortfolioEngineCore;
    using Shouldly;

    [TestClass]
    public class CalendarsTests
    {
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private static string CommandText = string.Empty;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            dbAccess = new ShimDBAccess().Instance;
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlDb.FormatAdminErrorStringStringStringString = 
                (severity, location, message, trace) => $"{severity} - {location} - {message} - {trace}";
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean = 
                (_, severity, function, code, exceptionMessage, skipLog) => StatusEnum.rsServerError;


        }

        [TestMethod]
        public void SelectCalendars_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT * FROM EPGP_COST_BREAKDOWNS ORDER BY CB_NAME";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCalendars.SelectCalendars(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCalendar_CalendarIdLessThan0_ShouldReutnrStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT CB_ID=0,CB_NAME='New Calendar',CB_DESC=NULL,CB_LOCK_TO=NULL,CB_LOCK_FROM=NULL";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCalendars.SelectCalendar(dbAccess, -1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCalendar_CalendarIdGreaterThan0_ShouldReutnrStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = @p1";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.SelectCalendar(dbAccess, 3, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCalendarByName_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT * FROM EPGP_COST_BREAKDOWNS WHERE CB_NAME = @p1";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;

            // Act
            var result = dbaCalendars.SelectCalendarByName(dbAccess, DummyString, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCalendarPeriods_OnSuccess_ReturnsStatusEnumSuccess()
        {           
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT * FROM EPG_PERIODS WHERE CB_ID = @p1 Order By PRD_ID";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.SelectCalendarPeriods(dbAccess, 1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCalendarPeriodCount_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "SELECT MAX(PRD_ID) as PeriodCount FROM EPG_PERIODS WHERE CB_ID = @p1";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.SelectCalendarPeriodCount(dbAccess, 1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void DeletePeriods_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            const string ExpectedCommandText = "DELETE FROM EPG_PERIODS WHERE CB_ID = @p1";
            ShimSqlDb.AllInstances.DeleteDataByIdStringInt32StatusEnumInt32Out = DeleteDataByIdSuccess;

            // Act
            var result = dbaCalendars.DeletePeriods(dbAccess, 1, out rowsAffected);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => rowsAffected.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void ReadCalendarFTEs_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            const string ExpectedCommandText = "EPG_SP_ReadCalendarFTEs @p1";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.ReadCalendarFTEs(dbAccess, 1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedCommandText),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void InsertPeriods_OnSuccess_ShouldReturnStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow()
                    }.GetEnumerator()
                }
            };
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = dbaCalendars.InsertPeriods(dbAccess, 1, dataTable, out rowsAffected);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => rowsAffected.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void InsertPeriods_OnException_ShouldReturnStatusEnumError()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow()
                    }.GetEnumerator()
                }
            };
            var rowsAffected = 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCalendars.InsertPeriods(dbAccess, 1, dataTable, out rowsAffected);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsServerError),
                () => rowsAffected.ShouldBe(0));
        }

        [TestMethod]
        public void DeleteCalendar_DataTableRowsEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Can't delete Calendar, Calendar not found";
            var reply = string.Empty;
            const int CalendarId = 1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0
            };
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.DeleteCalendar(dbAccess, CalendarId, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void DeleteCalendar_CalendarIdZero_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Can't delete Timesheet Calendar";
            var reply = string.Empty;
            const int CalendarId = 0;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCalendars.DeleteCalendar(dbAccess, CalendarId, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }


        [TestMethod]
        public void DeleteCalendar_MessageNotEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "This Calendar cannot be deleted, it is used as follows:";
            var reply = string.Empty;
            const int CalendarId = 1;
            var readCount = 0;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimSqlDataReader.AllInstances.Read = _ => ++readCount <= 1;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyString;

            // Act
            var result = dbaCalendars.DeleteCalendar(dbAccess, CalendarId, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void DeleteCalendar_OnSuccess_ReturnsStautsSuccess()
        {
            // Arrange
            var reply = string.Empty;
            const int CalendarId = 1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => DummyString;

            // Act
            var result = dbaCalendars.DeleteCalendar(dbAccess, CalendarId, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeEmpty());
        }

        [TestMethod]
        public void DeleteCalendar_OnException_ReturnsServerError()
        {
            // Arrange
            var reply = string.Empty;
            const int CalendarId = 1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCalendars.DeleteCalendar(dbAccess, CalendarId, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsServerError),
                () => reply.ShouldBeEmpty());
        }

        private StatusEnum DeleteDataByIdSuccess(SqlDb db, string commandText, int id, StatusEnum statusEnumError, out int rowsAffected)
        {
            CommandText = commandText;
            rowsAffected = DummyInt;
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataByNameSuccess(SqlDb db, string commandText, string name, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataByIdSuccess(SqlDb db, string commandText, int id, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataSuccess(SqlDb db, string commandText, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
