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
using capreport = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.capreport" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CapreportTest : AbstractBaseSetupTypedTest<capreport>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (capreport) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodbuildGrid = "buildGrid";
        private const string MethodprocessData = "processData";
        private const string MethodprocessPeriods = "processPeriods";
        private const string MethodprocessResourceInfo = "processResourceInfo";
        private const string MethodbuildResourceCap = "buildResourceCap";
        private const string MethodbuildColumns = "buildColumns";
        private const string Fieldtable = "table";
        private const string FieldarrResOC = "arrResOC";
        private const string FieldlstPeriods = "lstPeriods";
        private const string FieldlstResourceCap = "lstResourceCap";
        private const string FieldhshResourceWork = "hshResourceWork";
        private const string FieldhshResourceOCWork = "hshResourceOCWork";
        private const string FieldhshResourceOC = "hshResourceOC";
        private const string Fielddt = "dt";
        private const string FieldGridview1 = "Gridview1";
        private Type _capreportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private capreport _capreportInstance;
        private capreport _capreportInstanceFixture;

        #region General Initializer : Class (capreport) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="capreport" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _capreportInstanceType = typeof(capreport);
            _capreportInstanceFixture = Create(true);
            _capreportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (capreport)

        #region General Initializer : Class (capreport) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="capreport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodbuildGrid, 0)]
        [TestCase(MethodprocessData, 0)]
        [TestCase(MethodprocessPeriods, 0)]
        [TestCase(MethodprocessResourceInfo, 0)]
        [TestCase(MethodbuildResourceCap, 0)]
        [TestCase(MethodbuildColumns, 0)]
        public void AUT_Capreport_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_capreportInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (capreport) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="capreport" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldtable)]
        [TestCase(FieldarrResOC)]
        [TestCase(FieldlstPeriods)]
        [TestCase(FieldlstResourceCap)]
        [TestCase(FieldhshResourceWork)]
        [TestCase(FieldhshResourceOCWork)]
        [TestCase(FieldhshResourceOC)]
        [TestCase(Fielddt)]
        [TestCase(FieldGridview1)]
        public void AUT_Capreport_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_capreportInstanceFixture, 
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
        ///     Class (<see cref="capreport" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Capreport_Is_Instance_Present_Test()
        {
            // Assert
            _capreportInstanceType.ShouldNotBeNull();
            _capreportInstance.ShouldNotBeNull();
            _capreportInstanceFixture.ShouldNotBeNull();
            _capreportInstance.ShouldBeAssignableTo<capreport>();
            _capreportInstanceFixture.ShouldBeAssignableTo<capreport>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (capreport) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_capreport_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            capreport instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _capreportInstanceType.ShouldNotBeNull();
            _capreportInstance.ShouldNotBeNull();
            _capreportInstanceFixture.ShouldNotBeNull();
            _capreportInstance.ShouldBeAssignableTo<capreport>();
            _capreportInstanceFixture.ShouldBeAssignableTo<capreport>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="capreport" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodbuildGrid)]
        [TestCase(MethodprocessData)]
        [TestCase(MethodprocessPeriods)]
        [TestCase(MethodprocessResourceInfo)]
        [TestCase(MethodbuildResourceCap)]
        [TestCase(MethodbuildColumns)]
        public void AUT_Capreport_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<capreport>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Capreport_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Capreport_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Capreport_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_buildGrid_Method_Call_Internally(Type[] types)
        {
            var methodbuildGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildGrid, Fixture, methodbuildGridPrametersTypes);
        }

        #endregion

        #region Method Call : (buildGrid) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildGrid_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodbuildGridPrametersTypes = null;
            object[] parametersOfbuildGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildGrid, methodbuildGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfbuildGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbuildGrid.ShouldBeNull();
            methodbuildGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildGrid_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodbuildGridPrametersTypes = null;
            object[] parametersOfbuildGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodbuildGrid, parametersOfbuildGrid, methodbuildGridPrametersTypes);

            // Assert
            parametersOfbuildGrid.ShouldBeNull();
            methodbuildGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodbuildGridPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildGrid, Fixture, methodbuildGridPrametersTypes);

            // Assert
            methodbuildGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildGrid_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_processData_Method_Call_Internally(Type[] types)
        {
            var methodprocessDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessData, Fixture, methodprocessDataPrametersTypes);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var resWeb = CreateType<SPWeb>();
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };
            object[] parametersOfprocessData = { web, resWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessData, methodprocessDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfprocessData);

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
        public void AUT_Capreport_processData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var resWeb = CreateType<SPWeb>();
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };
            object[] parametersOfprocessData = { web, resWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodprocessData, parametersOfprocessData, methodprocessDataPrametersTypes);

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
        public void AUT_Capreport_processData_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Capreport_processData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessData, Fixture, methodprocessDataPrametersTypes);

            // Assert
            methodprocessDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_processPeriods_Method_Call_Internally(Type[] types)
        {
            var methodprocessPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessPeriods, Fixture, methodprocessPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processPeriods_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfprocessPeriods = { li };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessPeriods, methodprocessPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfprocessPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessPeriods.ShouldNotBeNull();
            parametersOfprocessPeriods.Length.ShouldBe(1);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(1);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(parametersOfprocessPeriods.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processPeriods_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfprocessPeriods = { li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodprocessPeriods, parametersOfprocessPeriods, methodprocessPeriodsPrametersTypes);

            // Assert
            parametersOfprocessPeriods.ShouldNotBeNull();
            parametersOfprocessPeriods.Length.ShouldBe(1);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(1);
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(parametersOfprocessPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessPeriods, 0);
            const int parametersCount = 1;

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
        public void AUT_Capreport_processPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessPeriodsPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessPeriods, Fixture, methodprocessPeriodsPrametersTypes);

            // Assert
            methodprocessPeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processPeriods_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_processResourceInfo_Method_Call_Internally(Type[] types)
        {
            var methodprocessResourceInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessResourceInfo, Fixture, methodprocessResourceInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processResourceInfo_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessResourceInfo = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, methodprocessResourceInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfprocessResourceInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessResourceInfo.ShouldNotBeNull();
            parametersOfprocessResourceInfo.Length.ShouldBe(1);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(1);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(parametersOfprocessResourceInfo.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processResourceInfo_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfprocessResourceInfo = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodprocessResourceInfo, parametersOfprocessResourceInfo, methodprocessResourceInfoPrametersTypes);

            // Assert
            parametersOfprocessResourceInfo.ShouldNotBeNull();
            parametersOfprocessResourceInfo.Length.ShouldBe(1);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(1);
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(parametersOfprocessResourceInfo.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processResourceInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, 0);
            const int parametersCount = 1;

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
        public void AUT_Capreport_processResourceInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessResourceInfoPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodprocessResourceInfo, Fixture, methodprocessResourceInfoPrametersTypes);

            // Assert
            methodprocessResourceInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResourceInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_processResourceInfo_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResourceInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_buildResourceCap_Method_Call_Internally(Type[] types)
        {
            var methodbuildResourceCapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildResourceCap, Fixture, methodbuildResourceCapPrametersTypes);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildResourceCap_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var field = CreateType<string>();
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfbuildResourceCap = { list, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildResourceCap, methodbuildResourceCapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfbuildResourceCap);

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
        public void AUT_Capreport_buildResourceCap_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var field = CreateType<string>();
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfbuildResourceCap = { list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodbuildResourceCap, parametersOfbuildResourceCap, methodbuildResourceCapPrametersTypes);

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
        public void AUT_Capreport_buildResourceCap_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Capreport_buildResourceCap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbuildResourceCapPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildResourceCap, Fixture, methodbuildResourceCapPrametersTypes);

            // Assert
            methodbuildResourceCapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildResourceCap) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildResourceCap_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildResourceCap, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Capreport_buildColumns_Method_Call_Internally(Type[] types)
        {
            var methodbuildColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildColumns, Fixture, methodbuildColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfbuildColumns = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildColumns, methodbuildColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_capreportInstanceFixture, parametersOfbuildColumns);

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
        public void AUT_Capreport_buildColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfbuildColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_capreportInstance, MethodbuildColumns, parametersOfbuildColumns, methodbuildColumnsPrametersTypes);

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
        public void AUT_Capreport_buildColumns_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Capreport_buildColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbuildColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_capreportInstance, MethodbuildColumns, Fixture, methodbuildColumnsPrametersTypes);

            // Assert
            methodbuildColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Capreport_buildColumns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_capreportInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}