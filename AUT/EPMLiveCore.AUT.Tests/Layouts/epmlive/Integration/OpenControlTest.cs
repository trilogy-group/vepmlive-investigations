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

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Integration.OpenControl" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class OpenControlTest : AbstractBaseSetupTypedTest<OpenControl>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OpenControl) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodRedirectTo = "RedirectTo";
        private Type _openControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OpenControl _openControlInstance;
        private OpenControl _openControlInstanceFixture;

        #region General Initializer : Class (OpenControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OpenControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _openControlInstanceType = typeof(OpenControl);
            _openControlInstanceFixture = Create(true);
            _openControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OpenControl)

        #region General Initializer : Class (OpenControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="OpenControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRedirectTo, 0)]
        [TestCase(MethodRedirectTo, 1)]
        public void AUT_OpenControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_openControlInstanceFixture, 
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
        ///     Class (<see cref="OpenControl" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_OpenControl_Is_Instance_Present_Test()
        {
            // Assert
            _openControlInstanceType.ShouldNotBeNull();
            _openControlInstance.ShouldNotBeNull();
            _openControlInstanceFixture.ShouldNotBeNull();
            _openControlInstance.ShouldBeAssignableTo<OpenControl>();
            _openControlInstanceFixture.ShouldBeAssignableTo<OpenControl>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OpenControl) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_OpenControl_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            OpenControl instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _openControlInstanceType.ShouldNotBeNull();
            _openControlInstance.ShouldNotBeNull();
            _openControlInstanceFixture.ShouldNotBeNull();
            _openControlInstance.ShouldBeAssignableTo<OpenControl>();
            _openControlInstanceFixture.ShouldBeAssignableTo<OpenControl>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="OpenControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRedirectTo)]
        public void AUT_OpenControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<OpenControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OpenControl_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_openControlInstanceFixture, parametersOfPage_Load);

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
        public void AUT_OpenControl_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_openControlInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_OpenControl_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_OpenControl_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_openControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OpenControl_RedirectTo_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodRedirectTo, Fixture, methodRedirectToPrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var control = CreateType<string>();
            var methodRedirectToPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRedirectTo = { control };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectTo, methodRedirectToPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_openControlInstanceFixture, parametersOfRedirectTo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectTo.ShouldNotBeNull();
            parametersOfRedirectTo.Length.ShouldBe(1);
            methodRedirectToPrametersTypes.Length.ShouldBe(1);
            methodRedirectToPrametersTypes.Length.ShouldBe(parametersOfRedirectTo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var control = CreateType<string>();
            var methodRedirectToPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRedirectTo = { control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_openControlInstance, MethodRedirectTo, parametersOfRedirectTo, methodRedirectToPrametersTypes);

            // Assert
            parametersOfRedirectTo.ShouldNotBeNull();
            parametersOfRedirectTo.Length.ShouldBe(1);
            methodRedirectToPrametersTypes.Length.ShouldBe(1);
            methodRedirectToPrametersTypes.Length.ShouldBe(parametersOfRedirectTo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRedirectTo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRedirectToPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodRedirectTo, Fixture, methodRedirectToPrametersTypes);

            // Assert
            methodRedirectToPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectTo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_openControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OpenControl_RedirectTo_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodRedirectToPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodRedirectTo, Fixture, methodRedirectToPrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var control = CreateType<string>();
            var methodRedirectToPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfRedirectTo = { li, control };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectTo, methodRedirectToPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_openControlInstanceFixture, parametersOfRedirectTo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectTo.ShouldNotBeNull();
            parametersOfRedirectTo.Length.ShouldBe(2);
            methodRedirectToPrametersTypes.Length.ShouldBe(2);
            methodRedirectToPrametersTypes.Length.ShouldBe(parametersOfRedirectTo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var control = CreateType<string>();
            var methodRedirectToPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfRedirectTo = { li, control };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_openControlInstance, MethodRedirectTo, parametersOfRedirectTo, methodRedirectToPrametersTypes);

            // Assert
            parametersOfRedirectTo.ShouldNotBeNull();
            parametersOfRedirectTo.Length.ShouldBe(2);
            methodRedirectToPrametersTypes.Length.ShouldBe(2);
            methodRedirectToPrametersTypes.Length.ShouldBe(parametersOfRedirectTo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRedirectTo, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRedirectToPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_openControlInstance, MethodRedirectTo, Fixture, methodRedirectToPrametersTypes);

            // Assert
            methodRedirectToPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectTo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OpenControl_RedirectTo_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectTo, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_openControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}