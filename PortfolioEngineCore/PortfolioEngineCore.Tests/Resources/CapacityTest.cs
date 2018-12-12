//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient.Fakes;
//using System.Diagnostics.CodeAnalysis;
//using System.Fakes;
//using System.Text;
//using System.Xml;
//using Microsoft.QualityTools.Testing.Fakes;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PortfolioEngineCore.Fakes;
//using Shouldly;

//namespace PortfolioEngineCore.Tests.Resources
//{
//    /// <summary>
//    /// Unit Tests for <see cref="PortfolioEngineCore.Capacity"/>
//    /// </summary>
//    [TestClass, ExcludeFromCodeCoverage]
//    public class CapacityTest
//    {
//        private const int DummyInt = 1;
//        private const string DummyString = "DummyString";
//        private PrivateType _privateType;
//        private PrivateObject _privateObject;
//        private Capacity _testEntity;
//        private IDisposable _shimsContext;
//        private readonly StringBuilder query = new StringBuilder();
//        private int currentDataReaderCount;
//        private int maxDatareaderCount;
//        private int DataReaderResult = 0;
//        private int prdID = 0;
//        private int fieldID = 9299;

//        //Function Names
//        private const string ProcessPeriods = "ProcessPeriods";
//        private const string SelectMyDepts = "SelectMyDepts";
//        private const string SelectResourcesFromTicket = "SelectResourcesFromTicket";
//        private const string SelectMyResources = "SelectMyResources";
//        private const string AddCustomFieldLookup = "AddCustomFieldLookup";
//        private const string SelectMyProjects = "SelectMyProjects";
//        private const string GetSuperPM = "GetSuperPM";
//        private const string RemovePlanRowsWOHours = "RemovePlanRowsWOHours";
//        private const string AddCustomField = "AddCustomField";
//        private const string GetSuperRM = "GetSuperRM";
//        private const string MakeListFromCollection = "MakeListFromCollection";
//        private const string MapToPeriod = "MapToPeriod";
//        private const string SetParentUIDs = "SetParentUIDs";
//        private const string GetFTEValue = "GetFTEValue";
//        private const string GetFTEConv = "GetFTEConv";
//        private const string GetBCUID = "GetBCUID";

//        [TestInitialize]
//        public void SetUp()
//        {
//            _shimsContext = ShimsContext.Create();

//            InitShims();
//            query.Clear();
//            maxDatareaderCount = 1;
//            currentDataReaderCount = 0;

//            _testEntity = new Capacity(
//                DummyString,
//                DummyString,
//                DummyString,
//                DummyString,
//                DummyString,
//                SecurityLevels.AdminCalc);
//            _privateObject = new PrivateObject(_testEntity);
//            _privateType = new PrivateType(typeof(Capacity));
//        }

//        [TestCleanup]
//        public void TearDown()
//        {
//            _shimsContext?.Dispose();
//        }

