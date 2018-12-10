using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Reporting = EPMLiveWebParts.ReportingFilter;

namespace EPMLiveWebParts.Tests.ReportingFilter
{
    [TestClass]
    public class ReportingFilterToolpartTests
    {
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string Title = "Title";
        private const string ListTitle = "List Title";
        private const string FieldTitle = "Field Title";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodCreateChildControls = "CreateChildControls";
        private static readonly Guid DefaultWebId = Guid.NewGuid();
        private static readonly Guid DefaultListId = Guid.NewGuid();
        private static readonly DateTime DefaultDate = new DateTime(2019, 1, 1);
        private ReportingFilterToolpart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _resultBuilder;
        private HtmlTextWriter _resultWriter;
        private StringWriter _stringWriter;
        private Reporting _reportingFilter;
        private bool _didRebuildControl;
        private bool _didRegisterClientScript;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new ReportingFilterToolpart
            {
                Page = new Page(),
                ID = One
            };
            _privateObject = new PrivateObject(_testObject);

            _didRebuildControl = false;
            _didRegisterClientScript = false;
            PrepareSpContext();
            ShimCoreFunctions.getSiteItemsSPWebSPViewStringStringStringStringIListOfString =
                (a, b, c, d, e, f, g) => GetSiteItemsDataTable();

            _reportingFilter = new Reporting
            {
                DefaultValueForFieldFilter = DummyString,
                ListToFilterOn = ListTitle,
                FieldToFilterOn = FieldTitle
            };
            ShimPage.AllInstances.ClientScriptGet = _ => new ShimClientScriptManager
            {
                IsClientScriptBlockRegisteredTypeString = (a, b) => false,
                RegisterClientScriptBlockTypeStringString = (a, b, c) => _didRegisterClientScript = true
            };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane()
            {
                SelectedWebPartGet = () => _reportingFilter
            };
            ShimReportingFilter.AllInstances.RebuildControlTree = _ => _didRebuildControl = true;

            _privateObject.Invoke(MethodCreateChildControls);

