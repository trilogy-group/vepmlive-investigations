using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    using Fakes;
    using Testables;

    [TestClass]
    public class AdsyncAdminTests
    {
        private IDisposable shimsContext;
        private adsyncadmin adsyncadmin;
        private PrivateObject privateObject;
        private readonly DropDownList FixTimes = new DropDownList();
        private readonly DropDownList DropDownListScheduleType = new DropDownList();
        private readonly DropDownList DropDownListDays = new DropDownList();
        private readonly DropDownList DropDownListTime = new DropDownList();
        private readonly Label LblDomain = new Label();
        private readonly Label LblMessages = new Label();
        private readonly Label LblLastRun = new Label();
        private readonly ListBox LbOptions = new ListBox();
        private readonly ListBox LbSelections = new ListBox();
        private readonly HiddenField Selections = new HiddenField();
        private readonly Panel PnlFieldMappings = new Panel();
        private readonly Table TblFieldMappings = new Table();
        private readonly HtmlTextArea TxtAreaEntityExclusions = new HtmlTextArea();
        private readonly Button BtnRunManually = new Button();
        private readonly CheckBoxList CheckBoxListDays = new CheckBoxList();
        private readonly CheckBox CbDelete = new CheckBox();
        private readonly InputFormControl FrequencyOptions = new InputFormControlTestable();
        private readonly TextBox SizeLimitTextBox = new TextBox();
        private const string PageInitMethodName = "Page_Init";
        private const string InitDomainMethodName = "InitDomain";
        private const string InitResourceFieldMethodName = "InitResourceField";
        private const string LoadScheduleStatusMethodName = "LoadScheduleStatus";
        private const string DummyValue = "DummyValue";
        private const string InitGroupsMethodName = "InitGroups";
        private const string ADFieldsMethodName = "ADFields";
        private const string SaveAllMethodName = "SaveAll";
        private const string GetFieldMappingsMethodName = "GetFieldMappings";
        private const string InitResourcePoolFieldsMethodName = "InitResourcePoolFields";
        private const string GetEntityExclusionsMethodName = "GetEntityExclusions";
        private const string GetDeleteMethodName = "GetDelete";
        private const string GetOptionsMethodName = "GetOptions";
        private const string InitScheduleMethodName = "InitSchedule";
        private const string DisposeTableMethodName = "DisposeTable";
        private const string BtnRunManuallyClickMethodName = "btnRunManually_Click";
        private const string InitSavedFieldMappingsMethodName = "InitSavedFieldMappings";
        private const string DropDownListScheduleType_SelectedIndexChangedMethodName = "DropDownListScheduleType_SelectedIndexChanged";
        private const string GetActiveDirectorySizeLimitMethodName = "GetActiveDirectorySizeLimit";
        private const string GetGroupsMethodName = "GetGroups";
        private const string InitActiveDirectorySizeLimitTextBoxMethodName = "InitActiveDirectorySizeLimitTextBox";
        private const string InitDeleteMethodName = "InitDelete";
        private const string InitExclusionsMethodName = "InitExclusions";
        private const string SubmitClickMethodName = "Submit_Click";
        private const string PageLoadCompleteMethodName = "Page_LoadComplete";

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
            privateObject.SetFieldOrProperty("lbl_domain", LblDomain);
            privateObject.SetFieldOrProperty("lblMessages", LblMessages);
            privateObject.SetFieldOrProperty("lblLastRun", LblLastRun);
            privateObject.SetFieldOrProperty("lb_options", LbOptions);
            privateObject.SetFieldOrProperty("lb_selections", LbSelections);
            privateObject.SetFieldOrProperty("selections", Selections);
            privateObject.SetFieldOrProperty("pnl_fieldMappings", PnlFieldMappings);
            privateObject.SetFieldOrProperty("tbl_fieldMappings", TblFieldMappings);
            privateObject.SetFieldOrProperty("txtArea_entityExclusions", TxtAreaEntityExclusions);
            privateObject.SetFieldOrProperty("btnRunManually", BtnRunManually);
            privateObject.SetFieldOrProperty("CheckBoxList_days", CheckBoxListDays);
            privateObject.SetFieldOrProperty("cbDelete", CbDelete);
            privateObject.SetFieldOrProperty("FrequencyOptions", FrequencyOptions);
            privateObject.SetFieldOrProperty("_htDropdownIds", new Hashtable());
            privateObject.SetFieldOrProperty("SizeLimitTextBox", SizeLimitTextBox);
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
            LblDomain?.Dispose();
            LblMessages?.Dispose();
            LblLastRun?.Dispose();
            LbOptions?.Dispose();
            LbSelections?.Dispose();
            Selections?.Dispose();
            PnlFieldMappings?.Dispose();
            TblFieldMappings?.Dispose();
            TxtAreaEntityExclusions?.Dispose();
            BtnRunManually?.Dispose();
            CheckBoxListDays?.Dispose();
            CbDelete?.Dispose();
            FrequencyOptions?.Dispose();
            adsyncadmin?.Dispose();
            SizeLimitTextBox?.Dispose();
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
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyValue;
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
        public void InitDomain_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Domain = "Domain.com";
            ShimADSync.AllInstances.GetFullDomain = _ => Domain;

            // Act
            privateObject.Invoke(InitDomainMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => LblDomain.Text.ShouldNotBeNullOrEmpty(),
                () => LblDomain.Text.ShouldBe(Domain));
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
                () => LblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => LblMessages.Text.ShouldBe(ExpectedValue),
                () => BtnRunManually.Enabled.ShouldBeFalse());
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
                () => LblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => LblMessages.Text.ShouldBe(ExpectedValue),
                () => BtnRunManually.Enabled.ShouldBeFalse());
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
                GetStringInt32 = i => DummyValue
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => LblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => LblMessages.Text.ShouldBe(DummyValue));
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
                GetStringInt32 = i => DummyValue,
                GetDateTimeInt32 = i => dummyDate
            };

            // Atcy
            privateObject.Invoke(LoadScheduleStatusMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => LblMessages.Text.ShouldNotBeNullOrEmpty(),
                () => LblMessages.Text.ShouldBe(ExpectedValue),
                () => LblLastRun.Text.ShouldNotBeNullOrEmpty(),
                () => LblLastRun.Text.ShouldBe(dummyDate.ToString()));
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

        [TestMethod]
        public void InitGroups_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimADSync.AllInstances.GetGroupsString = (_, path) => new List<string>
            {
                DummyValue
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyValue;

            // Act
            privateObject.Invoke(InitGroupsMethodName);

            // Assert
            LbSelections.Items.Count.ShouldBeGreaterThan(0);
        }

        [TestMethod]
        public void InitGroups_OnException_ShouldLogError()
        {
            // Arrange
            ShimADSync.AllInstances.GetGroupsString = (_, path) => new List<string>
            {
                DummyValue
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyValue;
            ShimListItemCollection.AllInstances.FindByTextString = (_, name) => null;

            // Act
            privateObject.Invoke(InitGroupsMethodName);
            var logs = privateObject.GetFieldOrProperty("_ExecutionLogs") as List<string>;

            // Assert
            logs.ShouldSatisfyAllConditions(
                () => logs.ShouldNotBeNull(),
                () => logs.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void ADFields_FieldNameDefault_ReturnsExpectedObject()
        {
            // Arrange
            ShimADSync.AllInstances.GetADGroupUserAttributesStringString =
                (_, domain, name) => new List<string> { DummyValue };
            privateObject.SetFieldOrProperty("_groups", new List<string> { DummyValue });
            privateObject.SetFieldOrProperty("_SavedFieldMappings", new List<string> { DummyValue });
            privateObject.SetFieldOrProperty("_SavedFieldMappingValues", new Hashtable
            {
                [DummyValue] = DummyValue
            });

            // Act
            var result = privateObject.Invoke(ADFieldsMethodName, DummyValue) as DropDownList;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.SelectedIndex.ShouldBe(1),
                () => result.SelectedValue.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void ADFields_FieldNameTitle_ReturnsExpectedObject()
        {
            // Arrange
            const string ExpectedValue = "displayName";
            ShimADSync.AllInstances.GetADGroupUserAttributesStringString =
                (_, domain, name) => new List<string> { ExpectedValue };
            privateObject.SetFieldOrProperty("_groups", new List<string> { DummyValue });
            const string FieldName = "title";

            // Act
            var result = privateObject.Invoke(ADFieldsMethodName, FieldName) as DropDownList;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Enabled.ShouldBeFalse(),
                () => result.SelectedValue.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void ADFields_FieldNameSharepointAccount_ReturnsExpectedObject()
        {
            // Arrange
            const string ExpectedValue = "sAMAccountName";
            ShimADSync.AllInstances.GetADGroupUserAttributesStringString =
                (_, domain, name) => new List<string> { ExpectedValue };
            privateObject.SetFieldOrProperty("_groups", new List<string> { DummyValue });
            const string FieldName = "sharepointaccount";

            // Act
            var result = privateObject.Invoke(ADFieldsMethodName, FieldName) as DropDownList;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Enabled.ShouldBeFalse(),
                () => result.SelectedValue.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void ADFields_OnException_ShouldLogError()
        {
            // Arrange
            const string ExpectedValue = "Error Message";
            var errorMessage = string.Empty;
            ShimADSync.AllInstances.GetADGroupUserAttributesStringString =
                (_, domain, name) =>
                {
                    throw new Exception(ExpectedValue);
                };
            privateObject.SetFieldOrProperty("_groups", new List<string> { DummyValue });
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                WriteString = message => errorMessage = message
            };

            // Act
            var result = privateObject.Invoke(ADFieldsMethodName, DummyValue) as DropDownList;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldNotBeNullOrEmpty(),
                () => errorMessage.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void SaveAll_OnSuccess_RedirectsToExpectedPage()
        {
            // Arrange
            const string ExpectedPage = "main.aspx";
            var redirectPage = string.Empty;
            Shimadsyncadmin.AllInstances.GetOptions = _ => string.Empty;
            ShimListControl.AllInstances.SelectedValueGet = _ => "1";
            Shimadsyncadmin.AllInstances.GetGroups = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetFieldMappings = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetEntityExclusions = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetDelete = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetActiveDirectorySizeLimit = _ => 1;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) => { };
            ShimADSync.AllInstances.AddTimerJobSPWebInt32Int32StringBoolean =
                (_, web, time, schedule, days, runNow) => true;
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                RedirectString = page => redirectPage = page
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name => ExpectedPage
            };

            // Act
            privateObject.Invoke(SaveAllMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectPage.ShouldNotBeNullOrEmpty(),
                () => redirectPage.ShouldBe(ExpectedPage));
        }

        [TestMethod]
        public void SaveAll_OnSuccess_RedirectsToSettingsPage()
        {
            // Arrange
            const string ExpectedPage = "settings.aspx";
            var redirectPage = string.Empty;
            Shimadsyncadmin.AllInstances.GetOptions = _ => string.Empty;
            ShimListControl.AllInstances.SelectedValueGet = _ => "1";
            Shimadsyncadmin.AllInstances.GetGroups = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetFieldMappings = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetEntityExclusions = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetDelete = _ => DummyValue;
            Shimadsyncadmin.AllInstances.GetActiveDirectorySizeLimit = _ => 1;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) => { };
            ShimADSync.AllInstances.AddTimerJobSPWebInt32Int32StringBoolean =
                (_, web, time, schedule, days, runNow) => true;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (page, flags, context) =>
            {
                redirectPage = page;
                return true;
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = name => string.Empty
            };

            // Act
            privateObject.Invoke(SaveAllMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectPage.ShouldNotBeNullOrEmpty(),
                () => redirectPage.ShouldBe(ExpectedPage));
        }

        [TestMethod]
        public void GetFieldMappings_Should_ReturnExpectedValue()
        {
            // Arrange
            const string TitleField = "title";
            const string SharepointField = "sharepointaccount";
            var expectedValue = $"|{TitleField};displayname|{SharepointField};samaccountname|{DummyValue};{DummyValue}";
            privateObject.SetFieldOrProperty("_resourcePoolFields", new List<string>
            {
                TitleField,
                SharepointField,
                DummyValue
            });
            privateObject.SetFieldOrProperty("_htDropdownIds", new Hashtable
            {
                [TitleField] = new DropDownList(),
                [SharepointField] = new DropDownList(),
                [DummyValue] = new DropDownList()
            });
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                FormGet = () => new ShimNameValueCollection
                {
                    ItemGetString = name => DummyValue
                }
            };

            // Act
            var result = privateObject.Invoke(GetFieldMappingsMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void InitResourcePoolFields_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => DummyValue;
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (web, setting, translate, relative) => DummyValue;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => new ShimSPSite
                {
                    RootWebGet = () => new ShimSPWeb
                    {
                        SiteGet = () => new ShimSPSite
                        {
                            AllWebsGet = () => new ShimSPWebCollection
                            {
                                ItemGetString = url => new ShimSPWeb
                                {
                                    ListsGet = () => new ShimSPListCollection
                                    {
                                        ItemGetString = listNAme => new ShimSPList()
                                    }
                                }
                            }
                        }
                    }
                }
            };
            ShimSPList.AllInstances.FieldsGet = _ =>
            {
                var list = new List<SPField>
                {
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Text,
                        HiddenGet = () => false,
                        ReadOnlyFieldGet = () => false,
                        SealedGet = () => false,
                        InternalNameGet = () => DummyValue
                    }
                };
                return new ShimSPFieldCollection().Bind(list);
            };
            Shimadsyncadmin.AllInstances.InitResourceFieldString = (_, name) => { };
            Shimadsyncadmin.AllInstances.InitSavedFieldMappingsString = (_, mappings) => { };

            // Act
            privateObject.Invoke(InitResourcePoolFieldsMethodName);
            var poolFields = privateObject.GetFieldOrProperty("_resourcePoolFields") as List<string>;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => poolFields.ShouldNotBeNull(),
                () => poolFields.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetEntityExclusions_Should_ExecuteCorrectly()
        {
            // Arrange
            var expectedValue = $"{DummyValue};{DummyValue};";
            ShimADSync.AllInstances.GetUserSIDByCNStringString = (_, cn, domain) => DummyValue;
            TxtAreaEntityExclusions.Value = $"{DummyValue};";
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) => { };

            // Act
            var result = privateObject.Invoke(GetEntityExclusionsMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetEntityExclusions_SIDEmpty_ExecutesCorrectly()
        {
            // Arrange
            var expectedValue = $"{DummyValue};";
            ShimADSync.AllInstances.GetUserSIDByCNStringString = (_, cn, domain) => string.Empty;
            TxtAreaEntityExclusions.Value = string.Empty;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (web, setting, value) => { };

            // Act
            var result = privateObject.Invoke(GetEntityExclusionsMethodName) as string;
            var logs = privateObject.GetFieldOrProperty("_ExecutionLogs") as List<string>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrEmpty(),
                () => logs.ShouldNotBeNull(),
                () => logs.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetDelete_CheckBoxDeleteChecked_ReturnsTrue()
        {
            // Arrange
            CbDelete.Checked = true;

            // Act
            var result = privateObject.Invoke(GetDeleteMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(bool.TrueString.ToLower()));
        }

        [TestMethod]
        public void GetDelete_CheckBoxDeleteNotChecked_ReturnsFalse()
        {
            // Arrange
            CbDelete.Checked = false;

            // Act
            var result = privateObject.Invoke(GetDeleteMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(bool.FalseString.ToLower()));
        }

        [TestMethod]
        public void GetOptions_SelectedValue2_ReturnsExpectedValue()
        {
            // Arrange
            ShimListControl.AllInstances.SelectedValueGet = _ => "2";
            CheckBoxListDays.Items.Add(new ListItem()
            {
                Value = DummyValue,
                Selected = true
            });

            // Act
            var result = privateObject.Invoke(GetOptionsMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void GetOptions_SelectedValueFromDropDown_ReturnsExpectedValue()
        {
            // Arrange
            ShimListControl.AllInstances.SelectedValueGet = _ => DummyValue;
            CheckBoxListDays.Items.Add(new ListItem()
            {
                Value = DummyValue,
                Selected = true
            });

            // Act
            var result = privateObject.Invoke(GetOptionsMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void InitSchedule_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => $"{DummyValue},{DummyValue}";
            var item = new ListItem(DummyValue)
            {
                Selected = false
            };
            CheckBoxListDays.Items.Add(item);

            // Act
            privateObject.Invoke(InitScheduleMethodName);

            // Assert
            item.Selected.ShouldBeTrue();
        }

        [TestMethod]
        public void DisposeTable_Should_DisposeCell()
        {
            // Arrange
            var table = new ShimTable
            {
                RowsGet = () => new ShimTableRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimTableRow
                    {
                        CellsGet = () => new ShimTableCellCollection
                        {
                            CountGet = () => 1,
                            ItemGetInt32 = i => new ShimTableCell()
                        }
                    }
                }
            }.Instance;
            var controlWasDisposed = false;
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimControl
                {
                    Dispose = () => controlWasDisposed = true
                }
            };

            // Act
            privateObject.Invoke(DisposeTableMethodName, table);

            // Assert
            controlWasDisposed.ShouldBeTrue();
        }

        [TestMethod]
        public void DisposeTable_TableNull_NoActionTaken()
        {
            // Arrange
            Table table = null;
            var controlWasDisposed = false;
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimControl
                {
                    Dispose = () => controlWasDisposed = true
                }
            };

            // Act
            privateObject.Invoke(DisposeTableMethodName, table);

            // Assert
            controlWasDisposed.ShouldBeFalse();
        }

        [TestMethod]
        public void btnRunManuallyClick_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Url = "dummy.org";
            var expectedValue = $"{Url}/_layouts/epmlive/adsyncadmin.aspx";
            var redirectUrl = string.Empty;
            Shimadsyncadmin.AllInstances.GetOptions = _ => DummyValue;
            ShimListControl.AllInstances.SelectedValueGet = _ => "1";
            ShimADSync.AllInstances.AddTimerJobSPWebInt32Int32StringBoolean =
                (_, web, time, schedule, days, run) => true;
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => Url;
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                RedirectString = url => redirectUrl = url
            };

            // Act
            privateObject.Invoke(BtnRunManuallyClickMethodName, new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void InitSavedFieldMappings_Should_ExecuteCorrectly()
        {
            // Arrange
            const string Mappings = "dummy;value|dummy;value";

            // Act
            privateObject.Invoke(InitSavedFieldMappingsMethodName, Mappings);
            var fieldMappings = privateObject.GetFieldOrProperty("_SavedFieldMappingValues") as Hashtable;
            var mappingValues = privateObject.GetFieldOrProperty("_SavedFieldMappings") as List<string>;

            // Assert
            this.ShouldSatisfyAllConditions(
                () => mappingValues.ShouldNotBeNull(),
                () => mappingValues.ShouldNotBeEmpty(),
                () => fieldMappings.ShouldNotBeNull(),
                () => fieldMappings.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void DropDownListScheduleTypeSelectedIndexChanged_SheculeType3_ExecutesCorrectly()
        {
            // Arrange
            ShimListControl.AllInstances.SelectedValueGet = _ => "3";
            const string ExpectedLabel = "Day of Month";

            // Act
            privateObject.Invoke(
                DropDownListScheduleType_SelectedIndexChangedMethodName,
                new object(),
                EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => DropDownListDays.Visible.ShouldBeTrue(),
                () => CheckBoxListDays.Visible.ShouldBeFalse(),
                () => FrequencyOptions.LabelText.ShouldBe(ExpectedLabel));
        }

        [TestMethod]
        public void DropDownListScheduleTypeSelectedIndexChanged_ScheduleTypeDefault_ExecutesCorrectly()
        {
            // Arrange
            ShimListControl.AllInstances.SelectedValueGet = _ => DummyValue;
            const string ExpectedLabel = "Day(s) of Week";

            // Act
            privateObject.Invoke(
                DropDownListScheduleType_SelectedIndexChangedMethodName,
                new object(),
                EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => DropDownListDays.Visible.ShouldBeFalse(),
                () => CheckBoxListDays.Visible.ShouldBeTrue(),
                () => FrequencyOptions.LabelText.ShouldBe(ExpectedLabel));
        }

        [TestMethod]
        public void Dispose_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimControlCollection.AllInstances.CountGet = _ => 1;
            ShimControlCollection.AllInstances.ItemGetInt32 =
                (_, index) => new ShimTable { };
            var disposeTableWasCalled = false;
            var controlDisposed = false;
            Shimadsyncadmin.AllInstances.DisposeTableTable =
                (_, table) => disposeTableWasCalled = true;
            ShimControl.AllInstances.Dispose = _ =>
            controlDisposed = true;

            // Act
            adsyncadmin.Dispose();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => disposeTableWasCalled.ShouldBeTrue(),
                () => controlDisposed.ShouldBeTrue());
        }

        [TestMethod]
        public void GetActiveDirectorySizeLimit_Should_ReturnExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 1;
            SizeLimitTextBox.Text = ExpectedValue.ToString();

            // Act
            var result = privateObject.Invoke(GetActiveDirectorySizeLimitMethodName) as int?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetActiveDirectorySizeLimit_OnException_ReturnsZero()
        {
            // Arrange
            const int ExpectedValue = 0;
            SizeLimitTextBox.Text = DummyValue;

            // Act
            var result = privateObject.Invoke(GetActiveDirectorySizeLimitMethodName) as int?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetGroups_Should_ReturnExpectedValue()
        {
            // Arrange
            Selections.Value = DummyValue;

            // Act
            var result = privateObject.Invoke(GetGroupsMethodName) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void InitActiveDirectorySizeLimitTextBox_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => string.Empty;
            const string ExpectedValue = "5000";

            // Act
            privateObject.Invoke(InitActiveDirectorySizeLimitTextBoxMethodName);

            // Assert
            SizeLimitTextBox.Text.ShouldBe(ExpectedValue);
        }

        [TestMethod]
        public void InitDelete_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => bool.TrueString;

            // Act
            privateObject.Invoke(InitDeleteMethodName);

            // Assert
            CbDelete.Checked.ShouldBeTrue();
        }

        [TestMethod]
        public void InitExclusions_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString =
                (web, setting) => DummyValue;

            // Act
            privateObject.Invoke(InitExclusionsMethodName);

            // Assert
            TxtAreaEntityExclusions.Value.ShouldBe(DummyValue);
        }

        [TestMethod]
        public void SubmitClick_Should_ExecuteCorrectly()
        {
            // Arrange
            var saveAllWasCalled = false;
            Shimadsyncadmin.AllInstances.SaveAll = _ => saveAllWasCalled = true;

            // Act
            privateObject.Invoke(SubmitClickMethodName, new object(), EventArgs.Empty);

            // Assert
            saveAllWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void PageLoadComplete_Should_ExecuteCorrectly()
        {
            // Arrange, Act
            privateObject.Invoke(PageLoadCompleteMethodName, new object(), EventArgs.Empty);
            var adSync = privateObject.GetFieldOrProperty("_ADSync") as ADSync;

            // Assert
            adSync.ShouldBeNull();
        }
    }
}