//        [TestMethod]
//        public void GetRVInfo_ParametersGiven_CheckBehaviour()
//        {
//            // Arrange
//            string sParmXML = $@"<dummy>
//                                    <CalID>-1</CalID>
//                                    <StartPeriodID>1</StartPeriodID>
//                                    <FinishPeriodID>10</FinishPeriodID>
//                                    <RequestNo>{DummyInt}</RequestNo>
//                                    <Depts>
//                                        <Dept ID='{DummyInt}'></Dept>
//                                    </Depts>
//                                    <PIs>
//                                        <PI ID='{DummyInt}'></PI>
//                                    </PIs>
//                                    <Resources>
//                                        <Resource ID='{DummyInt}'></Resource>
//                                    </Resources>
//                                </dummy>";
//            var xmlDocument = new XmlDocument();
//            xmlDocument.LoadXml(sParmXML);
//            sParmXML = xmlDocument.InnerXml;
//            string sReplyXML = string.Empty;
//            string sResult = string.Empty;
//            maxDatareaderCount = 10;
//            var expectedReplyXML = "<ResourceValues><Options><CalendarID>8</CalendarID><PlanningCalendarID>4</PlanningCalendarID><FromPeriodID>9</FromPeriodID><ToPeriodID>10</ToPeriodID><gpPMOAdmin>1</gpPMOAdmin><CommitmentsOpMode>5</CommitmentsOpMode><RequestNo>1</RequestNo><RoleFieldID>2</RoleFieldID><MajorCategoryFieldID>3</MajorCategoryFieldID><CalendarName>11</CalendarName></Options><CostCategories><Cat UID=\"72\" MC=\"74\" CC=\"75\" ID=\"76\" LVL=\"77\" Role=\"73\" PID=\"0\" Name=\"78\" FName=\"\" RName=\"79\" /><Cat UID=\"80\" MC=\"82\" CC=\"83\" ID=\"84\" LVL=\"85\" Role=\"81\" PID=\"0\" Name=\"86\" FName=\"\" RName=\"87\" /><Cat UID=\"88\" MC=\"90\" CC=\"91\" ID=\"92\" LVL=\"93\" Role=\"89\" PID=\"0\" Name=\"94\" FName=\"\" RName=\"95\" /><Cat UID=\"96\" MC=\"98\" CC=\"99\" ID=\"100\" LVL=\"101\" Role=\"97\" PID=\"0\" Name=\"102\" FName=\"\" RName=\"103\" /><Cat UID=\"104\" MC=\"106\" CC=\"107\" ID=\"108\" LVL=\"109\" Role=\"105\" PID=\"0\" Name=\"110\" FName=\"\" RName=\"111\" /><Cat UID=\"112\" MC=\"114\" CC=\"115\" ID=\"116\" LVL=\"117\" Role=\"113\" PID=\"0\" Name=\"118\" FName=\"\" RName=\"119\" /><Cat UID=\"120\" MC=\"122\" CC=\"123\" ID=\"124\" LVL=\"125\" Role=\"121\" PID=\"0\" Name=\"126\" FName=\"\" RName=\"127\" /><Cat UID=\"128\" MC=\"130\" CC=\"131\" ID=\"132\" LVL=\"133\" Role=\"129\" PID=\"0\" Name=\"134\" FName=\"\" RName=\"135\" /><Cat UID=\"136\" MC=\"138\" CC=\"139\" ID=\"140\" LVL=\"141\" Role=\"137\" PID=\"0\" Name=\"142\" FName=\"\" RName=\"143\" /><Cat UID=\"144\" MC=\"146\" CC=\"147\" ID=\"148\" LVL=\"149\" Role=\"145\" PID=\"0\" Name=\"150\" FName=\"\" RName=\"151\" /></CostCategories><Periods><PD ID=\"0\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"13\" /><PD ID=\"1\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"17\" /><PD ID=\"2\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"21\" /><PD ID=\"3\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"25\" /><PD ID=\"4\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"29\" /><PD ID=\"5\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"33\" /><PD ID=\"6\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"37\" /><PD ID=\"7\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"41\" /><PD ID=\"8\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"45\" /><PD ID=\"9\" St=\"2010-10-10T10:10:10\" End=\"2010-10-10T10:10:10\" Name=\"49\" /></Periods><Depts><Dept ID=\"862\" Name=\"863\" Desc=\"\" /><Dept ID=\"864\" Name=\"865\" Desc=\"\" /><Dept ID=\"866\" Name=\"867\" Desc=\"\" /><Dept ID=\"868\" Name=\"869\" Desc=\"\" /><Dept ID=\"870\" Name=\"871\" Desc=\"\" /><Dept ID=\"872\" Name=\"873\" Desc=\"\" /><Dept ID=\"874\" Name=\"875\" Desc=\"\" /><Dept ID=\"876\" Name=\"877\" Desc=\"\" /><Dept ID=\"878\" Name=\"879\" Desc=\"\" /><Dept ID=\"880\" Name=\"881\" Desc=\"\" /></Depts><PIs><PI ProjID=\"682\" WProjID=\"683\" Name=\"684\" LP=\"\" IM=\"689\" SO=\"691\" Stage=\"690\" WSS=\"\" IMID=\"688\" Pri=\"687\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"692\" WProjID=\"693\" Name=\"694\" LP=\"\" IM=\"699\" SO=\"701\" Stage=\"700\" WSS=\"\" IMID=\"698\" Pri=\"697\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"702\" WProjID=\"703\" Name=\"704\" LP=\"\" IM=\"709\" SO=\"711\" Stage=\"710\" WSS=\"\" IMID=\"708\" Pri=\"707\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"712\" WProjID=\"713\" Name=\"714\" LP=\"\" IM=\"719\" SO=\"721\" Stage=\"720\" WSS=\"\" IMID=\"718\" Pri=\"717\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"722\" WProjID=\"723\" Name=\"724\" LP=\"\" IM=\"729\" SO=\"731\" Stage=\"730\" WSS=\"\" IMID=\"728\" Pri=\"727\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"732\" WProjID=\"733\" Name=\"734\" LP=\"\" IM=\"739\" SO=\"741\" Stage=\"740\" WSS=\"\" IMID=\"738\" Pri=\"737\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"742\" WProjID=\"743\" Name=\"744\" LP=\"\" IM=\"749\" SO=\"751\" Stage=\"750\" WSS=\"\" IMID=\"748\" Pri=\"747\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"752\" WProjID=\"753\" Name=\"754\" LP=\"\" IM=\"759\" SO=\"761\" Stage=\"760\" WSS=\"\" IMID=\"758\" Pri=\"757\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"762\" WProjID=\"763\" Name=\"764\" LP=\"\" IM=\"769\" SO=\"771\" Stage=\"770\" WSS=\"\" IMID=\"768\" Pri=\"767\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI><PI ProjID=\"772\" WProjID=\"773\" Name=\"774\" LP=\"\" IM=\"779\" SO=\"781\" Stage=\"780\" WSS=\"\" IMID=\"778\" Pri=\"777\" St=\"2010-10-10T10:10:10\" Fin=\"2010-10-10T10:10:10\"><CFs /></PI></PIs><Resources><Res ID=\"782\" Name=\"787\" DeptUID=\"786\" RoleUID=\"788\" RTUID=\"0\" BC_Role=\"789\" BC_CC=\"789\"><CFs /></Res><Res ID=\"790\" Name=\"795\" DeptUID=\"794\" RoleUID=\"796\" RTUID=\"0\" BC_Role=\"797\" BC_CC=\"797\"><CFs /></Res><Res ID=\"798\" Name=\"803\" DeptUID=\"802\" RoleUID=\"804\" RTUID=\"0\" BC_Role=\"805\" BC_CC=\"805\"><CFs /></Res><Res ID=\"806\" Name=\"811\" DeptUID=\"810\" RoleUID=\"812\" RTUID=\"0\" BC_Role=\"813\" BC_CC=\"813\"><CFs /></Res><Res ID=\"814\" Name=\"819\" DeptUID=\"818\" RoleUID=\"820\" RTUID=\"0\" BC_Role=\"821\" BC_CC=\"821\"><CFs /></Res><Res ID=\"822\" Name=\"827\" DeptUID=\"826\" RoleUID=\"828\" RTUID=\"0\" BC_Role=\"829\" BC_CC=\"829\"><CFs /></Res><Res ID=\"830\" Name=\"835\" DeptUID=\"834\" RoleUID=\"836\" RTUID=\"0\" BC_Role=\"837\" BC_CC=\"837\"><CFs /></Res><Res ID=\"838\" Name=\"843\" DeptUID=\"842\" RoleUID=\"844\" RTUID=\"0\" BC_Role=\"845\" BC_CC=\"845\"><CFs /></Res><Res ID=\"846\" Name=\"851\" DeptUID=\"850\" RoleUID=\"852\" RTUID=\"0\" BC_Role=\"853\" BC_CC=\"853\"><CFs /></Res><Res ID=\"854\" Name=\"859\" DeptUID=\"858\" RoleUID=\"860\" RTUID=\"0\" BC_Role=\"861\" BC_CC=\"861\"><CFs /></Res></Resources><Roles><Role ID=\"972\" Name=\"973\" /><Role ID=\"974\" Name=\"975\" /><Role ID=\"976\" Name=\"977\" /><Role ID=\"978\" Name=\"979\" /><Role ID=\"980\" Name=\"981\" /><Role ID=\"982\" Name=\"983\" /><Role ID=\"984\" Name=\"985\" /><Role ID=\"986\" Name=\"987\" /><Role ID=\"988\" Name=\"989\" /><Role ID=\"990\" Name=\"991\" /></Roles><Cmts /><CHs><CH UID=\"512\" PD=\"0\" FTES=\"0\" Hrs=\"5.14\" /><CH UID=\"515\" PD=\"0\" FTES=\"0\" Hrs=\"5.17\" /><CH UID=\"518\" PD=\"0\" FTES=\"0\" Hrs=\"5.2\" /><CH UID=\"521\" PD=\"0\" FTES=\"0\" Hrs=\"5.23\" /><CH UID=\"524\" PD=\"0\" FTES=\"0\" Hrs=\"5.26\" /><CH UID=\"527\" PD=\"0\" FTES=\"0\" Hrs=\"5.29\" /><CH UID=\"530\" PD=\"0\" FTES=\"0\" Hrs=\"5.32\" /><CH UID=\"533\" PD=\"0\" FTES=\"0\" Hrs=\"5.35\" /><CH UID=\"536\" PD=\"0\" FTES=\"0\" Hrs=\"5.38\" /><CH UID=\"539\" PD=\"0\" FTES=\"0\" Hrs=\"5.41\" /></CHs><OReqts /><ORs /><SWs /><ActWs><ActW ProjID=\"632\" WresID=\"633\" PD=\"30\" MC=\"634\" FTES=\"-1\" Hrs=\"6.36\" /><ActW ProjID=\"637\" WresID=\"638\" PD=\"31\" MC=\"639\" FTES=\"-1\" Hrs=\"6.41\" /><ActW ProjID=\"642\" WresID=\"643\" PD=\"32\" MC=\"644\" FTES=\"-1\" Hrs=\"6.46\" /><ActW ProjID=\"647\" WresID=\"648\" PD=\"33\" MC=\"649\" FTES=\"-1\" Hrs=\"6.51\" /><ActW ProjID=\"652\" WresID=\"653\" PD=\"34\" MC=\"654\" FTES=\"-1\" Hrs=\"6.56\" /><ActW ProjID=\"657\" WresID=\"658\" PD=\"35\" MC=\"659\" FTES=\"-1\" Hrs=\"6.61\" /><ActW ProjID=\"662\" WresID=\"663\" PD=\"36\" MC=\"664\" FTES=\"-1\" Hrs=\"6.66\" /><ActW ProjID=\"667\" WresID=\"668\" PD=\"37\" MC=\"669\" FTES=\"-1\" Hrs=\"6.71\" /><ActW ProjID=\"672\" WresID=\"673\" PD=\"38\" MC=\"674\" FTES=\"-1\" Hrs=\"6.76\" /><ActW ProjID=\"677\" WresID=\"678\" PD=\"39\" MC=\"679\" FTES=\"-1\" Hrs=\"6.81\" /></ActWs><NWs><NW ID=\"999999\" Name=\"No Assigned Work\" /><NW ID=\"1032\" Name=\"1033\" /><NW ID=\"1034\" Name=\"1035\" /><NW ID=\"1036\" Name=\"1037\" /><NW ID=\"1038\" Name=\"1039\" /><NW ID=\"1040\" Name=\"1041\" /><NW ID=\"1042\" Name=\"1043\" /><NW ID=\"1044\" Name=\"1045\" /><NW ID=\"1046\" Name=\"1047\" /><NW ID=\"1048\" Name=\"1049\" /><NW ID=\"1050\" Name=\"1051\" /></NWs><NWHs><NWH UID=\"992\" WresID=\"993\" PD=\"40\" FTES=\"0\" Hrs=\"995\" /><NWH UID=\"996\" WresID=\"997\" PD=\"41\" FTES=\"0\" Hrs=\"999\" /><NWH UID=\"1000\" WresID=\"1001\" PD=\"42\" FTES=\"0\" Hrs=\"1003\" /><NWH UID=\"1004\" WresID=\"1005\" PD=\"43\" FTES=\"0\" Hrs=\"1007\" /><NWH UID=\"1008\" WresID=\"1009\" PD=\"44\" FTES=\"0\" Hrs=\"1011\" /><NWH UID=\"1012\" WresID=\"1013\" PD=\"45\" FTES=\"0\" Hrs=\"1015\" /><NWH UID=\"1016\" WresID=\"1017\" PD=\"46\" FTES=\"0\" Hrs=\"1019\" /><NWH UID=\"1020\" WresID=\"1021\" PD=\"47\" FTES=\"0\" Hrs=\"1023\" /><NWH UID=\"1024\" WresID=\"1025\" PD=\"48\" FTES=\"0\" Hrs=\"1027\" /><NWH UID=\"1028\" WresID=\"1029\" PD=\"49\" FTES=\"0\" Hrs=\"1031\" /><NWH UID=\"999999\" WresID=\"542\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"543\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"544\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"545\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"546\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"547\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"548\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"549\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"550\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /><NWH UID=\"999999\" WresID=\"551\" PD=\"9\" FTES=\"0\" Hrs=\"0\" /></NWHs><RAVs /><Tgts><Tgt UID=\"884\" ID=\"882\" Flag=\"885\" Name=\"883\" /><Tgt UID=\"888\" ID=\"886\" Flag=\"889\" Name=\"887\" /><Tgt UID=\"892\" ID=\"890\" Flag=\"893\" Name=\"891\" /><Tgt UID=\"896\" ID=\"894\" Flag=\"897\" Name=\"895\" /><Tgt UID=\"900\" ID=\"898\" Flag=\"901\" Name=\"899\" /><Tgt UID=\"904\" ID=\"902\" Flag=\"905\" Name=\"903\" /><Tgt UID=\"908\" ID=\"906\" Flag=\"909\" Name=\"907\" /><Tgt UID=\"912\" ID=\"910\" Flag=\"913\" Name=\"911\" /><Tgt UID=\"916\" ID=\"914\" Flag=\"917\" Name=\"915\" /><Tgt UID=\"920\" ID=\"918\" Flag=\"921\" Name=\"919\" /></Tgts><TgtVs><TgtV ID=\"922\" PD=\"0\" DeptUID=\"924\" RoleUID=\"925\" FTES=\"-1\" Hrs=\"926\" /><TgtV ID=\"927\" PD=\"0\" DeptUID=\"929\" RoleUID=\"930\" FTES=\"-1\" Hrs=\"931\" /><TgtV ID=\"932\" PD=\"0\" DeptUID=\"934\" RoleUID=\"935\" FTES=\"-1\" Hrs=\"936\" /><TgtV ID=\"937\" PD=\"0\" DeptUID=\"939\" RoleUID=\"940\" FTES=\"-1\" Hrs=\"941\" /><TgtV ID=\"942\" PD=\"0\" DeptUID=\"944\" RoleUID=\"945\" FTES=\"-1\" Hrs=\"946\" /><TgtV ID=\"947\" PD=\"0\" DeptUID=\"949\" RoleUID=\"950\" FTES=\"-1\" Hrs=\"951\" /><TgtV ID=\"952\" PD=\"0\" DeptUID=\"954\" RoleUID=\"955\" FTES=\"-1\" Hrs=\"956\" /><TgtV ID=\"957\" PD=\"0\" DeptUID=\"959\" RoleUID=\"960\" FTES=\"-1\" Hrs=\"961\" /><TgtV ID=\"962\" PD=\"0\" DeptUID=\"964\" RoleUID=\"965\" FTES=\"-1\" Hrs=\"966\" /></TgtVs><TgtCs><TgtC ID=\"1072\" LV=\"1073\" HV=\"1074\" RGB=\"1075\" Desc=\"1076\" /><TgtC ID=\"1077\" LV=\"1078\" HV=\"1079\" RGB=\"1080\" Desc=\"1081\" /><TgtC ID=\"1082\" LV=\"1083\" HV=\"1084\" RGB=\"1085\" Desc=\"1086\" /><TgtC ID=\"1087\" LV=\"1088\" HV=\"1089\" RGB=\"1090\" Desc=\"1091\" /><TgtC ID=\"1092\" LV=\"1093\" HV=\"1094\" RGB=\"1095\" Desc=\"1096\" /><TgtC ID=\"1097\" LV=\"1098\" HV=\"1099\" RGB=\"1100\" Desc=\"1101\" /><TgtC ID=\"1102\" LV=\"1103\" HV=\"1104\" RGB=\"1105\" Desc=\"1106\" /><TgtC ID=\"1107\" LV=\"1108\" HV=\"1109\" RGB=\"1110\" Desc=\"1111\" /><TgtC ID=\"1112\" LV=\"1113\" HV=\"1114\" RGB=\"1115\" Desc=\"1116\" /><TgtC ID=\"1117\" LV=\"1118\" HV=\"1119\" RGB=\"1120\" Desc=\"1121\" /></TgtCs><RPFlds><RPFld ID=\"9299\" Type=\"9\" Name=\"183\" GivenName=\"182\" /><RPFld ID=\"9300\" Type=\"9\" Name=\"186\" GivenName=\"185\" /><RPFld ID=\"9301\" Type=\"9\" Name=\"189\" GivenName=\"188\" /><RPFld ID=\"9302\" Type=\"9\" Name=\"192\" GivenName=\"191\" /><RPFld ID=\"9303\" Type=\"9\" Name=\"195\" GivenName=\"194\" /><RPFld ID=\"9304\" Type=\"9\" Name=\"198\" GivenName=\"197\" /><RPFld ID=\"9305\" Type=\"4\" Name=\"201\" GivenName=\"200\" /><RPFld ID=\"9306\" Type=\"4\" Name=\"204\" GivenName=\"203\" /><RPFld ID=\"9307\" Type=\"4\" Name=\"207\" GivenName=\"206\" /><RPFld ID=\"9308\" Type=\"4\" Name=\"210\" GivenName=\"209\" /></RPFlds><PIFlds><PIFld ID=\"9309\" Type=\"216\" Name=\"\" GivenName=\"215\" /><PIFld ID=\"9310\" Type=\"222\" Name=\"\" GivenName=\"221\" /><PIFld ID=\"9299\" Type=\"228\" Name=\"\" GivenName=\"227\" /><PIFld ID=\"9300\" Type=\"234\" Name=\"\" GivenName=\"233\" /><PIFld ID=\"9301\" Type=\"240\" Name=\"\" GivenName=\"239\" /><PIFld ID=\"9302\" Type=\"246\" Name=\"\" GivenName=\"245\" /><PIFld ID=\"9303\" Type=\"252\" Name=\"\" GivenName=\"251\" /><PIFld ID=\"9304\" Type=\"258\" Name=\"\" GivenName=\"257\" /><PIFld ID=\"9305\" Type=\"264\" Name=\"\" GivenName=\"263\" /><PIFld ID=\"9306\" Type=\"270\" Name=\"\" GivenName=\"269\" /></PIFlds><ResFlds /><Lookups /><FTEConvs /><UserDepts /></ResourceValues>";

