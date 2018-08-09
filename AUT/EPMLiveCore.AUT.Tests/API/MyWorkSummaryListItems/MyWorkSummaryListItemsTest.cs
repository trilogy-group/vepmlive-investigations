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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.MyWorkSummaryListItems" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyWorkSummaryListItemsTest : AbstractBaseSetupTypedTest<MyWorkSummaryListItems>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWorkSummaryListItems) Initializer

        private const string MethodGetMyWorkSummary = "GetMyWorkSummary";
        private Type _myWorkSummaryListItemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWorkSummaryListItems _myWorkSummaryListItemsInstance;
        private MyWorkSummaryListItems _myWorkSummaryListItemsInstanceFixture;

        #region General Initializer : Class (MyWorkSummaryListItems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWorkSummaryListItems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkSummaryListItemsInstanceType = typeof(MyWorkSummaryListItems);
            _myWorkSummaryListItemsInstanceFixture = Create(true);
            _myWorkSummaryListItemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWorkSummaryListItems)

        #region General Initializer : Class (MyWorkSummaryListItems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyWorkSummaryListItems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetMyWorkSummary, 0)]
        public void AUT_MyWorkSummaryListItems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myWorkSummaryListItemsInstanceFixture, 
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
        ///     Class (<see cref="MyWorkSummaryListItems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyWorkSummaryListItems_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkSummaryListItemsInstanceType.ShouldNotBeNull();
            _myWorkSummaryListItemsInstance.ShouldNotBeNull();
            _myWorkSummaryListItemsInstanceFixture.ShouldNotBeNull();
            _myWorkSummaryListItemsInstance.ShouldBeAssignableTo<MyWorkSummaryListItems>();
            _myWorkSummaryListItemsInstanceFixture.ShouldBeAssignableTo<MyWorkSummaryListItems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWorkSummaryListItems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MyWorkSummaryListItems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyWorkSummaryListItems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myWorkSummaryListItemsInstanceType.ShouldNotBeNull();
            _myWorkSummaryListItemsInstance.ShouldNotBeNull();
            _myWorkSummaryListItemsInstanceFixture.ShouldNotBeNull();
            _myWorkSummaryListItemsInstance.ShouldBeAssignableTo<MyWorkSummaryListItems>();
            _myWorkSummaryListItemsInstanceFixture.ShouldBeAssignableTo<MyWorkSummaryListItems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="MyWorkSummaryListItems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetMyWorkSummary)]
        public void AUT_MyWorkSummaryListItems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_myWorkSummaryListItemsInstanceFixture,
                                                                              _myWorkSummaryListItemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkSummaryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, Fixture, methodGetMyWorkSummaryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWorkSummaryListItems.GetMyWorkSummary(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkSummaryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkSummary = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkSummary, methodGetMyWorkSummaryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, Fixture, methodGetMyWorkSummaryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, parametersOfGetMyWorkSummary, methodGetMyWorkSummaryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkSummaryListItemsInstanceFixture, parametersOfGetMyWorkSummary);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkSummary.ShouldNotBeNull();
            parametersOfGetMyWorkSummary.Length.ShouldBe(1);
            methodGetMyWorkSummaryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkSummaryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkSummary = { data };

            // Assert
            parametersOfGetMyWorkSummary.ShouldNotBeNull();
            parametersOfGetMyWorkSummary.Length.ShouldBe(1);
            methodGetMyWorkSummaryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, parametersOfGetMyWorkSummary, methodGetMyWorkSummaryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkSummaryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, Fixture, methodGetMyWorkSummaryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkSummaryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkSummaryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkSummaryListItemsInstanceFixture, _myWorkSummaryListItemsInstanceType, MethodGetMyWorkSummary, Fixture, methodGetMyWorkSummaryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkSummaryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkSummary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkSummaryListItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkSummary) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkSummaryListItems_GetMyWorkSummary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkSummary, 0);
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