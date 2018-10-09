using System;
using System.Data.SqlClient.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    public partial class GetTsTests
    {
        private const string PageLoadMethod = "Page_Load";
        
        [TestMethod]
        public void PageLoad_Should_Succeed()
        {
            PageLoadCommon();
        }

        private void PageLoadCommon()
        {
            // Arrange
            var addGroupsWasCalled = false;
            var addHeaderWasCalled = false;
            Shimgetts.AllInstances.addGroupsSPWeb = (a, b) => addGroupsWasCalled = true;
            Shimgetts.AllInstances.addHeaderSPWeb = (a, b) => addHeaderWasCalled = true;

            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();

            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy();

            ShimHttpRequest.AllInstances.ItemGetString = (a, b) => string.Empty;

            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (a, b, c, d) => "http://test.com";

            ShimSPWeb.AllInstances.UrlGet = _ => "HTTP://TEST.COM";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();

            ShimSPListCollection.AllInstances.ItemGetString = (a, b) => new ShimSPList();

            // Act
            _privateObject.Invoke(PageLoadMethod, new object[] { new object(), EventArgs.Empty });
            var data = _privateObject.GetFieldOrProperty("data");
            var docXml = _privateObject.GetFieldOrProperty(docXmlProperty) as XmlDocument;

            // Assert
            Assert.IsTrue(addGroupsWasCalled);
            Assert.IsTrue(addHeaderWasCalled);

            Assert.IsNotNull(docXml);
            docXml.OuterXml.ShouldBe(data);
        }
    }
}