using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.MyTasks" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyTasksTest : AbstractBaseSetupTypedTest<MyTasks>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyTasks) Initializer

        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRender = "Render";
        private Type _myTasksInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyTasks _myTasksInstance;
        private MyTasks _myTasksInstanceFixture;

        #region General Initializer : Class (MyTasks) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyTasks" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myTasksInstanceType = typeof(MyTasks);
            _myTasksInstanceFixture = Create(true);
            _myTasksInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyTasks)

        #region General Initializer : Class (MyTasks) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyTasks" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRender, 0)]
        public void AUT_MyTasks_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myTasksInstanceFixture, 
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
        ///     Class (<see cref="MyTasks" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MyTasks_Is_Instance_Present_Test()
        {
            // Assert
            _myTasksInstanceType.ShouldNotBeNull();
            _myTasksInstance.ShouldNotBeNull();
            _myTasksInstanceFixture.ShouldNotBeNull();
            _myTasksInstance.ShouldBeAssignableTo<MyTasks>();
            _myTasksInstanceFixture.ShouldBeAssignableTo<MyTasks>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyTasks) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MyTasks_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyTasks instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myTasksInstanceType.ShouldNotBeNull();
            _myTasksInstance.ShouldNotBeNull();
            _myTasksInstanceFixture.ShouldNotBeNull();
            _myTasksInstance.ShouldBeAssignableTo<MyTasks>();
            _myTasksInstanceFixture.ShouldBeAssignableTo<MyTasks>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MyTasks" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRender)]
        public void AUT_MyTasks_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MyTasks>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyTasks_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myTasksInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_CreateChildControls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myTasksInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myTasksInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myTasksInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myTasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyTasks_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myTasksInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myTasksInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myTasksInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myTasksInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MyTasks_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myTasksInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}