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

namespace EPMLiveWebParts.ReportFiltering.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainServices.SPFieldTypeHelper" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SPFieldTypeHelperTest : AbstractBaseSetupTypedTest<SPFieldTypeHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SPFieldTypeHelper) Initializer

        private const string MethodGetFieldType = "GetFieldType";
        private Type _sPFieldTypeHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SPFieldTypeHelper _sPFieldTypeHelperInstance;
        private SPFieldTypeHelper _sPFieldTypeHelperInstanceFixture;

        #region General Initializer : Class (SPFieldTypeHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SPFieldTypeHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sPFieldTypeHelperInstanceType = typeof(SPFieldTypeHelper);
            _sPFieldTypeHelperInstanceFixture = Create(true);
            _sPFieldTypeHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SPFieldTypeHelper)

        #region General Initializer : Class (SPFieldTypeHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SPFieldTypeHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetFieldType, 0)]
        public void AUT_SPFieldTypeHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sPFieldTypeHelperInstanceFixture, 
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
        ///     Class (<see cref="SPFieldTypeHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SPFieldTypeHelper_Is_Instance_Present_Test()
        {
            // Assert
            _sPFieldTypeHelperInstanceType.ShouldNotBeNull();
            _sPFieldTypeHelperInstance.ShouldNotBeNull();
            _sPFieldTypeHelperInstanceFixture.ShouldNotBeNull();
            _sPFieldTypeHelperInstance.ShouldBeAssignableTo<SPFieldTypeHelper>();
            _sPFieldTypeHelperInstanceFixture.ShouldBeAssignableTo<SPFieldTypeHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SPFieldTypeHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SPFieldTypeHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SPFieldTypeHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sPFieldTypeHelperInstanceType.ShouldNotBeNull();
            _sPFieldTypeHelperInstance.ShouldNotBeNull();
            _sPFieldTypeHelperInstanceFixture.ShouldNotBeNull();
            _sPFieldTypeHelperInstance.ShouldBeAssignableTo<SPFieldTypeHelper>();
            _sPFieldTypeHelperInstanceFixture.ShouldBeAssignableTo<SPFieldTypeHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SPFieldTypeHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFieldType)]
        public void AUT_SPFieldTypeHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_sPFieldTypeHelperInstanceFixture,
                                                                              _sPFieldTypeHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => SPFieldTypeHelper.GetFieldType(fieldType);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fieldType = CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldType = { fieldType };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldType, methodGetFieldTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPFieldType>(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(1);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPFieldType>(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldType = CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldType = { fieldType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFieldType, methodGetFieldTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPFieldTypeHelperInstanceFixture, parametersOfGetFieldType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(1);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldType = CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldType = { fieldType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPFieldType>(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(1);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFieldTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPFieldTypeHelperInstanceFixture, _sPFieldTypeHelperInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPFieldTypeHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : SPFieldType) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPFieldTypeHelper_GetFieldType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldType, 0);
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