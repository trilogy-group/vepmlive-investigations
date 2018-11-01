using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.WorkEngineSolutionStoreListSvc.Fakes;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.WebPageCode
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GettasksTests
    {
        private IDisposable _shimsObject;
        private gettasks _testObj;
        private PrivateObject _privateObj;
        private string _responseText;
        private bool _responseWritten;
        private ShimSPSite _site;
        private ShimSPWeb _web;
        private const string DummyUrl = "http://xyz.com";
        private const string DummyString = "DummyString";
        private const string PageLoadMethod = "Page_Load";
        private const string DummyVersion = "1.0.0";
        private Guid _guidProjectCenter;
        private Guid _guidTaskCenter;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new gettasks();
            _privateObj = new PrivateObject(_testObj);
            _guidProjectCenter = Guid.NewGuid();
            _guidTaskCenter = Guid.NewGuid();
            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = key =>
                {
                    switch (key)
                    {
                        case "ID":
                            return "1";
                        case "view":
                            return Guid.Empty.ToString();
                        case "disablefilters":
                            return "false";
                        default:
                            return string.Empty;
                    }
                }
            };
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                WriteString = text =>
                {
                    _responseText = text;
                    _responseWritten = true;
                }
            };
            ShimHttpResponse.AllInstances.CacheGet = sender => new ShimHttpCachePolicy();
            ShimLists.Constructor = _ => { };
            ShimNetworkCredential.ConstructorStringStringString = (_, s1, s2, s3) => { };
            ShimCoreFunctions.getFarmSettingString = _ => DummyUrl;
            ShimCoreFunctions.GetAssemblyVersion = () => DummyVersion;

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _web,
                SiteGet = () => _site
            };
            ShimLists.Constructor = _ => { };
            ShimSPList.AllInstances.ViewsGet = sender => new ShimSPViewCollection();
            ShimSPViewCollection.AllInstances.ItemGetGuid = (sender, guid) => new ShimSPView();
            ShimSPView.AllInstances.QueryGet = sender => string.Empty;
            Shimgettasks.AllInstances.addHeaderXmlDocument = (sender, xmlDoc) => xmlDoc;
            Shimgettasks.AllInstances.getCellDataSPListItem = (sender, xmlDoc) => string.Empty;
            ShimSPList.AllInstances.GetItemsSPQuery = (sender, spQuery) => new ShimSPListItemCollection();
            ShimSPListItemCollection.AllInstances.GetEnumerator = sender => new List<SPListItem>().GetEnumerator();
            ShimSPListItemCollection.AllInstances.ListGet = sender => new ShimSPList();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, item) =>
            {
                switch (item)
                {
                    case "EPMLiveWPProjectCenter":
                        return "EPMLiveWPProjectCenter";
                    case "EPMLiveWPTaskCenter":
                        return "EPMLiveWPTaskCenter";
                    case "EPMLiveWPUseResPool":
                        return "true";
                    case "EPMLiveResourcePool":
                        return "EPMLiveResourcePool";
                    case "EPMLiveWorkPlannerFields":
                        return "EPMLiveWorkPlannerFields";
                    default:
                        return DummyString;
                }
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_, item, translateUrl, isRelative) => item == "EPMLiveResourceURL"
                ? "EPMLiveResourceURL"
                : DummyString;
            var epmLiveWpProjectCenter = new ShimSPList()
            {
                IDGet = () => _guidProjectCenter
            };
            var epmLiveWpTaskCenter = new ShimSPList()
            {
                IDGet = () => _guidTaskCenter
            };
            var userCount = 0;
            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                AllWebsGet = () => new ShimSPWebCollection
                {
                    ItemGetString = _ => _web
                },
                RootWebGet = () => _web
            };
            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site,
                UrlGet = () => DummyString,
                AllUsersGet = () => new ShimSPUserCollection
                {
                    ItemGetString = _ =>
                    {
                        userCount++;

                        return userCount == 1
                            ? null
                            : new ShimSPUser();
                    }
                },
                ServerRelativeUrlGet = () => "/",
                GetListItemString = item => new ShimSPListItem(),
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name =>
                    {
                        switch (name)
                        {
                            case "EPMLiveWPProjectCenter":
                                return epmLiveWpProjectCenter;
                            case "EPMLiveWPTaskCenter":
                                return epmLiveWpTaskCenter;
                            default:
                                return new ShimSPList();
                        }
                    }
                }
            };
        }

        [TestMethod]
        public void PageLoad_ConfigSettingLockWebGuidEmpty_FillFields()
        {
            // Arrange
            ShimCoreFunctions.getLockedWebSPWeb = spWeb => Guid.Empty;

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((SPList)_privateObj.GetField("lstProjectCenter")).ID.ShouldBe(_guidProjectCenter),
                () => ((SPList)_privateObj.GetField("lstTaskCenter")).ID.ShouldBe(_guidTaskCenter),
                () => _privateObj.GetField("useResourcePool").ShouldBe(true),
                () => _privateObj.GetField("sResourcePoolUrl").ShouldBe("EPMLiveResourceURL"),
                () => _privateObj.GetField("sResourceList").ShouldBe("EPMLiveResourcePool"),
                () => _privateObj.GetField("wpFields").ShouldBe("EPMLiveWorkPlannerFields"),
                () => ((string)_privateObj.GetField("data")).ShouldBe(
                    "<rows><row id=\"_SummaryTask_\" style=\"font-weight:bold;\" open=\"1\" locked=\"1\" /></rows>"));
        }

        [TestMethod]
        public void PageLoad_ConfigSettingLockWebDifferentGuid_FillFields()
        {
            // Arrange
            ShimCoreFunctions.getLockedWebSPWeb = spWeb => Guid.NewGuid();

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ((SPList)_privateObj.GetField("lstProjectCenter")).ID.ShouldBe(_guidProjectCenter),
                () => ((SPList)_privateObj.GetField("lstTaskCenter")).ID.ShouldBe(_guidTaskCenter),
                () => _privateObj.GetField("useResourcePool").ShouldBe(true),
                () => _privateObj.GetField("sResourcePoolUrl").ShouldBe("EPMLiveResourceURL"),
                () => _privateObj.GetField("sResourceList").ShouldBe("EPMLiveResourcePool"),
                () => _privateObj.GetField("wpFields").ShouldBe("EPMLiveWorkPlannerFields"),
                () => ((string)_privateObj.GetField("data")).ShouldBe(
                    "<rows><row id=\"_SummaryTask_\" style=\"font-weight:bold;\" open=\"1\" locked=\"1\" /></rows>"));
        }
    }
}