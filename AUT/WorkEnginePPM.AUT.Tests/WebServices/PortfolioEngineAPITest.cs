using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.PortfolioEngineAPI" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class PortfolioEngineAPITest : AbstractBaseSetupTypedTest<PortfolioEngineAPI>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PortfolioEngineAPI) Initializer

        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodGetFunctions = "GetFunctions";
        private const string MethodDispose = "Dispose";
        private const string MethodUploadFile = "UploadFile";
        private const string MethodReadPermissionGroups = "ReadPermissionGroups";
        private const string MethodReadResourcePermissionGroups = "ReadResourcePermissionGroups";
        private const string MethodReadResourceCostCategoryRole = "ReadResourceCostCategoryRole";
        private const string MethodReadResources = "ReadResources";
        private const string MethodUpdateResources = "UpdateResources";
        private const string MethodDeleteResourceCheck = "DeleteResourceCheck";
        private const string MethodGenerateDataTicket = "GenerateDataTicket";
        private const string MethodGetCostCategoryRoles = "GetCostCategoryRoles";
        private const string MethodGetDepartments = "GetDepartments";
        private const string MethodGetHolidaySchedules = "GetHolidaySchedules";
        private const string MethodGetPersonalItems = "GetPersonalItems";
        private const string MethodGetWorkSchedules = "GetWorkSchedules";
        private const string MethodUpdateDepartments = "UpdateDepartments";
        private const string MethodDeleteDepartments = "DeleteDepartments";
        private const string MethodUpdateRoles = "UpdateRoles";
        private const string MethodDeleteRoles = "DeleteRoles";
        private const string MethodUpdateWorkSchedule = "UpdateWorkSchedule";
        private const string MethodUpdateScheduledWork = "UpdateScheduledWork";
        private const string MethodDeleteWorkSchedule = "DeleteWorkSchedule";
        private const string MethodUpdateHolidaySchedules = "UpdateHolidaySchedules";
        private const string MethodDeleteHolidaySchedule = "DeleteHolidaySchedule";
        private const string MethodUpdatePersonalItems = "UpdatePersonalItems";
        private const string MethodDeletePersonalItems = "DeletePersonalItems";
        private const string MethodUpdateResourceTimeoff = "UpdateResourceTimeoff";
        private const string MethodDeleteResourceTimeoff = "DeleteResourceTimeoff";
        private const string MethodUpdateListWork = "UpdateListWork";
        private const string MethodUpdateScheduledWorkByID = "UpdateScheduledWorkByID";
        private const string MethodDeleteListWork = "DeleteListWork";
        private const string MethodDeletePIListWork = "DeletePIListWork";
        private const string MethodSetDatabaseVersion = "SetDatabaseVersion";
        private const string MethodExecuteReportExtract = "ExecuteReportExtract";
        private const string MethodPostTimesheetData = "PostTimesheetData";
        private const string MethodPostCostValues = "PostCostValues";
        private const string MethodRefreshRoles = "RefreshRoles";
        private const string MethodScheduleDataImport = "ScheduleDataImport";
        private const string MethodCollectDataImportResult = "CollectDataImportResult";
        private const string Field_spWeb = "_spWeb";
        private Type _portfolioEngineAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PortfolioEngineAPI _portfolioEngineAPIInstance;
        private PortfolioEngineAPI _portfolioEngineAPIInstanceFixture;

        #region General Initializer : Class (PortfolioEngineAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PortfolioEngineAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _portfolioEngineAPIInstanceType = typeof(PortfolioEngineAPI);
            _portfolioEngineAPIInstanceFixture = Create(true);
            _portfolioEngineAPIInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PortfolioEngineAPI)

        #region General Initializer : Class (PortfolioEngineAPI) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PortfolioEngineAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodGetFunctions, 0)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodUploadFile, 0)]
        [TestCase(MethodReadPermissionGroups, 0)]
        [TestCase(MethodReadResourcePermissionGroups, 0)]
        [TestCase(MethodReadResourceCostCategoryRole, 0)]
        [TestCase(MethodReadResources, 0)]
        [TestCase(MethodUpdateResources, 0)]
        [TestCase(MethodDeleteResourceCheck, 0)]
        [TestCase(MethodGenerateDataTicket, 0)]
        [TestCase(MethodGetCostCategoryRoles, 0)]
        [TestCase(MethodGetDepartments, 0)]
        [TestCase(MethodGetHolidaySchedules, 0)]
        [TestCase(MethodGetPersonalItems, 0)]
        [TestCase(MethodGetWorkSchedules, 0)]
        [TestCase(MethodUpdateDepartments, 0)]
        [TestCase(MethodDeleteDepartments, 0)]
        [TestCase(MethodUpdateRoles, 0)]
        [TestCase(MethodDeleteRoles, 0)]
        [TestCase(MethodUpdateWorkSchedule, 0)]
        [TestCase(MethodUpdateScheduledWork, 0)]
        [TestCase(MethodDeleteWorkSchedule, 0)]
        [TestCase(MethodUpdateHolidaySchedules, 0)]
        [TestCase(MethodDeleteHolidaySchedule, 0)]
        [TestCase(MethodUpdatePersonalItems, 0)]
        [TestCase(MethodDeletePersonalItems, 0)]
        [TestCase(MethodUpdateResourceTimeoff, 0)]
        [TestCase(MethodDeleteResourceTimeoff, 0)]
        [TestCase(MethodUpdateListWork, 0)]
        [TestCase(MethodUpdateScheduledWorkByID, 0)]
        [TestCase(MethodDeleteListWork, 0)]
        [TestCase(MethodDeletePIListWork, 0)]
        [TestCase(MethodSetDatabaseVersion, 0)]
        [TestCase(MethodExecuteReportExtract, 0)]
        [TestCase(MethodPostTimesheetData, 0)]
        [TestCase(MethodPostCostValues, 0)]
        [TestCase(MethodRefreshRoles, 0)]
        [TestCase(MethodScheduleDataImport, 0)]
        [TestCase(MethodCollectDataImportResult, 0)]
        public void AUT_PortfolioEngineAPI_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_portfolioEngineAPIInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PortfolioEngineAPI) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PortfolioEngineAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Field_spWeb)]
        public void AUT_PortfolioEngineAPI_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_portfolioEngineAPIInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PortfolioEngineAPI) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="PortfolioEngineAPI" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_PortfolioEngineAPI_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<PortfolioEngineAPI>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (PortfolioEngineAPI) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="PortfolioEngineAPI" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_PortfolioEngineAPI_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<PortfolioEngineAPI>(Fixture);
        }

        #endregion

        #region General Constructor : Class (PortfolioEngineAPI) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PortfolioEngineAPI" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_PortfolioEngineAPI_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            object[] parametersOfPortfolioEngineAPI = { spWeb };
            var methodPortfolioEngineAPIPrametersTypes = new Type[] { typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_portfolioEngineAPIInstanceType, methodPortfolioEngineAPIPrametersTypes, parametersOfPortfolioEngineAPI);
        }

        #endregion

        #region General Constructor : Class (PortfolioEngineAPI) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PortfolioEngineAPI" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_PortfolioEngineAPI_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPortfolioEngineAPIPrametersTypes = new Type[] { typeof(SPWeb) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_portfolioEngineAPIInstanceType, Fixture, methodPortfolioEngineAPIPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (PortfolioEngineAPI) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PortfolioEngineAPI" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_PortfolioEngineAPI_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfPortfolioEngineAPI = {  };
            Type [] methodPortfolioEngineAPIPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_portfolioEngineAPIInstanceType, methodPortfolioEngineAPIPrametersTypes, parametersOfPortfolioEngineAPI);
        }

        #endregion

        #region General Constructor : Class (PortfolioEngineAPI) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PortfolioEngineAPI" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_PortfolioEngineAPI_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodPortfolioEngineAPIPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_portfolioEngineAPIInstanceType, Fixture, methodPortfolioEngineAPIPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="PortfolioEngineAPI" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetFunctions)]
        [TestCase(MethodReadPermissionGroups)]
        [TestCase(MethodReadResourcePermissionGroups)]
        [TestCase(MethodReadResourceCostCategoryRole)]
        [TestCase(MethodReadResources)]
        [TestCase(MethodUpdateResources)]
        [TestCase(MethodDeleteResourceCheck)]
        [TestCase(MethodGenerateDataTicket)]
        [TestCase(MethodGetCostCategoryRoles)]
        [TestCase(MethodGetDepartments)]
        [TestCase(MethodGetHolidaySchedules)]
        [TestCase(MethodGetPersonalItems)]
        [TestCase(MethodGetWorkSchedules)]
        [TestCase(MethodUpdateDepartments)]
        [TestCase(MethodDeleteDepartments)]
        [TestCase(MethodUpdateRoles)]
        [TestCase(MethodDeleteRoles)]
        [TestCase(MethodUpdateWorkSchedule)]
        [TestCase(MethodUpdateScheduledWork)]
        [TestCase(MethodDeleteWorkSchedule)]
        [TestCase(MethodUpdateHolidaySchedules)]
        [TestCase(MethodDeleteHolidaySchedule)]
        [TestCase(MethodUpdatePersonalItems)]
        [TestCase(MethodDeletePersonalItems)]
        [TestCase(MethodUpdateResourceTimeoff)]
        [TestCase(MethodDeleteResourceTimeoff)]
        [TestCase(MethodUpdateListWork)]
        [TestCase(MethodUpdateScheduledWorkByID)]
        [TestCase(MethodDeleteListWork)]
        [TestCase(MethodDeletePIListWork)]
        [TestCase(MethodSetDatabaseVersion)]
        [TestCase(MethodExecuteReportExtract)]
        [TestCase(MethodPostTimesheetData)]
        [TestCase(MethodPostCostValues)]
        [TestCase(MethodRefreshRoles)]
        [TestCase(MethodScheduleDataImport)]
        [TestCase(MethodCollectDataImportResult)]
        public void AUT_PortfolioEngineAPI_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_portfolioEngineAPIInstanceFixture,
                                                                              _portfolioEngineAPIInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PortfolioEngineAPI" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        [TestCase(MethodDispose)]
        [TestCase(MethodUploadFile)]
        public void AUT_PortfolioEngineAPI_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PortfolioEngineAPI>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioEngineAPIInstance.Execute(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioEngineAPI, string>(_portfolioEngineAPIInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioEngineAPIInstance.ExecuteJSON(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioEngineAPI, string>(_portfolioEngineAPIInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFunctionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, Fixture, methodGetFunctionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetFunctions(data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetFunctionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFunctions = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFunctions, methodGetFunctionsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, Fixture, methodGetFunctionsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, parametersOfGetFunctions, methodGetFunctionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFunctions.ShouldNotBeNull();
            parametersOfGetFunctions.Length.ShouldBe(1);
            methodGetFunctionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, parametersOfGetFunctions, methodGetFunctionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetFunctionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFunctions = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFunctions, methodGetFunctionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetFunctions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFunctions.ShouldNotBeNull();
            parametersOfGetFunctions.Length.ShouldBe(1);
            methodGetFunctionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetFunctionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFunctions = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, parametersOfGetFunctions, methodGetFunctionsPrametersTypes);

            // Assert
            parametersOfGetFunctions.ShouldNotBeNull();
            parametersOfGetFunctions.Length.ShouldBe(1);
            methodGetFunctionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetFunctionsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, Fixture, methodGetFunctionsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFunctionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFunctionsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetFunctions, Fixture, methodGetFunctionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFunctionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFunctions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFunctions) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetFunctions_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFunctions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Dispose_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_portfolioEngineAPIInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_Dispose_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UploadFile_Method_Call_Internally(Type[] types)
        {
            var methodUploadFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodUploadFile, Fixture, methodUploadFilePrametersTypes);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var fileBytes = CreateType<byte[]>();
            var fileName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _portfolioEngineAPIInstance.UploadFile(fileBytes, fileName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fileBytes = CreateType<byte[]>();
            var fileName = CreateType<string>();
            var methodUploadFilePrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            object[] parametersOfUploadFile = { fileBytes, fileName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUploadFile, methodUploadFilePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PortfolioEngineAPI, string>(_portfolioEngineAPIInstanceFixture, out exception1, parametersOfUploadFile);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodUploadFile, parametersOfUploadFile, methodUploadFilePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUploadFile.ShouldNotBeNull();
            parametersOfUploadFile.Length.ShouldBe(2);
            methodUploadFilePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fileBytes = CreateType<byte[]>();
            var fileName = CreateType<string>();
            var methodUploadFilePrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            object[] parametersOfUploadFile = { fileBytes, fileName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PortfolioEngineAPI, string>(_portfolioEngineAPIInstance, MethodUploadFile, parametersOfUploadFile, methodUploadFilePrametersTypes);

            // Assert
            parametersOfUploadFile.ShouldNotBeNull();
            parametersOfUploadFile.Length.ShouldBe(2);
            methodUploadFilePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUploadFilePrametersTypes = new Type[] { typeof(byte[]), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodUploadFile, Fixture, methodUploadFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUploadFilePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUploadFilePrametersTypes = new Type[] { typeof(byte[]), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioEngineAPIInstance, MethodUploadFile, Fixture, methodUploadFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUploadFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUploadFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UploadFile) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UploadFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUploadFile, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadPermissionGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, Fixture, methodReadPermissionGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ReadPermissionGroups(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadPermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadPermissionGroups = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPermissionGroups, methodReadPermissionGroupsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, Fixture, methodReadPermissionGroupsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, parametersOfReadPermissionGroups, methodReadPermissionGroupsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfReadPermissionGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReadPermissionGroups.ShouldNotBeNull();
            parametersOfReadPermissionGroups.Length.ShouldBe(1);
            methodReadPermissionGroupsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadPermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadPermissionGroups = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, parametersOfReadPermissionGroups, methodReadPermissionGroupsPrametersTypes);

            // Assert
            parametersOfReadPermissionGroups.ShouldNotBeNull();
            parametersOfReadPermissionGroups.Length.ShouldBe(1);
            methodReadPermissionGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadPermissionGroupsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, Fixture, methodReadPermissionGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadPermissionGroupsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadPermissionGroups, Fixture, methodReadPermissionGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadPermissionGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPermissionGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadPermissionGroups) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadPermissionGroups_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPermissionGroups, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadResourcePermissionGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, Fixture, methodReadResourcePermissionGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ReadResourcePermissionGroups(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourcePermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResourcePermissionGroups = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResourcePermissionGroups, methodReadResourcePermissionGroupsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, Fixture, methodReadResourcePermissionGroupsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, parametersOfReadResourcePermissionGroups, methodReadResourcePermissionGroupsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfReadResourcePermissionGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReadResourcePermissionGroups.ShouldNotBeNull();
            parametersOfReadResourcePermissionGroups.Length.ShouldBe(1);
            methodReadResourcePermissionGroupsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourcePermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResourcePermissionGroups = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, parametersOfReadResourcePermissionGroups, methodReadResourcePermissionGroupsPrametersTypes);

            // Assert
            parametersOfReadResourcePermissionGroups.ShouldNotBeNull();
            parametersOfReadResourcePermissionGroups.Length.ShouldBe(1);
            methodReadResourcePermissionGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadResourcePermissionGroupsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, Fixture, methodReadResourcePermissionGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadResourcePermissionGroupsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadResourcePermissionGroupsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourcePermissionGroups, Fixture, methodReadResourcePermissionGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadResourcePermissionGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResourcePermissionGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadResourcePermissionGroups) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourcePermissionGroups_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadResourcePermissionGroups, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadResourceCostCategoryRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, Fixture, methodReadResourceCostCategoryRolePrametersTypes);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ReadResourceCostCategoryRole(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourceCostCategoryRolePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResourceCostCategoryRole = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResourceCostCategoryRole, methodReadResourceCostCategoryRolePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, Fixture, methodReadResourceCostCategoryRolePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, parametersOfReadResourceCostCategoryRole, methodReadResourceCostCategoryRolePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfReadResourceCostCategoryRole);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReadResourceCostCategoryRole.ShouldNotBeNull();
            parametersOfReadResourceCostCategoryRole.Length.ShouldBe(1);
            methodReadResourceCostCategoryRolePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourceCostCategoryRolePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResourceCostCategoryRole = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, parametersOfReadResourceCostCategoryRole, methodReadResourceCostCategoryRolePrametersTypes);

            // Assert
            parametersOfReadResourceCostCategoryRole.ShouldNotBeNull();
            parametersOfReadResourceCostCategoryRole.Length.ShouldBe(1);
            methodReadResourceCostCategoryRolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadResourceCostCategoryRolePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, Fixture, methodReadResourceCostCategoryRolePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadResourceCostCategoryRolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadResourceCostCategoryRolePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResourceCostCategoryRole, Fixture, methodReadResourceCostCategoryRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadResourceCostCategoryRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResourceCostCategoryRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadResourceCostCategoryRole) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResourceCostCategoryRole_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadResourceCostCategoryRole, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, Fixture, methodReadResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ReadResources(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResources = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResources, methodReadResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, Fixture, methodReadResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, parametersOfReadResources, methodReadResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfReadResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReadResources.ShouldNotBeNull();
            parametersOfReadResources.Length.ShouldBe(1);
            methodReadResourcesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodReadResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfReadResources = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, parametersOfReadResources, methodReadResourcesPrametersTypes);

            // Assert
            parametersOfReadResources.ShouldNotBeNull();
            parametersOfReadResources.Length.ShouldBe(1);
            methodReadResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadResourcesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, Fixture, methodReadResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodReadResources, Fixture, methodReadResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ReadResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateResources(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResources = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResources, methodUpdateResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, parametersOfUpdateResources, methodUpdateResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateResources.ShouldNotBeNull();
            parametersOfUpdateResources.Length.ShouldBe(1);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResources = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, parametersOfUpdateResources, methodUpdateResourcesPrametersTypes);

            // Assert
            parametersOfUpdateResources.ShouldNotBeNull();
            parametersOfUpdateResources.Length.ShouldBe(1);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourceCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, Fixture, methodDeleteResourceCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteResourceCheck(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourceCheckPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourceCheck = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceCheck, methodDeleteResourceCheckPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, Fixture, methodDeleteResourceCheckPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, parametersOfDeleteResourceCheck, methodDeleteResourceCheckPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteResourceCheck);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteResourceCheck.ShouldNotBeNull();
            parametersOfDeleteResourceCheck.Length.ShouldBe(1);
            methodDeleteResourceCheckPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourceCheckPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourceCheck = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, parametersOfDeleteResourceCheck, methodDeleteResourceCheckPrametersTypes);

            // Assert
            parametersOfDeleteResourceCheck.ShouldNotBeNull();
            parametersOfDeleteResourceCheck.Length.ShouldBe(1);
            methodDeleteResourceCheckPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteResourceCheckPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, Fixture, methodDeleteResourceCheckPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteResourceCheckPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourceCheckPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceCheck, Fixture, methodDeleteResourceCheckPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourceCheckPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceCheck, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourceCheck) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceCheck_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourceCheck, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateDataTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GenerateDataTicket(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGenerateDataTicket = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, methodGenerateDataTicketPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, parametersOfGenerateDataTicket, methodGenerateDataTicketPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGenerateDataTicket);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGenerateDataTicket.ShouldNotBeNull();
            parametersOfGenerateDataTicket.Length.ShouldBe(1);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGenerateDataTicket = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, parametersOfGenerateDataTicket, methodGenerateDataTicketPrametersTypes);

            // Assert
            parametersOfGenerateDataTicket.ShouldNotBeNull();
            parametersOfGenerateDataTicket.Length.ShouldBe(1);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateDataTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGenerateDataTicket, Fixture, methodGenerateDataTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateDataTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateDataTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GenerateDataTicket_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGenerateDataTicket, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCostCategoryRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetCostCategoryRoles(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetCostCategoryRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostCategoryRoles = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, parametersOfGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetCostCategoryRoles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostCategoryRoles.ShouldNotBeNull();
            parametersOfGetCostCategoryRoles.Length.ShouldBe(1);
            methodGetCostCategoryRolesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetCostCategoryRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostCategoryRoles = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, parametersOfGetCostCategoryRoles, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            parametersOfGetCostCategoryRoles.ShouldNotBeNull();
            parametersOfGetCostCategoryRoles.Length.ShouldBe(1);
            methodGetCostCategoryRolesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCostCategoryRolesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostCategoryRolesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostCategoryRolesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetCostCategoryRoles, Fixture, methodGetCostCategoryRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostCategoryRolesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostCategoryRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostCategoryRoles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetCostCategoryRoles_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostCategoryRoles, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, Fixture, methodGetDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetDepartments(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDepartments = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDepartments, methodGetDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, Fixture, methodGetDepartmentsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, parametersOfGetDepartments, methodGetDepartmentsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetDepartments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDepartments.ShouldNotBeNull();
            parametersOfGetDepartments.Length.ShouldBe(1);
            methodGetDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetDepartments = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, parametersOfGetDepartments, methodGetDepartmentsPrametersTypes);

            // Assert
            parametersOfGetDepartments.ShouldNotBeNull();
            parametersOfGetDepartments.Length.ShouldBe(1);
            methodGetDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDepartmentsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, Fixture, methodGetDepartmentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDepartmentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDepartmentsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetDepartments, Fixture, methodGetDepartmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDepartmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDepartments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDepartments) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetDepartments_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDepartments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetHolidaySchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, Fixture, methodGetHolidaySchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetHolidaySchedules(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetHolidaySchedules = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHolidaySchedules, methodGetHolidaySchedulesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, Fixture, methodGetHolidaySchedulesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, parametersOfGetHolidaySchedules, methodGetHolidaySchedulesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetHolidaySchedules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetHolidaySchedules.ShouldNotBeNull();
            parametersOfGetHolidaySchedules.Length.ShouldBe(1);
            methodGetHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetHolidaySchedules = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, parametersOfGetHolidaySchedules, methodGetHolidaySchedulesPrametersTypes);

            // Assert
            parametersOfGetHolidaySchedules.ShouldNotBeNull();
            parametersOfGetHolidaySchedules.Length.ShouldBe(1);
            methodGetHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, Fixture, methodGetHolidaySchedulesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetHolidaySchedules, Fixture, methodGetHolidaySchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHolidaySchedulesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHolidaySchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHolidaySchedules) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetHolidaySchedules_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetHolidaySchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetPersonalItems(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetPersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPersonalItems = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, methodGetPersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, parametersOfGetPersonalItems, methodGetPersonalItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetPersonalItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersonalItems.ShouldNotBeNull();
            parametersOfGetPersonalItems.Length.ShouldBe(1);
            methodGetPersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetPersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPersonalItems = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, parametersOfGetPersonalItems, methodGetPersonalItemsPrametersTypes);

            // Assert
            parametersOfGetPersonalItems.ShouldNotBeNull();
            parametersOfGetPersonalItems.Length.ShouldBe(1);
            methodGetPersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersonalItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetPersonalItems, Fixture, methodGetPersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetPersonalItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkSchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, Fixture, methodGetWorkSchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.GetWorkSchedules(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkSchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkSchedules = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkSchedules, methodGetWorkSchedulesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, Fixture, methodGetWorkSchedulesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, parametersOfGetWorkSchedules, methodGetWorkSchedulesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfGetWorkSchedules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkSchedules.ShouldNotBeNull();
            parametersOfGetWorkSchedules.Length.ShouldBe(1);
            methodGetWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkSchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkSchedules = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, parametersOfGetWorkSchedules, methodGetWorkSchedulesPrametersTypes);

            // Assert
            parametersOfGetWorkSchedules.ShouldNotBeNull();
            parametersOfGetWorkSchedules.Length.ShouldBe(1);
            methodGetWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkSchedulesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, Fixture, methodGetWorkSchedulesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkSchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkSchedulesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodGetWorkSchedules, Fixture, methodGetWorkSchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkSchedulesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkSchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkSchedules) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_GetWorkSchedules_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkSchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateDepartments(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDepartments = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, methodUpdateDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, parametersOfUpdateDepartments, methodUpdateDepartmentsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateDepartments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateDepartments.ShouldNotBeNull();
            parametersOfUpdateDepartments.Length.ShouldBe(1);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDepartments = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, parametersOfUpdateDepartments, methodUpdateDepartmentsPrametersTypes);

            // Assert
            parametersOfUpdateDepartments.ShouldNotBeNull();
            parametersOfUpdateDepartments.Length.ShouldBe(1);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDepartmentsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateDepartments, Fixture, methodUpdateDepartmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateDepartmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateDepartments) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateDepartments_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDepartments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteDepartmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteDepartments(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteDepartments = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, methodDeleteDepartmentsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, parametersOfDeleteDepartments, methodDeleteDepartmentsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteDepartments);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteDepartments.ShouldNotBeNull();
            parametersOfDeleteDepartments.Length.ShouldBe(1);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteDepartments = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, parametersOfDeleteDepartments, methodDeleteDepartmentsPrametersTypes);

            // Assert
            parametersOfDeleteDepartments.ShouldNotBeNull();
            parametersOfDeleteDepartments.Length.ShouldBe(1);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteDepartmentsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteDepartments, Fixture, methodDeleteDepartmentsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteDepartmentsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteDepartments) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteDepartments_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteDepartments, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateRoles(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateRoles = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRoles, methodUpdateRolesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, parametersOfUpdateRoles, methodUpdateRolesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateRoles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateRoles.ShouldNotBeNull();
            parametersOfUpdateRoles.Length.ShouldBe(1);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateRoles = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, parametersOfUpdateRoles, methodUpdateRolesPrametersTypes);

            // Assert
            parametersOfUpdateRoles.ShouldNotBeNull();
            parametersOfUpdateRoles.Length.ShouldBe(1);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateRolesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateRolesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateRoles, Fixture, methodUpdateRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateRolesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateRoles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateRoles_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateRoles, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, Fixture, methodDeleteRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteRoles(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteRoles = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteRoles, methodDeleteRolesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, Fixture, methodDeleteRolesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, parametersOfDeleteRoles, methodDeleteRolesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteRoles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteRoles.ShouldNotBeNull();
            parametersOfDeleteRoles.Length.ShouldBe(1);
            methodDeleteRolesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteRoles = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, parametersOfDeleteRoles, methodDeleteRolesPrametersTypes);

            // Assert
            parametersOfDeleteRoles.ShouldNotBeNull();
            parametersOfDeleteRoles.Length.ShouldBe(1);
            methodDeleteRolesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteRolesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, Fixture, methodDeleteRolesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteRolesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteRolesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteRoles, Fixture, methodDeleteRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteRolesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteRoles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteRoles_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteRoles, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateWorkSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateWorkSchedule(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateWorkSchedule = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, parametersOfUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateWorkSchedule);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateWorkSchedule.ShouldNotBeNull();
            parametersOfUpdateWorkSchedule.Length.ShouldBe(1);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateWorkSchedule = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, parametersOfUpdateWorkSchedule, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            parametersOfUpdateWorkSchedule.ShouldNotBeNull();
            parametersOfUpdateWorkSchedule.Length.ShouldBe(1);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateWorkSchedule, Fixture, methodUpdateWorkSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateWorkSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateWorkSchedule) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateWorkSchedule_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateWorkSchedule, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateScheduledWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateScheduledWork(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateScheduledWork = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, parametersOfUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateScheduledWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateScheduledWork.ShouldNotBeNull();
            parametersOfUpdateScheduledWork.Length.ShouldBe(1);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateScheduledWork = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, parametersOfUpdateScheduledWork, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            parametersOfUpdateScheduledWork.ShouldNotBeNull();
            parametersOfUpdateScheduledWork.Length.ShouldBe(1);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateScheduledWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWork, Fixture, methodUpdateScheduledWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateScheduledWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateScheduledWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteWorkSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteWorkSchedule(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteWorkSchedule = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, parametersOfDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteWorkSchedule);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfDeleteWorkSchedule.Length.ShouldBe(1);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteWorkSchedule = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, parametersOfDeleteWorkSchedule, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            parametersOfDeleteWorkSchedule.ShouldNotBeNull();
            parametersOfDeleteWorkSchedule.Length.ShouldBe(1);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteWorkSchedulePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteWorkSchedule, Fixture, methodDeleteWorkSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteWorkSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteWorkSchedule) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteWorkSchedule_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteWorkSchedule, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateHolidaySchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, Fixture, methodUpdateHolidaySchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateHolidaySchedules(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateHolidaySchedules = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedules, methodUpdateHolidaySchedulesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, Fixture, methodUpdateHolidaySchedulesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, parametersOfUpdateHolidaySchedules, methodUpdateHolidaySchedulesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateHolidaySchedules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateHolidaySchedules.ShouldNotBeNull();
            parametersOfUpdateHolidaySchedules.Length.ShouldBe(1);
            methodUpdateHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateHolidaySchedules = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, parametersOfUpdateHolidaySchedules, methodUpdateHolidaySchedulesPrametersTypes);

            // Assert
            parametersOfUpdateHolidaySchedules.ShouldNotBeNull();
            parametersOfUpdateHolidaySchedules.Length.ShouldBe(1);
            methodUpdateHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, Fixture, methodUpdateHolidaySchedulesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateHolidaySchedulesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateHolidaySchedules, Fixture, methodUpdateHolidaySchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateHolidaySchedulesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateHolidaySchedules) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateHolidaySchedules_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateHolidaySchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteHolidaySchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteHolidaySchedule(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteHolidaySchedule = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, parametersOfDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteHolidaySchedule);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfDeleteHolidaySchedule.Length.ShouldBe(1);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteHolidaySchedule = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, parametersOfDeleteHolidaySchedule, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            parametersOfDeleteHolidaySchedule.ShouldNotBeNull();
            parametersOfDeleteHolidaySchedule.Length.ShouldBe(1);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteHolidaySchedulePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteHolidaySchedule, Fixture, methodDeleteHolidaySchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteHolidaySchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteHolidaySchedule) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteHolidaySchedule_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteHolidaySchedule, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdatePersonalItems(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePersonalItems = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, parametersOfUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdatePersonalItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdatePersonalItems.ShouldNotBeNull();
            parametersOfUpdatePersonalItems.Length.ShouldBe(1);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdatePersonalItems = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, parametersOfUpdatePersonalItems, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            parametersOfUpdatePersonalItems.ShouldNotBeNull();
            parametersOfUpdatePersonalItems.Length.ShouldBe(1);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdatePersonalItems, Fixture, methodUpdatePersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdatePersonalItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdatePersonalItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdatePersonalItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePersonalItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeletePersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, Fixture, methodDeletePersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeletePersonalItems(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeletePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeletePersonalItems = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePersonalItems, methodDeletePersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, Fixture, methodDeletePersonalItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, parametersOfDeletePersonalItems, methodDeletePersonalItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeletePersonalItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeletePersonalItems.ShouldNotBeNull();
            parametersOfDeletePersonalItems.Length.ShouldBe(1);
            methodDeletePersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeletePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeletePersonalItems = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, parametersOfDeletePersonalItems, methodDeletePersonalItemsPrametersTypes);

            // Assert
            parametersOfDeletePersonalItems.ShouldNotBeNull();
            parametersOfDeletePersonalItems.Length.ShouldBe(1);
            methodDeletePersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeletePersonalItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, Fixture, methodDeletePersonalItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeletePersonalItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePersonalItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePersonalItems, Fixture, methodDeletePersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePersonalItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeletePersonalItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePersonalItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePersonalItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourceTimeoffPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateResourceTimeoff(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResourceTimeoff = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, parametersOfUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateResourceTimeoff);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateResourceTimeoff.ShouldNotBeNull();
            parametersOfUpdateResourceTimeoff.Length.ShouldBe(1);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResourceTimeoff = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, parametersOfUpdateResourceTimeoff, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            parametersOfUpdateResourceTimeoff.ShouldNotBeNull();
            parametersOfUpdateResourceTimeoff.Length.ShouldBe(1);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateResourceTimeoff, Fixture, methodUpdateResourceTimeoffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourceTimeoffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateResourceTimeoff) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateResourceTimeoff_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResourceTimeoff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourceTimeoffPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteResourceTimeoff(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourceTimeoff = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, parametersOfDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteResourceTimeoff);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteResourceTimeoff.ShouldNotBeNull();
            parametersOfDeleteResourceTimeoff.Length.ShouldBe(1);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteResourceTimeoff = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, parametersOfDeleteResourceTimeoff, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            parametersOfDeleteResourceTimeoff.ShouldNotBeNull();
            parametersOfDeleteResourceTimeoff.Length.ShouldBe(1);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourceTimeoffPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteResourceTimeoff, Fixture, methodDeleteResourceTimeoffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourceTimeoffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourceTimeoff) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteResourceTimeoff_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourceTimeoff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateListWork(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListWork = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListWork, methodUpdateListWorkPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, parametersOfUpdateListWork, methodUpdateListWorkPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateListWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateListWork.ShouldNotBeNull();
            parametersOfUpdateListWork.Length.ShouldBe(1);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListWork = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, parametersOfUpdateListWork, methodUpdateListWorkPrametersTypes);

            // Assert
            parametersOfUpdateListWork.ShouldNotBeNull();
            parametersOfUpdateListWork.Length.ShouldBe(1);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateListWork, Fixture, methodUpdateListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateListWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateListWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateScheduledWorkByIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, Fixture, methodUpdateScheduledWorkByIDPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.UpdateScheduledWorkByID(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateScheduledWorkByIDPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateScheduledWorkByID = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWorkByID, methodUpdateScheduledWorkByIDPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, Fixture, methodUpdateScheduledWorkByIDPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, parametersOfUpdateScheduledWorkByID, methodUpdateScheduledWorkByIDPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfUpdateScheduledWorkByID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateScheduledWorkByID.ShouldNotBeNull();
            parametersOfUpdateScheduledWorkByID.Length.ShouldBe(1);
            methodUpdateScheduledWorkByIDPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateScheduledWorkByIDPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateScheduledWorkByID = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, parametersOfUpdateScheduledWorkByID, methodUpdateScheduledWorkByIDPrametersTypes);

            // Assert
            parametersOfUpdateScheduledWorkByID.ShouldNotBeNull();
            parametersOfUpdateScheduledWorkByID.Length.ShouldBe(1);
            methodUpdateScheduledWorkByIDPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateScheduledWorkByIDPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, Fixture, methodUpdateScheduledWorkByIDPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateScheduledWorkByIDPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateScheduledWorkByIDPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodUpdateScheduledWorkByID, Fixture, methodUpdateScheduledWorkByIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateScheduledWorkByIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWorkByID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateScheduledWorkByID) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_UpdateScheduledWorkByID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateScheduledWorkByID, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeleteListWork(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteListWork = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteListWork, methodDeleteListWorkPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, parametersOfDeleteListWork, methodDeleteListWorkPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeleteListWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteListWork.ShouldNotBeNull();
            parametersOfDeleteListWork.Length.ShouldBe(1);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteListWork = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, parametersOfDeleteListWork, methodDeleteListWorkPrametersTypes);

            // Assert
            parametersOfDeleteListWork.ShouldNotBeNull();
            parametersOfDeleteListWork.Length.ShouldBe(1);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteListWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeleteListWork, Fixture, methodDeleteListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteListWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeleteListWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteListWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeletePIListWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.DeletePIListWork(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeletePIListWork = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, methodDeletePIListWorkPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, parametersOfDeletePIListWork, methodDeletePIListWorkPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfDeletePIListWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeletePIListWork.ShouldNotBeNull();
            parametersOfDeletePIListWork.Length.ShouldBe(1);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeletePIListWork = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, parametersOfDeletePIListWork, methodDeletePIListWorkPrametersTypes);

            // Assert
            parametersOfDeletePIListWork.ShouldNotBeNull();
            parametersOfDeletePIListWork.Length.ShouldBe(1);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePIListWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodDeletePIListWork, Fixture, methodDeletePIListWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePIListWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeletePIListWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_DeletePIListWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePIListWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetDatabaseVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.SetDatabaseVersion(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetDatabaseVersion = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, parametersOfSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfSetDatabaseVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetDatabaseVersion.ShouldNotBeNull();
            parametersOfSetDatabaseVersion.Length.ShouldBe(1);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetDatabaseVersion = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, parametersOfSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes);

            // Assert
            parametersOfSetDatabaseVersion.ShouldNotBeNull();
            parametersOfSetDatabaseVersion.Length.ShouldBe(1);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_SetDatabaseVersion_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteReportExtractPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ExecuteReportExtract(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteReportExtract = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, methodExecuteReportExtractPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, parametersOfExecuteReportExtract, methodExecuteReportExtractPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfExecuteReportExtract);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteReportExtract.ShouldNotBeNull();
            parametersOfExecuteReportExtract.Length.ShouldBe(1);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteReportExtract = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, parametersOfExecuteReportExtract, methodExecuteReportExtractPrametersTypes);

            // Assert
            parametersOfExecuteReportExtract.ShouldNotBeNull();
            parametersOfExecuteReportExtract.Length.ShouldBe(1);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ExecuteReportExtract_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_Internally(Type[] types)
        {
            var methodPostTimesheetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.PostTimesheetData(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostTimesheetData = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, methodPostTimesheetDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, parametersOfPostTimesheetData, methodPostTimesheetDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfPostTimesheetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPostTimesheetData.ShouldNotBeNull();
            parametersOfPostTimesheetData.Length.ShouldBe(1);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostTimesheetData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, parametersOfPostTimesheetData, methodPostTimesheetDataPrametersTypes);

            // Assert
            parametersOfPostTimesheetData.ShouldNotBeNull();
            parametersOfPostTimesheetData.Length.ShouldBe(1);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostTimesheetData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_Internally(Type[] types)
        {
            var methodPostCostValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.PostCostValues(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostCostValues = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCostValues, methodPostCostValuesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, parametersOfPostCostValues, methodPostCostValuesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfPostCostValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPostCostValues.ShouldNotBeNull();
            parametersOfPostCostValues.Length.ShouldBe(1);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostCostValues = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, parametersOfPostCostValues, methodPostCostValuesPrametersTypes);

            // Assert
            parametersOfPostCostValues.ShouldNotBeNull();
            parametersOfPostCostValues.Length.ShouldBe(1);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPostCostValuesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostCostValuesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodPostCostValues, Fixture, methodPostCostValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostCostValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCostValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_PostCostValues_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostCostValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_Internally(Type[] types)
        {
            var methodRefreshRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, Fixture, methodRefreshRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.RefreshRoles(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRefreshRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRefreshRoles = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshRoles, methodRefreshRolesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, Fixture, methodRefreshRolesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, parametersOfRefreshRoles, methodRefreshRolesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfRefreshRoles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRefreshRoles.ShouldNotBeNull();
            parametersOfRefreshRoles.Length.ShouldBe(1);
            methodRefreshRolesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRefreshRolesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRefreshRoles = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, parametersOfRefreshRoles, methodRefreshRolesPrametersTypes);

            // Assert
            parametersOfRefreshRoles.ShouldNotBeNull();
            parametersOfRefreshRoles.Length.ShouldBe(1);
            methodRefreshRolesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRefreshRolesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, Fixture, methodRefreshRolesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRefreshRolesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshRolesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodRefreshRoles, Fixture, methodRefreshRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRefreshRolesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshRoles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_RefreshRoles_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshRoles, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_Internally(Type[] types)
        {
            var methodScheduleDataImportPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.ScheduleDataImport(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfScheduleDataImport = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, methodScheduleDataImportPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, parametersOfScheduleDataImport, methodScheduleDataImportPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfScheduleDataImport);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfScheduleDataImport.ShouldNotBeNull();
            parametersOfScheduleDataImport.Length.ShouldBe(1);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfScheduleDataImport = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, parametersOfScheduleDataImport, methodScheduleDataImportPrametersTypes);

            // Assert
            parametersOfScheduleDataImport.ShouldNotBeNull();
            parametersOfScheduleDataImport.Length.ShouldBe(1);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodScheduleDataImportPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodScheduleDataImport, Fixture, methodScheduleDataImportPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodScheduleDataImportPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ScheduleDataImport) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_ScheduleDataImport_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodScheduleDataImport, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_Internally(Type[] types)
        {
            var methodCollectDataImportResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => PortfolioEngineAPI.CollectDataImportResult(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCollectDataImportResult = { data };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, methodCollectDataImportResultPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, parametersOfCollectDataImportResult, methodCollectDataImportResultPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_portfolioEngineAPIInstanceFixture, parametersOfCollectDataImportResult);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCollectDataImportResult.ShouldNotBeNull();
            parametersOfCollectDataImportResult.Length.ShouldBe(1);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCollectDataImportResult = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, parametersOfCollectDataImportResult, methodCollectDataImportResultPrametersTypes);

            // Assert
            parametersOfCollectDataImportResult.ShouldNotBeNull();
            parametersOfCollectDataImportResult.Length.ShouldBe(1);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCollectDataImportResultPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_portfolioEngineAPIInstanceFixture, _portfolioEngineAPIInstanceType, MethodCollectDataImportResult, Fixture, methodCollectDataImportResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCollectDataImportResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioEngineAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CollectDataImportResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_PortfolioEngineAPI_CollectDataImportResult_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCollectDataImportResult, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}