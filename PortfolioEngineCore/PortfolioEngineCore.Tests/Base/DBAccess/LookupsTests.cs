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
    public class LookupsTests
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const string LookupId = "LV_UID";
        private const string LookupLevel = "LV_LEVEL";
        private const string LookupInactive = "LV_INACTIVE";
        private const string LookupValue = "LV_VALUE";
        private static string ExecutedCommand = string.Empty;
        private static string CustomReply = string.Empty;
        private IDisposable shimsContext;
        private DBAccess dbAccess;

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
            ShimSqlDb.ReadStringValueObject = objectValue => objectValue == null
                                                                ? string.Empty
                                                                : objectValue.ToString();
            ShimSqlDb.AllInstances.ConnectionGet = _ => new SqlConnection();
            ShimSqlDb.ReadIntValueObject = objectValue =>
            {
                if (objectValue is int)
                {
                    return Convert.ToInt32(objectValue);
                }
                else
                {
                    return DummyInt;
                }
            };
            ShimSqlDb.AllInstances.ConnectionGet = _ => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction();
            ShimSqlTransaction.AllInstances.Commit = _ => { };
            ShimDataTable.AllInstances.LoadIDataReader = (_, reader) => { };
        }

        [TestMethod]
        public void SelectLookups_onSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var expectedCommand = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES"
                            + " WHERE LOOKUP_UID <> (SELECT ADM_RPE_DEPT_CODE FROM EPG_ADMIN)"
                            + " AND LOOKUP_UID <> (SELECT ADM_ROLE_CODE FROM EPG_ADMIN)"
                            + " ORDER BY LOOKUP_NAME";
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaLookups.SelectLookups(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => ExecutedCommand.ShouldBe(expectedCommand));
        }

        [TestMethod]
        public void SelectLookup_onSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            const string ExpectedCommand = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES WHERE LOOKUP_UID = @p1";
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaLookups.SelectLookup(dbAccess, DummyInt, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => ExecutedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void SelectLookupValues_onSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            const string ExpectedCommand = "SELECT LV_UID, LV_VALUE, LV_LEVEL, LV_INACTIVE FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            var dataTable = new DataTable();
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaLookups.SelectLookupValues(dbAccess, DummyInt, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => ExecutedCommand.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void DeleteLookup_CanDeleteLookupError_ReturnsDbaStatus()
        {
            // Arrange
            var dataTable = new DataTable();
            var reply = string.Empty;
            ShimdbaLookups.CanDeleteLookupDBAccessInt32StringOut = CanDeleteLookupError;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = dbaLookups.DeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void DeleteLookup_LookupBeenUsed_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var expectedErrorMessage = $"This Lookup cannot be deleted, it is currently used as follows:\n\n{DummyString}";
            var dataTable = new DataTable();
            var reply = string.Empty;
            CustomReply = DummyString;
            ShimdbaLookups.CanDeleteLookupDBAccessInt32StringOut = CanDeleteLookupSuccess;

            // Act
            var result = dbaLookups.DeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void DeleteLookup_OnSuccess_ReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            var reply = string.Empty;
            CustomReply = string.Empty;
            var expectedSqlCommands = new List<string>
            {
                "DELETE FROM EPGP_LOOKUP_VALUES Where LOOKUP_UID = @pLOOKUP_UID",
                "DELETE FROM EPGP_LOOKUP_TABLES Where LOOKUP_UID = @pLOOKUP_UID"
            };
            var sqlCommands = new List<string>();
            ShimdbaLookups.CanDeleteLookupDBAccessInt32StringOut = CanDeleteLookupSuccess;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };

            // Act
            var result = dbaLookups.DeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteLookup_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var dataTable = new DataTable();
            var reply = string.Empty;
            CustomReply = string.Empty;
            ShimdbaLookups.CanDeleteLookupDBAccessInt32StringOut = CanDeleteLookupSuccess;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaLookups.DeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(DummyString));
        }

        [TestMethod]
        public void CanDeleteLookup_OnSuccess_ReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            var reply = string.Empty;
            var count = 0;
            var expectedContent = $"{DummyString}:  {DummyString}\n";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name => DummyString
            };

            // Act
            var result = dbaLookups.CanDeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookup_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var dataTable = new DataTable();
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaLookups.CanDeleteLookup(dbAccess, DummyInt, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(DummyString));
        }

        [TestMethod]
        public void CanDeleteLookupItems_CFieldId9105_ShouldReturnExpectedContent()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var count = 1;
            var expectedContent = $"Timesheet  {DummyString}  {DummyString}:  {DummyString}";
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
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = _ => 9105;

            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookupItems_CFieldId9305_ShouldReturnExpectedContent()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var count = 1;
            var expectedContent = $"Resource Plan  {DummyString}:  {DummyString}";
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
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = _ => 9305;

            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookupItems_CFieldId11801_ShouldReturnExpectedContent()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var count = 1;
            var expectedContent = $"PI Cost Value  {DummyString}  {DummyString}";
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
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadIntValueObject = _ => 11801;

            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookupItems_CFieldId20001AndCFTableResourceINT_ShouldReturnExpectedContent()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var count = 1;
            var expectedContent = $"Resource  {DummyString}:  {DummyString}";
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
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case "Field_ID":
                            return 20001;
                        case "Table_ID":
                            return 101;
                        default:
                            return DummyString;
                    }
                }
            };

            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookupItems_CFieldId20001AndCFTablePortfolioINT_ShouldReturnExpectedContent()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var count = 1;
            var expectedContent = $"Program Data  {DummyString}:  {DummyString}";
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
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case "Field_ID":
                            return 20001;
                        case "Table_ID":
                            return 201;
                        default:
                            return DummyString;
                    }
                }
            };


            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void CanDeleteLookupItems_OnException_ReturnExpectedMessage()
        {
            // Arrange
            const string LvuIds = "1";
            var reply = string.Empty;
            var expectedContent = $"<message>{DummyString}</message>";
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaLookups.CanDeleteLookupItems(dbAccess, LvuIds, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContainWithoutWhitespace(expectedContent));
        }

        [TestMethod]
        public void UpdateLookupInfo_NameEmpty_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 1;
            const string ExpectedMessage = "Please enter a Lookup Name";

            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, string.Empty, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateLookupInfo_LookupAlreadyExists_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 2;
            var expectedMessage = $"Can't save Lookup.\nA Lookup with name '{DummyString}' already exists";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = i => new ShimDataRow
                {
                    ItemGetString = name => DummyInt
                }
            };

            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, DummyString, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void UpdateLookupInfo_DuplicateValue_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 2;
            var expectedMessage = $"Can't save Lookup.\nDuplicate value not allowed: {DummyString}";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(0, 1, 0, DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(1, 1, 0, DummyString)
                    }

                }.GetEnumerator()
            };

            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, DummyString, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void UpdateLookupInfo_LookupIdZero_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 0;
            const string ExpectedMessage = "<message></message>";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(0, 5, 0, DummyString)
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(1, 4, 0, "Dummy")
                    }

                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlDb.AllInstances.GetLastIdentityValueInt32Out = GetLastIdentityValue;

            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, DummyString, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateLookupInfo_LookupIdGreaterThanZero_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 2;
            const string ExpectedMessage = "<message></message>";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(0, 5, 0, DummyString),
                        RowStateGet = () => DataRowState.Modified
                    },
                    new ShimDataRow
                    {
                        ItemGetString = GetLookupItemValues(1, 4, 0, "Dummy"),
                        RowStateGet = () => DataRowState.Deleted
                    }
                }.GetEnumerator()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true
            };

            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, DummyString, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateLookupInfo_OnException_ReturnsExpectedValue()
        {
            // Arrange
            var reply = string.Empty;
            var dataTable = new DataTable();
            var lookupId = 2;
            var expectedMessage = $"<message>{DummyString}</message>";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(DummyString);
            };
            
            // Act
            var result = dbaLookups.UpdateLookupInfo(dbAccess, ref lookupId, DummyString, DummyString, dataTable, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedMessage));
        }

        private FakesDelegates.Func<string, object> GetLookupItemValues(int id, int level, int inactive, string value)
        {
            return name =>
            {
                switch (name)
                {
                    case LookupId:
                        return id;
                    case LookupLevel:
                        return level;
                    case LookupInactive:
                        return inactive;
                    case LookupValue:
                        return value;
                    default:
                        return DummyString;
                }
            };
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool GetLastIdentityValue(SqlDb dbAccess, out int lookupId)
        {
            lookupId = 0;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameSuccess(
            SqlDb db, 
            string command, 
            string name, 
            StatusEnum enumError, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameError(
            SqlDb db, 
            string command, 
            string name, 
            StatusEnum enumError, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteLookupSuccess(DBAccess dbAccess, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteLookupError(DBAccess dbAccess, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByIdSuccess(
            SqlDb dbAccess,
            string command,
            int id,
            StatusEnum statusErrror,
            out DataTable dataTable)
        {
            ExecutedCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSuccess(
            SqlDb dbAccess,
            string command,
            StatusEnum statusError,
            out DataTable dataTable)
        {
            ExecutedCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
