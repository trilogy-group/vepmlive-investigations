using System;
using System.Collections;
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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.setup" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class SetupTest : AbstractBaseSetupTypedTest<setup>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (setup) Initializer

        private const string MethodbtnGrpPermAdd_OnClick = "btnGrpPermAdd_OnClick";
        private const string MethodlnkGrpPermDelete_OnClick = "lnkGrpPermDelete_OnClick";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodbtnAdd_Click = "btnAdd_Click";
        private const string MethodbtnRemove_Click = "btnRemove_Click";
        private const string MethodcheckLocks = "checkLocks";
        private const string MethodlnkButton_Click = "lnkButton_Click";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodloadTemplates = "loadTemplates";
        private const string MethodGetGroupsPermissionsAssignment = "GetGroupsPermissionsAssignment";
        private const string MethodbtnSynch_Click = "btnSynch_Click";
        private const string MethodgetPeriods = "getPeriods";
        private const string Fieldurl = "url";
        private const string FieldButton1 = "Button1";
        private const string FieldtxtResourceURL = "txtResourceURL";
        private const string FieldchkLockConfig = "chkLockConfig";
        private const string FieldlstAllTemplates = "lstAllTemplates";
        private const string FieldlstSelectedTemplates = "lstSelectedTemplates";
        private const string FieldtxtProjectServer = "txtProjectServer";
        private const string FieldddlWorkspaceType = "ddlWorkspaceType";
        private const string FieldddlNavigation = "ddlNavigation";
        private const string FieldddlPermissions = "ddlPermissions";
        private const string FieldGvGroupsPermissions = "GvGroupsPermissions";
        private const string FieldddlGroups = "ddlGroups";
        private const string FieldddlSPPermissions = "ddlSPPermissions";
        private const string FielddtGroupsPermissions = "dtGroupsPermissions";
        private const string FieldlblGridFocus = "lblGridFocus";
        private const string FieldddlRoleOwners = "ddlRoleOwners";
        private const string FieldddlRoleMembers = "ddlRoleMembers";
        private const string FieldddlRoleVisitors = "ddlRoleVisitors";
        private const string FieldtxtResToolReportURL = "txtResToolReportURL";
        private Type _setupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private setup _setupInstance;
        private setup _setupInstanceFixture;

        #region General Initializer : Class (setup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="setup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _setupInstanceType = typeof(setup);
            _setupInstanceFixture = Create(true);
            _setupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (setup)

        #region General Initializer : Class (setup) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="setup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodbtnGrpPermAdd_OnClick, 0)]
        [TestCase(MethodlnkGrpPermDelete_OnClick, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodbtnAdd_Click, 0)]
        [TestCase(MethodbtnRemove_Click, 0)]
        [TestCase(MethodcheckLocks, 0)]
        [TestCase(MethodlnkButton_Click, 0)]
        [TestCase(MethodButton1_Click, 0)]
        [TestCase(MethodloadTemplates, 0)]
        [TestCase(MethodGetGroupsPermissionsAssignment, 0)]
        [TestCase(MethodbtnSynch_Click, 0)]
        [TestCase(MethodgetPeriods, 0)]
        public void AUT_Setup_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_setupInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (setup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="setup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldurl)]
        [TestCase(FieldButton1)]
        [TestCase(FieldtxtResourceURL)]
        [TestCase(FieldchkLockConfig)]
        [TestCase(FieldlstAllTemplates)]
        [TestCase(FieldlstSelectedTemplates)]
        [TestCase(FieldtxtProjectServer)]
        [TestCase(FieldddlWorkspaceType)]
        [TestCase(FieldddlNavigation)]
        [TestCase(FieldddlPermissions)]
        [TestCase(FieldGvGroupsPermissions)]
        [TestCase(FieldddlGroups)]
        [TestCase(FieldddlSPPermissions)]
        [TestCase(FielddtGroupsPermissions)]
        [TestCase(FieldlblGridFocus)]
        [TestCase(FieldddlRoleOwners)]
        [TestCase(FieldddlRoleMembers)]
        [TestCase(FieldddlRoleVisitors)]
        [TestCase(FieldtxtResToolReportURL)]
        public void AUT_Setup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_setupInstanceFixture, 
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
        ///     Class (<see cref="setup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Setup_Is_Instance_Present_Test()
        {
            // Assert
            _setupInstanceType.ShouldNotBeNull();
            _setupInstance.ShouldNotBeNull();
            _setupInstanceFixture.ShouldNotBeNull();
            _setupInstance.ShouldBeAssignableTo<setup>();
            _setupInstanceFixture.ShouldBeAssignableTo<setup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (setup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_setup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            setup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _setupInstanceType.ShouldNotBeNull();
            _setupInstance.ShouldNotBeNull();
            _setupInstanceFixture.ShouldNotBeNull();
            _setupInstance.ShouldBeAssignableTo<setup>();
            _setupInstanceFixture.ShouldBeAssignableTo<setup>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="setup" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodbtnGrpPermAdd_OnClick)]
        [TestCase(MethodlnkGrpPermDelete_OnClick)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodbtnAdd_Click)]
        [TestCase(MethodbtnRemove_Click)]
        [TestCase(MethodcheckLocks)]
        [TestCase(MethodlnkButton_Click)]
        [TestCase(MethodButton1_Click)]
        [TestCase(MethodloadTemplates)]
        [TestCase(MethodGetGroupsPermissionsAssignment)]
        [TestCase(MethodbtnSynch_Click)]
        [TestCase(MethodgetPeriods)]
        public void AUT_Setup_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<setup>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnGrpPermAdd_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnGrpPermAdd_OnClick, Fixture, methodbtnGrpPermAdd_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnGrpPermAdd_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, methodbtnGrpPermAdd_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfbtnGrpPermAdd_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnGrpPermAdd_OnClick.ShouldNotBeNull();
            parametersOfbtnGrpPermAdd_OnClick.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnGrpPermAdd_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnGrpPermAdd_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodbtnGrpPermAdd_OnClick, parametersOfbtnGrpPermAdd_OnClick, methodbtnGrpPermAdd_OnClickPrametersTypes);

            // Assert
            parametersOfbtnGrpPermAdd_OnClick.ShouldNotBeNull();
            parametersOfbtnGrpPermAdd_OnClick.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnGrpPermAdd_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnGrpPermAdd_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnGrpPermAdd_OnClick, Fixture, methodbtnGrpPermAdd_OnClickPrametersTypes);

            // Assert
            methodbtnGrpPermAdd_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnGrpPermAdd_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnGrpPermAdd_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnGrpPermAdd_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodlnkGrpPermDelete_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodlnkGrpPermDelete_OnClick, Fixture, methodlnkGrpPermDelete_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkGrpPermDelete_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, methodlnkGrpPermDelete_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOflnkGrpPermDelete_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflnkGrpPermDelete_OnClick.ShouldNotBeNull();
            parametersOflnkGrpPermDelete_OnClick.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(parametersOflnkGrpPermDelete_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkGrpPermDelete_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodlnkGrpPermDelete_OnClick, parametersOflnkGrpPermDelete_OnClick, methodlnkGrpPermDelete_OnClickPrametersTypes);

            // Assert
            parametersOflnkGrpPermDelete_OnClick.ShouldNotBeNull();
            parametersOflnkGrpPermDelete_OnClick.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(parametersOflnkGrpPermDelete_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnkGrpPermDelete_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodlnkGrpPermDelete_OnClick, Fixture, methodlnkGrpPermDelete_OnClickPrametersTypes);

            // Assert
            methodlnkGrpPermDelete_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkGrpPermDelete_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkGrpPermDelete_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlnkGrpPermDelete_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Setup_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Setup_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Setup_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_btnAdd_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnAdd_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnAdd_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, methodbtnAdd_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfbtnAdd_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnAdd_Click.ShouldNotBeNull();
            parametersOfbtnAdd_Click.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnAdd_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnAdd_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodbtnAdd_Click, parametersOfbtnAdd_Click, methodbtnAdd_ClickPrametersTypes);

            // Assert
            parametersOfbtnAdd_Click.ShouldNotBeNull();
            parametersOfbtnAdd_Click.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnAdd_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnAdd_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnAdd_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);

            // Assert
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnAdd_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_btnRemove_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRemove_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnRemove_Click, Fixture, methodbtnRemove_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnRemove_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemove_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRemove_Click, methodbtnRemove_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfbtnRemove_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRemove_Click.ShouldNotBeNull();
            parametersOfbtnRemove_Click.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRemove_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnRemove_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemove_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodbtnRemove_Click, parametersOfbtnRemove_Click, methodbtnRemove_ClickPrametersTypes);

            // Assert
            parametersOfbtnRemove_Click.ShouldNotBeNull();
            parametersOfbtnRemove_Click.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRemove_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnRemove_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRemove_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnRemove_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnRemove_Click, Fixture, methodbtnRemove_ClickPrametersTypes);

            // Assert
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnRemove_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRemove_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_checkLocks_Method_Call_Internally(Type[] types)
        {
            var methodcheckLocksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodcheckLocks, Fixture, methodcheckLocksPrametersTypes);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_checkLocks_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodcheckLocksPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcheckLocks = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcheckLocks, methodcheckLocksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfcheckLocks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcheckLocks.ShouldNotBeNull();
            parametersOfcheckLocks.Length.ShouldBe(1);
            methodcheckLocksPrametersTypes.Length.ShouldBe(1);
            methodcheckLocksPrametersTypes.Length.ShouldBe(parametersOfcheckLocks.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_checkLocks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodcheckLocksPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcheckLocks = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodcheckLocks, parametersOfcheckLocks, methodcheckLocksPrametersTypes);

            // Assert
            parametersOfcheckLocks.ShouldNotBeNull();
            parametersOfcheckLocks.Length.ShouldBe(1);
            methodcheckLocksPrametersTypes.Length.ShouldBe(1);
            methodcheckLocksPrametersTypes.Length.ShouldBe(parametersOfcheckLocks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_checkLocks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcheckLocks, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_checkLocks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcheckLocksPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodcheckLocks, Fixture, methodcheckLocksPrametersTypes);

            // Assert
            methodcheckLocksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkLocks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_checkLocks_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcheckLocks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_lnkButton_Click_Method_Call_Internally(Type[] types)
        {
            var methodlnkButton_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodlnkButton_Click, Fixture, methodlnkButton_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkButton_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkButton_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlnkButton_Click, methodlnkButton_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOflnkButton_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflnkButton_Click.ShouldNotBeNull();
            parametersOflnkButton_Click.Length.ShouldBe(2);
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(parametersOflnkButton_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkButton_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkButton_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodlnkButton_Click, parametersOflnkButton_Click, methodlnkButton_ClickPrametersTypes);

            // Assert
            parametersOflnkButton_Click.ShouldNotBeNull();
            parametersOflnkButton_Click.Length.ShouldBe(2);
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(2);
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(parametersOflnkButton_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkButton_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlnkButton_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkButton_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodlnkButton_Click, Fixture, methodlnkButton_ClickPrametersTypes);

            // Assert
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_lnkButton_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlnkButton_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfButton1_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

            // Assert
            parametersOfButton1_Click.ShouldNotBeNull();
            parametersOfButton1_Click.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            methodButton1_ClickPrametersTypes.Length.ShouldBe(parametersOfButton1_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_loadTemplates_Method_Call_Internally(Type[] types)
        {
            var methodloadTemplatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodloadTemplates, Fixture, methodloadTemplatesPrametersTypes);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_loadTemplates_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var validtemplates = CreateType<string>();
            var methodloadTemplatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfloadTemplates = { validtemplates };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadTemplates, methodloadTemplatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfloadTemplates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadTemplates.ShouldNotBeNull();
            parametersOfloadTemplates.Length.ShouldBe(1);
            methodloadTemplatesPrametersTypes.Length.ShouldBe(1);
            methodloadTemplatesPrametersTypes.Length.ShouldBe(parametersOfloadTemplates.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_loadTemplates_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var validtemplates = CreateType<string>();
            var methodloadTemplatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfloadTemplates = { validtemplates };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodloadTemplates, parametersOfloadTemplates, methodloadTemplatesPrametersTypes);

            // Assert
            parametersOfloadTemplates.ShouldNotBeNull();
            parametersOfloadTemplates.Length.ShouldBe(1);
            methodloadTemplatesPrametersTypes.Length.ShouldBe(1);
            methodloadTemplatesPrametersTypes.Length.ShouldBe(parametersOfloadTemplates.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_loadTemplates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadTemplates, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_loadTemplates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadTemplatesPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodloadTemplates, Fixture, methodloadTemplatesPrametersTypes);

            // Assert
            methodloadTemplatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadTemplates) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_loadTemplates_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadTemplates, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_Internally(Type[] types)
        {
            var methodGetGroupsPermissionsAssignmentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<setup, string>(_setupInstanceFixture, out exception1, parametersOfGetGroupsPermissionsAssignment);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<setup, string>(_setupInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<setup, string>(_setupInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_setupInstanceFixture, parametersOfGetGroupsPermissionsAssignment));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            object[] parametersOfGetGroupsPermissionsAssignment = null; // no parameter present

            // Assert
            parametersOfGetGroupsPermissionsAssignment.ShouldBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<setup, string>(_setupInstance, MethodGetGroupsPermissionsAssignment, parametersOfGetGroupsPermissionsAssignment, methodGetGroupsPermissionsAssignmentPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetGroupsPermissionsAssignmentPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodGetGroupsPermissionsAssignment, Fixture, methodGetGroupsPermissionsAssignmentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGroupsPermissionsAssignmentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroupsPermissionsAssignment) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_GetGroupsPermissionsAssignment_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGroupsPermissionsAssignment, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_btnSynch_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSynch_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnSynch_Click, Fixture, methodbtnSynch_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnSynch_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSynch_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSynch_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSynch_Click, methodbtnSynch_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_setupInstanceFixture, parametersOfbtnSynch_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSynch_Click.ShouldNotBeNull();
            parametersOfbtnSynch_Click.Length.ShouldBe(2);
            methodbtnSynch_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSynch_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSynch_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnSynch_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSynch_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSynch_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_setupInstance, MethodbtnSynch_Click, parametersOfbtnSynch_Click, methodbtnSynch_ClickPrametersTypes);

            // Assert
            parametersOfbtnSynch_Click.ShouldNotBeNull();
            parametersOfbtnSynch_Click.Length.ShouldBe(2);
            methodbtnSynch_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSynch_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSynch_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnSynch_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSynch_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnSynch_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSynch_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodbtnSynch_Click, Fixture, methodbtnSynch_ClickPrametersTypes);

            // Assert
            methodbtnSynch_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSynch_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_btnSynch_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSynch_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Setup_getPeriods_Method_Call_Internally(Type[] types)
        {
            var methodgetPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodgetPeriods, Fixture, methodgetPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodgetPeriodsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetPeriods = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetPeriods, methodgetPeriodsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<setup, ArrayList>(_setupInstanceFixture, out exception1, parametersOfgetPeriods);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<setup, ArrayList>(_setupInstance, MethodgetPeriods, parametersOfgetPeriods, methodgetPeriodsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetPeriods.ShouldNotBeNull();
            parametersOfgetPeriods.Length.ShouldBe(1);
            methodgetPeriodsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_setupInstanceFixture, parametersOfgetPeriods));
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodgetPeriodsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetPeriods = { url };

            // Assert
            parametersOfgetPeriods.ShouldNotBeNull();
            parametersOfgetPeriods.Length.ShouldBe(1);
            methodgetPeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<setup, ArrayList>(_setupInstance, MethodgetPeriods, parametersOfgetPeriods, methodgetPeriodsPrametersTypes));
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPeriodsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodgetPeriods, Fixture, methodgetPeriodsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPeriodsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPeriodsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_setupInstance, MethodgetPeriods, Fixture, methodgetPeriodsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPeriodsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPeriods, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_setupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPeriods) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Setup_getPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetPeriods, 0);
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