//            // Act
//            var result = _testEntity.GetRVInfo(sParmXML, out sReplyXML, out sResult);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => sReplyXML.ShouldBe(expectedReplyXML),
//                () => result.ShouldBe(0));
//        }

//        [TestMethod]
//        public void SelectMyDepts_SuperRMFalse_CheckBehaviour()
//        {
//            // Arrange
//            var reply = string.Empty;
//            var expectedReply = "<Depts />";
//            ShimCapacity.AllInstances.GetSuperRM = _ => false;

//            // Act
//            var result = _testEntity.SelectMyDepts(out reply);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => result.ShouldBe(0),
//                () => reply.ShouldBe(expectedReply));
//        }

//        [TestMethod]
//        public void SelectMyDepts_SuperRMTrue_CheckBehaviour()
//        {
//            // Arrange
//            var reply = string.Empty;
//            var expectedReply = "<Depts><Dept ID=\"2\" Name=\"4\" MgrName=\"5\" /></Depts>";
//            ShimCapacity.AllInstances.GetSuperRM = _ => true;

//            // Act
//            var result = _testEntity.SelectMyDepts(out reply);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => result.ShouldBe(0),
//                () => reply.ShouldBe(expectedReply));
//        }

//        [TestMethod]
//        public void SelectResourcesFromTicket_ResourceTicketValid_CheckBehaviour()
//        {
//            // Arrange
//            string sTicket = DummyString;
//            string sReply = string.Empty;
//            string sReplyMessage = string.Empty;

