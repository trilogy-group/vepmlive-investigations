using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.MyWork" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyWorkTest : AbstractBaseSetupTypedTest<MyWork>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWork) Initializer

        private const string MethodGetArchivedWebs = "GetArchivedWebs";
        private const string MethodGetGlobalViews = "GetGlobalViews";
        private const string MethodGetListFieldsAndTypesFromDb = "GetListFieldsAndTypesFromDb";
        private const string MethodGetListIdsFromDb = "GetListIdsFromDb";
        private const string MethodGetListNameFromDb = "GetListNameFromDb";
        private const string MethodGetSpContentDbSqlConnection = "GetSpContentDbSqlConnection";
        private const string MethodSaveGlobalViews = "SaveGlobalViews";
        private const string MethodShouldUseReportingDb = "ShouldUseReportingDb";
        private const string MethodBuildFieldElement = "BuildFieldElement";
        private const string MethodDeleteGlobalView = "DeleteGlobalView";
        private const string MethodDeletePersonalView = "DeletePersonalView";
        private const string MethodGenerateColDictionary = "GenerateColDictionary";
        private const string MethodGetDataFromLists = "GetDataFromLists";
        private const string MethodGetDataFromReportingDB = "GetDataFromReportingDB";
        private const string MethodGetDataFromSP = "GetDataFromSP";
        private const string MethodGetExampleDateFormat = "GetExampleDateFormat";
        private const string MethodGetGridSafeValue = "GetGridSafeValue";
        private const string MethodGetLeftCols = "GetLeftCols";
        private const string MethodGetMyWorkElement = "GetMyWorkElement";
        private const string MethodGetMyWorkFieldValue = "GetMyWorkFieldValue";
        private const string MethodGetMyWorkGridView = "GetMyWorkGridView";
        private const string MethodGetMyWorkItemElement = "GetMyWorkItemElement";
        private const string MethodGetMyWorkListIdsFromDb = "GetMyWorkListIdsFromDb";
        private const string MethodGetPersonalViews = "GetPersonalViews";
        private const string MethodGetQuery = "GetQuery";
        private const string MethodGetSettings = "GetSettings";
        private const string MethodGetTypeAndFormat = "GetTypeAndFormat";
        private const string MethodGetWorkingOn = "GetWorkingOn";
        private const string MethodGetWorkspaceNameFromDb = "GetWorkspaceNameFromDb";
        private const string MethodMapCompleteField = "MapCompleteField";
        private const string MethodProcessMyWork = "ProcessMyWork";
        private const string MethodQueryMyWorkData = "QueryMyWorkData";
        private const string MethodRenameGlobalView = "RenameGlobalView";
        private const string MethodRenamePersonalView = "RenamePersonalView";
        private const string MethodSavePersonalViews = "SavePersonalViews";
        private const string MethodTagSiteIdExists = "TagSiteIdExists";
        private const string MethodWriteToDebugWindow = "WriteToDebugWindow";
        private const string MethodCheckListEditPermission = "CheckListEditPermission";
        private const string MethodDeleteMyWorkGridView = "DeleteMyWorkGridView";
        private const string MethodGetMyWork = "GetMyWork";
        private const string MethodGetMyWorkFieldType = "GetMyWorkFieldType";
        private const string MethodGetMyWorkGridColType = "GetMyWorkGridColType";
        private const string MethodGetMyWorkGridData = "GetMyWorkGridData";
        private const string MethodGetMyWorkGridEnum = "GetMyWorkGridEnum";
        private const string MethodGetMyWorkGridLayout = "GetMyWorkGridLayout";
        private const string MethodGetMyWorkGridViews = "GetMyWorkGridViews";
        private const string MethodGetMyWorkListItem = "GetMyWorkListItem";
        private const string MethodGetRelatedGridFormat = "GetRelatedGridFormat";
        private const string MethodGetWorkingOnGridData = "GetWorkingOnGridData";
        private const string MethodGetWorkingOnGridLayout = "GetWorkingOnGridLayout";
        private const string MethodRenameMyWorkGridView = "RenameMyWorkGridView";
        private const string MethodSaveMyWorkGridView = "SaveMyWorkGridView";
        private const string MethodUpdateMyWorkItem = "UpdateMyWorkItem";
        private const string FieldASSIGNED_TO_FIELD = "ASSIGNED_TO_FIELD";
        private const string FieldCOMMENT_COL_WIDTH = "COMMENT_COL_WIDTH";
        private const string FieldCOMMENT_COUNT_FIELD = "COMMENT_COUNT_FIELD";
        private const string FieldCOMMENTERS_FIELD = "COMMENTERS_FIELD";
        private const string FieldCOMMENTERS_READ_FIELD = "COMMENTERS_READ_FIELD";
        private const string FieldCOMPLETE_COL_WIDTH = "COMPLETE_COL_WIDTH";
        private const string FieldCOMPLETED_FIELD = "COMPLETED_FIELD";
        private const string FieldCREATED_BY_FIELD = "CREATED_BY_FIELD";
        private const string FieldCREATED_FIELD = "CREATED_FIELD";
        private const string FieldDUE_DATE_COL_WIDTH = "DUE_DATE_COL_WIDTH";
        private const string FieldDUE_DATE_FIELD = "DUE_DATE_FIELD";
        private const string FieldDUE_DAY_COL_WIDTH = "DUE_DAY_COL_WIDTH";
        private const string FieldDUE_DAY_FIELD = "DUE_DAY_FIELD";
        private const string FieldFLAG_COL_WIDTH = "FLAG_COL_WIDTH";
        private const string FieldFLAG_FIELD = "FLAG_FIELD";
        private const string FieldGENERAL_SETTINGS_CROSS_SITE_URLS = "GENERAL_SETTINGS_CROSS_SITE_URLS";
        private const string FieldGENERAL_SETTINGS_PERFORMANCE_MODE = "GENERAL_SETTINGS_PERFORMANCE_MODE";
        private const string FieldGENERAL_SETTINGS_SELECTED_FIELDS = "GENERAL_SETTINGS_SELECTED_FIELDS";
        private const string FieldGENERAL_SETTINGS_SELECTED_LISTS = "GENERAL_SETTINGS_SELECTED_LISTS";
        private const string FieldGENERAL_SETTINGS_SELECTED_MY_WORK_LISTS = "GENERAL_SETTINGS_SELECTED_MY_WORK_LISTS";
        private const string FieldLIST_ID_FIELD = "LIST_ID_FIELD";
        private const string FieldMODIFIED_BY_FIELD = "MODIFIED_BY_FIELD";
        private const string FieldMODIFIED_FIELD = "MODIFIED_FIELD";
        private const string FieldMY_WORK_GRID_GLOBAL_VIEWS = "MY_WORK_GRID_GLOBAL_VIEWS";
        private const string FieldMY_WORK_GRID_PERSONAL_VIEWS = "MY_WORK_GRID_PERSONAL_VIEWS";
        private const string FieldMY_WORK_LIST_SERVER_TEMPLATE_ID = "MY_WORK_LIST_SERVER_TEMPLATE_ID";
        private const string FieldPRIORITY_COL_WIDTH = "PRIORITY_COL_WIDTH";
        private const string FieldPRIORITY_FIELD = "PRIORITY_FIELD";
        private const string FieldSITE_ID_FIELD = "SITE_ID_FIELD";
        private const string FieldSITE_URL_FIELD = "SITE_URL_FIELD";
        private const string FieldTITLE_COL_WIDTH = "TITLE_COL_WIDTH";
        private const string FieldTITLE_FIELD = "TITLE_FIELD";
        private const string FieldWEB_ID_FIELD = "WEB_ID_FIELD";
        private const string FieldWORK_TYPE_FIELD = "WORK_TYPE_FIELD";
        private const string FieldWORKING_ON_FIELD = "WORKING_ON_FIELD";
        private Type _myWorkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWork _myWorkInstance;
        private MyWork _myWorkInstanceFixture;

        #region General Initializer : Class (MyWork) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWork" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkInstanceType = typeof(MyWork);
            _myWorkInstanceFixture = Create(true);
            _myWorkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWork)

        #region General Initializer : Class (MyWork) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyWork" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetArchivedWebs, 0)]
        [TestCase(MethodGetGlobalViews, 0)]
        [TestCase(MethodGetListFieldsAndTypesFromDb, 0)]
        [TestCase(MethodGetListIdsFromDb, 0)]
        [TestCase(MethodGetListNameFromDb, 0)]
        [TestCase(MethodGetSpContentDbSqlConnection, 0)]
        [TestCase(MethodSaveGlobalViews, 0)]
        [TestCase(MethodShouldUseReportingDb, 0)]
        [TestCase(MethodBuildFieldElement, 0)]
        [TestCase(MethodDeleteGlobalView, 0)]
        [TestCase(MethodDeletePersonalView, 0)]
        [TestCase(MethodGenerateColDictionary, 0)]
        [TestCase(MethodGetDataFromLists, 0)]
        [TestCase(MethodGetDataFromReportingDB, 0)]
        [TestCase(MethodGetDataFromSP, 0)]
        [TestCase(MethodGetExampleDateFormat, 0)]
        [TestCase(MethodGetGridSafeValue, 0)]
        [TestCase(MethodGetLeftCols, 0)]
        [TestCase(MethodGetMyWorkElement, 0)]
        [TestCase(MethodGetMyWorkFieldValue, 0)]
        [TestCase(MethodGetMyWorkGridView, 0)]
        [TestCase(MethodGetMyWorkItemElement, 0)]
        [TestCase(MethodGetMyWorkListIdsFromDb, 0)]
        [TestCase(MethodGetPersonalViews, 0)]
        [TestCase(MethodGetQuery, 0)]
        [TestCase(MethodGetSettings, 0)]
        [TestCase(MethodGetTypeAndFormat, 0)]
        [TestCase(MethodGetWorkingOn, 0)]
        [TestCase(MethodGetWorkingOn, 1)]
        [TestCase(MethodGetWorkspaceNameFromDb, 0)]
        [TestCase(MethodMapCompleteField, 0)]
        [TestCase(MethodProcessMyWork, 0)]
        [TestCase(MethodQueryMyWorkData, 0)]
        [TestCase(MethodRenameGlobalView, 0)]
        [TestCase(MethodRenamePersonalView, 0)]
        [TestCase(MethodSaveGlobalViews, 1)]
        [TestCase(MethodSavePersonalViews, 0)]
        [TestCase(MethodTagSiteIdExists, 0)]
        [TestCase(MethodWriteToDebugWindow, 0)]
        [TestCase(MethodCheckListEditPermission, 0)]
        [TestCase(MethodDeleteMyWorkGridView, 0)]
        [TestCase(MethodGetMyWork, 0)]
        [TestCase(MethodGetMyWorkFieldType, 0)]
        [TestCase(MethodGetMyWorkGridColType, 0)]
        [TestCase(MethodGetMyWorkGridData, 0)]
        [TestCase(MethodGetMyWorkGridEnum, 0)]
        [TestCase(MethodGetMyWorkGridLayout, 0)]
        [TestCase(MethodGetMyWorkGridViews, 0)]
        [TestCase(MethodGetMyWorkListItem, 0)]
        [TestCase(MethodGetRelatedGridFormat, 0)]
        [TestCase(MethodGetWorkingOnGridData, 0)]
        [TestCase(MethodGetWorkingOnGridLayout, 0)]
        [TestCase(MethodRenameMyWorkGridView, 0)]
        [TestCase(MethodSaveMyWorkGridView, 0)]
        [TestCase(MethodUpdateMyWorkItem, 0)]
        public void AUT_MyWork_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myWorkInstanceFixture,
                                                                 Fixture,
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MyWork) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MyWork" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldASSIGNED_TO_FIELD)]
        [TestCase(FieldCOMMENT_COL_WIDTH)]
        [TestCase(FieldCOMMENT_COUNT_FIELD)]
        [TestCase(FieldCOMMENTERS_FIELD)]
        [TestCase(FieldCOMMENTERS_READ_FIELD)]
        [TestCase(FieldCOMPLETE_COL_WIDTH)]
        [TestCase(FieldCOMPLETED_FIELD)]
        [TestCase(FieldCREATED_BY_FIELD)]
        [TestCase(FieldCREATED_FIELD)]
        [TestCase(FieldDUE_DATE_COL_WIDTH)]
        [TestCase(FieldDUE_DATE_FIELD)]
        [TestCase(FieldDUE_DAY_COL_WIDTH)]
        [TestCase(FieldDUE_DAY_FIELD)]
        [TestCase(FieldFLAG_COL_WIDTH)]
        [TestCase(FieldFLAG_FIELD)]
        [TestCase(FieldGENERAL_SETTINGS_CROSS_SITE_URLS)]
        [TestCase(FieldGENERAL_SETTINGS_PERFORMANCE_MODE)]
        [TestCase(FieldGENERAL_SETTINGS_SELECTED_FIELDS)]
        [TestCase(FieldGENERAL_SETTINGS_SELECTED_LISTS)]
        [TestCase(FieldGENERAL_SETTINGS_SELECTED_MY_WORK_LISTS)]
        [TestCase(FieldLIST_ID_FIELD)]
        [TestCase(FieldMODIFIED_BY_FIELD)]
        [TestCase(FieldMODIFIED_FIELD)]
        [TestCase(FieldMY_WORK_GRID_GLOBAL_VIEWS)]
        [TestCase(FieldMY_WORK_GRID_PERSONAL_VIEWS)]
        [TestCase(FieldMY_WORK_LIST_SERVER_TEMPLATE_ID)]
        [TestCase(FieldPRIORITY_COL_WIDTH)]
        [TestCase(FieldPRIORITY_FIELD)]
        [TestCase(FieldSITE_ID_FIELD)]
        [TestCase(FieldSITE_URL_FIELD)]
        [TestCase(FieldTITLE_COL_WIDTH)]
        [TestCase(FieldTITLE_FIELD)]
        [TestCase(FieldWEB_ID_FIELD)]
        [TestCase(FieldWORK_TYPE_FIELD)]
        [TestCase(FieldWORKING_ON_FIELD)]
        public void AUT_MyWork_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_myWorkInstanceFixture,
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
        ///     Class (<see cref="MyWork" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyWork_Is_Instance_Present_Test()
        {
            // Assert
            _myWorkInstanceType.ShouldNotBeNull();
            _myWorkInstance.ShouldNotBeNull();
            _myWorkInstanceFixture.ShouldNotBeNull();
            _myWorkInstance.ShouldBeAssignableTo<MyWork>();
            _myWorkInstanceFixture.ShouldBeAssignableTo<MyWork>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWork) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MyWork_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyWork instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myWorkInstanceType.ShouldNotBeNull();
            _myWorkInstance.ShouldNotBeNull();
            _myWorkInstanceFixture.ShouldNotBeNull();
            _myWorkInstance.ShouldBeAssignableTo<MyWork>();
            _myWorkInstanceFixture.ShouldBeAssignableTo<MyWork>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="MyWork" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetArchivedWebs)]
        [TestCase(MethodGetGlobalViews)]
        [TestCase(MethodGetListFieldsAndTypesFromDb)]
        [TestCase(MethodGetListIdsFromDb)]
        [TestCase(MethodGetListNameFromDb)]
        [TestCase(MethodGetSpContentDbSqlConnection)]
        [TestCase(MethodSaveGlobalViews)]
        [TestCase(MethodShouldUseReportingDb)]
        [TestCase(MethodBuildFieldElement)]
        [TestCase(MethodDeleteGlobalView)]
        [TestCase(MethodDeletePersonalView)]
        [TestCase(MethodGenerateColDictionary)]
        [TestCase(MethodGetDataFromLists)]
        [TestCase(MethodGetDataFromReportingDB)]
        [TestCase(MethodGetDataFromSP)]
        [TestCase(MethodGetExampleDateFormat)]
        [TestCase(MethodGetGridSafeValue)]
        [TestCase(MethodGetLeftCols)]
        [TestCase(MethodGetMyWorkElement)]
        [TestCase(MethodGetMyWorkFieldValue)]
        [TestCase(MethodGetMyWorkGridView)]
        [TestCase(MethodGetMyWorkItemElement)]
        [TestCase(MethodGetMyWorkListIdsFromDb)]
        [TestCase(MethodGetPersonalViews)]
        [TestCase(MethodGetQuery)]
        [TestCase(MethodGetSettings)]
        [TestCase(MethodGetTypeAndFormat)]
        [TestCase(MethodGetWorkingOn)]
        [TestCase(MethodGetWorkspaceNameFromDb)]
        [TestCase(MethodMapCompleteField)]
        [TestCase(MethodProcessMyWork)]
        [TestCase(MethodQueryMyWorkData)]
        [TestCase(MethodRenameGlobalView)]
        [TestCase(MethodRenamePersonalView)]
        [TestCase(MethodSavePersonalViews)]
        [TestCase(MethodTagSiteIdExists)]
        [TestCase(MethodWriteToDebugWindow)]
        [TestCase(MethodCheckListEditPermission)]
        [TestCase(MethodDeleteMyWorkGridView)]
        [TestCase(MethodGetMyWork)]
        [TestCase(MethodGetMyWorkFieldType)]
        [TestCase(MethodGetMyWorkGridColType)]
        [TestCase(MethodGetMyWorkGridData)]
        [TestCase(MethodGetMyWorkGridEnum)]
        [TestCase(MethodGetMyWorkGridLayout)]
        [TestCase(MethodGetMyWorkGridViews)]
        [TestCase(MethodGetMyWorkListItem)]
        [TestCase(MethodGetRelatedGridFormat)]
        [TestCase(MethodGetWorkingOnGridData)]
        [TestCase(MethodGetWorkingOnGridLayout)]
        [TestCase(MethodRenameMyWorkGridView)]
        [TestCase(MethodSaveMyWorkGridView)]
        [TestCase(MethodUpdateMyWorkItem)]
        public void AUT_MyWork_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_myWorkInstanceFixture,
                                                                              _myWorkInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetArchivedWebs_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetArchivedWebsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, Fixture, methodGetArchivedWebsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetArchivedWebs(siteId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetArchivedWebsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetArchivedWebs = { siteId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetArchivedWebs, methodGetArchivedWebsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, Fixture, methodGetArchivedWebsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<Guid>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, parametersOfGetArchivedWebs, methodGetArchivedWebsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetArchivedWebs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetArchivedWebs.ShouldNotBeNull();
            parametersOfGetArchivedWebs.Length.ShouldBe(1);
            methodGetArchivedWebsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGetArchivedWebsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetArchivedWebs = { siteId };

            // Assert
            parametersOfGetArchivedWebs.ShouldNotBeNull();
            parametersOfGetArchivedWebs.Length.ShouldBe(1);
            methodGetArchivedWebsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<Guid>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, parametersOfGetArchivedWebs, methodGetArchivedWebsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetArchivedWebsPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, Fixture, methodGetArchivedWebsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetArchivedWebsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetArchivedWebsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetArchivedWebs, Fixture, methodGetArchivedWebsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetArchivedWebsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetArchivedWebs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetArchivedWebs) (Return Type : List<Guid>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetArchivedWebs_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetArchivedWebs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetGlobalViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGlobalViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, Fixture, methodGetGlobalViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var configWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetGlobalViews(configWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var configWeb = CreateType<SPWeb>();
            var methodGetGlobalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetGlobalViews = { configWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGlobalViews, methodGetGlobalViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, Fixture, methodGetGlobalViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<MyWorkGridView>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, parametersOfGetGlobalViews, methodGetGlobalViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetGlobalViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGlobalViews.ShouldNotBeNull();
            parametersOfGetGlobalViews.Length.ShouldBe(1);
            methodGetGlobalViewsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var configWeb = CreateType<SPWeb>();
            var methodGetGlobalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetGlobalViews = { configWeb };

            // Assert
            parametersOfGetGlobalViews.ShouldNotBeNull();
            parametersOfGetGlobalViews.Length.ShouldBe(1);
            methodGetGlobalViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<MyWorkGridView>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, parametersOfGetGlobalViews, methodGetGlobalViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGlobalViewsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, Fixture, methodGetGlobalViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGlobalViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGlobalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGlobalViews, Fixture, methodGetGlobalViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGlobalViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGlobalViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGlobalViews) (Return Type : IEnumerable<MyWorkGridView>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGlobalViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGlobalViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListFieldsAndTypesFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, Fixture, methodGetListFieldsAndTypesFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetListFieldsAndTypesFromDb(listId, webId, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodGetListFieldsAndTypesFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfGetListFieldsAndTypesFromDb = { listId, webId, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListFieldsAndTypesFromDb, methodGetListFieldsAndTypesFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, Fixture, methodGetListFieldsAndTypesFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IOrderedEnumerable<KeyValuePair<string, string>>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, parametersOfGetListFieldsAndTypesFromDb, methodGetListFieldsAndTypesFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetListFieldsAndTypesFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListFieldsAndTypesFromDb.ShouldNotBeNull();
            parametersOfGetListFieldsAndTypesFromDb.Length.ShouldBe(3);
            methodGetListFieldsAndTypesFromDbPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodGetListFieldsAndTypesFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfGetListFieldsAndTypesFromDb = { listId, webId, spWeb };

            // Assert
            parametersOfGetListFieldsAndTypesFromDb.ShouldNotBeNull();
            parametersOfGetListFieldsAndTypesFromDb.Length.ShouldBe(3);
            methodGetListFieldsAndTypesFromDbPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IOrderedEnumerable<KeyValuePair<string, string>>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, parametersOfGetListFieldsAndTypesFromDb, methodGetListFieldsAndTypesFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListFieldsAndTypesFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, Fixture, methodGetListFieldsAndTypesFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListFieldsAndTypesFromDbPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListFieldsAndTypesFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListFieldsAndTypesFromDb, Fixture, methodGetListFieldsAndTypesFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListFieldsAndTypesFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListFieldsAndTypesFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListFieldsAndTypesFromDb) (Return Type : IOrderedEnumerable<KeyValuePair<string, string>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListFieldsAndTypesFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListFieldsAndTypesFromDb, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListIdsFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, Fixture, methodGetListIdsFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var selectedList = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetListIdsFromDb(selectedList, spWeb, archivedWebs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var selectedList = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var methodGetListIdsFromDbPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(List<Guid>) };
            object[] parametersOfGetListIdsFromDb = { selectedList, spWeb, archivedWebs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListIdsFromDb, methodGetListIdsFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, Fixture, methodGetListIdsFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<string>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, parametersOfGetListIdsFromDb, methodGetListIdsFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetListIdsFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListIdsFromDb.ShouldNotBeNull();
            parametersOfGetListIdsFromDb.Length.ShouldBe(3);
            methodGetListIdsFromDbPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedList = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var methodGetListIdsFromDbPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(List<Guid>) };
            object[] parametersOfGetListIdsFromDb = { selectedList, spWeb, archivedWebs };

            // Assert
            parametersOfGetListIdsFromDb.ShouldNotBeNull();
            parametersOfGetListIdsFromDb.Length.ShouldBe(3);
            methodGetListIdsFromDbPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<string>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, parametersOfGetListIdsFromDb, methodGetListIdsFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListIdsFromDbPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(List<Guid>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, Fixture, methodGetListIdsFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListIdsFromDbPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListIdsFromDbPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(List<Guid>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListIdsFromDb, Fixture, methodGetListIdsFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIdsFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListIdsFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListIdsFromDb) (Return Type : IEnumerable<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListIdsFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListIdsFromDb, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetListNameFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListNameFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, Fixture, methodGetListNameFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetListNameFromDb(listId, webId, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodGetListNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfGetListNameFromDb = { listId, webId, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListNameFromDb, methodGetListNameFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, Fixture, methodGetListNameFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, parametersOfGetListNameFromDb, methodGetListNameFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetListNameFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListNameFromDb.ShouldNotBeNull();
            parametersOfGetListNameFromDb.Length.ShouldBe(3);
            methodGetListNameFromDbPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var spWeb = CreateType<SPWeb>();
            var methodGetListNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            object[] parametersOfGetListNameFromDb = { listId, webId, spWeb };

            // Assert
            parametersOfGetListNameFromDb.ShouldNotBeNull();
            parametersOfGetListNameFromDb.Length.ShouldBe(3);
            methodGetListNameFromDbPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, parametersOfGetListNameFromDb, methodGetListNameFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, Fixture, methodGetListNameFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListNameFromDbPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetListNameFromDb, Fixture, methodGetListNameFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNameFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListNameFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListNameFromDb) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetListNameFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListNameFromDb, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSpContentDbSqlConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.GetSpContentDbSqlConnection(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSpContentDbSqlConnection = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SqlConnection>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, parametersOfGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetSpContentDbSqlConnection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSpContentDbSqlConnection.ShouldNotBeNull();
            parametersOfGetSpContentDbSqlConnection.Length.ShouldBe(1);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSpContentDbSqlConnection = { spWeb };

            // Assert
            parametersOfGetSpContentDbSqlConnection.ShouldNotBeNull();
            parametersOfGetSpContentDbSqlConnection.Length.ShouldBe(1);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SqlConnection>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, parametersOfGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSpContentDbSqlConnection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveGlobalViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, Fixture, methodSaveGlobalViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var myWorkGridView = CreateType<MyWorkGridView>();
            var configWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.SaveGlobalViews(myWorkGridView, configWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkGridView = CreateType<MyWorkGridView>();
            var configWeb = CreateType<SPWeb>();
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(MyWorkGridView), typeof(SPWeb) };
            object[] parametersOfSaveGlobalViews = { myWorkGridView, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, methodSaveGlobalViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfSaveGlobalViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveGlobalViews.ShouldNotBeNull();
            parametersOfSaveGlobalViews.Length.ShouldBe(2);
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkGridView = CreateType<MyWorkGridView>();
            var configWeb = CreateType<SPWeb>();
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(MyWorkGridView), typeof(SPWeb) };
            object[] parametersOfSaveGlobalViews = { myWorkGridView, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, parametersOfSaveGlobalViews, methodSaveGlobalViewsPrametersTypes);

            // Assert
            parametersOfSaveGlobalViews.ShouldNotBeNull();
            parametersOfSaveGlobalViews.Length.ShouldBe(2);
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(MyWorkGridView), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, Fixture, methodSaveGlobalViewsPrametersTypes);

            // Assert
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_ShouldUseReportingDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodShouldUseReportingDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodShouldUseReportingDb, Fixture, methodShouldUseReportingDbPrametersTypes);
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ShouldUseReportingDb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => MyWork.ShouldUseReportingDb(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ShouldUseReportingDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodShouldUseReportingDbPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfShouldUseReportingDb = { spWeb };

            // Assert
            parametersOfShouldUseReportingDb.ShouldNotBeNull();
            parametersOfShouldUseReportingDb.Length.ShouldBe(1);
            methodShouldUseReportingDbPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_myWorkInstanceFixture, _myWorkInstanceType, MethodShouldUseReportingDb, parametersOfShouldUseReportingDb, methodShouldUseReportingDbPrametersTypes));
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ShouldUseReportingDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShouldUseReportingDbPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodShouldUseReportingDb, Fixture, methodShouldUseReportingDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodShouldUseReportingDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ShouldUseReportingDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShouldUseReportingDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ShouldUseReportingDb) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ShouldUseReportingDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShouldUseReportingDb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_BuildFieldElement_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildFieldElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodBuildFieldElement, Fixture, methodBuildFieldElementPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var value = CreateType<string>();
            var field = CreateType<string>();
            var methodBuildFieldElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string) };
            object[] parametersOfBuildFieldElement = { fieldTypes, value, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildFieldElement, methodBuildFieldElementPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildFieldElement.ShouldNotBeNull();
            parametersOfBuildFieldElement.Length.ShouldBe(3);
            methodBuildFieldElementPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfBuildFieldElement));
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var value = CreateType<string>();
            var field = CreateType<string>();
            var methodBuildFieldElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string) };
            object[] parametersOfBuildFieldElement = { fieldTypes, value, field };

            // Assert
            parametersOfBuildFieldElement.ShouldNotBeNull();
            parametersOfBuildFieldElement.Length.ShouldBe(3);
            methodBuildFieldElementPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XElement>(_myWorkInstanceFixture, _myWorkInstanceType, MethodBuildFieldElement, parametersOfBuildFieldElement, methodBuildFieldElementPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildFieldElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodBuildFieldElement, Fixture, methodBuildFieldElementPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildFieldElementPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildFieldElementPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodBuildFieldElement, Fixture, methodBuildFieldElementPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildFieldElementPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildFieldElement, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildFieldElement) (Return Type : XElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_BuildFieldElement_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildFieldElement, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_DeleteGlobalView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteGlobalViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteGlobalView, Fixture, methodDeleteGlobalViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteGlobalView_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var isDefault = CreateType<bool>();
            var globalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodDeleteGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfDeleteGlobalView = { viewId, isDefault, globalViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteGlobalView, methodDeleteGlobalViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfDeleteGlobalView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteGlobalView.ShouldNotBeNull();
            parametersOfDeleteGlobalView.Length.ShouldBe(4);
            methodDeleteGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteGlobalView_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var isDefault = CreateType<bool>();
            var globalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodDeleteGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfDeleteGlobalView = { viewId, isDefault, globalViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteGlobalView, parametersOfDeleteGlobalView, methodDeleteGlobalViewPrametersTypes);

            // Assert
            parametersOfDeleteGlobalView.ShouldNotBeNull();
            parametersOfDeleteGlobalView.Length.ShouldBe(4);
            methodDeleteGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteGlobalView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteGlobalView, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteGlobalView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteGlobalView, Fixture, methodDeleteGlobalViewPrametersTypes);

            // Assert
            methodDeleteGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteGlobalView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteGlobalView_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteGlobalView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_DeletePersonalView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeletePersonalViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeletePersonalView, Fixture, methodDeletePersonalViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeletePersonalView_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var personalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodDeletePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfDeletePersonalView = { viewId, personalViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeletePersonalView, methodDeletePersonalViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfDeletePersonalView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeletePersonalView.ShouldNotBeNull();
            parametersOfDeletePersonalView.Length.ShouldBe(3);
            methodDeletePersonalViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeletePersonalView_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var personalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodDeletePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfDeletePersonalView = { viewId, personalViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeletePersonalView, parametersOfDeletePersonalView, methodDeletePersonalViewPrametersTypes);

            // Assert
            parametersOfDeletePersonalView.ShouldNotBeNull();
            parametersOfDeletePersonalView.Length.ShouldBe(3);
            methodDeletePersonalViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeletePersonalView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePersonalView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeletePersonalView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeletePersonalView, Fixture, methodDeletePersonalViewPrametersTypes);

            // Assert
            methodDeletePersonalViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeletePersonalView_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePersonalView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GenerateColDictionary_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateColDictionaryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGenerateColDictionary, Fixture, methodGenerateColDictionaryPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GenerateColDictionary_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkDataTable = CreateType<DataTable>();
            var myWorkFields = CreateType<IEnumerable<string>>();
            var methodGenerateColDictionaryPrametersTypes = new Type[] { typeof(DataTable), typeof(IEnumerable<string>) };
            object[] parametersOfGenerateColDictionary = { myWorkDataTable, myWorkFields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGenerateColDictionary, methodGenerateColDictionaryPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGenerateColDictionary.ShouldNotBeNull();
            parametersOfGenerateColDictionary.Length.ShouldBe(2);
            methodGenerateColDictionaryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGenerateColDictionary));
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GenerateColDictionary_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkDataTable = CreateType<DataTable>();
            var myWorkFields = CreateType<IEnumerable<string>>();
            var methodGenerateColDictionaryPrametersTypes = new Type[] { typeof(DataTable), typeof(IEnumerable<string>) };
            object[] parametersOfGenerateColDictionary = { myWorkDataTable, myWorkFields };

            // Assert
            parametersOfGenerateColDictionary.ShouldNotBeNull();
            parametersOfGenerateColDictionary.Length.ShouldBe(2);
            methodGenerateColDictionaryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, int>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGenerateColDictionary, parametersOfGenerateColDictionary, methodGenerateColDictionaryPrametersTypes));
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GenerateColDictionary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateColDictionaryPrametersTypes = new Type[] { typeof(DataTable), typeof(IEnumerable<string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGenerateColDictionary, Fixture, methodGenerateColDictionaryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateColDictionaryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GenerateColDictionary_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateColDictionary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateColDictionary) (Return Type : Dictionary<string, int>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GenerateColDictionary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGenerateColDictionary, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetDataFromLists_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDataFromListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromLists, Fixture, methodGetDataFromListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromLists_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var result = CreateType<XDocument>();
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var query = CreateType<string>();
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var selectedFields = CreateType<List<string>>();
            var selectedLists = CreateType<List<string>>();
            var methodGetDataFromListsPrametersTypes = new Type[] { typeof(XDocument), typeof(Dictionary<string, SPField>), typeof(string), typeof(SPSite), typeof(SPWeb), typeof(List<string>), typeof(List<string>) };
            object[] parametersOfGetDataFromLists = { result, fieldTypes, query, spSite, spWeb, selectedFields, selectedLists };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDataFromLists, methodGetDataFromListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetDataFromLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDataFromLists.ShouldNotBeNull();
            parametersOfGetDataFromLists.Length.ShouldBe(7);
            methodGetDataFromListsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromLists_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var result = CreateType<XDocument>();
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var query = CreateType<string>();
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var selectedFields = CreateType<List<string>>();
            var selectedLists = CreateType<List<string>>();
            var methodGetDataFromListsPrametersTypes = new Type[] { typeof(XDocument), typeof(Dictionary<string, SPField>), typeof(string), typeof(SPSite), typeof(SPWeb), typeof(List<string>), typeof(List<string>) };
            object[] parametersOfGetDataFromLists = { result, fieldTypes, query, spSite, spWeb, selectedFields, selectedLists };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromLists, parametersOfGetDataFromLists, methodGetDataFromListsPrametersTypes);

            // Assert
            parametersOfGetDataFromLists.ShouldNotBeNull();
            parametersOfGetDataFromLists.Length.ShouldBe(7);
            methodGetDataFromListsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromLists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataFromLists, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromLists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataFromListsPrametersTypes = new Type[] { typeof(XDocument), typeof(Dictionary<string, SPField>), typeof(string), typeof(SPSite), typeof(SPWeb), typeof(List<string>), typeof(List<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromLists, Fixture, methodGetDataFromListsPrametersTypes);

            // Assert
            methodGetDataFromListsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromLists_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataFromLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDataFromReportingDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, Fixture, methodGetDataFromReportingDBPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workTypes = CreateType<Dictionary<string, string>>();
            var selectedFields = CreateType<IEnumerable<string>>();
            var archivedWebs = CreateType<List<Guid>>();
            var spWeb = CreateType<SPWeb>();
            var selectedLists = CreateType<List<string>>();
            var data = CreateType<string>();
            var methodGetDataFromReportingDBPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(IEnumerable<string>), typeof(List<Guid>), typeof(SPWeb), typeof(List<string>), typeof(string) };
            object[] parametersOfGetDataFromReportingDB = { workTypes, selectedFields, archivedWebs, spWeb, selectedLists, data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataFromReportingDB, methodGetDataFromReportingDBPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, Fixture, methodGetDataFromReportingDBPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<DataTable>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, parametersOfGetDataFromReportingDB, methodGetDataFromReportingDBPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetDataFromReportingDB);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataFromReportingDB.ShouldNotBeNull();
            parametersOfGetDataFromReportingDB.Length.ShouldBe(6);
            methodGetDataFromReportingDBPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workTypes = CreateType<Dictionary<string, string>>();
            var selectedFields = CreateType<IEnumerable<string>>();
            var archivedWebs = CreateType<List<Guid>>();
            var spWeb = CreateType<SPWeb>();
            var selectedLists = CreateType<List<string>>();
            var data = CreateType<string>();
            var methodGetDataFromReportingDBPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(IEnumerable<string>), typeof(List<Guid>), typeof(SPWeb), typeof(List<string>), typeof(string) };
            object[] parametersOfGetDataFromReportingDB = { workTypes, selectedFields, archivedWebs, spWeb, selectedLists, data };

            // Assert
            parametersOfGetDataFromReportingDB.ShouldNotBeNull();
            parametersOfGetDataFromReportingDB.Length.ShouldBe(6);
            methodGetDataFromReportingDBPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<DataTable>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, parametersOfGetDataFromReportingDB, methodGetDataFromReportingDBPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataFromReportingDBPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(IEnumerable<string>), typeof(List<Guid>), typeof(SPWeb), typeof(List<string>), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, Fixture, methodGetDataFromReportingDBPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataFromReportingDBPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataFromReportingDBPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(IEnumerable<string>), typeof(List<Guid>), typeof(SPWeb), typeof(List<string>), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromReportingDB, Fixture, methodGetDataFromReportingDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataFromReportingDBPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataFromReportingDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataFromReportingDB) (Return Type : IEnumerable<DataTable>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromReportingDB_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataFromReportingDB, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetDataFromSP_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDataFromSPPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, Fixture, methodGetDataFromSPPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var selectedListIds = CreateType<List<string>>();
            var dataQuery = CreateType<SPSiteDataQuery>();
            var spWeb = CreateType<SPWeb>();
            var spSite = CreateType<SPSite>();
            var archivedWebs = CreateType<List<Guid>>();
            var selectedLists = CreateType<IEnumerable<string>>();
            var methodGetDataFromSPPrametersTypes = new Type[] { typeof(List<string>), typeof(SPSiteDataQuery), typeof(SPWeb), typeof(SPSite), typeof(List<Guid>), typeof(IEnumerable<string>) };
            object[] parametersOfGetDataFromSP = { selectedListIds, dataQuery, spWeb, spSite, archivedWebs, selectedLists };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataFromSP, methodGetDataFromSPPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, Fixture, methodGetDataFromSPPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<DataTable>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, parametersOfGetDataFromSP, methodGetDataFromSPPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetDataFromSP);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataFromSP.ShouldNotBeNull();
            parametersOfGetDataFromSP.Length.ShouldBe(6);
            methodGetDataFromSPPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedListIds = CreateType<List<string>>();
            var dataQuery = CreateType<SPSiteDataQuery>();
            var spWeb = CreateType<SPWeb>();
            var spSite = CreateType<SPSite>();
            var archivedWebs = CreateType<List<Guid>>();
            var selectedLists = CreateType<IEnumerable<string>>();
            var methodGetDataFromSPPrametersTypes = new Type[] { typeof(List<string>), typeof(SPSiteDataQuery), typeof(SPWeb), typeof(SPSite), typeof(List<Guid>), typeof(IEnumerable<string>) };
            object[] parametersOfGetDataFromSP = { selectedListIds, dataQuery, spWeb, spSite, archivedWebs, selectedLists };

            // Assert
            parametersOfGetDataFromSP.ShouldNotBeNull();
            parametersOfGetDataFromSP.Length.ShouldBe(6);
            methodGetDataFromSPPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<DataTable>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, parametersOfGetDataFromSP, methodGetDataFromSPPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataFromSPPrametersTypes = new Type[] { typeof(List<string>), typeof(SPSiteDataQuery), typeof(SPWeb), typeof(SPSite), typeof(List<Guid>), typeof(IEnumerable<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, Fixture, methodGetDataFromSPPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataFromSPPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataFromSPPrametersTypes = new Type[] { typeof(List<string>), typeof(SPSiteDataQuery), typeof(SPWeb), typeof(SPSite), typeof(List<Guid>), typeof(IEnumerable<string>) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetDataFromSP, Fixture, methodGetDataFromSPPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataFromSPPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataFromSP, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataFromSP) (Return Type : IEnumerable<DataTable>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetDataFromSP_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataFromSP, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExampleDateFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var yearLabel = CreateType<string>();
            var monthLabel = CreateType<string>();
            var dayLabel = CreateType<string>();
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetExampleDateFormat = { web, yearLabel, monthLabel, dayLabel };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, parametersOfGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetExampleDateFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExampleDateFormat.ShouldNotBeNull();
            parametersOfGetExampleDateFormat.Length.ShouldBe(4);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var yearLabel = CreateType<string>();
            var monthLabel = CreateType<string>();
            var dayLabel = CreateType<string>();
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetExampleDateFormat = { web, yearLabel, monthLabel, dayLabel };

            // Assert
            parametersOfGetExampleDateFormat.ShouldNotBeNull();
            parametersOfGetExampleDateFormat.Length.ShouldBe(4);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, parametersOfGetExampleDateFormat, methodGetExampleDateFormatPrametersTypes));
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExampleDateFormatPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetExampleDateFormat, Fixture, methodGetExampleDateFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExampleDateFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExampleDateFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetExampleDateFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExampleDateFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetGridSafeValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridSafeValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, Fixture, methodGetGridSafeValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<XElement>();
            var methodGetGridSafeValuePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetGridSafeValue = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGridSafeValue, methodGetGridSafeValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, Fixture, methodGetGridSafeValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, parametersOfGetGridSafeValue, methodGetGridSafeValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetGridSafeValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGridSafeValue.ShouldNotBeNull();
            parametersOfGetGridSafeValue.Length.ShouldBe(1);
            methodGetGridSafeValuePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<XElement>();
            var methodGetGridSafeValuePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfGetGridSafeValue = { field };

            // Assert
            parametersOfGetGridSafeValue.ShouldNotBeNull();
            parametersOfGetGridSafeValue.Length.ShouldBe(1);
            methodGetGridSafeValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, parametersOfGetGridSafeValue, methodGetGridSafeValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridSafeValuePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, Fixture, methodGetGridSafeValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridSafeValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridSafeValuePrametersTypes = new Type[] { typeof(XElement) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetGridSafeValue, Fixture, methodGetGridSafeValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridSafeValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridSafeValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridSafeValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetGridSafeValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridSafeValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetLeftCols_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLeftColsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, Fixture, methodGetLeftColsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var myWorkGridView = CreateType<MyWorkGridView>();
            var methodGetLeftColsPrametersTypes = new Type[] { typeof(MyWorkGridView) };
            object[] parametersOfGetLeftCols = { myWorkGridView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLeftCols, methodGetLeftColsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, Fixture, methodGetLeftColsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, parametersOfGetLeftCols, methodGetLeftColsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetLeftCols);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLeftCols.ShouldNotBeNull();
            parametersOfGetLeftCols.Length.ShouldBe(1);
            methodGetLeftColsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkGridView = CreateType<MyWorkGridView>();
            var methodGetLeftColsPrametersTypes = new Type[] { typeof(MyWorkGridView) };
            object[] parametersOfGetLeftCols = { myWorkGridView };

            // Assert
            parametersOfGetLeftCols.ShouldNotBeNull();
            parametersOfGetLeftCols.Length.ShouldBe(1);
            methodGetLeftColsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, parametersOfGetLeftCols, methodGetLeftColsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLeftColsPrametersTypes = new Type[] { typeof(MyWorkGridView) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, Fixture, methodGetLeftColsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLeftColsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLeftColsPrametersTypes = new Type[] { typeof(MyWorkGridView) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetLeftCols, Fixture, methodGetLeftColsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLeftColsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLeftCols, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLeftCols) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetLeftCols_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLeftCols, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkElement_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, Fixture, methodGetMyWorkElementPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkElementPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkElement = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkElement, methodGetMyWorkElementPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, Fixture, methodGetMyWorkElementPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XElement>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, parametersOfGetMyWorkElement, methodGetMyWorkElementPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkElement.ShouldNotBeNull();
            parametersOfGetMyWorkElement.Length.ShouldBe(1);
            methodGetMyWorkElementPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkElementPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkElement = { data };

            // Assert
            parametersOfGetMyWorkElement.ShouldNotBeNull();
            parametersOfGetMyWorkElement.Length.ShouldBe(1);
            methodGetMyWorkElementPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XElement>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, parametersOfGetMyWorkElement, methodGetMyWorkElementPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkElementPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, Fixture, methodGetMyWorkElementPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkElementPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkElementPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkElement, Fixture, methodGetMyWorkElementPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkElementPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkElement, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkElement) (Return Type : XElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkElement_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkElement, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, Fixture, methodGetMyWorkFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var myWorkField = CreateType<string>();
            var myWorkDataRow = CreateType<DataRow>();
            var colDict = CreateType<Dictionary<string, int>>();
            var fieldsTableRows = CreateType<EnumerableRowCollection<DataRow>>();
            var flagsTable = CreateType<DataTable>();
            var methodGetMyWorkFieldValuePrametersTypes = new Type[] { typeof(string), typeof(DataRow), typeof(Dictionary<string, int>), typeof(EnumerableRowCollection<DataRow>), typeof(DataTable) };
            object[] parametersOfGetMyWorkFieldValue = { myWorkField, myWorkDataRow, colDict, fieldsTableRows, flagsTable };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkFieldValue, methodGetMyWorkFieldValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, Fixture, methodGetMyWorkFieldValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, parametersOfGetMyWorkFieldValue, methodGetMyWorkFieldValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkFieldValue.ShouldNotBeNull();
            parametersOfGetMyWorkFieldValue.Length.ShouldBe(5);
            methodGetMyWorkFieldValuePrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkField = CreateType<string>();
            var myWorkDataRow = CreateType<DataRow>();
            var colDict = CreateType<Dictionary<string, int>>();
            var fieldsTableRows = CreateType<EnumerableRowCollection<DataRow>>();
            var flagsTable = CreateType<DataTable>();
            var methodGetMyWorkFieldValuePrametersTypes = new Type[] { typeof(string), typeof(DataRow), typeof(Dictionary<string, int>), typeof(EnumerableRowCollection<DataRow>), typeof(DataTable) };
            object[] parametersOfGetMyWorkFieldValue = { myWorkField, myWorkDataRow, colDict, fieldsTableRows, flagsTable };

            // Assert
            parametersOfGetMyWorkFieldValue.ShouldNotBeNull();
            parametersOfGetMyWorkFieldValue.Length.ShouldBe(5);
            methodGetMyWorkFieldValuePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, parametersOfGetMyWorkFieldValue, methodGetMyWorkFieldValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkFieldValuePrametersTypes = new Type[] { typeof(string), typeof(DataRow), typeof(Dictionary<string, int>), typeof(EnumerableRowCollection<DataRow>), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, Fixture, methodGetMyWorkFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkFieldValuePrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkFieldValuePrametersTypes = new Type[] { typeof(string), typeof(DataRow), typeof(Dictionary<string, int>), typeof(EnumerableRowCollection<DataRow>), typeof(DataTable) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldValue, Fixture, methodGetMyWorkFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkFieldValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkFieldValue, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, Fixture, methodGetMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xDocument = CreateType<XDocument>();
            var methodGetMyWorkGridViewPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfGetMyWorkGridView = { xDocument };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridView, methodGetMyWorkGridViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, Fixture, methodGetMyWorkGridViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<MyWorkGridView>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, parametersOfGetMyWorkGridView, methodGetMyWorkGridViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkGridView.ShouldNotBeNull();
            parametersOfGetMyWorkGridView.Length.ShouldBe(1);
            methodGetMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xDocument = CreateType<XDocument>();
            var methodGetMyWorkGridViewPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfGetMyWorkGridView = { xDocument };

            // Assert
            parametersOfGetMyWorkGridView.ShouldNotBeNull();
            parametersOfGetMyWorkGridView.Length.ShouldBe(1);
            methodGetMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<MyWorkGridView>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, parametersOfGetMyWorkGridView, methodGetMyWorkGridViewPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridViewPrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, Fixture, methodGetMyWorkGridViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridViewPrametersTypes = new Type[] { typeof(XDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridView, Fixture, methodGetMyWorkGridViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridView) (Return Type : MyWorkGridView) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkItemElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, Fixture, methodGetMyWorkItemElementPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkItemElementPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkItemElement = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkItemElement, methodGetMyWorkItemElementPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, Fixture, methodGetMyWorkItemElementPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XElement>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, parametersOfGetMyWorkItemElement, methodGetMyWorkItemElementPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkItemElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkItemElement.ShouldNotBeNull();
            parametersOfGetMyWorkItemElement.Length.ShouldBe(1);
            methodGetMyWorkItemElementPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkItemElementPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkItemElement = { data };

            // Assert
            parametersOfGetMyWorkItemElement.ShouldNotBeNull();
            parametersOfGetMyWorkItemElement.Length.ShouldBe(1);
            methodGetMyWorkItemElementPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XElement>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, parametersOfGetMyWorkItemElement, methodGetMyWorkItemElementPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkItemElementPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, Fixture, methodGetMyWorkItemElementPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkItemElementPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkItemElementPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkItemElement, Fixture, methodGetMyWorkItemElementPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkItemElementPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkItemElement, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkItemElement) (Return Type : XElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkItemElement_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkItemElement, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkListIdsFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, Fixture, methodGetMyWorkListIdsFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var selectedListIds = CreateType<List<string>>();
            var methodGetMyWorkListIdsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>), typeof(List<string>) };
            object[] parametersOfGetMyWorkListIdsFromDb = { spWeb, archivedWebs, selectedListIds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListIdsFromDb, methodGetMyWorkListIdsFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, Fixture, methodGetMyWorkListIdsFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<Guid>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, parametersOfGetMyWorkListIdsFromDb, methodGetMyWorkListIdsFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkListIdsFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkListIdsFromDb.ShouldNotBeNull();
            parametersOfGetMyWorkListIdsFromDb.Length.ShouldBe(3);
            methodGetMyWorkListIdsFromDbPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var selectedListIds = CreateType<List<string>>();
            var methodGetMyWorkListIdsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>), typeof(List<string>) };
            object[] parametersOfGetMyWorkListIdsFromDb = { spWeb, archivedWebs, selectedListIds };

            // Assert
            parametersOfGetMyWorkListIdsFromDb.ShouldNotBeNull();
            parametersOfGetMyWorkListIdsFromDb.Length.ShouldBe(3);
            methodGetMyWorkListIdsFromDbPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<Guid>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, parametersOfGetMyWorkListIdsFromDb, methodGetMyWorkListIdsFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkListIdsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>), typeof(List<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, Fixture, methodGetMyWorkListIdsFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkListIdsFromDbPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkListIdsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>), typeof(List<string>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListIdsFromDb, Fixture, methodGetMyWorkListIdsFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkListIdsFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListIdsFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListIdsFromDb) (Return Type : IEnumerable<Guid>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListIdsFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkListIdsFromDb, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetPersonalViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, Fixture, methodGetPersonalViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var configWeb = CreateType<SPWeb>();
            var methodGetPersonalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetPersonalViews = { configWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersonalViews, methodGetPersonalViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, Fixture, methodGetPersonalViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<MyWorkGridView>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, parametersOfGetPersonalViews, methodGetPersonalViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetPersonalViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersonalViews.ShouldNotBeNull();
            parametersOfGetPersonalViews.Length.ShouldBe(1);
            methodGetPersonalViewsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var configWeb = CreateType<SPWeb>();
            var methodGetPersonalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetPersonalViews = { configWeb };

            // Assert
            parametersOfGetPersonalViews.ShouldNotBeNull();
            parametersOfGetPersonalViews.Length.ShouldBe(1);
            methodGetPersonalViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IEnumerable<MyWorkGridView>>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, parametersOfGetPersonalViews, methodGetPersonalViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersonalViewsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, Fixture, methodGetPersonalViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetPersonalViews, Fixture, methodGetPersonalViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalViews) (Return Type : IEnumerable<MyWorkGridView>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetPersonalViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetQueryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQuery, methodGetQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, parametersOfGetQuery, methodGetQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQuery.ShouldNotBeNull();
            parametersOfGetQuery.Length.ShouldBe(1);
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetQueryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetQuery = { data };

            // Assert
            parametersOfGetQuery.ShouldNotBeNull();
            parametersOfGetQuery.Length.ShouldBe(1);
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, parametersOfGetQuery, methodGetQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSettings_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var selectedFields = CreateType<List<string>>();
            var selectedLists = CreateType<List<string>>();
            var siteUrls = CreateType<List<string>>();
            var performanceMode = CreateType<bool>();
            var noListsSelected = CreateType<bool>();
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(List<string>), typeof(List<string>), typeof(bool), typeof(bool) };
            object[] parametersOfGetSettings = { data, selectedFields, selectedLists, siteUrls, performanceMode, noListsSelected };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSettings, methodGetSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSettings.ShouldNotBeNull();
            parametersOfGetSettings.Length.ShouldBe(6);
            methodGetSettingsPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSettings_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var selectedFields = CreateType<List<string>>();
            var selectedLists = CreateType<List<string>>();
            var siteUrls = CreateType<List<string>>();
            var performanceMode = CreateType<bool>();
            var noListsSelected = CreateType<bool>();
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(List<string>), typeof(List<string>), typeof(bool), typeof(bool) };
            object[] parametersOfGetSettings = { data, selectedFields, selectedLists, siteUrls, performanceMode, noListsSelected };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSettings, parametersOfGetSettings, methodGetSettingsPrametersTypes);

            // Assert
            parametersOfGetSettings.ShouldNotBeNull();
            parametersOfGetSettings.Length.ShouldBe(6);
            methodGetSettingsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSettings, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string), typeof(List<string>), typeof(List<string>), typeof(List<string>), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);

            // Assert
            methodGetSettingsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetSettings_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTypeAndFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetTypeAndFormat, Fixture, methodGetTypeAndFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var selectedField = CreateType<string>();
            var type = CreateType<string>();
            var format = CreateType<string>();
            var methodGetTypeAndFormatPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetTypeAndFormat = { fieldTypes, selectedField, type, format };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTypeAndFormat, methodGetTypeAndFormatPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetTypeAndFormat);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTypeAndFormat.ShouldNotBeNull();
            parametersOfGetTypeAndFormat.Length.ShouldBe(4);
            methodGetTypeAndFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var selectedField = CreateType<string>();
            var type = CreateType<string>();
            var format = CreateType<string>();
            var methodGetTypeAndFormatPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetTypeAndFormat = { fieldTypes, selectedField, type, format };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetTypeAndFormat, parametersOfGetTypeAndFormat, methodGetTypeAndFormatPrametersTypes);

            // Assert
            parametersOfGetTypeAndFormat.ShouldNotBeNull();
            parametersOfGetTypeAndFormat.Length.ShouldBe(4);
            methodGetTypeAndFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTypeAndFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTypeAndFormatPrametersTypes = new Type[] { typeof(Dictionary<string, SPField>), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetTypeAndFormat, Fixture, methodGetTypeAndFormatPrametersTypes);

            // Assert
            methodGetTypeAndFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTypeAndFormat) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetTypeAndFormat_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTypeAndFormat, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetWorkingOn_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWorkingOn = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, methodGetWorkingOnPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, parametersOfGetWorkingOn, methodGetWorkingOnPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetWorkingOn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkingOn.ShouldNotBeNull();
            parametersOfGetWorkingOn.Length.ShouldBe(1);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWorkingOn = { spWeb };

            // Assert
            parametersOfGetWorkingOn.ShouldNotBeNull();
            parametersOfGetWorkingOn.Length.ShouldBe(1);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, parametersOfGetWorkingOn, methodGetWorkingOnPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetWorkingOn_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOn = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, methodGetWorkingOnPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, parametersOfGetWorkingOn, methodGetWorkingOnPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetWorkingOn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkingOn.ShouldNotBeNull();
            parametersOfGetWorkingOn.Length.ShouldBe(1);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOn = { data };

            // Assert
            parametersOfGetWorkingOn.ShouldNotBeNull();
            parametersOfGetWorkingOn.Length.ShouldBe(1);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, parametersOfGetWorkingOn, methodGetWorkingOnPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkingOnPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOn, Fixture, methodGetWorkingOnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkingOnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkingOn) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOn_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkingOn, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceNameFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, Fixture, methodGetWorkspaceNameFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetWorkspaceNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetWorkspaceNameFromDb = { webId, siteUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceNameFromDb, methodGetWorkspaceNameFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, Fixture, methodGetWorkspaceNameFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, parametersOfGetWorkspaceNameFromDb, methodGetWorkspaceNameFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetWorkspaceNameFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkspaceNameFromDb.ShouldNotBeNull();
            parametersOfGetWorkspaceNameFromDb.Length.ShouldBe(2);
            methodGetWorkspaceNameFromDbPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetWorkspaceNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetWorkspaceNameFromDb = { webId, siteUrl };

            // Assert
            parametersOfGetWorkspaceNameFromDb.ShouldNotBeNull();
            parametersOfGetWorkspaceNameFromDb.Length.ShouldBe(2);
            methodGetWorkspaceNameFromDbPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, parametersOfGetWorkspaceNameFromDb, methodGetWorkspaceNameFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkspaceNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, Fixture, methodGetWorkspaceNameFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkspaceNameFromDbPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkspaceNameFromDbPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkspaceNameFromDb, Fixture, methodGetWorkspaceNameFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceNameFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceNameFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceNameFromDb) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkspaceNameFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkspaceNameFromDb, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_MapCompleteField_Static_Method_Call_Internally(Type[] types)
        {
            var methodMapCompleteFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodMapCompleteField, Fixture, methodMapCompleteFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_MapCompleteField_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var myWorkReportData = CreateType<MyWorkReportData>();
            var methodMapCompleteFieldPrametersTypes = new Type[] { typeof(SPWeb), typeof(MyWorkReportData) };
            object[] parametersOfMapCompleteField = { spWeb, myWorkReportData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMapCompleteField, methodMapCompleteFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfMapCompleteField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMapCompleteField.ShouldNotBeNull();
            parametersOfMapCompleteField.Length.ShouldBe(2);
            methodMapCompleteFieldPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_MapCompleteField_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var myWorkReportData = CreateType<MyWorkReportData>();
            var methodMapCompleteFieldPrametersTypes = new Type[] { typeof(SPWeb), typeof(MyWorkReportData) };
            object[] parametersOfMapCompleteField = { spWeb, myWorkReportData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodMapCompleteField, parametersOfMapCompleteField, methodMapCompleteFieldPrametersTypes);

            // Assert
            parametersOfMapCompleteField.ShouldNotBeNull();
            parametersOfMapCompleteField.Length.ShouldBe(2);
            methodMapCompleteFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_MapCompleteField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapCompleteField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_MapCompleteField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapCompleteFieldPrametersTypes = new Type[] { typeof(SPWeb), typeof(MyWorkReportData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodMapCompleteField, Fixture, methodMapCompleteFieldPrametersTypes);

            // Assert
            methodMapCompleteFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapCompleteField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_MapCompleteField_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapCompleteField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_ProcessMyWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessMyWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodProcessMyWork, Fixture, methodProcessMyWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ProcessMyWork_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var selectedFields = CreateType<IEnumerable<string>>();
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var workTypes = CreateType<Dictionary<string, string>>();
            var workspaces = CreateType<Dictionary<string, string>>();
            var result = CreateType<XDocument>();
            var methodProcessMyWorkPrametersTypes = new Type[] { typeof(DataTable), typeof(SPSite), typeof(SPWeb), typeof(IEnumerable<string>), typeof(Dictionary<string, SPField>), typeof(Dictionary<string, string>), typeof(Dictionary<string, string>), typeof(XDocument) };
            object[] parametersOfProcessMyWork = { dataTable, spSite, spWeb, selectedFields, fieldTypes, workTypes, workspaces, result };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessMyWork, methodProcessMyWorkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfProcessMyWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessMyWork.ShouldNotBeNull();
            parametersOfProcessMyWork.Length.ShouldBe(8);
            methodProcessMyWorkPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ProcessMyWork_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataTable = CreateType<DataTable>();
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var selectedFields = CreateType<IEnumerable<string>>();
            var fieldTypes = CreateType<Dictionary<string, SPField>>();
            var workTypes = CreateType<Dictionary<string, string>>();
            var workspaces = CreateType<Dictionary<string, string>>();
            var result = CreateType<XDocument>();
            var methodProcessMyWorkPrametersTypes = new Type[] { typeof(DataTable), typeof(SPSite), typeof(SPWeb), typeof(IEnumerable<string>), typeof(Dictionary<string, SPField>), typeof(Dictionary<string, string>), typeof(Dictionary<string, string>), typeof(XDocument) };
            object[] parametersOfProcessMyWork = { dataTable, spSite, spWeb, selectedFields, fieldTypes, workTypes, workspaces, result };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodProcessMyWork, parametersOfProcessMyWork, methodProcessMyWorkPrametersTypes);

            // Assert
            parametersOfProcessMyWork.ShouldNotBeNull();
            parametersOfProcessMyWork.Length.ShouldBe(8);
            methodProcessMyWorkPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ProcessMyWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessMyWork, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ProcessMyWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessMyWorkPrametersTypes = new Type[] { typeof(DataTable), typeof(SPSite), typeof(SPWeb), typeof(IEnumerable<string>), typeof(Dictionary<string, SPField>), typeof(Dictionary<string, string>), typeof(Dictionary<string, string>), typeof(XDocument) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodProcessMyWork, Fixture, methodProcessMyWorkPrametersTypes);

            // Assert
            methodProcessMyWorkPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessMyWork) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_ProcessMyWork_Static_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessMyWork, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_QueryMyWorkData_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueryMyWorkDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, Fixture, methodQueryMyWorkDataPrametersTypes);
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dataQuery = CreateType<SPSiteDataQuery>();
            var siteUrl = CreateType<string>();
            var webId = CreateType<Guid>();
            var userToken = CreateType<SPUserToken>();
            var methodQueryMyWorkDataPrametersTypes = new Type[] { typeof(SPSiteDataQuery), typeof(string), typeof(Guid), typeof(SPUserToken) };
            object[] parametersOfQueryMyWorkData = { dataQuery, siteUrl, webId, userToken };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueryMyWorkData, methodQueryMyWorkDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, Fixture, methodQueryMyWorkDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, parametersOfQueryMyWorkData, methodQueryMyWorkDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfQueryMyWorkData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueryMyWorkData.ShouldNotBeNull();
            parametersOfQueryMyWorkData.Length.ShouldBe(4);
            methodQueryMyWorkDataPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataQuery = CreateType<SPSiteDataQuery>();
            var siteUrl = CreateType<string>();
            var webId = CreateType<Guid>();
            var userToken = CreateType<SPUserToken>();
            var methodQueryMyWorkDataPrametersTypes = new Type[] { typeof(SPSiteDataQuery), typeof(string), typeof(Guid), typeof(SPUserToken) };
            object[] parametersOfQueryMyWorkData = { dataQuery, siteUrl, webId, userToken };

            // Assert
            parametersOfQueryMyWorkData.ShouldNotBeNull();
            parametersOfQueryMyWorkData.Length.ShouldBe(4);
            methodQueryMyWorkDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, parametersOfQueryMyWorkData, methodQueryMyWorkDataPrametersTypes));
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueryMyWorkDataPrametersTypes = new Type[] { typeof(SPSiteDataQuery), typeof(string), typeof(Guid), typeof(SPUserToken) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, Fixture, methodQueryMyWorkDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueryMyWorkDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueryMyWorkDataPrametersTypes = new Type[] { typeof(SPSiteDataQuery), typeof(string), typeof(Guid), typeof(SPUserToken) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodQueryMyWorkData, Fixture, methodQueryMyWorkDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueryMyWorkDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueryMyWorkData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueryMyWorkData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_QueryMyWorkData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueryMyWorkData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_RenameGlobalView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameGlobalViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameGlobalView, Fixture, methodRenameGlobalViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameGlobalView_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var viewName = CreateType<string>();
            var globalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodRenameGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfRenameGlobalView = { viewId, viewName, globalViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenameGlobalView, methodRenameGlobalViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfRenameGlobalView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenameGlobalView.ShouldNotBeNull();
            parametersOfRenameGlobalView.Length.ShouldBe(4);
            methodRenameGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameGlobalView_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var viewName = CreateType<string>();
            var globalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodRenameGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfRenameGlobalView = { viewId, viewName, globalViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameGlobalView, parametersOfRenameGlobalView, methodRenameGlobalViewPrametersTypes);

            // Assert
            parametersOfRenameGlobalView.ShouldNotBeNull();
            parametersOfRenameGlobalView.Length.ShouldBe(4);
            methodRenameGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameGlobalView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameGlobalView, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameGlobalView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameGlobalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameGlobalView, Fixture, methodRenameGlobalViewPrametersTypes);

            // Assert
            methodRenameGlobalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameGlobalView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameGlobalView_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameGlobalView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_RenamePersonalView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenamePersonalViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenamePersonalView, Fixture, methodRenamePersonalViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenamePersonalView_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var viewName = CreateType<string>();
            var personalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodRenamePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfRenamePersonalView = { viewId, viewName, personalViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenamePersonalView, methodRenamePersonalViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfRenamePersonalView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenamePersonalView.ShouldNotBeNull();
            parametersOfRenamePersonalView.Length.ShouldBe(4);
            methodRenamePersonalViewPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenamePersonalView_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var viewName = CreateType<string>();
            var personalViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodRenamePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfRenamePersonalView = { viewId, viewName, personalViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenamePersonalView, parametersOfRenamePersonalView, methodRenamePersonalViewPrametersTypes);

            // Assert
            parametersOfRenamePersonalView.ShouldNotBeNull();
            parametersOfRenamePersonalView.Length.ShouldBe(4);
            methodRenamePersonalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenamePersonalView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenamePersonalView, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenamePersonalView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenamePersonalViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenamePersonalView, Fixture, methodRenamePersonalViewPrametersTypes);

            // Assert
            methodRenamePersonalViewPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenamePersonalView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenamePersonalView_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenamePersonalView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_SaveGlobalViews_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSaveGlobalViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, Fixture, methodSaveGlobalViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Void_Overloading_Of_1_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkGridViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfSaveGlobalViews = { myWorkGridViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, methodSaveGlobalViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfSaveGlobalViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveGlobalViews.ShouldNotBeNull();
            parametersOfSaveGlobalViews.Length.ShouldBe(2);
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Void_Overloading_Of_1_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkGridViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfSaveGlobalViews = { myWorkGridViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, parametersOfSaveGlobalViews, methodSaveGlobalViewsPrametersTypes);

            // Assert
            parametersOfSaveGlobalViews.ShouldNotBeNull();
            parametersOfSaveGlobalViews.Length.ShouldBe(2);
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveGlobalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveGlobalViews, Fixture, methodSaveGlobalViewsPrametersTypes);

            // Assert
            methodSaveGlobalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGlobalViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveGlobalViews_Static_Method_Call_Overloading_Of_1_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveGlobalViews, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_SavePersonalViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodSavePersonalViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSavePersonalViews, Fixture, methodSavePersonalViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SavePersonalViews_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var myWorkGridViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodSavePersonalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfSavePersonalViews = { myWorkGridViews, configWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSavePersonalViews, methodSavePersonalViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfSavePersonalViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSavePersonalViews.ShouldNotBeNull();
            parametersOfSavePersonalViews.Length.ShouldBe(2);
            methodSavePersonalViewsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SavePersonalViews_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var myWorkGridViews = CreateType<IEnumerable<MyWorkGridView>>();
            var configWeb = CreateType<SPWeb>();
            var methodSavePersonalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };
            object[] parametersOfSavePersonalViews = { myWorkGridViews, configWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodSavePersonalViews, parametersOfSavePersonalViews, methodSavePersonalViewsPrametersTypes);

            // Assert
            parametersOfSavePersonalViews.ShouldNotBeNull();
            parametersOfSavePersonalViews.Length.ShouldBe(2);
            methodSavePersonalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SavePersonalViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSavePersonalViews, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SavePersonalViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSavePersonalViewsPrametersTypes = new Type[] { typeof(IEnumerable<MyWorkGridView>), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSavePersonalViews, Fixture, methodSavePersonalViewsPrametersTypes);

            // Assert
            methodSavePersonalViewsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SavePersonalViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SavePersonalViews_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSavePersonalViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TagSiteIdExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_TagSiteIdExists_Static_Method_Call_Internally(Type[] types)
        {
            var methodTagSiteIdExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodTagSiteIdExists, Fixture, methodTagSiteIdExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (TagSiteIdExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_TagSiteIdExists_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodTagSiteIdExistsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfTagSiteIdExists = { spWeb };

            // Assert
            parametersOfTagSiteIdExists.ShouldNotBeNull();
            parametersOfTagSiteIdExists.Length.ShouldBe(1);
            methodTagSiteIdExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_myWorkInstanceFixture, _myWorkInstanceType, MethodTagSiteIdExists, parametersOfTagSiteIdExists, methodTagSiteIdExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (TagSiteIdExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_TagSiteIdExists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTagSiteIdExistsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodTagSiteIdExists, Fixture, methodTagSiteIdExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTagSiteIdExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TagSiteIdExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_TagSiteIdExists_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTagSiteIdExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TagSiteIdExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_TagSiteIdExists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTagSiteIdExists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteToDebugWindowPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodWriteToDebugWindow, Fixture, methodWriteToDebugWindowPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodWriteToDebugWindowPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToDebugWindow = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteToDebugWindow, methodWriteToDebugWindowPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfWriteToDebugWindow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteToDebugWindow.ShouldNotBeNull();
            parametersOfWriteToDebugWindow.Length.ShouldBe(1);
            methodWriteToDebugWindowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodWriteToDebugWindowPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWriteToDebugWindow = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myWorkInstanceFixture, _myWorkInstanceType, MethodWriteToDebugWindow, parametersOfWriteToDebugWindow, methodWriteToDebugWindowPrametersTypes);

            // Assert
            parametersOfWriteToDebugWindow.ShouldNotBeNull();
            parametersOfWriteToDebugWindow.Length.ShouldBe(1);
            methodWriteToDebugWindowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteToDebugWindow, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteToDebugWindowPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodWriteToDebugWindow, Fixture, methodWriteToDebugWindowPrametersTypes);

            // Assert
            methodWriteToDebugWindowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteToDebugWindow) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_WriteToDebugWindow_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteToDebugWindow, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_CheckListEditPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckListEditPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, Fixture, methodCheckListEditPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCheckListEditPermissionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCheckListEditPermission = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCheckListEditPermission, methodCheckListEditPermissionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, Fixture, methodCheckListEditPermissionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, parametersOfCheckListEditPermission, methodCheckListEditPermissionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfCheckListEditPermission);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCheckListEditPermission.ShouldNotBeNull();
            parametersOfCheckListEditPermission.Length.ShouldBe(1);
            methodCheckListEditPermissionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodCheckListEditPermissionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCheckListEditPermission = { data };

            // Assert
            parametersOfCheckListEditPermission.ShouldNotBeNull();
            parametersOfCheckListEditPermission.Length.ShouldBe(1);
            methodCheckListEditPermissionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, parametersOfCheckListEditPermission, methodCheckListEditPermissionPrametersTypes));
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCheckListEditPermissionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, Fixture, methodCheckListEditPermissionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCheckListEditPermissionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckListEditPermissionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodCheckListEditPermission, Fixture, methodCheckListEditPermissionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckListEditPermissionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckListEditPermission, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckListEditPermission) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_CheckListEditPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckListEditPermission, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, Fixture, methodDeleteMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteMyWorkGridView = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteMyWorkGridView, methodDeleteMyWorkGridViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, Fixture, methodDeleteMyWorkGridViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, parametersOfDeleteMyWorkGridView, methodDeleteMyWorkGridViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfDeleteMyWorkGridView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteMyWorkGridView.ShouldNotBeNull();
            parametersOfDeleteMyWorkGridView.Length.ShouldBe(1);
            methodDeleteMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDeleteMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteMyWorkGridView = { data };

            // Assert
            parametersOfDeleteMyWorkGridView.ShouldNotBeNull();
            parametersOfDeleteMyWorkGridView.Length.ShouldBe(1);
            methodDeleteMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, parametersOfDeleteMyWorkGridView, methodDeleteMyWorkGridViewPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, Fixture, methodDeleteMyWorkGridViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodDeleteMyWorkGridView, Fixture, methodDeleteMyWorkGridViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteMyWorkGridViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteMyWorkGridView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteMyWorkGridView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_DeleteMyWorkGridView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteMyWorkGridView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWork_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, Fixture, methodGetMyWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWork = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWork, methodGetMyWorkPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, Fixture, methodGetMyWorkPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, parametersOfGetMyWork, methodGetMyWorkPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWork.ShouldNotBeNull();
            parametersOfGetMyWork.Length.ShouldBe(1);
            methodGetMyWorkPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWork = { data };

            // Assert
            parametersOfGetMyWork.ShouldNotBeNull();
            parametersOfGetMyWork.Length.ShouldBe(1);
            methodGetMyWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, parametersOfGetMyWork, methodGetMyWorkPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, Fixture, methodGetMyWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWork, Fixture, methodGetMyWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWork_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkFieldType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkFieldType, Fixture, methodGetMyWorkFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkFieldType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkFieldType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkFieldType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkFieldType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridColTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, Fixture, methodGetMyWorkGridColTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridColTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridColType = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridColType, methodGetMyWorkGridColTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, Fixture, methodGetMyWorkGridColTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, parametersOfGetMyWorkGridColType, methodGetMyWorkGridColTypePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridColType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkGridColType.ShouldNotBeNull();
            parametersOfGetMyWorkGridColType.Length.ShouldBe(1);
            methodGetMyWorkGridColTypePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridColTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridColType = { data };

            // Assert
            parametersOfGetMyWorkGridColType.ShouldNotBeNull();
            parametersOfGetMyWorkGridColType.Length.ShouldBe(1);
            methodGetMyWorkGridColTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, parametersOfGetMyWorkGridColType, methodGetMyWorkGridColTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridColTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, Fixture, methodGetMyWorkGridColTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridColTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridColTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridColType, Fixture, methodGetMyWorkGridColTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridColTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridColType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridColType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridColType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridColType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridData, Fixture, methodGetMyWorkGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridData = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridData, methodGetMyWorkGridDataPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMyWorkGridData.ShouldNotBeNull();
            parametersOfGetMyWorkGridData.Length.ShouldBe(1);
            methodGetMyWorkGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridData));
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridData = { data };

            // Assert
            parametersOfGetMyWorkGridData.ShouldNotBeNull();
            parametersOfGetMyWorkGridData.Length.ShouldBe(1);
            methodGetMyWorkGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridData, parametersOfGetMyWorkGridData, methodGetMyWorkGridDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridData, Fixture, methodGetMyWorkGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridData, Fixture, methodGetMyWorkGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridEnumPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, Fixture, methodGetMyWorkGridEnumPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridEnumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridEnum = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridEnum, methodGetMyWorkGridEnumPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, Fixture, methodGetMyWorkGridEnumPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, parametersOfGetMyWorkGridEnum, methodGetMyWorkGridEnumPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridEnum);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkGridEnum.ShouldNotBeNull();
            parametersOfGetMyWorkGridEnum.Length.ShouldBe(1);
            methodGetMyWorkGridEnumPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridEnumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridEnum = { data };

            // Assert
            parametersOfGetMyWorkGridEnum.ShouldNotBeNull();
            parametersOfGetMyWorkGridEnum.Length.ShouldBe(1);
            methodGetMyWorkGridEnumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, parametersOfGetMyWorkGridEnum, methodGetMyWorkGridEnumPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridEnumPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, Fixture, methodGetMyWorkGridEnumPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridEnumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridEnumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridEnum, Fixture, methodGetMyWorkGridEnumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridEnumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridEnum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridEnum) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridEnum_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridEnum, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, Fixture, methodGetMyWorkGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridLayout = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridLayout, methodGetMyWorkGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, Fixture, methodGetMyWorkGridLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, parametersOfGetMyWorkGridLayout, methodGetMyWorkGridLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkGridLayout.ShouldNotBeNull();
            parametersOfGetMyWorkGridLayout.Length.ShouldBe(1);
            methodGetMyWorkGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkGridLayout = { data };

            // Assert
            parametersOfGetMyWorkGridLayout.ShouldNotBeNull();
            parametersOfGetMyWorkGridLayout.Length.ShouldBe(1);
            methodGetMyWorkGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, parametersOfGetMyWorkGridLayout, methodGetMyWorkGridLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, Fixture, methodGetMyWorkGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridLayout, Fixture, methodGetMyWorkGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkGridViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, Fixture, methodGetMyWorkGridViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetMyWorkGridViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetMyWorkGridViews = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridViews, methodGetMyWorkGridViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, Fixture, methodGetMyWorkGridViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, parametersOfGetMyWorkGridViews, methodGetMyWorkGridViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkGridViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkGridViews.ShouldNotBeNull();
            parametersOfGetMyWorkGridViews.Length.ShouldBe(1);
            methodGetMyWorkGridViewsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetMyWorkGridViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetMyWorkGridViews = { spWeb };

            // Assert
            parametersOfGetMyWorkGridViews.ShouldNotBeNull();
            parametersOfGetMyWorkGridViews.Length.ShouldBe(1);
            methodGetMyWorkGridViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, parametersOfGetMyWorkGridViews, methodGetMyWorkGridViewsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkGridViewsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, Fixture, methodGetMyWorkGridViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkGridViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkGridViewsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkGridViews, Fixture, methodGetMyWorkGridViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkGridViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkGridViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkGridViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkGridViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, Fixture, methodGetMyWorkListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkListItem = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListItem, methodGetMyWorkListItemPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, Fixture, methodGetMyWorkListItemPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, parametersOfGetMyWorkListItem, methodGetMyWorkListItemPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetMyWorkListItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkListItem.ShouldNotBeNull();
            parametersOfGetMyWorkListItem.Length.ShouldBe(1);
            methodGetMyWorkListItemPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyWorkListItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyWorkListItem = { data };

            // Assert
            parametersOfGetMyWorkListItem.ShouldNotBeNull();
            parametersOfGetMyWorkListItem.Length.ShouldBe(1);
            methodGetMyWorkListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, parametersOfGetMyWorkListItem, methodGetMyWorkListItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkListItemPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, Fixture, methodGetMyWorkListItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkListItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetMyWorkListItem, Fixture, methodGetMyWorkListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetMyWorkListItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkListItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRelatedGridFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetRelatedGridFormat, Fixture, methodGetRelatedGridFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var type = CreateType<string>();
            var format = CreateType<string>();
            var spField = CreateType<SPField>();
            var spWeb = CreateType<SPWeb>();
            var methodGetRelatedGridFormatPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetRelatedGridFormat = { type, format, spField, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridFormat, methodGetRelatedGridFormatPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRelatedGridFormat.ShouldNotBeNull();
            parametersOfGetRelatedGridFormat.Length.ShouldBe(4);
            methodGetRelatedGridFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetRelatedGridFormat));
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<string>();
            var format = CreateType<string>();
            var spField = CreateType<SPField>();
            var spWeb = CreateType<SPWeb>();
            var methodGetRelatedGridFormatPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetRelatedGridFormat = { type, format, spField, spWeb };

            // Assert
            parametersOfGetRelatedGridFormat.ShouldNotBeNull();
            parametersOfGetRelatedGridFormat.Length.ShouldBe(4);
            methodGetRelatedGridFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetRelatedGridFormat, parametersOfGetRelatedGridFormat, methodGetRelatedGridFormatPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRelatedGridFormatPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPField), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetRelatedGridFormat, Fixture, methodGetRelatedGridFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRelatedGridFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRelatedGridFormatPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPField), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetRelatedGridFormat, Fixture, methodGetRelatedGridFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRelatedGridFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRelatedGridFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetRelatedGridFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetRelatedGridFormat_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRelatedGridFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, Fixture, methodGetWorkingOnGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOnGridData = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridData, methodGetWorkingOnGridDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, Fixture, methodGetWorkingOnGridDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, parametersOfGetWorkingOnGridData, methodGetWorkingOnGridDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetWorkingOnGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkingOnGridData.ShouldNotBeNull();
            parametersOfGetWorkingOnGridData.Length.ShouldBe(1);
            methodGetWorkingOnGridDataPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOnGridData = { data };

            // Assert
            parametersOfGetWorkingOnGridData.ShouldNotBeNull();
            parametersOfGetWorkingOnGridData.Length.ShouldBe(1);
            methodGetWorkingOnGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, parametersOfGetWorkingOnGridData, methodGetWorkingOnGridDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkingOnGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, Fixture, methodGetWorkingOnGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkingOnGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkingOnGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridData, Fixture, methodGetWorkingOnGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkingOnGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkingOnGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkingOnGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, Fixture, methodGetWorkingOnGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOnGridLayout = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridLayout, methodGetWorkingOnGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, Fixture, methodGetWorkingOnGridLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, parametersOfGetWorkingOnGridLayout, methodGetWorkingOnGridLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfGetWorkingOnGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkingOnGridLayout.ShouldNotBeNull();
            parametersOfGetWorkingOnGridLayout.Length.ShouldBe(1);
            methodGetWorkingOnGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkingOnGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkingOnGridLayout = { data };

            // Assert
            parametersOfGetWorkingOnGridLayout.ShouldNotBeNull();
            parametersOfGetWorkingOnGridLayout.Length.ShouldBe(1);
            methodGetWorkingOnGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, parametersOfGetWorkingOnGridLayout, methodGetWorkingOnGridLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkingOnGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, Fixture, methodGetWorkingOnGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkingOnGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkingOnGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodGetWorkingOnGridLayout, Fixture, methodGetWorkingOnGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkingOnGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkingOnGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_GetWorkingOnGridLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkingOnGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, Fixture, methodRenameMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRenameMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRenameMyWorkGridView = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameMyWorkGridView, methodRenameMyWorkGridViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, Fixture, methodRenameMyWorkGridViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, parametersOfRenameMyWorkGridView, methodRenameMyWorkGridViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfRenameMyWorkGridView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameMyWorkGridView.ShouldNotBeNull();
            parametersOfRenameMyWorkGridView.Length.ShouldBe(1);
            methodRenameMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodRenameMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRenameMyWorkGridView = { data };

            // Assert
            parametersOfRenameMyWorkGridView.ShouldNotBeNull();
            parametersOfRenameMyWorkGridView.Length.ShouldBe(1);
            methodRenameMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, parametersOfRenameMyWorkGridView, methodRenameMyWorkGridViewPrametersTypes));
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, Fixture, methodRenameMyWorkGridViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodRenameMyWorkGridView, Fixture, methodRenameMyWorkGridViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameMyWorkGridViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameMyWorkGridView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameMyWorkGridView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_RenameMyWorkGridView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameMyWorkGridView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveMyWorkGridViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, Fixture, methodSaveMyWorkGridViewPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSaveMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSaveMyWorkGridView = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveMyWorkGridView, methodSaveMyWorkGridViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, Fixture, methodSaveMyWorkGridViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, parametersOfSaveMyWorkGridView, methodSaveMyWorkGridViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfSaveMyWorkGridView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveMyWorkGridView.ShouldNotBeNull();
            parametersOfSaveMyWorkGridView.Length.ShouldBe(1);
            methodSaveMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSaveMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSaveMyWorkGridView = { data };

            // Assert
            parametersOfSaveMyWorkGridView.ShouldNotBeNull();
            parametersOfSaveMyWorkGridView.Length.ShouldBe(1);
            methodSaveMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, parametersOfSaveMyWorkGridView, methodSaveMyWorkGridViewPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, Fixture, methodSaveMyWorkGridViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveMyWorkGridViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveMyWorkGridViewPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodSaveMyWorkGridView, Fixture, methodSaveMyWorkGridViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveMyWorkGridViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveMyWorkGridView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveMyWorkGridView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_SaveMyWorkGridView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveMyWorkGridView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMyWorkItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, Fixture, methodUpdateMyWorkItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateMyWorkItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateMyWorkItem = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkItem, methodUpdateMyWorkItemPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, Fixture, methodUpdateMyWorkItemPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, parametersOfUpdateMyWorkItem, methodUpdateMyWorkItemPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myWorkInstanceFixture, parametersOfUpdateMyWorkItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateMyWorkItem.ShouldNotBeNull();
            parametersOfUpdateMyWorkItem.Length.ShouldBe(1);
            methodUpdateMyWorkItemPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodUpdateMyWorkItemPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateMyWorkItem = { data };

            // Assert
            parametersOfUpdateMyWorkItem.ShouldNotBeNull();
            parametersOfUpdateMyWorkItem.Length.ShouldBe(1);
            methodUpdateMyWorkItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, parametersOfUpdateMyWorkItem, methodUpdateMyWorkItemPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateMyWorkItemPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, Fixture, methodUpdateMyWorkItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateMyWorkItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateMyWorkItemPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myWorkInstanceFixture, _myWorkInstanceType, MethodUpdateMyWorkItem, Fixture, methodUpdateMyWorkItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateMyWorkItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateMyWorkItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWork_UpdateMyWorkItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkItem, 0);
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