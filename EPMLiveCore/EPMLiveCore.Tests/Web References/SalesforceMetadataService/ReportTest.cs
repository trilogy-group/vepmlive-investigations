using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EPMLiveCore.SalesforceMetadataService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Web_References.SalesforceMetadataService
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.SalesforceMetadataService.Report"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportTest
    {
        private PrivateObject _privateObject;
        private Report _testEntity;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;

        [TestInitialize]
        public void SetUp()
        {
            _testEntity = new Report();
            _privateObject = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void Properties_TestGetterAndSetter()
        {
            // Arrange
            var propertiesDictionary = new Dictionary<string, object>()
            {
                ["aggregates"] = new ReportAggregate[] { },
                ["block"] = new Report[] { },
                ["blockInfo"] = new ReportBlockInfo(),
                ["buckets"] = new ReportBucketField[] { },
                ["chart"] = new ReportChart(),
                ["colorRanges"] = new ReportColorRange[] { },
                ["columns"] = new ReportColumn[] { },
                ["crossFilters"] = new ReportCrossFilter[] { },
                ["currency"] = new CurrencyIsoCode(),
                ["currencySpecified"] = true,
                ["description"] = DummyString,
                ["division"] = DummyString,
                ["filter"] = new ReportFilter(),
                ["format"] = new ReportFormat(),
                ["groupingsAcross"] = new ReportGrouping[] { },
                ["groupingsDown"] = new ReportGrouping[] { },
                ["name"] = DummyString,
                ["params"] = new ReportParam[] { },
                ["reportType"] = DummyString,
                ["roleHierarchyFilter"] = DummyString,
                ["rowLimit"] = DummyInt,
                ["rowLimitSpecified"] = true,
                ["scope"] = DummyString,
                ["showDetails"] = true,
                ["showDetailsSpecified"] = true,
                ["sortColumn"] = DummyString,
                ["sortOrder"] = new SortOrder(),
                ["sortOrderSpecified"] = true,
                ["territoryHierarchyFilter"] = DummyString,
                ["timeFrameFilter"] = new ReportTimeFrameFilter(),
                ["userFilter"] = DummyString,
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