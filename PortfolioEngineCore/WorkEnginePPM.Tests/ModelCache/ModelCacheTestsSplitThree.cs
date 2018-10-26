using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.ModelCacheTests
{
    public partial class ModelCacheTests
    {
        private Dictionary<int, CatItemData> costCat;
        private Dictionary<int, DataItem> dataItemDictionary;
        private Dictionary<int, ListItemData> listItems;
        private Dictionary<int, CustomFieldData> customFields;
        private Dictionary<int, PeriodData> periods;
        private Dictionary<string, DetailRowData> targetData;
        private Dictionary<int, RateTable> rates;
        private const int max = 500;
        private const int one = 1;
        private const int two = 2;
        private const string GetBottomGridMethodName = "GetBottomGrid";
        private const string GetBottomGridLayoutMethodName = "GetBottomGridLayout";
        private const string GetBottomGridDataMethodName = "GetBottomGridData";
        private const string SetFTEModeMethodName = "SetFTEMode";
        private const string GetFTEModeMethodName = "GetFTEMode";
        private const string SetGanttModeMethodName = "SetGanttMode";
        private const string DoSetGroupingFlagMethodName = "DoSetGroupingFlag";
        private const string ProcessTotalsMethodName = "ProcessTotals";
        private const string CreatePsuedoTargetMethodName = "CreatePsuedoTarget";
        private const string ProcessTargetsMethodName = "ProcessTargets";
        private const string DoCopyVersionMethodName = "DoCopyVersion";
        private const string GetFilterGridLayoutMethodName = "GetFilterGridLayout";
        private const string GetFilterGridDataMethodName = "GetFilterGridData";
        private const string SetFilterDataMethodName = "SetFilterData";
        private const string IsFilteredMethodName = "IsFiltered";
        private const string GetTotalGridLayoutMethodName = "GetTotalGridLayout";
        private const string GetCTCmpGridDataMethodName = "GetCTCmpGridData";
        private const string SetCTCmpDataMethodName = "SetCTCmpData";
        private const string GetTotalGridDataMethodName = "GetTotalGridData";
        private const string SetTotColsbasedonTotalingMethodName = "SetTotColsbasedonTotaling";
        private const string SetTotalDataMethodName = "SetTotalData";
        private const string GetSortAndGroupMethodName = "GetSortAndGroup";
        private const string SetSortAndGroupMethodName = "SetSortAndGroup";
        private const string FormatWorkMethodName = "FormatWork";
        private const string FormatDurationMethodName = "FormatDuration";
        private const string GetColumnGridDataMethodName = "GetColumnGridData";
        private const string SetColumnOrderDataMethodName = "SetColumnOrderData";
        private const string GetVersionsPIListsMethodName = "GetVersionsPILists";
        private const string GetSaveVersionsMethodName = "GetSaveVersions";
        private const string GetTargetsMethodName = "GetTargets";
        private const string SaveVersionMethodName = "SaveVersion";
        private const string GetPeriodsandVersionsMethodName = "GetPeriodsandVersions";
        private const string SetPeriodsandVersionsMethodName = "SetPeriodsandVersions";
        private const string DeleteTargetMethodName = "DeleteTarget";
        private const string CreateTargetMethodName = "CreateTarget";
        private const string BuildCatJSonMethodName = "BuildCatJSon";
        private const string BuildCustFieldJSonMethodName = "BuildCustFieldJSon";
        private const string RatesAndCategoryMethodName = "RatesAndCategory";
        private const string PrepareTargetDataMethodName = "PrepareTargetData";

        private void SetupListsAndDictionaries()
        {
            periods = new Dictionary<int, PeriodData>();
            costCat = new Dictionary<int, CatItemData>()
            {
                [one] = new CatItemData(max)
                {
                    ID = one,
                    UID = one,
                    Level = one,
                    Role_UID = one,
                    MC_UID = one,
                    Category = one,
                    Name = DummyString,
                    UoM = DummyString,
                    FullName = DummyString,
                    MC_Val = DummyString,
                    Role_Name = DummyString,
                },
                [2] = new CatItemData(max)
                {
                    ID = two,
                    UID = two,
                    Level = two,
                    Role_UID = two,
                    MC_UID = two,
                    Category = two,
                    Name = DummyString,
                    UoM = DummyString,
                    FullName = DummyString,
                    MC_Val = DummyString,
                    Role_Name = DummyString,
                }
            };
            dataItemDictionary = new Dictionary<int, DataItem>()
            {
                [one] = new DataItem()
                {
                    UID = one,
                    Name = DummyString
                },
                [two] = new DataItem()
                {
                    UID = two,
                    Name = DummyString
                }
            };
            listItems = new Dictionary<int, ListItemData>()
            {
                [one] = new ListItemData()
                {
                    ID = one,
                    UID = one,
                    Level = one,
                    Name = DummyString,
                    FullName = DummyString,
                    InActive = true
                },
                [two] = new ListItemData()
                {
                    ID = two,
                    UID = two,
                    Level = two,
                    Name = DummyString,
                    FullName = DummyString,
                    InActive = true
                }
            };
            customFields = new Dictionary<int, CustomFieldData>()
            {
                [one] = new CustomFieldData()
                {
                    FieldID = one,
                    LookupOnly = one,
                    LookupID = one,
                    LeafOnly = one,
                    UseFullName = one,
                    Name = DummyString,
                    ListItems = listItems
                },
                [two] = new CustomFieldData()
                {
                    FieldID = two,
                    LookupOnly = two,
                    LookupID = two,
                    LeafOnly = two,
                    UseFullName = two,
                    Name = DummyString,
                    ListItems = listItems
                }
            };
            targetData = new Dictionary<string, DetailRowData>()
            {
                [one.ToString()] = new DetailRowData(max)
                {
                    Scenario_ID = one,
                    BC_UID = one,
                    CT_ID = one,
                    m_rt = one,
                },
                [two.ToString()] = new DetailRowData(max)
                {
                    Scenario_ID = two,
                    BC_UID = two,
                    CT_ID = two,
                    m_rt = two,
                }
            };
            rates = new Dictionary<int, RateTable>()
            {
                [one] = new RateTable(max)
                {
                    Name = DummyString
                },
                [two] = new RateTable(max)
                {
                    Name = DummyString
                }
            };
        }

        [TestMethod]
        public void GetBottomGrid_WhenCalled_Returns()
        {
            // Arrange
            var colRoot = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
                {
                    name = DummyString,
                    fid = 150
                }
            };
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
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_bgrid_sorted", nonPublicInstance, sortedGrid);
            privateObject.SetFieldOrProperty("m_target_sorted", nonPublicInstance, sortedGrid);
            privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, 1);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetBottomGridMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count().ShouldBe(2));
        }

        [TestMethod]
        public void GetBottomGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange
            var colRoot = new List<SortFieldDefn>();
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = new PeriodData()
                {
                    PeriodName = DummyString
                }
            };

            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("bShowGantt", nonPublicInstance, false);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, string.Empty);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetBottomGridLayoutMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Head").Elements("Header").Where(x => x.Attribute("P0C") != null).Count(x => x.Attribute("P0C").Value.Equals(DummyString)).ShouldBe(1));
        }

        [TestMethod]
        public void GetBottomGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var colRoot = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
                {
                    name = DummyString,
                    fid = 150
                }
            };
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
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, 0);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_bgrid_sorted", nonPublicInstance, sortedGrid);
            privateObject.SetFieldOrProperty("m_target_sorted", nonPublicInstance, sortedGrid);
            privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, 1);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetBottomGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").ShouldNotBeNull(),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count().ShouldBe(2));
        }

        [TestMethod]
        public void SetFTEMode_WhenCalled_SetsFieldValues()
        {
            // Arrange
            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("bShowFTEs", nonPublicInstance, false);

            // Act
            privateObject.Invoke(SetFTEModeMethodName, publicInstance, new object[] { DummyInt });
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);
            var showFte = (bool)privateObject.GetFieldOrProperty("bShowFTEs", nonPublicInstance);

            // Assert
            layoutCache.ShouldSatisfyAllConditions(
                () => layoutCache.ShouldBe(string.Empty),
                () => showFte.ShouldBe(true));
        }

        [TestMethod]
        public void GetFTEMode_ShowFteTrue_Returns1()
        {
            // Arrange
            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("bShowFTEs", nonPublicInstance, true);

            // Act
            var actual = (int)privateObject.Invoke(GetFTEModeMethodName, publicInstance, new object[] { });
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => layoutCache.ShouldBe(string.Empty),
                () => actual.ShouldBe(1));
        }

        [TestMethod]
        public void GetFTEMode_ShowFteTrue_Returns0()
        {
            // Arrange
            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("bShowFTEs", nonPublicInstance, false);

            // Act
            var actual = (int)privateObject.Invoke(GetFTEModeMethodName, publicInstance, new object[] { });
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => layoutCache.ShouldBe(string.Empty),
                () => actual.ShouldBe(0));
        }

        [TestMethod]
        public void SetGanttMode_GanttMode0_Returns0()
        {
            // Arrange
            const int ganttMode = 0;

            privateObject.SetFieldOrProperty("m_pi_top", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_allow_grouping", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_grouping_enabled", nonPublicInstance, true);

            // Act
            var actual = (int)privateObject.Invoke(SetGanttModeMethodName, publicInstance, new object[] { ganttMode });
            var showGantt = (bool)privateObject.GetFieldOrProperty("bShowGantt", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => showGantt.ShouldBe(false),
                () => actual.ShouldBe(0));
        }

        [TestMethod]
        public void SetGanttMode_GroupingEnabled_Returns1()
        {
            // Arrange
            const int ganttMode = 1;

            privateObject.SetFieldOrProperty("m_pi_top", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_allow_grouping", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_grouping_enabled", nonPublicInstance, true);

            // Act
            var actual = (int)privateObject.Invoke(SetGanttModeMethodName, publicInstance, new object[] { ganttMode });
            var showGantt = (bool)privateObject.GetFieldOrProperty("bShowGantt", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => showGantt.ShouldBe(true),
                () => actual.ShouldBe(1));
        }

        [TestMethod]
        public void SetGanttMode_GroupingDisabled_Returns2()
        {
            // Arrange
            const int ganttMode = 1;

            privateObject.SetFieldOrProperty("m_pi_top", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_allow_grouping", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_grouping_enabled", nonPublicInstance, false);

            // Act
            var actual = (int)privateObject.Invoke(SetGanttModeMethodName, publicInstance, new object[] { ganttMode });
            var showGantt = (bool)privateObject.GetFieldOrProperty("bShowGantt", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => showGantt.ShouldBe(true),
                () => actual.ShouldBe(2));
        }

        [TestMethod]
        public void SetGanttMode_AllowGroupingFalse_Returns0()
        {
            // Arrange
            const int ganttMode = 1;

            privateObject.SetFieldOrProperty("m_pi_top", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_allow_grouping", nonPublicInstance, false);
            privateObject.SetFieldOrProperty("m_grouping_enabled", nonPublicInstance, true);

            // Act
            var actual = (int)privateObject.Invoke(SetGanttModeMethodName, publicInstance, new object[] { ganttMode });
            var showGantt = (bool)privateObject.GetFieldOrProperty("bShowGantt", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => showGantt.ShouldBe(true),
                () => actual.ShouldBe(0));
        }

        [TestMethod]
        public void DoSetGroupingFlag_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            var groupMode = 111;

            privateObject.SetFieldOrProperty("m_grouping_enabled", nonPublicInstance, false);

            // Act
            privateObject.Invoke(DoSetGroupingFlagMethodName, publicInstance, new object[] { groupMode });
            var grouping = (bool)privateObject.GetFieldOrProperty("m_grouping_enabled", nonPublicInstance);

            // Assert
            grouping.ShouldBe(true);
        }

        [TestMethod]
        public void ProcessTotals_WhenCalled_ProcessesTotals()
        {
            // Arrange
            var totalDetails = new Dictionary<string, DetailRowData>()
            {
                [DummyString] = new DetailRowData(max)
                {
                    g1 = 11
                }
            };
            var filterSource = new List<DetailRowData>()
            {
                new DetailRowData(max)
                {
                    bSelected = true,
                    m_total_to = 1,
                    zCost = (new object[max +1]).Select(x => 1d).ToArray(),
                    zValue = (new object[max +1]).Select(x => 10d).ToArray(),
                    zFTE = (new object[max +1]).Select(x => 100d).ToArray()
                }
            };

            privateObject.SetFieldOrProperty("m_total_dets", nonPublicInstance, totalDetails);
            privateObject.SetFieldOrProperty("m_filtersource", nonPublicInstance, filterSource);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);

            // Act
            privateObject.Invoke(ProcessTotalsMethodName, nonPublicInstance, new object[] { });
            var actual = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_total_dets", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[DummyString].g1.ShouldBe(0),
                () => actual[DummyString].zCost.Sum().ShouldBe(500d),
                () => actual[DummyString].zValue.Sum().ShouldBe(5000d),
                () => actual[DummyString].zFTE.Sum().ShouldBe(50000d));
        }

        [TestMethod]
        public void CreatePsuedoTarget_WhenCalled_SetsTarget()
        {
            // Arrange
            var ctaRoot = new List<DataItem>()
            {
                new DataItem()
                {
                    bSelected = true,
                    Name = DummyString,
                    UID = DummyInt
                }
            };
            var detailData = new Dictionary<string, DetailRowData>()
            {
                [DummyString] = new DetailRowData(max)
                {
                    Scenario_ID = -1,
                    CT_ID = DummyInt
                }
            };

            privateObject.SetFieldOrProperty("m_CTARoot", nonPublicInstance, ctaRoot);
            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);

            // Act
            privateObject.Invoke(CreatePsuedoTargetMethodName, nonPublicInstance, new object[] { });
            var actual = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_targetdata", nonPublicInstance);
            var applyTarget = (int)privateObject.GetFieldOrProperty("m_apply_target", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual["K1 1"].Scenario_ID.ShouldBe(1),
                () => applyTarget.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessTargets_WhenCalled_SetsTargets()
        {
            // Arrange
            const string key = "K 1";
            var totalDetails = new Dictionary<string, DetailRowData>()
            {
                [key] = new DetailRowData(max)
                {
                    g1 = 11
                }
            };
            var targetData = new Dictionary<string, DetailRowData>()
            {
                [DummyString] = new DetailRowData(max)
                {
                    Scenario_ID = -1,
                    PROJECT_ID = 1,
                    bSelected = true,
                    m_total_to = 1,
                    zCost = (new object[max + 1]).Select(x => 1d).ToArray(),
                    zValue = (new object[max + 1]).Select(x => 10d).ToArray(),
                    zFTE = (new object[max + 1]).Select(x => 100d).ToArray()
                }
            };
            var totalRoot = new List<DataItem>()
            {
                new DataItem()
                {
                    bSelected = true,
                    UID = 1
                }
            };

            privateObject.SetFieldOrProperty("m_target_dets", nonPublicInstance, totalDetails);
            privateObject.SetFieldOrProperty("m_targetdata", nonPublicInstance, targetData);
            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, totalRoot);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);
            privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, -1);

            // Act
            privateObject.Invoke(ProcessTargetsMethodName, nonPublicInstance, new object[] { });
            var actual = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_target_dets", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual[key].g1.ShouldBe(0),
                () => actual[key].zCost.Sum().ShouldBe(500d),
                () => actual[key].zValue.Sum().ShouldBe(5000d),
                () => actual[key].zFTE.Sum().ShouldBe(50000d));
        }

        [TestMethod]
        public void DoCopyVersion_WhenCalled_CopiesFields()
        {
            // Arrange
            const int fromValue = DummyInt;
            const int toValue = 2;
            const int piValue = -10;
            var validations = 0;
            var now = DateTime.Now;
            var dataItem = new DataItem()
            {
                Name = DummyString
            };
            var scenario = new Dictionary<int, DataItem>()
            {
                [toValue] = dataItem
            };
            var detailData = new Dictionary<string, DetailRowData>()
            {
                ["1"] = new DetailRowData(max)
                {
                    Scenario_ID = fromValue,
                    CT_ID = DummyInt,
                    PROJECT_ID = piValue,
                    BC_UID = DummyInt,
                    BC_SEQ = DummyInt
                }
            };
            var piData = new PIData(max)
            {
                ScenarioID = fromValue,
                PI_Name = DummyString,
                oStartDate = now,
                oFinishDate = now,
                StartDate = now,
                FinishDate = now,
                PI_ID = piValue
            };
            var pids = new Dictionary<string, PIData>()
            {
                [$"{piValue} {fromValue}"] = piData
            };

            ShimModelCache.AllInstances.SetHighlevelFilterFlag = _ =>
            {
                validations += 1;
            };
            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, scenario);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);

            // Act
            privateObject.Invoke(DoCopyVersionMethodName, publicInstance, new object[] { fromValue.ToString(), toValue.ToString(), piValue.ToString() });
            var actualPids = (Dictionary<string, PIData>)privateObject.GetFieldOrProperty("m_PIs", nonPublicInstance);
            var actualDetails = (Dictionary<string, DetailRowData>)privateObject.GetFieldOrProperty("m_detaildata", nonPublicInstance);

            // Assert
            actualPids.ShouldSatisfyAllConditions(
                () => actualPids.Count.ShouldBe(2),
                () => actualDetails.Count.ShouldBe(2),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetFilterGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange and Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetFilterGridLayoutMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Panel").Attribute("Visible").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Cfg").Attribute("MainCol").Value.ShouldBe("Filtering"),
                () => actual.Element("Grid").Element("LeftCols").Elements("C").Count(x => x.Attribute("Name").Value.Equals("Filtering")).ShouldBe(1),
                () => actual.Element("Grid").Element("Header").Attribute("Filtering").Value.ShouldBe("Filter"));
        }

        [TestMethod]
        public void GetFilterGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                }
            };

            privateObject.SetFieldOrProperty("m_filterList", nonPublicInstance, filteredList);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetFilterGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("FilterEmpty").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count(x => x.Attribute("Filtering").Value.Equals(DummyString)).ShouldBe(3));
        }

        [TestMethod]
        public void SetFilterData_WhenCalled_ReturnsString()
        {
            // Arrange
            var validations = 0;
            var filteredData = "1 0 1";
            var dataItem = new DataItem()
            {
                level = DummyInt,
                Name = DummyString,
                bSelected = true,
                UID = DummyInt
            };
            var filteredList = new List<DataItem>()
            {
                dataItem,
                dataItem,
                dataItem
            };
            var scenario = new Dictionary<int, DataItem>()
            {
                [1] = dataItem,
                [2] = dataItem,
                [3] = dataItem,
            };

            ShimModelCache.AllInstances.SetHighlevelFilterFlag = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_filterList", nonPublicInstance, filteredList);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, scenario);

            // Act
            var actual = (string)privateObject.Invoke(SetFilterDataMethodName, publicInstance, new object[] { filteredData });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe($"{DummyInt},{DummyInt},{DummyInt}"),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void IsFiltered_GroupCondition1_Returns()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true,
                    bAllSelected = false,
                    UID = DummyInt,
                    group = 1
                }
            };
            var rowData = new DetailRowData(50)
            {
                PROJECT_ID = 1,
                TXVal = (new object[50]).Select(x => DummyString).ToArray()
            };

            privateObject.SetFieldOrProperty("m_filterRoot", nonPublicInstance, filteredList);
            privateObject.SetFieldOrProperty("m_selcln", nonPublicInstance, new Dictionary<string, DataItem>());

            // Act
            var actual = (bool)privateObject.Invoke(IsFilteredMethodName, nonPublicInstance, new object[] { rowData });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse());
        }

        [TestMethod]
        public void IsFiltered_GroupCondition2_Returns()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true,
                    bAllSelected = false,
                    UID = DummyInt,
                    group = 11811
                }
            };
            var rowData = new DetailRowData(50)
            {
                PROJECT_ID = 1,
                TXVal = (new object[50]).Select(x => DummyString).ToArray()
            };

            privateObject.SetFieldOrProperty("m_filterRoot", nonPublicInstance, filteredList);
            privateObject.SetFieldOrProperty("m_selcln", nonPublicInstance, new Dictionary<string, DataItem>());

            // Act
            var actual = (bool)privateObject.Invoke(IsFilteredMethodName, nonPublicInstance, new object[] { rowData });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse());
        }

        [TestMethod]
        public void IsFiltered_SelectedTrue_ReturnsTrue()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true,
                    bAllSelected = true,
                    UID = DummyInt,
                    group = 1
                }
            };
            var rowData = new DetailRowData(50)
            {
                PROJECT_ID = 1,
                TXVal = (new object[50]).Select(x => DummyString).ToArray()
            };

            privateObject.SetFieldOrProperty("m_filterRoot", nonPublicInstance, filteredList);
            privateObject.SetFieldOrProperty("m_selcln", nonPublicInstance, new Dictionary<string, DataItem>());

            // Act
            var actual = (bool)privateObject.Invoke(IsFilteredMethodName, nonPublicInstance, new object[] { rowData });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue());
        }

        [TestMethod]
        public void GetTotalGridLayout_WhenCalled_ReturnsString()
        {
            // Arrange and Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTotalGridLayoutMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Toolbar").Attribute("Visible").Value.ShouldBe("0"),
                () => actual.Element("Grid").Element("Panel").Attribute("Visible").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Cfg").Attribute("MainCol").Value.ShouldBe("Filtering"),
                () => actual.Element("Grid").Element("LeftCols").Elements("C").Count(x => x.Attribute("Name").Value.Equals("Filtering")).ShouldBe(1),
                () => actual.Element("Grid").Element("Header").Attribute("Filtering").Value.ShouldBe("Filter"));
        }

        [TestMethod]
        public void GetCTCmpGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                }
            };

            privateObject.SetFieldOrProperty("m_CTARoot", nonPublicInstance, filteredList);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetCTCmpGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("FilterEmpty").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count(x => x.Attribute("Filtering").Value.Equals(DummyString)).ShouldBe(3));
        }

        [TestMethod]
        public void SetCTCmpData_WhenCalled_Returns()
        {
            // Arrange
            const string cmpData = "1 0 1";
            var dataItemList = new List<DataItem>()
            {
                new DataItem(),
                new DataItem(),
                new DataItem(),
            };

            privateObject.SetFieldOrProperty("m_CTARoot", nonPublicInstance, dataItemList);

            // Act
            privateObject.Invoke(SetCTCmpDataMethodName, publicInstance, new object[] { cmpData });
            var actual = (List<DataItem>)privateObject.GetFieldOrProperty("m_CTARoot", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(3),
                () => actual.Count(x => x.bSelected).ShouldBe(2),
                () => actual.Count(x => !x.bSelected).ShouldBe(1));
        }

        [TestMethod]
        public void GetTotalGridData_WhenCalled_ReturnsString()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                },
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true
                }
            };

            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, filteredList);

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetTotalGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("FilterEmpty").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count(x => x.Attribute("Filtering").Value.Equals(DummyString)).ShouldBe(3));
        }

        [TestMethod]
        public void SetTotColsbasedonTotaling_WhenCalled_ReturnsString()
        {
            // Arrange
            var filteredList = new List<DataItem>()
            {
                new DataItem()
                {
                    level = DummyInt,
                    Name = DummyString,
                    bSelected = true,
                    UID = DummyInt
                }
            };
            var colRoot = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
                {
                    fid = DummyInt
                }
            };

            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, filteredList);
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, colRoot);
            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);

            // Act
            privateObject.Invoke(SetTotColsbasedonTotalingMethodName, nonPublicInstance, new object[] { });
            var actualcolRoot = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_TotColRoot", nonPublicInstance);
            var actualLayoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);

            // Assert
            actualcolRoot.ShouldSatisfyAllConditions(
                () => actualcolRoot.Count.ShouldBe(1),
                () => actualcolRoot[0].selected.ShouldBe(1),
                () => actualLayoutCache.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void SetTotalData_WhenCalled_SetSelectionsBoolean()
        {
            // Arrange
            var validations = 0;
            const string data = "1 0 1";
            var dataItemList = new List<DataItem>()
            {
                new DataItem(),
                new DataItem(),
                new DataItem(),
            };

            ShimModelCache.AllInstances.SetTotColsbasedonTotaling = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("m_TotalRoot", nonPublicInstance, dataItemList);

            // Act
            privateObject.Invoke(SetTotalDataMethodName, publicInstance, new object[] { data });
            var actualcolRoot = (List<DataItem>)privateObject.GetFieldOrProperty("m_TotalRoot", nonPublicInstance);

            // Assert
            actualcolRoot.ShouldSatisfyAllConditions(
                () => actualcolRoot.Count.ShouldBe(3),
                () => actualcolRoot.Count(x => x.bSelected).ShouldBe(2),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetSortAndGroup_DetFieldsNull_SetsGroupDefinition()
        {
            // Arrange
            var groupDefinition = new SortGroupDefn();
            var detFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
            };
            var totalFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn(),
                new SortFieldDefn()
            };
            var customIntArray = new int[2, 3]
            {
                { 1, 1, 1 },
                { 4, 4, 4 }
            };

            privateObject.SetFieldOrProperty("m_initial_zoom", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_loadmsg", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_loaddatareturn", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_lowlevelDataCount", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_PI_Count", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_GotAllPIs", nonPublicInstance, false);
            privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_detShowToLevel", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_totShowToLevel", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_TotFields", nonPublicInstance, totalFields);
            privateObject.SetFieldOrProperty("m_DetFields", nonPublicInstance, null);

            // Act
            testObject.GetSortAndGroup(ref groupDefinition);

            // Assert
            groupDefinition.ShouldSatisfyAllConditions(
                () => groupDefinition.ViewZoomTo.ShouldBe(DummyString),
                () => groupDefinition.errMsg.ShouldBe(DummyString),
                () => groupDefinition.LoadReturnCode.ShouldBe(DummyInt),
                () => groupDefinition.HaveLowlevelData.ShouldBe(DummyInt),
                () => groupDefinition.NumPIs.ShouldBe(DummyInt),
                () => groupDefinition.MissingPIs.ShouldBe(1),
                () => groupDefinition.TotalsCmp.ShouldBe(1),
                () => groupDefinition.DetFields.Length.ShouldBe(0),
                () => groupDefinition.TotFields.Length.ShouldBe(0),
                () => groupDefinition.DetRows.Count(x => x == null).ShouldBe(3),
                () => groupDefinition.TotRows.Count(x => x == null).ShouldBe(3));
        }

        [TestMethod]
        public void GetSortAndGroup_DetFieldsNotNull_SetsGroupDefinition()
        {
            // Arrange
            var groupDefinition = new SortGroupDefn();
            var detFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
            };
            var totalFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn(),
                new SortFieldDefn()
            };
            var customIntArray = new int[2, 3]
            {
                { 1, 1, 1 },
                { 4, 4, 4 }
            };

            privateObject.SetFieldOrProperty("m_initial_zoom", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_loadmsg", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_loaddatareturn", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_lowlevelDataCount", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_PI_Count", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_GotAllPIs", nonPublicInstance, false);
            privateObject.SetFieldOrProperty("m_apply_target", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_detShowToLevel", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_totShowToLevel", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_TotFields", nonPublicInstance, totalFields);
            privateObject.SetFieldOrProperty("m_DetFields", nonPublicInstance, detFields);

            // Act
            testObject.GetSortAndGroup(ref groupDefinition);

            // Assert
            groupDefinition.ShouldSatisfyAllConditions(
                () => groupDefinition.ViewZoomTo.ShouldBe(DummyString),
                () => groupDefinition.errMsg.ShouldBe(DummyString),
                () => groupDefinition.LoadReturnCode.ShouldBe(DummyInt),
                () => groupDefinition.HaveLowlevelData.ShouldBe(DummyInt),
                () => groupDefinition.NumPIs.ShouldBe(DummyInt),
                () => groupDefinition.MissingPIs.ShouldBe(1),
                () => groupDefinition.TotalsCmp.ShouldBe(1),
                () => groupDefinition.DetFields.Length.ShouldBe(1),
                () => groupDefinition.TotFields.Length.ShouldBe(2),
                () => groupDefinition.DetRows.Count(x => x.fid.Equals(1)).ShouldBe(3),
                () => groupDefinition.TotRows.Count(x => x.fid.Equals(4)).ShouldBe(3),
                () => groupDefinition.DetRows.Count(x => x.decf.Equals(1)).ShouldBe(3),
                () => groupDefinition.TotRows.Count(x => x.decf.Equals(4)).ShouldBe(3),
                () => groupDefinition.DetRows.Count(x => x.grpf.Equals(1)).ShouldBe(3),
                () => groupDefinition.TotRows.Count(x => x.grpf.Equals(4)).ShouldBe(3));
        }

        [TestMethod]
        public void SetSortAndGroup_WhenCalled_Returns()
        {
            // Arrange
            const int value1 = 4;
            const int value2 = 10;
            var validations = 0;
            var detRowDefn = new SortRowDefn()
            {
                fid = value1,
                decf = value1,
                grpf = value1
            };
            var totRowDefn = new SortRowDefn()
            {
                fid = value2,
                decf = value2,
                grpf = value2
            };
            var groupDefinition = new SortGroupDefn()
            {
                DetShowToLevel = DummyInt,
                TotShowToLevel = DummyInt,
                DetRows = new SortRowDefn[3]
                {
                    detRowDefn,
                    detRowDefn,
                    detRowDefn,
                },
                TotRows = new SortRowDefn[3]
                {
                    totRowDefn,
                    totRowDefn,
                    totRowDefn,
                }
            };
            var customIntArray = new int[2, 3];

            ShimModelCache.AllInstances.ProcessAndCreateDistplayLists = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_SnGFids", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGAsc", nonPublicInstance, customIntArray);
            privateObject.SetFieldOrProperty("m_SnGGrp", nonPublicInstance, customIntArray);

            // Act
            privateObject.Invoke(SetSortAndGroupMethodName, publicInstance, new object[] { groupDefinition });
            var detShowToLevel = (int)privateObject.GetFieldOrProperty("m_detShowToLevel", nonPublicInstance);
            var totShowToLevel = (int)privateObject.GetFieldOrProperty("m_totShowToLevel", nonPublicInstance);
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);
            var fids = (int[,])privateObject.GetFieldOrProperty("m_SnGFids", nonPublicInstance);
            var ascs = (int[,])privateObject.GetFieldOrProperty("m_SnGAsc", nonPublicInstance);
            var groups = (int[,])privateObject.GetFieldOrProperty("m_SnGGrp", nonPublicInstance);

            // Assert
            detShowToLevel.ShouldSatisfyAllConditions(
                () => detShowToLevel.ShouldBe(DummyInt),
                () => totShowToLevel.ShouldBe(DummyInt),
                () => layoutCache.ShouldBe(string.Empty),
                () => fids[0, 2].ShouldBe(value1),
                () => fids[1, 2].ShouldBe(value2),
                () => ascs[0, 2].ShouldBe(value1),
                () => ascs[1, 2].ShouldBe(value2),
                () => groups[0, 2].ShouldBe(value1),
                () => groups[1, 2].ShouldBe(value2),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void FormatWork_HoursZero_ReturnsEmptyString()
        {
            // Arrange
            const double hours = 0d;

            // Act
            var actual = (string)privateObject.Invoke(FormatWorkMethodName, nonPublicInstance, new object[] { hours });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void FormatDuration_HoursZero_ReturnsEmptyString()
        {
            // Arrange
            const double minutes = 0;

            // Act
            var actual = (string)privateObject.Invoke(FormatDurationMethodName, nonPublicInstance, new object[] { minutes });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetColumnGridData_WhenCalled_ReturnsString()
        {
            // Arrange and Act
            var actual = XDocument.Parse((string)privateObject.Invoke(GetColumnGridDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Grid").Element("Cfg").Attribute("FilterEmpty").Value.ShouldBe("1"),
                () => actual.Element("Grid").Element("Body").Element("I").Elements("I").Count(x => x.Attribute("Filtering").Value.Equals(string.Empty)).ShouldBe(50));
        }

        [TestMethod]
        public void GetColumnData_DetFieldsNull_SetsGroupDefinition()
        {
            // Arrange
            var groupDefinition = new SortGroupDefn();
            var detFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
            };
            var totalFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn(),
                new SortFieldDefn()
            };

            privateObject.SetFieldOrProperty("m_DetFreeze", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_TotFreeze", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, totalFields);
            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, detFields);

            // Act
            testObject.GetColumnData(ref groupDefinition);

            // Assert
            groupDefinition.ShouldSatisfyAllConditions(
                () => groupDefinition.DetFreeze.ShouldBe(DummyInt),
                () => groupDefinition.TotFreeze.ShouldBe(DummyInt),
                () => groupDefinition.DetFields.Length.ShouldBe(1),
                () => groupDefinition.TotFields.Length.ShouldBe(2));
        }

        [TestMethod]
        public void SetColumnOrderData_DetFieldsNull_SetsGroupDefinition()
        {
            // Arrange
            var detFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn()
            };
            var totalFields = new List<SortFieldDefn>()
            {
                new SortFieldDefn(),
                new SortFieldDefn()
            };
            var groupDefinition = new SortGroupDefn()
            {
                DetFields = detFields.ToArray(),
                TotFields = totalFields.ToArray(),
                DetFreeze = DummyInt,
                TotFreeze = DummyInt
            };

            privateObject.SetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_TotColRoot", nonPublicInstance, totalFields);
            privateObject.SetFieldOrProperty("m_DetColRoot", nonPublicInstance, detFields);

            // Act
            privateObject.Invoke(SetColumnOrderDataMethodName, publicInstance, new object[] { groupDefinition });
            var detRoot = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_DetColRoot", nonPublicInstance);
            var totalRoot = (List<SortFieldDefn>)privateObject.GetFieldOrProperty("m_TotColRoot", nonPublicInstance);
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);
            var detFreeze = (int)privateObject.GetFieldOrProperty("m_DetFreeze", nonPublicInstance);
            var totFreeze = (int)privateObject.GetFieldOrProperty("m_TotFreeze", nonPublicInstance);

            // Assert
            detRoot.ShouldSatisfyAllConditions(
                () => layoutCache.ShouldBe(string.Empty),
                () => detFreeze.ShouldBe(DummyInt),
                () => totFreeze.ShouldBe(DummyInt),
                () => totalRoot.Count.ShouldBe(2),
                () => detRoot.Count.ShouldBe(1));
        }

        [TestMethod]
        public void GetVersionsPILists_FromVersionEqualsToVersionTrue_Returns()
        {
            // Arrange
            const int fromVersion = 0;
            const int toVersion = 0;
            var groupDefinition = new SortGroupDefn();

            // Act
            testObject.GetVersionsPILists(ref groupDefinition, fromVersion, toVersion);

            // Assert
            groupDefinition.ShouldSatisfyAllConditions(
                () => groupDefinition.DetFields.Length.ShouldBe(0),
                () => groupDefinition.TotFields.Length.ShouldBe(0));
        }

        [TestMethod]
        public void GetVersionsPILists_FromVersionEqualsToVersionFalse_Returns()
        {
            // Arrange
            const int fromVersionZero = 0;
            const int fromVersion = -1;
            const int toVersion = 1;
            const string expectedDetField = "expectedDetField";
            const string expectedTotField = "expectedTotField";
            var groupDefinition = new SortGroupDefn();
            var pids = new Dictionary<string, PIData>()
            {
                ["1"] = new PIData(50)
                {
                    ScenarioID = fromVersion,
                    PI_ID = DummyInt,
                    PI_Name = expectedTotField
                },
                ["2"] = new PIData(50)
                {
                    ScenarioID = toVersion,
                    PI_ID = DummyInt,
                    PI_Name = DummyString
                },
                ["3"] = new PIData(50)
                {
                    ScenarioID = fromVersion,
                    PI_ID = DummyInt + 1,
                    PI_Name = expectedDetField
                }
            };

            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);

            // Act
            testObject.GetVersionsPILists(ref groupDefinition, fromVersionZero, toVersion);

            // Assert
            groupDefinition.ShouldSatisfyAllConditions(
                () => groupDefinition.DetFields.Length.ShouldBe(1),
                () => groupDefinition.TotFields.Length.ShouldBe(1),
                () => groupDefinition.DetFields[0].name.ShouldBe(expectedDetField),
                () => groupDefinition.TotFields[0].name.ShouldBe(expectedTotField));
        }

        [TestMethod]
        public void GetSaveVersions_WhenCalled_AddsVersions()
        {
            // Arrange
            var versions = new List<ItemDefn>();
            var scenario = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    bLoaded = true,
                    UID = DummyInt,
                    Name = DummyString
                },
                [2] = new DataItem()
                {
                    bLoaded = false,
                    UID = DummyInt,
                    Name = DummyString
                },
                [3] = new DataItem()
                {
                    bLoaded = true,
                    UID = 0,
                    Name = DummyString
                }
            };

            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, scenario);

            // Act
            testObject.GetSaveVersions(ref versions);

            // Assert
            versions.ShouldSatisfyAllConditions(
                () => versions.Count.ShouldBe(1),
                () => versions[0].Name.ShouldBe(DummyString),
                () => versions[0].Id.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void GetTargets_WhenCalled_AddsTargets()
        {
            // Arrange
            var targets = new List<ItemDefn>();
            var target = new List<DataItem>()
            {
                new DataItem()
                {
                    bLoaded = true,
                    UID = DummyInt,
                    Name = DummyString
                },
                new DataItem()
                {
                    bLoaded = false,
                    UID = DummyInt,
                    Name = DummyString
                },
                new DataItem()
                {
                    bLoaded = true,
                    UID = 0,
                    Name = DummyString
                }
            };

            privateObject.SetFieldOrProperty("m_Target", nonPublicInstance, target);

            // Act
            testObject.GetTargets(ref targets);

            // Assert
            targets.ShouldSatisfyAllConditions(
                () => targets.Count.ShouldBe(3),
                () => targets.Count(x => x.Name.Equals(DummyString)).ShouldBe(3),
                () => targets.Count(x => x.Id.Equals(DummyInt)).ShouldBe(2));
        }

        [TestMethod]
        public void SaveVersion_WhenCalled_ReturnsInteger()
        {
            // Arrange
            const string version = "1";
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var now = DateTime.Now;
            var pids = new Dictionary<string, PIData>()
            {
                ["1"] = new PIData(max)
                {
                    ScenarioID = -1,
                    PI_ID = DummyInt
                },
                ["2"] = new PIData(max)
                {
                    ScenarioID = -1,
                    PI_ID = DummyInt
                },
                ["3"] = new PIData(max)
                {
                    ScenarioID = 1,
                    PI_ID = DummyInt,
                    StartDate = DateTime.MinValue,
                    FinishDate = DateTime.MinValue
                },
                ["4"] = new PIData(50)
                {
                    ScenarioID = 1,
                    PI_ID = DummyInt,
                    StartDate = now,
                    FinishDate = now
                }
            };
            var costType = new Dictionary<int, DataItem>()
            {
                [1] = new DataItem()
                {
                    UID = DummyInt
                },
                [2] = new DataItem()
                {
                    UID = DummyInt
                }
            };
            var detailData = new Dictionary<string, DetailRowData>()
            {
                ["1"] = new DetailRowData(max)
                {
                    Scenario_ID = 1,
                    zCost = (new object[max + 1]).Select(x => 10d).ToArray(),
                    zValue = (new object[max + 1]).Select(x => 10d).ToArray()
                }
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return 1;
            };

            privateObject.SetFieldOrProperty("m_PIs", nonPublicInstance, pids);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, costType);
            privateObject.SetFieldOrProperty("m_detaildata", nonPublicInstance, detailData);
            privateObject.SetFieldOrProperty("m_sModel", nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty("m_max_period", nonPublicInstance, max);

            // Act
            var actual = (int)privateObject.Invoke(SaveVersionMethodName, publicInstance, new object[] { sqlConnection, version });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(0),
                () => validations.ShouldBe(506));
        }

        [TestMethod]
        public void GetPeriodsandVersions_WhenCalled_SetsPeriodsAndOptions()
        {
            // Arrange
            var periodsAndOptions = new PeriodsAndOptions();
            var periodData = new PeriodData()
            {
                PeriodID = DummyInt,
                PeriodName = DummyString
            };
            var periods = new Dictionary<int, PeriodData>()
            {
                [1] = periodData,
                [2] = periodData,
                [3] = periodData
            };

            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_display_minp", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_display_maxp", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_drag_minp", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("m_drag_maxp", nonPublicInstance, DummyInt);
            privateObject.SetFieldOrProperty("bShowFTEs", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("bUseQTY", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("bUseCosts", nonPublicInstance, true);
            privateObject.SetFieldOrProperty("m_show_rhs_dec_costs", nonPublicInstance, true);

            // Act
            testObject.GetPeriodsandVersions(ref periodsAndOptions);

            // Assert
            periodsAndOptions.ShouldSatisfyAllConditions(
                () => periodsAndOptions.displayStart.ShouldBe(DummyInt),
                () => periodsAndOptions.displayFinish.ShouldBe(DummyInt),
                () => periodsAndOptions.dragStart.ShouldBe(DummyInt),
                () => periodsAndOptions.dragFinish.ShouldBe(DummyInt),
                () => periodsAndOptions.showWhichQTY.ShouldBe(1),
                () => periodsAndOptions.showQTY.ShouldBe(1),
                () => periodsAndOptions.showCosts.ShouldBe(1),
                () => periodsAndOptions.showRHSDecCosts.ShouldBe(1),
                () => periodsAndOptions.Periods.Count(x => x.Id.Equals(DummyInt) && x.Name.Equals(DummyString)).ShouldBe(3));
        }

        [TestMethod]
        public void SetPeriodsandVersions_WhenCalled_SetsFields()
        {
            // Arrange
            var validations = 0;
            var periodsAndOptions = new PeriodsAndOptions()
            {
                displayStart = DummyInt,
                displayFinish = DummyInt,
                dragStart = DummyInt,
                dragFinish = DummyInt,
                showWhichQTY = 1,
                showQTY = 1,
                showCosts = 1,
                showRHSDecCosts = 1,
            };

            ShimModelCache.AllInstances.ApplyUserOptions = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetPeriodsandVersionsMethodName, publicInstance, new object[] { periodsAndOptions });
            var minDisplay = (int)privateObject.GetFieldOrProperty("m_display_minp", nonPublicInstance);
            var maxDisplay = (int)privateObject.GetFieldOrProperty("m_display_maxp", nonPublicInstance);
            var minDrag = (int)privateObject.GetFieldOrProperty("m_drag_minp", nonPublicInstance);
            var maxDrag = (int)privateObject.GetFieldOrProperty("m_drag_maxp", nonPublicInstance);
            var showFte = (bool)privateObject.GetFieldOrProperty("bShowFTEs", nonPublicInstance);
            var useQty = (bool)privateObject.GetFieldOrProperty("bUseQTY", nonPublicInstance);
            var useCosts = (bool)privateObject.GetFieldOrProperty("bUseCosts", nonPublicInstance);
            var decCosts = (bool)privateObject.GetFieldOrProperty("m_show_rhs_dec_costs", nonPublicInstance);
            var layoutCache = (string)privateObject.GetFieldOrProperty("bottomgridlayoutcache", nonPublicInstance);

            // Assert
            layoutCache.ShouldSatisfyAllConditions(
                () => layoutCache.ShouldBe(string.Empty),
                () => minDisplay.ShouldBe(DummyInt),
                () => maxDisplay.ShouldBe(DummyInt),
                () => minDrag.ShouldBe(DummyInt),
                () => maxDrag.ShouldBe(DummyInt),
                () => showFte.ShouldBeTrue(),
                () => useQty.ShouldBeTrue(),
                () => useCosts.ShouldBeTrue(),
                () => decCosts.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void DeleteTarget_WhenCalled_SetsTarget()
        {
            // Arrange
            const string targetString = "1";
            const int otherId = 10;
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var dataItem = new DataItem()
            {
                UID = otherId
            };
            var targetBefore = new List<DataItem>()
            {
                dataItem,
                dataItem,
                dataItem
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return 1;
            };

            privateObject.SetFieldOrProperty("m_Target", nonPublicInstance, targetBefore);

            // Act
            privateObject.Invoke(DeleteTargetMethodName, publicInstance, new object[] { sqlConnection, targetString });
            var targetAfter = (List<DataItem>)privateObject.GetFieldOrProperty("m_Target", nonPublicInstance);

            // Assert
            targetAfter.ShouldSatisfyAllConditions(
                () => targetAfter.Count(x => x.UID.Equals(otherId)).ShouldBe(3),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void CreateTarget_WhenCalled_ReturnsInteger()
        {
            // Arrange
            var validations = 0;
            var readHit = 0;
            var sqlConnection = new SqlConnection();
            var targetBefore = new List<DataItem>();

            dataReader.ItemGetInt32 = input => input;
            dataReader.Read = () =>
            {
                readHit += 1;
                validations += 1;
                if (readHit <= 3)
                {
                    return true;
                }
                else
                {
                    readHit = 0;
                }
                return false;
            };

            ShimSqlDb.ReadIntValueObject = _ => 0;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return 1;
            };

            privateObject.SetFieldOrProperty("m_Target", nonPublicInstance, targetBefore);

            // Act
            var actual = (int)privateObject.Invoke(CreateTargetMethodName, publicInstance, new object[] { sqlConnection, DummyString, DummyString, DummyInt, DummyInt });
            var targetAfter = (List<DataItem>)privateObject.GetFieldOrProperty("m_Target", nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(1),
                () => targetAfter.Count.ShouldBe(1),
                () => targetAfter[0].UID.ShouldBe(1),
                () => targetAfter[0].Name.ShouldBe(DummyString),
                () => targetAfter[0].Desc.ShouldBe(DummyString),
                () => validations.ShouldBe(11));
        }

        [TestMethod]
        public void BuildCatJSon_WhenCalled_Returns()
        {
            // Arrange
            const int index = 0;
            const int maxValue = 1;
            var expected = "{Name:'1',Text:'DummyString',Value:'1'},{Name:'Level1',Expanded:-1,Level:1, Items:[ {Name:'2',Text:'DummyString',Value:'2'}]}";
            var ratesCategrory = new CSRatesAndCategory()
            {
                Categories = new CSCategoryEntry[]
                {
                    new CSCategoryEntry()
                    {
                        Level = 1,
                        ID = 1,
                        UID = 1,
                        Name = DummyString
                    },
                    new CSCategoryEntry()
                    {
                        Level = 2,
                        ID = 2,
                        UID = 2,
                        Name = DummyString
                    },
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(BuildCatJSonMethodName, nonPublicInstance, new object[] { ratesCategrory, index, maxValue });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void BuildCustFieldJSon_WhenCalled_Returns()
        {
            // Arrange
            const int index = 0;
            const int maxValue = 1;
            var expected = "{Name:'1',Text:'DummyString',Value:'1'},{Name:'Level1',Expanded:-1,Level:1, Items:[ {Name:'2',Text:'DummyString',Value:'2'}]}";
            var customFieldData = new CustomFieldData()
            {
                UseFullName = 1,
                ListItems = new Dictionary<int, ListItemData>()
                {
                    [1] = new ListItemData()
                    {
                        Level = 1,
                        ID = 1,
                        UID = 1,
                        Name = DummyString,
                        FullName = DummyString,
                    },
                    [2] = new ListItemData()
                    {
                        Level = 2,
                        ID = 2,
                        UID = 2,
                        Name = DummyString,
                        FullName = DummyString
                    },
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(BuildCustFieldJSonMethodName, nonPublicInstance, new object[] { customFieldData, index, maxValue });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void RatesAndCategory_WhenCalled_Returns()
        {
            // Arrange
            const string expectedCostCatJson = "{Items:[DummyString]}";
            const string expectedCostTypeJson = "{Items:[{Name:'0',Text:'No Cost Type',Value:'0'},{Name:'1',Text:'DummyString',Value:'1'},{Name:'2',Text:'DummyString',Value:'2'}]}";
            var validations = 0;
            var ratesAndCategory = new CSRatesAndCategory();

            ShimModelCache.AllInstances.BuildCatJSonCSRatesAndCategoryInt32Int32 = (_, _1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_Periods", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_Scenario", nonPublicInstance, dataItemDictionary);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, dataItemDictionary);
            privateObject.SetFieldOrProperty("m_CustFields", nonPublicInstance, customFields);

            // Act
            testObject.RatesAndCategory(ref ratesAndCategory);
            var costCatJson = (string)privateObject.GetFieldOrProperty("m_CostCatjsonMenu", nonPublicInstance);
            var costTypeJson = (string)privateObject.GetFieldOrProperty("m_CostTypejsonMenu", nonPublicInstance);

            // Assert
            ratesAndCategory.ShouldSatisfyAllConditions(
                () => costCatJson.ShouldBe(expectedCostCatJson),
                () => costTypeJson.ShouldBe(expectedCostTypeJson),
                () => ratesAndCategory.NamedRates.Length.ShouldBe(0),
                () => ratesAndCategory.Categories.Count(x => x.Name.Equals(DummyString)).ShouldBe(2),
                () => ratesAndCategory.Versions.Count(x => x.Name.Equals(DummyString)).ShouldBe(2),
                () => ratesAndCategory.CostTypes.Count(x => x.Name.Equals(DummyString)).ShouldBe(2),
                () => ratesAndCategory.CustomFields.Count(x => x.Name.Equals($"z{DummyString}")).ShouldBe(2),
                () => ratesAndCategory.CustomFields[0].LookUp.Count(x => x.Name.Equals(DummyString)).ShouldBe(2),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PrepareTargetData_WhenCalled_Returns()
        {
            // Arrange
            var validations = 0;
            var sqlConnection = new SqlConnection();
            var csTargetData = new CSTargetData();

            ShimModelCache.AllInstances.LoadTargetsSqlConnectionString = (_, _1, _2) =>
            {
                validations += 1;
                return DummyInt;
            };
            ShimModelCache.AllInstances.GetLookUpStringInt32Int32Ref = (ModelCache instance, int index, ref int lUID) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty("m_targetdata", nonPublicInstance, targetData);
            privateObject.SetFieldOrProperty("m_CostCat", nonPublicInstance, costCat);
            privateObject.SetFieldOrProperty("m_CostTypes", nonPublicInstance, dataItemDictionary);
            privateObject.SetFieldOrProperty("m_Rates", nonPublicInstance, rates);

            // Act
            testObject.PrepareTargetData(sqlConnection, one, ref csTargetData);

            // Assert
            csTargetData.ShouldSatisfyAllConditions(
                () => csTargetData.targetRows.Length.ShouldBe(1),
                () => csTargetData.targetRows[0].BC_UID.ShouldBe(one),
                () => validations.ShouldBe(6));
        }
    }
}