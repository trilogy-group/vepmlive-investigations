using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Xml;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.API.Integration;
using EPMLiveCore.API.Integration.Fakes;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Fakes;
using EPMLiveCore.ListDefinitions;
using EPMLiveIntegration;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.CommandUI.Fakes;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DispFormTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string MethodOnPreRender = "OnPreRender";
        private const string EditActionsButton = "Ribbon.ListForm.Edit.Actions.Controls._children";
        private DispForm _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private Dictionary<string, XmlNode> _registeredExtensions;
        private readonly Guid DefaultListId = Guid.NewGuid();
        private readonly Guid DefaultSiteId = Guid.NewGuid();
        private readonly Guid DefaultWebId = Guid.NewGuid();

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            PrepareSpContext();
            PrepareSettings();

            _registeredExtensions = new Dictionary<string, XmlNode>();

            _testObject = new DispForm { Page = new Page() };
            _privateObject = new PrivateObject(_testObject);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void OnPreRender_Invoke_RegistersRibbons()
        {
            // Arrange

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            _registeredExtensions.ShouldNotBeNull();
            _registeredExtensions.ShouldNotBeEmpty();
            var registeredKeys = _registeredExtensions.Keys;
            this.ShouldSatisfyAllConditions(
                () => registeredKeys.ShouldContain("Ribbon.ListForm.Display.Groups._children"),
                () => registeredKeys.ShouldContain("Ribbon.ListForm.Display.Scaling._children"),
                () => registeredKeys.ShouldContain("Ribbon.ListForm.Display.Manage.Controls._children"),
                () => registeredKeys.ShouldContain("Ribbon.ListForm.Display.Actions.Controls._children"),
                () => registeredKeys.ShouldContain("Ribbon.DocLibListForm.Edit.Actions.Controls._children"),
                () => registeredKeys.ShouldContain(EditActionsButton));
        }

        [TestMethod]
        public void OnPreRender_NotArchivedColumn_RegisterRestoreButton()
        {
            // Arrange
            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case ProjectArchiverService.ArchivedColumn:
                        return true;
                    case "WorkspaceUrl":
                        return string.Empty;
                    default:
                        return DummyString;
                }
            };
            ShimListCommands.GetRibbonPropsSPList = _ => new RibbonProperties
            {
                bBuildTeam = true,
                aEPKButtons = new ArrayList { "costs", "resplan" },
                aEPKActivex = new ArrayList()
            };

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            _registeredExtensions.ShouldNotBeNull();
            _registeredExtensions.ShouldNotBeEmpty();
            this.ShouldSatisfyAllConditions(
                () =>
                {
                    _registeredExtensions.ShouldContainKey(EditActionsButton);
                    var node = _registeredExtensions[EditActionsButton];
                    var id = node.Attributes["Id"];
                    id.ShouldNotBeNull();
                    id.Value.ShouldBe("Ribbon.ListItem.EPMLive.FavoriteStatus");
                });
        }

        private void PrepareSpContext()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPContext.AllInstances.ListItemGet = _ => new ShimSPListItem();

            ShimSPRibbon.GetCurrentPage = _ => new ShimSPRibbon();
            ShimRibbon.AllInstances.RegisterDataExtensionXmlNodeString = 
                (_, node, key) => _registeredExtensions[key] = node;

            ShimSPWeb.AllInstances.IDGet = _ => DefaultWebId;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LanguageGet = _ => Id;
            ShimSPWeb.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => Id;
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, __)=> new ShimSPFeature();
            ShimSPSite.AllInstances.IDGet = _ => DefaultSiteId;

            ShimSPList.AllInstances.IDGet = _ => DefaultListId;
            var fieldCollection = new ShimSPFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => fieldCollection.Bind(new SPField[] { new ShimSPField() });
            ShimSPList.AllInstances.BaseTemplateGet = _ => (SPListTemplateType)EPMLiveLists.ProjectCenter;

            ShimSPListItem.AllInstances.ItemGetString = (_, key) =>
            {
                switch (key)
                {
                    case ProjectArchiverService.ArchivedColumn:
                        return false;
                    case "WorkspaceUrl":
                        return ExampleUrl;
                    default:
                        return DummyString;
                }
            };
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.ModerationInformationGet = _ => new ShimSPModerationInformation();
            ShimSPModerationInformation.AllInstances.StatusGet = _ => SPModerationStatusType.Approved;

            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;
        }

        private static void PrepareSettings()
        {
            ShimScriptLink.RegisterPageStringBoolean = (a, b, c) => { };

            ShimGridGanttSettings.ConstructorSPList = (instance, _) =>
            {
                instance.AssociatedItems = true;
                instance.EnableRequests = true;
            };

            ShimIntegrationCore.ConstructorGuidGuid = (a, b, c) => { };
            ShimIntegrationCore.AllInstances.GetItemButtonsGuidSPListItemStringOut =
                (IntegrationCore instance, Guid listid, SPListItem li, out string errors) =>
                {
                    errors = null;
                    return new List<IntegrationControl>
                    {
                        new IntegrationControl
                        {
                            Control = DummyString,
                            Window = IntegrationControlWindowStyle.FullDialog,
                            Image = DummyString,
                            Title = DummyString
                        }
                    };
                };

            ShimSPRibbonScriptManager.AllInstances.RegisterInitializeFunctionControlStringStringBooleanString =
                (a, b, c, d, e, f) => { };

            ShimListCommands.GetAssociatedListsSPList = _ => new ArrayList()
            {
                new AssociatedListInfo
                {
                    Title = DummyString,
                    LinkedField = DummyString,
                    icon = DummyString
                }
            };
            ShimListCommands.GetRibbonPropsSPList = _ => new RibbonProperties
            {
                bBuildTeam = true,
                aEPKButtons = new ArrayList
                {
                    "costs",
                    "resplan",
                },
                aEPKActivex = new ArrayList
                {
                    "resplan"
                }
            };
            ShimListCommands.GetListPlannerInfoSPList = _ => new ListPlannerProps
            {
                PlannerV2Menu = "<EPMLivePlanner><TaskPlanner></TaskPlanner></EPMLivePlanner>"
            };
        }
    }
}