            _resultBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_resultBuilder);
            _resultWriter = new HtmlTextWriter(_stringWriter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void OnPreRender_Choice_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFieldChoice().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPField.AllInstances.ReorderableGet = _ => false;

            _reportingFilter.DefaultValueForFieldFilter = $"{Title},{DummyString}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<select name=\"1$ctl13\">"),
                () => result.ShouldContainWithoutWhitespace("<option value=\"&lt;SELECT LIST>\">&lt;SELECT LIST&gt;</option>"),
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{ListTitle}\">{ListTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/>Field: <select name=\"1$ctl14\">"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><input id=\"1_ctl15\" type=\"checkbox\" name=\"1$ctl15\" /><label for=\"1_ctl15\">Allow multiple \"Field\" values to be selected.</label><br/><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/><input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" />"),
                () => result.ShouldContainWithoutWhitespace("<label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/><select size=\"1\" name=\"1$ctl19\">"),
                () => result.ShouldContainWithoutWhitespace($"<option value=\"{DummyString}\">{DummyString}</option>"));
        }

        [TestMethod]
        public void OnPreRender_Lookup_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFieldLookup().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;

            _reportingFilter.DefaultValueForFieldFilter = $"{Title},{DummyString}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{FieldTitle}\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/>Field: <select name=\"1$ctl14\">"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><input id=\"1_ctl15\" type=\"checkbox\" name=\"1$ctl15\" /><label for=\"1_ctl15\">Allow multiple \"Field\" values to be selected.</label><br/><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/><input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" />"),
                () => result.ShouldContainWithoutWhitespace("<label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/><select size=\"1\" name=\"1$ctl19\">"),
                () => result.ShouldContainWithoutWhitespace($"<option value=\"{DummyString}\">{DummyString}</option>"));
        }

        [TestMethod]
        public void OnPreRender_LookupRollup_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFieldLookup().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimGridGanttSettings.ConstructorSPList = (instance, _) => instance.RollupLists = DummyString;

            _reportingFilter.DefaultValueForFieldFilter = $"{Title},{DummyString}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{FieldTitle}\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/>Field: <select name=\"1$ctl14\">"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><input id=\"1_ctl15\" type=\"checkbox\" name=\"1$ctl15\" /><label for=\"1_ctl15\">Allow multiple \"Field\" values to be selected.</label><br/><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/><input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" />"),
                () => result.ShouldContainWithoutWhitespace("<label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/><select size=\"1\" name=\"1$ctl19\">"),
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{Title}\">{Title}</option>"));
        }

        [TestMethod]
        public void OnPreRender_Text_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;

            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"Field Title\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><br/><br/><input id=\"1_ctl16\" type=\"checkbox\""),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" /><label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/>"),
                () => result.ShouldContainWithoutWhitespace($"<input name=\"1$ctl20\" type=\"text\" value=\"{DummyString}\" />"));
        }

        [TestMethod]
        public void OnPreRender_Integer_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Integer;

            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{FieldTitle}\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><br/><input id=\"1_ctl18\" type=\"checkbox\" name=\"1$ctl18\" /><label for=\"1_ctl18\">Is Percentage Value</label><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/><input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" />"),
                () => result.ShouldContainWithoutWhitespace($"<label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/><input name=\"1$ctl20\" type=\"text\" value=\"{DummyString}\" />"));
        }

        [TestMethod]
        public void OnPreRender_DateTime_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            _reportingFilter.DefaultValueForFieldFilter = $"{DefaultDate.ToShortDateString()},{DefaultDate.ToShortDateString()}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{FieldTitle}\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><br/><br/><input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" /><label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/><span>Begin</span><br/>"),
                () => result.ShouldContainWithoutWhitespace($"<input name=\"1$ctl23\" type=\"text\" value=\"{DefaultDate.ToShortDateString()}\" id=\"1_ctl23\" /><br/><span>End</span><br/><input name=\"1$ctl25\" type=\"text\" value=\"{DefaultDate.ToShortDateString()}\" id=\"1_ctl25\" />"));
        }

        [TestMethod]
        public void OnPreRender_User_WritesResult()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;

            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNullOrEmpty();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{ListTitle}\">{ListTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace($"<option selected=\"selected\" value=\"{FieldTitle}\">{FieldTitle}</option>"),
                () => result.ShouldContainWithoutWhitespace("</select><br/><input id=\"1_ctl15\" type=\"checkbox\" name=\"1$ctl15\" /><label for=\"1_ctl15\">Allow multiple \"Field\" values to be selected.</label><br/><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl16\" type=\"checkbox\" name=\"1$ctl16\" /><label for=\"1_ctl16\">Show Titles Drop down</label><br/>"),
                () => result.ShouldContainWithoutWhitespace("<input id=\"1_ctl17\" type=\"checkbox\" name=\"1$ctl17\" /><label for=\"1_ctl17\">Allow multiple \"Title\" values to be selected.</label><br/><br/>Default Value:<br/>"),
                () => result.ShouldContainWithoutWhitespace("<span class=\"ms-descriptiontext\">The control is not available because you do not have the correct permissions.</span>"));
        }

        [TestMethod]
        public void ApplyChanges_Lookup_SetsDefaultValue()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPFieldLookup().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimGridGanttSettings.ConstructorSPList = (instance, _) => instance.RollupLists = DummyString;

            _reportingFilter.DefaultValueForFieldFilter = $"{Title},{DummyString}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didRebuildControl.ShouldBeTrue(),
                () => _reportingFilter.DefaultValueForFieldFilter.ShouldBe(Title));
        }

        [TestMethod]
        public void ApplyChanges_Text_SetsDefaultValue()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;

            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didRebuildControl.ShouldBeTrue(),
                () => _reportingFilter.DefaultValueForFieldFilter.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_User_SetsDefaultValue()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;

            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });
            
            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didRebuildControl.ShouldBeTrue(),
                () => _reportingFilter.DefaultValueForFieldFilter.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void ApplyChanges_DateTime_SetsDefaultValue()
        {
            // Arrange
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField().Instance;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            _reportingFilter.DefaultValueForFieldFilter = $"{DefaultDate.ToShortDateString()},{DefaultDate.ToShortDateString()}";
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didRebuildControl.ShouldBeTrue(),
                () => _reportingFilter.DefaultValueForFieldFilter.ShouldBe($"{DefaultDate.ToShortDateString()},{DefaultDate.ToShortDateString()}"));
        }

        private void PrepareSpContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPWebCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPWeb();
            var listCollection = new ShimSPListCollection();
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Bind(new SPList[] { new ShimSPList() });
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();

            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection();
            
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
            ShimSPList.AllInstances.IDGet = _ => DefaultListId;
            ShimSPList.AllInstances.TitleGet = _ => ListTitle;
            var listItemCollection = new ShimSPListItemCollection();
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => listItemCollection.Bind(new SPListItem[] { new ShimSPListItem() });
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });
            ShimSPListItem.AllInstances.TitleGet = _ => DummyString;

            ShimSPFieldCollection.AllInstances.ItemGetString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimSPField.AllInstances.TitleGet = _ => FieldTitle;
            ShimSPField.AllInstances.InternalNameGet = _ => Title;
            ShimSPField.AllInstances.ReorderableGet = _ => true;

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection { DummyString };
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => DefaultListId.ToString();
            ShimSPFieldLookup.AllInstances.LookupWebIdGet = _ => DefaultWebId;
        }

        private DataTable GetSiteItemsDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Title);
            dataTable.Rows.Add(new object[] { Title });

            return dataTable;
        }
    }
}
