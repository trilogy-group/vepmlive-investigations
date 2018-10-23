using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
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

        [TestMethod]
        public void GetBottomGrid_WhenCalled_Returns()
        {
            // Arrange
            var max = 500;
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
            var max = 500;
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
    }
}