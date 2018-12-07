using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Text;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    /// <summary>
    /// Unit Tests for <see cref="PortfolioEngineCore.ResourcePlans"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourcePlansTests
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private ResourcePlans _testEntity;
        private IDisposable _shimsContext;
        private readonly StringBuilder query = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;
        private int tosetMainKey = 0;
        private object DeptUID = 15000;
        private object WresId = 15001;

        // Function Names
        private const string GetResourcePlanStruct = "GetResourcePlanStruct";
        private const string SaveResourcePlanStruct = "SaveResourcePlanStruct";
        private const string GetMetaData = "GetMetaData";
        private const string GetPlanRowNotes = "GetPlanRowNotes";
        private const string GetPlanResources = "GetPlanResources";
        private const string GetImportCostPlanHours = "GetImportCostPlanHours";
        private const string GetPIList = "GetPIList";
        private const string GetImportWorkHours = "GetImportWorkHours";
        private const string SaveResourcePlanView = "SaveResourcePlanView";
        private const string SaveRowNote = "SaveRowNote";
        private const string GetRowEvents = "GetRowEvents";
        private const string ReadCalendarCosttypeCombinations = "ReadCalendarCosttypeCombinations";
        private const string SaveResourcePlan = "SaveResourcePlan";
        private const string AddNote = "AddNote";
        private const string HandleRequest = "HandleRequest";
        private const string GetRowNote = "GetRowNote";
        private const string GetResourcePlanWork = "GetResourcePlanWork";
        private const string DeleteResourcePlanView = "DeleteResourcePlanView";
        private const string GetResourcePlan = "GetResourcePlan";
        private const string GetValidResourcesFromList = "GetValidResourcesFromList";
        private const string PostCostValues = "PostCostValues";
        private const string ReadTicketString = "ReadTicketString";
        private const string GetResourcePlanViewsXML = "GetResourcePlanViewsXML";
        private const string GetPeriods = "GetPeriods";
        private const string GetResourcePlanViewXML = "GetResourcePlanViewXML";

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;

            _testEntity = new ResourcePlans(
                DummyString, 
                DummyString, 
                DummyString, 
                DummyString, 
                DummyString, 
                SecurityLevels.AdminCalc);
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(ResourcePlans));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetResourcePlanStruct_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xExecute = new CStruct();
            xExecute.LoadXML($"<dummy><Wepid>{DummyString}</Wepid><TicketVal>{DummyString}</TicketVal><IsResource>{0}</IsResource></dummy>");
            var parameters = new object[] 
            {
                xExecute,
                new CStruct(),
                DummyInt,
                10
            };
            ShimsForGetResourcePlanStructTestMethods();
            var expectedQueries = new string[]
            {
                "EPG_SP_ReadAdmin",
                "EPG_SP_ReadRates",
                "EPG_SP_ReadRateTypes",
                "EPG_SP_ReadResourcePlans_NAX",
                "EPG_SP_ReadResourcePlansHours",
                "EPG_SP_ReadViewFieldDefinitionsWithProjectFields",
                "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID",
                "SELECT DISTINCT p.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_MANAGER,WPROJ_ID,WORKITEM_START_DATE  FROM EPGP_PROJECTS p  Left Join EPGX_PROJECT_VERSIONS pv On pv.PROJECT_ID=p.PROJECT_ID And VERSION_ID= 36 WHERE PROJECT_MARKED_DELETION = 0 AND p.PROJECT_ID in (2,3,4,5,6,7,8,9,10,11) ORDER BY PROJECT_NAME",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'DummyString') LT on PROJECT_EXT_UID=LT.TokenVal",
                "SELECT TOSET_MAINKEY FROM EPGP_COST_VALUES_TOSET WHERE TOSET_MAINKEY < 3",
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetResourcePlanStruct,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeTrue());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetResourcePlanStruct_SuperPIMFalse_CheckBehaviour()
        {
            // Arrange
            var xExecute = new CStruct();
            xExecute.LoadXML($"<dummy><Wepid>{DummyString}</Wepid><TicketVal>{DummyString}</TicketVal><IsResource>{0}</IsResource></dummy>");
            var parameters = new object[]
            {
                xExecute,
                new CStruct(),
                DummyInt,
                10
            };
            ShimsForGetResourcePlanStructTestMethods();
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) => 
            {
                if (_2 == GlobalPermissionsEnum.gpSuperPIM)
                {
                    return false;
                }
                return true;
            };
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = string.Empty;
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'DummyString') LT on PROJECT_EXT_UID=LT.TokenVal",
                "EPG_SP_ReadAdmin",
                "SELECT TOSET_MAINKEY FROM EPGP_COST_VALUES_TOSET WHERE TOSET_MAINKEY < 3",
                "EPG_SP_ReadViewFieldDefinitionsWithProjectFields",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = 15001 OR SU.SURR_WRES_ID = 15001) AND PROJECT_ID in (2,3,4,5,6,7,8,9,10,11)",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetResourcePlanStruct,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeFalse());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetResourcePlanStruct_SuperRMFalse_CheckBehaviour()
        {
            // Arrange
            var xExecute = new CStruct();
            xExecute.LoadXML($"<dummy><Wepid>{DummyString}</Wepid><TicketVal>{DummyString}</TicketVal><IsResource>{1}</IsResource></dummy>");
            var parameters = new object[]
            {
                xExecute,
                new CStruct(),
                DummyInt,
                10
            };
            ShimsForGetResourcePlanStructTestMethods();
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) =>
            {
                if (_2 == GlobalPermissionsEnum.gpSuperRM)
                {
                    return false;
                }
                return true;
            };
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = "";
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadAdmin",
                "SELECT TOSET_MAINKEY FROM EPGP_COST_VALUES_TOSET WHERE TOSET_MAINKEY < 3",
                "EPG_SP_ReadViewFieldDefinitionsWithProjectFields",
                "EPG_SP_ReadManagerResDeptsB",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetResourcePlanStruct,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeFalse());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveResourcePlanStruct_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xGrid = new CStruct();
            xGrid.LoadXML("<Dummy>" +
                            "<Body>" +
                                "<B>" +
                                    $"<I GUID='{(new Guid()).ToString()}' Status='0' Changed='1' DeleteExistingPlan='1' Project_UID='1' RowEventId='1' UID='1' H1='1' F1='1' M1='1' h1='1' f1='1' m1='1'>" +
                                        $"<I GUID='{(new Guid()).ToString()}' Status='1' Deleted='1' Added='0' RowEventId='1' UID='1' H1='1' F1='1' M1='1' h1='1' f1='1' m1='1'>" +
                                            $"<I GUID='{(new Guid()).ToString()}' Status='1' Changed='1' Deleted='0' Added='1' RowEventId='1' UID='1' H1='1' F1='1' M1='1' h1='1' f1='1' m1='1'></I>" +
                                            $"<I GUID='{(new Guid()).ToString()}' Status='1' Changed='1' Deleted='0' Added='0' RowEventId='1' UID='1' H1='1' F1='1' M1='1' h1='1' f1='1' m1='1'></I>" +
                                        "</I>" +
                                    "</I>" +
                                    $"<I GUID='{(new Guid()).ToString()}' Status='1' Changed='1' DeleteExistingPlan='1'>" +
                                        $"<I GUID='{(new Guid()).ToString()}' Status='1' Changed='1' DeleteExistingPlan='1'>" +
                                            $"<I GUID='{(new Guid()).ToString()}' Status='1' Changed='1' DeleteExistingPlan='1'></I>" +
                                        "</I>" +
                                    "</I>" +
                                "</B>" +
                            "</Body>" +
                          "</Dummy>");
            var parameters = new object[] { xGrid, DummyInt, 10 };
            var expectedQueries = new string[]
            {
                "DELETE FROM EPG_RESOURCEPLANS WHERE CMT_UID = 1",
                "DELETE FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = 1",
                "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 1 AND PRD_ID >= 1",
                "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID IN (1,66,67,68) AND (PRD_ID >= 1 AND PRD_ID <= 10)",
                "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID IN (SELECT CMT_UID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = 1)",
                "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID IN (SELECT CMT_GUID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = 1)",
                "DELETE FROM EPGP_RP_CATEGORY_VALUES WHERE CAT_CMT_UID = 1",
                "DELETE FROM EPGP_RP_CATEGORY_VALUES WHERE CAT_CMT_UID IN (SELECT CMT_UID FROM EPG_RESOURCEPLANS WHERE PROJECT_ID = 1)",
                "EPG_SP_AddPlanResourcesToTeamEPG_SP_ReadFieldInfo",
                "EPG_SP_ReadAdmin",
                "EPG_SP_ReadViewFieldDefinitionsWithProjectFields",
                "INSERT INTO [EPG_RESOURCEPLANS] ( CMT_GUID,CMT_UID,CMT_STATUS,CMT_PRIVATE,CMT_TIMESTAMP,RP_GROUP,RP_PM_STATUS,RP_RM_STATUS,RP_ACTIVE_COMMITMENT,PROJECT_ID,BC_UID,PARENT_BC_UID,CMT_ROLE,CMT_DEPT,CMT_RT_UID,WRES_ID,WRES_ID_PENDING,CMT_ENTEREDBY_WRES_ID,CMT_RATE_PRD_ID,CMT_HOURS,CMT_DESC,CMT_LAST_EVENT_CONTEXT) VALUES ('00000000-0000-0000-0000-000000000000',1,1,0,CONVERT(DATETIME, '0001-01-01 00:00:00', 102),'M0001',0,0,0,0,0,0,0,0,0,0,0,15001,0,1,'',1)",
                "INSERT INTO [EPGP_RP_CATEGORY_VALUES] ( CAT_CMT_UID,CAT_TEXT_1,CAT_TEXT_2,CAT_TEXT_3,CAT_TEXT_4,CAT_TEXT_5,CAT_CODE_1,CAT_CODE_2,CAT_CODE_3,CAT_CODE_4,CAT_CODE_5) VALUES ( 1,'','','','','',0,0,0,0,0)",
                "INSERT INTO EPG_RESOURCEPLANS_HOURS (CMT_UID,PRD_ID,CMH_HOURS,CMH_FTES,CMH_MODE,CMH_REVENUES,CMH_PENDING) VALUES(@CMT_UID,@PRD_ID,@CMH_HOURS,@CMH_FTES,@CMH_MODE,@CMH_REVENUES,@CMH_PENDING)",
                "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_CONTEXT,RPEN_EVENT_CONTEXT,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_CONTEXT,@RPEN_EVENT_CONTEXT,@RPEN_TIMESTAMP,@RPEN_WRES_ID,@RPEN_TITLE,@RPEN_HTML,@RPEN_TO)",
                "SELECT CMT_UID, CMT_GUID FROM EPG_RESOURCEPLANS INNER JOIN dbo.EPG_FN_ConvertGuidListToTable(N'00000000-0000-0000-0000-000000000000') LT on CMT_GUID=LT.TokenVal",
                "SELECT MAX(CMT_UID) as HighestUID FROM EPG_RESOURCEPLANS",
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_HOURS = (SELECT SUM(CMH_HOURS) FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 1) WHERE CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_HOURS = (SELECT SUM(CMH_HOURS) FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 52) WHERE CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_HOURS = (SELECT SUM(CMH_HOURS) FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 66) WHERE CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_HOURS = (SELECT SUM(CMH_HOURS) FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 67) WHERE CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_HOURS = (SELECT SUM(CMH_HOURS) FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = 68) WHERE CMT_GUID = '00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_TIMESTAMP=CONVERT(DATETIME, '0001-01-01 00:00:00', 102),CMT_STATUS=1,CMT_PRIVATE=0,RP_PM_STATUS=0,RP_RM_STATUS=0,RP_ACTIVE_COMMITMENT=0,PROJECT_ID=0,BC_UID=0,CMT_ROLE=0,CMT_DEPT=0,CMT_RT_UID=0,WRES_ID=0,WRES_ID_PENDING=0,CMT_ENTEREDBY_WRES_ID=15001,CMT_HOURS=0 WHERE CMT_TIMESTAMP=CONVERT(DATETIME, '0001-01-01 00:00:00', 102) AND CMT_GUID='00000000-0000-0000-0000-000000000000'",
                "UPDATE [EPG_RESOURCEPLANS] SET CMT_TIMESTAMP=CONVERT(DATETIME, '0001-01-01 00:00:00', 102),CMT_STATUS=1,CMT_PRIVATE=0,RP_PM_STATUS=0,RP_RM_STATUS=0,RP_ACTIVE_COMMITMENT=0,PROJECT_ID=0,BC_UID=0,CMT_ROLE=0,CMT_DEPT=0,CMT_RT_UID=0,WRES_ID=0,WRES_ID_PENDING=0,CMT_ENTEREDBY_WRES_ID=15001,CMT_HOURS=1,CMT_LAST_EVENT_CONTEXT=1 WHERE CMT_TIMESTAMP=CONVERT(DATETIME, '0001-01-01 00:00:00', 102) AND CMT_GUID='00000000-0000-0000-0000-000000000000'",
                "UPDATE Unknown Table SET  =  (SELECT SUM(CMT_HOURS) / 100 FROM EPG_RESOURCEPLANS WHERE RP_ACTIVE_COMMITMENT = 1 AND CMT_PRIVATE = 0 AND CMT_STATUS = 256 AND PROJECT_ID = 1) WHERE PROJECT_ID = 1",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                SaveResourcePlanStruct,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeTrue());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetMetaData_IsResourceTrue_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><Wepid>{DummyString}</Wepid><TicketVal>{DummyString}</TicketVal><IsResource>{1}</IsResource></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string ticket, out string reply) =>
            {
                reply = DummyString;
                return true;
            };
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) =>
            {
                return GlobalPermissionsEnum.gpSuperRM != _2;
            };
            ShimResourcePlans.AllInstances.GetResourcePlanViewsXMLCStructOut = (ResourcePlans resourcePlans, out CStruct xPlanViews) =>
            {
                xPlanViews = new CStruct();
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadManagerResDeptsB",
                "SELECT WRES_ID, RES_NAME, WRES_RP_DEPT FROM EPG_RESOURCES  JOIN dbo.EPG_FN_ConvertListToTable(N'DummyString')    LT on (WRES_ID = LT.TokenVal AND WRES_RP_DEPT IS NOT NULL) WHERE WRES_RP_DEPT NOT IN (15000)",
                "EPG_SP_ReadAdmin",
                "EPG_SP_ReadCostCategoryWithRoles",
                "EPG_SP_ReadFTEs",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetMetaData,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeTrue());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetMetaData_IsResourceFalse_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><Wepid>{DummyString}</Wepid><IsResource>{0}</IsResource></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string ticket, out string reply) =>
            {
                reply = DummyString;
                return true;
            };
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) =>
            {
                return _2 == GlobalPermissionsEnum.gpSuperPIM ? false : true;
            };
            ShimResourcePlans.AllInstances.GetResourcePlanViewsXMLCStructOut = (ResourcePlans resourcePlans, out CStruct xPlanViews) =>
            {
                xPlanViews = new CStruct();
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @PROJECT_EXT_UID",
                "SELECT PROJECT_ID, PROJECT_NAME FROM EPGP_PROJECTS LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = 15001 OR SU.SURR_WRES_ID = 15001) AND PROJECT_ID in (2)",
                "SELECT PROJECT_ID, PROJECT_NAME FROM EPGP_PROJECTS WHERE PROJECT_ID in (2)",
                "EPG_SP_ReadAdmin",
                "EPG_SP_ReadCostCategoryWithRoles",
                "EPG_SP_ReadFTEs",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetMetaData,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetMetaData_ProjectIDEmpty_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string ticket, out string reply) =>
            {
                reply = DummyString;
                return true;
            };
            ShimCommon.AddIDToListStringRefInt32 = (ref string sList, int lID) =>
            {
                sList = "";
                return true;
            };
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) =>
            {
                return _2 == GlobalPermissionsEnum.gpSuperPIM ? false : true;
            };
            ShimResourcePlans.AllInstances.GetResourcePlanViewsXMLCStructOut = (ResourcePlans resourcePlans, out CStruct xPlanViews) =>
            {
                xPlanViews = new CStruct();
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'') LT on PROJECT_EXT_UID=LT.TokenVal",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetMetaData,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPlanRowNotes_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource></dummy>"; 
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT * FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID ORDER BY RPEN_TIMESTAMP DESC",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetPlanRowNotes,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPlanResources_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><FromPeriodId>1</FromPeriodId><ToPeriodId>10</ToPeriodId></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string sTicket, out string sReply) =>
            {
                sReply = DummyString;
                return true;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS JOIN dbo.EPG_FN_ConvertWEPIDToTable(N'DummyString') LT on PROJECT_EXT_UID=LT.TokenVal",
                "EPG_SP_ReadAdmin",
                "EPG_SP_CheckUserGlobalPermission",
                "EPG_SP_ReadInitialisedCustomFields",
                "EPG_SP_ReadInitialisedCustomFields",
                "EPG_SP_ReadInitialisedCustomFields",
                "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID",
                "SELECT WR.WRES_ID,RES_NAME,WRES_INACTIVE,WRES_IS_GENERIC,MR_NOTES,WR.WRES_RP_DEPT as RPDeptUID,BC_UID as CCRoleUID,WRES_EMAIL,RPDEPT1.LV_VALUE AS Field9015,C3.RT_NAME AS Field9020 FROM EPG_RESOURCES WR  LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = 15001 LEFT JOIN EPGP_COST_XREF CX ON WR.WRES_ID = CX.WRES_ID LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT1 ON (RPDEPT1.LV_UID = WR.WRES_RP_DEPT) LEFT JOIN EPGP_COST_RATES C2 ON WR.WRES_ID = C2.WRES_ID LEFT JOIN EPG_RATES C3 ON C3.RT_UID = C2.RT_UID  WHERE WR.WRES_ID <> 1  AND WR.WRES_INACTIVE = 0  AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0)  ORDER BY RES_NAME",
                "EPG_SP_ReadResourcesWorkA",
                "EPG_SP_ReadResourcesWorkB",
                "EPG_SP_ReadResourcesWorkC",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetPlanResources,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }
        
        [TestMethod]
        public void GetImportCostPlanHours_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><FromPeriodId>1</FromPeriodId><ToPeriodId>10</ToPeriodId></dummy>";
            var parameters = new object[] { request, DummyString };
            maxDatareaderCount = 4;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        return DummyInt;
                    },
                }.Instance;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadPICVwRole",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetImportCostPlanHours,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPIList_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><FromPeriodId>1</FromPeriodId><ToPeriodId>10</ToPeriodId></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) => false;
            maxDatareaderCount = 10;
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE (PROJECT_EXT_UID IS NOT NULL OR PROJECT_EXT_UID <> '') AND (PROJECT_ARCHIVED IS NULL OR PROJECT_ARCHIVED = 0) ORDER BY PROJECT_NAME",
                "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = 15001 OR SU.SURR_WRES_ID = 15001) AND (PROJECT_ARCHIVED IS NULL OR PROJECT_ARCHIVED = 0) AND PROJECT_ID in (2,5,8,11,14,17,20,23,26,29) ORDER BY PROJECT_NAME",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetPIList,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeTrue());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetImportWorkHours_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><FromPeriodId>1</FromPeriodId><ToPeriodId>10</ToPeriodId></dummy>";
            var parameters = new object[] { request, DummyString };
            maxDatareaderCount = 5;
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        return DataReaderResult;
                    },
                }.Instance;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadPlannedWorkByPeriod_NAX",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetImportWorkHours,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveResourcePlanView_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><View Default='1'></View></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "UPDATE EPG_VIEWS SET VIEW_NAME=@VIEW_NAME,WRES_ID=@WRES_ID,VIEW_DEFAULT=@VIEW_DEFAULT,VIEW_DATA=@VIEW_DATA,VIEW_CONTEXT=30000 WHERE VIEW_GUID=@VIEW_GUID",
                "UPDATE EPG_VIEWS SET VIEW_DEFAULT=0 WHERE VIEW_CONTEXT=30000 AND VIEW_GUID<>@VIEW_GUID",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                SaveResourcePlanView,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveResourcePlanView_AffectedRowsZero_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><View Default='1'></View></dummy>";
            var parameters = new object[] { request, DummyString };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                return 0;
            };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "UPDATE EPG_VIEWS SET VIEW_NAME=@VIEW_NAME,WRES_ID=@WRES_ID,VIEW_DEFAULT=@VIEW_DEFAULT,VIEW_DATA=@VIEW_DATA,VIEW_CONTEXT=30000 WHERE VIEW_GUID=@VIEW_GUID",
                "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@VIEW_GUID,@VIEW_NAME,@WRES_ID,@VIEW_DEFAULT,@VIEW_DATA,30000)",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                SaveResourcePlanView,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ShouldBeFalse());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveRowNote_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><Note Default='1'><HTML>{DummyString}</HTML></Note></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "DELETE FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID=@RPEN_CMT_GUID AND RPEN_TO IS NULL",
                "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_TIMESTAMP,@RPEN_WRES_ID,NULL,@RPEN_HTML,NULL)",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                SaveRowNote,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetRowEvents_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><Note Default='1'><HTML>{DummyString}</HTML></Note></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT RN.*, WR.RES_NAME FROM EPG_RPE_NOTES RN LEFT JOIN EPG_RESOURCES WR ON (RN.RPEN_WRES_ID = WR.WRES_ID) WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID AND RPEN_CONTEXT = 1 AND RPEN_EVENT_CONTEXT >= 0 ORDER BY RPEN_TIMESTAMP",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetRowEvents,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ReadCalendarCosttypeCombinations_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><IsResource>{0}</IsResource><TicketVal>{DummyString}</TicketVal><Note Default='1'><HTML>{DummyString}</HTML></Note></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadAdmin",
                "EPG_SP_ReadCostValueSetswRole",
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                ReadCalendarCosttypeCombinations,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void SaveResourcePlan_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><StartPeriod>1</StartPeriod><FinishPeriod>10</FinishPeriod><Data><Grid></Grid></Data></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "EPG_SP_ReadAdmin",
                "If Exists(Select TOP 1 LOG_TIMESTAMP From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 8)) Delete From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 5)",
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS)  VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,GetDate(),@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)",
            };

            // Act
            var result = _privateObject.Invoke(
                SaveResourcePlan,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddNote_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><Note Planrow_GUID='{(new Guid()).ToString()}' Project_UID='{DummyInt}'></Note></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "INSERT INTO EPG_RPE_NOTES (RPEN_CMT_GUID,RPEN_PROJECT_ID,RPEN_TIMESTAMP,RPEN_WRES_ID,RPEN_TITLE,RPEN_HTML,RPEN_TO) VALUES(@RPEN_CMT_GUID,@RPEN_PROJECT_ID,@RPEN_TIMESTAMP,@RPEN_WRES_ID,@RPEN_TITLE,@RPEN_HTML,@RPEN_TO)",
            };

            // Act
            var result = _privateObject.Invoke(
                AddNote,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void HandleRequest_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy Function='AddNote'></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
            };

            // Act
            var result = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetRowNote_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy Function='AddNote'></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_CAN_LOGIN = 1 AND WRES_USE_NT_LOGON = 1 AND WRES_NT_ACCOUNT=@WRES_NT_ACCOUNT",
                "SELECT * FROM EPG_RPE_NOTES WHERE RPEN_CMT_GUID = @RPEN_CMT_GUID AND RPEN_CONTEXT = 0",
            };

            // Act
            var result = _privateObject.Invoke(
                GetRowNote,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetResourcePlanWork_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy Function='AddNote'></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "EPG_SP_ReadAdmin",
                "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID = @PROJECT_EXT_UID",
                "EPG_SP_CheckUserGlobalPermission",
                "EPG_SP_ReadInitialisedCustomFields",
                "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID",
                "SELECT WR.WRES_ID,RES_NAME,WRES_INACTIVE,WRES_IS_GENERIC,MR_NOTES,WR.WRES_RP_DEPT as RPDeptUID,BC_UID as CCRoleUID,WRES_EMAIL,RPDEPT1.LV_VALUE AS Field9015,C3.RT_NAME AS Field9020 FROM EPG_RESOURCES WR  LEFT join EPG_MY_RESOURCES MR ON WR.WRES_ID = MR.WRES_ID AND MR.MR_WRES_ID = 15001 LEFT JOIN EPGP_COST_XREF CX ON WR.WRES_ID = CX.WRES_ID LEFT JOIN EPGP_LOOKUP_VALUES RPDEPT1 ON (RPDEPT1.LV_UID = WR.WRES_RP_DEPT) LEFT JOIN EPGP_COST_RATES C2 ON WR.WRES_ID = C2.WRES_ID LEFT JOIN EPG_RATES C3 ON C3.RT_UID = C2.RT_UID  WHERE WR.WRES_ID <> 1  AND WR.WRES_INACTIVE = 0  AND (WR.WRES_IS_RESOURCE <> 0 OR WR.WRES_IS_GENERIC <> 0)  ORDER BY RES_NAME",
                "EPG_SP_ReadResourcesWorkA",
                "EPG_SP_ReadResourcesWorkB",
                "EPG_SP_ReadResourcesWorkC",
            };

            // Act
            var result = _privateObject.Invoke(
                GetResourcePlanWork,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void DeleteResourcePlanView_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><View ViewGUID='{(new Guid()).ToString()}'></View></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@VIEW_GUID",
            };

            // Act
            var result = _privateObject.Invoke(
                DeleteResourcePlanView,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetResourcePlan_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><FromPeriodId>1</FromPeriodId><ToPeriodId>10</ToPeriodId></dummy>";
            var parameters = new object[] { request, DummyString };
            var isInvokedGetResourcePlanStruct = false;
            ShimResourcePlans.AllInstances.GetResourcePlanStructCStructCStructOutInt32Int32 = (ResourcePlans resourcePlans, CStruct xExecute, out CStruct xReply, int fromPeriodId, int toPeriodId) =>
            {
                isInvokedGetResourcePlanStruct = true;
                xReply = new CStruct();
                return true;
            };

            // Act
            var result = (bool)_privateObject.Invoke(
                GetResourcePlan,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => isInvokedGetResourcePlanStruct.ShouldBeTrue());
        }

        [TestMethod]
        public void GetValidResourcesFromList_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _1, _2) => false;
            var expectedQueries = new string[]
            {
                "EPG_SP_ReadManagerResDeptsB",
                "SELECT WRES_ID FROM EPG_RESOURCES WHERE WRES_RP_DEPT IN (15000)"
            };

            // Act
            var result = _privateObject.Invoke(
                GetValidResourcesFromList,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => result.ToString().ShouldBe(string.Empty));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void PostCostValues_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { DummyString, true, true };
            var expectedQueries = new string[]
            {
                "INSERT INTO EPG_JOBS(JOB_GUID, JOB_CONTEXT, JOB_SESSION ,WRES_ID, JOB_SUBMITTED,JOB_STATUS, JOB_COMMENT, JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)",
                "If Exists(Select TOP 1 LOG_TIMESTAMP From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 8)) Delete From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 5)",
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS)  VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,GetDate(),@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)",
            };

            // Act
            var result = _privateObject.Invoke(
                PostCostValues,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ReadTicketString_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { (new Guid()).ToString(), DummyString };
            var expectedQueries = new string[]
            {
                "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = @DC_TICKET",
            };

            // Act
            var result = _privateObject.Invoke(
                ReadTicketString,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetResourcePlanViewsXML_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var reply = new CStruct();
            var parameters = new object[] { reply };
            var expectedQueries = new string[]
            {
                "SELECT VIEW_DEFAULT,VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=",
            };

            // Act
            var result = _privateObject.Invoke(
                GetResourcePlanViewsXML,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void PostCostValues_2ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var request = $"<dummy><View ViewGUID='{(new Guid()).ToString()}'></View></dummy>";
            var parameters = new object[] { request, DummyString };
            var expectedQueries = new string[]
            {
                "INSERT INTO EPG_JOBS(JOB_GUID, JOB_CONTEXT, JOB_SESSION ,WRES_ID, JOB_SUBMITTED,JOB_STATUS, JOB_COMMENT, JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)",
                "If Exists(Select TOP 1 LOG_TIMESTAMP From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 8)) Delete From EPG_LOG Where LOG_TIMESTAMP < (GETDATE() - 5)",
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS)  VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,GetDate(),@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)",
            };

            // Act
            var result = _privateObject.Invoke(
                PostCostValues,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void GetPeriods_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new DBAccess(DummyString), DummyInt, new List<CPeriod>()};
            ShimResourcePlans.GetPeriodsDBAccessInt32ListOfCPeriodOut = null;

            // Act
            var result = _privateType.InvokeStatic(
                GetPeriods,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain("EPG_SP_ReadPeriods"),
                () => result.ShouldBeOfType(typeof(StatusEnum)));
        }

        [TestMethod]
        public void GetResourcePlanViewXML_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new Guid(), DummyString };
            var expectedQuery = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_GUID=";

            // Act
            var result = (bool)_privateObject.Invoke(
                GetResourcePlanViewXML,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain(expectedQuery));
        }
        
        private void InitShims()
        {
            ShimResourcePlans.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = 2,
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>();
                return StatusEnum.rsSuccess;
            };
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            SetupSqlShims();
        }

        private void ShimsForGetResourcePlanStructTestMethods()
        {
            maxDatareaderCount = 10;
            ShimResourcePlans.AllInstances.ReadTicketStringStringStringOut = (ResourcePlans resourcePlans, string sTicket, out string sReply) =>
            {
                sReply = DummyString;
                return true;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dba, int iCal, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = 2,
                    },
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dba, int lPortfolioCommitmentsCalendarUID, int lStartPeriodID, out CStruct xCostCategoryRolesOut, bool bGetAll) =>
            {
                xCostCategoryRolesOut = new CStruct();
                xCostCategoryRolesOut.LoadXML($"<{DummyString}></{DummyString}>");
                return StatusEnum.rsSuccess;
            };
        }

        private void SetupSqlShims()
        {
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
                {
                    return true;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "TOSET_MAINKEY")
                        {
                            if (tosetMainKey != 2)
                            {
                                tosetMainKey++;
                            }
                            return tosetMainKey;
                        }
                        else if (key == "FA_FORMAT")
                        {
                            return 4;
                        }
                        else if (key == "CMT_TIMESTAMP" || key == "RPEN_TIMESTAMP" || key == "PRD_FINISH_DATE" || key == "PRD_CLOSED_DATE")
                        {
                            return DateTime.Now;
                        }
                        else if (key == "CMT_GUID")
                        {
                            return new Guid();
                        }
                        else if (key == "DeptUID")
                        {
                            return DeptUID;
                        }
                        else if (key == "WRES_ID")
                        {
                            return WresId;
                        }
                        else if (key == "ADM_PORT_COMMITMENTS_OPMODE")
                        {
                            return 0;
                        }
                        else if (key == "CB_ID")
                        {
                            return 14;
                        }
                        else if (key == "VIEW_DATA")
                        {
                            return "<Dummy></Dummy>";
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }
    }
}
