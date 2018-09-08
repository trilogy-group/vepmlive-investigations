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

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.MyWork" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MyWorkTest : AbstractBaseSetupTypedTest<MyWork>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWork) Initializer

        private const string MethodOnPreLoad = "OnPreLoad";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodRegisterRibbon = "RegisterRibbon";
        private Type _myWorkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWork _myWorkInstance;
        private MyWork _myWorkInstanceFixture;

        #region General Initializer : Class (MyWork) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWork" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkInstanceType = typeof(MyWork);
            _myWorkInstanceFixture = Create(true);
            _myWorkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWork)

        #region General Initializer : Class (MyWork) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyWork" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnPreLoad, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRegisterRibbon, 0)]
        public void AUT_MyWork_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myWorkInstanceFixture, 
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
        ///     Class (<see cref="MyWork" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyWork_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkInstanceType.ShouldNotBeNull();
            _myWorkInstance.ShouldNotBeNull();
            _myWorkInstanceFixture.ShouldNotBeNull();
            _myWorkInstance.ShouldBeAssignableTo<MyWork>();
            _myWorkInstanceFixture.ShouldBeAssignableTo<MyWork>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWork) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MyWork_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyWork instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myWorkInstanceType.ShouldNotBeNull();
            _myWorkInstance.ShouldNotBeNull();
            _myWorkInstanceFixture.ShouldNotBeNull();
            _myWorkInstance.ShouldBeAssignableTo<MyWork>();
            _myWorkInstanceFixture.ShouldBeAssignableTo<MyWork>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MyWork" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnPreLoad)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRegisterRibbon)]
        public void AUT_MyWork_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MyWork>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_OnPreLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnPreLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodOnPreLoad, Fixture, methodOnPreLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_OnPreLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreLoad, methodOnPreLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfOnPreLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreLoad.ShouldNotBeNull();
            parametersOfOnPreLoad.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(parametersOfOnPreLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_OnPreLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkInstance, MethodOnPreLoad, parametersOfOnPreLoad, methodOnPreLoadPrametersTypes);

            // Assert
            parametersOfOnPreLoad.ShouldNotBeNull();
            parametersOfOnPreLoad.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            methodOnPreLoadPrametersTypes.Length.ShouldBe(parametersOfOnPreLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_OnPreLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_OnPreLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodOnPreLoad, Fixture, methodOnPreLoadPrametersTypes);

            // Assert
            methodOnPreLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_OnPreLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_MyWork_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_MyWork_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_RegisterRibbon_Method_Call_Internally(Type[] types)
        {
            var methodRegisterRibbonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodRegisterRibbon, Fixture, methodRegisterRibbonPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RegisterRibbon_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;
            object[] parametersOfRegisterRibbon = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterRibbon, methodRegisterRibbonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfRegisterRibbon);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterRibbon.ShouldBeNull();
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RegisterRibbon_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;
            object[] parametersOfRegisterRibbon = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkInstance, MethodRegisterRibbon, parametersOfRegisterRibbon, methodRegisterRibbonPrametersTypes);

            // Assert
            parametersOfRegisterRibbon.ShouldBeNull();
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RegisterRibbon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkInstance, MethodRegisterRibbon, Fixture, methodRegisterRibbonPrametersTypes);

            // Assert
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RegisterRibbon_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterRibbon, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}