using System;
using System.Web;
using System.Web.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestClass]
    public class EActionTests
    {
        private const string DummyUrl = "DummyUrl";
        private const string DummyConnection = "DummyConnection";
        private const string DummyGuid = "45123065201040805060203010405080";

        private IDisposable _shimsContext;
        private eaction _eAction;
        private PrivateObject _privateObject;
        private AdoShims _adoShims;

        [TestInitialize]
        public void Setup()
        {
            _shimsContext = ShimsContext.Create();
            _eAction = new eaction();
            _privateObject = new PrivateObject(_eAction);
            _adoShims = AdoShims.ShimAdoNetCalls();
        }


        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void ExecuteQuery_ProperlyDisposes()
        {
            // Arrange
            var spWeb = new ShimSPWeb
            {
                UrlGet = () => DummyUrl
            };
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyConnection;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication());
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid(DummyGuid);
            _privateObject.SetFieldOrProperty("_request", (HttpRequest)new ShimHttpRequest());
            ShimHttpRequest.AllInstances.ItemGetString = (_, str) => str;

            // Act
            _privateObject.Invoke("ExecuteQuery", (SPWeb)spWeb);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1));
        }
    }
}
