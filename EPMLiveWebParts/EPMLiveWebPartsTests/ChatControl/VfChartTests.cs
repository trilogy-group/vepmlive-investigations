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
                        return "true";
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
        public void GetXaml_()
        {
            // Arrange

            // Act
            var result = _testObject.GetXaml();

            // Assert

        }

        [TestMethod]
        public void GetXaml_Bubble_()
        {
            // Arrange
            _testObject.PropChartMainStyle = "Bubble";
            _testObject.PropChartShowZeroValueData = true;

            // Act
            var result = _testObject.GetXaml();

            // Assert

        }

        [TestMethod]
        public void GetXaml_BubbleWithoutLegend_()
        {
            // Arrange
            _testObject.PropChartMainStyle = "Bubble";
            _testObject.PropChartShowZeroValueData = true;
            ShimPersonalizationDataRepository.AllInstances.GetUserSettingsPersonalizationSearchCriteria =
                (_, __) => new PersonalizationData
                {
                    ForeignKey = _dummyGuid,
                    UserId = One,
                    SiteId = _dummyGuid,
                    WebId = _dummyGuid,
                    ListId = _dummyGuid,
                    Value = "1|2|3,3|4|5|6|None Selected"
                };

            // Act
            var result = _testObject.GetXaml();

            // Assert

        }

        [TestMethod]
        public void GetXaml_BubbleNotShowZeroValueData_()
        {
            // Arrange
            _testObject.PropChartMainStyle = "Bubble";
            _testObject.PropChartShowZeroValueData = false;

            // Act
            var result = _testObject.GetXaml();

            // Assert

        }

        [TestMethod]
        public void GetHtml_()
        {
            // Arrange

            // Act
            var result = _testObject.GetHtml(DummyString);

            // Assert
        }

        [TestMethod]
        public void GetQueryString_()
        {
            // Arrange

            // Act
            var result = _testObject.GetQueryString();

            // Assert

        }

        [TestMethod]
        public void EmptyContructor_()
        {
            // Arrange

            // Act
            var result = new TestClass();

            // Assert

        }

        [TestMethod]
        public void HandleException_()
        {
            // Arrange

            // Act
            _privateObject.Invoke("HandleException", new object[] { new InvalidOperationException() });

            // Assert
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
