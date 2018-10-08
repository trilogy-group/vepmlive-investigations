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
using System.Security;
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
using EPMLiveIntegration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Services;
using UplandIntegrations.PowerSteering;
using Integrator = UplandIntegrations.PowerSteering;

namespace UplandIntegrations.PowerSteering
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.PowerSteering.Integrator" />)
    ///     and namespace <see cref="UplandIntegrations.PowerSteering"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public class IntegratorTest : AbstractBaseSetupV3Test
    {
        public IntegratorTest() : base(typeof(Integrator))
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

        #region General Initializer : Class (Integrator) Initializer

        #region Methods

        private const string MethodBuildIdMap = "BuildIdMap";
        private const string MethodGetAuthInfo = "GetAuthInfo";
        private const string MethodGetPowerSteeringService = "GetPowerSteeringService";
        private const string MethodProcessResults = "ProcessResults";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodDeleteItems = "DeleteItems";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodPullData = "PullData";
        private const string MethodGetItem = "GetItem";
        private const string MethodGetDropDownValues = "GetDropDownValues";
        private const string MethodTestConnection = "TestConnection";
        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodGetEmbeddedItemControls = "GetEmbeddedItemControls";
        private const string MethodGetPageButtons = "GetPageButtons";
        private const string MethodGetURL = "GetURL";
        private const string MethodGetControlCode = "GetControlCode";
        private const string MethodGetProxyResult = "GetProxyResult";

        #endregion

        #region Fields

        private const string FieldPROJECT_INFO_URL = "PROJECT_INFO_URL";
        private const string FieldUPSERT_ERROR_MESSAGE = "UPSERT_ERROR_MESSAGE";

        #endregion

        private Type _integratorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Integrator _integratorInstance;
        private Integrator _integratorInstanceFixture;

        #region General Initializer : Class (Integrator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Integrator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integratorInstanceType = typeof(Integrator);
            _integratorInstanceFixture = this.Create<Integrator>(true);
            _integratorInstance = _integratorInstanceFixture ?? this.Create<Integrator>(false);
            CurrentInstance = _integratorInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Integrator)

        #region General Initializer : Class (Integrator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Integrator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodBuildIdMap, 0)]
        [TestCase(MethodGetAuthInfo, 0)]
        [TestCase(MethodGetPowerSteeringService, 0)]
        [TestCase(MethodProcessResults, 0)]
        [TestCase(MethodUpdateItems, 0)]
        [TestCase(MethodDeleteItems, 0)]
        [TestCase(MethodGetColumns, 0)]
        [TestCase(MethodPullData, 0)]
        [TestCase(MethodGetItem, 0)]
        [TestCase(MethodGetDropDownValues, 0)]
        [TestCase(MethodTestConnection, 0)]
        [TestCase(MethodInstallIntegration, 0)]
        [TestCase(MethodRemoveIntegration, 0)]
        [TestCase(MethodGetEmbeddedItemControls, 0)]
        [TestCase(MethodGetPageButtons, 0)]
        [TestCase(MethodGetURL, 0)]
        [TestCase(MethodGetControlCode, 0)]
        [TestCase(MethodGetProxyResult, 0)]
        public void AUT_Integrator_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integratorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Integrator) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Integrator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPROJECT_INFO_URL)]
        [TestCase(FieldUPSERT_ERROR_MESSAGE)]
        public void AUT_Integrator_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_integratorInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="Integrator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Integrator_Is_Instance_Present_Test()
        {
            // Assert
            _integratorInstanceType.ShouldNotBeNull();
            _integratorInstance.ShouldNotBeNull();
            _integratorInstanceFixture.ShouldNotBeNull();
            _integratorInstance.ShouldBeAssignableTo<Integrator>();
            _integratorInstanceFixture.ShouldBeAssignableTo<Integrator>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Integrator) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Integrator_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Integrator instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _integratorInstanceType.ShouldNotBeNull();
            _integratorInstance.ShouldNotBeNull();
            _integratorInstanceFixture.ShouldNotBeNull();
            _integratorInstance.ShouldBeAssignableTo<Integrator>();
            _integratorInstanceFixture.ShouldBeAssignableTo<Integrator>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_BuildIdMap_Method_Call_Internally(Type[] types)
        {
            var methodBuildIdMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            var items = this.CreateType<DataTable>();
            var ids = this.CreateType<List<string>>();
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            object[] parametersOfBuildIdMap = { items, ids };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodBuildIdMap, methodBuildIdMapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfBuildIdMap);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildIdMap.ShouldNotBeNull();
            parametersOfBuildIdMap.Length.ShouldBe(2);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            var items = this.CreateType<DataTable>();
            var ids = this.CreateType<List<string>>();
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            object[] parametersOfBuildIdMap = { items, ids };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, Dictionary<string, string>>(_integratorInstance, MethodBuildIdMap, parametersOfBuildIdMap, methodBuildIdMapPrametersTypes);

            // Assert
            parametersOfBuildIdMap.ShouldNotBeNull();
            parametersOfBuildIdMap.Length.ShouldBe(2);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodBuildIdMap, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodBuildIdMap);
            var methodInfo = this.GetMethodInfo(MethodBuildIdMap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetAuthInfo_Method_Call_Internally(Type[] types)
        {
            var methodGetAuthInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetAuthInfo, Fixture, methodGetAuthInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthInfo_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAuthInfo);
            var webProps = this.CreateType<WebProperties>();
            var serverUrl = this.CreateType<string>();
            var contextName = this.CreateType<string>();
            var apiKey = this.CreateType<string>();
            var apiSecret = this.CreateType<SecureString>();
            var methodGetAuthInfoPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(string), typeof(string), typeof(SecureString) };
            object[] parametersOfGetAuthInfo = { webProps, serverUrl, contextName, apiKey, apiSecret };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetAuthInfo, methodGetAuthInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetAuthInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAuthInfo.ShouldNotBeNull();
            parametersOfGetAuthInfo.Length.ShouldBe(5);
            methodGetAuthInfoPrametersTypes.Length.ShouldBe(5);
            methodGetAuthInfoPrametersTypes.Length.ShouldBe(parametersOfGetAuthInfo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthInfo_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAuthInfo);
            var webProps = this.CreateType<WebProperties>();
            var serverUrl = this.CreateType<string>();
            var contextName = this.CreateType<string>();
            var apiKey = this.CreateType<string>();
            var apiSecret = this.CreateType<SecureString>();
            var methodGetAuthInfoPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(string), typeof(string), typeof(SecureString) };
            object[] parametersOfGetAuthInfo = { webProps, serverUrl, contextName, apiKey, apiSecret };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integratorInstance, MethodGetAuthInfo, parametersOfGetAuthInfo, methodGetAuthInfoPrametersTypes);

            // Assert
            parametersOfGetAuthInfo.ShouldNotBeNull();
            parametersOfGetAuthInfo.Length.ShouldBe(5);
            methodGetAuthInfoPrametersTypes.Length.ShouldBe(5);
            methodGetAuthInfoPrametersTypes.Length.ShouldBe(parametersOfGetAuthInfo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAuthInfo);
            var methodInfo = this.GetMethodInfo(MethodGetAuthInfo, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAuthInfo);
            var methodGetAuthInfoPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(string), typeof(string), typeof(SecureString) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetAuthInfo, Fixture, methodGetAuthInfoPrametersTypes);

            // Assert
            methodGetAuthInfoPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthInfo_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAuthInfo);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAuthInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPowerSteeringService) (Return Type : PowerSteeringService) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetPowerSteeringService_Method_Call_Internally(Type[] types)
        {
            var methodGetPowerSteeringServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPowerSteeringService, Fixture, methodGetPowerSteeringServicePrametersTypes);
        }

        #endregion

        #region Method Call : (GetPowerSteeringService) (Return Type : PowerSteeringService) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPowerSteeringService_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPowerSteeringService);
            var methodGetPowerSteeringServicePrametersTypes = new Type[] { typeof(WebProperties) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPowerSteeringService, Fixture, methodGetPowerSteeringServicePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPowerSteeringServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPowerSteeringService) (Return Type : PowerSteeringService) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPowerSteeringService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPowerSteeringService);
            var methodGetPowerSteeringServicePrametersTypes = new Type[] { typeof(WebProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPowerSteeringService, Fixture, methodGetPowerSteeringServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPowerSteeringServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPowerSteeringService) (Return Type : PowerSteeringService) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPowerSteeringService_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPowerSteeringService);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPowerSteeringService, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPowerSteeringService) (Return Type : PowerSteeringService) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPowerSteeringService_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPowerSteeringService);
            var methodInfo = this.GetMethodInfo(MethodGetPowerSteeringService, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessResults) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_ProcessResults_Method_Call_Internally(Type[] types)
        {
            var methodProcessResultsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodProcessResults, Fixture, methodProcessResultsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ProcessResults) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_ProcessResults_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessResults);
            var methodInfo = this.GetMethodInfo(MethodProcessResults, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ProcessResults) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_ProcessResults_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessResults);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessResults, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.UpdateItems(webProps, items, log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { webProps, items, log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, TransactionTable>(_integratorInstanceFixture, out exception1, parametersOfUpdateItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { webProps, items, log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var methodInfo = this.GetMethodInfo(MethodUpdateItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_DeleteItems_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.DeleteItems(webProps, items, log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { webProps, items, log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodDeleteItems, methodDeleteItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, TransactionTable>(_integratorInstanceFixture, out exception1, parametersOfDeleteItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var webProps = this.CreateType<WebProperties>();
            var items = this.CreateType<DataTable>();
            var log = this.CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { webProps, items, log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes);

            // Assert
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodDeleteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var methodInfo = this.GetMethodInfo(MethodDeleteItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var listName = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetColumns(webProps, log, listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var listName = this.CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { webProps, log, listName };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetColumns, methodGetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, List<ColumnProperty>>(_integratorInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, List<ColumnProperty>>(_integratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var listName = this.CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { webProps, log, listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, List<ColumnProperty>>(_integratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var methodInfo = this.GetMethodInfo(MethodGetColumns, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion
        
        #region Method Call : (PullData) (Return Type : DataTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var items = this.CreateType<DataTable>();
            var lastSynchDate = this.CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.PullData(webProps, log, items, lastSynchDate);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion
        
        #region Method Call : (PullData) (Return Type : DataTable) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var items = this.CreateType<DataTable>();
            var lastSynchDate = this.CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { webProps, log, items, lastSynchDate };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, DataTable>(_integratorInstanceFixture, out exception1, parametersOfPullData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var items = this.CreateType<DataTable>();
            var lastSynchDate = this.CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { webProps, log, items, lastSynchDate };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfPullData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var items = this.CreateType<DataTable>();
            var lastSynchDate = this.CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { webProps, log, items, lastSynchDate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var methodInfo = this.GetMethodInfo(MethodPullData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetItem_Method_Call_Internally(Type[] types)
        {
            var methodGetItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var items = this.CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetItem(webProps, log, itemId, items);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var items = this.CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { webProps, log, itemId, items };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetItem, methodGetItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, DataTable>(_integratorInstanceFixture, out exception1, parametersOfGetItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var items = this.CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { webProps, log, itemId, items };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

            // Assert
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var methodInfo = this.GetMethodInfo(MethodGetItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetDropDownValues_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var property = this.CreateType<string>();
            var parentpropertyValue = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetDropDownValues(webProps, log, property, parentpropertyValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var property = this.CreateType<string>();
            var parentpropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { webProps, log, property, parentpropertyValue };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, Dictionary<string, string>>(_integratorInstanceFixture, out exception1, parametersOfGetDropDownValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, Dictionary<string, string>>(_integratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var property = this.CreateType<string>();
            var parentpropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { webProps, log, property, parentpropertyValue };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetDropDownValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var property = this.CreateType<string>();
            var parentpropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { webProps, log, property, parentpropertyValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, Dictionary<string, string>>(_integratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

            // Assert
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_TestConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.TestConnection(webProps, log, out message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { webProps, log, message };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, methodTestConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfTestConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { webProps, log, message };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, methodTestConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfTestConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { webProps, log, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

            // Assert
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var methodInfo = this.GetMethodInfo(MethodTestConnection, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var apiUrl = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.InstallIntegration(webProps, log, out message, integrationKey, apiUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var apiUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var apiUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var apiUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfInstallIntegration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var apiUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.RemoveIntegration(webProps, log, out message, integrationKey);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfRemoveIntegration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var message = this.CreateType<string>();
            var integrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

            // Assert
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetEmbeddedItemControls_Method_Call_Internally(Type[] types)
        {
            var methodGetEmbeddedItemControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetEmbeddedItemControls(webProps, log);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { webProps, log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, List<string>>(_integratorInstanceFixture, out exception1, parametersOfGetEmbeddedItemControls);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, List<string>>(_integratorInstance, MethodGetEmbeddedItemControls, parametersOfGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetEmbeddedItemControls.ShouldNotBeNull();
            parametersOfGetEmbeddedItemControls.Length.ShouldBe(2);
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { webProps, log };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetEmbeddedItemControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEmbeddedItemControls.ShouldNotBeNull();
            parametersOfGetEmbeddedItemControls.Length.ShouldBe(2);
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { webProps, log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, List<string>>(_integratorInstance, MethodGetEmbeddedItemControls, parametersOfGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            parametersOfGetEmbeddedItemControls.ShouldNotBeNull();
            parametersOfGetEmbeddedItemControls.Length.ShouldBe(2);
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetEmbeddedItemControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetPageButtons_Method_Call_Internally(Type[] types)
        {
            var methodGetPageButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var globalButtons = this.CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetPageButtons(webProps, log, globalButtons);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var globalButtons = this.CreateType<bool>();
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            object[] parametersOfGetPageButtons = { webProps, log, globalButtons };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, methodGetPageButtonsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, List<IntegrationControl>>(_integratorInstanceFixture, out exception1, parametersOfGetPageButtons);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, List<IntegrationControl>>(_integratorInstance, MethodGetPageButtons, parametersOfGetPageButtons, methodGetPageButtonsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPageButtons.ShouldNotBeNull();
            parametersOfGetPageButtons.Length.ShouldBe(3);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var globalButtons = this.CreateType<bool>();
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            object[] parametersOfGetPageButtons = { webProps, log, globalButtons };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, List<IntegrationControl>>(_integratorInstance, MethodGetPageButtons, parametersOfGetPageButtons, methodGetPageButtonsPrametersTypes);

            // Assert
            parametersOfGetPageButtons.ShouldNotBeNull();
            parametersOfGetPageButtons.Length.ShouldBe(3);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetPageButtons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetURL_Method_Call_Internally(Type[] types)
        {
            var methodGetURLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var control = this.CreateType<string>();
            var itemId = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetURL(webProps, log, control, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var control = this.CreateType<string>();
            var itemId = this.CreateType<string>();
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetURL = { webProps, log, control, itemId };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetURL, methodGetURLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, string>(_integratorInstanceFixture, out exception1, parametersOfGetURL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetURL, parametersOfGetURL, methodGetURLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetURL.ShouldNotBeNull();
            parametersOfGetURL.Length.ShouldBe(4);
            methodGetURLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var control = this.CreateType<string>();
            var itemId = this.CreateType<string>();
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetURL = { webProps, log, control, itemId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetURL, parametersOfGetURL, methodGetURLPrametersTypes);

            // Assert
            parametersOfGetURL.ShouldNotBeNull();
            parametersOfGetURL.Length.ShouldBe(4);
            methodGetURLPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetURLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetURLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetURL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetURL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var methodInfo = this.GetMethodInfo(MethodGetURL, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetControlCode_Method_Call_Internally(Type[] types)
        {
            var methodGetControlCodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetControlCode(webProps, log, itemId, control);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { webProps, log, itemId, control };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, methodGetControlCodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, string>(_integratorInstanceFixture, out exception1, parametersOfGetControlCode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetControlCode, parametersOfGetControlCode, methodGetControlCodePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetControlCode.ShouldNotBeNull();
            parametersOfGetControlCode.Length.ShouldBe(4);
            methodGetControlCodePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { webProps, log, itemId, control };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, methodGetControlCodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetControlCode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetControlCode.ShouldNotBeNull();
            parametersOfGetControlCode.Length.ShouldBe(4);
            methodGetControlCodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { webProps, log, itemId, control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetControlCode, parametersOfGetControlCode, methodGetControlCodePrametersTypes);

            // Assert
            parametersOfGetControlCode.ShouldNotBeNull();
            parametersOfGetControlCode.Length.ShouldBe(4);
            methodGetControlCodePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetControlCodePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlCodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetControlCode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetProxyResult_Method_Call_Internally(Type[] types)
        {
            var methodGetProxyResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var property = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetProxyResult(webProps, log, itemId, control, property);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { webProps, log, itemId, control, property };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, methodGetProxyResultPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, string>(_integratorInstanceFixture, out exception1, parametersOfGetProxyResult);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetProxyResult.ShouldNotBeNull();
            parametersOfGetProxyResult.Length.ShouldBe(5);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { webProps, log, itemId, control, property };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, methodGetProxyResultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetProxyResult);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProxyResult.ShouldNotBeNull();
            parametersOfGetProxyResult.Length.ShouldBe(5);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var itemId = this.CreateType<string>();
            var control = this.CreateType<string>();
            var property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { webProps, log, itemId, control, property };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes);

            // Assert
            parametersOfGetProxyResult.ShouldNotBeNull();
            parametersOfGetProxyResult.Length.ShouldBe(5);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetProxyResultPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetProxyResult_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}