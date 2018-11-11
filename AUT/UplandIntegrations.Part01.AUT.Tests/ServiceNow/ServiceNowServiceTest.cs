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
using UplandIntegrations.ServiceNow;
using ServiceNowService = UplandIntegrations.ServiceNow;

namespace UplandIntegrations.ServiceNow
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.ServiceNow.ServiceNowService" />)
    ///     and namespace <see cref="UplandIntegrations.ServiceNow"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ServiceNowServiceTest : AbstractBaseSetupV3Test
    {
        public ServiceNowServiceTest() : base(typeof(ServiceNowService))
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

        #region General Initializer : Class (ServiceNowService) Initializer

        #region Methods

        private const string MethodInstallWebhook = "InstallWebhook";
        private const string MethodRemoveWebhook = "RemoveWebhook";
        private const string MethodGetSystemTables = "GetSystemTables";
        private const string MethodGetObjectItem = "GetObjectItem";
        private const string MethodGetObjectItems = "GetObjectItems";
        private const string MethodCreateObjectItem = "CreateObjectItem";
        private const string MethodUpdateObjectItem = "UpdateObjectItem";
        private const string MethodDeleteObjectItem = "DeleteObjectItem";
        private const string MethodGetViewUrlResourceByServiceNowType = "GetViewUrlResourceByServiceNowType";
        private const string MethodExecute = "Execute";
        private const string MethodGetRestRequestResourceByServiceNowType = "GetRestRequestResourceByServiceNowType";
        private const string MethodGetJson = "GetJson";
        private const string MethodFillDataTableFromJson = "FillDataTableFromJson";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodDispose = "Dispose";

        #endregion

        #region Fields

        private const string FieldrestClient = "restClient";
        private const string FieldjsonSerializerSettings = "jsonSerializerSettings";

        #endregion

        private Type _serviceNowServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ServiceNowService _serviceNowServiceInstance;
        private ServiceNowService _serviceNowServiceInstanceFixture;

        #region General Initializer : Class (ServiceNowService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ServiceNowService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _serviceNowServiceInstanceType = typeof(ServiceNowService);
            _serviceNowServiceInstanceFixture = this.Create<ServiceNowService>(true);
            _serviceNowServiceInstance = _serviceNowServiceInstanceFixture ?? this.Create<ServiceNowService>(false);
            CurrentInstance = _serviceNowServiceInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (InstallWebhook) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_InstallWebhook_Method_Call_Internally(Type[] types)
        {
            var methodInstallWebhookPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodInstallWebhook, Fixture, methodInstallWebhookPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveWebhook) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_RemoveWebhook_Method_Call_Internally(Type[] types)
        {
            var methodRemoveWebhookPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodRemoveWebhook, Fixture, methodRemoveWebhookPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSystemTables) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetSystemTables_Method_Call_Internally(Type[] types)
        {
            var methodGetSystemTablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetSystemTables, Fixture, methodGetSystemTablesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodGetObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetObjectItem, Fixture, methodGetObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetObjectItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetObjectItems_Method_Call_Internally(Type[] types)
        {
            var methodGetObjectItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetObjectItems, Fixture, methodGetObjectItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateObjectItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_CreateObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodCreateObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodCreateObjectItem, Fixture, methodCreateObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_UpdateObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodUpdateObjectItem, Fixture, methodUpdateObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteObjectItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_DeleteObjectItem_Method_Call_Internally(Type[] types)
        {
            var methodDeleteObjectItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodDeleteObjectItem, Fixture, methodDeleteObjectItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewUrlResourceByServiceNowType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetViewUrlResourceByServiceNowType_Method_Call_Internally(Type[] types)
        {
            var methodGetViewUrlResourceByServiceNowTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetViewUrlResourceByServiceNowType, Fixture, methodGetViewUrlResourceByServiceNowTypePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : RestResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRestRequestResourceByServiceNowType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetRestRequestResourceByServiceNowType_Method_Call_Internally(Type[] types)
        {
            var methodGetRestRequestResourceByServiceNowTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetRestRequestResourceByServiceNowType, Fixture, methodGetRestRequestResourceByServiceNowTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetJson) (Return Type : JObject) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetJson_Method_Call_Internally(Type[] types)
        {
            var methodGetJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetJson, Fixture, methodGetJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (FillDataTableFromJson) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_FillDataTableFromJson_Method_Call_Internally(Type[] types)
        {
            var methodFillDataTableFromJsonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodFillDataTableFromJson, Fixture, methodFillDataTableFromJsonPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowService_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowServiceInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}