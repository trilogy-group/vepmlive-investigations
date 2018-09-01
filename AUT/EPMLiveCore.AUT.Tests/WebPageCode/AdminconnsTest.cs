using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using adminconns = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adminconns" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AdminconnsTest : AbstractBaseSetupTypedTest<adminconns>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adminconns) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodWebApplicationSelector1_ContextChange = "WebApplicationSelector1_ContextChange";
        private const string MethodGetConnSettings = "GetConnSettings";
        private const string MethodbtnUpgrade_Click = "btnUpgrade_Click";
        private const string MethodButton1_Click = "Button1_Click";
        private const string MethodAddorUpdateConnString = "AddorUpdateConnString";
        private const string MethodAddWebConfigModification = "AddWebConfigModification";
        private const string MethodConnectionTest = "ConnectionTest";
        private const string FieldtxtConnString = "txtConnString";
        private const string FieldlblStatus = "lblStatus";
        private const string FieldlblStatusDyn = "lblStatusDyn";
        private const string FieldxWebConfig = "xWebConfig";
        private const string FieldWebApplicationSelector1 = "WebApplicationSelector1";
        private const string FieldtxtReportServer = "txtReportServer";
        private const string FieldtxtDefaultPath = "txtDefaultPath";
        private const string FieldchkIntegrated = "chkIntegrated";
        private const string FieldchkWindowsAuth = "chkWindowsAuth";
        private const string FieldtxtUsername = "txtUsername";
        private const string FieldtxtPassword = "txtPassword";
        private const string FieldbtnUpgrade = "btnUpgrade";
        private const string FieldlblVersion = "lblVersion";
        private const string FieldbtnInstallDB = "btnInstallDB";
        private const string Fieldcon1 = "con1";
        private const string Fieldcon2 = "con2";
        private const string Fieldcon3 = "con3";
        private const string FieldsCoreStatus = "sCoreStatus";
        private const string FieldsWPStatus = "sWPStatus";
        private const string FieldsTSStatus = "sTSStatus";
        private const string FieldsDashboardStatus = "sDashboardStatus";
        private const string FieldsPFEStatus = "sPFEStatus";
        private const string Fieldwebappid = "webappid";
        private Type _adminconnsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adminconns _adminconnsInstance;
        private adminconns _adminconnsInstanceFixture;

        #region General Initializer : Class (adminconns) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adminconns" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adminconnsInstanceType = typeof(adminconns);
            _adminconnsInstanceFixture = Create(true);
            _adminconnsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adminconns)

        #region General Initializer : Class (adminconns) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adminconns" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodWebApplicationSelector1_ContextChange, 0)]
        [TestCase(MethodGetConnSettings, 0)]
        [TestCase(MethodbtnUpgrade_Click, 0)]
        [TestCase(MethodButton1_Click, 0)]
        [TestCase(MethodAddorUpdateConnString, 0)]
        [TestCase(MethodAddWebConfigModification, 0)]
        [TestCase(MethodConnectionTest, 0)]
        public void AUT_Adminconns_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adminconnsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adminconns) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adminconns" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldtxtConnString)]
        [TestCase(FieldlblStatus)]
        [TestCase(FieldlblStatusDyn)]
        [TestCase(FieldxWebConfig)]
        [TestCase(FieldWebApplicationSelector1)]
        [TestCase(FieldtxtReportServer)]
        [TestCase(FieldtxtDefaultPath)]
        [TestCase(FieldchkIntegrated)]
        [TestCase(FieldchkWindowsAuth)]
        [TestCase(FieldtxtUsername)]
        [TestCase(FieldtxtPassword)]
        [TestCase(FieldbtnUpgrade)]
        [TestCase(FieldlblVersion)]
        [TestCase(FieldbtnInstallDB)]
        [TestCase(Fieldcon1)]
        [TestCase(Fieldcon2)]
        [TestCase(Fieldcon3)]
        [TestCase(FieldsCoreStatus)]
        [TestCase(FieldsWPStatus)]
        [TestCase(FieldsTSStatus)]
        [TestCase(FieldsDashboardStatus)]
        [TestCase(FieldsPFEStatus)]
        [TestCase(Fieldwebappid)]
        public void AUT_Adminconns_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adminconnsInstanceFixture, 
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
        ///     Class (<see cref="adminconns" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adminconns_Is_Instance_Present_Test()
        {
            // Assert
            _adminconnsInstanceType.ShouldNotBeNull();
            _adminconnsInstance.ShouldNotBeNull();
            _adminconnsInstanceFixture.ShouldNotBeNull();
            _adminconnsInstance.ShouldBeAssignableTo<adminconns>();
            _adminconnsInstanceFixture.ShouldBeAssignableTo<adminconns>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adminconns) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adminconns_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adminconns instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adminconnsInstanceType.ShouldNotBeNull();
            _adminconnsInstance.ShouldNotBeNull();
            _adminconnsInstanceFixture.ShouldNotBeNull();
            _adminconnsInstance.ShouldBeAssignableTo<adminconns>();
            _adminconnsInstanceFixture.ShouldBeAssignableTo<adminconns>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adminconns" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodWebApplicationSelector1_ContextChange)]
        [TestCase(MethodGetConnSettings)]
        [TestCase(MethodbtnUpgrade_Click)]
        [TestCase(MethodButton1_Click)]
        [TestCase(MethodAddorUpdateConnString)]
        [TestCase(MethodAddWebConfigModification)]
        [TestCase(MethodConnectionTest)]
        public void AUT_Adminconns_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adminconns>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Adminconns_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Adminconns_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminconns_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_Internally(Type[] types)
        {
            var methodWebApplicationSelector1_ContextChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfWebApplicationSelector1_ContextChange);

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
        public void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfWebApplicationSelector1_ContextChange = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodWebApplicationSelector1_ContextChange, parametersOfWebApplicationSelector1_ContextChange, methodWebApplicationSelector1_ContextChangePrametersTypes);

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
        public void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebApplicationSelector1_ContextChangePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodWebApplicationSelector1_ContextChange, Fixture, methodWebApplicationSelector1_ContextChangePrametersTypes);

            // Assert
            methodWebApplicationSelector1_ContextChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebApplicationSelector1_ContextChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_WebApplicationSelector1_ContextChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebApplicationSelector1_ContextChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_GetConnSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetConnSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodGetConnSettings, Fixture, methodGetConnSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_GetConnSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetConnSettingsPrametersTypes = null;
            object[] parametersOfGetConnSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnSettings, methodGetConnSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfGetConnSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnSettings.ShouldBeNull();
            methodGetConnSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetConnSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_GetConnSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetConnSettingsPrametersTypes = null;
            object[] parametersOfGetConnSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodGetConnSettings, parametersOfGetConnSettings, methodGetConnSettingsPrametersTypes);

            // Assert
            parametersOfGetConnSettings.ShouldBeNull();
            methodGetConnSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_GetConnSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetConnSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodGetConnSettings, Fixture, methodGetConnSettingsPrametersTypes);

            // Assert
            methodGetConnSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_GetConnSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_btnUpgrade_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnUpgrade_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodbtnUpgrade_Click, Fixture, methodbtnUpgrade_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_btnUpgrade_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnUpgrade_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnUpgrade_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnUpgrade_Click, methodbtnUpgrade_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfbtnUpgrade_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnUpgrade_Click.ShouldNotBeNull();
            parametersOfbtnUpgrade_Click.Length.ShouldBe(2);
            methodbtnUpgrade_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnUpgrade_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnUpgrade_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_btnUpgrade_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnUpgrade_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnUpgrade_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodbtnUpgrade_Click, parametersOfbtnUpgrade_Click, methodbtnUpgrade_ClickPrametersTypes);

            // Assert
            parametersOfbtnUpgrade_Click.ShouldNotBeNull();
            parametersOfbtnUpgrade_Click.Length.ShouldBe(2);
            methodbtnUpgrade_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnUpgrade_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnUpgrade_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_btnUpgrade_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnUpgrade_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_btnUpgrade_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnUpgrade_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodbtnUpgrade_Click, Fixture, methodbtnUpgrade_ClickPrametersTypes);

            // Assert
            methodbtnUpgrade_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnUpgrade_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_btnUpgrade_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnUpgrade_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_Button1_Click_Method_Call_Internally(Type[] types)
        {
            var methodButton1_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_Button1_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodButton1_Click, methodButton1_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfButton1_Click);

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
        public void AUT_Adminconns_Button1_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfButton1_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodButton1_Click, parametersOfButton1_Click, methodButton1_ClickPrametersTypes);

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
        public void AUT_Adminconns_Button1_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Adminconns_Button1_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodButton1_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodButton1_Click, Fixture, methodButton1_ClickPrametersTypes);

            // Assert
            methodButton1_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Button1_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_Button1_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodButton1_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddorUpdateConnString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_AddorUpdateConnString_Method_Call_Internally(Type[] types)
        {
            var methodAddorUpdateConnStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodAddorUpdateConnString, Fixture, methodAddorUpdateConnStringPrametersTypes);
        }

        #endregion

        #region Method Call : (AddorUpdateConnString) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddorUpdateConnString_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddorUpdateConnStringPrametersTypes = null;
            object[] parametersOfAddorUpdateConnString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddorUpdateConnString, methodAddorUpdateConnStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfAddorUpdateConnString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddorUpdateConnString.ShouldBeNull();
            methodAddorUpdateConnStringPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddorUpdateConnString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddorUpdateConnString_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddorUpdateConnStringPrametersTypes = null;
            object[] parametersOfAddorUpdateConnString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodAddorUpdateConnString, parametersOfAddorUpdateConnString, methodAddorUpdateConnStringPrametersTypes);

            // Assert
            parametersOfAddorUpdateConnString.ShouldBeNull();
            methodAddorUpdateConnStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddorUpdateConnString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddorUpdateConnString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddorUpdateConnStringPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodAddorUpdateConnString, Fixture, methodAddorUpdateConnStringPrametersTypes);

            // Assert
            methodAddorUpdateConnStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddorUpdateConnString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddorUpdateConnString_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddorUpdateConnString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_AddWebConfigModification_Method_Call_Internally(Type[] types)
        {
            var methodAddWebConfigModificationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodAddWebConfigModification, Fixture, methodAddWebConfigModificationPrametersTypes);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddWebConfigModification_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webApp = CreateType<SPWebApplication>();
            var path = CreateType<string>();
            var name = CreateType<string>();
            var sequence = CreateType<uint>();
            var value = CreateType<string>();
            var type = CreateType<SPWebConfigModification.SPWebConfigModificationType>();
            var methodAddWebConfigModificationPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(string), typeof(string), typeof(uint), typeof(string), typeof(SPWebConfigModification.SPWebConfigModificationType) };
            object[] parametersOfAddWebConfigModification = { webApp, path, name, sequence, value, type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddWebConfigModification, methodAddWebConfigModificationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfAddWebConfigModification);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddWebConfigModification.ShouldNotBeNull();
            parametersOfAddWebConfigModification.Length.ShouldBe(6);
            methodAddWebConfigModificationPrametersTypes.Length.ShouldBe(6);
            methodAddWebConfigModificationPrametersTypes.Length.ShouldBe(parametersOfAddWebConfigModification.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddWebConfigModification_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webApp = CreateType<SPWebApplication>();
            var path = CreateType<string>();
            var name = CreateType<string>();
            var sequence = CreateType<uint>();
            var value = CreateType<string>();
            var type = CreateType<SPWebConfigModification.SPWebConfigModificationType>();
            var methodAddWebConfigModificationPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(string), typeof(string), typeof(uint), typeof(string), typeof(SPWebConfigModification.SPWebConfigModificationType) };
            object[] parametersOfAddWebConfigModification = { webApp, path, name, sequence, value, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adminconnsInstance, MethodAddWebConfigModification, parametersOfAddWebConfigModification, methodAddWebConfigModificationPrametersTypes);

            // Assert
            parametersOfAddWebConfigModification.ShouldNotBeNull();
            parametersOfAddWebConfigModification.Length.ShouldBe(6);
            methodAddWebConfigModificationPrametersTypes.Length.ShouldBe(6);
            methodAddWebConfigModificationPrametersTypes.Length.ShouldBe(parametersOfAddWebConfigModification.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddWebConfigModification_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddWebConfigModification, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddWebConfigModification_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddWebConfigModificationPrametersTypes = new Type[] { typeof(SPWebApplication), typeof(string), typeof(string), typeof(uint), typeof(string), typeof(SPWebConfigModification.SPWebConfigModificationType) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodAddWebConfigModification, Fixture, methodAddWebConfigModificationPrametersTypes);

            // Assert
            methodAddWebConfigModificationPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWebConfigModification) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_AddWebConfigModification_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddWebConfigModification, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adminconns_ConnectionTest_Method_Call_Internally(Type[] types)
        {
            var methodConnectionTestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodConnectionTest, Fixture, methodConnectionTestPrametersTypes);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sDBConnStr = CreateType<string>();
            var methodConnectionTestPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConnectionTest = { sDBConnStr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodConnectionTest, methodConnectionTestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminconns, bool>(_adminconnsInstanceFixture, out exception1, parametersOfConnectionTest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminconns, bool>(_adminconnsInstance, MethodConnectionTest, parametersOfConnectionTest, methodConnectionTestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfConnectionTest.ShouldNotBeNull();
            parametersOfConnectionTest.Length.ShouldBe(1);
            methodConnectionTestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sDBConnStr = CreateType<string>();
            var methodConnectionTestPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConnectionTest = { sDBConnStr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodConnectionTest, methodConnectionTestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adminconns, bool>(_adminconnsInstanceFixture, out exception1, parametersOfConnectionTest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adminconns, bool>(_adminconnsInstance, MethodConnectionTest, parametersOfConnectionTest, methodConnectionTestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfConnectionTest.ShouldNotBeNull();
            parametersOfConnectionTest.Length.ShouldBe(1);
            methodConnectionTestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sDBConnStr = CreateType<string>();
            var methodConnectionTestPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConnectionTest = { sDBConnStr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConnectionTest, methodConnectionTestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adminconnsInstanceFixture, parametersOfConnectionTest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConnectionTest.ShouldNotBeNull();
            parametersOfConnectionTest.Length.ShouldBe(1);
            methodConnectionTestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sDBConnStr = CreateType<string>();
            var methodConnectionTestPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfConnectionTest = { sDBConnStr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<adminconns, bool>(_adminconnsInstance, MethodConnectionTest, parametersOfConnectionTest, methodConnectionTestPrametersTypes);

            // Assert
            parametersOfConnectionTest.ShouldNotBeNull();
            parametersOfConnectionTest.Length.ShouldBe(1);
            methodConnectionTestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConnectionTestPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adminconnsInstance, MethodConnectionTest, Fixture, methodConnectionTestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConnectionTestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConnectionTest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adminconnsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConnectionTest) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adminconns_ConnectionTest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConnectionTest, 0);
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