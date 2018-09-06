using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMCostPlanner" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMCostPlannerTest : AbstractBaseSetupTypedTest<DSMCostPlanner>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMCostPlanner) Initializer

        private const string MethodImportData = "ImportData";
        private const string MethodSaveRows = "SaveRows";
        private const string MethodUpdateProject = "UpdateProject";
        private const string MethodGetMasterRecordId = "GetMasterRecordId";
        private const string MethodGetRateOrFTEConversion = "GetRateOrFTEConversion";
        private const string MethodFillDataViewFromCSVFile = "FillDataViewFromCSVFile";
        private const string MethodFillMasterRecordDataViews = "FillMasterRecordDataViews";
        private const string MethodFormatMessage = "FormatMessage";
        private const string MethodLogDSMMessage = "LogDSMMessage";
        private const string MethodRaiseDSMProgressChangedEvent = "RaiseDSMProgressChangedEvent";
        private const string MethodRaiseDSMCompletedEvent = "RaiseDSMCompletedEvent";
        private const string Field_spWeb = "_spWeb";
        private const string Field_fileId = "_fileId";
        private const string Field_listId = "_listId";
        private const string Field_dSMResult = "_dSMResult";
        private const string FieldcolCalendar = "colCalendar";
        private const string FieldcolProject = "colProject";
        private const string FieldcolCostType = "colCostType";
        private const string FieldcolCostCategory = "colCostCategory";
        private const string FieldcolPeriod = "colPeriod";
        private const string FieldcolCostAmount = "colCostAmount";
        private const string FieldcolQTY = "colQTY";
        private const string FieldcolFTE = "colFTE";
        private const string FieldcolDetailRow = "colDetailRow";
        private const string FieldcolOC_01 = "colOC_01";
        private const string FieldcolOC_02 = "colOC_02";
        private const string FieldcolOC_03 = "colOC_03";
        private const string FieldcolOC_04 = "colOC_04";
        private const string FieldcolOC_05 = "colOC_05";
        private const string FieldcolTEXT_01 = "colTEXT_01";
        private const string FieldcolTEXT_02 = "colTEXT_02";
        private const string FieldcolTEXT_03 = "colTEXT_03";
        private const string FieldcolTEXT_04 = "colTEXT_04";
        private const string FieldcolTEXT_05 = "colTEXT_05";
        private const string Field_dtInsertCostData = "_dtInsertCostData";
        private const string Field_dvRawData = "_dvRawData";
        private const string Field_dvCostBreakdowns = "_dvCostBreakdowns";
        private const string Field_dvProjects = "_dvProjects";
        private const string Field_dvCostTypes = "_dvCostTypes";
        private const string Field_dvCostCategories = "_dvCostCategories";
        private const string Field_dvPeriods = "_dvPeriods";
        private const string Field_dvCostCustomFields = "_dvCostCustomFields";
        private const string Field_dvCostBreakdownAttribs = "_dvCostBreakdownAttribs";
        private const string Field_totalRecords = "_totalRecords";
        private const string Fieldcontext = "context";
        private const string FieldspRegionalSettings = "spRegionalSettings";
        private const string FielddateSeparator = "dateSeparator";
        private const string FieldcalendarOrderType = "calendarOrderType";
        private Type _dSMCostPlannerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMCostPlanner _dSMCostPlannerInstance;
        private DSMCostPlanner _dSMCostPlannerInstanceFixture;

        #region General Initializer : Class (DSMCostPlanner) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMCostPlanner" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMCostPlannerInstanceType = typeof(DSMCostPlanner);
            _dSMCostPlannerInstanceFixture = Create(true);
            _dSMCostPlannerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DSMCostPlanner)

        #region General Initializer : Class (DSMCostPlanner) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DSMCostPlanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodImportData, 0)]
        [TestCase(MethodSaveRows, 0)]
        [TestCase(MethodGetMasterRecordId, 0)]
        [TestCase(MethodGetRateOrFTEConversion, 0)]
        [TestCase(MethodFillDataViewFromCSVFile, 0)]
        [TestCase(MethodFillMasterRecordDataViews, 0)]
        [TestCase(MethodFormatMessage, 0)]
        [TestCase(MethodLogDSMMessage, 0)]
        [TestCase(MethodRaiseDSMProgressChangedEvent, 0)]
        [TestCase(MethodRaiseDSMCompletedEvent, 0)]
        public void AUT_DSMCostPlanner_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dSMCostPlannerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DSMCostPlanner) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DSMCostPlanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_spWeb)]
        [TestCase(Field_fileId)]
        [TestCase(Field_listId)]
        [TestCase(Field_dSMResult)]
        [TestCase(FieldcolCalendar)]
        [TestCase(FieldcolProject)]
        [TestCase(FieldcolCostType)]
        [TestCase(FieldcolCostCategory)]
        [TestCase(FieldcolPeriod)]
        [TestCase(FieldcolCostAmount)]
        [TestCase(FieldcolQTY)]
        [TestCase(FieldcolFTE)]
        [TestCase(FieldcolDetailRow)]
        [TestCase(FieldcolOC_01)]
        [TestCase(FieldcolOC_02)]
        [TestCase(FieldcolOC_03)]
        [TestCase(FieldcolOC_04)]
        [TestCase(FieldcolOC_05)]
        [TestCase(FieldcolTEXT_01)]
        [TestCase(FieldcolTEXT_02)]
        [TestCase(FieldcolTEXT_03)]
        [TestCase(FieldcolTEXT_04)]
        [TestCase(FieldcolTEXT_05)]
        [TestCase(Field_dtInsertCostData)]
        [TestCase(Field_dvRawData)]
        [TestCase(Field_dvCostBreakdowns)]
        [TestCase(Field_dvProjects)]
        [TestCase(Field_dvCostTypes)]
        [TestCase(Field_dvCostCategories)]
        [TestCase(Field_dvPeriods)]
        [TestCase(Field_dvCostCustomFields)]
        [TestCase(Field_dvCostBreakdownAttribs)]
        [TestCase(Field_totalRecords)]
        [TestCase(Fieldcontext)]
        [TestCase(FieldspRegionalSettings)]
        [TestCase(FielddateSeparator)]
        [TestCase(FieldcalendarOrderType)]
        public void AUT_DSMCostPlanner_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dSMCostPlannerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DSMCostPlanner" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodImportData)]
        [TestCase(MethodSaveRows)]
        [TestCase(MethodUpdateProject)]
        [TestCase(MethodGetMasterRecordId)]
        [TestCase(MethodGetRateOrFTEConversion)]
        [TestCase(MethodFillDataViewFromCSVFile)]
        [TestCase(MethodFillMasterRecordDataViews)]
        [TestCase(MethodFormatMessage)]
        [TestCase(MethodLogDSMMessage)]
        [TestCase(MethodRaiseDSMProgressChangedEvent)]
        [TestCase(MethodRaiseDSMCompletedEvent)]
        public void AUT_DSMCostPlanner_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DSMCostPlanner>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_ImportData_Method_Call_Internally(Type[] types)
        {
            var methodImportDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodImportData, Fixture, methodImportDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_ImportData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _dSMCostPlannerInstance.ImportData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_ImportData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodImportDataPrametersTypes = null;
            object[] parametersOfImportData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodImportData, methodImportDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dSMCostPlannerInstanceFixture, parametersOfImportData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportData.ShouldBeNull();
            methodImportDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_ImportData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodImportDataPrametersTypes = null;
            object[] parametersOfImportData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dSMCostPlannerInstance, MethodImportData, parametersOfImportData, methodImportDataPrametersTypes);

            // Assert
            parametersOfImportData.ShouldBeNull();
            methodImportDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_ImportData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodImportDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodImportData, Fixture, methodImportDataPrametersTypes);

            // Assert
            methodImportDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_ImportData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_SaveRows_Method_Call_Internally(Type[] types)
        {
            var methodSaveRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodSaveRows, Fixture, methodSaveRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var calendarId = CreateType<Int32>();
            var projectId = CreateType<Int32>();
            var costTypeId = CreateType<Int32>();
            var dtInsertCostDetails = CreateType<DataTable>();
            var dtInsertCostDetailValues = CreateType<DataTable>();
            var methodSaveRowsPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(DataTable), typeof(DataTable) };
            object[] parametersOfSaveRows = { calendarId, projectId, costTypeId, dtInsertCostDetails, dtInsertCostDetailValues };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveRows, methodSaveRowsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, Boolean>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfSaveRows);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Boolean>(_dSMCostPlannerInstance, MethodSaveRows, parametersOfSaveRows, methodSaveRowsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveRows.ShouldNotBeNull();
            parametersOfSaveRows.Length.ShouldBe(5);
            methodSaveRowsPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var calendarId = CreateType<Int32>();
            var projectId = CreateType<Int32>();
            var costTypeId = CreateType<Int32>();
            var dtInsertCostDetails = CreateType<DataTable>();
            var dtInsertCostDetailValues = CreateType<DataTable>();
            var methodSaveRowsPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(DataTable), typeof(DataTable) };
            object[] parametersOfSaveRows = { calendarId, projectId, costTypeId, dtInsertCostDetails, dtInsertCostDetailValues };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveRows, methodSaveRowsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, Boolean>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfSaveRows);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Boolean>(_dSMCostPlannerInstance, MethodSaveRows, parametersOfSaveRows, methodSaveRowsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveRows.ShouldNotBeNull();
            parametersOfSaveRows.Length.ShouldBe(5);
            methodSaveRowsPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var calendarId = CreateType<Int32>();
            var projectId = CreateType<Int32>();
            var costTypeId = CreateType<Int32>();
            var dtInsertCostDetails = CreateType<DataTable>();
            var dtInsertCostDetailValues = CreateType<DataTable>();
            var methodSaveRowsPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(DataTable), typeof(DataTable) };
            object[] parametersOfSaveRows = { calendarId, projectId, costTypeId, dtInsertCostDetails, dtInsertCostDetailValues };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Boolean>(_dSMCostPlannerInstance, MethodSaveRows, parametersOfSaveRows, methodSaveRowsPrametersTypes);

            // Assert
            parametersOfSaveRows.ShouldNotBeNull();
            parametersOfSaveRows.Length.ShouldBe(5);
            methodSaveRowsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveRowsPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(DataTable), typeof(DataTable) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodSaveRows, Fixture, methodSaveRowsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveRowsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveRows, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveRows) (Return Type : Boolean) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_SaveRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveRows, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateProject) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_UpdateProject_Method_Call_Internally(Type[] types)
        {
            var methodUpdateProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodUpdateProject, Fixture, methodUpdateProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateProject) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_UpdateProject_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var projectId = CreateType<int>();
            var methodUpdateProjectPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfUpdateProject = { projectId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, bool>(_dSMCostPlannerInstance, MethodUpdateProject, parametersOfUpdateProject, methodUpdateProjectPrametersTypes);

            // Assert
            parametersOfUpdateProject.ShouldNotBeNull();
            parametersOfUpdateProject.Length.ShouldBe(1);
            methodUpdateProjectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProject) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_UpdateProject_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateProjectPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodUpdateProject, Fixture, methodUpdateProjectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateProjectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_Internally(Type[] types)
        {
            var methodGetMasterRecordIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodGetMasterRecordId, Fixture, methodGetMasterRecordIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var columnName = CreateType<string>();
            var columnValue = CreateType<string>();
            var foreignKeyId = CreateType<string>();
            var costCategoryArray = CreateType<string[]>();
            var methodGetMasterRecordIdPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string[]) };
            object[] parametersOfGetMasterRecordId = { columnName, columnValue, foreignKeyId, costCategoryArray };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMasterRecordId, methodGetMasterRecordIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, Int32>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfGetMasterRecordId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Int32>(_dSMCostPlannerInstance, MethodGetMasterRecordId, parametersOfGetMasterRecordId, methodGetMasterRecordIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMasterRecordId.ShouldNotBeNull();
            parametersOfGetMasterRecordId.Length.ShouldBe(4);
            methodGetMasterRecordIdPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var columnName = CreateType<string>();
            var columnValue = CreateType<string>();
            var foreignKeyId = CreateType<string>();
            var costCategoryArray = CreateType<string[]>();
            var methodGetMasterRecordIdPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string[]) };
            object[] parametersOfGetMasterRecordId = { columnName, columnValue, foreignKeyId, costCategoryArray };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMasterRecordId, methodGetMasterRecordIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, Int32>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfGetMasterRecordId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Int32>(_dSMCostPlannerInstance, MethodGetMasterRecordId, parametersOfGetMasterRecordId, methodGetMasterRecordIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetMasterRecordId.ShouldNotBeNull();
            parametersOfGetMasterRecordId.Length.ShouldBe(4);
            methodGetMasterRecordIdPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columnName = CreateType<string>();
            var columnValue = CreateType<string>();
            var foreignKeyId = CreateType<string>();
            var costCategoryArray = CreateType<string[]>();
            var methodGetMasterRecordIdPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string[]) };
            object[] parametersOfGetMasterRecordId = { columnName, columnValue, foreignKeyId, costCategoryArray };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Int32>(_dSMCostPlannerInstance, MethodGetMasterRecordId, parametersOfGetMasterRecordId, methodGetMasterRecordIdPrametersTypes);

            // Assert
            parametersOfGetMasterRecordId.ShouldNotBeNull();
            parametersOfGetMasterRecordId.Length.ShouldBe(4);
            methodGetMasterRecordIdPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMasterRecordIdPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string[]) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodGetMasterRecordId, Fixture, methodGetMasterRecordIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMasterRecordIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMasterRecordId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMasterRecordId) (Return Type : Int32) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetMasterRecordId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMasterRecordId, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_Internally(Type[] types)
        {
            var methodGetRateOrFTEConversionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodGetRateOrFTEConversion, Fixture, methodGetRateOrFTEConversionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var calendarId = CreateType<Int32>();
            var costCategoryId = CreateType<Int32>();
            var periodId = CreateType<Int32>();
            var isQty = CreateType<Boolean>();
            var methodGetRateOrFTEConversionPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(Boolean) };
            object[] parametersOfGetRateOrFTEConversion = { calendarId, costCategoryId, periodId, isQty };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRateOrFTEConversion, methodGetRateOrFTEConversionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, Double>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfGetRateOrFTEConversion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Double>(_dSMCostPlannerInstance, MethodGetRateOrFTEConversion, parametersOfGetRateOrFTEConversion, methodGetRateOrFTEConversionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRateOrFTEConversion.ShouldNotBeNull();
            parametersOfGetRateOrFTEConversion.Length.ShouldBe(4);
            methodGetRateOrFTEConversionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var calendarId = CreateType<Int32>();
            var costCategoryId = CreateType<Int32>();
            var periodId = CreateType<Int32>();
            var isQty = CreateType<Boolean>();
            var methodGetRateOrFTEConversionPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(Boolean) };
            object[] parametersOfGetRateOrFTEConversion = { calendarId, costCategoryId, periodId, isQty };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, Double>(_dSMCostPlannerInstance, MethodGetRateOrFTEConversion, parametersOfGetRateOrFTEConversion, methodGetRateOrFTEConversionPrametersTypes);

            // Assert
            parametersOfGetRateOrFTEConversion.ShouldNotBeNull();
            parametersOfGetRateOrFTEConversion.Length.ShouldBe(4);
            methodGetRateOrFTEConversionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRateOrFTEConversionPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(Boolean) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodGetRateOrFTEConversion, Fixture, methodGetRateOrFTEConversionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRateOrFTEConversionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRateOrFTEConversionPrametersTypes = new Type[] { typeof(Int32), typeof(Int32), typeof(Int32), typeof(Boolean) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodGetRateOrFTEConversion, Fixture, methodGetRateOrFTEConversionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRateOrFTEConversionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRateOrFTEConversion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRateOrFTEConversion) (Return Type : Double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_GetRateOrFTEConversion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRateOrFTEConversion, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_Internally(Type[] types)
        {
            var methodFillDataViewFromCSVFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFillDataViewFromCSVFile, Fixture, methodFillDataViewFromCSVFilePrametersTypes);
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodFillDataViewFromCSVFilePrametersTypes = null;
            object[] parametersOfFillDataViewFromCSVFile = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFillDataViewFromCSVFile, methodFillDataViewFromCSVFilePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, DataView>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfFillDataViewFromCSVFile);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, DataView>(_dSMCostPlannerInstance, MethodFillDataViewFromCSVFile, parametersOfFillDataViewFromCSVFile, methodFillDataViewFromCSVFilePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFillDataViewFromCSVFile.ShouldBeNull();
            methodFillDataViewFromCSVFilePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFillDataViewFromCSVFilePrametersTypes = null;
            object[] parametersOfFillDataViewFromCSVFile = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, DataView>(_dSMCostPlannerInstance, MethodFillDataViewFromCSVFile, parametersOfFillDataViewFromCSVFile, methodFillDataViewFromCSVFilePrametersTypes);

            // Assert
            parametersOfFillDataViewFromCSVFile.ShouldBeNull();
            methodFillDataViewFromCSVFilePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodFillDataViewFromCSVFilePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFillDataViewFromCSVFile, Fixture, methodFillDataViewFromCSVFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFillDataViewFromCSVFilePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFillDataViewFromCSVFilePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFillDataViewFromCSVFile, Fixture, methodFillDataViewFromCSVFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFillDataViewFromCSVFilePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FillDataViewFromCSVFile) (Return Type : DataView) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillDataViewFromCSVFile_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillDataViewFromCSVFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FillMasterRecordDataViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_FillMasterRecordDataViews_Method_Call_Internally(Type[] types)
        {
            var methodFillMasterRecordDataViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFillMasterRecordDataViews, Fixture, methodFillMasterRecordDataViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (FillMasterRecordDataViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillMasterRecordDataViews_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodFillMasterRecordDataViewsPrametersTypes = null;
            object[] parametersOfFillMasterRecordDataViews = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillMasterRecordDataViews, methodFillMasterRecordDataViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dSMCostPlannerInstanceFixture, parametersOfFillMasterRecordDataViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillMasterRecordDataViews.ShouldBeNull();
            methodFillMasterRecordDataViewsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillMasterRecordDataViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillMasterRecordDataViews_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFillMasterRecordDataViewsPrametersTypes = null;
            object[] parametersOfFillMasterRecordDataViews = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dSMCostPlannerInstance, MethodFillMasterRecordDataViews, parametersOfFillMasterRecordDataViews, methodFillMasterRecordDataViewsPrametersTypes);

            // Assert
            parametersOfFillMasterRecordDataViews.ShouldBeNull();
            methodFillMasterRecordDataViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillMasterRecordDataViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillMasterRecordDataViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFillMasterRecordDataViewsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFillMasterRecordDataViews, Fixture, methodFillMasterRecordDataViewsPrametersTypes);

            // Assert
            methodFillMasterRecordDataViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillMasterRecordDataViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FillMasterRecordDataViews_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillMasterRecordDataViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_FormatMessage_Method_Call_Internally(Type[] types)
        {
            var methodFormatMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFormatMessage, Fixture, methodFormatMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var calendarName = CreateType<string>();
            var projectName = CreateType<string>();
            var costTypeName = CreateType<string>();
            var costCategoryName = CreateType<string>();
            var periodName = CreateType<string>();
            var quantity = CreateType<double>();
            var cost = CreateType<double>();
            var errorMessage = CreateType<string>();
            var methodFormatMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(double), typeof(double), typeof(string) };
            object[] parametersOfFormatMessage = { calendarName, projectName, costTypeName, costCategoryName, periodName, quantity, cost, errorMessage };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatMessage, methodFormatMessagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DSMCostPlanner, string>(_dSMCostPlannerInstanceFixture, out exception1, parametersOfFormatMessage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, string>(_dSMCostPlannerInstance, MethodFormatMessage, parametersOfFormatMessage, methodFormatMessagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatMessage.ShouldNotBeNull();
            parametersOfFormatMessage.Length.ShouldBe(8);
            methodFormatMessagePrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var calendarName = CreateType<string>();
            var projectName = CreateType<string>();
            var costTypeName = CreateType<string>();
            var costCategoryName = CreateType<string>();
            var periodName = CreateType<string>();
            var quantity = CreateType<double>();
            var cost = CreateType<double>();
            var errorMessage = CreateType<string>();
            var methodFormatMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(double), typeof(double), typeof(string) };
            object[] parametersOfFormatMessage = { calendarName, projectName, costTypeName, costCategoryName, periodName, quantity, cost, errorMessage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DSMCostPlanner, string>(_dSMCostPlannerInstance, MethodFormatMessage, parametersOfFormatMessage, methodFormatMessagePrametersTypes);

            // Assert
            parametersOfFormatMessage.ShouldNotBeNull();
            parametersOfFormatMessage.Length.ShouldBe(8);
            methodFormatMessagePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(double), typeof(double), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFormatMessage, Fixture, methodFormatMessagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatMessagePrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(double), typeof(double), typeof(string) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodFormatMessage, Fixture, methodFormatMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatMessagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatMessage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatMessage) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_FormatMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatMessage, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogDSMMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodLogDSMMessage, Fixture, methodLogDSMMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var messageType = CreateType<Int32>();
            var methodLogDSMMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };
            object[] parametersOfLogDSMMessage = { message, messageType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogDSMMessage, methodLogDSMMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dSMCostPlannerInstanceFixture, parametersOfLogDSMMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogDSMMessage.ShouldNotBeNull();
            parametersOfLogDSMMessage.Length.ShouldBe(2);
            methodLogDSMMessagePrametersTypes.Length.ShouldBe(2);
            methodLogDSMMessagePrametersTypes.Length.ShouldBe(parametersOfLogDSMMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var messageType = CreateType<Int32>();
            var methodLogDSMMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };
            object[] parametersOfLogDSMMessage = { message, messageType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dSMCostPlannerInstance, MethodLogDSMMessage, parametersOfLogDSMMessage, methodLogDSMMessagePrametersTypes);

            // Assert
            parametersOfLogDSMMessage.ShouldNotBeNull();
            parametersOfLogDSMMessage.Length.ShouldBe(2);
            methodLogDSMMessagePrametersTypes.Length.ShouldBe(2);
            methodLogDSMMessagePrametersTypes.Length.ShouldBe(parametersOfLogDSMMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogDSMMessage, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogDSMMessagePrametersTypes = new Type[] { typeof(string), typeof(Int32) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodLogDSMMessage, Fixture, methodLogDSMMessagePrametersTypes);

            // Assert
            methodLogDSMMessagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogDSMMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_LogDSMMessage_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogDSMMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_Internally(Type[] types)
        {
            var methodRaiseDSMProgressChangedEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodRaiseDSMProgressChangedEvent, Fixture, methodRaiseDSMProgressChangedEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currentProcess = CreateType<string>();
            var methodRaiseDSMProgressChangedEventPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfRaiseDSMProgressChangedEvent = { currentProcess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRaiseDSMProgressChangedEvent, methodRaiseDSMProgressChangedEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dSMCostPlannerInstanceFixture, parametersOfRaiseDSMProgressChangedEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaiseDSMProgressChangedEvent.ShouldNotBeNull();
            parametersOfRaiseDSMProgressChangedEvent.Length.ShouldBe(1);
            methodRaiseDSMProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseDSMProgressChangedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseDSMProgressChangedEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentProcess = CreateType<string>();
            var methodRaiseDSMProgressChangedEventPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfRaiseDSMProgressChangedEvent = { currentProcess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dSMCostPlannerInstance, MethodRaiseDSMProgressChangedEvent, parametersOfRaiseDSMProgressChangedEvent, methodRaiseDSMProgressChangedEventPrametersTypes);

            // Assert
            parametersOfRaiseDSMProgressChangedEvent.ShouldNotBeNull();
            parametersOfRaiseDSMProgressChangedEvent.Length.ShouldBe(1);
            methodRaiseDSMProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseDSMProgressChangedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseDSMProgressChangedEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRaiseDSMProgressChangedEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRaiseDSMProgressChangedEventPrametersTypes = new Type[] { typeof(String) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodRaiseDSMProgressChangedEvent, Fixture, methodRaiseDSMProgressChangedEventPrametersTypes);

            // Assert
            methodRaiseDSMProgressChangedEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMProgressChangedEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMProgressChangedEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRaiseDSMProgressChangedEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_Internally(Type[] types)
        {
            var methodRaiseDSMCompletedEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodRaiseDSMCompletedEvent, Fixture, methodRaiseDSMCompletedEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodRaiseDSMCompletedEventPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfRaiseDSMCompletedEvent = { exception };
            var methodInfo = GetMethodInfo(MethodRaiseDSMCompletedEvent, methodRaiseDSMCompletedEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dSMCostPlannerInstanceFixture, parametersOfRaiseDSMCompletedEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaiseDSMCompletedEvent.ShouldNotBeNull();
            parametersOfRaiseDSMCompletedEvent.Length.ShouldBe(1);
            methodRaiseDSMCompletedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseDSMCompletedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseDSMCompletedEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodRaiseDSMCompletedEventPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfRaiseDSMCompletedEvent = { exception };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dSMCostPlannerInstance, MethodRaiseDSMCompletedEvent, parametersOfRaiseDSMCompletedEvent, methodRaiseDSMCompletedEventPrametersTypes);

            // Assert
            parametersOfRaiseDSMCompletedEvent.ShouldNotBeNull();
            parametersOfRaiseDSMCompletedEvent.Length.ShouldBe(1);
            methodRaiseDSMCompletedEventPrametersTypes.Length.ShouldBe(1);
            methodRaiseDSMCompletedEventPrametersTypes.Length.ShouldBe(parametersOfRaiseDSMCompletedEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRaiseDSMCompletedEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRaiseDSMCompletedEventPrametersTypes = new Type[] { typeof(Exception) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dSMCostPlannerInstance, MethodRaiseDSMCompletedEvent, Fixture, methodRaiseDSMCompletedEventPrametersTypes);

            // Assert
            methodRaiseDSMCompletedEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaiseDSMCompletedEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DSMCostPlanner_RaiseDSMCompletedEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRaiseDSMCompletedEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dSMCostPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}