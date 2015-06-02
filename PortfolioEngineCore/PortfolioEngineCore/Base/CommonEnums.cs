using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioEngineCore
{
    public enum StatusEnum
    {
        rsSuccess = 0,                          // Operation Succeeded,
        rsRequestUnknown = 1,                    // Request not recognised
        rsRequestInvalid = 2,                    // Some part of the request syntax is invalid (general status)
        rsRequestIncomplete = 3,                 // More info expected in request
        rsRequestStringEmpty = 4,                // Request string contained no info
        rsRequestNotImplemented = 5,             // Request is known but currently not implemented
        rsRequestInvalidParameter = 6,           // One of the request nodes/parameters is invalid or cotextually invalid
        rsNodeNameInvalid = 7,                   // Node name not recognised as valid syntax for the request
        rsSessionExpired = 8,
        rsDBConnectFailed = 9,
        rsDBTableNotFound = 10,
        rsTicketNotFound = 11,
        rsDateFormatInvalid = 21,                // The format of a string date is invalid ("YYYYMMDDhhmmss")
        rsDecodeInvalidInteger = 23,             // A request numeric parameter did not hold a numeric value
        rsDecodeIntegerTooSmall = 24,            // A request numeric parameters value was too small
        rsDecodeIntegerTooLarge = 25,            // A request numeric parameters value was too large
        rsRequestInvalidXML = 30,                // Request XML contains a syntax error - i.e. it can//t be parsed
        rsRequestInvalidRoot = 32,               // No root node found for the request
        rsRequestMultiplesInvalid = 31,          // Request contains repeated parameters which is invalid
        rsRequestMissing = 33,                   // Request node was found but the request itself was missing
        rsRequestParameterMissing = 34,          // A required parameter for the request was missing
        rsRequestCannotBeCompleted = 35,         // A general failure to perform as desired - display mess on client
        rsRequestEncounteredDuplicate = 36,      // A failure to perform because some kind of duplicate encountered
        rsRequestInvalidPeriodRange = 37,
        rsRequestInvalidPeriod = 38,
        rsWEIBeginSessionFailed = 39,
        rsWEIWebServiceNotSpecified = 40,
        rsWEIWebServiceError = 41,
        rsSecurityAccessDenied = 50,             // User does not have permission to make this request
        rsSecurityNoProjects = 51,             // User does not have permission to see selected projects
        rsSecurityNoResources = 52,             // User does not have permission to see selected resources
        rsVarCharInvalidCharacters = 59,
        rsVarCharInvalidLength = 60,

        rsPasswordChangeFailed = 61,
        rsCannotDeleteUsedRateType = 62,

        rsTriggerValidationError = 64,

        rsUserJobNotInRegistry = 70,
        rsUserJobCreateObjectFailed = 71,
        rsUserJobInvalidObject = 72,

        rsProjIDtoWProjIDConversionFailed = 102,

        rsServerError = 999,

        rsProjectNotFound = 1000,
        rsProjectAlreadyExists = 1001,
        rsProjectParametersInvalid = 1004,
        rsProjectCheckedout = 1007,
        rsProjectNameInvalid = 1016,
        rsProjectPrefixTooLong = 1019,
        rsProjectPrefixTooShort = 1020,
        rsProjectPrefixInvalidCharacters = 1021,
        rsProjStartDateMissing = 1025,
        rsMailSendFailure = 1030,
        rsMailConfigInvalid = 1031,


        // Reserve 2000 - 2100 for QueueManager errors

        rsLookupInvalidLevelSequence = 2001,
        rsLookupAlreadyExists = 2002,
        rsLookupWriteError = 2003,

        rsPortfolioNoViews = 3001,
        rsPIResourceCalendarNotSet = 3002,
        rsPIResourcePlanViewNotSet = 3003,
        rsPIResourceApprovalCodeNotSet = 3004,

        rsEVCalcError = 3100,

        // Sync 4000 - 4999 between vb and C#
        rsNotifyEventNotFound = 4001,
        rsNoSenderEMailAddress = 4002,
        rsNoRecipientEMailAddress = 4003,

        rsInvalidPeriodID = 8000,
        rsTSNotFound = 8001,
        rsTSDeptStatusChanged = 8002,
        rsTSProjStatusChanged = 8003,
        rsTSCantDeleteSubmittedRow = 8004,
        rsTSDeptManagerLocked = 8005,
        rsTSHasChanged = 8006,
        rsInvalidCustomFieldID = 8007,
        rsBasePathNotSet = 8008,
        rsTaskStatusUpdateFailed = 8009,
        rsOtherResourceAssignedTask = 8010,
        rsTSPeriodClosed = 8011,
        rsTSDeptPeriodClosed = 8012,
        rsDelegatePermissionDenied = 8013,
        rsRoleCodeInvalid = 8014,
        rsTimestampHasChanged = 8015,

        rsWSSUnknownError = 8100,
        rsWSSSiteAlreadyExists = 8101,
        rsWSSSiteNotFound = 8102,
        rsWSSNoUserNTAccount = 8103,
        rsWSSCannotDeleteSiteUsedByOtherPIs = 8104,
        rsWSSCannotDeleteSiteUsedByOtherProjects = 8105,
        rsWSSCannotAttachSiteUsedByOtherProjects = 8106,
        rsWSSCannotAttachSiteUsedByOtherPIs = 8107,
        rsWSSRoleNameAlreadyExists = 8108,
        rsWSSNoAdminData = 8109,
        rsWSSNoServerData = 8110,
        rsWSSNoCurrentServer = 8111,
        rsWSSSecurityPrincipalInvalid = 8112,
        rsWSSAdminComponentFailed = 8113,
        rsWSSURLErrorOrPermissionsProblem = 8114,

        rsWSSLoginFailed = 8120,
        rsWSSReadFailed = 8121,
        rsWSSCOMPlusComponentFailed = 8122,
        rsWSSClassNotInitialized = 8123,

        rsResourceRowLimitExceeded = 8200,

        rsPSILoginFailed = 8300,
        rsLookupTableAlreadyExists = 8301,

        rsRequestAuthenticationFailed = 8999
    }

    public enum TraceChannelEnum
    {
        All = -1,
        None = 0x0,
        Exception = 0x1,
        WSS = 0x2,
        Upload = 0x4,
        WebServices = 0x8
    }

    public enum SeverityEnum
    {
        None = 0,
        Information = 1,
        Warning = 2,
        Error = 3,
        Exception = 4,
        DBException = 5
    }

    public enum GlobalPermissionsEnum
    {
        gpToday = 3001,       // EPK B01 Home, Delegate,
        gpUserAdmin = 3002,   // EPK A04 Manage Status Date and Non-Work Items,
        gpDBA = 3003,         // EPK A06 DBA Utilities,
        gpTimesheet = 3004,   // EPK T01 Timesheet and Plan Non-working time,
        //gpTaskStatus = 3005,  // EPK T02 Progressor  - requires T02 - NOT USED
        gpTSDeptApproval = 3006,      // EPK T03 Department Timesheet Approval,
        gpTSProjApproval = 3007,      // EPK T04 Project Timesheet Approval,
        gpTSOverview = 3008,  // EPK A02 Timesheet App Admin,
        gpTSAdmin = 3009,     // EPK A01 Base and Timesheet SysAdmin,
        gpPortCenter = 3010,  // EPK P01 View Portfolio,
        gpPortfolio = 3011,   // EPK P02 View Portfolio Item Details,
        gpEditPI = 3012,      // EPK P03 Edit Portfolio Item,
        gpCreatePI = 3013,    // EPK P04 Create Portfolio Item,
        gpEditCostType = 3014,        // EPK P05 Edit Cost - requires P03,
        gpEditStage = 3015,   // EPK P06 Edit Stage - requires P03,
        gpManageWSS = 3016,   // EPK P07 Manage WSS Site,
        gpPublishPI = 3017,   // EPK P08 Publish Portfolio Item,
        gpWorkItems = 3018,   // EPK P09 Work Items - requires P03,
        gpEditSecurity = 3019,        // EPK P10 Edit Security - requires P03,
        gpClosePI = 3020,     // EPK P11 Close Portfolio Item,
        gpBudgetAnalyzer = 3021,      // EPK P12 Save Changes made in Modeler,
        gpProjectVerCenter = 3022,    // EPK P13 CT Analyzer,
        gpProjectVersions = 3023,     // EPK P21 View Project Details,
        gpOptimizerAnalyzer = 3023,     // EPK P21 change made for optimizer,
        gpProjectsTab = 3024,         // EPK P22 Create/Link Projects,
        gpPortAdmin = 3025,   // EPK A03 Portfolio and Capacity SysAdmin,
        gpResourcePlan = 3026,        // EPK C02 Edit Resource Plan,
        gpCommitments = 3027,         // EPK C01 View Resource Plans,
        gpCapCenter = 3028,   // EPK R01 Resource Center,
        gpUserBtn1 = 3029,    // EPK U01 User Button 1,
        gpUserBtn2 = 3030,    // EPK U02 User Button 2,
        gpUserBtn3 = 3031,    // EPK U03 User Button 3,
        gpUserBtn4 = 3032,    // EPK U04 User Button 4,
        gpUserBtn5 = 3033,    // EPK U05 User Button 5,
        gpUserBtn6 = 3034,    // EPK U06 User Button 6,
        gpUserBtn7 = 3035,    // EPK U07 User Button 7,
        gpUserBtn8 = 3036,    // EPK U08 User Button 8,
        gpUserBtn9 = 3037,    // EPK U09 User Button 9,
        gpUserBtn10 = 3038,   // EPK U10 User Button 10,
        gpSuperPIM = 3040,    // EPK C03 Edit Res Plans for All Portfolio Items,
        gpSuperRM = 3041,     // EPK C04 Edit Res Plans for All Departments,
        gpPMOAdmin = 3042,    // EPK A05 PMO App Admin,
        gpResDept = 3043,     // EPK C05 Resource Plans Analyzer,
        gpEVUser = 3044      // EPK E01 Earned Value User,
    }

    enum UserInfoContextsEnum
    {
        uicTSRegisterPeriod = 20000,
        uicTSDeptApprovalPeriod = 20001,
        uicTSProjApprovalPeriod = 20002,
        uicProjectBrowserSettings = 20003,
        uicTodaySettings = 20004,
        uicTSViewEditorViewID = 20005,
        uicTimesheetSettings = 20006,
        uicTSActualsSettings = 20007,
        uicTSActualsDeptSettings = 20008,
        uicTSActualsProjSettings = 20009,
        uicTSActualsUserSettings = 20010,
        uicTSNonWorkSettings = 20011,
        uicPICommitmentsSettings = 20012,
        uicDeptCommitmentsSettings = 20013,
        uicAssignmentsMeSettings = 20014,
        uicAssignmentsMyGuysSettings = 20015,

        // Resource selector column contexts
        uicRSDelegates = 20021,
        uicRSCostCategories = 20022,
        uicRSMyResources = 20023,
        uicRSCommitments = 20024,
        uicRSDeptManager = 20025,
        // Resource commitments editor column context
        uicCECommitments = 20030,
        // Resource stuff for Port Centre
        uicPortCentreSettings = 20080,

        uicRPEditorPIMode = 20091,
        uicRPEditorDeptMode = 20092,
        uicRCSettings = 20100,
        uicRCViewSettings = 20101,
        uicRXViewModeDept = 20102,
        uicRXViewModeRes = 20103,
        uicRXViewModePI = 20104,
        uicRASettings = 20110,

        uicEVEditor = 20202,

        siRPEditorPISettings = 30000,
        siWIEditorPISettings = 30001,
        siEVEditorPISettings = 30002,

        siPORT_VIEW_PROMPT = 10042,
        siPGM_VIEW_PROMPT = 10043,

        siVIEW_FILTER = 10044
    }

    enum TSFieldFormatEnum
    {
        ffDate = 1,
        ffInteger = 2,
        ffNumber = 3,
        ffCode = 4,
        ffMVCode = 40,
        ffNames = 6,
        ffCurrency = 8,
        ffText = 9,
        ffPercent = 11,
        ffTime = 12,
        ffYesNo = 13,
        ffWork = 20,
        ffDuration = 23,
        ffCatCode = 54,
        ffCatText = 59,
        ffCustom = 96,
        ffGroups = 98,
        ffGroup = 99
    }

    enum TSFieldAlignEnum
    {
        faLeft = 0,
        faCenter = 1,
        faRight = 2
    }

    enum SortTypeEnum
    {
        stDescending = -1,
        stNone = 0,
        stAscending = 1
    }

    enum ViewTypeEnum
    {
        vtTimesheet = 1,
        vtProgressor = 2,
        vtExplorer = 3,
        vtResourcePlan = 4
    }

    enum SpecialFieldIDsEnum
    {
        sfProjectName = 9000,
        sfTaskName = 9001,
        sfChargeNumber = 9002,
        sfChargeStatus = 9003,
        sfResourceName = 9004,
        sfDeptName = 9005,
        sfRoleName = 9006,
        sfCostCategoryRoleName = 9007,
        sfCostCategoryName = 9008,
        sfMajorCategory = 9009,
        sfGroupBy = 9010,
        sfRowType = 9011,
        sfDescription = 9012,
        sfTimestamp = 9013,
        sfID = 9014,
        sfRPDeptName = 9015,

        sfResourceNotes = 9016,
        sfResourceGroups = 9017,
        sfResourceType = 9018,
        sfResourceCostCategory = 9019,
        sfResourceRate = 9020,
        sfResourceStatus = 9021,
        sfResourceEMail = 9024,
        sfRPEGroup = 9025,
        sfMSPStartDate = 9040,
        sfMSPFinishDate = 9041,
        sfMSPActualWork = 9042,
        sfMSPRemainingWork = 9043,
        sfTKSActualStart = 9050,
        sfTKSActualFinish = 9051,
        sfTKSRemainingWork = 9052,
        sfTKSPercentComplete = 9053,
        sfTKSActualWork = 9054,
        sfTKSExpectedFinish = 9055,
        sfTSCatText1 = 9100,
        sfTSCatText2 = 9101,
        sfTSCatText3 = 9102,
        sfTSCatText4 = 9103,
        sfTSCatText5 = 9104,
        sfTSCatCode1 = 9105,
        sfTSCatCode2 = 9106,
        sfTSCatCode3 = 9107,
        sfTSCatCode4 = 9108,
        sfTSCatCode5 = 9109,
        sfResourceNames = 2030,
        sfAllocation = 9110,
        sfRateType = 9112,
        sfRatePeriod = 9113,
        sfRate = 9114,
        sfTotalCost = 9115,
        sfCalcTotalCost = 9116,
        sfStartDate = 2122,
        sfFinishDate = 2050,
        sfRPStartDate = 9117,
        sfRPFinishDate = 9118,
        sfRPCatText1 = 9300,
        sfRPCatText2 = 9301,
        sfRPCatText3 = 9302,
        sfRPCatText4 = 9303,
        sfRPCatText5 = 9304,
        sfRPCatCode1 = 9305,
        sfRPCatCode2 = 9306,
        sfRPCatCode3 = 9307,
        sfRPCatCode4 = 9308,
        sfRPCatCode5 = 9309,

        sfEVName = 9400,
        sfEVFullName = 9401,
        sfEVOwner = 9402,
        sfEVValue = 9403,
        sfEVCost = 9404,
        sfEVPercentComplete = 9405,
        sfEVStartDate = 9406,
        sfEVFinishDate = 9407,
        sfEVActualStartDate = 9408,
        sfEVActualFinishDate = 9409,
        sfEVOBS = 9410,
        sfEVLineType = 9411,
        sfEVCostCategoryRole = 9412,
        sfEVCatText1 = 9500,
        sfEVCatText2 = 9501,
        sfEVCatText3 = 9502,
        sfEVCatText4 = 9503,
        sfEVCatText5 = 9504,
        sfEVCatCode1 = 9505,
        sfEVCatCode2 = 9506,
        sfEVCatCode3 = 9507,
        sfEVCatCode4 = 9508,
        sfEVCatCode5 = 9509
    }

    enum DelegateContextEnum
    {
        scPlaceholder = 0,
        scTimesheet = 1,
        scDepartment = 2,
        scPIPlanOwner = 3,
        scPIManager = 4,
        scResourceManager = 5,
        scPIStageOwner = 6
    }

    enum PlanRowStatusEnum
    {
        rpsRequirement = 0x1,
        rpsCommitment = 0x100,          // 256,
        rpsCommitmentCancelled = 0x200  // 512,
    }

    enum IncludeGenericsEnum
    {
        igNo = 0,
        igYes = 1,
        igExclusive = 2 // this means only return generics,
    }

    enum ResourceTypeEnum
    {
        rtUser = 1,
        rtResource = 2,
        rtGeneric = 3
    }

    enum ResourceStatusEnum
    {
        rsActive = 0,
        rsInactive = 1,
    }

    enum CustomFieldDBTable
    {
        Unknown = 0,
        ResourceINT = 101,
        ResourceTEXT = 102,
        ResourceDEC = 103,
        ResourceNTEXT = 104,
        ResourceDATE = 105,
        ResourceMV = 151,
        PortfolioINT = 201,
        PortfolioTEXT = 202,
        PortfolioDEC = 203,
        PortfolioNTEXT = 204,
        PortfolioDATE = 205,
        Program = 251,
        ProjectINT = 301,
        ProjectTEXT = 302,
        ProjectDEC = 303,
        ProjectNTEXT = 304,
        ProjectDATE = 305,
        ProgramText = 402,
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }

    public enum FieldType
    {
        TypeCost = 8,
        TypeCode = 4,
        TypeMVCode = 40,
        TypeFlag = 13,
        TypeText = 9,
        TypeNumber = 3,
        TypeDate = 1,
        TypeNText = 19,
    }

    public enum EntityID
    {
        Resource = 1,
        Portfolio = 2,
        Program = 3,
        Project = 4,
        Task = 5,
        Unknown = 0
    }

    public enum CTEditMode
    {
        ctBudget = 1,
        ctCalculated = 3,
        ctCalculatedCumulative = 30,
        ctTSActuals = 4,
        ctTSActualsToDate = 40,
        ctWEActuals = 41,
        ctDPWork = 5,
        ctDPForecastWork = 50,
        ctWIWork = 6,
        ctWIForecastWork = 60,
        ctCommitments = 9,
        ctForecastCommitments = 90,
        ctCommitmentsREV = 91,
        ctForecastCommitmentsREV = 92,
        ctDisplay = 0,
        ctDisplaywDetails = 101
    }

    public enum QueuedJobContext
    {
    qjcCustom = 0,
    qjcImportProject = 1,
    qjcImportLookup = 2,
    qjcImportResources = 3,
    qjcExecuteActiveX = 4,
    qjcImportPIs = 5,
    qjcImportData = 6,
    qjcExportData = 7,
    qjcMaintenance = 8,
    qjcRefreshRoles = 200,
    qjcCalcAvailability = 111,
    qjcCalcDefaultFTEs = 112,
    qjcPostCostValues = 113,
    qjcTest = 100001
    }
}
