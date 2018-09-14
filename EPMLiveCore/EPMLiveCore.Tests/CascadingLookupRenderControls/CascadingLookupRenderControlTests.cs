using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.CascadingLookupRenderControls
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CascadingLookupRenderControlTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string HtmlSpanOpen = "<span style=\"vertical-align:middle\">";
        private const string HtmlSpanClose = "</span>";
        private const string HtmlNewLine = "<br/>";
        private const string Image = "/_layouts/images/dropdown.gif";
        private const string LookupThrottleMessage = "LookupThrottleMessage";
        private const string RequiredLookupThrottleMessage = "RequiredLookupThrottleMessage";
        private const string ParamElement = "Param";
        private const string DataElement = "Data";
        private const string KeyAttribute = "key";
        private const string FieldWebForeign = "m_webForeign";
        private const string FieldDropList = "_dropList";
        private const string FieldSelectedValueIndex = "m_selectedValueIndex";
        private const string FieldTextBox = "_textBox";
        private const string FieldDataSource = "_dataSource";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodOnInit = "OnInit";
        private const string MethodSetFieldControlValue = "SetFieldControlValue";
        private const string PropertyDataSource = "DataSource";
        private const string PropertyHiddenFieldName = "HiddenFieldName";
        private const string PageScript1 = "<script> if (!_LookupFieldsPropsArray) { var _LookupFieldsPropsArray = new Array(); } </script>";
        private readonly Guid DummyGuid = Guid.NewGuid();
        private CascadingLookupRenderControl _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private ShimSPWeb _shimWeb;
        private ShimSPListCollection _shimListCollection;
        private ShimSPList _shimList;
        private ShimSPFieldCollection _shimFields;
        private ShimSPFieldLookup _shimFieldLookup;
        private bool _scriptRegistered;
        private bool _webClosed;
        private bool _baseOnInitCalled;
        private Page _page;
        private StringWriter _responseWriter;
        private SPFieldLookupValue _item;
        private DropDownList _dropDownList;
        private TextBox _textBox;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            _scriptRegistered = false;
            _webClosed = false;
            _baseOnInitCalled = false;

            _page = new Page();
            ShimScriptLink.RegisterPageStringBoolean = (a, b, c) => { _scriptRegistered = true; };
            ShimSPResource.GetStringStringObjectArray = (key, _) => key;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated =
                code => code.Invoke();

            _testObject = new CascadingLookupRenderControl();
            ShimSharePointContext();
            
            _testObject.Page = _page;
            _testObject.TabIndex = 0;
            _testObject.CustomProperty = GetDocument().ToString();
            _testObject.LookupData = new LookupConfigData()
            {
                Type = DummyString,
                Field = DummyString,
                Parent = DummyString,
                ParentListField = DummyString
            };

            _privateObject = new PrivateObject(_testObject);
            _privateObject.SetFieldOrProperty(FieldWebForeign, _shimWeb.Instance);
            _privateObject.Invoke(MethodOnInit, new object[] { EventArgs.Empty });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
            _dropDownList?.Dispose();
            _textBox?.Dispose();
            _page?.Dispose();
            _testObject?.Dispose();
        }

        [TestMethod]
        public void OnPreRender_Invoke_RegisterScripts()
        {
            // Arrange
            var prerendered = false;
            var registeredScripts = new List<string>();
            ShimLookupField.AllInstances.OnPreRenderEventArgs = (_, __) => prerendered = true;
            ShimClientScriptManager.AllInstances.RegisterClientScriptBlockTypeStringStringBoolean =
                (a, b, c, script, d) => { registeredScripts.Add(script); };

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _baseOnInitCalled.ShouldBeTrue(),
                () => _scriptRegistered.ShouldBeTrue(),
                () => prerendered.ShouldBeTrue(),
                () => registeredScripts[0].ShouldBe(PageScript1),
                () => AssertScript(registeredScripts[1]));
        }

        [TestMethod]
        public void CreateChildControls_CachedFieldValue_DoesNotAddControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(0));
        }

        [TestMethod]
        public void CreateChildControls_DisplayMode_DoesNotAddControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.Display;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(0));
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void CreateChildControls_NotLookupField_ThrowsException()
        {
            // Arrange
            ShimLookupField.AllInstances.CreateChildControls = _ => { };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            ShimFieldMetadata.AllInstances.FieldGet = _ => new ShimSPField();

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert Expected Exception
        }

        [TestMethod]
        public void CreateChildControls_FieldDoesAllowMultipleValues_DoesNotAddControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            _shimFieldLookup.AllowMultipleValuesGet = () => true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(0));
        }

        [TestMethod]
        public void CreateChildControls_LookupThrottle_AddsSpanControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            _shimFieldLookup.AllowMultipleValuesGet = () => false;
            _shimList.IsThrottledGet = () => true;
            ShimSPField.AllInstances.RequiredGet = _ => false;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(3),
                () => _testObject.Controls.OfType<Literal>().Count().ShouldBe(3),
                () => ((Literal)_testObject.Controls[0]).Text.ShouldBe(HtmlSpanOpen),
                () => ((Literal)_testObject.Controls[1]).Text.ShouldBe(LookupThrottleMessage),
                () => ((Literal)_testObject.Controls[2]).Text.ShouldBe(HtmlSpanClose));
        }

        [TestMethod]
        public void CreateChildControls_RequiredLookupThrottle_AddsSpanControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            _shimFieldLookup.AllowMultipleValuesGet = () => false;
            _shimList.IsThrottledGet = () => true;
            ShimSPField.AllInstances.RequiredGet = _ => true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(3),
                () => _testObject.Controls.OfType<Literal>().Count().ShouldBe(3),
                () => ((Literal)_testObject.Controls[0]).Text.ShouldBe(HtmlSpanOpen),
                () => ((Literal)_testObject.Controls[1]).Text.ShouldBe(RequiredLookupThrottleMessage),
                () => ((Literal)_testObject.Controls[2]).Text.ShouldBe(HtmlSpanClose));
        }

        [TestMethod]
        public void CreateChildControls_CreateNonThrottled_FillsDropDown()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            _shimFieldLookup.AllowMultipleValuesGet = () => false;
            _shimList.IsThrottledGet = () => false;
            ShimSPField.AllInstances.RequiredGet = _ => false;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            DataView source = null;
            if (_testObject.Controls.Count > 0)
            {
                source = GetDropDownListDataSource(_testObject.Controls[0]);
            }
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _webClosed.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(2),
                () => source.ShouldNotBeNull(),
                () => source.Table.Rows.Count.ShouldBe(2),
                () => _testObject.Controls[1].ShouldBeOfType<LiteralControl>(),
                () => ((LiteralControl)_testObject.Controls[1]).Text.ShouldBe(HtmlNewLine));
        }

        [TestMethod]
        public void CreateChildControls_MoreThan20Rows_AddsTextBoxAndImageControls()
        {
            // Arrange
            var childCreated = false;
            ShimLookupField.AllInstances.CreateChildControls = _ => { childCreated = true; };
            ShimBaseFieldControl.AllInstances.IsFieldValueCachedGet = _ => false;
            _testObject.ControlMode = SPControlMode.New;
            _shimFieldLookup.AllowMultipleValuesGet = () => false;
            _shimList.IsThrottledGet = () => false;
            ShimSPField.AllInstances.RequiredGet = _ => false;
            Shim30ListItems();

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childCreated.ShouldBeTrue(),
                () => _webClosed.ShouldBeTrue(),
                () => _testObject.Controls.Count.ShouldBe(5),
                () => _testObject.Controls[0].ShouldBeOfType<Literal>(),
                () => ((Literal)_testObject.Controls[0]).Text.ShouldBe(HtmlSpanOpen),
                () => _testObject.Controls[1].ShouldBeOfType<TextBox>(),
                () => ((TextBox)_testObject.Controls[1]).Text.ShouldBeNullOrEmpty(),
                () => _testObject.Controls[2].ShouldBeOfType<Image>(),
                () => ((Image)_testObject.Controls[2]).ImageUrl.ShouldBe(Image),
                () => _testObject.Controls[3].ShouldBeOfType<Literal>(),
                () => ((Literal)_testObject.Controls[3]).Text.ShouldBe(HtmlSpanClose),
                () => _testObject.Controls[4].ShouldBeOfType<LiteralControl>(),
                () => ((LiteralControl)_testObject.Controls[4]).Text.ShouldBe(HtmlNewLine));
        }

        [TestMethod]
        public void SetFieldControlValue_DropDownListNothingSelected_SetsNotSelectedIndex()
        {
            // Arrange
            _dropDownList = new DropDownList();
            _privateObject.SetFieldOrProperty(FieldDropList, _dropDownList);
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, -1);

            // Act
            _privateObject.Invoke(MethodSetFieldControlValue, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _dropDownList.SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetFieldControlValue_DropDownListSelected_SetsNotSelectedIndex()
        {
            // Arrange
            _dropDownList = new DropDownList();
            _privateObject.SetFieldOrProperty(FieldDropList, _dropDownList);
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, 0);

            // Act
            _privateObject.Invoke(MethodSetFieldControlValue, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _dropDownList.SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetFieldControlValue_TextBox_SetsText()
        {
            // Arrange
            _textBox = new TextBox();
            var registeredField = string.Empty;
            _privateObject.SetFieldOrProperty(FieldTextBox, _textBox);
            _privateObject.SetFieldOrProperty(FieldDataSource, _privateObject.GetFieldOrProperty(PropertyDataSource));
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, 0);
            ShimClientScriptManager.AllInstances.RegisterHiddenFieldStringString =
                (_, __, field) => { registeredField = field; };

            // Act
            _privateObject.Invoke(MethodSetFieldControlValue, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _textBox.Text.ShouldBeNullOrEmpty(),
                () => registeredField.ShouldBe("0"));
        }

        [TestMethod]
        public void SetFieldControlValue_TextBoxNotSelectedValue_SetsText()
        {
            // Arrange
            _textBox = new TextBox();
            var registeredField = string.Empty;
            var hiddenFieldName = _privateObject.GetFieldOrProperty(PropertyHiddenFieldName) as string;
            _privateObject.SetFieldOrProperty(FieldTextBox, _textBox);
            _privateObject.SetFieldOrProperty(FieldDataSource, _privateObject.GetFieldOrProperty(PropertyDataSource));
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, -1);
            _responseWriter = new StringWriter();
            ShimPage.AllInstances.IsPostBackGet = _ => true;
            ShimControl.AllInstances.ContextGet = _ => new HttpContext(
                new HttpRequest(string.Empty, ExampleUrl, string.Empty),
                new HttpResponse(_responseWriter));
            ShimHttpRequest.AllInstances.FormGet = _ => new NameValueCollection { { hiddenFieldName, null } };
            ShimClientScriptManager.AllInstances.RegisterHiddenFieldStringString =
                (_, __, field) => { registeredField = field; };

            // Act
            _privateObject.Invoke(MethodSetFieldControlValue, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _textBox.Text.ShouldBeNullOrEmpty(),
                () => registeredField.ShouldBe("0"));
        }

        [TestMethod]
        public void UpdateFieldValueInItem_Invoke_SetsItem()
        {
            // Arrange
            _dropDownList = new DropDownList();
            _dropDownList.DataSource = _privateObject.GetFieldOrProperty(PropertyDataSource);
            _dropDownList.DataValueField = "ValueField";
            _dropDownList.DataTextField = "TextField";
            _dropDownList.DataBind();
            _dropDownList.SelectedIndex = 0;
            _privateObject.SetFieldOrProperty(FieldDropList, _dropDownList);
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, 0);

            // Act
            _testObject.UpdateFieldValueInItem();

            // Assert
            _item.ShouldNotBeNull();
        }

        [TestMethod]
        public void UpdateFieldValueInItem_NoDataSource_DoesNotSetsItem()
        {
            // Arrange
            _dropDownList = new DropDownList();
            _privateObject.SetFieldOrProperty(FieldDropList, _dropDownList);
            _privateObject.SetFieldOrProperty(FieldSelectedValueIndex, 0);

            // Act
            _testObject.UpdateFieldValueInItem();

            // Assert
            _item.ShouldBeNull();
        }

        [TestMethod]
        public void Dispose_Invoke_DisposesAllObjects()
        {
            // Arrange
            var disposedControls = false;
            ShimControl.AllInstances.Dispose = control =>
            {
                disposedControls = true;
                ShimsContext.ExecuteWithoutShims(() => control.Dispose());
            };

            // Act
            _testObject.Dispose();

            // Assert
            disposedControls.ShouldBeTrue();
        }

        private void ShimSharePointContext()
        {
            ShimSPFieldCollectionMethods();
            ShimSPListMethods();
            ShimSPListCollectionMethods();
            ShimSPWebMethods();
            var site = ShimSPSiteMethods();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _shimWeb.Instance,
                SiteGet = () => site.Instance
            }.Instance;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _shimWeb;
            ShimTemplateBasedControl.AllInstances.WebGet = _ => _shimWeb;
        }

        private ShimSPSite ShimSPSiteMethods()
        {
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                RootWebGet = () => _shimWeb.Instance,
                WebApplicationGet = () => new ShimSPWebApplication
                {
                    ApplicationPoolGet = () => new SPApplicationPool(),

                    CurrentUserIgnoreThrottle = () => false,
                    MaxItemsPerThrottledOperationGet = () => 5
                }.Instance
            };
            _shimWeb.SiteGet = () => site.Instance;
            return site;
        }

        private void ShimSPFieldCollectionMethods()
        {
            _shimFields = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = _ => new ShimSPField()
                {
                    TitleGet = () => DummyString,
                    InternalNameGet = () => DummyString
                }.Instance
            };

            _shimFieldLookup = new ShimSPFieldLookup
            {
                LookupFieldGet = () => DummyGuid.ToString(),
                LookupWebIdGet = () => DummyGuid,
                LookupListGet = () => DummyGuid.ToString()
            };
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimFieldMetadata.AllInstances.FieldGet = _ => _shimFieldLookup.Instance;
            ShimLookupField.AllInstances.OnInitEventArgs = (_, __) => { _baseOnInitCalled = true; };
            ShimFormComponent.AllInstances.ListItemGet = _ => GetListItem();
            ShimSPFieldLookupValue.ConstructorString = (_, key) =>
            {
                ShimSPFieldLookupValue.AllInstances.ToString01 = __ => key;
            };
            _testObject.LookupField = _shimFieldLookup;
        }

        private void ShimSPWebMethods()
        {
            var user = new ShimSPUser
            {
                IDGet = () => Id
            };

            _shimWeb = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                CurrentUserGet = () => user,
                EnsureUserString = _ => user,
                SiteUserInfoListGet = () => _shimList.Instance,
                ListsGet = () => _shimListCollection.Instance,
                Close = () => { _webClosed = true; },
                UrlGet = () => ExampleUrl
            };
        }

        private void ShimSPListCollectionMethods()
        {
            _shimListCollection = new ShimSPListCollection
            {
                ItemGetString = _ => _shimList,
                ItemGetGuid = _ => _shimList,
                GetListGuidBoolean = (_, __) => _shimList,
                TryGetListString = list => _shimList.Instance
            };
        }

        private void ShimSPListMethods()
        {
            _shimList = new ShimSPList
            {
                IDGet = () => DummyGuid,
                ItemsGet = () => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem> { GetListItem() }.GetEnumerator(),
                    GetDataTable = () => new DataTable()
                },
                FieldsGet = () => _shimFields.Instance,
                ParentWebGet = () => _shimWeb,

                IsThrottledGet = () => true
            };
        }

        private ShimSPListItem GetListItem()
        {
            return new ShimSPListItem()
            {
                IDGet = () => Id,
                ItemGetGuid = _ => DummyString,
                ItemGetString = _ => DummyString,
                ItemSetStringObject = (_, val) => { _item = val as SPFieldLookupValue; }
            };
        }

        private void Shim30ListItems()
        {
            var items = new List<SPListItem>();
            for (int i = 0; i < 30; i++)
            {
                items.Add(GetListItem());
            }
            _shimList.ItemsGet = () => new ShimSPListItemCollection
            {
                GetEnumerator = () => items.GetEnumerator(),
                GetDataTable = () => new DataTable()
            };
        }

        private DataView GetDropDownListDataSource(Control control)
        {
            var list = control as DropDownList;
            return list?.DataSource as DataView;
        }

        private XDocument GetDocument()
        {
            var doc = new XDocument(
                new XElement(DataElement,
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "ParentWebID"), DummyGuid.ToString()),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "LookupWebID"), DummyGuid.ToString()),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "LookupListID"), DummyGuid.ToString()),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "LookupFieldInternalName"), DummyString),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "LookupFieldID"), DummyGuid.ToString()),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "ListID"), DummyGuid.ToString()),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "ItemID"), One),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "ControlType"), DummyString),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "Parent"), DummyString),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "ParentListField"), DummyString),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "SourceControlID"), DummyString),
                    new XElement(ParamElement, new XAttribute(KeyAttribute, "SourceDropDownID"), DummyString)));
            return doc;
        }

        private void AssertScript(string script)
        {
            this.ShouldSatisfyAllConditions(
                () => script.ShouldContain("if (_LookupFieldsPropsArray) {"),
                () => script.ShouldContain("var lookupFieldProp_DummyString ="),
                () => script.ShouldContain("FieldName : 'DummyString'"),
                () => script.ShouldContain("ControlType: 'DummyString'"),
                () => script.ShouldContain("FieldInfo:"),
                () => script.ShouldContain($"LookupWebId: '{DummyGuid}'"),
                () => script.ShouldContain($"LookupListId: '{DummyGuid}'"),
                () => script.ShouldContain($"LookupField: '{DummyGuid}'"),
                () => script.ShouldContain("ControlInfo:"),
                () => script.ShouldContain("DropDownClientId: ''"),
                () => script.ShouldContain("TextBoxClientId: ''"),
                () => script.ShouldContain("DropImageClientId: ''"),
                () => script.ShouldContain($"CurWebURL: '{ExampleUrl}'"),
                () => script.ShouldContain("IsMultiSelect: false"),
                () => script.ShouldContain("SourceControlId: 'DummyString'"),
                () => script.ShouldContain("SearchText: ''"),
                () => script.ShouldContain("SingleSelectLookupVal: ''"),
                () => script.ShouldContain("SingleSelectDisplayVal: ''"),
                () => script.ShouldContain("Parent: 'DummyString'"),
                () => script.ShouldContain("ParentListField: 'DummyString'"),
                () => script.ShouldContain("CachedValue: ''"),
                () => script.ShouldContain("var arrLength = _LookupFieldsPropsArray.length;"),
                () => script.ShouldContain("_LookupFieldsPropsArray[arrLength] = lookupFieldProp_DummyString};"));
        }
    }
}
