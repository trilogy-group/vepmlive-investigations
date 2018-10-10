using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.IO;
using System.IO.Fakes;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using static WorkEnginePPM._TGrid;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class ModelsTests
    {
        private IDisposable shimsContext;
        private Models modelsObject;
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyException = "Dummy Exception";
        private const string DeleteModelInfoMethodName = "DeleteModelInfo";
        private const string UpdateModelInfoMethodName = "UpdateModelInfo";
        private const string InitializeSecurityColumnsMethodName = "InitializeSecurityColumns";
        private PrivateType privateType;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            modelsObject = new Models();
            privateType = new PrivateType(typeof(Models));
        }

        private void SetupShims()
        {
            ShimCStruct.ConvertXMLToJSONString = content => content;
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetSubStructString = (_, content) => new CStruct();
            ShimDataAccess.ConstructorStringSecurityLevels = (_, baseInfo, level) => { };
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) => string.Empty;
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void IsReusable_Get_ReturnsFalse()
        {
            // Arrange, Act
            var result = modelsObject.IsReusable;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ProcessRequest_OnSuccess_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string FunctionName = "ModelsRequest";
            var expectedResponseContent = $"<reply handler=\"WorkEnginePPM.Models\" function=\"{FunctionName}\" context=\"{FunctionName}\" >";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimCStruct.AllInstances.GetStringAttrString = (_, content) => FunctionName;

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void ProcessRequest_OnException_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string FunctionName = "ModelsRequest";
            var expectedResponseContent = $"<location>WorkEnginePPM.Models.ProcessRequest</location><message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) => string.Empty;
            ShimCStruct.AllInstances.GetStringAttrString = (_, content) => FunctionName;
            ShimCStruct.AllInstances.GetSubStructString = (_, content) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void ProcessRequest_CheckRequestException_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            var expectedResponseContent = $"<location>WorkEnginePPM.Models.ProcessRequest</location><message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var context = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new ShimStream(new MemoryStream())
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content

                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimWebAdmin.CheckRequestHttpContextStringString = (httpContext, className, request) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            modelsObject.ProcessRequest(context);

            // Assert
            modelsObject.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void DeleteModelInfo_OnSuccess_ReturnsExpectedMessage()
        {
            // Arrange
            var context = new ShimHttpContext().Instance;
            var data = new CStruct();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 1;
            ShimdbaModels.DeleteModelDBAccessInt32StringOut = DeleteModelSuccess;

            // Act
            var result = privateType.InvokeStatic(DeleteModelInfoMethodName, context, data) as string;


            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void DeleteModelInfo_OnException_ReturnsExpectedMessage()
        {
            // Arrange
            var expectedErrorMessage = $"<message>{DummyException}</message><trace></trace></error>";
            var context = new ShimHttpContext().Instance;
            var data = new CStruct();
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 1;
            ShimdbaModels.DeleteModelDBAccessInt32StringOut = DeleteModelException;

            // Act
            var result = privateType.InvokeStatic(DeleteModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_OnSuccess_ReturnsExpectedMessage()
        {
            // Arrange
            var expectedMessage = $"<Model MODEL_UID=\"{DummyInt}\" MODEL_NAME=\"{DummyString}\" MODEL_DESC=\"{DummyString}\" />";
            var context = new ShimHttpContext().Instance;
            var data = new ShimCStruct
            {
                GetIntAttrString = name => DummyInt,
                GetStringAttrString = _ => DummyString
            }.Instance;
            Shim_DGrid.AllInstances.SetXmlDataString = (_, content) => new DataTable();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaModels.UpdateModelInfoDBAccessInt32RefStringStringInt32Int32StringDataTableStringOut = UpdateModelInfoSuccess;

            // Act
            var result = privateType.InvokeStatic(UpdateModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedMessage));
        }

        [TestMethod]
        public void UpdateModelInfo_OnException_ReturnsErrorMessage()
        {
            // Arrange
            var expectedMessage = $"<location>Models.UpdateModelsInfo3</location><message>{DummyException}</message><trace></trace></error>";
            var context = new ShimHttpContext().Instance;
            var data = new ShimCStruct
            {
                GetIntAttrString = name => DummyInt,
                GetStringAttrString = _ => DummyString
            }.Instance;
            Shim_DGrid.AllInstances.SetXmlDataString = (_, content) => new DataTable();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaModels.UpdateModelInfoDBAccessInt32RefStringStringInt32Int32StringDataTableStringOut = UpdateModelInfoException;

            // Act
            var result = privateType.InvokeStatic(UpdateModelInfoMethodName, context, data) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedMessage));
        }

        [TestMethod]
        public void InitializeSecurityColumns_Should_AddColumns()
        {
            // Arrange
            var grid = new _TGrid();
            var privateObject = new PrivateObject(grid);

            // Act
            privateType.InvokeStatic(InitializeSecurityColumnsMethodName, grid);
            var columns = privateObject.GetFieldOrProperty("m_cols") as List<TCol>;

            // Assert
            columns.ShouldSatisfyAllConditions(
                () => columns.ShouldNotBeNull(),
                () => columns.ShouldNotBeEmpty(),
                () => columns.Count.ShouldBe(4));
        }

        [TestMethod]
        public void ModelsRequest_UpdateModelInfo_ShoudlReturnExpectedValue()
        {
            // Arrange
            const string RequestContext = "UpdateModelInfo";
            var context = new ShimHttpContext();
            var data = new CStruct();
            ShimModels.UpdateModelInfoHttpContextCStruct = (httpcontext, structData) => DummyString;

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ModelsRequest_DeleteModelInfo_ShoudlReturnExpectedValue()
        {
            // Arrange
            const string RequestContext = "DeleteModelInfo";
            var context = new ShimHttpContext();
            var data = new CStruct();
            ShimModels.DeleteModelInfoHttpContextCStruct = (httpcontext, structData) => DummyString;

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ModelsRequest_SelectModelError_ShoudlReturnExpectedValue()
        {
            // Arrange
            const string RequestContext = "ReadModelInfo";
            var expectedErrorMessage = $"<message>{DummyException}</message>";
            var context = new ShimHttpContext();
            var data = new ShimCStruct
            {
                InnerTextGet = () => DummyInt.ToString()
            };
            ShimdbaModels.SelectModelDBAccessInt32DataTableOut = SelectModelError;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedErrorMessage));
        }

        [TestMethod]
        public void ModelsRequest_ReadModelInfo_ShouldReturnExpecteDcontent()
        {
            // Arrange
            const string EditPermission = "EDIT_PERMISSION";
            const string ViewPermission = "VIEW_PERMISSION";
            const string RequestContext = "ReadModelInfo";
            var expectedModelContextValue = $"<Model MODEL_UID=\"{DummyInt}\" MODEL_NAME=\"{DummyString}\" MODEL_DESC=\"{DummyString}\" MODEL_CB_ID=\"{DummyInt}\">";
            var expectedCalendarsValue = $"<calendars><item id=\"-1\" name=\"[None]\" /><item id=\"{DummyInt}\" name=\"{DummyString}\" /></calendars>";
            var expectedCostTypesValue = $"<costtypes><item id=\"{DummyInt}\" name=\"{DummyString}\" used=\"{DummyInt}\" /></costtypes>";
            var expectedFlagCustomFieldsValue = $"<flagcustomfields><item id=\"-1\" name=\"[None]\" /><item id=\"{DummyInt}\" name=\"{DummyString}\" selected=\"{DummyInt}\" /></flagcustomfields>";
            var context = new ShimHttpContext();
            var data = new ShimCStruct
            {
                InnerTextGet = () => DummyInt.ToString()
            };
            ShimdbaModels.SelectModelDBAccessInt32DataTableOut = SelectModelSuccess;
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = SelectCalendarsSuccess;
            ShimdbaModels.SelectCostTypesForModelDBAccessInt32DataTableOut = SelectCostTypesForModelSuccess;
            ShimdbaModels.SelectCustomFields_FlagsDBAccessDataTableOut = SelectCustomFieldsSuccess;
            ShimdbaGroups.SelectEmptyCostTypeSecurityGroupsDBAccessDataTableOut = SelectEmptyCostTypeSecurityGroupsSuccess;
            ShimdbaModels.SelectModelVersionsDBAccessInt32DataTableOut = SelectModelVersions;
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
                        ItemGetString = name =>
                        {
                            switch (name)
                            {
                                case EditPermission:
                                case ViewPermission:
                                    return DummyInt;
                                default:
                                    return DummyString;
                            }
                        }
                    }
                }.GetEnumerator(),
                AddObjectArray = parameters => new ShimDataRow()
            };

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(expectedModelContextValue),
                () => result.ShouldContain(expectedCalendarsValue),
                () => result.ShouldContain(expectedCostTypesValue),
                () => result.ShouldContain(expectedFlagCustomFieldsValue));
        }

        [TestMethod]
        public void ModelsRequest_ReadModelInfoDataTableModelEmpty_ShouldReturnExpecteDcontent()
        {
            // Arrange
            const string RequestContext = "ReadModelInfo";
            const string ExpectedModelContextValue = "<Model MODEL_UID=\"0\" MODEL_NAME=\"New Model\" MODEL_DESC=\"\" MODEL_CB_ID=\"-1\">";
            const string ExpectedCalendarsValue = "<calendars><item id=\"-1\" name=\"[None]\" /></calendars>";
            const string ExpectedCostTypesValue = "<costtypes />";
            const string ExpectedFlagCustomFieldsValue = "<flagcustomfields><item id=\"-1\" name=\"[None]\" /></flagcustomfields>";
            var context = new ShimHttpContext();
            var data = new ShimCStruct
            {
                InnerTextGet = () => DummyInt.ToString()
            };
            ShimdbaModels.SelectModelDBAccessInt32DataTableOut = SelectModelSuccess;
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = SelectCalendarsSuccess;
            ShimdbaModels.SelectCostTypesForModelDBAccessInt32DataTableOut = SelectCostTypesForModelSuccess;
            ShimdbaModels.SelectCustomFields_FlagsDBAccessDataTableOut = SelectCustomFieldsSuccess;
            ShimdbaGroups.SelectEmptyCostTypeSecurityGroupsDBAccessDataTableOut = SelectEmptyCostTypeSecurityGroupsSuccess;
            ShimdbaModels.SelectModelVersionsDBAccessInt32DataTableOut = SelectModelVersions;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0,
                ItemGetInt32 = index => null,
                GetEnumerator = () => new List<DataRow>().GetEnumerator(),
                AddObjectArray = parameters => new ShimDataRow()
            };

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(ExpectedModelContextValue),
                () => result.ShouldContain(ExpectedCalendarsValue),
                () => result.ShouldContain(ExpectedCostTypesValue),
                () => result.ShouldContain(ExpectedFlagCustomFieldsValue));
        }

        [TestMethod]
        public void ModelsRequest_OnException_ReturnErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "<message>Dummy Exception</message>";
            const string RequestContext = "ReadModelInfo";
            var context = new ShimHttpContext();
            var data = new ShimCStruct
            {
                InnerTextGet = () => DummyInt.ToString()
            };
            ShimSqlDb.AllInstances.Open = _ => 
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = Models.ModelsRequest(context, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldContain(ExpectedErrorMessage));
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectModelVersions(DBAccess dbAccess, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectEmptyCostTypeSecurityGroupsSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCustomFieldsSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCostTypesForModelSuccess(DBAccess dbAccess, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCalendarsSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectModelSuccess(DBAccess dbAccess, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectModelError(DBAccess dbAccess, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateModelInfoSuccess(
            DBAccess dba, 
            ref int viewId, 
            string name, 
            string description, 
            int calendar, 
            int firstPeriod, 
            string lastPEriod, 
            DataTable dataTable, 
            out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateModelInfoException(
            DBAccess dba,
            ref int viewId, 
            string name, 
            string description, 
            int calendar, 
            int firstPeriod,
            string lastPEriod, 
            DataTable dataTable, 
            out string reply)
        {
            throw new Exception(DummyException);
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteModelSuccess(DBAccess dbAccess, int id, out string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteModelException(DBAccess dbAccess, int id, out string reply)
        {
            throw new Exception(DummyException);
        }
    }
}
