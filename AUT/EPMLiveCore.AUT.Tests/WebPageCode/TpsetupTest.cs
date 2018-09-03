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
using tpsetup = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.tpsetup" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class TpsetupTest : AbstractBaseSetupTypedTest<tpsetup>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (tpsetup) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodloadPeriods = "loadPeriods";
        private const string MethodloadOutlineCodes = "loadOutlineCodes";
        private const string MethodloadValueTypes = "loadValueTypes";
        private const string MethodlnkButton_Click = "lnkButton_Click";
        private const string MethodbtnAdd_Click = "btnAdd_Click";
        private const string MethodbtnDelete_Click = "btnDelete_Click";
        private const string MethodGridView1_RowCommand = "GridView1_RowCommand";
        private const string MethodGridView2_RowCommand = "GridView2_RowCommand";
        private const string MethoddeleteWebPeriod = "deleteWebPeriod";
        private const string MethodGridView1_RowDataBound = "GridView1_RowDataBound";
        private const string MethodGridView2_RowDataBound = "GridView2_RowDataBound";
        private const string FieldpnlFeature = "pnlFeature";
        private const string FieldlnkButton = "lnkButton";
        private const string FieldpnlMain = "pnlMain";
        private const string FieldlstUsed = "lstUsed";
        private const string FieldlstAvailable = "lstAvailable";
        private const string FieldbtnAdd = "btnAdd";
        private const string FieldbtnDelete = "btnDelete";
        private const string FieldGridView1 = "GridView1";
        private const string FieldGridView2 = "GridView2";
        private const string FieldpnlAdmin = "pnlAdmin";
        private const string FieldhlAdmin = "hlAdmin";
        private Type _tpsetupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private tpsetup _tpsetupInstance;
        private tpsetup _tpsetupInstanceFixture;

        #region General Initializer : Class (tpsetup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="tpsetup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tpsetupInstanceType = typeof(tpsetup);
            _tpsetupInstanceFixture = Create(true);
            _tpsetupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (tpsetup)

        #region General Initializer : Class (tpsetup) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="tpsetup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodloadPeriods, 0)]
        [TestCase(MethodloadOutlineCodes, 0)]
        [TestCase(MethodloadValueTypes, 0)]
        [TestCase(MethodlnkButton_Click, 0)]
        [TestCase(MethodbtnAdd_Click, 0)]
        [TestCase(MethodbtnDelete_Click, 0)]
        [TestCase(MethodGridView1_RowCommand, 0)]
        [TestCase(MethodGridView2_RowCommand, 0)]
        [TestCase(MethoddeleteWebPeriod, 0)]
        [TestCase(MethodGridView1_RowDataBound, 0)]
        [TestCase(MethodGridView2_RowDataBound, 0)]
        public void AUT_Tpsetup_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tpsetupInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (tpsetup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="tpsetup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpnlFeature)]
        [TestCase(FieldlnkButton)]
        [TestCase(FieldpnlMain)]
        [TestCase(FieldlstUsed)]
        [TestCase(FieldlstAvailable)]
        [TestCase(FieldbtnAdd)]
        [TestCase(FieldbtnDelete)]
        [TestCase(FieldGridView1)]
        [TestCase(FieldGridView2)]
        [TestCase(FieldpnlAdmin)]
        [TestCase(FieldhlAdmin)]
        public void AUT_Tpsetup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_tpsetupInstanceFixture, 
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
        ///     Class (<see cref="tpsetup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Tpsetup_Is_Instance_Present_Test()
        {
            // Assert
            _tpsetupInstanceType.ShouldNotBeNull();
            _tpsetupInstance.ShouldNotBeNull();
            _tpsetupInstanceFixture.ShouldNotBeNull();
            _tpsetupInstance.ShouldBeAssignableTo<tpsetup>();
            _tpsetupInstanceFixture.ShouldBeAssignableTo<tpsetup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (tpsetup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_tpsetup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            tpsetup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _tpsetupInstanceType.ShouldNotBeNull();
            _tpsetupInstance.ShouldNotBeNull();
            _tpsetupInstanceFixture.ShouldNotBeNull();
            _tpsetupInstance.ShouldBeAssignableTo<tpsetup>();
            _tpsetupInstanceFixture.ShouldBeAssignableTo<tpsetup>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="tpsetup" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodloadPeriods)]
        [TestCase(MethodloadOutlineCodes)]
        [TestCase(MethodloadValueTypes)]
        [TestCase(MethodlnkButton_Click)]
        [TestCase(MethodbtnAdd_Click)]
        [TestCase(MethodbtnDelete_Click)]
        [TestCase(MethodGridView1_RowCommand)]
        [TestCase(MethodGridView2_RowCommand)]
        [TestCase(MethoddeleteWebPeriod)]
        [TestCase(MethodGridView1_RowDataBound)]
        [TestCase(MethodGridView2_RowDataBound)]
        public void AUT_Tpsetup_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<tpsetup>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Tpsetup_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Tpsetup_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tpsetup_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_loadPeriods_Method_Call_Internally(Type[] types)
        {
            var methodloadPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadPeriods, Fixture, methodloadPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadPeriods_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadPeriodsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadPeriods = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadPeriods, methodloadPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfloadPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadPeriods.ShouldNotBeNull();
            parametersOfloadPeriods.Length.ShouldBe(1);
            methodloadPeriodsPrametersTypes.Length.ShouldBe(1);
            methodloadPeriodsPrametersTypes.Length.ShouldBe(parametersOfloadPeriods.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadPeriods_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadPeriodsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadPeriods = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodloadPeriods, parametersOfloadPeriods, methodloadPeriodsPrametersTypes);

            // Assert
            parametersOfloadPeriods.ShouldNotBeNull();
            parametersOfloadPeriods.Length.ShouldBe(1);
            methodloadPeriodsPrametersTypes.Length.ShouldBe(1);
            methodloadPeriodsPrametersTypes.Length.ShouldBe(parametersOfloadPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadPeriods, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadPeriodsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadPeriods, Fixture, methodloadPeriodsPrametersTypes);

            // Assert
            methodloadPeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadPeriods_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_loadOutlineCodes_Method_Call_Internally(Type[] types)
        {
            var methodloadOutlineCodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadOutlineCodes, Fixture, methodloadOutlineCodesPrametersTypes);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadOutlineCodes_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadOutlineCodesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadOutlineCodes = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadOutlineCodes, methodloadOutlineCodesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfloadOutlineCodes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadOutlineCodes.ShouldNotBeNull();
            parametersOfloadOutlineCodes.Length.ShouldBe(1);
            methodloadOutlineCodesPrametersTypes.Length.ShouldBe(1);
            methodloadOutlineCodesPrametersTypes.Length.ShouldBe(parametersOfloadOutlineCodes.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadOutlineCodes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadOutlineCodesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadOutlineCodes = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodloadOutlineCodes, parametersOfloadOutlineCodes, methodloadOutlineCodesPrametersTypes);

            // Assert
            parametersOfloadOutlineCodes.ShouldNotBeNull();
            parametersOfloadOutlineCodes.Length.ShouldBe(1);
            methodloadOutlineCodesPrametersTypes.Length.ShouldBe(1);
            methodloadOutlineCodesPrametersTypes.Length.ShouldBe(parametersOfloadOutlineCodes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadOutlineCodes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadOutlineCodes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadOutlineCodes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadOutlineCodesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadOutlineCodes, Fixture, methodloadOutlineCodesPrametersTypes);

            // Assert
            methodloadOutlineCodesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadOutlineCodes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadOutlineCodes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadOutlineCodes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_loadValueTypes_Method_Call_Internally(Type[] types)
        {
            var methodloadValueTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadValueTypes, Fixture, methodloadValueTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadValueTypes_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadValueTypes = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadValueTypes, methodloadValueTypesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfloadValueTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadValueTypes.ShouldNotBeNull();
            parametersOfloadValueTypes.Length.ShouldBe(1);
            methodloadValueTypesPrametersTypes.Length.ShouldBe(1);
            methodloadValueTypesPrametersTypes.Length.ShouldBe(parametersOfloadValueTypes.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadValueTypes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodloadValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfloadValueTypes = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodloadValueTypes, parametersOfloadValueTypes, methodloadValueTypesPrametersTypes);

            // Assert
            parametersOfloadValueTypes.ShouldNotBeNull();
            parametersOfloadValueTypes.Length.ShouldBe(1);
            methodloadValueTypesPrametersTypes.Length.ShouldBe(1);
            methodloadValueTypesPrametersTypes.Length.ShouldBe(parametersOfloadValueTypes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadValueTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadValueTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadValueTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadValueTypesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodloadValueTypes, Fixture, methodloadValueTypesPrametersTypes);

            // Assert
            methodloadValueTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadValueTypes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_loadValueTypes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadValueTypes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_lnkButton_Click_Method_Call_Internally(Type[] types)
        {
            var methodlnkButton_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodlnkButton_Click, Fixture, methodlnkButton_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_lnkButton_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkButton_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlnkButton_Click, methodlnkButton_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOflnkButton_Click);

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
        public void AUT_Tpsetup_lnkButton_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOflnkButton_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodlnkButton_Click, parametersOflnkButton_Click, methodlnkButton_ClickPrametersTypes);

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
        public void AUT_Tpsetup_lnkButton_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tpsetup_lnkButton_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlnkButton_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodlnkButton_Click, Fixture, methodlnkButton_ClickPrametersTypes);

            // Assert
            methodlnkButton_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (lnkButton_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_lnkButton_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlnkButton_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_btnAdd_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnAdd_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnAdd_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, methodbtnAdd_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfbtnAdd_Click);

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
        public void AUT_Tpsetup_btnAdd_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAdd_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodbtnAdd_Click, parametersOfbtnAdd_Click, methodbtnAdd_ClickPrametersTypes);

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
        public void AUT_Tpsetup_btnAdd_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tpsetup_btnAdd_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnAdd_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodbtnAdd_Click, Fixture, methodbtnAdd_ClickPrametersTypes);

            // Assert
            methodbtnAdd_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAdd_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnAdd_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnAdd_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_btnDelete_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnDelete_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodbtnDelete_Click, Fixture, methodbtnDelete_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnDelete_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnDelete_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, methodbtnDelete_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfbtnDelete_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnDelete_Click.ShouldNotBeNull();
            parametersOfbtnDelete_Click.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnDelete_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnDelete_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnDelete_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodbtnDelete_Click, parametersOfbtnDelete_Click, methodbtnDelete_ClickPrametersTypes);

            // Assert
            parametersOfbtnDelete_Click.ShouldNotBeNull();
            parametersOfbtnDelete_Click.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnDelete_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnDelete_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnDelete_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnDelete_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodbtnDelete_Click, Fixture, methodbtnDelete_ClickPrametersTypes);

            // Assert
            methodbtnDelete_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnDelete_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_btnDelete_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnDelete_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_GridView1_RowCommand_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfGridView1_RowCommand);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowCommand.ShouldNotBeNull();
            parametersOfGridView1_RowCommand.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView1_RowCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodGridView1_RowCommand, parametersOfGridView1_RowCommand, methodGridView1_RowCommandPrametersTypes);

            // Assert
            parametersOfGridView1_RowCommand.ShouldNotBeNull();
            parametersOfGridView1_RowCommand.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView1_RowCommand, Fixture, methodGridView1_RowCommandPrametersTypes);

            // Assert
            methodGridView1_RowCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_GridView2_RowCommand_Method_Call_Internally(Type[] types)
        {
            var methodGridView2_RowCommandPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView2_RowCommand, Fixture, methodGridView2_RowCommandPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView2_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView2_RowCommand = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView2_RowCommand, methodGridView2_RowCommandPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfGridView2_RowCommand);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView2_RowCommand.ShouldNotBeNull();
            parametersOfGridView2_RowCommand.Length.ShouldBe(2);
            methodGridView2_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowCommand_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewCommandEventArgs>();
            var methodGridView2_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };
            object[] parametersOfGridView2_RowCommand = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodGridView2_RowCommand, parametersOfGridView2_RowCommand, methodGridView2_RowCommandPrametersTypes);

            // Assert
            parametersOfGridView2_RowCommand.ShouldNotBeNull();
            parametersOfGridView2_RowCommand.Length.ShouldBe(2);
            methodGridView2_RowCommandPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowCommandPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowCommand.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowCommand_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView2_RowCommand, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowCommand_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView2_RowCommandPrametersTypes = new Type[] { typeof(object), typeof(GridViewCommandEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView2_RowCommand, Fixture, methodGridView2_RowCommandPrametersTypes);

            // Assert
            methodGridView2_RowCommandPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowCommand) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowCommand_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView2_RowCommand, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_deleteWebPeriod_Method_Call_Internally(Type[] types)
        {
            var methoddeleteWebPeriodPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethoddeleteWebPeriod, Fixture, methoddeleteWebPeriodPrametersTypes);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_deleteWebPeriod_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var period = CreateType<string>();
            var url = CreateType<string>();
            var methoddeleteWebPeriodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfdeleteWebPeriod = { web, period, url };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddeleteWebPeriod, methoddeleteWebPeriodPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfdeleteWebPeriod);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdeleteWebPeriod.ShouldNotBeNull();
            parametersOfdeleteWebPeriod.Length.ShouldBe(3);
            methoddeleteWebPeriodPrametersTypes.Length.ShouldBe(3);
            methoddeleteWebPeriodPrametersTypes.Length.ShouldBe(parametersOfdeleteWebPeriod.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_deleteWebPeriod_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var period = CreateType<string>();
            var url = CreateType<string>();
            var methoddeleteWebPeriodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfdeleteWebPeriod = { web, period, url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethoddeleteWebPeriod, parametersOfdeleteWebPeriod, methoddeleteWebPeriodPrametersTypes);

            // Assert
            parametersOfdeleteWebPeriod.ShouldNotBeNull();
            parametersOfdeleteWebPeriod.Length.ShouldBe(3);
            methoddeleteWebPeriodPrametersTypes.Length.ShouldBe(3);
            methoddeleteWebPeriodPrametersTypes.Length.ShouldBe(parametersOfdeleteWebPeriod.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_deleteWebPeriod_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddeleteWebPeriod, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_deleteWebPeriod_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddeleteWebPeriodPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethoddeleteWebPeriod, Fixture, methoddeleteWebPeriodPrametersTypes);

            // Assert
            methoddeleteWebPeriodPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteWebPeriod) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_deleteWebPeriod_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddeleteWebPeriod, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView1_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfGridView1_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView1_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodGridView1_RowDataBound, parametersOfGridView1_RowDataBound, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView1_RowDataBound.ShouldNotBeNull();
            parametersOfGridView1_RowDataBound.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView1_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView1_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView1_RowDataBound, Fixture, methodGridView1_RowDataBoundPrametersTypes);

            // Assert
            methodGridView1_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView1_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView1_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView1_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGridView2_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView2_RowDataBound, Fixture, methodGridView2_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView2_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, methodGridView2_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpsetupInstanceFixture, parametersOfGridView2_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGridView2_RowDataBound.ShouldNotBeNull();
            parametersOfGridView2_RowDataBound.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGridView2_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpsetupInstance, MethodGridView2_RowDataBound, parametersOfGridView2_RowDataBound, methodGridView2_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGridView2_RowDataBound.ShouldNotBeNull();
            parametersOfGridView2_RowDataBound.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGridView2_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGridView2_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpsetupInstance, MethodGridView2_RowDataBound, Fixture, methodGridView2_RowDataBoundPrametersTypes);

            // Assert
            methodGridView2_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GridView2_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpsetup_GridView2_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGridView2_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpsetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}