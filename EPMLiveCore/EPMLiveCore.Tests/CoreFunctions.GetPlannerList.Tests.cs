using System;
using System.Collections.Generic;
using System.Collections.Specialized.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class CoreFunctionsGetPlannerListTest
    {
        private CoreFunctions _testObj;
        private PrivateObject _privateObj;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void Setup()
        {
            _shimsContext = ShimsContext.Create();

            _testObj = new CoreFunctions();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void GetPlannerList_NullList_ReturnsList()
        {
            // Arrange
            const string planners = "plan11|plan12,plan21|plan22";
            const string falseString = "false";
            const string trueString = "true";
            const string documentTemplateUrl = "DocumentTemplateUrl.mpp";

            var lWeb = new ShimSPWeb()
            {
                PropertiesGet = () => new ShimSPPropertyBag(),
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = (title) =>
                    {
                        if (title == "Planner Templates")
                        {
                            return null;
                        }

                        return new ShimSPList()
                        {
                            TitleGet = () => title
                        };
                    },
                    ItemGetString = (key) => new ShimSPList()
                    {
                        ContentTypesEnabledGet = () => false
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    FeaturesGet = () => new ShimSPFeatureCollection()
                    {
                        ItemGetGuid = (guid) => new ShimSPFeature().Instance
                    }
                }
            }.Instance;

            var web = new ShimSPWeb()
            {
                PropertiesGet = () => new ShimSPPropertyBag(),
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = (title) =>
                    {
                        if (title == "Planner Templates")
                        {
                            return null;
                        }

                        return new ShimSPList()
                        {
                            TitleGet = () => title
                        };
                    },
                    ItemGetString = (key) =>
                    {
                        if(key == "Project Schedules")
                        {
                            return new ShimSPDocumentLibrary();
                        }

                        return new ShimSPList()
                        {
                            ContentTypesEnabledGet = () => false
                        };
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    FeaturesGet = () => new ShimSPFeatureCollection()
                    {
                        ItemGetGuid = (guid) => new ShimSPFeature().Instance
                    }
                }
            }.Instance;

            var listItem = new ShimSPListItem()
            {

            }.Instance;

            var customProperties = new Dictionary<string, string>();
            customProperties.Add("EPMLivePlannerPlanners", planners);
            customProperties.Add("EPMLiveDisablePublishing", falseString);
            customProperties.Add("EPMLiveDisablePlanners", falseString);

            customProperties.Add("EPMLivePlannerplan11TaskCenter", "TaskCenterplan11");
            customProperties.Add("EPMLivePlannerplan11ProjectCenter", "ProjectCenterplan11");
            customProperties.Add("EPMLivePlannerplan11Description", "Descriptionplan11");
            customProperties.Add("EPMLivePlannerplan11EnableOnline", string.Empty);
            customProperties.Add("EPMLivePlannerplan11EnableKanban", falseString);
            customProperties.Add("EPMLivePlannerplan11EnableProject", falseString);

            customProperties.Add("EPMLivePlannerplan21TaskCenter", "TaskCenterplan21");
            customProperties.Add("EPMLivePlannerplan21ProjectCenter", "ProjectCenterplan21");
            customProperties.Add("EPMLivePlannerplan21Description", "Descriptionplan21");
            customProperties.Add("EPMLivePlannerplan21EnableOnline", falseString);
            customProperties.Add("EPMLivePlannerplan21EnableKanban", falseString);
            customProperties.Add("EPMLivePlannerplan21EnableProject", falseString);

            customProperties.Add("EPMLiveWPProjectCenter", "EPMLiveWPProjectCenter");
            customProperties.Add("EPMLiveWPTaskCenter", "EPMLiveWPTaskCenter");
            customProperties.Add("EPMLiveWPEnable", trueString);
            customProperties.Add("EPMLiveAgileProjectCenter", "EPMLiveAgileProjectCenter");
            customProperties.Add("EPMLiveAgileTaskCenter", "EPMLiveAgileTaskCenter");
            customProperties.Add("EPMLiveAgileEnable", trueString);

            customProperties.Add("epmlivepub-pc", "epmlivepub-pc");
            customProperties.Add("epmlivepub-tc", "epmlivepub-tc");

            ShimSPDocumentLibrary.AllInstances.DocumentTemplateUrlGet = _ => documentTemplateUrl;
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;
            ShimSPList.AllInstances.ContentTypesEnabledGet = _ => false;
            ShimStringDictionary.AllInstances.ContainsKeyString = (instance, key) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (instance, key) => customProperties[key];

            // Act
            var actual = (Dictionary<string, PlannerDefinition>)_privateObj.Invoke("iGetPlannerList", BindingFlags.NonPublic | BindingFlags.Static, new object[] { lWeb, web, null });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(5),
                () => actual["plan11"].ShouldNotBeNull(),
                () => actual["plan11"].title.ShouldBe("plan12"),
                () => actual.Keys.Contains("plan21").ShouldBeFalse(),
                () => actual["MPP"].ShouldNotBeNull(),
                () => actual["MPP"].title.ShouldBe("Microsoft Office Project"),
                () => actual["WorkEngineWorkPlanner"].ShouldNotBeNull(),
                () => actual["WorkEngineWorkPlanner"].title.ShouldBe("Work Planner"),
                () => actual["WorkEngineAgilePlanner"].ShouldNotBeNull(),
                () => actual["WorkEngineAgilePlanner"].title.ShouldBe("Agile Planner"),
                () => actual["EditInMicrosoftProject"].ShouldNotBeNull(),
                () => actual["EditInMicrosoftProject"].title.ShouldBe("Microsoft Project"));
        }

        [TestMethod]
        public void GetPlannerList_ListNotNull_ReturnsList()
        {
            // Arrange
            const string planners = "plan11|plan12,plan21|plan22";
            const string falseString = "false";
            const string trueString = "true";
            const string documentTemplateUrl = "DocumentTemplateUrl.mpp";
            const string customTitle = "Project Center";

            var lWeb = new ShimSPWeb()
            {
                PropertiesGet = () => new ShimSPPropertyBag(),
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = (title) =>
                    {
                        if (title == "Planner Templates")
                        {
                            return null;
                        }

                        return new ShimSPList()
                        {
                            TitleGet = () => title
                        };
                    },
                    ItemGetString = (key) => new ShimSPList()
                    {
                        ContentTypesEnabledGet = () => false
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    FeaturesGet = () => new ShimSPFeatureCollection()
                    {
                        ItemGetGuid = (guid) => new ShimSPFeature().Instance
                    }
                }
            }.Instance;

            var web = new ShimSPWeb()
            {
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = (guid) => new ShimSPFeature().Instance
                },
                PropertiesGet = () => new ShimSPPropertyBag(),
                ListsGet = () => new ShimSPListCollection()
                {
                    TryGetListString = (title) =>
                    {
                        if (title == "Planner Templates")
                        {
                            return null;
                        }

                        return new ShimSPList()
                        {
                            TitleGet = () => title
                        };
                    },
                    ItemGetString = (key) =>
                    {
                        if (key == "Project Schedules")
                        {
                            return new ShimSPDocumentLibrary();
                        }

                        return new ShimSPList()
                        {
                            ContentTypesEnabledGet = () => false
                        };
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    FeaturesGet = () => new ShimSPFeatureCollection()
                    {
                        ItemGetGuid = (guid) => new ShimSPFeature().Instance
                    }
                }
            }.Instance;

            var listItem = new ShimSPListItem()
            {
                ParentListGet = () => new ShimSPList()
                {
                    TitleGet = () => customTitle
                }
            }.Instance;

            var customProperties = new Dictionary<string, string>();
            customProperties.Add("EPMLivePlannerPlanners", planners);
            customProperties.Add("EPMLiveDisablePublishing", falseString);
            customProperties.Add("EPMLiveDisablePlanners", falseString);

            customProperties.Add("EPMLivePlannerplan11TaskCenter", customTitle);
            customProperties.Add("EPMLivePlannerplan11ProjectCenter", "ProjectCenterplan11");
            customProperties.Add("EPMLivePlannerplan11Description", "Descriptionplan11");
            customProperties.Add("EPMLivePlannerplan11EnableOnline", trueString);
            customProperties.Add("EPMLivePlannerplan11EnableKanban", falseString);
            customProperties.Add("EPMLivePlannerplan11EnableProject", falseString);

            customProperties.Add("EPMLivePlannerplan21TaskCenter", "TaskCenterplan21");
            customProperties.Add("EPMLivePlannerplan21ProjectCenter", customTitle);
            customProperties.Add("EPMLivePlannerplan21Description", "Descriptionplan21");
            customProperties.Add("EPMLivePlannerplan21EnableOnline", trueString);
            customProperties.Add("EPMLivePlannerplan21EnableKanban", falseString);
            customProperties.Add("EPMLivePlannerplan21EnableProject", falseString);

            customProperties.Add("EPMLiveWPProjectCenter", customTitle);
            customProperties.Add("EPMLiveWPTaskCenter", "EPMLiveWPTaskCenter");
            customProperties.Add("EPMLiveWPEnable", trueString);
            customProperties.Add("EPMLiveAgileProjectCenter", customTitle);
            customProperties.Add("EPMLiveAgileTaskCenter", "EPMLiveAgileTaskCenter");
            customProperties.Add("EPMLiveAgileEnable", trueString);

            customProperties.Add("epmlivepub-pc", customTitle);
            customProperties.Add("epmlivepub-tc", "epmlivepub-tc");

            ShimSPDocumentLibrary.AllInstances.DocumentTemplateUrlGet = _ => documentTemplateUrl;
            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.Empty;
            ShimSPList.AllInstances.ContentTypesEnabledGet = _ => false;
            ShimStringDictionary.AllInstances.ContainsKeyString = (instance, key) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (instance, key) => customProperties[key];

            // Act
            var actual = (Dictionary<string, PlannerDefinition>)_privateObj.Invoke("iGetPlannerList", BindingFlags.NonPublic | BindingFlags.Static, new object[] { lWeb, web, listItem });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(5),
                () => actual["plan11"].ShouldNotBeNull(),
                () => actual["plan11"].title.ShouldBe("plan12"),
                () => actual["plan21"].ShouldNotBeNull(),
                () => actual["plan21"].title.ShouldBe("plan22"),
                () => actual.Keys.Contains("MPP").ShouldBeFalse(),
                () => actual["WorkEngineWorkPlanner"].ShouldNotBeNull(),
                () => actual["WorkEngineWorkPlanner"].title.ShouldBe("Work Planner"),
                () => actual["WorkEngineAgilePlanner"].ShouldNotBeNull(),
                () => actual["WorkEngineAgilePlanner"].title.ShouldBe("Agile Planner"),
                () => actual["EditInMicrosoftProject"].ShouldNotBeNull(),
                () => actual["EditInMicrosoftProject"].title.ShouldBe("Microsoft Project"));
        }
    }
}