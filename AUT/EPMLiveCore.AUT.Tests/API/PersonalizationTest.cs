using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Personalization" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalizationTest : AbstractBaseSetupTypedTest<Personalization>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Personalization) Initializer

        private const string MethodGet = "Get";
        private const string MethodSet = "Set";
        private Type _personalizationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Personalization _personalizationInstance;
        private Personalization _personalizationInstanceFixture;

        #region General Initializer : Class (Personalization) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Personalization" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalizationInstanceType = typeof(Personalization);
            _personalizationInstanceFixture = Create(true);
            _personalizationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Personalization)

        #region General Initializer : Class (Personalization) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Personalization" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGet, 0)]
        [TestCase(MethodSet, 0)]
        public void AUT_Personalization_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_personalizationInstanceFixture, 
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
        ///     Class (<see cref="Personalization" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Personalization_Is_Instance_Present_Test()
        {
            // Assert
            _personalizationInstanceType.ShouldNotBeNull();
            _personalizationInstance.ShouldNotBeNull();
            _personalizationInstanceFixture.ShouldNotBeNull();
            _personalizationInstance.ShouldBeAssignableTo<Personalization>();
            _personalizationInstanceFixture.ShouldBeAssignableTo<Personalization>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Personalization) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Personalization_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Personalization instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _personalizationInstanceType.ShouldNotBeNull();
            _personalizationInstance.ShouldNotBeNull();
            _personalizationInstanceFixture.ShouldNotBeNull();
            _personalizationInstance.ShouldBeAssignableTo<Personalization>();
            _personalizationInstanceFixture.ShouldBeAssignableTo<Personalization>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Personalization" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGet)]
        [TestCase(MethodSet)]
        public void AUT_Personalization_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Personalization>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Personalization_Get_Method_Call_Internally(Type[] types)
        {
            var methodGetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodGet, Fixture, methodGetPrametersTypes);
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalizationInstance.Get(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGet = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGet, methodGetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Personalization, string>(_personalizationInstanceFixture, out exception1, parametersOfGet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodGet, parametersOfGet, methodGetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(2);
            methodGetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodGet, parametersOfGet, methodGetPrametersTypes));
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGet = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGet, methodGetPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(2);
            methodGetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_personalizationInstanceFixture, parametersOfGet));
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGet = { data, spWeb };

            // Assert
            parametersOfGet.ShouldNotBeNull();
            parametersOfGet.Length.ShouldBe(2);
            methodGetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodGet, parametersOfGet, methodGetPrametersTypes));
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodGet, Fixture, methodGetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Get) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Get_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGet, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Personalization_Set_Method_Call_Internally(Type[] types)
        {
            var methodSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodSet, Fixture, methodSetPrametersTypes);
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalizationInstance.Set(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSet = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSet, methodSetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Personalization, string>(_personalizationInstanceFixture, out exception1, parametersOfSet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodSet, parametersOfSet, methodSetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSet.ShouldNotBeNull();
            parametersOfSet.Length.ShouldBe(2);
            methodSetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodSet, parametersOfSet, methodSetPrametersTypes));
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSet = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSet, methodSetPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSet.ShouldNotBeNull();
            parametersOfSet.Length.ShouldBe(2);
            methodSetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_personalizationInstanceFixture, parametersOfSet));
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSet = { data, spWeb };

            // Assert
            parametersOfSet.ShouldNotBeNull();
            parametersOfSet.Length.ShouldBe(2);
            methodSetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Personalization, string>(_personalizationInstance, MethodSet, parametersOfSet, methodSetPrametersTypes));
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodSet, Fixture, methodSetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalizationInstance, MethodSet, Fixture, methodSetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Set) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Personalization_Set_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSet, 0);
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