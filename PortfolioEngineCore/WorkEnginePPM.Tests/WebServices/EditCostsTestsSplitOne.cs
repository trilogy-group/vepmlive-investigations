using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Reflection;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Base.DBAccess.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;
using static WorkEnginePPM.EditCosts;
using ShimSystemWebService = System.Web.Services.Fakes.ShimWebService;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class EditCostsTests
    {
        private IDisposable _shimContext;
        private EditCosts _testEntity;
        private PrivateObject _privateObject;
        private PrivateType _privateType;

        private const string MergeCostCategoriesMethodName = "MergeCostCategories";
        private const string MergeCostCategoryValuesMethodName = "MergeCostCategoryValues";
        private const string BuildJSONLookupMethodName = "BuildJSONLookup";
        private const string SendXMLToWorkEngineMethodName = "SendXMLToWorkEngine";
        private const string BuildCalculatedDataMethodName = "BuildCalculatedData";
        private const string GetCostTypeMethodName = "GetCostType";

        private const string CostTypeIdFieldName = "CT_ID";
        private const string CostTypeNameFieldName = "CT_NAME";
        private const string CostTypeCalendarIdFieldName = "CT_CB_ID";
        private const string CostTypeEditModeFieldName = "CT_EDIT_MODE";
        private const string CostTypeAllowNamedRatesFieldName = "CT_ALLOW_NAMED_RATES";
        private const string CostTypeInitialLevelFieldName = "INITIAL_LEVEL";
        private const string PeriodIdFieldName = "PRD_ID";
        private const string PeriodNameFieldName = "PRD_NAME";
        private const string PeriodStartDateFieldName = "PRD_START_DATE";
        private const string PeriodFinishDateFieldName = "PRD_FINISH_DATE";
        private const string CustomFieldIdFieldName = "CF_ID";
        private const string CustomFieldFieldIdFieldName = "CF_FIELD_ID";
        private const string CustomFieldEditableFieldName = "CF_EDITABLE";
        private const string CustomFieldVisibleFieldName = "CF_VISIBLE";
        private const string CustomFieldIdentityFieldName = "CF_IDENTITY";
        private const string CustomFieldRequiredFieldName = "CF_REQUIRED";
        private const string CustomFieldFrozenFieldName = "CF_FROZEN";
        private const string CustomFieldAttrNameFieldName = "FA_NAME";
        private const string CustomFieldAttrLookupOnlyFieldName = "FA_LOOKUPONLY";
        private const string CustomFieldAttrUidFieldName = "FA_LOOKUP_UID";
        private const string CustomFieldAttrLeafOnlyFieldName = "FA_LEAFONLY";
        private const string CustomFieldAttrUseFullNameFieldName = "FA_USEFULLNAME";
        private const string NamedRateUidFieldName = "RT_UID";
        private const string NamedRateNameFieldName = "RT_NAME";
        private const string NamedRateLevelFieldName = "RT_LEVEL";
        private const string NamedRateEffectiveDateFieldName = "RT_EFFECTIVE_DATE";
        private const string NamedRateRateFieldName = "RT_RATE";
        private const string LookupUidFieldName = "LV_UID";
        private const string LookupFullValueFieldName = "LV_FULLVALUE";
        private const string LookupValuedFieldName = "LV_VALUE";
        private const string LookupLevelFieldName = "LV_LEVEL";
        private const string LookupInactiveFieldName = "LV_INACTIVE";
        private const string ProjectCheckedOutFieldName = "PROJECT_CHECKEDOUT";
        private const string ProjectCheckedOutDateFieldName = "PROJECT_CHECKEDOUT_DATE";
        private const string ProjectResourceNameFieldName = "RES_NAME";
        private const string CostTypeOperationIdFieldName = "CL_CT_ID";
        private const string CostTypeOperationOperationFieldName = "CL_OP";
        private const string CostCategoryUidFieldName = "BC_UID";
        private const string CostCategoryIdFieldName = "BC_ID";
        private const string CostCategoryNameFieldName = "BC_NAME";
        private const string CostCategoryLevelFieldName = "BC_LEVEL";
        private const string CostCategoryUomFieldName = "BC_UOM";
        private const string CostCategorySeqFieldName = "BC_SEQ";
        private const string PeriodRateCostCategoryUidFieldName = "BA_BC_UID";
        private const string PeriodRatePeriodIdFieldName = "BA_PRD_ID";
        private const string PeriodRateFteConvFieldName = "BA_FTE_CONV";
        private const string PeriodRateRateFieldName = "BA_RATE";
        private const string PeriodCostPeriodIdFieldName = "BD_PERIOD";
        private const string PeriodCostValueFieldName = "BD_VALUE";
        private const string PeriodCostCostFieldName = "BD_COST";
        private const string SeqFieldName = "Seq";
        private const string UsedFieldName = "Used";
        private const string ViewUidFieldName = "VIEW_UID";
        private const string ViewNameFieldName = "VIEW_NAME";

        private const string DummyString = "DummyString";
        private const string DummyBaseInfo = "DummyBaseInfo";
        private const string DummyCostTypeName = "DummyCostTypeName";
        private const string DummyPeriodName1 = "DummyPeriodName1";
        private const string DummyPeriodName2 = "DummyPeriodName2";
        private const string DummyNamedRateName = "DummyNamedRateName";
        private const int DummyCostTypeId1 = 10;
        private const int DummyCostTypeId2 = 11;
        private const int DummyCostTypeId3 = 12;
        private const int DummyCostTypeId4 = 13;
        private const int DummyCostTypeId5 = 14;
        private const int DummyCostTypeCalendarId = 15;
        private int _costTypeEditMode = 0;
        private const int DummyCostTypeInitialLevel = 0;
        private const int DummyPeriodId1 = 166;
        private const int DummyPeriodId2 = 167;
        private const int DummyNamedRateId = 20;
        private const int DummyNamedRateLevel = 21;
        private const bool DummyCostTypeIncludeNamedRates = true;
        private static readonly DateTime DummyDateTime = new DateTime(2018, 6, 1, 0, 0, 0);
        private static readonly DateTime DummyStartDate1 = new DateTime(2018, 5, 1, 0, 0, 0);
        private static readonly DateTime DummyFinishDate1 = new DateTime(2018, 7, 1, 0, 0, 0);
        private static readonly DateTime DummyStartDate2 = new DateTime(2018, 6, 1, 0, 0, 0);
        private static readonly DateTime DummyFinishDate2 = new DateTime(2018, 6, 1, 0, 0, 0);
        private const int DummyCustomFieldId = 30;
        private const int DummyCustomFieldFieldId = 31;
        private const bool DummyCustomFieldEditable = true;
        private const bool DummyCustomFieldVisible = true;
        private const bool DummyCustomFieldIdentity = true;
        private const bool DummyCustomFieldRequired = true;
        private const bool DummyCustomFieldFrozen = true;
        private const string DummyCustomFieldName = "DummyCustomFieldName";
        private const bool DummyCustomFieldLookupOnly = true;
        private const int DummyCustomFieldLookupId = 24;
        private const bool DummyCustomFieldLeafOnly = true;
        private const bool DummyCustomFieldUseFullName = true;
        private const int DummyLookupItemId = 40;
        private const string DummyLookupItemFullName = "DummyLookupItemFullName";
        private const string DummyLookupItemName = "DummyLookupItemName";
        private const int DummyLookupItemLevel = 1;
        private const bool DummyLookupItemInactive = false;
        private const int DummyProjectCheckedOut = 1;
        private static readonly DateTime DummyProjectCheckedOutDate = DummyDateTime;
        private const string DummyProjectResourceName = "DummyProjectResourceName";
        private const int DummyCostTypeOperationId = 50;
        private const int DummyCostTypeOperationOperation = 51;
        private const int DummyCostCategoryUid1 = 60;
        private const int DummyCostCategoryUid2 = 61;
        private const int DummyCostCategoryUid3 = 62;
        private const int DummyCostCategoryUid4 = 63;
        private const int DummyCostCategoryUid5 = 64;
        private const int DummyCostCategoryId1 = 70;
        private const int DummyCostCategoryId2 = 71;
        private const int DummyCostCategoryId3 = 72;
        private const int DummyCostCategoryId4 = 73;
        private const int DummyCostCategoryId5 = 74;
        private const string DummyCostCategoryName1 = "DummyCostCategoryName1";
        private const string DummyCostCategoryName2 = "DummyCostCategoryName2";
        private const string DummyCostCategoryName3 = "DummyCostCategoryName3";
        private const string DummyCostCategoryName4 = "DummyCostCategoryName4";
        private const string DummyCostCategoryName5 = "DummyCostCategoryName5";
        private const int DummyCostCategoryLevel1 = 1;
        private const int DummyCostCategoryLevel2 = 2;
        private const int DummyCostCategoryLevel3 = 3;
        private const string DummyCostCategoryUom1 = "DummyCostCategoryUom1";
        private const string DummyCostCategoryUom2 = "DummyCostCategoryUom2";
        private const string DummyCostCategoryUom3 = "DummyCostCategoryUom3";
        private const string DummyCostCategoryUom4 = "DummyCostCategoryUom4";
        private const string DummyCostCategoryUom5 = "DummyCostCategoryUom5";
        private const int DummyPeriodRateFteConv = 80;
        private const double DummyPeriodRateRate = 81;
        private const double DummyPeriodCostValue = 90;
        private const double DummyPeriodCostCost = 91;
        private const decimal DummyDiscountRate = 10;
        private const int CustomFieldId11801 = 11801;
        private const int CustomFieldId11802 = 11802;
        private const int CustomFieldId11803 = 11803;
        private const int CustomFieldId11804 = 11804;
        private const int CustomFieldId11805 = 11805;
        private const int CustomFieldId11811 = 11811;
        private const int CustomFieldId11812 = 11812;
        private const int CustomFieldId11813 = 11813;
        private const int CustomFieldId11814 = 11814;
        private const int CustomFieldId11815 = 11815;
        private const int DummyInt = 1;
        private const string DummyError = "DummyError";
        private const string wepId = "33";
        private const int DefaultProjectId = 0;
        private const int DefaultCostTypeId = 0;
        private const int DefaultFteMode = 0;
        private const string DummyViewName = "DummyViewName";
        private const string DummyViewUid = "444";
        private const int DummyProjectId = 100;
        private const int DummyLookupItemUid1 = 110;
        private const int DummyLookupItemUid2 = 120;
        private const int DummyLookupItemUid3 = 130;
        private const int DummyLookupItemUid4 = 140;
        private const string DummyLookupItemName1 = "DummyLookupItemName1";
        private const string DummyLookupItemName2 = "DummyLookupItemName2";
        private const string DummyLookupItemName3 = "DummyLookupItemName3";
        private const string DummyLookupItemName4 = "DummyLookupItemName4";

        private readonly string xmlDataSaveEditCostsData = $@"<Root><Body><B><I Visible=""1"" id=""I{DummyCostCategoryUid1}""><I Visible=""0"" id=""I{DummyCostCategoryUid2}S1"" CanWrite=""0""/><I Visible=""1"" id=""I{DummyCostCategoryUid2}S2"" CanWrite=""1"" Changed=""0""/></I><I Visible=""1"" id=""I{DummyCostCategoryUid3}"" Changed=""1"" Y{CustomFieldId11801}=""1""  Y{CustomFieldId11802}=""1""  Y{CustomFieldId11803}=""1""  Y{CustomFieldId11804}=""1""  Y{CustomFieldId11805}=""1"" Y{CustomFieldId11811}=""1""  Y{CustomFieldId11812}=""1""  Y{CustomFieldId11813}=""1""  Y{CustomFieldId11814}=""1""  Y{CustomFieldId11815}=""1"" C{DummyPeriodId1}=""1""></I></B></Body></Root>";
        private readonly string xmlDataSaveEditCostsSimpleData = $"<Root><Body><B><I Visible=\"1\" id=\"I{DummyCostCategoryUid1}\"/></B></Body></Root>";

        private StatusEnum _currentStatus = StatusEnum.rsSuccess;
        private string _currentStatusText;
        private ShimDBAccess _dbAccess;
        private ShimSqlDb _sqlDb;
        private List<CostCategory> _costCategoryList1;
        private List<CostCategory> _costCategoryList2;
        private CostCategory _costCategory1;
        private CostCategory _costCategory2;
        private Type _costTypeOperationClass;
        private ConstructorInfo _costTypeOperationCtor;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new EditCosts();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(EditCosts));

            _currentStatusText = string.Empty;

            _costTypeOperationClass = typeof(CostType).Assembly.GetType("WorkEnginePPM.EditCosts+CostTypeOperation");
            _costTypeOperationCtor = _costTypeOperationClass.GetConstructors()[0];

            ShimSystemWebService.AllInstances.ContextGet = sender => new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };

            _dbAccess = new ShimDBAccess();
            _sqlDb = new ShimSqlDb(_dbAccess)
            {
                Open = () => StatusEnum.rsSuccess,
                StatusGet = () => _currentStatus,
                StatusSetStatusEnum = status => _currentStatus = status,
                StatusTextGet = () => _currentStatusText,
                StatusTextSetString = newText => _currentStatusText = newText
            };
            ShimWebAdmin.BuildBaseInfoHttpContext = context => DummyBaseInfo;
            ShimDataAccess.ConstructorStringSecurityLevels = (sender, baseInfo, secLevel) => new ShimDataAccess(sender)
            {
                dbaGet = () => _dbAccess
            };

            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = (DBAccess dba, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("ADM_WE_SERVERURL", typeof(string));

                var dataRow = dataTable.NewRow();
                dataRow["ADM_WE_SERVERURL"] = "http://tempuri.org";

                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };

            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess dbAccessParam, string projectIds, out string result) =>
            {
                result = string.Empty;
                return StatusEnum.rsSuccess;
            };
            ShimDateTime.NowGet = () => DummyDateTime;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _testEntity?.Dispose();
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void GetEditCostsLayout_EditModeZero_ReturnsXml()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 0;

            _costTypeEditMode = 0;

            SetupShimDbaEditCosts();

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            var expectedContents = new List<string>()
            {
                $"<Cfg CostsAreEditable=\"0\" StartPeriod=\"{DummyPeriodId1}\" FinishPeriod=\"{DummyPeriodId2}\" FloatingPeriods=\"1\" MainCol=\"Category\" Code=\"GTACCNPSQEBSLC\" Dragging=\"0\" ColMoving=\"0\" ColsPosLap=\"1\" ColsLap=\"1\" LeftWidth=\"400\" SuppressCfg=\"1\" InEditMode=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" DefaultSort=\"rowid\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789IS\" Style=\"GM\" CSS=\"RPEditor\" FastColumns=\"1\" Sorting=\"0\" NoTreeLines=\"1\" />",
            };

            // Act
            var actualResult = _testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)),
                () => ExpectedContentsGetEditCostsLayout().ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsLayout_EditMode1_ReturnsXml()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 1;

            _costTypeEditMode = 1;

            SetupShimDbaEditCosts();

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            var expectedContents = new List<string>()
            {
                $"<Cfg CostsAreEditable=\"1\" StartPeriod=\"{DummyPeriodId1}\" FinishPeriod=\"{DummyPeriodId2}\" FloatingPeriods=\"1\" MainCol=\"Category\" Code=\"GTACCNPSQEBSLC\" Dragging=\"0\" ColMoving=\"0\" ColsPosLap=\"1\" ColsLap=\"1\" LeftWidth=\"400\" SuppressCfg=\"1\" InEditMode=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" DefaultSort=\"rowid\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789IS\" Style=\"GM\" CSS=\"RPEditor\" FastColumns=\"1\" Sorting=\"0\" NoTreeLines=\"1\" />"
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)),
                () => ExpectedContentsGetEditCostsLayout().ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsLayout_EditMode101_ReturnsXml()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 1;

            _costTypeEditMode = 101;

            SetupShimDbaEditCosts();

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            var expectedContents = new List<string>()
            {
                $"<Cfg CostsAreEditable=\"0\" StartPeriod=\"{DummyPeriodId1}\" FinishPeriod=\"{DummyPeriodId2}\" FloatingPeriods=\"1\" MainCol=\"Category\" Code=\"GTACCNPSQEBSLC\" Dragging=\"0\" ColMoving=\"0\" ColsPosLap=\"1\" ColsLap=\"1\" LeftWidth=\"400\" SuppressCfg=\"1\" InEditMode=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" DefaultSort=\"rowid\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789IS\" Style=\"GM\" CSS=\"RPEditor\" FastColumns=\"1\" Sorting=\"0\" NoTreeLines=\"1\" />"
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)),
                () => ExpectedContentsGetEditCostsLayout().ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsLayout_EditMode3_ReturnsXml()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 1;

            _costTypeEditMode = 3;

            SetupShimDbaEditCosts();

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            var expectedContents = new List<string>()
            {
                $"<Cfg CostsAreEditable=\"0\" StartPeriod=\"{DummyPeriodId1}\" FinishPeriod=\"{DummyPeriodId2}\" FloatingPeriods=\"1\" MainCol=\"Category\" Code=\"GTACCNPSQEBSLC\" Dragging=\"0\" ColMoving=\"0\" ColsPosLap=\"1\" ColsLap=\"1\" LeftWidth=\"400\" SuppressCfg=\"1\" InEditMode=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" DefaultSort=\"rowid\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789IS\" Style=\"GM\" CSS=\"RPEditor\" FastColumns=\"1\" Sorting=\"0\" NoTreeLines=\"1\" />"
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)),
                () => ExpectedContentsGetEditCostsLayout().ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsLayout_EditMode3OperationNotFound_ReturnsXmlError()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 1;

            _costTypeEditMode = 3;

            SetupShimDbaEditCosts();

            ShimdbaEditCosts.SelectCostTypeOperationsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeOperationIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeOperationOperationFieldName, typeof(int));

                return StatusEnum.rsSuccess;
            };

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"GetEditCostsLayout&#xA;&#xA;\" /></Grid>");
        }

        [TestMethod]
        public void GetEditCostsLayout_AuthenticateUserFail_ReturnsXmlError()
        {
            // Arrange
            var viewUid = "10";
            var tryCheckout = 1;

            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return false;
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"GetEditCostsLayout&#xA;&#xA;User Authentication Failed. Stage={DummyString}\" /></Grid>");
        }

        [TestMethod]
        public void GetEditCostsLayout_ProjectIdZero_ReturnsXmlError()
        {
            // Arrange
            var viewUid = "10";
            var wepId = string.Empty;
            var tryCheckout = 1;

            SetupShimDbaEditCosts();

            ShimdbaEditCosts.SelectViewCalendarInfoDBAccessInt32Int32OutInt32OutInt32Out = (DBAccess dba, int nViewUid, out int nCalendarId, out int nFirstPeriod, out int nLastPeriod) =>
            {
                nCalendarId = 1;
                nFirstPeriod = int.MinValue;
                nLastPeriod = int.MaxValue;
                return StatusEnum.rsSuccess;
            };

            ShimViewData.GetViewXmlByNameDBAccessViewDataContextString = (dbAccessParam, contextParam, viewName) => new[]
            {
                $"<Node AutoAdjustPeriods=\"1\" StartPeriodDelta=\"{DummyPeriodId1}\" FinishPeriodDelta=\"{DummyPeriodId2}\"></Node>"
            };

            // Act
            var actualResult = (string)_testEntity.GetEditCostsLayout(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBe("<Grid><IO Result=\"-10\" Message=\"GetEditCostsLayout&#xA;&#xA;\" /></Grid>"),
                () => _currentStatus.ShouldBe(StatusEnum.rsProjectNotFound),
                () => _currentStatusText.ShouldBe("Project not found for WEPID "));
        }

        [TestMethod]
        public void GetEditCostsData_EditModeZero_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            _costTypeEditMode = 0;

            SetupShimDbaEditCosts();

            var expectedContents = new List<string>()
            {
                $"<I id=\"I{DummyCostCategoryUid1}\" rowid=\"{DummyCostCategoryUid1}\" Category=\"{DummyCostCategoryName1}\" uom=\"{DummyCostCategoryUom1}\" Discount=\"0\" CanEdit=\"0\" Def=\"Summary\" R{DummyPeriodId1}=\"{DummyPeriodRateRate}\" E{DummyPeriodId1}=\"{DummyPeriodRateFteConv}\" Q{DummyPeriodId1}=\"{DummyPeriodCostValue}\" C{DummyPeriodId1}=\"{DummyPeriodCostCost}\">",
                $"<I id=\"I{DummyCostCategoryUid2}\" rowid=\"{DummyCostCategoryUid2}\" Category=\"{DummyCostCategoryName2}\" uom=\"{DummyCostCategoryUom2}\" Discount=\"0\" CanEdit=\"0\" Def=\"Summary\">",
                $"<I id=\"I{DummyCostCategoryUid3}\" rowid=\"{DummyCostCategoryUid3}\" Category=\"{DummyCostCategoryName3}\" uom=\"{DummyCostCategoryUom3}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />",
                $"<I id=\"I{DummyCostCategoryUid4}\" rowid=\"{DummyCostCategoryUid4}\" Category=\"{DummyCostCategoryName4}\" uom=\"{DummyCostCategoryUom4}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />",
                $"<I id=\"I{DummyCostCategoryUid5}\" rowid=\"{DummyCostCategoryUid5}\" Category=\"{DummyCostCategoryName5}\" uom=\"{DummyCostCategoryUom5}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />"
            };

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsData_EditMode1_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            _costTypeEditMode = 1;

            SetupShimDbaEditCosts();

            var expectedContents = new List<string>()
            {
                $"<I id=\"I{DummyCostCategoryUid1}\" rowid=\"{DummyCostCategoryUid1}\" Category=\"{DummyCostCategoryName1}\" uom=\"{DummyCostCategoryUom1}\" Discount=\"{DummyDiscountRate}\" CanEdit=\"0\" Def=\"Summary\" V=\"{DummyNamedRateId}\" W=\"{DummyNamedRateName}\" R{DummyPeriodId1}=\"{DummyPeriodRateRate}\" E{DummyPeriodId1}=\"{DummyPeriodRateFteConv}\">",
                $"<I id=\"I{DummyCostCategoryUid2}\" rowid=\"{DummyCostCategoryUid2}\" Category=\"{DummyCostCategoryName2}\" uom=\"{DummyCostCategoryUom2}\" Discount=\"{DummyDiscountRate}\" CanEdit=\"0\" Def=\"R\">",
                $"<I id=\"I{DummyCostCategoryUid2}S1\" rowid=\"{DummyCostCategoryUid2}\" Category=\"{DummyCostCategoryName2}\" uom=\"{DummyCostCategoryUom2}\" Discount=\"{DummyDiscountRate}\" CanEdit=\"0\" Def=\"R\" V=\"{DummyNamedRateId}\" W=\"{DummyNamedRateName}\" />"
            };

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsData_EditMode3_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            _costTypeEditMode = 3;

            SetupShimDbaEditCosts();

            var expectedContents = new List<string>()
            {
                $"<I id=\"I{DummyCostCategoryUid1}\" rowid=\"{DummyCostCategoryUid1}\" Category=\"{DummyCostCategoryName1}\" uom=\"{DummyCostCategoryUom1}\" Discount=\"0\" CanEdit=\"0\" Def=\"Summary\" R{DummyPeriodId1}=\"{DummyPeriodRateRate}\" E{DummyPeriodId1}=\"{DummyPeriodRateFteConv}\" Q{DummyPeriodId1}=\"{DummyPeriodCostValue}\" C{DummyPeriodId1}=\"{DummyPeriodCostCost}\">",
                $"<I id=\"I{DummyCostCategoryUid2}\" rowid=\"{DummyCostCategoryUid2}\" Category=\"{DummyCostCategoryName2}\" uom=\"{DummyCostCategoryUom2}\" Discount=\"0\" CanEdit=\"0\" Def=\"Summary\">",
                $"<I id=\"I{DummyCostCategoryUid3}\" rowid=\"{DummyCostCategoryUid3}\" Category=\"{DummyCostCategoryName3}\" uom=\"{DummyCostCategoryUom3}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />",
                $"<I id=\"I{DummyCostCategoryUid4}\" rowid=\"{DummyCostCategoryUid4}\" Category=\"{DummyCostCategoryName4}\" uom=\"{DummyCostCategoryUom4}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />",
                $"<I id=\"I{DummyCostCategoryUid5}\" rowid=\"{DummyCostCategoryUid5}\" Category=\"{DummyCostCategoryName5}\" uom=\"{DummyCostCategoryUom5}\" Discount=\"0\" CanEdit=\"0\" Def=\"R\" />"
            };

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetEditCostsData_AuthenticateUserFail_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return false;
            };

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"GetEditCostsData&#xA;&#xA;User Authentication Failed. Stage={DummyString}\" /></Grid>");
        }

        [TestMethod]
        public void GetEditCostsData_ProjectIdZero_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var wepId = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            SetupShimDbaEditCosts();

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"GetEditCostsData&#xA;&#xA;Invalid Project ID:{DefaultProjectId}; wepid:;\" /></Grid>");
        }

        [TestMethod]
        public void GetEditCostsData_SelectProjectByExtUidFail_ReturnsXml()
        {
            // Arrange
            var viewUid = string.Empty;
            var tryCheckout = 0;
            var loadAllCostCategories = true;

            SetupShimDbaEditCosts();

            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string sExtUID, out int nProjectID) =>
            {
                nProjectID = 0;
                return StatusEnum.rsWSSUnknownError;
            };

            // Act
            var actualResult = _testEntity.GetEditCostsData(
                DefaultProjectId,
                DefaultCostTypeId,
                viewUid,
                DefaultFteMode,
                wepId,
                tryCheckout,
                loadAllCostCategories);

            // Assert
            actualResult.ShouldBe($"<Grid><IO Result=\"-10\" Message=\"GetEditCostsData&#xA;&#xA;\" /></Grid>");
        }

        private void SetupShimDbaEditCosts()
        {
            ShimdbaEditCosts.SelectCostTypeDBAccessInt32DataTableOut = (DBAccess dbAccessParam, int costTypeIdParam, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeNameFieldName, typeof(string));
                dataTable.Columns.Add(CostTypeCalendarIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeEditModeFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeAllowNamedRatesFieldName, typeof(bool));
                dataTable.Columns.Add(CostTypeInitialLevelFieldName, typeof(int));

                var dataRow = dataTable.NewRow();
                dataRow[CostTypeIdFieldName] = DummyCostTypeId1;
                dataRow[CostTypeNameFieldName] = DummyCostTypeName;
                dataRow[CostTypeCalendarIdFieldName] = DummyCostTypeCalendarId;
                dataRow[CostTypeEditModeFieldName] = _costTypeEditMode;
                dataRow[CostTypeAllowNamedRatesFieldName] = DummyCostTypeIncludeNamedRates;
                dataRow[CostTypeInitialLevelFieldName] = DummyCostTypeInitialLevel;

                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.CheckCostTypeSecurityDBAccessInt32Int32Ref = (DBAccess dbAccessParam, int costTypeIdParam, ref int costTypeEditModeParam) => true;
            ShimdbaEditCosts.SelectViewCalendarInfoDBAccessInt32Int32OutInt32OutInt32Out = (DBAccess dba, int nViewUid, out int nCalendarId, out int nFirstPeriod, out int nLastPeriod) =>
            {
                nCalendarId = DummyCostTypeCalendarId;
                nFirstPeriod = DummyPeriodId1;
                nLastPeriod = DummyPeriodId2;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectCalendarPeriodsDBAccessInt32DataTableOut = (DBAccess dba, int nCalendarId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(PeriodIdFieldName, typeof(int));
                dataTable.Columns.Add(PeriodNameFieldName, typeof(string));
                dataTable.Columns.Add(PeriodStartDateFieldName, typeof(DateTime));
                dataTable.Columns.Add(PeriodFinishDateFieldName, typeof(DateTime));

                var dataRow = dataTable.NewRow();
                dataRow[PeriodIdFieldName] = DummyPeriodId1;
                dataRow[PeriodNameFieldName] = DummyPeriodName1;
                dataRow[PeriodStartDateFieldName] = DummyStartDate1;
                dataRow[PeriodFinishDateFieldName] = DummyFinishDate1;
                dataTable.Rows.Add(dataRow);

                var dataRow2 = dataTable.NewRow();
                dataRow2[PeriodIdFieldName] = DummyPeriodId2;
                dataRow2[PeriodNameFieldName] = DummyPeriodName2;
                dataRow2[PeriodStartDateFieldName] = DummyStartDate2;
                dataRow2[PeriodFinishDateFieldName] = DummyFinishDate2;
                dataTable.Rows.Add(dataRow2);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectProjectIDByExtUIDDBAccessStringInt32Out = (DBAccess dba, string extUid, out int projectId) =>
            {
                projectId = 9;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.GetProjectInfoDBAccessInt32DateTimeOutDateTimeOut = (DBAccess dba, int projectId, out DateTime dtStart, out DateTime dtFinish) =>
            {
                dtStart = DummyDateTime;
                dtFinish = DummyDateTime;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectCostCustomFieldsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CustomFieldIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeIdFieldName, typeof(int));
                dataTable.Columns.Add(CustomFieldFieldIdFieldName, typeof(int));
                dataTable.Columns.Add(CustomFieldEditableFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldVisibleFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldIdentityFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldRequiredFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldFrozenFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldAttrNameFieldName, typeof(string));
                dataTable.Columns.Add(CustomFieldAttrLookupOnlyFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldAttrUidFieldName, typeof(int));
                dataTable.Columns.Add(CustomFieldAttrLeafOnlyFieldName, typeof(bool));
                dataTable.Columns.Add(CustomFieldAttrUseFullNameFieldName, typeof(bool));

                var dataRow = dataTable.NewRow();
                dataRow[CustomFieldIdFieldName] = DummyCustomFieldId;
                dataRow[CostTypeIdFieldName] = DummyCostTypeId1;
                dataRow[CustomFieldFieldIdFieldName] = DummyCustomFieldFieldId;
                dataRow[CustomFieldEditableFieldName] = DummyCustomFieldEditable;
                dataRow[CustomFieldVisibleFieldName] = DummyCustomFieldVisible;
                dataRow[CustomFieldIdentityFieldName] = DummyCustomFieldIdentity;
                dataRow[CustomFieldRequiredFieldName] = DummyCustomFieldRequired;
                dataRow[CustomFieldFrozenFieldName] = DummyCustomFieldFrozen;
                dataRow[CustomFieldAttrNameFieldName] = DummyCustomFieldName;
                dataRow[CustomFieldAttrLookupOnlyFieldName] = DummyCustomFieldLookupOnly;
                dataRow[CustomFieldAttrUidFieldName] = DummyCustomFieldLookupId;
                dataRow[CustomFieldAttrLeafOnlyFieldName] = DummyCustomFieldLeafOnly;
                dataRow[CustomFieldAttrUseFullNameFieldName] = DummyCustomFieldUseFullName;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectNamedRateItemsDBAccessDataTableOut = (DBAccess dba, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(NamedRateUidFieldName, typeof(int));
                dataTable.Columns.Add(NamedRateNameFieldName, typeof(string));
                dataTable.Columns.Add(NamedRateLevelFieldName, typeof(int));

                var dataRow = dataTable.NewRow();
                dataRow[NamedRateUidFieldName] = DummyNamedRateId;
                dataRow[NamedRateNameFieldName] = DummyNamedRateName;
                dataRow[NamedRateLevelFieldName] = DummyNamedRateLevel;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectLookupDBAccessInt32DataTableOut = (DBAccess dba, int nLookupId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(LookupUidFieldName, typeof(int));
                dataTable.Columns.Add(LookupFullValueFieldName, typeof(string));
                dataTable.Columns.Add(LookupValuedFieldName, typeof(string));
                dataTable.Columns.Add(LookupLevelFieldName, typeof(int));
                dataTable.Columns.Add(LookupInactiveFieldName, typeof(bool));

                var dataRow = dataTable.NewRow();
                dataRow[LookupUidFieldName] = DummyLookupItemId;
                dataRow[LookupFullValueFieldName] = DummyLookupItemFullName;
                dataRow[LookupValuedFieldName] = DummyLookupItemName;
                dataRow[LookupLevelFieldName] = DummyLookupItemLevel;
                dataRow[LookupInactiveFieldName] = DummyLookupItemInactive;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectPIDetailsDBAccessInt32DataTableOut = (DBAccess dba, int projectId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(ProjectCheckedOutFieldName, typeof(int));
                dataTable.Columns.Add(ProjectCheckedOutDateFieldName, typeof(DateTime));
                dataTable.Columns.Add(ProjectResourceNameFieldName, typeof(string));

                var dataRow = dataTable.NewRow();
                dataRow[ProjectCheckedOutFieldName] = DummyProjectCheckedOut;
                dataRow[ProjectCheckedOutDateFieldName] = DummyProjectCheckedOutDate;
                dataRow[ProjectResourceNameFieldName] = DummyProjectResourceName;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectCostTypeOperationsDBAccessInt32DataTableOut = (DBAccess dba, int costTypeId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeOperationIdFieldName, typeof(int));
                dataTable.Columns.Add(CostTypeOperationOperationFieldName, typeof(int));

                var dataRow = dataTable.NewRow();
                dataRow[CostTypeOperationIdFieldName] = DummyCostTypeOperationId;
                dataRow[CostTypeOperationOperationFieldName] = DummyCostTypeOperationOperation;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectCostCategoriesDBAccessInt32DataTableOut = (DBAccess dba, int nCostType, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostTypeIdFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryUidFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryIdFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryNameFieldName, typeof(string));
                dataTable.Columns.Add(CostCategoryLevelFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryUomFieldName, typeof(string));

                dataTable.Rows.Add(
                    CreateCostCategoryRow(
                        dataTable.NewRow(),
                        DummyCostTypeId1,
                        DummyCostCategoryUid1,
                        DummyCostCategoryId1,
                        DummyCostCategoryName1,
                        DummyCostCategoryLevel1,
                        DummyCostCategoryUom1));

                dataTable.Rows.Add(
                    CreateCostCategoryRow(
                        dataTable.NewRow(),
                        DummyCostTypeId2,
                        DummyCostCategoryUid2,
                        DummyCostCategoryId2,
                        DummyCostCategoryName2,
                        DummyCostCategoryLevel2,
                        DummyCostCategoryUom2));

                dataTable.Rows.Add(
                    CreateCostCategoryRow(
                        dataTable.NewRow(),
                        DummyCostTypeId3,
                        DummyCostCategoryUid3,
                        DummyCostCategoryId3,
                        DummyCostCategoryName3,
                        DummyCostCategoryLevel3,
                        DummyCostCategoryUom3));

                dataTable.Rows.Add(
                    CreateCostCategoryRow(
                        dataTable.NewRow(),
                        DummyCostTypeId4,
                        DummyCostCategoryUid4,
                        DummyCostCategoryId4,
                        DummyCostCategoryName4,
                        DummyCostCategoryLevel3,
                        DummyCostCategoryUom4));

                dataTable.Rows.Add(
                    CreateCostCategoryRow(
                        dataTable.NewRow(),
                        DummyCostTypeId5,
                        DummyCostCategoryUid5,
                        DummyCostCategoryId5,
                        DummyCostCategoryName5,
                        DummyCostCategoryLevel2,
                        DummyCostCategoryUom5));

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectPeriodsRatesDBAccessInt32DataTableOut = (DBAccess dba, int calendarId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(PeriodRateCostCategoryUidFieldName, typeof(int));
                dataTable.Columns.Add(PeriodRatePeriodIdFieldName, typeof(int));
                dataTable.Columns.Add(PeriodRateFteConvFieldName, typeof(int));
                dataTable.Columns.Add(PeriodRateRateFieldName, typeof(double));

                var dataRow = dataTable.NewRow();
                dataRow[PeriodRateCostCategoryUidFieldName] = DummyCostCategoryUid1;
                dataRow[PeriodRatePeriodIdFieldName] = DummyPeriodId1;
                dataRow[PeriodRateFteConvFieldName] = DummyPeriodRateFteConv;
                dataRow[PeriodRateRateFieldName] = DummyPeriodRateRate;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectPeriodsCostValuesDBAccessInt32Int32Int32DataTableOut = (DBAccess dba, int calendarId, int costTypeId, int projectId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostCategoryUidFieldName, typeof(int));
                dataTable.Columns.Add(PeriodCostPeriodIdFieldName, typeof(int));
                dataTable.Columns.Add(PeriodCostValueFieldName, typeof(double));
                dataTable.Columns.Add(PeriodCostCostFieldName, typeof(double));

                var dataRow = dataTable.NewRow();
                dataRow[CostCategoryUidFieldName] = DummyCostCategoryUid1;
                dataRow[PeriodCostPeriodIdFieldName] = DummyPeriodId1;
                dataRow[PeriodCostValueFieldName] = DummyPeriodCostValue;
                dataRow[PeriodCostCostFieldName] = DummyPeriodCostCost;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.GetDiscountRateDBAccessInt32 = (DBAccess dba, int projectId) => DummyDiscountRate;
            ShimdbaEditCosts.SelectCostCategoryDataDBAccessInt32Int32Int32DataTableOut = (DBAccess dba, int calendarId, int costTypeId, int projectId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostCategoryUidFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryIdFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryNameFieldName, typeof(string));
                dataTable.Columns.Add(CostCategoryLevelFieldName, typeof(int));
                dataTable.Columns.Add(CostCategoryUomFieldName, typeof(string));
                dataTable.Columns.Add(SeqFieldName, typeof(int));
                dataTable.Columns.Add(UsedFieldName, typeof(int));
                dataTable.Columns.Add(NamedRateUidFieldName, typeof(int));
                dataTable.Columns.Add(NamedRateNameFieldName, typeof(string));

                for (var i = 0; i < 5; i++)
                {
                    var si = (i + 1).ToString("0");
                    dataTable.Columns.Add($"OC_0{si}");
                    dataTable.Columns.Add($"LV_0{si}");
                    dataTable.Columns.Add($"LVF_0{si}");
                    dataTable.Columns.Add($"TEXT_0{si}");
                }

                dataTable.Rows.Add(
                    CreateCostCategoryDataRow(
                        dataTable.NewRow(),
                        DummyCostCategoryUid1,
                        DummyCostCategoryId1,
                        DummyCostCategoryName1,
                        DummyCostCategoryLevel1,
                        DummyCostCategoryUom1,
                        0,
                        1,
                        DummyNamedRateId,
                        DummyNamedRateName));

                dataTable.Rows.Add(
                    CreateCostCategoryDataRow(
                        dataTable.NewRow(),
                        DummyCostCategoryUid2,
                        DummyCostCategoryId2,
                        DummyCostCategoryName2,
                        DummyCostCategoryLevel2,
                        DummyCostCategoryUom2,
                        1,
                        1,
                        DummyNamedRateId,
                        DummyNamedRateName));

                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.SelectPeriodsCostDetailsValuesDBAccessInt32Int32Int32DataTableOut = (DBAccess dba, int calendarId, int costTypeId, int projectId, out DataTable dataTable) =>
            {
                dataTable = new DataTable();
                dataTable.Columns.Add(CostCategoryUidFieldName, typeof(int));
                dataTable.Columns.Add(PeriodCostPeriodIdFieldName, typeof(int));
                dataTable.Columns.Add(PeriodCostValueFieldName, typeof(double));
                dataTable.Columns.Add(PeriodCostCostFieldName, typeof(double));
                dataTable.Columns.Add(CostCategorySeqFieldName, typeof(int));

                var dataRow = dataTable.NewRow();
                dataRow[CostCategoryUidFieldName] = DummyCostCategoryUid1;
                dataRow[PeriodCostPeriodIdFieldName] = DummyPeriodId1;
                dataRow[PeriodCostValueFieldName] = DummyPeriodCostValue;
                dataRow[PeriodCostCostFieldName] = DummyPeriodCostCost;
                dataRow[CostCategorySeqFieldName] = 1;
                dataTable.Rows.Add(dataRow);

                return StatusEnum.rsSuccess;
            };
        }

        private DataRow CreateCostCategoryRow(DataRow row, int costTypeId, int costCategoryUid, int costCategoryId, string costCategoryName, int costCategoryLevel, string costCategoryUom)
        {
            row[CostTypeIdFieldName] = costTypeId;
            row[CostCategoryUidFieldName] = costCategoryUid;
            row[CostCategoryIdFieldName] = costCategoryId;
            row[CostCategoryNameFieldName] = costCategoryName;
            row[CostCategoryLevelFieldName] = costCategoryLevel;
            row[CostCategoryUomFieldName] = costCategoryUom;
            return row;
        }

        private DataRow CreateCostCategoryDataRow(
            DataRow row,
            int costCategoryUid,
            int costCategoryId,
            string costCategoryName,
            int costCategoryLevel,
            string costCategoryUom,
            int seq,
            int used,
            int namedRateUid,
            string nameRateName)
        {
            row[CostCategoryUidFieldName] = costCategoryUid;
            row[CostCategoryIdFieldName] = costCategoryId;
            row[CostCategoryNameFieldName] = costCategoryName;
            row[CostCategoryLevelFieldName] = costCategoryLevel;
            row[CostCategoryUomFieldName] = costCategoryUom;
            row[SeqFieldName] = seq;
            row[UsedFieldName] = used;
            row[NamedRateUidFieldName] = namedRateUid;
            row[NamedRateNameFieldName] = nameRateName;

            for (var i = 0; i < 5; i++)
            {
                var si = (i + 1).ToString("0");
                row[$"OC_0{si}"] = i * 100 + costCategoryUid;
                row[$"LV_0{si}"] = $"{costCategoryUid}LV_0{si}";
                row[$"LVF_0{si}"] = $"{costCategoryUid}LVF_0{si}";
                row[$"TEXT_0{si}"] = $"{costCategoryUid}TEXT_0{si}";
            }

            return row;
        }

        private void CustomFieldSelectAllType()
        {
            ShimdbaEditCosts.SelectCostCustomFieldsDBAccessInt32DataTableOut = (DBAccess dba, int nCostTypeId, out DataTable dataTable) =>
            {
                dataTable = CreateDataTableCustomField();

                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11801));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11802));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11803));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11804));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11805));

                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11811));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11812));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11813));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11814));
                dataTable.Rows.Add(CreateCustomFieldRow(dataTable.NewRow(), CustomFieldId11815));

                return StatusEnum.rsSuccess;
            };
        }

        private static DataTable CreateDataTableCustomField()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CustomFieldIdFieldName, typeof(int));
            dataTable.Columns.Add(CostTypeIdFieldName, typeof(int));
            dataTable.Columns.Add(CustomFieldFieldIdFieldName, typeof(int));
            dataTable.Columns.Add(CustomFieldEditableFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldVisibleFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldIdentityFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldRequiredFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldFrozenFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldAttrNameFieldName, typeof(string));
            dataTable.Columns.Add(CustomFieldAttrLookupOnlyFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldAttrUidFieldName, typeof(int));
            dataTable.Columns.Add(CustomFieldAttrLeafOnlyFieldName, typeof(bool));
            dataTable.Columns.Add(CustomFieldAttrUseFullNameFieldName, typeof(bool));
            return dataTable;
        }

        private static DataRow CreateCustomFieldRow(DataRow dataRow, int fieldId)
        {
            dataRow[CustomFieldIdFieldName] = DummyCustomFieldId;
            dataRow[CostTypeIdFieldName] = DummyCostTypeId1;
            dataRow[CustomFieldFieldIdFieldName] = fieldId;
            dataRow[CustomFieldEditableFieldName] = DummyCustomFieldEditable;
            dataRow[CustomFieldVisibleFieldName] = DummyCustomFieldVisible;
            dataRow[CustomFieldIdentityFieldName] = DummyCustomFieldIdentity;
            dataRow[CustomFieldRequiredFieldName] = DummyCustomFieldRequired;
            dataRow[CustomFieldFrozenFieldName] = DummyCustomFieldFrozen;
            dataRow[CustomFieldAttrNameFieldName] = DummyCustomFieldName + fieldId;
            dataRow[CustomFieldAttrLookupOnlyFieldName] = DummyCustomFieldLookupOnly;
            dataRow[CustomFieldAttrUidFieldName] = DummyCustomFieldLookupId;
            dataRow[CustomFieldAttrLeafOnlyFieldName] = DummyCustomFieldLeafOnly;
            dataRow[CustomFieldAttrUseFullNameFieldName] = DummyCustomFieldUseFullName;

            return dataRow;
        }

        private static List<string> ExpectedContentsGetEditCostsLayout()
        {
            return new List<string>()
            {
                $"<C Name=\"W\" Type=\"Text\" CanEdit=\"0\" CanMove=\"0\" Defaults=\"{{Items:[{{Name:'0',Text:'[None]',Value:'0_'}},{{Name:'{DummyNamedRateId}',Text:'{DummyNamedRateName}',Value:'{DummyNamedRateId}_{DummyNamedRateName}'}}]}}\" />",
                $"<C Name=\"Z{DummyCustomFieldId}\" Type=\"Text\" CanEdit=\"0\" CanMove=\"0\" Defaults=\"{{Items:[{{Name:'0',Text:'[None]',Value:'0_'}},{{Name:'{DummyLookupItemId}',Text:'{DummyLookupItemFullName}',Value:'{DummyLookupItemId}_{DummyLookupItemFullName}'}}]}}\" MinWidth=\"30\" />",
                "<C Name=\"rowid\" Type=\"Int\" Visible=\"0\" />",
                $"<C Name=\"P{DummyPeriodId1}\" Simple=\"13\" Width=\"0\" CanResize=\"0\" ShowHint=\"0\" />",
                $"<C Name=\"Q{DummyPeriodId1}\" Type=\"Float\" EditFormat=\"0.##\" Format=\",0.##;&lt;span style='color:red;'&gt;-,0.##&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"40\" Current=\"1\" />",
                $"<C Name=\"F{DummyPeriodId1}\" Type=\"Float\" EditFormat=\"0.###\" Format=\",0.000;&lt;span style='color:red;'&gt;-,0.000&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"45\" />",
                $"<C Name=\"C{DummyPeriodId1}\" Type=\"Float\" EditFormat=\"0.##\" Format=\",0;&lt;span style='color:red;'&gt;-,0&lt;/span&gt;;\" AltFormat=\",0.00;&lt;span style='color:red;'&gt;-,0.00&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"50\" Width=\"70\" />",
                $"<C Name=\"P{DummyPeriodId2}\" Simple=\"13\" Width=\"0\" CanResize=\"0\" ShowHint=\"0\" />",
                $"<C Name=\"Q{DummyPeriodId2}\" Type=\"Float\" EditFormat=\"0.##\" Format=\",0.##;&lt;span style='color:red;'&gt;-,0.##&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"40\" Current=\"1\" />",
                $"<C Name=\"F{DummyPeriodId2}\" Type=\"Float\" EditFormat=\"0.###\" Format=\",0.000;&lt;span style='color:red;'&gt;-,0.000&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"45\" />",
                $"<C Name=\"C{DummyPeriodId2}\" Type=\"Float\" EditFormat=\"0.##\" Format=\",0;&lt;span style='color:red;'&gt;-,0&lt;/span&gt;;\" AltFormat=\",0.00;&lt;span style='color:red;'&gt;-,0.00&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"50\" Width=\"70\" />",
                "<C Name=\"PQ\" Simple=\"13\" Width=\"0\" CanResize=\"0\" ShowHint=\"0\" />",
                "<C Name=\"TQ\" Type=\"Float\" Format=\",#.##;&lt;span style=\'color:red;\'&gt;-,#.##&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"90\" />",
                "<C Name=\"TC\" Type=\"Float\" Format=\",0;&lt;span style=\'color:red;\'&gt;-,0&lt;/span&gt;;\" AltFormat=\",0.00;&lt;span style=\'color:red;\'&gt;-,0.00&lt;/span&gt;;\" CanMove=\"0\" MinWidth=\"25\" Width=\"90\" />",
                $"<Header CategoryVisible=\"-1\" Spanned=\"-1\" uom=\" \" W=\" \" Z{DummyCustomFieldId}=\" \" P{DummyPeriodId1}Span=\"4\" P{DummyPeriodId1}=\" {DummyPeriodName1}\" C{DummyPeriodId1}=\" {DummyPeriodName1}\" P{DummyPeriodId2}Span=\"4\" P{DummyPeriodId2}=\" {DummyPeriodName2}\" C{DummyPeriodId2}=\" {DummyPeriodName2}\" PQSpan=\"3\" PQ=\" Full Totals\" TC=\" Full Totals\" />",
                $"<Header id=\"Header\" uom=\" UoM \" W=\" Named Rate \" Z{DummyCustomFieldId}=\" {DummyCustomFieldName} \" P{DummyPeriodId1}=\"\" Q{DummyPeriodId1}=\" Qty \" F{DummyPeriodId1}=\" FTE \" C{DummyPeriodId1}=\" Cost \" P{DummyPeriodId2}=\"\" Q{DummyPeriodId2}=\" Qty \" F{DummyPeriodId2}=\" FTE \" C{DummyPeriodId2}=\" Cost \" TQ=\" Qty \" TC=\" Cost \" />"
            };
        }
    }
}