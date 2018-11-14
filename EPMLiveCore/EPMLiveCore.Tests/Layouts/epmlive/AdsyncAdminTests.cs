using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    using System.Collections;
    using System.Data;
    using System.Data.Fakes;
    using System.Data.SqlClient.Fakes;
    using System.Diagnostics.Fakes;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.Fakes;
    using Fakes;
    using Microsoft.SharePoint.Administration.Fakes;
    using Microsoft.SharePoint.WebControls;
    using Testables;

    [TestClass]
    public class AdsyncAdminTests
    {

        private IDisposable shimsContext;
        private adsyncadmin adsyncadmin;
        private PrivateObject privateObject;
        private string PageInitMethodName = "Page_Init";

        private readonly DropDownList FixTimes = new DropDownList();
        private readonly DropDownList DropDownListScheduleType = new DropDownList();
        private readonly DropDownList DropDownListDays = new DropDownList();
        private readonly DropDownList DropDownListTime = new DropDownList();
        private readonly Label lbl_domain = new Label();
        private readonly Label lblMessages = new Label();
        private readonly Label lblLastRun = new Label();
        private readonly ListBox lb_options = new ListBox();
        private readonly ListBox lb_selections = new ListBox();
        private readonly HiddenField selections = new HiddenField();
        private readonly Panel pnl_fieldMappings = new Panel();
        private readonly Table tbl_fieldMappings = new Table();
        private readonly HtmlTextArea txtArea_entityExclusions = new HtmlTextArea();
        private readonly Button btnRunManually = new Button();
        private readonly CheckBoxList CheckBoxList_days = new CheckBoxList();
        private readonly CheckBox cbDelete = new CheckBox();
        private readonly InputFormControl FrequencyOptions = new InputFormControlTestable();
        private string InitDomainMethodName = "InitDomain";
        private string InitResourceFieldMethodName = "InitResourceField";
        private string LoadScheduleStatusMethodName = "LoadScheduleStatus";
        private const string Dummyvalue = "DummyValue";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            adsyncadmin = new adsyncadmin();
            privateObject = new PrivateObject(adsyncadmin);

            privateObject.SetFieldOrProperty("FixTimes", FixTimes);
            privateObject.SetFieldOrProperty("DropDownListScheduleType", DropDownListScheduleType);
            privateObject.SetFieldOrProperty("DropDownListDays", DropDownListDays);
            privateObject.SetFieldOrProperty("DropDownListTime", DropDownListTime);
            privateObject.SetFieldOrProperty("lbl_domain", lbl_domain);
            privateObject.SetFieldOrProperty("lblMessages", lblMessages);
            privateObject.SetFieldOrProperty("lblLastRun", lblLastRun);
            privateObject.SetFieldOrProperty("lb_options", lb_options);
            privateObject.SetFieldOrProperty("lb_selections", lb_selections);
            privateObject.SetFieldOrProperty("selections", selections);
            privateObject.SetFieldOrProperty("pnl_fieldMappings", pnl_fieldMappings);
            privateObject.SetFieldOrProperty("tbl_fieldMappings", tbl_fieldMappings);
            privateObject.SetFieldOrProperty("txtArea_entityExclusions", txtArea_entityExclusions);
            privateObject.SetFieldOrProperty("btnRunManually", btnRunManually);
            privateObject.SetFieldOrProperty("CheckBoxList_days", CheckBoxList_days);
            privateObject.SetFieldOrProperty("cbDelete", cbDelete);
            privateObject.SetFieldOrProperty("FrequencyOptions", FrequencyOptions);
            privateObject.SetFieldOrProperty("_htDropdownIds", new Hashtable());
            
            privateObject.SetFieldOrProperty("_ADSync", new ADSync());
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
            FixTimes?.Dispose();
            DropDownListScheduleType?.Dispose();
            DropDownListDays?.Dispose();
            DropDownListTime?.Dispose();
            lbl_domain?.Dispose();
            lblMessages?.Dispose();
            lblLastRun?.Dispose();
            lb_options?.Dispose();
            lb_selections?.Dispose();
            selections?.Dispose();
            pnl_fieldMappings?.Dispose();
            tbl_fieldMappings?.Dispose();
            txtArea_entityExclusions?.Dispose();
            btnRunManually?.Dispose();
            CheckBoxList_days?.Dispose();
            cbDelete?.Dispose();
            FrequencyOptions?.Dispose();
        }

        private void SetupShims()
        {
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimAct.ConstructorSPWeb = (_, web) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimCoreFunctions.getConnectionStringGuid = _ => Dummyvalue;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.ConstructorString = (_, connection) => { };
        }

        [TestMethod]
        public void PageInit_IsOnline_ShouldRedirectPage()
        {
            // Arrange
            const string ExpectedUrl = "epmlive/noaccess.aspx";
            var redirectWasCalled = false;
            var url = string.Empty;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (redirect, flags, context) =>
            {
                redirectWasCalled = true;
                url = redirect;
                return true;
            };
            ShimAct.AllInstances.IsOnlineGet = _ => true;

            // Act
            privateObject.Invoke(PageInitMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectWasCalled.ShouldBeTrue(),
                () => url.ShouldNotBeNull(),
                () => url.ShouldBe(ExpectedUrl));
        }

        [TestMethod]
        public void PageInit_IsOnlineFalse_ShouldRedirectPage()
        {
            // Arrange
            var InitDomainWasCalled = false;
            var InitGroupsWasCalled = false;
            var InitActiveDirectorySizeLimitTextBoxWasCalled = false;
            var InitResourcePoolFieldsWasCalled = false;
            var InitScheduleWasCalled = false;
            var InitExclusionsWasCalled = false;
            var InitDeleteWasCalled = false;
            var LoadScheduleStatusWasCalled = false;
            ShimAct.AllInstances.IsOnlineGet = _ => false;
            Shimadsyncadmin.AllInstances.InitDomain = _ => InitDomainWasCalled = true;
            Shimadsyncadmin.AllInstances.InitGroups = _ => InitGroupsWasCalled = true;
            Shimadsyncadmin.AllInstances.InitActiveDirectorySizeLimitTextBox = 
                _ => InitActiveDirectorySizeLimitTextBoxWasCalled = true;
            Shimadsyncadmin.AllInstances.InitResourcePoolFields = 
                _ => InitResourcePoolFieldsWasCalled = true;
            Shimadsyncadmin.AllInstances.InitSchedule = _ => InitScheduleWasCalled = true;
            Shimadsyncadmin.AllInstances.InitExclusions = _ => InitExclusionsWasCalled = true;
            Shimadsyncadmin.AllInstances.InitDelete = _ => InitDeleteWasCalled = true;
            Shimadsyncadmin.AllInstances.LoadScheduleStatus = _ => LoadScheduleStatusWasCalled = true;

            // Act
            privateObject.Invoke(PageInitMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => InitDomainWasCalled.ShouldBeTrue(),
                () => InitGroupsWasCalled.ShouldBeTrue(),
                () => InitActiveDirectorySizeLimitTextBoxWasCalled.ShouldBeTrue(),
                () => InitResourcePoolFieldsWasCalled.ShouldBeTrue(),
                () => InitScheduleWasCalled.ShouldBeTrue(),
                () => InitExclusionsWasCalled.ShouldBeTrue(),
                () => InitDeleteWasCalled.ShouldBeTrue(),
                () => LoadScheduleStatusWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void InitDomain_Should_ExecuteCOrrectly()
        {
            // Arrange
            const string Domain = "Domain.com";
            ShimADSync.AllInstances.GetFullDomain = _ => Domain;

            // Act
            privateObject.Invoke(InitDomainMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lbl_domain.Text.ShouldNotBeNullOrEmpty(),
                () => lbl_domain.Text.ShouldBe(Domain));
        }

        [TestMethod]
        public void InitResourceField_Should_ExecuteCorrectly()
        {
            // Arrange
            Shimadsyncadmin.AllInstances.ADFieldsString = (_, name) => new DropDownList();
            TableRow row = null;
            ShimTableRowCollection.AllInstances.AddTableRow = (_, dataRow) =>
            {
                row = dataRow;
                return 1;
            };

            // Act
            privateObject.Invoke(InitResourceFieldMethodName, "dummyValue");

            // Assert
            row.Cells.Count.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void LoadScheduleStatus_Status0_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "Queued";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                IsDBNullInt32 = i => false,
                GetInt32Int32 = i => 0,
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => lblMessages.Text.ShouldBe(ExpectedValue),
                () => btnRunManually.Enabled.ShouldBeFalse());
        }

        [TestMethod]
        public void LoadScheduleStatus_Status1_ExecutesCorrectly()
        {
            // Arrange
            var ExpectedValue = $"Processing ({1.ToString("##0")}%)";
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                IsDBNullInt32 = i => false,
                GetInt32Int32 = i => 1
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => lblMessages.Text.ShouldBe(ExpectedValue),
                () => btnRunManually.Enabled.ShouldBeFalse());
        }

        [TestMethod]
        public void LoadScheduleStatus_Status5_ExecutesCorrectly()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                IsDBNullInt32 = i => false,
                GetInt32Int32 = i => 5,
                GetStringInt32 = i => Dummyvalue
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => lblMessages.Text.ShouldBe(Dummyvalue));
        }

        [TestMethod]
        public void LoadScheduleStatus_StatusDefaultValue_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "No Results";
            var dummyDate = DateTime.Now;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                IsDBNullInt32 = i => i == 5,
                GetInt32Int32 = i => 6,
                GetStringInt32 = i => Dummyvalue,
                GetDateTimeInt32 = i => dummyDate
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => lblMessages.Text.ShouldBe(ExpectedValue),
                () => lblLastRun.Text.ShouldNotBeNullOrEmpty(),
                () => lblLastRun.Text.ShouldBe(dummyDate.ToString()));
        }

        [TestMethod]
        public void LoadScheduleStatus_OnException()
        {
            // Arrange
            const string ExpectedValue = "Dummy Error";
            var logMessage = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => 
            {
                throw new Exception(ExpectedValue);
            };
            ShimEventLog.SourceExistsString = _ => false;
            ShimEventLog.CreateEventSourceStringString = (source, logName) => { };
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 =
                (_, message, type, id) =>
                {
                    logMessage = message;
                };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => logMessage.ShouldNotBeNullOrEmpty(),
                () => logMessage.ShouldContain(ExpectedValue));
        }

    }
}
