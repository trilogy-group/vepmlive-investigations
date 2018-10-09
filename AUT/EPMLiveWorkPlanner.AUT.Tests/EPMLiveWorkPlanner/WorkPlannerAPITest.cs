using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Services;
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
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner;
using WorkPlannerAPI = EPMLiveWorkPlanner;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.WorkPlannerAPI" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public class WorkPlannerAPITest : AbstractBaseSetupV3Test
    {
        public WorkPlannerAPITest() : base(typeof(WorkPlannerAPI))
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

        #region General Initializer : Class (WorkPlannerAPI) Initializer

        #region Methods

        private const string MethodExecute = "Execute";
        private const string MethodGetExternalTasks = "GetExternalTasks";
        private const string MethodGetExternalProjects = "GetExternalProjects";
        private const string MethodImportTasks = "ImportTasks";
        private const string MethodprocessTasks = "processTasks";
        private const string MethodbSpecialColumn = "bSpecialColumn";
        private const string MethodImportTasksFixXmlStructure = "ImportTasksFixXmlStructure";
        private const string MethodGetPlannersByProjectList = "GetPlannersByProjectList";
        private const string MethodGetPlannersByTaskList = "GetPlannersByTaskList";
        private const string MethodGetUpdateDetailLayout = "GetUpdateDetailLayout";
        private const string MethodSaveProject = "SaveProject";
        private const string MethodSaveAgilePlan = "SaveAgilePlan";
        private const string MethodSaveWorkPlan = "SaveWorkPlan";
        private const string MethodStrToByteArray = "StrToByteArray";
        private const string MethodUpgradeProjectScheduleLibrary = "UpgradeProjectScheduleLibrary";
        private const string MethodiApplyNewTemplate = "iApplyNewTemplate";
        private const string MethodApplyNewTemplate = "ApplyNewTemplate";
        private const string MethodgetLIField = "getLIField";
        private const string MethodiGetTemplates = "iGetTemplates";
        private const string MethodiSaveTemplate = "iSaveTemplate";
        private const string MethodSaveTemplate = "SaveTemplate";
        private const string MethodGetTemplates = "GetTemplates";
        private const string MethodGetTaskFile = "GetTaskFile";
        private const string MethodProcessTaskXmlFromTaskCenter = "ProcessTaskXmlFromTaskCenter";
        private const string MethodGetTasks = "GetTasks";
        private const string MethodProcessExternal = "ProcessExternal";
        private const string MethodbIsSpecialExternalField = "bIsSpecialExternalField";
        private const string MethodGetExternalLinkLayout = "GetExternalLinkLayout";
        private const string MethodAddCustomFooter = "AddCustomFooter";
        private const string MethodGetUpdates = "GetUpdates";
        private const string MethodgetFieldValue = "getFieldValue";
        private const string MethodgetAttribute = "getAttribute";
        private const string MethodPublishProcessTasks = "PublishProcessTasks";
        private const string MethodPublishProcessTask = "PublishProcessTask";
        private const string MethodPublishGetFieldValue = "PublishGetFieldValue";
        private const string MethodPublishIsAssignmentField = "PublishIsAssignmentField";
        private const string MethodPublishIsValidField = "PublishIsValidField";
        private const string MethodPublishProcessFolders = "PublishProcessFolders";
        private const string MethodPublish = "Publish";
        private const string MethodappendSpecialColumns = "appendSpecialColumns";
        private const string MethodiGetGeneralLayout = "iGetGeneralLayout";
        private const string MethodGetAgileLayout = "GetAgileLayout";
        private const string MethodisNewValidTask = "isNewValidTask";
        private const string MethodAppendNewAgileTasks = "AppendNewAgileTasks";
        private const string MethodGetLayout = "GetLayout";
        private const string MethodGetAgileFolderFieldFormula = "GetAgileFolderFieldFormula";
        private const string MethodaddCalculations = "addCalculations";
        private const string MethodGetFolderLayout = "GetFolderLayout";
        private const string MethodGetViews = "GetViews";
        private const string MethodisValidField = "isValidField";
        private const string MethodGetDetailLayout = "GetDetailLayout";
        private const string MethodSetupProjectCenterList = "SetupProjectCenterList";
        private const string MethodGetResourceTable = "GetResourceTable";
        private const string MethodGetProjectInfo = "GetProjectInfo";
        private const string MethodsetEnumField = "setEnumField";
        private const string MethodGetAssignmentLayout = "GetAssignmentLayout";
        private const string MethodGetLinksLayout = "GetLinksLayout";
        private const string MethodGetAllocationLayout = "GetAllocationLayout";
        private const string MethodProcessAllocationResourcesCols = "ProcessAllocationResourcesCols";
        private const string MethodGetAddLinksLayout = "GetAddLinksLayout";
        private const string MethodgetFormat = "getFormat";
        private const string MethodReadOnlyField = "ReadOnlyField";
        private const string MethodGetFieldType = "GetFieldType";
        private const string MethodaddFieldNodeToDef = "addFieldNodeToDef";
        private const string MethodisAssignmentField = "isAssignmentField";
        private const string MethodprocessIndividualField = "processIndividualField";
        private const string MethodprocessField = "processField";
        private const string MethodgetRealField = "getRealField";
        private const string MethodtestFunction = "testFunction";
        private const string MethodgetSettings = "getSettings";
        private const string MethodGetKanBanPlanners = "GetKanBanPlanners";
        private const string MethodGetKanBanFilter1 = "GetKanBanFilter1";
        private const string MethodGetKanBanBoard = "GetKanBanBoard";
        private const string MethodEncodeJsonData = "EncodeJsonData";
        private const string MethodDecodeJsonData = "DecodeJsonData";
        private const string MethodReOrderAndSaveItem = "ReOrderAndSaveItem";

        #endregion

        private Type _workPlannerAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkPlannerAPI _workPlannerAPIInstance;
        private WorkPlannerAPI _workPlannerAPIInstanceFixture;

        #region General Initializer : Class (WorkPlannerAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkPlannerAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workPlannerAPIInstanceType = typeof(WorkPlannerAPI);
            _workPlannerAPIInstanceFixture = this.Create<WorkPlannerAPI>(true);
            _workPlannerAPIInstance = _workPlannerAPIInstanceFixture ?? this.Create<WorkPlannerAPI>(false);
            CurrentInstance = _workPlannerAPIInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkPlannerAPI)

        #region General Initializer : Class (WorkPlannerAPI) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkPlannerAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodGetExternalTasks, 0)]
        [TestCase(MethodGetExternalProjects, 0)]
        [TestCase(MethodImportTasks, 0)]
        [TestCase(MethodprocessTasks, 0)]
        [TestCase(MethodbSpecialColumn, 0)]
        [TestCase(MethodImportTasksFixXmlStructure, 0)]
        [TestCase(MethodGetPlannersByProjectList, 0)]
        [TestCase(MethodGetPlannersByTaskList, 0)]
        [TestCase(MethodGetUpdateDetailLayout, 0)]
        [TestCase(MethodSaveProject, 0)]
        [TestCase(MethodSaveAgilePlan, 0)]
        [TestCase(MethodSaveWorkPlan, 0)]
        [TestCase(MethodStrToByteArray, 0)]
        [TestCase(MethodUpgradeProjectScheduleLibrary, 0)]
        [TestCase(MethodiApplyNewTemplate, 0)]
        [TestCase(MethodApplyNewTemplate, 0)]
        [TestCase(MethodgetLIField, 0)]
        [TestCase(MethodiGetTemplates, 0)]
        [TestCase(MethodiSaveTemplate, 0)]
        [TestCase(MethodSaveTemplate, 0)]
        [TestCase(MethodGetTemplates, 0)]
        [TestCase(MethodGetTaskFile, 0)]
        [TestCase(MethodProcessTaskXmlFromTaskCenter, 0)]
        [TestCase(MethodGetTasks, 0)]
        [TestCase(MethodProcessExternal, 0)]
        [TestCase(MethodbIsSpecialExternalField, 0)]
        [TestCase(MethodGetExternalLinkLayout, 0)]
        [TestCase(MethodAddCustomFooter, 0)]
        [TestCase(MethodGetUpdates, 0)]
        [TestCase(MethodgetFieldValue, 0)]
        [TestCase(MethodgetAttribute, 0)]
        [TestCase(MethodPublishProcessTasks, 0)]
        [TestCase(MethodPublishProcessTask, 0)]
        [TestCase(MethodPublishGetFieldValue, 0)]
        [TestCase(MethodPublishIsAssignmentField, 0)]
        [TestCase(MethodPublishIsValidField, 0)]
        [TestCase(MethodPublishProcessFolders, 0)]
        [TestCase(MethodPublish, 0)]
        [TestCase(MethodappendSpecialColumns, 0)]
        [TestCase(MethodiGetGeneralLayout, 0)]
        [TestCase(MethodGetAgileLayout, 0)]
        [TestCase(MethodisNewValidTask, 0)]
        [TestCase(MethodAppendNewAgileTasks, 0)]
        [TestCase(MethodGetLayout, 0)]
        [TestCase(MethodGetAgileFolderFieldFormula, 0)]
        [TestCase(MethodaddCalculations, 0)]
        [TestCase(MethodGetFolderLayout, 0)]
        [TestCase(MethodGetViews, 0)]
        [TestCase(MethodisValidField, 0)]
        [TestCase(MethodGetDetailLayout, 0)]
        [TestCase(MethodgetFieldValue, 1)]
        [TestCase(MethodSetupProjectCenterList, 0)]
        [TestCase(MethodGetResourceTable, 0)]
        [TestCase(MethodGetProjectInfo, 0)]
        [TestCase(MethodsetEnumField, 0)]
        [TestCase(MethodGetAssignmentLayout, 0)]
        [TestCase(MethodGetLinksLayout, 0)]
        [TestCase(MethodGetAllocationLayout, 0)]
        [TestCase(MethodProcessAllocationResourcesCols, 0)]
        [TestCase(MethodGetAddLinksLayout, 0)]
        [TestCase(MethodgetFormat, 0)]
        [TestCase(MethodReadOnlyField, 0)]
        [TestCase(MethodGetFieldType, 0)]
        [TestCase(MethodaddFieldNodeToDef, 0)]
        [TestCase(MethodisAssignmentField, 0)]
        [TestCase(MethodprocessIndividualField, 0)]
        [TestCase(MethodprocessField, 0)]
        [TestCase(MethodgetRealField, 0)]
        [TestCase(MethodtestFunction, 0)]
        [TestCase(MethodgetSettings, 0)]
        [TestCase(MethodGetKanBanPlanners, 0)]
        [TestCase(MethodGetKanBanFilter1, 0)]
        [TestCase(MethodGetKanBanBoard, 0)]
        [TestCase(MethodEncodeJsonData, 0)]
        [TestCase(MethodDecodeJsonData, 0)]
        [TestCase(MethodReOrderAndSaveItem, 0)]
        public void AUT_WorkPlannerAPI_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workPlannerAPIInstanceFixture, 
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
        ///     Class (<see cref="WorkPlannerAPI" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkPlannerAPI_Is_Instance_Present_Test()
        {
            // Assert
            _workPlannerAPIInstanceType.ShouldNotBeNull();
            _workPlannerAPIInstance.ShouldNotBeNull();
            _workPlannerAPIInstanceFixture.ShouldNotBeNull();
            _workPlannerAPIInstance.ShouldBeAssignableTo<WorkPlannerAPI>();
            _workPlannerAPIInstanceFixture.ShouldBeAssignableTo<WorkPlannerAPI>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkPlannerAPI) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkPlannerAPI_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkPlannerAPI instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workPlannerAPIInstanceType.ShouldNotBeNull();
            _workPlannerAPIInstance.ShouldNotBeNull();
            _workPlannerAPIInstanceFixture.ShouldNotBeNull();
            _workPlannerAPIInstance.ShouldBeAssignableTo<WorkPlannerAPI>();
            _workPlannerAPIInstanceFixture.ShouldBeAssignableTo<WorkPlannerAPI>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workPlannerAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var Functionname = this.CreateType<string>();
            var Dataxml = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _workPlannerAPIInstance.Execute(Functionname, Dataxml);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var Functionname = this.CreateType<string>();
            var Dataxml = this.CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Functionname, Dataxml };
            Exception exception, exception1;
            var methodInfo = this.GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkPlannerAPI, string>(_workPlannerAPIInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkPlannerAPI, string>(_workPlannerAPIInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var Functionname = this.CreateType<string>();
            var Dataxml = this.CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Functionname, Dataxml };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfExecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var Functionname = this.CreateType<string>();
            var Dataxml = this.CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Functionname, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkPlannerAPI, string>(_workPlannerAPIInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workPlannerAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workPlannerAPIInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodExecute);
            var methodInfo = this.GetMethodInfo(MethodExecute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExternalTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, Fixture, methodGetExternalTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetExternalTasks(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalTasks = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalTasks, methodGetExternalTasksPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, Fixture, methodGetExternalTasksPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, parametersOfGetExternalTasks, methodGetExternalTasksPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetExternalTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExternalTasks.ShouldNotBeNull();
            parametersOfGetExternalTasks.Length.ShouldBe(2);
            methodGetExternalTasksPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalTasks = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, parametersOfGetExternalTasks, methodGetExternalTasksPrametersTypes);

            // Assert
            parametersOfGetExternalTasks.ShouldNotBeNull();
            parametersOfGetExternalTasks.Length.ShouldBe(2);
            methodGetExternalTasksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var methodGetExternalTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, Fixture, methodGetExternalTasksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExternalTasksPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var methodGetExternalTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalTasks, Fixture, methodGetExternalTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExternalTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExternalTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalTasks);
            var methodInfo = this.GetMethodInfo(MethodGetExternalTasks, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExternalProjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, Fixture, methodGetExternalProjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetExternalProjects(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalProjectsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalProjects = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalProjects, methodGetExternalProjectsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, Fixture, methodGetExternalProjectsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, parametersOfGetExternalProjects, methodGetExternalProjectsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetExternalProjects);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExternalProjects.ShouldNotBeNull();
            parametersOfGetExternalProjects.Length.ShouldBe(2);
            methodGetExternalProjectsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalProjectsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalProjects = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, parametersOfGetExternalProjects, methodGetExternalProjectsPrametersTypes);

            // Assert
            parametersOfGetExternalProjects.ShouldNotBeNull();
            parametersOfGetExternalProjects.Length.ShouldBe(2);
            methodGetExternalProjectsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var methodGetExternalProjectsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, Fixture, methodGetExternalProjectsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExternalProjectsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var methodGetExternalProjectsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalProjects, Fixture, methodGetExternalProjectsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExternalProjectsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalProjects, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExternalProjects) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalProjects_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalProjects);
            var methodInfo = this.GetMethodInfo(MethodGetExternalProjects, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodImportTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, Fixture, methodImportTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.ImportTasks(data, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodImportTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfImportTasks = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportTasks, methodImportTasksPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, Fixture, methodImportTasksPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, parametersOfImportTasks, methodImportTasksPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfImportTasks.ShouldNotBeNull();
            parametersOfImportTasks.Length.ShouldBe(2);
            methodImportTasksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, parametersOfImportTasks, methodImportTasksPrametersTypes));
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodImportTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfImportTasks = { data, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodImportTasks, methodImportTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfImportTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportTasks.ShouldNotBeNull();
            parametersOfImportTasks.Length.ShouldBe(2);
            methodImportTasksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodImportTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfImportTasks = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, parametersOfImportTasks, methodImportTasksPrametersTypes);

            // Assert
            parametersOfImportTasks.ShouldNotBeNull();
            parametersOfImportTasks.Length.ShouldBe(2);
            methodImportTasksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var methodImportTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, Fixture, methodImportTasksPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodImportTasksPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var methodImportTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasks, Fixture, methodImportTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodImportTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ImportTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasks);
            var methodInfo = this.GetMethodInfo(MethodImportTasks, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessTasks, Fixture, methodprocessTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_Void_With_11_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTasks);
            var ndImportTask = this.CreateType<XmlNode>();
            var docRet = this.CreateType<XmlDocument>();
            var ndParent = this.CreateType<XmlNode>();
            var docPlan = this.CreateType<XmlDocument>();
            var sUID = this.CreateType<string>();
            var arrCols = this.CreateType<ArrayList>();
            var bAllowDuplicates = this.CreateType<bool>();
            var curtaskuid = this.CreateType<int>();
            var sResField = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var sTaskType = this.CreateType<string>();
            var methodprocessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument), typeof(XmlNode), typeof(XmlDocument), typeof(string), typeof(ArrayList), typeof(bool), typeof(int), typeof(string), typeof(DataSet), typeof(string) };
            object[] parametersOfprocessTasks = { ndImportTask, docRet, ndParent, docPlan, sUID, arrCols, bAllowDuplicates, curtaskuid, sResField, dsResources, sTaskType };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodprocessTasks, methodprocessTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfprocessTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessTasks.ShouldNotBeNull();
            parametersOfprocessTasks.Length.ShouldBe(11);
            methodprocessTasksPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_Void_With_11_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTasks);
            var ndImportTask = this.CreateType<XmlNode>();
            var docRet = this.CreateType<XmlDocument>();
            var ndParent = this.CreateType<XmlNode>();
            var docPlan = this.CreateType<XmlDocument>();
            var sUID = this.CreateType<string>();
            var arrCols = this.CreateType<ArrayList>();
            var bAllowDuplicates = this.CreateType<bool>();
            var curtaskuid = this.CreateType<int>();
            var sResField = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var sTaskType = this.CreateType<string>();
            var methodprocessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument), typeof(XmlNode), typeof(XmlDocument), typeof(string), typeof(ArrayList), typeof(bool), typeof(int), typeof(string), typeof(DataSet), typeof(string) };
            object[] parametersOfprocessTasks = { ndImportTask, docRet, ndParent, docPlan, sUID, arrCols, bAllowDuplicates, curtaskuid, sResField, dsResources, sTaskType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessTasks, parametersOfprocessTasks, methodprocessTasksPrametersTypes);

            // Assert
            parametersOfprocessTasks.ShouldNotBeNull();
            parametersOfprocessTasks.Length.ShouldBe(11);
            methodprocessTasksPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTasks);
            var methodInfo = this.GetMethodInfo(MethodprocessTasks, 0);
            const int parametersCount = 11;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTasks);
            var methodprocessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument), typeof(XmlNode), typeof(XmlDocument), typeof(string), typeof(ArrayList), typeof(bool), typeof(int), typeof(string), typeof(DataSet), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessTasks, Fixture, methodprocessTasksPrametersTypes);

            // Assert
            methodprocessTasksPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTasks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processTasks_Static_Method_Call_With_11_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodprocessTasks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_Internally(Type[] types)
        {
            var methodbSpecialColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbSpecialColumn, Fixture, methodbSpecialColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbSpecialColumn);
            var sCol = this.CreateType<string>();
            var methodbSpecialColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbSpecialColumn = { sCol };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodbSpecialColumn, methodbSpecialColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfbSpecialColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbSpecialColumn.ShouldNotBeNull();
            parametersOfbSpecialColumn.Length.ShouldBe(1);
            methodbSpecialColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbSpecialColumn);
            var sCol = this.CreateType<string>();
            var methodbSpecialColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbSpecialColumn = { sCol };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbSpecialColumn, parametersOfbSpecialColumn, methodbSpecialColumnPrametersTypes);

            // Assert
            parametersOfbSpecialColumn.ShouldNotBeNull();
            parametersOfbSpecialColumn.Length.ShouldBe(1);
            methodbSpecialColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbSpecialColumn);
            var methodbSpecialColumnPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbSpecialColumn, Fixture, methodbSpecialColumnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodbSpecialColumnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbSpecialColumn);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodbSpecialColumn, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (bSpecialColumn) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bSpecialColumn_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbSpecialColumn);
            var methodInfo = this.GetMethodInfo(MethodbSpecialColumn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_Internally(Type[] types)
        {
            var methodImportTasksFixXmlStructurePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasksFixXmlStructure, Fixture, methodImportTasksFixXmlStructurePrametersTypes);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFixXmlStructure);
            var data = this.CreateType<XmlDocument>();
            var sUID = this.CreateType<string>();
            var sStructure = this.CreateType<string>();
            var methodImportTasksFixXmlStructurePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfImportTasksFixXmlStructure = { data, sUID, sStructure };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFixXmlStructure, methodImportTasksFixXmlStructurePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfImportTasksFixXmlStructure);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfImportTasksFixXmlStructure.ShouldNotBeNull();
            parametersOfImportTasksFixXmlStructure.Length.ShouldBe(3);
            methodImportTasksFixXmlStructurePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFixXmlStructure);
            var data = this.CreateType<XmlDocument>();
            var sUID = this.CreateType<string>();
            var sStructure = this.CreateType<string>();
            var methodImportTasksFixXmlStructurePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfImportTasksFixXmlStructure = { data, sUID, sStructure };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasksFixXmlStructure, parametersOfImportTasksFixXmlStructure, methodImportTasksFixXmlStructurePrametersTypes);

            // Assert
            parametersOfImportTasksFixXmlStructure.ShouldNotBeNull();
            parametersOfImportTasksFixXmlStructure.Length.ShouldBe(3);
            methodImportTasksFixXmlStructurePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFixXmlStructure);
            var methodInfo = this.GetMethodInfo(MethodImportTasksFixXmlStructure, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFixXmlStructure);
            var methodImportTasksFixXmlStructurePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodImportTasksFixXmlStructure, Fixture, methodImportTasksFixXmlStructurePrametersTypes);

            // Assert
            methodImportTasksFixXmlStructurePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportTasksFixXmlStructure) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ImportTasksFixXmlStructure_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodImportTasksFixXmlStructure);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodImportTasksFixXmlStructure, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPlannersByProjectListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, Fixture, methodGetPlannersByProjectListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var projectList = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetPlannersByProjectList(projectList, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var projectList = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var methodGetPlannersByProjectListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetPlannersByProjectList = { projectList, web };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByProjectList, methodGetPlannersByProjectListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, Fixture, methodGetPlannersByProjectListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, parametersOfGetPlannersByProjectList, methodGetPlannersByProjectListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetPlannersByProjectList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPlannersByProjectList.ShouldNotBeNull();
            parametersOfGetPlannersByProjectList.Length.ShouldBe(2);
            methodGetPlannersByProjectListPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var projectList = this.CreateType<string>();
            var web = this.CreateType<SPWeb>();
            var methodGetPlannersByProjectListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetPlannersByProjectList = { projectList, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, parametersOfGetPlannersByProjectList, methodGetPlannersByProjectListPrametersTypes);

            // Assert
            parametersOfGetPlannersByProjectList.ShouldNotBeNull();
            parametersOfGetPlannersByProjectList.Length.ShouldBe(2);
            methodGetPlannersByProjectListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var methodGetPlannersByProjectListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, Fixture, methodGetPlannersByProjectListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPlannersByProjectListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var methodGetPlannersByProjectListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByProjectList, Fixture, methodGetPlannersByProjectListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPlannersByProjectListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByProjectList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPlannersByProjectList) (Return Type : SortedList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByProjectList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByProjectList);
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByProjectList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPlannersByTaskListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, Fixture, methodGetPlannersByTaskListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var web = this.CreateType<SPWeb>();
            var taskList = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetPlannersByTaskList(web, taskList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var web = this.CreateType<SPWeb>();
            var taskList = this.CreateType<string>();
            var methodGetPlannersByTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetPlannersByTaskList = { web, taskList };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByTaskList, methodGetPlannersByTaskListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, Fixture, methodGetPlannersByTaskListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, parametersOfGetPlannersByTaskList, methodGetPlannersByTaskListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetPlannersByTaskList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPlannersByTaskList.ShouldNotBeNull();
            parametersOfGetPlannersByTaskList.Length.ShouldBe(2);
            methodGetPlannersByTaskListPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var web = this.CreateType<SPWeb>();
            var taskList = this.CreateType<string>();
            var methodGetPlannersByTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetPlannersByTaskList = { web, taskList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SortedList>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, parametersOfGetPlannersByTaskList, methodGetPlannersByTaskListPrametersTypes);

            // Assert
            parametersOfGetPlannersByTaskList.ShouldNotBeNull();
            parametersOfGetPlannersByTaskList.Length.ShouldBe(2);
            methodGetPlannersByTaskListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var methodGetPlannersByTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, Fixture, methodGetPlannersByTaskListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPlannersByTaskListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var methodGetPlannersByTaskListPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetPlannersByTaskList, Fixture, methodGetPlannersByTaskListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPlannersByTaskListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByTaskList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPlannersByTaskList) (Return Type : SortedList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetPlannersByTaskList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetPlannersByTaskList);
            var methodInfo = this.GetMethodInfo(MethodGetPlannersByTaskList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdateDetailLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, Fixture, methodGetUpdateDetailLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetUpdateDetailLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetUpdateDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetUpdateDetailLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetUpdateDetailLayout, methodGetUpdateDetailLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, Fixture, methodGetUpdateDetailLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, parametersOfGetUpdateDetailLayout, methodGetUpdateDetailLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetUpdateDetailLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUpdateDetailLayout.ShouldNotBeNull();
            parametersOfGetUpdateDetailLayout.Length.ShouldBe(2);
            methodGetUpdateDetailLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetUpdateDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetUpdateDetailLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, parametersOfGetUpdateDetailLayout, methodGetUpdateDetailLayoutPrametersTypes);

            // Assert
            parametersOfGetUpdateDetailLayout.ShouldNotBeNull();
            parametersOfGetUpdateDetailLayout.Length.ShouldBe(2);
            methodGetUpdateDetailLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var methodGetUpdateDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, Fixture, methodGetUpdateDetailLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdateDetailLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var methodGetUpdateDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdateDetailLayout, Fixture, methodGetUpdateDetailLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdateDetailLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetUpdateDetailLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUpdateDetailLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdateDetailLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdateDetailLayout);
            var methodInfo = this.GetMethodInfo(MethodGetUpdateDetailLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, Fixture, methodSaveProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.SaveProject(data, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveProjectPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveProject = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveProject, methodSaveProjectPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, Fixture, methodSaveProjectPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, parametersOfSaveProject, methodSaveProjectPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfSaveProject.ShouldNotBeNull();
            parametersOfSaveProject.Length.ShouldBe(2);
            methodSaveProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, parametersOfSaveProject, methodSaveProjectPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveProjectPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveProject = { data, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodSaveProject, methodSaveProjectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfSaveProject);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveProject.ShouldNotBeNull();
            parametersOfSaveProject.Length.ShouldBe(2);
            methodSaveProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveProjectPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveProject = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, parametersOfSaveProject, methodSaveProjectPrametersTypes);

            // Assert
            parametersOfSaveProject.ShouldNotBeNull();
            parametersOfSaveProject.Length.ShouldBe(2);
            methodSaveProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var methodSaveProjectPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, Fixture, methodSaveProjectPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveProjectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var methodSaveProjectPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveProject, Fixture, methodSaveProjectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveProjectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveProject, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SaveProject) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveProject_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveProject);
            var methodInfo = this.GetMethodInfo(MethodSaveProject, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveAgilePlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, Fixture, methodSaveAgilePlanPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.SaveAgilePlan(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveAgilePlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveAgilePlan = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveAgilePlan, methodSaveAgilePlanPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, Fixture, methodSaveAgilePlanPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, parametersOfSaveAgilePlan, methodSaveAgilePlanPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfSaveAgilePlan);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveAgilePlan.ShouldNotBeNull();
            parametersOfSaveAgilePlan.Length.ShouldBe(2);
            methodSaveAgilePlanPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveAgilePlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveAgilePlan = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, parametersOfSaveAgilePlan, methodSaveAgilePlanPrametersTypes);

            // Assert
            parametersOfSaveAgilePlan.ShouldNotBeNull();
            parametersOfSaveAgilePlan.Length.ShouldBe(2);
            methodSaveAgilePlanPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var methodSaveAgilePlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, Fixture, methodSaveAgilePlanPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveAgilePlanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var methodSaveAgilePlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveAgilePlan, Fixture, methodSaveAgilePlanPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveAgilePlanPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveAgilePlan, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveAgilePlan) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveAgilePlan_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveAgilePlan);
            var methodInfo = this.GetMethodInfo(MethodSaveAgilePlan, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveWorkPlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, Fixture, methodSaveWorkPlanPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.SaveWorkPlan(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveWorkPlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveWorkPlan = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveWorkPlan, methodSaveWorkPlanPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, Fixture, methodSaveWorkPlanPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, parametersOfSaveWorkPlan, methodSaveWorkPlanPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfSaveWorkPlan);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveWorkPlan.ShouldNotBeNull();
            parametersOfSaveWorkPlan.Length.ShouldBe(2);
            methodSaveWorkPlanPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveWorkPlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveWorkPlan = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, parametersOfSaveWorkPlan, methodSaveWorkPlanPrametersTypes);

            // Assert
            parametersOfSaveWorkPlan.ShouldNotBeNull();
            parametersOfSaveWorkPlan.Length.ShouldBe(2);
            methodSaveWorkPlanPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var methodSaveWorkPlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, Fixture, methodSaveWorkPlanPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveWorkPlanPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var methodSaveWorkPlanPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveWorkPlan, Fixture, methodSaveWorkPlanPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveWorkPlanPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveWorkPlan, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveWorkPlan) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveWorkPlan_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveWorkPlan);
            var methodInfo = this.GetMethodInfo(MethodSaveWorkPlan, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodStrToByteArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var str = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.StrToByteArray(str);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var str = this.CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodStrToByteArray, methodStrToByteArrayPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, parametersOfStrToByteArray, methodStrToByteArrayPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, parametersOfStrToByteArray, methodStrToByteArrayPrametersTypes));
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var str = this.CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodStrToByteArray, methodStrToByteArrayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfStrToByteArray);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var str = this.CreateType<string>();
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStrToByteArray = { str };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<byte[]>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, parametersOfStrToByteArray, methodStrToByteArrayPrametersTypes);

            // Assert
            parametersOfStrToByteArray.ShouldNotBeNull();
            parametersOfStrToByteArray.Length.ShouldBe(1);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var methodStrToByteArrayPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodStrToByteArray, Fixture, methodStrToByteArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStrToByteArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodStrToByteArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StrToByteArray) (Return Type : byte[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_StrToByteArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodStrToByteArray);
            var methodInfo = this.GetMethodInfo(MethodStrToByteArray, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpgradeProjectScheduleLibraryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodUpgradeProjectScheduleLibrary, Fixture, methodUpgradeProjectScheduleLibraryPrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            var oFile = this.CreateType<SPFile>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.UpgradeProjectScheduleLibrary(web, id, planner, oFile);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            var oFile = this.CreateType<SPFile>();
            var methodUpgradeProjectScheduleLibraryPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPFile) };
            object[] parametersOfUpgradeProjectScheduleLibrary = { web, id, planner, oFile };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodUpgradeProjectScheduleLibrary, methodUpgradeProjectScheduleLibraryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfUpgradeProjectScheduleLibrary);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpgradeProjectScheduleLibrary.ShouldNotBeNull();
            parametersOfUpgradeProjectScheduleLibrary.Length.ShouldBe(4);
            methodUpgradeProjectScheduleLibraryPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            var oFile = this.CreateType<SPFile>();
            var methodUpgradeProjectScheduleLibraryPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPFile) };
            object[] parametersOfUpgradeProjectScheduleLibrary = { web, id, planner, oFile };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodUpgradeProjectScheduleLibrary, parametersOfUpgradeProjectScheduleLibrary, methodUpgradeProjectScheduleLibraryPrametersTypes);

            // Assert
            parametersOfUpgradeProjectScheduleLibrary.ShouldNotBeNull();
            parametersOfUpgradeProjectScheduleLibrary.Length.ShouldBe(4);
            methodUpgradeProjectScheduleLibraryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            var methodInfo = this.GetMethodInfo(MethodUpgradeProjectScheduleLibrary, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            var methodUpgradeProjectScheduleLibraryPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPFile) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodUpgradeProjectScheduleLibrary, Fixture, methodUpgradeProjectScheduleLibraryPrametersTypes);

            // Assert
            methodUpgradeProjectScheduleLibraryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeProjectScheduleLibrary) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_UpgradeProjectScheduleLibrary_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodUpgradeProjectScheduleLibrary);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodUpgradeProjectScheduleLibrary, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_Internally(Type[] types)
        {
            var methodiApplyNewTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiApplyNewTemplate, Fixture, methodiApplyNewTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiApplyNewTemplate);
            var web = this.CreateType<SPWeb>();
            var lWeb = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var templateid = this.CreateType<string>();
            var itemid = this.CreateType<string>();
            var type = this.CreateType<string>();
            var projectname = this.CreateType<string>();
            var methodiApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfiApplyNewTemplate = { web, lWeb, planner, templateid, itemid, type, projectname };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodiApplyNewTemplate, methodiApplyNewTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfiApplyNewTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiApplyNewTemplate.ShouldNotBeNull();
            parametersOfiApplyNewTemplate.Length.ShouldBe(7);
            methodiApplyNewTemplatePrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiApplyNewTemplate);
            var web = this.CreateType<SPWeb>();
            var lWeb = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var templateid = this.CreateType<string>();
            var itemid = this.CreateType<string>();
            var type = this.CreateType<string>();
            var projectname = this.CreateType<string>();
            var methodiApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfiApplyNewTemplate = { web, lWeb, planner, templateid, itemid, type, projectname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiApplyNewTemplate, parametersOfiApplyNewTemplate, methodiApplyNewTemplatePrametersTypes);

            // Assert
            parametersOfiApplyNewTemplate.ShouldNotBeNull();
            parametersOfiApplyNewTemplate.Length.ShouldBe(7);
            methodiApplyNewTemplatePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiApplyNewTemplate);
            var methodInfo = this.GetMethodInfo(MethodiApplyNewTemplate, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiApplyNewTemplate);
            var methodiApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiApplyNewTemplate, Fixture, methodiApplyNewTemplatePrametersTypes);

            // Assert
            methodiApplyNewTemplatePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iApplyNewTemplate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iApplyNewTemplate_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiApplyNewTemplate);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiApplyNewTemplate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_Internally(Type[] types)
        {
            var methodApplyNewTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodApplyNewTemplate, Fixture, methodApplyNewTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var templateid = this.CreateType<string>();
            var itemid = this.CreateType<string>();
            var type = this.CreateType<string>();
            var projectname = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.ApplyNewTemplate(web, planner, templateid, itemid, type, projectname);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var templateid = this.CreateType<string>();
            var itemid = this.CreateType<string>();
            var type = this.CreateType<string>();
            var projectname = this.CreateType<string>();
            var methodApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfApplyNewTemplate = { web, planner, templateid, itemid, type, projectname };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodApplyNewTemplate, methodApplyNewTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfApplyNewTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyNewTemplate.ShouldNotBeNull();
            parametersOfApplyNewTemplate.Length.ShouldBe(6);
            methodApplyNewTemplatePrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var templateid = this.CreateType<string>();
            var itemid = this.CreateType<string>();
            var type = this.CreateType<string>();
            var projectname = this.CreateType<string>();
            var methodApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfApplyNewTemplate = { web, planner, templateid, itemid, type, projectname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodApplyNewTemplate, parametersOfApplyNewTemplate, methodApplyNewTemplatePrametersTypes);

            // Assert
            parametersOfApplyNewTemplate.ShouldNotBeNull();
            parametersOfApplyNewTemplate.Length.ShouldBe(6);
            methodApplyNewTemplatePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            var methodInfo = this.GetMethodInfo(MethodApplyNewTemplate, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            var methodApplyNewTemplatePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodApplyNewTemplate, Fixture, methodApplyNewTemplatePrametersTypes);

            // Assert
            methodApplyNewTemplatePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyNewTemplate) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ApplyNewTemplate_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodApplyNewTemplate);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodApplyNewTemplate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLIFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetLIField, Fixture, methodgetLIFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            var li = this.CreateType<SPListItem>();
            var Field = this.CreateType<string>();
            var methodgetLIFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfgetLIField = { li, Field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetLIField, methodgetLIFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetLIField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLIField.ShouldNotBeNull();
            parametersOfgetLIField.Length.ShouldBe(2);
            methodgetLIFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            var li = this.CreateType<SPListItem>();
            var Field = this.CreateType<string>();
            var methodgetLIFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            object[] parametersOfgetLIField = { li, Field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetLIField, parametersOfgetLIField, methodgetLIFieldPrametersTypes);

            // Assert
            parametersOfgetLIField.ShouldNotBeNull();
            parametersOfgetLIField.Length.ShouldBe(2);
            methodgetLIFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            var methodgetLIFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetLIField, Fixture, methodgetLIFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLIFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            var methodgetLIFieldPrametersTypes = new Type[] { typeof(SPListItem), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetLIField, Fixture, methodgetLIFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLIFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetLIField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getLIField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getLIField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetLIField);
            var methodInfo = this.GetMethodInfo(MethodgetLIField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetTemplatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetTemplates, Fixture, methodiGetTemplatesPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var type = this.CreateType<string>();
            var methodiGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfiGetTemplates = { web, planner, type };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodiGetTemplates, methodiGetTemplatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfiGetTemplates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetTemplates.ShouldNotBeNull();
            parametersOfiGetTemplates.Length.ShouldBe(3);
            methodiGetTemplatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var type = this.CreateType<string>();
            var methodiGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfiGetTemplates = { web, planner, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetTemplates, parametersOfiGetTemplates, methodiGetTemplatesPrametersTypes);

            // Assert
            parametersOfiGetTemplates.ShouldNotBeNull();
            parametersOfiGetTemplates.Length.ShouldBe(3);
            methodiGetTemplatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            var methodiGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetTemplates, Fixture, methodiGetTemplatesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetTemplatesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            var methodiGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetTemplates, Fixture, methodiGetTemplatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetTemplatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiGetTemplates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetTemplates) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetTemplates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetTemplates);
            var methodInfo = this.GetMethodInfo(MethodiGetTemplates, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_Internally(Type[] types)
        {
            var methodiSaveTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, Fixture, methodiSaveTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            var sPlannerId = this.CreateType<string>();
            var sTemplateName = this.CreateType<string>();
            var sDescription = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodiSaveTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfiSaveTemplate = { sPlannerId, sTemplateName, sDescription, data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiSaveTemplate, methodiSaveTemplatePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, Fixture, methodiSaveTemplatePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, parametersOfiSaveTemplate, methodiSaveTemplatePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfiSaveTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiSaveTemplate.ShouldNotBeNull();
            parametersOfiSaveTemplate.Length.ShouldBe(5);
            methodiSaveTemplatePrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            var sPlannerId = this.CreateType<string>();
            var sTemplateName = this.CreateType<string>();
            var sDescription = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodiSaveTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfiSaveTemplate = { sPlannerId, sTemplateName, sDescription, data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, parametersOfiSaveTemplate, methodiSaveTemplatePrametersTypes);

            // Assert
            parametersOfiSaveTemplate.ShouldNotBeNull();
            parametersOfiSaveTemplate.Length.ShouldBe(5);
            methodiSaveTemplatePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            var methodiSaveTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, Fixture, methodiSaveTemplatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiSaveTemplatePrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            var methodiSaveTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiSaveTemplate, Fixture, methodiSaveTemplatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiSaveTemplatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiSaveTemplate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iSaveTemplate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iSaveTemplate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiSaveTemplate);
            var methodInfo = this.GetMethodInfo(MethodiSaveTemplate, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, Fixture, methodSaveTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.SaveTemplate(data, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveTemplatePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveTemplate = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveTemplate, methodSaveTemplatePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, Fixture, methodSaveTemplatePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, parametersOfSaveTemplate, methodSaveTemplatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfSaveTemplate.ShouldNotBeNull();
            parametersOfSaveTemplate.Length.ShouldBe(2);
            methodSaveTemplatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, parametersOfSaveTemplate, methodSaveTemplatePrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveTemplatePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveTemplate = { data, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodSaveTemplate, methodSaveTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfSaveTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveTemplate.ShouldNotBeNull();
            parametersOfSaveTemplate.Length.ShouldBe(2);
            methodSaveTemplatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodSaveTemplatePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfSaveTemplate = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, parametersOfSaveTemplate, methodSaveTemplatePrametersTypes);

            // Assert
            parametersOfSaveTemplate.ShouldNotBeNull();
            parametersOfSaveTemplate.Length.ShouldBe(2);
            methodSaveTemplatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var methodSaveTemplatePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, Fixture, methodSaveTemplatePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveTemplatePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var methodSaveTemplatePrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSaveTemplate, Fixture, methodSaveTemplatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTemplatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSaveTemplate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SaveTemplate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SaveTemplate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSaveTemplate);
            var methodInfo = this.GetMethodInfo(MethodSaveTemplate, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTemplatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, Fixture, methodGetTemplatesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var type = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetTemplates(web, planner, type);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var type = this.CreateType<string>();
            var methodGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTemplates = { web, planner, type };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTemplates, methodGetTemplatesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, Fixture, methodGetTemplatesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, parametersOfGetTemplates, methodGetTemplatesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetTemplates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTemplates.ShouldNotBeNull();
            parametersOfGetTemplates.Length.ShouldBe(3);
            methodGetTemplatesPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var type = this.CreateType<string>();
            var methodGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTemplates = { web, planner, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, parametersOfGetTemplates, methodGetTemplatesPrametersTypes);

            // Assert
            parametersOfGetTemplates.ShouldNotBeNull();
            parametersOfGetTemplates.Length.ShouldBe(3);
            methodGetTemplatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var methodGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, Fixture, methodGetTemplatesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTemplatesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var methodGetTemplatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTemplates, Fixture, methodGetTemplatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTemplatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTemplates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTemplates) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTemplates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTemplates);
            var methodInfo = this.GetMethodInfo(MethodGetTemplates, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTaskFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetTaskFile(web, id, planner);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTaskFile = { web, id, planner };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTaskFile, methodGetTaskFilePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, parametersOfGetTaskFile, methodGetTaskFilePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetTaskFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTaskFile.ShouldNotBeNull();
            parametersOfGetTaskFile.Length.ShouldBe(3);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var web = this.CreateType<SPWeb>();
            var id = this.CreateType<string>();
            var planner = this.CreateType<string>();
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetTaskFile = { web, id, planner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPFile>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, parametersOfGetTaskFile, methodGetTaskFilePrametersTypes);

            // Assert
            parametersOfGetTaskFile.ShouldNotBeNull();
            parametersOfGetTaskFile.Length.ShouldBe(3);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTaskFilePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var methodGetTaskFilePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTaskFile, Fixture, methodGetTaskFilePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTaskFilePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTaskFile, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTaskFile) (Return Type : SPFile) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTaskFile_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTaskFile);
            var methodInfo = this.GetMethodInfo(MethodGetTaskFile, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessTaskXmlFromTaskCenterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, Fixture, methodProcessTaskXmlFromTaskCenterPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            var doc = this.CreateType<XmlDocument>();
            var props = this.CreateType<PlannerProps>();
            var web = this.CreateType<SPWeb>();
            var projectid = this.CreateType<string>();
            var lastid = this.CreateType<int>();
            var methodProcessTaskXmlFromTaskCenterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(PlannerProps), typeof(SPWeb), typeof(string), typeof(int) };
            object[] parametersOfProcessTaskXmlFromTaskCenter = { doc, props, web, projectid, lastid };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessTaskXmlFromTaskCenter, methodProcessTaskXmlFromTaskCenterPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, Fixture, methodProcessTaskXmlFromTaskCenterPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, parametersOfProcessTaskXmlFromTaskCenter, methodProcessTaskXmlFromTaskCenterPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfProcessTaskXmlFromTaskCenter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProcessTaskXmlFromTaskCenter.ShouldNotBeNull();
            parametersOfProcessTaskXmlFromTaskCenter.Length.ShouldBe(5);
            methodProcessTaskXmlFromTaskCenterPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            var doc = this.CreateType<XmlDocument>();
            var props = this.CreateType<PlannerProps>();
            var web = this.CreateType<SPWeb>();
            var projectid = this.CreateType<string>();
            var lastid = this.CreateType<int>();
            var methodProcessTaskXmlFromTaskCenterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(PlannerProps), typeof(SPWeb), typeof(string), typeof(int) };
            object[] parametersOfProcessTaskXmlFromTaskCenter = { doc, props, web, projectid, lastid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, parametersOfProcessTaskXmlFromTaskCenter, methodProcessTaskXmlFromTaskCenterPrametersTypes);

            // Assert
            parametersOfProcessTaskXmlFromTaskCenter.ShouldNotBeNull();
            parametersOfProcessTaskXmlFromTaskCenter.Length.ShouldBe(5);
            methodProcessTaskXmlFromTaskCenterPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            var methodProcessTaskXmlFromTaskCenterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(PlannerProps), typeof(SPWeb), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, Fixture, methodProcessTaskXmlFromTaskCenterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessTaskXmlFromTaskCenterPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            var methodProcessTaskXmlFromTaskCenterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(PlannerProps), typeof(SPWeb), typeof(string), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessTaskXmlFromTaskCenter, Fixture, methodProcessTaskXmlFromTaskCenterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessTaskXmlFromTaskCenterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessTaskXmlFromTaskCenter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessTaskXmlFromTaskCenter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessTaskXmlFromTaskCenter_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessTaskXmlFromTaskCenter);
            var methodInfo = this.GetMethodInfo(MethodProcessTaskXmlFromTaskCenter, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, Fixture, methodGetTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetTasks(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetTasks = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTasks, methodGetTasksPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, Fixture, methodGetTasksPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, parametersOfGetTasks, methodGetTasksPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTasks.ShouldNotBeNull();
            parametersOfGetTasks.Length.ShouldBe(2);
            methodGetTasksPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetTasks = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, parametersOfGetTasks, methodGetTasksPrametersTypes);

            // Assert
            parametersOfGetTasks.ShouldNotBeNull();
            parametersOfGetTasks.Length.ShouldBe(2);
            methodGetTasksPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var methodGetTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, Fixture, methodGetTasksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTasksPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var methodGetTasksPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetTasks, Fixture, methodGetTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetTasks);
            var methodInfo = this.GetMethodInfo(MethodGetTasks, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessExternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, Fixture, methodProcessExternalPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            var doc = this.CreateType<XmlDocument>();
            var oListTaskCenter = this.CreateType<SPList>();
            var predsucc = this.CreateType<string>();
            var projectid = this.CreateType<string>();
            var plannerid = this.CreateType<string>();
            var before = this.CreateType<bool>();
            var dsResources = this.CreateType<DataSet>();
            var ndTaskLinkedTO = this.CreateType<XmlNode>();
            var bLinked = this.CreateType<bool>();
            var curtaskid = this.CreateType<string>();
            var lastid = this.CreateType<int>();
            var methodProcessExternalPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(DataSet), typeof(XmlNode), typeof(bool), typeof(string), typeof(int) };
            object[] parametersOfProcessExternal = { doc, oListTaskCenter, predsucc, projectid, plannerid, before, dsResources, ndTaskLinkedTO, bLinked, curtaskid, lastid };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessExternal, methodProcessExternalPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, Fixture, methodProcessExternalPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, parametersOfProcessExternal, methodProcessExternalPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfProcessExternal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProcessExternal.ShouldNotBeNull();
            parametersOfProcessExternal.Length.ShouldBe(11);
            methodProcessExternalPrametersTypes.Length.ShouldBe(11);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            var doc = this.CreateType<XmlDocument>();
            var oListTaskCenter = this.CreateType<SPList>();
            var predsucc = this.CreateType<string>();
            var projectid = this.CreateType<string>();
            var plannerid = this.CreateType<string>();
            var before = this.CreateType<bool>();
            var dsResources = this.CreateType<DataSet>();
            var ndTaskLinkedTO = this.CreateType<XmlNode>();
            var bLinked = this.CreateType<bool>();
            var curtaskid = this.CreateType<string>();
            var lastid = this.CreateType<int>();
            var methodProcessExternalPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(DataSet), typeof(XmlNode), typeof(bool), typeof(string), typeof(int) };
            object[] parametersOfProcessExternal = { doc, oListTaskCenter, predsucc, projectid, plannerid, before, dsResources, ndTaskLinkedTO, bLinked, curtaskid, lastid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, parametersOfProcessExternal, methodProcessExternalPrametersTypes);

            // Assert
            parametersOfProcessExternal.ShouldNotBeNull();
            parametersOfProcessExternal.Length.ShouldBe(11);
            methodProcessExternalPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            var methodProcessExternalPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(DataSet), typeof(XmlNode), typeof(bool), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, Fixture, methodProcessExternalPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessExternalPrametersTypes.Length.ShouldBe(11);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            var methodProcessExternalPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPList), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(DataSet), typeof(XmlNode), typeof(bool), typeof(string), typeof(int) };
            const int parametersCount = 11;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessExternal, Fixture, methodProcessExternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessExternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessExternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessExternal) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessExternal_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessExternal);
            var methodInfo = this.GetMethodInfo(MethodProcessExternal, 0);
            const int parametersCount = 11;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_Internally(Type[] types)
        {
            var methodbIsSpecialExternalFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbIsSpecialExternalField, Fixture, methodbIsSpecialExternalFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbIsSpecialExternalField);
            var field = this.CreateType<string>();
            var methodbIsSpecialExternalFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbIsSpecialExternalField = { field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodbIsSpecialExternalField, methodbIsSpecialExternalFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfbIsSpecialExternalField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbIsSpecialExternalField.ShouldNotBeNull();
            parametersOfbIsSpecialExternalField.Length.ShouldBe(1);
            methodbIsSpecialExternalFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbIsSpecialExternalField);
            var field = this.CreateType<string>();
            var methodbIsSpecialExternalFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbIsSpecialExternalField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbIsSpecialExternalField, parametersOfbIsSpecialExternalField, methodbIsSpecialExternalFieldPrametersTypes);

            // Assert
            parametersOfbIsSpecialExternalField.ShouldNotBeNull();
            parametersOfbIsSpecialExternalField.Length.ShouldBe(1);
            methodbIsSpecialExternalFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbIsSpecialExternalField);
            var methodbIsSpecialExternalFieldPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodbIsSpecialExternalField, Fixture, methodbIsSpecialExternalFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodbIsSpecialExternalFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbIsSpecialExternalField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodbIsSpecialExternalField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (bIsSpecialExternalField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_bIsSpecialExternalField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodbIsSpecialExternalField);
            var methodInfo = this.GetMethodInfo(MethodbIsSpecialExternalField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExternalLinkLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, Fixture, methodGetExternalLinkLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetExternalLinkLayout(data, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalLinkLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalLinkLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalLinkLayout, methodGetExternalLinkLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, Fixture, methodGetExternalLinkLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, parametersOfGetExternalLinkLayout, methodGetExternalLinkLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetExternalLinkLayout.ShouldNotBeNull();
            parametersOfGetExternalLinkLayout.Length.ShouldBe(2);
            methodGetExternalLinkLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, parametersOfGetExternalLinkLayout, methodGetExternalLinkLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalLinkLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalLinkLayout = { data, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetExternalLinkLayout, methodGetExternalLinkLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetExternalLinkLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetExternalLinkLayout.ShouldNotBeNull();
            parametersOfGetExternalLinkLayout.Length.ShouldBe(2);
            methodGetExternalLinkLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetExternalLinkLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetExternalLinkLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, parametersOfGetExternalLinkLayout, methodGetExternalLinkLayoutPrametersTypes);

            // Assert
            parametersOfGetExternalLinkLayout.ShouldNotBeNull();
            parametersOfGetExternalLinkLayout.Length.ShouldBe(2);
            methodGetExternalLinkLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var methodGetExternalLinkLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, Fixture, methodGetExternalLinkLayoutPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetExternalLinkLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var methodGetExternalLinkLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetExternalLinkLayout, Fixture, methodGetExternalLinkLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExternalLinkLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetExternalLinkLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetExternalLinkLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetExternalLinkLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetExternalLinkLayout);
            var methodInfo = this.GetMethodInfo(MethodGetExternalLinkLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddCustomFooterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAddCustomFooter, Fixture, methodAddCustomFooterPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddCustomFooter);
            var doc = this.CreateType<XmlDocument>();
            var id = this.CreateType<string>();
            var title = this.CreateType<string>();
            var methodAddCustomFooterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfAddCustomFooter = { doc, id, title };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodAddCustomFooter, methodAddCustomFooterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfAddCustomFooter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddCustomFooter.ShouldNotBeNull();
            parametersOfAddCustomFooter.Length.ShouldBe(3);
            methodAddCustomFooterPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddCustomFooter);
            var doc = this.CreateType<XmlDocument>();
            var id = this.CreateType<string>();
            var title = this.CreateType<string>();
            var methodAddCustomFooterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfAddCustomFooter = { doc, id, title };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAddCustomFooter, parametersOfAddCustomFooter, methodAddCustomFooterPrametersTypes);

            // Assert
            parametersOfAddCustomFooter.ShouldNotBeNull();
            parametersOfAddCustomFooter.Length.ShouldBe(3);
            methodAddCustomFooterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddCustomFooter);
            var methodInfo = this.GetMethodInfo(MethodAddCustomFooter, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddCustomFooter);
            var methodAddCustomFooterPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAddCustomFooter, Fixture, methodAddCustomFooterPrametersTypes);

            // Assert
            methodAddCustomFooterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddCustomFooter) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AddCustomFooter_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAddCustomFooter);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodAddCustomFooter, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetUpdates(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetUpdates = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetUpdates, methodGetUpdatesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, parametersOfGetUpdates, methodGetUpdatesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetUpdates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUpdates.ShouldNotBeNull();
            parametersOfGetUpdates.Length.ShouldBe(2);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetUpdates = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, parametersOfGetUpdates, methodGetUpdatesPrametersTypes);

            // Assert
            parametersOfGetUpdates.ShouldNotBeNull();
            parametersOfGetUpdates.Length.ShouldBe(2);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdatesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetUpdates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetUpdates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetUpdates);
            var methodInfo = this.GetMethodInfo(MethodGetUpdates, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var field = this.CreateType<string>();
            var value = this.CreateType<string>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldValue = { field, value };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(2);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var field = this.CreateType<string>();
            var value = this.CreateType<string>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetFieldValue = { field, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(2);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var nd = this.CreateType<XmlNode>();
            var attribute = this.CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, methodgetAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var nd = this.CreateType<XmlNode>();
            var attribute = this.CreateType<string>();
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfgetAttribute = { nd, attribute };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetAttribute, parametersOfgetAttribute, methodgetAttributePrametersTypes);

            // Assert
            parametersOfgetAttribute.ShouldNotBeNull();
            parametersOfgetAttribute.Length.ShouldBe(2);
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodgetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetAttribute, Fixture, methodgetAttributePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAttributePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getAttribute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getAttribute_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetAttribute);
            var methodInfo = this.GetMethodInfo(MethodgetAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishProcessTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTasks, Fixture, methodPublishProcessTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTasks);
            var ndFolder = this.CreateType<XmlNode>();
            var parentfolderpath = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var iteration = this.CreateType<string>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };
            object[] parametersOfPublishProcessTasks = { ndFolder, parentfolderpath, data, oTaskCenter, dsResources, iteration, props };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTasks, methodPublishProcessTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishProcessTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishProcessTasks.ShouldNotBeNull();
            parametersOfPublishProcessTasks.Length.ShouldBe(7);
            methodPublishProcessTasksPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTasks);
            var ndFolder = this.CreateType<XmlNode>();
            var parentfolderpath = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var iteration = this.CreateType<string>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };
            object[] parametersOfPublishProcessTasks = { ndFolder, parentfolderpath, data, oTaskCenter, dsResources, iteration, props };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTasks, parametersOfPublishProcessTasks, methodPublishProcessTasksPrametersTypes);

            // Assert
            parametersOfPublishProcessTasks.ShouldNotBeNull();
            parametersOfPublishProcessTasks.Length.ShouldBe(7);
            methodPublishProcessTasksPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTasks);
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTasks, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTasks);
            var methodPublishProcessTasksPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTasks, Fixture, methodPublishProcessTasksPrametersTypes);

            // Assert
            methodPublishProcessTasksPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTasks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTasks_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTasks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishProcessTaskPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTask, Fixture, methodPublishProcessTaskPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTask);
            var ndTask = this.CreateType<XmlNode>();
            var parentfolder = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var iteration = this.CreateType<string>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };
            object[] parametersOfPublishProcessTask = { ndTask, parentfolder, data, oTaskCenter, dsResources, iteration, props };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTask, methodPublishProcessTaskPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishProcessTask);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishProcessTask.ShouldNotBeNull();
            parametersOfPublishProcessTask.Length.ShouldBe(7);
            methodPublishProcessTaskPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTask);
            var ndTask = this.CreateType<XmlNode>();
            var parentfolder = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var iteration = this.CreateType<string>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };
            object[] parametersOfPublishProcessTask = { ndTask, parentfolder, data, oTaskCenter, dsResources, iteration, props };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTask, parametersOfPublishProcessTask, methodPublishProcessTaskPrametersTypes);

            // Assert
            parametersOfPublishProcessTask.ShouldNotBeNull();
            parametersOfPublishProcessTask.Length.ShouldBe(7);
            methodPublishProcessTaskPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTask);
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTask, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTask);
            var methodPublishProcessTaskPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(string), typeof(PlannerProps) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessTask, Fixture, methodPublishProcessTaskPrametersTypes);

            // Assert
            methodPublishProcessTaskPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessTask) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessTask_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessTask);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessTask, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishGetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishGetFieldValue, Fixture, methodPublishGetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            var field = this.CreateType<string>();
            var ndTask = this.CreateType<XmlNode>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var methodPublishGetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(XmlNode), typeof(SPList), typeof(DataSet) };
            object[] parametersOfPublishGetFieldValue = { field, ndTask, oTaskCenter, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishGetFieldValue, methodPublishGetFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishGetFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishGetFieldValue.ShouldNotBeNull();
            parametersOfPublishGetFieldValue.Length.ShouldBe(4);
            methodPublishGetFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            var field = this.CreateType<string>();
            var ndTask = this.CreateType<XmlNode>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var methodPublishGetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(XmlNode), typeof(SPList), typeof(DataSet) };
            object[] parametersOfPublishGetFieldValue = { field, ndTask, oTaskCenter, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishGetFieldValue, parametersOfPublishGetFieldValue, methodPublishGetFieldValuePrametersTypes);

            // Assert
            parametersOfPublishGetFieldValue.ShouldNotBeNull();
            parametersOfPublishGetFieldValue.Length.ShouldBe(4);
            methodPublishGetFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            var methodPublishGetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(XmlNode), typeof(SPList), typeof(DataSet) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishGetFieldValue, Fixture, methodPublishGetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPublishGetFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            var methodPublishGetFieldValuePrametersTypes = new Type[] { typeof(string), typeof(XmlNode), typeof(SPList), typeof(DataSet) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishGetFieldValue, Fixture, methodPublishGetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishGetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishGetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PublishGetFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishGetFieldValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishGetFieldValue);
            var methodInfo = this.GetMethodInfo(MethodPublishGetFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishIsAssignmentFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsAssignmentField, Fixture, methodPublishIsAssignmentFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsAssignmentField);
            var fieldAttr = this.CreateType<string>();
            var methodPublishIsAssignmentFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishIsAssignmentField = { fieldAttr };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishIsAssignmentField, methodPublishIsAssignmentFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishIsAssignmentField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishIsAssignmentField.ShouldNotBeNull();
            parametersOfPublishIsAssignmentField.Length.ShouldBe(1);
            methodPublishIsAssignmentFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsAssignmentField);
            var fieldAttr = this.CreateType<string>();
            var methodPublishIsAssignmentFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishIsAssignmentField = { fieldAttr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsAssignmentField, parametersOfPublishIsAssignmentField, methodPublishIsAssignmentFieldPrametersTypes);

            // Assert
            parametersOfPublishIsAssignmentField.ShouldNotBeNull();
            parametersOfPublishIsAssignmentField.Length.ShouldBe(1);
            methodPublishIsAssignmentFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsAssignmentField);
            var methodPublishIsAssignmentFieldPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsAssignmentField, Fixture, methodPublishIsAssignmentFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishIsAssignmentFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsAssignmentField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishIsAssignmentField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PublishIsAssignmentField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsAssignmentField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsAssignmentField);
            var methodInfo = this.GetMethodInfo(MethodPublishIsAssignmentField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishIsValidFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsValidField, Fixture, methodPublishIsValidFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsValidField);
            var fieldAttr = this.CreateType<string>();
            var methodPublishIsValidFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishIsValidField = { fieldAttr };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishIsValidField, methodPublishIsValidFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishIsValidField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishIsValidField.ShouldNotBeNull();
            parametersOfPublishIsValidField.Length.ShouldBe(1);
            methodPublishIsValidFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsValidField);
            var fieldAttr = this.CreateType<string>();
            var methodPublishIsValidFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishIsValidField = { fieldAttr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsValidField, parametersOfPublishIsValidField, methodPublishIsValidFieldPrametersTypes);

            // Assert
            parametersOfPublishIsValidField.ShouldNotBeNull();
            parametersOfPublishIsValidField.Length.ShouldBe(1);
            methodPublishIsValidFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsValidField);
            var methodPublishIsValidFieldPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishIsValidField, Fixture, methodPublishIsValidFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishIsValidFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsValidField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishIsValidField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PublishIsValidField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishIsValidField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishIsValidField);
            var methodInfo = this.GetMethodInfo(MethodPublishIsValidField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishProcessFoldersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessFolders, Fixture, methodPublishProcessFoldersPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessFolders);
            var ndFolder = this.CreateType<XmlNode>();
            var parentfolderpath = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessFoldersPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(PlannerProps) };
            object[] parametersOfPublishProcessFolders = { ndFolder, parentfolderpath, data, oTaskCenter, dsResources, props };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessFolders, methodPublishProcessFoldersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublishProcessFolders);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishProcessFolders.ShouldNotBeNull();
            parametersOfPublishProcessFolders.Length.ShouldBe(6);
            methodPublishProcessFoldersPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessFolders);
            var ndFolder = this.CreateType<XmlNode>();
            var parentfolderpath = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var oTaskCenter = this.CreateType<SPList>();
            var dsResources = this.CreateType<DataSet>();
            var props = this.CreateType<PlannerProps>();
            var methodPublishProcessFoldersPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(PlannerProps) };
            object[] parametersOfPublishProcessFolders = { ndFolder, parentfolderpath, data, oTaskCenter, dsResources, props };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessFolders, parametersOfPublishProcessFolders, methodPublishProcessFoldersPrametersTypes);

            // Assert
            parametersOfPublishProcessFolders.ShouldNotBeNull();
            parametersOfPublishProcessFolders.Length.ShouldBe(6);
            methodPublishProcessFoldersPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessFolders);
            var methodInfo = this.GetMethodInfo(MethodPublishProcessFolders, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessFolders);
            var methodPublishProcessFoldersPrametersTypes = new Type[] { typeof(XmlNode), typeof(string), typeof(XmlDocument), typeof(SPList), typeof(DataSet), typeof(PlannerProps) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublishProcessFolders, Fixture, methodPublishProcessFoldersPrametersTypes);

            // Assert
            methodPublishProcessFoldersPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishProcessFolders) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_PublishProcessFolders_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublishProcessFolders);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublishProcessFolders, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_Publish_Static_Method_Call_Internally(Type[] types)
        {
            var methodPublishPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, Fixture, methodPublishPrametersTypes);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.Publish(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfPublish = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublish, methodPublishPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, Fixture, methodPublishPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, parametersOfPublish, methodPublishPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfPublish);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPublish.ShouldNotBeNull();
            parametersOfPublish.Length.ShouldBe(2);
            methodPublishPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfPublish = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, parametersOfPublish, methodPublishPrametersTypes);

            // Assert
            parametersOfPublish.ShouldNotBeNull();
            parametersOfPublish.Length.ShouldBe(2);
            methodPublishPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var methodPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, Fixture, methodPublishPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPublishPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var methodPublishPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodPublish, Fixture, methodPublishPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodPublish, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Publish) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_Publish_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodPublish);
            var methodInfo = this.GetMethodInfo(MethodPublish, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_Internally(Type[] types)
        {
            var methodappendSpecialColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodappendSpecialColumns, Fixture, methodappendSpecialColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            var docOut = this.CreateType<XmlDocument>();
            var ndCols = this.CreateType<XmlNode>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.appendSpecialColumns(ref docOut, ref ndCols);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            var docOut = this.CreateType<XmlDocument>();
            var ndCols = this.CreateType<XmlNode>();
            var methodappendSpecialColumnsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfappendSpecialColumns = { docOut, ndCols };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodappendSpecialColumns, methodappendSpecialColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfappendSpecialColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfappendSpecialColumns.ShouldNotBeNull();
            parametersOfappendSpecialColumns.Length.ShouldBe(2);
            methodappendSpecialColumnsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            var docOut = this.CreateType<XmlDocument>();
            var ndCols = this.CreateType<XmlNode>();
            var methodappendSpecialColumnsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };
            object[] parametersOfappendSpecialColumns = { docOut, ndCols };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodappendSpecialColumns, parametersOfappendSpecialColumns, methodappendSpecialColumnsPrametersTypes);

            // Assert
            parametersOfappendSpecialColumns.ShouldNotBeNull();
            parametersOfappendSpecialColumns.Length.ShouldBe(2);
            methodappendSpecialColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            var methodInfo = this.GetMethodInfo(MethodappendSpecialColumns, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            var methodappendSpecialColumnsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodappendSpecialColumns, Fixture, methodappendSpecialColumnsPrametersTypes);

            // Assert
            methodappendSpecialColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendSpecialColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_appendSpecialColumns_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodappendSpecialColumns);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodappendSpecialColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetGeneralLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, Fixture, methodiGetGeneralLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            var web = this.CreateType<SPWeb>();
            var sPlannerXml = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var bIsAgileLayout = this.CreateType<bool>();
            var methodiGetGeneralLayoutPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(XmlDocument), typeof(bool) };
            object[] parametersOfiGetGeneralLayout = { web, sPlannerXml, data, bIsAgileLayout };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiGetGeneralLayout, methodiGetGeneralLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, Fixture, methodiGetGeneralLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, parametersOfiGetGeneralLayout, methodiGetGeneralLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfiGetGeneralLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetGeneralLayout.ShouldNotBeNull();
            parametersOfiGetGeneralLayout.Length.ShouldBe(4);
            methodiGetGeneralLayoutPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            var web = this.CreateType<SPWeb>();
            var sPlannerXml = this.CreateType<string>();
            var data = this.CreateType<XmlDocument>();
            var bIsAgileLayout = this.CreateType<bool>();
            var methodiGetGeneralLayoutPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(XmlDocument), typeof(bool) };
            object[] parametersOfiGetGeneralLayout = { web, sPlannerXml, data, bIsAgileLayout };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, parametersOfiGetGeneralLayout, methodiGetGeneralLayoutPrametersTypes);

            // Assert
            parametersOfiGetGeneralLayout.ShouldNotBeNull();
            parametersOfiGetGeneralLayout.Length.ShouldBe(4);
            methodiGetGeneralLayoutPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            var methodiGetGeneralLayoutPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(XmlDocument), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, Fixture, methodiGetGeneralLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetGeneralLayoutPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            var methodiGetGeneralLayoutPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(XmlDocument), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodiGetGeneralLayout, Fixture, methodiGetGeneralLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetGeneralLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodiGetGeneralLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetGeneralLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_iGetGeneralLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodiGetGeneralLayout);
            var methodInfo = this.GetMethodInfo(MethodiGetGeneralLayout, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAgileLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, Fixture, methodGetAgileLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetAgileLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAgileLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAgileLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAgileLayout, methodGetAgileLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, Fixture, methodGetAgileLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, parametersOfGetAgileLayout, methodGetAgileLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetAgileLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAgileLayout.ShouldNotBeNull();
            parametersOfGetAgileLayout.Length.ShouldBe(2);
            methodGetAgileLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAgileLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAgileLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, parametersOfGetAgileLayout, methodGetAgileLayoutPrametersTypes);

            // Assert
            parametersOfGetAgileLayout.ShouldNotBeNull();
            parametersOfGetAgileLayout.Length.ShouldBe(2);
            methodGetAgileLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var methodGetAgileLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, Fixture, methodGetAgileLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAgileLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var methodGetAgileLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileLayout, Fixture, methodGetAgileLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAgileLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAgileLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAgileLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileLayout);
            var methodInfo = this.GetMethodInfo(MethodGetAgileLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isNewValidTask) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_isNewValidTask_Static_Method_Call_Internally(Type[] types)
        {
            var methodisNewValidTaskPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisNewValidTask, Fixture, methodisNewValidTaskPrametersTypes);
        }

        #endregion

        #region Method Call : (isNewValidTask) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isNewValidTask_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisNewValidTask);
            var li = this.CreateType<SPListItem>();
            var agileDoc = this.CreateType<XmlDocument>();
            var methodisNewValidTaskPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };
            object[] parametersOfisNewValidTask = { li, agileDoc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisNewValidTask, parametersOfisNewValidTask, methodisNewValidTaskPrametersTypes);

            // Assert
            parametersOfisNewValidTask.ShouldNotBeNull();
            parametersOfisNewValidTask.Length.ShouldBe(2);
            methodisNewValidTaskPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isNewValidTask) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isNewValidTask_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisNewValidTask);
            var methodisNewValidTaskPrametersTypes = new Type[] { typeof(SPListItem), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisNewValidTask, Fixture, methodisNewValidTaskPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisNewValidTaskPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isNewValidTask) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isNewValidTask_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisNewValidTask);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodisNewValidTask, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (isNewValidTask) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isNewValidTask_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisNewValidTask);
            var methodInfo = this.GetMethodInfo(MethodisNewValidTask, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_Internally(Type[] types)
        {
            var methodAppendNewAgileTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, Fixture, methodAppendNewAgileTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            var web = this.CreateType<SPWeb>();
            var p = this.CreateType<PlannerProps>();
            var doc = this.CreateType<XmlDocument>();
            var projectid = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var methodAppendNewAgileTasksPrametersTypes = new Type[] { typeof(SPWeb), typeof(PlannerProps), typeof(XmlDocument), typeof(string), typeof(DataSet) };
            object[] parametersOfAppendNewAgileTasks = { web, p, doc, projectid, dsResources };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodAppendNewAgileTasks, methodAppendNewAgileTasksPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, Fixture, methodAppendNewAgileTasksPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, parametersOfAppendNewAgileTasks, methodAppendNewAgileTasksPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfAppendNewAgileTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAppendNewAgileTasks.ShouldNotBeNull();
            parametersOfAppendNewAgileTasks.Length.ShouldBe(5);
            methodAppendNewAgileTasksPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            var web = this.CreateType<SPWeb>();
            var p = this.CreateType<PlannerProps>();
            var doc = this.CreateType<XmlDocument>();
            var projectid = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var methodAppendNewAgileTasksPrametersTypes = new Type[] { typeof(SPWeb), typeof(PlannerProps), typeof(XmlDocument), typeof(string), typeof(DataSet) };
            object[] parametersOfAppendNewAgileTasks = { web, p, doc, projectid, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, parametersOfAppendNewAgileTasks, methodAppendNewAgileTasksPrametersTypes);

            // Assert
            parametersOfAppendNewAgileTasks.ShouldNotBeNull();
            parametersOfAppendNewAgileTasks.Length.ShouldBe(5);
            methodAppendNewAgileTasksPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            var methodAppendNewAgileTasksPrametersTypes = new Type[] { typeof(SPWeb), typeof(PlannerProps), typeof(XmlDocument), typeof(string), typeof(DataSet) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, Fixture, methodAppendNewAgileTasksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAppendNewAgileTasksPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            var methodAppendNewAgileTasksPrametersTypes = new Type[] { typeof(SPWeb), typeof(PlannerProps), typeof(XmlDocument), typeof(string), typeof(DataSet) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodAppendNewAgileTasks, Fixture, methodAppendNewAgileTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppendNewAgileTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodAppendNewAgileTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AppendNewAgileTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_AppendNewAgileTasks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodAppendNewAgileTasks);
            var methodInfo = this.GetMethodInfo(MethodAppendNewAgileTasks, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, Fixture, methodGetLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetLayout, methodGetLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, Fixture, methodGetLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, parametersOfGetLayout, methodGetLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLayout.ShouldNotBeNull();
            parametersOfGetLayout.Length.ShouldBe(2);
            methodGetLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, parametersOfGetLayout, methodGetLayoutPrametersTypes);

            // Assert
            parametersOfGetLayout.ShouldNotBeNull();
            parametersOfGetLayout.Length.ShouldBe(2);
            methodGetLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var methodGetLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, Fixture, methodGetLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var methodGetLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLayout, Fixture, methodGetLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLayout);
            var methodInfo = this.GetMethodInfo(MethodGetLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAgileFolderFieldFormulaPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileFolderFieldFormula, Fixture, methodGetAgileFolderFieldFormulaPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            var field = this.CreateType<string>();
            var methodGetAgileFolderFieldFormulaPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAgileFolderFieldFormula = { field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetAgileFolderFieldFormula, methodGetAgileFolderFieldFormulaPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetAgileFolderFieldFormula);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAgileFolderFieldFormula.ShouldNotBeNull();
            parametersOfGetAgileFolderFieldFormula.Length.ShouldBe(1);
            methodGetAgileFolderFieldFormulaPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            var field = this.CreateType<string>();
            var methodGetAgileFolderFieldFormulaPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAgileFolderFieldFormula = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileFolderFieldFormula, parametersOfGetAgileFolderFieldFormula, methodGetAgileFolderFieldFormulaPrametersTypes);

            // Assert
            parametersOfGetAgileFolderFieldFormula.ShouldNotBeNull();
            parametersOfGetAgileFolderFieldFormula.Length.ShouldBe(1);
            methodGetAgileFolderFieldFormulaPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            var methodGetAgileFolderFieldFormulaPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileFolderFieldFormula, Fixture, methodGetAgileFolderFieldFormulaPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAgileFolderFieldFormulaPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            var methodGetAgileFolderFieldFormulaPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAgileFolderFieldFormula, Fixture, methodGetAgileFolderFieldFormulaPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAgileFolderFieldFormulaPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAgileFolderFieldFormula, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAgileFolderFieldFormula) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAgileFolderFieldFormula_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAgileFolderFieldFormula);
            var methodInfo = this.GetMethodInfo(MethodGetAgileFolderFieldFormula, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_Internally(Type[] types)
        {
            var methodaddCalculationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddCalculations, Fixture, methodaddCalculationsPrametersTypes);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddCalculations);
            var p = this.CreateType<PlannerProps>();
            var docOut = this.CreateType<XmlDocument>();
            var ndDef = this.CreateType<XmlNode>();
            var bAgile = this.CreateType<bool>();
            var methodaddCalculationsPrametersTypes = new Type[] { typeof(PlannerProps), typeof(XmlDocument), typeof(XmlNode), typeof(bool) };
            object[] parametersOfaddCalculations = { p, docOut, ndDef, bAgile };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodaddCalculations, methodaddCalculationsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfaddCalculations);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddCalculations.ShouldNotBeNull();
            parametersOfaddCalculations.Length.ShouldBe(4);
            methodaddCalculationsPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddCalculations);
            var p = this.CreateType<PlannerProps>();
            var docOut = this.CreateType<XmlDocument>();
            var ndDef = this.CreateType<XmlNode>();
            var bAgile = this.CreateType<bool>();
            var methodaddCalculationsPrametersTypes = new Type[] { typeof(PlannerProps), typeof(XmlDocument), typeof(XmlNode), typeof(bool) };
            object[] parametersOfaddCalculations = { p, docOut, ndDef, bAgile };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddCalculations, parametersOfaddCalculations, methodaddCalculationsPrametersTypes);

            // Assert
            parametersOfaddCalculations.ShouldNotBeNull();
            parametersOfaddCalculations.Length.ShouldBe(4);
            methodaddCalculationsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddCalculations);
            var methodInfo = this.GetMethodInfo(MethodaddCalculations, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddCalculations);
            var methodaddCalculationsPrametersTypes = new Type[] { typeof(PlannerProps), typeof(XmlDocument), typeof(XmlNode), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddCalculations, Fixture, methodaddCalculationsPrametersTypes);

            // Assert
            methodaddCalculationsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addCalculations) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addCalculations_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddCalculations);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodaddCalculations, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFolderLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, Fixture, methodGetFolderLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetFolderLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetFolderLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetFolderLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetFolderLayout, methodGetFolderLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, Fixture, methodGetFolderLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, parametersOfGetFolderLayout, methodGetFolderLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetFolderLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFolderLayout.ShouldNotBeNull();
            parametersOfGetFolderLayout.Length.ShouldBe(2);
            methodGetFolderLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetFolderLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetFolderLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, parametersOfGetFolderLayout, methodGetFolderLayoutPrametersTypes);

            // Assert
            parametersOfGetFolderLayout.ShouldNotBeNull();
            parametersOfGetFolderLayout.Length.ShouldBe(2);
            methodGetFolderLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var methodGetFolderLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, Fixture, methodGetFolderLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFolderLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var methodGetFolderLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFolderLayout, Fixture, methodGetFolderLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFolderLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetFolderLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFolderLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFolderLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFolderLayout);
            var methodInfo = this.GetMethodInfo(MethodGetFolderLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetViews(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetViewsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetViews = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetViews, methodGetViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetViews.ShouldNotBeNull();
            parametersOfGetViews.Length.ShouldBe(2);
            methodGetViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetViewsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetViews = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes);

            // Assert
            parametersOfGetViews.ShouldNotBeNull();
            parametersOfGetViews.Length.ShouldBe(2);
            methodGetViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var methodGetViewsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var methodGetViewsPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetViews);
            var methodInfo = this.GetMethodInfo(MethodGetViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Internally(Type[] types)
        {
            var methodisValidFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, Fixture, methodisValidFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var fieldname = this.CreateType<string>();
            var isProjectCenter = this.CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.isValidField(fieldname, isProjectCenter);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var fieldname = this.CreateType<string>();
            var isProjectCenter = this.CreateType<bool>();
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfisValidField = { fieldname, isProjectCenter };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodisValidField, methodisValidFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, Fixture, methodisValidFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, parametersOfisValidField, methodisValidFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfisValidField.ShouldNotBeNull();
            parametersOfisValidField.Length.ShouldBe(2);
            methodisValidFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, parametersOfisValidField, methodisValidFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var fieldname = this.CreateType<string>();
            var isProjectCenter = this.CreateType<bool>();
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfisValidField = { fieldname, isProjectCenter };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodisValidField, methodisValidFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfisValidField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisValidField.ShouldNotBeNull();
            parametersOfisValidField.Length.ShouldBe(2);
            methodisValidFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var fieldname = this.CreateType<string>();
            var isProjectCenter = this.CreateType<bool>();
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfisValidField = { fieldname, isProjectCenter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, parametersOfisValidField, methodisValidFieldPrametersTypes);

            // Assert
            parametersOfisValidField.ShouldNotBeNull();
            parametersOfisValidField.Length.ShouldBe(2);
            methodisValidFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, Fixture, methodisValidFieldPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodisValidFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, Fixture, methodisValidFieldPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodisValidFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var methodisValidFieldPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisValidField, Fixture, methodisValidFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisValidFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodisValidField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isValidField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isValidField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisValidField);
            var methodInfo = this.GetMethodInfo(MethodisValidField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDetailLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, Fixture, methodGetDetailLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetDetailLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetDetailLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetDetailLayout, methodGetDetailLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, Fixture, methodGetDetailLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, parametersOfGetDetailLayout, methodGetDetailLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetDetailLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDetailLayout.ShouldNotBeNull();
            parametersOfGetDetailLayout.Length.ShouldBe(2);
            methodGetDetailLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetDetailLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, parametersOfGetDetailLayout, methodGetDetailLayoutPrametersTypes);

            // Assert
            parametersOfGetDetailLayout.ShouldNotBeNull();
            parametersOfGetDetailLayout.Length.ShouldBe(2);
            methodGetDetailLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var methodGetDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, Fixture, methodGetDetailLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDetailLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var methodGetDetailLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetDetailLayout, Fixture, methodGetDetailLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDetailLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetDetailLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDetailLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetDetailLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetDetailLayout);
            var methodInfo = this.GetMethodInfo(MethodGetDetailLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.getFieldValue(li, oField, dsResources);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes));
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, methodgetFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var li = this.CreateType<SPListItem>();
            var oField = this.CreateType<SPField>();
            var dsResources = this.CreateType<DataSet>();
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            object[] parametersOfgetFieldValue = { li, oField, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, parametersOfgetFieldValue, methodgetFieldValuePrametersTypes);

            // Assert
            parametersOfgetFieldValue.ShouldNotBeNull();
            parametersOfgetFieldValue.Length.ShouldBe(3);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetFieldValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodgetFieldValuePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(DataSet) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFieldValue, Fixture, methodgetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFieldValue_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFieldValue);
            var methodInfo = this.GetMethodInfo(MethodgetFieldValue, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetupProjectCenterListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSetupProjectCenterList, Fixture, methodSetupProjectCenterListPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSetupProjectCenterList);
            var oProjectCenter = this.CreateType<SPList>();
            var sPlanner = this.CreateType<string>();
            var methodSetupProjectCenterListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfSetupProjectCenterList = { oProjectCenter, sPlanner };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodSetupProjectCenterList, methodSetupProjectCenterListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfSetupProjectCenterList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetupProjectCenterList.ShouldNotBeNull();
            parametersOfSetupProjectCenterList.Length.ShouldBe(2);
            methodSetupProjectCenterListPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSetupProjectCenterList);
            var oProjectCenter = this.CreateType<SPList>();
            var sPlanner = this.CreateType<string>();
            var methodSetupProjectCenterListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfSetupProjectCenterList = { oProjectCenter, sPlanner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSetupProjectCenterList, parametersOfSetupProjectCenterList, methodSetupProjectCenterListPrametersTypes);

            // Assert
            parametersOfSetupProjectCenterList.ShouldNotBeNull();
            parametersOfSetupProjectCenterList.Length.ShouldBe(2);
            methodSetupProjectCenterListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSetupProjectCenterList);
            var methodInfo = this.GetMethodInfo(MethodSetupProjectCenterList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSetupProjectCenterList);
            var methodSetupProjectCenterListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodSetupProjectCenterList, Fixture, methodSetupProjectCenterListPrametersTypes);

            // Assert
            methodSetupProjectCenterListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupProjectCenterList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_SetupProjectCenterList_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodSetupProjectCenterList);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodSetupProjectCenterList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, Fixture, methodGetResourceTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var props = this.CreateType<PlannerProps>();
            var listid = this.CreateType<Guid>();
            var itemid = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetResourceTable(props, listid, itemid, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var props = this.CreateType<PlannerProps>();
            var listid = this.CreateType<Guid>();
            var itemid = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetResourceTablePrametersTypes = new Type[] { typeof(PlannerProps), typeof(Guid), typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceTable = { props, listid, itemid, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetResourceTable, methodGetResourceTablePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, Fixture, methodGetResourceTablePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, parametersOfGetResourceTable, methodGetResourceTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOfGetResourceTable.ShouldNotBeNull();
            parametersOfGetResourceTable.Length.ShouldBe(4);
            methodGetResourceTablePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, parametersOfGetResourceTable, methodGetResourceTablePrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var props = this.CreateType<PlannerProps>();
            var listid = this.CreateType<Guid>();
            var itemid = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetResourceTablePrametersTypes = new Type[] { typeof(PlannerProps), typeof(Guid), typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceTable = { props, listid, itemid, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodGetResourceTable, methodGetResourceTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetResourceTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetResourceTable.ShouldNotBeNull();
            parametersOfGetResourceTable.Length.ShouldBe(4);
            methodGetResourceTablePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var props = this.CreateType<PlannerProps>();
            var listid = this.CreateType<Guid>();
            var itemid = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetResourceTablePrametersTypes = new Type[] { typeof(PlannerProps), typeof(Guid), typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceTable = { props, listid, itemid, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, parametersOfGetResourceTable, methodGetResourceTablePrametersTypes);

            // Assert
            parametersOfGetResourceTable.ShouldNotBeNull();
            parametersOfGetResourceTable.Length.ShouldBe(4);
            methodGetResourceTablePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var methodGetResourceTablePrametersTypes = new Type[] { typeof(PlannerProps), typeof(Guid), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, Fixture, methodGetResourceTablePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetResourceTablePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var methodGetResourceTablePrametersTypes = new Type[] { typeof(PlannerProps), typeof(Guid), typeof(string), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetResourceTable, Fixture, methodGetResourceTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetResourceTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetResourceTable) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetResourceTable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetResourceTable);
            var methodInfo = this.GetMethodInfo(MethodGetResourceTable, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, Fixture, methodGetProjectInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetProjectInfo(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetProjectInfoPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetProjectInfo = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetProjectInfo, methodGetProjectInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, Fixture, methodGetProjectInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, parametersOfGetProjectInfo, methodGetProjectInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetProjectInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProjectInfo.ShouldNotBeNull();
            parametersOfGetProjectInfo.Length.ShouldBe(2);
            methodGetProjectInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetProjectInfoPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetProjectInfo = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, parametersOfGetProjectInfo, methodGetProjectInfoPrametersTypes);

            // Assert
            parametersOfGetProjectInfo.ShouldNotBeNull();
            parametersOfGetProjectInfo.Length.ShouldBe(2);
            methodGetProjectInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var methodGetProjectInfoPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, Fixture, methodGetProjectInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProjectInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var methodGetProjectInfoPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetProjectInfo, Fixture, methodGetProjectInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProjectInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetProjectInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProjectInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetProjectInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetProjectInfo);
            var methodInfo = this.GetMethodInfo(MethodGetProjectInfo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetEnumFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodsetEnumField, Fixture, methodsetEnumFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            var oField = this.CreateType<SPField>();
            var ndCol = this.CreateType<XmlNode>();
            var fieldDoc = this.CreateType<XmlDocument>();
            var docOut = this.CreateType<XmlDocument>();
            var web = this.CreateType<SPWeb>();
            var multi = this.CreateType<bool>();
            var enumattr = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.setEnumField(oField, ref ndCol, fieldDoc, docOut, web, multi, enumattr, dsResources);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            var oField = this.CreateType<SPField>();
            var ndCol = this.CreateType<XmlNode>();
            var fieldDoc = this.CreateType<XmlDocument>();
            var docOut = this.CreateType<XmlDocument>();
            var web = this.CreateType<SPWeb>();
            var multi = this.CreateType<bool>();
            var enumattr = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var methodsetEnumFieldPrametersTypes = new Type[] { typeof(SPField), typeof(XmlNode), typeof(XmlDocument), typeof(XmlDocument), typeof(SPWeb), typeof(bool), typeof(string), typeof(DataSet) };
            object[] parametersOfsetEnumField = { oField, ndCol, fieldDoc, docOut, web, multi, enumattr, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodsetEnumField, methodsetEnumFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfsetEnumField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetEnumField.ShouldNotBeNull();
            parametersOfsetEnumField.Length.ShouldBe(8);
            methodsetEnumFieldPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            var oField = this.CreateType<SPField>();
            var ndCol = this.CreateType<XmlNode>();
            var fieldDoc = this.CreateType<XmlDocument>();
            var docOut = this.CreateType<XmlDocument>();
            var web = this.CreateType<SPWeb>();
            var multi = this.CreateType<bool>();
            var enumattr = this.CreateType<string>();
            var dsResources = this.CreateType<DataSet>();
            var methodsetEnumFieldPrametersTypes = new Type[] { typeof(SPField), typeof(XmlNode), typeof(XmlDocument), typeof(XmlDocument), typeof(SPWeb), typeof(bool), typeof(string), typeof(DataSet) };
            object[] parametersOfsetEnumField = { oField, ndCol, fieldDoc, docOut, web, multi, enumattr, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodsetEnumField, parametersOfsetEnumField, methodsetEnumFieldPrametersTypes);

            // Assert
            parametersOfsetEnumField.ShouldNotBeNull();
            parametersOfsetEnumField.Length.ShouldBe(8);
            methodsetEnumFieldPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            var methodInfo = this.GetMethodInfo(MethodsetEnumField, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            var methodsetEnumFieldPrametersTypes = new Type[] { typeof(SPField), typeof(XmlNode), typeof(XmlDocument), typeof(XmlDocument), typeof(SPWeb), typeof(bool), typeof(string), typeof(DataSet) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodsetEnumField, Fixture, methodsetEnumFieldPrametersTypes);

            // Assert
            methodsetEnumFieldPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setEnumField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_setEnumField_Static_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodsetEnumField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodsetEnumField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAssignmentLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, Fixture, methodGetAssignmentLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetAssignmentLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAssignmentLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAssignmentLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAssignmentLayout, methodGetAssignmentLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, Fixture, methodGetAssignmentLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, parametersOfGetAssignmentLayout, methodGetAssignmentLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetAssignmentLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAssignmentLayout.ShouldNotBeNull();
            parametersOfGetAssignmentLayout.Length.ShouldBe(2);
            methodGetAssignmentLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAssignmentLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAssignmentLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, parametersOfGetAssignmentLayout, methodGetAssignmentLayoutPrametersTypes);

            // Assert
            parametersOfGetAssignmentLayout.ShouldNotBeNull();
            parametersOfGetAssignmentLayout.Length.ShouldBe(2);
            methodGetAssignmentLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var methodGetAssignmentLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, Fixture, methodGetAssignmentLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAssignmentLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var methodGetAssignmentLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAssignmentLayout, Fixture, methodGetAssignmentLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAssignmentLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAssignmentLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAssignmentLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAssignmentLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAssignmentLayout);
            var methodInfo = this.GetMethodInfo(MethodGetAssignmentLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLinksLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, Fixture, methodGetLinksLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetLinksLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetLinksLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetLinksLayout, methodGetLinksLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, Fixture, methodGetLinksLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, parametersOfGetLinksLayout, methodGetLinksLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetLinksLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLinksLayout.ShouldNotBeNull();
            parametersOfGetLinksLayout.Length.ShouldBe(2);
            methodGetLinksLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetLinksLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, parametersOfGetLinksLayout, methodGetLinksLayoutPrametersTypes);

            // Assert
            parametersOfGetLinksLayout.ShouldNotBeNull();
            parametersOfGetLinksLayout.Length.ShouldBe(2);
            methodGetLinksLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var methodGetLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, Fixture, methodGetLinksLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLinksLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var methodGetLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetLinksLayout, Fixture, methodGetLinksLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinksLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetLinksLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinksLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetLinksLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetLinksLayout);
            var methodInfo = this.GetMethodInfo(MethodGetLinksLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAllocationLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, Fixture, methodGetAllocationLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetAllocationLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAllocationLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAllocationLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAllocationLayout, methodGetAllocationLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, Fixture, methodGetAllocationLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, parametersOfGetAllocationLayout, methodGetAllocationLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetAllocationLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllocationLayout.ShouldNotBeNull();
            parametersOfGetAllocationLayout.Length.ShouldBe(2);
            methodGetAllocationLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAllocationLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAllocationLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, parametersOfGetAllocationLayout, methodGetAllocationLayoutPrametersTypes);

            // Assert
            parametersOfGetAllocationLayout.ShouldNotBeNull();
            parametersOfGetAllocationLayout.Length.ShouldBe(2);
            methodGetAllocationLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var methodGetAllocationLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, Fixture, methodGetAllocationLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllocationLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var methodGetAllocationLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAllocationLayout, Fixture, methodGetAllocationLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllocationLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAllocationLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllocationLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAllocationLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAllocationLayout);
            var methodInfo = this.GetMethodInfo(MethodGetAllocationLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessAllocationResourcesColsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessAllocationResourcesCols, Fixture, methodProcessAllocationResourcesColsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessAllocationResourcesCols);
            var ndCols = this.CreateType<XmlNode>();
            var oWeb = this.CreateType<SPWeb>();
            var methodProcessAllocationResourcesColsPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };
            object[] parametersOfProcessAllocationResourcesCols = { ndCols, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodProcessAllocationResourcesCols, methodProcessAllocationResourcesColsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfProcessAllocationResourcesCols);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessAllocationResourcesCols.ShouldNotBeNull();
            parametersOfProcessAllocationResourcesCols.Length.ShouldBe(2);
            methodProcessAllocationResourcesColsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessAllocationResourcesCols);
            var ndCols = this.CreateType<XmlNode>();
            var oWeb = this.CreateType<SPWeb>();
            var methodProcessAllocationResourcesColsPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };
            object[] parametersOfProcessAllocationResourcesCols = { ndCols, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessAllocationResourcesCols, parametersOfProcessAllocationResourcesCols, methodProcessAllocationResourcesColsPrametersTypes);

            // Assert
            parametersOfProcessAllocationResourcesCols.ShouldNotBeNull();
            parametersOfProcessAllocationResourcesCols.Length.ShouldBe(2);
            methodProcessAllocationResourcesColsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessAllocationResourcesCols);
            var methodInfo = this.GetMethodInfo(MethodProcessAllocationResourcesCols, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessAllocationResourcesCols);
            var methodProcessAllocationResourcesColsPrametersTypes = new Type[] { typeof(XmlNode), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodProcessAllocationResourcesCols, Fixture, methodProcessAllocationResourcesColsPrametersTypes);

            // Assert
            methodProcessAllocationResourcesColsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAllocationResourcesCols) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ProcessAllocationResourcesCols_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodProcessAllocationResourcesCols);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodProcessAllocationResourcesCols, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAddLinksLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, Fixture, methodGetAddLinksLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetAddLinksLayout(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAddLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAddLinksLayout = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAddLinksLayout, methodGetAddLinksLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, Fixture, methodGetAddLinksLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, parametersOfGetAddLinksLayout, methodGetAddLinksLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetAddLinksLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAddLinksLayout.ShouldNotBeNull();
            parametersOfGetAddLinksLayout.Length.ShouldBe(2);
            methodGetAddLinksLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetAddLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetAddLinksLayout = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, parametersOfGetAddLinksLayout, methodGetAddLinksLayoutPrametersTypes);

            // Assert
            parametersOfGetAddLinksLayout.ShouldNotBeNull();
            parametersOfGetAddLinksLayout.Length.ShouldBe(2);
            methodGetAddLinksLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var methodGetAddLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, Fixture, methodGetAddLinksLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAddLinksLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var methodGetAddLinksLayoutPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetAddLinksLayout, Fixture, methodGetAddLinksLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAddLinksLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetAddLinksLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAddLinksLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetAddLinksLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetAddLinksLayout);
            var methodInfo = this.GetMethodInfo(MethodGetAddLinksLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            var oField = this.CreateType<SPField>();
            var oDoc = this.CreateType<XmlDocument>();
            var EditFormat = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetFormat = { oField, oDoc, EditFormat, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFormat, methodgetFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, parametersOfgetFormat, methodgetFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFormat.ShouldNotBeNull();
            parametersOfgetFormat.Length.ShouldBe(4);
            methodgetFormatPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            var oField = this.CreateType<SPField>();
            var oDoc = this.CreateType<XmlDocument>();
            var EditFormat = this.CreateType<string>();
            var oWeb = this.CreateType<SPWeb>();
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string), typeof(SPWeb) };
            object[] parametersOfgetFormat = { oField, oDoc, EditFormat, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, parametersOfgetFormat, methodgetFormatPrametersTypes);

            // Assert
            parametersOfgetFormat.ShouldNotBeNull();
            parametersOfgetFormat.Length.ShouldBe(4);
            methodgetFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            var methodgetFormatPrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetFormat, Fixture, methodgetFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetFormat);
            var methodInfo = this.GetMethodInfo(MethodgetFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadOnlyField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ReadOnlyField_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadOnlyFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReadOnlyField, Fixture, methodReadOnlyFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadOnlyField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReadOnlyField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReadOnlyField);
            var oField = this.CreateType<SPField>();
            var p = this.CreateType<PlannerProps>();
            var methodReadOnlyFieldPrametersTypes = new Type[] { typeof(SPField), typeof(PlannerProps) };
            object[] parametersOfReadOnlyField = { oField, p };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReadOnlyField, parametersOfReadOnlyField, methodReadOnlyFieldPrametersTypes);

            // Assert
            parametersOfReadOnlyField.ShouldNotBeNull();
            parametersOfReadOnlyField.Length.ShouldBe(2);
            methodReadOnlyFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadOnlyField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReadOnlyField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReadOnlyField);
            var methodReadOnlyFieldPrametersTypes = new Type[] { typeof(SPField), typeof(PlannerProps) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReadOnlyField, Fixture, methodReadOnlyFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadOnlyFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadOnlyField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReadOnlyField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReadOnlyField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodReadOnlyField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReadOnlyField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReadOnlyField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReadOnlyField);
            var methodInfo = this.GetMethodInfo(MethodReadOnlyField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            var oField = this.CreateType<SPField>();
            var docF = this.CreateType<XmlDocument>();
            var canEdit = this.CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string) };
            object[] parametersOfGetFieldType = { oField, docF, canEdit };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetFieldType, methodGetFieldTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetFieldType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(3);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            var oField = this.CreateType<SPField>();
            var docF = this.CreateType<XmlDocument>();
            var canEdit = this.CreateType<string>();
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string) };
            object[] parametersOfGetFieldType = { oField, docF, canEdit };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, parametersOfGetFieldType, methodGetFieldTypePrametersTypes);

            // Assert
            parametersOfGetFieldType.ShouldNotBeNull();
            parametersOfGetFieldType.Length.ShouldBe(3);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldTypePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            var methodGetFieldTypePrametersTypes = new Type[] { typeof(SPField), typeof(XmlDocument), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetFieldType, Fixture, methodGetFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetFieldType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetFieldType);
            var methodInfo = this.GetMethodInfo(MethodGetFieldType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_Internally(Type[] types)
        {
            var methodaddFieldNodeToDefPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, Fixture, methodaddFieldNodeToDefPrametersTypes);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            var docOut = this.CreateType<XmlDocument>();
            var defName = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodaddFieldNodeToDefPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfaddFieldNodeToDef = { docOut, defName, field };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodaddFieldNodeToDef, methodaddFieldNodeToDefPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, Fixture, methodaddFieldNodeToDefPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, parametersOfaddFieldNodeToDef, methodaddFieldNodeToDefPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfaddFieldNodeToDef);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfaddFieldNodeToDef.ShouldNotBeNull();
            parametersOfaddFieldNodeToDef.Length.ShouldBe(3);
            methodaddFieldNodeToDefPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            var docOut = this.CreateType<XmlDocument>();
            var defName = this.CreateType<string>();
            var field = this.CreateType<string>();
            var methodaddFieldNodeToDefPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfaddFieldNodeToDef = { docOut, defName, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, parametersOfaddFieldNodeToDef, methodaddFieldNodeToDefPrametersTypes);

            // Assert
            parametersOfaddFieldNodeToDef.ShouldNotBeNull();
            parametersOfaddFieldNodeToDef.Length.ShouldBe(3);
            methodaddFieldNodeToDefPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            var methodaddFieldNodeToDefPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, Fixture, methodaddFieldNodeToDefPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddFieldNodeToDefPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            var methodaddFieldNodeToDefPrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodaddFieldNodeToDef, Fixture, methodaddFieldNodeToDefPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddFieldNodeToDefPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodaddFieldNodeToDef, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addFieldNodeToDef) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_addFieldNodeToDef_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodaddFieldNodeToDef);
            var methodInfo = this.GetMethodInfo(MethodaddFieldNodeToDef, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isAssignmentField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_isAssignmentField_Static_Method_Call_Internally(Type[] types)
        {
            var methodisAssignmentFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisAssignmentField, Fixture, methodisAssignmentFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (isAssignmentField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isAssignmentField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisAssignmentField);
            var fieldname = this.CreateType<string>();
            var p = this.CreateType<PlannerProps>();
            var methodisAssignmentFieldPrametersTypes = new Type[] { typeof(string), typeof(PlannerProps) };
            object[] parametersOfisAssignmentField = { fieldname, p };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisAssignmentField, parametersOfisAssignmentField, methodisAssignmentFieldPrametersTypes);

            // Assert
            parametersOfisAssignmentField.ShouldNotBeNull();
            parametersOfisAssignmentField.Length.ShouldBe(2);
            methodisAssignmentFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isAssignmentField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isAssignmentField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisAssignmentField);
            var methodisAssignmentFieldPrametersTypes = new Type[] { typeof(string), typeof(PlannerProps) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodisAssignmentField, Fixture, methodisAssignmentFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisAssignmentFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isAssignmentField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isAssignmentField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisAssignmentField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodisAssignmentField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (isAssignmentField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_isAssignmentField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodisAssignmentField);
            var methodInfo = this.GetMethodInfo(MethodisAssignmentField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessIndividualFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessIndividualField, Fixture, methodprocessIndividualFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessIndividualField);
            var docOut = this.CreateType<XmlDocument>();
            var oField = this.CreateType<SPField>();
            var docF = this.CreateType<XmlDocument>();
            var p = this.CreateType<PlannerProps>();
            var methodprocessIndividualFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(XmlDocument), typeof(PlannerProps) };
            object[] parametersOfprocessIndividualField = { docOut, oField, docF, p };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodprocessIndividualField, methodprocessIndividualFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfprocessIndividualField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessIndividualField.ShouldNotBeNull();
            parametersOfprocessIndividualField.Length.ShouldBe(4);
            methodprocessIndividualFieldPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessIndividualField);
            var docOut = this.CreateType<XmlDocument>();
            var oField = this.CreateType<SPField>();
            var docF = this.CreateType<XmlDocument>();
            var p = this.CreateType<PlannerProps>();
            var methodprocessIndividualFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(XmlDocument), typeof(PlannerProps) };
            object[] parametersOfprocessIndividualField = { docOut, oField, docF, p };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessIndividualField, parametersOfprocessIndividualField, methodprocessIndividualFieldPrametersTypes);

            // Assert
            parametersOfprocessIndividualField.ShouldNotBeNull();
            parametersOfprocessIndividualField.Length.ShouldBe(4);
            methodprocessIndividualFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessIndividualField);
            var methodInfo = this.GetMethodInfo(MethodprocessIndividualField, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessIndividualField);
            var methodprocessIndividualFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(XmlDocument), typeof(PlannerProps) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessIndividualField, Fixture, methodprocessIndividualFieldPrametersTypes);

            // Assert
            methodprocessIndividualFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processIndividualField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processIndividualField_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessIndividualField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodprocessIndividualField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_processField_Static_Method_Call_Internally(Type[] types)
        {
            var methodprocessFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessField, Fixture, methodprocessFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processField_Static_Method_Call_Void_With_8_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessField);
            var docOut = this.CreateType<XmlDocument>();
            var oField = this.CreateType<SPField>();
            var visible = this.CreateType<string>();
            var ndCols = this.CreateType<XmlNode>();
            var ndHeader = this.CreateType<XmlNode>();
            var p = this.CreateType<PlannerProps>();
            var web = this.CreateType<SPWeb>();
            var dsResources = this.CreateType<DataSet>();
            var methodprocessFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(string), typeof(XmlNode), typeof(XmlNode), typeof(PlannerProps), typeof(SPWeb), typeof(DataSet) };
            object[] parametersOfprocessField = { docOut, oField, visible, ndCols, ndHeader, p, web, dsResources };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodprocessField, methodprocessFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfprocessField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessField.ShouldNotBeNull();
            parametersOfprocessField.Length.ShouldBe(8);
            methodprocessFieldPrametersTypes.Length.ShouldBe(8);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processField_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessField);
            var docOut = this.CreateType<XmlDocument>();
            var oField = this.CreateType<SPField>();
            var visible = this.CreateType<string>();
            var ndCols = this.CreateType<XmlNode>();
            var ndHeader = this.CreateType<XmlNode>();
            var p = this.CreateType<PlannerProps>();
            var web = this.CreateType<SPWeb>();
            var dsResources = this.CreateType<DataSet>();
            var methodprocessFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(string), typeof(XmlNode), typeof(XmlNode), typeof(PlannerProps), typeof(SPWeb), typeof(DataSet) };
            object[] parametersOfprocessField = { docOut, oField, visible, ndCols, ndHeader, p, web, dsResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessField, parametersOfprocessField, methodprocessFieldPrametersTypes);

            // Assert
            parametersOfprocessField.ShouldNotBeNull();
            parametersOfprocessField.Length.ShouldBe(8);
            methodprocessFieldPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessField);
            var methodInfo = this.GetMethodInfo(MethodprocessField, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessField);
            var methodprocessFieldPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPField), typeof(string), typeof(XmlNode), typeof(XmlNode), typeof(PlannerProps), typeof(SPWeb), typeof(DataSet) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodprocessField, Fixture, methodprocessFieldPrametersTypes);

            // Assert
            methodprocessFieldPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_processField_Static_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodprocessField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodprocessField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var field = this.CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPField>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getRealField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetRealField);
            var methodInfo = this.GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_Internally(Type[] types)
        {
            var methodtestFunctionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, Fixture, methodtestFunctionPrametersTypes);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.testFunction(data, oWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodtestFunctionPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOftestFunction = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodtestFunction, methodtestFunctionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, Fixture, methodtestFunctionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, parametersOftestFunction, methodtestFunctionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            parametersOftestFunction.ShouldNotBeNull();
            parametersOftestFunction.Length.ShouldBe(2);
            methodtestFunctionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, parametersOftestFunction, methodtestFunctionPrametersTypes));
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodtestFunctionPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOftestFunction = { data, oWeb };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodtestFunction, methodtestFunctionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOftestFunction);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOftestFunction.ShouldNotBeNull();
            parametersOftestFunction.Length.ShouldBe(2);
            methodtestFunctionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodtestFunctionPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOftestFunction = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, parametersOftestFunction, methodtestFunctionPrametersTypes);

            // Assert
            parametersOftestFunction.ShouldNotBeNull();
            parametersOftestFunction.Length.ShouldBe(2);
            methodtestFunctionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var methodtestFunctionPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, Fixture, methodtestFunctionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodtestFunctionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var methodtestFunctionPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodtestFunction, Fixture, methodtestFunctionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodtestFunctionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodtestFunction, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (testFunction) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_testFunction_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodtestFunction);
            var methodInfo = this.GetMethodInfo(MethodtestFunction, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, Fixture, methodgetSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.getSettings(web, planner);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var methodgetSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetSettings = { web, planner };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetSettings, methodgetSettingsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, Fixture, methodgetSettingsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<PlannerProps>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, parametersOfgetSettings, methodgetSettingsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfgetSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetSettings.ShouldNotBeNull();
            parametersOfgetSettings.Length.ShouldBe(2);
            methodgetSettingsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var web = this.CreateType<SPWeb>();
            var planner = this.CreateType<string>();
            var methodgetSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetSettings = { web, planner };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<PlannerProps>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, parametersOfgetSettings, methodgetSettingsPrametersTypes);

            // Assert
            parametersOfgetSettings.ShouldNotBeNull();
            parametersOfgetSettings.Length.ShouldBe(2);
            methodgetSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var methodgetSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, Fixture, methodgetSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSettingsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var methodgetSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodgetSettings, Fixture, methodgetSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodgetSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getSettings) (Return Type : PlannerProps) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_getSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodgetSettings);
            var methodInfo = this.GetMethodInfo(MethodgetSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetKanBanPlannersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, Fixture, methodGetKanBanPlannersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetKanBanPlanners(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanPlannersPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanPlanners = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanPlanners, methodGetKanBanPlannersPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, Fixture, methodGetKanBanPlannersPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, parametersOfGetKanBanPlanners, methodGetKanBanPlannersPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetKanBanPlanners);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetKanBanPlanners.ShouldNotBeNull();
            parametersOfGetKanBanPlanners.Length.ShouldBe(2);
            methodGetKanBanPlannersPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanPlannersPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanPlanners = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, parametersOfGetKanBanPlanners, methodGetKanBanPlannersPrametersTypes);

            // Assert
            parametersOfGetKanBanPlanners.ShouldNotBeNull();
            parametersOfGetKanBanPlanners.Length.ShouldBe(2);
            methodGetKanBanPlannersPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var methodGetKanBanPlannersPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, Fixture, methodGetKanBanPlannersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetKanBanPlannersPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var methodGetKanBanPlannersPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanPlanners, Fixture, methodGetKanBanPlannersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetKanBanPlannersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanPlanners, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetKanBanPlanners) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanPlanners_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanPlanners);
            var methodInfo = this.GetMethodInfo(MethodGetKanBanPlanners, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetKanBanFilter1PrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, Fixture, methodGetKanBanFilter1PrametersTypes);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetKanBanFilter1(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanFilter1PrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanFilter1 = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanFilter1, methodGetKanBanFilter1PrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, Fixture, methodGetKanBanFilter1PrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, parametersOfGetKanBanFilter1, methodGetKanBanFilter1PrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetKanBanFilter1);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetKanBanFilter1.ShouldNotBeNull();
            parametersOfGetKanBanFilter1.Length.ShouldBe(2);
            methodGetKanBanFilter1PrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanFilter1PrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanFilter1 = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, parametersOfGetKanBanFilter1, methodGetKanBanFilter1PrametersTypes);

            // Assert
            parametersOfGetKanBanFilter1.ShouldNotBeNull();
            parametersOfGetKanBanFilter1.Length.ShouldBe(2);
            methodGetKanBanFilter1PrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var methodGetKanBanFilter1PrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, Fixture, methodGetKanBanFilter1PrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetKanBanFilter1PrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var methodGetKanBanFilter1PrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanFilter1, Fixture, methodGetKanBanFilter1PrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetKanBanFilter1PrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanFilter1, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetKanBanFilter1) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanFilter1_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanFilter1);
            var methodInfo = this.GetMethodInfo(MethodGetKanBanFilter1, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetKanBanBoardPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, Fixture, methodGetKanBanBoardPrametersTypes);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.GetKanBanBoard(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanBoardPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanBoard = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanBoard, methodGetKanBanBoardPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, Fixture, methodGetKanBanBoardPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, parametersOfGetKanBanBoard, methodGetKanBanBoardPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfGetKanBanBoard);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetKanBanBoard.ShouldNotBeNull();
            parametersOfGetKanBanBoard.Length.ShouldBe(2);
            methodGetKanBanBoardPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodGetKanBanBoardPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfGetKanBanBoard = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, parametersOfGetKanBanBoard, methodGetKanBanBoardPrametersTypes);

            // Assert
            parametersOfGetKanBanBoard.ShouldNotBeNull();
            parametersOfGetKanBanBoard.Length.ShouldBe(2);
            methodGetKanBanBoardPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var methodGetKanBanBoardPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, Fixture, methodGetKanBanBoardPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetKanBanBoardPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var methodGetKanBanBoardPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodGetKanBanBoard, Fixture, methodGetKanBanBoardPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetKanBanBoardPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodGetKanBanBoard, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetKanBanBoard) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_GetKanBanBoard_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodGetKanBanBoard);
            var methodInfo = this.GetMethodInfo(MethodGetKanBanBoard, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncodeJsonDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodEncodeJsonData, Fixture, methodEncodeJsonDataPrametersTypes);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            var data = this.CreateType<string>();
            var methodEncodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeJsonData = { data };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodEncodeJsonData, methodEncodeJsonDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfEncodeJsonData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncodeJsonData.ShouldNotBeNull();
            parametersOfEncodeJsonData.Length.ShouldBe(1);
            methodEncodeJsonDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            var data = this.CreateType<string>();
            var methodEncodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeJsonData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodEncodeJsonData, parametersOfEncodeJsonData, methodEncodeJsonDataPrametersTypes);

            // Assert
            parametersOfEncodeJsonData.ShouldNotBeNull();
            parametersOfEncodeJsonData.Length.ShouldBe(1);
            methodEncodeJsonDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            var methodEncodeJsonDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodEncodeJsonData, Fixture, methodEncodeJsonDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEncodeJsonDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            var methodEncodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodEncodeJsonData, Fixture, methodEncodeJsonDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncodeJsonDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodEncodeJsonData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EncodeJsonData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_EncodeJsonData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodEncodeJsonData);
            var methodInfo = this.GetMethodInfo(MethodEncodeJsonData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecodeJsonDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodDecodeJsonData, Fixture, methodDecodeJsonDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            var data = this.CreateType<string>();
            var methodDecodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeJsonData = { data };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodDecodeJsonData, methodDecodeJsonDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfDecodeJsonData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecodeJsonData.ShouldNotBeNull();
            parametersOfDecodeJsonData.Length.ShouldBe(1);
            methodDecodeJsonDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            var data = this.CreateType<string>();
            var methodDecodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeJsonData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodDecodeJsonData, parametersOfDecodeJsonData, methodDecodeJsonDataPrametersTypes);

            // Assert
            parametersOfDecodeJsonData.ShouldNotBeNull();
            parametersOfDecodeJsonData.Length.ShouldBe(1);
            methodDecodeJsonDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            var methodDecodeJsonDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodDecodeJsonData, Fixture, methodDecodeJsonDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDecodeJsonDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            var methodDecodeJsonDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodDecodeJsonData, Fixture, methodDecodeJsonDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeJsonDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodDecodeJsonData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DecodeJsonData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_DecodeJsonData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodDecodeJsonData);
            var methodInfo = this.GetMethodInfo(MethodDecodeJsonData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodReOrderAndSaveItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, Fixture, methodReOrderAndSaveItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkPlannerAPI.ReOrderAndSaveItem(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodReOrderAndSaveItemPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfReOrderAndSaveItem = { data, oWeb };
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodReOrderAndSaveItem, methodReOrderAndSaveItemPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, Fixture, methodReOrderAndSaveItemPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, parametersOfReOrderAndSaveItem, methodReOrderAndSaveItemPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workPlannerAPIInstanceFixture, parametersOfReOrderAndSaveItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReOrderAndSaveItem.ShouldNotBeNull();
            parametersOfReOrderAndSaveItem.Length.ShouldBe(2);
            methodReOrderAndSaveItemPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var data = this.CreateType<XmlDocument>();
            var oWeb = this.CreateType<SPWeb>();
            var methodReOrderAndSaveItemPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            object[] parametersOfReOrderAndSaveItem = { data, oWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, parametersOfReOrderAndSaveItem, methodReOrderAndSaveItemPrametersTypes);

            // Assert
            parametersOfReOrderAndSaveItem.ShouldNotBeNull();
            parametersOfReOrderAndSaveItem.Length.ShouldBe(2);
            methodReOrderAndSaveItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var methodReOrderAndSaveItemPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, Fixture, methodReOrderAndSaveItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReOrderAndSaveItemPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var methodReOrderAndSaveItemPrametersTypes = new Type[] { typeof(XmlDocument), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workPlannerAPIInstanceFixture, _workPlannerAPIInstanceType, MethodReOrderAndSaveItem, Fixture, methodReOrderAndSaveItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReOrderAndSaveItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodReOrderAndSaveItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workPlannerAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReOrderAndSaveItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkPlannerAPI_ReOrderAndSaveItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodReOrderAndSaveItem);
            var methodInfo = this.GetMethodInfo(MethodReOrderAndSaveItem, 0);
            const int parametersCount = 2;

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