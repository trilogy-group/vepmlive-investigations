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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ExtensionMethods" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExtensionMethodsTest : AbstractBaseSetupTest
    {

        public ExtensionMethodsTest() : base(typeof(ExtensionMethods))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExtensionMethods) Initializer

        private const string MethodLc = "Lc";
        private const string MethodToPrettierName = "ToPrettierName";
        private const string MethodMd5 = "Md5";
        private Type _extensionMethodsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ExtensionMethods) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExtensionMethods" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionMethodsInstanceType = typeof(ExtensionMethods);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExtensionMethods)

        #region General Initializer : Class (ExtensionMethods) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLc, 0)]
        [TestCase(MethodToPrettierName, 0)]
        [TestCase(MethodMd5, 0)]
        public void AUT_ExtensionMethods_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="ExtensionMethods" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExtensionMethods_Is_Static_Type_Present_Test()
        {
            // Assert
            _extensionMethodsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ExtensionMethods" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLc)]
        [TestCase(MethodToPrettierName)]
        [TestCase(MethodMd5)]
        public void AUT_ExtensionMethods_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _extensionMethodsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Lc_Static_Method_Call_Internally(Type[] types)
        {
            var methodLcPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodLc, Fixture, methodLcPrametersTypes);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var val = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Lc(val);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var val = CreateType<bool>();
            var methodLcPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfLc = { val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLc, methodLcPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfLc);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLc.ShouldNotBeNull();
            parametersOfLc.Length.ShouldBe(1);
            methodLcPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var val = CreateType<bool>();
            var methodLcPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfLc = { val };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodLc, parametersOfLc, methodLcPrametersTypes);

            // Assert
            parametersOfLc.ShouldNotBeNull();
            parametersOfLc.Length.ShouldBe(1);
            methodLcPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLcPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodLc, Fixture, methodLcPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLcPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLcPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodLc, Fixture, methodLcPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLcPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLc, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Lc) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Lc_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLc, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Internally(Type[] types)
        {
            var methodToPrettierNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.ToPrettierName(internalName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToPrettierName = { internalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToPrettierName, methodToPrettierNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToPrettierName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(1);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToPrettierName = { internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodToPrettierName, parametersOfToPrettierName, methodToPrettierNamePrametersTypes);

            // Assert
            parametersOfToPrettierName.ShouldNotBeNull();
            parametersOfToPrettierName.Length.ShouldBe(1);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToPrettierNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToPrettierNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodToPrettierName, Fixture, methodToPrettierNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToPrettierNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToPrettierName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToPrettierName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_ToPrettierName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToPrettierName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ExtensionMethods_Md5_Static_Method_Call_Internally(Type[] types)
        {
            var methodMd5PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ExtensionMethods.Md5(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMd5 = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMd5, methodMd5PrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfMd5);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMd5.ShouldNotBeNull();
            parametersOfMd5.Length.ShouldBe(1);
            methodMd5PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfMd5 = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionMethodsInstanceType, MethodMd5, parametersOfMd5, methodMd5PrametersTypes);

            // Assert
            parametersOfMd5.ShouldNotBeNull();
            parametersOfMd5.Length.ShouldBe(1);
            methodMd5PrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodMd5PrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodMd5PrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMd5PrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionMethodsInstanceType, MethodMd5, Fixture, methodMd5PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMd5PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMd5, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Md5) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExtensionMethods_Md5_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMd5, 0);
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