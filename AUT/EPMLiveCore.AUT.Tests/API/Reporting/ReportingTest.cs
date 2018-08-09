using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Reporting" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingTest : AbstractBaseSetupTypedTest<Reporting>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Reporting) Initializer

        private const string MethodProcessIzendaReportsFromList = "ProcessIzendaReportsFromList";
        private const string MethodAddIzendaReport = "AddIzendaReport";
        private const string MethodiAddIzendaReport = "iAddIzendaReport";
        private const string MethodProcessReportDataSources = "ProcessReportDataSources";
        private const string MethodCanProcessFile = "CanProcessFile";
        private const string MethodprocessRDL = "processRDL";
        private Type _reportingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Reporting _reportingInstance;
        private Reporting _reportingInstanceFixture;

        #region General Initializer : Class (Reporting) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Reporting" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingInstanceType = typeof(Reporting);
            _reportingInstanceFixture = Create(true);
            _reportingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Reporting)

        #region General Initializer : Class (Reporting) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Reporting" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessIzendaReportsFromList, 0)]
        [TestCase(MethodAddIzendaReport, 0)]
        [TestCase(MethodiAddIzendaReport, 0)]
        [TestCase(MethodProcessReportDataSources, 0)]
        [TestCase(MethodCanProcessFile, 0)]
        [TestCase(MethodprocessRDL, 0)]
        public void AUT_Reporting_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingInstanceFixture, 
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
        ///     Class (<see cref="Reporting" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Reporting_Is_Instance_Present_Test()
        {
            // Assert
            _reportingInstanceType.ShouldNotBeNull();
            _reportingInstance.ShouldNotBeNull();
            _reportingInstanceFixture.ShouldNotBeNull();
            _reportingInstance.ShouldBeAssignableTo<Reporting>();
            _reportingInstanceFixture.ShouldBeAssignableTo<Reporting>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Reporting) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Reporting_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Reporting instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingInstanceType.ShouldNotBeNull();
            _reportingInstance.ShouldNotBeNull();
            _reportingInstanceFixture.ShouldNotBeNull();
            _reportingInstance.ShouldBeAssignableTo<Reporting>();
            _reportingInstanceFixture.ShouldBeAssignableTo<Reporting>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Reporting" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessIzendaReportsFromList)]
        [TestCase(MethodAddIzendaReport)]
        [TestCase(MethodiAddIzendaReport)]
        [TestCase(MethodProcessReportDataSources)]
        [TestCase(MethodCanProcessFile)]
        [TestCase(MethodprocessRDL)]
        public void AUT_Reporting_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingInstanceFixture,
                                                                              _reportingInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessIzendaReportsFromListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodProcessIzendaReportsFromList, Fixture, methodProcessIzendaReportsFromListPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var sError = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Reporting.ProcessIzendaReportsFromList(list, out sError);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var sError = CreateType<string>();
            var methodProcessIzendaReportsFromListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfProcessIzendaReportsFromList = { list, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingInstanceFixture, _reportingInstanceType, MethodProcessIzendaReportsFromList, parametersOfProcessIzendaReportsFromList, methodProcessIzendaReportsFromListPrametersTypes);

            // Assert
            parametersOfProcessIzendaReportsFromList.ShouldNotBeNull();
            parametersOfProcessIzendaReportsFromList.Length.ShouldBe(2);
            methodProcessIzendaReportsFromListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessIzendaReportsFromList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessIzendaReportsFromListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodProcessIzendaReportsFromList, Fixture, methodProcessIzendaReportsFromListPrametersTypes);

            // Assert
            methodProcessIzendaReportsFromListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessIzendaReportsFromList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessIzendaReportsFromList_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessIzendaReportsFromList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_AddIzendaReport_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddIzendaReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodAddIzendaReport, Fixture, methodAddIzendaReportPrametersTypes);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_AddIzendaReport_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var title = CreateType<string>();
            var xml = CreateType<string>();
            var sError = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Reporting.AddIzendaReport(web, title, xml, out sError);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_AddIzendaReport_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var title = CreateType<string>();
            var xml = CreateType<string>();
            var sError = CreateType<string>();
            var methodAddIzendaReportPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfAddIzendaReport = { web, title, xml, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingInstanceFixture, _reportingInstanceType, MethodAddIzendaReport, parametersOfAddIzendaReport, methodAddIzendaReportPrametersTypes);

            // Assert
            parametersOfAddIzendaReport.ShouldNotBeNull();
            parametersOfAddIzendaReport.Length.ShouldBe(4);
            methodAddIzendaReportPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_AddIzendaReport_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddIzendaReport, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_AddIzendaReport_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddIzendaReportPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodAddIzendaReport, Fixture, methodAddIzendaReportPrametersTypes);

            // Assert
            methodAddIzendaReportPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddIzendaReport) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_AddIzendaReport_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddIzendaReport, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_iAddIzendaReport_Static_Method_Call_Internally(Type[] types)
        {
            var methodiAddIzendaReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodiAddIzendaReport, Fixture, methodiAddIzendaReportPrametersTypes);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_iAddIzendaReport_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var xml = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            var siteid = CreateType<string>();
            var methodiAddIzendaReportPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(string) };
            object[] parametersOfiAddIzendaReport = { title, xml, cn, siteid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiAddIzendaReport, methodiAddIzendaReportPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingInstanceFixture, parametersOfiAddIzendaReport);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiAddIzendaReport.ShouldNotBeNull();
            parametersOfiAddIzendaReport.Length.ShouldBe(4);
            methodiAddIzendaReportPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_iAddIzendaReport_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var xml = CreateType<string>();
            var cn = CreateType<SqlConnection>();
            var siteid = CreateType<string>();
            var methodiAddIzendaReportPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(string) };
            object[] parametersOfiAddIzendaReport = { title, xml, cn, siteid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingInstanceFixture, _reportingInstanceType, MethodiAddIzendaReport, parametersOfiAddIzendaReport, methodiAddIzendaReportPrametersTypes);

            // Assert
            parametersOfiAddIzendaReport.ShouldNotBeNull();
            parametersOfiAddIzendaReport.Length.ShouldBe(4);
            methodiAddIzendaReportPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_iAddIzendaReport_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiAddIzendaReport, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_iAddIzendaReport_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiAddIzendaReportPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodiAddIzendaReport, Fixture, methodiAddIzendaReportPrametersTypes);

            // Assert
            methodiAddIzendaReportPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iAddIzendaReport) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_iAddIzendaReport_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiAddIzendaReport, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessReportDataSourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodProcessReportDataSources, Fixture, methodProcessReportDataSourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var FileList = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Reporting.ProcessReportDataSources(web, FileList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var FileList = CreateType<string>();
            var methodProcessReportDataSourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessReportDataSources = { web, FileList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessReportDataSources, methodProcessReportDataSourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingInstanceFixture, parametersOfProcessReportDataSources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessReportDataSources.ShouldNotBeNull();
            parametersOfProcessReportDataSources.Length.ShouldBe(2);
            methodProcessReportDataSourcesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var FileList = CreateType<string>();
            var methodProcessReportDataSourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessReportDataSources = { web, FileList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingInstanceFixture, _reportingInstanceType, MethodProcessReportDataSources, parametersOfProcessReportDataSources, methodProcessReportDataSourcesPrametersTypes);

            // Assert
            parametersOfProcessReportDataSources.ShouldNotBeNull();
            parametersOfProcessReportDataSources.Length.ShouldBe(2);
            methodProcessReportDataSourcesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessReportDataSources, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessReportDataSourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodProcessReportDataSources, Fixture, methodProcessReportDataSourcesPrametersTypes);

            // Assert
            methodProcessReportDataSourcesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportDataSources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_ProcessReportDataSources_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessReportDataSources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CanProcessFile) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_CanProcessFile_Static_Method_Call_Internally(Type[] types)
        {
            var methodCanProcessFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodCanProcessFile, Fixture, methodCanProcessFilePrametersTypes);
        }

        #endregion

        #region Method Call : (CanProcessFile) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_CanProcessFile_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var docFiles = CreateType<XmlDocument>();
            var methodCanProcessFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(XmlDocument) };
            object[] parametersOfCanProcessFile = { web, li, docFiles };

            // Assert
            parametersOfCanProcessFile.ShouldNotBeNull();
            parametersOfCanProcessFile.Length.ShouldBe(3);
            methodCanProcessFilePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_reportingInstanceFixture, _reportingInstanceType, MethodCanProcessFile, parametersOfCanProcessFile, methodCanProcessFilePrametersTypes));
        }

        #endregion

        #region Method Call : (CanProcessFile) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_CanProcessFile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCanProcessFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(XmlDocument) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodCanProcessFile, Fixture, methodCanProcessFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCanProcessFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CanProcessFile) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_CanProcessFile_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCanProcessFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CanProcessFile) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_CanProcessFile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCanProcessFile, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Reporting_processRDL_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessRDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodprocessRDL, Fixture, methodprocessRDLPrametersTypes);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_processRDL_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var SSRS = CreateType<SSRS2006.ReportingService2006>();
            var web = CreateType<SPWeb>();
            var folder = CreateType<SPListItem>();
            var dsr = CreateType<SSRS2006.DataSourceReference>();
            var list = CreateType<SPDocumentLibrary>();
            var docFiles = CreateType<XmlDocument>();
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary), typeof(XmlDocument) };
            object[] parametersOfprocessRDL = { SSRS, web, folder, dsr, list, docFiles };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessRDL, methodprocessRDLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingInstanceFixture, parametersOfprocessRDL);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessRDL.ShouldNotBeNull();
            parametersOfprocessRDL.Length.ShouldBe(6);
            methodprocessRDLPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_processRDL_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var SSRS = CreateType<SSRS2006.ReportingService2006>();
            var web = CreateType<SPWeb>();
            var folder = CreateType<SPListItem>();
            var dsr = CreateType<SSRS2006.DataSourceReference>();
            var list = CreateType<SPDocumentLibrary>();
            var docFiles = CreateType<XmlDocument>();
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary), typeof(XmlDocument) };
            object[] parametersOfprocessRDL = { SSRS, web, folder, dsr, list, docFiles };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingInstanceFixture, _reportingInstanceType, MethodprocessRDL, parametersOfprocessRDL, methodprocessRDLPrametersTypes);

            // Assert
            parametersOfprocessRDL.ShouldNotBeNull();
            parametersOfprocessRDL.Length.ShouldBe(6);
            methodprocessRDLPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_processRDL_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessRDL, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_processRDL_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessRDLPrametersTypes = new Type[] { typeof(SSRS2006.ReportingService2006), typeof(SPWeb), typeof(SPListItem), typeof(SSRS2006.DataSourceReference), typeof(SPDocumentLibrary), typeof(XmlDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingInstanceFixture, _reportingInstanceType, MethodprocessRDL, Fixture, methodprocessRDLPrametersTypes);

            // Assert
            methodprocessRDLPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processRDL) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Reporting_processRDL_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessRDL, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}