//            // Act
//            var result = _testEntity.SelectResourcesFromTicket(sTicket, out sReply, out sReplyMessage);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => sReply.ShouldBe("<Resources><Resource ID=\"3\" Name=\"4\" /></Resources>"),
//                () => sReplyMessage.ShouldBe(string.Empty),
//                () => result.ShouldBe(0));
//        }

//        [TestMethod]
//        public void SelectResourcesFromTicket_ResourceTicketNotValid_CheckBehaviour()
//        {
//            // Arrange
//            string sTicket = DummyString;
//            string sReply = string.Empty;
//            string sReplyMessage = string.Empty;
//            ShimSqlCommand.AllInstances.ExecuteReader = command =>
//            {
//                query.AppendLine(command.CommandText);
//                return new ShimSqlDataReader()
//                {
//                    Close = () => currentDataReaderCount = 0,
//                    Read = () =>
//                    {
//                        currentDataReaderCount++;
//                        return currentDataReaderCount <= maxDatareaderCount;
//                    },
//                    GetSqlInt32Int32 = indx => DummyInt,
//                    ItemGetString = key =>
//                    {
//                        DataReaderResult++;
//                        if (key == "DC_DATA")
//                        {
//                            return DummyString;
//                        }
//                        return DataReaderResult;
//                    },
//                }.Instance;
//            };

