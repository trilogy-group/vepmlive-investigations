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
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Rates" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RatesTest : AbstractBaseSetupTypedTest<Rates>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Rates) Initializer

        private const string PropertyIsReusable = "IsReusable";
        private const string MethodProcessRequest = "ProcessRequest";
        private const string MethodRatesRequest = "RatesRequest";
        private const string MethodSaveRatesInfo = "SaveRatesInfo";
        private Type _ratesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Rates _ratesInstance;
        private Rates _ratesInstanceFixture;

        #region General Initializer : Class (Rates) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Rates" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ratesInstanceType = typeof(Rates);
            _ratesInstanceFixture = Create(true);
            _ratesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Rates)

        #region General Initializer : Class (Rates) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Rates" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessRequest, 0)]
        [TestCase(MethodRatesRequest, 0)]
        [TestCase(MethodSaveRatesInfo, 0)]
        public void AUT_Rates_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ratesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Rates) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Rates" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyIsReusable)]
        public void AUT_Rates_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ratesInstanceFixture,
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
        ///     Class (<see cref="Rates" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Rates_Is_Instance_Present_Test()
        {
            // Assert
            _ratesInstanceType.ShouldNotBeNull();
            _ratesInstance.ShouldNotBeNull();
            _ratesInstanceFixture.ShouldNotBeNull();
            _ratesInstance.ShouldBeAssignableTo<Rates>();
            _ratesInstanceFixture.ShouldBeAssignableTo<Rates>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Rates) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Rates_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Rates instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ratesInstanceType.ShouldNotBeNull();
            _ratesInstance.ShouldNotBeNull();
            _ratesInstanceFixture.ShouldNotBeNull();
            _ratesInstance.ShouldBeAssignableTo<Rates>();
            _ratesInstanceFixture.ShouldBeAssignableTo<Rates>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Rates) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyIsReusable)]
        public void AUT_Rates_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Rates, T>(_ratesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Rates) => Property (IsReusable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Rates_Public_Class_IsReusable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///     Class (<see cref="Rates" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRatesRequest)]
        [TestCase(MethodSaveRatesInfo)]
        public void AUT_Rates_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_ratesInstanceFixture,
                                                                              _ratesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Rates" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessRequest)]
        public void AUT_Rates_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Rates>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Rates_ProcessRequest_Method_Call_Internally(Type[] types)
        {
            var methodProcessRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ratesInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_ProcessRequest_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            Action executeAction = null;

            // Act
            executeAction = () => _ratesInstance.ProcessRequest(context);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_ProcessRequest_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfProcessRequest = { context };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessRequest, methodProcessRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ratesInstanceFixture, parametersOfProcessRequest);

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
        public void AUT_Rates_ProcessRequest_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfProcessRequest = { context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ratesInstance, MethodProcessRequest, parametersOfProcessRequest, methodProcessRequestPrametersTypes);

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
        public void AUT_Rates_ProcessRequest_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Rates_ProcessRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessRequestPrametersTypes = new Type[] { typeof(HttpContext) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ratesInstance, MethodProcessRequest, Fixture, methodProcessRequestPrametersTypes);

            // Assert
            methodProcessRequestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_ProcessRequest_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessRequest, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ratesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Rates_RatesRequest_Static_Method_Call_Internally(Type[] types)
        {
            var methodRatesRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodRatesRequest, Fixture, methodRatesRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sRequestContext = CreateType<string>();
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => Rates.RatesRequest(Context, sRequestContext, xData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sRequestContext = CreateType<string>();
            var xData = CreateType<CStruct>();
            var methodRatesRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CStruct) };
            object[] parametersOfRatesRequest = { Context, sRequestContext, xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRatesRequest, methodRatesRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ratesInstanceFixture, parametersOfRatesRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRatesRequest.ShouldNotBeNull();
            parametersOfRatesRequest.Length.ShouldBe(3);
            methodRatesRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sRequestContext = CreateType<string>();
            var xData = CreateType<CStruct>();
            var methodRatesRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CStruct) };
            object[] parametersOfRatesRequest = { Context, sRequestContext, xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ratesInstanceFixture, _ratesInstanceType, MethodRatesRequest, parametersOfRatesRequest, methodRatesRequestPrametersTypes);

            // Assert
            parametersOfRatesRequest.ShouldNotBeNull();
            parametersOfRatesRequest.Length.ShouldBe(3);
            methodRatesRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRatesRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodRatesRequest, Fixture, methodRatesRequestPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRatesRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRatesRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CStruct) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodRatesRequest, Fixture, methodRatesRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRatesRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRatesRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ratesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RatesRequest) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_RatesRequest_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRatesRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Rates_SaveRatesInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveRatesInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, Fixture, methodSaveRatesInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var xData = CreateType<CStruct>();
            var methodSaveRatesInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(CStruct) };
            object[] parametersOfSaveRatesInfo = { Context, xData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveRatesInfo, methodSaveRatesInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, Fixture, methodSaveRatesInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, parametersOfSaveRatesInfo, methodSaveRatesInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_ratesInstanceFixture, parametersOfSaveRatesInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveRatesInfo.ShouldNotBeNull();
            parametersOfSaveRatesInfo.Length.ShouldBe(2);
            methodSaveRatesInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var xData = CreateType<CStruct>();
            var methodSaveRatesInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(CStruct) };
            object[] parametersOfSaveRatesInfo = { Context, xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, parametersOfSaveRatesInfo, methodSaveRatesInfoPrametersTypes);

            // Assert
            parametersOfSaveRatesInfo.ShouldNotBeNull();
            parametersOfSaveRatesInfo.Length.ShouldBe(2);
            methodSaveRatesInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveRatesInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, Fixture, methodSaveRatesInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveRatesInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveRatesInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(CStruct) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_ratesInstanceFixture, _ratesInstanceType, MethodSaveRatesInfo, Fixture, methodSaveRatesInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveRatesInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveRatesInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_ratesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveRatesInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rates_SaveRatesInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveRatesInfo, 0);
            const int parametersCount = 2;

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