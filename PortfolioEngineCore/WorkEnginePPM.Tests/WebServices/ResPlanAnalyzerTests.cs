using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using RPADataCache;
using RPADataCache.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResPlanAnalyzerTests
    {
        private IDisposable _shimContext;

        private const string DummyUser = "DummyUser";
        private const string DummyBaseInfo = "DummyBaseInfo";
        private const string DummyConnectionString = "DummyConnectionString";
        private const string DummyReplyMessage = "DummyReplyMessage";
        private const string DummyReply = "DummyReply";
        private const string DummyViewValue = "DummyViewValue";
        private const string DummyTicket = "DummyTicket";

        private const string ExpectedRaLoadDataException = "<Result Context=\"ResPlanAnalyzer.RALoadData at\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in ResPlanAnalyzer.asmx (O011): 'Exception of type 'System.Exception' was thrown.'\" /></Result>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => Guid.NewGuid()
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = webParam => DummyUser;

            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut =
                (HttpContext contextParam, out string stage) =>
                {
                    stage = string.Empty;
                    return true;
                };
            ShimWebAdmin.GetConnectionStringHttpContext = contextParam => DummyConnectionString;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void RaLoadData_SetResourceAnalyzerUserCalendarFalse_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => false
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                "<Result Context=\"RALoadData\" Status=\"0\">",
                "<Error ID=\"100\" Value=\"\" />",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"\" />",
                "<FromResGrid Value=\"0\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"\" />",
                "<gpPMOAdmin Value=\"\" />",
                "<LoadingDataReply Value=\"\" />",
                $"<TicketValue Value=\"{DummyTicket}\" />",
                "<TicketReturns Value=\"\" />",
                "<DetailsLoaded Value=\"0\" />",
                "<PeriodRange Start=\"0\" Finish=\"0\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"0\" />"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_SetResourceAnalyzerUserCalendarThrowsException_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) =>
                    {
                        throw new Exception();
                    }
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            actualResult.ShouldBe(ExpectedRaLoadDataException);
        }

        [TestMethod]
        public void RaLoadData_SelectResourcesFromTicketFail_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);
            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => true,
                GetSuperRM = () => true,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = DummyReply;
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSecurityAccessDenied;
                    }
            };

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                $"<Error Value=\"Failed to decode ticket - {DummyReplyMessage}\" />",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"\" />",
                "<FromResGrid Value=\"0\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"\" />",
                "<gpPMOAdmin Value=\"\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}\" />",
                $"<TicketValue Value=\"{DummyTicket}\" />",
                $"<TicketReturns Value=\"{DummyReply}\" />",
                "<DetailsLoaded Value=\"0\" />",
                "<PeriodRange Start=\"0\" Finish=\"0\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"0\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_GetRVInfoFail_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);
            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => true,
                GetSuperRM = () => false,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = CreateResourcesXml();
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSuccess;
                    },
                SelectMyResourcesStringOut = (out string resourceXml) =>
                {
                    resourceXml = CreateMyResourcesXml();
                    return 0;
                },
                GetRVInfoStringStringOutStringOut = (string paramXml, out string replyXml, out string result) =>
                {
                    replyXml = string.Empty;
                    result = string.Empty;

                    return (int)StatusEnum.rsSecurityAccessDenied;
                }
            };

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                $"<Error Value=\"{DummyReplyMessage}&#xA;You do not have access to these resources: &#xA;ResourceName300,ResourceName310,ResourceName320,ResourceName330,ResourceName340,...&#xA;\" />",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"\" />",
                "<FromResGrid Value=\"1\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"\" />",
                "<gpPMOAdmin Value=\"\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}&#xA;You do not have access to these resources: &#xA;ResourceName300,ResourceName310,ResourceName320,ResourceName330,ResourceName340,...\" />",
                $"<TicketValue Value=\"{DummyTicket}\" />",
                "<TicketReturns Value=\"&lt;Data&gt;&lt;Resource ID=&quot;100&quot;/&gt;&lt;",
                "Resource ID=&quot;300&quot; Name=&quot;ResourceName300&quot;/&gt;&lt;Resource ID=&quot;310&quot; Name=&quot;ResourceName310&quot;/&gt;&lt;",
                "Resource ID=&quot;320&quot; Name=&quot;ResourceName320&quot;/&gt;&lt;Resource ID=&quot;330&quot; Name=&quot;ResourceName330&quot;/&gt;&lt;",
                "Resource ID=&quot;340&quot; Name=&quot;ResourceName340&quot;/&gt;&lt;Resource ID=&quot;350&quot; Name=&quot;ResourceName350&quot;/&gt;&lt;",
                "Resource ID=&quot;360&quot; Name=&quot;ResourceName360&quot;/&gt;&lt;/Data&gt;\" />",
                "<DetailsLoaded Value=\"0\" />",
                "<PeriodRange Start=\"0\" Finish=\"0\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"0\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_GetRVInfoReplyEmpty_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);
            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => true,
                GetSuperRM = () => false,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = CreateResourcesXml();
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSuccess;
                    },
                SelectMyResourcesStringOut = (out string resourceXml) =>
                {
                    resourceXml = CreateMyResourcesXml();
                    return 0;
                },
                GetRVInfoStringStringOutStringOut = (string paramXml, out string replyXml, out string replyMessage) =>
                {
                    replyXml = string.Empty;
                    replyMessage = DummyReplyMessage;

                    return (int)StatusEnum.rsSuccess;
                }
            };

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                "<Error Value=\"Loading Data failed\" />",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"\" />",
                "<FromResGrid Value=\"1\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"\" />",
                "<gpPMOAdmin Value=\"\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}&#xA;You do not have access to these resources: &#xA;ResourceName300,ResourceName310,ResourceName320,ResourceName330,ResourceName340,...&#xA;{DummyReplyMessage}\" />",
                $"<TicketValue Value=\"{DummyTicket}\" />",
                "<TicketReturns Value=\"&lt;Data&gt;&lt;Resource ID=&quot;100&quot;/&gt;&lt;",
                "Resource ID=&quot;300&quot; Name=&quot;ResourceName300&quot;/&gt;&lt;Resource ID=&quot;310&quot; Name=&quot;ResourceName310&quot;/&gt;&lt;",
                "Resource ID=&quot;320&quot; Name=&quot;ResourceName320&quot;/&gt;&lt;Resource ID=&quot;330&quot; Name=&quot;ResourceName330&quot;/&gt;&lt;",
                "Resource ID=&quot;340&quot; Name=&quot;ResourceName340&quot;/&gt;&lt;Resource ID=&quot;350&quot; Name=&quot;ResourceName350&quot;/&gt;&lt;",
                "Resource ID=&quot;360&quot; Name=&quot;ResourceName360&quot;/&gt;&lt;/Data&gt;\" />",
                "<DetailsLoaded Value=\"0\" />",
                "<PeriodRange Start=\"0\" Finish=\"0\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"0\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_GetRVInfoReplyFilled_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true,
                    GetResourceAnalyzerViewsXMLStringOut = (out string viewsParam) =>
                    {
                        viewsParam = string.Empty;
                        return false;
                    }
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);
            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => true,
                GetSuperRM = () => false,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = CreateResourcesXml();
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSuccess;
                    },
                SelectMyResourcesStringOut = (out string resourceXml) =>
                {
                    resourceXml = CreateMyResourcesXml();
                    return 0;
                },
                GetRVInfoStringStringOutStringOut = (string paramXml, out string replyXml, out string replyMessage) =>
                {
                    replyXml = @"
<Data>
<Options CalendarID=""400"" PlanningCalendarID=""401"" FromPeriodID=""402"" 
         ToPeriodID=""403"" gpPMOAdmin=""404""  CommitmentsOpMode=""405"" 
         RequestNo=""406"" RoleFieldID=""407"" MajorCategoryFieldID=""408"" CalendarName=""409"" />
</Data>
";
                    replyMessage = DummyReplyMessage;

                    return (int)StatusEnum.rsSuccess;
                }
            };
            ShimRPAData.AllInstances.PopulateInternalsStringOut = (RPAData sender, out string log) => log = string.Empty;
            ShimRPAData.AllInstances.DoUserDepts = sender => { };
            ShimRPAData.AllInstances.setupdispcolnsStringOut = (RPAData sender, out string log) => log = string.Empty;
            ShimRPAData.AllInstances.ReDrawGrid = sender => { };
            ShimRPAData.AllInstances.GetTargetRGBData = sender => string.Empty;
            ShimRPAData.AllInstances.GetTotalsDataBoolean = (sender, retColumnData) => string.Empty;
            ShimRPAData.AllInstances.GetRawDataCount = sender => 1000;

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(string.Empty);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                "<Result Context=\"GetResourceValues\" Status=\"0\">",
                "<Error ID=\"100\" Value=\"\" />",
                "</Result>",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"&lt;WorkDetails&gt;&lt;ActualWork Value=&quot;0&quot; /&gt;&lt;ProposedWork Value=&quot;1&quot; ",
                "/&gt;&lt;ScheduledWork Value=&quot;0&quot; /&gt;&lt;CommittedWork Value=&quot;1&quot; /&gt;&lt;PersonalWork Value=&quot;0&quot; ",
                "/&gt;&lt;OpenRequestWork Value=&quot;0&quot; /&gt;&lt;NegMode Value=&quot;0&quot; /&gt;&lt;ShowPersonal Value=&quot;1&quot; ",
                "/&gt;&lt;ShowOpenReq Value=&quot;0&quot; /&gt;&lt;/WorkDetails&gt;\">",
                "<WorkDetails>",
                "<ActualWork Value=\"0\" />",
                "<ProposedWork Value=\"1\" />",
                "<ScheduledWork Value=\"0\" />",
                "<CommittedWork Value=\"1\" />",
                "<PersonalWork Value=\"0\" />",
                "<OpenRequestWork Value=\"0\" />",
                "<NegMode Value=\"0\" />",
                "<ShowPersonal Value=\"1\" />",
                "<ShowOpenReq Value=\"0\" />",
                "</WorkDetails>",
                "</DetailsConfiguration>",
                "<FromResGrid Value=\"1\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"&lt;WorkDisplayMode Mode=&quot;1&quot; /&gt;\" />",
                "<gpPMOAdmin Value=\"0\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}&#xA;You do not have access to these resources: &#xA;ResourceName300,ResourceName310,ResourceName320,ResourceName330,ResourceName340,...&#xA;{DummyReplyMessage}\" />",
                "<TicketValue Value=\"A6CD298B-BAB7-4459-99DD-05C0F7A3C3D3\" />",
                "<TicketReturns Value=\"&lt;Data&gt;&lt;Resource ID=&quot;100&quot;/&gt;&lt;",
                "Resource ID=&quot;300&quot; Name=&quot;ResourceName300&quot;/&gt;&lt;Resource ID=&quot;310&quot; Name=&quot;ResourceName310&quot;/&gt;&lt;",
                "Resource ID=&quot;320&quot; Name=&quot;ResourceName320&quot;/&gt;&lt;Resource ID=&quot;330&quot; Name=&quot;ResourceName330&quot;/&gt;&lt;",
                "Resource ID=&quot;340&quot; Name=&quot;ResourceName340&quot;/&gt;&lt;Resource ID=&quot;350&quot; Name=&quot;ResourceName350&quot;/&gt;&lt;",
                "Resource ID=&quot;360&quot; Name=&quot;ResourceName360&quot;/&gt;&lt;/Data&gt;\" />",
                "<DetailsLoaded Value=\"1000\" />",
                "<PeriodRange Start=\"0\" Finish=\"1\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"1\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_GetRVInfoReplyFilledViewHasValue_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true,
                    GetResourceAnalyzerViewsXMLStringOut = (out string viewsParam) =>
                    {
                        viewsParam = DummyViewValue;
                        return false;
                    }
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);

            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => true,
                GetSuperRM = () => false,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = CreateResourcesXml();
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSuccess;
                    },
                SelectMyResourcesStringOut = (out string resourceXml) =>
                {
                    resourceXml = CreateMyResourcesXml();
                    return 0;
                },
                GetRVInfoStringStringOutStringOut = (string paramXml, out string replyXml, out string replyMessage) =>
                {
                    replyXml = @"
<Data>
<Options CalendarID=""400"" PlanningCalendarID=""401"" FromPeriodID=""402"" 
         ToPeriodID=""403"" gpPMOAdmin=""404""  CommitmentsOpMode=""405"" 
         RequestNo=""406"" RoleFieldID=""407"" MajorCategoryFieldID=""408"" CalendarName=""409"" />
</Data>
";
                    replyMessage = DummyReplyMessage;

                    return (int)StatusEnum.rsSuccess;
                }
            };

            ShimRPAData.AllInstances.PopulateInternalsStringOut = (RPAData sender, out string log) => log = string.Empty;
            ShimRPAData.AllInstances.DoUserDepts = sender => { };
            ShimRPAData.AllInstances.setupdispcolnsStringOut = (RPAData sender, out string log) => log = string.Empty;
            ShimRPAData.AllInstances.ReDrawGrid = sender => { };
            ShimRPAData.AllInstances.GetTargetRGBData = sender => string.Empty;
            ShimRPAData.AllInstances.GetTotalsDataBoolean = (sender, retColumnData) => string.Empty;
            ShimRPAData.AllInstances.GetRawDataCount = sender => 1000;

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(string.Empty);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                "<Result Context=\"GetResourceValues\" Status=\"0\">",
                "<Error ID=\"100\" Value=\"\" />",
                "</Result>",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"&lt;WorkDetails&gt;&lt;ActualWork Value=&quot;0&quot; /&gt;&lt;ProposedWork Value=&quot;1&quot; ",
                "/&gt;&lt;ScheduledWork Value=&quot;0&quot; /&gt;&lt;CommittedWork Value=&quot;1&quot; /&gt;&lt;PersonalWork Value=&quot;0&quot; ",
                "/&gt;&lt;OpenRequestWork Value=&quot;0&quot; /&gt;&lt;NegMode Value=&quot;0&quot; /&gt;&lt;ShowPersonal Value=&quot;1&quot; ",
                "/&gt;&lt;ShowOpenReq Value=&quot;0&quot; /&gt;&lt;/WorkDetails&gt;\">",
                "<WorkDetails>",
                "<ActualWork Value=\"0\" />",
                "<ProposedWork Value=\"1\" />",
                "<ScheduledWork Value=\"0\" />",
                "<CommittedWork Value=\"1\" />",
                "<PersonalWork Value=\"0\" />",
                "<OpenRequestWork Value=\"0\" />",
                "<NegMode Value=\"0\" />",
                "<ShowPersonal Value=\"1\" />",
                "<ShowOpenReq Value=\"0\" />",
                "</WorkDetails>",
                "</DetailsConfiguration>",
                "<FromResGrid Value=\"1\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"&lt;WorkDisplayMode Mode=&quot;1&quot; /&gt;\" />",
                "<gpPMOAdmin Value=\"0\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}&#xA;You do not have access to these resources: &#xA;ResourceName300,ResourceName310,ResourceName320,ResourceName330,ResourceName340,...&#xA;{DummyReplyMessage}\" />",
                "<TicketValue Value=\"A6CD298B-BAB7-4459-99DD-05C0F7A3C3D3\" />",
                "<TicketReturns Value=\"&lt;Data&gt;&lt;Resource ID=&quot;100&quot;/&gt;&lt;",
                "Resource ID=&quot;300&quot; Name=&quot;ResourceName300&quot;/&gt;&lt;Resource ID=&quot;310&quot; Name=&quot;ResourceName310&quot;/&gt;&lt;",
                "Resource ID=&quot;320&quot; Name=&quot;ResourceName320&quot;/&gt;&lt;Resource ID=&quot;330&quot; Name=&quot;ResourceName330&quot;/&gt;&lt;",
                "Resource ID=&quot;340&quot; Name=&quot;ResourceName340&quot;/&gt;&lt;Resource ID=&quot;350&quot; Name=&quot;ResourceName350&quot;/&gt;&lt;",
                "Resource ID=&quot;360&quot; Name=&quot;ResourceName360&quot;/&gt;&lt;/Data&gt;\" />",
                "<DetailsLoaded Value=\"1000\" />",
                "<PeriodRange Start=\"0\" Finish=\"1\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"1\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void RaLoadData_ResourceEmptyProjectFilled_ReturnsString()
        {
            // Arrange
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = sender => true;
            ShimWebAdmin.BuildBaseInfoHttpContext = contextParam => DummyBaseInfo;
            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimResourceAnalyzer(sender)
                {
                    SetResourceAnalyzerUserCalendarSettingsXMLInt32Int32Int32 = (calId, startId, finishId) => true
                };
            ShimCapacityScenarios.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (sender, basePath, username, pid, company, dataBaseConnectionString, secLevel, bDebug) => new ShimCapacityScenarios(sender);

            ShimCapacity.ConstructorString = (sender, baseInfo) => new ShimCapacity(sender)
            {
                GetSuperPM = () => false,
                GetSuperRM = () => false,
                SelectResourcesFromTicketStringStringOutStringOut =
                    (string sTicket, out string reply, out string replyMessage) =>
                    {
                        reply = CreateProjectsXml();
                        replyMessage = DummyReplyMessage;
                        return (int)StatusEnum.rsSuccess;
                    },
                SelectMyProjectsStringOut = (out string resourceXml) =>
                {
                    resourceXml = CreateMyProjectsXml();
                    return 0;
                },
                GetRVInfoStringStringOutStringOut = (string paramXml, out string replyXml, out string replyMessage) =>
                {
                    replyXml = string.Empty;
                    replyMessage = DummyReplyMessage;

                    return (int)StatusEnum.rsSuccess;
                }
            };

            var context = new ShimHttpContext();
            var xml = CreateXmlToLoad(DummyTicket);
            var raData = new RPAData();

            var expectedResult = new List<string>()
            {
                "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\">",
                "<Error Value=\"Loading Data failed\" />",
                "<TotalsConfiguration Value=\"\" />",
                "<DetailsConfiguration Value=\"\" />",
                "<FromResGrid Value=\"0\" />",
                "<AllowCSResMode Value=\"1\" />",
                "<DisplayMode Value=\"\" />",
                "<gpPMOAdmin Value=\"\" />",
                $"<LoadingDataReply Value=\"{DummyReplyMessage}&#xA;You do not have access to these projects: &#xA;ProjectName300,ProjectName310,ProjectName320,ProjectName330,ProjectName340,...&#xA;{DummyReplyMessage}\" />",
                $"<TicketValue Value=\"{DummyTicket}\" />",
                "<TicketReturns Value=\"&lt;Data&gt;&lt;PI ID=&quot;100&quot;/&gt;&lt;",
                "PI ID=&quot;300&quot; Name=&quot;ProjectName300&quot;/&gt;&lt;PI ID=&quot;310&quot; Name=&quot;ProjectName310&quot;/&gt;&lt;",
                "PI ID=&quot;320&quot; Name=&quot;ProjectName320&quot;/&gt;&lt;PI ID=&quot;330&quot; Name=&quot;ProjectName330&quot;/&gt;&lt;",
                "PI ID=&quot;340&quot; Name=&quot;ProjectName340&quot;/&gt;&lt;PI ID=&quot;350&quot; Name=&quot;ProjectName350&quot;/&gt;&lt;",
                "PI ID=&quot;360&quot; Name=&quot;ProjectName360&quot;/&gt;&lt;/Data&gt;\" />",
                "<DetailsLoaded Value=\"0\" />",
                "<PeriodRange Start=\"0\" Finish=\"0\" />",
                "<HeatMapText Value=\"\" />",
                "<NegMode Value=\"0\" />",
                "</Result>"
            };

            // Act
            var actualResult = ResPlanAnalyzer.RALoadData(context, xml, raData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedResult.ForEach(c => actualResult.ShouldContain(c)));
        }

        private string CreateXmlToLoad(string ticket)
        {
            return $@"<Data Ticket=""{ticket}"" CalID=""10"" StartID=""20"" FinishID=""30"" />";
        }

        private string CreateResourcesXml()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
               .Append(@"<Resource ID=""100""/>")
               .Append(@"<Resource ID=""300"" Name=""ResourceName300""/>")
               .Append(@"<Resource ID=""310"" Name=""ResourceName310""/>")
               .Append(@"<Resource ID=""320"" Name=""ResourceName320""/>")
               .Append(@"<Resource ID=""330"" Name=""ResourceName330""/>")
               .Append(@"<Resource ID=""340"" Name=""ResourceName340""/>")
               .Append(@"<Resource ID=""350"" Name=""ResourceName350""/>")
               .Append(@"<Resource ID=""360"" Name=""ResourceName360""/>")
               .Append(@"</Data>");

            return stringBuilder.ToString();
        }

        private string CreateMyResourcesXml()
        {
            return @"<Resources><Resource ID=""100""/><Resource ID=""200""/></Resources>";
        }

        private string CreateProjectsXml()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
               .Append(@"<PI ID=""100""/>")
               .Append(@"<PI ID=""300"" Name=""ProjectName300""/>")
               .Append(@"<PI ID=""310"" Name=""ProjectName310""/>")
               .Append(@"<PI ID=""320"" Name=""ProjectName320""/>")
               .Append(@"<PI ID=""330"" Name=""ProjectName330""/>")
               .Append(@"<PI ID=""340"" Name=""ProjectName340""/>")
               .Append(@"<PI ID=""350"" Name=""ProjectName350""/>")
               .Append(@"<PI ID=""360"" Name=""ProjectName360""/>")
               .Append(@"</Data>");

            return stringBuilder.ToString();
        }

        private string CreateMyProjectsXml()
        {
            return @"<Projects><Project ID=""100""/><Project ID=""200""/></Projects>";
        }
    }
}