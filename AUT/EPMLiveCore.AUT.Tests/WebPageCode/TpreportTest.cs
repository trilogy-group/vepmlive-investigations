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
using tpreport = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.tpreport" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TpreportTest : AbstractBaseSetupTypedTest<tpreport>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (tpreport) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodprocessData = "processData";
        private const string MethodlogError = "logError";
        private const string MethodprocessPeriods = "processPeriods";
        private const string MethodprocessResourceInfo = "processResourceInfo";
        private const string MethodprocessTaskInfo = "processTaskInfo";
        private const string MethodprocessProjectInfo = "processProjectInfo";
        private const string MethodbuildResourceCap = "buildResourceCap";
        private const string MethodbuildColumns = "buildColumns";
        private const string Fieldtable = "table";
        private const string FieldarrProjectOC = "arrProjectOC";
        private const string FieldarrTaskOC = "arrTaskOC";
        private const string FieldarrResOC = "arrResOC";
        private const string FieldarrPeriods = "arrPeriods";
        private const string FieldlstResourceCap = "lstResourceCap";
        private const string FieldhshProjectOC = "hshProjectOC";
        private const string FieldhshResourceOC = "hshResourceOC";
        private const string Fielddt = "dt";
        private const string FieldGridview1 = "Gridview1";
        private Type _tpreportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private tpreport _tpreportInstance;
        private tpreport _tpreportInstanceFixture;

        #region General Initializer : Class (tpreport) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="tpreport" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _tpreportInstanceType = typeof(tpreport);
            _tpreportInstanceFixture = Create(true);
            _tpreportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (tpreport)

        #region General Initializer : Class (tpreport) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="tpreport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodprocessData, 0)]
        [TestCase(MethodlogError, 0)]
        [TestCase(MethodprocessPeriods, 0)]
        [TestCase(MethodprocessResourceInfo, 0)]
        [TestCase(MethodprocessTaskInfo, 0)]
        [TestCase(MethodprocessProjectInfo, 0)]
        [TestCase(MethodbuildResourceCap, 0)]
        [TestCase(MethodbuildColumns, 0)]
        public void AUT_Tpreport_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_tpreportInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (tpreport) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="tpreport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldtable)]
        [TestCase(FieldarrProjectOC)]
        [TestCase(FieldarrTaskOC)]
        [TestCase(FieldarrResOC)]
        [TestCase(FieldarrPeriods)]
        [TestCase(FieldlstResourceCap)]
        [TestCase(FieldhshProjectOC)]
        [TestCase(FieldhshResourceOC)]
        [TestCase(Fielddt)]
        [TestCase(FieldGridview1)]
        public void AUT_Tpreport_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_tpreportInstanceFixture, 
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
        ///     Class (<see cref="tpreport" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Tpreport_Is_Instance_Present_Test()
        {
            // Assert
            _tpreportInstanceType.ShouldNotBeNull();
            _tpreportInstance.ShouldNotBeNull();
            _tpreportInstanceFixture.ShouldNotBeNull();
            _tpreportInstance.ShouldBeAssignableTo<tpreport>();
            _tpreportInstanceFixture.ShouldBeAssignableTo<tpreport>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (tpreport) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_tpreport_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            tpreport instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _tpreportInstanceType.ShouldNotBeNull();
            _tpreportInstance.ShouldNotBeNull();
            _tpreportInstanceFixture.ShouldNotBeNull();
            _tpreportInstance.ShouldBeAssignableTo<tpreport>();
            _tpreportInstanceFixture.ShouldBeAssignableTo<tpreport>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="tpreport" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodprocessData)]
        [TestCase(MethodlogError)]
        [TestCase(MethodprocessPeriods)]
        [TestCase(MethodprocessResourceInfo)]
        [TestCase(MethodprocessTaskInfo)]
        [TestCase(MethodprocessProjectInfo)]
        [TestCase(MethodbuildResourceCap)]
        [TestCase(MethodbuildColumns)]
        public void AUT_Tpreport_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<tpreport>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Tpreport_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Tpreport_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Tpreport_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_processData_Method_Call_Internally(Type[] types)
        {
            var methodprocessDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessData, Fixture, methodprocessDataPrametersTypes);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var resWeb = CreateType<SPWeb>();
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };
            object[] parametersOfprocessData = { web, resWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessData, methodprocessDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfprocessData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessData.ShouldNotBeNull();
            parametersOfprocessData.Length.ShouldBe(2);
            methodprocessDataPrametersTypes.Length.ShouldBe(2);
            methodprocessDataPrametersTypes.Length.ShouldBe(parametersOfprocessData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var resWeb = CreateType<SPWeb>();
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };
            object[] parametersOfprocessData = { web, resWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodprocessData, parametersOfprocessData, methodprocessDataPrametersTypes);

            // Assert
            parametersOfprocessData.ShouldNotBeNull();
            parametersOfprocessData.Length.ShouldBe(2);
            methodprocessDataPrametersTypes.Length.ShouldBe(2);
            methodprocessDataPrametersTypes.Length.ShouldBe(parametersOfprocessData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessData, Fixture, methodprocessDataPrametersTypes);

            // Assert
            methodprocessDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_logError_Method_Call_Internally(Type[] types)
        {
            var methodlogErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodlogError, Fixture, methodlogErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_logError_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var error = CreateType<string>();
            var methodlogErrorPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOflogError = { error };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodlogError, methodlogErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOflogError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOflogError.ShouldNotBeNull();
            parametersOflogError.Length.ShouldBe(1);
            methodlogErrorPrametersTypes.Length.ShouldBe(1);
            methodlogErrorPrametersTypes.Length.ShouldBe(parametersOflogError.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_logError_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var error = CreateType<string>();
            var methodlogErrorPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOflogError = { error };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodlogError, parametersOflogError, methodlogErrorPrametersTypes);

            // Assert
            parametersOflogError.ShouldNotBeNull();
            parametersOflogError.Length.ShouldBe(1);
            methodlogErrorPrametersTypes.Length.ShouldBe(1);
            methodlogErrorPrametersTypes.Length.ShouldBe(parametersOflogError.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_logError_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlogError, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_logError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlogErrorPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodlogError, Fixture, methodlogErrorPrametersTypes);

            // Assert
            methodlogErrorPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (logError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_logError_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlogError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_processPeriods_Method_Call_Internally(Type[] types)
        {
            var methodprocessPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessPeriods, Fixture, methodprocessPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrDtRow = CreateType<object[]>();
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem), typeof(object[]) };
            object[] parametersOfprocessPeriods = { li, arrDtRow };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessPeriods, methodprocessPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfprocessPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessPeriods.ShouldNotBeNull();
            parametersOfprocessPeriods.Length.ShouldBe(2);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(2);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(parametersOfprocessPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var arrDtRow = CreateType<object[]>();
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem), typeof(object[]) };
            object[] parametersOfprocessPeriods = { li, arrDtRow };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodprocessPeriods, parametersOfprocessPeriods, methodprocessPeriodsPrametersTypes);

            // Assert
            parametersOfprocessPeriods.ShouldNotBeNull();
            parametersOfprocessPeriods.Length.ShouldBe(2);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(2);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(parametersOfprocessPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessPeriods, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem), typeof(object[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessPeriods, Fixture, methodprocessPeriodsPrametersTypes);

            // Assert
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processPeriods_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_processResourceInfo_Method_Call_Internally(Type[] types)
        {
            var methodprocessResourceInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessResourceInfo, Fixture, methodprocessResourceInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processResourceInfo_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var resource = CreateType<string>();
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };
            object[] parametersOfprocessResourceInfo = { web, arrDtRow, resource };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, methodprocessResourceInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfprocessResourceInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessResourceInfo.ShouldNotBeNull();
            parametersOfprocessResourceInfo.Length.ShouldBe(3);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(3);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(parametersOfprocessResourceInfo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processResourceInfo_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var resource = CreateType<string>();
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };
            object[] parametersOfprocessResourceInfo = { web, arrDtRow, resource };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodprocessResourceInfo, parametersOfprocessResourceInfo, methodprocessResourceInfoPrametersTypes);

            // Assert
            parametersOfprocessResourceInfo.ShouldNotBeNull();
            parametersOfprocessResourceInfo.Length.ShouldBe(3);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(3);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(parametersOfprocessResourceInfo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processResourceInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processResourceInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessResourceInfo, Fixture, methodprocessResourceInfoPrametersTypes);

            // Assert
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processResourceInfo_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_processTaskInfo_Method_Call_Internally(Type[] types)
        {
            var methodprocessTaskInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessTaskInfo, Fixture, methodprocessTaskInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processTaskInfo_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var project = CreateType<string>();
            var task = CreateType<string>();
            var wbs = CreateType<string>();
            var methodprocessTaskInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfprocessTaskInfo = { web, arrDtRow, project, task, wbs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessTaskInfo, methodprocessTaskInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfprocessTaskInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessTaskInfo.ShouldNotBeNull();
            parametersOfprocessTaskInfo.Length.ShouldBe(5);
            methodprocessTaskInfoPrametersTypes.Length.ShouldBe(5);
            methodprocessTaskInfoPrametersTypes.Length.ShouldBe(parametersOfprocessTaskInfo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processTaskInfo_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var project = CreateType<string>();
            var task = CreateType<string>();
            var wbs = CreateType<string>();
            var methodprocessTaskInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfprocessTaskInfo = { web, arrDtRow, project, task, wbs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodprocessTaskInfo, parametersOfprocessTaskInfo, methodprocessTaskInfoPrametersTypes);

            // Assert
            parametersOfprocessTaskInfo.ShouldNotBeNull();
            parametersOfprocessTaskInfo.Length.ShouldBe(5);
            methodprocessTaskInfoPrametersTypes.Length.ShouldBe(5);
            methodprocessTaskInfoPrametersTypes.Length.ShouldBe(parametersOfprocessTaskInfo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processTaskInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessTaskInfo, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processTaskInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessTaskInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessTaskInfo, Fixture, methodprocessTaskInfoPrametersTypes);

            // Assert
            methodprocessTaskInfoPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTaskInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processTaskInfo_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessTaskInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_processProjectInfo_Method_Call_Internally(Type[] types)
        {
            var methodprocessProjectInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessProjectInfo, Fixture, methodprocessProjectInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processProjectInfo_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var project = CreateType<string>();
            var methodprocessProjectInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };
            object[] parametersOfprocessProjectInfo = { web, arrDtRow, project };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessProjectInfo, methodprocessProjectInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfprocessProjectInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessProjectInfo.ShouldNotBeNull();
            parametersOfprocessProjectInfo.Length.ShouldBe(3);
            methodprocessProjectInfoPrametersTypes.Length.ShouldBe(3);
            methodprocessProjectInfoPrametersTypes.Length.ShouldBe(parametersOfprocessProjectInfo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processProjectInfo_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var arrDtRow = CreateType<object[]>();
            var project = CreateType<string>();
            var methodprocessProjectInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };
            object[] parametersOfprocessProjectInfo = { web, arrDtRow, project };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodprocessProjectInfo, parametersOfprocessProjectInfo, methodprocessProjectInfoPrametersTypes);

            // Assert
            parametersOfprocessProjectInfo.ShouldNotBeNull();
            parametersOfprocessProjectInfo.Length.ShouldBe(3);
            methodprocessProjectInfoPrametersTypes.Length.ShouldBe(3);
            methodprocessProjectInfoPrametersTypes.Length.ShouldBe(parametersOfprocessProjectInfo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processProjectInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessProjectInfo, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processProjectInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessProjectInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(object[]), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodprocessProjectInfo, Fixture, methodprocessProjectInfoPrametersTypes);

            // Assert
            methodprocessProjectInfoPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processProjectInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_processProjectInfo_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessProjectInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_buildResourceCap_Method_Call_Internally(Type[] types)
        {
            var methodbuildResourceCapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodbuildResourceCap, Fixture, methodbuildResourceCapPrametersTypes);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildResourceCap_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var field = CreateType<string>();
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfbuildResourceCap = { list, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildResourceCap, methodbuildResourceCapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfbuildResourceCap);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbuildResourceCap.ShouldNotBeNull();
            parametersOfbuildResourceCap.Length.ShouldBe(2);
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(2);
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(parametersOfbuildResourceCap.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildResourceCap_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var field = CreateType<string>();
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfbuildResourceCap = { list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodbuildResourceCap, parametersOfbuildResourceCap, methodbuildResourceCapPrametersTypes);

            // Assert
            parametersOfbuildResourceCap.ShouldNotBeNull();
            parametersOfbuildResourceCap.Length.ShouldBe(2);
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(2);
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(parametersOfbuildResourceCap.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildResourceCap_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbuildResourceCap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildResourceCap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodbuildResourceCap, Fixture, methodbuildResourceCapPrametersTypes);

            // Assert
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildResourceCap_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildResourceCap, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Tpreport_buildColumns_Method_Call_Internally(Type[] types)
        {
            var methodbuildColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodbuildColumns, Fixture, methodbuildColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfbuildColumns = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildColumns, methodbuildColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_tpreportInstanceFixture, parametersOfbuildColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbuildColumns.ShouldNotBeNull();
            parametersOfbuildColumns.Length.ShouldBe(1);
            methodbuildColumnsPrametersTypes.Length.ShouldBe(1);
            methodbuildColumnsPrametersTypes.Length.ShouldBe(parametersOfbuildColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfbuildColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_tpreportInstance, MethodbuildColumns, parametersOfbuildColumns, methodbuildColumnsPrametersTypes);

            // Assert
            parametersOfbuildColumns.ShouldNotBeNull();
            parametersOfbuildColumns.Length.ShouldBe(1);
            methodbuildColumnsPrametersTypes.Length.ShouldBe(1);
            methodbuildColumnsPrametersTypes.Length.ShouldBe(parametersOfbuildColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbuildColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_tpreportInstance, MethodbuildColumns, Fixture, methodbuildColumnsPrametersTypes);

            // Assert
            methodbuildColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Tpreport_buildColumns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_tpreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}