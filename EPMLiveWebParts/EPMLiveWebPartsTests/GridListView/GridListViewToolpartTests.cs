using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Properties;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.AssignmentPlanner
{
    [TestClass]
    public class GridListViewToolpartTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string ViewTitle = "View Title";
        private const string ListTitle = "List Title";
        private const string FieldTitle = "Field Title";
        private const string Title = "Title";
        private const string RollupList = "Rollup List";
        private const string ValueOn = "on";
        private const string ValueOff = "off";
        private const string GanttControl = "gantt";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodOnInit = "OnInit";
        private const string MethodCreateChildControls = "CreateChildControls";
        private GridListViewToolpart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _resultBuilder;
        private HtmlTextWriter _resultWriter;
        private StringWriter _stringWriter;
        private GridListView _gridListView;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new GridListViewToolpart
            {
                ID = One
            };
            _privateObject = new PrivateObject(_testObject);

            _gridListView = new GridListView
            {
                PropLockViewContext = true,
                PropRollupList = RollupList,
                PropExecView = ValueOn,
                PropExpand = One,
                PropPerformance = true,
                PropContentReporting = true,
                PropShowViewToolbar = true,
                PropHideNewButton = true,
                PropUsePopup = true,
                PropAllowEdit = true,
                PropEdit = true,
                PropShowInsertRow = true,
                PropUseParent = true,
                PropShowSearch = true,
                PropLockSearch = true,
            };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane()
            {
                SelectedWebPartGet = () => _gridListView
            };
            _privateObject.Invoke(MethodOnInit, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodCreateChildControls);

            _resultBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_resultBuilder);
            _resultWriter = new HtmlTextWriter(_stringWriter);

            PrepareSpContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _resultWriter?.Dispose();
            _stringWriter?.Dispose();
            _gridListView?.Dispose();
            _testObject?.Dispose();
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersLoading()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContain(Resources.txtGridToolpartJS.Replace("#tpid#", One)),
                () => result.ShouldContainWithoutWhitespace("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>"),
                () => result.ShouldContainWithoutWhitespace("<div id=\"divTpLoading\" style=\"width:100%;height:400;background:#FFFFFF;display:none\" align=\"center\"><br><br><br><br><br><br><br><img src=\"_layouts/images/gears_anv4.gif\"></div>"));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersListInformation()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<div id=\"divEverything\"><div class=\"UserSectionHead\">List Information<table cellpadding=1 style=\"padding-left: 5px\">"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkLock1\" id=\"chkLock1\" checked onclick=\"lockContext();\">Lock View Context</td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>List:<br><select name=\"ddlList1\" id=\"ddlList1\" disabled=\"disabled\" class=\"aspNetDisabled\" onchange=\"changeList();\"><option value=\"\">&lt; Select List &gt;</option><option selected=\"selected\" value=\"http://example.com\">List Title</option></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>View:<br><select id=\"ddlView1\" name=\"ddlView1\" disabled ><option value=\"\">&lt; Select View &gt;</option><option value=\"View Title\" selected>View Title</option></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Default Control:<br><select id=\"ddlDefaultControl1\" name=\"ddlDefaultControl1\"><option value=\"Grid\" selected=\"selected\">Grid</option><option value=\"Gantt\">Gantt</option></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkUseDefaults1\" id=\"chkUseDefaults1\" checked onclick=\"useDefaults();\">Use Settings from List</td></tr><tr><td></td></tr></table></div>"));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersFieldInformation()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<div style='width:100%' class='UserDottedLine'></div><div id=\"divNonDefaults\" style=\"display:none\"><div class=\"UserSectionHead\" id=\"fldSection1\">Field Information<table cellpadding=1 style=\"padding-left: 5px\">"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Start:<br><select id=\"ddlStart1\" name=\"ddlStart1\" onchange=\"propStart = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Finish:<br><select id=\"ddlFinish1\" name=\"ddlFinish1\" onchange=\"propFinish = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Progress Bar:<br><select id=\"ddlProgress1\" name=\"ddlProgress1\" onchange=\"propProgress = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Milestone:<br><select id=\"ddlMilestone1\" name=\"ddlMilestone1\" onchange=\"propMilestone = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Right Information:<br><select id=\"ddlInfo1\" name=\"ddlInfo1\" onchange=\"propInfo = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>WBS:<br><select id=\"ddlWBS1\" name=\"ddlWBS1\" onchange=\"propWBS = this.options[this.selectedIndex].value;\"></select></td></tr></table></div>"));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersRollupSettings()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<div style='width:100%' class='UserDottedLine'></div><div class=\"UserSectionHead\">Rollup Settings<br><table cellpadding=1 style=\"padding-left: 5px\">"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Rollup List(s):<br><textarea name=\"rollupList\" class=\"ms-input\" cols=\"25\" rows=\"5\">rollupList</textarea></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Rollup Site(s):<br><textarea name=\"rollupSites\" class=\"ms-input\" cols=\"25\" rows=\"5\">rollupSites</textarea></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkExecutive1\" checked> Executive View</td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkPerformance1\" checked> Enhance Perfomance</td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkContentReporting1\" checked> Use Content DB</td></tr></table></div>"));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersOtherInformation()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<div style='width:100%' class='UserDottedLine'></div><div class=\"UserSectionHead\">Other Information<table cellpadding=1 style=\"padding-left: 5px\">"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkShowViewToolbar1\" checked>Show View Toolbar</td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Item Link Type:<br><select id=\"ddlLinkType1\" name=\"ddlLinkType1\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkHideNew1\" checked>Hide New Button</td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td><input type=\"checkbox\" name=\"chkUsePopup1\" checked>Use Pop-up</td></tr></table></div>"));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersEditMode()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => result.ShouldContainWithoutWhitespace("<div style='width:100%' class='UserDottedLine'></div></div><div class=\"UserSectionHead\">Additional Groupings<table cellpadding=1 style=\"padding-left: 5px\">"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Select Field:<br><select id=\"ddlGroup11\" name=\"ddlGroup11\" onchange=\"propGroup1 = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Select Field:<br><select id=\"ddlGroup21\" name=\"ddlGroup21\" onchange=\"propGroup2 = this.options[this.selectedIndex].value;\"></select></td></tr>"),
                () => result.ShouldContainWithoutWhitespace("<tr><td>Expand To Level:<br><select id=\"ddlExpand1\" name=\"ddlExpand1\"><option value=\"\">< Use View Settings ></option><option value=\"1\">Level 1</option><option value=\"2\">Level 2</option><option value=\"3\">Level 3</option><option value=\"4\">Level 4</option></select></td></tr></table></div>"),
                () => result.ShouldContainWithoutWhitespace("<script>var contextList = \"http://example.com\";var contextView = \"View Title\";var contextFields = \"Field Title|Title|Text\";var propStart = \"ddlStart1\";var propFinish = \"ddlFinish1\";var propProgress = \"ddlProgress1\";var propInfo = \"ddlInformation1\";var propWBS = \"ddlWBS1\";var propMilestone = \"ddlMilestone1\";var propGroup1 = \"ddlGroup11\";var propGroup2 = \"ddlGroup21\";var propLinkType = \"ddlLinkType1\";var webUrl = \"\";var oFields = \"Field Title|Title|Text\";"));
        }

        [TestMethod]
        public void RenderToolPart_Gantt_RendersToolpartHtml()
        {
            // Arrange
            LoadGridListView(ValueOff);
            _gridListView.PropDefaultControl = GanttControl;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            result.ShouldContainWithoutWhitespace("<tr><td>Default Control:<br><select id=\"ddlDefaultControl1\" name=\"ddlDefaultControl1\"><option value=\"Grid\">Grid</option><option value=\"Gantt\" selected=\"selected\">Gantt</option></select></td></tr><tr><td>");
        }

        [TestMethod]
        public void ApplyChanges_PropertiesOn_SetsProperties()
        {
            // Arrange
            _testObject.Page = new Page();
            SetPageRequest(ValueOn);

            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertBoolGridListViewProperties(true),
                () => _gridListView.PropList.ShouldBe(ExampleUrl),
                () => _gridListView.PropView.ShouldBe(ViewTitle),
                () => AssertGridProperties(ValueOn));
        }

        [TestMethod]
        public void ApplyChanges_PropertiesOff_SetsProperties()
        {
            // Arrange
            _testObject.Page = new Page();
            SetPageRequest(ValueOff);

            // Act
            _testObject.ApplyChanges();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertBoolGridListViewProperties(false),
                () => _gridListView.PropList.ShouldBe($"ddlList{One}"),
                () => _gridListView.PropView.ShouldBe($"ddlView{One}"),
                () => AssertGridProperties(ValueOff));
        }

        private void LoadGridListView(string checkValues)
        {
            _testObject.Page = new Page();
            SetPageRequest(checkValues);
            _testObject.ApplyChanges();
        }

        private void AssertBoolGridListViewProperties(bool isTrue)
        {
            _gridListView.ShouldSatisfyAllConditions(
                () => AssertBoolProperty(_gridListView.PropShowViewToolbar, isTrue),
                () => AssertBoolProperty(_gridListView.PropUsePopup, isTrue),
                () => AssertBoolProperty(_gridListView.PropUseParent, isTrue),
                () => AssertBoolProperty(_gridListView.PropShowSearch, isTrue),
                () => AssertBoolProperty(_gridListView.PropLockSearch, isTrue),
                () => AssertBoolProperty(_gridListView.PropLockViewContext, isTrue),
                () => AssertBoolProperty(_gridListView.PropUseDefaults, isTrue),
                () => AssertBoolProperty(_gridListView.PropHideNewButton, isTrue),
                () => AssertBoolProperty(_gridListView.PropAllowEdit, isTrue),
                () => AssertBoolProperty(_gridListView.PropEdit, isTrue),
                () => AssertBoolProperty(_gridListView.PropShowInsertRow, isTrue),
                () => AssertBoolProperty(_gridListView.PropPerformance, isTrue),
                () => AssertBoolProperty(_gridListView.PropContentReporting, isTrue));
        }

        private void AssertBoolProperty(bool? currentValue, bool expectedValue)
        {
            currentValue.ShouldNotBeNull();
            currentValue.ShouldBe(expectedValue);
        }

        private void AssertGridProperties(string execViewValue)
        {
            _gridListView.ShouldSatisfyAllConditions(
                () => _gridListView.PropExecView.ShouldBe(execViewValue),
                () => _gridListView.PropRollupList.ShouldBe("rollupList"),
                () => _gridListView.PropRollupSites.ShouldBe("rollupSites"),
                () => _gridListView.PropFinish.ShouldBe($"ddlFinish{One}"),
                () => _gridListView.PropInformation.ShouldBe($"ddlInformation{One}"),
                () => _gridListView.PropMilestone.ShouldBe($"ddlMilestone{One}"),
                () => _gridListView.PropProgress.ShouldBe($"ddlProgress{One}"),
                () => _gridListView.PropStart.ShouldBe($"ddlStart{One}"),
                () => _gridListView.PropWBS.ShouldBe($"ddlWBS{One}"),
                () => _gridListView.PropLinkType.ShouldBe($"ddlLinkType{One}"),
                () => _gridListView.PropGroup1.ShouldBe($"ddlGroup1{One}"),
                () => _gridListView.PropGroup2.ShouldBe($"ddlGroup2{One}"),
                () => _gridListView.PropExpand.ShouldBe($"ddlExpand{One}"),
                () => _gridListView.PropDefaultControl.ShouldBe($"ddlDefaultControl{One}"));
        }

        private void SetPageRequest(string checkItems)
        {
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.ItemGetString = (_, key) =>
                (key.Contains("chk"))
                ? checkItems
                : key;
        }

        private void PrepareSpContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();

            var listCollection = new ShimSPListCollection();
            ShimSPWeb.AllInstances.ListsGet = _ => listCollection.Bind(new SPList[] { new ShimSPList() });
            ShimSPWeb.AllInstances.GetListFromUrlString = (_, __) => new ShimSPList();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();

            ShimSPList.AllInstances.TitleGet = _ => ListTitle;
            ShimSPList.AllInstances.HiddenGet = _ => false;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            var viewCollection = new ShimSPViewCollection();
            ShimSPList.AllInstances.ViewsGet = _ => viewCollection.Bind(new SPView[] { new ShimSPView() });
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });

            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.UrlGet = _ => ExampleUrl;

            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPView.AllInstances.TitleGet = _ => ViewTitle;
            ShimSPView.AllInstances.HiddenGet = _ => false;
            ShimSPView.AllInstances.PersonalViewGet = _ => false;

            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimSPField.AllInstances.TitleGet = _ => FieldTitle;
            ShimSPField.AllInstances.InternalNameGet = _ => Title;

            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
        }
    }
}
