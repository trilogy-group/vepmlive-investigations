using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using TimeSheets.Fakes;

namespace EPMLiveTimesheets.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TimesheetadminTests
    {
        private IDisposable _shimObject;
        private timesheetadmin _testObject;
        private PrivateObject _privateObject;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private List<string> _attributes;
        private bool _addListFieldDataCalled;
        private bool _loadTypesCalled;
        private LinkButton _linkButton;

        private const int DummyIntZero = 0;
        private const int DummyIntOne = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string PageLoadMethod = "Page_Load";
        private const string PnlActivation = "pnlActivation";
        private const string PnlTs = "pnlTs";
        private const string PnlTL = "pnlTL";
        private const string PnlMain = "pnlMain";
        private const string DtSpStart = "dtSpStart";
        private const string DtSpEnd = "dtSpEnd";
        private const string HlAdmin = "hlAdmin";
        private const string DdlFieldLists = "ddlFieldLists";
        private const string OnChange = "onchange";
        private const string FirstField = "FirstField";
        private const string SecondField = "SecondField";
        private const string Button1ClickMethod = "Button1_Click";
        private const string GridView1RowCommandMethod = "GridView1_RowCommand";
        private const string GridView1RowDataBoundMethod = "GridView1_RowDataBound";
        private const string LoadTypesMethod = "loadTypes";
        private const string AddListFieldDataMethod = "addListFieldData";
        private const string EPMLiveTSAllowUnassigned = "EPMLiveTSAllowUnassigned";
        private const string EPMLiveTSAllowNotes = "EPMLiveTSAllowNotes";
        private const string EPMLiveTSUseCurrent = "EPMLiveTSUseCurrent";
        private const string EPMLiveEnableNonTeamNotf = "EPMLiveEnableNonTeamNotf";
        private const string EPMLiveTSDisableApprovals = "EPMLiveTSDisableApprovals";
        private const string EPMLiveTSLiveHours = "EPMLiveTSLiveHours";
        private const string EPMLiveDaySettings = "EPMLiveDaySettings";
        private const string EPMLiveTSFlag = "EPMLiveTSFlag";
        private const string EPMLiveTSLists = "EPMLiveTSLists";
        private const string EPMLiveTSNonWork = "EPMLiveTSNonWork";
        private const string EPMLiveTSTimesheetHours = "EPMLiveTSTimesheetHours";
        private const string EPMLiveTSMyFields = "EPMLiveTSMyFields";
        private const string EPMLiveTSAllowStopWatch = "EPMLiveTSAllowStopWatch";
        private const string EPMPortManagerColumn = "EPMPortManagerColumn";
        private const string EPMLiveTSFields = "EPMLiveTSFields-";

        [TestInitialize]
        public void TestInitialize()
        {
            _addListFieldDataCalled = false;
            _loadTypesCalled = false;
            _attributes = new List<string>();
            _linkButton = null;
            _shimObject = ShimsContext.Create();
            _testObject = new timesheetadmin();
            _privateObject = new PrivateObject(_testObject);
            SetupShims();
            InitializeUiControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            _web = new ShimSPWeb
            {
                UserIsSiteAdminGet = () => true,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList(),
                    ItemGetString = _ => new ShimSPList()
                }.Bind(new SPList[]
                {
                    new ShimSPList
                    {
                        TitleGet = () => DummyString
                    }
                }),
                SiteGet = () => _site
            };
            _site = new ShimSPSite
            {
                UrlGet = () => DummyUrl,
                RootWebGet = () => _web,
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => _web;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => _web;
            ShimSPContext.AllInstances.SiteGet = _ => _site;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimPath.GetDirectoryNameString = _ => string.Empty;
        }

        private void InitializeUiControls()
        {
            var allFields = _testObject.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObject.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        [TestMethod]
        public void PageLoad_WhenIsNotRootWeb_ConfirmResult()
        {
            // Arrange
            SetupForPageLoadMethod(false);

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlActivation = (Panel)_privateObject.GetField(PnlActivation);
            var pnlTs = (Panel)_privateObject.GetField(PnlTs);
            var pnlTL = (Panel)_privateObject.GetField(PnlTL);
            var pnlMain = (Panel)_privateObject.GetField(PnlMain);
            var dtSpStart = (DateTimeControl)_privateObject.GetField(DtSpStart);
            var dtSpEnd = (DateTimeControl)_privateObject.GetField(DtSpEnd);
            var hlAdmin = (HyperLink)_privateObject.GetField(HlAdmin);
            var ddlFieldLists = (DropDownList)_privateObject.GetField(DdlFieldLists);
            this.ShouldSatisfyAllConditions(
                () => pnlActivation.Visible.ShouldBeTrue(),
                () => pnlTs.Visible.ShouldBeFalse(),
                () => pnlTL.Visible.ShouldBeTrue(),
                () => pnlMain.Visible.ShouldBeFalse(),
                () => dtSpStart.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => dtSpEnd.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => hlAdmin.NavigateUrl.ShouldBe($"{DummyUrl}/_layouts/epmlive/timesheetadmin.aspx"),
                () => ddlFieldLists.Attributes.Count.ShouldBe(1),
                () => ddlFieldLists.Attributes[OnChange].ShouldNotBeNull(),
                () => _addListFieldDataCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_WhenIsRootWeb_ConfirmResult()
        {
            // Arrange
            SetupForPageLoadMethod(true);

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlActivation = (Panel)_privateObject.GetField(PnlActivation);
            var pnlTs = (Panel)_privateObject.GetField(PnlTs);
            var pnlTL = (Panel)_privateObject.GetField(PnlTL);
            var pnlMain = (Panel)_privateObject.GetField(PnlMain);
            var dtSpStart = (DateTimeControl)_privateObject.GetField(DtSpStart);
            var dtSpEnd = (DateTimeControl)_privateObject.GetField(DtSpEnd);
            var hlAdmin = (HyperLink)_privateObject.GetField(HlAdmin);
            var ddlFieldLists = (DropDownList)_privateObject.GetField(DdlFieldLists);
            var chkAllowUnassigned = (CheckBox)_privateObject.GetField("chkAllowUnassigned");
            var chkAllowNotes = (CheckBox)_privateObject.GetField("chkAllowNotes");
            var chkCurrentData = (CheckBox)_privateObject.GetField("chkCurrentData");
            var chkEnableNonTeamNotf = (CheckBox)_privateObject.GetField("chkEnableNonTeamNotf");
            var chkSunday = (CheckBox)_privateObject.GetField("chkSunday");
            var chkMonday = (CheckBox)_privateObject.GetField("chkMonday");
            var chkTuesday = (CheckBox)_privateObject.GetField("chkTuesday");
            var chkWednesday = (CheckBox)_privateObject.GetField("chkWednesday");
            var chkThursday = (CheckBox)_privateObject.GetField("chkThursday");
            var chkFriday = (CheckBox)_privateObject.GetField("chkFriday");
            var chkSaturday = (CheckBox)_privateObject.GetField("chkSaturday");
            var chkDisableApprovals = (CheckBox)_privateObject.GetField("chkDisableApprovals");
            var chkShowLiveHours = (CheckBox)_privateObject.GetField("chkShowLiveHours");
            var txtSundayMin = (TextBox)_privateObject.GetField("txtSundayMin");
            var txtSundayMax = (TextBox)_privateObject.GetField("txtSundayMax");
            var txtMondayMin = (TextBox)_privateObject.GetField("txtMondayMin");
            var txtMondayMax = (TextBox)_privateObject.GetField("txtMondayMax");
            var txtTuesdayMin = (TextBox)_privateObject.GetField("txtTuesdayMin");
            var txtTuesdayMax = (TextBox)_privateObject.GetField("txtTuesdayMax");
            var txtWednesdayMin = (TextBox)_privateObject.GetField("txtWednesdayMin");
            var txtWednesdayMax = (TextBox)_privateObject.GetField("txtWednesdayMax");
            var txtThursdayMin = (TextBox)_privateObject.GetField("txtThursdayMin");
            var txtThursdayMax = (TextBox)_privateObject.GetField("txtThursdayMax");
            var txtFridayMin = (TextBox)_privateObject.GetField("txtFridayMin");
            var txtFridayMax = (TextBox)_privateObject.GetField("txtFridayMax");
            var txtSaturdayMin = (TextBox)_privateObject.GetField("txtSaturdayMin");
            var txtSaturdayMax = (TextBox)_privateObject.GetField("txtSaturdayMax");
            this.ShouldSatisfyAllConditions(
                () => pnlActivation.Visible.ShouldBeTrue(),
                () => pnlTs.Visible.ShouldBeFalse(),
                () => pnlTL.Visible.ShouldBeTrue(),
                () => pnlMain.Visible.ShouldBeTrue(),
                () => dtSpStart.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => dtSpEnd.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => hlAdmin.NavigateUrl.ShouldBeNullOrWhiteSpace(),
                () => ddlFieldLists.Attributes.Count.ShouldBe(1),
                () => ddlFieldLists.Attributes[OnChange].ShouldNotBeNull(),
                () => chkAllowUnassigned.Checked.ShouldBeTrue(),
                () => chkAllowNotes.Checked.ShouldBeTrue(),
                () => chkCurrentData.Checked.ShouldBeTrue(),
                () => chkEnableNonTeamNotf.Checked.ShouldBeTrue(),
                () => chkSunday.Checked.ShouldBeTrue(),
                () => chkMonday.Checked.ShouldBeTrue(),
                () => chkTuesday.Checked.ShouldBeTrue(),
                () => chkWednesday.Checked.ShouldBeTrue(),
                () => chkThursday.Checked.ShouldBeTrue(),
                () => chkFriday.Checked.ShouldBeTrue(),
                () => chkSaturday.Checked.ShouldBeTrue(),
                () => txtSundayMin.Text.ShouldBe(DummyString),
                () => txtSundayMax.Text.ShouldBe(DummyString),
                () => txtMondayMin.Text.ShouldBe(DummyString),
                () => txtMondayMax.Text.ShouldBe(DummyString),
                () => txtTuesdayMin.Text.ShouldBe(DummyString),
                () => txtTuesdayMax.Text.ShouldBe(DummyString),
                () => txtWednesdayMin.Text.ShouldBe(DummyString),
                () => txtWednesdayMax.Text.ShouldBe(DummyString),
                () => txtThursdayMin.Text.ShouldBe(DummyString),
                () => txtThursdayMax.Text.ShouldBe(DummyString),
                () => txtFridayMin.Text.ShouldBe(DummyString),
                () => txtFridayMax.Text.ShouldBe(DummyString),
                () => txtSaturdayMin.Text.ShouldBe(DummyString),
                () => txtSaturdayMax.Text.ShouldBe(DummyString),
                () => chkDisableApprovals.Checked.ShouldBeTrue(),
                () => chkShowLiveHours.Checked.ShouldBeTrue(),
                () => _loadTypesCalled.ShouldBeTrue(),
                () => _addListFieldDataCalled.ShouldBeTrue());
        }

        private void SetupForPageLoadMethod(bool isRootWeb)
        {
            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => DummyIntOne;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => _web;
            ShimSPWeb.AllInstances.IsRootWebGet = _ => isRootWeb;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            Shimtimesheetadmin.AllInstances.addListFieldDataSPWebSPWebString = (_, _1, _2, _3) => _addListFieldDataCalled = true;
            Shimtimesheetadmin.AllInstances.loadTypesSqlConnection = (_, __) => _loadTypesCalled = true;
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) =>
            {
                switch (setting)
                {
                    case EPMLiveTSAllowUnassigned:
                    case EPMLiveTSAllowNotes:
                    case EPMLiveTSUseCurrent:
                    case EPMLiveEnableNonTeamNotf:
                    case EPMLiveTSDisableApprovals:
                    case EPMLiveTSLiveHours:
                        return "true";
                    case EPMLiveDaySettings:
                        return $"true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}";
                    default:
                        return DummyString;
                }
            };
            ShimTimesheetSettings.ConstructorSPWeb = (instance, __) =>
            {
                instance.TimesheetFields = new ArrayList { FirstField };
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(new SPField[]
            {
                new ShimSPField()
                {
                    TitleGet = () => FirstField,
                    InternalNameGet = () => FirstField
                },
                new ShimSPField()
                {
                    TitleGet = () => SecondField,
                    InternalNameGet = () => SecondField
                }
            });
            ShimSPField.AllInstances.ReorderableGet = _ => true;
            ShimSqlCommand.ConstructorString = (_, __) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyIntOne;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.MinValue;
            ShimSqlDataReader.AllInstances.Close = _ => { };
        }

        [TestMethod]
        public void Button1Click_OnValidCall_ConfirmResult()
        {
            // Arrange
            var lstSettings = new List<string>();
            var txtLists = (TextBox)_privateObject.GetField("txtLists");
            var responseRedirected = false;
            txtLists.Text = DummyString;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, setting, __) =>
            {
                lstSettings.Add(setting);
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimHttpResponse.AllInstances.RedirectString = (_, __) => responseRedirected = true;

            // Act
            _privateObject.Invoke(Button1ClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lstSettings.ShouldContain(EPMLiveTSAllowUnassigned),
                () => lstSettings.ShouldContain(EPMLiveTSAllowNotes),
                () => lstSettings.ShouldContain(EPMLiveTSFlag),
                () => lstSettings.ShouldContain(EPMLiveTSLists),
                () => lstSettings.ShouldContain(EPMLiveTSNonWork),
                () => lstSettings.ShouldContain(EPMLiveTSTimesheetHours),
                () => lstSettings.ShouldContain(EPMLiveTSDisableApprovals),
                () => lstSettings.ShouldContain(EPMLiveTSUseCurrent),
                () => lstSettings.ShouldContain(EPMLiveTSLiveHours),
                () => lstSettings.ShouldContain(EPMLiveTSMyFields),
                () => lstSettings.ShouldContain(EPMLiveTSAllowStopWatch),
                () => lstSettings.ShouldContain(EPMLiveEnableNonTeamNotf),
                () => lstSettings.ShouldContain(EPMPortManagerColumn),
                () => lstSettings.ShouldContain(EPMLiveDaySettings),
                () => lstSettings.ShouldContain(EPMLiveTSFields),
                () => responseRedirected.ShouldBeTrue());
        }

        [TestMethod]
        public void GridView1RowCommand_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string DelCommand = "Del";
            var gridViewEventArg = new ShimGridViewCommandEventArgs().Instance;
            var sqlCommand = string.Empty;
            ShimCommandEventArgs.AllInstances.CommandNameGet = _ => DelCommand;
            Shimtimesheetadmin.AllInstances.loadTypesSqlConnection = (_, __) => _loadTypesCalled = true;
            ShimSqlCommand.ConstructorString = (instance, command) => instance.CommandText = command;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                sqlCommand = instance.CommandText;
                return DummyIntOne;
            };

            // Act
            _privateObject.Invoke(GridView1RowCommandMethod, this, gridViewEventArg);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommand.ShouldBe("delete from TSTYPE where site_uid = @siteid and tstype_id=@tstype_id"),
                () => _loadTypesCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GridView1RowDataBound_WhenTypeCountIsZero_ConfirmResult()
        {
            // Arrange
            var gridViewEventArg = SetupForGridView1RowDataBoundMethod(DummyIntZero.ToString());

            // Act
            _privateObject.Invoke(GridView1RowDataBoundMethod, this, gridViewEventArg);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _attributes.ShouldContain($"onclick|javascript:return confirm('Are you sure you want to delete {DummyString}?')"),
                () => _attributes.ShouldContain($"onclick|javascript:editType('{DummyString}','{DummyString}');return false;"));
        }

        [TestMethod]
        public void GridView1RowDataBound_WhenTypeCountIsNotZero_ConfirmResult()
        {
            // Arrange
            var gridViewEventArg = SetupForGridView1RowDataBoundMethod(DummyIntZero.ToString());

            // Act
            _privateObject.Invoke(GridView1RowDataBoundMethod, this, gridViewEventArg);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _linkButton.ShouldNotBeNull(),
                () => _linkButton.Visible.ShouldBeFalse());
        }

        private GridViewRowEventArgs SetupForGridView1RowDataBoundMethod(string typeCount)
        {
            const string TypeCount = "TypeCount";
            var gridViewEventArg = new ShimGridViewRowEventArgs
            {
                RowGet = () => new ShimGridViewRow
                {
                    RowTypeGet = () => DataControlRowType.DataRow
                }
            }.Instance;
            _linkButton = new ShimLinkButton().Instance;
            ShimControl.AllInstances.FindControlString = (_, __) => _linkButton;
            ShimWebControl.AllInstances.AttributesGet = _ => new ShimAttributeCollection
            {
                AddStringString = (key, value) => _attributes.Add($"{key}|{value}")
            };
            ShimDataBinder.EvalObjectString = (_, expression) =>
            {
                if (expression == TypeCount)
                {
                    return typeCount;
                }
                return DummyString;
            };
            return gridViewEventArg;
        }

        [TestMethod]
        public void LoadTypes_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataBind = false;
            ShimSqlCommand.ConstructorString = (_, __) => { };
            ShimDataSet.Constructor = _ => { };
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = __ => new DataTable()
            };
            ShimSqlDataAdapter.ConstructorSqlCommand = (_, __) => { };
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, __) => DummyIntOne;
            ShimGridView.AllInstances.DataBind = _ => dataBind = true;

            // Act
            _privateObject.Invoke(LoadTypesMethod, new ShimSqlConnection().Instance);

            // Assert
            dataBind.ShouldBeTrue();
        }

        [TestMethod]
        public void AddListFieldData_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(new SPField[]
            {
                new ShimSPField
                {
                    TitleGet = () => DummyString,
                    InternalNameGet = () => DummyString,
                    ReorderableGet = () => true
                }
            });
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;

            // Act
            _privateObject.Invoke(AddListFieldDataMethod, _web.Instance, _web.Instance, DummyString);

            // Assert
            var lstData = _privateObject.GetField("lstData");
            var inputData = _privateObject.GetField("inputData");
            this.ShouldSatisfyAllConditions(
                () => lstData.ShouldBe($"<input type='hidden' name='lst{DummyString}' id='lst{DummyString}' value='{DummyString}|{DummyString}'>\r\n"),
                () => inputData.ShouldBe($"<input type='hidden' name='input{DummyString}' id='input{DummyString}' value='{DummyString}'>\r\n"));
        }
    }
}
