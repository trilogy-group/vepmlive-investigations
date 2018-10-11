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
    public class ModelsTests
    {
        private const string DummyString = "DummyString";
        private const int DummyInt = 10;
        private static string SqlCommand = string.Empty;
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
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.AllInstances.ConnectionGet = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction();
            ShimSqlTransaction.AllInstances.Commit = _ => { };
        }
             
        [TestMethod]
        public void UpdateModelInfo_ModelNameEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var modelId = 1;
            var reply = string.Empty;
            var tableVersions = new DataTable();
            const string ExpectedErrorMessage = "Please enter a Model Name";

            // Act
            var result = dbaModels.UpdateModelInfo(
                dbAccess, 
                ref modelId, 
                string.Empty, 
                DummyString, 
                1, 
                1, 
                DummyString, 
                tableVersions, 
                out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedErrorMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_ModelAlreadyExists_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var modelId = 2;
            var reply = string.Empty;
            var tableVersions = new DataTable();
            var expectedErrorMessage = $"Model with name '{DummyString}' already exists";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };

            // Act
            var result = dbaModels.UpdateModelInfo(
                dbAccess, 
                ref modelId, 
                DummyString, 
                DummyString, 
                1, 
                1, 
                DummyString, 
                tableVersions, 
                out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_AddModel_ReturnsStatusSuccess()
        {
            // Arrange
            var modelId = 0;
            var reply = string.Empty;
            var tableVersions = new DataTable();
            const string ExpectedSqlCommand = "INSERT Into EPGP_MODEL_SCENARIOS (MODEL_NAME,MODEL_DESC,MODEL_CB_ID,MODEL_SELECTED_FIELD_ID)"
                       + " Values(@pMODEL_NAME, @pMODEL_DESC,@pCB_ID,@pCF)";
            var sqlCommand = string.Empty;
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimSqlDb.ReadIntValueObject = _ => modelId;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommand = command.CommandText;
                return 1;
            };
            ShimSqlDb.AllInstances.GetLastIdentityValueInt32Out = GetLastIdentityValue;

            // Act
            var result = dbaModels.UpdateModelInfo(
                dbAccess, 
                ref modelId, 
                DummyString, 
                DummyString, 
                1, 
                1, 
                DummyString, 
                tableVersions, 
                out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => sqlCommand.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void UpdateModelInfo_UpdateModel_ReturnsStatusSucces()
        {
            // Arrange
            var modelId = 1;
            var reply = string.Empty;
            var tableVersions = new DataTable();
            var expectedSqlCommands = new List<string>
            {
                "INSERT INTO EPGP_MODEL_GROUP_SECURITY (MODEL_UID,MODEL_VERSION_UID,GROUP_ID,VIEW_PERMISSION, EDIT_PERMISSION)" +
                                "VALUES(@pMODEL_UID,@pGroupVERSION_UID,@pGroupID,@pReadPermission,@pEditPermission)",
                "INSERT INTO EPGP_MODEL_VERSIONS (MODEL_UID,MODEL_VERSION_UID,MODEL_VERSION_NAME,MODEL_VERSION_DESC)  VALUES(@pMODEL_UID,@pVERSION_UID,@pName,@pDesc)",
                "DELETE FROM EPGP_MODEL_VERSIONS WHERE MODEL_UID = @pMODEL_UID",
                "DELETE FROM EPGP_MODEL_GROUP_SECURITY WHERE MODEL_UID = @pMODEL_UID",
                "INSERT INTO EPGP_MODEL_CTS (MODEL_UID,MODEL_CT_ID)  VALUES(@pMODEL_UID,@pCT_ID)",
                "DELETE FROM EPGP_MODEL_CTS WHERE MODEL_UID = @pMODEL_UID"
            };
            var sqlCommands = new List<string>();
            const string CostTypes = "1,2";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameError;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyInt
                    }
                }.GetEnumerator()
            };
            ShimSqlDb.ReadIntValueObject = _ => 0;
            ShimSqlDb.ReadStringValueObject = _ => $"1::Admin::1::1";
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlDb.AllInstances.GetLastIdentityValueInt32Out = GetLastIdentityValue;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
            };

            // Act
            var result = dbaModels.UpdateModelInfo(
                dbAccess, 
                ref modelId,
                DummyString, 
                DummyString, 
                1,
                1,
                CostTypes, 
                tableVersions, 
                out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNull(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateModelInfo_OnException_ReturnsStatusRequestCannotBeCompleted()
        {
            // Arrange
            var modelId = 1;
            var reply = string.Empty;
            var tableVersions = new DataTable();
            const string CostTypes = "1,2";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaModels.UpdateModelInfo(
                dbAccess,
                ref modelId,
                DummyString,
                DummyString,
                1,
                1,
                CostTypes,
                tableVersions,
                out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNull(),
                () => reply.ShouldContain(DummyString));
        }

        [TestMethod]
        public void DeleteModel_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            const string ExpectedCommand = "EPG_SP_DeleteModel";
            var commandText = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                commandText = command.CommandText;
                return 1;
            };

            // Act
            var result = dbaModels.DeleteModel(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => commandText.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void DeleteModel_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaModels.DeleteModel(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(DummyString));
        }

        [TestMethod]
        public void SelectModelVersions_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            const string ExpectedSqlCommand = "select mv.MODEL_UID, mv.MODEL_VERSION_UID, mv.MODEL_VERSION_NAME, mv.MODEL_VERSION_DESC, mgs.GROUP_ID, g.GROUP_NAME, mgs.VIEW_PERMISSION, mgs.EDIT_PERMISSION"
            + " from EPGP_MODEL_VERSIONS mv"
            + " left join EPGP_MODEL_GROUP_SECURITY mgs on mgs.MODEL_UID = mv.MODEL_UID and mgs.MODEL_VERSION_UID = mv.MODEL_VERSION_UID"
            + " left join EPG_GROUPS g on g.GROUP_ID = mgs.GROUP_ID"
            + " where mv.MODEL_UID = @p1"
            + " order by MODEL_VERSION_NAME";

            // Act
            var result = dbaModels.SelectModelVersions(dbAccess, DummyInt, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => SqlCommand.ShouldBe(ExpectedSqlCommand),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCustomFieldsFlags_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            const string ExpectedSqlCommand = "SELECT * FROM EPGC_FIELD_ATTRIBS WHERE FA_FORMAT=13 AND FA_TABLE_ID=201 ORDER BY FA_NAME";

            // Act
            var result = dbaModels.SelectCustomFields_Flags(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => SqlCommand.ShouldBe(ExpectedSqlCommand),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectCostTypesForModel_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            const string ExpectedSqlCommand = "SELECT ct.CT_ID, CT_NAME,"
            + " case When (cvct.MODEL_CT_ID is null) Then 0 Else 1 End as used"
            + " FROM EPGP_COST_TYPES ct"
            + " LEFT JOIN  EPGP_MODEL_CTS cvct ON (cvct.MODEL_CT_ID = ct.CT_ID AND MODEL_UID = @p1)"
            + " WHERE CT_EDIT_MODE Not In (3,30) ORDER BY CT_NAME";

            // Act
            var result = dbaModels.SelectCostTypesForModel(dbAccess,DummyInt, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => SqlCommand.ShouldBe(ExpectedSqlCommand),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectModel_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            const string ExpectedSqlCommand = "SELECT * FROM EPGP_MODEL_SCENARIOS WHERE MODEL_UID = @p1";

            // Act
            var result = dbaModels.SelectModel(dbAccess, DummyInt, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => SqlCommand.ShouldBe(ExpectedSqlCommand),
                () => dataTable.ShouldNotBeNull());
        }

        [TestMethod]
        public void SelectModels_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            const string ExpectedSqlCommand = "SELECT * FROM EPGP_MODEL_SCENARIOS ORDER BY MODEL_NAME";

            // Act
            var result = dbaModels.SelectModels(dbAccess,  out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => SqlCommand.ShouldBe(ExpectedSqlCommand),
                () => dataTable.ShouldNotBeNull());
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSuccess(SqlDb db, string command, StatusEnum statusEnum, out DataTable dataTable)
        {
            SqlCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByIdSuccess(
            SqlDb db,
            string command,
            int id,
            StatusEnum statusEnum, 
            out DataTable dataTable)
        {
            SqlCommand = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool GetLastIdentityValue(SqlDb db, out int lookupId)
        {
            lookupId = 0;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameError
            (SqlDb db, 
            string commandText, 
            string name,
            StatusEnum statusEnum,
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameSuccess(
            SqlDb db, 
            string commandText, 
            string name, 
            StatusEnum statusEnum, 
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
