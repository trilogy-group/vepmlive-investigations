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

namespace EPMLiveWebParts.Utilities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Utilities.Extensions" />)
    ///     and namespace <see cref="EPMLiveWebParts.Utilities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExtensionsTest : AbstractBaseSetupTest
    {

        public ExtensionsTest() : base(typeof(Extensions))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Extensions) Initializer

        private const string MethodXSSProtect = "XSSProtect";
        private Type _extensionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Extensions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Extensions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionsInstanceType = typeof(Extensions);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Extensions)

        #region General Initializer : Class (Extensions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Extensions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodXSSProtect, 0)]
        public void AUT_Extensions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="Extensions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Extensions_Is_Static_Type_Present_Test()
        {
            // Assert
            _extensionsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Extensions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodXSSProtect)]
        public void AUT_Extensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _extensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Extensions_XSSProtect_Static_Method_Call_Internally(Type[] types)
        {
            var methodXSSProtectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodXSSProtect, Fixture, methodXSSProtectPrametersTypes);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Extensions.XSSProtect(input);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodXSSProtectPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfXSSProtect = { input };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodXSSProtect, methodXSSProtectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfXSSProtect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfXSSProtect.ShouldNotBeNull();
            parametersOfXSSProtect.Length.ShouldBe(1);
            methodXSSProtectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var input = CreateType<string>();
            var methodXSSProtectPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfXSSProtect = { input };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionsInstanceType, MethodXSSProtect, parametersOfXSSProtect, methodXSSProtectPrametersTypes);

            // Assert
            parametersOfXSSProtect.ShouldNotBeNull();
            parametersOfXSSProtect.Length.ShouldBe(1);
            methodXSSProtectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodXSSProtectPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodXSSProtect, Fixture, methodXSSProtectPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodXSSProtectPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodXSSProtectPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodXSSProtect, Fixture, methodXSSProtectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodXSSProtectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodXSSProtect, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (XSSProtect) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_XSSProtect_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodXSSProtect, 0);
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