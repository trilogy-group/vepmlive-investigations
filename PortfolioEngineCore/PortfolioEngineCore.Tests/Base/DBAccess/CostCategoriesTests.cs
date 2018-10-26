using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class CostCategoriesTests
    {
        private IDisposable shimsContext;
        private const string DummyString = "";
        private static string CommandText = string.Empty;
        private static StatusEnum StatusEnumReturn;
        private DBAccess dbAccess;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            dbAccess = new ShimDBAccess();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimSqlDb.AllInstances.CommitTransaction = _ => { };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };
            ShimSqlDb.AllInstances.ConnectionGet = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction
            {
                Commit = () => { },
            };
        }

        [TestMethod]
        public void SelectCostCategories_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            const string ExpectedCommandText = "SELECT * FROM EPGP_CATEGORIES ORDER BY CA_ID";
            DataTable dataTable = null;
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectData;
            StatusEnumReturn = StatusEnum.rsSuccess;

            // Act
            var result = dbaCostCategories.SelectCostCategories(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedCommandText));
        }

        [TestMethod]
        public void ReadCostCategoryRates_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            DataTable dataTable = null;
            var baseRate = 0M;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataById;
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 10
                }
            };

            // Act
            var result = dbaCostCategories.ReadCostCategoryRates(dbAccess, 1, out baseRate, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => baseRate.ShouldBe(10M));
        }

        [TestMethod]
        public void ReadCostCategoryRates_OnError_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            DataTable dataTable = null;
            var baseRate = 0M;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataById;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = dbaCostCategories.ReadCostCategoryRates(dbAccess, 1, out baseRate, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => dataTable.ShouldNotBeNull(),
                () => baseRate.ShouldBe(0));
        }

        [TestMethod]
        public void CanDeleteCostCategory_Should_ReturnsStatusSuccess()
        {
            // Arrange
            const string BcuIds = "1";
            var reply = string.Empty;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 2,
                ItemGetString = name => DummyString
            };

            // Act
            var result = dbaCostCategories.CanDeleteCostCategory(dbAccess, BcuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void CanDeleteCostCategory_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string BcuIds = "1";
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostCategories.CanDeleteCostCategory(dbAccess, BcuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void CreateCostCategories_MajorCategoryLookupZero_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 0
                }
            };
            var expectedCommands = new List<string>
            {
                "Delete From EPGP_COST_CATEGORIES",
                "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID)" +
                " Select CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM,0,CA_UID as CC From EPGP_CATEGORIES"
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            var result = dbaCostCategories.CreateCostCategories(dbAccess, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(e => executedCommands.Contains(e)).ShouldBeTrue());
        }

        [TestMethod]
        public void CreateCostCategories_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 0
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostCategories.CreateCostCategories(dbAccess, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain("CostCategories.CreateCostCategories"));
        }

        [TestMethod]
        public void CreateCostCategories_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var count = 0;
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => 1
                }
            };
            var expectedCommands = new List<string>
            {
                "Delete From EPGP_COST_CATEGORIES",
                "Insert Into EPGP_COST_CATEGORIES (BC_UID,BC_NAME,BC_ID,BC_LEVEL,BC_ROLE,BC_UOM,MC_UID,CA_UID)" +
                " Values (@UID,@NAME,@ID,@LEVEL,@ROLE,@UOM,@MCUID,@CAUID)"
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 1)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = name => 1,
                Close = () => { }
            };

            // Act
            var result = dbaCostCategories.CreateCostCategories(dbAccess, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(e => executedCommands.Contains(e)).ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateCostCategoryFTEs_NoPEriodsOnCalendar_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedMessage = "No Periods in calendar!";
            var reply = string.Empty;
            var dataTable = new DataTable();
            ShimdbaCalendars.SelectCalendarPeriodCountDBAccessInt32DataTableOut = SelectCalendarPeriods;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 0
                    }
                }.GetEnumerator()
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryFTEs(dbAccess, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateCostCategoryFTEs_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var expectedCommands = new List<string>
            {
                @"Update EPGP_COST_BREAKDOWN_ATTRIBS SET BA_FTE_CONV=@fte" +
                " Where CB_ID=@cal And BA_BC_UID=@cc And BA_PRD_ID=@period And BA_RATETYPE_UID=0 And BA_CODE_UID=0",
                @"Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)",
                "Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)"
            };
            var executedCommands = new List<string>();
            ShimdbaCalendars.SelectCalendarPeriodCountDBAccessInt32DataTableOut = SelectCalendarPeriods;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1,
                        RowStateGet = () => DataRowState.Modified
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryFTEs(dbAccess, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(e => executedCommands.Contains(e)).ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateCostCategoryFTEs_InsertBreakdownAttributes_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var expectedCommands = new List<string>
            {
                "Update EPGP_COST_BREAKDOWN_ATTRIBS SET BA_FTE_CONV=@fte" +
                " Where CB_ID=@cal And BA_BC_UID=@cc And BA_PRD_ID=@period And BA_RATETYPE_UID=0 And BA_CODE_UID=0",
                "Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)",
                "Insert Into EPGP_COST_BREAKDOWN_ATTRIBS (CB_ID,BA_RATETYPE_UID,BA_CODE_UID,BA_BC_UID,BA_PRD_ID,BA_FTE_CONV,BA_RATE)" +
                " Values (@cal,0,0,@cc,@period,@fte,0)",
                "Delete From EPGP_COST_BREAKDOWN_ATTRIBS" +
                " Where (BA_FTE_CONV = 0 Or BA_FTE_CONV is NULL) And (BA_RATE = 0 Or BA_RATE is NULL)"
            };
            var executedCommands = new List<string>();
            ShimdbaCalendars.SelectCalendarPeriodCountDBAccessInt32DataTableOut = SelectCalendarPeriods;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            return name == "BA_BC_UID" ? 3 : 1;
                        },
                        RowStateGet = () => DataRowState.Modified
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryFTEs(dbAccess, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(e => executedCommands.Contains(e)).ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateCostCategoryFTEs_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExceptionMessage = "Dummy Exception";
            var reply = string.Empty;
            var dataTable = new DataTable();
            ShimdbaCalendars.SelectCalendarPeriodCountDBAccessInt32DataTableOut = SelectCalendarPeriods;
            ShimDataTable.AllInstances.RowsGet = _ =>
            {
                throw new Exception(ExceptionMessage);
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryFTEs(dbAccess, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExceptionMessage));
        }

        [TestMethod]
        public void UpdateCostCategoryRates_BaseRateNotSpecified_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Base Rate must be specified";
            var reply = string.Empty;
            var dataTable = new DataTable();

            // Act
            var result = dbaCostCategories.UpdateCostCategoryRates(dbAccess, 1, 0, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateCostCategoryRates_DateListWithDuplicatedValues_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ExpectedErrorMessage = "Effective dates must be specified and unique";
            var reply = string.Empty;
            var dataTableValues = new Dictionary<string, object>
            {
                ["BC_EFFECTIVE_DATE"] = DateTime.Parse("1901-01-01"),
                ["BC_RATE"] = 3
            };
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = GetItem(dataTableValues)
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryRates(dbAccess, 1, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateCostCategoryRates_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var dataTableValues = new Dictionary<string, object>
            {
                ["BC_EFFECTIVE_DATE"] = DateTime.Now,
                ["BC_RATE"] = 3
            };
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = GetItem(dataTableValues)
                        }
                    }.GetEnumerator()
                }
            };
            var expectedCommands = new List<string>
            {
                "INSERT INTO EPG_COST_CATEGORY_RATE_VALUES (BC_UID,BC_EFFECTIVE_DATE,BC_RATE)" +
                " VALUES(@pCA_UID,@pDate,@pRate)",
                "DELETE FROM EPG_COST_CATEGORY_RATE_VALUES WHERE BC_UID = @pCA_UID"
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            var result = dbaCostCategories.UpdateCostCategoryRates(dbAccess, 1, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(e => executedCommands.Contains(e)).ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateCostCategoryRates_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            const string ErrorMessage = "Dummy Exception";
            var reply = string.Empty;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => 
                {
                    throw new Exception(ErrorMessage);
                }
            };
            
            // Act
            var result = dbaCostCategories.UpdateCostCategoryRates(dbAccess, 1, 1, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ErrorMessage));
        }

        [TestMethod]
        public void SaveCostCategories_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => 1
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            var expectedCommands = new List<string>
            {
                "UPDATE EPG_ADMIN Set ADM_MC_LOOKUP=@Lookup,ADM_MC_DEFAULT=@Default",
                "INSERT INTO EPGP_CATEGORIES (CA_UID,CA_NAME,CA_ID,CA_LEVEL,CA_ROLE,CA_UOM)" +
                " VALUES(@CAUID,@CANAME,@CAID,@CALEVEL,@CAROLE,@CAUOM)"
            };
            var executedCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => 1,
                Close = () => { }
            };
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaCostCategories.CreateCostCategoriesDBAccessStringOut = CreateCostCategories;

            // Act
            var result = dbaCostCategories.SaveCostCategories(dbAccess, 2, 2, new DataTable(), out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => expectedCommands.All(p => executedCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCostCategories_CreateCostCategoriesError_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => 1
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 0
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                ItemGetString = name => 1,
                Close = () => { }
            };
            StatusEnumReturn = StatusEnum.rsServerError;
            ShimdbaCostCategories.CreateCostCategoriesDBAccessStringOut = CreateCostCategories;

            // Act
            var result = dbaCostCategories.SaveCostCategories(dbAccess, 2, 2, new DataTable(), out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty());
        }

        [TestMethod]
        public void SaveCostCategories_OnException_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            const string ErrorMessage = "Dummy Exception";
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = SelectAdmin;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(ErrorMessage);
            };

            // Act
            var result = dbaCostCategories.SaveCostCategories(dbAccess, 2, 2, new DataTable(), out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ErrorMessage));
        }

        private FakesDelegates.Func<string, object> GetItem(IDictionary<string, object> dictionary)
        {
            return name =>
            {
                object value;
                if (dictionary.TryGetValue(name, out value))
                {
                    return value;
                }
                else
                {
                    return DBNull.Value;
                };
            };
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CreateCostCategories(DBAccess db, out string reply)
        {
            reply = DummyString;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCalendarPeriods(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectAdmin(DBAccess db, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataById(
            SqlDb db, 
            string command, 
            int id, 
            StatusEnum errorStatus, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            CommandText = command;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectData(
            SqlDb db, 
            string command, 
            StatusEnum errorStatus, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            CommandText = command;
            return StatusEnumReturn;
        }
    }
}
