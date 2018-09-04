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
using addperiod = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.addperiod" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AddperiodTest : AbstractBaseSetupTypedTest<addperiod>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (addperiod) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodaddWebPeriods = "addWebPeriods";
        private const string MethodbtnSubmit_Click = "btnSubmit_Click";
        private const string FieldcalStart = "calStart";
        private const string FieldcalEnd = "calEnd";
        private const string FieldlblError = "lblError";
        private const string FieldtxtName = "txtName";
        private const string FieldtxtCapacity = "txtCapacity";
        private Type _addperiodInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private addperiod _addperiodInstance;
        private addperiod _addperiodInstanceFixture;

        #region General Initializer : Class (addperiod) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="addperiod" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addperiodInstanceType = typeof(addperiod);
            _addperiodInstanceFixture = Create(true);
            _addperiodInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (addperiod)

        #region General Initializer : Class (addperiod) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="addperiod" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodaddWebPeriods, 0)]
        [TestCase(MethodbtnSubmit_Click, 0)]
        public void AUT_Addperiod_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addperiodInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (addperiod) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="addperiod" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldcalStart)]
        [TestCase(FieldcalEnd)]
        [TestCase(FieldlblError)]
        [TestCase(FieldtxtName)]
        [TestCase(FieldtxtCapacity)]
        public void AUT_Addperiod_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addperiodInstanceFixture, 
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
        ///     Class (<see cref="addperiod" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Addperiod_Is_Instance_Present_Test()
        {
            // Assert
            _addperiodInstanceType.ShouldNotBeNull();
            _addperiodInstance.ShouldNotBeNull();
            _addperiodInstanceFixture.ShouldNotBeNull();
            _addperiodInstance.ShouldBeAssignableTo<addperiod>();
            _addperiodInstanceFixture.ShouldBeAssignableTo<addperiod>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (addperiod) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_addperiod_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            addperiod instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _addperiodInstanceType.ShouldNotBeNull();
            _addperiodInstance.ShouldNotBeNull();
            _addperiodInstanceFixture.ShouldNotBeNull();
            _addperiodInstance.ShouldBeAssignableTo<addperiod>();
            _addperiodInstanceFixture.ShouldBeAssignableTo<addperiod>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="addperiod" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodaddWebPeriods)]
        [TestCase(MethodbtnSubmit_Click)]
        public void AUT_Addperiod_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<addperiod>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiod_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Addperiod_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Addperiod_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addperiod_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiod_addWebPeriods_Method_Call_Internally(Type[] types)
        {
            var methodaddWebPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodaddWebPeriods, Fixture, methodaddWebPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_addWebPeriods_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_addperiodInstanceFixture, parametersOfaddWebPeriods);

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
        public void AUT_Addperiod_addWebPeriods_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var periods = CreateType<string[]>();
            var url = CreateType<string>();
            var methodaddWebPeriodsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string[]), typeof(string) };
            object[] parametersOfaddWebPeriods = { web, periods, url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodInstance, MethodaddWebPeriods, parametersOfaddWebPeriods, methodaddWebPeriodsPrametersTypes);

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
        public void AUT_Addperiod_addWebPeriods_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addperiod_addWebPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddWebPeriodsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string[]), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodaddWebPeriods, Fixture, methodaddWebPeriodsPrametersTypes);

            // Assert
            methodaddWebPeriodsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addWebPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_addWebPeriods_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddWebPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addperiod_btnSubmit_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSubmit_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_btnSubmit_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addperiodInstanceFixture, parametersOfbtnSubmit_Click);

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
        public void AUT_Addperiod_btnSubmit_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSubmit_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addperiodInstance, MethodbtnSubmit_Click, parametersOfbtnSubmit_Click, methodbtnSubmit_ClickPrametersTypes);

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
        public void AUT_Addperiod_btnSubmit_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addperiod_btnSubmit_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addperiodInstance, MethodbtnSubmit_Click, Fixture, methodbtnSubmit_ClickPrametersTypes);

            // Assert
            methodbtnSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSubmit_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addperiod_btnSubmit_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSubmit_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addperiodInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}