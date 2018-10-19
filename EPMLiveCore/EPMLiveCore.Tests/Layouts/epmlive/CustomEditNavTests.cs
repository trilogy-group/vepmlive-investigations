using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class CustomEditNavTests
    {
        private const int DummyNavigationNodeID = 777;
        private const string DummyNodeTitle = "DummyNodeTitle";
        private const string TopNavType = "topnav";
        private const string QuickLaunchType = "quiklnch";
        private const int DummyParentId = 007;
        private const string LoadHeadingDropDownListMethodName = "LoadHeadingDropDownList";
        private const string BorkedType = "BorkedType";
        private const string IsEditingHeadingFieldName = "_isEditingHeading";
        private const string NodeTypeFieldName = "_nodeType";
        private const string WebFieldName = "_web";
        private const string AppHelperFieldName = "appHelper";
        private const string DdlNavigationHeadingsFieldName = "ddlNavigationHeadings";
        private const string AppIdFieldName = "_appId";
        private const string CurrentNodeFieldName = "_currentNode";

        private IDisposable _context;
        private PrivateObject _privateObject;
        private CustomEditNav _customEditNav;

        private List<int> _navigationIds;
        private ListItemCollection _items;
        private string _actualSelectedValue;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _customEditNav = new CustomEditNav();
            _privateObject = new PrivateObject(_customEditNav);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void LoadHeadingDropDownListHelper_TopNavHaveNavigationNodesValidAppId_Populates()
        {
            // Arrange
            ArrangeLoadHeadingDropDownListHelper(TopNavType, true, 1, false);

            // Act
            _privateObject.Invoke(LoadHeadingDropDownListMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _navigationIds.ShouldContain(DummyNavigationNodeID),
                () =>
                {
                    var item = _items[0];
                    item.Text.ShouldBe(DummyNodeTitle);
                    item.Value.ShouldBe(DummyNavigationNodeID.ToString());
                },
                () => _actualSelectedValue.ShouldBe(DummyParentId.ToString()));
        }

        [TestMethod]
        public void LoadHeadingDropDownListHelper_QuickHaveNavigationNodesValidAppId_Populates()
        {
            // Arrange
            ArrangeLoadHeadingDropDownListHelper(QuickLaunchType, true, 1, false);

            // Act
            _privateObject.Invoke(LoadHeadingDropDownListMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _navigationIds.ShouldContain(DummyNavigationNodeID),
                () =>
                {
                    var item = _items[0];
                    item.Text.ShouldBe(DummyNodeTitle);
                    item.Value.ShouldBe(DummyNavigationNodeID.ToString());
                },
                () => _actualSelectedValue.ShouldBe(DummyParentId.ToString()));
        }

        [TestMethod]
        public void LoadHeadingDropDownListHelper_QuickNotHaveNavigationNodesValidAppId_Populates()
        {
            // Arrange
            ArrangeLoadHeadingDropDownListHelper(QuickLaunchType, false, 1, false);

            // Act
            _privateObject.Invoke(LoadHeadingDropDownListMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _navigationIds.ShouldBeEmpty(),
                () =>
                {
                    var item = _items[0];
                    item.Text.ShouldBe(DummyNodeTitle);
                    item.Value.ShouldBe(DummyNavigationNodeID.ToString());
                },
                () => _actualSelectedValue.ShouldBe(DummyParentId.ToString()));
        }

        [TestMethod]
        public void LoadHeadingDropDownListHelper_TopNavNotHaveNavigationNodesValidAppId_Populates()
        {
            // Arrange
            ArrangeLoadHeadingDropDownListHelper(TopNavType, false, 1, false);

            // Act
            _privateObject.Invoke(LoadHeadingDropDownListMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _navigationIds.ShouldBeEmpty(),
                () =>
                {
                    var item = _items[0];
                    item.Text.ShouldBe(DummyNodeTitle);
                    item.Value.ShouldBe(DummyNavigationNodeID.ToString());
                },
                () => _actualSelectedValue.ShouldBe(DummyParentId.ToString()));
        }

        [TestMethod]
        public void LoadHeadingDropDownListHelper_InvalidType_Throws()
        {
            // Arrange
            ArrangeLoadHeadingDropDownListHelper(BorkedType, false, 1, false);

            // Act
            Action action = () => _privateObject.Invoke(LoadHeadingDropDownListMethodName);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldThrow<NullReferenceException>(),
                () => _navigationIds.ShouldBeEmpty(),
                () => { _items.Count.ShouldBe(0); },
                () => _actualSelectedValue.ShouldBeNullOrEmpty());
        }

        private void ArrangeLoadHeadingDropDownListHelper(string nodeType, bool shouldHaveNavigationNodes, int appId, bool shouldCurrentNodeBeNull)
        {
            _privateObject.SetField(IsEditingHeadingFieldName, false);
            _privateObject.SetField(NodeTypeFieldName, nodeType);
            _privateObject.SetField(WebFieldName, (SPWeb)new ShimSPWeb());
            _privateObject.SetField(AppHelperFieldName, (AppSettingsHelper)new ShimAppSettingsHelper());
            _privateObject.SetField(DdlNavigationHeadingsFieldName, (DropDownList)new ShimListControl(new ShimDropDownList()));
            _privateObject.SetField(AppIdFieldName, appId);
            _privateObject.SetField(CurrentNodeFieldName, (SPNavigationNode)(!shouldCurrentNodeBeNull ? new ShimSPNavigationNode() : null ));

            ShimSPWeb.AllInstances.NavigationGet = _ => new ShimSPNavigation();
            ShimSPNavigation.AllInstances.TopNavigationBarGet = _ => (SPNavigationNodeCollection)new ShimSPBaseCollection(new ShimSPNavigationNodeCollection());
            ShimSPNavigation.AllInstances.QuickLaunchGet = _ => (SPNavigationNodeCollection)new ShimSPBaseCollection(new ShimSPNavigationNodeCollection());
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPNavigationNode> { new ShimSPNavigationNode() }.GetEnumerator();
            ShimSPNavigationNode.AllInstances.IdGet = _ => DummyNavigationNodeID;
            ShimSPNavigationNode.AllInstances.TitleGet = _ => DummyNodeTitle;
            ShimSPNavigationNode.AllInstances.ParentIdGet = _ => DummyParentId;

            _navigationIds = shouldHaveNavigationNodes ? new List<int>{DummyNavigationNodeID}: new List<int>();
            ShimAppSettingsHelper.AllInstances.TryGetTopNavIdsByAppIdInt32 = (_1, _2) => _navigationIds;
            ShimAppSettingsHelper.AllInstances.TryGetQuickLaunchIdsByAppIdInt32 = (_1, _2) => _navigationIds;

            _items = new ListItemCollection();
            ShimListControl.AllInstances.ItemsGet = _ => _items;
            ShimListControl.AllInstances.SelectedValueSetString = (_, str) => _actualSelectedValue = str;

        }
    }
}
