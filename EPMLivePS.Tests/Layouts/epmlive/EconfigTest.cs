using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
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
using NUnit.Framework;
using Shouldly;
using static EPMLiveEnterprise.WebSvcEvents.Fakes.ShimEventHandlersDataSet;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestFixture]
    public class EconfigTest
    {
        private const int UserId = 1;
        private const string WebUrl = "www.example.com";
        private const string ServerRelativeUrl = "/";
        private const string MethodLoadEnterpriseFields = "loadEnterpriseFields";
        private const string ConnectionString = "ConnectionString";
        private static readonly Guid SpSiteId = Guid.NewGuid();
        private static readonly Guid SpWebId = Guid.NewGuid();
        private static readonly Guid SpWebApplicationId = Guid.NewGuid();

        private IDisposable _shimsContext;
        private econfig _testEntity;
        private PrivateObject _testEntityPrivate;
        private AdoShims _adoShims;
        private SPContext _spContextCurrent;

        [SetUp]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            InitializeSharePoint();

            _testEntity = new econfig();
            _testEntityPrivate = new PrivateObject(_testEntity);
            _adoShims = AdoShims.ShimAdoNetCalls();

            InitializeUiControls();
        }

        [TearDown]
        public void TearDown()
        {
            _shimsContext?.Dispose();
            _testEntity?.Dispose();
        }

        [Test]
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

        private static IEnumerable<object[]> LnkReactivateClickArguments =>
            new List<object[]>
            {
                new object[]
                {
                    "EventId = 53 and name = 'EPMLivePublisher'",
                    "73DBE692-F21D-4129-8E2B-8B1ED4FA00F5",
                    "EPMLivePublisher",
                    "EPMLiveEnterprise.OnPublish",
                    53,
                    "Successfully started install of EPM Live Publishing EventHandler (Project.Published)"
                },
                new object[]
                {
                    "EventId = 133 and name = 'EPMLiveStatusing'",
                    "8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B",
                    "EPMLiveStatusing",
                    "EPMLiveEnterprise.Status",
                    133,
                    "Successfully started install of EPM Live Statusing EventHandler (Statusing.Applied)"
                },
                new object[]
                {
                    "EventId = 95 and name = 'EPMLiveResUpdated'",
                    "B0C1D09C-F1F6-4a6b-858C-529E22B7688C",
                    "EPMLiveResUpdated",
                    "EPMLiveEnterprise.ResourceEvents",
                    95,
                    "Successfully started install of EPM Live Resource EventHandler (Resource.Updated)"
                },
                new object[]
                {
                    "EventId = 89 and name = 'EPMLiveResCreated'",
                    "286DE0F8-2042-4c8b-A8F7-3E276150CD9C",
                    "EPMLiveResCreated",
                    "EPMLiveEnterprise.ResourceEvents",
                    89,
                    "Successfully started install of EPM Live Resource EventHandler (Resource.Created)"
                },
                new object[]
                {
                    "EventId = 92 and name = 'EPMLiveResDeleting'",
                    "074BCE6F-CF3B-4a94-BCC4-A262B32AE41E",
                    "EPMLiveResDeleting",
                    "EPMLiveEnterprise.ResourceEvents",
                    92,
                    "Successfully started install of EPM Live Resource EventHandler (Resource.Deleting)"
                }
            };

        [Test]
        [TestCaseSource(nameof(LnkReactivateClickArguments))]
        public void LnkReactivateClick_IfDataTableSelectMethodReturnsValue_CreatesEventHandlerAssociations(
            string expectedExpression,
            string expectedEventHandlerId,
            string expectedName,
            string expectedClassName,
            int expectedEventId,
            string expectedLogMessage)
        {
            // Arrange
            SetupShimEvents(expectedExpression);

            var passedGuid = Guid.Empty;
            var passedName = string.Empty;
            var passedClassName = string.Empty;
            var passedEventId = default(int);

            ShimEventHandlersDataSet.Constructor = instance =>
            {
                var shimHandlerDataSet = new ShimEventHandlersDataSet(instance);
                var shimHandlerDataTable = new ShimEventHandlersDataTable();
                shimHandlerDataTable.AddEventHandlersRowGuidStringStringStringInt32StringInt32 =
                    (eventHandlerId, name, assemblyName, className, eventId, description, order) =>
                    {
                        passedGuid = eventHandlerId;
                        passedName = name;
                        passedClassName = className;
                        passedEventId = eventId;

                        return null;
                    };

                shimHandlerDataSet.EventHandlersGet = () => shimHandlerDataTable.Instance;
            };

            var passedMessage = string.Empty;
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 =
                (instance, message, logType, eventId) => passedMessage = message;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();

            // Act
            _testEntityPrivate.Invoke("lnkReactivate_Click", this, EventArgs.Empty);

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => passedGuid.ShouldBe(new Guid(expectedEventHandlerId)),
                () => passedName.ShouldBe(expectedName),
                () => passedClassName.ShouldBe(expectedClassName),
                () => passedEventId.ShouldBe(expectedEventId),
                () => passedMessage.ShouldBe(expectedLogMessage));
        }

        [Test]
        public void Button1Click_Always_CreatesConnectionAndSetsValues()
        {
            // Arrange
            var passedValues = new Dictionary<string, string>();

            var shimEconfig = new Shimeconfig(_testEntity);
            shimEconfig.setValSqlConnectionStringString =
                (connection, itemKey, itemValue) => passedValues.Add(itemKey, itemValue);

            ShimCoreFunctions.getConnectionStringGuid = _ => ConnectionString;

            SetupPageControls();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();

            // Act
            _testEntityPrivate.Invoke("Button1_Click", this, EventArgs.Empty);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.IsConnectionCreated(ConnectionString).ShouldBeTrue(),
                () => _adoShims.IsConnectionOpened(ConnectionString).ShouldBeTrue(),
                () => _adoShims.IsConnectionDisposed(ConnectionString).ShouldBeTrue(),
                () => passedValues.ShouldContainKey("AssignedToField"),
                () => passedValues.ShouldContainKey("TimesheetField"),
                () => passedValues.ShouldContainKey("TimesheetHoursField"),
                () => passedValues.ShouldContainKey("LockSynch"),
                () => passedValues.ShouldContainKey("ForceWS"),
                () => passedValues.ShouldContainKey("CrossSite"),
                () => passedValues.ShouldContainKey("DefaultURL"),
                () => passedValues.ShouldContainKey("ConnectedURLs"),
                () => passedValues.ShouldContainKey("ValidTemplates"));
        }

        [Test]
        public void SetVal_Always_SelectsConfigValueFromEconfig()
        {
            // Arrange
            const string cmdTextTemplate = "SELECT config_value FROM ECONFIG where config_name='{0}'";
            const string itemKey = "Key";
            var expectedCmdText = string.Format(cmdTextTemplate, itemKey);

            // Act
            _testEntityPrivate.Invoke("setVal", null, itemKey, string.Empty);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.Count.ShouldBe(2),
                () => _adoShims.IsCommandCreated(expectedCmdText).ShouldBeTrue(),
                () => _adoShims.IsCommandExecuted(expectedCmdText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCmdText).ShouldBeTrue());
        }

        [Test]
        public void SetVal_IfDataReaderReturnsValue_UpdatesEconfig()
        {
            // Arrange
            const string cmdTextTemplate = "UPDATE ECONFIG set config_value = @val where config_name='{0}'";
            const string itemKey = "Key";
            const string itemValue = "Value";
            var expectedCmdText = string.Format(cmdTextTemplate, itemKey);

            ShimSqlDataReader.AllInstances.Read = _ => true;

            // Act
            _testEntityPrivate.Invoke("setVal", null, itemKey, itemValue);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.Count.ShouldBe(2),
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(expectedCmdText) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals("@val") &&
                           cmd.Parameters[0].Value.Equals(itemValue)),
                () => _adoShims.IsCommandExecuted(expectedCmdText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCmdText).ShouldBeTrue());
        }

        [Test]
        public void SetVal_IfDataReaderDoesNotReturnValue_InsertsEconfig()
        {
            // Arrange
            const string cmdTextTemplate = "INSERT INTO ECONFIG (config_value,config_name) VALUES (@val,'{0}')";
            const string itemKey = "Key";
            const string itemValue = "Value";
            var expectedCmdText = string.Format(cmdTextTemplate, itemKey);

            ShimSqlDataReader.AllInstances.Read = _ => false;

            // Act
            _testEntityPrivate.Invoke("setVal", null, itemKey, itemValue);

            // Assert
            _adoShims.ShouldSatisfyAllConditions(
                () => _adoShims.CommandsCreated.Count.ShouldBe(2),
                () => _adoShims.CommandsCreated.ShouldContain(
                    cmd => cmd.CommandText.Equals(expectedCmdText) &&
                           cmd.Parameters.Count == 1 &&
                           cmd.Parameters[0].ParameterName.Equals("@val") &&
                           cmd.Parameters[0].Value.Equals(itemValue)),
                () => _adoShims.IsCommandExecuted(expectedCmdText).ShouldBeTrue(),
                () => _adoShims.IsCommandDisposed(expectedCmdText).ShouldBeTrue());
        }

        private void SetupShimEvents(string expectedFilterExpression)
        {
            var shimEventHandlerDataSet = new ShimEventHandlersDataSet();
            var shimEventHandlerDataTable = new ShimEventHandlersDataTable();
            var shimDataTable = new ShimDataTable(shimEventHandlerDataTable.Instance);
            shimDataTable.SelectString = filterExpression =>
            {
                return filterExpression == expectedFilterExpression
                    ? new DataRow[0]
                    : new DataRow[1];
            };

            shimEventHandlerDataSet.EventHandlersGet = () => shimEventHandlerDataTable;
            ShimEvents.AllInstances.ReadEventHandlerAssociations = _ => shimEventHandlerDataSet;
            ShimEvents.AllInstances.CreateEventHandlerAssociationsEventHandlersDataSet = (_1, _2) => { };
            ShimEvents.AllInstances.UrlSetString = (_1, _2) => { };
            ShimEvents.AllInstances.UseDefaultCredentialsSetBoolean = (_1, _2) => { };
        }

        private void SetupPageControls()
        {
            var bindFlags = System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Instance;

            var fields = _testEntity.GetType().GetFields(bindFlags);
            foreach (var field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(Control)))
                {
                    var fieldInstance = Activator.CreateInstance(field.FieldType);
                    _testEntityPrivate.SetField(field.Name, fieldInstance);
                }
            }
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
