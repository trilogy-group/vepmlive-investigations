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
using System.Web.UI.WebControls;
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
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner.Layouts.epmlive;
using ImportExcel = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.ImportExcel" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ImportExcelTest : AbstractBaseSetupV3Test
    {
        public ImportExcelTest() : base(typeof(ImportExcel))
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

        #region General Initializer : Class (ImportExcel) Initializer

        #region Methods

        private const string MethodPage_Load = "Page_Load";
        private const string MethodgvColumns_RowDataBound = "gvColumns_RowDataBound";
        private const string MethodbtnSheet_Click = "btnSheet_Click";
        private const string MethodGetCellValue = "GetCellValue";
        private const string MethodbtnFinish_Click = "btnFinish_Click";
        private const string MethodbtnUpload_Click = "btnUpload_Click";

        #endregion

        #region Fields

        private const string FielddtCols = "dtCols";

        #endregion

        private Type _importExcelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ImportExcel _importExcelInstance;
        private ImportExcel _importExcelInstanceFixture;

        #region General Initializer : Class (ImportExcel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportExcel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importExcelInstanceType = typeof(ImportExcel);
            _importExcelInstanceFixture = this.Create<ImportExcel>(true);
            _importExcelInstance = _importExcelInstanceFixture ?? this.Create<ImportExcel>(false);
            CurrentInstance = _importExcelInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ImportExcel)

        #region General Initializer : Class (ImportExcel) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ImportExcel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodgvColumns_RowDataBound, 0)]
        [TestCase(MethodGetCellValue, 0)]
        public void AUT_ImportExcel_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_importExcelInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ImportExcel) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ImportExcel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddtCols)]
        public void AUT_ImportExcel_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_importExcelInstanceFixture, 
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
        ///     Class (<see cref="ImportExcel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ImportExcel_Is_Instance_Present_Test()
        {
            // Assert
            _importExcelInstanceType.ShouldNotBeNull();
            _importExcelInstance.ShouldNotBeNull();
            _importExcelInstanceFixture.ShouldNotBeNull();
            _importExcelInstance.ShouldBeAssignableTo<ImportExcel>();
            _importExcelInstanceFixture.ShouldBeAssignableTo<ImportExcel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportExcel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ImportExcel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ImportExcel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _importExcelInstanceType.ShouldNotBeNull();
            _importExcelInstance.ShouldNotBeNull();
            _importExcelInstanceFixture.ShouldNotBeNull();
            _importExcelInstance.ShouldBeAssignableTo<ImportExcel>();
            _importExcelInstanceFixture.ShouldBeAssignableTo<ImportExcel>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_Page_Load_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importExcelInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ImportExcel_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var sender = this.CreateType<object>();
            var e = this.CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importExcelInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ImportExcel_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);
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
        public void AUT_ImportExcel_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPage_Load);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importExcelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodgvColumns_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodgvColumns_RowDataBound, Fixture, methodgvColumns_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgvColumns_RowDataBound);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewRowEventArgs>();
            var methodgvColumns_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgvColumns_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgvColumns_RowDataBound, methodgvColumns_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_importExcelInstanceFixture, parametersOfgvColumns_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgvColumns_RowDataBound.ShouldNotBeNull();
            parametersOfgvColumns_RowDataBound.Length.ShouldBe(2);
            methodgvColumns_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvColumns_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvColumns_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgvColumns_RowDataBound);
            var sender = this.CreateType<object>();
            var e = this.CreateType<GridViewRowEventArgs>();
            var methodgvColumns_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfgvColumns_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_importExcelInstance, MethodgvColumns_RowDataBound, parametersOfgvColumns_RowDataBound, methodgvColumns_RowDataBoundPrametersTypes);

            // Assert
            parametersOfgvColumns_RowDataBound.ShouldNotBeNull();
            parametersOfgvColumns_RowDataBound.Length.ShouldBe(2);
            methodgvColumns_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvColumns_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvColumns_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgvColumns_RowDataBound);
            var methodInfo = this.GetMethodInfo(MethodgvColumns_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgvColumns_RowDataBound);
            var methodgvColumns_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodgvColumns_RowDataBound, Fixture, methodgvColumns_RowDataBoundPrametersTypes);

            // Assert
            methodgvColumns_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvColumns_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_gvColumns_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgvColumns_RowDataBound);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgvColumns_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_importExcelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSheet_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_btnSheet_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnSheet_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodbtnSheet_Click, Fixture, methodbtnSheet_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_GetCellValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCellValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_GetCellValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<ImportExcel, string>(_importExcelInstanceFixture, out exception1, parametersOfGetCellValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ImportExcel, string>(_importExcelInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

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
        public void AUT_ImportExcel_GetCellValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var document = this.CreateType<SpreadsheetDocument>();
            var cell = this.CreateType<Cell>();
            var cellFormats = this.CreateType<CellFormats>();
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };
            object[] parametersOfGetCellValue = { document, cell, cellFormats };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ImportExcel, string>(_importExcelInstance, MethodGetCellValue, parametersOfGetCellValue, methodGetCellValuePrametersTypes);

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
        public void AUT_ImportExcel_GetCellValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCellValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_GetCellValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            var methodGetCellValuePrametersTypes = new Type[] { typeof(SpreadsheetDocument), typeof(Cell), typeof(CellFormats) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodGetCellValue, Fixture, methodGetCellValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCellValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_GetCellValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetCellValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetCellValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_importExcelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCellValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ImportExcel_GetCellValue_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (btnFinish_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_btnFinish_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnFinish_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodbtnFinish_Click, Fixture, methodbtnFinish_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnUpload_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ImportExcel_btnUpload_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnUpload_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_importExcelInstance, MethodbtnUpload_Click, Fixture, methodbtnUpload_ClickPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}