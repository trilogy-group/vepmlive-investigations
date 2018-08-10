using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WorkEngineAPI" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class WorkEngineAPITest : AbstractBaseSetupTypedTest<WorkEngineAPI>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkEngineAPI) Initializer

        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodtestFunction = "testFunction";
        private const string MethodGetPublisherSettings = "GetPublisherSettings";
        private const string MethodGetPublisherItemInfo = "GetPublisherItemInfo";
        private const string MethodPublish = "Publish";
        private const string MethodPublishStatus = "PublishStatus";
        private const string MethodGetProjectInfoFromName = "GetProjectInfoFromName";
        private const string MethodGetUpdateCount = "GetUpdateCount";
        private const string MethodGetUpdates = "GetUpdates";
        private const string MethodProcessUpdates = "ProcessUpdates";
        private const string MethodGetTeam = "GetTeam";
        private const string MethodSaveTeam = "SaveTeam";
        private const string MethodGetTeamGridLayout = "GetTeamGridLayout";
        private const string MethodGetResourceGridLayout = "GetResourceGridLayout";
        private const string MethodGetResourceGridData = "GetResourceGridData";
        private const string MethodGetTeamGridData = "GetTeamGridData";
        private const string MethodGetResourcePool = "GetResourcePool";
        private const string MethodGetMyWorkGridColType = "GetMyWorkGridColType";
        private const string MethodIsModerationEnabled = "IsModerationEnabled";
        private const string MethodDeleteMyWorkGridView = "DeleteMyWorkGridView";
        private const string MethodRenameMyWorkGridView = "RenameMyWorkGridView";
        private const string MethodGetMyWorkGridViews = "GetMyWorkGridViews";
        private const string MethodCheckMyWorkListEditPermission = "CheckMyWorkListEditPermission";
        private const string MethodSaveMyWorkGridView = "SaveMyWorkGridView";
        private const string MethodGetMyWorkGridEnum = "GetMyWorkGridEnum";
        private const string MethodGetListItem = "GetListItem";
        private const string MethodGetMyWorkListItem = "GetMyWorkListItem";
        private const string MethodGetMyPersonalization = "GetMyPersonalization";
        private const string MethodGetMyWork = "GetMyWork";
        private const string MethodGetMyWorkGridData = "GetMyWorkGridData";
        private const string MethodGetMyWorkGridLayout = "GetMyWorkGridLayout";
        private const string MethodGetWorkingOnGridLayout = "GetWorkingOnGridLayout";
        private const string MethodGetWorkingOnGridData = "GetWorkingOnGridData";
        private const string MethodIsFieldEditable = "IsFieldEditable";
        private const string MethodSetMyPersonalization = "SetMyPersonalization";
        private const string MethodUpdateListItem = "UpdateListItem";
        private const string MethodUpdateMyWorkItem = "UpdateMyWorkItem";
        private const string MethodGetTemplateInformation = "GetTemplateInformation";
        private const string MethodGetAllTempGalTemps = "GetAllTempGalTemps";
        private const string MethodGetAllSolGalTemps = "GetAllSolGalTemps";
        private const string MethodCreateWorkspace = "CreateWorkspace";
        private const string MethodQueueCreateWorkspace = "QueueCreateWorkspace";
        private const string MethodAddAndQueueCreateWorkspaceJob = "AddAndQueueCreateWorkspaceJob";
        private const string MethodGetAllMarketAppsInJSON = "GetAllMarketAppsInJSON";
        private const string MethodCreateComment = "CreateComment";
        private const string MethodCreatePublicComment = "CreatePublicComment";
        private const string MethodReadComment = "ReadComment";
        private const string MethodUpdateComment = "UpdateComment";
        private const string MethodDeleteComment = "DeleteComment";
        private const string MethodGetMyCommentsByDate = "GetMyCommentsByDate";
        private const string MethodGetNotifications = "GetNotifications";
        private const string MethodSetNotificationFlags = "SetNotificationFlags";
        private const string MethodQueueItemMessage = "QueueItemMessage";
        private const string MethodSendEmail = "SendEmail";
        private const string MethodGetResources = "GetResources";
        private const string MethodGetResourcePoolDataGrid = "GetResourcePoolDataGrid";
        private const string MethodGetResourcePoolDataGridChanges = "GetResourcePoolDataGridChanges";
        private const string MethodGetResourcePoolLayoutGrid = "GetResourcePoolLayoutGrid";
        private const string MethodGetResourcePoolViews = "GetResourcePoolViews";
        private const string MethodSaveResourcePoolViews = "SaveResourcePoolViews";
        private const string MethodDeleteResourcePoolViews = "DeleteResourcePoolViews";
        private const string MethodUpdateResourcePoolViews = "UpdateResourcePoolViews";
        private const string MethodDeleteResourcePoolResource = "DeleteResourcePoolResource";
        private const string MethodExportResources = "ExportResources";
        private const string MethodIsImportResourceAlreadyRunning = "IsImportResourceAlreadyRunning";
        private const string MethodCancelTimerJob = "CancelTimerJob";
        private const string MethodRefreshResources = "RefreshResources";
        private const string MethodGetResourceTimeOff = "GetResourceTimeOff";
        private const string MethodEventReceiverManager = "EventReceiverManager";
        private const string MethodAddRemoveFeatureEvents = "AddRemoveFeatureEvents";
        private const string MethodClearCache = "ClearCache";
        private const string MethodGetListsAndViewsGridData = "GetListsAndViewsGridData";
        private const string MethodGetListAndViewsGridLayout = "GetListAndViewsGridLayout";
        private const string MethodGetNavigationLinks = "GetNavigationLinks";
        private const string MethodReorderLinks = "ReorderLinks";
        private const string MethodRemoveNavigationLink = "RemoveNavigationLink";
        private const string MethodGetContextualMenuItems = "GetContextualMenuItems";
        private const string MethodLoadFavoriteStatus = "LoadFavoriteStatus";
        private const string MethodAddFavorites = "AddFavorites";
        private const string MethodRemoveFavorites = "RemoveFavorites";
        private const string MethodLoadFavoriteWsStatus = "LoadFavoriteWsStatus";
        private const string MethodAddFavoritesWs = "AddFavoritesWs";
        private const string MethodRemoveFavoritesWs = "RemoveFavoritesWs";
        private const string MethodCreateFrequentApp = "CreateFrequentApp";
        private const string MethodCreateRecentItem = "CreateRecentItem";
        private const string MethodSetPropertiesBagSettings = "SetPropertiesBagSettings";
        private const string MethodGenerateQuickLaunchFromApp = "GenerateQuickLaunchFromApp";
        private const string MethodGetDiagnosticsInfo = "GetDiagnosticsInfo";
        private const string MethodGetPropertiesBagParams = "GetPropertiesBagParams";
        private const string MethodGetAssociatedItems = "GetAssociatedItems";
        private const string MethodGetFancyFormAssociatedItems = "GetFancyFormAssociatedItems";
        private const string MethodGetFancyFormAssociatedItemAttachments = "GetFancyFormAssociatedItemAttachments";
        private const string MethodGetMyWorkSummary = "GetMyWorkSummary";
        private const string MethodInstallPlatformIntegration = "InstallPlatformIntegration";
        private const string MethodRemovePlatformIntegration = "RemovePlatformIntegration";
        private const string MethodGetWorkspaceCenterGridData = "GetWorkspaceCenterGridData";
        private const string MethodWorkSpaceCenterLayout = "WorkSpaceCenterLayout";
        private const string MethodIsSecurityJobAlreadyRunning = "IsSecurityJobAlreadyRunning";
        private const string FieldEPMLiveReportingAssembly = "EPMLiveReportingAssembly";
        private const string FieldEPMLiveTSAssembly = "EPMLiveTSAssembly";
        private const string FieldEPMLiveWPAssembly = "EPMLiveWPAssembly";
        private Type _workEngineAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkEngineAPI _workEngineAPIInstance;
        private WorkEngineAPI _workEngineAPIInstanceFixture;

        #region General Initializer : Class (WorkEngineAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkEngineAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workEngineAPIInstanceType = typeof(WorkEngineAPI);
            _workEngineAPIInstanceFixture = Create(true);
            _workEngineAPIInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkEngineAPI)

        #region General Initializer : Class (WorkEngineAPI) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkEngineAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodtestFunction, 0)]
        [TestCase(MethodGetPublisherSettings, 0)]
        [TestCase(MethodGetPublisherItemInfo, 0)]
        [TestCase(MethodPublish, 0)]
        [TestCase(MethodPublishStatus, 0)]
        [TestCase(MethodGetProjectInfoFromName, 0)]
        [TestCase(MethodGetUpdateCount, 0)]
        [TestCase(MethodGetUpdates, 0)]
        [TestCase(MethodProcessUpdates, 0)]
        [TestCase(MethodGetTeam, 0)]
        [TestCase(MethodSaveTeam, 0)]
        [TestCase(MethodGetTeamGridLayout, 0)]
        [TestCase(MethodGetResourceGridLayout, 0)]
        [TestCase(MethodGetResourceGridData, 0)]
        [TestCase(MethodGetTeamGridData, 0)]
        [TestCase(MethodGetResourcePool, 0)]
        [TestCase(MethodGetMyWorkGridColType, 0)]
        [TestCase(MethodIsModerationEnabled, 0)]
        [TestCase(MethodDeleteMyWorkGridView, 0)]
        [TestCase(MethodRenameMyWorkGridView, 0)]
        [TestCase(MethodGetMyWorkGridViews, 0)]
        [TestCase(MethodCheckMyWorkListEditPermission, 0)]
        [TestCase(MethodSaveMyWorkGridView, 0)]
        [TestCase(MethodGetMyWorkGridEnum, 0)]
        [TestCase(MethodGetListItem, 0)]
        [TestCase(MethodGetMyWorkListItem, 0)]
        [TestCase(MethodGetMyPersonalization, 0)]
        [TestCase(MethodGetMyWork, 0)]
        [TestCase(MethodGetMyWorkGridData, 0)]
        [TestCase(MethodGetMyWorkGridLayout, 0)]
        [TestCase(MethodGetWorkingOnGridLayout, 0)]
        [TestCase(MethodGetWorkingOnGridData, 0)]
        [TestCase(MethodIsFieldEditable, 0)]
        [TestCase(MethodSetMyPersonalization, 0)]
        [TestCase(MethodUpdateListItem, 0)]
        [TestCase(MethodUpdateMyWorkItem, 0)]
        [TestCase(MethodGetTemplateInformation, 0)]
        [TestCase(MethodGetAllTempGalTemps, 0)]
        [TestCase(MethodGetAllSolGalTemps, 0)]
        [TestCase(MethodCreateWorkspace, 0)]
        [TestCase(MethodQueueCreateWorkspace, 0)]
        [TestCase(MethodAddAndQueueCreateWorkspaceJob, 0)]
        [TestCase(MethodGetAllMarketAppsInJSON, 0)]
        [TestCase(MethodCreateComment, 0)]
        [TestCase(MethodCreatePublicComment, 0)]
        [TestCase(MethodReadComment, 0)]
        [TestCase(MethodUpdateComment, 0)]
        [TestCase(MethodDeleteComment, 0)]
        [TestCase(MethodGetMyCommentsByDate, 0)]
        [TestCase(MethodGetNotifications, 0)]
        [TestCase(MethodSetNotificationFlags, 0)]
        [TestCase(MethodQueueItemMessage, 0)]
        [TestCase(MethodSendEmail, 0)]
        [TestCase(MethodGetResources, 0)]
        [TestCase(MethodGetResourcePoolDataGrid, 0)]
        [TestCase(MethodGetResourcePoolDataGridChanges, 0)]
        [TestCase(MethodGetResourcePoolLayoutGrid, 0)]
        [TestCase(MethodGetResourcePoolViews, 0)]
        [TestCase(MethodSaveResourcePoolViews, 0)]
        [TestCase(MethodDeleteResourcePoolViews, 0)]
        [TestCase(MethodUpdateResourcePoolViews, 0)]
        [TestCase(MethodDeleteResourcePoolResource, 0)]
        [TestCase(MethodExportResources, 0)]
        [TestCase(MethodIsImportResourceAlreadyRunning, 0)]
        [TestCase(MethodCancelTimerJob, 0)]
        [TestCase(MethodRefreshResources, 0)]
        [TestCase(MethodGetResourceTimeOff, 0)]
        [TestCase(MethodEventReceiverManager, 0)]
        [TestCase(MethodAddRemoveFeatureEvents, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodGetListsAndViewsGridData, 0)]
        [TestCase(MethodGetListAndViewsGridLayout, 0)]
        [TestCase(MethodGetNavigationLinks, 0)]
        [TestCase(MethodReorderLinks, 0)]
        [TestCase(MethodRemoveNavigationLink, 0)]
        [TestCase(MethodGetContextualMenuItems, 0)]
        [TestCase(MethodLoadFavoriteStatus, 0)]
        [TestCase(MethodAddFavorites, 0)]
        [TestCase(MethodRemoveFavorites, 0)]
        [TestCase(MethodLoadFavoriteWsStatus, 0)]
        [TestCase(MethodAddFavoritesWs, 0)]
        [TestCase(MethodRemoveFavoritesWs, 0)]
        [TestCase(MethodCreateFrequentApp, 0)]
        [TestCase(MethodCreateRecentItem, 0)]
        [TestCase(MethodSetPropertiesBagSettings, 0)]
        [TestCase(MethodGenerateQuickLaunchFromApp, 0)]
        [TestCase(MethodGetDiagnosticsInfo, 0)]
        [TestCase(MethodGetPropertiesBagParams, 0)]
        [TestCase(MethodGetAssociatedItems, 0)]
        [TestCase(MethodGetFancyFormAssociatedItems, 0)]
        [TestCase(MethodGetFancyFormAssociatedItemAttachments, 0)]
        [TestCase(MethodGetMyWorkSummary, 0)]
        [TestCase(MethodInstallPlatformIntegration, 0)]
        [TestCase(MethodRemovePlatformIntegration, 0)]
        [TestCase(MethodGetWorkspaceCenterGridData, 0)]
        [TestCase(MethodWorkSpaceCenterLayout, 0)]
        [TestCase(MethodIsSecurityJobAlreadyRunning, 0)]
        public void AUT_WorkEngineAPI_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workEngineAPIInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkEngineAPI) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkEngineAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldEPMLiveReportingAssembly)]
        [TestCase(FieldEPMLiveTSAssembly)]
        [TestCase(FieldEPMLiveWPAssembly)]
        public void AUT_WorkEngineAPI_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workEngineAPIInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WorkEngineAPI" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodtestFunction)]
        [TestCase(MethodGetPublisherSettings)]
        [TestCase(MethodGetPublisherItemInfo)]
        [TestCase(MethodPublish)]
        [TestCase(MethodPublishStatus)]
        [TestCase(MethodGetProjectInfoFromName)]
        [TestCase(MethodGetUpdateCount)]
        [TestCase(MethodGetUpdates)]
        [TestCase(MethodProcessUpdates)]
        [TestCase(MethodGetTeam)]
        [TestCase(MethodSaveTeam)]
        [TestCase(MethodGetTeamGridLayout)]
        [TestCase(MethodGetResourceGridLayout)]
        [TestCase(MethodGetResourceGridData)]
        [TestCase(MethodGetTeamGridData)]
        [TestCase(MethodGetResourcePool)]
        [TestCase(MethodGetMyWorkGridColType)]
        [TestCase(MethodIsModerationEnabled)]
        [TestCase(MethodDeleteMyWorkGridView)]
        [TestCase(MethodRenameMyWorkGridView)]
        [TestCase(MethodGetMyWorkGridViews)]
        [TestCase(MethodCheckMyWorkListEditPermission)]
        [TestCase(MethodSaveMyWorkGridView)]
        [TestCase(MethodGetMyWorkGridEnum)]
        [TestCase(MethodGetListItem)]
        [TestCase(MethodGetMyWorkListItem)]
        [TestCase(MethodGetMyPersonalization)]
        [TestCase(MethodGetMyWork)]
        [TestCase(MethodGetMyWorkGridData)]
        [TestCase(MethodGetMyWorkGridLayout)]
        [TestCase(MethodGetWorkingOnGridLayout)]
        [TestCase(MethodGetWorkingOnGridData)]
        [TestCase(MethodIsFieldEditable)]
        [TestCase(MethodSetMyPersonalization)]
        [TestCase(MethodUpdateListItem)]
        [TestCase(MethodUpdateMyWorkItem)]
        [TestCase(MethodGetTemplateInformation)]
        [TestCase(MethodGetAllTempGalTemps)]
        [TestCase(MethodGetAllSolGalTemps)]
        [TestCase(MethodCreateWorkspace)]
        [TestCase(MethodQueueCreateWorkspace)]
        [TestCase(MethodAddAndQueueCreateWorkspaceJob)]
        [TestCase(MethodGetAllMarketAppsInJSON)]
        [TestCase(MethodCreateComment)]
        [TestCase(MethodCreatePublicComment)]
        [TestCase(MethodReadComment)]
        [TestCase(MethodUpdateComment)]
        [TestCase(MethodDeleteComment)]
        [TestCase(MethodGetMyCommentsByDate)]
        [TestCase(MethodGetNotifications)]
        [TestCase(MethodSetNotificationFlags)]
        [TestCase(MethodQueueItemMessage)]
        [TestCase(MethodSendEmail)]
        [TestCase(MethodGetResources)]
        [TestCase(MethodGetResourcePoolDataGrid)]
        [TestCase(MethodGetResourcePoolDataGridChanges)]
        [TestCase(MethodGetResourcePoolLayoutGrid)]
        [TestCase(MethodGetResourcePoolViews)]
        [TestCase(MethodSaveResourcePoolViews)]
        [TestCase(MethodDeleteResourcePoolViews)]
        [TestCase(MethodUpdateResourcePoolViews)]
        [TestCase(MethodDeleteResourcePoolResource)]
        [TestCase(MethodExportResources)]
        [TestCase(MethodIsImportResourceAlreadyRunning)]
        [TestCase(MethodCancelTimerJob)]
        [TestCase(MethodRefreshResources)]
        [TestCase(MethodGetResourceTimeOff)]
        [TestCase(MethodEventReceiverManager)]
        [TestCase(MethodAddRemoveFeatureEvents)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodGetListsAndViewsGridData)]
        [TestCase(MethodGetListAndViewsGridLayout)]
        [TestCase(MethodGetNavigationLinks)]
        [TestCase(MethodReorderLinks)]
        [TestCase(MethodRemoveNavigationLink)]
        [TestCase(MethodGetContextualMenuItems)]
        [TestCase(MethodLoadFavoriteStatus)]
        [TestCase(MethodAddFavorites)]
        [TestCase(MethodRemoveFavorites)]
        [TestCase(MethodLoadFavoriteWsStatus)]
        [TestCase(MethodAddFavoritesWs)]
        [TestCase(MethodRemoveFavoritesWs)]
        [TestCase(MethodCreateFrequentApp)]
        [TestCase(MethodCreateRecentItem)]
        [TestCase(MethodSetPropertiesBagSettings)]
        [TestCase(MethodGenerateQuickLaunchFromApp)]
        [TestCase(MethodGetDiagnosticsInfo)]
        [TestCase(MethodGetPropertiesBagParams)]
        [TestCase(MethodGetAssociatedItems)]
        [TestCase(MethodGetFancyFormAssociatedItems)]
        [TestCase(MethodGetFancyFormAssociatedItemAttachments)]
        [TestCase(MethodGetMyWorkSummary)]
        [TestCase(MethodInstallPlatformIntegration)]
        [TestCase(MethodRemovePlatformIntegration)]
        [TestCase(MethodGetWorkspaceCenterGridData)]
        [TestCase(MethodWorkSpaceCenterLayout)]
        [TestCase(MethodIsSecurityJobAlreadyRunning)]
        public void AUT_WorkEngineAPI_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_workEngineAPIInstanceFixture,
                                                                              _workEngineAPIInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkEngineAPI" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        public void AUT_WorkEngineAPI_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkEngineAPI>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAPIInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_testFunction_Static_Method_Call_Internally(Type[] types)
        {
            var methodtestFunctionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodtestFunction, Fixture, methodtestFunctionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPublisherSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetPublisherSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPublisherSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetPublisherSettings, Fixture, methodGetPublisherSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPublisherItemInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetPublisherItemInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPublisherItemInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetPublisherItemInfo, Fixture, methodGetPublisherItemInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_Publish_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodPublish, Fixture, methodPublishPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_PublishStatus_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodPublishStatus, Fixture, methodPublishStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectInfoFromName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetProjectInfoFromName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectInfoFromNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetProjectInfoFromName, Fixture, methodGetProjectInfoFromNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetUpdateCount_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdateCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetUpdateCount, Fixture, methodGetUpdateCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetUpdates_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ProcessUpdates_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessUpdatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodProcessUpdates, Fixture, methodProcessUpdatesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetTeam_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetTeam, Fixture, methodGetTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SaveTeam_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSaveTeam, Fixture, methodSaveTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetTeamGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetTeamGridLayout, Fixture, methodGetTeamGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourceGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourceGridLayout, Fixture, methodGetResourceGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourceGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourceGridData, Fixture, methodGetResourceGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetTeamGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetTeamGridData, Fixture, methodGetTeamGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourcePool_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkGridColType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridColTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkGridColType, Fixture, methodGetMyWorkGridColTypePrametersTypes);
        }

        #endregion

        #region Method Call : (IsModerationEnabled) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_IsModerationEnabled_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsModerationEnabledPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodIsModerationEnabled, Fixture, methodIsModerationEnabledPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_DeleteMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodDeleteMyWorkGridView, Fixture, methodDeleteMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RenameMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRenameMyWorkGridView, Fixture, methodRenameMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkGridViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkGridViews, Fixture, methodGetMyWorkGridViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckMyWorkListEditPermission) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CheckMyWorkListEditPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckMyWorkListEditPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCheckMyWorkListEditPermission, Fixture, methodCheckMyWorkListEditPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SaveMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSaveMyWorkGridView, Fixture, methodSaveMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkGridEnum_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridEnumPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkGridEnum, Fixture, methodGetMyWorkGridEnumPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetListItem, Fixture, methodGetListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkListItem, Fixture, methodGetMyWorkListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyPersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyPersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyPersonalization, Fixture, methodGetMyPersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWork, Fixture, methodGetMyWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkGridData, Fixture, methodGetMyWorkGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkGridLayout, Fixture, methodGetMyWorkGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetWorkingOnGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetWorkingOnGridLayout, Fixture, methodGetWorkingOnGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetWorkingOnGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetWorkingOnGridData, Fixture, methodGetWorkingOnGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFieldEditable) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_IsFieldEditable_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsFieldEditablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodIsFieldEditable, Fixture, methodIsFieldEditablePrametersTypes);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SetMyPersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetMyPersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSetMyPersonalization, Fixture, methodSetMyPersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_UpdateListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodUpdateListItem, Fixture, methodUpdateListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_UpdateMyWorkItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMyWorkItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodUpdateMyWorkItem, Fixture, methodUpdateMyWorkItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTemplateInformation) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetTemplateInformation_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTemplateInformationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetTemplateInformation, Fixture, methodGetTemplateInformationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllTempGalTemps) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetAllTempGalTemps_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAllTempGalTempsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetAllTempGalTemps, Fixture, methodGetAllTempGalTempsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllSolGalTemps) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetAllSolGalTemps_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAllSolGalTempsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetAllSolGalTemps, Fixture, methodGetAllSolGalTempsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CreateWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_QueueCreateWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodAddAndQueueCreateWorkspaceJob, Fixture, methodAddAndQueueCreateWorkspaceJobPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllMarketAppsInJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetAllMarketAppsInJSON_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAllMarketAppsInJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetAllMarketAppsInJSON, Fixture, methodGetAllMarketAppsInJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateComment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CreateComment_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCreateComment, Fixture, methodCreateCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (CreatePublicComment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CreatePublicComment_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreatePublicCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCreatePublicComment, Fixture, methodCreatePublicCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadComment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ReadComment_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodReadComment, Fixture, methodReadCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateComment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_UpdateComment_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodUpdateComment, Fixture, methodUpdateCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteComment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_DeleteComment_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCommentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodDeleteComment, Fixture, methodDeleteCommentPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyCommentsByDate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyCommentsByDate_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyCommentsByDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyCommentsByDate, Fixture, methodGetMyCommentsByDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetNotifications) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetNotifications_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNotificationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetNotifications, Fixture, methodGetNotificationsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetNotificationFlags) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SetNotificationFlags_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetNotificationFlagsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSetNotificationFlags, Fixture, methodSetNotificationFlagsPrametersTypes);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_QueueItemMessage_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueItemMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodQueueItemMessage, Fixture, methodQueueItemMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (SendEmail) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SendEmail_Static_Method_Call_Internally(Type[] types)
        {
            var methodSendEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSendEmail, Fixture, methodSendEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResources, Fixture, methodGetResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourcePoolDataGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolDataGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourcePoolDataGrid, Fixture, methodGetResourcePoolDataGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolDataGridChanges) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourcePoolDataGridChanges_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolDataGridChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourcePoolDataGridChanges, Fixture, methodGetResourcePoolDataGridChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolLayoutGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourcePoolLayoutGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolLayoutGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourcePoolLayoutGrid, Fixture, methodGetResourcePoolLayoutGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourcePoolViews, Fixture, methodGetResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SaveResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSaveResourcePoolViews, Fixture, methodSaveResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_DeleteResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodDeleteResourcePoolViews, Fixture, methodDeleteResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResourcePoolViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_UpdateResourcePoolViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcePoolViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodUpdateResourcePoolViews, Fixture, methodUpdateResourcePoolViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourcePoolResource) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_DeleteResourcePoolResource_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourcePoolResourcePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodDeleteResourcePoolResource, Fixture, methodDeleteResourcePoolResourcePrametersTypes);
        }

        #endregion

        #region Method Call : (ExportResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ExportResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodExportResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodExportResources, Fixture, methodExportResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_IsImportResourceAlreadyRunning_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsImportResourceAlreadyRunningPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CancelTimerJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodCancelTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCancelTimerJob, Fixture, methodCancelTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RefreshResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodRefreshResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRefreshResources, Fixture, methodRefreshResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceTimeOff) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetResourceTimeOff_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceTimeOffPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetResourceTimeOff, Fixture, methodGetResourceTimeOffPrametersTypes);
        }

        #endregion

        #region Method Call : (EventReceiverManager) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_EventReceiverManager_Static_Method_Call_Internally(Type[] types)
        {
            var methodEventReceiverManagerPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodEventReceiverManager, Fixture, methodEventReceiverManagerPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRemoveFeatureEvents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_AddRemoveFeatureEvents_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddRemoveFeatureEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodAddRemoveFeatureEvents, Fixture, methodAddRemoveFeatureEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListsAndViewsGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetListsAndViewsGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListsAndViewsGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetListsAndViewsGridData, Fixture, methodGetListsAndViewsGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListAndViewsGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetListAndViewsGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListAndViewsGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetListAndViewsGridLayout, Fixture, methodGetListAndViewsGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNavigationLinks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetNavigationLinks_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNavigationLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetNavigationLinks, Fixture, methodGetNavigationLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (ReorderLinks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_ReorderLinks_Static_Method_Call_Internally(Type[] types)
        {
            var methodReorderLinksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodReorderLinks, Fixture, methodReorderLinksPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveNavigationLink) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RemoveNavigationLink_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveNavigationLinkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRemoveNavigationLink, Fixture, methodRemoveNavigationLinkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetContextualMenuItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetContextualMenuItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetContextualMenuItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetContextualMenuItems, Fixture, methodGetContextualMenuItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadFavoriteStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_LoadFavoriteStatus_Static_Method_Call_Internally(Type[] types)
        {
            var methodLoadFavoriteStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodLoadFavoriteStatus, Fixture, methodLoadFavoriteStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFavorites) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_AddFavorites_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddFavoritesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodAddFavorites, Fixture, methodAddFavoritesPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveFavorites) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RemoveFavorites_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveFavoritesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRemoveFavorites, Fixture, methodRemoveFavoritesPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadFavoriteWsStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_LoadFavoriteWsStatus_Static_Method_Call_Internally(Type[] types)
        {
            var methodLoadFavoriteWsStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodLoadFavoriteWsStatus, Fixture, methodLoadFavoriteWsStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFavoritesWs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_AddFavoritesWs_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddFavoritesWsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodAddFavoritesWs, Fixture, methodAddFavoritesWsPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveFavoritesWs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RemoveFavoritesWs_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveFavoritesWsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRemoveFavoritesWs, Fixture, methodRemoveFavoritesWsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateFrequentApp) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CreateFrequentApp_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateFrequentAppPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCreateFrequentApp, Fixture, methodCreateFrequentAppPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateRecentItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_CreateRecentItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateRecentItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodCreateRecentItem, Fixture, methodCreateRecentItemPrametersTypes);
        }

        #endregion

        #region Method Call : (SetPropertiesBagSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_SetPropertiesBagSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetPropertiesBagSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodSetPropertiesBagSettings, Fixture, methodSetPropertiesBagSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateQuickLaunchFromApp) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GenerateQuickLaunchFromApp_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateQuickLaunchFromAppPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGenerateQuickLaunchFromApp, Fixture, methodGenerateQuickLaunchFromAppPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDiagnosticsInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetDiagnosticsInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDiagnosticsInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetDiagnosticsInfo, Fixture, methodGetDiagnosticsInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPropertiesBagParams) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetPropertiesBagParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertiesBagParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetPropertiesBagParams, Fixture, methodGetPropertiesBagParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssociatedItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetAssociatedItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAssociatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetAssociatedItems, Fixture, methodGetAssociatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetFancyFormAssociatedItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFancyFormAssociatedItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetFancyFormAssociatedItems, Fixture, methodGetFancyFormAssociatedItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFancyFormAssociatedItemAttachments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetFancyFormAssociatedItemAttachments_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFancyFormAssociatedItemAttachmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetFancyFormAssociatedItemAttachments, Fixture, methodGetFancyFormAssociatedItemAttachmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetMyWorkSummary_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkSummaryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetMyWorkSummary, Fixture, methodGetMyWorkSummaryPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallPlatformIntegration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_InstallPlatformIntegration_Static_Method_Call_Internally(Type[] types)
        {
            var methodInstallPlatformIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodInstallPlatformIntegration, Fixture, methodInstallPlatformIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemovePlatformIntegration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_RemovePlatformIntegration_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemovePlatformIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodRemovePlatformIntegration, Fixture, methodRemovePlatformIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_GetWorkspaceCenterGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceCenterGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodGetWorkspaceCenterGridData, Fixture, methodGetWorkspaceCenterGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (WorkSpaceCenterLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_WorkSpaceCenterLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodWorkSpaceCenterLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodWorkSpaceCenterLayout, Fixture, methodWorkSpaceCenterLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAPI_IsSecurityJobAlreadyRunning_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsSecurityJobAlreadyRunningPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workEngineAPIInstanceFixture, _workEngineAPIInstanceType, MethodIsSecurityJobAlreadyRunning, Fixture, methodIsSecurityJobAlreadyRunningPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}