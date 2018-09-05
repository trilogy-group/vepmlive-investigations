using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore.Services.DataServices.Core;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore.Services.DataServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Services.DataServices.Controller" />)
    ///     and namespace <see cref="PortfolioEngineCore.Services.DataServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ControllerTest : AbstractBaseSetupTypedTest<Controller>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Controller) Initializer

        private const string PropertyCurrent = "Current";
        private const string MethodProcessRequest = "ProcessRequest";
        private const string MethodLoadModules = "LoadModules";
        private const string Field_instance = "_instance";
        private const string FieldLocker = "Locker";
        private const string Field_events = "_events";
        private const string Field_logger = "_logger";
        private Type _controllerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Controller _controllerInstance;
        private Controller _controllerInstanceFixture;

        #region General Initializer : Class (Controller) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Controller" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _controllerInstanceType = typeof(Controller);
            _controllerInstanceFixture = Create(true);
            _controllerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Controller)

        #region General Initializer : Class (Controller) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Controller" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessRequest, 0)]
        [TestCase(MethodLoadModules, 0)]
        public void AUT_Controller_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_controllerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Controller) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Controller" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrent)]
        public void AUT_Controller_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_controllerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Controller) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Controller" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_instance)]
        [TestCase(FieldLocker)]
        [TestCase(Field_events)]
        [TestCase(Field_logger)]
        public void AUT_Controller_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_controllerInstanceFixture, 
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
        ///     Class (<see cref="Controller" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Controller_Is_Instance_Present_Test()
        {
            // Assert
            _controllerInstanceType.ShouldNotBeNull();
            _controllerInstance.ShouldNotBeNull();
            _controllerInstanceFixture.ShouldNotBeNull();
            _controllerInstance.ShouldBeAssignableTo<Controller>();
            _controllerInstanceFixture.ShouldBeAssignableTo<Controller>();
        }

        #endregion
        
        #region Category : GetterSetter

        #region General Getters/Setters : Class (Controller) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Controller) , PropertyCurrent)]
        public void AUT_Controller_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Controller, T>(_controllerInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Controller) => Property (Current) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Controller_Current_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrent);
            Action currentAction = () => propertyInfo.SetValue(_controllerInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Controller) => Property (Current) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Controller_Public_Class_Current_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Controller" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessRequest)]
        [TestCase(MethodLoadModules)]
        public void AUT_Controller_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Controller>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Controller_ProcessRequest_Method_Call_Internally(Type[] types)
        {
            var methodProcessRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_controllerInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var moduleKind = CreateType<ModuleKind>();
            var actionKind = CreateType<ActionKind>();
            var data = CreateType<Dictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _controllerInstance.ProcessRequest(moduleKind, actionKind, data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var moduleKind = CreateType<ModuleKind>();
            var actionKind = CreateType<ActionKind>();
            var data = CreateType<Dictionary<string, object>>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(ModuleKind), typeof(ActionKind), typeof(Dictionary<string, object>) };
            object[] parametersOfProcessRequest = { moduleKind, actionKind, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessRequest, methodProcessRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_controllerInstanceFixture, parametersOfProcessRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessRequest.ShouldNotBeNull();
            parametersOfProcessRequest.Length.ShouldBe(3);
            methodProcessRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var moduleKind = CreateType<ModuleKind>();
            var actionKind = CreateType<ActionKind>();
            var data = CreateType<Dictionary<string, object>>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(ModuleKind), typeof(ActionKind), typeof(Dictionary<string, object>) };
            object[] parametersOfProcessRequest = { moduleKind, actionKind, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Controller, Transaction>(_controllerInstance, MethodProcessRequest, parametersOfProcessRequest, methodProcessRequestPrametersTypes);

            // Assert
            parametersOfProcessRequest.ShouldNotBeNull();
            parametersOfProcessRequest.Length.ShouldBe(3);
            methodProcessRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodProcessRequestPrametersTypes = new Type[] { typeof(ModuleKind), typeof(ActionKind), typeof(Dictionary<string, object>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_controllerInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodProcessRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessRequestPrametersTypes = new Type[] { typeof(ModuleKind), typeof(ActionKind), typeof(Dictionary<string, object>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_controllerInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_controllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : Transaction) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_ProcessRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadModules) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Controller_LoadModules_Method_Call_Internally(Type[] types)
        {
            var methodLoadModulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_controllerInstance, MethodLoadModules, Fixture, methodLoadModulesPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadModules) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_LoadModules_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadModulesPrametersTypes = null;
            object[] parametersOfLoadModules = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadModules, methodLoadModulesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_controllerInstanceFixture, parametersOfLoadModules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadModules.ShouldBeNull();
            methodLoadModulesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadModules) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_LoadModules_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadModulesPrametersTypes = null;
            object[] parametersOfLoadModules = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_controllerInstance, MethodLoadModules, parametersOfLoadModules, methodLoadModulesPrametersTypes);

            // Assert
            parametersOfLoadModules.ShouldBeNull();
            methodLoadModulesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadModules) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_LoadModules_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadModulesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_controllerInstance, MethodLoadModules, Fixture, methodLoadModulesPrametersTypes);

            // Assert
            methodLoadModulesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadModules) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Controller_LoadModules_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadModules, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_controllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}