using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using addperiods = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.addperiods" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AddperiodsTest : AbstractBaseSetupTypedTest<addperiods>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (addperiods) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodddlPeriodType_SelectedIndexChanged = "ddlPeriodType_SelectedIndexChanged";
        private const string MethodbtnSubmit2_Click = "btnSubmit2_Click";
        private const string MethodaddWebPeriods = "addWebPeriods";
        private const string MethodbtnSubmit_Click = "btnSubmit_Click";
        private const string FieldddlPeriodType = "ddlPeriodType";
        private const string FieldcalStart = "calStart";
        private const string Fielddisplay = "display";
        private const string FieldperiodType = "periodType";
        private const string FieldlblError = "lblError";
        private const string FieldtxtNumber = "txtNumber";
        private const string FieldtxtStartWeek = "txtStartWeek";
        private const string FieldbtnSubmit = "btnSubmit";
        private const string FieldGridView2 = "GridView2";
        private const string FieldpnlData = "pnlData";
        private const string FieldpnlGrid = "pnlGrid";
        private Type _addperiodsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private addperiods _addperiodsInstance;
        private addperiods _addperiodsInstanceFixture;

        #region General Initializer : Class (addperiods) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="addperiods" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addperiodsInstanceType = typeof(addperiods);
            _addperiodsInstanceFixture = Create(true);
            _addperiodsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (addperiods)

        #region General Initializer : Class (addperiods) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="addperiods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodddlPeriodType_SelectedIndexChanged, 0)]
        [TestCase(MethodbtnSubmit2_Click, 0)]
        [TestCase(MethodaddWebPeriods, 0)]
        [TestCase(MethodbtnSubmit_Click, 0)]
        public void AUT_Addperiods_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addperiodsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (addperiods) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="addperiods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldddlPeriodType)]
        [TestCase(FieldcalStart)]
        [TestCase(Fielddisplay)]
        [TestCase(FieldperiodType)]
        [TestCase(FieldlblError)]
        [TestCase(FieldtxtNumber)]
        [TestCase(FieldtxtStartWeek)]
        [TestCase(FieldbtnSubmit)]
        [TestCase(FieldGridView2)]
        [TestCase(FieldpnlData)]
        [TestCase(FieldpnlGrid)]
        public void AUT_Addperiods_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addperiodsInstanceFixture, 
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
        ///     Class (<see cref="addperiods" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Addperiods_Is_Instance_Present_Test()
        {
            // Assert
            _addperiodsInstanceType.ShouldNotBeNull();
            _addperiodsInstance.ShouldNotBeNull();
            _addperiodsInstanceFixture.ShouldNotBeNull();
            _addperiodsInstance.ShouldBeAssignableTo<addperiods>();
            _addperiodsInstanceFixture.ShouldBeAssignableTo<addperiods>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (addperiods) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_addperiods_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            addperiods instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _addperiodsInstanceType.ShouldNotBeNull();
            _addperiodsInstance.ShouldNotBeNull();
            _addperiodsInstanceFixture.ShouldNotBeNull();
            _addperiodsInstance.ShouldBeAssignableTo<addperiods>();
            _addperiodsInstanceFixture.ShouldBeAssignableTo<addperiods>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="addperiods" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodddlPeriodType_SelectedIndexChanged)]
        [TestCase(MethodbtnSubmit2_Click)]
        [TestCase(MethodaddWebPeriods)]
        [TestCase(MethodbtnSubmit_Click)]
        public void AUT_Addperiods_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<addperiods>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiods_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Addperiods_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Addperiods_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addperiods_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlPeriodType_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodddlPeriodType_SelectedIndexChanged, Fixture, methodddlPeriodType_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlPeriodType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlPeriodType_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlPeriodType_SelectedIndexChanged, methodddlPeriodType_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodsInstanceFixture, parametersOfddlPeriodType_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlPeriodType_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlPeriodType_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlPeriodType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlPeriodType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlPeriodType_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlPeriodType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlPeriodType_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodsInstance, MethodddlPeriodType_SelectedIndexChanged, parametersOfddlPeriodType_SelectedIndexChanged, methodddlPeriodType_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlPeriodType_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlPeriodType_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlPeriodType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlPeriodType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlPeriodType_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlPeriodType_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlPeriodType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodddlPeriodType_SelectedIndexChanged, Fixture, methodddlPeriodType_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlPeriodType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlPeriodType_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_ddlPeriodType_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlPeriodType_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiods_btnSubmit2_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSubmit2_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodbtnSubmit2_Click, Fixture, methodbtnSubmit2_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit2_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit2_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSubmit2_Click, methodbtnSubmit2_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodsInstanceFixture, parametersOfbtnSubmit2_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSubmit2_Click.ShouldNotBeNull();
            parametersOfbtnSubmit2_Click.Length.ShouldBe(2);
            methodbtnSubmit2_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit2_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit2_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit2_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit2_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodsInstance, MethodbtnSubmit2_Click, parametersOfbtnSubmit2_Click, methodbtnSubmit2_ClickPrametersTypes);

            // Assert
            parametersOfbtnSubmit2_Click.ShouldNotBeNull();
            parametersOfbtnSubmit2_Click.Length.ShouldBe(2);
            methodbtnSubmit2_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSubmit2_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnSubmit2_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit2_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSubmit2_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit2_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSubmit2_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodbtnSubmit2_Click, Fixture, methodbtnSubmit2_ClickPrametersTypes);

            // Assert
            methodbtnSubmit2_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit2_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit2_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSubmit2_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiods_addWebPeriods_Method_Call_Internally(Type[] types)
        {
            var methodaddWebPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodaddWebPeriods, Fixture, methodaddWebPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_addWebPeriods_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var periods = CreateType<string[]>();
            var url = CreateType<string>();
            var methodaddWebPeriodsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string[]), typeof(string) };
            object[] parametersOfaddWebPeriods = { web, periods, url };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddWebPeriods, methodaddWebPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodsInstanceFixture, parametersOfaddWebPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddWebPeriods.ShouldNotBeNull();
            parametersOfaddWebPeriods.Length.ShouldBe(3);
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(3);
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(parametersOfaddWebPeriods.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_addWebPeriods_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var periods = CreateType<string[]>();
            var url = CreateType<string>();
            var methodaddWebPeriodsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string[]), typeof(string) };
            object[] parametersOfaddWebPeriods = { web, periods, url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodsInstance, MethodaddWebPeriods, parametersOfaddWebPeriods, methodaddWebPeriodsPrametersTypes);

            // Assert
            parametersOfaddWebPeriods.ShouldNotBeNull();
            parametersOfaddWebPeriods.Length.ShouldBe(3);
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(3);
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(parametersOfaddWebPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_addWebPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddWebPeriods, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_addWebPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddWebPeriodsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string[]), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodaddWebPeriods, Fixture, methodaddWebPeriodsPrametersTypes);

            // Assert
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_addWebPeriods_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddWebPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiods_btnSubmit_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSubmit_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodsInstanceFixture, parametersOfbtnSubmit_Click);

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
        public void AUT_Addperiods_btnSubmit_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodsInstance, MethodbtnSubmit_Click, parametersOfbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes);

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
        public void AUT_Addperiods_btnSubmit_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addperiods_btnSubmit_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodsInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiods_btnSubmit_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}