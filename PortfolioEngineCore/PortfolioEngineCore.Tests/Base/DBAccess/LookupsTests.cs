using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class LookupsTests
    {
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private static string ExecutedCommand = string.Empty;
        private static string CustomReply = string.Empty;


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


        private StatusEnum CanDeleteLookupSuccess(DBAccess dbAccess, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        private StatusEnum CanDeleteLookupError(DBAccess dbAccess, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsRequestCannotBeCompleted;
        }


        private StatusEnum SelectDataByIdSuccess(SqlDb dbAccess, string command, int id, StatusEnum statusErrror, out DataTable dataTable)
        {
            ExecutedCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataSuccess(SqlDb dbAccess, string command, StatusEnum statusError, out DataTable dataTable)
        {
            ExecutedCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
