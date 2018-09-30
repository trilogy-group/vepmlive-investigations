using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Fakes;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise.Layouts.epmlive;
using EPMLiveEnterprise.Layouts.epmlive.Fakes;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcCustomFields.Fakes;
using EPMLiveEnterprise.WebSvcEvents;
using EPMLiveEnterprise.WebSvcEvents.Fakes;
using EPMLiveEnterprise.WebSvcLookupTables.Fakes;
using EPMLiveEnterprise.WebSvcProject.Fakes;
using EPMLiveEnterprise.WebSvcWssInterop.Fakes;
using Microsoft.Office.Project.Server.Library.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using RR = EPMLiveEnterprise.WebSvcResource.Fakes;
using static EPMLiveEnterprise.WebSvcWssInterop.Fakes.ShimWssSettingsDataSet;
using static EPMLiveEnterprise.WebSvcResource.Fakes.ShimResourceDataSet;
using static EPMLiveEnterprise.WebSvcResource.ResourceDataSet;
using System.Data.Fakes;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class EconfigTest
    {
        private IDisposable shimsContext;
        private econfig testEntity;
        private PrivateObject privateObject;
        private CultureInfo currentCulture;
        private const string ValidUrl = "http://fake.url";
        private const string DummyString = "dummy";
        private DropDownList ddlAssignedToField;
        private DropDownList ddlTimesheet;
        private DropDownList ddlTimesheetHours;
        private ListBox lstSelectedTemplates;
        private ListBox lstAllTemplates;
        private Label lblProjectPublished;
        private Label lblStatusingApplied;
        private Label lblResUpdated;
        private Label lblResCreated;
        private Label lblResDeleted;
        private CheckBox chkCrossSite;
        private CheckBox chkLockSynch;
        private CheckBox chkForceWS;
        private TextBox txtDefaultURL;
        private TextBox txtUrls;
        private Label lblError;
        private int sqlReaderReadCount;
        private int executeReaderCallCount;
        private int sqlCommandDisposeCallCount;
        private bool isConnectionOpenedCalled;
        private bool isExecuteNonQueryCalled;
        private bool isConnectionDisposeCalled;
        private bool isConnectionCloseCalled;
        private String errorMessage;
        private String redirectPath;
        private String logMessage;

        [TestInitialize]
        public void TestInitialize()
        {
            sqlReaderReadCount = 0;
            executeReaderCallCount = 0;
            sqlCommandDisposeCallCount = 0;
            isConnectionOpenedCalled = false;
            isExecuteNonQueryCalled = false;
            isConnectionDisposeCalled = false;
            isConnectionCloseCalled = false;
            errorMessage = string.Empty;
            redirectPath = string.Empty;
            logMessage = string.Empty;
            currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            shimsContext = ShimsContext.Create();
            testEntity = new econfig();
            privateObject = new PrivateObject(testEntity);
            InitializeUiControls();
            SetupShims();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (code) =>
            {
                SetupShims();
                code.Invoke();
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            shimsContext?.Dispose();
            testEntity?.Dispose();
            ddlAssignedToField?.Dispose();
            ddlTimesheet?.Dispose();
            ddlTimesheetHours?.Dispose();
            lstSelectedTemplates?.Dispose();
            lstAllTemplates?.Dispose();
            lblProjectPublished?.Dispose();
            lblStatusingApplied?.Dispose();
            lblResUpdated?.Dispose();
            lblResCreated?.Dispose();
            lblResDeleted?.Dispose();
            chkCrossSite?.Dispose();
            chkLockSynch?.Dispose();
            chkForceWS?.Dispose();
            txtDefaultURL?.Dispose();
            txtUrls?.Dispose();
            lblError?.Dispose();
            Thread.CurrentThread.CurrentCulture = currentCulture;
        }
        
        private void InitializeUiControls()
        {
            ddlAssignedToField = new DropDownList();
            privateObject.SetFieldOrProperty("ddlAssignedToField", ddlAssignedToField);

            ddlTimesheet = new DropDownList();
            privateObject.SetFieldOrProperty("ddlTimesheet", ddlTimesheet);

            ddlTimesheetHours = new DropDownList();
            privateObject.SetFieldOrProperty("ddlTimesheetHours", ddlTimesheetHours);

            lstSelectedTemplates = new ListBox();
            privateObject.SetFieldOrProperty("lstSelectedTemplates", lstSelectedTemplates);

            lstAllTemplates = new ListBox();
            privateObject.SetFieldOrProperty("lstAllTemplates", lstAllTemplates);

            lblProjectPublished = new Label();
            privateObject.SetFieldOrProperty("lblProjectPublished", lblProjectPublished);

            lblStatusingApplied = new Label();
            privateObject.SetFieldOrProperty("lblStatusingApplied", lblStatusingApplied);

            lblResUpdated = new Label();
            privateObject.SetFieldOrProperty("lblResUpdated", lblResUpdated);

            lblResCreated = new Label();
            privateObject.SetFieldOrProperty("lblResCreated", lblResCreated);

            lblResDeleted = new Label();
            privateObject.SetFieldOrProperty("lblResDeleted", lblResDeleted);

            chkCrossSite = new CheckBox();
            privateObject.SetFieldOrProperty("chkCrossSite", chkCrossSite);

            chkForceWS = new CheckBox();
            privateObject.SetFieldOrProperty("chkForceWS", chkForceWS);

            chkLockSynch = new CheckBox();
            privateObject.SetFieldOrProperty("chkLockSynch", chkLockSynch);

            txtDefaultURL = new TextBox();
            privateObject.SetFieldOrProperty("txtDefaultURL", txtDefaultURL);

            txtUrls = new TextBox();
            privateObject.SetFieldOrProperty("txtUrls", txtUrls);

            lblError = new Label();
            privateObject.SetFieldOrProperty("lblError", lblError);
        }

        [TestMethod()]
        public void Econfig_Page_Load_IsPostBack_False_InitializeControls()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;

            // Act
            var result = privateObject.Invoke("Page_Load",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => sqlReaderReadCount.ShouldBe(9),
                () => executeReaderCallCount.ShouldBe(9),
                () => sqlCommandDisposeCallCount.ShouldBe(9),
                () => isConnectionOpenedCalled.ShouldBeTrue(),
                () => isExecuteNonQueryCalled.ShouldBeFalse(),
                () => isConnectionDisposeCalled.ShouldBeTrue(),
                () => isConnectionCloseCalled.ShouldBeFalse(),
                () => lblProjectPublished.Text.ShouldBe("Not Installed"),
                () => lblStatusingApplied.Text.ShouldBe("Not Installed"),
                () => lblResUpdated.Text.ShouldBe("Not Installed"),
                () => lblResCreated.Text.ShouldBe("Not Installed"),
                () => lblResDeleted.Text.ShouldBe("Not Installed"),
                () => chkCrossSite.Checked.ShouldBeTrue(),
                () => txtDefaultURL.Text.ShouldBe("true"),
                () => txtUrls.Text.ShouldBe("true"),
                () => lblError.Visible.ShouldBeFalse(),
                () => lblError.Text.ShouldBe(string.Empty),
                () => errorMessage.ShouldBe(string.Empty));

        }

        [TestMethod()]
        public void Econfig_lnkSynchResources_Click_GivenArguments_ConfirmRedirect()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;

            // Act
            var result = privateObject.Invoke("lnkSynchResources_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => redirectPath.ShouldBe("epmlive/econfig.aspx"),
                () => sqlReaderReadCount.ShouldBe(1),
                () => executeReaderCallCount.ShouldBe(1),
                () => sqlCommandDisposeCallCount.ShouldBe(0),
                () => isConnectionOpenedCalled.ShouldBeTrue(),
                () => isExecuteNonQueryCalled.ShouldBeFalse(),
                () => isConnectionDisposeCalled.ShouldBeFalse(),
                () => isConnectionCloseCalled.ShouldBeTrue());

        }

        [TestMethod()]
        public void Econfig_lnkReactivate_Click_GivenArguments_ConfirmLogs()
        {
            // Arrange
            SetupShims();
            ShimDataTable.AllInstances.SelectString = (_, __) => new DataRow[0];
            var obj = new Object();
            var eventArgs = EventArgs.Empty;

            // Act
            var result = privateObject.Invoke("lnkReactivate_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => logMessage.ShouldBe("Successfully started install of EPM Live Publishing EventHandler (Project.Published)Successfully started install of EPM Live Statusing EventHandler (Statusing.Applied)Successfully started install of EPM Live Resource EventHandler (Resource.Updated)Successfully started install of EPM Live Resource EventHandler (Resource.Created)Successfully started install of EPM Live Resource EventHandler (Resource.Deleting)"));

        }

        [TestMethod()]
        public void Econfig_btnCancel_Click_GivenArguments_ConfirmRedirect()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;

            // Act
            var result = privateObject.Invoke("btnCancel_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => redirectPath.ShouldBe("default.aspx"));

        }

        [TestMethod()]
        public void Econfig_btnAdd_Click_GivenArguments_ConfirmDropDownListItems()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;
            ShimListItem.AllInstances.SelectedGet = (_) => true;
            lstAllTemplates = new ListBox();
            lstAllTemplates.Items.Add(DummyString);
            privateObject.SetFieldOrProperty("lstAllTemplates", lstAllTemplates);

            // Act
            var result = privateObject.Invoke("btnAdd_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => lstSelectedTemplates.Items.Count.ShouldBe(1),
                () => lstAllTemplates.Items.Count.ShouldBe(0));
        }

        [TestMethod()]
        public void Econfig_btnRemove_Click_GivenArguments_ConfirmDropDownListItems()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;
            ShimListItem.AllInstances.SelectedGet = (_) => true;
            lstSelectedTemplates = new ListBox();
            lstSelectedTemplates.Items.Add(DummyString);
            privateObject.SetFieldOrProperty("lstSelectedTemplates", lstSelectedTemplates);

            // Act
            var result = privateObject.Invoke("btnRemove_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => lstSelectedTemplates.Items.Count.ShouldBe(0),
                () => lstAllTemplates.Items.Count.ShouldBe(1));

        }

        [TestMethod()]
        public void Econfig_Button1_Click_ConfirmCalls()
        {
            // Arrange
            SetupShims();
            var obj = new Object();
            var eventArgs = EventArgs.Empty;

            // Act
            var result = privateObject.Invoke("Button1_Click",
                new object[] { obj, eventArgs });

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull(),
                () => sqlReaderReadCount.ShouldBe(9),
                () => executeReaderCallCount.ShouldBe(9),
                () => sqlCommandDisposeCallCount.ShouldBe(0),
                () => isConnectionOpenedCalled.ShouldBeTrue(),
                () => isExecuteNonQueryCalled.ShouldBeTrue(),
                () => isConnectionDisposeCalled.ShouldBeFalse(),
                () => isConnectionCloseCalled.ShouldBeTrue(),
                () => lblError.Visible.ShouldBeTrue(),
                () => lblError.Text.ShouldBe(string.Empty),
                () => errorMessage.ShouldBe(string.Empty));

        }

        private void SetupShims()
        {
            var spArray = new SPField[1];
            spArray[0] = new ShimSPField()
            {
                IdGet = () => Guid.Empty,
                ReorderableGet = () => true,
                ShowInEditFormGet = () => true,
                InternalNameGet = () => string.Empty
            };
            var webApplication = new SPWebApplication()
            {
                Id = Guid.Empty
            };
            var spFieldCollection = new ShimSPFieldCollection()
            {
                ItemGetGuid = _ => (spArray as SPField[])?[0]
            };
            var spList = new ShimSPList()
            {
                FieldsGet = () => spFieldCollection
            };
            var spListCollection = new ShimSPListCollection()
            {
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList
            };
            var webTemplate = new ShimSPWebTemplate()
            {
                IsHiddenGet = () => false,
                TitleGet = () => DummyString,
            }.Instance;
            var listWebTemplate = new List<SPWebTemplate>()
            {
                webTemplate,
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = (_) => listWebTemplate.GetEnumerator();
            var spWeb = new ShimSPWeb()
            {
                Close = () => { },
                ListsGet = () => spListCollection,
                GetAvailableWebTemplatesUInt32 = _ => new ShimSPWebTemplateCollection()
                {
                    ItemGetInt32 = (idx) => webTemplate,
                }.Instance,
                AllUsersGet = () => new ShimSPUserCollection(),
            };
            var shimSPSite = new ShimSPSite()
            {
                IDGet = () => new Guid(),
                WebApplicationGet = () => webApplication,
                RootWebGet = () => spWeb,
                UrlGet = () => ValidUrl,
                Close = () => { },
                ServerRelativeUrlGet = () => ValidUrl
            };
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.OpenWeb = (_) => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_,__) => spWeb;
            ShimSPSite.AllInstances.UrlGet = (_) => ValidUrl;
            ShimSPSite.AllInstances.WebApplicationGet = (_) => webApplication;
            ShimSPSite.AllInstances.WebApplicationGet = (_) => webApplication;
            ShimSPSite.AllInstances.Close = (_) => { };
            ShimSPSite.AllInstances.Dispose = (_) => { };
            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext()
            {
                UserGet = () => new GenericPrincipal(
                    new GenericIdentity(string.Empty),
                    new string[0])
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => shimSPSite,
                WebGet = () => spWeb
            };
            ShimPage.AllInstances.ResponseGet = (_) => new ShimHttpResponse()
            {
                WriteString = (str) => { errorMessage = str; },
            }.Instance;
            ShimCustomFields.Constructor = (_) => { };
            ShimCustomFields.AllInstances.ReadCustomFieldsByEntityGuid = (_,__) => GetDummyDataSet();
            ShimLookupTable.Constructor = (_) => { };
            RR.ShimResource.Constructor = (_) => { };
            var resDataTable = new ResourcesDataTable();
            RR.ShimResource.AllInstances.ReadUserListResourceActiveFilter = (_, __) => new RR.ShimResourceDataSet()
            {
                ResourcesGet = () => resDataTable,
            }.Instance;
            ShimEntity.AllInstances.UniqueIdGet = (_) => Guid.NewGuid().ToString();
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                isConnectionOpenedCalled = true;
            };
            ShimSqlCommand.ConstructorString = (_, __) => { };      
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                executeReaderCallCount++;
                return new ShimSqlDataReader();
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                isExecuteNonQueryCalled = true;
                return 0;
            };
            ShimSqlConnection.AllInstances.Close = (_) =>
            {
                isConnectionCloseCalled = true;
            };
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, __) =>
            {
                isConnectionDisposeCalled = true;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) =>
            {
                sqlCommandDisposeCallCount++;
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                sqlReaderReadCount++;
                return true;
            };
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.Empty;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, __) => "true";
            ShimEvents.Constructor = (_) => { };
            ShimEvents.AllInstances.UrlSetString = (_, __) => { };
            ShimEvents.AllInstances.UseDefaultCredentialsSetBoolean = (_, __) => { };
            ShimEvents.AllInstances.ReadEventHandlerAssociations = (_) => new ShimEventHandlersDataSet()
            {
                EventHandlersGet = () => new EventHandlersDataSet.EventHandlersDataTable(),
            }.Instance;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (path, __, ___) =>
            {
                redirectPath = path;
                return true;
            };
            ShimHttpResponse.AllInstances.RedirectString = (_, path) =>
            {
                redirectPath = path;
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => null;
            ShimEventLog.AllInstances.WriteEntryString = (_, logMsg) =>
            {
                logMessage += logMsg;
            };
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (_, logMsg, __, ___) =>
            {
                logMessage += logMsg;
            };
            ShimEventLog.ConstructorStringStringString = (_1, _2, _3, _4) => { };
            ShimEvents.AllInstances.ReadEventHandlerAssociations = (_) => new ShimEventHandlersDataSet()
            {
                EventHandlersGet = () => new EventHandlersDataSet.EventHandlersDataTable(),
            }.Instance;
            ShimEvents.AllInstances.CreateEventHandlerAssociationsEventHandlersDataSet = (_, __) => { };
        }

        private CustomFieldDataSet GetDummyDataSet()
        {
            var dataSet = new CustomFieldDataSet();
            var table = new DataTable();
            table.Columns.Add("MD_PROP_NAME");
            table.Columns.Add("MD_PROP_UID");
            table.Columns.Add("MD_PROP_TYPE_ENUM", typeof(int));
            table.Rows.Add(new object[] { "column1_row1", "column2_row1", 21 });
            table.Rows.Add(new object[] { "column1_row2", "column2_row2", 15 });
            table.Rows.Add(new object[] { "column1_row3", "column2_row3", 17 });
            dataSet.Tables.Add(table);
            return dataSet;
        }

    }
}
