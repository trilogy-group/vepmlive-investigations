using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.ModelCacheTests
{
    public partial class ModelCacheTests
    {
        private const string LoadScenariosMethodName = "LoadScenarios";
        private const string LoadTargetsMethodName = "LoadTargets";
        private const string ApplyUserOptionsMethodName = "ApplyUserOptions";
        private const string StashRateCacheMethodName = "StashRateCache";
        private const string InitalLoadDataMethodName = "InitalLoadData";
        private const string BuildCustomFilterListsMethodName = "BuildCustomFilterLists";
        private const string AddTotalEntryMethodName = "AddTotalEntry";
        private const string AddColEntryMethodName = "AddColEntry";
        private const string DoSnGStuffMethodName = "DoSnGStuff";
        private const string SortCollectionMethodName = "SortCollection";
        private const string ConCatCollectionMethodName = "ConCatCollection";
        private const string SetHighlevelFilterFlagMethodName = "SetHighlevelFilterFlag";
        private const string GetShortCatUIDMethodName = "GetShortCatUID";
        private const string GetLookUpStringMethodName = "GetLookUpString";
        private const string ProcessAndCreateDistplayListsMethodName = "ProcessAndCreateDistplayLists";
        private const string BuildTotalsKeyMethodName = "BuildTotalsKey";
        private const string SortAndGroupCollectionMethodName = "SortAndGroupCollection";
        private const string RollUpMethodName = "RollUp";
        private const string SetSelectedForRowMethodName = "SetSelectedForRow";
        private const string GetTopGridMethodName = "GetTopGrid";
        private const string GetTopGridLayoutMethodName = "GetTopGridLayout";
        private const string GetTopGridDataMethodName = "GetTopGridData";

        [TestMethod]
        public void LoadScenarios_WhenCalled_PopulatesDetailData()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 0;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var periodIndicator = new int[100];
            var piData = new PIData(10)
            {
                PI_Name = DummyString,
                oStartDate = now,
                oFinishDate = now,
                m_PI_Extra_data = new string[257],
                m_PI_Format_Extra_data = new string[] { DummyString }
            };
            var dataItem = new DataItem()
            {
                Name = DummyString
            };
            var catItem = new CatItemData(10)
            {
                Name = DummyString,
                FullName = DummyString,
                MC_Val = DummyString,
            };
            var scenario = new Dictionary<int, DataItem>()
            {
                [1] = dataItem,
                [2] = dataItem,
                [3] = dataItem,
                [4] = dataItem
            };
            var pids = new Dictionary<string, PIData>()
            {
                ["1 -1"] = piData,
                ["1 1"] = piData,
                ["4 4"] = piData
            };
            var costTypes = new Dictionary<int, DataItem>()
            {
                [4] = dataItem
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [4] = catItem
            };
            var periodData = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    StartDate = now.AddDays(1)
                }
            };
            var detailsData = new Dictionary<string, DetailRowData>();

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    readIntHit += 1;
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => $"{DummyString}{readIntHit}";
            ShimSqlDb.ReadDoubleValueObject = _ => readIntHit;
            ShimSqlDb.ReadDecimalValueObject = _ => readIntHit;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimModelCache.AllInstances.StashRateCache = _ =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.GetLookUpStringInt32Int32Ref = (ModelCache instance, int index, ref int lUID) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_sCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_sOtherCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, scenario);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, costTypes);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_CostCat_rolly", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periodData);
            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailsData);
            privateObject.SetFieldOrProperty("perind", nonPublicInstance, periodIndicator);

            // Act
            privateObject.Invoke(
                LoadScenariosMethodName,
                nonPublicInstance,
                new object[] { sqlConnection, "1,2", true, true });
            pids = (Dictionary<string, PIData>)privateObject.GetFieldOrProperty("m_PIs", nonPublicInstance);
            detailsData = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_detaildata", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => pids.Count.ShouldBe(5),
                () => detailsData.Count.ShouldBe(6),
                () => validations.ShouldBe(43));
        }

        [TestMethod]
        public void LoadTargets_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var readIntHit = 0;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var periodIndicator = new int[100];
            var detailRow = new DetailRowData(10)
            {
                Scenario_ID = -4,
                BC_SEQ = 4,
                sUoM = string.Empty
            };
            var targetData = new Dictionary<string, DetailRowData>()
            {
                [DummyString] = detailRow
            };

            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    readIntHit += 1;
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadStringValueObject = _ => string.Empty;
            ShimSqlDb.ReadDoubleValueObject = _ => readIntHit;
            ShimSqlDb.ReadDecimalValueObject = _ => readIntHit;
            ShimSqlDb.ReadIntValueObject = _ => readIntHit;
            ShimSqlDb.ReadDateValueObject = _ => now;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimModelCache.AllInstances.StripNumStringRef = (ModelCache instance, ref string input) =>
            {
                validations += 1;
                return DummyInt;
            };

            privateObject.SetFieldOrProperty("m_targetdata", nonPublicInstance, targetData);
            privateObject.SetFieldOrProperty("m_sCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_sOtherCostTypes", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("maxp", nonPublicInstance, 10);
            privateObject.SetFieldOrProperty("perind", nonPublicInstance, periodIndicator);

            // Act
            var actual = privateObject.Invoke(LoadTargetsMethodName, nonPublicInstance, new object[] { sqlConnection, DummyString });
            targetData = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_targetdata", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyInt),
                () => targetData.Count.ShouldBe(4),
                () => validations.ShouldBe(9));
        }

        [TestMethod]
        public void ApplyUserOptions_WhenCalled_SetsPeriodMode()
        {
            // Arrange
            var validations = 0;
            var periodMode = new int[500];

            ShimModelCache.AllInstances.LoadAnyScenarios = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 200);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, 100);
            privateObject.SetFieldOrProperty("m_drag_minp", nonPublicInstance, 300);
            privateObject.SetFieldOrProperty("m_drag_maxp", nonPublicInstance, 50);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 400);
            privateObject.SetFieldOrProperty("m_PeriodMode", nonPublicInstance, periodMode);

            // Act
            privateObject.Invoke(ApplyUserOptionsMethodName, publicInstance, new object[] { });
            var actual = (int[])privateObject.GetFieldOrProperty("m_PeriodMode", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count(x => x == 0).ShouldBe(399),
                () => actual.Count(x => x == 2).ShouldBe(2),
                () => actual.Count(x => x == 1).ShouldBe(99),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void StashRateCache_WhenCalled_UpdatesRateCache()
        {
            // Arrange
            var detailData = new Dictionary<string, DetailRowData>()
            {
                ["1"] = new DetailRowData(200)
                {
                    BC_UID = 1,
                    m_rt = 1
                },
                ["2"] = new DetailRowData(200)
                {
                    BC_UID = 2,
                    m_rt = 2
                }
            };
            var rateCache = new Dictionary<string, RateFTECache>()
            {
                [$"K1 1"] = new RateFTECache(200)
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [2] = new CatItemData(200)
            };
            var rates = new Dictionary<int, RateTable>()
            {
                [2] = new RateTable(200)
            };

            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_ratecache", nonPublicInstance, rateCache);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 200);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_Rates", nonPublicInstance, rates);

            // Act
            privateObject.Invoke(StashRateCacheMethodName, nonPublicInstance, new object[] { });
            rateCache = (Dictionary<string, RateFTECache>)privateObject.GetFieldOrProperty("m_ratecache", nonPublicInstance);

            // Assert
            rateCache.ShouldSatisfyAllConditions(
                () => rateCache.Count.ShouldBe(2),
                () => rateCache[$"K2 2"].ShouldNotBeNull());
        }

        [TestMethod]
        public void InitalLoadData_MCBIdEmpty_ReturnsInteger1()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var ticket = DummyString;
            var model = DummyString;
            var versions = DummyString;
            var resId = DummyString;
            var viewId = DummyString;

            ShimModelCache.AllInstances.GrabPidsFromTickectSqlConnectionStringStringOutBooleanOutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string ticketParam, out string sPids, out bool bNoneMissing, out int PICount) =>
            {
                validations += 1;
                sPids = string.Empty;
                bNoneMissing = true;
                PICount = 1;
                return 1;
            };
            ShimModelCache.AllInstances.GrabCostViewInfoSqlConnectionStringInt32OutStringOutStringOutInt32OutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string sCostView, out int lCB_ID, out string sCostTypes, out string sOtherCostTypes, out int lMinP, out int lMaxP) =>
            {
                validations += 10;
                lCB_ID = -1;
                sCostTypes = DummyString;
                sOtherCostTypes = DummyString;
                lMinP = 10;
                lMaxP = 100;
                return 1;
            };
            ShimModelCache.AllInstances.GrabModelInfoSqlConnectionStringInt32OutInt32OutStringOutStringOut = (ModelCache instance, SqlConnection oDataAccess, string sModel, out int lCB_ID, out int lSelFID, out string sCostTypes, out string sOtherCostTypes) =>
            {
                validations += 20;
                lCB_ID = 1;
                lSelFID = 1;
                sCostTypes = string.Empty;
                sOtherCostTypes = string.Empty;
                return 1;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                InitalLoadDataMethodName,
                publicInstance,
                new object[] { sqlConnection, ticket, model, versions, resId, viewId });
            var loadMessage = (string)privateObject.GetFieldOrProperty("m_loadmsg", nonPublicInstance);
            var mode = (int)privateObject.GetFieldOrProperty("m_mode", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(1),
                () => mode.ShouldBe(1001),
                () => loadMessage.ShouldBe("No Cost Breakdown (CB_IB) specified"),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void InitalLoadData_CostTypesEmpty_ReturnsInteger2()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var ticket = DummyString;
            var model = DummyString;
            var versions = DummyString;
            var resId = DummyString;
            var viewId = string.Empty;

            ShimModelCache.AllInstances.GrabPidsFromTickectSqlConnectionStringStringOutBooleanOutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string ticketParam, out string sPids, out bool bNoneMissing, out int PICount) =>
            {
                validations += 1;
                sPids = DummyString;
                bNoneMissing = true;
                PICount = 1;
                return 1;
            };
            ShimModelCache.AllInstances.GrabCostViewInfoSqlConnectionStringInt32OutStringOutStringOutInt32OutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string sCostView, out int lCB_ID, out string sCostTypes, out string sOtherCostTypes, out int lMinP, out int lMaxP) =>
            {
                validations += 10;
                lCB_ID = 1;
                sCostTypes = string.Empty;
                sOtherCostTypes = string.Empty;
                lMinP = 10;
                lMaxP = 100;
                return 1;
            };
            ShimModelCache.AllInstances.GrabModelInfoSqlConnectionStringInt32OutInt32OutStringOutStringOut = (ModelCache instance, SqlConnection oDataAccess, string sModel, out int lCB_ID, out int lSelFID, out string sCostTypes, out string sOtherCostTypes) =>
            {
                validations += 20;
                lCB_ID = 1;
                lSelFID = 1;
                sCostTypes = string.Empty;
                sOtherCostTypes = string.Empty;
                return 1;
            };

            // Act
            var actual = (int)privateObject.Invoke(
                InitalLoadDataMethodName,
                publicInstance,
                new object[] { sqlConnection, ticket, model, versions, resId, viewId });
            var loadMessage = (string)privateObject.GetFieldOrProperty("m_loadmsg", nonPublicInstance);
            var mode = (int)privateObject.GetFieldOrProperty("m_mode", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(2),
                () => mode.ShouldBe(1000),
                () => loadMessage.ShouldBe("No Cost Types specified"),
                () => validations.ShouldBe(21));
        }

        [TestMethod]
        public void InitalLoadData_CostTypesNotEmpty_ReturnsInteger0()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var ticket = DummyString;
            var model = DummyString;
            var versions = DummyString;
            var resId = DummyString;
            var viewId = DummyString;
            var maxArraySize = 200;
            var now = DateTime.Now;
            var views = new List<DataItem>()
            {
                new DataItem()
                {
                    UID = 1
                }
            };
            var detailData = new Dictionary<string, DetailRowData>()
            {
                ["1"] = new DetailRowData(maxArraySize)
                {
                    HasValues = true,
                    sKey = DummyString
                }
            };
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    StartDate = now,
                    FinishDate = now,
                    PeriodID = 1
                }
            };

            ShimModelCache.AllInstances.GrabPidsFromTickectSqlConnectionStringStringOutBooleanOutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string ticketParam, out string sPids, out bool bNoneMissing, out int PICount) =>
            {
                validations += 1;
                sPids = DummyString;
                bNoneMissing = true;
                PICount = 1;
                return 1;
            };
            ShimModelCache.AllInstances.GrabCostViewInfoSqlConnectionStringInt32OutStringOutStringOutInt32OutInt32Out = (ModelCache instance, SqlConnection oDataAccess, string sCostView, out int lCB_ID, out string sCostTypes, out string sOtherCostTypes, out int lMinP, out int lMaxP) =>
            {
                validations += 10;
                lCB_ID = 1;
                sCostTypes = DummyString;
                sOtherCostTypes = DummyString;
                lMinP = 0;
                lMaxP = 0;
                return 1;
            };
            ShimModelCache.AllInstances.GrabModelInfoSqlConnectionStringInt32OutInt32OutStringOutStringOut = (ModelCache instance, SqlConnection oDataAccess, string sModel, out int lCB_ID, out int lSelFID, out string sCostTypes, out string sOtherCostTypes) =>
            {
                validations += 20;
                lCB_ID = 1;
                lSelFID = 1;
                sCostTypes = string.Empty;
                sOtherCostTypes = string.Empty;
                return 1;
            };
            ShimModelCache.AllInstances.GrabViewsAndStatusSqlConnectionStringInt32 = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.ReadPeriodsSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadCatItemsSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadCustomFieldsSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadCostTypeNamesSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadModelNamesStringStringSqlConnectionListOfItemDefnRef = (ModelCache instance, string modelParam, string sWResID, SqlConnection oDataAccess, ref List<ItemDefn> optlist) => { };
            ShimModelCache.AllInstances.ReadStagesSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadExtraPifieldsSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadPILevelDataSqlConnectionDateTimeOutDateTimeOut = (ModelCache instance, SqlConnection oDataAccess, out DateTime earlystart, out DateTime latefinish) =>
            {
                validations += 1;
                earlystart = now;
                latefinish = now;
            };
            ShimModelCache.AllInstances.ReadCostCustomFieldsAndDataSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadBudgetBandsSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.ReadModelTargetsSqlConnectionString = (_, _1, _2) => { };
            ShimModelCache.AllInstances.ReadRateTableSqlConnection = (_, __) => { };
            ShimModelCache.AllInstances.LoadScenariosSqlConnectionStringBooleanBoolean = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.StashRateCache = _ => { };
            ShimModelCache.AllInstances.BuildCustomFilterLists = _ => { };
            ShimModelCache.AllInstances.SelectUserViewDataSqlConnectionInt32 = (_, _1, _2) => DummyString;
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_CT_Views", nonPublicInstance, views);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, 200);
            privateObject.SetFieldOrProperty("m_dtMin", nonPublicInstance, now);
            privateObject.SetFieldOrProperty("m_dtMax", nonPublicInstance, now);
            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);

            // Act
            var actual = (int)privateObject.Invoke(
                InitalLoadDataMethodName,
                publicInstance,
                new object[] { sqlConnection, ticket, model, versions, resId, viewId });
            var loadMessage = (string)privateObject.GetFieldOrProperty("m_loadmsg", nonPublicInstance);
            var mode = (int)privateObject.GetFieldOrProperty("m_mode", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => mode.ShouldBe(1001),
                () => loadMessage.ShouldBe(string.Empty),
                () => validations.ShouldBe(15));
        }

        [TestMethod]
        public void BuildCustomFilterLists_WhenCalled_SetsDataItems()
        {
            // Arrange
            var validations = 0;
            var filters = new Dictionary<int, DataItem>[200];
            var customFields = new Dictionary<int, CustomFieldData>()
            {
                [1] = new CustomFieldData()
                {
                    FieldID = 11810,
                    ListItems = new Dictionary<int, ListItemData>()
                }
            };
            var pids = new Dictionary<string, PIData>()
            {
                ["1 1"] = new PIData(500)
                {
                    PI_Name = "juan-Test project ",
                    ScenarioID = -1,
                    PI_ID = 1,
                }
            };
            var extraFieldTypes = new int[500];
            var costTypes = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = new CatItemData(500)
                {
                    Level = 10,
                    Category = 1,
                    UID = 1,
                    Rates = null
                }
            };
            var detailData = new Dictionary<string, DetailRowData>()
            {
                ["1"] = new DetailRowData(500)
                {
                    PROJECT_ID = 1,
                    Scenario_ID = 1,
                    BC_UID = 1,
                    sUoM = string.Empty
                }
            };
            var rateCache = new Dictionary<string, RateFTECache>();
            var periods = new Dictionary<int, PeriodData>();
            var sngFids = new int[10, 10];

            ShimModelCache.AllInstances.FormatExtraDisplayStringInt32 = (_, _1, _2) => DummyString;
            ShimModelCache.AllInstances.ApplyUserOptions = _ =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.SortCollectionInt32 = (_, __) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.ConCatCollectionInt32Int32String = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.SetHighlevelFilterFlag = _ =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.AddTotalEntryStringInt32Boolean = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.DoSnGStuffInt32StringBoolean = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.AddColEntryStringInt32BooleanBooleanBoolean = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_CustFields", nonPublicInstance, customFields);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_allow_grouping", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filters);
            privateObject.SetFieldOrProperty("m_ExtraFieldTypes", nonPublicInstance, extraFieldTypes);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, costTypes);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_CostCat_rolly", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_targetdata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_ratecache", nonPublicInstance, rateCache);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, sngFids);

            // Act
            privateObject.Invoke(BuildCustomFilterListsMethodName, nonPublicInstance, new object[] { });
            var ctaRoot = (List<DataItem>)privateObject.GetFieldOrProperty("m_CTARoot", nonPublicInstance);
            var bcList = (List<ListItemData>)privateObject.GetFieldOrProperty("m_BC_List", nonPublicInstance);
            var bcRoleList = (List<ListItemData>)privateObject.GetFieldOrProperty("m_BC_Role_List", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => ctaRoot.Count.ShouldBe(1),
                () => bcList.Count.ShouldBe(1),
                () => bcRoleList.Count.ShouldBe(2),
                () => validations.ShouldBe(57));
        }

        [TestMethod]
        public void AddTotalEntry_WhenCalled_PopulatesTotalRoot()
        {
            // Arrange
            const string expectedName = "expectedName";
            const bool expectedSelect = true;
            const int expectedUid = 111;
            var totalRoot = new List<DataItem>();

            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, totalRoot);

            // Act
            privateObject.Invoke(AddTotalEntryMethodName, nonPublicInstance, new object[] { expectedName, expectedUid, expectedSelect });
            var actual = (List<DataItem>)privateObject.GetFieldOrProperty("m_TotalRoot", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[0].Name.ShouldBe(expectedName),
                () => actual[0].bSelected.ShouldBe(expectedSelect),
                () => actual[0].UID.ShouldBe(expectedUid));
        }

        [TestMethod]
        public void AddColEntry_WhenCalled_SetsColRoots()
        {
            // Arrange
            const string expectedName = "expectedName";
            const bool BdSelect = true;
            const bool BtSelect = true;
            const bool AddToTotal = true;
            const int expectedFid = 111;
            var sortFieldList = new List<SortFieldDefn>();

            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, sortFieldList);
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, sortFieldList);

            // Act
            privateObject.Invoke(AddColEntryMethodName, nonPublicInstance, new object[] { expectedName, expectedFid, BdSelect, AddToTotal, BtSelect });
            var colRoot = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_DetColRoot", nonPublicInstance);
            var totalColRoot = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_TotColRoot", nonPublicInstance);

            // Assert
            colRoot.ShouldSatisfyAllConditions(
                () => colRoot.Count.ShouldBe(2),
                () => totalColRoot.Count.ShouldBe(2),
                () => colRoot.Count(x => x.name.Equals(expectedName)).ShouldBe(2),
                () => totalColRoot.Count(x => x.name.Equals(expectedName)).ShouldBe(2));
        }

        [TestMethod]
        public void DoSnGStuff_WhenCalled_SetsFields()
        {
            // Arrange
            const string expectedName = "expectedName";
            const bool AddToTotal = true;
            const int expectedFid = 111;
            var sortFieldList = new List<SortFieldDefn>();

            privateObject.SetFieldOrProperty("m_DetFields", nonPublicInstance, sortFieldList);
            privateObject.SetFieldOrProperty("m_TotFields", nonPublicInstance, sortFieldList);

            // Act
            privateObject.Invoke(DoSnGStuffMethodName, nonPublicInstance, new object[] { expectedFid, expectedName, AddToTotal });
            var fields = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_DetFields", nonPublicInstance);
            var totalFields = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_TotFields", nonPublicInstance);

            // Assert
            fields.ShouldSatisfyAllConditions(
                () => fields.Count.ShouldBe(2),
                () => totalFields.Count.ShouldBe(2),
                () => fields.Count(x => x.name.Equals(expectedName)).ShouldBe(2),
                () => totalFields.Count(x => x.name.Equals(expectedName)).ShouldBe(2));
        }

        [TestMethod]
        public void SortCollection_WhenCalled_SetsGrouping()
        {
            // Arrange
            var validations = 0;
            var key = 0;
            var dataItem = new DataItem()
            {
                UID = 0,
                Name = DummyString,
                Desc = DummyString
            };
            var filter = new Dictionary<int, DataItem>[]
            {
                new Dictionary<int, DataItem>()
                {
                    [1] = dataItem,
                    [2] = dataItem
                }
            };

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortItemsInt32 = (_, __) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return DummyInt;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                uid = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filter);

            // Act
            privateObject.Invoke(SortCollectionMethodName, nonPublicInstance, new object[] { key });
            filter = (Dictionary<int, DataItem>[])privateObject.GetFieldOrProperty("m_filter_sel", nonPublicInstance);

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => filter.Length.ShouldBe(1),
                () => filter[key].Count.ShouldBe(1),
                () => filter[key][0].Name.ShouldBe("No Value"),
                () => validations.ShouldBe(7));
        }

        [TestMethod]
        public void ConCatCollection_WhenCalled_UpdatesFilters()
        {
            // Arrange
            const int key = 0;
            const int groupId = 111;
            const string groupName = "GroupName";
            var dataItem = new DataItem()
            {
                UID = 0,
                Name = DummyString,
                Desc = DummyString
            };
            var filters = new Dictionary<int, DataItem>[]
            {
                new Dictionary<int, DataItem>()
                {
                    [1] = dataItem,
                    [2] = dataItem
                }
            };
            var emptyList = new List<DataItem>();

            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filters);
            privateObject.SetFieldOrProperty("m_filterList", nonPublicInstance, emptyList);
            privateObject.SetFieldOrProperty("m_filterRoot", nonPublicInstance, emptyList);

            // Act
            privateObject.Invoke(ConCatCollectionMethodName, nonPublicInstance, new object[] { key, groupId, groupName });
            var filterList = (List<DataItem>)privateObject.GetFieldOrProperty("m_filterList", nonPublicInstance);
            var filterRoot = (List<DataItem>)privateObject.GetFieldOrProperty("m_filterRoot", nonPublicInstance);

            // Assert
            filterList.ShouldSatisfyAllConditions(
                () => filterList.Count.ShouldBe(4),
                () => filterRoot.Count.ShouldBe(4),
                () => filterList.Count(x => x.level.Equals(2)).ShouldBe(2),
                () => filterList.Count(x => x.level.Equals(1)).ShouldBe(2));
        }

        [TestMethod]
        public void SetHighlevelFilterFlag_WhenCalled_ReturnsDictionary()
        {
            // Arrange
            var dataItemLevel1 = new DataItem()
            {
                UID = 0,
                Name = DummyString,
                level = 1
            };
            var dataItem2 = new DataItem()
            {
                UID = 1,
                Name = DummyString,
                level = 2,
                bSelected = false
            };
            var dataItem3 = new DataItem()
            {
                UID = 2,
                Name = DummyString,
                level = 2,
                bSelected = true,
                group = 11820
            };
            var dataItem4 = new DataItem()
            {
                UID = 3,
                Name = DummyString,
                level = 2,
                bSelected = true,
                group = 10
            };
            var filterList = new List<DataItem>()
            {
                dataItemLevel1,
                dataItem2,
                dataItem3,
                dataItem4
            };

            privateObject.SetFieldOrProperty("m_filterList", nonPublicInstance, filterList);

            // Act
            privateObject.Invoke(SetHighlevelFilterFlagMethodName, nonPublicInstance, new object[] { });
            var actual = (Dictionary<string, DataItem>)privateObject.GetFieldOrProperty("m_selcln", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(2),
                () => actual[$"K {10} {3}"].ShouldNotBeNull(),
                () => actual[$"K {11820} {DummyString}"].ShouldNotBeNull());
        }

        [TestMethod]
        public void GetShortCatUID_CategoryEqualsUid_ReturnsInteger()
        {
            // Arrange
            const int category = 11;
            const int uid = 11;
            var catItem = new CatItemData(100)
            {
                Category = category,
                UID = uid
            };
            var costCategory = new Dictionary<int, CatItemData>()
            {
                [category] = catItem
            };

            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCategory);

            // Act
            var actual = (int)privateObject.Invoke(GetShortCatUIDMethodName, nonPublicInstance, new object[] { catItem });

            // Assert
            actual.ShouldBe(uid);
        }

        [TestMethod]
        public void GetShortCatUID_keyPresent_ReturnsInteger()
        {
            // Arrange
            const int category = 11;
            const int uid = 111;
            var catItem = new CatItemData(100)
            {
                Category = category,
                UID = uid
            };
            var costCategory = new Dictionary<int, CatItemData>()
            {
                [category] = catItem
            };

            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCategory);

            // Act
            var actual = (int)privateObject.Invoke(GetShortCatUIDMethodName, nonPublicInstance, new object[] { catItem });

            // Assert
            actual.ShouldBe(uid);
        }

        [TestMethod]
        public void GetShortCatUID_keyNotPresent_Returns0()
        {
            // Arrange
            const int category = 11;
            const int uid = 111;
            var catItem = new CatItemData(100)
            {
                Category = category,
                UID = uid
            };
            var costCategory = new Dictionary<int, CatItemData>()
            {
                [uid] = catItem
            };

            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCategory);

            // Act
            var actual = (int)privateObject.Invoke(GetShortCatUIDMethodName, nonPublicInstance, new object[] { catItem });

            // Assert
            actual.ShouldBe(0);
        }

        [TestMethod]
        public void GetLookUpString_Value1_ReturnsFullName()
        {
            // Arrange
            const int uid = 1;
            const int index = 0;
            const int custInt = 1;
            const string name = "Name";
            const string fullName = "FullName";
            var customerFull = new int[] { custInt };
            var customerDictionary = new Dictionary<int, ListItemData>[]
            {
                new Dictionary<int, ListItemData>()
                {
                    [uid] = new ListItemData()
                    {
                        Name = name,
                        FullName = fullName
                    }
                }
            };

            privateObject.SetFieldOrProperty("m_cust_lk", nonPublicInstance, customerDictionary);
            privateObject.SetFieldOrProperty("m_cust_full", nonPublicInstance, customerFull);

            // Act
            var actual = (string)privateObject.Invoke(GetLookUpStringMethodName, nonPublicInstance, new object[] { index, uid });

            // Assert
            actual.ShouldBe(fullName);
        }

        [TestMethod]
        public void GetLookUpString_Value0_ReturnsName()
        {
            // Arrange
            const int uid = 1;
            const int index = 0;
            const int custInt = 0;
            const string name = "Name";
            const string fullName = "FullName";
            var customerFull = new int[] { custInt };
            var customerDictionary = new Dictionary<int, ListItemData>[]
            {
                new Dictionary<int, ListItemData>()
                {
                    [uid] = new ListItemData()
                    {
                        Name = name,
                        FullName = fullName
                    }
                }
            };

            privateObject.SetFieldOrProperty("m_cust_lk", nonPublicInstance, customerDictionary);
            privateObject.SetFieldOrProperty("m_cust_full", nonPublicInstance, customerFull);

            // Act
            var actual = (string)privateObject.Invoke(GetLookUpStringMethodName, nonPublicInstance, new object[] { index, uid });

            // Assert
            actual.ShouldBe(name);
        }

        //[TestMethod]
        //public void ProcessAndCreateDistplayLists_WhenCalled_Returns()
        //{
        //    // Arrange
        //    const int max = 500;
        //    const int applyTarget = 1;
        //    var validations = 0;
        //    var detailData = new Dictionary<string, DetailRowData>()
        //    {
        //        [DummyString] = new DetailRowData(max)
        //        {
        //            HasValues = true
        //        }
        //    };
        //    var target = new List<DataItem>()
        //    {
        //        new DataItem()
        //        {
        //            UID = applyTarget,
        //            Name = DummyString
        //        }
        //    };
        //    var snGroup = new int[][]
        //    {
        //        new int[] { 1 }
        //    };
        //    var snFids = new int[][]
        //    {
        //        new int[] { (int)FieldIDs.PI_FID }
        //    };

        //    ShimModelCache.AllInstances.IsFilteredDetailRowData = (_, __) => true;
        //    ShimModelCache.AllInstances.BuildTotalsKey = (_, __) => DummyString;
        //    ShimModelCache.AllInstances.CopyOverTotFields = _ =>
        //    {
        //        validations += 1;
        //    };
        //    ShimModelCache.AllInstances.ProcessTargets = _ =>
        //    {
        //        validations += 1;
        //    };
        //    ShimModelCache.AllInstances.ProcessTotals = _ =>
        //    {
        //        validations += 1;
        //    };
        //    ShimModelCache.AllInstances.SortAndGroupCollection = (ModelCache instance, List<DetailRowData> clnIn, int index, out bool bGrouped) =>
        //    {
        //        validations += 1;
        //        bGrouped = true;
        //        return null;
        //    };
        //    ShimModelCache.AllInstances.RollUp = (_, _1, _2, _3, _4, _5) =>
        //    {
        //        validations += 1;
        //    };

        //    privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
        //    privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);
        //    privateObject.SetFieldOrProperty("m_Target", nonPublicInstance, target);
        //    privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, applyTarget);
        //    privateObject.SetFieldOrProperty("m_bCTAMode", nonPublicInstance, false);
        //    privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);

        //    // Act
        //    privateObject.Invoke(ProcessAndCreateDistplayListsMethodName, nonPublicInstance, new object[] { });
        //    var targetNames = (string)privateObject.GetFieldOrProperty("m_tarnames", nonPublicInstance);

        //    // Assert
        //    validations.ShouldSatisfyAllConditions(
        //        () => targetNames.ShouldBe(DummyString),
        //        () => validations.ShouldBe(10));
        //}

        [TestMethod]
        public void BuildTotalsKey_WhenCalled_ReturnsString()
        {
            // Arrange
            const int expected = 111;
            var rowData = new DetailRowData(100)
            {
                PROJECT_ID = expected
            };
            var totalRoot = new List<DataItem>()
            {
                new DataItem()
                {
                    UID = (int)FieldIDs.PI_FID,
                    bSelected = true
                }
            };

            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, totalRoot);

            // Act
            var actual = (string)privateObject.Invoke(BuildTotalsKeyMethodName, nonPublicInstance, new object[] { rowData });

            // Assert
            actual.ShouldBe($"K {expected}");
        }

        [TestMethod]
        public void SortAndGroupCollection_FidsSet1_ReturnsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 100;
            var validations = 0;
            var dataList = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    Internal_ID = 1,
                    bRealone = true,
                    m_par = 1,
                    bGotChildren = true,
                    CT_ID = 1,
                    Scenario_ID = 1
                }
            };
            var snGroup = new int[1, 3]
            {
                { 1, 2, 3 }
            };
            var snFids = new int[1, 3]
            {
                { 2, 1, 3 }
            };
            var snAsc = new int[1, 3]
            {
                { 1, 1, 1 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [DummyString] = new PIData(max)
                {
                    PI_Name = DummyString,
                    Scenario_name = DummyString,
                    Internal_ID = 1
                }
            };
            var dataItemDictionary = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineGroupingValueInt32Int32Int32StringString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortGroupInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return 1;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                group = 0;
                uid = 1;
                level = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, snFids);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, snAsc);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, dataItemDictionary);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, dataItemDictionary);

            // Act
            var actual = (List<DetailRowData>)privateObject.Invoke(SortAndGroupCollectionMethodName, nonPublicInstance, new object[] { dataList, index, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void SortAndGroupCollection_FidsSet2_ReturnsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 100;
            var validations = 0;
            var dataList = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    Internal_ID = 1,
                    bRealone = true,
                    m_par = 1,
                    bGotChildren = true,
                    CT_ID = 1,
                    Scenario_ID = 1
                }
            };
            var snGroup = new int[1, 3]
            {
                { 1, 2, 3 }
            };
            var snFids = new int[1, 3]
            {
                { 4, 10, 11 }
            };
            var snAsc = new int[1, 3]
            {
                { 1, 1, 1 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [DummyString] = new PIData(max)
                {
                    PI_Name = DummyString,
                    Scenario_name = DummyString,
                    Internal_ID = 1
                }
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = new CatItemData(max)
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var dataItemDict = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var filter = new List<Dictionary<int, DataItem>>();

            for (var i = 1; i <= 12; i++)
            {
                filter.Add(dataItemDict);
            }

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineGroupingValueInt32Int32Int32StringString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortGroupInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DoNotSortGroupInt32 = (_, _1) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return 1;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                group = 0;
                uid = 1;
                level = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, snFids);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, snAsc);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filter.ToArray());

            // Act
            var actual = (List<DetailRowData>)privateObject.Invoke(SortAndGroupCollectionMethodName, nonPublicInstance, new object[] { dataList, index, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void SortAndGroupCollection_FidsSet3_ReturnsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 100;
            var validations = 0;
            var now = DateTime.Now;
            var dataList = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    Internal_ID = 1,
                    bRealone = true,
                    m_par = 1,
                    bGotChildren = true,
                    CT_ID = 1,
                    Scenario_ID = 1,
                    Det_Start = now,
                    m_tot1 = 10
                }
            };
            var snGroup = new int[1, 3]
            {
                { 1, 2, 3 }
            };
            var snFids = new int[1, 3]
            {
                { 5, 12, 13 }
            };
            var snAsc = new int[1, 3]
            {
                { 1, 1, 1 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [DummyString] = new PIData(max)
                {
                    PI_Name = DummyString,
                    Scenario_name = DummyString,
                    Internal_ID = 1
                }
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = new CatItemData(max)
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var dataItemDict = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var filter = new List<Dictionary<int, DataItem>>();

            for (var i = 1; i <= 13; i++)
            {
                filter.Add(dataItemDict);
            }

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineGroupingValueInt32Int32Int32StringString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortGroupInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DoNotSortGroupInt32 = (_, _1) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return 1;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                group = 0;
                uid = 1;
                level = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, snFids);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, snAsc);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filter.ToArray());

            // Act
            var actual = (List<DetailRowData>)privateObject.Invoke(SortAndGroupCollectionMethodName, nonPublicInstance, new object[] { dataList, index, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => validations.ShouldBe(12));
        }

        [TestMethod]
        public void SortAndGroupCollection_FidsSet4_ReturnsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 100;
            var validations = 0;
            var now = DateTime.Now;
            var dataList = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    Internal_ID = 1,
                    bRealone = true,
                    m_par = 1,
                    bGotChildren = true,
                    CT_ID = 1,
                    Scenario_ID = 1,
                    Det_Start = now,
                    m_tot1 = 10,
                    Role_Name = DummyString,
                    TXVal = new string[]
                    {
                        DummyString,
                        DummyString,
                        DummyString
                    },
                    OCVal = new int[max]
                }
            };
            var snGroup = new int[1, 3]
            {
                { 1, 2, 3 }
            };
            var snFids = new int[1, 3]
            {
                { 8, 11801, 11811 }
            };
            var snAsc = new int[1, 3]
            {
                { 1, 1, 1 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [DummyString] = new PIData(max)
                {
                    PI_Name = DummyString,
                    Scenario_name = DummyString,
                    Internal_ID = 1
                }
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = new CatItemData(max)
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var dataItemDict = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var filter = new List<Dictionary<int, DataItem>>();

            for (var i = 1; i <= max; i++)
            {
                filter.Add(dataItemDict);
            }

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineGroupingValueInt32Int32Int32StringString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortGroupInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DoNotSortGroupInt32 = (_, _1) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return 1;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                group = 0;
                uid = 1;
                level = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, snFids);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, snAsc);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filter.ToArray());

            // Act
            var actual = (List<DetailRowData>)privateObject.Invoke(SortAndGroupCollectionMethodName, nonPublicInstance, new object[] { dataList, index, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => validations.ShouldBe(14));
        }

        [TestMethod]
        public void SortAndGroupCollection_FidsSet5_ReturnsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 500;
            var validations = 0;
            var now = DateTime.Now;
            var dataList = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    Internal_ID = 1,
                    PROJECT_ID = 1,
                    bRealone = true,
                    m_par = 1,
                    bGotChildren = true,
                    CT_ID = 1,
                    Scenario_ID = 1,
                    Det_Start = now,
                    m_tot1 = 10,
                    Role_Name = DummyString,
                    TXVal = new string[]
                    {
                        DummyString,
                        DummyString,
                        DummyString
                    },
                    OCVal = new int[max]
                }
            };
            var snGroup = new int[1, 3]
            {
                { 1, 2, 3 }
            };
            var snFids = new int[1, 3]
            {
                { 150, 200, 1 }
            };
            var snAsc = new int[1, 3]
            {
                { 1, 1, 1 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [$"1 -1"] = new PIData(max)
                {
                    PI_Name = DummyString,
                    Scenario_name = DummyString,
                    Internal_ID = 1,
                    ScenarioID = -1,
                    m_PI_Extra_data = (new string[max]).Select(x => "1").ToArray()
                }
            };
            var costCat = new Dictionary<int, CatItemData>()
            {
                [1] = new CatItemData(max)
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var dataItemDict = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = 1,
                    Name = DummyString
                }
            };
            var scenario = new Dictionary<int, DataItem>()
            {
                [-1] = new DataItem()
                {
                    Name = DummyString
                }
            };
            var filter = new List<Dictionary<int, DataItem>>();
            var extraFieldTypes = (new int[max]).Select(x => 9911).ToArray();

            for (var i = 1; i <= max; i++)
            {
                filter.Add(dataItemDict);
            }

            ShimSortAndGroup.AllInstances.NewGrouping = _ =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineGroupingValueInt32Int32Int32StringString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DefineItemValuesInt32Int32Int32Int32StringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.SortGroupInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.DoNotSortGroupInt32 = (_, _1) =>
            {
                validations += 1;
            };
            ShimSortAndGroup.AllInstances.CalculateGrouplingListInt32Int32 = (_, _1, _2) =>
            {
                validations += 1;
                return 1;
            };
            ShimSortAndGroup.AllInstances.ElementDetailsInt32Int32RefInt32RefInt32RefInt32RefStringRef = (SortAndGroup instance, int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal) =>
            {
                validations += 1;
                group = 3;
                uid = 1;
                level = 1;
                return -1;
            };
            ShimSortAndGroup.AllInstances.FinishedWithGrouping = _ =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.FormatExtraSortStringInt32 = (_, _1, _2) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimModelCache.AllInstances.FormatExtraDisplayStringInt32 = (_, _1, _2) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, snFids);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, snAsc);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_filter_sel", nonPublicInstance, filter.ToArray());
            privateObject.SetFieldOrProperty("m_ExtraFieldTypes", nonPublicInstance, extraFieldTypes);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, scenario);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);

            // Act
            var actual = (List<DetailRowData>)privateObject.Invoke(SortAndGroupCollectionMethodName, nonPublicInstance, new object[] { dataList, index, true });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => validations.ShouldBe(19));
        }

        [TestMethod]
        public void RollUp_IndexEqualsG1_SetsDataList()
        {
            // Arrange
            const int index = 0;
            const int max = 500;
            var validations = 0;
            var now = DateTime.Now;
            var dataList1 = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    bRealone = true,
                    m_par = 1,
                    g1 = 1,
                    g2 = 1,
                    Det_Start = now,
                    Det_Finish = now,
                    b_PIOver = true,
                    PROJECT_ID = 1,
                    Scenario_ID = 0,
                    bGotChildren = false
                }
            };
            var dataList2 = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    bRealone = true,
                    m_par = 1,
                    g1 = 10,
                    g2 = 1,
                    Det_Start = now,
                    Det_Finish = now,
                    b_PIOver = true,
                    PROJECT_ID = 1,
                    Scenario_ID = 0,
                    bGotChildren = false,
                    m_lev = 1
                },
                new DetailRowData(max)
                {
                    bRealone = true,
                    m_par = 1,
                    g1 = 10,
                    g2 = 1,
                    Det_Start = now,
                    Det_Finish = now,
                    b_PIOver = true,
                    PROJECT_ID = 1,
                    Scenario_ID = 0,
                    bGotChildren = false,
                    m_lev = 2
                }
            };
            var snGroup = new int[2, 3]
            {
                { 1, 2, 3 },
                { 1, 2, 3 }
            };
            var pids = new Dictionary<string, PIData>()
            {
                [$"1 -1"] = new PIData(max)
                {
                    StartDate = now,
                    FinishDate = now,
                    Internal_ID = 1,
                    ScenarioID = -1
                }
            };

            ShimModelCache.AllInstances.ProcessTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, snGroup);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_tgrid_displayed", nonPublicInstance, dataList2);
            privateObject.SetFieldOrProperty("m_bgrid_sorted", nonPublicInstance, dataList2);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 1);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);

            // Act
            privateObject.Invoke(RollUpMethodName, nonPublicInstance, new object[] { dataList1, true, index, 1, max });
            privateObject.Invoke(SetSelectedForRowMethodName, publicInstance, new object[] { "1" });

            // Assert
            validations.ShouldBe(1);
        }

        [TestMethod]
        public void GetTopGrid_WhenCalled_ReturnsString()
        {
            // Arrange
            var max = 500;
            var colRoot = new List<SortFieldDefn>();
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    PeriodName = DummyString
                }
            };
            var sortedGrid = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    bRealone = false,
                    bGotChildren = true,
                    m_lev = 1
                },
                new DetailRowData(max)
                {
                    bRealone = true,
                    bGotChildren = true,
                    m_lev = 1
                }
            };

            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_tgrid_sorted", nonPublicInstance, sortedGrid);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTopGridMethodName, publicInstance, new object[] { }));
            var displayedGrid = (List<DetailRowData>)privateObject.GetFieldOrProperty("m_tgrid_displayed", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count().ShouldBe(2),
                () => displayedGrid.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetTopGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            var max = 500;
            var colRoot = new List<SortFieldDefn>();
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    PeriodName = DummyString
                }
            };

            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("bShowGantt", nonPublicInstance, false);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTopGridLayoutMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Head").Elements("Header").Where(x => x.Attribute("P1C") != null).Count(x => x.Attribute("P1C").Value.Equals(DummyString)).ShouldBe(1));
        }

        [TestMethod]
        public void GetTopGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var max = 500;
            var colRoot = new List<SortFieldDefn>();
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    PeriodName = DummyString
                }
            };
            var sortedGrid = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    bRealone = false,
                    bGotChildren = true,
                    m_lev = 1
                },
                new DetailRowData(max)
                {
                    bRealone = true,
                    bGotChildren = true,
                    m_lev = 1
                }
            };

            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_tgrid_sorted", nonPublicInstance, sortedGrid);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTopGridDataMethodName, publicInstance, new object[] { }));
            var displayedGrid = (List<DetailRowData>)privateObject.GetFieldOrProperty("m_tgrid_displayed", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("FilterEmpty").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count().ShouldBe(2),
                () => displayedGrid.Count.ShouldBe(2));
        }
    }
}