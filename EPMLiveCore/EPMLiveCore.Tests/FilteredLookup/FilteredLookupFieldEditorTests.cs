using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;

namespace EPMLiveCore.Tests.FilteredLookup
{
    [TestClass]
    public class FilteredLookupFieldEditorTests
    {
        private const string SetControlVisibilityMethodName = "SetControlVisibility";
        private const string SetTargetColumnMethodName = "SetTargetColumn";
        private const string CanFieldBeDisplayedMethodName = "CanFieldBeDisplayed";
        private const string SetTargetListViewMethodName = "SetTargetListView";
        private const string SetTargetListMethodName = "SetTargetList";
        private const string OnInitMethodName = "OnInit";
        private const string TargetListId = "TARGET_LIST_ID";
        private const string TargetListViewId = "TARGET_LISTVIEW_ID";
        private const string TargetColumnId = "TARGET_COLUMN_ID";
        private const string TargetwebId = "TARGET_WEB_ID";
        private const string SelectedTargetListChangedMethodName = "SelectedTargetListChanged";
        private const string SelectedTargetWebChangedMethodName = "SelectedTargetWebChanged";
        private const string SelectedFilterOptionChangedMethodName = "SelectedFilterOptionChanged";
        private const string SetTargetWebMethodName = "SetTargetWeb";
        private const string DummyUrl = "https://dummy.org/";
        private const string DummyString = "DummyString";
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private static readonly StateBag ViewState = new StateBag();
        private readonly CheckBox cbxAllowMultiValue = new CheckBox();
        private readonly CheckBox cbxUnlimitedLengthInDocLib = new CheckBox();
        private readonly CheckBox cbxRecursiveFilter = new CheckBox();
        private readonly TextBox txtQueryFilter = new TextBox();
        private readonly Label lblTargetList = new Label();
        private readonly Label lblTargetWeb = new Label();
        private readonly DropDownList listTargetList = new DropDownList();
        private readonly DropDownList listTargetWeb = new DropDownList();
        private readonly DropDownList listTargetListView = new DropDownList();
        private readonly DropDownList listTargetColumn = new DropDownList();
        private readonly HtmlTableCell tdListView = new HtmlTableCell();
        private readonly HtmlTableCell tdQuery = new HtmlTableCell();
        private readonly RadioButtonList rdFilterOption = new RadioButtonList();
        private readonly HtmlGenericControl SpanDocLibWarning = new HtmlGenericControl();
        private readonly HtmlGenericControl SpanLengthWarning = new HtmlGenericControl();
        private IDisposable shimsContext;
        private FilteredLookupFieldEditor filteredLookupFieldEditor;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            filteredLookupFieldEditor = new FilteredLookupFieldEditor();
            privateObject = new PrivateObject(filteredLookupFieldEditor);
            privateObject.SetFieldOrProperty("cbxAllowMultiValue", cbxAllowMultiValue);
            privateObject.SetFieldOrProperty("cbxUnlimitedLengthInDocLib", cbxUnlimitedLengthInDocLib);
            privateObject.SetFieldOrProperty("cbxRecursiveFilter", cbxRecursiveFilter);
            privateObject.SetFieldOrProperty("txtQueryFilter", txtQueryFilter);
            privateObject.SetFieldOrProperty("lblTargetList", lblTargetList);
            privateObject.SetFieldOrProperty("lblTargetWeb", lblTargetWeb);
            privateObject.SetFieldOrProperty("listTargetList", listTargetList);
            privateObject.SetFieldOrProperty("listTargetWeb", listTargetWeb);
            privateObject.SetFieldOrProperty("listTargetListView", listTargetListView);
            privateObject.SetFieldOrProperty("tdListView", tdListView);
            privateObject.SetFieldOrProperty("tdQuery", tdQuery);
            privateObject.SetFieldOrProperty("rdFilterOption", rdFilterOption);
            privateObject.SetFieldOrProperty("SpanDocLibWarning", SpanDocLibWarning);
            privateObject.SetFieldOrProperty("SpanLengthWarning", SpanLengthWarning);
            privateObject.SetFieldOrProperty("listTargetColumn", listTargetColumn);
        }

