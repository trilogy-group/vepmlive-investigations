using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.Utils;
using UplandIntegrations.Jira;
using JiraService = UplandIntegrations.Jira;

namespace UplandIntegrations.Jira
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.Jira.JiraService" />)
    ///     and namespace <see cref="UplandIntegrations.Jira"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class JiraServiceTest : AbstractBaseSetupV3Test
    {
        public JiraServiceTest() : base(typeof(JiraService))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (JiraService) Initializer

        #region Methods

        private const string MethodInstallWebhook = "InstallWebhook";
        private const string MethodRemoveWebhook = "RemoveWebhook";
        private const string MethodGetObjectItem = "GetObjectItem";
        private const string MethodGetObjectItems = "GetObjectItems";
        private const string MethodCreateObjectItem = "CreateObjectItem";
        private const string MethodUpdateObjectItem = "UpdateObjectItem";
        private const string MethodDeleteObjectItem = "DeleteObjectItem";
        private const string MethodCreateVersion = "CreateVersion";
        private const string MethodCreateComponent = "CreateComponent";
        private const string MethodCreateIssue = "CreateIssue";
        private const string MethodUpdateVersion = "UpdateVersion";
        private const string MethodUpdateComponent = "UpdateComponent";
        private const string MethodUpdateIssue = "UpdateIssue";
        private const string MethodGetProjects = "GetProjects";
        private const string MethodGetProject = "GetProject";
        private const string MethodGetVersion = "GetVersion";
        private const string MethodGetProjectVersions = "GetProjectVersions";
        private const string MethodGetComponent = "GetComponent";
        private const string MethodGetProjectComponents = "GetProjectComponents";
        private const string MethodGetIssue = "GetIssue";
        private const string MethodGetIssuesByLastSyncDateTime = "GetIssuesByLastSyncDateTime";
        private const string MethodDeleteVersion = "DeleteVersion";
        private const string MethodDeleteComponent = "DeleteComponent";
        private const string MethodDeleteIssue = "DeleteIssue";
        private const string MethodExecute = "Execute";
        private const string MethodGetRestRequestResourceByJiraType = "GetRestRequestResourceByJiraType";
        private const string MethodGetJson = "GetJson";
        private const string MethodFillDataTableFromJson = "FillDataTableFromJson";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodDispose = "Dispose";

        #endregion

        #region Fields

        private const string FieldrestClient = "restClient";
        private const string FieldjsonSerializerSettings = "jsonSerializerSettings";

        #endregion

        private Type _jiraServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private JiraService _jiraServiceInstance;
        private JiraService _jiraServiceInstanceFixture;

        #region General Initializer : Class (JiraService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="JiraService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _jiraServiceInstanceType = typeof(JiraService);
            _jiraServiceInstanceFixture = this.Create<JiraService>(true);
            _jiraServiceInstance = _jiraServiceInstanceFixture ?? this.Create<JiraService>(false);
            CurrentInstance = _jiraServiceInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (InstallWebhook) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_InstallWebhook_Method_Call_Internally(Type[] types)
        {
            var methodInstallWebhookPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodInstallWebhook, Fixture, methodInstallWebhookPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveWebhook) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_RemoveWebhook_Method_Call_Internally(Type[] types)
        {
            var methodRemoveWebhookPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodRemoveWebhook, Fixture, methodRemoveWebhookPrametersTypes);
        }

        #endregion

        #region Method Call : (GetObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodGetObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetObjectItem, Fixture, methodGetObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetObjectItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetObjectItems_Method_Call_Internally(Type[] types)
        {
            var methodGetObjectItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetObjectItems, Fixture, methodGetObjectItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateObjectItem) (Return Type : Int64) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_CreateObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodCreateObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodCreateObjectItem, Fixture, methodCreateObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_UpdateObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodUpdateObjectItem, Fixture, methodUpdateObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_DeleteObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodDeleteObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodDeleteObjectItem, Fixture, methodDeleteObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateVersion) (Return Type : Int64) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_CreateVersion_Method_Call_Internally(Type[] types)
        {
            var methodCreateVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodCreateVersion, Fixture, methodCreateVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateComponent) (Return Type : Int64) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_CreateComponent_Method_Call_Internally(Type[] types)
        {
            var methodCreateComponentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodCreateComponent, Fixture, methodCreateComponentPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateIssue) (Return Type : Int64) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_CreateIssue_Method_Call_Internally(Type[] types)
        {
            var methodCreateIssuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodCreateIssue, Fixture, methodCreateIssuePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_UpdateVersion_Method_Call_Internally(Type[] types)
        {
            var methodUpdateVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodUpdateVersion, Fixture, methodUpdateVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateComponent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_UpdateComponent_Method_Call_Internally(Type[] types)
        {
            var methodUpdateComponentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodUpdateComponent, Fixture, methodUpdateComponentPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateIssue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_UpdateIssue_Method_Call_Internally(Type[] types)
        {
            var methodUpdateIssuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodUpdateIssue, Fixture, methodUpdateIssuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjects) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetProjects_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetProjects, Fixture, methodGetProjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProject) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetProject_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetProject, Fixture, methodGetProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (GetVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetVersion_Method_Call_Internally(Type[] types)
        {
            var methodGetVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetVersion, Fixture, methodGetVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectVersions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetProjectVersions_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetProjectVersions, Fixture, methodGetProjectVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetComponent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetComponent_Method_Call_Internally(Type[] types)
        {
            var methodGetComponentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetComponent, Fixture, methodGetComponentPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectComponents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetProjectComponents_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectComponentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetProjectComponents, Fixture, methodGetProjectComponentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIssue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetIssue_Method_Call_Internally(Type[] types)
        {
            var methodGetIssuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetIssue, Fixture, methodGetIssuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetIssuesByLastSyncDateTime) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetIssuesByLastSyncDateTime_Method_Call_Internally(Type[] types)
        {
            var methodGetIssuesByLastSyncDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetIssuesByLastSyncDateTime, Fixture, methodGetIssuesByLastSyncDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_DeleteVersion_Method_Call_Internally(Type[] types)
        {
            var methodDeleteVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodDeleteVersion, Fixture, methodDeleteVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteComponent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_DeleteComponent_Method_Call_Internally(Type[] types)
        {
            var methodDeleteComponentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodDeleteComponent, Fixture, methodDeleteComponentPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteIssue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_DeleteIssue_Method_Call_Internally(Type[] types)
        {
            var methodDeleteIssuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodDeleteIssue, Fixture, methodDeleteIssuePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : RestResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRestRequestResourceByJiraType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetRestRequestResourceByJiraType_Method_Call_Internally(Type[] types)
        {
            var methodGetRestRequestResourceByJiraTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetRestRequestResourceByJiraType, Fixture, methodGetRestRequestResourceByJiraTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetJson) (Return Type : JObject) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetJson_Method_Call_Internally(Type[] types)
        {
            var methodGetJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetJson, Fixture, methodGetJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (FillDataTableFromJson) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_FillDataTableFromJson_Method_Call_Internally(Type[] types)
        {
            var methodFillDataTableFromJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodFillDataTableFromJson, Fixture, methodFillDataTableFromJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_JiraService_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_jiraServiceInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}