//            // Act
//            var result = _testEntity.SelectResourcesFromTicket(sTicket, out sReply, out sReplyMessage);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => sReply.ShouldBe("<PIs><PI ID=\"3\" Name=\"4\" /></PIs>"),
//                () => sReplyMessage.ShouldBe(string.Empty),
//                () => result.ShouldBe(0));
//        }

//        [TestMethod]
//        public void SelectMyResources_ParametersGiven_CheckBehaviour()
//        {
//            // Arrange
//            var sReply = string.Empty;

//            // Act
//            var result = _testEntity.SelectMyResources(out sReply);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => sReply.ShouldBe("<Resources><Resource ID=\"6\" ExtID=\"7\" Name=\"8\" /></Resources>"),
//                () => result.ShouldBe(0));
//        }

//        [TestMethod]
//        public void AddCustomFieldLookup_LookupIDZero_CheckBehaviour()
//        {
//            // Arrange
//            var parameters = new object[] 
//            {
//                new ShimDBAccess().Instance,
//                new Dictionary<int, ResourceValues.clsLookupList>(),
//                DummyInt,
//                0
//            };
//            ShimCapacity.AddCustomFieldLookupDBAccessDictionaryOfInt32clsLookupListInt32Int32 = null;
            
//            // Act
//            var result = _privateType.InvokeStatic(
//                AddCustomFieldLookup,
//                parameters);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => query.ToString().ShouldContain("EPG_SP_ReadFieldInfo"),
//                () => query.ToString().ShouldContain("EPG_SP_ReadListItems"),
//                () => result.ShouldBe(StatusEnum.rsSuccess));
//        }

