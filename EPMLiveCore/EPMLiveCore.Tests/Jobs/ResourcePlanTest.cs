using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    public class ResourcePlanTest
    {
        private IDisposable _shimsContext;

        private string _resourceUrl;
        private ShimSPWeb _webShim;
        private string _resourcePlanListsString;
        private Guid _siteId;
        private int _hours;
        private string _workdays;
        
        private ShimSPListItem _listItemShim;
        private string _webServerRelativeUrl;
        private IList<SPFieldUserValue> _spFieldUserValues;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _resourceUrl = "http://test.test";

            _webServerRelativeUrl = "http://test.test";

            _resourcePlanListsString = "1,2,3";
            _siteId = Guid.NewGuid();
            _hours = 1;
            _workdays = "1";

            _listItemShim = new ShimSPListItem
            {
                ItemGetGuid = id => new object()
            };

            var listItemCollection = new ShimSPListItemCollection();

            var webList = new ShimSPList
            {
                GetItemsSPQuery = query =>
                {
                    return listItemCollection.Bind(new[] { _listItemShim.Instance });
                },
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = name => new ShimSPField()
                }
            };

            var webListCollectionShim = new ShimSPListCollection
            {
                ItemGetString = (name) => webList.Instance
            };

            _webShim = new ShimSPWeb
            {
                ServerRelativeUrlGet = () => _webServerRelativeUrl,
                ListsGet = () => webListCollectionShim.Instance
            };

            ShimSPFieldLookupValue.ConstructorString = (element, name) =>
                new ShimSPFieldLookupValue();

            _spFieldUserValues = new List<SPFieldUserValue>
            {
                new SPFieldUserValue(_webShim.Instance, "1"),
                new SPFieldUserValue(_webShim.Instance, "2"),
            };

            // (CC-76656, 2018-07-18) Sadly, can not shim SPFieldUserValueCollection constructor to be able to contain elements, due to SP limitations
            // Therefore, can not test ResourceInfo generation
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void ProcessResourcePlan_ResourceUrlNullOrWhitespace_NoProcessing()
        {
            // Arrange
            _resourceUrl = "  ";

            // Act
            var result = ResourcePlan.ProcessResourcePlan(
                _resourceUrl, 
                _webShim.Instance, 
                _resourcePlanListsString, 
                _siteId, 
                _hours, 
                _workdays);

            // Assert
            Assert.AreEqual(0, result.InfoMessages.Count);
            Assert.AreEqual(0, result.ErrorMessages.Count);
            Assert.AreEqual(0, result.ResourceLinks.Count);
            Assert.AreEqual(0, result.ResourceInfos.Count);
        }

        [TestMethod]
        public void ProcessResourcePlan_ResourceUrlNotNullOrWhitespace_AddsResourceLink()
        {
            // Arrange
            _resourcePlanListsString = null;

            // Act
            var result = ResourcePlan.ProcessResourcePlan(
                _resourceUrl, 
                _webShim.Instance, 
                _resourcePlanListsString,
                _siteId,
                _hours,
                _workdays);

            // Assert
            Assert.AreEqual(1, result.ResourceLinks.Count);
            Assert.AreEqual(_webServerRelativeUrl, result.ResourceLinks[0].ServerRelativeUrl);
            Assert.AreEqual(_resourceUrl, result.ResourceLinks[0].ResourceUrl);
            Assert.AreEqual(_siteId, result.ResourceLinks[0].SiteId);
            Assert.AreEqual(_workdays, result.ResourceLinks[0].Workdays);
            Assert.AreEqual(_hours, result.ResourceLinks[0].Hours);
        }

        [TestMethod]
        public void ProcessResourcePlan_ResourcePlanListsNotEmpty_ProcessingCalled()
        {
            // Arrange
            var isPlanListProcessingCalled = false;
            ShimResourcePlan.ProcessResourcePlanListStringSPWebGuidResourcePlanProcessingResultRef =
                (string resourcePlanList, SPWeb web, Guid siteId, ref ResourcePlanProcessingResult processingResult) =>
                {
                    isPlanListProcessingCalled = true;
                };

            // Act
            var result = ResourcePlan.ProcessResourcePlan(
                _resourceUrl,
                _webShim.Instance,
                _resourcePlanListsString,
                _siteId,
                _hours,
                _workdays);

            // Assert
            Assert.AreEqual(1, result.ResourceLinks.Count);
            Assert.AreEqual(_webServerRelativeUrl, result.ResourceLinks[0].ServerRelativeUrl);
            Assert.AreEqual(_resourceUrl, result.ResourceLinks[0].ResourceUrl);
            Assert.AreEqual(_siteId, result.ResourceLinks[0].SiteId);
            Assert.AreEqual(_workdays, result.ResourceLinks[0].Workdays);
            Assert.AreEqual(_hours, result.ResourceLinks[0].Hours);

            Assert.IsTrue(isPlanListProcessingCalled);
            Assert.IsTrue(result.InfoMessages.Contains("Processing: " + _resourcePlanListsString));
        }

        [TestMethod]
        public void ProcessResourcePlan_HasItemsInResourcePlanList_ListItemProcessingCalled()
        {
            // Arrange
            var isPlanListItemProcessingCalled = false;
            ShimResourcePlan.ProcessResourcePlanListItemSPListItemSPListSPWebGuidString =
                (a, b, c, d, e) =>
                {
                    isPlanListItemProcessingCalled = true;
                    return null;
                };

            // Act
            var result = ResourcePlan.ProcessResourcePlan(
                _resourceUrl,
                _webShim.Instance,
                _resourcePlanListsString,
                _siteId,
                _hours, 
                _workdays);

            // Assert
            Assert.IsTrue(isPlanListItemProcessingCalled);
        }
    }
}
