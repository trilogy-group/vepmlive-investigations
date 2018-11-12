using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        private bool _addListFieldDataCalled;
        private bool _loadTypesCalled;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";

        [TestInitialize]
        public void TestInitialize()
        {
            _addListFieldDataCalled = false;
            _loadTypesCalled = false;
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
                UrlGet = () => DummyUrl,
                UserIsSiteAdminGet = () => true,
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList()
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
            _privateObject.Invoke("Page_Load", this, EventArgs.Empty);

            // Assert
            var pnlActivation = (Panel)_privateObject.GetField("pnlActivation");
            var pnlTs = (Panel)_privateObject.GetField("pnlTs");
            var pnlTL = (Panel)_privateObject.GetField("pnlTL");
            var pnlMain = (Panel)_privateObject.GetField("pnlMain");
            var dtSpStart = (DateTimeControl)_privateObject.GetField("dtSpStart");
            var dtSpEnd = (DateTimeControl)_privateObject.GetField("dtSpEnd");
            var hlAdmin = (HyperLink)_privateObject.GetField("hlAdmin");
            var ddlFieldLists = (DropDownList)_privateObject.GetField("ddlFieldLists");
            this.ShouldSatisfyAllConditions(
                () => pnlActivation.Visible.ShouldBeTrue(),
                () => pnlTs.Visible.ShouldBeFalse(),
                () => pnlTL.Visible.ShouldBeTrue(),
                () => pnlMain.Visible.ShouldBeFalse(),
                () => dtSpStart.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => dtSpEnd.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => hlAdmin.NavigateUrl.ShouldBe($"{DummyUrl}/_layouts/epmlive/timesheetadmin.aspx"),
                () => ddlFieldLists.Attributes.Count.ShouldBe(1),
                () => ddlFieldLists.Attributes["onchange"].ShouldNotBeNull(),
                () => _addListFieldDataCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_WhenIsRootWeb_ConfirmResult()
        {
            // Arrange
            SetupForPageLoadMethod(true);

            // Act
            _privateObject.Invoke("Page_Load", this, EventArgs.Empty);

            // Assert
            var pnlActivation = (Panel)_privateObject.GetField("pnlActivation");
            var pnlTs = (Panel)_privateObject.GetField("pnlTs");
            var pnlTL = (Panel)_privateObject.GetField("pnlTL");
            var pnlMain = (Panel)_privateObject.GetField("pnlMain");
            var dtSpStart = (DateTimeControl)_privateObject.GetField("dtSpStart");
            var dtSpEnd = (DateTimeControl)_privateObject.GetField("dtSpEnd");
            var hlAdmin = (HyperLink)_privateObject.GetField("hlAdmin");
            var ddlFieldLists = (DropDownList)_privateObject.GetField("ddlFieldLists");
            this.ShouldSatisfyAllConditions(
                () => pnlActivation.Visible.ShouldBeTrue(),
                () => pnlTs.Visible.ShouldBeFalse(),
                () => pnlTL.Visible.ShouldBeTrue(),
                () => pnlMain.Visible.ShouldBeTrue(),
                () => dtSpStart.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => dtSpEnd.DatePickerFrameUrl.ShouldBe($"{DummyUrl}/_layouts/iframe.aspx"),
                () => hlAdmin.NavigateUrl.ShouldBeNullOrWhiteSpace(),
                () => ddlFieldLists.Attributes.Count.ShouldBe(1),
                () => ddlFieldLists.Attributes["onchange"].ShouldNotBeNull(),
                () => _loadTypesCalled.ShouldBeTrue(),
                () => _addListFieldDataCalled.ShouldBeTrue());
        }

        private void SetupForPageLoadMethod(bool isRootWeb)
        {
            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => DummyInt;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => _web;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => _web;
            ShimSPContext.AllInstances.SiteGet = _ => _site;
            ShimSPWeb.AllInstances.IsRootWebGet = _ => isRootWeb;
            Shimtimesheetadmin.AllInstances.addListFieldDataSPWebSPWebString = (_, _1, _2, _3) => _addListFieldDataCalled = true;
            Shimtimesheetadmin.AllInstances.loadTypesSqlConnection = (_, __) => _loadTypesCalled = true;
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) =>
            {
                switch (setting)
                {
                    case "EPMLiveTSAllowUnassigned":
                    case "EPMLiveTSAllowNotes":
                    case "EPMLiveTSUseCurrent":
                    case "EPMLiveEnableNonTeamNotf":
                    case "EPMLiveTSDisableApprovals":
                    case "EPMLiveTSLiveHours":
                        return "true";
                    case "EPMLiveDaySettings":
                        return $"true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}|true|{DummyString}|{DummyString}";
                    default:
                        return DummyString;
                }
            };
            ShimSPSite.ConstructorString = (instance, __) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => _web;
            ShimTimesheetSettings.ConstructorSPWeb = (instance, __) => 
            {
                instance.TimesheetFields = new ArrayList { "FirstField" };
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(new SPField[]
            {
                new ShimSPField()
                {
                    TitleGet = () => "FirstField",
                    InternalNameGet = () => "FirstField"
                },
                new ShimSPField()
                {
                    TitleGet = () => "SecondField",
                    InternalNameGet = () => "SecondField"
                }
            });
            ShimSPField.AllInstances.ReorderableGet = _ => true;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlCommand.ConstructorString = (_, __) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.MinValue;
            ShimSqlDataReader.AllInstances.Close = _ => { };
        }
    }
}
