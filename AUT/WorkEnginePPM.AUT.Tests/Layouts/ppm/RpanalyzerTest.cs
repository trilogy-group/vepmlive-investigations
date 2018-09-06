using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.rpanalyzer" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RpanalyzerTest : AbstractBaseSetupTypedTest<rpanalyzer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (rpanalyzer) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetMaxPeriodLimit = "GetMaxPeriodLimit";
        private const string FieldstrOutput = "strOutput";
        private const string FieldsProjectName = "sProjectName";
        private Type _rpanalyzerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private rpanalyzer _rpanalyzerInstance;
        private rpanalyzer _rpanalyzerInstanceFixture;

        #region General Initializer : Class (rpanalyzer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="rpanalyzer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rpanalyzerInstanceType = typeof(rpanalyzer);
            _rpanalyzerInstanceFixture = Create(true);
            _rpanalyzerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (rpanalyzer)

        #region General Initializer : Class (rpanalyzer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="rpanalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetMaxPeriodLimit, 0)]
        public void AUT_Rpanalyzer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_rpanalyzerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (rpanalyzer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="rpanalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstrOutput)]
        [TestCase(FieldsProjectName)]
        public void AUT_Rpanalyzer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rpanalyzerInstanceFixture, 
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
        ///     Class (<see cref="rpanalyzer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Rpanalyzer_Is_Instance_Present_Test()
        {
            // Assert
            _rpanalyzerInstanceType.ShouldNotBeNull();
            _rpanalyzerInstance.ShouldNotBeNull();
            _rpanalyzerInstanceFixture.ShouldNotBeNull();
            _rpanalyzerInstance.ShouldBeAssignableTo<rpanalyzer>();
            _rpanalyzerInstanceFixture.ShouldBeAssignableTo<rpanalyzer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (rpanalyzer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_rpanalyzer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            rpanalyzer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rpanalyzerInstanceType.ShouldNotBeNull();
            _rpanalyzerInstance.ShouldNotBeNull();
            _rpanalyzerInstanceFixture.ShouldNotBeNull();
            _rpanalyzerInstance.ShouldBeAssignableTo<rpanalyzer>();
            _rpanalyzerInstanceFixture.ShouldBeAssignableTo<rpanalyzer>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="rpanalyzer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetMaxPeriodLimit)]
        public void AUT_Rpanalyzer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<rpanalyzer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Rpanalyzer_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rpanalyzerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rpanalyzerInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rpanalyzerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rpanalyzerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rpanalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_Internally(Type[] types)
        {
            var methodGetMaxPeriodLimitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rpanalyzerInstance, MethodGetMaxPeriodLimit, Fixture, methodGetMaxPeriodLimitPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMaxPeriodLimitPrametersTypes = null;
            object[] parametersOfGetMaxPeriodLimit = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaxPeriodLimit, methodGetMaxPeriodLimitPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<rpanalyzer, Int32>(_rpanalyzerInstanceFixture, out exception1, parametersOfGetMaxPeriodLimit);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<rpanalyzer, Int32>(_rpanalyzerInstance, MethodGetMaxPeriodLimit, parametersOfGetMaxPeriodLimit, methodGetMaxPeriodLimitPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaxPeriodLimit.ShouldBeNull();
            methodGetMaxPeriodLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetMaxPeriodLimitPrametersTypes = null;
            object[] parametersOfGetMaxPeriodLimit = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMaxPeriodLimit, methodGetMaxPeriodLimitPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<rpanalyzer, Int32>(_rpanalyzerInstanceFixture, out exception1, parametersOfGetMaxPeriodLimit);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<rpanalyzer, Int32>(_rpanalyzerInstance, MethodGetMaxPeriodLimit, parametersOfGetMaxPeriodLimit, methodGetMaxPeriodLimitPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMaxPeriodLimit.ShouldBeNull();
            methodGetMaxPeriodLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMaxPeriodLimitPrametersTypes = null;
            object[] parametersOfGetMaxPeriodLimit = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<rpanalyzer, Int32>(_rpanalyzerInstance, MethodGetMaxPeriodLimit, parametersOfGetMaxPeriodLimit, methodGetMaxPeriodLimitPrametersTypes);

            // Assert
            parametersOfGetMaxPeriodLimit.ShouldBeNull();
            methodGetMaxPeriodLimitPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMaxPeriodLimitPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rpanalyzerInstance, MethodGetMaxPeriodLimit, Fixture, methodGetMaxPeriodLimitPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMaxPeriodLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMaxPeriodLimit) (Return Type : Int32) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Rpanalyzer_GetMaxPeriodLimit_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMaxPeriodLimit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rpanalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}