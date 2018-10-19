using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

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
        public void BuildCustomFilterLists_WhenCalled_Returns()
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
    }
}