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

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class CostTypesTests
    {
        private IDisposable shimsContext;
        private CostTypes costTypes;
        private const string DummyString = "DummyString";
        private const string DummyException = "Dummy Exception Message";
        private static string CustomReply = string.Empty;
        private static StatusEnum StatusEnumReturn;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            costTypes = new CostTypes();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimStreamReader.AllInstances.ReadToEnd = _ => string.Empty;
            ShimWebAdmin.CheckRequestHttpContextStringString = (context, className, request) => string.Empty;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.ConvertXMLToJSONString = content => content;
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimDataAccess.ConstructorStringSecurityLevels = (_, baseInfo, securityLevels) => { };
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimSqlDb.ReadIntValueObject = valueObject =>
            {
                int result;
                int.TryParse(valueObject?.ToString(), out result);
                return result;
            };
            ShimSqlDb.ReadStringValueObject = valueObject => valueObject?.ToString();
        }

        [TestMethod]
        public void IsReusable_Get_ReturnsFalse()
        {
            // Arrange, Act
            var result = costTypes.IsReusable;

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ProcessRequest_OnSuccess_WritesResponseContent()
        {
            // Arrange
            const string ExpectedContentType = "text/xml; charset=utf-8";
            const string FunctionName = "CostTypesRequest";
            var expectedResponseContent = $"<reply handler=\"WorkEnginePPM.CostTypes\" function=\"{FunctionName}\" context=\"{FunctionName}\" ></reply>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content
                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimStreamReader.AllInstances.ReadToEnd = _ => string.Empty;
            ShimWebAdmin.CheckRequestHttpContextStringString = (context, className, request) => string.Empty;
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => FunctionName;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.ConvertXMLToJSONString = content => content;

            // Act
            costTypes.ProcessRequest(httpContext);

            // Assert
            costTypes.ShouldSatisfyAllConditions(
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
            const string FunctionName = "CostTypesRequest";
            var expectedResponseContent = $"<message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content
                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => FunctionName;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            costTypes.ProcessRequest(httpContext);

            // Assert
            costTypes.ShouldSatisfyAllConditions(
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
            const string FunctionName = "CostTypesRequest";
            var expectedResponseContent = $"<message>{DummyException}</message>";
            var contentType = string.Empty;
            var responseContent = string.Empty;
            var httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    InputStreamGet = () => new MemoryStream()
                },
                ResponseGet = () => new ShimHttpResponse
                {
                    WriteString = content => responseContent = content,
                    ContentTypeSetString = content => contentType = content
                },
                ServerGet = () => new ShimHttpServerUtility()
            };
            ShimCStruct.AllInstances.GetStringAttrString = (_, name) => FunctionName;
            ShimWebAdmin.CheckRequestHttpContextStringString = (context, className, request) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            costTypes.ProcessRequest(httpContext);

            // Assert
            costTypes.ShouldSatisfyAllConditions(
                () => contentType.ShouldNotBeNullOrEmpty(),
                () => contentType.ShouldBe(ExpectedContentType),
                () => responseContent.ShouldNotBeNullOrEmpty(),
                () => responseContent.ShouldContainWithoutWhitespace(expectedResponseContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetCostTotalsInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "GetCostTotalsInfo";
            var data = new CStruct();
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "{Name:'0',Text:'[None]',Value:'0'}";
            const string ExpectedElementContent = "{Name:'1',Text:'1',Value:'1'}";
            ShimCStruct.AllInstances.InnerTextGet = _ => "1";
            ShimdbaCostTypes.SelectBudgetTotalListDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaCostTypes.SelectCostTotalsInfoDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent),
                () => result.ShouldContainWithoutWhitespace(ExpectedElementContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetCostTotalsInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "GetCostTotalsInfo";
            var data = new CStruct();
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<message>Dummy Exception Message</message>";
            ShimCStruct.AllInstances.InnerTextGet = _ => "1";
            ShimdbaCostTypes.SelectBudgetTotalListDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaCostTypes.SelectCostTotalsInfoDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCostTotalsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                InnerTextGet = () => "1"
            };
            var httpContext = new ShimHttpContext();
            ShimdbaCostTypes.SelectBudgetTotalListDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaCostTypes.SelectCostTotalsInfoDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            CustomReply = DummyString;
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaCostTypes.UpdateCostTotalsInfoDBAccessInt32DataTableStringOut = UpdateCostTotalsInfo;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfoDatabaseError_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCostTotalsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                InnerTextGet = () => "1"
            };
            var httpContext = new ShimHttpContext();
            var expectedDefaultContent = $"<message>{DummyException}</message>";
            ShimdbaCostTypes.SelectBudgetTotalListDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaCostTypes.SelectCostTotalsInfoDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            CustomReply = string.Empty;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaCostTypes.UpdateCostTotalsInfoDBAccessInt32DataTableStringOut = UpdateCostTotalsInfo;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCostTotalsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                InnerTextGet = () => "1"
            };
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<message>Dummy Exception Message</message>";
            ShimdbaCostTypes.SelectBudgetTotalListDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaCostTypes.SelectCostTotalsInfoDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            Shim_TGrid.AllInstances.GetDataTable = _ =>
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetSecurityInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "GetSecurityInfo";
            var data = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<costtype CT_ID=\"1\">";
            ShimdbaGroups.SelectCostTypeSecurityGroupsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetSecurityInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "GetSecurityInfo";
            var data = new CStruct();
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<message>Dummy Exception Message</message>";
            ShimCStruct.AllInstances.InnerTextGet = _ => "1";
            ShimdbaGroups.SelectCostTypeSecurityGroupsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimCostTypes.InitializeSecurityColumns_TGrid = _ =>
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateSecurityInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
                GetSubStructString = name => new CStruct()
            };
            var httpContext = new ShimHttpContext();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attrName => 1
                }
            };
            CustomReply = DummyString;
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfo;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfoDatabaseError_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateSecurityInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
                GetSubStructString = name => new CStruct()
            };
            var httpContext = new ShimHttpContext();
            var expectedDefaultContent = $"<message>{DummyException}</message>";
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attrName => 1
                }
            };
            CustomReply = DummyString;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfo;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateSecurityInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
                GetSubStructString = name => new CStruct()
            };
            var httpContext = new ShimHttpContext();
            var expectedDefaultContent = $"<message>{DummyException}</message>";
            ShimCStruct.AllInstances.GetListString = (_, name) =>
            {
                throw new Exception(DummyException);
            };
            CustomReply = DummyString;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfo;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_DeleteCostType_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "DeleteCostType";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1
            };
            var httpContext = new ShimHttpContext();
            CustomReply = DummyString;
            ShimdbaCostTypes.DeleteCostTypeDBAccessInt32StringOut = DeleteCostTypeSuccess;
            
            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_DeleteCostTypeOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "DeleteCostType";
            var expectedDefaultContent = $"<message>{DummyException}</message>";

            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1
            };
            var httpContext = new ShimHttpContext();
            CustomReply = DummyString;
            ShimdbaCostTypes.DeleteCostTypeDBAccessInt32StringOut = DeleteCostTypeException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetPostOptionsInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string ExpectedContent = "<calendars><item id=\"1\" name=\"1\" used=\"1\" /></calendars>";
            const string RequestContext = "GetPostOptionsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                InnerTextGet = () => "1",

            };
            var httpContext = new ShimHttpContext();
            ShimdbaCostTypes.SelectCostTypePostOptionsDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;

            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            ShimdbaCostTypes.IsAutoPostEnabledOnRatePerProjectChangeDBAccessInt32 = (dba, id) => true;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExpectedContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetPostOptionsInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            var expectedContent = $"<message>{DummyException}</message>";
            const string RequestContext = "GetPostOptionsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimdbaCostTypes.SelectCostTypePostOptionsDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => 
            {
                throw new Exception(DummyException);
            };
            ShimdbaCostTypes.IsAutoPostEnabledOnRatePerProjectChangeDBAccessInt32 = (dba, id) => true;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdatePostOptionsInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdatePostOptionsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) => true,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            CustomReply = DummyString;
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaCostTypes.UpdatePostOptionsInfoDBAccessInt32StringBooleanStringOut = UpdatePostOptionsInfo;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdatePostOptionsInfoDataBaseError_ReturnsExpectedResult()
        {
            // Arrange
            var expectedContent = $"<message>{DummyException}</message>";
            const string RequestContext = "UpdatePostOptionsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) => true,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            CustomReply = string.Empty;
            ShimdbaCostTypes.UpdatePostOptionsInfoDBAccessInt32StringBooleanStringOut = UpdatePostOptionsInfo;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdatePostOptionsInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            var expectedContent = $"<message>{DummyException}</message>";
            const string RequestContext = "UpdatePostOptionsInfo";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) =>
                {
                    throw new Exception(DummyException);
                },
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            CustomReply = string.Empty;
            ShimdbaCostTypes.UpdatePostOptionsInfoDBAccessInt32StringBooleanStringOut = UpdatePostOptionsInfo;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedContent));
        }

        [TestMethod]
        public void CostTypesRequest_ValidateFormula_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "ValidateFormula";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) => true,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            CustomReply = DummyString;
            ShimdbaCostTypes.ValidateAndSaveCostTypeFormulaDBAccessInt32StringRefBoolean = ValidateAndSaveCostTypeSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_ReadCalendarsForCostType_ReturnsExpectedResult()
        {
            // Arrange
            const int DummyInt = 10;
            const string CbId = "CB_ID";
            const string RequestContext = "ReadCalendarsForCostType";
            var expectedValue = $"<calendars><item id=\"{DummyInt}\" name=\"{DummyString}\" /></calendars>";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) => true,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimdbaEditCosts.SelectCostTypeDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyInt
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 
                        {
                            switch (name)
                            {
                                case CbId:
                                    return DummyInt;
                                default:
                                    return DummyString;
                            }
                        }
                    }
                }.GetEnumerator()
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void CostTypesRequest_PostCostValues_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "PostCostValues";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetBooleanAttrStringBoolean = (name, defaultValue) => true,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimdbaQueueManager.PostCostValuesDBAccessStringStringStringInt32Out = PostCostValuesSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeEmpty());
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTypeInfo_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCosttypeInfo";
            const string ExpectedValue = "<costtype CT_ID=\"1\" CT_NAME=\"DummyString\" />";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attrName => 1,
                    GetListString = attrName => new List<CStruct>()
                }
            };
            var httpContext = new ShimHttpContext();
            StatusEnumReturn = StatusEnum.rsSuccess;
            ShimdbaCostTypes.UpdateCostTypeInfoDBAccessInt32RefStringInt32Int32Int32Int32CStructCStructStringStringOut = UpdateCostTypeInfo;
            
            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTypeInfoDataBaseError_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCosttypeInfo";
            var expectedValue = $"<message>{DummyString}</message>";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attrName => 1,
                    GetListString = attrName => new List<CStruct>()
                }
            };
            var httpContext = new ShimHttpContext();
            CustomReply = string.Empty;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyString;
            StatusEnumReturn = StatusEnum.rsRequestCannotBeCompleted;
            ShimdbaCostTypes.UpdateCostTypeInfoDBAccessInt32RefStringInt32Int32Int32Int32CStructCStructStringStringOut = UpdateCostTypeInfo;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTypeInfoOnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "UpdateCosttypeInfo";
            var expectedValue = $"<message>{DummyException}</message>";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            ShimCStruct.AllInstances.GetListString = (_, name) => 
            {
                throw new Exception(DummyException);
            };
            var httpContext = new ShimHttpContext();
            CustomReply = string.Empty;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(expectedValue));
        }

        [TestMethod]
        public void CostTypesRequest_GetCostTypesInfoEditModeCalculated_ReturnsExpectedResult()
        {
            // Arrange
            const int DummyInt = 3;
            const string RequestContext = "GetCostTypesInfo";
            var expecteFieldContent = $"<costtype CT_ID=\"{DummyInt}\" CT_NAME=\"{DummyInt}\" CT_EDIT_MODE=\"{DummyInt}\" " +
                $"CT_CB_ID=\"{DummyInt}\" CT_INITIAL_LEVEL=\"{DummyInt}\" CT_NAMEDRATES=\"{DummyInt}\">";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyInt
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    },
                    new ShimDataRow
                    {
                        ItemGetString = name => 0
                    },
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            ShimdbaCostTypes.SelectCostTypeDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimdbaCostTypes.SelectInitializedCostTypeCustomFieldsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimdbaCostTypes.SelectCostTypesForCalcDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimdbaCostTypes.SelectCostTypeFormulaDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaUsers.SelectAvailCCsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expecteFieldContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetCostTypesInfoNewCostType_ReturnsExpectedResult()
        {
            // Arrange
            const int DummyInt = 3;
            const string RequestContext = "GetCostTypesInfo";
            var expecteFieldContent = $"<costtype CT_ID=\"0\" CT_NAME=\"New Cost Type\" CT_EDIT_MODE=\"1\" CT_CB_ID=\"-1\" " +
                "CT_INITIAL_LEVEL=\"1\" CT_NAMEDRATES=\"0\">";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 0,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyInt
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    },
                    
                }.GetEnumerator()
            };
            ShimdbaCostTypes.SelectCostTypeDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimdbaCostTypes.SelectInitializedCostTypeCustomFieldsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimdbaCostTypes.SelectCostTypesForCalcDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;
            ShimdbaCostTypes.SelectCostTypeFormulaDBAccessInt32DataTableOut = SelectCostTypePostOptionsSuccess;
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = SelectBudgetTotalListSuccess;
            ShimdbaUsers.SelectAvailCCsDBAccessInt32DataTableOut = SelectCostTotalsInfoSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expecteFieldContent));
        }

        [TestMethod]
        public void CostTypesRequest_OnException_ReturnsExpectedResult()
        {
            // Arrange
            const string RequestContext = "GetCostTypesInfo";
            var expecteFieldContent = $"<message>{DummyException}</message>";
            var data = new ShimCStruct
            {
                GetIntAttrString = name => 1,
                GetStringAttrString = name => DummyString,
                GetStringString = name => DummyString,
                InnerTextGet = () => "1",
            };
            var httpContext = new ShimHttpContext();
            ShimdbaCostTypes.SelectCostTypeDBAccessInt32DataTableOut = SelectCostTypeError;
            ShimSqlDb.AllInstances.StatusTextGet = _ =>
            {
                throw new Exception(DummyException);
            };

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expecteFieldContent));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCostTypeError(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateCostTypeInfo(
            DBAccess dba, 
            ref int nCTId, 
            string sName, 
            int nEditMode, 
            int nInitialLevel, 
            int nInputCalendar, 
            int nNamedRates, 
            CStruct xAvailCCs, 
            CStruct xCFs, 
            string sFormula, 
            out string sReply)
        {
            sReply = CustomReply;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum PostCostValuesSuccess(
            DBAccess dba, 
            string command, 
            string context, 
            string path, 
            out int rowsAffected)
        {
            rowsAffected = 1;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private string ValidateAndSaveCostTypeSuccess(DBAccess dba, int nFieldId, ref string sFormula, bool bSave)
        {
            return CustomReply;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdatePostOptionsInfo(DBAccess db, int id, string calendars, bool autoPost, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        private StatusEnum SelectCostTypePostOptionsSuccess(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteCostTypeSuccess(DBAccess db, int id, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum DeleteCostTypeException(DBAccess db, int id, out string reply)
        {
            throw new Exception(DummyException);
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateCostTypeSecurityInfo(DBAccess db, int id, CStruct data, out string reply)
        {
            reply = CustomReply;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum UpdateCostTotalsInfo(DBAccess db, int id, DataTable dataTable, out string reply)
        {
            reply = CustomReply;
            return StatusEnumReturn;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectCostTotalsInfoSuccess(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum SelectBudgetTotalListSuccess(DBAccess db, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
