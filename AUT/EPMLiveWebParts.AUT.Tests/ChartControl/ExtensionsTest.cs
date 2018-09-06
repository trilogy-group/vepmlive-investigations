using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Extensions" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
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

        private const string MethodDelimit = "Delimit";
        private const string MethodUnDelimit = "UnDelimit";
        private const string MethodToArray = "ToArray";
        private const string MethodAdd = "Add";
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
        [TestCase(MethodDelimit, 0)]
        [TestCase(MethodUnDelimit, 0)]
        [TestCase(MethodToArray, 0)]
        [TestCase(MethodAdd, 0)]
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
        [TestCase(MethodDelimit)]
        [TestCase(MethodUnDelimit)]
        [TestCase(MethodToArray)]
        [TestCase(MethodAdd)]
        public void AUT_Extensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _extensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Extensions_Delimit_Static_Method_Call_Internally(Type[] types)
        {
            var methodDelimitPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodDelimit, Fixture, methodDelimitPrametersTypes);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Extensions.Delimit(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodDelimitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDelimit = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDelimit, methodDelimitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDelimit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDelimit.ShouldNotBeNull();
            parametersOfDelimit.Length.ShouldBe(1);
            methodDelimitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodDelimitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDelimit = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionsInstanceType, MethodDelimit, parametersOfDelimit, methodDelimitPrametersTypes);

            // Assert
            parametersOfDelimit.ShouldNotBeNull();
            parametersOfDelimit.Length.ShouldBe(1);
            methodDelimitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDelimitPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodDelimit, Fixture, methodDelimitPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDelimitPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDelimitPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodDelimit, Fixture, methodDelimitPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDelimitPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelimit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Delimit) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Delimit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelimit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Extensions_UnDelimit_Static_Method_Call_Internally(Type[] types)
        {
            var methodUnDelimitPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodUnDelimit, Fixture, methodUnDelimitPrametersTypes);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Extensions.UnDelimit(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUnDelimitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUnDelimit = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUnDelimit, methodUnDelimitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfUnDelimit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUnDelimit.ShouldNotBeNull();
            parametersOfUnDelimit.Length.ShouldBe(1);
            methodUnDelimitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUnDelimitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUnDelimit = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _extensionsInstanceType, MethodUnDelimit, parametersOfUnDelimit, methodUnDelimitPrametersTypes);

            // Assert
            parametersOfUnDelimit.ShouldNotBeNull();
            parametersOfUnDelimit.Length.ShouldBe(1);
            methodUnDelimitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodUnDelimitPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodUnDelimit, Fixture, methodUnDelimitPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodUnDelimitPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnDelimitPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodUnDelimit, Fixture, methodUnDelimitPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUnDelimitPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnDelimit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UnDelimit) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_UnDelimit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnDelimit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Extensions_ToArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodToArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodToArray, Fixture, methodToArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Extensions.ToArray(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodToArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToArray = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToArray, methodToArrayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfToArray);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToArray.ShouldNotBeNull();
            parametersOfToArray.Length.ShouldBe(1);
            methodToArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodToArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfToArray = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(null, _extensionsInstanceType, MethodToArray, parametersOfToArray, methodToArrayPrametersTypes);

            // Assert
            parametersOfToArray.ShouldNotBeNull();
            parametersOfToArray.Length.ShouldBe(1);
            methodToArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodToArrayPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodToArray, Fixture, methodToArrayPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToArrayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodToArrayPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodToArray, Fixture, methodToArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToArray) (Return Type : string[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_ToArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodToArray, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Extensions_Add_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodAdd, Fixture, methodAddPrametersTypes);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sb = CreateType<StringBuilder>();
            var formatString = CreateType<string>();
            var args = CreateType<object[]>();
            Action executeAction = null;

            // Act
            executeAction = () => Extensions.Add(sb, formatString, args);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sb = CreateType<StringBuilder>();
            var formatString = CreateType<string>();
            var args = CreateType<object[]>();
            var methodAddPrametersTypes = new Type[] { typeof(StringBuilder), typeof(string), typeof(object[]) };
            object[] parametersOfAdd = { sb, formatString, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAdd, methodAddPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAdd);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(3);
            methodAddPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sb = CreateType<StringBuilder>();
            var formatString = CreateType<string>();
            var args = CreateType<object[]>();
            var methodAddPrametersTypes = new Type[] { typeof(StringBuilder), typeof(string), typeof(object[]) };
            object[] parametersOfAdd = { sb, formatString, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _extensionsInstanceType, MethodAdd, parametersOfAdd, methodAddPrametersTypes);

            // Assert
            parametersOfAdd.ShouldNotBeNull();
            parametersOfAdd.Length.ShouldBe(3);
            methodAddPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAdd, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPrametersTypes = new Type[] { typeof(StringBuilder), typeof(string), typeof(object[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _extensionsInstanceType, MethodAdd, Fixture, methodAddPrametersTypes);

            // Assert
            methodAddPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Add) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Extensions_Add_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAdd, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}