using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.SPFields;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.SPFields
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DaysHoursBreakdownFieldControlTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string WrongTimeValue = "10";
        private const string DummyString = "DummyString";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodFinishDateTextBoxTextChanged = "FinishDateTextBoxTextChanged";
        private const string MethodStartDateTextBoxTextChanged = "StartDateTextBoxTextChanged";
        private static readonly Guid DefaultWebId = Guid.NewGuid();
        private static readonly Guid DefaultListId = Guid.NewGuid();
        private static readonly DateTime DefaultDate = new DateTime(2019, 1, 1);
        private DaysHoursBreakdownFieldControl _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private bool _didRegisterScript;
        private DataControlFieldCollection _columns;
        private object _itemFieldValue;
        private static Label _errorLabel;
        private static TextBox _timeTextBox;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            
            ShimBaseFieldControl.AllInstances.CreateChildControls = _ => { };
            ShimBaseFieldControl.AllInstances.ItemFieldValueGet = _ => _itemFieldValue;
            ShimBaseFieldControl.AllInstances.ItemFieldValueSetObject = (_, newValue) => _itemFieldValue = newValue;
            ShimGridView.AllInstances.HeaderRowGet = _ => new ShimGridViewRow();
            ShimTableRow.AllInstances.CellsGet = _ => new ShimTableCellCollection { CountGet = () => 1 };
            _testObject = new DaysHoursBreakdownFieldControl
            {
                Page = new Page(),
                ID = One,
                ControlMode = SPControlMode.Edit,
                ItemFieldValue = One
            };
            _privateObject = new PrivateObject(_testObject);
            _errorLabel = new Label();
            _timeTextBox = new TextBox { Text = "10:30:00" };

            SetupTemplateContainer();
            SetupHttpContext();
            PrepareSpContext();

            _didRegisterScript = false;
            ShimScriptManager.RegisterStartupScriptControlTypeStringStringBoolean =
                (a, b, c, d, e) => _didRegisterScript = true;
            ShimFieldMetadata.AllInstances.FieldGet =
                _ => new DaysHoursBreakdownField(new ShimSPFieldCollection(), "Text", "Display Name")
                {
                    StartDateField = "StartDateField",
                    FinishDateField = "FinishDateField",
                    HoursField = "HoursField"
                };
            ShimFormComponent.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimFormComponent.AllInstances.ListItemGet = _ => new ShimSPListItem();

            _columns = new DataControlFieldCollection();
            ShimGridView.AllInstances.ColumnsGet = _ => _columns;
            ShimGridView.AllInstances.DataBind = _ => { };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void UpdateFieldValueInItem_Invoke_SetsValues()
        {
            // Arrange
            decimal value = 0;
            ShimSPListItem.AllInstances.ItemSetStringObject = (_, key, itemValue) =>
            {
                if (key.Equals("HoursField"))
                {
                    value = Convert.ToDecimal(itemValue);
                }
            };
            _privateObject.Invoke(MethodCreateChildControls);

            // Act
            _testObject.UpdateFieldValueInItem();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => value.ShouldBe(30),
                () =>
                {
                    _testObject.ItemFieldValue.ShouldNotBeNull();
                    _testObject.ItemFieldValue.ShouldBe("30");
                },
                () => _didRegisterScript.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateChildControls_WorkHoursFail_FillsErrorFields()
        {
            // Arrange
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => 2;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldNotBeNullOrWhiteSpace();
            _errorLabel.Text.ShouldBe("<b>Error: </b>Your user account does not have a Work Hours schedule specified in the Resource Pool.  Please contact your Administrator to correctly associate your account with a Work Hours schedule.");
        }

        [TestMethod]
        public void CreateChildControls_LoadDaysFail_FillsErrorFields()
        {
            // Arrange
            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case "SharePointAccount":
                        return null;
                    default:
                        return GetListItemValue(key);
                }
            };

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldNotBeNullOrWhiteSpace();
            _errorLabel.Text.ShouldBe("<b>Error: </b>You do not have permission to read required information from the resource pool. You must have at least read-only access to the resource pool in order to enter Time Off. Please contact your system administrator to have your permissions adjusted.");
        }

        [TestMethod]
        public void FinishDateTextBoxTextChanged_Invoke_UpdatesGrid()
        {
            // Arrange
            _privateObject.Invoke(MethodCreateChildControls);
            var dateFormat = CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern.Replace('-', '/').Replace('.', '/');
            var textBox = new TextBox { Text = DefaultDate.ToString(dateFormat) };

            // Act
            _privateObject.Invoke(MethodFinishDateTextBoxTextChanged, new object[] { textBox, EventArgs.Empty });

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void FinishDateTextBoxTextChanged_UpdateError_FillsErrorLabel()
        {
            // Arrange
            _privateObject.Invoke(MethodCreateChildControls);
            var textBox = new TextBox { Text = WrongTimeValue };
            _timeTextBox = new TextBox { Text = WrongTimeValue };

            // Act
            _privateObject.Invoke(MethodFinishDateTextBoxTextChanged, new object[] { textBox, EventArgs.Empty });

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldNotBeNullOrWhiteSpace();
            _errorLabel.Text.ShouldContainWithoutWhitespace("<b>Error: </b>");
        }

        [TestMethod]
        public void StartDateTextBoxTextChanged_Invoke_UpdatesGrid()
        {
            // Arrange
            _privateObject.Invoke(MethodCreateChildControls);
            var dateFormat = CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern.Replace('-', '/').Replace('.', '/');
            var textBox = new TextBox { Text = DefaultDate.ToString(dateFormat) };

            // Act
            _privateObject.Invoke(MethodStartDateTextBoxTextChanged, new object[] { textBox, EventArgs.Empty });

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void StartDateTextBoxTextChanged_UpdateError_FillsErrorLabel()
        {
            // Arrange
            _privateObject.Invoke(MethodCreateChildControls);
            var textBox = new TextBox { Text = WrongTimeValue };
            _timeTextBox = new TextBox { Text = WrongTimeValue };

            // Act
            _privateObject.Invoke(MethodStartDateTextBoxTextChanged, new object[] { textBox, EventArgs.Empty });

            // Assert
            _errorLabel.ShouldNotBeNull();
            _errorLabel.Text.ShouldNotBeNullOrWhiteSpace();
            _errorLabel.Text.ShouldContainWithoutWhitespace("<b>Error: </b>");
        }

        private void PrepareSpContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.ListItemGet = _ => new ShimSPListItem();

            ShimCoreFunctions.getLockedWebSPWeb = web => DefaultWebId;
            ShimCoreFunctions.iGetConfigSettingSPWebStringBooleanBoolean = (a, b, c, d) => string.Empty;
            ShimUtils.GetConfigWebSPWebGuid = (_, __) => new ShimSPWeb();
            var listCollection = new ShimSPListCollection();
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Bind(new SPList[] { new ShimSPList() });
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPWeb.AllInstances.Close = _ => { };

            ShimSPSite.ConstructorString = (_, __) =>
            {
                ShimSPSite.AllInstances.OpenWeb = x => new ShimSPWeb();
                ShimSPSite.AllInstances.Close = x => { };
            };

            ShimSPListCollection.AllInstances.GetListGuidBoolean = (a, b, c) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });
            var listItemCollection = new ShimSPListItemCollection();
            ShimSPList.AllInstances.ItemsGet = _ => listItemCollection.Bind(new SPListItem[] { new ShimSPListItem().Instance });
            ShimSPListItem.AllInstances.IDGet = _ => Id;
            ShimSPListItem.AllInstances.TitleGet = _ => "LITitle";
            ShimSPListItem.AllInstances.ItemGetString = (_, key) => GetListItemValue(key);

            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPFieldLookup();
            ShimSPField.AllInstances.GetCustomPropertyString = (_, key) => key;

            ShimSPFieldLookup.AllInstances.LookupListGet = _ => DefaultListId.ToString();

            ShimSPFieldUserValue.ConstructorSPWebString = (a, b, c) => { };
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => Id;

            ShimSPFieldLookupValue.ConstructorString = (_, __) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => Id;

            ShimSPRegionalSettings.AllInstances.LocaleIdGet = _ => (uint)CultureInfo.InvariantCulture.LCID;
        }

        private static object GetListItemValue(string key)
        {
            switch (key)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    return 8;
                case "Sunday":
                case "Saturday":
                    return 0;
                case "Date":
                case "StartDateField":
                case "FinishDateField":
                    return DefaultDate;
                default:
                    return DummyString;
            }
        }

        private void SetupHttpContext()
        {
            HttpContext.Current = new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.FormGet = _ => new NameValueCollection
            {
                { "__CALLBACKID", DummyString }
            };
        }

        private static void SetupTemplateContainer()
        {
            ShimTemplateBasedControl.AllInstances.TemplateContainerGet = _ => new ShimTemplateContainer();
            ShimControl.AllInstances.FindControlString = (_, key) =>
            {
                switch (key)
                {
                    case "DaysHoursBreakdownGridPanel":
                    case "DaysHoursBreakdownErrorPanel":
                    case "DHBErrorPanel":
                        return new Panel();
                    case "DaysHoursBreakdownGridErrorLabel":
                    case "DHBErrorLabel":
                        return _errorLabel;
                    case "DaysHoursBreakdownStartDateTextBox":
                    case "DaysHoursBreakdownFinishDateTextBox":
                    case "DaysHoursBreakdownFirstLoadTextBox":
                    case "DaysHoursBreakdownErrorTextBox":
                    case "DaysHoursBreakdownInfoTextBox":
                        return new TextBox();
                    case "DaysHoursBreakdownValueTextBox":
                        return _timeTextBox;
                    case "DaysHoursBreakdownPostBackMarkerTextBox":
                        return new TextBox { Text = bool.FalseString.ToLower() };
                    case "DaysHoursBreakdownGridView":
                        return new ShimSPGridView().Instance;
                    case "DaysHoursBreakdownUpdatePanel":
                        return new UpdatePanel();
                    default:
                        return null;
                }
            };
        }
    }
}
