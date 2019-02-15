using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq.Fakes;
using System.Xml.Fakes;
using System.Web.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Shouldly;
using EPMLiveCore.Fakes;
using EPMLiveCore.API.Fakes;

namespace EPMLiveCore.Tests.ISAPI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class WorkEngineAPITests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private WorkEngineAPI _workEngineAPI;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const string ExecuteResult = "<Result Status=\"1\"><Error ID=\"1001\">Invalid Method Info Call</Error></Result>";
        private const string TestFunctionResult = "<Result Status=\"0\"><SPWeb>00000000-0000-0000-0000-000000000000</SPWeb><Data>DummyString</Data></Result>";
        private const string GetPublisherSettingResult = "<Result Status=\"1\"><Error ID=\"1000\">Error: Not valid URL.</Error></Result>";
        private const string GetPublisherItemResult = "<Result Status=\"0\"></Result>";
        private const string ResultCompare = "<Result Status=\"0\">DummyString</Result>";

        private const string Execute = "Execute";
        private const string ExecuteJSON = "ExecuteJSON";
        private const string TestFunction = "testFunction";
        private const string GetPublisherSettings = "GetPublisherSettings";
        private const string GetPublisherItemInfo = "GetPublisherItemInfo";
        private const string Publish = "Publish";
        private const string PublishStatus = "PublishStatus";
        private const string GetProjectInfoFromName = "GetProjectInfoFromName";
        private const string GetUpdateCount = "GetUpdateCount";
        private const string GetUpdates = "GetUpdates";
        private const string ProcessUpdates = "ProcessUpdates";
        private const string GetTeam = "GetTeam";
        private const string SaveTeam = "SaveTeam";
        private const string GetTeamGridLayout = "GetTeamGridLayout";
        private const string GetResourceGridLayout = "GetResourceGridLayout";
        private const string GetResourceGridData = "GetResourceGridData";
        private const string GetTeamGridData = "GetTeamGridData";
        private const string GetResourcePool = "GetResourcePool";
        private const string GetMyWorkGridColType = "GetMyWorkGridColType";
        private const string IsModerationEnabled = "IsModerationEnabled";
        private const string DeleteMyWorkGridView = "DeleteMyWorkGridView";
        private const string RenameMyWorkGridView = "RenameMyWorkGridView";
        private const string GetMyWorkGridViews = "GetMyWorkGridViews";
        private const string CheckMyWorkListEditPermission = "CheckMyWorkListEditPermission";
        private const string SaveMyWorkGridView = "SaveMyWorkGridView";
        private const string GetMyWorkGridEnum = "GetMyWorkGridEnum";
        private const string GetListItem = "GetListItem";
        private const string GetMyWorkListItem = "GetMyWorkListItem";
        private const string GetMyPersonalization = "GetMyPersonalization";
        private const string GetMyWork = "GetMyWork";
        private const string GetMyWorkGridData = "GetMyWorkGridData";
        private const string GetMyWorkGridLayout = "GetMyWorkGridLayout";
        private const string GetWorkingOnGridLayout = "GetWorkingOnGridLayout";
        private const string GetWorkingOnGridData = "GetWorkingOnGridData";
        private const string IsFieldEditable = "IsFieldEditable";
        private const string SetMyPersonalization = "SetMyPersonalization";
        private const string UpdateListItem = "UpdateListItem";
        private const string UpdateMyWorkItem = "UpdateMyWorkItem";
        private const string GetTemplateInformation = "GetTemplateInformation";
        private const string GetAllTempGalTemps = "GetAllTempGalTemps";
        private const string GetAllSolGalTemps = "GetAllSolGalTemps";
        private const string CreateWorkspace = "CreateWorkspace";
        private const string QueueCreateWorkspace = "QueueCreateWorkspace";
        private const string AddAndQueueCreateWorkspaceJob = "AddAndQueueCreateWorkspaceJob";
        private const string GetAllMarketAppsInJSON = "GetAllMarketAppsInJSON";
        private const string CreateComment = "CreateComment";
        private const string CreatePublicComment = "CreatePublicComment";
        private const string ReadComment = "ReadComment";
        private const string UpdateComment = "UpdateComment";
        private const string DeleteComment = "DeleteComment";
        private const string GetMyCommentsByDate = "GetMyCommentsByDate";
        private const string GetNotifications = "GetNotifications";
        private const string SetNotificationFlags = "SetNotificationFlags";
        private const string QueueItemMessage = "QueueItemMessage";
        private const string SendEmail = "SendEmail";
        private const string GetResources = "GetResources";
        private const string GetResourcePoolDataGrid = "GetResourcePoolDataGrid";
        private const string GetResourcePoolDataGridChanges = "GetResourcePoolDataGridChanges";
        private const string GetResourcePoolLayoutGrid = "GetResourcePoolLayoutGrid";
        private const string GetResourcePoolViews = "GetResourcePoolViews";
        private const string SaveResourcePoolViews = "SaveResourcePoolViews";
        private const string DeleteResourcePoolViews = "DeleteResourcePoolViews";
        private const string UpdateResourcePoolViews = "UpdateResourcePoolViews";
        private const string DeleteResourcePoolResource = "DeleteResourcePoolResource";
        private const string ExportResources = "ExportResources";
        private const string IsImportResourceAlreadyRunning = "IsImportResourceAlreadyRunning";
        private const string CancelTimerJob = "CancelTimerJob";
        private const string RefreshResources = "RefreshResources";

        private const string GetResourceTimeOff = "GetResourceTimeOff";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();

            _workEngineAPI = new WorkEngineAPI();
            _privateObject = new PrivateObject(_workEngineAPI);
            _privateType = new PrivateType(typeof(WorkEngineAPI));
            InitializeSetup();
        }

        private void InitializeSetup()
        {
            ShimXmlDocument.Constructor = _ => new ShimXmlDocument();
            ShimXmlDocument.AllInstances.LoadXmlString = (_, _1) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlDocument();
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection();
            ShimXmlAttributeCollection.AllInstances.ItemOfGetString = (_, strVal) => new ShimXmlAttribute();
            ShimJSONUtil.ConvertXmlToJsonStringString = (_, _1) => DummyString;
            ShimXmlNode.AllInstances.SelectSingleNodeString = (_, _1) => new ShimXmlNode(new ShimXmlElement());
            ShimXmlDocument.AllInstances.CreateAttributeString = (_, _1) => new ShimXmlAttribute();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => new ShimSPList();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimSqlConnection.ConstructorString = (_, _1) => new ShimSqlConnection();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, _1, _2) => new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection()
            {
                AddWithValueStringObject = (x, y) => new ShimSqlParameter()
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, _1) => new Guid();
            ShimSqlDataReader.AllInstances.IsDBNullInt32 = (_, _1) => false;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => 2;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSPList.AllInstances.GetItemsSPQuery = (_, _1) => new ShimSPListItemCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPSite.AllInstances.MakeFullUrlString = (_, _1) => DummyString;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.UrlGet = _ => new Uri("http://localhost/");
            ShimSPSite.ConstructorGuid = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, _1) => new ShimSPUser();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsTimeSheet_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "timesheet_"+ DummyString, DummyString };
            
            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsReporting_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "reporting_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsAssignmentplanner_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "assignmentplanner_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsTagmanager_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "tagmanager_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsPersonalization_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "personalization_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsWebparts_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "webparts_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsSocialengine_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "socialengine_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void Execute_FunctionAndDataXMLIsNotNullAndFunctionPartIsDefault_ReturnString()
        {
            // Arrange
            var parameters = new object[] { "default_" + DummyString, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Execute,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ExecuteResult);
        }

        [TestMethod]
        public void ExecuteJSON_FunctionAndDataXMLIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            ShimWorkEngineAPI.AllInstances.ExecuteStringString = (_, _1, _2) => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                ExecuteJSON,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void TestFunction_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };

            // Act
            var actualResult = _privateType.InvokeStatic(
                TestFunction,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(TestFunctionResult);
        }

        [TestMethod]
        public void GetPublisherSettings_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXmlNode.AllInstances.InnerTextGet = _ => "http://" + DummyString + ".mpp";
            ShimHttpUtility.UrlDecodeString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetPublisherSettings,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(GetPublisherSettingResult);
        }

        [TestMethod]
        public void GetPublisherItemInfo_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXmlNode.AllInstances.InnerTextGet = _ => DummyString + ".mpp";

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetPublisherItemInfo,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(GetPublisherItemResult);
        }

        [TestMethod]
        public void Publish_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXmlNode.AllInstances.InnerTextGet = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, _1, _2) => DummyString;
            ShimSqlDataReader.AllInstances.Read = _ => true;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                Publish,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(GetPublisherItemResult);
        }

        [TestMethod]
        public void PublishStatus_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                PublishStatus,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"><PublishStatus/></Result>");
        }

        [TestMethod]
        public void GetProjectInfoFromName_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSPListItemCollection.AllInstances.CountGet = _ => 0;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                GetProjectInfoFromName,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"><ProjectInfo ProjectId=\"\"></ProjectInfo></Result>");
        }

        [TestMethod]
        public void GetUpdateCount_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                GetUpdateCount,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(GetPublisherItemResult);
        }

        [TestMethod]
        public void GetUpdates_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetUpdates,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(GetPublisherItemResult);
        }

        [TestMethod]
        public void ProcessUpdates_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                ProcessUpdates,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"1\"><Error ID=\"4052\">Error: Index was outside the bounds of the array.</Error></Result>");
        }

        [TestMethod]
        public void GetTeam_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetTeamStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetTeam,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void SaveTeam_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.SaveTeamStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveTeam,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void GetTeamGridLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetTeamGridLayoutStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetTeamGridLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void GetResourceGridLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetResourceGridLayoutStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourceGridLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void GetResourceGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetResourceGridDataStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourceGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void GetTeamGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetTeamGridDataStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetTeamGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void GetResourcePool_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPITeam.GetResourcePoolXmlStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourcePool,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\">DummyString</Result>");
        }

        [TestMethod]
        public void UpdateMyWorkItem_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.UpdateMyWorkItemString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                UpdateMyWorkItem,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void UpdateListItem_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimListItem.UpdateListItemString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                UpdateListItem,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void SetMyPersonalization_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyPersonalization.SetMyPersonalizationString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SetMyPersonalization,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void IsFieldEditable_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimFieldInfo.IsFieldEditableString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                IsFieldEditable,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetWorkingOnGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetWorkingOnGridDataString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetWorkingOnGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetWorkingOnGridLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetWorkingOnGridLayoutString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetWorkingOnGridLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetMyWorkGridLayout_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkGridLayoutString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkGridLayout,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetMyWorkGridData_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkGridDataString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkGridData,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetMyWork_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWork,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyPersonalization_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyPersonalization.GetMyPersonalizationString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyPersonalization,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyWorkListItem_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkListItemString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkListItem,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetListItem_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimListItem.GetListItemString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetListItem,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyWorkGridEnum_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkGridEnumString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkGridEnum,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void SaveMyWorkGridView_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.SaveMyWorkGridViewString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveMyWorkGridView,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CheckMyWorkListEditPermission_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.CheckListEditPermissionString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CheckMyWorkListEditPermission,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyWorkGridViews_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkGridViewsSPWeb = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkGridViews,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void RenameMyWorkGridView_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.RenameMyWorkGridViewString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                RenameMyWorkGridView,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void DeleteMyWorkGridView_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.DeleteMyWorkGridViewString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                DeleteMyWorkGridView,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void IsModerationEnabled_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimListItem.IsModerationEnabledString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                IsModerationEnabled,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyWorkGridColType_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimMyWork.GetMyWorkGridColTypeString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyWorkGridColType,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetAllMarketAppsInJSON_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSolLibTemplatesManager.CreateWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetAllMarketAppsInJSON,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void AddAndQueueCreateWorkspaceJob_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimWorkspaceTimerjobAgent.AddAndQueueCreateWorkspaceJobString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                AddAndQueueCreateWorkspaceJob,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void QueueCreateWorkspace_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimWorkspaceTimerjobAgent.QueueCreateWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                QueueCreateWorkspace,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CreateWorkspace_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSolLibTemplatesManager.CreateWorkspaceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateWorkspace,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetAllSolGalTemps_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSolLibTemplatesManager.ReturnAllSolutionGalleryTemplatesInXMLString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetAllSolGalTemps,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetAllTempGalTemps_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimSolLibTemplatesManager.ReturnAllLocalTemplatesInXMLString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetAllTempGalTemps,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetTemplateInformation_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimTemplate.GetTemplateInformationString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetTemplateInformation,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetMyCommentsByDate_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.GetMyCommentsByDateString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetMyCommentsByDate,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void DeleteComment_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.DeleteCommentString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                DeleteComment,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void UpdateComment_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.UpdateCommentString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                UpdateComment,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void ReadComment_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.ReadCommentString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                ReadComment,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CreatePublicComment_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.CreatePublicCommentString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreatePublicComment,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CreateComment_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimCommentManager.CreateCommentString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateComment,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetNotifications_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimNotification.GetNotificationsString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetNotifications,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void SetNotificationFlags_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimNotification.SetNotificationFlagsString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SetNotificationFlags,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void QueueItemMessage_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimAPIEmail.QueueItemMessageXmlStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                QueueItemMessage,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetResources_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.GetResourcesStringSPWeb = (_, _1) => DummyString;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResources,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void ExportResources_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.ExportResourcesSPWeb = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                ExportResources,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void DeleteResourcePoolResource_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.DeleteResourcePoolResourceString = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                DeleteResourcePoolResource,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void UpdateResourcePoolViews_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.UpdateResourcePoolViewsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                UpdateResourcePoolViews,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void DeleteResourcePoolViews_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.DeleteResourcePoolViewsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                DeleteResourcePoolViews,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void SaveResourcePoolViews_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.SaveResourcePoolViewsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SaveResourcePoolViews,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetResourcePoolViews_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.GetResourcePoolViewsStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourcePoolViews,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void GetResourcePoolLayoutGrid_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.GetResourcePoolLayoutGridStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourcePoolLayoutGrid,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetResourcePoolDataGridChanges_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.GetResourcePoolDataGridChangesStringSPWeb = (_, _1) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourcePoolDataGridChanges,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetResourcePoolDataGrid_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.GetResourcePoolDataGridChangesStringSPWeb = (_, _1) => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourcePoolDataGrid,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"1\"><Error ID=\"15001\">Error: Object reference not set to an instance of an object.</Error></Result>");
        }

        [TestMethod]
        public void IsImportResourceAlreadyRunning_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimTimer.IsImportResourceAlreadyRunningSPWeb = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                IsImportResourceAlreadyRunning,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void RefreshResources_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.RefreshResourcesSPWeb = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                RefreshResources,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(ResultCompare);
        }

        [TestMethod]
        public void CancelTimerJob_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimResourceGrid.RefreshResourcesSPWeb = _ => DummyString;
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => new ShimXElement();
            ShimXContainer.AllInstances.Elements = _ => new List<XElement>() { new ShimXElement() };
            ShimXElement.AllInstances.AttributeXName = (_, _1) => new ShimXAttribute();
            ShimXAttribute.AllInstances.ValueGet = _ => "JobID";
            ShimXElement.AllInstances.ValueGet = _ => new Guid().ToString();
            ShimTimer.CancelTimerJobSPWebGuid = (_, _1) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                CancelTimerJob,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"><ResourceImporter Success=\"True\" /></Result>");
        }

        [TestMethod]
        public void GetResourceTimeOff_StringDataAndSPWebIsNotNull_ReturnString()
        {
            // Arrange
            var parameters = new object[] { DummyString, new ShimSPWeb().Instance };
            ShimXDocument.ParseString = _ => new ShimXDocument();
            ShimXDocument.AllInstances.RootGet = _ => new ShimXElement();
            ShimXContainer.AllInstances.Elements = _ => new List<XElement>() { new ShimXElement() };
            ShimXElement.AllInstances.AttributeXName = (_, _1) => new ShimXAttribute();
            ShimXAttribute.AllInstances.ValueGet = _ => "JobID";
            ShimXElement.AllInstances.ValueGet = _ => new Guid().ToString();
            ShimTimer.CancelTimerJobSPWebGuid = (_, _1) => { };
            ShimXContainer.AllInstances.ElementXName = (_, _1) => new ShimXElement();

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetResourceTimeOff,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("<Result Status=\"0\"><GetResourceTimeOff /></Result>");
        }
    }
}
