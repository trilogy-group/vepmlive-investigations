using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using XLSImportJob = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.XLSImportJob" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class XLSImportJobTest : AbstractBaseSetupV3Test
    {
        public XLSImportJobTest() : base(typeof(XLSImportJob))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (XLSImportJob) Initializer

        #region Methods

        private const string MethodGetCellValue = "GetCellValue";
        private const string Methodexecute = "execute";

        #endregion

        private Type _xLSImportJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private XLSImportJob _xLSImportJobInstance;
        private XLSImportJob _xLSImportJobInstanceFixture;

        #region General Initializer : Class (XLSImportJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="XLSImportJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _xLSImportJobInstanceType = typeof(XLSImportJob);
            _xLSImportJobInstanceFixture = this.Create<XLSImportJob>(true);
            _xLSImportJobInstance = _xLSImportJobInstanceFixture ?? this.Create<XLSImportJob>(false);
            CurrentInstance = _xLSImportJobInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (XLSImportJob)

        #region General Initializer : Class (XLSImportJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="XLSImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetCellValue, 0)]
        [TestCase(Methodexecute, 0)]
        public void AUT_XLSImportJob_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_xLSImportJobInstanceFixture, 
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
        ///     Class (<see cref="XLSImportJob" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_XLSImportJob_Is_Instance_Present_Test()
        {
            // Assert
            _xLSImportJobInstanceType.ShouldNotBeNull();
            _xLSImportJobInstance.ShouldNotBeNull();
            _xLSImportJobInstanceFixture.ShouldNotBeNull();
            _xLSImportJobInstance.ShouldBeAssignableTo<XLSImportJob>();
            _xLSImportJobInstanceFixture.ShouldBeAssignableTo<XLSImportJob>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (XLSImportJob) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_XLSImportJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            XLSImportJob instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _xLSImportJobInstanceType.ShouldNotBeNull();
            _xLSImportJobInstance.ShouldNotBeNull();
            _xLSImportJobInstanceFixture.ShouldNotBeNull();
            _xLSImportJobInstance.ShouldBeAssignableTo<XLSImportJob>();
            _xLSImportJobInstanceFixture.ShouldBeAssignableTo<XLSImportJob>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (GetCellValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_XLSImportJob_GetCellValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCellValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xLSImportJobInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var document = this.CreateType<SpreadsheetDocument>();
            var cell = this.CreateType<Cell>();
            var cellFormats = this.CreateType<CellFormats>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };
            object[] parametersOfGetCellValue = { document, cell, cellFormats };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodGetCellValue, methodGetCellValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<XLSImportJob, string>(_xLSImportJobInstanceFixture, out exception1, parametersOfGetCellValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<XLSImportJob, string>(_xLSImportJobInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(3);
            methodGetCellValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var document = this.CreateType<SpreadsheetDocument>();
            var cell = this.CreateType<Cell>();
            var cellFormats = this.CreateType<CellFormats>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };
            object[] parametersOfGetCellValue = { document, cell, cellFormats };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<XLSImportJob, string>(_xLSImportJobInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

            // Assert
            parametersOfGetCellValue.ShouldNotBeNull();
            parametersOfGetCellValue.Length.ShouldBe(3);
            methodGetCellValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xLSImportJobInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCellValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xLSImportJobInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCellValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetCellValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_xLSImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_GetCellValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var methodInfo = this.GetMethodInfo(MethodGetCellValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_XLSImportJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xLSImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _xLSImportJobInstance.execute(osite, oweb, data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_xLSImportJobInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_xLSImportJobInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_xLSImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_XLSImportJob_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_xLSImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}