using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
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
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string ValueOn = "on";
        private const string ValueOff = "off";
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
                PropRollupList = "Rollup List",
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
            _privateObject.Invoke("OnInit", new object[] { EventArgs.Empty });
            _privateObject.Invoke("CreateChildControls");

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
        public void RenderToolPart_Invoke_RendersToolpartHtml()
        {
            // Arrange
            LoadGridListView(ValueOn);
            _gridListView.PropDefaultControl = DummyString;

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            result.ShouldBe("");
        }

        [TestMethod]
        public void RenderToolPart_Gantt_RendersToolpartHtml()
        {
            // Arrange
            LoadGridListView(ValueOff);
            _gridListView.PropDefaultControl = "gantt";

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _resultWriter });

            // Assert
            var result = _resultBuilder.ToString();
            result.ShouldNotBeNull();
            result.ShouldBe("");
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
                () => _gridListView.PropList.ShouldBe($"ddlView{One}"),
                () => _gridListView.PropView.ShouldBe($"ddlView{One}"),
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

            ShimSPList.AllInstances.TitleGet = _ => "List Title";
            ShimSPList.AllInstances.HiddenGet = _ => false;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            var viewCollection = new ShimSPViewCollection();
            ShimSPList.AllInstances.ViewsGet = _ => viewCollection.Bind(new SPView[] { new ShimSPView() });
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });

            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.UrlGet = _ => ExampleUrl;

            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPView.AllInstances.TitleGet = _ => "View Title";
            ShimSPView.AllInstances.HiddenGet = _ => false;
            ShimSPView.AllInstances.PersonalViewGet = _ => false;

            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimSPField.AllInstances.TitleGet = _ => "Field Title";
            ShimSPField.AllInstances.InternalNameGet = _ => "Title";

            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
        }
    }
}
