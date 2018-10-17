using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceValues;
using Shouldly;
using static System.Net.Mime.MediaTypeNames;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass]
    public class ClsResourceValuesTests
    {
        private IDisposable shimsContext;
        private clsResourceValues clsResourceValues;
        private const string DummyString = "DummyStirng";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            clsResourceValues = new clsResourceValues();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void XML_BaseStructure_ShouldRenderCorrectly()
        {
            // Arrange
            const int CalendarId = 34;
            const int PlanningCalendarID = 367;
            const int FromPeriodID = 4;
            const int ToPeriodID = 1;
            const int GpPMOAdmin = 98;
            const int CommitmentsOpMode = 9;
            const int lRequestNo = 64;
            const int RoleFieldID = 5;
            const int MajorCategoryFieldID = 100;

            var expectedCalendar = $"<CalendarID>{CalendarId}</CalendarID>";
            var expectedPlanning = $"<PlanningCalendarID>{PlanningCalendarID}</PlanningCalendarID>";
            var expectedFromPeriod = $"<FromPeriodID>{FromPeriodID}</FromPeriodID>";
            var expectedToPeriod = $"<ToPeriodID>{ToPeriodID}</ToPeriodID>";
            var expectedPMOAdmin = $"<gpPMOAdmin>{GpPMOAdmin}</gpPMOAdmin>";
            var expectedCommitment = $"<CommitmentsOpMode>{CommitmentsOpMode}</CommitmentsOpMode>";
            var expectedRequest = $"<RequestNo>{lRequestNo}</RequestNo>";
            var expectedRoleField = $"<RoleFieldID>{RoleFieldID}</RoleFieldID>";
            var expectedMajorCategory = $"<MajorCategoryFieldID>{MajorCategoryFieldID}</MajorCategoryFieldID>";
            var expectedCalendarName = $"<CalendarName>{DummyString}</CalendarName>";

            clsResourceValues.CalendarID = CalendarId;
            clsResourceValues.PlanningCalendarID = PlanningCalendarID;
            clsResourceValues.FromPeriodID = FromPeriodID;
            clsResourceValues.ToPeriodID = ToPeriodID;
            clsResourceValues.gpPMOAdmin = GpPMOAdmin;
            clsResourceValues.CommitmentsOpMode = CommitmentsOpMode;
            clsResourceValues.lRequestNo = lRequestNo;
            clsResourceValues.RoleFieldID = RoleFieldID;
            clsResourceValues.MajorCategoryFieldID = MajorCategoryFieldID;
            clsResourceValues.CalendarName = DummyString;

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedCalendar),
                () => result.ShouldContainWithoutWhitespace(expectedPlanning),
                () => result.ShouldContainWithoutWhitespace(expectedFromPeriod),
                () => result.ShouldContainWithoutWhitespace(expectedToPeriod),
                () => result.ShouldContainWithoutWhitespace(expectedPMOAdmin),
                () => result.ShouldContainWithoutWhitespace(expectedCommitment),
                () => result.ShouldContainWithoutWhitespace(expectedRequest),
                () => result.ShouldContainWithoutWhitespace(expectedRoleField),
                () => result.ShouldContainWithoutWhitespace(expectedMajorCategory),
                () => result.ShouldContainWithoutWhitespace(expectedCalendarName));
        }

        [TestMethod]
        public void XML_CostCategoriesAndRates_ShouldRederCorrectly()
        {
            // Arrange
            const int DummyId = 3;
            var catItem = new clsCatItem
            {
                UID = DummyId,
                MajorCategory = DummyId,
                Category = DummyId,
                ID = DummyId,
                Level = DummyId,
                Role_UID = DummyId,
                PID = DummyId,
                Name = DummyString,
                FullName = DummyString,
                RoleName = DummyString
            };
            var expectedCostCategoriesValue = "<CostCategories>" +
            "<Cat UID=\"3\" MC=\"3\" CC=\"3\" ID=\"3\" LVL=\"3\" Role=\"3\" PID=\"3\" Name=\"DummyStirng\" FName=\"DummyStirng\" RName=\"DummyStirng\" />" + 
            "</CostCategories>";
            var expecteRatesValue = "<Rates>" +
            "<Rate UID=\"3\" ID=\"3\" LVL=\"3\" PID=\"3\" Name=\"DummyStirng\" FName=\"DummyStirng\" />" +
            "</Rates>";
            clsResourceValues.CostCategories = new Dictionary<int, clsCatItem>
            {
                [1] = catItem
            };
            clsResourceValues.Rates = new Dictionary<int, clsCatItem>
            {
                [1] = catItem
            };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(expectedCostCategoriesValue),
                () => result.ShouldContainWithoutWhitespace(expecteRatesValue));
        }

        [TestMethod]
        public void XML()
        {
            // Arrange
            clsResourceValues.CostCategories = new Dictionary<int, clsCatItem>
            {
                [1] = new clsCatItem()
            };
            clsResourceValues.Rates = new Dictionary<int, clsCatItem>
            {
                [1] = new clsCatItem()
            };
            clsResourceValues.Periods = new Dictionary<int, ResourceValues.CPeriod>
            {
                [1] = new ResourceValues.CPeriod()
            };
            clsResourceValues.Departments = new Dictionary<int, clsEPKItem>
            {
                [1] = new clsEPKItem()
            };
            clsResourceValues.PIs = new Dictionary<int, clsPIData>
            {
                [1] = new clsPIData
                {
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.Resources = new Dictionary<int, clsResCap>
            {
                [1] = new clsResCap
                {
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.Roles = new Dictionary<int, clsListItem>
            {
                [1] = new clsListItem()
            };
            clsResourceValues.Commitments = new Dictionary<int, clsCommitment>
            {
                [1] = new clsCommitment
                {
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.OpenReqs = new Dictionary<int, clsCommitment>
            {
                [1] = new clsCommitment
                {
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.OpenReqHours = new List<clsCommitmentHours>
            {
                new clsCommitmentHours()
            };
            clsResourceValues.SchedWorkHours = new List<clsSchedWork>
            {
                new clsSchedWork()
            };
            clsResourceValues.ActualWorkHours = new List<clsSchedWork>
            {
                new clsSchedWork()
            };
            clsResourceValues.ActualWorkHours = new List<clsSchedWork>
            {
                new clsSchedWork()
            };
            clsResourceValues.NWItems = new Dictionary<int, clsEPKItem>
            {
                [1] = new clsEPKItem()
            };
            clsResourceValues.ResNWValues = new List<clsNWValue>
            {
                new clsNWValue()
            };
            clsResourceValues.ResAvail = new List<clsResAvail>
            {
                new clsResAvail()
            };
            clsResourceValues.CapacityTargets = new Dictionary<int, clsEPKItem>
            {
                [1] = new clsEPKItem()
            };
            clsResourceValues.TargetColors = new Dictionary<int, clsViewTargetColours>
            {
                [1] = new clsViewTargetColours()
            };
            clsResourceValues.PlanFields = new List<clsPortField>
            {
                new clsPortField()
            };
            clsResourceValues.PIFields = new List<clsPortField>
            {
                new clsPortField()
            };
            clsResourceValues.ResFields = new List<clsPortField>
            {
                new clsPortField()
            };
            clsResourceValues.Lookups = new Dictionary<int, clsLookupList>
            {
                [1] = new clsLookupList
                {
                    ListItems = new Dictionary<int, clsListItem>
                    {
                        [1] = new clsListItem()
                    }
                }
            };
            clsResourceValues.FTEConvData = new List<clsFTEConv>
            {
                new clsFTEConv()
            };
            clsResourceValues.UserDepartments = new List<int>
            {
                1
            };

            // Act
            var result = clsResourceValues.XML();


            // Assert
            result.ShouldNotBeNullOrEmpty();

        }

        [TestMethod]
        public void LoadFromXML()
        {
            // Arrange
            var xmlcontent = GetXmlContent();

            // Act
            clsResourceValues.LoadFromXML(xmlcontent);

            // Assert

        }

        private string GetXmlContent()
        {
            var content = @"<ResourceValues>
                    <Options>
                        <CalendarID>0</CalendarID>
                        <PlanningCalendarID>0</PlanningCalendarID>
                        <FromPeriodID>0</FromPeriodID>
                        <ToPeriodID>0</ToPeriodID>
                        <gpPMOAdmin>0</gpPMOAdmin>
                        <CommitmentsOpMode>0</CommitmentsOpMode>
                        <RequestNo>0</RequestNo>
                        <RoleFieldID>0</RoleFieldID>
                        <MajorCategoryFieldID>0</MajorCategoryFieldID>
                        <CalendarName></CalendarName>
                    </Options>
                    <CostCategories>
                        <Cat UID=""0"" MC=""0"" CC=""0"" ID=""0"" LVL=""0"" Role=""0"" PID=""0"" Name="""" FName="""" RName="""" />
                    </CostCategories>
                    <Rates>
                        <Rate UID=""0"" ID=""0"" LVL=""0"" PID=""0"" Name="""" FName="""" />
                    </Rates>
                    <Periods>
                        <PD ID=""0"" St=""0001-01-01T00:00:00"" End=""0001-01-01T00:00:00"" Name="""" />
                    </Periods>
                    <Depts>
                        <Dept ID=""0"" Name="""" Desc="""" />
                    </Depts>
                    <PIs>
                        <PI ProjID=""0"" WProjID=""0"" Name="""" LP="""" IM="""" SO="""" Stage="""" WSS="""" IMID=""0"" Pri=""0"" St=""0001-01-01T00:00:00"" Fin=""0001-01-01T00:00:00"">
                            <CFs>
                                <CF Fld=""DummyStirng"" />
                            </CFs>
                        </PI>
                    </PIs>
                    <Resources>
                        <Res ID=""0"" Name="""" DeptUID=""0"" RoleUID=""0"" RTUID=""0"" BC_Role=""0"" BC_CC=""0"">
                            <CFs>
                                <CF Fld=""DummyStirng"" />
                            </CFs>
                        </Res>
                    </Resources>
                    <Roles>
                        <Role ID=""0"" Name="""" />
                    </Roles>
                    <Cmts>
                        <Cmt UID=""0"" ID=""0"" ProjID=""0"" WresID=""0"" BC_Role=""0"" BC_CC=""0"" RoleUID=""0"" DeptUID=""0"" Status=""0"" Dragable=""0"" Rate=""0"" Cost=""0"" St=""0001-01-01T00:00:00"" Fin=""0001-01-01T00:00:00"" RT="""" MC="""" GP="""">
                            <CFs>
                                <CF Fld=""DummyStirng"" />
                            </CFs>
                        </Cmt>
                    </Cmts>
                    <CHs>
                        <CH UID=""0"" PD=""0"" FTES=""0"" Hrs=""0""/>
                    </CHs>
                    <OReqts>
                        <OReqt UID=""0"" ID=""0"" ProjID=""0"" WresID=""0"" BC_Role=""0"" BC_CC=""0"" RoleUID=""0"" DeptUID=""0"" Status=""0"" Rate=""0"" Cost=""0"" St=""0001-01-01T00:00:00"" Fin=""0001-01-01T00:00:00"" RT="""" MC="""" GP="""">
                            <CFs>
                                <CF Fld=""DummyStirng"" />
                            </CFs>
                        </OReqt>
                    </OReqts>
                    <ORs>
                        <OR UID=""0"" PD=""0"" FTES=""0"" Hrs=""0"" />
                    </ORs>
                    <SWs>
                        <SW ProjID=""0"" WresID=""0"" PD=""0"" MC="""" FTES=""0"" Hrs=""0"" />
                    </SWs>
                    <ActWs>
                        <ActW ProjID=""0"" WresID=""0"" PD=""0"" MC="""" FTES=""0"" Hrs=""0"" />
                    </ActWs>
                    <NWs>
                        <NW ID=""0"" Name="""" />
                    </NWs>
                    <NWHs>
                        <NWH UID=""0"" WresID=""0"" PD=""0"" FTES=""0"" Hrs=""0"" />
                    </NWHs>
                    <RAVs>
                        <RAV WresID=""0"" PD=""0"" FTES=""0"" Hrs=""0"" />
                    </RAVs>
                    <Tgts>
                        <Tgt UID=""0"" ID=""0"" Flag=""0"" Name="""" />
                    </Tgts>
                    <TgtVs>
                        <TgtV UID=""0"" ID=""0"" DeptUID=""0"" RoleUID=""0"" FTES=""0"" Hrs=""0"" />
                    </TgtVs>
                    <TgtCs>
                        <TgtC ID=""0"" LV=""0"" HV=""0"" RGB=""0"" Desc="""" />
                    </TgtCs>
                    <RPFlds>
                        <RPFld ID=""0"" Type=""0"" Name="""" GivenName="""" />
                    </RPFlds>
                    <PIFlds>
                        <PIFld ID=""0"" Type=""0"" Name="""" GivenName="""" />
                    </PIFlds>
                    <ResFlds>
                        <ResFld ID=""0"" Type=""0"" Name="""" GivenName="""" />
                    </ResFlds>
                    <Lookups>
                        <Lookup ID=""0"">
                            <LIs>
                                <LI UID=""0"" ID=""0"" Level=""0"" Inactive=""0"" Name="""" />
                            </LIs>
                        </Lookup>
                    </Lookups>
                    <FTEConvs>
                        <FTEConv CAT_ID=""0"" Period_ID=""0"" FTE=""0"" />
                    </FTEConvs>
                    <UserDepts>
                        <Dept DEPT_UID=""1"" />
                    </UserDepts>
                </ResourceValues>";

            return content;
        }

        [TestMethod]
        public void SetFullNamesListItem_Should_ExecuteCorrectly()
        {
            // Arrange
            var listItems = new Dictionary<int, clsListItem>
            {
                [1] = new clsListItem
                {
                    Level = 1,
                    Name = "Dummy",
                    FullName = "DummyString"
                },
                [2] = new clsListItem
                {
                    Level = 4,
                    Name = "Name",
                    FullName = "FullDummyContentLong"
                }
            };

            // Act
            clsResourceValues.SetFullNames(listItems, 4);

            // Assert
            listItems.ShouldSatisfyAllConditions(
                () => listItems.ShouldNotBeNull(),
                () => listItems[1].ShouldNotBeNull(),
                () => listItems[1].Name.ShouldBe(listItems[1].FullName),
                () => listItems[2].ShouldNotBeNull(),
                () => listItems[2].FullName.ShouldContain(listItems[1].Name));
        }

        [TestMethod]
        public void SetFullNames_Should_ExecuteCorrectly()
        {
            // Arrange
            var listItems = new Dictionary<int, clsCatItem>
            {
                [1] = new clsCatItem
                {
                    Level = 1,
                    Name = "Dummy",
                    FullName = "DummyString"
                },
                [2] = new clsCatItem
                {
                    Level = 4,
                    Name = "Name",
                    FullName = "FullName"
                }
            };

            // Act
            clsResourceValues.SetFullNames(listItems, 4);

            // Assert
            listItems.ShouldSatisfyAllConditions(
                () => listItems.ShouldNotBeNull(),
                () => listItems[1].ShouldNotBeNull(),
                () => listItems[1].Name.ShouldBe(listItems[1].FullName),
                () => listItems[2].ShouldNotBeNull(),
                () => listItems[2].FullName.ShouldContain(listItems[1].Name));
        }





    }
}
