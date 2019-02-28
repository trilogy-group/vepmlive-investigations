using System;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise.Layouts.epmlive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using NUnit.Framework;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestFixture]
    public class EPubStatusTest
    {
        private MethodInfo _pageLoadMethod;
        private epubstatus _epubstatus;
        private EventArgs _args;
        private IDisposable _shimsContext;
        protected AdoShims _adoShims;
        protected SharepointShims _sharepointShims;

        [SetUp]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _pageLoadMethod = typeof(epubstatus).GetMethod("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic);
            _epubstatus = new epubstatus();
            _args = new EventArgs();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

        }

        [TearDown]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [Test]
        public void PageLoad_ActionDelete_AdoDisposed()
        {
            // Arrange
            SetupShims("delete", _epubstatus);

            // Act
            _pageLoadMethod.Invoke(_epubstatus, new object[] {null, _args});

            // Assert
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataAdaptersDisposed.Count);
            Assert.AreEqual(
                "DELETE FROM publishercheck where projectguid=@projectguid",
                _adoShims.CommandsDisposed[0].CommandText);
        }

        [Test]
        public void PageLoad_ActionUnlink_AdoDisposed()
        {
            // Arrange
            SetupShims("unlink", _epubstatus);

            // Act
            _pageLoadMethod.Invoke(_epubstatus, new object[] { null, _args });

            // Assert
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataAdaptersDisposed.Count);
            Assert.AreEqual(
                "UPDATE publishercheck set weburl='',webguid=NULL where projectguid=@projectguid",
                _adoShims.CommandsDisposed[0].CommandText);
        }

        private void SetupShims(string actionName, epubstatus page)
        {
            ShimHttpRequest.AllInstances.ItemGetString = (request, s) =>
            {
                var result = actionName;
                return result;
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action.Invoke();
            ShimCoreFunctions.getConnectionStringGuid = guid => string.Empty;

            ShimSPContext.AllInstances.SiteGet = context => _sharepointShims.SiteShim;
            _sharepointShims.SiteShim.WebApplicationGet = () => _sharepointShims.ApplicationShim;

            var field = typeof(epubstatus).GetField("GvItems", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(page, (SPGridView)new ShimSPGridView());
        }
    }
}
