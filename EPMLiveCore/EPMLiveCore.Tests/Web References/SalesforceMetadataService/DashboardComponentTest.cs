using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.DashboardComponent"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class DashboardComponentTest
    {
        private PrivateObject _privateObject;
        private DashboardComponent _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new DashboardComponent();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["autoselectColumnsFromReport"] = true,
                ["autoselectColumnsFromReportSpecified"] = true,
                ["chartAxisRange"] = new ChartRangeType(),
                ["chartAxisRangeSpecified"] = true,
                ["chartAxisRangeMax"] = (double)DummyInt,
                ["chartAxisRangeMaxSpecified"] = true,
                ["chartAxisRangeMin"] = (double)DummyInt,
                ["chartAxisRangeMinSpecified"] = true,
                ["chartSummary"] = new ChartSummary[] { },
                ["componentType"] = new DashboardComponentType(),
                ["dashboardFilterColumns"] = new DashboardFilterColumn[] { },
                ["dashboardTableColumn"] = new DashboardTableColumn[] { },
                ["displayUnits"] = new ChartUnits(),
                ["displayUnitsSpecified"] = true,
                ["drillDownUrl"] = DummyString,
                ["drillEnabled"] = true,
                ["drillEnabledSpecified"] = true,
                ["drillToDetailEnabled"] = true,
                ["drillToDetailEnabledSpecified"] = true,
                ["enableHover"] = true,
                ["enableHoverSpecified"] = true,
                ["expandOthers"] = true,
                ["expandOthersSpecified"] = true,
                ["footer"] = DummyString,
                ["gaugeMax"] = (double)DummyInt,
                ["gaugeMaxSpecified"] = true,
                ["gaugeMin"] = (double)DummyInt,
                ["gaugeMinSpecified"] = true,
                ["groupingColumn"] = new string[] { },
                ["header"] = DummyString,
                ["indicatorBreakpoint1"] = (double)DummyInt,
                ["indicatorBreakpoint1Specified"] = true,
                ["indicatorBreakpoint2"] = (double)DummyInt,
                ["indicatorBreakpoint2Specified"] = true,
                ["indicatorHighColor"] = DummyString,
                ["indicatorLowColor"] = DummyString,
                ["indicatorMiddleColor"] = DummyString,
                ["legendPosition"] = new ChartLegendPosition(),
                ["legendPositionSpecified"] = true,
                ["maxValuesDisplayed"] = DummyInt,
                ["maxValuesDisplayedSpecified"] = true,
                ["metricLabel"] = DummyString,
                ["page"] = DummyString,
                ["pageHeightInPixels"] = DummyInt,
                ["pageHeightInPixelsSpecified"] = true,
                ["report"] = DummyString,
                ["scontrol"] = DummyString,
                ["scontrolHeightInPixels"] = DummyInt,
                ["scontrolHeightInPixelsSpecified"] = true,
                ["showPercentage"] = true,
                ["showPercentageSpecified"] = true,
                ["showPicturesOnCharts"] = true,
                ["showPicturesOnChartsSpecified"] = true,
                ["showPicturesOnTables"] = true,
                ["showPicturesOnTablesSpecified"] = true,
                ["showTotal"] = true,
                ["showTotalSpecified"] = true,
                ["showValues"] = true,
                ["showValuesSpecified"] = true,
                ["sortBy"] = new DashboardComponentFilter(),
                ["sortBySpecified"] = true,
                ["title"] = DummyString,
                ["useReportChart"] = true,
                ["useReportChartSpecified"] = true,
            };

            // Act
            foreach (var kvp in propertiesDictionary)
            {
                _privateObject.SetProperty(kvp.Key, kvp.Value);
            }

            // Assert
            var assertions = new List<Action>();
            foreach (var kvp in propertiesDictionary)
            {
                assertions.Add(() => _privateObject.GetProperty(kvp.Key).ShouldBe(kvp.Value));
            }
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
    }
}