        [TestCleanup]
        public void Clenaup()
        {
            shimsContext?.Dispose();
            cbxAllowMultiValue?.Dispose();
            cbxUnlimitedLengthInDocLib?.Dispose();
            cbxRecursiveFilter?.Dispose();
            txtQueryFilter?.Dispose();
            lblTargetList?.Dispose();
            lblTargetWeb?.Dispose();
            listTargetList?.Dispose();
            listTargetWeb?.Dispose();
            listTargetListView?.Dispose();
            tdListView?.Dispose();
            tdQuery?.Dispose();
            rdFilterOption?.Dispose();
            SpanDocLibWarning?.Dispose();
            SpanLengthWarning?.Dispose();
            listTargetColumn?.Dispose();
        }

        private void SetupShims()
        {
            ShimUserControl.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimControl.AllInstances.ViewStateGet = _ => ViewState;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimSPFieldLookup.AllInstances.LookupWebIdGet = _ => DummyGuid;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.LookupFieldGet = _ => DummyString;
            ShimSPControl.GetContextSiteHttpContext = _ => new ShimSPSite();
            ShimControl.AllInstances.ContextGet = _ => new ShimHttpContext();
            ShimListItemCollection.AllInstances.FindByValueString = (_, searchValue) => new ListItem();
        }

        [TestMethod]
        public void InitializeWithField_Should_ExecuteCorrectly()
        {
            // Arrange
            ShimUserControl.AllInstances.IsPostBackGet = _ => false;
            var field = new ShimFilteredLookupField
            {
                AllowMultipleValuesGet = () => true,
                QueryFilterAsStringGet = () => DummyString,
                IsFilterRecursiveGet = () => true,
                ListViewFilterGet = () => DummyString
            };
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetWeb = _ => { };
            ShimFilteredLookupFieldEditor.AllInstances.SetControlVisibility = _ => { };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);

