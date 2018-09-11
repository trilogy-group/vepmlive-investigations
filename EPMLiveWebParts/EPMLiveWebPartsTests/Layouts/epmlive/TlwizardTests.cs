using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Layouts.epmlive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TlwizardTests
    {
        private IDisposable _shimsObject;
        private tlwizard _testObj;
        private PrivateObject _privateObj;
        private ShimSPSite _site;
        private TextBox _txtReportDatabase;
        private TextBox _txtReportServer;
        private TextBox _txtReportPassword;
        private TextBox _txtReportUsername;
        private HiddenField _hdnSaveReportPassword;
        private CheckBox _chkWindows;
        private Label _lblNoReporting;

        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";

        private const string PageLoadMethod = "Page_Load";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new tlwizard();
            _privateObj = new PrivateObject(_testObj);

            InitializeUiControls();

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUiControls()
        {
            var allFields = _testObj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }

            _txtReportDatabase = (TextBox)_privateObj.GetFieldOrProperty("txtReportDatabase");
            _txtReportServer = (TextBox)_privateObj.GetFieldOrProperty("txtReportServer");
            _txtReportPassword = (TextBox)_privateObj.GetFieldOrProperty("txtReportPassword");
            _txtReportUsername = (TextBox)_privateObj.GetFieldOrProperty("txtReportUsername");
            _hdnSaveReportPassword = (HiddenField)_privateObj.GetFieldOrProperty("hdnSaveReportPassword");
            _chkWindows = (CheckBox)_privateObj.GetFieldOrProperty("chkWindows");
            _lblNoReporting = (Label)_privateObj.GetFieldOrProperty("lblNoReporting");
        }

        private void SetupShims()
        {
            _site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                UrlGet = () => DummyUrl,
                IDGet = () => Guid.NewGuid()
            };

            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _site
            };

            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) =>
            {
                switch (setting)
                {
                    case "ReportingServicesURL":
                        return "/reportService";
                    default:
                        return DummyString;
                }
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();

            ShimSqlDataReader.AllInstances.Close = _ => { };

            ShimPage.AllInstances.IsPostBackGet = _ => false;
        }

        [TestMethod]
        public void PageLoad_WhenExecuteReaderIsTrue_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(true, DummyString);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBe(DummyString),
                () => _txtReportServer.Text.ShouldBe(DummyString),
                () => _txtReportPassword.Text.ShouldBe(DummyString),
                () => _txtReportUsername.Text.ShouldBe(DummyString),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeTrue(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeTrue(),
                () => _hdnSaveReportPassword.Value.ShouldBe(DummyString),
                () => _chkWindows.Enabled.ShouldBeFalse());
        }

        [TestMethod]
        public void PageLoad_WhenExecuteReaderIsFalse_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(false, DummyString);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBeEmpty(),
                () => _txtReportServer.Text.ShouldBeEmpty(),
                () => _chkWindows.Enabled.ShouldBeFalse(),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeFalse(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeFalse(),
                () => _lblNoReporting.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_WhenConnectionStringIsEmpty_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(false, string.Empty);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBeEmpty(),
                () => _txtReportServer.Text.ShouldBeEmpty(),
                () => _chkWindows.Enabled.ShouldBeFalse(),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeFalse(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeFalse(),
                () => _lblNoReporting.Visible.ShouldBeTrue());
        }

        private static void SetupForPageLoad(bool reader, string connectionString)
        {
            ShimSqlDataReader.AllInstances.Read = _ => reader;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => connectionString;
        }
    }
}
