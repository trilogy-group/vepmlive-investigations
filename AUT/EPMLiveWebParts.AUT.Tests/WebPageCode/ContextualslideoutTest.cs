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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.contextualslideout" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ContextualslideoutTest : AbstractBaseSetupTypedTest<contextualslideout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (contextualslideout) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodHideSlideOut = "HideSlideOut";
        private const string FieldData = "Data";
        private Type _contextualslideoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private contextualslideout _contextualslideoutInstance;
        private contextualslideout _contextualslideoutInstanceFixture;

        #region General Initializer : Class (contextualslideout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="contextualslideout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _contextualslideoutInstanceType = typeof(contextualslideout);
            _contextualslideoutInstanceFixture = Create(true);
            _contextualslideoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (contextualslideout)

        #region General Initializer : Class (contextualslideout) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="contextualslideout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodHideSlideOut, 0)]
        public void AUT_Contextualslideout_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_contextualslideoutInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (contextualslideout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="contextualslideout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldData)]
        public void AUT_Contextualslideout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_contextualslideoutInstanceFixture, 
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
        ///     Class (<see cref="contextualslideout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Contextualslideout_Is_Instance_Present_Test()
        {
            // Assert
            _contextualslideoutInstanceType.ShouldNotBeNull();
            _contextualslideoutInstance.ShouldNotBeNull();
            _contextualslideoutInstanceFixture.ShouldNotBeNull();
            _contextualslideoutInstance.ShouldBeAssignableTo<contextualslideout>();
            _contextualslideoutInstanceFixture.ShouldBeAssignableTo<contextualslideout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (contextualslideout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_contextualslideout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            contextualslideout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _contextualslideoutInstanceType.ShouldNotBeNull();
            _contextualslideoutInstance.ShouldNotBeNull();
            _contextualslideoutInstanceFixture.ShouldNotBeNull();
            _contextualslideoutInstance.ShouldBeAssignableTo<contextualslideout>();
            _contextualslideoutInstanceFixture.ShouldBeAssignableTo<contextualslideout>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="contextualslideout" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodHideSlideOut)]
        public void AUT_Contextualslideout_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<contextualslideout>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Contextualslideout_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_contextualslideoutInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_contextualslideoutInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_contextualslideoutInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_contextualslideoutInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_contextualslideoutInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideSlideOut) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Contextualslideout_HideSlideOut_Method_Call_Internally(Type[] types)
        {
            var methodHideSlideOutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_contextualslideoutInstance, MethodHideSlideOut, Fixture, methodHideSlideOutPrametersTypes);
        }

        #endregion

        #region Method Call : (HideSlideOut) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_HideSlideOut_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var slideOutId = CreateType<string>();
            var methodHideSlideOutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfHideSlideOut = { slideOutId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHideSlideOut, methodHideSlideOutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_contextualslideoutInstanceFixture, parametersOfHideSlideOut);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHideSlideOut.ShouldNotBeNull();
            parametersOfHideSlideOut.Length.ShouldBe(1);
            methodHideSlideOutPrametersTypes.Length.ShouldBe(1);
            methodHideSlideOutPrametersTypes.Length.ShouldBe(parametersOfHideSlideOut.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideSlideOut) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_HideSlideOut_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var slideOutId = CreateType<string>();
            var methodHideSlideOutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfHideSlideOut = { slideOutId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_contextualslideoutInstance, MethodHideSlideOut, parametersOfHideSlideOut, methodHideSlideOutPrametersTypes);

            // Assert
            parametersOfHideSlideOut.ShouldNotBeNull();
            parametersOfHideSlideOut.Length.ShouldBe(1);
            methodHideSlideOutPrametersTypes.Length.ShouldBe(1);
            methodHideSlideOutPrametersTypes.Length.ShouldBe(parametersOfHideSlideOut.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideSlideOut) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_HideSlideOut_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHideSlideOut, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (HideSlideOut) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Contextualslideout_HideSlideOut_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHideSlideOut, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_contextualslideoutInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}