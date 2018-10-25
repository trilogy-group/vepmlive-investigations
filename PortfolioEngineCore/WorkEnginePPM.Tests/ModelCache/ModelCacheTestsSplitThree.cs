using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.ModelCacheTests
{
    public partial class ModelCacheTests
    {
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

        [TestMethod]
        public void GetBottomGrid_WhenCalled_Returns()
        {
            // Arrange
            const int max = 500;
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
            const int max = 500;
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
            const int max = 500;
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
            const int max = 500;
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
            const int max = 500;
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
            const int max = 500;
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
            const int max = 500;
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
            var cmpData = "1 0 1";
            var dataItemList = new List<DataItem>()
            {
                new DataItem()
                {
                    bSelected = false
                },
                new DataItem()
                {
                    bSelected = false
                },
                new DataItem()
                {
                    bSelected = false
                }
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
    }
}