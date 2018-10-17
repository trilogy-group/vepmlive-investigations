using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Configuration.Fakes;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.API.Integration.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveIntegrationService.Tests
{
    [TestClass]
    public class GoToControlTests
    {
        private const string DummyControl = "DummyControl";
        private const string DummyId = "DummyId";
        private const string DummyIntegrationId = "DummyIntegrationId";
        private const string PageLoadMethodName = "Page_Load";
        private const string LabelMessageField = "lblMessage";
        private const string RequestField = "_request";
        private const string DummyString = "DummyString";
        private const string ResponseField = "_response";
        private const string SpListItemId = "0147852369874125452102121450214";

        private static readonly Guid[] Guids = {
            new Guid("14203147854102365498741023654781"),
            new Guid("54175203164578961402365410258410"),
            new Guid("06748745745745201649785203147852"),
            new Guid("47103210405062017801546902010452"),
        };

        private IDisposable _context;
        private AdoShims _adoShims;
        private PrivateObject _privateObject;
        private PrivateObject _pagePrivateObject;
        private GoToControl _goToControl;

        private Dictionary<string, object> _parametersAdded;
        private bool _redirectWasCalled;
        private string redirectUrl;
        private Label _label;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _goToControl = new GoToControl();
            _privateObject = new PrivateObject(_goToControl);
            _pagePrivateObject = new PrivateObject(_goToControl, new PrivateType(typeof(Page)));
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void PageLoad_ControlStartsWithEPM_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(true, true, true, true, true, true, false);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(1),
                () => _redirectWasCalled.ShouldBeTrue(),
                () => _parametersAdded.Count.ShouldBe(1),
                () => _parametersAdded.Values.ShouldContain(DummyIntegrationId),
                () => redirectUrl.ShouldContain(DummyControl),
                () => redirectUrl.ShouldContain(DummyId),
                () => redirectUrl.ShouldContain(DummyIntegrationId));
        }

        [TestMethod]
        public void PageLoad_EmptyWebGuid_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(true, true, false, true, false, true, false);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _redirectWasCalled.ShouldBeFalse(),
                () => _label.Text.ShouldBe("Invalid Integration"));
        }

        [TestMethod]
        public void PageLoad_DataFailsToRead_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(true, true, false, true, true, false, false);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _redirectWasCalled.ShouldBeFalse(),
                () => _label.Text.ShouldBe("Invalid Control"));
        }

        [TestMethod]
        public void PageLoad_ControlStartsWithoutEPMAndListItemDoesntContains_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(true, true, false, true, true, true, true);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _redirectWasCalled.ShouldBeFalse(),
                () => _label.Text.ShouldBe("Couldn't find matching ID"));
        }

        [TestMethod]
        public void PageLoad_ControlStartsWithoutEPMAndListItemContains_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(true, true, false, true, true, true, false);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _redirectWasCalled.ShouldBeTrue(),
                () => _parametersAdded.Count.ShouldBe(3),
                () => _parametersAdded.Values.ShouldContain(DummyIntegrationId),
                () => _parametersAdded.Values.ShouldContain(DummyControl),
                () => redirectUrl.ShouldContain(SpListItemId),
                () => redirectUrl.ShouldContain(Guids[0].ToString()),
                () => redirectUrl.ShouldContain(Guids[3].ToString()),
                () => redirectUrl.ShouldContain(DummyControl));
        }

        [TestMethod]
        public void PageLoad_NoRequestIdControlStartsWithoutEPMAndListItemContains_RedirectsProperly()
        {
            // Arrange
            ArrangePageLoadTests(false, true, false, true, true, true, false);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsDisposed.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.DataReadersDisposed.Count.ShouldBe(2),
                () => _redirectWasCalled.ShouldBeTrue(),
                () => _parametersAdded.Count.ShouldBe(3),
                () => _parametersAdded.Values.ShouldContain(DummyIntegrationId),
                () => _parametersAdded.Values.ShouldContain(DummyControl),
                () => redirectUrl.ShouldNotContain(SpListItemId),
                () => redirectUrl.ShouldContain(Guids[0].ToString()),
                () => redirectUrl.ShouldContain(Guids[3].ToString()),
                () => redirectUrl.ShouldContain(DummyControl));
        }

        private void ArrangePageLoadTests(
            bool requestShouldHaveId,
            bool requestShouldHaveControl,
            bool shouldControlStartWithEpm,
            bool requestShouldHaveIntegration,
            bool shouldDataReadFirstCall,
            bool shouldDataReadSecondCall,
            bool shouldSPListItemCollectionBeEmpty)
        {
            _label = new Label();
            _privateObject.SetField(LabelMessageField, _label);
            _pagePrivateObject.SetField(RequestField, (HttpRequest)new ShimHttpRequest());
            ShimHttpRequest.AllInstances.ItemGetString = (_, str) =>
            {
                switch (str)
                {
                    case "ID":
                        return requestShouldHaveId
                            ? DummyId
                            : null;
                    case "Control":
                        return requestShouldHaveControl
                            ? (shouldControlStartWithEpm ? $"epmlive-{DummyControl}" : DummyControl)
                            : null;
                    case "IntegrationId":
                        return requestShouldHaveIntegration
                            ? DummyIntegrationId
                            : null;
                    default:
                        return string.Empty;
                }
            };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            var shimSpServiceCollection = new ShimSPServiceCollection();
            var shimPPersistedObjectCollection = new ShimSPPersistedObjectCollection<SPService>(shimSpServiceCollection);
            shimPPersistedObjectCollection.GetValueOf1String(_ => (SPWebService)new ShimSPWebService());
            ShimSPFarm.AllInstances.ServicesGet = _ => shimSpServiceCollection;
            ShimSPWebService.AllInstances.WebApplicationsGet = _ =>
                (SPWebApplicationCollection)new ShimSPPersistedObjectCollection<SPWebApplication>(new ShimSPWebApplicationCollection())
                {
                    GetEnumerator = () => new List<SPWebApplication>
                    {
                        (SPWebApplication)new ShimSPPersistedObject(new ShimSPWebApplication())
                        {
                            NameGet = () => "WebApplication"
                        }
                    }.GetEnumerator()
                };

            ShimConfigurationManager.AppSettingsGet = () => new ShimNameValueCollection
            {
                ItemGetString = str => str
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();

            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, index) => Guids[index];
            var firstCall = true;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (firstCall)
                {
                    firstCall = false;
                    return shouldDataReadFirstCall;
                }
                return shouldDataReadSecondCall;
            };
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_1, _2) => false;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_1, i) => i;

            ShimSPSite.ConstructorGuid = (_1, _2) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_1, _2) => new ShimSPWeb();
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_1, _2) => new ShimSPList();
            ShimSPList.AllInstances.GetItemsSPQuery = (_1, _2) => new ShimSPListItemCollection();
            ShimSPListItemCollection.AllInstances.CountGet = _ => shouldSPListItemCollectionBeEmpty ? 0 : 1;
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_1, _2) => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_1, _2) => SpListItemId;

            _parametersAdded = new Dictionary<string, object>();
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection();
            ShimSqlParameterCollection.AllInstances.AddWithValueStringObject = (_1, str, obj) =>
            {
                _parametersAdded[str] = obj;
                return new ShimSqlParameter();
            };
            _pagePrivateObject.SetField(ResponseField, (HttpResponse)new ShimHttpResponse());
            _redirectWasCalled = false;
            redirectUrl = null;
            ShimHttpResponse.AllInstances.RedirectString = (_1, str) =>
            {
                _redirectWasCalled = true;
                redirectUrl = str;
            };
            ShimIntegrationCore.ConstructorGuidGuid = (_1, _2, _3) => new ShimIntegrationCore();
            ShimIntegrationCore.AllInstances.GetControlURLGuidGuidStringString = (
                _,
                guid1,
                guid2,
                string1,
                string2) => $"{guid1}{guid2}{string1}{string2}";
        }
    }
}
