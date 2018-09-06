using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PPM.EPKRequest" />)
    ///     and namespace <see cref="PPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EPKRequestTest : AbstractBaseSetupTypedTest<EPKRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPKRequest) Initializer

        private const string PropertyIsReusable = "IsReusable";
        private const string MethodProcessRequest = "ProcessRequest";
        private const string MethodHandleException = "HandleException";
        private Type _ePKRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPKRequest _ePKRequestInstance;
        private EPKRequest _ePKRequestInstanceFixture;

        #region General Initializer : Class (EPKRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPKRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePKRequestInstanceType = typeof(EPKRequest);
            _ePKRequestInstanceFixture = Create(true);
            _ePKRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPKRequest)

        #region General Initializer : Class (EPKRequest) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPKRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessRequest, 0)]
        [TestCase(MethodHandleException, 0)]
        public void AUT_EPKRequest_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePKRequestInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPKRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EPKRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyIsReusable)]
        public void AUT_EPKRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ePKRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="EPKRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPKRequest_Is_Instance_Present_Test()
        {
            // Assert
            _ePKRequestInstanceType.ShouldNotBeNull();
            _ePKRequestInstance.ShouldNotBeNull();
            _ePKRequestInstanceFixture.ShouldNotBeNull();
            _ePKRequestInstance.ShouldBeAssignableTo<EPKRequest>();
            _ePKRequestInstanceFixture.ShouldBeAssignableTo<EPKRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPKRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPKRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPKRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePKRequestInstanceType.ShouldNotBeNull();
            _ePKRequestInstance.ShouldNotBeNull();
            _ePKRequestInstanceFixture.ShouldNotBeNull();
            _ePKRequestInstance.ShouldBeAssignableTo<EPKRequest>();
            _ePKRequestInstanceFixture.ShouldBeAssignableTo<EPKRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EPKRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyIsReusable)]
        public void AUT_EPKRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EPKRequest, T>(_ePKRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EPKRequest) => Property (IsReusable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPKRequest_Public_Class_IsReusable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsReusable);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EPKRequest" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHandleException)]
        public void AUT_EPKRequest_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ePKRequestInstanceFixture,
                                                                              _ePKRequestInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EPKRequest" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessRequest)]
        public void AUT_EPKRequest_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPKRequest>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKRequest_ProcessRequest_Method_Call_Internally(Type[] types)
        {
            var methodProcessRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKRequestInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePKRequestInstance.ProcessRequest(context);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfProcessRequest = { context };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessRequest, methodProcessRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKRequestInstanceFixture, parametersOfProcessRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessRequest.ShouldNotBeNull();
            parametersOfProcessRequest.Length.ShouldBe(1);
            methodProcessRequestPrametersTypes.Length.ShouldBe(1);
            methodProcessRequestPrametersTypes.Length.ShouldBe(parametersOfProcessRequest.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfProcessRequest = { context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePKRequestInstance, MethodProcessRequest, parametersOfProcessRequest, methodProcessRequestPrametersTypes);

            // Assert
            parametersOfProcessRequest.ShouldNotBeNull();
            parametersOfProcessRequest.Length.ShouldBe(1);
            methodProcessRequestPrametersTypes.Length.ShouldBe(1);
            methodProcessRequestPrametersTypes.Length.ShouldBe(parametersOfProcessRequest.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessRequest, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePKRequestInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);

            // Assert
            methodProcessRequestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_ProcessRequest_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessRequest, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKRequestInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPKRequest_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKRequestInstanceFixture, _ePKRequestInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfHandleException = { ex };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePKRequestInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfHandleException = { ex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ePKRequestInstanceFixture, _ePKRequestInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKRequestInstanceFixture, _ePKRequestInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ePKRequestInstanceFixture, _ePKRequestInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ePKRequestInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPKRequest_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
            const int parametersCount = 1;

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