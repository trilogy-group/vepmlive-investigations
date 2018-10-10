using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class AdminPagesdbaCustomFieldsTests
    {
        private const string DummyString = "DummyString";
        private const string GetCFFieldNameMethodName = "GetCFFieldName";
        private static string CustomReply = string.Empty;
        private static string CommandText = string.Empty;
        private static int RowsAffected = 0;
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            dbAccess = new ShimDBAccess().Instance;
            privateType = new PrivateType(typeof(dbaCustomFields));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void SelectCustomFields_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_DESC,"
                            + " case When (FA_TABLE_ID >100 And FA_TABLE_ID<200) Then 1 When (FA_TABLE_ID >200 And FA_TABLE_ID<300) Then 2 Else 0 End as Entity"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " Where FA_TABLE_ID > 100 and FA_TABLE_ID < 300"
                            + " ORDER BY Entity,FA_NAME";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.SelectCustomFields(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectPortfolioFormulaCustomFields_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT FA_FIELD_ID,FA_NAME"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " WHERE FA_TABLE_ID > 200 AND FA_TABLE_ID < 300 AND (FA_FORMAT = 3 OR FA_FORMAT = 8 OR FA_FORMAT = 9)"
                            + " ORDER BY FA_NAME";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.SelectPortfolioFormulaCustomFields(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectCustomField_FieldIdGreaterThanZero_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_DESC,"
                                + " case When (FA_TABLE_ID >100 And FA_TABLE_ID<200) Then 1 When (FA_TABLE_ID >200 And FA_TABLE_ID<300) Then 2 Else 0 End as Entity"
                                + " FROM EPGC_FIELD_ATTRIBS"
                                + " Where FA_TABLE_ID > 100 and FA_TABLE_ID < 300 AND FA_FIELD_ID=@p1"
                                + " ORDER BY Entity,FA_NAME";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCustomFields.SelectCustomField(dbAccess, 1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectCustomField_FieldIdZero_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT FA_FIELD_ID=0,FA_NAME='New Custom Field',FA_FORMAT=9,FA_TABLE_ID=0,FA_FIELD_IN_TABLE=0,FA_DESC='',Entity=2";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.SelectCustomField(dbAccess, 0, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectRPTotalHoursCustomFieldCandidates_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT FA_FIELD_ID,FA_NAME,FA_DESC"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " Where FA_TABLE_ID = 203 And FA_FORMAT=3"
                            + " ORDER BY FA_NAME";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.SelectRPTotalHoursCustomFieldCandidates(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectRoles_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT LV_UID, LV_VALUE "
                            + " FROM EPGP_LOOKUP_VALUES"
                            + " WHERE LOOKUP_UID = (SELECT ADM_ROLE_CODE FROM EPG_ADMIN)"
                            + " ORDER BY LV_ID";
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.SelectRoles(dbAccess, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void SelectCustomFieldFormula_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var dataTable = new DataTable();
            dataTable = null;
            const string ExpectedSqlCommand = "SELECT CL_UID,CL_SEQ,CL_RESULT,CL_COMPONENT,CL_RATIO,CL_OP,CL_PRI,f1.FA_NAME as ResultName,f2.FA_NAME as ComponentName"
                + " FROM EPGP_CALCS c "
                + " Join EPGC_FIELD_ATTRIBS f1 On c.CL_RESULT=f1.FA_FIELD_ID"
                + " Left Join EPGC_FIELD_ATTRIBS f2 On c.CL_COMPONENT=f2.FA_FIELD_ID"
                + " Where CL_OBJECT=1 AND CL_RESULT=@p1"
                + " Order By CL_UID,CL_SEQ";
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;

            // Act
            var result = dbaCustomFields.SelectCustomFieldFormula(dbAccess, 1, out dataTable);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => dataTable.ShouldNotBeNull(),
                () => CommandText.ShouldBe(ExpectedSqlCommand));
        }

        [TestMethod]
        public void DeleteCustomFieldFormula_OnSuccess_ShouldReturnStatusSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            const string ExpectedSqlCommand = "DELETE EPGP_CALCS WHERE CL_OBJECT=1 AND CL_RESULT=@p1";
            ShimSqlDb.AllInstances.DeleteDataByIdStringInt32StatusEnumInt32Out = DeleteDataByIdSuccess;
            RowsAffected = 1;

            // Act
            var result = dbaCustomFields.DeleteCustomFieldFormula(dbAccess, 1, out rowsAffected);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => CommandText.ShouldBe(ExpectedSqlCommand),
                () => rowsAffected.ShouldBe(RowsAffected));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceINT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceINT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_INT_VALUES";
            var expectedFieldValue = $"RI_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_TEXT_VALUES";
            var expectedFieldValue = $"RT_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceDEC_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceDEC;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_DEC_VALUES";
            var expectedFieldValue = $"RC_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceNTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceNTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_NTEXT_VALUES";
            var expectedFieldValue = $"RN_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceDATE_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceDATE;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_DATE_VALUES";
            var expectedFieldValue = $"RD_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypePortfolioDATE_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.PortfolioDATE;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PROJECT_DATE_VALUES";
            var expectedFieldValue = $"PD_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeResourceMV_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ResourceMV;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGC_RESOURCE_MV_VALUES";
            const string ExpectedFieldValue = "MVR_UID";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(ExpectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypePortfolioINT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.PortfolioINT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PROJECT_INT_VALUES";
            var expectedFieldValue = $"PI_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypePortfolioTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.PortfolioTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PROJECT_TEXT_VALUES";
            var expectedFieldValue = $"PT_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypePortfolioDEC_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.PortfolioDEC;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PROJECT_DEC_VALUES";
            var expectedFieldValue = $"PC_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypePortfolioNTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.PortfolioNTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PROJECT_NTEXT_VALUES";
            var expectedFieldValue = $"PN_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProgram_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.Program;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PI_PROGS";
            const string ExpectedFieldValue = "PROG_UID";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(ExpectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProjectINT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProjectINT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGX_PROJ_INT_VALUES";
            var expectedFieldValue = $"XI_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProjectTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProjectTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGX_PROJ_TEXT_VALUES";
            var expectedFieldValue = $"XT_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProjectDEC_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProjectDEC;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGX_PROJ_DEC_VALUES";
            var expectedFieldValue = $"XC_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProjectNTEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProjectNTEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGX_PROJ_NTEXT_VALUES";
            var expectedFieldValue = $"XN_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProjectDATE_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProjectDATE;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGX_PROJ_DATE_VALUES";
            var expectedFieldValue = $"XD_{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeProgramText_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.ProgramText;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PI_PROGS";
            var expectedFieldValue = $"PROG_PI_TEXT{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeTaskWIINT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.TaskWIINT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PI_WORKITEMS";
            var expectedFieldValue = $"WORKITEM_FLAG{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeTaskWITEXT_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.TaskWITEXT;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PI_WORKITEMS";
            var expectedFieldValue = $"WORKITEM_CTEXT{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeTaskWIDEC_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.TaskWIDEC;
            const int FieldId = TableId;
            const string ExpectedTableValue = "EPGP_PI_WORKITEMS";
            var expectedFieldValue = $"WORKITEM_NUMBER{FieldId.ToString("000")}";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNullOrEmpty(),
                () => field.ShouldBe(expectedFieldValue));
        }

        [TestMethod]
        public void GetCFFieldName_FieldTypeUnkwonValue_ExecutesCorrectly()
        {
            // Arrange
            const int TableId = (int)CustomFieldDBTable.Unknown;
            const int FieldId = TableId;
            const string ExpectedTableValue = "Unknown Table";
            var table = string.Empty;
            var field = string.Empty;
            var args = new object[] { TableId, FieldId, table, field };

            // Act
            privateType.InvokeStatic(GetCFFieldNameMethodName, args);
            table = args[2] as string;
            field = args[3] as string;

            // Assert
            privateType.ShouldSatisfyAllConditions(
                () => table.ShouldNotBeNullOrEmpty(),
                () => table.ShouldBe(ExpectedTableValue),
                () => field.ShouldNotBeNull(),
                () => field.ShouldBeEmpty());
        }

        [TestMethod]
        public void GetCustomFieldNameFromID_OnSuccess_ReturnsExpectedValues()
        {
            // Arrange
            const string ExpectedTableName = "EPGC_RESOURCE_INT_VALUES";
            const string ExpectedFieldName = "RI_101";
            var tableName = string.Empty;
            var fieldName = string.Empty;
            ShimSqlDb.ReadIntValueObject = _ => (int)CustomFieldDBTable.ResourceINT;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => "Dummmy"
            };

            // Act
            var result = dbaCustomFields.GetCustomFieldNameFromID(dbAccess, 1, out tableName, out fieldName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => tableName.ShouldBe(ExpectedTableName),
                () => fieldName.ShouldBe(ExpectedFieldName));
        }

        [TestMethod]
        public void GetCustomFieldNameFromID_OnException_ReturnsExpectedValues()
        {
            // Arrange
            var tableName = string.Empty;
            var fieldName = string.Empty;
            ShimSqlDb.ReadIntValueObject = _ => (int)CustomFieldDBTable.ResourceINT;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean =
                (_, function, status, exception, skipLog) => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = dbaCustomFields.GetCustomFieldNameFromID(dbAccess, 1, out tableName, out fieldName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => tableName.ShouldBeEmpty(),
                () => fieldName.ShouldBeEmpty());
        }

        [TestMethod]
        public void CanDeleteCustomField_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var expectedValue = $"{DummyString}: {DummyString}\n";
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name => DummyString
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;

            // Act
            var result = dbaCustomFields.CanDeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => reply.ShouldBe(expectedValue),
                () => result.ShouldBe(StatusEnum.rsSuccess));
        }

        [TestMethod]
        public void CanDeleteCustomField_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var expectedValue = $"<message>{DummyString}</message>";
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception(DummyString);
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;

            // Act
            var result = dbaCustomFields.CanDeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => reply.ShouldNotBeEmpty(),
                () => reply.ShouldContain(expectedValue),
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted));
        }

        [TestMethod]
        public void DeleteCustomField_CanDeleteCustomFieldError_ReturnsStatusError()
        {
            // Arrange
            var reply = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception(DummyString);
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldError;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsRequestCannotBeCompleted;

            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted));
        }

        [TestMethod]
        public void DeleteCustomField_CustomFieldCurrentlyUsed_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            const string ExpectedMessage = "This Custom Field cannot be deleted, it is currently used as follows";
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception(DummyString);
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            CustomReply = DummyString;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;

            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void DeleteCustomField_DataTableRowsEmpty_ReturnsRequestCannotBeCompletedr()
        {
            // Arrange
            var reply = string.Empty;
            const string ExpectedMessage = "Can't delete field, field not found";
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception(DummyString);
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            CustomReply = string.Empty;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0
            };

            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void DeleteCustomField_FieldTablePortfolioINT_ExecutesCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var expectedSqlCommands = new List<string>
            {
                $"Update {DummyString} Set {DummyString}=NULL",
                "DELETE FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=@pField",
                "DELETE FROM EPGP_CALCS Where CL_RESULT=@pField1 Or CL_COMPONENT=@pField2"
            };
            var sqlCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => 201;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            CustomReply = string.Empty;
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = GetTableAndFieldTrue;
            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteCustomField_FieldTableResourceINT_ExecutesCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var expectedSqlCommands = new List<string>
            {
                $"Update {DummyString} Set {DummyString}=NULL",
                "DELETE FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=@pField",
                "DELETE FROM EPGP_CALCS Where CL_RESULT=@pField1 Or CL_COMPONENT=@pField2"
            };
            var sqlCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => (int)CustomFieldTable.ResourceINT;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            CustomReply = string.Empty;
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = GetTableAndFieldTrue;
            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteCustomField_FieldTableResourceMV_ExecutesCorrectly()
        {
            // Arrange
            var reply = string.Empty;
            var expectedSqlCommands = new List<string>
            {
                "Delete From EPGC_RESOURCE_MV_VALUES Where MVR_FIELD_ID=@pField",
                "DELETE FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=@pField",
                "DELETE FROM EPGP_CALCS Where CL_RESULT=@pField1 Or CL_COMPONENT=@pField2"
            };
            var sqlCommands = new List<string>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommands.Add(command.CommandText);
                return 1;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => (int)CustomFieldTable.ResourceMV;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            CustomReply = string.Empty;
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = GetTableAndFieldTrue;
            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => sqlCommands.ShouldNotBeEmpty(),
                () => expectedSqlCommands.All(p => sqlCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteCustomField_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var expectedMessage = $"<message>{DummyString}</message>";
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                throw new Exception(DummyString);
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => (int)CustomFieldTable.ResourceMV;
            ShimdbaCustomFields.CanDeleteCustomFieldDBAccessInt32StringOut = CanDeleteCustomFieldSuccess;
            ShimSqlDb.AllInstances.SelectDataByIdStringInt32StatusEnumDataTableOut = SelectDataByIdSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            CustomReply = string.Empty;
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = GetTableAndFieldTrue;

            // Act
            var result = dbaCustomFields.DeleteCustomField(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeEmpty(),
                () => reply.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void UpdateCustomFieldInfo_FieldNameEmpty_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var fieldId = 1;
            const string ExpectedMessage = "<message>Please enter a Field Name</message>";

            // Act
            var result = dbaCustomFields.UpdateCustomFieldInfo(dbAccess, 1, 1, ref fieldId, string.Empty, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateCustomFieldInfo_FieldAlreadyExists_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var fieldId = 3;
            var ExpectedMessage = $"A field with name '{DummyString}' already exists";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimSqlDb.ReadIntValueObject = _ => 1;

            // Act
            var result = dbaCustomFields.UpdateCustomFieldInfo(dbAccess, 1, 1, ref fieldId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void UpdateCustomFieldInfo_UpdateField_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var fieldId = 1;
            const string ExpectedCommand = "UPDATE EPGC_FIELD_ATTRIBS "
                        + " SET FA_NAME=@pNAME,FA_DESC=@pDESC"
                        + " WHERE FA_FIELD_ID = @pFIELDID";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                CommandText = command.CommandText;
                return 1;
            };

            // Act
            var result = dbaCustomFields.UpdateCustomFieldInfo(dbAccess, 1, 1, ref fieldId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => CommandText.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void UpdateCustomFieldInfo_AddField_ReturnsStatusSuccess()
        {
            // Arrange
            var reply = string.Empty;
            var fieldId = 0;
            const string ExpectedCommand = "INSERT Into EPGC_FIELD_ATTRIBS " + 
                " (FA_NAME,FA_DESC,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE)" + 
                " Values(@pNAME,@pDESC,@pFORMAT,@pTABLE,@pFIELD)";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimDataTable.AllInstances.ColumnsGet = _ => 
            {
                var list = new List<DataColumn>
                {
                    new ShimDataColumn
                    {
                        ColumnNameGet = () => "Dum1"
                    }
                };
                return new ShimDataColumnCollection().Bind(list);
            };
            ShimSqlDb.ReadIntValueObject = _ => 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                CommandText = command.CommandText;
                return 1;
            };
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name => DummyString,
                Close = () => { }
            };
            ShimEPKClass01.GetTableIDInt32Int32 = (entity, fieldType) => 1;
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = GetTableAndFieldTrue;
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;

            // Act
            var result = dbaCustomFields.UpdateCustomFieldInfo(dbAccess, 1, 1, ref fieldId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldBeNullOrEmpty(),
                () => CommandText.ShouldBe(ExpectedCommand));
        }

        [TestMethod]
        public void UpdateCustomFieldInfo_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var reply = string.Empty;
            var fieldId = 0;
            var expectedMessage = $"<message>{DummyString}</message>";
            ShimSqlDb.AllInstances.SelectDataByNameStringStringStatusEnumDataTableOut = SelectDataByNameSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(DummyString);
            };

            // Act
            var result = dbaCustomFields.UpdateCustomFieldInfo(dbAccess, 1, 1, ref fieldId, DummyString, DummyString, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldNotBeNullOrEmpty(),
                () => reply.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void ValidateAndSaveCustomFieldFormula_WithValidaFormula_ReturnsEmptyValue()
        {
            // Arrange
            var formula = "1+2-9*8/9+3.14";
            ShimdbaCustomFields.SelectPortfolioFormulaCustomFieldsDBAccessDataTableOut = SelectPortfoilioSuccess;

            // Act
            var result = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dbAccess, 1, ref formula);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void ValidateAndSaveCustomFieldFormula_TooManyOperators()
        {
            // Arrange
            var formula = "1++2";
            const string ExpectedMessage = "Too many operators";
            ShimdbaCustomFields.SelectPortfolioFormulaCustomFieldsDBAccessDataTableOut = SelectPortfoilioSuccess;

            // Act
            var result = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dbAccess, 1, ref formula);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldContain(ExpectedMessage);
        }

        [TestMethod]
        public void ValidateAndSaveCustomFieldFormula_UnknownFieldName_()
        {
            // Arrange
            var formula = "1.6.3+9";
            const string ExpectedMessage = "Unknown custom field name";
            ShimdbaCustomFields.SelectPortfolioFormulaCustomFieldsDBAccessDataTableOut = SelectPortfoilioSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow()
                    {
                        ItemGetString = name => DummyString
                    }

                }.GetEnumerator()
            };

            // Act
            var result = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dbAccess, 1, ref formula);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.ShouldContain(ExpectedMessage);
        }

        [TestMethod]
        public void ValidateAndSaveCustomFieldFormula_SaveFormula_ExecutesCorrectly()
        {
            // Arrange
            const string Field = "1.6.3";
            var formula = $"{Field}+{Field}*{Field}/{Field}-6";
            const string ExpectedCommand = "INSERT INTO  EPGP_CALCS (CL_OBJECT, CL_PRI, CL_OP, CL_UID, CL_SEQ, CL_RESULT, CL_COMPONENT, CL_RATIO) " +
                            "VALUES(1, 0, @CL_OP, @CL_UID, @CL_SEQ, @CL_RESULT, @CL_COMPONENT, @CL_RATIO)";
            ShimdbaCustomFields.SelectPortfolioFormulaCustomFieldsDBAccessDataTableOut = SelectPortfoilioSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => Field,
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow()
                    {
                        ItemGetString = name => Field,
                    }
                }.GetEnumerator()
            };
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            ShimSqlDb.AllInstances.DeleteDataByIdStringInt32StatusEnumInt32Out = DeleteDataByIdSuccess;
            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                CommandText = command.CommandText;
                return 1;
            };

            // Act
            var result = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dbAccess, 2, ref formula, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrEmpty(),
                () => CommandText.ShouldBe(ExpectedCommand));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectPortfoilioSuccess(DBAccess arg1, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool GetTableAndFieldTrue(int table, int field, out string tableName, out string fieldName)
        {
            tableName = DummyString;
            fieldName = DummyString;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteCustomFieldError(DBAccess db, int id, out string reply)
        {
            reply = DummyString;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CanDeleteCustomFieldSuccess(DBAccess db, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByNameSuccess(
            SqlDb db,
            string command,
            string name,
            StatusEnum statusError,
            out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteDataByIdSuccess(
            SqlDb dbc, 
            string command, 
            int id, 
            StatusEnum statusError, 
            out int rowsAffected)
        {
            CommandText = command;
            rowsAffected = RowsAffected;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataByIdSuccess(
            SqlDb db, 
            string command, 
            int id, 
            StatusEnum statusError, 
            out DataTable dataTable)
        {
            CommandText = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectDataSuccess(
            SqlDb db,
            string command, 
            StatusEnum statusError, 
            out DataTable dataTable)
        {
            CommandText = command;
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
