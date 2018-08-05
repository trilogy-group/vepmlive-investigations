using System;
using System.Linq;
using System.Web.UI;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise.Layouts.epmlive;
using EPMLiveEnterprise.Layouts.epmlive.Fakes;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
using EPMLiveEnterprise.WebSvcEvents;
using EPMLiveEnterprise.WebSvcEvents.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestClass]
    public class EconfigTest
    {
        private const int UserId = 1;
        private const string WebUrl = "www.example.com";
        private const string ServerRelativeUrl = "/";
        private const string MethodLoadEnterpriseFields = "loadEnterpriseFields";
        private static readonly Guid SpSiteId = Guid.NewGuid();
        private static readonly Guid SpWebId = Guid.NewGuid();
        private static readonly Guid SpWebApplicationId = Guid.NewGuid();

        private IDisposable _shimsContext;
        private econfig _testEntity;
        private PrivateObject _testEntityPrivate;
        private AdoShims _adoShims;
        private SPContext _spContextCurrent;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            InitializeSharePoint();

            _testEntity = new econfig();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _adoShims = AdoShims.ShimAdoNetCalls();

            InitializeUiControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void LoadEnterpriseFields_WhenCalled_FetchesDataFromDbAndSelectsRelatedItemInDropDownList()
        {
            // Arrange
            ArrangeShimsForLoadEnterpriseFields();
            const string expectedCommandText01 = "SELECT config_value FROM ECONFIG where config_name='AssignedToField'";
            const string expectedCommandText02 = "SELECT config_value FROM ECONFIG where config_name='TimesheetField'";
            const string expectedCommandText03 = "SELECT config_value FROM ECONFIG where config_name='TimesheetHoursField'";
            const string expectedCommandText04 = "SELECT config_value FROM ECONFIG where config_name='LockSynch'";
            const string expectedCommandText05 = "SELECT config_value FROM ECONFIG where config_name='ForceWS'";
            const string expectedCommandText06 = "SELECT config_value FROM ECONFIG where config_name='ValidTemplates'";
            const string expectedCommandText07 = "SELECT config_value FROM ECONFIG where config_name='CrossSite'";
            const string expectedCommandText08 = "SELECT config_value FROM ECONFIG where config_name='DefaultURL'";
            const string expectedCommandText09 = "SELECT config_value FROM ECONFIG where config_name='ConnectedURLs'";

            // Act
            _testEntityPrivate.Invoke(MethodLoadEnterpriseFields);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.ConnectionsCreated.Count.ShouldBe(1),
                () => _adoShims.ConnectionsDisposed.Count.ShouldBe(1),
                () => _adoShims.CommandsCreated.Count.ShouldBe(9),
                () => _adoShims.CommandsDisposed.Count.ShouldBe(9),
                () => _adoShims.CommandsExecuted.Count.ShouldBe(9),
                () => _adoShims.DataReadersCreated.Count.ShouldBe(9),
                () => _adoShims.IsCommandExecuted(expectedCommandText01).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText02).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText03).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText04).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText05).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText06).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText07).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText08).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCommandText09).ShouldBeTrue());
        }

        private void ArrangeShimsForLoadEnterpriseFields()
        {
            ShimCustomFields.AllInstances.UrlSetString = (_, __) => { };
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_, __) => new CustomFieldDataSet();
            ShimEvents.AllInstances.UrlSetString = (_, __) => { };
            ShimEvents.AllInstances.ReadEventHandlerAssociations = _ => new EventHandlersDataSet();
            ShimCoreFunctions.getConnectionStringGuid = _ => string.Empty;
            Shimeconfig.AllInstances.loadTemplatesString = (_, __) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
        }

        private void InitializeSharePoint()
        {
            var shimSpWebApplication = new ShimSPWebApplication();
            var shimSpPersistedObject = new ShimSPPersistedObject(shimSpWebApplication)
            {
                IdGet = () => SpWebApplicationId
            };

            var shimSpSite = new ShimSPSite()
            {
                IDGet = () => SpSiteId,
                WebApplicationGet = () => shimSpWebApplication.Instance
            };

            var shimSpWeb = new ShimSPWeb()
            {
                IDGet = () => SpWebId,
                UrlGet = () => WebUrl,
                ServerRelativeUrlGet = () => ServerRelativeUrl,
                CurrentUserGet = () => new ShimSPUser()
                {
                    IDGet = () => UserId
                }
            };

            var shimSpContext = new ShimSPContext()
            {
                SiteGet = () => shimSpSite,
                WebGet = () => shimSpWeb
            };

            ShimSPContext.CurrentGet = () => shimSpContext;
            _spContextCurrent = shimSpContext.Instance;
        }

        private void InitializeUiControls()
        {
            var allFields = _testEntity.GetType()
                                       .GetFields(System.Reflection.BindingFlags.Instance |
                                                  System.Reflection.BindingFlags.NonPublic)
                                       .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _testEntityPrivate.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }
    }
}