//        [TestMethod]
//        public void SelectMyProjects_ParametersGiven_CheckBehaviour()
//        {
//            // Arrange
//            string reply = string.Empty;
//            string expectedReply = "<Projects><Project ID=\"2\" Name=\"3\" /></Projects>";

//            // Act
//            var result = _testEntity.SelectMyProjects(out reply);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => reply.ShouldBe(expectedReply),
//                () => result.ShouldBe(0));
//        }

//        [TestMethod]
//        public void GetSuperPM_EmptyInput_CheckBehaviour()
//        {
//            // Arrange
//            var parameters = new object[] { };
//            _privateObject.SetFieldOrProperty("_userWResID", 0);

//            // Act
//            var result = (bool)_privateObject.Invoke(
//                GetSuperPM,
//                parameters);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => query.ToString().ShouldContain("EPG_SP_CheckUserGlobalPermission"),
//                () => result.ShouldBeTrue());
//        }

//        [TestMethod]
//        public void AddCustomField_ParametersGiven_CheckBehaviour()
//        {
//            // Arrange
//            var customfields = new List<string>();
//            var sqlDataReader = new ShimSqlDataReader()
//            {
//                ItemGetString = key => DateTime.Now,
//            }.Instance;
//            var parameters = new object[] { customfields, DummyInt, 1, sqlDataReader, DummyString };

