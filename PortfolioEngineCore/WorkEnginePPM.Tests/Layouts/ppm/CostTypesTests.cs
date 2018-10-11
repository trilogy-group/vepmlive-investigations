using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.IO;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /* =================== */

        [TestMethod]
        public void CostTypesRequest_GetCostTotalsInfo()
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
        public void CostTypesRequest_GetCostTotalsInfoOnException_()
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

        /* =================== */

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfo()
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
            const string ExpectedDefaultContent = "{Name:'0',Text:'[None]',Value:'0'}";
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
            ShimdbaCostTypes.UpdateCostTotalsInfoDBAccessInt32DataTableStringOut = UpdateCostTotalsInfoSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfoDatabaseError()
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
            ShimdbaCostTypes.UpdateCostTotalsInfoDBAccessInt32DataTableStringOut = UpdateCostTotalsInfoError;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateCostTotalsInfoOnException_()
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


        /* =================== */

        [TestMethod]
        public void CostTypesRequest_GetSecurityInfo()
        {
            // Arrange
            const string RequestContext = "GetSecurityInfo";
            var data = new ShimCStruct
            {
                InnerTextGet = () => "1"
            };
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<costtype CT_ID=\"1\">";
            ShimdbaGroups.SelectCostTypeSecurityGroupsDBAccessInt32DataTableOut = SelectCostTypeSecurityGroupsSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedDefaultContent));
        }

        [TestMethod]
        public void CostTypesRequest_GetSecurityInfoOnException_()
        {
            // Arrange
            const string RequestContext = "GetSecurityInfo";
            var data = new CStruct();
            var httpContext = new ShimHttpContext();
            const string ExpectedDefaultContent = "<message>Dummy Exception Message</message>";
            ShimCStruct.AllInstances.InnerTextGet = _ => "1";
            ShimdbaGroups.SelectCostTypeSecurityGroupsDBAccessInt32DataTableOut = SelectCostTypeSecurityGroupsSuccess;
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

        /* =================== */

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfo()
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
            const string ExpectedDefaultContent = "{Name:'0',Text:'[None]',Value:'0'}";
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
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfoSuccess;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfoDatabaseError_()
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

            //ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            //{
            //    GetEnumerator = () => new List<DataRow>
            //    {
            //        new ShimDataRow
            //        {
            //            ItemGetString = name => 1
            //        }
            //    }.GetEnumerator()
            //};
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>
            {
                new ShimCStruct
                {
                    GetIntAttrString = attrName => 1
                }
            };
            CustomReply = DummyString;
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfoError;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(DummyString));
        }

        [TestMethod]
        public void CostTypesRequest_UpdateSecurityInfoOnException_()
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
            //ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            //{
            //    GetEnumerator = () => new List<DataRow>
            //    {
            //        new ShimDataRow
            //        {
            //            ItemGetString = name => 1
            //        }
            //    }.GetEnumerator()
            //};
            ShimCStruct.AllInstances.GetListString = (_, name) =>
            {
                throw new Exception(DummyException);
            };
            CustomReply = DummyString;
            ShimdbaCostTypes.UpdateCostTypeSecurityInfoDBAccessInt32CStructStringOut = UpdateCostTypeSecurityInfoError;
            ShimSqlDb.AllInstances.StatusTextGet = _ => DummyException;

            // Act
            var result = CostTypes.CostTypesRequest(httpContext, RequestContext, data);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedDefaultContent));
        }



        private StatusEnum UpdateCostTypeSecurityInfoSuccess(DBAccess db, int id, CStruct data, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        private StatusEnum UpdateCostTypeSecurityInfoError(DBAccess db, int id, CStruct data, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        private StatusEnum SelectCostTypeSecurityGroupsSuccess(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum UpdateCostTotalsInfoSuccess(DBAccess db, int id, DataTable dataTable, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsSuccess;
        }

        private StatusEnum UpdateCostTotalsInfoError(DBAccess db, int id, DataTable dataTable, out string reply)
        {
            reply = CustomReply;
            return StatusEnum.rsRequestCannotBeCompleted;
        }

        private StatusEnum SelectCostTotalsInfoSuccess(DBAccess db, int id, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectBudgetTotalListSuccess(DBAccess db, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
