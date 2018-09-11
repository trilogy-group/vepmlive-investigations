using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Utilities.LookupFilterHelper" />)
    ///     and namespace <see cref="EPMLiveWebParts.Utilities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LookupFilterHelperTest : AbstractBaseSetupTypedTest<LookupFilterHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LookupFilterHelper) Initializer

        private const string MethodAppendLookupQueryToExistingQuery = "AppendLookupQueryToExistingQuery";
        private const string MethodGetLookupValuesQuery = "GetLookupValuesQuery";
        private Type _lookupFilterHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LookupFilterHelper _lookupFilterHelperInstance;
        private LookupFilterHelper _lookupFilterHelperInstanceFixture;

        #region General Initializer : Class (LookupFilterHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LookupFilterHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _lookupFilterHelperInstanceType = typeof(LookupFilterHelper);
            _lookupFilterHelperInstanceFixture = Create(true);
            _lookupFilterHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LookupFilterHelper)

        #region General Initializer : Class (LookupFilterHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="LookupFilterHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAppendLookupQueryToExistingQuery, 0)]
        [TestCase(MethodGetLookupValuesQuery, 0)]
        public void AUT_LookupFilterHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_lookupFilterHelperInstanceFixture, 
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
        ///     Class (<see cref="LookupFilterHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_LookupFilterHelper_Is_Instance_Present_Test()
        {
            // Assert
            _lookupFilterHelperInstanceType.ShouldNotBeNull();
            _lookupFilterHelperInstance.ShouldNotBeNull();
            _lookupFilterHelperInstanceFixture.ShouldNotBeNull();
            _lookupFilterHelperInstance.ShouldBeAssignableTo<LookupFilterHelper>();
            _lookupFilterHelperInstanceFixture.ShouldBeAssignableTo<LookupFilterHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LookupFilterHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_LookupFilterHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LookupFilterHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _lookupFilterHelperInstanceType.ShouldNotBeNull();
            _lookupFilterHelperInstance.ShouldNotBeNull();
            _lookupFilterHelperInstanceFixture.ShouldNotBeNull();
            _lookupFilterHelperInstance.ShouldBeAssignableTo<LookupFilterHelper>();
            _lookupFilterHelperInstanceFixture.ShouldBeAssignableTo<LookupFilterHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="LookupFilterHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAppendLookupQueryToExistingQuery)]
        [TestCase(MethodGetLookupValuesQuery)]
        public void AUT_LookupFilterHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_lookupFilterHelperInstanceFixture,
                                                                              _lookupFilterHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodAppendLookupQueryToExistingQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodAppendLookupQueryToExistingQuery, Fixture, methodAppendLookupQueryToExistingQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var lookupField = CreateType<string>();
            var lookupFieldList = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => LookupFilterHelper.AppendLookupQueryToExistingQuery(ref xmlQuery, lookupField, lookupFieldList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var lookupField = CreateType<string>();
            var lookupFieldList = CreateType<string>();
            var methodAppendLookupQueryToExistingQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfAppendLookupQueryToExistingQuery = { xmlQuery, lookupField, lookupFieldList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryToExistingQuery, methodAppendLookupQueryToExistingQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_lookupFilterHelperInstanceFixture, parametersOfAppendLookupQueryToExistingQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAppendLookupQueryToExistingQuery.ShouldNotBeNull();
            parametersOfAppendLookupQueryToExistingQuery.Length.ShouldBe(3);
            methodAppendLookupQueryToExistingQueryPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlQuery = CreateType<XmlDocument>();
            var lookupField = CreateType<string>();
            var lookupFieldList = CreateType<string>();
            var methodAppendLookupQueryToExistingQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfAppendLookupQueryToExistingQuery = { xmlQuery, lookupField, lookupFieldList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodAppendLookupQueryToExistingQuery, parametersOfAppendLookupQueryToExistingQuery, methodAppendLookupQueryToExistingQueryPrametersTypes);

            // Assert
            parametersOfAppendLookupQueryToExistingQuery.ShouldNotBeNull();
            parametersOfAppendLookupQueryToExistingQuery.Length.ShouldBe(3);
            methodAppendLookupQueryToExistingQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryToExistingQuery, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendLookupQueryToExistingQueryPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodAppendLookupQueryToExistingQuery, Fixture, methodAppendLookupQueryToExistingQueryPrametersTypes);

            // Assert
            methodAppendLookupQueryToExistingQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryToExistingQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_AppendLookupQueryToExistingQuery_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryToExistingQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_lookupFilterHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupValuesQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lookupFilterIDs = CreateType<IEnumerable>();
            var methodGetLookupValuesQueryPrametersTypes = new Type[] { typeof(IEnumerable) };
            object[] parametersOfGetLookupValuesQuery = { lookupFilterIDs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_lookupFilterHelperInstanceFixture, parametersOfGetLookupValuesQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLookupValuesQuery.ShouldNotBeNull();
            parametersOfGetLookupValuesQuery.Length.ShouldBe(1);
            methodGetLookupValuesQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lookupFilterIDs = CreateType<IEnumerable>();
            var methodGetLookupValuesQueryPrametersTypes = new Type[] { typeof(IEnumerable) };
            object[] parametersOfGetLookupValuesQuery = { lookupFilterIDs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodGetLookupValuesQuery, parametersOfGetLookupValuesQuery, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            parametersOfGetLookupValuesQuery.ShouldNotBeNull();
            parametersOfGetLookupValuesQuery.Length.ShouldBe(1);
            methodGetLookupValuesQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookupValuesQueryPrametersTypes = new Type[] { typeof(IEnumerable) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookupValuesQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookupValuesQueryPrametersTypes = new Type[] { typeof(IEnumerable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_lookupFilterHelperInstanceFixture, _lookupFilterHelperInstanceType, MethodGetLookupValuesQuery, Fixture, methodGetLookupValuesQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookupValuesQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_lookupFilterHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLookupValuesQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LookupFilterHelper_GetLookupValuesQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookupValuesQuery, 0);
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