//            // Act
//            var result = _privateType.InvokeStatic(
//                AddCustomField,
//                parameters);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => customfields.ShouldNotBeEmpty(),
//                () => customfields.Count.ShouldBe(1),
//                () => customfields[0].ShouldBe("1 10 2010-10-10"));
//        }

//        [TestMethod]
//        public void GetSuperRM_EmptyInput_CheckBehaviour()
//        {
//            // Arrange
//            var parameters = new object[] { };
//            _privateObject.SetFieldOrProperty("_userWResID", 0);

//            // Act
//            var result = (bool)_privateObject.Invoke(
//                GetSuperRM,
//                parameters);

//            // Assert
//            this.ShouldSatisfyAllConditions(
//                () => query.ToString().ShouldContain("EPG_SP_CheckUserGlobalPermission"),
//                () => result.ShouldBeTrue());
//        }
        
//        private void InitShims()
//        {
//            ShimCapacity.AddCustomFieldLookupDBAccessDictionaryOfInt32clsLookupListInt32Int32 = (_, _1, _2, _3) =>
//            {
//                return StatusEnum.rsSuccess;
//            };
//            ShimResourcePlans.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
//            {
//                clnPeriods = new List<CPeriod>()
//                {
//                    new CPeriod()
//                    {
//                        PeriodID = 2,
//                    }
//                };
//                return StatusEnum.rsSuccess;
//            };
//            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
//            {
//                clnPeriods = new List<CPeriod>();
//                return StatusEnum.rsSuccess;
//            };
//            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
//            SetupSqlShims();
//        }

