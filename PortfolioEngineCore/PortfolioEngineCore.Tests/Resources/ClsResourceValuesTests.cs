using System;
using System.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    using ResourceValues;

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
        public void XML_PeriodsAndDepartmentsAndPIs_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedPeriodsValue = "<Periods><PD ID=\"0\" St=\"0001-01-01T00:00:00\" End=\"0001-01-01T00:00:00\" Name=\"\" /></Periods>";
            const string ExpectedDepartamentsValue = "<Depts><Dept ID=\"0\" Name=\"\" Desc=\"\" /></Depts>";
            var expectedPIsValue = @"    <PIs>
                <PI ProjID=""0"" WProjID=""0"" Name="""" LP="""" IM="""" SO="""" Stage="""" WSS="""" IMID=""0"" Pri=""0"" St=""0001-01-01T00:00:00"" Fin=""0001-01-01T00:00:00"">
                    <CFs>
                        <CF Fld=""DummyStirng"" />
                    </CFs>
                </PI>
            </PIs>";
            clsResourceValues.Periods = new Dictionary<int, CPeriod>
            {
                [1] = new CPeriod()
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

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedPeriodsValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedDepartamentsValue),
                () => result.ShouldContainWithoutWhitespace(expectedPIsValue));
        }

        [TestMethod]
        public void XML_ResourcesAndRoles_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedResourceValue = "<Res ID=\"1\" Name=\"DummyStirng\" DeptUID=\"1\" RoleUID=\"1\" RTUID=\"1\" BC_Role=\"1\" BC_CC=\"1\">";
            const string ExpectedCustomFieldValue = "<CFs><CF Fld=\"DummyStirng\" /></CFs>";
            const string ExpectedRoleValue = "<Role ID=\"1\" Name=\"DummyStirng\" />";
            clsResourceValues.Resources = new Dictionary<int, clsResCap>
            {
                [1] = new clsResCap
                {
                    ID = 1,
                    Name = DummyString,
                    DeptUID = 1,
                    RoleUID = 1,
                    RT_UID = 1,
                    BC_UID_Role = 1,
                    BC_UID_CC = 1,
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.Roles = new Dictionary<int, clsListItem>
            {
                [1] = new clsListItem
                {
                    ID = 1,
                    Name = DummyString
                }
            };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedResourceValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedCustomFieldValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedRoleValue));
        }

        [TestMethod]
        public void XML_Commitments_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedResourceValue = "<Cmts><Cmt UID=\"0\" ID=\"0\" ProjID=\"0\" WresID=\"0\" BC_Role=\"0\"";
            const string ExpectedCustomFieldValue = "<CFs><CF Fld=\"DummyStirng\" /></CFs>";
            const string ExpectedCommitmentHourValue = "<CHs><CH UID=\"0\" PD=\"0\" FTES=\"0\" Hrs=\"0\" /></CHs>";
            clsResourceValues.Commitments = new Dictionary<int, clsCommitment>
            {
                [1] = new clsCommitment
                {
                    CustomFields = new List<string> { DummyString }
                }
            };
            clsResourceValues.CommitmentHours = new List<clsCommitmentHours>
            {
                new clsCommitmentHours()
            };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedResourceValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedCustomFieldValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedCommitmentHourValue));
        }

        [TestMethod]
        public void XML_OpenReqs_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedOpenReqValue = "<OReqts><OReqt UID=\"0\" ID=\"0\" ProjID=\"0\" WresID=\"0\"";
            const string ExpectedCustomFieldValue = "<CFs><CF Fld=\"DummyStirng\" /></CFs>";
            const string ExpectedOpenReqHourValue = "<ORs><OR UID=\"0\" PD=\"0\" FTES=\"0\" Hrs=\"0\" /></ORs>";
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

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedOpenReqValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedCustomFieldValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedOpenReqHourValue));
        }

        [TestMethod]
        public void XML_WorkHours_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedScheduledHoursValue = "<SWs><SW ProjID=\"0\" WresID=\"0\" PD=\"0\" MC=\"\" FTES=\"0\" Hrs=\"0\" /></SWs>";
            const string ExpectedActualWorkHoursValue = "<ActWs><ActW ProjID=\"0\" WresID=\"0\" PD=\"0\" MC=\"\" FTES=\"0\" Hrs=\"0\" /></ActWs>";
            clsResourceValues.SchedWorkHours = new List<clsSchedWork>
            {
                new clsSchedWork()
            };
            clsResourceValues.ActualWorkHours = new List<clsSchedWork>
            {
                new clsSchedWork()
            };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedScheduledHoursValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedActualWorkHoursValue));
        }

        [TestMethod]
        public void XML_NWItems_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedNWItemValue = "<NWs><NW ID=\"0\" Name=\"\" /></NWs>";
            const string ExpectedResNWValueValue = "<NWHs><NWH UID=\"0\" WresID=\"0\" PD=\"0\" FTES=\"0\" Hrs=\"0\" /></NWHs>";
            const string ExpectedResVailItemValue = "<RAVs><RAV WresID=\"0\" PD=\"0\" FTES=\"0\" Hrs=\"0\" /></RAVs>";
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

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedNWItemValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedResNWValueValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedResVailItemValue));
        }

        [TestMethod]
        public void XML_CapacityTargets_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedCapacityTargetValue = "<Tgts><Tgt UID=\"0\" ID=\"0\" Flag=\"0\" Name=\"\" /></Tgts>";
            const string ExpectedCapacityValue = "<TgtVs><TgtV ID=\"0\" PD=\"0\" DeptUID=\"0\" RoleUID=\"0\" FTES=\"0\" Hrs=\"0\" /></TgtVs>";
            const string ExpectedTargetColorValue = "<TgtCs><TgtC ID=\"0\" LV=\"0\" HV=\"0\" RGB=\"0\" Desc=\"\" /></TgtCs>";
            clsResourceValues.CapacityTargets = new Dictionary<int, clsEPKItem>
            {
                [1] = new clsEPKItem()
            };
            clsResourceValues.CapacityTargetValues= new List<clsCapacityValue>
            {
                new clsCapacityValue()
            };
            clsResourceValues.TargetColors = new Dictionary<int, clsViewTargetColours>
            {
                [1] = new clsViewTargetColours()
            };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedCapacityTargetValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedCapacityValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedTargetColorValue));
        }

        [TestMethod]
        public void XML_Fields_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedPlnaFieldValue = "<RPFlds><RPFld ID=\"0\" Type=\"0\" Name=\"\" GivenName=\"\" /></RPFlds>";
            const string ExpectedPIFieldValue = "<PIFlds><PIFld ID=\"0\" Type=\"0\" Name=\"\" GivenName=\"\" /></PIFlds>";
            const string ExpectedResFieldValue = "<ResFlds><ResFld ID=\"0\" Type=\"0\" Name=\"\" GivenName=\"\" /></ResFlds>";
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

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedPlnaFieldValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedPIFieldValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedResFieldValue));
        }

        [TestMethod]
        public void XML_Lookups_ShouldRederCorrectly()
        {
            // Arrange
            const string ExpectedLookupItemValue = "<LIs><LI UID=\"0\" ID=\"0\" Level=\"0\" Inactive=\"0\" Name=\"\" /></LIs>";
            const string ExpectedFTEConvValue = "<FTEConvs><FTEConv CAT_ID=\"0\" Period_ID=\"0\" FTE=\"0\" /></FTEConvs>";
            const string ExpectedUserDepartamentValue = "<UserDepts><Dept DEPT_UID=\"1\" /></UserDepts>";
            clsResourceValues.Lookups = new Dictionary<int, clsLookupList>
            {
                [1] = new clsLookupList()
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
            clsResourceValues.UserDepartments = new List<int> { 1 };

            // Act
            var result = clsResourceValues.XML();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContainWithoutWhitespace(ExpectedLookupItemValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedFTEConvValue),
                () => result.ShouldContainWithoutWhitespace(ExpectedUserDepartamentValue));
        }

        [TestMethod]
        public void LoadFromXML_Should_ExecuteCorrectly()
        {
            // Arrange
            var xmlcontent = GetXmlContent();

            // Act
            var result = clsResourceValues.LoadFromXML(xmlcontent);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => ValidateResourceValuesFields());
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

        private void ValidateResourceValuesFields()
        {
            clsResourceValues.CostCategories.ShouldNotBeNull();
            clsResourceValues.CostCategories.ShouldNotBeEmpty();
            clsResourceValues.Rates.ShouldNotBeNull();
            clsResourceValues.Rates.ShouldNotBeEmpty();
            clsResourceValues.Periods.ShouldNotBeNull();
            clsResourceValues.Periods.ShouldNotBeEmpty();
            clsResourceValues.Departments.ShouldNotBeNull();
            clsResourceValues.Departments.ShouldNotBeEmpty();
            clsResourceValues.PIs.ShouldNotBeNull();
            clsResourceValues.PIs.ShouldNotBeEmpty();
            clsResourceValues.Resources.ShouldNotBeNull();
            clsResourceValues.Resources.ShouldNotBeEmpty();
            clsResourceValues.Roles.ShouldNotBeNull();
            clsResourceValues.Roles.ShouldNotBeEmpty();
            clsResourceValues.Commitments.ShouldNotBeNull();
            clsResourceValues.Commitments.ShouldNotBeEmpty();
            clsResourceValues.CommitmentHours.ShouldNotBeNull();
            clsResourceValues.CommitmentHours.ShouldNotBeEmpty();
            clsResourceValues.OpenReqs.ShouldNotBeNull();
            clsResourceValues.OpenReqs.ShouldNotBeEmpty();
            clsResourceValues.OpenReqHours.ShouldNotBeNull();
            clsResourceValues.OpenReqHours.ShouldNotBeEmpty();
            clsResourceValues.SchedWorkHours.ShouldNotBeNull();
            clsResourceValues.SchedWorkHours.ShouldNotBeEmpty();
            clsResourceValues.ActualWorkHours.ShouldNotBeNull();
            clsResourceValues.ActualWorkHours.ShouldNotBeEmpty();
            clsResourceValues.NWItems.ShouldNotBeNull();
            clsResourceValues.NWItems.ShouldNotBeEmpty();
            clsResourceValues.ResNWValues.ShouldNotBeNull();
            clsResourceValues.ResNWValues.ShouldNotBeEmpty();
            clsResourceValues.CapacityTargets.ShouldNotBeNull();
            clsResourceValues.CapacityTargets.ShouldNotBeEmpty();
            clsResourceValues.CapacityTargetValues.ShouldNotBeNull();
            clsResourceValues.CapacityTargetValues.ShouldNotBeEmpty();
            clsResourceValues.TargetColors.ShouldNotBeNull();
            clsResourceValues.TargetColors.ShouldNotBeEmpty();
            clsResourceValues.PlanFields.ShouldNotBeNull();
            clsResourceValues.PlanFields.ShouldNotBeEmpty();
            clsResourceValues.PIFields.ShouldNotBeNull();
            clsResourceValues.PIFields.ShouldNotBeEmpty();
            clsResourceValues.ResFields.ShouldNotBeNull();
            clsResourceValues.ResFields.ShouldNotBeEmpty();
            clsResourceValues.Lookups.ShouldNotBeNull();
            clsResourceValues.Lookups.ShouldNotBeEmpty();
            clsResourceValues.FTEConvData.ShouldNotBeNull();
            clsResourceValues.FTEConvData.ShouldNotBeEmpty();
            clsResourceValues.UserDepartments.ShouldNotBeNull();
            clsResourceValues.UserDepartments.ShouldNotBeEmpty();
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
    }
}
