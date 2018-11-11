using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using EPMLiveWebParts.Personalization.DomainModel;
using EPMLiveWebParts.Personalization.Repositories.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ChatControl
{
    [TestClass]
    public class VfChartTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string QTitle = "Title";
        private const string QXfield = "XField";
        private const string QXfieldLabel = "XFieldLabel";
        private const string QYfieldLabel = "YFieldLabel";
        private const string QZfieldLabel = "ZFieldLabel";
        private const string QYfields = "YFields";
        private const string QZfield = "ZField";
        private const string QBubbleChartColorField = "BubbleChartColorFieldDropDownList";
        private const string QAggrtype = "AggrType";
        private const string QRolluplists = "RollupLists";
        private const string QRollupsites = "RollupSites";
        private const string QView = "View";
        private const string QList = "List";
        private const string QChartType = "Type";
        private const string QView3D = "View3D";
        private const string QColorSet = "Palette";
        private const string QHeight = "H";
        private const string QWidth = "W";
        private const string QLegend = "Legend";
        private const string QPercentage = "Percent";
        private const string QCurrency = "Currency";
        private const string QGridlines = "Grid";
        private const string QLabels = "Labels";
        private const string QShowZeroValueData = "ZeroValues";
        private const string QShowBubbleChartInputs = "BubbleChartInputs";
        private const string QChartWebPartId = "ChartWebPartId";
        private const string QLookupField = "LookupField";
        private const string QLookupFieldList = "LookupFieldList";
        private const string True = "true";
        private const string BubbleType = "Bubble";
        private const string Column = "Column";
        private const string Sum = "SUM";
        private const string PersonalizationDataValue = "1|2|3,3|4|5|6|None Selected";
        private const string ChartInit = "<vc:Chart xmlns:vc=\"clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts\" BorderThickness=\"0\"  Watermark=\"False\"";
        private const string ChartTitles = "<vc:Chart.Titles>";
        private const string ChartTitle = "<vc:Title Text=";
        private const string ChartLegends = "<vc:Chart.Legends><vc:Legend";
        private const string ChartAxesX = "<vc:Chart.AxesX>";
        private const string ChartAxesY = "<vc:Chart.AxesY>";
        private const string ChartAxisDeclare = "<vc:Axis Title=";
        private const string ChartAxisGrid = "<vc:Axis.Grids><vc:ChartGrid";
        private const string ChartSeries = "<vc:Chart.Series>";
        private const string ChartBubbleDataPoint = "<vc:DataPoint XValue=";
        private const string ChartShowInLegend = "ShowInLegend=";
        private const string VisifireJsScript = "<script type='text/javascript' src='/_layouts/epmlive/Visifire.js";
        private const string OnLoadFunctionDeclaration = "function onLoad()";
        private const string OnLoadFunctionCall = "addLoadEvent(onLoad);";
        private const string GetXmlHttpFunctionCall = "var xmlHttp = GetXMLHttpObj();";
        private const string XmlHttpOpenRequest = "xmlHttp.open('GET', L_Menu_BaseUrl";
        private const string XmlHttpSendRequest = "xmlHttp.send(";
        private const string SetVChartDataXml = "vChart.setDataXml(xmlHttp.responseText);";
        private const string SetVChartSize = "vChart.setSize(";
        private const string SetVChartCulture = "vChart.setCulture(";
        private const string RenderVChart = "vChart.render('Visifire";
        private const string DivVisifire = "<div style='width:100%;height:100%;' id='Visifire";
        private const string DivDiagnostics = "<div id='ChartDiagnostics' style='width:400px;";
        private const string ParagraphQueryString = "<p>Querystring:";
        private const string ElementOpenChartMenu = @"<a onclick=""javascript:window.open(L_Menu_BaseUrl";
        private const string ExceptionTrace = "**** EXCEPTION ****";
        private const string MethodHandleException = "HandleException";
        private Guid _dummyGuid = Guid.NewGuid();
        private VfChart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;

        private class TestClass : VfChart
        {
            public TestClass()
            {

            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            ShimSharePointContext();

            var shimRequest = CreateHttpRequest();
            _testObject = new VfChart(shimRequest.Instance);
            _privateObject = new PrivateObject(_testObject);

            _testObject.PropChartWebPartId = _dummyGuid.ToString();
            _testObject.Series = new List<VfChartSeries>
            {
                GetChartSeries(),
                GetChartSeries()
            };

            ShimPersonalizationDataRepository.AllInstances.GetUserSettingsPersonalizationSearchCriteria =
                (_, __) => new PersonalizationData
                {
                    ForeignKey = _dummyGuid,
                    UserId = One,
                    SiteId = _dummyGuid,
                    WebId = _dummyGuid,
                    ListId = _dummyGuid,
                    Value = "1|2|3,3|4|5|6|7"
                };
        }

        private ShimHttpRequest CreateHttpRequest()
        {
            return new ShimHttpRequest
            {
                ItemGetString = key =>
                {
                    if (key.Equals(QView3D)
                    || key.Equals(QLegend)
                    || key.Equals(QPercentage)
                    || key.Equals(QCurrency)
                    || key.Equals(QGridlines)
                    || key.Equals(QLabels)
                    || key.Equals(QShowZeroValueData)
                    || key.Equals(QShowBubbleChartInputs))
                    {
                        return True;
                    }

                    return DummyString;
                }
            };
        }

        private VfChartSeries GetChartSeries()
        {
            var series = new VfChartSeries(DummyString)
            {
                new VfPoint(DummyString, 1, 1)
            };
            return series;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetXaml_Get_ReturnsChartElements()
        {
            // Arrange, Act
            var result = _testObject.GetXaml();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ChartInit),
                () => result.ShouldContain(ChartTitles),
                () => result.ShouldContain(ChartTitle),
                () => result.ShouldContain(ChartLegends),
                () => result.ShouldContain(ChartAxesX),
                () => result.ShouldContain(ChartAxesY),
                () => result.ShouldContain(ChartAxisDeclare),
                () => result.ShouldContain(ChartAxisGrid),
                () => result.ShouldContain(ChartSeries));
        }

        [TestMethod]
        public void GetXaml_Bubble_WritesBubbleDataPoint()
        {
            // Arrange
            _testObject.PropChartMainStyle = BubbleType;
            _testObject.PropChartShowZeroValueData = true;

            // Act
            var result = _testObject.GetXaml();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ChartBubbleDataPoint),
                () => result.ShouldContain(ChartShowInLegend));
        }

        [TestMethod]
        public void GetXaml_BubbleWithoutLegend_DoesNotConsiderLegend()
        {
            // Arrange
            _testObject.PropChartMainStyle = BubbleType;
            _testObject.PropChartShowZeroValueData = true;
            ShimPersonalizationDataRepository.AllInstances.GetUserSettingsPersonalizationSearchCriteria =
                (_, __) => new PersonalizationData
                {
                    ForeignKey = _dummyGuid,
                    UserId = One,
                    SiteId = _dummyGuid,
                    WebId = _dummyGuid,
                    ListId = _dummyGuid,
                    Value = PersonalizationDataValue
                };

            // Act
            var result = _testObject.GetXaml();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(ChartBubbleDataPoint),
                () => result.ShouldContain(ChartShowInLegend));
        }

        [TestMethod]
        public void GetXaml_BubbleNotShowZeroValueData_WritesBubbleDataPoint()
        {
            // Arrange
            _testObject.PropChartMainStyle = BubbleType;
            _testObject.PropChartShowZeroValueData = false;

            // Act
            var result = _testObject.GetXaml();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotContain(ChartBubbleDataPoint),
                () => result.ShouldContain(ChartShowInLegend));
        }

        [TestMethod]
        public void GetHtml_Get_WritesJs()
        {
            // Arrange, Act
            var result = _testObject.GetHtml(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(VisifireJsScript),
                () => result.ShouldContain(OnLoadFunctionDeclaration),
                () => result.ShouldContain(OnLoadFunctionCall),
                () => result.ShouldContain(GetXmlHttpFunctionCall),
                () => result.ShouldContain(SetVChartDataXml),
                () => result.ShouldContain(SetVChartSize),
                () => result.ShouldContain(SetVChartCulture),
                () => result.ShouldContain(RenderVChart),
                () => result.ShouldContain(XmlHttpOpenRequest),
                () => result.ShouldContain(XmlHttpSendRequest));
        }

        [TestMethod]
        public void GetHtml_Get_WritesHtml()
        {
            // Arrange, Act
            var result = _testObject.GetHtml(DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(DivVisifire),
                () => result.ShouldContain(DivDiagnostics),
                () => result.ShouldContain(ParagraphQueryString),
                () => result.ShouldContain(ElementOpenChartMenu));
        }

        [TestMethod]
        public void GetQueryString_BuildQueryString_ContainsPositioningFields()
        {
            // Arrange, Act
            var result = _testObject.GetQueryString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"{QXfield}="),
                () => result.ShouldContain($"{QXfieldLabel}="),
                () => result.ShouldContain($"{QYfieldLabel}="),
                () => result.ShouldContain($"{QZfieldLabel}="),
                () => result.ShouldContain($"{QYfields}="),
                () => result.ShouldContain($"{QZfield}="),
                () => result.ShouldContain($"{QPercentage}="),
                () => result.ShouldContain($"{QWidth}="),
                () => result.ShouldContain($"{QHeight}="));
        }

        [TestMethod]
        public void GetQueryString_BuildQueryString_ContainsStylingFields()
        {
            // Arrange, Act
            var result = _testObject.GetQueryString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"{QBubbleChartColorField}="),
                () => result.ShouldContain($"{QAggrtype}="),
                () => result.ShouldContain($"{QList}="),
                () => result.ShouldContain($"{QView}="),
                () => result.ShouldContain($"{QRolluplists}="),
                () => result.ShouldContain($"{QRollupsites}="),
                () => result.ShouldContain($"{QChartType}="),
                () => result.ShouldContain($"{QView3D}="),
                () => result.ShouldContain($"{QColorSet}="));
        }

        [TestMethod]
        public void GetQueryString_BuildQueryString_ContainsOtherFields()
        {
            // Arrange, Act
            var result = _testObject.GetQueryString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain($"{QLegend}="),
                () => result.ShouldContain($"{QCurrency}="),
                () => result.ShouldContain($"{QGridlines}="),
                () => result.ShouldContain($"{QLabels}="),
                () => result.ShouldContain($"{QShowZeroValueData}="),
                () => result.ShouldContain($"{QShowBubbleChartInputs}="),
                () => result.ShouldContain($"{QChartWebPartId}="),
                () => result.ShouldContain($"{QLookupField}="),
                () => result.ShouldContain($"{QLookupFieldList}="));
        }

        [TestMethod]
        public void EmptyContructor_Construct_InitializesVariables()
        {
            // Arrange, Act
            var result = new TestClass();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.PropChartTitle.ShouldBeEmpty(),
                () => result.PropChartXaxisField.ShouldBeEmpty(),
                () => result.PropChartYaxisField.ShouldBeEmpty(),
                () => result.PropChartZaxisField.ShouldBeEmpty(),
                () => result.PropBubbleChartColorField.ShouldBeEmpty(),
                () => result.PropChartRollupLists.ShouldBeEmpty(),
                () => result.PropChartRollupSites.ShouldBeEmpty(),
                () => result.PropChartSelectedList.ShouldBeEmpty(),
                () => result.PropChartSelectedView.ShouldBeEmpty(),
                () => result.PropChartMainStyle.ShouldBe(Column),
                () => result.PropChartAggregationType.ShouldBe(Sum));
        }

        [TestMethod]
        public void HandleException_TraceOutput_WritesToOutput()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodHandleException, new object[] { new InvalidOperationException(DummyString) });

            // Assert
            var result = _testObject.ToString();
            _testObject.ShouldSatisfyAllConditions(
                () => result.ShouldContain("EPMLiveWebParts"),
                () => result.ShouldContain("VfChart"));
        }

        private void ShimSharePointContext()
        {
            var user = new ShimSPUser
            {
                IDGet = () => Id
            };
            var fields = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = _ => new ShimSPField()
                {
                    TitleGet = () => DummyString
                }.Instance
            };
            var list = new ShimSPList
            {
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    ItemGetString = x => $"{DummyString},{DummyString}",
                    DisplayNameGet = () => DummyString
                },
                FieldsGet = () => fields.Instance
            };
            var webApp = new ShimSPWebApplication
            {
                ApplicationPoolGet = () => new SPApplicationPool()
            }.Instance;
            var lists = new ShimSPListCollection
            {
                ItemGetString = _ => list
            };
            var web = new ShimSPWeb
            {
                IDGet = () => _dummyGuid,
                CurrentUserGet = () => user,
                EnsureUserString = _ => user,
                SiteUserInfoListGet = () => list.Instance,
                ListsGet = () => lists.Instance
            };
            var site = new ShimSPSite
            {
                IDGet = () => _dummyGuid,
                RootWebGet = () => web.Instance,
                WebApplicationGet = () => webApp
            };
            web.SiteGet = () => site.Instance;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => web.Instance,
                SiteGet = () => site.Instance
            }.Instance;
        }
    }
}
