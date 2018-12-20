using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;
using TimeSheets.Layouts.epmlive;

namespace EPMLiveTimesheets.Tests.Layouts
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WorkLogTest
    {
        private IDisposable _shimsContext;
        private WorkLog _testEntity;
        private PrivateObject _privateObject;

        private const string OnInitMethodName = "OnInit";
        private const string PageLoadMethodName = "Page_Load";
        private const string DdlUsersSelectedIndexChangedMethodName = "ddlUsers_SelectedIndexChanged";
        private const string DtcDateDateChangedMethodName = "dtcDate_DateChanged";
        private const string PopulateFormMethodName = "PopulateForm";
        private const string BtnSaveClickMethodName = "btnSave_Click";

        private const string ListIdFieldName = "_listId";
        private const string ListItemIdFieldName = "_listItemId";
        private const string ActFieldName = "act";
        private const string ActivationFieldName = "activation";
        private const string PanelUsersFieldName = "pnlUsers";
        private const string PanelActivateFieldName = "pnlActivate";
        private const string PanelMainFieldName = "pnlMain";
        private const string PanelFormFieldName = "pnlForm";
        private const string PanelErrorFieldName = "pnlError";
        private const string LabelActivateFieldName = "lblActivate";
        private const string LabelErrorFieldName = "lblError";
        private const string DateTimeControlDateFieldName = "dtcDate";
        private const string DropDownListUsersFieldName = "ddlUsers";
        private const string H2TitleFieldName = "h2Title";
        private const string ButtonSaveFieldName = "btnSave";
        private const string ButtonSaveCloseFieldName = "btnSaveClose";
        private const string TextNotesFieldName = "txtNotes";
        private const string LabelDateMessageFieldName = "lblDateMessage";
        private const string LabelStatusMessageFieldName = "lblStatusMessage";
        private const string PanelNotesFieldName = "pnlNotes";

        private Guid _listId;
        private int _listItemId;
        private Panel _panelUser;
        private Panel _panelActivate;
        private Panel _panelMain;
        private Panel _panelForm;
        private Panel _panelError;
        private Panel _panelNotes;
        private Label _labelError;
        private Label _labelActivate;
        private Label _labelDateMessage;
        private Label _labelStatusMessage;
        private DropDownList _dropDownListUsers;
        private DateTimeControl _dateTimeControlDate;
        private HtmlGenericControl _h2Title;
        private Button _buttonSave;
        private Button _buttonSaveClose;
        private InputFormTextBox _txtNotes;

        private const string DummyString = "DummyString";
        private const string DummyUserName = "DummyUserName";
        private const string DummyUserLoginName = "DummyUserLoginName";
        private const string DummyListTitle = "DummyListTitle";
        private const string DummyListItemTitle = "DummyListItemTitle";
        private static readonly Guid DummySiteId = Guid.NewGuid();
        private static readonly Guid DummyListId = Guid.NewGuid();
        private static readonly DateTime DummyDateTimeNow = new DateTime(2018, 6, 7);
        private const int DummyItemId = 100;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new WorkLog();
            _privateObject = new PrivateObject(_testEntity);

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                SiteGet = () => new ShimSPSite()
                {
                    IDGet = () => DummySiteId
                },
                WebGet = () => new ShimSPWeb()
                {
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        NameGet = () => DummyUserName,
                        LoginNameGet = () => DummyUserLoginName
                    }
                }
            };

            ShimDateTime.NowGet = () => DummyDateTimeNow;
            InitializeUiControls();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void Dispose_Always_DisposesHoursPlaceHolder()
        {
            // Arrange
            var isDisposeCalled = false;
            ShimControl.AllInstances.Dispose = _ =>
            {
                isDisposeCalled = true;
            };

            // Act
            using (var workLog = new WorkLog())
            { }

            // Assert
            isDisposeCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void OnInit_Activation0DllUsersItem1_PnlUsersVisibleFalse()
        {
            // Arrange
            ShimAct.ConstructorSPWeb = (sender, spWeb) => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    ["ListId"] = DummyListId.ToString(),
                    ["ItemId"] = DummyItemId.ToString()
                }
            };
            ShimPage.AllInstances.ClientScriptGet = sender => new ShimClientScriptManager()
            {
                IsStartupScriptRegisteredTypeString = (type, key) => false,
                RegisterStartupScriptTypeStringString = (type, key, script) => { }
            };

            ShimTSItem.GetWorkTypesGuid = guid => new Dictionary<int, string>()
            {
                { 1, "work" }
            };
            ShimTSItem.GetDelegateForDropDownListSPWebSPUser = (dropDownList, web, user) => { };

            // Act
            _privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _listId.ShouldBe(DummyListId),
                () => _listItemId.ShouldBe(DummyItemId),
                () => _panelUser.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void OnInit_Activation0DllUsersItem2_PnlUsersVisibleTrue()
        {
            // Arrange
            ShimAct.ConstructorSPWeb = (sender, spWeb) => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    ["ListId"] = DummyListId.ToString(),
                    ["ItemId"] = DummyItemId.ToString()
                }
            };
            ShimPage.AllInstances.ClientScriptGet = sender => new ShimClientScriptManager()
            {
                IsStartupScriptRegisteredTypeString = (type, key) => false,
                RegisterStartupScriptTypeStringString = (type, key, script) => { }
            };

            ShimTSItem.GetWorkTypesGuid = guid => new Dictionary<int, string>()
            {
                { 1, "work" }
            };
            ShimTSItem.GetDelegateForDropDownListSPWebSPUser = (dropDownList, web, user) =>
            {
                dropDownList.Items.Add(new ListItem(user.Name, user.LoginName));
            };

            // Act
            _privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _listId.ShouldBe(DummyListId),
                () => _listItemId.ShouldBe(DummyItemId),
                () => _panelUser.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void OnInit_Activation1_PropertiesSame()
        {
            // Arrange
            ShimAct.ConstructorSPWeb = (sender, spWeb) => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 1;

            // Act
            _privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert
            var listId = (Guid)_privateObject.GetField(ListIdFieldName);
            var listItemId = (int)_privateObject.GetField(ListItemIdFieldName);

            this.ShouldSatisfyAllConditions(
                () => listId.ShouldBe(Guid.Empty),
                () => listItemId.ShouldBe(0));
        }

        [TestMethod]
        public void DdlUsersSelectedIndexChanged_IsTsListFalse_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => false
                };

            // Act
            _privateObject.Invoke(DdlUsersSelectedIndexChangedMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dateTimeControlDate.SelectedDate.ShouldBe(DummyDateTimeNow),
                () => _dropDownListUsers.SelectedIndex.ShouldBe(0),
                () => _h2Title.InnerText.ShouldBe($"{DummyListTitle}: {DummyListItemTitle}"),
                () => _panelForm.Visible.ShouldBeFalse(),
                () => _panelError.Visible.ShouldBeTrue(),
                () => _labelError.Text.ShouldBe("This list is not configured for use with timesheets."));
        }

        [TestMethod]
        public void DtcDateDateChanged_IsTSCheckedFalse_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => true,
                    IsTSCheckedGet = () => false
                };

            // Act
            _privateObject.Invoke(DtcDateDateChangedMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dateTimeControlDate.SelectedDate.ShouldBe(DummyDateTimeNow),
                () => _dropDownListUsers.SelectedIndex.ShouldBe(0),
                () => _h2Title.InnerText.ShouldBe($"{DummyListTitle}: {DummyListItemTitle}"),
                () => _panelForm.Visible.ShouldBeFalse(),
                () => _panelError.Visible.ShouldBeTrue(),
                () => _labelError.Text.ShouldBe("This item has not been allowed in timesheets."));
        }

        [TestMethod]
        public void PageLoad_Activation1_FillProperties()
        {
            // Arrange
            var shimAct = new ShimAct()
            {
                translateStatusInt32 = activation => DummyString
            };

            _privateObject.SetField(ActFieldName, shimAct.Instance);
            _privateObject.SetField(ActivationFieldName, 1);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _panelActivate.Visible.ShouldBeTrue(),
                () => _panelMain.Visible.ShouldBeFalse(),
                () => _labelActivate.Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void PageLoad_Activation0_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => false
                };

            _privateObject.SetField(ActivationFieldName, 0);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dateTimeControlDate.SelectedDate.ShouldBe(DummyDateTimeNow),
                () => _dropDownListUsers.SelectedIndex.ShouldBe(0),
                () => _h2Title.InnerText.ShouldBe($"{DummyListTitle}: {DummyListItemTitle}"),
                () => _panelForm.Visible.ShouldBeFalse(),
                () => _panelError.Visible.ShouldBeTrue(),
                () => _labelError.Text.ShouldBe("You must be assigned to this item in order to submit hours."));
        }

        [TestMethod]
        public void PageLoad_Activation0IsPostBack_FillProperties()
        {
            // Arrange
            InitClass();

            ShimPage.AllInstances.IsPostBackGet = sender => true;
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => false
                };

            _privateObject.SetField(ActivationFieldName, 0);

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _dateTimeControlDate.SelectedDate.ShouldBe(DummyDateTimeNow),
                () => _dropDownListUsers.SelectedIndex.ShouldBe(0),
                () => _h2Title.InnerText.ShouldBe(string.Empty),
                () => _panelForm.Visible.ShouldBeTrue(),
                () => _labelError.Text.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void PopulateForm_PeriodId0_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => true,
                    IsTSCheckedGet = () => true,
                    PeriodIdGet = () => 0
                };

            // Act
            _privateObject.Invoke(PopulateFormMethodName);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _buttonSave.Enabled.ShouldBeFalse(),
                () => _buttonSaveClose.Enabled.ShouldBeFalse(),
                () => _txtNotes.Enabled.ShouldBeFalse(),
                () => _labelDateMessage.Text.ShouldBe("This date does not fall within a valid timesheet period."),
                () => _labelStatusMessage.Text.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void PopulateForm_ValidDayFalse_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => true,
                    IsTSCheckedGet = () => true,
                    PeriodIdGet = () => 1,
                    ValidDayGet = () => false
                };

            // Act
            _privateObject.Invoke(PopulateFormMethodName);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _buttonSave.Enabled.ShouldBeFalse(),
                () => _buttonSaveClose.Enabled.ShouldBeFalse(),
                () => _txtNotes.Enabled.ShouldBeFalse(),
                () => _labelDateMessage.Text.ShouldBe("Monday is not a valid timesheet day."),
                () => _labelStatusMessage.Text.ShouldBeNullOrEmpty());
        }

        [TestMethod]
        public void PopulateForm_AllValid_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => true,
                    IsTSCheckedGet = () => true,
                    PeriodIdGet = () => 1,
                    ValidDayGet = () => true,
                    AllowNotesGet = () => false,
                    NotesGet = () => DummyString,
                    WorkGet = () => new Dictionary<int, float>(),
                    DaySettingsGet = () => new ShimDaySettings()
                    {
                        GetDaySettingDateTime = dateParam => new DaySetting(true, 0, 100)
                    }
                };

            // Act
            _privateObject.Invoke(PopulateFormMethodName);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _buttonSave.Enabled.ShouldBeTrue(),
                () => _buttonSaveClose.Enabled.ShouldBeTrue(),
                () => _txtNotes.Enabled.ShouldBeTrue(),
                () => _labelDateMessage.Text.ShouldBeEmpty(),
                () => _labelStatusMessage.Text.ShouldBeNullOrEmpty(),
                () => _panelNotes.Visible.ShouldBeFalse(),
                () => _txtNotes.Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void BtnSaveClick_Should_FillProperties()
        {
            // Arrange
            InitClass();
            ShimTSItem.ConstructorGuidInt32DateTimeStringString =
                (sender, listId, listItemId, date, userLoginName, userName) => new ShimTSItem(sender)
                {
                    ListGet = () => new ShimSPList()
                    {
                        TitleGet = () => DummyListTitle
                    },
                    ListItemGet = () => new ShimSPListItem()
                    {
                        TitleGet = () => DummyListItemTitle
                    },
                    AuthorizedGet = () => true,
                    IsTSListGet = () => true,
                    IsTSCheckedGet = () => true,
                    PeriodIdGet = () => 1,
                    ValidDayGet = () => true,
                    AllowNotesGet = () => false,
                    NotesGet = () => DummyString,
                    WorkGet = () => new Dictionary<int, float>(),
                    DaySettingsGet = () => new ShimDaySettings()
                    {
                        GetDaySettingDateTime = dateParam => new DaySetting(true, 0, 100)
                    },
                    WorkFromInputSetDictionaryOfInt32TextBox = txtHours => { },
                    Update = () => true
                };

            var buttonSave = new Button()
            {
                ID = "btnSaveClose"
            };

            // Act
            _privateObject.Invoke(BtnSaveClickMethodName, buttonSave, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _buttonSave.Enabled.ShouldBeTrue(),
                () => _buttonSaveClose.Enabled.ShouldBeTrue(),
                () => _txtNotes.Enabled.ShouldBeTrue(),
                () => _labelDateMessage.Text.ShouldBeEmpty(),
                () => _labelStatusMessage.Text.ShouldBe($"Work hours saved for {DummyDateTimeNow.ToString("M/d/yyyy")}"),
                () => _panelNotes.Visible.ShouldBeTrue(),
                () => _txtNotes.Text.ShouldBe(DummyString));
        }

        private void InitializeUiControls()
        {
            var allFields = _testEntity.GetType()
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _privateObject.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void InitClass()
        {
            ShimAct.ConstructorSPWeb = (sender, spWeb) => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (sender, actFeature) => 0;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                QueryStringGet = () => new NameValueCollection()
                {
                    ["ListId"] = DummyListId.ToString(),
                    ["ItemId"] = DummyItemId.ToString()
                }
            };
            ShimPage.AllInstances.ClientScriptGet = sender => new ShimClientScriptManager()
            {
                IsStartupScriptRegisteredTypeString = (type, key) => false,
                RegisterStartupScriptTypeStringString = (type, key, script) => { }
            };

            ShimTSItem.GetWorkTypesGuid = guid => new Dictionary<int, string>()
            {
                { 1, "work" }
            };
            ShimTSItem.GetDelegateForDropDownListSPWebSPUser = (dropDownList, web, user) =>
            {
                dropDownList.Items.Add(new ListItem(user.Name, user.LoginName));
            };

            _privateObject.Invoke(OnInitMethodName, EventArgs.Empty);
        }

        private void LoadFields()
        {
            _listId = (Guid)_privateObject.GetField(ListIdFieldName);
            _listItemId = (int)_privateObject.GetField(ListItemIdFieldName);
            _panelUser = (Panel)_privateObject.GetField(PanelUsersFieldName);
            _panelActivate = (Panel)_privateObject.GetField(PanelActivateFieldName);
            _panelMain = (Panel)_privateObject.GetField(PanelMainFieldName);
            _panelForm = (Panel)_privateObject.GetField(PanelFormFieldName);
            _panelError = (Panel)_privateObject.GetField(PanelErrorFieldName);
            _panelNotes = (Panel)_privateObject.GetField(PanelNotesFieldName);
            _labelError = (Label)_privateObject.GetField(LabelErrorFieldName);
            _labelActivate = (Label)_privateObject.GetField(LabelActivateFieldName);
            _labelDateMessage = (Label)_privateObject.GetField(LabelDateMessageFieldName);
            _labelStatusMessage = (Label)_privateObject.GetField(LabelStatusMessageFieldName);
            _dateTimeControlDate = (DateTimeControl)_privateObject.GetField(DateTimeControlDateFieldName);
            _dropDownListUsers = (DropDownList)_privateObject.GetField(DropDownListUsersFieldName);
            _h2Title = (HtmlGenericControl)_privateObject.GetField(H2TitleFieldName);
            _txtNotes = (InputFormTextBox)_privateObject.GetField(TextNotesFieldName);
            _buttonSave = (Button)_privateObject.GetField(ButtonSaveFieldName);
            _buttonSaveClose = (Button)_privateObject.GetField(ButtonSaveCloseFieldName);
        }
    }
}
