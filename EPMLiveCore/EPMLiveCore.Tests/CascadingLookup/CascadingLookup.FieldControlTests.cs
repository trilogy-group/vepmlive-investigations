using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.CascadingLookup
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CascadingLookupFieldControlTests
    {
        private IDisposable _shimsContext;
        private CascadingLookupFieldControl _testObject;
        private PrivateObject _privateObject;
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private const string PopulateDropdownMethodName = "PopulateDropdown";
        private const string DdlClFieldSelectedIndexChangedMethodName = "ddlCLField_SelectedIndexChanged";
        private const string UpdateChildrenMethodName = "UpdateChildren";
        private const string ExecuteQueryMethodName = "ExecuteQuery";
        private const string InitializeDDLMethodName = "InitializeDDL";

        private const string FieldFieldName = "Field";
        private const string DummyValue = "DummyValue";
        private const string DummyString = "DummyString";
        private const string DummyFilter = "DummyFilter";
        private const string DummyUrl = "DummyUrl";
        private const string DummyList = "DummyList";
        private const string DummyField = "DummyField";

        private Label _labelErrorField;
        private DropDownList _dropDownListClField;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new CascadingLookupFieldControl();
            _privateObject = new PrivateObject(_testObject);

            SetupTemplateContainer();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _testObject?.Dispose();
        }

        [TestMethod]
        public void GetValue_HaveSelectedValue_ReturnsSelectedValue()
        {
            // Arrange
            DefaultEnsureChildControls();

            // Act
            var actualResult = _testObject.Value;

            // Assert
            actualResult.ShouldBe(DummyValue);
        }

        [TestMethod]
        public void GetValue_FilteredValue_ReturnsSelectedValue()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName => propertyName
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            var dataTable = new DataTable();
            dataTable.Columns.Add(FieldFieldName);

            var row = dataTable.NewRow();
            row[FieldFieldName] = DummyValue;
            dataTable.Rows.Add(row);

            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => "Url",
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = internalName => new ShimSPField()
                            },
                            GetItemsSPQuery = query => new ShimSPListItemCollection()
                            {
                                GetDataTable = () => dataTable
                            }
                        }
                    }
                },
            };

            var page = new Page();
            page.Controls.Add(
                new DropDownList()
                {
                    ID = "FilterValueField"
                });
            ShimControl.AllInstances.PageGet = sender => page;

            // Act
            var actualResult = _testObject.Value;

            // Assert
            actualResult.ShouldBe(DummyValue);
        }

        [TestMethod]
        public void GetValue_SelectedValueThrowsException_ReturnsStringError()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName =>
                {
                    if (propertyName == "FilterValueField")
                    {
                        return string.Empty;
                    }

                    return propertyName;
                }
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => "Url",
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = internalName => new ShimSPField()
                            },
                            GetItemsSPQuery = query => new ShimSPListItemCollection()
                        }
                    }
                }
            };

            ShimListControl.AllInstances.SelectedValueGet = sender =>
            {
                throw new Exception();
            };

            // Act
            var actualResult = _testObject.Value;

            // Assert
            actualResult.ShouldBe("ERROR ddlCLField");
        }

        [TestMethod]
        public void GetValue_DropDownListCLFieldNull_ReturnsStringNull()
        {
            // Arrange, Act
            var actualResult = _testObject.Value;

            // Assert
            actualResult.ShouldBe("NULL ddlCLField");
        }

        [TestMethod]
        public void SetValue_NewSelectedValue_SelectedValueSetted()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName =>
                {
                    if (propertyName == "FilterValueField")
                    {
                        return string.Empty;
                    }

                    return propertyName;
                }
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            var dataTable = new DataTable();
            dataTable.Columns.Add(FieldFieldName);

            var row = dataTable.NewRow();
            row[FieldFieldName] = DummyValue;
            dataTable.Rows.Add(row);

            var row2 = dataTable.NewRow();
            row2[FieldFieldName] = DummyString;
            dataTable.Rows.Add(row2);

            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => "Url",
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = internalName => new ShimSPField()
                            },
                            GetItemsSPQuery = query => new ShimSPListItemCollection()
                            {
                                GetDataTable = () => dataTable
                            }
                        }
                    }
                }
            };
            ShimBaseFieldControl.AllInstances.ItemFieldValueGet = sender => DummyString;

            // Act
            _testObject.Value = DummyString;

            // Assert
            var actualResult = _testObject.Value;
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void Focus_DdlClFieldNull_ThrowsNullReferenceException()
        {
            // Arrange
            var focusCalled = false;
            DefaultEnsureChildControls();

            ShimControl.AllInstances.Focus = sender => focusCalled = true;

            //Act
            _testObject.Focus();

            // Assert
            focusCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void FindControlRecursive_FoundId_ReturnsControlWithId()
        {
            // Arrange
            var childControl = new Control()
            {
                ID = DummyString
            };

            var root = new Control();
            root.Controls.Add(childControl);

            // Act
            var actualResult = CascadingLookupFieldControl.FindControlRecursive(root, DummyString);

            // Assert
            actualResult.ShouldBe(childControl);
        }

        [TestMethod]
        public void FindControlRecursive_NotFoundId_ReturnsNull()
        {
            // Arrange, Act
            var actualResult = CascadingLookupFieldControl.FindControlRecursive(new Control(), DummyString);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void CreateChildControls_ControlModeDisplay_DoesNotSetProperties()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName => propertyName
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.Display;

            // Act
            _privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            GetFields();

            this.ShouldSatisfyAllConditions(
                () => _labelErrorField.ShouldBeNull(),
                () => _dropDownListClField.ShouldBeNull());
        }

        [TestMethod]
        public void CreateChildControls_DropDownListNotFound_ThrowsNullReferenceException()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName => propertyName
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            ShimControl.AllInstances.FindControlString = (_, key) =>
            {
                switch (key)
                {
                    case "lblError":
                        return new Label();
                    default:
                        return null;
                }
            };

            // Act
            Action action = () => _privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            action.ShouldThrow<NullReferenceException>();
        }

        [TestMethod]
        public void CreateChildControls_FieldNull_SetPropertiesError()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName => null
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            // Act
            _privateObject.Invoke(CreateChildControlsMethodName);

            // Assert
            GetFields();
            this.ShouldSatisfyAllConditions(
             () => _labelErrorField.CssClass.ShouldBe("ms-alerttext"),
             () => _labelErrorField.Text.ShouldBe("Invalid URI: The URI is empty."),
             () => _labelErrorField.Visible.ShouldBeTrue(),
             () => _dropDownListClField.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void PopulateDropdown_DoesNotFoundControl_SetPropertiesError()
        {
            // Arrange
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName => propertyName
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            var dataTable = new DataTable();
            dataTable.Columns.Add(FieldFieldName);

            var row = dataTable.NewRow();
            row[FieldFieldName] = DummyValue;
            dataTable.Rows.Add(row);

            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => "Url",
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = internalName => new ShimSPField()
                            },
                            GetItemsSPQuery = query => new ShimSPListItemCollection()
                            {
                                GetDataTable = () => dataTable
                            }
                        }
                    }
                },
            };

            // Act
            _privateObject.Invoke(PopulateDropdownMethodName);

            // Assert
            GetFields();

            this.ShouldSatisfyAllConditions(
                () => _labelErrorField.CssClass.ShouldBe("ms-alerttext"),
                () => _labelErrorField.Text.ShouldBe("Object reference not set to an instance of an object."),
                () => _labelErrorField.Visible.ShouldBeTrue(),
                () => _dropDownListClField.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void DdlClFieldSelectedIndexChanged_ChildFieldNotFound_KeepItems()
        {
            // Arrange
            DefaultEnsureChildControls(DummyFilter);

            var page = new Page();
            page.Controls.Add(
                new Control()
                {
                    ID = "ChildrenField"
                });
            page.Controls.Add(
                new DropDownList()
                {
                    ID = DummyFilter
                });

            ShimControl.AllInstances.PageGet = sender => page;

            // Act
            _privateObject.Invoke(DdlClFieldSelectedIndexChangedMethodName, this, EventArgs.Empty);

            // Assert
            GetFields();

            this.ShouldSatisfyAllConditions(
                () => _dropDownListClField.ShouldNotBeNull(),
                () => _dropDownListClField.Items.Count.ShouldBe(1),
                () => _dropDownListClField.Items[0].Value.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void DdlClFieldSelectedIndexChanged_PageNotFound_SetPropertiesError()
        {
            // Arrange
            DefaultEnsureChildControls();

            // Act
            _privateObject.Invoke(DdlClFieldSelectedIndexChangedMethodName, this, EventArgs.Empty);

            // Assert
            GetFields();

            this.ShouldSatisfyAllConditions(
                () => _labelErrorField.CssClass.ShouldBe("ms-alerttext"),
                () => _labelErrorField.Text.ShouldBe("Object reference not set to an instance of an object."),
                () => _labelErrorField.Visible.ShouldBeTrue(),
                () => _dropDownListClField.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void UpdateChildren_OnValidCall_PopulateCascadingLookUpPageParent()
        {
            // Arrange
            var pageCount = 0;
            DefaultEnsureChildControls(DummyFilter);

            var page = new Page();
            page.Controls.Add(
                new Control()
                {
                    ID = "ChildrenField"
                });
            page.Controls.Add(
                new DropDownList()
                {
                    ID = DummyFilter
                });
            var cascadingLookUpFieldControl = new CascadingLookupFieldControl();
            cascadingLookUpFieldControl.Controls.Add(page);

            ShimControl.AllInstances.PageGet = sender =>
            {
                if (pageCount++ > 2)
                {
                    return new Page();
                }

                return page;
            };

            // Act
            _privateObject.Invoke(UpdateChildrenMethodName, "ChildrenField");

            // Assert
            var privaObject = new PrivateObject(cascadingLookUpFieldControl);
            _dropDownListClField = (DropDownList)privaObject.GetField("ddlCLField");

            this.ShouldSatisfyAllConditions(
                () => _dropDownListClField.ShouldNotBeNull(),
                () => _dropDownListClField.Items.Count.ShouldBe(1),
                () => _dropDownListClField.Items[0].Value.ShouldBe(DummyValue));
        }

        [TestMethod]
        public void ExecuteQuery_UrlMatchFalse_ThrowException()
        {
            // Arrange
            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
            };

            // Act
            Action action = () => _privateObject.Invoke(
                ExecuteQueryMethodName, 
                DummyUrl, 
                DummyList, 
                DummyField, 
                new ShimSPQuery().Instance);

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe("Configuration Error (Url). Please contact Administrator.");
        }

        [TestMethod]
        public void ExecuteQuery_ListsNotFound_ThrowException()
        {
            // Arrange
            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl
                }
            };

            // Act
            Action action = () => _privateObject.Invoke(
                ExecuteQueryMethodName, 
                DummyUrl, 
                DummyList, 
                DummyField, 
                new ShimSPQuery().Instance);

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe("Configuration Error (List). Please contact Administrator.");
        }

        [TestMethod]
        public void ExecuteQuery_FieldNotFound_ThrowException()
        {
            // Arrange
            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                    }
                }
            };

            // Act
            Action action = () => _privateObject.Invoke(
                ExecuteQueryMethodName, 
                DummyUrl, 
                DummyList, 
                DummyField, 
                new ShimSPQuery().Instance);

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe("Configuration Error (Field). Please contact Administrator.");
        }

        [TestMethod]
        public void InitializeDdl_DefineNoneIsBoolean_AddItemOnDropDownList()
        {
            // Arrange
            var actualDropDownList = new DropDownList();

            // Act
            _privateObject.Invoke(InitializeDDLMethodName, actualDropDownList, bool.TrueString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualDropDownList.Items.Count.ShouldBe(1),
                () => actualDropDownList.Items[0].Text.ShouldBe("[Select One...]"),
                () => actualDropDownList.Items[0].Value.ShouldBe(string.Empty));
        }

        private void SetupTemplateContainer()
        {
            ShimTemplateBasedControl.AllInstances.TemplateContainerGet = _ => new ShimTemplateContainer();
            ShimControl.AllInstances.FindControlString = (_, key) =>
            {
                switch (key)
                {
                    case "lblError":
                        return new Label();
                    case "ddlCLField":
                        return new DropDownList();
                    default:
                        return null;
                }
            };
        }

        private static void DefaultEnsureChildControls(string filterValueField = "")
        {
            ShimFieldMetadata.AllInstances.FieldGet = sender => new ShimSPField()
            {
                GetCustomPropertyString = propertyName =>
                {
                    if (propertyName == "FilterValueField")
                    {
                        return filterValueField;
                    }

                    return propertyName;
                }
            };
            ShimFormComponent.AllInstances.ControlModeGet = sender => SPControlMode.New;

            ShimSPSite.ConstructorString = (sender, url) => new ShimSPSite(sender)
            {
                OpenWeb = () => new ShimSPWeb()
                {
                    UrlGet = () => "Url",
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName => new ShimSPList()
                        {
                            FieldsGet = () => new ShimSPFieldCollection()
                            {
                                GetFieldByInternalNameString = internalName => new ShimSPField()
                            },
                            GetItemsSPQuery = query => new ShimSPListItemCollection()
                            {
                                GetDataTable = CreateDataTableDropDown
                            }
                        }
                    }
                },
            };
        }

        private static DataTable CreateDataTableDropDown()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(FieldFieldName);

            var row = dataTable.NewRow();
            row[FieldFieldName] = DummyValue;
            dataTable.Rows.Add(row);
            return dataTable;
        }

        private void GetFields()
        {
            _labelErrorField = (Label)_privateObject.GetField("lblError");
            _dropDownListClField = (DropDownList)_privateObject.GetField("ddlCLField");
        }
    }
}