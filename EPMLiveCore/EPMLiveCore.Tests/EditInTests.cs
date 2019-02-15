using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class EditInTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string EPMLivePlannerPlannersConfigName = "EPMLivePlannerPlanners";
        private const string EPMLiveWPEnableConfigName = "EPMLiveWPEnable";
        private const string EPMLiveAgileEnableConfigName = "EPMLiveAgileEnable";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private IDisposable shimsContext;
        private PrivateObject privateObject;
        private EditIn editIn;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            editIn = new EditIn();
            privateObject = new PrivateObject(editIn);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPRequestContext.CurrentGet = () => new ShimSPRequestContext();

            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (web, configName) => DummyString;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ServerVariablesGet = () => new NameValueCollection
                {
                    ["URL"] = "dummy.org"
                }
            };
        }

        [TestMethod]
        public void CreateChildControls_RenderMenuItemTemplates_ExecutesCorrectly()
        {
            // Arrange
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid(),
                    FeaturesGet = () => new ShimSPFeatureCollection
                    {
                        ItemGetGuid = guid => null
                    }
                }
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => "/",
                SiteGet = () => new ShimSPSite
                {
                    FeaturesGet = () => new ShimSPFeatureCollection
                    {
                        ItemGetGuid = itemGuid => new ShimSPFeature()
                    }
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = itemGuid => null
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPDocumentLibrary
                    {
                        DocumentTemplateUrlGet = () => $"{DummyString}mpp"
                    }
                }
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean =
                (web, configName, relative) => configName == EPMLivePlannerPlannersConfigName
                                                ? "Dummy|string,Dummy|string"
                                                : DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString =
                (web, configName) => configName == EPMLiveWPEnableConfigName || configName == EPMLiveAgileEnableConfigName
                                        ? bool.TrueString
                                        : DummyString;
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimSPListItem
                {
                    IDGet = () => 652
                }
            };
            privateObject.SetFieldOrProperty("sListName", DummyString);

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);
            var manuItemTemplates = editIn.Controls?.OfType<MenuItemTemplate>();

            // Assert
            editIn.ShouldSatisfyAllConditions(
                () => editIn.Controls.ShouldNotBeNull(),
                () => manuItemTemplates.ShouldNotBeNull(),
                () => manuItemTemplates.ShouldNotBeEmpty(),
                () => manuItemTemplates.FirstOrDefault(p => p.Text == "Edit In Work Planner").ShouldNotBeNull(),
                () => manuItemTemplates.FirstOrDefault(p => p.Text == "Edit With Project").ShouldNotBeNull(),
                () => manuItemTemplates.FirstOrDefault(p => p.Text == "Edit In string").ShouldNotBeNull());
        }

        [TestMethod]
        public void CreateChildControls_RenderSubMenuItemTemplates_ExecutesCorrectly()
        {
            // Arrange
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => DummyGuid,
                    FeaturesGet = () => new ShimSPFeatureCollection
                    {
                        ItemGetGuid = guid => null
                    }
                }
            };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                ServerRelativeUrlGet = () => "/",
                SiteGet = () => new ShimSPSite
                {
                    FeaturesGet = () => new ShimSPFeatureCollection
                    {
                        ItemGetGuid = itemGuid => new ShimSPFeature()
                    }
                },
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    ItemGetGuid = itemGuid => null
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = name => new ShimSPDocumentLibrary
                    {
                        DocumentTemplateUrlGet = () => $"{DummyString}mpp"
                    }
                }
            };

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean =
                (web, configName, relative) => configName == "EPMLivePlannerPlanners"
                                                ? "Dummy|string,Dummy|string"
                                                : DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString =
                (web, configName) => configName == "EPMLiveWPEnable" || configName == "EPMLiveAgileEnable"
                                        ? bool.TrueString
                                        : DummyString;

            ShimCoreFunctions.getLockedWebSPWeb = _ => DummyGuid;

            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection
            {
                CountGet = () => 2,
                ItemGetInt32 = index => new ShimSPListItem
                {
                    IDGet = () => 652
                }
            };
            ShimSPList.AllInstances.GetItemsSPQuery = (_, query) => new ShimSPListItemCollection
            {
                GetEnumerator = () => new List<SPListItem>
                {
                    new ShimSPListItem
                    {
                        TitleGet = () => DummyString
                    }
                }.GetEnumerator()
            };
            privateObject.SetFieldOrProperty("sListName", DummyString);

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);
            var subMenuItemTemplates = editIn.Controls?.OfType<SubMenuTemplate>();

            // Assert
            editIn.ShouldSatisfyAllConditions(
                () => editIn.Controls.ShouldNotBeNull(),
                () => subMenuItemTemplates.ShouldNotBeNull(),
                () => subMenuItemTemplates.ShouldNotBeEmpty(),
                () => subMenuItemTemplates.FirstOrDefault(p => p.Text == "Edit In Work Planner").ShouldNotBeNull(),
                () => subMenuItemTemplates.FirstOrDefault(p => p.Text == "Edit In Agile Planner").ShouldNotBeNull(),
                () => subMenuItemTemplates.FirstOrDefault(p => p.Text == "Edit With Project").ShouldNotBeNull());
        }
    }
}
