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

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.Utility" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilityTest : AbstractBaseSetupTypedTest<Utility>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Utility) Initializer

        private const string MethodGetCleanAlphaNumeric = "GetCleanAlphaNumeric";
        private Type _utilityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Utility _utilityInstance;
        private Utility _utilityInstanceFixture;

        #region General Initializer : Class (Utility) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Utility" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _utilityInstanceType = typeof(Utility);
            _utilityInstanceFixture = Create(true);
            _utilityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Utility)

        #region General Initializer : Class (Utility) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Utility" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetCleanAlphaNumeric, 0)]
        public void AUT_Utility_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_utilityInstanceFixture, 
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
        ///     Class (<see cref="Utility" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Utility_Is_Instance_Present_Test()
        {
            // Assert
            _utilityInstanceType.ShouldNotBeNull();
            _utilityInstance.ShouldNotBeNull();
            _utilityInstanceFixture.ShouldNotBeNull();
            _utilityInstance.ShouldBeAssignableTo<Utility>();
            _utilityInstanceFixture.ShouldBeAssignableTo<Utility>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Utility) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Utility_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Utility instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _utilityInstanceType.ShouldNotBeNull();
            _utilityInstance.ShouldNotBeNull();
            _utilityInstanceFixture.ShouldNotBeNull();
            _utilityInstance.ShouldBeAssignableTo<Utility>();
            _utilityInstanceFixture.ShouldBeAssignableTo<Utility>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Utility" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCleanAlphaNumeric)]
        public void AUT_Utility_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_utilityInstanceFixture,
                                                                              _utilityInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanAlphaNumericPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_utilityInstanceFixture, _utilityInstanceType, MethodGetCleanAlphaNumeric, Fixture, methodGetCleanAlphaNumericPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utility.GetCleanAlphaNumeric(input);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodGetCleanAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanAlphaNumeric = { input };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanAlphaNumeric, methodGetCleanAlphaNumericPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_utilityInstanceFixture, parametersOfGetCleanAlphaNumeric);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanAlphaNumeric.ShouldNotBeNull();
            parametersOfGetCleanAlphaNumeric.Length.ShouldBe(1);
            methodGetCleanAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodGetCleanAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanAlphaNumeric = { input };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_utilityInstanceFixture, _utilityInstanceType, MethodGetCleanAlphaNumeric, parametersOfGetCleanAlphaNumeric, methodGetCleanAlphaNumericPrametersTypes);

            // Assert
            parametersOfGetCleanAlphaNumeric.ShouldNotBeNull();
            parametersOfGetCleanAlphaNumeric.Length.ShouldBe(1);
            methodGetCleanAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCleanAlphaNumericPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_utilityInstanceFixture, _utilityInstanceType, MethodGetCleanAlphaNumeric, Fixture, methodGetCleanAlphaNumericPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCleanAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_utilityInstanceFixture, _utilityInstanceType, MethodGetCleanAlphaNumeric, Fixture, methodGetCleanAlphaNumericPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanAlphaNumericPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanAlphaNumeric, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_utilityInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanAlphaNumeric) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utility_GetCleanAlphaNumeric_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanAlphaNumeric, 0);
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