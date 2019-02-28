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
using EPMLiveIntegration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.ServiceNow;
using ServiceNowIntegrator = UplandIntegrations.ServiceNow;

namespace UplandIntegrations.ServiceNow
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.ServiceNow.ServiceNowIntegrator" />)
    ///     and namespace <see cref="UplandIntegrations.ServiceNow"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public class ServiceNowIntegratorTest : AbstractBaseSetupV3Test
    {
        public ServiceNowIntegratorTest() : base(typeof(ServiceNowIntegrator))
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

        #region General Initializer : Class (ServiceNowIntegrator) Initializer

        #region Methods

        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodGetControls = "GetControls";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodGetDropDownValues = "GetDropDownValues";
        private const string MethodTestConnection = "TestConnection";
        private const string MethodDeleteItems = "DeleteItems";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodGetItem = "GetItem";
        private const string MethodPullData = "PullData";
        private const string MethodCheckWebProps = "CheckWebProps";
        private const string MethodGetDefaultColumn = "GetDefaultColumn";
        private const string MethodGetControlCode = "GetControlCode";
        private const string MethodGetEmbeddedItemControls = "GetEmbeddedItemControls";
        private const string MethodGetPageButtons = "GetPageButtons";
        private const string MethodGetURL = "GetURL";
        private const string MethodGetProxyResult = "GetProxyResult";

        #endregion

        private Type _serviceNowIntegratorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ServiceNowIntegrator _serviceNowIntegratorInstance;
        private ServiceNowIntegrator _serviceNowIntegratorInstanceFixture;

        #region General Initializer : Class (ServiceNowIntegrator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ServiceNowIntegrator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _serviceNowIntegratorInstanceType = typeof(ServiceNowIntegrator);
            _serviceNowIntegratorInstanceFixture = this.Create<ServiceNowIntegrator>(true);
            _serviceNowIntegratorInstance = _serviceNowIntegratorInstanceFixture ?? this.Create<ServiceNowIntegrator>(false);
            CurrentInstance = _serviceNowIntegratorInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ServiceNowIntegrator)

        #region General Initializer : Class (ServiceNowIntegrator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ServiceNowIntegrator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstallIntegration, 0)]
        [TestCase(MethodRemoveIntegration, 0)]
        [TestCase(MethodGetControls, 0)]
        [TestCase(MethodGetColumns, 0)]
        [TestCase(MethodGetDropDownValues, 0)]
        [TestCase(MethodTestConnection, 0)]
        [TestCase(MethodDeleteItems, 0)]
        [TestCase(MethodUpdateItems, 0)]
        [TestCase(MethodGetItem, 0)]
        [TestCase(MethodPullData, 0)]
        [TestCase(MethodCheckWebProps, 0)]
        [TestCase(MethodGetDefaultColumn, 0)]
        [TestCase(MethodGetControlCode, 0)]
        [TestCase(MethodGetEmbeddedItemControls, 0)]
        [TestCase(MethodGetPageButtons, 0)]
        [TestCase(MethodGetURL, 0)]
        [TestCase(MethodGetProxyResult, 0)]
        public void AUT_ServiceNowIntegrator_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_serviceNowIntegratorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ServiceNowIntegrator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ServiceNowIntegrator_Is_Instance_Present_Test()
        {
            // Assert
            _serviceNowIntegratorInstanceType.ShouldNotBeNull();
            _serviceNowIntegratorInstance.ShouldNotBeNull();
            _serviceNowIntegratorInstanceFixture.ShouldNotBeNull();
            _serviceNowIntegratorInstance.ShouldBeAssignableTo<ServiceNowIntegrator>();
            _serviceNowIntegratorInstanceFixture.ShouldBeAssignableTo<ServiceNowIntegrator>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ServiceNowIntegrator) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ServiceNowIntegrator_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ServiceNowIntegrator instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _serviceNowIntegratorInstanceType.ShouldNotBeNull();
            _serviceNowIntegratorInstance.ShouldNotBeNull();
            _serviceNowIntegratorInstanceFixture.ShouldNotBeNull();
            _serviceNowIntegratorInstance.ShouldBeAssignableTo<ServiceNowIntegrator>();
            _serviceNowIntegratorInstanceFixture.ShouldBeAssignableTo<ServiceNowIntegrator>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var APIUrl = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.InstallIntegration(WebProps, Log, out Message, IntegrationKey, APIUrl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var APIUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { WebProps, Log, Message, IntegrationKey, APIUrl };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var APIUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { WebProps, Log, Message, IntegrationKey, APIUrl };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

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

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var APIUrl = this.CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { WebProps, Log, Message, IntegrationKey, APIUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodInstallIntegration);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.RemoveIntegration(WebProps, Log, out Message, IntegrationKey);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { WebProps, Log, Message, IntegrationKey };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { WebProps, Log, Message, IntegrationKey };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

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

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var IntegrationKey = this.CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { WebProps, Log, Message, IntegrationKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRemoveIntegration);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetControls_Method_Call_Internally(Type[] types)
        {
            var methodGetControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControls, Fixture, methodGetControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetControls(WebProps, Log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var methodGetControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetControls = { WebProps, Log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetControls, methodGetControlsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetControls);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstance, MethodGetControls, parametersOfGetControls, methodGetControlsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetControls.ShouldNotBeNull();
            parametersOfGetControls.Length.ShouldBe(2);
            methodGetControlsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var methodGetControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetControls = { WebProps, Log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstance, MethodGetControls, parametersOfGetControls, methodGetControlsPrametersTypes);

            // Assert
            parametersOfGetControls.ShouldNotBeNull();
            parametersOfGetControls.Length.ShouldBe(2);
            methodGetControlsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var methodGetControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControls, Fixture, methodGetControlsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetControlsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var methodGetControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControls, Fixture, methodGetControlsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetControls, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControls) (Return Type : List<IntegrationControl>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControls);
            var methodInfo = this.GetMethodInfo(MethodGetControls, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ListName = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetColumns(WebProps, Log, ListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ListName = this.CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { WebProps, Log, ListName };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetColumns, methodGetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, List<ColumnProperty>>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<ColumnProperty>>(_serviceNowIntegratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ListName = this.CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { WebProps, Log, ListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<ColumnProperty>>(_serviceNowIntegratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetColumns_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Property = this.CreateType<string>();
            var ParentPropertyValue = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetDropDownValues(WebProps, log, Property, ParentPropertyValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Property = this.CreateType<string>();
            var ParentPropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, Dictionary<string, string>>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetDropDownValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, Dictionary<string, string>>(_serviceNowIntegratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Property = this.CreateType<string>();
            var ParentPropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetDropDownValues);

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
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Property = this.CreateType<string>();
            var ParentPropertyValue = this.CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, Dictionary<string, string>>(_serviceNowIntegratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDropDownValues);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetDropDownValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDropDownValues_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ServiceNowIntegrator_TestConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_TestConnection_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.TestConnection(WebProps, Log, out Message);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { WebProps, Log, Message };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, methodTestConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfTestConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { WebProps, Log, Message };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, methodTestConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfTestConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var Message = this.CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { WebProps, Log, Message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, bool>(_serviceNowIntegratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodTestConnection);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodTestConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_TestConnection_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.DeleteItems(WebProps, Items, Log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { WebProps, Items, Log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodDeleteItems, methodDeleteItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfDeleteItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { WebProps, Items, Log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDeleteItems);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodDeleteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_DeleteItems_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.UpdateItems(WebProps, Items, Log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { WebProps, Items, Log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfUpdateItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var WebProps = this.CreateType<WebProperties>();
            var Items = this.CreateType<DataTable>();
            var Log = this.CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { WebProps, Items, Log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, TransactionTable>(_serviceNowIntegratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpdateItems);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetItem) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetItem_Method_Call_Internally(Type[] types)
        {
            var methodGetItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Items = this.CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetItem(WebProps, log, ItemID, Items);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Items = this.CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { WebProps, log, ItemID, Items };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetItem, methodGetItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Items = this.CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { WebProps, log, ItemID, Items };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetItem);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetItem_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (PullData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Items = this.CreateType<DataTable>();
            var LastSynchDate = this.CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.PullData(WebProps, log, Items, LastSynchDate);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Items = this.CreateType<DataTable>();
            var LastSynchDate = this.CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { WebProps, log, Items, LastSynchDate };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfPullData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var WebProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var Items = this.CreateType<DataTable>();
            var LastSynchDate = this.CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { WebProps, log, Items, LastSynchDate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, DataTable>(_serviceNowIntegratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPullData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_PullData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (CheckWebProps) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_Internally(Type[] types)
        {
            var methodCheckWebPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodCheckWebProps, Fixture, methodCheckWebPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckWebProps) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckWebProps);
            var WebProps = this.CreateType<WebProperties>();
            var checkOtherWebProperties = this.CreateType<Boolean>();
            var methodCheckWebPropsPrametersTypes = new Type[] { typeof(WebProperties), typeof(Boolean) };
            object[] parametersOfCheckWebProps = { WebProps, checkOtherWebProperties };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodCheckWebProps, methodCheckWebPropsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfCheckWebProps);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckWebProps.ShouldNotBeNull();
            parametersOfCheckWebProps.Length.ShouldBe(2);
            methodCheckWebPropsPrametersTypes.Length.ShouldBe(2);
            methodCheckWebPropsPrametersTypes.Length.ShouldBe(parametersOfCheckWebProps.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckWebProps) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckWebProps);
            var WebProps = this.CreateType<WebProperties>();
            var checkOtherWebProperties = this.CreateType<Boolean>();
            var methodCheckWebPropsPrametersTypes = new Type[] { typeof(WebProperties), typeof(Boolean) };
            object[] parametersOfCheckWebProps = { WebProps, checkOtherWebProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_serviceNowIntegratorInstance, MethodCheckWebProps, parametersOfCheckWebProps, methodCheckWebPropsPrametersTypes);

            // Assert
            parametersOfCheckWebProps.ShouldNotBeNull();
            parametersOfCheckWebProps.Length.ShouldBe(2);
            methodCheckWebPropsPrametersTypes.Length.ShouldBe(2);
            methodCheckWebPropsPrametersTypes.Length.ShouldBe(parametersOfCheckWebProps.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckWebProps) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckWebProps);
            var methodInfo = this.GetMethodInfo(MethodCheckWebProps, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckWebProps) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckWebProps);
            var methodCheckWebPropsPrametersTypes = new Type[] { typeof(WebProperties), typeof(Boolean) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodCheckWebProps, Fixture, methodCheckWebPropsPrametersTypes);

            // Assert
            methodCheckWebPropsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckWebProps) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_CheckWebProps_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodCheckWebProps);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodCheckWebProps, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            var objectName = this.CreateType<string>();
            var columnName = this.CreateType<string>();
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetDefaultColumn = { objectName, columnName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetDefaultColumn, methodGetDefaultColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetDefaultColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultColumn.ShouldNotBeNull();
            parametersOfGetDefaultColumn.Length.ShouldBe(2);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            var objectName = this.CreateType<string>();
            var columnName = this.CreateType<string>();
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetDefaultColumn = { objectName, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetDefaultColumn, parametersOfGetDefaultColumn, methodGetDefaultColumnPrametersTypes);

            // Assert
            parametersOfGetDefaultColumn.ShouldNotBeNull();
            parametersOfGetDefaultColumn.Length.ShouldBe(2);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetDefaultColumn, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetDefaultColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDefaultColumn);
            var methodInfo = this.GetMethodInfo(MethodGetDefaultColumn, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_Internally(Type[] types)
        {
            var methodGetControlCodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetControlCode(WebProps, Log, ItemID, Control);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { WebProps, Log, ItemID, Control };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, methodGetControlCodePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, string>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetControlCode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetControlCode, parametersOfGetControlCode, methodGetControlCodePrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { WebProps, Log, ItemID, Control };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, methodGetControlCodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetControlCode);

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
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetControlCode = { WebProps, Log, ItemID, Control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetControlCode, parametersOfGetControlCode, methodGetControlCodePrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetControlCodePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            var methodGetControlCodePrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetControlCode, Fixture, methodGetControlCodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlCodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetControlCode);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetControlCode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetControlCode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetControlCode_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_Internally(Type[] types)
        {
            var methodGetEmbeddedItemControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetEmbeddedItemControls(WebProps, Log);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { WebProps, Log };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, List<string>>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetEmbeddedItemControls);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<string>>(_serviceNowIntegratorInstance, MethodGetEmbeddedItemControls, parametersOfGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { WebProps, Log };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetEmbeddedItemControls);

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
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfGetEmbeddedItemControls = { WebProps, Log };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<string>>(_serviceNowIntegratorInstance, MethodGetEmbeddedItemControls, parametersOfGetEmbeddedItemControls, methodGetEmbeddedItemControlsPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            var methodGetEmbeddedItemControlsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetEmbeddedItemControls, Fixture, methodGetEmbeddedItemControlsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEmbeddedItemControlsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetEmbeddedItemControls);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetEmbeddedItemControls, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEmbeddedItemControls) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetEmbeddedItemControls_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_Internally(Type[] types)
        {
            var methodGetPageButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var GlobalButtons = this.CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetPageButtons(WebProps, Log, GlobalButtons);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var GlobalButtons = this.CreateType<bool>();
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            object[] parametersOfGetPageButtons = { WebProps, Log, GlobalButtons };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, methodGetPageButtonsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetPageButtons);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstance, MethodGetPageButtons, parametersOfGetPageButtons, methodGetPageButtonsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetPageButtons.ShouldNotBeNull();
            parametersOfGetPageButtons.Length.ShouldBe(3);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var GlobalButtons = this.CreateType<bool>();
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            object[] parametersOfGetPageButtons = { WebProps, Log, GlobalButtons };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, methodGetPageButtonsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetPageButtons);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPageButtons.ShouldNotBeNull();
            parametersOfGetPageButtons.Length.ShouldBe(3);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var GlobalButtons = this.CreateType<bool>();
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            object[] parametersOfGetPageButtons = { WebProps, Log, GlobalButtons };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, List<IntegrationControl>>(_serviceNowIntegratorInstance, MethodGetPageButtons, parametersOfGetPageButtons, methodGetPageButtonsPrametersTypes);

            // Assert
            parametersOfGetPageButtons.ShouldNotBeNull();
            parametersOfGetPageButtons.Length.ShouldBe(3);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            var methodGetPageButtonsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetPageButtons, Fixture, methodGetPageButtonsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPageButtonsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPageButtons);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPageButtons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPageButtons) (Return Type : List<IntegrationControl>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetPageButtons_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ServiceNowIntegrator_GetURL_Method_Call_Internally(Type[] types)
        {
            var methodGetURLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetURL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var webProps = this.CreateType<WebProperties>();
            var log = this.CreateType<IntegrationLog>();
            var control = this.CreateType<string>();
            var itemId = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetURL(webProps, log, control, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, string>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetURL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetURL, parametersOfGetURL, methodGetURLPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetURL, parametersOfGetURL, methodGetURLPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetURLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            var methodGetURLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetURL, Fixture, methodGetURLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetURLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetURL);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetURL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetURL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetURL_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetProxyResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_Internally(Type[] types)
        {
            var methodGetProxyResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var Property = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _serviceNowIntegratorInstance.GetProxyResult(WebProps, Log, ItemID, Control, Property);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var Property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { WebProps, Log, ItemID, Control, Property };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, methodGetProxyResultPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ServiceNowIntegrator, string>(_serviceNowIntegratorInstanceFixture, out exception1, parametersOfGetProxyResult);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var Property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { WebProps, Log, ItemID, Control, Property };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, methodGetProxyResultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceNowIntegratorInstanceFixture, parametersOfGetProxyResult);

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
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var WebProps = this.CreateType<WebProperties>();
            var Log = this.CreateType<IntegrationLog>();
            var ItemID = this.CreateType<string>();
            var Control = this.CreateType<string>();
            var Property = this.CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { WebProps, Log, ItemID, Control, Property };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ServiceNowIntegrator, string>(_serviceNowIntegratorInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes);

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
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetProxyResultPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceNowIntegratorInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProxyResult);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetProxyResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceNowIntegratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ServiceNowIntegrator_GetProxyResult_Method_Call_Parameters_Count_Verification_Test()
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