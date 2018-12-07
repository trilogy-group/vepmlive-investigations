using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.Layouts.epmlive
{
    using ReportingChart;

    [TestClass]
    public class UpdateWebPartTests
    {
        private IDisposable shimsContext;
        private UpdateWebPart updateWebPart;
        private PrivateObject privateObject;
        private string PageLoadMethodName = "Page_Load";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            updateWebPart = new UpdateWebPart();
            privateObject = new PrivateObject(updateWebPart);
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.LocaleGet = _ => CultureInfo.CurrentCulture;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPSite.ConstructorString = (_, path) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.UrlGet = _ => string.Empty;
        }

        [TestMethod]
        public void PageLoad_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string DummyString = "dummyString";
            const string PropChartShowGridlines = "sPropChartShowGridlines";
            const string PropChartShowLegend = "sPropChartShowLegend";
            const string PropChartShowSeriesLabels = "sPropChartShowSeriesLabels";
            const string ChartType = "sChartType";
            ReportingChart reportingChart = null;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case PropChartShowGridlines:
                        case PropChartShowLegend:
                        case PropChartShowSeriesLabels:
                            return bool.TrueString;
                        case ChartType:
                            return EPMLiveWebParts.ReportingChart.ChartType.Area.ToString();
                        default:
                            return DummyString;
                    }
                }
            };
            ShimSPWeb.AllInstances.GetFileString = (_, path) => new ShimSPFile
            {
                GetLimitedWebPartManagerPersonalizationScope = scope => new ShimSPLimitedWebPartManager
                {
                    WebPartsGet = () =>
                    {
                        var list = new List<WebPart>
                        {
                            new ReportingChart
                            {
                                ID = DummyString
                            }
                        };
                        return new ShimSPLimitedWebPartCollection().Bind(list);
                    },
                    SaveChangesWebPart = web =>
                    {
                        reportingChart = (ReportingChart)web;
                    }
                }
            };
            
            // Act
            privateObject.Invoke(PageLoadMethodName, null, EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe("Success"),
                () => reportingChart.ShouldNotBeNull(),
                () => reportingChart.PropChartAggregationType.ShouldBe(DummyString),
                () => reportingChart.PropChartYaxisField.ShouldBe(DummyString),
                () => reportingChart.PropChartXaxisField.ShouldBe(DummyString),
                () => reportingChart.PropChartShowSeriesLabels.ShouldBeTrue(),
                () => reportingChart.PropChartShowGridlines.ShouldBeTrue(),
                () => reportingChart.PropChartShowLegend.ShouldBeTrue(),
                () => reportingChart.PropChartType.ShouldBe(EPMLiveWebParts.ReportingChart.ChartType.Area));
        }

        [TestMethod]
        public void PageLoad_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string ErrorMessage = "dummyString";
            const string ExpectedMessage = "Failed. Error Message : " + ErrorMessage;
            ShimPage.AllInstances.RequestGet = _ => null;
            ShimSPSite.AllInstances.OpenWeb = _ =>
            {
                throw new Exception(ErrorMessage);
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, null, EventArgs.Empty);
            var data = privateObject.GetFieldOrProperty("data") as string;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => data.ShouldNotBeNullOrEmpty(),
                () => data.ShouldBe(ExpectedMessage));
        }
    }
}
