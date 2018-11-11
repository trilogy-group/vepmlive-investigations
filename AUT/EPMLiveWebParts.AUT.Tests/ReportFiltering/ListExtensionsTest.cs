using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace ReportFiltering
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ReportFiltering.ListExtensions" />)
    ///     and namespace <see cref="ReportFiltering"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListExtensionsTest : AbstractBaseSetupTest
    {

        public ListExtensionsTest() : base(typeof(ListExtensions))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListExtensions) Initializer

        private const string MethodAsCommaSeparatedString = "AsCommaSeparatedString";
        private const string MethodPopulateFromCommaSeparatedString = "PopulateFromCommaSeparatedString";
        private Type _listExtensionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ListExtensions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListExtensions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listExtensionsInstanceType = typeof(ListExtensions);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListExtensions)

        #region General Initializer : Class (ListExtensions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListExtensions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAsCommaSeparatedString, 0)]
        [TestCase(MethodPopulateFromCommaSeparatedString, 0)]
        public void AUT_ListExtensions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="ListExtensions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListExtensions_Is_Static_Type_Present_Test()
        {
            // Assert
            _listExtensionsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ListExtensions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAsCommaSeparatedString)]
        [TestCase(MethodPopulateFromCommaSeparatedString)]
        public void AUT_ListExtensions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _listExtensionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_Internally(Type[] types)
        {
            var methodAsCommaSeparatedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listExtensionsInstanceType, MethodAsCommaSeparatedString, Fixture, methodAsCommaSeparatedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            Action executeAction = null;

            // Act
            executeAction = () => ListExtensions.AsCommaSeparatedString(list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            var methodAsCommaSeparatedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>) };
            object[] parametersOfAsCommaSeparatedString = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAsCommaSeparatedString, methodAsCommaSeparatedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAsCommaSeparatedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAsCommaSeparatedString.ShouldNotBeNull();
            parametersOfAsCommaSeparatedString.Length.ShouldBe(1);
            methodAsCommaSeparatedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<IEnumerable<string>>();
            var methodAsCommaSeparatedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>) };
            object[] parametersOfAsCommaSeparatedString = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _listExtensionsInstanceType, MethodAsCommaSeparatedString, parametersOfAsCommaSeparatedString, methodAsCommaSeparatedStringPrametersTypes);

            // Assert
            parametersOfAsCommaSeparatedString.ShouldNotBeNull();
            parametersOfAsCommaSeparatedString.Length.ShouldBe(1);
            methodAsCommaSeparatedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAsCommaSeparatedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listExtensionsInstanceType, MethodAsCommaSeparatedString, Fixture, methodAsCommaSeparatedStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAsCommaSeparatedStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAsCommaSeparatedStringPrametersTypes = new Type[] { typeof(IEnumerable<string>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listExtensionsInstanceType, MethodAsCommaSeparatedString, Fixture, methodAsCommaSeparatedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAsCommaSeparatedStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAsCommaSeparatedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AsCommaSeparatedString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_AsCommaSeparatedString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAsCommaSeparatedString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_Internally(Type[] types)
        {
            var methodPopulateFromCommaSeparatedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listExtensionsInstanceType, MethodPopulateFromCommaSeparatedString, Fixture, methodPopulateFromCommaSeparatedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ListExtensions.PopulateFromCommaSeparatedString(list, stringToSeparate);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };
            object[] parametersOfPopulateFromCommaSeparatedString = { list, stringToSeparate };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, methodPopulateFromCommaSeparatedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfPopulateFromCommaSeparatedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateFromCommaSeparatedString.ShouldNotBeNull();
            parametersOfPopulateFromCommaSeparatedString.Length.ShouldBe(2);
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<List<string>>();
            var stringToSeparate = CreateType<string>();
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };
            object[] parametersOfPopulateFromCommaSeparatedString = { list, stringToSeparate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _listExtensionsInstanceType, MethodPopulateFromCommaSeparatedString, parametersOfPopulateFromCommaSeparatedString, methodPopulateFromCommaSeparatedStringPrametersTypes);

            // Assert
            parametersOfPopulateFromCommaSeparatedString.ShouldNotBeNull();
            parametersOfPopulateFromCommaSeparatedString.Length.ShouldBe(2);
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateFromCommaSeparatedStringPrametersTypes = new Type[] { typeof(List<string>), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _listExtensionsInstanceType, MethodPopulateFromCommaSeparatedString, Fixture, methodPopulateFromCommaSeparatedStringPrametersTypes);

            // Assert
            methodPopulateFromCommaSeparatedStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFromCommaSeparatedString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListExtensions_PopulateFromCommaSeparatedString_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateFromCommaSeparatedString, 0);

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