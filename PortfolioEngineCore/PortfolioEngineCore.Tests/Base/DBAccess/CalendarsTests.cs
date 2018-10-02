using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    using Fakes;
    using PortfolioEngineCore;

    [TestClass]
    public class CalendarsTests
    {
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private static string CommandText = string.Empty;
        private const string DummyString = "DummyString";
        private const string PeriodName = "PRD_NAME";
        private const string PeriodStartDate = "PRD_START_DATE";
        private const string PeriodFinishDate = "PRD_FINISH_DATE";
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

        [TestMethod]
        public void UpdateCalendar_CalendarNameEmpty_ReturnsStautsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Please enter a Calendar Name";
            var reply = string.Empty;
            var calendarId = 0;

            // Act
            var result = dbaCalendars.UpdateCalendar(dbAccess, ref calendarId, string.Empty, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
               () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
               () => reply.ShouldNotBeNullOrEmpty(),
               () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateCalendar_CalendarNameAlreadyExists_ReturnsStautsRequestCannotBeCompleted()
        {
            // Arrange
            var ExpectedErrorMessage = $"Can't save Calendar.\nA field with name '{DummyString}' already exists";
            var reply = string.Empty;
            var calendarId = 3;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };

            // Act
            var result = dbaCalendars.UpdateCalendar(dbAccess, ref calendarId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
               () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
               () => reply.ShouldNotBeNullOrEmpty(),
               () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateCalendar_CalendarIDGreaterThan0_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var calendarId = 1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0,
            };

            // Act
            var result = dbaCalendars.UpdateCalendar(dbAccess, ref calendarId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
               () => result.ShouldBe(StatusEnum.rsSuccess),
               () => reply.ShouldBeEmpty());
        }

        [TestMethod]
        public void UpdateCalendar_CalendarIDLessThan0_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var calendarId = -1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0,
            };

            // Act
            var result = dbaCalendars.UpdateCalendar(dbAccess, ref calendarId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
               () => result.ShouldBe(StatusEnum.rsSuccess),
               () => reply.ShouldBeEmpty());
        }

        [TestMethod]
        public void UpdateCalendar_OnException_ReturnsStatusServerError()
        {
            // Arrange
            const string ExpectedErrorMessage = "Dummy MEssage";
            var reply = string.Empty;
            var calendarId = -1;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0,
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception(ExpectedErrorMessage);
            };

            // Act
            var result = dbaCalendars.UpdateCalendar(dbAccess, ref calendarId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
               () => result.ShouldBe(StatusEnum.rsSuccess),
               () => reply.ShouldNotBeNullOrEmpty(),
               () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void CheckPeriods_PeriodNameEmpty_ReturnStatusRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "All Periods must have a name";
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
                            ItemGetString = name =>
                            {
                                switch (name)
                                {
                                    case PeriodName:
                                        return string.Empty;
                                    default:
                                        return DateTime.Now;
                                }
                            }
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaCalendars.CheckPeriods(dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void CheckPeriods_StartDateGreaterThanFinishDate_ReturnStatusRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Period finish must be later than period start";
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
                            ItemGetString = name =>
                            {
                                switch (name)
                                {
                                    case PeriodName:
                                        return DummyString;
                                    case PeriodStartDate:
                                        return DateTime.Now.AddDays(1);
                                    case PeriodFinishDate:
                                        return DateTime.Now.AddDays(-1);
                                    default:
                                        return string.Empty;
                                }
                            }
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaCalendars.CheckPeriods(dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void CheckPeriods_StartDateNotContigousWithPreviousFinishDate_ReturnStatusRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Period start date must be contiguous with previous period finish date";
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
                            ItemGetString = name =>
                            {
                                switch (name)
                                {
                                    case PeriodName:
                                        return DummyString;
                                    case PeriodStartDate:
                                        return DateTime.Now.AddDays(-1);
                                    case PeriodFinishDate:
                                        return DateTime.Now.AddDays(1);
                                    default:
                                        return string.Empty;
                                }
                            }
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name =>
                            {
                                switch (name)
                                {
                                    case PeriodName:
                                        return DummyString;
                                    case PeriodStartDate:
                                        return DateTime.Now.AddDays(-1);
                                    case PeriodFinishDate:
                                        return DateTime.Now.AddDays(1);
                                    default:
                                        return string.Empty;
                                }
                            }
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaCalendars.CheckPeriods(dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(ExpectedErrorMessage));
        }

        [TestMethod]
        public void CheckPeriods_OnSuccess_ReturnsStatusSuccess()
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
                            ItemGetString = name =>
                            {
                                switch (name)
                                {
                                    case PeriodName:
                                        return DummyString;
                                    case PeriodStartDate:
                                        return DateTime.Now.AddDays(-1);
                                    case PeriodFinishDate:
                                        return DateTime.Now.AddDays(1);
                                    default:
                                        return string.Empty;
                                }
                            }
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaCalendars.CheckPeriods(dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeEmpty());
        }

        [TestMethod]
        public void CheckPeriods_OnException_ReturnsStatusRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Dummy Message";
            var reply = string.Empty;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () =>
                    {
                        throw new Exception(ExpectedErrorMessage);
                    }
                }
            };

            // Act
            var result = dbaCalendars.CheckPeriods(dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedErrorMessage));
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteDataByIdSuccess(SqlDb db, string commandText, int id, StatusEnum statusEnumError, out int rowsAffected)
        {
            CommandText = commandText;
            rowsAffected = DummyInt;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameSuccess(SqlDb db, string commandText, string name, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByIdSuccess(SqlDb db, string commandText, int id, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSuccess(SqlDb db, string commandText, StatusEnum statusEnumError, out DataTable dataTable)
        {
            CommandText = commandText;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
