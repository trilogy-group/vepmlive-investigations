using System;
using System.Collections.Generic;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.CascadingLookup
{
    using EPMLiveCore;
    using Fakes;

    [TestClass]
    public class CascadingLookupFieldSettingsTests
    {
        private const string btnLoad_ClickMethodName = "btnLoad_Click";
        private const string ConvertToInternalNameMethodName = "ConvertToInternalName";
        private const string CleanupChildrenFieldMethodName = "CleanupChildrenField";
        private const string IsRelativeUrlMethodName = "IsRelativeUrl";
        private const string UpdateDDLSelectionMethodName = "UpdateDDLSelection";
        private const string WSSLoadFieldsMethodName = "WSSLoadFields";
        private const string ValidateSettingsMethodName = "ValidateSettings";
        private const string ddlField_SelectedIndexChangedMethodName = "ddlField_SelectedIndexChanged";
        private const string WSSLoadListsMethodName = "WSSLoadLists";
        private const string DummyString = "DummyString";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private CascadingLookupFieldSettings cascadingLookupFieldSettings;
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private readonly DropDownList ddlFilterValueField = new DropDownList();
        private readonly DropDownList ddlList = new DropDownList();
        private readonly DropDownList ddlField = new DropDownList();
        private readonly DropDownList ddlParentField = new DropDownList();
        private readonly CheckBox chkFilterCriteria = new CheckBox();
        private readonly CheckBox chkDefineNone = new CheckBox();
        private readonly Button btnLoad = new Button();
        private readonly TextBox txtUrl = new TextBox();
        private readonly Label lblUrl = new Label();
        private readonly Label lblList = new Label();
        private readonly Label lblField = new Label();
        private readonly Label lblParentField = new Label();
        private readonly Label lblFilterValueField = new Label();
        private readonly Label lblError = new Label();

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            cascadingLookupFieldSettings = new CascadingLookupFieldSettings();
            privateObject = new PrivateObject(cascadingLookupFieldSettings);
            privateObject.SetFieldOrProperty("ddlFilterValueField", ddlFilterValueField);
            privateObject.SetFieldOrProperty("ddlList", ddlList);
            privateObject.SetFieldOrProperty("ddlField", ddlField);
            privateObject.SetFieldOrProperty("ddlParentField", ddlParentField);
            privateObject.SetFieldOrProperty("chkFilterCriteria", chkFilterCriteria);
            privateObject.SetFieldOrProperty("chkDefineNone", chkDefineNone);
            privateObject.SetFieldOrProperty("btnLoad", btnLoad);
            privateObject.SetFieldOrProperty("txtUrl", txtUrl);
            privateObject.SetFieldOrProperty("lblUrl", lblUrl);
            privateObject.SetFieldOrProperty("lblList", lblList);
            privateObject.SetFieldOrProperty("lblField", lblField);
            privateObject.SetFieldOrProperty("lblParentField", lblParentField);
            privateObject.SetFieldOrProperty("lblFilterValueField", lblFilterValueField);
            privateObject.SetFieldOrProperty("lblError", lblError);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
            ddlFilterValueField?.Dispose();
            ddlList?.Dispose();
            ddlField?.Dispose();
            ddlParentField?.Dispose();
            chkFilterCriteria?.Dispose();
            chkDefineNone?.Dispose();
            btnLoad?.Dispose();
            txtUrl?.Dispose();
            lblUrl?.Dispose();
            lblList?.Dispose();
            lblField?.Dispose();
            lblParentField?.Dispose();
            lblFilterValueField?.Dispose();
            lblError?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, name) => new ShimSPList();
        }

        [TestMethod]
        public void InitializeWithField_Should_ExecuteCorrectly()
        {
            // Arrange
            var field = new ShimCascadingLookupField
            {
                UrlGet = () => DummyString,
                ListGet = () => DummyString,
                DefineNoneGet = () => DummyString,
            };
            ddlFilterValueField.Items.Add(DummyString);
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimControl.AllInstances.EnsureChildControls = _ => { };

            // Act
            cascadingLookupFieldSettings.InitializeWithField(field);
            var url = privateObject.GetFieldOrProperty("Url") as string;
            var list = privateObject.GetFieldOrProperty("List") as string;
            var defineNone = privateObject.GetFieldOrProperty("DefineNone") as string;

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => url.ShouldNotBeNullOrEmpty(),
                () => url.ShouldBe(DummyString),
                () => list.ShouldNotBeNullOrEmpty(),
                () => list.ShouldBe(DummyString),
                () => defineNone.ShouldNotBeNullOrEmpty(),
                () => defineNone.ShouldBe(DummyString),
                () => ddlFilterValueField.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void DisplayAsNewSection_Get_ReturnsTrue()
        {
            // Arrange, Act
            var result = cascadingLookupFieldSettings.DisplayAsNewSection;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateChildControls_IsPostBack()
        {
            // Arrange
            ShimUserControl.AllInstances.IsPostBackGet = _ => true;

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            chkDefineNone.Checked.ShouldBeFalse();
            ddlFilterValueField.EnableViewState.ShouldBeTrue();
            ddlParentField.EnableViewState.ShouldBeTrue();
            ddlField.EnableViewState.ShouldBeTrue();
            ddlList.AutoPostBack.ShouldBeTrue();
            ddlList.EnableViewState.ShouldBeTrue();
            ddlList.AutoPostBack.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateChildControls_IsNotPostBack()
        {
            // Arrange
            var wSSLoadFieldsWasCalled = false;
            var btnLoadClickWasCalled = false;
            ShimUserControl.AllInstances.IsPostBackGet = _ => false;
            ShimCascadingLookupFieldSettings.AllInstances.WSSLoadFieldsSPFieldCollectionDropDownListStringObjectBoolean =
                (_, fields, dropDown, selectedValue, sender, allowCustomField) =>
                {
                    wSSLoadFieldsWasCalled = true;
                };
            ShimCascadingLookupFieldSettings.AllInstances.btnLoad_ClickObjectEventArgs =
                (_, sender, events) =>
                {
                    btnLoadClickWasCalled = true;
                };

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => ddlList.Visible.ShouldBeFalse(),
                () => lblList.Visible.ShouldBeFalse(),
                () => wSSLoadFieldsWasCalled.ShouldBeTrue(),
                () => btnLoadClickWasCalled.ShouldBeTrue(),
                () => txtUrl.Text.ShouldBe("Current"));
        }

        [TestMethod]
        public void CreateChildControls_OnException_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedErrorMessage = "Dummy Error";
            ShimUserControl.AllInstances.IsPostBackGet = _ => false;
            privateObject.SetFieldOrProperty("DefineNone", DummyString);
            privateObject.SetFieldOrProperty("Url", DummyString);
            ShimCascadingLookupFieldSettings.AllInstances.btnLoad_ClickObjectEventArgs = (_, sender, events) =>
            {
                throw new Exception(ExpectedErrorMessage);
            };
            ShimCascadingLookupFieldSettings.AllInstances.WSSLoadFieldsSPFieldCollectionDropDownListStringObjectBoolean = 
                (_, fields, dropDown, valueFields, sener, alloCustomFields) => { };

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => lblError.Text.ShouldNotBeNullOrEmpty(),
                () => lblError.Text.ShouldContain(ExpectedErrorMessage),
                () => lblError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void btnLoad_Click()
        {
            // Arrange
            var WSSLoadListsWasCalled = false;
            var ddlListSelectedIndexChangedWasCalled = false;
            ShimCascadingLookupFieldSettings.AllInstances.FindRelativeUrlString = (_, url) => DummyString;
            ShimCascadingLookupFieldSettings.AllInstances.WSSLoadListsStringDropDownListStringObject =
                (_, url, dropDown, selectedValue, sender) =>
                {
                    WSSLoadListsWasCalled = true;
                };
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimCascadingLookupFieldSettings.AllInstances.ddlList_SelectedIndexChangedObjectEventArgs =
                (_, sender, events) =>
                {
                    ddlListSelectedIndexChangedWasCalled = true;
                };

            // Act
            privateObject.Invoke(btnLoad_ClickMethodName, new object(), EventArgs.Empty);

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => ddlListSelectedIndexChangedWasCalled.ShouldBeTrue(),
                () => WSSLoadListsWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void btnLoad_Click_OnException_ReportsError()
        {
            // Arrange
            const string ErrorMessage = "Error Message";
            ShimCascadingLookupFieldSettings.AllInstances.FindRelativeUrlString = (_, url) => DummyString;
            ShimCascadingLookupFieldSettings.AllInstances.WSSLoadListsStringDropDownListStringObject =
                (_, url, dropDown, selectedValue, sender) =>
                {
                    throw new Exception(ErrorMessage);
                };
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimCascadingLookupFieldSettings.AllInstances.ddlList_SelectedIndexChangedObjectEventArgs =
                (_, sender, events) => { };
            privateObject.SetFieldOrProperty("Url", DummyString);
            privateObject.SetFieldOrProperty("List", DummyString);

            // Act
            privateObject.Invoke(btnLoad_ClickMethodName, new object(), EventArgs.Empty);

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => lblError.Text.ShouldContain(ErrorMessage),
                () => lblError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void ConvertToInternalName_Should_ReturnExpectedValue()
        {
            // Arrange
            const string Name = "Test!%<>@$";
            const string ExpectedValue = "Test_x005F_x0021_x005F__x005F_x0";

            // Act
            var result = privateObject.Invoke(ConvertToInternalNameMethodName, Name) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void CleanupChildrenField_Should_ExecuteCorrectly()
        {
            // Arrange
            var field = new ShimSPField
            {
                ParentListGet = () => new ShimSPList
                {
                    FieldsGet = () => new ShimSPFieldCollection
                    {
                        GetFieldByInternalNameString = name =>
                        {
                            if (name == "[Test")
                            {
                                throw new Exception();
                            }
                            else
                            {
                                return new ShimSPField();
                            }
                        }
                    }
                }
            }.Instance;
            const string ChildrenField = "[Dummy] [String] [Test] ";
            const string ExpectedValue = "[Dummy] [String] ";

            // Act
            var result = privateObject.Invoke(CleanupChildrenFieldMethodName, field, ChildrenField) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void IsRelativeUrl_UrlCurrent_ReturnsTrue()
        {
            // Arrange
            var privateType = new PrivateType(typeof(CascadingLookupFieldSettings));
            const string Url = "Current";

            // Act
            var result = (bool)privateType.InvokeStatic(IsRelativeUrlMethodName, Url);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsRelativeUrl_UrlTop_ReturnsTrue()
        {
            // Arrange
            var privateType = new PrivateType(typeof(CascadingLookupFieldSettings));
            const string Url = "Top";

            // Act
            var result = (bool)privateType.InvokeStatic(IsRelativeUrlMethodName, Url);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsRelativeUrl_UrlParent_ReturnsTrue()
        {
            // Arrange
            var privateType = new PrivateType(typeof(CascadingLookupFieldSettings));
            const string Url = "Parent";

            // Act
            var result = (bool)privateType.InvokeStatic(IsRelativeUrlMethodName, Url);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void IsRelativeUrl_UrlNotRelative_ReturnsFalse()
        {
            // Arrange
            var privateType = new PrivateType(typeof(CascadingLookupFieldSettings));
            const string Url = "http://dummy.org/url";

            // Act
            var result = (bool)privateType.InvokeStatic(IsRelativeUrlMethodName, Url);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void UpdateDDLSelection()
        {
            // Arrange
            var dropDown = new DropDownList();
            dropDown.Items.Add(DummyString);
            var args = new object[] { dropDown, DummyString, DummyString, cascadingLookupFieldSettings };

            // Act
            privateObject.Invoke(UpdateDDLSelectionMethodName, args);
            var listItem = dropDown.Items.FindByValue(DummyString);

            // Assert
            listItem.ShouldNotBeNull();
            listItem.Selected.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateDDLSelection_ItemNotFound_ThrowsException()
        {
            // Arrange
            var dropDown = new DropDownList();
            dropDown.Items.Add("Value");
            var args = new object[] { dropDown, DummyString, DummyString, cascadingLookupFieldSettings };

            // Act
            Action action = () => privateObject.Invoke(UpdateDDLSelectionMethodName, args);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void WSSLoadFields_AllowCustomFieldTypeOnlyFalse_ExecutesCorrectly()
        {
            // Arrange
            var dropDown = new DropDownList();
            ShimSPList.AllInstances.FieldsGet = _ =>
            {
                var list = new List<SPField>
                {
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Number,
                        InternalNameGet = () => DummyString,
                        TitleGet = () => DummyString
                    },
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.WorkflowStatus,
                        InternalNameGet = () => DummyString,
                        TitleGet = () => DummyString
                    }
                };
                return new ShimSPFieldCollection().Bind(list);
            };
            var args = new object[] { DummyString, DummyString, dropDown, DummyString, DummyString };

            // Act
            privateObject.Invoke(WSSLoadFieldsMethodName, args);

            // Assert
            dropDown.ShouldSatisfyAllConditions(
                () => dropDown.Items.Count.ShouldBe(2),
                () => dropDown.Items.FindByValue(DummyString).ShouldNotBeNull());
        }

        [TestMethod]
        public void WSSLoadFields_AllowCustomFieldTypeOnly_ExecutesCorrectly()
        {
            // Arrange
            var dropDown = new DropDownList();
            var fields = new List<SPField>
            {
                new ShimSPField
                {
                    TypeAsStringGet = () => "CascadingLookupField",
                    InternalNameGet = () => DummyString,
                    TitleGet = () => DummyString
                },
                new ShimSPField
                {
                    TypeAsStringGet = () => DummyString,
                    InternalNameGet = () => DummyString,
                    TitleGet = () => DummyString
                }
            };
            var fieldsCollection = new ShimSPFieldCollection().Bind(fields).Instance;
            var args = new object[] { fieldsCollection, dropDown, DummyString, new object(), true };

            // Act
            privateObject.Invoke(WSSLoadFieldsMethodName, args);

            // Assert
            dropDown.ShouldSatisfyAllConditions(
                () => dropDown.Items.Count.ShouldBe(2),
                () => dropDown.Items.FindByValue(DummyString).ShouldNotBeNull());
        }

        [TestMethod]
        public void WSSLoadFields_NoUsableFieldOnList_ThrowsException()
        {
            // Arrange
            var dropDown = new DropDownList();
            var fields = new List<SPField>();
            var fieldsCollection = new ShimSPFieldCollection().Bind(fields).Instance;
            var args = new object[] { fieldsCollection, dropDown, DummyString, new object(), false };

            // Act
            Action action = () => privateObject.Invoke(WSSLoadFieldsMethodName, args);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void ValidateSettings_Should_ExecuteCorrectly()
        {
            // Arrange
            chkFilterCriteria.Checked = false;
            ddlParentField.Items.Add(new ListItem(DummyString, DummyString) { Selected = false });
            ddlFilterValueField.Items.Add(new ListItem(DummyString, DummyString) { Selected = false });

            // Act
            privateObject.Invoke(ValidateSettingsMethodName);
            var parentFieldItem = ddlParentField.Items.FindByValue(DummyString);
            var filterValueFieldItem = ddlParentField.Items.FindByValue(DummyString);

            // Assert
            cascadingLookupFieldSettings.ShouldSatisfyAllConditions(
                () => parentFieldItem.ShouldNotBeNull(),
                () => parentFieldItem.Selected.ShouldBeTrue(),
                () => filterValueFieldItem.ShouldNotBeNull(),
                () => filterValueFieldItem.Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void ddlField_SelectedIndexChanged_onSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var chkFilterCriteriaWasCalled = false;
            ShimCascadingLookupFieldSettings.AllInstances.chkFilterCriteria_CheckedChangedObjectEventArgs = 
                (_, sender, events) => 
                {
                    chkFilterCriteriaWasCalled = true;
                };
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            
            // Act
            privateObject.Invoke(ddlField_SelectedIndexChangedMethodName, new object(), EventArgs.Empty);

            // Assert
            chkFilterCriteriaWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void ddlField_SelectedIndexChanged_OnException_ShouldRetportError()
        {
            // Arrange
            const string ErrorMessage = "Error Message";
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimCascadingLookupFieldSettings.AllInstances.chkFilterCriteria_CheckedChangedObjectEventArgs = 
                (_, sender, events) => 
                {
                    throw new Exception(ErrorMessage);
                };

            // Act
            privateObject.Invoke(ddlField_SelectedIndexChangedMethodName, new object(), EventArgs.Empty);

            // Assert
            lblError.ShouldSatisfyAllConditions(
                () => lblError.Text.ShouldContain(ErrorMessage),
                () => lblError.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void WSSLoadLists()
        {
            // Arrange
            var dropDown = new DropDownList();
            var args = new object[] { DummyString, dropDown, DummyString, DummyString };
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>
                {
                    new ShimSPList
                    {
                        HiddenGet = () => false
                    }
                };
                return new ShimSPListCollection().Bind(list);
            };

            // Act
            privateObject.Invoke(WSSLoadListsMethodName, args);

            // Assert
            dropDown.Items.Count.ShouldBe(2);
        }

        [TestMethod]
        public void WSSLoadLists_InvalidSiteUrl_ThrowsException()
        {
            // Arrange
            var dropDown = new DropDownList();
            var args = new object[] { DummyString, dropDown, DummyString, DummyString };
            ShimSPWeb.AllInstances.UrlGet = _ => string.Empty;
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>
                {
                    new ShimSPList
                    {
                        HiddenGet = () => false
                    }
                };
                return new ShimSPListCollection().Bind(list);
            };

            // Act
            Action action = () => privateObject.Invoke(WSSLoadListsMethodName, args);

            // Assert
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void WSSLoadLists_WebListEmpty_ThrowsException()
        {
            // Arrange
            var dropDown = new DropDownList();
            var args = new object[] { DummyString, dropDown, DummyString, DummyString };
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>();
                return new ShimSPListCollection().Bind(list);
            };

            // Act
            Action action = () => privateObject.Invoke(WSSLoadListsMethodName, args);

            // Assert
            action.ShouldThrow<Exception>();
        }

    }
}
