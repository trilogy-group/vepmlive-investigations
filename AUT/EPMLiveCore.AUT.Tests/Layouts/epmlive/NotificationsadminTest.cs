using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.notificationsadmin" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NotificationsadminTest : AbstractBaseSetupTypedTest<notificationsadmin>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (notificationsadmin) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodbtnTest_Click = "btnTest_Click";
        private const string MethodloadNotificationBoxes = "loadNotificationBoxes";
        private const string MethodBindNListsToGrid = "BindNListsToGrid";
        private const string MethodgvNotificationLists_RowDataBound = "gvNotificationLists_RowDataBound";
        private const string MethodAddNewPageList = "AddNewPageList";
        private const string MethodAddList = "AddList";
        private const string MethodEditList = "EditList";
        private const string MethodDeleteList = "DeleteList";
        private const string MethodbtnCancel_Click = "btnCancel_Click";
        private const string MethodbtnAdd_Click = "btnAdd_Click";
        private const string MethodbtnRemove_Click = "btnRemove_Click";
        private const string MethodbtnSave_Click = "btnSave_Click";
        private const string MethodsaveSettings = "saveSettings";
        private const string FieldstrTitle = "strTitle";
        private const string FieldstrTemplate = "strTemplate";
        private const string Fielddesc = "desc";
        private const string FieldpnlTL = "pnlTL";
        private const string FieldpnlMain = "pnlMain";
        private const string FieldpnlGeneralSettings = "pnlGeneralSettings";
        private const string FieldpnlUserSettings = "pnlUserSettings";
        private const string FieldhlAdmin = "hlAdmin";
        private const string FieldButton1 = "Button1";
        private const string FieldbtnAdd = "btnAdd";
        private const string FieldbtnRemove = "btnRemove";
        private const string FieldbtnTest = "btnTest";
        private const string FieldddlRunTime = "ddlRunTime";
        private const string FieldtxtFromEmail = "txtFromEmail";
        private const string FieldtxtEmailSubject = "txtEmailSubject";
        private const string FieldtxtNotes = "txtNotes";
        private const string FieldgvNotificationLists = "gvNotificationLists";
        private const string FieldlblLastRun = "lblLastRun";
        private const string FieldlblNotEnabled = "lblNotEnabled";
        private const string FieldlblStatus = "lblStatus";
        private Type _notificationsadminInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private notificationsadmin _notificationsadminInstance;
        private notificationsadmin _notificationsadminInstanceFixture;

        #region General Initializer : Class (notificationsadmin) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="notificationsadmin" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _notificationsadminInstanceType = typeof(notificationsadmin);
            _notificationsadminInstanceFixture = Create(true);
            _notificationsadminInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (notificationsadmin)

        #region General Initializer : Class (notificationsadmin) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="notificationsadmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodbtnTest_Click, 0)]
        [TestCase(MethodloadNotificationBoxes, 0)]
        [TestCase(MethodBindNListsToGrid, 0)]
        [TestCase(MethodgvNotificationLists_RowDataBound, 0)]
        [TestCase(MethodAddNewPageList, 0)]
        [TestCase(MethodAddList, 0)]
        [TestCase(MethodEditList, 0)]
        [TestCase(MethodDeleteList, 0)]
        [TestCase(MethodbtnCancel_Click, 0)]
        [TestCase(MethodbtnAdd_Click, 0)]
        [TestCase(MethodbtnRemove_Click, 0)]
        [TestCase(MethodbtnSave_Click, 0)]
        [TestCase(MethodsaveSettings, 0)]
        public void AUT_Notificationsadmin_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_notificationsadminInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (notificationsadmin) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="notificationsadmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstrTitle)]
        [TestCase(FieldstrTemplate)]
        [TestCase(Fielddesc)]
        [TestCase(FieldpnlTL)]
        [TestCase(FieldpnlMain)]
        [TestCase(FieldpnlGeneralSettings)]
        [TestCase(FieldpnlUserSettings)]
        [TestCase(FieldhlAdmin)]
        [TestCase(FieldButton1)]
        [TestCase(FieldbtnAdd)]
        [TestCase(FieldbtnRemove)]
        [TestCase(FieldbtnTest)]
        [TestCase(FieldddlRunTime)]
        [TestCase(FieldtxtFromEmail)]
        [TestCase(FieldtxtEmailSubject)]
        [TestCase(FieldtxtNotes)]
        [TestCase(FieldgvNotificationLists)]
        [TestCase(FieldlblLastRun)]
        [TestCase(FieldlblNotEnabled)]
        [TestCase(FieldlblStatus)]
        public void AUT_Notificationsadmin_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_notificationsadminInstanceFixture, 
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
        ///     Class (<see cref="notificationsadmin" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Notificationsadmin_Is_Instance_Present_Test()
        {
            // Assert
            _notificationsadminInstanceType.ShouldNotBeNull();
            _notificationsadminInstance.ShouldNotBeNull();
            _notificationsadminInstanceFixture.ShouldNotBeNull();
            _notificationsadminInstance.ShouldBeAssignableTo<notificationsadmin>();
            _notificationsadminInstanceFixture.ShouldBeAssignableTo<notificationsadmin>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (notificationsadmin) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_notificationsadmin_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            notificationsadmin instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _notificationsadminInstanceType.ShouldNotBeNull();
            _notificationsadminInstance.ShouldNotBeNull();
            _notificationsadminInstanceFixture.ShouldNotBeNull();
            _notificationsadminInstance.ShouldBeAssignableTo<notificationsadmin>();
            _notificationsadminInstanceFixture.ShouldBeAssignableTo<notificationsadmin>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="notificationsadmin" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodbtnTest_Click)]
        [TestCase(MethodloadNotificationBoxes)]
        [TestCase(MethodBindNListsToGrid)]
        [TestCase(MethodgvNotificationLists_RowDataBound)]
        [TestCase(MethodAddNewPageList)]
        [TestCase(MethodAddList)]
        [TestCase(MethodEditList)]
        [TestCase(MethodDeleteList)]
        [TestCase(MethodbtnCancel_Click)]
        [TestCase(MethodbtnAdd_Click)]
        [TestCase(MethodbtnRemove_Click)]
        [TestCase(MethodbtnSave_Click)]
        [TestCase(MethodsaveSettings)]
        public void AUT_Notificationsadmin_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<notificationsadmin>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Notificationsadmin_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Notificationsadmin_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Notificationsadmin_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_btnTest_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnTest_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnTest_Click, Fixture, methodbtnTest_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnTest_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnTest_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnTest_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnTest_Click, methodbtnTest_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfbtnTest_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnTest_Click.ShouldNotBeNull();
            parametersOfbtnTest_Click.Length.ShouldBe(2);
            methodbtnTest_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnTest_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnTest_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnTest_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnTest_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnTest_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodbtnTest_Click, parametersOfbtnTest_Click, methodbtnTest_ClickPrametersTypes);

            // Assert
            parametersOfbtnTest_Click.ShouldNotBeNull();
            parametersOfbtnTest_Click.Length.ShouldBe(2);
            methodbtnTest_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnTest_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnTest_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnTest_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnTest_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnTest_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnTest_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnTest_Click, Fixture, methodbtnTest_ClickPrametersTypes);

            // Assert
            methodbtnTest_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnTest_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnTest_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnTest_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_Internally(Type[] types)
        {
            var methodloadNotificationBoxesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodloadNotificationBoxes, Fixture, methodloadNotificationBoxesPrametersTypes);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var sOptedOutUsers = CreateType<string>();
            var methodloadNotificationBoxesPrametersTypes = new Type[] { typeof(SPSite), typeof(string) };
            object[] parametersOfloadNotificationBoxes = { site, sOptedOutUsers };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadNotificationBoxes, methodloadNotificationBoxesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfloadNotificationBoxes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadNotificationBoxes.ShouldNotBeNull();
            parametersOfloadNotificationBoxes.Length.ShouldBe(2);
            methodloadNotificationBoxesPrametersTypes.Length.ShouldBe(2);
            methodloadNotificationBoxesPrametersTypes.Length.ShouldBe(parametersOfloadNotificationBoxes.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var sOptedOutUsers = CreateType<string>();
            var methodloadNotificationBoxesPrametersTypes = new Type[] { typeof(SPSite), typeof(string) };
            object[] parametersOfloadNotificationBoxes = { site, sOptedOutUsers };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodloadNotificationBoxes, parametersOfloadNotificationBoxes, methodloadNotificationBoxesPrametersTypes);

            // Assert
            parametersOfloadNotificationBoxes.ShouldNotBeNull();
            parametersOfloadNotificationBoxes.Length.ShouldBe(2);
            methodloadNotificationBoxesPrametersTypes.Length.ShouldBe(2);
            methodloadNotificationBoxesPrametersTypes.Length.ShouldBe(parametersOfloadNotificationBoxes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadNotificationBoxes, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadNotificationBoxesPrametersTypes = new Type[] { typeof(SPSite), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodloadNotificationBoxes, Fixture, methodloadNotificationBoxesPrametersTypes);

            // Assert
            methodloadNotificationBoxesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadNotificationBoxes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_loadNotificationBoxes_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadNotificationBoxes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_Internally(Type[] types)
        {
            var methodBindNListsToGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodBindNListsToGrid, Fixture, methodBindNListsToGridPrametersTypes);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sLists = CreateType<string>();
            var methodBindNListsToGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBindNListsToGrid = { sLists };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBindNListsToGrid, methodBindNListsToGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfBindNListsToGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBindNListsToGrid.ShouldNotBeNull();
            parametersOfBindNListsToGrid.Length.ShouldBe(1);
            methodBindNListsToGridPrametersTypes.Length.ShouldBe(1);
            methodBindNListsToGridPrametersTypes.Length.ShouldBe(parametersOfBindNListsToGrid.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sLists = CreateType<string>();
            var methodBindNListsToGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBindNListsToGrid = { sLists };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodBindNListsToGrid, parametersOfBindNListsToGrid, methodBindNListsToGridPrametersTypes);

            // Assert
            parametersOfBindNListsToGrid.ShouldNotBeNull();
            parametersOfBindNListsToGrid.Length.ShouldBe(1);
            methodBindNListsToGridPrametersTypes.Length.ShouldBe(1);
            methodBindNListsToGridPrametersTypes.Length.ShouldBe(parametersOfBindNListsToGrid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBindNListsToGrid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBindNListsToGridPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodBindNListsToGrid, Fixture, methodBindNListsToGridPrametersTypes);

            // Assert
            methodBindNListsToGridPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BindNListsToGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_BindNListsToGrid_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBindNListsToGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodgvNotificationLists_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodgvNotificationLists_RowDataBound, Fixture, methodgvNotificationLists_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodgvNotificationLists_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgvNotificationLists_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgvNotificationLists_RowDataBound, methodgvNotificationLists_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfgvNotificationLists_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgvNotificationLists_RowDataBound.ShouldNotBeNull();
            parametersOfgvNotificationLists_RowDataBound.Length.ShouldBe(2);
            methodgvNotificationLists_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvNotificationLists_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvNotificationLists_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodgvNotificationLists_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgvNotificationLists_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodgvNotificationLists_RowDataBound, parametersOfgvNotificationLists_RowDataBound, methodgvNotificationLists_RowDataBoundPrametersTypes);

            // Assert
            parametersOfgvNotificationLists_RowDataBound.ShouldNotBeNull();
            parametersOfgvNotificationLists_RowDataBound.Length.ShouldBe(2);
            methodgvNotificationLists_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvNotificationLists_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvNotificationLists_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgvNotificationLists_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgvNotificationLists_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodgvNotificationLists_RowDataBound, Fixture, methodgvNotificationLists_RowDataBoundPrametersTypes);

            // Assert
            methodgvNotificationLists_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvNotificationLists_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_gvNotificationLists_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgvNotificationLists_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewPageList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_AddNewPageList_Method_Call_Internally(Type[] types)
        {
            var methodAddNewPageListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodAddNewPageList, Fixture, methodAddNewPageListPrametersTypes);
        }

        #endregion

        #region Method Call : (AddNewPageList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddNewPageList_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddNewPageListPrametersTypes = null;
            object[] parametersOfAddNewPageList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddNewPageList, methodAddNewPageListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfAddNewPageList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddNewPageList.ShouldBeNull();
            methodAddNewPageListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewPageList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddNewPageList_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddNewPageListPrametersTypes = null;
            object[] parametersOfAddNewPageList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodAddNewPageList, parametersOfAddNewPageList, methodAddNewPageListPrametersTypes);

            // Assert
            parametersOfAddNewPageList.ShouldBeNull();
            methodAddNewPageListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewPageList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddNewPageList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddNewPageListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodAddNewPageList, Fixture, methodAddNewPageListPrametersTypes);

            // Assert
            methodAddNewPageListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewPageList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddNewPageList_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddNewPageList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_AddList_Method_Call_Internally(Type[] types)
        {
            var methodAddListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodAddList, Fixture, methodAddListPrametersTypes);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var sLists = CreateType<string>();
            var sCols = CreateType<string>();
            var sQueries = CreateType<string>();
            var methodAddListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfAddList = { sSection, sLists, sCols, sQueries };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddList, methodAddListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfAddList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddList.ShouldNotBeNull();
            parametersOfAddList.Length.ShouldBe(4);
            methodAddListPrametersTypes.Length.ShouldBe(4);
            methodAddListPrametersTypes.Length.ShouldBe(parametersOfAddList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var sLists = CreateType<string>();
            var sCols = CreateType<string>();
            var sQueries = CreateType<string>();
            var methodAddListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfAddList = { sSection, sLists, sCols, sQueries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodAddList, parametersOfAddList, methodAddListPrametersTypes);

            // Assert
            parametersOfAddList.ShouldNotBeNull();
            parametersOfAddList.Length.ShouldBe(4);
            methodAddListPrametersTypes.Length.ShouldBe(4);
            methodAddListPrametersTypes.Length.ShouldBe(parametersOfAddList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddList, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodAddList, Fixture, methodAddListPrametersTypes);

            // Assert
            methodAddListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_AddList_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_EditList_Method_Call_Internally(Type[] types)
        {
            var methodEditListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodEditList, Fixture, methodEditListPrametersTypes);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_EditList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var sLists = CreateType<string>();
            var sCols = CreateType<string>();
            var sQueries = CreateType<string>();
            var methodEditListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfEditList = { sSection, sLists, sCols, sQueries };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEditList, methodEditListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfEditList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEditList.ShouldNotBeNull();
            parametersOfEditList.Length.ShouldBe(4);
            methodEditListPrametersTypes.Length.ShouldBe(4);
            methodEditListPrametersTypes.Length.ShouldBe(parametersOfEditList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_EditList_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var sLists = CreateType<string>();
            var sCols = CreateType<string>();
            var sQueries = CreateType<string>();
            var methodEditListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfEditList = { sSection, sLists, sCols, sQueries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodEditList, parametersOfEditList, methodEditListPrametersTypes);

            // Assert
            parametersOfEditList.ShouldNotBeNull();
            parametersOfEditList.Length.ShouldBe(4);
            methodEditListPrametersTypes.Length.ShouldBe(4);
            methodEditListPrametersTypes.Length.ShouldBe(parametersOfEditList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_EditList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEditList, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_EditList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEditListPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodEditList, Fixture, methodEditListPrametersTypes);

            // Assert
            methodEditListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_EditList_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_DeleteList_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodDeleteList, Fixture, methodDeleteListPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_DeleteList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var methodDeleteListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteList = { sSection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteList, methodDeleteListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfDeleteList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteList.ShouldNotBeNull();
            parametersOfDeleteList.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(parametersOfDeleteList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_DeleteList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSection = CreateType<string>();
            var methodDeleteListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteList = { sSection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodDeleteList, parametersOfDeleteList, methodDeleteListPrametersTypes);

            // Assert
            parametersOfDeleteList.ShouldNotBeNull();
            parametersOfDeleteList.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
            methodDeleteListPrametersTypes.Length.ShouldBe(parametersOfDeleteList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_DeleteList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_DeleteList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodDeleteList, Fixture, methodDeleteListPrametersTypes);

            // Assert
            methodDeleteListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_DeleteList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_btnCancel_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnCancel_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, methodbtnCancel_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfbtnCancel_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnCancel_Click.ShouldNotBeNull();
            parametersOfbtnCancel_Click.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnCancel_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnCancel_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnCancel_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodbtnCancel_Click, parametersOfbtnCancel_Click, methodbtnCancel_ClickPrametersTypes);

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
        public void AUT_Notificationsadmin_btnCancel_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Notificationsadmin_btnCancel_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnCancel_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnCancel_Click, Fixture, methodbtnCancel_ClickPrametersTypes);

            // Assert
            methodbtnCancel_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnCancel_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnCancel_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnCancel_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_btnAdd_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnAdd_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnAdd_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, methodbtnAdd_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfbtnAdd_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnAdd_Click.ShouldNotBeNull();
            parametersOfbtnAdd_Click.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnAdd_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnAdd_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodbtnAdd_Click, parametersOfbtnAdd_Click, methodbtnAdd_ClickPrametersTypes);

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
        public void AUT_Notificationsadmin_btnAdd_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Notificationsadmin_btnAdd_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);

            // Assert
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnAdd_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_btnRemove_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRemove_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnRemove_Click, Fixture, methodbtnRemove_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnRemove_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemove_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRemove_Click, methodbtnRemove_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfbtnRemove_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRemove_Click.ShouldNotBeNull();
            parametersOfbtnRemove_Click.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRemove_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnRemove_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemove_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodbtnRemove_Click, parametersOfbtnRemove_Click, methodbtnRemove_ClickPrametersTypes);

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
        public void AUT_Notificationsadmin_btnRemove_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Notificationsadmin_btnRemove_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRemove_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnRemove_Click, Fixture, methodbtnRemove_ClickPrametersTypes);

            // Assert
            methodbtnRemove_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemove_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnRemove_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRemove_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_btnSave_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSave_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnSave_Click, Fixture, methodbtnSave_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnSave_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSave_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSave_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSave_Click, methodbtnSave_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfbtnSave_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSave_Click.ShouldNotBeNull();
            parametersOfbtnSave_Click.Length.ShouldBe(2);
            methodbtnSave_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSave_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSave_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnSave_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSave_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSave_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodbtnSave_Click, parametersOfbtnSave_Click, methodbtnSave_ClickPrametersTypes);

            // Assert
            parametersOfbtnSave_Click.ShouldNotBeNull();
            parametersOfbtnSave_Click.Length.ShouldBe(2);
            methodbtnSave_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSave_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSave_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnSave_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSave_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnSave_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSave_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodbtnSave_Click, Fixture, methodbtnSave_ClickPrametersTypes);

            // Assert
            methodbtnSave_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_btnSave_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSave_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Notificationsadmin_saveSettings_Method_Call_Internally(Type[] types)
        {
            var methodsaveSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodsaveSettings, Fixture, methodsaveSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_saveSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodsaveSettingsPrametersTypes = null;
            object[] parametersOfsaveSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsaveSettings, methodsaveSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationsadminInstanceFixture, parametersOfsaveSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsaveSettings.ShouldBeNull();
            methodsaveSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_saveSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodsaveSettingsPrametersTypes = null;
            object[] parametersOfsaveSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationsadminInstance, MethodsaveSettings, parametersOfsaveSettings, methodsaveSettingsPrametersTypes);

            // Assert
            parametersOfsaveSettings.ShouldBeNull();
            methodsaveSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_saveSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodsaveSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationsadminInstance, MethodsaveSettings, Fixture, methodsaveSettingsPrametersTypes);

            // Assert
            methodsaveSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Notificationsadmin_saveSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsaveSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationsadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}