using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class DBCommonTests
    {
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private const string DummyString = "DummyString";
        private const string CopyRSToRPFieldDefinition = "CopyRSToRPFieldDefinition";
        private static Dictionary<string, CStruct> StructDictionary;

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
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean =
                (_, function, status, exception, log) => StatusEnum.rsRequestCannotBeCompleted;
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, function, enumStatus, text, log) => StatusEnum.rsRequestCannotBeCompleted;
        }

        [TestMethod]
        public void ReadUserInfo_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            const string InfData = "UINF_DATA";
            var data = 0;
            var xml = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name =>
                {
                    return name == InfData ? 1.ToString() : DummyString;
                }
            };

            // Act
            var result = DBCommon.ReadUserInfo(dbAccess, 1, UserInfoContextsEnum.siEVEditorPISettings, out data, out xml);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => data.ShouldBe(1),
                () => xml.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ReadSystemInfo_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var xml = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };

            // Act
            var result = DBCommon.ReadSystemInfo(dbAccess, 1, UserInfoContextsEnum.siEVEditorPISettings, out xml);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => xml.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetUserButtonsStruct_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            const string BtnPage = "BTN_PAGE";
            var userButtons = new CStruct();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    return name == BtnPage ? 1.ToString() : DummyString;
                }
            };
            // Act
            var result = DBCommon.GetUserButtonsStruct(dbAccess, DummyString, out userButtons);
            var subStruct = userButtons.GetSubStruct("USRBUT");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => subStruct.ShouldNotBeNull(),
                () => subStruct.GetIntAttr("PageID").ShouldNotBeNull(),
                () => subStruct.GetIntAttr("PageID").ShouldBe(1),
                () => subStruct.GetString("Key").ShouldNotBeNullOrEmpty(),
                () => subStruct.GetString("Key").ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetUserButtonsStruct_OnException_ReturnsStatusError()
        {
            // Arrange
            var userButtons = new CStruct();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            };
            // Act
            var result = DBCommon.GetUserButtonsStruct(dbAccess, DummyString, out userButtons);
            var subStruct = userButtons.GetSubStruct("USRBUT");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted));
        }

        [TestMethod]
        public void ReadPlanViewFields_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var fields = new List<CTSFieldDefinition>();
            fields = null;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
            };
            ShimDBCommon.CopyRSToRPFieldDefinitionDBAccessSqlDataReaderCTSFieldDefinitionOut = CopyRSToRPFieldDefinitionSuccess;

            // Act
            var result = DBCommon.ReadPlanViewFields(dbAccess, 1, out fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => fields.ShouldNotBeNull());
        }

        [TestMethod]
        public void ReadPlanViewFields_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var fields = new List<CTSFieldDefinition>();
            fields = null;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };
            ShimDBCommon.CopyRSToRPFieldDefinitionDBAccessSqlDataReaderCTSFieldDefinitionOut = CopyRSToRPFieldDefinitionSuccess;

            // Act
            var result = DBCommon.ReadPlanViewFields(dbAccess, 1, out fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => fields.ShouldBeNull());
        }

        [TestMethod]
        public void CopyRSToRPFieldDefinition_IsCategory_ExecutesCorrectly()
        {
            // Arrange
            var fieldDefinition = new CTSFieldDefinition();
            fieldDefinition = null;
            var readerValues = new Dictionary<string, object>
            {
                ["FIELD_ID"] = 1,
                ["FIELD_TITLE"] = DummyString,
                ["FIELD_ALIGN"] = (int)TSFieldAlignEnum.faLeft,
                ["FIELD_HIDDEN"] = true,
                ["FIELD_FROZEN"] = false,
                ["FIELD_NAME_SQL"] = DummyString,
                ["FIELD_FORMAT"] = (int)TSFieldFormatEnum.ffCatCode,
                ["FA_FIELD_ID"] = DummyString,
                ["FA_LOOKUP_UID"] = 1,
                ["FA_LEAFONLY"] = true,
                ["FA_USEFULLNAME"] = false,
                ["FA_VALUE_UNIQUE"] = true,
            };
            var reader = new ShimSqlDataReader
            {
                ItemGetString = name =>
                {
                    object value;
                    readerValues.TryGetValue(name, out value);
                    return value;
                }
            }.Instance;
            var args = new object[] { dbAccess, reader, fieldDefinition };
            var privateType = new PrivateType(typeof(DBCommon));

            // Act
            var result = privateType.InvokeStatic(CopyRSToRPFieldDefinition, args) as StatusEnum?;
            fieldDefinition = args[2] as CTSFieldDefinition;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(StatusEnum.rsSuccess),
                () => fieldDefinition.ShouldNotBeNull(),
                () => fieldDefinition.Title.ShouldBe(DummyString),
                () => fieldDefinition.IsCategory.ShouldBeTrue(),
                () => fieldDefinition.CategoryIsIdentity.ShouldBeTrue());
        }

        [TestMethod]
        public void CopyRSToRPFieldDefinition_IsCategoryFalse_ExecutesCorrectly()
        {
            // Arrange
            var fieldDefinition = new CTSFieldDefinition();
            fieldDefinition = null;
            var readerValues = new Dictionary<string, object>
            {
                ["FIELD_ID"] = 1,
                ["FIELD_TITLE"] = DummyString,
                ["FIELD_ALIGN"] = (int)TSFieldAlignEnum.faLeft,
                ["FIELD_HIDDEN"] = true,
                ["FIELD_FROZEN"] = false,
                ["FIELD_NAME_SQL"] = DummyString,
                ["FIELD_FORMAT"] = (int)TSFieldFormatEnum.ffCatCode,
                ["FA_FIELD_ID"] = DBNull.Value,
            };
            var reader = new ShimSqlDataReader
            {
                ItemGetString = name =>
                {
                    object value;
                    readerValues.TryGetValue(name, out value);
                    return value;
                }
            }.Instance;
            var args = new object[] { dbAccess, reader, fieldDefinition };
            var privateType = new PrivateType(typeof(DBCommon));

            // Act
            var result = privateType.InvokeStatic(CopyRSToRPFieldDefinition, args) as StatusEnum?;
            fieldDefinition = args[2] as CTSFieldDefinition;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(StatusEnum.rsSuccess),
                () => fieldDefinition.ShouldNotBeNull(),
                () => fieldDefinition.Title.ShouldBe(DummyString),
                () => fieldDefinition.IsCategory.ShouldBeFalse(),
                () => fieldDefinition.CategoryIsIdentity.ShouldBeFalse());
        }

        [TestMethod]
        public void GetPeriods_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var periods = new List<CPeriod>();
            periods = null;
            var count = 0;
            var readerValues = new Dictionary<string, object>
            {
                ["PRD_ID"] = 1,
                ["PRD_NAME"] = DummyString,
                ["PRD_START_DATE"] = DateTime.Now,
                ["PRD_FINISH_DATE"] = DateTime.Now,
                ["PRD_IS_CLOSED"] = 1,
                ["PRD_CLOSED_DATE"] = DateTime.Now,
                ["PRD_CLOSED_NAME"] = DummyString
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    object value;
                    readerValues.TryGetValue(name, out value);
                    return value;
                }
            }.Instance;

            // Act
            var result = DBCommon.GetPeriods(dbAccess, 1, out periods);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => periods.ShouldNotBeNull(),
                () => periods.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetPeriods_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var periods = new List<CPeriod>();
            periods = null;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            }.Instance;

            // Act
            var result = DBCommon.GetPeriods(dbAccess, 1, out periods);

            // Assert
            result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted);
        }

        [TestMethod]
        public void CopyRSToRPFieldDefinition_OnException_ReturnsStatusSuccess()
        {
            // Arrange
            var fieldDefinition = new CTSFieldDefinition();
            fieldDefinition = null;
            var reader = new ShimSqlDataReader
            {
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            }.Instance;
            var args = new object[] { dbAccess, reader, fieldDefinition };
            var privateType = new PrivateType(typeof(DBCommon));

            // Act
            var result = privateType.InvokeStatic(CopyRSToRPFieldDefinition, args) as StatusEnum?;
            fieldDefinition = args[2] as CTSFieldDefinition;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(StatusEnum.rsSuccess));
        }

        [TestMethod]
        public void GetCostCategoryRolesStruct_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var costCategory = new CStruct();
            costCategory = null;
            ShimDBCommon.GetCostCategoryRolesDBAccessInt32Int32DictionaryOfStringCStructOutBoolean = GetCostCategoryRolesSuccess;
            StructDictionary = new Dictionary<string, CStruct>
            {
                [DummyString] = new CStruct()
            };

            // Act
            var result = DBCommon.GetCostCategoryRolesStruct(dbAccess, 1, 1, out costCategory, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => costCategory.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetLookupListXML_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var reply = new CStruct();
            reply = null;
            var rowValues = new Dictionary<string, object>
            {
                ["LV_UID"] = 1,
                ["LV_LEVEL"] = 1,
                ["LV_VALUE"] = DummyString,
                ["LV_FULLVALUE"] = DummyString,
                ["LV_INACTIVE"] = true
            };
            ShimdbaEditCosts.SelectLookupDBAccessInt32DataTableOut = SelectLookupSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            object value;
                            rowValues.TryGetValue(name, out value);
                            return value;
                        }
                    }
                }.GetEnumerator()
            };

            // Act
            var result = DBCommon.GetLookupListXML(dbAccess, 1, out reply);
            var itemsStruct = reply?.GetSubStruct("Items");
            var itemStruct = itemsStruct?.GetSubStruct("Item");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => reply.ShouldNotBeNull(),
                () => itemStruct.ShouldNotBeNull(),
                () => itemStruct.GetStringAttr("Name").ShouldNotBeNullOrEmpty(),
                () => itemStruct.GetStringAttr("Name").ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetLookupListXML_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var reply = new CStruct();
            reply = null;
            var rowValues = new Dictionary<string, object>
            {
                ["LV_UID"] = 1,
                ["LV_LEVEL"] = 1,
                ["LV_VALUE"] = DummyString,
                ["LV_FULLVALUE"] = DummyString,
                ["LV_INACTIVE"] = true
            };
            ShimdbaEditCosts.SelectLookupDBAccessInt32DataTableOut = SelectLookupSuccess;
            ShimDataTable.AllInstances.RowsGet = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = DBCommon.GetLookupListXML(dbAccess, 1, out reply);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => reply.ShouldBeNull());
        }

        [TestMethod]
        public void SelectProjectIDByExtUID_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var projectId = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => 1
            };

            // Act
            var result = DBCommon.SelectProjectIDByExtUID(dbAccess, DummyString, out projectId);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => projectId.ShouldBe(1));
        }

        [TestMethod]
        public void SelectProjectIDByExtUID_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var projectId = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = DBCommon.SelectProjectIDByExtUID(dbAccess, DummyString, out projectId);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => projectId.ShouldBe(0));
        }

        [TestMethod]
        public void GetPortfolioFieldsAndValues_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var projectId = new Dictionary<string, string>();
            projectId = null;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name => DummyString
            };

            // Atc
            var result = DBCommon.GetPortfolioFieldsAndValues(dbAccess, "1", out projectId);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => projectId.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetPortfolioFieldsAndValues_OnException_ReturnRequestCannotBeCompleted()
        {
            // Arrange
            var projectId = new Dictionary<string, string>();
            projectId = null;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = DBCommon.GetPortfolioFieldsAndValues(dbAccess, "1", out projectId);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => projectId.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetCostCategoryRoles_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var count = 0;
            var categoryRoles = new Dictionary<string, CStruct>();
            categoryRoles = null;
            var readerValues = new Dictionary<string, Func<object>>
            {
                ["BC_ROLE"] = () => 1,
                ["BC_UID"] = () => count + 1,
                ["BC_LEVEL"] = () => 6,
                ["RoleName"] = () => string.Empty,
                ["BC_NAME"] = () => DummyString,
                ["CostCategoryUID"] = () => count + 2,
                ["PeriodID"] = () => 2,
                ["FTE"] = () => 1,
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 2)
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
                    Func<object> value;
                    readerValues.TryGetValue(name, out value);
                    return value();
                }
            };

            // Act
            var result = DBCommon.GetCostCategoryRoles(dbAccess, 1, 1, out categoryRoles, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => categoryRoles.ShouldNotBeNull(),
                () => categoryRoles.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetCostCategoryRoles_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var categoryRoles = new Dictionary<string, CStruct>();
            categoryRoles = null;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    throw new Exception();
                }
            };

            // Act
            var result = DBCommon.GetCostCategoryRoles(dbAccess, 1, 1, out categoryRoles, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => categoryRoles.ShouldNotBeNull(),
                () => categoryRoles.ShouldBeEmpty());
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectLookupSuccess(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum GetCostCategoryRolesSuccess(
            DBAccess dba,
            int lPortfolioCommitmentsCalendarUID,
            int lStartPeriodID,
            out Dictionary<string, CStruct> dicCostCategoryRolesOut,
            bool bGetAll)
        {
            dicCostCategoryRolesOut = StructDictionary ?? new Dictionary<string, CStruct>();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CopyRSToRPFieldDefinitionSuccess(DBAccess db, SqlDataReader reader, out CTSFieldDefinition fields)
        {
            fields = new CTSFieldDefinition();
            return StatusEnum.rsSuccess;
        }
    }
}
