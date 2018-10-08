using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Diagnostics.CodeAnalysis;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportingDataTest
    {
        private const string SampleTable = "SampleTable";
        private const int SamplePageNum = 1;
        private const int SamplePageSize = 10;

        private IDisposable _shimsContext;
        private SharepointShims _sharepointShims;
        private AdoShims _adoShims;
        
        [TestInitialize]
        public void Initialize()
        {
            _shimsContext = ShimsContext.Create();

            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _adoShims = AdoShims.ShimAdoNetCalls();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void GetReportingData_Called_AdoDisposed()
        {
            // Arrange
            ShimReportBiz.ConstructorGuid = (biz, guid) =>
            {
                new ShimReportBiz(biz)
                {
                    SiteExists = () => true
                };
            };

            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, set) =>
            {
                var table = new DataTable(SampleTable);
                set.Tables.Add(table);
                return 0;
            };

            // Act
            var result = ReportingData.GetReportingData(
                _sharepointShims.WebShim,
                string.Empty,
                true,
                string.Empty,
                string.Empty,
                SamplePageNum,
                SamplePageSize);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Tables.Count.ShouldBe(1),
                () => result.Tables[0].TableName.ShouldBe(SampleTable),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(2),
                () => _adoShims.DataAdaptersDisposed.Count.ShouldBe(1));
        }

        [TestMethod]
        public void ProcessReportFilter_Called_AdoDisposed()
        {
            // Arrange, Act
            var result = ReportingData.ProcessReportFilter(
                _sharepointShims.ListShim,
                _sharepointShims.WebShim,
                string.Empty);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe("<In><FieldRef Name=\"Title\"/><Values></Values></In>"),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(1));
        }
    }
}
