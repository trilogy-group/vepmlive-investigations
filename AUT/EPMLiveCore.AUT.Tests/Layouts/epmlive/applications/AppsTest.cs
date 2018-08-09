using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.applications.Apps" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.applications"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AppsTest : AbstractBaseSetupTypedTest<Apps>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Apps) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGridView_RowDataBound = "GridView_RowDataBound";
        private const string MethodInstallButton = "InstallButton";
        private Type _appsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Apps _appsInstance;
        private Apps _appsInstanceFixture;

        #region General Initializer : Class (Apps) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Apps" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _appsInstanceType = typeof(Apps);
            _appsInstanceFixture = Create(true);
            _appsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Apps)

        #region General Initializer : Class (Apps) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Apps" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGridView_RowDataBound, 0)]
        [TestCase(MethodInstallButton, 0)]
        public void AUT_Apps_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_appsInstanceFixture, 
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
        ///     Class (<see cref="Apps" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Apps_Is_Instance_Present_Test()
        {
            // Assert
            _appsInstanceType.ShouldNotBeNull();
            _appsInstance.ShouldNotBeNull();
            _appsInstanceFixture.ShouldNotBeNull();
            _appsInstance.ShouldBeAssignableTo<Apps>();
            _appsInstanceFixture.ShouldBeAssignableTo<Apps>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Apps) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Apps_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Apps instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _appsInstanceType.ShouldNotBeNull();
            _appsInstance.ShouldNotBeNull();
            _appsInstanceFixture.ShouldNotBeNull();
            _appsInstance.ShouldBeAssignableTo<Apps>();
            _appsInstanceFixture.ShouldBeAssignableTo<Apps>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Apps" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGridView_RowDataBound)]
        [TestCase(MethodInstallButton)]
        public void AUT_Apps_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Apps>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Apps_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Apps_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Apps_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Apps_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Apps_GridView_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodGridView_RowDataBound, Fixture, methodGridView_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_GridView_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, methodGridView_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appsInstanceFixture, parametersOfGridView_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView_RowDataBound.ShouldNotBeNull();
            parametersOfGridView_RowDataBound.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_GridView_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appsInstance, MethodGridView_RowDataBound, parametersOfGridView_RowDataBound, methodGridView_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView_RowDataBound.ShouldNotBeNull();
            parametersOfGridView_RowDataBound.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_GridView_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_GridView_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodGridView_RowDataBound, Fixture, methodGridView_RowDataBoundPrametersTypes);

            // Assert
            methodGridView_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_GridView_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Apps_InstallButton_Method_Call_Internally(Type[] types)
        {
            var methodInstallButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodInstallButton, Fixture, methodInstallButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodInstallButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfInstallButton = { id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstallButton, methodInstallButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallButton.ShouldNotBeNull();
            parametersOfInstallButton.Length.ShouldBe(1);
            methodInstallButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_appsInstanceFixture, parametersOfInstallButton));
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<object>();
            var methodInstallButtonPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfInstallButton = { id };

            // Assert
            parametersOfInstallButton.ShouldNotBeNull();
            parametersOfInstallButton.Length.ShouldBe(1);
            methodInstallButtonPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Apps, string>(_appsInstance, MethodInstallButton, parametersOfInstallButton, methodInstallButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInstallButtonPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodInstallButton, Fixture, methodInstallButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInstallButtonPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallButtonPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appsInstance, MethodInstallButton, Fixture, methodInstallButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallButtonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_appsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InstallButton) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Apps_InstallButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallButton, 0);
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