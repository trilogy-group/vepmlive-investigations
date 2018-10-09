using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using System.Web.Fakes;
using System.IO.Fakes;
using System.IO;
using WorkEnginePPM.Fakes;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore;
using System.Data;
using System.Data.Fakes;
using System.Collections.Generic;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CostCategoriesTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private CostCategories _costCategories;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const double DummyDouble = 1;
        private const long DummyLong = 1;
        private const decimal DummyDecimal = 1;

        private const string ProcessRequest = "ProcessRequest";
        private const string CostCategoriesRequest = "CostCategoriesRequest";
        private const string ReadCostCategoryRatesInfo = "ReadCostCategoryRatesInfo";
        private const string SaveCostCategoryRatesInfo = "SaveCostCategoryRatesInfo";
        private const string SaveCostCategoryInfo = "SaveCostCategoryInfo";
        private const string DeleteCostCategoryInfo = "DeleteCostCategoryInfo";
        private const string InitializeFTEColumns = "InitializeFTEColumns";
        private const string ReadCalendarFTEsInfo = "ReadCalendarFTEsInfo";
        private const string SaveCalendarFTEsInfo = "SaveCalendarFTEsInfo";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();

            _costCategories = new CostCategories();
            _privateObject = new PrivateObject(_costCategories);
            _privateType = new PrivateType(typeof(CostCategories));
            InitializeSetup();
        }

        private void InitializeSetup()
        {
            ShimStreamReader.ConstructorStream = (_, _1) => new ShimStreamReader();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.InputStreamGet = _ => new MemoryStream();
            ShimStreamReader.AllInstances.ReadToEnd = _ => DummyString;
            ShimHttpContext.AllInstances.ServerGet = _ => new ShimHttpServerUtility();
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.GetSubStructString = (_, _1) => new ShimCStruct();
            ShimHttpContext.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimHttpResponse.AllInstances.ContentTypeGet = _ => DummyString;
            ShimCStruct.ConvertXMLToJSONString = _ => DummyString;
            ShimHttpResponse.AllInstances.WriteString = (_, _1) => { };
            ShimDataAccess.ConstructorStringSecurityLevels = (_, _1, _2) => new ShimDataAccess();
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimSqlDb.AllInstances.Close = _ => { };

            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateDecimalAttrStringDecimal = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateStringStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.GetDecimalAttrStringDecimal = (_, _1, _2) => DummyDecimal;
            ShimCStruct.AllInstances.AddElementStringString = (_, _1, _2) => { };
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimDataRow.AllInstances.ItemGetString = (_, _1) => DummyString;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;

            _privateObject.GetFieldOrProperty("IsReusable");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void ProcessRequest_HttpContextIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance };
            ShimWebAdmin.CheckRequestHttpContextStringString = (_, _1, _2) => "";
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimWebAdmin.BuildReplyStringStringStringString = (_, _1, _2, _3) => DummyString;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "CostCategoriesRequest";
            ShimCostCategories.CostCategoriesRequestHttpContextStringCStruct = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessRequest,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsReadMajorCategoryItems_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "ReadMajorCategoryItems", new ShimCStruct().Instance };
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimWebAdmin.BuildBaseInfoHttpContext = (_) => DummyString;
            ShimDataAccess.AllInstances.dbaGet = _ => new ShimDBAccess();
            ShimdbaGeneral.SelectLookupDBAccessInt32DataTableOut = (DBAccess dba, int nLookupId, out DataTable dt) =>
            {
                dt = new ShimDataTable().Instance;
                return StatusEnum.rsSuccess;
            };
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimDataRow.AllInstances.ItemGetString = (_, _1) => DummyString;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimCStruct.AllInstances.XML = _ => DummyString;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsDeleteCostCategoryInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "DeleteCostCategoryInfo", new ShimCStruct().Instance };
            ShimCostCategories.DeleteCostCategoryInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsSaveCostCategoryInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "SaveCostCategoryInfo", new ShimCStruct().Instance };
            ShimCostCategories.SaveCostCategoryInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsReadCostCategoryRatesInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "ReadCostCategoryRatesInfo", new ShimCStruct().Instance };
            ShimCostCategories.ReadCostCategoryRatesInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsReadCalendarFTEsInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "ReadCalendarFTEsInfo", new ShimCStruct().Instance };
            ShimCostCategories.ReadCalendarFTEsInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsSaveCostCategoryRatesInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "SaveCostCategoryRatesInfo", new ShimCStruct().Instance };
            ShimCostCategories.SaveCostCategoryRatesInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsSaveCalendarFTEsInfo_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, "SaveCalendarFTEsInfo", new ShimCStruct().Instance };
            ShimCostCategories.SaveCalendarFTEsInfoHttpContextCStruct = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void CostCategoriesRequest_HttpContextAndCstructIsNotNullRequestIsDefault_ReturnCategoryRequest()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, DummyString, new ShimCStruct().Instance };
            ShimWebAdmin.FormatErrorStringStringStringString = (_, _1, _2, _3) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CostCategoriesRequest,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ReadCostCategoryRatesInfo_HttpContextAndCstructIsNotNull_ReturnCategoryCostRates()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.ReadCostCategoryRatesDBAccessInt32DecimalOutDataTableOut =
                (DBAccess dba, int nBCUID, out decimal baserate, out DataTable dt) =>
                {
                    baserate = DummyDecimal;
                    dt = new ShimDataTable().Instance;
                    return StatusEnum.rsSuccess;
                };
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                ReadCostCategoryRatesInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void SaveCostCategoryRatesInfo_HttpContextAndCstructIsNotNull_ReturnSaveCategory()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.UpdateCostCategoryRatesDBAccessInt32DecimalDataTableStringOut =
                (DBAccess dba, int nCA_UID, decimal baserate, DataTable dt, out string sReply) =>
                {
                    sReply = string.Empty;
                    return StatusEnum.rsTaskStatusUpdateFailed;
                };
            ShimWebAdmin.FormatErrorStringStringStringString = (_, _1, _2, _3) => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            Shim_TGrid.AllInstances.HandleRowsDataTableInt32ListOfCStructBoolean = (_, _1, _2, _3, _4) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveCostCategoryRatesInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void SaveCostCategoryRatesInfo_HttpContextAndCstructIsNotNullAndStatusEnumIsSuccess_ReturnSaveCategory()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.UpdateCostCategoryRatesDBAccessInt32DecimalDataTableStringOut =
                (DBAccess dba, int nCA_UID, decimal baserate, DataTable dt, out string sReply) =>
                {
                    sReply = DummyString;
                    return StatusEnum.rsSuccess;
                };
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            Shim_TGrid.AllInstances.HandleRowsDataTableInt32ListOfCStructBoolean = (_, _1, _2, _3, _4) => { };
            ShimAdminFunctions.CalcCategoryRatesDBAccessStringOut = (DBAccess dba, out string sReply) =>
            {
                sReply = DummyString;
                return false;
            };
            ShimSqlDb.FormatAdminErrorStringStringStringString = (_, _1, _2, _3) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveCostCategoryRatesInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void SaveCostCategoryInfo_HttpContextAndCstructIsNotNull_ReturnSaveCategoryCost()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.SaveCostCategoriesDBAccessInt32Int32DataTableStringOut =
                (DBAccess dba, int nMCLookupId, int nMCDefaultId, DataTable dt, out string sReply) =>
                {
                    sReply = DummyString;
                    return StatusEnum.rsSuccess;
                };
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            Shim_TGrid.AllInstances.HandleRowsDataTableInt32ListOfCStructBoolean = (_, _1, _2, _3, _4) => { };
            ShimAdminFunctions.CalcCategoryRatesDBAccessStringOut = (DBAccess dba, out string sReply) =>
            {
                sReply = DummyString;
                return false;
            };
            ShimAdminFunctions.SubmitJobRequestDBAccessInt32StringString = (_, _1, _2, _3) => true;
            ShimSqlDb.FormatAdminErrorStringStringStringString = (_, _1, _2, _3) => DummyString;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveCostCategoryInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void SaveCostCategoryInfo_HttpContextAndCstructIsNotNullCalcCategoryIsTrue_ReturnSaveCategoryCost()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.SaveCostCategoriesDBAccessInt32Int32DataTableStringOut =
                (DBAccess dba, int nMCLookupId, int nMCDefaultId, DataTable dt, out string sReply) =>
                {
                    sReply = DummyString;
                    return StatusEnum.rsSuccess;
                };
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            Shim_TGrid.AllInstances.HandleRowsDataTableInt32ListOfCStructBoolean = (_, _1, _2, _3, _4) => { };
            ShimAdminFunctions.CalcCategoryRatesDBAccessStringOut = (DBAccess dba, out string sReply) =>
            {
                sReply = DummyString;
                return true;
            };
            ShimAdminFunctions.SubmitJobRequestDBAccessInt32StringString = (_, _1, _2, _3) => true;
            ShimPortfolioEngineAPI.Constructor = _ => new ShimPortfolioEngineAPI();
            ShimPortfolioEngineAPI.AllInstances.ExecuteStringString = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveCostCategoryInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void DeleteCostCategoryInfo_HttpContextAndCstructIsNotNullCalcCategoryIsTrue_ReturnDeletedCostCategory()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimdbaCostCategories.CanDeleteCostCategoryDBAccessStringStringOut =
                (DBAccess dba, string sBCUIDs, out string sReply) =>
                {
                    sReply = DummyString;
                    return StatusEnum.rsSuccess;
                };
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                DeleteCostCategoryInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void InitializeFTEColumns_DBAccessAndTGridIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyInt, new Shim_TGrid().Instance };
            ShimdbaCalendars.SelectCalendarPeriodsDBAccessInt32DataTableOut =
                (DBAccess dba, int nCalendarId, out DataTable dt) =>
                {
                    dt = new ShimDataTable().Instance;
                    return StatusEnum.rsSuccess;
                };
            ShimdbaCalendars.ReadCalendarFTEsDBAccessInt32DataTableOut =
                (DBAccess dba, int nCalendarId, out DataTable dt) =>
                {
                    dt = new ShimDataTable().Instance;
                    return StatusEnum.rsSuccess;
                };

            // Act
            var actualResult = _privateType.InvokeStatic(
                InitializeFTEColumns,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ReadCalendarFTEsInfo_HttpContextAndCstructIsNotNull_ReturnReadCalendar()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimCostCategories.InitializeFTEColumnsDBAccessInt32_TGrid = (_, _1, _2) => { };
            ShimdbaCalendars.SelectCalendarsDBAccessDataTableOut = (DBAccess dba, out DataTable dt) =>
            {
                dt = new ShimDataTable().Instance;
                return StatusEnum.rsSuccess;
            };
            ShimdbaCalendars.ReadCalendarFTEsDBAccessInt32DataTableOut = (DBAccess dba, int nCalendarId, out DataTable dt) =>
            {
                dt = new ShimDataTable().Instance;
                return StatusEnum.rsSuccess;
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                ReadCalendarFTEsInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void SaveCalendarFTEsInfo_HttpContextAndCstructIsNotNull_ReturnSaveCalendar()
        {
            // Arrange
            var parameters = new object[] { new ShimHttpContext().Instance, new ShimCStruct().Instance };
            ShimWebAdmin.BuildBaseInfoHttpContext = _ => DummyString;
            ShimCStruct.AllInstances.InnerTextGet = _ => DummyInt.ToString();
            ShimCostCategories.InitializeFTEColumnsDBAccessInt32_TGrid = (_, _1, _2) => { };
            ShimdbaCostCategories.UpdateCostCategoryFTEsDBAccessInt32DataTableStringOut =
                (DBAccess dba, int nCalendar, DataTable dt, out string sReply) =>
                {
                    sReply = string.Empty;
                    return StatusEnum.rsTaskStatusUpdateFailed;
                };
            ShimWebAdmin.FormatErrorStringStringStringString = (_, _1, _2, _3) => DummyString;
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            Shim_TGrid.AllInstances.HandleRowsDataTableInt32ListOfCStructBoolean = (_, _1, _2, _3, _4) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveCalendarFTEsInfo,
                parameters);

            // Assert
            actualResult.ShouldBe(DummyString);
        }
    }
}