//        private void ShimsForGetResourcePlanStructTestMethods()
//        {
//            maxDatareaderCount = 10;
//            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string sTicket, out string sReply) =>
//            {
//                sReply = DummyString;
//                return true;
//            };
//            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
//            {
//                clnPeriods = new List<CPeriod>()
//                {
//                    new CPeriod()
//                    {
//                        PeriodID = 2,
//                    },
//                };
//                return StatusEnum.rsSuccess;
//            };
//            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out CStruct xCostCategoryRolesOut, bool bGetAll) =>
//            {
//                xCostCategoryRolesOut = new CStruct();
//                xCostCategoryRolesOut.LoadXML($"<{DummyString}></{DummyString}>");
//                return StatusEnum.rsSuccess;
//            };
//        }

//        private void SetupSqlShims()
//        {
//            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
//            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
//            ShimSqlConnection.ConstructorString = (_, _1) => { };
//            ShimSqlConnection.AllInstances.Open = _ => { };
//            ShimSqlConnection.AllInstances.Close = _ => { };
//            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
//            {
//                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
//                {
//                    return true;
//                }
//                return DummyInt;
//            };
//            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
//            {
//                query.Append("\n" + command.CommandText);
//                return DummyInt;
//            };
//            ShimSqlCommand.AllInstances.ExecuteReader = command =>
//            {
//                query.AppendLine(command.CommandText);
//                return new ShimSqlDataReader()
//                {
//                    Close = () => currentDataReaderCount = 0,
//                    Read = () =>
//                    {
//                        currentDataReaderCount++;
//                        return currentDataReaderCount <= maxDatareaderCount;
//                    },
//                    GetSqlInt32Int32 = indx => DummyInt,
//                    ItemGetString = key =>
//                    {
//                        DataReaderResult++;
//                        if (key.ToLower().Contains("date") || key.ToLower().Contains("timestamp"))
//                        {
//                            return DateTime.Now;
//                        }
//                        else if (key == "VIEW_DATA")
//                        {
//                            return "<Dummy></Dummy>";
//                        }
//                        else if (key == "PRD_ID")
//                        {
//                            var result = prdID;
//                            prdID++;
//                            return result;
//                        }
//                        else if (key == "FIELD_ID")
//                        {
//                            var result = fieldID;
//                            fieldID++;
//                            if (fieldID > 9299 + 11)
//                            {
//                                fieldID = 9299;
//                            }
//                            return result;
//                        }
//                        return DataReaderResult;
//                    },
//                }.Instance;
//            };
//        }

//        private List<Action> AssertQueries(string[] expectedQueries)
//        {
//            var assertions = new List<Action>();
//            foreach (var expectedQuery in expectedQueries)
//            {
//                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
//            }
//            return assertions;
//        }
//    }
//}
