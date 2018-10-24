using System;
using System.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Resources
{
    using Fakes;
    using PortfolioEngineCore;
    using Shouldly;

    [TestClass]
    public class RPEditorResourcesTests
    {
        private IDisposable shimsContext;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private CStruct CreateShimCStruct(
            string stringAttribute, 
            int intAttribute, 
            bool booleanAttribute)
        {
            return new ShimCStruct
            {
                GetStringAttrString = _ => stringAttribute,
                GetIntAttrString = _ => intAttribute,
                GetBooleanAttrString = _ => booleanAttribute
            }.Instance;
        }

        private void SetupShims()
        {
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.GetIntString = (_, name) => 1;
            ShimCStruct.AllInstances.GetBooleanString = (_, name) => true;
            ShimCStruct.AllInstances.GetBooleanAttrString = (_, name) => true;
            ShimCStruct.AllInstances.GetListSortedByAttributeStringString = (_, name, attribute) => new SortedList<string, CStruct>();
        }

        [TestMethod]
        public void BuildPlanResourcesGridXMLString_Should_ExecuteCorrectly()
        {
            // Arrange
            const string PlanResources = "<plans></plans>";
            ShimRPEditorResources.BuildPlanResourcesGridXMLCStructCStruct = (resultStruct, plan) => DummyString;

            // Act
            var result = RPEditorResources.BuildPlanResourcesGridXML(PlanResources);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void BuildPlanResourcesGridXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var resultStruct = new CStruct();
            resultStruct.Initialize("Main");
            var planResources = new ShimCStruct
            {
                GetSubStructString = name => new ShimCStruct
                {
                    GetListString = structName =>
                    {
                        return new List<CStruct>
                        {
                            new ShimCStruct
                            {
                                GetSubStructString = _ => new CStruct(),
                                GetStringString = _ => "Dummy",
                                GetStringAttrString = _ => "Dummy"
                            }
                        };
                    },
                    GetSubStructString = structName => new ShimCStruct
                    {
                        GetListString = attr => 
                        {
                            return new List<CStruct>
                            {
                                CreateShimCStruct(DummyString, 9004, true),
                                CreateShimCStruct(DummyString, 9006, true),
                                CreateShimCStruct(DummyString, 9015, true),
                                CreateShimCStruct(DummyString, 9016, true),
                                CreateShimCStruct(DummyString, 9017, true),
                                CreateShimCStruct(DummyString, 9019, true),
                                CreateShimCStruct(DummyString, 9020, true),
                                CreateShimCStruct(DummyString, 9024, true),
                                CreateShimCStruct(DummyString, 9, true),
                            };
                        }
                    }
                }
            };
            var expectedElements = new List<string>
            {
                "<C Name=\"ItemName\" Type=\"Text\" Width=\"200\" CanEdit=\"0\" CanMove=\"0\" CanHide=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" Visible=\"1\" />",
                "<C Name=\"Res_Name\" Type=\"Text\" CanMove=\"1\" CaseSensitive=\"0\" ShowHint=\"0\" Visible=\"0\" />",
                "<C Name=\"Role_Name\" Type=\"Text\" CanMove=\"1\" CaseSensitive=\"0\" ShowHint=\"0\" Visible=\"0\" />",
                "<Cfg MainCol=\"ItemName\" Code=\"GTACCNPSQEBSLC\" SuppressCfg=\"3\" Dragging=\"1\" ColsMoving=\"1\" ColsPosLap=\"1\" ColsLap=\"1\" "+
                "Sorting=\"1\" VisibleLap=\"1\" SectionWidthLap=\"1\" GroupLap=\"1\" WideHScroll=\"0\" LeftWidth=\"400\" Width=\"400\" RightWidth=\"400\" MaxHeight=\"0\" "+
                "ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" DefaultSort=\"ItemName\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" "+
                "LastId=\"1\" CaseSensitiveId=\"0\" Style=\"GM\" CSS=\"RPEditor\" FastColumns=\"1\" ExpandAllLevels=\"3\" GroupSortMain=\"1\" GroupRestoreSort=\"1\" "+
                "IdNames=\"id\" NoTreeLines=\"1\" ConstHeight=\"1\" NoFormatEscape=\"1\" FocusWholeRow=\"1\" Paging=\"2\" ChildPaging=\"2\" PageLength=\"20\" MaxPages=\"1\" "+
                "NoPager=\"1\" AllPages=\"1\" />",
                "<Head><Filter id=\"Filter\" Visible=\"0\" /></Head>"
            };

            // Act
            var result = RPEditorResources.BuildPlanResourcesGridXML(resultStruct, planResources);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedElements.ForEach(p => result.ShouldContainWithoutWhitespace(p)));
        }
    }
}
