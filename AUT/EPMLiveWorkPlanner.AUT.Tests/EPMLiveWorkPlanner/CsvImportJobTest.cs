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
using CsvImportJob = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.CsvImportJob" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CsvImportJobTest : AbstractBaseSetupV3Test
    {
        public CsvImportJobTest() : base(typeof(CsvImportJob))
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

        #region General Initializer : Class (CsvImportJob) Initializer

        #region Methods

        private const string MethodConvertFromCSV = "ConvertFromCSV";
        private const string Methodexecute = "execute";

        #endregion

        private Type _csvImportJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private CsvImportJob _csvImportJobInstance;
        private CsvImportJob _csvImportJobInstanceFixture;

        #region General Initializer : Class (CsvImportJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CsvImportJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _csvImportJobInstanceType = typeof(CsvImportJob);
            _csvImportJobInstanceFixture = this.Create<CsvImportJob>(true);
            _csvImportJobInstance = _csvImportJobInstanceFixture ?? this.Create<CsvImportJob>(false);
            CurrentInstance = _csvImportJobInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CsvImportJob)

        #region General Initializer : Class (CsvImportJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CsvImportJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertFromCSV, 0)]
        [TestCase(Methodexecute, 0)]
        public void AUT_CsvImportJob_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_csvImportJobInstanceFixture, 
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
        ///     Class (<see cref="CsvImportJob" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CsvImportJob_Is_Instance_Present_Test()
        {
            // Assert
            _csvImportJobInstanceType.ShouldNotBeNull();
            _csvImportJobInstance.ShouldNotBeNull();
            _csvImportJobInstanceFixture.ShouldNotBeNull();
            _csvImportJobInstance.ShouldBeAssignableTo<CsvImportJob>();
            _csvImportJobInstanceFixture.ShouldBeAssignableTo<CsvImportJob>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CsvImportJob) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CsvImportJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CsvImportJob instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _csvImportJobInstanceType.ShouldNotBeNull();
            _csvImportJobInstance.ShouldNotBeNull();
            _csvImportJobInstanceFixture.ShouldNotBeNull();
            _csvImportJobInstance.ShouldBeAssignableTo<CsvImportJob>();
            _csvImportJobInstanceFixture.ShouldBeAssignableTo<CsvImportJob>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CsvImportJob_ConvertFromCSV_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromCSVPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_csvImportJobInstance, MethodConvertFromCSV, Fixture, methodConvertFromCSVPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            var line = this.CreateType<string>();
            var cols = this.CreateType<int>();
            var methodConvertFromCSVPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfConvertFromCSV = { line, cols };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodConvertFromCSV, methodConvertFromCSVPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_csvImportJobInstanceFixture, parametersOfConvertFromCSV);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertFromCSV.ShouldNotBeNull();
            parametersOfConvertFromCSV.Length.ShouldBe(2);
            methodConvertFromCSVPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            var line = this.CreateType<string>();
            var cols = this.CreateType<int>();
            var methodConvertFromCSVPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfConvertFromCSV = { line, cols };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CsvImportJob, string[]>(_csvImportJobInstance, MethodConvertFromCSV, parametersOfConvertFromCSV, methodConvertFromCSVPrametersTypes);

            // Assert
            parametersOfConvertFromCSV.ShouldNotBeNull();
            parametersOfConvertFromCSV.Length.ShouldBe(2);
            methodConvertFromCSVPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            var methodConvertFromCSVPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_csvImportJobInstance, MethodConvertFromCSV, Fixture, methodConvertFromCSVPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertFromCSVPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            var methodConvertFromCSVPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_csvImportJobInstance, MethodConvertFromCSV, Fixture, methodConvertFromCSVPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertFromCSVPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodConvertFromCSV, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_csvImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertFromCSV) (Return Type : string[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_ConvertFromCSV_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodConvertFromCSV);
            var methodInfo = this.GetMethodInfo(MethodConvertFromCSV, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CsvImportJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_csvImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_execute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _csvImportJobInstance.execute(osite, oweb, data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_execute_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_csvImportJobInstanceFixture, parametersOfexecute);

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
        public void AUT_CsvImportJob_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var osite = this.CreateType<SPSite>();
            var oweb = this.CreateType<SPWeb>();
            var data = this.CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { osite, oweb, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_csvImportJobInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

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
        public void AUT_CsvImportJob_execute_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CsvImportJob_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_csvImportJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CsvImportJob_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(Methodexecute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_csvImportJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}