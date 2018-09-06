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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.ListDisplayUtils" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListDisplayUtilsTest : AbstractBaseSetupTypedTest<ListDisplayUtils>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListDisplayUtils) Initializer

        private const string MethodConvertToString = "ConvertToString";
        private const string MethodConvertFromString = "ConvertFromString";
        private Type _listDisplayUtilsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListDisplayUtils _listDisplayUtilsInstance;
        private ListDisplayUtils _listDisplayUtilsInstanceFixture;

        #region General Initializer : Class (ListDisplayUtils) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListDisplayUtils" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listDisplayUtilsInstanceType = typeof(ListDisplayUtils);
            _listDisplayUtilsInstanceFixture = Create(true);
            _listDisplayUtilsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListDisplayUtils)

        #region General Initializer : Class (ListDisplayUtils) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListDisplayUtils" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertToString, 0)]
        [TestCase(MethodConvertFromString, 0)]
        public void AUT_ListDisplayUtils_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listDisplayUtilsInstanceFixture, 
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
        ///     Class (<see cref="ListDisplayUtils" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListDisplayUtils_Is_Instance_Present_Test()
        {
            // Assert
            _listDisplayUtilsInstanceType.ShouldNotBeNull();
            _listDisplayUtilsInstance.ShouldNotBeNull();
            _listDisplayUtilsInstanceFixture.ShouldNotBeNull();
            _listDisplayUtilsInstance.ShouldBeAssignableTo<ListDisplayUtils>();
            _listDisplayUtilsInstanceFixture.ShouldBeAssignableTo<ListDisplayUtils>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListDisplayUtils) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListDisplayUtils_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListDisplayUtils instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listDisplayUtilsInstanceType.ShouldNotBeNull();
            _listDisplayUtilsInstance.ShouldNotBeNull();
            _listDisplayUtilsInstanceFixture.ShouldNotBeNull();
            _listDisplayUtilsInstance.ShouldBeAssignableTo<ListDisplayUtils>();
            _listDisplayUtilsInstanceFixture.ShouldBeAssignableTo<ListDisplayUtils>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ListDisplayUtils" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertToString)]
        [TestCase(MethodConvertFromString)]
        public void AUT_ListDisplayUtils_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_listDisplayUtilsInstanceFixture,
                                                                              _listDisplayUtilsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertToString, Fixture, methodConvertToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<string, Dictionary<string, string>>>();
            Action executeAction = null;

            // Act
            executeAction = () => ListDisplayUtils.ConvertToString(data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodConvertToStringPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfConvertToString = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertToString, methodConvertToStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listDisplayUtilsInstanceFixture, parametersOfConvertToString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertToString.ShouldNotBeNull();
            parametersOfConvertToString.Length.ShouldBe(1);
            methodConvertToStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodConvertToStringPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfConvertToString = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertToString, parametersOfConvertToString, methodConvertToStringPrametersTypes);

            // Assert
            parametersOfConvertToString.ShouldNotBeNull();
            parametersOfConvertToString.Length.ShouldBe(1);
            methodConvertToStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodConvertToStringPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, string>>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertToString, Fixture, methodConvertToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodConvertToStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertToStringPrametersTypes = new Type[] { typeof(Dictionary<string, Dictionary<string, string>>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertToString, Fixture, methodConvertToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertToStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayUtilsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertToString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertToString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertToString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var values = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ListDisplayUtils.ConvertFromString(values);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertFromString = { values };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertFromString, methodConvertFromStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, Dictionary<string, string>>>(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, parametersOfConvertFromString, methodConvertFromStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listDisplayUtilsInstanceFixture, parametersOfConvertFromString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertFromString.ShouldNotBeNull();
            parametersOfConvertFromString.Length.ShouldBe(1);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var values = CreateType<string>();
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConvertFromString = { values };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, Dictionary<string, string>>>(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, parametersOfConvertFromString, methodConvertFromStringPrametersTypes);

            // Assert
            parametersOfConvertFromString.ShouldNotBeNull();
            parametersOfConvertFromString.Length.ShouldBe(1);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertFromStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listDisplayUtilsInstanceFixture, _listDisplayUtilsInstanceType, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listDisplayUtilsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<string, Dictionary<string, string>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListDisplayUtils_ConvertFromString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);
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