            // Act
            filteredLookupFieldEditor.InitializeWithField(field);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => lblTargetWeb.Text.ShouldBe(DummyString),
                () => lblTargetList.Text.ShouldBe(DummyString),
                () => cbxAllowMultiValue.Checked.ShouldBeTrue(),
                () => cbxRecursiveFilter.Checked.ShouldBeTrue());
        }

        [TestMethod]
        public void SetControlVisibility_UrlWithoutExpectedPath_ExecutesCorrectly()
        {
            // Arrange
            ShimHttpRequest.AllInstances.UrlGet = _ => new Uri(DummyUrl);
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;

            // Act
            privateObject.Invoke(SetControlVisibilityMethodName);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => lblTargetList.Visible.ShouldBeTrue(),
                () => lblTargetWeb.Visible.ShouldBeTrue(),
                () => listTargetList.Visible.ShouldBeFalse(),
                () => listTargetWeb.Visible.ShouldBeFalse(),
                () => SpanDocLibWarning.Visible.ShouldBeFalse(),
                () => SpanLengthWarning.Visible.ShouldBeFalse(),
                () => cbxUnlimitedLengthInDocLib.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void SetControlVisibility_UrlWithExpectedPath_ExecutesCorrectly()
        {
            // Arrange
            var url = $"{DummyUrl}/fldNew.aspx";
            ShimHttpRequest.AllInstances.UrlGet = _ => new Uri(url);
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DocumentLibrary;

            // Act
            privateObject.Invoke(SetControlVisibilityMethodName);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => lblTargetList.Visible.ShouldBeFalse(),
                () => lblTargetWeb.Visible.ShouldBeFalse(),
                () => listTargetList.Visible.ShouldBeTrue(),
                () => listTargetWeb.Visible.ShouldBeTrue(),
                () => SpanDocLibWarning.Visible.ShouldBeTrue(),
                () => SpanLengthWarning.Visible.ShouldBeTrue(),
                () => cbxUnlimitedLengthInDocLib.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void OnSaveChange_FilterOptionQuery_ExecutesCorrectly()
        {
            // Arrange
            var queryFilterAsString = string.Empty;
            var lookupList = string.Empty;
            var lookupField = string.Empty;
            var listViewFilter = string.Empty;
            var isFilterRecursive = false;
            var countRelated = false;
            const string SelectedItem = "Query";
            var field = new ShimFilteredLookupField
            {
                QueryFilterAsStringSetString = value =>
                {
                    queryFilterAsString = value;
                },
                ListViewFilterSetString = value =>
                {
                    listViewFilter = value;
                },
                IsFilterRecursiveSetBoolean = value =>
                {
                    isFilterRecursive = value;
                }

            }.Instance;
            txtQueryFilter.Text = DummyString;
            cbxRecursiveFilter.Checked = true;
            ShimSPControl.GetContextSiteHttpContext = _ => new ShimSPSite
            {
                OpenWebGuid = guid => new ShimSPWeb()
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, SelectedItem);
            ShimSPFieldLookup.AllInstances.LookupListSetString = (_, value) =>
            {
                lookupList = value;
            };
            ShimSPFieldLookup.AllInstances.CountRelatedSetBoolean = (_, value) =>
            {
                countRelated = value;
            };
            ShimSPFieldLookup.AllInstances.LookupFieldSetString = (_, value) =>
            {
                lookupField = value;
            };

            // Act
            filteredLookupFieldEditor.OnSaveChange(field, false);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => queryFilterAsString.ShouldBe(DummyString),
                () => lookupField.ShouldBe(SelectedItem),
                () => lookupList.ShouldBeEmpty(),
                () => isFilterRecursive.ShouldBeTrue(),
                () => countRelated.ShouldBeFalse());
        }

        [TestMethod]
        public void OnSaveChange_FilterOptionListView_ExecutesCorrectly()
        {
            // Arrange
            var queryFilterAsString = string.Empty;
            var lookupList = string.Empty;
            var lookupField = string.Empty;
            var listViewFilter = string.Empty;
            var isFilterRecursive = false;
            var countRelated = false;
            const string SelectedItem = "ListView";
            var field = new ShimFilteredLookupField
            {
                QueryFilterAsStringSetString = value =>
                {
                    queryFilterAsString = value;

                },
                ListViewFilterSetString = value =>
                {
                    listViewFilter = value;
                },
                IsFilterRecursiveSetBoolean = value =>
                {
                    isFilterRecursive = value;
                }
            }.Instance;
            txtQueryFilter.Text = DummyString;
            cbxRecursiveFilter.Checked = true;
            ShimSPControl.GetContextSiteHttpContext = _ => new ShimSPSite
            {
                OpenWebGuid = guid => new ShimSPWeb()
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, SelectedItem);
            ShimListControl.AllInstances.SelectedIndexGet = _ => 0;
            ShimSPFieldLookup.AllInstances.LookupListSetString = (_, value) =>
            {
                lookupList = value;
            };
            ShimSPFieldLookup.AllInstances.CountRelatedSetBoolean = (_, value) =>
            {
                countRelated = value;
            };
            ShimSPFieldLookup.AllInstances.LookupFieldSetString = (_, value) =>
            {
                lookupField = value;
            };

            // Act
            filteredLookupFieldEditor.OnSaveChange(field, false);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => queryFilterAsString.ShouldBeEmpty(),
                () => lookupField.ShouldBe(SelectedItem),
                () => listViewFilter.ShouldBe(SelectedItem),
                () => lookupList.ShouldBeEmpty(),
                () => isFilterRecursive.ShouldBeTrue(),
                () => countRelated.ShouldBeFalse());
        }

        [TestMethod]
        public void OnSaveChange_IsNewField_ExecutesCorrectly()
        {
            // Arrange
            var lookupWebId = Guid.Empty;
            var lookupList = string.Empty;
            var lookupField = string.Empty;
            var isFilterRecursive = false;
            var countRelated = false;
            var selectedItem = DummyGuid.ToString();
            var field = new ShimFilteredLookupField
            {
                IsFilterRecursiveSetBoolean = value =>
                {
                    isFilterRecursive = value;
                }
            }.Instance;
            txtQueryFilter.Text = DummyString;
            cbxRecursiveFilter.Checked = true;
            ShimSPControl.GetContextSiteHttpContext = _ => new ShimSPSite
            {
                OpenWebGuid = guid => new ShimSPWeb
                {
                    IDGet = () => DummyGuid
                }
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, selectedItem);
            ShimListControl.AllInstances.SelectedIndexGet = _ => 0;
            ShimSPFieldLookup.AllInstances.LookupWebIdSetGuid = (_, value) =>
            {
                lookupWebId = value;
            };
            ShimSPFieldLookup.AllInstances.LookupListSetString = (_, value) =>
            {
                lookupList = value;
            };
            ShimSPFieldLookup.AllInstances.CountRelatedSetBoolean = (_, value) =>
            {
                countRelated = value;
            };
            ShimSPFieldLookup.AllInstances.LookupFieldSetString = (_, value) =>
            {
                lookupField = value;
            };

            // Act
            filteredLookupFieldEditor.OnSaveChange(field, true);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => lookupWebId.ShouldBe(DummyGuid),
                () => lookupField.ShouldBe(selectedItem),
                () => lookupList.ShouldBe(selectedItem),
                () => isFilterRecursive.ShouldBeTrue(),
                () => countRelated.ShouldBeFalse());
        }

        [TestMethod]
        public void DisplayAsNewSection_Get_ReturnsTrue()
        {
            // Arrange, Act
            var result = filteredLookupFieldEditor.DisplayAsNewSection;

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SetTargetColumn_TargetColumnIdEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 0;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = itemGuid => new ShimSPList
                    {
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField
                                {
                                    IdGet = () => DummyGuid,
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        }
                    }
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ViewState[TargetColumnId] = string.Empty;

            // Act
            privateObject.Invoke(SetTargetColumnMethodName, DummyGuid.ToString(), DummyGuid.ToString());

            // Assert
            index.ShouldBe(0);
        }

        [TestMethod]
        public void SetTargetColumn_TargetColumnIdNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 0;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = g => new ShimSPList
                    {
                        FieldsGet = () =>
                        {
                            var list = new List<SPField>
                            {
                                new ShimSPField
                                {
                                    IdGet = () => DummyGuid,
                                }
                            };
                            return new ShimSPFieldCollection().Bind(list);
                        }
                    }
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ViewState[TargetColumnId] = DummyString;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;

            // Act
            privateObject.Invoke(SetTargetColumnMethodName, DummyGuid.ToString(), DummyGuid.ToString());

            // Assert
            index.ShouldBe(IndexValue);
        }

        [TestMethod]
        public void CanFieldBeDisplayed_FieldTypeComputedAndEnabledLookup_ReturnsTrue()
        {
            // Arrange
            var field = new ShimSPFieldComputed()
            {
                EnableLookupGet = () => true
            }.Instance;

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Computed;
            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;

            // Act
            var result = (bool)privateObject.Invoke(CanFieldBeDisplayedMethodName, field);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CanFieldBeDisplayed_FieldTypeCalculatedAndOutputTypeText_ReturnsTrue()
        {
            // Arrange
            var field = new ShimSPFieldCalculated()
            {
                OutputTypeGet = () => SPFieldType.Text
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;
            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;

            // Act
            var result = (bool)privateObject.Invoke(CanFieldBeDisplayedMethodName, field);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CanFieldBeDisplayed_FieldTypeDefaultType_ReturnsTrue()
        {
            // Arrange
            var field = new ShimSPFieldCalculated()
            {
                OutputTypeGet = () => SPFieldType.Text
            }.Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.AllDayEvent;
            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;

            // Act
            var result = (bool)privateObject.Invoke(CanFieldBeDisplayedMethodName, field);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SetTargetListView_TargetListViewIdEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 1;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = itemGuid => new ShimSPList
                    {
                        ViewsGet = () =>
                        {
                            var list = new List<SPView>
                            {
                                new ShimSPView
                                {
                                    HiddenGet = () => false,
                                    PersonalViewGet = () => false
                                }
                            };
                            return new ShimSPViewCollection().Bind(list);
                        }
                    }
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ViewState[TargetListViewId] = string.Empty;

            // Act
            privateObject.Invoke(SetTargetListViewMethodName, DummyGuid.ToString(), DummyGuid.ToString());

            // Assert
            index.ShouldBe(0);
        }

        [TestMethod]
        public void SetTargetListView_TargetListViewIdNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 0;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = itemGuid => new ShimSPList
                    {
                        ViewsGet = () =>
                        {
                            var list = new List<SPView>
                            {
                                new ShimSPView
                                {
                                    HiddenGet = () => false,
                                    PersonalViewGet = () => false
                                }
                            };
                            return new ShimSPViewCollection().Bind(list);
                        }
                    }
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ViewState[TargetListViewId] = DummyString;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;

            // Act
            privateObject.Invoke(SetTargetListViewMethodName, DummyGuid.ToString(), DummyGuid.ToString());

            // Assert
            index.ShouldBe(IndexValue);
        }

        [TestMethod]
        public void SetTargetList_TargetListIdNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 0;
            var setTargetColumnWasCalled = false;
            var setTargetListViewWasCalled = false;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () =>
                {
                    var list = new List<SPList>
                    {
                        new ShimSPList
                        {
                            IDGet = () => DummyGuid,
                            HiddenGet = () => false,
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPListCollection().Bind(list);
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ViewState[TargetListId] = DummyString;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetColumnStringString =
                (_, webId, siteId) => setTargetColumnWasCalled = true;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString =
                (_, webId, siteId) => setTargetListViewWasCalled = true;

            // Act
            privateObject.Invoke(SetTargetListMethodName, DummyGuid.ToString(), true);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => index.ShouldBe(IndexValue),
                () => setTargetListViewWasCalled.ShouldBeTrue(),
                () => setTargetColumnWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void SetTargetList_TargetListIdEmpty_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 3;
            var index = 1;
            var setTargetColumnWasCalled = false;
            var setTargetListViewWasCalled = false;
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () =>
                {
                    var list = new List<SPList>
                    {
                        new ShimSPList
                        {
                            IDGet = () => DummyGuid,
                            HiddenGet = () => false,
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPListCollection().Bind(list);
                }
            };
            ShimFilteredLookupFieldEditor.AllInstances.CanFieldBeDisplayedSPField = (_, field) => true;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetColumnStringString =
                (_, webId, siteId) => setTargetColumnWasCalled = true;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString =
                (_, webId, siteId) => setTargetListViewWasCalled = true;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListStringBoolean = null;
            ViewState[TargetListId] = string.Empty;

            // Act
            privateObject.Invoke(SetTargetListMethodName, DummyGuid.ToString(), true);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => index.ShouldBe(0),
                () => setTargetListViewWasCalled.ShouldBeTrue(),
                () => setTargetColumnWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void OnInit_Should_ExecuteCorrectly()
        {
            // Arrange
            var page = new Page();
            var enableViewState = false;
            ShimControl.AllInstances.PageGet = _ => page;
            ShimControl.AllInstances.IsViewStateEnabledGet = _ => false;
            ShimControl.AllInstances.EnableViewStateSetBoolean = (_, valueSet) => enableViewState = valueSet;

            // Act
            privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => page.MaintainScrollPositionOnPostBack.ShouldBeTrue(),
                () => enableViewState.ShouldBeTrue());
        }

        [TestMethod]
        public void SelectedTargetListChanged_TargetWebItemsNotEmpty_ExecutesCorrectly()
        {
            // Arrange
            var sender = new object();
            var controlToFocus = new Control();
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection
            {
                CountGet = () => 1
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetColumnStringString = (_, webId, listId) => { };
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString = (_, webId, listId) => { };
            ShimControl.AllInstances.PageGet = _ => new ShimPage
            {
                SetFocusControl = control => controlToFocus = control
            };

            // Act
            privateObject.Invoke(SelectedTargetListChangedMethodName, sender, EventArgs.Empty);

            // Assert
            controlToFocus.ShouldSatisfyAllConditions(
                () => controlToFocus.ShouldNotBeNull(),
                () => controlToFocus.ShouldBe(listTargetColumn));
        }

        [TestMethod]
        public void SelectedTargetListChanged_TargetWebItemsEmpty_ExecutesCorrectly()
        {
            // Arrange
            var sender = new object();
            var controlToFocus = new Control();
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection
            {
                CountGet = () => 0
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);
            ViewState[TargetwebId] = DummyString;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetColumnStringString = (_, webId, listId) => { };
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString = (_, webId, listId) => { };
            ShimControl.AllInstances.PageGet = _ => new ShimPage
            {
                SetFocusControl = control => controlToFocus = control
            };

            // Act
            privateObject.Invoke(SelectedTargetListChangedMethodName, sender, EventArgs.Empty);

            // Assert
            controlToFocus.ShouldSatisfyAllConditions(
                () => controlToFocus.ShouldNotBeNull(),
                () => controlToFocus.ShouldBe(listTargetColumn));
        }

        [TestMethod]
        public void SelectedTargetWebChanged_Should_ExecuteCorrectly()
        {
            // Arrange
            var sender = new object();
            var controlToFocus = new Control();
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListStringBoolean = (_, webId, listId) => { };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);
            ShimDropDownList.AllInstances.SelectedIndexGet = _ => 1;
            ShimControl.AllInstances.PageGet = _ => new ShimPage
            {
                SetFocusControl = control => controlToFocus = control
            };

            // Act
            privateObject.Invoke(SelectedTargetWebChangedMethodName, sender, EventArgs.Empty);

            // Assert
            controlToFocus.ShouldSatisfyAllConditions(
                () => controlToFocus.ShouldNotBeNull(),
                () => controlToFocus.ShouldBe(listTargetList));
        }

        [TestMethod]
        public void SelectedFilterOptionChanged_FilterOptionSelectedItemEquals1_ExecutesCorrectly()
        {
            // Arrange
            var sender = new object();
            var setTargetListViewWasCalled = false;
            ShimListControl.AllInstances.SelectedIndexGet = _ => 1;
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString = (_, webId, listId) => 
            {
                setTargetListViewWasCalled = true;
            }; 

            // Act
            privateObject.Invoke(SelectedFilterOptionChangedMethodName, sender, EventArgs.Empty);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => setTargetListViewWasCalled.ShouldBeTrue(),
                () => tdListView.Visible.ShouldBeTrue(),
                () => listTargetListView.Visible.ShouldBeTrue(),
                () => cbxRecursiveFilter.Visible.ShouldBeFalse(),
                () => cbxRecursiveFilter.Checked.ShouldBeFalse());
        }

        [TestMethod]
        public void SelectedFilterOptionChanged_FilterOptionSelectedItemEquals0_ExecutesCorrectly()
        {
            // Arrange
            var sender = new object();
            var setTargetListViewWasCalled = false;
            ShimListControl.AllInstances.SelectedIndexGet = _ => 0;
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem(DummyString, DummyString);
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListViewStringString = (_, webId, listId) =>
            {
                setTargetListViewWasCalled = true;
            };

            // Act
            privateObject.Invoke(SelectedFilterOptionChangedMethodName, sender, EventArgs.Empty);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => setTargetListViewWasCalled.ShouldBeFalse(),
                () => tdQuery.Visible.ShouldBeTrue(),
                () => txtQueryFilter.Visible.ShouldBeTrue(),
                () => cbxRecursiveFilter.Visible.ShouldBeTrue(),
                () => cbxRecursiveFilter.Checked.ShouldBeFalse());
        }

        [TestMethod]
        public void SetTargetWeb_TargetWebItemNotNull_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 6;
            var setTargetListWasCalled = false;
            var index = 0;
            ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        TitleGet = () => DummyString,
                        IDGet = () => DummyGuid
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListStringBoolean =
                (_, webId, siteId) => setTargetListWasCalled = true;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, permissions) => true;
            ViewState[TargetwebId] = string.Empty;

            // Act
            privateObject.Invoke(SetTargetWebMethodName);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => setTargetListWasCalled.ShouldBeTrue(),
                () => index.ShouldBe(IndexValue));
        }

        [TestMethod]
        public void SetTargetWeb_TargetWebItemNull_ExecutesCorrectly()
        {
            // Arrange
            const int IndexValue = 6;
            var setTargetListWasCalled = false;
            var index = 1;
            ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        TitleGet = () => DummyString,
                        IDGet = () => DummyGuid
                    },
                    new ShimSPWeb
                    {
                        TitleGet = () => DummyString,
                        IDGet = () => DummyGuid
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimSPWeb.AllInstances.IDGet = _ => DummyGuid;
            ShimListItemCollection.AllInstances.IndexOfListItem = (_, searchValue) => IndexValue;
            ShimFilteredLookupFieldEditor.AllInstances.SetTargetListStringBoolean =
                (_, webId, siteId) => setTargetListWasCalled = true;
            ShimDropDownList.AllInstances.SelectedIndexSetInt32 = (_, value) => index = value;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, permissions) => true;
            ViewState[TargetwebId] = DummyString;
            ShimListItemCollection.AllInstances.FindByValueString = (_, searchValue) => null; 

            // Act
            privateObject.Invoke(SetTargetWebMethodName);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => setTargetListWasCalled.ShouldBeTrue(),
                () => index.ShouldBe(0));
        }

        [TestMethod]
        public void SetTargetWeb_OnException_ExecutesCorrectly()
        {
            // Arrange
            var exceptionMessage = string.Empty;
            var setTargetListWasCalled = false;
            ShimSPControl.GetContextWebHttpContext = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        TitleGet = () => DummyString,
                        IDGet = () => DummyGuid
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, permissions) =>
            {
                throw new Exception();
            };
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = (area, category, severity, message) =>
            {
                exceptionMessage = $"{area} = {category} - {severity} - {message}";
            };

            // Act
            privateObject.Invoke(SetTargetWebMethodName);

            // Assert
            filteredLookupFieldEditor.ShouldSatisfyAllConditions(
                () => setTargetListWasCalled.ShouldBeFalse(),
                () => exceptionMessage.ShouldContain(Area.EPMLiveCore),
                () => exceptionMessage.ShouldContain(Categories.EPMLiveCore.IntegrationCore),
                () => exceptionMessage.ShouldContain(TraceSeverity.Medium.ToString()));
        }
    }
}
