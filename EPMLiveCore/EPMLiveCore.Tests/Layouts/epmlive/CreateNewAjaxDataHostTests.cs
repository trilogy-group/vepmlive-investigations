using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class CreateNewAjaxDataHostTests
    {
        private const string SuccessString = "Success";
        private IDisposable _context;
        private CreateNewAjaxDataHost _createNewAjaxDataHost;
        private PrivateObject _privateObject;
        private PrivateObject _privatePageObject;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _createNewAjaxDataHost = new CreateNewAjaxDataHost();
            _privateObject = new PrivateObject(_createNewAjaxDataHost);
            _privatePageObject = new PrivateObject(_createNewAjaxDataHost, new PrivateType(typeof(Page)));
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void PageLoad_Loads()
        {
            // Arrange
            _privatePageObject.SetField("_response", (HttpResponse)new ShimHttpResponse());
            _privatePageObject.SetField("_request", (HttpRequest)new ShimHttpRequest());
            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy();
            int actualCache = int.MinValue;
            ShimHttpResponse.Behavior = ShimBehaviors.DefaultValue;
            ShimHttpResponse.AllInstances.ExpiresSetInt32 = (_1, i) => actualCache = i;
            ShimHttpRequest.AllInstances.ItemGetString = (_, str) => str;
            var buildListItemWasCalled = false;
            ShimCreateNewAjaxDataHost.AllInstances.BuildListItemHTML = _ =>
            {
                buildListItemWasCalled = true;
                return SuccessString;
            };
            TextWriter writer = new StringWriter();
            ShimHttpResponse.AllInstances.OutputGet = _ => writer;

            // Act
            _privateObject.Invoke("Page_Load", this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => writer.ToString().ShouldBe($"{SuccessString}\n", StringCompareShould.IgnoreLineEndings),
                () => buildListItemWasCalled.ShouldBeTrue(),
                () => actualCache.ShouldBe(-1));
        }
    }
}