using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.ReportChart"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportChartTest
    {
        private PrivateObject _privateObject;
        private ReportChart _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new ReportChart();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["backgroundColor1"] = DummyString,
                ["backgroundColor2"] = DummyString,
                ["backgroundFadeDir"] = new ChartBackgroundDirection(),
                ["backgroundFadeDirSpecified"] = true,
                ["chartSummaries"] = new ChartSummary[] { },
                ["chartType"] = new ChartType(),
                ["enableHoverLabels"] = true,
                ["enableHoverLabelsSpecified"] = true,
                ["expandOthers"] = true,
                ["expandOthersSpecified"] = true,
                ["groupingColumn"] = DummyString,
                ["legendPosition"] = new ChartLegendPosition(),
                ["legendPositionSpecified"] = true,
                ["location"] = new ChartPosition(),
                ["locationSpecified"] = true,
                ["secondaryGroupingColumn"] = DummyString,
                ["showAxisLabels"] = true,
                ["showAxisLabelsSpecified"] = true,
                ["showPercentage"] = true,
                ["showPercentageSpecified"] = true,
                ["showTotal"] = true,
                ["showTotalSpecified"] = true,
                ["showValues"] = true,
                ["showValuesSpecified"] = true,
                ["size"] = new ReportChartSize(),
                ["sizeSpecified"] = true,
                ["summaryAxisManualRangeEnd"] = (double)DummyInt,
                ["summaryAxisManualRangeEndSpecified"] = true,
                ["summaryAxisManualRangeStart"] = (double)DummyInt,
                ["summaryAxisManualRangeStartSpecified"] = true,
                ["summaryAxisRange"] = new ChartRangeType(),
                ["summaryAxisRangeSpecified"] = true,
                ["textColor"] = DummyString,
                ["textSize"] = DummyInt,
                ["textSizeSpecified"] = true,
                ["title"] = DummyString,
                ["titleColor"] = DummyString,
                ["titleSize"] = DummyInt,
                ["titleSizeSpecified"] = true,
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