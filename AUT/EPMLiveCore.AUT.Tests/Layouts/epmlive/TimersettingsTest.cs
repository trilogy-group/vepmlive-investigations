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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.timersettings" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TimersettingsTest : AbstractBaseSetupTypedTest<timersettings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (timersettings) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodloadData = "loadData";
        private const string MethodbtnRunNow_Click = "btnRunNow_Click";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodsaveSettings = "saveSettings";
        private const string FieldstrTitle = "strTitle";
        private const string FieldstrTemplate = "strTemplate";
        private const string Fielddesc = "desc";
        private const string FieldpnlAdmin = "pnlAdmin";
        private const string FieldlstNotificationUsers = "lstNotificationUsers";
        private const string FieldlstSiteUsers = "lstSiteUsers";
        private const string FieldchkTask = "chkTask";
        private const string FieldchkAdmin = "chkAdmin";
        private const string FieldLists = "Lists";
        private const string FieldFixTimes = "FixTimes";
        private const string FieldpnlSaveResults = "pnlSaveResults";
        private const string FieldlblPropertyEPMLiveFixLists = "lblPropertyEPMLiveFixLists";
        private const string FieldtxtPropertyEPMLiveFixListsValue = "txtPropertyEPMLiveFixListsValue";
        private const string FieldlblPropertyEPMLiveFixTime = "lblPropertyEPMLiveFixTime";
        private const string FieldlblPropertyEPMLiveFixTimeValue = "lblPropertyEPMLiveFixTimeValue";
        private const string FieldpnlTL = "pnlTL";
        private const string FieldpnlMain = "pnlMain";
        private const string FieldhlAdmin = "hlAdmin";
        private const string FieldlblLastRun = "lblLastRun";
        private const string FieldlblLastResRun = "lblLastResRun";
        private const string FieldlblLastResResult = "lblLastResResult";
        private const string FieldlblNotEnabled = "lblNotEnabled";
        private const string FieldtxtResPlannerLists = "txtResPlannerLists";
        private const string FieldlblMessages = "lblMessages";
        private const string FieldlblResLog = "lblResLog";
        private const string FieldbtnRunNow = "btnRunNow";
        private const string Fielddisabled = "disabled";
        private const string FieldsiteUrl = "siteUrl";
        private const string Fieldsiteid = "siteid";
        private const string Fieldcn = "cn";
        private Type _timersettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private timersettings _timersettingsInstance;
        private timersettings _timersettingsInstanceFixture;

        #region General Initializer : Class (timersettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="timersettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timersettingsInstanceType = typeof(timersettings);
            _timersettingsInstanceFixture = Create(true);
            _timersettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (timersettings)

        #region General Initializer : Class (timersettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="timersettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodloadData, 0)]
        [TestCase(MethodbtnRunNow_Click, 0)]
        [TestCase(MethodButton1_Click, 0)]
        [TestCase(MethodsaveSettings, 0)]
        public void AUT_Timersettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timersettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (timersettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="timersettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldstrTitle)]
        [TestCase(FieldstrTemplate)]
        [TestCase(Fielddesc)]
        [TestCase(FieldpnlAdmin)]
        [TestCase(FieldlstNotificationUsers)]
        [TestCase(FieldlstSiteUsers)]
        [TestCase(FieldchkTask)]
        [TestCase(FieldchkAdmin)]
        [TestCase(FieldLists)]
        [TestCase(FieldFixTimes)]
        [TestCase(FieldpnlSaveResults)]
        [TestCase(FieldlblPropertyEPMLiveFixLists)]
        [TestCase(FieldtxtPropertyEPMLiveFixListsValue)]
        [TestCase(FieldlblPropertyEPMLiveFixTime)]
        [TestCase(FieldlblPropertyEPMLiveFixTimeValue)]
        [TestCase(FieldpnlTL)]
        [TestCase(FieldpnlMain)]
        [TestCase(FieldhlAdmin)]
        [TestCase(FieldlblLastRun)]
        [TestCase(FieldlblLastResRun)]
        [TestCase(FieldlblLastResResult)]
        [TestCase(FieldlblNotEnabled)]
        [TestCase(FieldtxtResPlannerLists)]
        [TestCase(FieldlblMessages)]
        [TestCase(FieldlblResLog)]
        [TestCase(FieldbtnRunNow)]
        [TestCase(Fielddisabled)]
        [TestCase(FieldsiteUrl)]
        [TestCase(Fieldsiteid)]
        [TestCase(Fieldcn)]
        public void AUT_Timersettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timersettingsInstanceFixture, 
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
        ///     Class (<see cref="timersettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Timersettings_Is_Instance_Present_Test()
        {
            // Assert
            _timersettingsInstanceType.ShouldNotBeNull();
            _timersettingsInstance.ShouldNotBeNull();
            _timersettingsInstanceFixture.ShouldNotBeNull();
            _timersettingsInstance.ShouldBeAssignableTo<timersettings>();
            _timersettingsInstanceFixture.ShouldBeAssignableTo<timersettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (timersettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_timersettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            timersettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timersettingsInstanceType.ShouldNotBeNull();
            _timersettingsInstance.ShouldNotBeNull();
            _timersettingsInstanceFixture.ShouldNotBeNull();
            _timersettingsInstance.ShouldBeAssignableTo<timersettings>();
            _timersettingsInstanceFixture.ShouldBeAssignableTo<timersettings>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="timersettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodloadData)]
        [TestCase(MethodbtnRunNow_Click)]
        [TestCase(MethodButton1_Click)]
        [TestCase(MethodsaveSettings)]
        public void AUT_Timersettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<timersettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timersettings_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timersettingsInstanceFixture, parametersOfPage_Load);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timersettingsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timersettings_loadData_Method_Call_Internally(Type[] types)
        {
            var methodloadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodloadData, Fixture, methodloadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_loadData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadData = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadData, methodloadDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timersettingsInstanceFixture, parametersOfloadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadData.ShouldNotBeNull();
            parametersOfloadData.Length.ShouldBe(1);
            methodloadDataPrametersTypes.Length.ShouldBe(1);
            methodloadDataPrametersTypes.Length.ShouldBe(parametersOfloadData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_loadData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadDataPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadData = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timersettingsInstance, MethodloadData, parametersOfloadData, methodloadDataPrametersTypes);

            // Assert
            parametersOfloadData.ShouldNotBeNull();
            parametersOfloadData.Length.ShouldBe(1);
            methodloadDataPrametersTypes.Length.ShouldBe(1);
            methodloadDataPrametersTypes.Length.ShouldBe(parametersOfloadData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_loadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_loadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadDataPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodloadData, Fixture, methodloadDataPrametersTypes);

            // Assert
            methodloadDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_loadData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timersettings_btnRunNow_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRunNow_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodbtnRunNow_Click, Fixture, methodbtnRunNow_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_btnRunNow_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRunNow_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRunNow_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRunNow_Click, methodbtnRunNow_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timersettingsInstanceFixture, parametersOfbtnRunNow_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRunNow_Click.ShouldNotBeNull();
            parametersOfbtnRunNow_Click.Length.ShouldBe(2);
            methodbtnRunNow_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRunNow_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRunNow_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_btnRunNow_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRunNow_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRunNow_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timersettingsInstance, MethodbtnRunNow_Click, parametersOfbtnRunNow_Click, methodbtnRunNow_ClickPrametersTypes);

            // Assert
            parametersOfbtnRunNow_Click.ShouldNotBeNull();
            parametersOfbtnRunNow_Click.Length.ShouldBe(2);
            methodbtnRunNow_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRunNow_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRunNow_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_btnRunNow_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRunNow_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_btnRunNow_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRunNow_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodbtnRunNow_Click, Fixture, methodbtnRunNow_ClickPrametersTypes);

            // Assert
            methodbtnRunNow_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunNow_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_btnRunNow_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRunNow_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timersettings_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timersettingsInstanceFixture, parametersOfButton1_Click);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timersettingsInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timersettings_saveSettings_Method_Call_Internally(Type[] types)
        {
            var methodsaveSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodsaveSettings, Fixture, methodsaveSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_saveSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currWeb = CreateType<SPWeb>();
            var methodsaveSettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfsaveSettings = { currWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsaveSettings, methodsaveSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timersettingsInstanceFixture, parametersOfsaveSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsaveSettings.ShouldNotBeNull();
            parametersOfsaveSettings.Length.ShouldBe(1);
            methodsaveSettingsPrametersTypes.Length.ShouldBe(1);
            methodsaveSettingsPrametersTypes.Length.ShouldBe(parametersOfsaveSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_saveSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currWeb = CreateType<SPWeb>();
            var methodsaveSettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfsaveSettings = { currWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timersettingsInstance, MethodsaveSettings, parametersOfsaveSettings, methodsaveSettingsPrametersTypes);

            // Assert
            parametersOfsaveSettings.ShouldNotBeNull();
            parametersOfsaveSettings.Length.ShouldBe(1);
            methodsaveSettingsPrametersTypes.Length.ShouldBe(1);
            methodsaveSettingsPrametersTypes.Length.ShouldBe(parametersOfsaveSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_saveSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsaveSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_saveSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsaveSettingsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timersettingsInstance, MethodsaveSettings, Fixture, methodsaveSettingsPrametersTypes);

            // Assert
            methodsaveSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (saveSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Timersettings_saveSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsaveSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timersettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}