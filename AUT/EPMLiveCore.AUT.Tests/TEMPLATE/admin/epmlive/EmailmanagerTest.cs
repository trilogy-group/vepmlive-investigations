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

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.EPMLiveCore.emailmanager" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailmanagerTest : AbstractBaseSetupTypedTest<emailmanager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (emailmanager) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGridView1_RowEditing = "GridView1_RowEditing";
        private const string MethodbtnSubmit_Click = "btnSubmit_Click";
        private const string MethodbtnCancel_Click = "btnCancel_Click";
        private const string MethodWebApplicationSelector1_ContextChange = "WebApplicationSelector1_ContextChange";
        private const string MethodloadTemplates = "loadTemplates";
        private Type _emailmanagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private emailmanager _emailmanagerInstance;
        private emailmanager _emailmanagerInstanceFixture;

        #region General Initializer : Class (emailmanager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="emailmanager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailmanagerInstanceType = typeof(emailmanager);
            _emailmanagerInstanceFixture = Create(true);
            _emailmanagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (emailmanager)

        #region General Initializer : Class (emailmanager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="emailmanager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGridView1_RowEditing, 0)]
        [TestCase(MethodbtnSubmit_Click, 0)]
        [TestCase(MethodbtnCancel_Click, 0)]
        [TestCase(MethodWebApplicationSelector1_ContextChange, 0)]
        [TestCase(MethodloadTemplates, 0)]
        public void AUT_Emailmanager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_emailmanagerInstanceFixture, 
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
        ///     Class (<see cref="emailmanager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Emailmanager_Is_Instance_Present_Test()
        {
            // Assert
            _emailmanagerInstanceType.ShouldNotBeNull();
            _emailmanagerInstance.ShouldNotBeNull();
            _emailmanagerInstanceFixture.ShouldNotBeNull();
            _emailmanagerInstance.ShouldBeAssignableTo<emailmanager>();
            _emailmanagerInstanceFixture.ShouldBeAssignableTo<emailmanager>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (emailmanager) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_emailmanager_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            emailmanager instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailmanagerInstanceType.ShouldNotBeNull();
            _emailmanagerInstance.ShouldNotBeNull();
            _emailmanagerInstanceFixture.ShouldNotBeNull();
            _emailmanagerInstance.ShouldBeAssignableTo<emailmanager>();
            _emailmanagerInstanceFixture.ShouldBeAssignableTo<emailmanager>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="emailmanager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGridView1_RowEditing)]
        [TestCase(MethodbtnSubmit_Click)]
        [TestCase(MethodbtnCancel_Click)]
        [TestCase(MethodWebApplicationSelector1_ContextChange)]
        [TestCase(MethodloadTemplates)]
        public void AUT_Emailmanager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<emailmanager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Emailmanager_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Emailmanager_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Emailmanager_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_GridView1_RowEditing_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowEditingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodGridView1_RowEditing, Fixture, methodGridView1_RowEditingPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_GridView1_RowEditing_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewEditEventArgs>();
            var methodGridView1_RowEditingPrametersTypes = new Type[] { typeof(object), typeof(GridViewEditEventArgs) };
            object[] parametersOfGridView1_RowEditing = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowEditing, methodGridView1_RowEditingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfGridView1_RowEditing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowEditing.ShouldNotBeNull();
            parametersOfGridView1_RowEditing.Length.ShouldBe(2);
            methodGridView1_RowEditingPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowEditingPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowEditing.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_GridView1_RowEditing_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewEditEventArgs>();
            var methodGridView1_RowEditingPrametersTypes = new Type[] { typeof(object), typeof(GridViewEditEventArgs) };
            object[] parametersOfGridView1_RowEditing = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodGridView1_RowEditing, parametersOfGridView1_RowEditing, methodGridView1_RowEditingPrametersTypes);

            // Assert
            parametersOfGridView1_RowEditing.ShouldNotBeNull();
            parametersOfGridView1_RowEditing.Length.ShouldBe(2);
            methodGridView1_RowEditingPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowEditingPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowEditing.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_GridView1_RowEditing_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowEditing, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_GridView1_RowEditing_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowEditingPrametersTypes = new Type[] { typeof(object), typeof(GridViewEditEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodGridView1_RowEditing, Fixture, methodGridView1_RowEditingPrametersTypes);

            // Assert
            methodGridView1_RowEditingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowEditing) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_GridView1_RowEditing_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowEditing, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_btnSubmit_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSubmit_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnSubmit_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfbtnSubmit_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSubmit_Click.ShouldNotBeNull();
            parametersOfbtnSubmit_Click.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnSubmit_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodbtnSubmit_Click, parametersOfbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            parametersOfbtnSubmit_Click.ShouldNotBeNull();
            parametersOfbtnSubmit_Click.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnSubmit_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnSubmit_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnSubmit_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_btnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnCancel_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, methodbtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfbtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodbtnCancel_Click, parametersOfbtnCancel_Click, methodbtnCancel_ClickPrametersTypes);

            // Assert
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);

            // Assert
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_btnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_Internally(Type[] types)
        {
            var methodWebApplicationSelector1_ContextChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfWebApplicationSelector1_ContextChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebApplicationSelector1_ContextChange.ShouldNotBeNull();
            parametersOfWebApplicationSelector1_ContextChange.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(parametersOfWebApplicationSelector1_ContextChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodWebApplicationSelector1_ContextChange, parametersOfWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            parametersOfWebApplicationSelector1_ContextChange.ShouldNotBeNull();
            parametersOfWebApplicationSelector1_ContextChange.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(parametersOfWebApplicationSelector1_ContextChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_WebApplicationSelector1_ContextChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Emailmanager_loadTemplates_Method_Call_Internally(Type[] types)
        {
            var methodloadTemplatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodloadTemplates, Fixture, methodloadTemplatesPrametersTypes);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_loadTemplates_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodloadTemplatesPrametersTypes = null;
            object[] parametersOfloadTemplates = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadTemplates, methodloadTemplatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_emailmanagerInstanceFixture, parametersOfloadTemplates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadTemplates.ShouldBeNull();
            methodloadTemplatesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_loadTemplates_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodloadTemplatesPrametersTypes = null;
            object[] parametersOfloadTemplates = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_emailmanagerInstance, MethodloadTemplates, parametersOfloadTemplates, methodloadTemplatesPrametersTypes);

            // Assert
            parametersOfloadTemplates.ShouldBeNull();
            methodloadTemplatesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_loadTemplates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodloadTemplatesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_emailmanagerInstance, MethodloadTemplates, Fixture, methodloadTemplatesPrametersTypes);

            // Assert
            methodloadTemplatesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Emailmanager_loadTemplates_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadTemplates, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_emailmanagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}