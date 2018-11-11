using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.Win32;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Features.EPMLiveLogging
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Features.EPMLiveLogging.EPMLiveLoggingEventReceiver" />)
    ///     and namespace <see cref="EPMLiveCore.Features.EPMLiveLogging"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class EPMLiveLoggingEventReceiverTest : AbstractBaseSetupTypedTest<EPMLiveLoggingEventReceiver>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveLoggingEventReceiver) Initializer

        private const string MethodFeatureActivated = "FeatureActivated";
        private const string MethodFeatureDeactivating = "FeatureDeactivating";
        private const string MethodRegisterLoggingService = "RegisterLoggingService";
        private const string MethodRegisterKey = "RegisterKey";
        private const string MethodUnRegisterLoggingService = "UnRegisterLoggingService";
        private const string MethodDeRegisterKey = "DeRegisterKey";
        private const string FieldEventLogApplicationRegistryKeyPath = "EventLogApplicationRegistryKeyPath";
        private Type _ePMLiveLoggingEventReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveLoggingEventReceiver _ePMLiveLoggingEventReceiverInstance;
        private EPMLiveLoggingEventReceiver _ePMLiveLoggingEventReceiverInstanceFixture;

        #region General Initializer : Class (EPMLiveLoggingEventReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveLoggingEventReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveLoggingEventReceiverInstanceType = typeof(EPMLiveLoggingEventReceiver);
            _ePMLiveLoggingEventReceiverInstanceFixture = Create(true);
            _ePMLiveLoggingEventReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveLoggingEventReceiver)

        #region General Initializer : Class (EPMLiveLoggingEventReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveLoggingEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFeatureActivated, 0)]
        [TestCase(MethodFeatureDeactivating, 0)]
        [TestCase(MethodRegisterLoggingService, 0)]
        [TestCase(MethodRegisterKey, 0)]
        [TestCase(MethodUnRegisterLoggingService, 0)]
        [TestCase(MethodDeRegisterKey, 0)]
        public void AUT_EPMLiveLoggingEventReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveLoggingEventReceiverInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveLoggingEventReceiver) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveLoggingEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEventLogApplicationRegistryKeyPath)]
        public void AUT_EPMLiveLoggingEventReceiver_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveLoggingEventReceiverInstanceFixture, 
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
        ///     Class (<see cref="EPMLiveLoggingEventReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPMLiveLoggingEventReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _ePMLiveLoggingEventReceiverInstanceType.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstance.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstanceFixture.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstance.ShouldBeAssignableTo<EPMLiveLoggingEventReceiver>();
            _ePMLiveLoggingEventReceiverInstanceFixture.ShouldBeAssignableTo<EPMLiveLoggingEventReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveLoggingEventReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPMLiveLoggingEventReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPMLiveLoggingEventReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePMLiveLoggingEventReceiverInstanceType.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstance.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstanceFixture.ShouldNotBeNull();
            _ePMLiveLoggingEventReceiverInstance.ShouldBeAssignableTo<EPMLiveLoggingEventReceiver>();
            _ePMLiveLoggingEventReceiverInstanceFixture.ShouldBeAssignableTo<EPMLiveLoggingEventReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPMLiveLoggingEventReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFeatureActivated)]
        [TestCase(MethodFeatureDeactivating)]
        [TestCase(MethodRegisterLoggingService)]
        [TestCase(MethodRegisterKey)]
        [TestCase(MethodUnRegisterLoggingService)]
        [TestCase(MethodDeRegisterKey)]
        public void AUT_EPMLiveLoggingEventReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveLoggingEventReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_Internally(Type[] types)
        {
            var methodFeatureActivatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveLoggingEventReceiverInstance.FeatureActivated(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, methodFeatureActivatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfFeatureActivated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureActivated.ShouldNotBeNull();
            parametersOfFeatureActivated.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(parametersOfFeatureActivated.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodFeatureActivated, parametersOfFeatureActivated, methodFeatureActivatedPrametersTypes);

            // Assert
            parametersOfFeatureActivated.ShouldNotBeNull();
            parametersOfFeatureActivated.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(parametersOfFeatureActivated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);

            // Assert
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureActivated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_Internally(Type[] types)
        {
            var methodFeatureDeactivatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodFeatureDeactivating, Fixture, methodFeatureDeactivatingPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveLoggingEventReceiverInstance.FeatureDeactivating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureDeactivating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, methodFeatureDeactivatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfFeatureDeactivating);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureDeactivating.ShouldNotBeNull();
            parametersOfFeatureDeactivating.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(parametersOfFeatureDeactivating.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureDeactivating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodFeatureDeactivating, parametersOfFeatureDeactivating, methodFeatureDeactivatingPrametersTypes);

            // Assert
            parametersOfFeatureDeactivating.ShouldNotBeNull();
            parametersOfFeatureDeactivating.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(parametersOfFeatureDeactivating.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodFeatureDeactivating, Fixture, methodFeatureDeactivatingPrametersTypes);

            // Assert
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_FeatureDeactivating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_Internally(Type[] types)
        {
            var methodRegisterLoggingServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodRegisterLoggingService, Fixture, methodRegisterLoggingServicePrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfRegisterLoggingService = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterLoggingService, methodRegisterLoggingServicePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfRegisterLoggingService);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterLoggingService.ShouldNotBeNull();
            parametersOfRegisterLoggingService.Length.ShouldBe(1);
            methodRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            methodRegisterLoggingServicePrametersTypes.Length.ShouldBe(parametersOfRegisterLoggingService.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfRegisterLoggingService = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodRegisterLoggingService, parametersOfRegisterLoggingService, methodRegisterLoggingServicePrametersTypes);

            // Assert
            parametersOfRegisterLoggingService.ShouldNotBeNull();
            parametersOfRegisterLoggingService.Length.ShouldBe(1);
            methodRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            methodRegisterLoggingServicePrametersTypes.Length.ShouldBe(parametersOfRegisterLoggingService.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterLoggingService, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodRegisterLoggingService, Fixture, methodRegisterLoggingServicePrametersTypes);

            // Assert
            methodRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterLoggingService) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterLoggingService_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterLoggingService, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_Internally(Type[] types)
        {
            var methodRegisterKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodRegisterKey, Fixture, methodRegisterKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var baseKey = CreateType<RegistryKey>();
            var key = CreateType<string>();
            var methodRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };
            object[] parametersOfRegisterKey = { baseKey, key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterKey, methodRegisterKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfRegisterKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterKey.ShouldNotBeNull();
            parametersOfRegisterKey.Length.ShouldBe(2);
            methodRegisterKeyPrametersTypes.Length.ShouldBe(2);
            methodRegisterKeyPrametersTypes.Length.ShouldBe(parametersOfRegisterKey.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var baseKey = CreateType<RegistryKey>();
            var key = CreateType<string>();
            var methodRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };
            object[] parametersOfRegisterKey = { baseKey, key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodRegisterKey, parametersOfRegisterKey, methodRegisterKeyPrametersTypes);

            // Assert
            parametersOfRegisterKey.ShouldNotBeNull();
            parametersOfRegisterKey.Length.ShouldBe(2);
            methodRegisterKeyPrametersTypes.Length.ShouldBe(2);
            methodRegisterKeyPrametersTypes.Length.ShouldBe(parametersOfRegisterKey.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterKey, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodRegisterKey, Fixture, methodRegisterKeyPrametersTypes);

            // Assert
            methodRegisterKeyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterKey) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_RegisterKey_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterKey, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_Internally(Type[] types)
        {
            var methodUnRegisterLoggingServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodUnRegisterLoggingService, Fixture, methodUnRegisterLoggingServicePrametersTypes);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodUnRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfUnRegisterLoggingService = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUnRegisterLoggingService, methodUnRegisterLoggingServicePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfUnRegisterLoggingService);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUnRegisterLoggingService.ShouldNotBeNull();
            parametersOfUnRegisterLoggingService.Length.ShouldBe(1);
            methodUnRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            methodUnRegisterLoggingServicePrametersTypes.Length.ShouldBe(parametersOfUnRegisterLoggingService.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodUnRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfUnRegisterLoggingService = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodUnRegisterLoggingService, parametersOfUnRegisterLoggingService, methodUnRegisterLoggingServicePrametersTypes);

            // Assert
            parametersOfUnRegisterLoggingService.ShouldNotBeNull();
            parametersOfUnRegisterLoggingService.Length.ShouldBe(1);
            methodUnRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            methodUnRegisterLoggingServicePrametersTypes.Length.ShouldBe(parametersOfUnRegisterLoggingService.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnRegisterLoggingService, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnRegisterLoggingServicePrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodUnRegisterLoggingService, Fixture, methodUnRegisterLoggingServicePrametersTypes);

            // Assert
            methodUnRegisterLoggingServicePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnRegisterLoggingService) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_UnRegisterLoggingService_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnRegisterLoggingService, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_Internally(Type[] types)
        {
            var methodDeRegisterKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodDeRegisterKey, Fixture, methodDeRegisterKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var baseKey = CreateType<RegistryKey>();
            var key = CreateType<string>();
            var methodDeRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };
            object[] parametersOfDeRegisterKey = { baseKey, key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeRegisterKey, methodDeRegisterKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveLoggingEventReceiverInstanceFixture, parametersOfDeRegisterKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeRegisterKey.ShouldNotBeNull();
            parametersOfDeRegisterKey.Length.ShouldBe(2);
            methodDeRegisterKeyPrametersTypes.Length.ShouldBe(2);
            methodDeRegisterKeyPrametersTypes.Length.ShouldBe(parametersOfDeRegisterKey.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var baseKey = CreateType<RegistryKey>();
            var key = CreateType<string>();
            var methodDeRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };
            object[] parametersOfDeRegisterKey = { baseKey, key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveLoggingEventReceiverInstance, MethodDeRegisterKey, parametersOfDeRegisterKey, methodDeRegisterKeyPrametersTypes);

            // Assert
            parametersOfDeRegisterKey.ShouldNotBeNull();
            parametersOfDeRegisterKey.Length.ShouldBe(2);
            methodDeRegisterKeyPrametersTypes.Length.ShouldBe(2);
            methodDeRegisterKeyPrametersTypes.Length.ShouldBe(parametersOfDeRegisterKey.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeRegisterKey, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeRegisterKeyPrametersTypes = new Type[] { typeof(RegistryKey), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveLoggingEventReceiverInstance, MethodDeRegisterKey, Fixture, methodDeRegisterKeyPrametersTypes);

            // Assert
            methodDeRegisterKeyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeRegisterKey) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveLoggingEventReceiver_DeRegisterKey_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeRegisterKey, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveLoggingEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}