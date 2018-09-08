using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainServices
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainServices.HtmlColorService" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainServices"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HtmlColorServiceTest : AbstractBaseSetupTest
    {

        public HtmlColorServiceTest() : base(typeof(HtmlColorService))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (HtmlColorService) Initializer

        private const string MethodGetRandomHtmlColor = "GetRandomHtmlColor";
        private const string MethodGetPredefinedColorBasedOnIndex = "GetPredefinedColorBasedOnIndex";
        private const string MethodRandomNumber = "RandomNumber";
        private const string FieldRandom = "Random";
        private const string FieldSyncLock = "SyncLock";
        private Type _htmlColorServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (HtmlColorService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="HtmlColorService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _htmlColorServiceInstanceType = typeof(HtmlColorService);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (HtmlColorService)

        #region General Initializer : Class (HtmlColorService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="HtmlColorService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetRandomHtmlColor, 0)]
        [TestCase(MethodGetPredefinedColorBasedOnIndex, 0)]
        [TestCase(MethodRandomNumber, 0)]
        public void AUT_HtmlColorService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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

        #region General Initializer : Class (HtmlColorService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="HtmlColorService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldRandom)]
        [TestCase(FieldSyncLock)]
        public void AUT_HtmlColorService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="HtmlColorService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_HtmlColorService_Is_Static_Type_Present_Test()
        {
            // Assert
            _htmlColorServiceInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="HtmlColorService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRandomHtmlColor)]
        [TestCase(MethodGetPredefinedColorBasedOnIndex)]
        [TestCase(MethodRandomNumber)]
        public void AUT_HtmlColorService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _htmlColorServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRandomHtmlColorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetRandomHtmlColor, Fixture, methodGetRandomHtmlColorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => HtmlColorService.GetRandomHtmlColor();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetRandomHtmlColorPrametersTypes = null;
            object[] parametersOfGetRandomHtmlColor = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRandomHtmlColor, methodGetRandomHtmlColorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRandomHtmlColor);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRandomHtmlColor.ShouldBeNull();
            methodGetRandomHtmlColorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRandomHtmlColorPrametersTypes = null;
            object[] parametersOfGetRandomHtmlColor = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Color>(null, _htmlColorServiceInstanceType, MethodGetRandomHtmlColor, parametersOfGetRandomHtmlColor, methodGetRandomHtmlColorPrametersTypes);

            // Assert
            parametersOfGetRandomHtmlColor.ShouldBeNull();
            methodGetRandomHtmlColorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRandomHtmlColorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetRandomHtmlColor, Fixture, methodGetRandomHtmlColorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRandomHtmlColorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRandomHtmlColorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetRandomHtmlColor, Fixture, methodGetRandomHtmlColorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRandomHtmlColorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRandomHtmlColor) (Return Type : Color) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetRandomHtmlColor_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRandomHtmlColor, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPredefinedColorBasedOnIndexPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetPredefinedColorBasedOnIndex, Fixture, methodGetPredefinedColorBasedOnIndexPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var index = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => HtmlColorService.GetPredefinedColorBasedOnIndex(index);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var methodGetPredefinedColorBasedOnIndexPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetPredefinedColorBasedOnIndex = { index };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPredefinedColorBasedOnIndex, methodGetPredefinedColorBasedOnIndexPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetPredefinedColorBasedOnIndex);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPredefinedColorBasedOnIndex.ShouldNotBeNull();
            parametersOfGetPredefinedColorBasedOnIndex.Length.ShouldBe(1);
            methodGetPredefinedColorBasedOnIndexPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var methodGetPredefinedColorBasedOnIndexPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetPredefinedColorBasedOnIndex = { index };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Color>(null, _htmlColorServiceInstanceType, MethodGetPredefinedColorBasedOnIndex, parametersOfGetPredefinedColorBasedOnIndex, methodGetPredefinedColorBasedOnIndexPrametersTypes);

            // Assert
            parametersOfGetPredefinedColorBasedOnIndex.ShouldNotBeNull();
            parametersOfGetPredefinedColorBasedOnIndex.Length.ShouldBe(1);
            methodGetPredefinedColorBasedOnIndexPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetPredefinedColorBasedOnIndexPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetPredefinedColorBasedOnIndex, Fixture, methodGetPredefinedColorBasedOnIndexPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPredefinedColorBasedOnIndexPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPredefinedColorBasedOnIndexPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodGetPredefinedColorBasedOnIndex, Fixture, methodGetPredefinedColorBasedOnIndexPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPredefinedColorBasedOnIndexPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPredefinedColorBasedOnIndex, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPredefinedColorBasedOnIndex) (Return Type : Color) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_GetPredefinedColorBasedOnIndex_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPredefinedColorBasedOnIndex, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HtmlColorService_RandomNumber_Static_Method_Call_Internally(Type[] types)
        {
            var methodRandomNumberPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodRandomNumber, Fixture, methodRandomNumberPrametersTypes);
        }

        #endregion
        
        #region Method Call : (RandomNumber) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_RandomNumber_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var min = CreateType<int>();
            var max = CreateType<int>();
            var methodRandomNumberPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfRandomNumber = { min, max };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _htmlColorServiceInstanceType, MethodRandomNumber, parametersOfRandomNumber, methodRandomNumberPrametersTypes);

            // Assert
            parametersOfRandomNumber.ShouldNotBeNull();
            parametersOfRandomNumber.Length.ShouldBe(2);
            methodRandomNumberPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_RandomNumber_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRandomNumberPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _htmlColorServiceInstanceType, MethodRandomNumber, Fixture, methodRandomNumberPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRandomNumberPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RandomNumber) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HtmlColorService_RandomNumber_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRandomNumber, 0);
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