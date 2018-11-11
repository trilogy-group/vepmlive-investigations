using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using DataTable = System.Data.DataTable;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.APITeam" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class APITeamTest : AbstractBaseSetupTypedTest<APITeam>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (APITeam) Initializer

        private const string MethodgetResources = "getResources";
        private const string MethodiGetResourceFromRPT = "iGetResourceFromRPT";
        private const string MethodiGetResourcesFromlist = "iGetResourcesFromlist";
        private const string MethodSaveTeam = "SaveTeam";
        private const string MethodSaveTeamForUnspecifiedList = "SaveTeamForUnspecifiedList";
        private const string MethodSaveTeamForUnspecifiedListCleanupUsers = "SaveTeamForUnspecifiedListCleanupUsers";
        private const string MethodSaveTeamForUnspecifiedListUpdateReport = "SaveTeamForUnspecifiedListUpdateReport";
        private const string MethodSaveTeamForUnspecifiedListMemberNodeSettings = "SaveTeamForUnspecifiedListMemberNodeSettings";
        private const string MethodSaveTeamForSpecificList = "SaveTeamForSpecificList";
        private const string MethodSaveTeamSpecificListMemberNodeSettings = "SaveTeamSpecificListMemberNodeSettings";
        private const string MethodReadSaveTeamSettingsFromWorkspaceRootWeb = "ReadSaveTeamSettingsFromWorkspaceRootWeb";
        private const string MethodReadSaveTeamQuerySettingsFromXml = "ReadSaveTeamQuerySettingsFromXml";
        private const string MethodUpdateProjectResourceRate = "UpdateProjectResourceRate";
        private const string MethodDeleteProjectResourceRates = "DeleteProjectResourceRates";
        private const string MethodGetResourceId = "GetResourceId";
        private const string MethodGetProjectId = "GetProjectId";
        private const string MethodsetItemPermissions = "setItemPermissions";
        private const string MethodProcessListItemGroupRoleAssignments = "ProcessListItemGroupRoleAssignments";
        private const string MethodGetListAdditionalPermissions = "GetListAdditionalPermissions";
        private const string MethodGetListLookupsSecurityGroups = "GetListLookupsSecurityGroups";
        private const string MethodsetPermissions = "setPermissions";
        private const string MethodGetTeam = "GetTeam";
        private const string MethodReadGetTeamSettingsForSpecificWeb = "ReadGetTeamSettingsForSpecificWeb";
        private const string MethodGetListUseTeamSetting = "GetListUseTeamSetting";
        private const string MethodReadGetTeamQuerySettingsFromXml = "ReadGetTeamQuerySettingsFromXml";
        private const string MethodGetTeamFromCurrent = "GetTeamFromCurrent";
        private const string MethodGetTeamFromListItem = "GetTeamFromListItem";
        private const string MethodAppendUserValuesToTeamDocument = "AppendUserValuesToTeamDocument";
        private const string MethodGetResourcesFromUrl = "GetResourcesFromUrl";
        private const string MethodGetTeamFromWeb = "GetTeamFromWeb";
        private const string MethodaddAttribute = "addAttribute";
        private const string MethodGetGenericResourceGrid = "GetGenericResourceGrid";
        private const string MethodGetTeamGridLayout = "GetTeamGridLayout";
        private const string MethodAddHtmlColumn = "AddHtmlColumn";
        private const string MethodGetResourceGridLayout = "GetResourceGridLayout";
        private const string MethodisValidResField = "isValidResField";
        private const string MethodGetResourceGridData = "GetResourceGridData";
        private const string MethodGetTeamGridData = "GetTeamGridData";
        private const string MethodGetResourcePoolXml = "GetResourcePoolXml";
        private const string MethodGetResourcePool = "GetResourcePool";
        private const string MethodGetResourcePoolForSave = "GetResourcePoolForSave";
        private const string MethodReadFilterInfoFromXml = "ReadFilterInfoFromXml";
        private const string MethodGetResourceUrl = "GetResourceUrl";
        private const string MethodGetResourceData = "GetResourceData";
        private const string MethodGetWebGroups = "GetWebGroups";
        private const string MethodVerifyProjectTeamWorkspace = "VerifyProjectTeamWorkspace";
        private const string MethodIsProjectCenter = "IsProjectCenter";
        private const string MethodIsPfeSite = "IsPfeSite";
        private const string FieldAllowEditProjectRateColumn = "AllowEditProjectRateColumn";
        private const string FieldGenericColumn = "GenericColumn";
        private const string FieldGenericColumnYes = "GenericColumnYes";
        private const string FieldProjectCenterListName = "ProjectCenterListName";
        private const string FieldProjectRateColumn = "ProjectRateColumn";
        private const string FieldProjectRateColumnCaption = "ProjectRateColumnCaption";
        private const string FieldProjectRateEditColumn = "ProjectRateEditColumn";
        private const string FieldStandardRateColumn = "StandardRateColumn";
        private const string FieldTitleColumn = "TitleColumn";
        private const string FieldUsernameColumn = "UsernameColumn";
        private const string FieldModifiedUsersSeparator = "ModifiedUsersSeparator";
        private const string FieldWEB_GROUPS_QUERY = "WEB_GROUPS_QUERY";
        private Type _aPITeamInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private APITeam _aPITeamInstance;
        private APITeam _aPITeamInstanceFixture;

        #region General Initializer : Class (APITeam) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="APITeam" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _aPITeamInstanceType = typeof(APITeam);
            _aPITeamInstanceFixture = Create(true);
            _aPITeamInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (APITeam)

        #region General Initializer : Class (APITeam) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="APITeam" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldWEB_GROUPS_QUERY)]
        public void AUT_APITeam_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_aPITeamInstanceFixture, 
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
        ///     Class (<see cref="APITeam" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_APITeam_Is_Instance_Present_Test()
        {
            // Assert
            _aPITeamInstanceType.ShouldNotBeNull();
            _aPITeamInstance.ShouldNotBeNull();
            _aPITeamInstanceFixture.ShouldNotBeNull();
            _aPITeamInstance.ShouldBeAssignableTo<APITeam>();
            _aPITeamInstanceFixture.ShouldBeAssignableTo<APITeam>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (APITeam) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APITeam_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            APITeam instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _aPITeamInstanceType.ShouldNotBeNull();
            _aPITeamInstance.ShouldNotBeNull();
            _aPITeamInstanceFixture.ShouldNotBeNull();
            _aPITeamInstance.ShouldBeAssignableTo<APITeam>();
            _aPITeamInstanceFixture.ShouldBeAssignableTo<APITeam>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (getResources) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_getResources_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, Fixture, methodgetResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodgetResourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            object[] parametersOfgetResources = { web, filterfield, filtervalue, hasPerms, arrColumns, liItem, nodeTeam };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetResources, methodgetResourcesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, Fixture, methodgetResourcesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, parametersOfgetResources, methodgetResourcesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfgetResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetResources.ShouldNotBeNull();
            parametersOfgetResources.Length.ShouldBe(7);
            methodgetResourcesPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodgetResourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            object[] parametersOfgetResources = { web, filterfield, filtervalue, hasPerms, arrColumns, liItem, nodeTeam };

            // Assert
            parametersOfgetResources.ShouldNotBeNull();
            parametersOfgetResources.Length.ShouldBe(7);
            methodgetResourcesPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, parametersOfgetResources, methodgetResourcesPrametersTypes));
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetResourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, Fixture, methodgetResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetResourcesPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetResourcesPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodgetResources, Fixture, methodgetResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getResources) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_getResources_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetResources, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetResourceFromRPTPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, Fixture, methodiGetResourceFromRPTPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var cn = CreateType<SqlConnection>();
            var list = CreateType<SPList>();
            var dt = CreateType<DataTable>();
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var filterIsLookup = CreateType<bool>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodiGetResourceFromRPTPrametersTypes = new Type[] { typeof(SqlConnection), typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            object[] parametersOfiGetResourceFromRPT = { cn, list, dt, web, filterfield, filtervalue, filterIsLookup, hasPerms, arrColumns, liItem, nodeTeam };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetResourceFromRPT, methodiGetResourceFromRPTPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, Fixture, methodiGetResourceFromRPTPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, parametersOfiGetResourceFromRPT, methodiGetResourceFromRPTPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfiGetResourceFromRPT);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetResourceFromRPT.ShouldNotBeNull();
            parametersOfiGetResourceFromRPT.Length.ShouldBe(11);
            methodiGetResourceFromRPTPrametersTypes.Length.ShouldBe(11);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cn = CreateType<SqlConnection>();
            var list = CreateType<SPList>();
            var dt = CreateType<DataTable>();
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var filterIsLookup = CreateType<bool>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodiGetResourceFromRPTPrametersTypes = new Type[] { typeof(SqlConnection), typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            object[] parametersOfiGetResourceFromRPT = { cn, list, dt, web, filterfield, filtervalue, filterIsLookup, hasPerms, arrColumns, liItem, nodeTeam };

            // Assert
            parametersOfiGetResourceFromRPT.ShouldNotBeNull();
            parametersOfiGetResourceFromRPT.Length.ShouldBe(11);
            methodiGetResourceFromRPTPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, parametersOfiGetResourceFromRPT, methodiGetResourceFromRPTPrametersTypes));
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetResourceFromRPTPrametersTypes = new Type[] { typeof(SqlConnection), typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, Fixture, methodiGetResourceFromRPTPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetResourceFromRPTPrametersTypes.Length.ShouldBe(11);
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetResourceFromRPTPrametersTypes = new Type[] { typeof(SqlConnection), typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(ArrayList), typeof(SPListItem), typeof(XmlNodeList) };
            const int parametersCount = 11;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourceFromRPT, Fixture, methodiGetResourceFromRPTPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetResourceFromRPTPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetResourceFromRPT, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetResourceFromRPT) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourceFromRPT_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetResourceFromRPT, 0);
            const int parametersCount = 11;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetResourcesFromlistPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, Fixture, methodiGetResourcesFromlistPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var dt = CreateType<DataTable>();
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var methodiGetResourcesFromlistPrametersTypes = new Type[] { typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem) };
            object[] parametersOfiGetResourcesFromlist = { list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetResourcesFromlist, methodiGetResourcesFromlistPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, Fixture, methodiGetResourcesFromlistPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, parametersOfiGetResourcesFromlist, methodiGetResourcesFromlistPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfiGetResourcesFromlist);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetResourcesFromlist.ShouldNotBeNull();
            parametersOfiGetResourcesFromlist.Length.ShouldBe(8);
            methodiGetResourcesFromlistPrametersTypes.Length.ShouldBe(8);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var dt = CreateType<DataTable>();
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filtervalue = CreateType<string>();
            var hasPerms = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var liItem = CreateType<SPListItem>();
            var methodiGetResourcesFromlistPrametersTypes = new Type[] { typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem) };
            object[] parametersOfiGetResourcesFromlist = { list, dt, web, filterfield, filtervalue, hasPerms, arrColumns, liItem };

            // Assert
            parametersOfiGetResourcesFromlist.ShouldNotBeNull();
            parametersOfiGetResourcesFromlist.Length.ShouldBe(8);
            methodiGetResourcesFromlistPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, parametersOfiGetResourcesFromlist, methodiGetResourcesFromlistPrametersTypes));
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetResourcesFromlistPrametersTypes = new Type[] { typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, Fixture, methodiGetResourcesFromlistPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetResourcesFromlistPrametersTypes.Length.ShouldBe(8);
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetResourcesFromlistPrametersTypes = new Type[] { typeof(SPList), typeof(DataTable), typeof(SPWeb), typeof(string), typeof(string), typeof(bool), typeof(ArrayList), typeof(SPListItem) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodiGetResourcesFromlist, Fixture, methodiGetResourcesFromlistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetResourcesFromlistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetResourcesFromlist, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetResourcesFromlist) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_iGetResourcesFromlist_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetResourcesFromlist, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeam_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, Fixture, methodSaveTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var teamDocumentXml = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.SaveTeam(teamDocumentXml, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var teamDocumentXml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSaveTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSaveTeam = { teamDocumentXml, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveTeam, methodSaveTeamPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, Fixture, methodSaveTeamPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, parametersOfSaveTeam, methodSaveTeamPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfSaveTeam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveTeam.ShouldNotBeNull();
            parametersOfSaveTeam.Length.ShouldBe(2);
            methodSaveTeamPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var teamDocumentXml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodSaveTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfSaveTeam = { teamDocumentXml, web };

            // Assert
            parametersOfSaveTeam.ShouldNotBeNull();
            parametersOfSaveTeam.Length.ShouldBe(2);
            methodSaveTeamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, parametersOfSaveTeam, methodSaveTeamPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, Fixture, methodSaveTeamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveTeamPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeam, Fixture, methodSaveTeamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTeam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveTeam) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveTeam, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamForUnspecifiedList_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamForUnspecifiedListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedList, Fixture, methodSaveTeamForUnspecifiedListPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var resultDocument = CreateType<XmlDocument>();
            var teamDocument = CreateType<XmlDocument>();
            var teamDocumentXml = CreateType<string>();
            var methodSaveTeamForUnspecifiedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlDocument), typeof(XmlDocument), typeof(string) };
            object[] parametersOfSaveTeamForUnspecifiedList = { web, resultDocument, teamDocument, teamDocumentXml };

            // Assert
            parametersOfSaveTeamForUnspecifiedList.ShouldNotBeNull();
            parametersOfSaveTeamForUnspecifiedList.Length.ShouldBe(4);
            methodSaveTeamForUnspecifiedListPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedList, parametersOfSaveTeamForUnspecifiedList, methodSaveTeamForUnspecifiedListPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlDocument), typeof(XmlDocument), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedList, Fixture, methodSaveTeamForUnspecifiedListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveTeamForUnspecifiedListPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlDocument), typeof(XmlDocument), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedList, Fixture, methodSaveTeamForUnspecifiedListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamForUnspecifiedListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListCleanupUsers) (Return Type : IList<int>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamForUnspecifiedListCleanupUsers_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListCleanupUsers, Fixture, methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListCleanupUsers) (Return Type : IList<int>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListCleanupUsers_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var listItemsDataTable = CreateType<DataTable>();
            var resourcePool = CreateType<DataTable>();
            var methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(DataTable), typeof(DataTable) };
            object[] parametersOfSaveTeamForUnspecifiedListCleanupUsers = { web, list, listItemsDataTable, resourcePool };

            // Assert
            parametersOfSaveTeamForUnspecifiedListCleanupUsers.ShouldNotBeNull();
            parametersOfSaveTeamForUnspecifiedListCleanupUsers.Length.ShouldBe(4);
            methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<IList<int>>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListCleanupUsers, parametersOfSaveTeamForUnspecifiedListCleanupUsers, methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListCleanupUsers) (Return Type : IList<int>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListCleanupUsers_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(DataTable), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListCleanupUsers, Fixture, methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamForUnspecifiedListCleanupUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListUpdateReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamForUnspecifiedListUpdateReport_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListUpdateReport, Fixture, methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListUpdateReport) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListUpdateReport_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var teamMemberCount = CreateType<int>();
            var methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };
            object[] parametersOfSaveTeamForUnspecifiedListUpdateReport = { web, teamMemberCount };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListUpdateReport, parametersOfSaveTeamForUnspecifiedListUpdateReport, methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes);

            // Assert
            parametersOfSaveTeamForUnspecifiedListUpdateReport.ShouldNotBeNull();
            parametersOfSaveTeamForUnspecifiedListUpdateReport.Length.ShouldBe(2);
            methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListUpdateReport) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListUpdateReport_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes = new Type[] { typeof(SPWeb), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListUpdateReport, Fixture, methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes);

            // Assert
            methodSaveTeamForUnspecifiedListUpdateReportPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListMemberNodeSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamForUnspecifiedListMemberNodeSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListMemberNodeSettings, Fixture, methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListMemberNodeSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListMemberNodeSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var listItemsDataTable = CreateType<DataTable>();
            var resourcePool = CreateType<DataTable>();
            var memberNode = CreateType<XmlNode>();
            var methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(DataTable), typeof(DataTable), typeof(XmlNode) };
            object[] parametersOfSaveTeamForUnspecifiedListMemberNodeSettings = { web, list, listItemsDataTable, resourcePool, memberNode };

            // Assert
            parametersOfSaveTeamForUnspecifiedListMemberNodeSettings.ShouldNotBeNull();
            parametersOfSaveTeamForUnspecifiedListMemberNodeSettings.Length.ShouldBe(5);
            methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListMemberNodeSettings, parametersOfSaveTeamForUnspecifiedListMemberNodeSettings, methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListMemberNodeSettings) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListMemberNodeSettings_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(DataTable), typeof(DataTable), typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListMemberNodeSettings, Fixture, methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveTeamForUnspecifiedListMemberNodeSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForUnspecifiedListMemberNodeSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(DataTable), typeof(DataTable), typeof(XmlNode) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForUnspecifiedListMemberNodeSettings, Fixture, methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamForUnspecifiedListMemberNodeSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeamForSpecificList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamForSpecificList_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamForSpecificListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForSpecificList, Fixture, methodSaveTeamForSpecificListPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamForSpecificList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForSpecificList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var teamDocumentXml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemid = CreateType<int>();
            var teamDocument = CreateType<XmlDocument>();
            var methodSaveTeamForSpecificListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(Guid), typeof(int), typeof(XmlDocument) };
            object[] parametersOfSaveTeamForSpecificList = { teamDocumentXml, web, listId, itemid, teamDocument };

            // Assert
            parametersOfSaveTeamForSpecificList.ShouldNotBeNull();
            parametersOfSaveTeamForSpecificList.Length.ShouldBe(5);
            methodSaveTeamForSpecificListPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForSpecificList, parametersOfSaveTeamForSpecificList, methodSaveTeamForSpecificListPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeamForSpecificList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForSpecificList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveTeamForSpecificListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(Guid), typeof(int), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForSpecificList, Fixture, methodSaveTeamForSpecificListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveTeamForSpecificListPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveTeamForSpecificList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamForSpecificList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamForSpecificListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(Guid), typeof(int), typeof(XmlDocument) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamForSpecificList, Fixture, methodSaveTeamForSpecificListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamForSpecificListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTeamSpecificListMemberNodeSettings) (Return Type : int?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_SaveTeamSpecificListMemberNodeSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamSpecificListMemberNodeSettings, Fixture, methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTeamSpecificListMemberNodeSettings) (Return Type : int?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamSpecificListMemberNodeSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var projectResourceRatesFeatureIsEnabled = CreateType<bool>();
            var projectId = CreateType<int>();
            var userValueCollection = CreateType<SPFieldUserValueCollection>();
            var dtResourcePool = CreateType<DataTable>();
            var userLookupIds = CreateType<List<int>>();
            var savedRatesUserIds = CreateType<List<int>>();
            var memberNode = CreateType<XmlNode>();
            var methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(bool), typeof(int), typeof(SPFieldUserValueCollection), typeof(DataTable), typeof(List<int>), typeof(List<int>), typeof(XmlNode) };
            object[] parametersOfSaveTeamSpecificListMemberNodeSettings = { web, li, projectResourceRatesFeatureIsEnabled, projectId, userValueCollection, dtResourcePool, userLookupIds, savedRatesUserIds, memberNode };

            // Assert
            parametersOfSaveTeamSpecificListMemberNodeSettings.ShouldNotBeNull();
            parametersOfSaveTeamSpecificListMemberNodeSettings.Length.ShouldBe(9);
            methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int?>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamSpecificListMemberNodeSettings, parametersOfSaveTeamSpecificListMemberNodeSettings, methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveTeamSpecificListMemberNodeSettings) (Return Type : int?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_SaveTeamSpecificListMemberNodeSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(bool), typeof(int), typeof(SPFieldUserValueCollection), typeof(DataTable), typeof(List<int>), typeof(List<int>), typeof(XmlNode) };
            const int parametersCount = 9;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodSaveTeamSpecificListMemberNodeSettings, Fixture, methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTeamSpecificListMemberNodeSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadSaveTeamSettingsFromWorkspaceRootWeb) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ReadSaveTeamSettingsFromWorkspaceRootWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamSettingsFromWorkspaceRootWeb, Fixture, methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadSaveTeamSettingsFromWorkspaceRootWeb) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadSaveTeamSettingsFromWorkspaceRootWeb_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var useTeam = CreateType<bool>();
            var listId = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool), typeof(Guid), typeof(int) };
            object[] parametersOfReadSaveTeamSettingsFromWorkspaceRootWeb = { web, useTeam, listId, itemid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamSettingsFromWorkspaceRootWeb, parametersOfReadSaveTeamSettingsFromWorkspaceRootWeb, methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes);

            // Assert
            parametersOfReadSaveTeamSettingsFromWorkspaceRootWeb.ShouldNotBeNull();
            parametersOfReadSaveTeamSettingsFromWorkspaceRootWeb.Length.ShouldBe(4);
            methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadSaveTeamSettingsFromWorkspaceRootWeb) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadSaveTeamSettingsFromWorkspaceRootWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool), typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamSettingsFromWorkspaceRootWeb, Fixture, methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes);

            // Assert
            methodReadSaveTeamSettingsFromWorkspaceRootWebPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadSaveTeamQuerySettingsFromXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ReadSaveTeamQuerySettingsFromXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadSaveTeamQuerySettingsFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamQuerySettingsFromXml, Fixture, methodReadSaveTeamQuerySettingsFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadSaveTeamQuerySettingsFromXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadSaveTeamQuerySettingsFromXml_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var teamDocument = CreateType<XmlDocument>();
            var listId = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodReadSaveTeamQuerySettingsFromXmlPrametersTypes = new Type[] { typeof(XmlDocument), typeof(Guid), typeof(int) };
            object[] parametersOfReadSaveTeamQuerySettingsFromXml = { teamDocument, listId, itemid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamQuerySettingsFromXml, parametersOfReadSaveTeamQuerySettingsFromXml, methodReadSaveTeamQuerySettingsFromXmlPrametersTypes);

            // Assert
            parametersOfReadSaveTeamQuerySettingsFromXml.ShouldNotBeNull();
            parametersOfReadSaveTeamQuerySettingsFromXml.Length.ShouldBe(3);
            methodReadSaveTeamQuerySettingsFromXmlPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadSaveTeamQuerySettingsFromXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadSaveTeamQuerySettingsFromXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadSaveTeamQuerySettingsFromXmlPrametersTypes = new Type[] { typeof(XmlDocument), typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadSaveTeamQuerySettingsFromXml, Fixture, methodReadSaveTeamQuerySettingsFromXmlPrametersTypes);

            // Assert
            methodReadSaveTeamQuerySettingsFromXmlPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProjectResourceRate) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_UpdateProjectResourceRate_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateProjectResourceRatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodUpdateProjectResourceRate, Fixture, methodUpdateProjectResourceRatePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateProjectResourceRate) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_UpdateProjectResourceRate_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var projectId = CreateType<int>();
            var resourceId = CreateType<int>();
            var rate = CreateType<decimal?>();
            var methodUpdateProjectResourceRatePrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(int), typeof(decimal?) };
            object[] parametersOfUpdateProjectResourceRate = { web, projectId, resourceId, rate };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodUpdateProjectResourceRate, parametersOfUpdateProjectResourceRate, methodUpdateProjectResourceRatePrametersTypes);

            // Assert
            parametersOfUpdateProjectResourceRate.ShouldNotBeNull();
            parametersOfUpdateProjectResourceRate.Length.ShouldBe(4);
            methodUpdateProjectResourceRatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProjectResourceRate) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_UpdateProjectResourceRate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateProjectResourceRatePrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(int), typeof(decimal?) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodUpdateProjectResourceRate, Fixture, methodUpdateProjectResourceRatePrametersTypes);

            // Assert
            methodUpdateProjectResourceRatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteProjectResourceRates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_DeleteProjectResourceRates_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteProjectResourceRatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodDeleteProjectResourceRates, Fixture, methodDeleteProjectResourceRatesPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteProjectResourceRates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_DeleteProjectResourceRates_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var projectId = CreateType<int>();
            var exceptResourceIds = CreateType<int[]>();
            var methodDeleteProjectResourceRatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(int[]) };
            object[] parametersOfDeleteProjectResourceRates = { web, projectId, exceptResourceIds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodDeleteProjectResourceRates, parametersOfDeleteProjectResourceRates, methodDeleteProjectResourceRatesPrametersTypes);

            // Assert
            parametersOfDeleteProjectResourceRates.ShouldNotBeNull();
            parametersOfDeleteProjectResourceRates.Length.ShouldBe(3);
            methodDeleteProjectResourceRatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteProjectResourceRates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_DeleteProjectResourceRates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteProjectResourceRatesPrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(int[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodDeleteProjectResourceRates, Fixture, methodDeleteProjectResourceRatesPrametersTypes);

            // Assert
            methodDeleteProjectResourceRatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, Fixture, methodGetResourceIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oWeb = CreateType<SPWeb>();
            var row = CreateType<DataRow>();
            var methodGetResourceIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow) };
            object[] parametersOfGetResourceId = { oWeb, row };

            // Assert
            parametersOfGetResourceId.ShouldNotBeNull();
            parametersOfGetResourceId.Length.ShouldBe(2);
            methodGetResourceIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, parametersOfGetResourceId, methodGetResourceIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(DataRow) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, Fixture, methodGetResourceIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceId_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetResourceIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, Fixture, methodGetResourceIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceId_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            var name = CreateType<string>();
            var methodGetResourceIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfGetResourceId = { web, username, name };

            // Assert
            parametersOfGetResourceId.ShouldNotBeNull();
            parametersOfGetResourceId.Length.ShouldBe(3);
            methodGetResourceIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, parametersOfGetResourceId, methodGetResourceIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceId_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceId, Fixture, methodGetResourceIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetProjectId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetProjectId, Fixture, methodGetProjectIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetProjectId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var id = CreateType<int>();
            var methodGetProjectIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };
            object[] parametersOfGetProjectId = { web, listId, id };

            // Assert
            parametersOfGetProjectId.ShouldNotBeNull();
            parametersOfGetProjectId.Length.ShouldBe(3);
            methodGetProjectIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetProjectId, parametersOfGetProjectId, methodGetProjectIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetProjectId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetProjectId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProjectIdPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetProjectId, Fixture, methodGetProjectIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProjectIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_setItemPermissions_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetItemPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetItemPermissions, Fixture, methodsetItemPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setItemPermissions_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<string>();
            var perms = CreateType<string>();
            var listItem = CreateType<SPListItem>();
            var methodsetItemPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPListItem) };
            object[] parametersOfsetItemPermissions = { web, user, perms, listItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetItemPermissions, methodsetItemPermissionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfsetItemPermissions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetItemPermissions.ShouldNotBeNull();
            parametersOfsetItemPermissions.Length.ShouldBe(4);
            methodsetItemPermissionsPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setItemPermissions_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<string>();
            var perms = CreateType<string>();
            var listItem = CreateType<SPListItem>();
            var methodsetItemPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPListItem) };
            object[] parametersOfsetItemPermissions = { web, user, perms, listItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetItemPermissions, parametersOfsetItemPermissions, methodsetItemPermissionsPrametersTypes);

            // Assert
            parametersOfsetItemPermissions.ShouldNotBeNull();
            parametersOfsetItemPermissions.Length.ShouldBe(4);
            methodsetItemPermissionsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setItemPermissions_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetItemPermissions, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setItemPermissions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetItemPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetItemPermissions, Fixture, methodsetItemPermissionsPrametersTypes);

            // Assert
            methodsetItemPermissionsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setItemPermissions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setItemPermissions_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetItemPermissions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessListItemGroupRoleAssignments) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ProcessListItemGroupRoleAssignments_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessListItemGroupRoleAssignmentsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodProcessListItemGroupRoleAssignments, Fixture, methodProcessListItemGroupRoleAssignmentsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessListItemGroupRoleAssignments) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ProcessListItemGroupRoleAssignments_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listItem = CreateType<SPListItem>();
            var user = CreateType<string>();
            var perms = CreateType<string>();
            var lookupsSecurityGroups = CreateType<IList<string>>();
            var additionalPermissions = CreateType<IList<string>>();
            var methodProcessListItemGroupRoleAssignmentsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(string), typeof(string), typeof(IList<string>), typeof(IList<string>) };
            object[] parametersOfProcessListItemGroupRoleAssignments = { web, listItem, user, perms, lookupsSecurityGroups, additionalPermissions };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodProcessListItemGroupRoleAssignments, parametersOfProcessListItemGroupRoleAssignments, methodProcessListItemGroupRoleAssignmentsPrametersTypes);

            // Assert
            parametersOfProcessListItemGroupRoleAssignments.ShouldNotBeNull();
            parametersOfProcessListItemGroupRoleAssignments.Length.ShouldBe(6);
            methodProcessListItemGroupRoleAssignmentsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessListItemGroupRoleAssignments) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ProcessListItemGroupRoleAssignments_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessListItemGroupRoleAssignmentsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(string), typeof(string), typeof(IList<string>), typeof(IList<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodProcessListItemGroupRoleAssignments, Fixture, methodProcessListItemGroupRoleAssignmentsPrametersTypes);

            // Assert
            methodProcessListItemGroupRoleAssignmentsPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListAdditionalPermissions) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetListAdditionalPermissions_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListAdditionalPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListAdditionalPermissions, Fixture, methodGetListAdditionalPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListAdditionalPermissions) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListAdditionalPermissions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gridGanttSettings = CreateType<GridGanttSettings>();
            var methodGetListAdditionalPermissionsPrametersTypes = new Type[] { typeof(GridGanttSettings) };
            object[] parametersOfGetListAdditionalPermissions = { gridGanttSettings };

            // Assert
            parametersOfGetListAdditionalPermissions.ShouldNotBeNull();
            parametersOfGetListAdditionalPermissions.Length.ShouldBe(1);
            methodGetListAdditionalPermissionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListAdditionalPermissions, parametersOfGetListAdditionalPermissions, methodGetListAdditionalPermissionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListAdditionalPermissions) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListAdditionalPermissions_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListAdditionalPermissionsPrametersTypes = new Type[] { typeof(GridGanttSettings) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListAdditionalPermissions, Fixture, methodGetListAdditionalPermissionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListAdditionalPermissionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListAdditionalPermissions) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListAdditionalPermissions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListAdditionalPermissionsPrametersTypes = new Type[] { typeof(GridGanttSettings) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListAdditionalPermissions, Fixture, methodGetListAdditionalPermissionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListAdditionalPermissionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListLookupsSecurityGroups) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetListLookupsSecurityGroups_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListLookupsSecurityGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListLookupsSecurityGroups, Fixture, methodGetListLookupsSecurityGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListLookupsSecurityGroups) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListLookupsSecurityGroups_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listItem = CreateType<SPListItem>();
            var gridGanttSettings = CreateType<GridGanttSettings>();
            var methodGetListLookupsSecurityGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(GridGanttSettings) };
            object[] parametersOfGetListLookupsSecurityGroups = { web, listItem, gridGanttSettings };

            // Assert
            parametersOfGetListLookupsSecurityGroups.ShouldNotBeNull();
            parametersOfGetListLookupsSecurityGroups.Length.ShouldBe(3);
            methodGetListLookupsSecurityGroupsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListLookupsSecurityGroups, parametersOfGetListLookupsSecurityGroups, methodGetListLookupsSecurityGroupsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListLookupsSecurityGroups) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListLookupsSecurityGroups_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListLookupsSecurityGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(GridGanttSettings) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListLookupsSecurityGroups, Fixture, methodGetListLookupsSecurityGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListLookupsSecurityGroupsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetListLookupsSecurityGroups) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListLookupsSecurityGroups_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListLookupsSecurityGroupsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem), typeof(GridGanttSettings) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListLookupsSecurityGroups, Fixture, methodGetListLookupsSecurityGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListLookupsSecurityGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_setPermissions_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetPermissions, Fixture, methodsetPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setPermissions_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<string>();
            var perms = CreateType<string>();
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetPermissions = { web, user, perms };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetPermissions, methodsetPermissionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfsetPermissions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetPermissions.ShouldNotBeNull();
            parametersOfsetPermissions.Length.ShouldBe(3);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setPermissions_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var user = CreateType<string>();
            var perms = CreateType<string>();
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetPermissions = { web, user, perms };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetPermissions, parametersOfsetPermissions, methodsetPermissionsPrametersTypes);

            // Assert
            parametersOfsetPermissions.ShouldNotBeNull();
            parametersOfsetPermissions.Length.ShouldBe(3);
            methodsetPermissionsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setPermissions_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetPermissions, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setPermissions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetPermissionsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodsetPermissions, Fixture, methodsetPermissionsPrametersTypes);

            // Assert
            methodsetPermissionsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setPermissions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_setPermissions_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetPermissions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeam_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, Fixture, methodGetTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var queryDocumentXml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeam(queryDocumentXml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var queryDocumentXml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeam = { queryDocumentXml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeam, methodGetTeamPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, Fixture, methodGetTeamPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, parametersOfGetTeam, methodGetTeamPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeam.ShouldNotBeNull();
            parametersOfGetTeam.Length.ShouldBe(2);
            methodGetTeamPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var queryDocumentXml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeam = { queryDocumentXml, oWeb };

            // Assert
            parametersOfGetTeam.ShouldNotBeNull();
            parametersOfGetTeam.Length.ShouldBe(2);
            methodGetTeamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, parametersOfGetTeam, methodGetTeamPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, Fixture, methodGetTeamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeam, Fixture, methodGetTeamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeam) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeam, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadGetTeamSettingsForSpecificWeb) (Return Type : SPWeb) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ReadGetTeamSettingsForSpecificWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadGetTeamSettingsForSpecificWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamSettingsForSpecificWeb, Fixture, methodReadGetTeamSettingsForSpecificWebPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadGetTeamSettingsForSpecificWeb) (Return Type : SPWeb) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadGetTeamSettingsForSpecificWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oWeb = CreateType<SPWeb>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var list = CreateType<SPList>();
            var useTeam = CreateType<bool>();
            var methodReadGetTeamSettingsForSpecificWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(int), typeof(SPList), typeof(bool) };
            object[] parametersOfReadGetTeamSettingsForSpecificWeb = { oWeb, webId, listId, itemId, list, useTeam };

            // Assert
            parametersOfReadGetTeamSettingsForSpecificWeb.ShouldNotBeNull();
            parametersOfReadGetTeamSettingsForSpecificWeb.Length.ShouldBe(6);
            methodReadGetTeamSettingsForSpecificWebPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPWeb>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamSettingsForSpecificWeb, parametersOfReadGetTeamSettingsForSpecificWeb, methodReadGetTeamSettingsForSpecificWebPrametersTypes));
        }

        #endregion

        #region Method Call : (ReadGetTeamSettingsForSpecificWeb) (Return Type : SPWeb) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadGetTeamSettingsForSpecificWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadGetTeamSettingsForSpecificWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(int), typeof(SPList), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamSettingsForSpecificWeb, Fixture, methodReadGetTeamSettingsForSpecificWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadGetTeamSettingsForSpecificWebPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (ReadGetTeamSettingsForSpecificWeb) (Return Type : SPWeb) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadGetTeamSettingsForSpecificWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadGetTeamSettingsForSpecificWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(Guid), typeof(int), typeof(SPList), typeof(bool) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamSettingsForSpecificWeb, Fixture, methodReadGetTeamSettingsForSpecificWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadGetTeamSettingsForSpecificWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListUseTeamSetting) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetListUseTeamSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListUseTeamSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListUseTeamSetting, Fixture, methodGetListUseTeamSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListUseTeamSetting) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListUseTeamSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetListUseTeamSettingPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListUseTeamSetting = { list };

            // Assert
            parametersOfGetListUseTeamSetting.ShouldNotBeNull();
            parametersOfGetListUseTeamSetting.Length.ShouldBe(1);
            methodGetListUseTeamSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListUseTeamSetting, parametersOfGetListUseTeamSetting, methodGetListUseTeamSettingPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListUseTeamSetting) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetListUseTeamSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListUseTeamSettingPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetListUseTeamSetting, Fixture, methodGetListUseTeamSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListUseTeamSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadGetTeamQuerySettingsFromXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ReadGetTeamQuerySettingsFromXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadGetTeamQuerySettingsFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamQuerySettingsFromXml, Fixture, methodReadGetTeamQuerySettingsFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadGetTeamQuerySettingsFromXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadGetTeamQuerySettingsFromXml_Static_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var queryDocumentXml = CreateType<string>();
            var filterField = CreateType<string>();
            var filterValue = CreateType<string>();
            var columns = CreateType<ArrayList>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var currentteam = CreateType<string>();
            var methodReadGetTeamQuerySettingsFromXmlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfReadGetTeamQuerySettingsFromXml = { queryDocumentXml, filterField, filterValue, columns, webId, listId, itemId, currentteam };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamQuerySettingsFromXml, parametersOfReadGetTeamQuerySettingsFromXml, methodReadGetTeamQuerySettingsFromXmlPrametersTypes);

            // Assert
            parametersOfReadGetTeamQuerySettingsFromXml.ShouldNotBeNull();
            parametersOfReadGetTeamQuerySettingsFromXml.Length.ShouldBe(8);
            methodReadGetTeamQuerySettingsFromXmlPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadGetTeamQuerySettingsFromXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadGetTeamQuerySettingsFromXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadGetTeamQuerySettingsFromXmlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(Guid), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadGetTeamQuerySettingsFromXml, Fixture, methodReadGetTeamQuerySettingsFromXmlPrametersTypes);

            // Assert
            methodReadGetTeamQuerySettingsFromXmlPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamFromCurrentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, Fixture, methodGetTeamFromCurrentPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var currentteam = CreateType<string>();
            var methodGetTeamFromCurrentPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(string) };
            object[] parametersOfGetTeamFromCurrent = { web, filterfield, filterval, arrColumns, currentteam };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeamFromCurrent, methodGetTeamFromCurrentPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, Fixture, methodGetTeamFromCurrentPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, parametersOfGetTeamFromCurrent, methodGetTeamFromCurrentPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeamFromCurrent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeamFromCurrent.ShouldNotBeNull();
            parametersOfGetTeamFromCurrent.Length.ShouldBe(5);
            methodGetTeamFromCurrentPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var currentteam = CreateType<string>();
            var methodGetTeamFromCurrentPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(string) };
            object[] parametersOfGetTeamFromCurrent = { web, filterfield, filterval, arrColumns, currentteam };

            // Assert
            parametersOfGetTeamFromCurrent.ShouldNotBeNull();
            parametersOfGetTeamFromCurrent.Length.ShouldBe(5);
            methodGetTeamFromCurrentPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, parametersOfGetTeamFromCurrent, methodGetTeamFromCurrentPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamFromCurrentPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, Fixture, methodGetTeamFromCurrentPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamFromCurrentPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamFromCurrentPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromCurrent, Fixture, methodGetTeamFromCurrentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamFromCurrentPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeamFromCurrent, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeamFromCurrent) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromCurrent_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeamFromCurrent, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamFromListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, Fixture, methodGetTeamFromListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var ListId = CreateType<Guid>();
            var ItemId = CreateType<int>();
            var methodGetTeamFromListItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(int) };
            object[] parametersOfGetTeamFromListItem = { web, filterfield, filterval, arrColumns, ListId, ItemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeamFromListItem, methodGetTeamFromListItemPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, Fixture, methodGetTeamFromListItemPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, parametersOfGetTeamFromListItem, methodGetTeamFromListItemPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeamFromListItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeamFromListItem.ShouldNotBeNull();
            parametersOfGetTeamFromListItem.Length.ShouldBe(6);
            methodGetTeamFromListItemPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var ListId = CreateType<Guid>();
            var ItemId = CreateType<int>();
            var methodGetTeamFromListItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(int) };
            object[] parametersOfGetTeamFromListItem = { web, filterfield, filterval, arrColumns, ListId, ItemId };

            // Assert
            parametersOfGetTeamFromListItem.ShouldNotBeNull();
            parametersOfGetTeamFromListItem.Length.ShouldBe(6);
            methodGetTeamFromListItemPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, parametersOfGetTeamFromListItem, methodGetTeamFromListItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamFromListItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, Fixture, methodGetTeamFromListItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamFromListItemPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamFromListItemPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList), typeof(Guid), typeof(int) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromListItem, Fixture, methodGetTeamFromListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamFromListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeamFromListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeamFromListItem) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromListItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeamFromListItem, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendUserValuesToTeamDocument) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_AppendUserValuesToTeamDocument_Static_Method_Call_Internally(Type[] types)
        {
            var methodAppendUserValuesToTeamDocumentPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAppendUserValuesToTeamDocument, Fixture, methodAppendUserValuesToTeamDocumentPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendUserValuesToTeamDocument) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_AppendUserValuesToTeamDocument_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userValueCollection = CreateType<SPFieldUserValueCollection>();
            var result = CreateType<XmlDocument>();
            var resources = CreateType<DataTable>();
            var additionalPermissions = CreateType<IList<string>>();
            var methodAppendUserValuesToTeamDocumentPrametersTypes = new Type[] { typeof(SPFieldUserValueCollection), typeof(XmlDocument), typeof(DataTable), typeof(IList<string>) };
            object[] parametersOfAppendUserValuesToTeamDocument = { userValueCollection, result, resources, additionalPermissions };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAppendUserValuesToTeamDocument, parametersOfAppendUserValuesToTeamDocument, methodAppendUserValuesToTeamDocumentPrametersTypes);

            // Assert
            parametersOfAppendUserValuesToTeamDocument.ShouldNotBeNull();
            parametersOfAppendUserValuesToTeamDocument.Length.ShouldBe(4);
            methodAppendUserValuesToTeamDocumentPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendUserValuesToTeamDocument) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_AppendUserValuesToTeamDocument_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendUserValuesToTeamDocumentPrametersTypes = new Type[] { typeof(SPFieldUserValueCollection), typeof(XmlDocument), typeof(DataTable), typeof(IList<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAppendUserValuesToTeamDocument, Fixture, methodAppendUserValuesToTeamDocumentPrametersTypes);

            // Assert
            methodAppendUserValuesToTeamDocumentPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcesFromUrl) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourcesFromUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcesFromUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcesFromUrl, Fixture, methodGetResourcesFromUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcesFromUrl) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcesFromUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var tSite = CreateType<SPSite>();
            var listItem = CreateType<SPListItem>();
            var resourceUrl = CreateType<string>();
            var methodGetResourcesFromUrlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(ArrayList), typeof(SPSite), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetResourcesFromUrl = { filterfield, filterval, arrColumns, tSite, listItem, resourceUrl };

            // Assert
            parametersOfGetResourcesFromUrl.ShouldNotBeNull();
            parametersOfGetResourcesFromUrl.Length.ShouldBe(6);
            methodGetResourcesFromUrlPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcesFromUrl, parametersOfGetResourcesFromUrl, methodGetResourcesFromUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcesFromUrl) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcesFromUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcesFromUrlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(ArrayList), typeof(SPSite), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcesFromUrl, Fixture, methodGetResourcesFromUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcesFromUrlPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetResourcesFromUrl) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcesFromUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcesFromUrlPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(ArrayList), typeof(SPSite), typeof(SPListItem), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcesFromUrl, Fixture, methodGetResourcesFromUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcesFromUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamFromWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, Fixture, methodGetTeamFromWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var methodGetTeamFromWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList) };
            object[] parametersOfGetTeamFromWeb = { web, filterfield, filterval, arrColumns };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeamFromWeb, methodGetTeamFromWebPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, Fixture, methodGetTeamFromWebPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, parametersOfGetTeamFromWeb, methodGetTeamFromWebPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeamFromWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeamFromWeb.ShouldNotBeNull();
            parametersOfGetTeamFromWeb.Length.ShouldBe(4);
            methodGetTeamFromWebPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var filterfield = CreateType<string>();
            var filterval = CreateType<string>();
            var arrColumns = CreateType<ArrayList>();
            var methodGetTeamFromWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList) };
            object[] parametersOfGetTeamFromWeb = { web, filterfield, filterval, arrColumns };

            // Assert
            parametersOfGetTeamFromWeb.ShouldNotBeNull();
            parametersOfGetTeamFromWeb.Length.ShouldBe(4);
            methodGetTeamFromWebPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, parametersOfGetTeamFromWeb, methodGetTeamFromWebPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamFromWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, Fixture, methodGetTeamFromWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamFromWebPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamFromWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(ArrayList) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamFromWeb, Fixture, methodGetTeamFromWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamFromWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeamFromWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeamFromWeb) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamFromWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeamFromWeb, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addAttribute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_addAttribute_Static_Method_Call_Internally(Type[] types)
        {
            var methodaddAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodaddAttribute, Fixture, methodaddAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (addAttribute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_addAttribute_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var doc = CreateType<XmlDocument>();
            var dr = CreateType<DataRow>();
            var attribute = CreateType<string>();
            var methodaddAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument), typeof(DataRow), typeof(string) };
            object[] parametersOfaddAttribute = { nd, doc, dr, attribute };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddAttribute, methodaddAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfaddAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddAttribute.ShouldNotBeNull();
            parametersOfaddAttribute.Length.ShouldBe(4);
            methodaddAttributePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addAttribute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_addAttribute_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddAttribute, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addAttribute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_addAttribute_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(XmlDocument), typeof(DataRow), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodaddAttribute, Fixture, methodaddAttributePrametersTypes);

            // Assert
            methodaddAttributePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addAttribute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_addAttribute_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddAttribute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGenericResourceGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, Fixture, methodGetGenericResourceGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetGenericResourceGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGenericResourceGrid = { id, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGenericResourceGrid, methodGetGenericResourceGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, Fixture, methodGetGenericResourceGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, parametersOfGetGenericResourceGrid, methodGetGenericResourceGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetGenericResourceGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGenericResourceGrid.ShouldNotBeNull();
            parametersOfGetGenericResourceGrid.Length.ShouldBe(2);
            methodGetGenericResourceGridPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetGenericResourceGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetGenericResourceGrid = { id, oWeb };

            // Assert
            parametersOfGetGenericResourceGrid.ShouldNotBeNull();
            parametersOfGetGenericResourceGrid.Length.ShouldBe(2);
            methodGetGenericResourceGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlDocument>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, parametersOfGetGenericResourceGrid, methodGetGenericResourceGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGenericResourceGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, Fixture, methodGetGenericResourceGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGenericResourceGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGenericResourceGridPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetGenericResourceGrid, Fixture, methodGetGenericResourceGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGenericResourceGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGenericResourceGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGenericResourceGrid) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetGenericResourceGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGenericResourceGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, Fixture, methodGetTeamGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridLayout(xml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeamGridLayout = { xml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeamGridLayout, methodGetTeamGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, Fixture, methodGetTeamGridLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, parametersOfGetTeamGridLayout, methodGetTeamGridLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeamGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeamGridLayout.ShouldNotBeNull();
            parametersOfGetTeamGridLayout.Length.ShouldBe(2);
            methodGetTeamGridLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeamGridLayout = { xml, oWeb };

            // Assert
            parametersOfGetTeamGridLayout.ShouldNotBeNull();
            parametersOfGetTeamGridLayout.Length.ShouldBe(2);
            methodGetTeamGridLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, parametersOfGetTeamGridLayout, methodGetTeamGridLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, Fixture, methodGetTeamGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamGridLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridLayout, Fixture, methodGetTeamGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeamGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeamGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeamGridLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddHtmlColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_AddHtmlColumn_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddHtmlColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAddHtmlColumn, Fixture, methodAddHtmlColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddHtmlColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_AddHtmlColumn_Static_Method_Call_Void_With_9_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<XmlDocument>();
            var allColumnsNode = CreateType<XmlNode>();
            var headerNode = CreateType<XmlNode>();
            var visible = CreateType<bool>();
            var name = CreateType<string>();
            var displayName = CreateType<string>();
            var relativeWidth = CreateType<int?>();
            var width = CreateType<int?>();
            var align = CreateType<string>();
            var methodAddHtmlColumnPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode), typeof(XmlNode), typeof(bool), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(string) };
            object[] parametersOfAddHtmlColumn = { xml, allColumnsNode, headerNode, visible, name, displayName, relativeWidth, width, align };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAddHtmlColumn, parametersOfAddHtmlColumn, methodAddHtmlColumnPrametersTypes);

            // Assert
            parametersOfAddHtmlColumn.ShouldNotBeNull();
            parametersOfAddHtmlColumn.Length.ShouldBe(9);
            methodAddHtmlColumnPrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddHtmlColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_AddHtmlColumn_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddHtmlColumnPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode), typeof(XmlNode), typeof(bool), typeof(string), typeof(string), typeof(int?), typeof(int?), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodAddHtmlColumn, Fixture, methodAddHtmlColumnPrametersTypes);

            // Assert
            methodAddHtmlColumnPrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, Fixture, methodGetResourceGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridLayout(xml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourceGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceGridLayout = { xml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceGridLayout, methodGetResourceGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, Fixture, methodGetResourceGridLayoutPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, parametersOfGetResourceGridLayout, methodGetResourceGridLayoutPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetResourceGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceGridLayout.ShouldNotBeNull();
            parametersOfGetResourceGridLayout.Length.ShouldBe(2);
            methodGetResourceGridLayoutPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourceGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceGridLayout = { xml, oWeb };

            // Assert
            parametersOfGetResourceGridLayout.ShouldNotBeNull();
            parametersOfGetResourceGridLayout.Length.ShouldBe(2);
            methodGetResourceGridLayoutPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, parametersOfGetResourceGridLayout, methodGetResourceGridLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, Fixture, methodGetResourceGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceGridLayoutPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceGridLayoutPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridLayout, Fixture, methodGetResourceGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceGridLayout, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_isValidResField_Static_Method_Call_Internally(Type[] types)
        {
            var methodisValidResFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodisValidResField, Fixture, methodisValidResFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_isValidResField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var methodisValidResFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisValidResField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisValidResField, methodisValidResFieldPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisValidResField.ShouldNotBeNull();
            parametersOfisValidResField.Length.ShouldBe(1);
            methodisValidResFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfisValidResField));
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_isValidResField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var methodisValidResFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisValidResField = { field };

            // Assert
            parametersOfisValidResField.ShouldNotBeNull();
            parametersOfisValidResField.Length.ShouldBe(1);
            methodisValidResFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodisValidResField, parametersOfisValidResField, methodisValidResFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_isValidResField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisValidResFieldPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodisValidResField, Fixture, methodisValidResFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisValidResFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_isValidResField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisValidResField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isValidResField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_isValidResField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisValidResField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, Fixture, methodGetResourceGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourceGridData(xml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourceGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceGridData = { xml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourceGridData, methodGetResourceGridDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, Fixture, methodGetResourceGridDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, parametersOfGetResourceGridData, methodGetResourceGridDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetResourceGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceGridData.ShouldNotBeNull();
            parametersOfGetResourceGridData.Length.ShouldBe(2);
            methodGetResourceGridDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourceGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourceGridData = { xml, oWeb };

            // Assert
            parametersOfGetResourceGridData.ShouldNotBeNull();
            parametersOfGetResourceGridData.Length.ShouldBe(2);
            methodGetResourceGridDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, parametersOfGetResourceGridData, methodGetResourceGridDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, Fixture, methodGetResourceGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceGridDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceGridData, Fixture, methodGetResourceGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceGridData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetTeamGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTeamGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, Fixture, methodGetTeamGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetTeamGridData(xml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeamGridData = { xml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTeamGridData, methodGetTeamGridDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, Fixture, methodGetTeamGridDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, parametersOfGetTeamGridData, methodGetTeamGridDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetTeamGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTeamGridData.ShouldNotBeNull();
            parametersOfGetTeamGridData.Length.ShouldBe(2);
            methodGetTeamGridDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetTeamGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTeamGridData = { xml, oWeb };

            // Assert
            parametersOfGetTeamGridData.ShouldNotBeNull();
            parametersOfGetTeamGridData.Length.ShouldBe(2);
            methodGetTeamGridDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, parametersOfGetTeamGridData, methodGetTeamGridDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTeamGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, Fixture, methodGetTeamGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTeamGridDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTeamGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetTeamGridData, Fixture, methodGetTeamGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTeamGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTeamGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTeamGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetTeamGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTeamGridData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, Fixture, methodGetResourcePoolXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolXml(xml, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourcePoolXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolXml = { xml, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolXml, methodGetResourcePoolXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, Fixture, methodGetResourcePoolXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, parametersOfGetResourcePoolXml, methodGetResourcePoolXmlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetResourcePoolXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolXml.ShouldNotBeNull();
            parametersOfGetResourcePoolXml.Length.ShouldBe(2);
            methodGetResourcePoolXmlPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetResourcePoolXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePoolXml = { xml, oWeb };

            // Assert
            parametersOfGetResourcePoolXml.ShouldNotBeNull();
            parametersOfGetResourcePoolXml.Length.ShouldBe(2);
            methodGetResourcePoolXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, parametersOfGetResourcePoolXml, methodGetResourcePoolXmlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, Fixture, methodGetResourcePoolXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolXml, Fixture, methodGetResourcePoolXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolXml, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourcePool_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePool(xml, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePool = { xml, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePool, methodGetResourcePoolPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, parametersOfGetResourcePool, methodGetResourcePoolPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetResourcePool);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePool.ShouldNotBeNull();
            parametersOfGetResourcePool.Length.ShouldBe(2);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetResourcePool = { xml, web };

            // Assert
            parametersOfGetResourcePool.ShouldNotBeNull();
            parametersOfGetResourcePool.Length.ShouldBe(2);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, parametersOfGetResourcePool, methodGetResourcePoolPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePool, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePool, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolForSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, Fixture, methodGetResourcePoolForSavePrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetResourcePoolForSave(xml, web, nodeTeam);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodGetResourcePoolForSavePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList) };
            object[] parametersOfGetResourcePoolForSave = { xml, web, nodeTeam };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolForSave, methodGetResourcePoolForSavePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, Fixture, methodGetResourcePoolForSavePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, parametersOfGetResourcePoolForSave, methodGetResourcePoolForSavePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetResourcePoolForSave);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourcePoolForSave.ShouldNotBeNull();
            parametersOfGetResourcePoolForSave.Length.ShouldBe(3);
            methodGetResourcePoolForSavePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            var methodGetResourcePoolForSavePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList) };
            object[] parametersOfGetResourcePoolForSave = { xml, web, nodeTeam };

            // Assert
            parametersOfGetResourcePoolForSave.ShouldNotBeNull();
            parametersOfGetResourcePoolForSave.Length.ShouldBe(3);
            methodGetResourcePoolForSavePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, parametersOfGetResourcePoolForSave, methodGetResourcePoolForSavePrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolForSavePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, Fixture, methodGetResourcePoolForSavePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolForSavePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolForSavePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePoolForSave, Fixture, methodGetResourcePoolForSavePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolForSavePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourcePoolForSave, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourcePoolForSave) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePoolForSave_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourcePoolForSave, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourcePool_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetResourcePoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var web = CreateType<SPWeb>();
            var nodeTeam = CreateType<XmlNodeList>();
            var ensureFilterValueSafe = CreateType<bool>();
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList), typeof(bool) };
            object[] parametersOfGetResourcePool = { xml, web, nodeTeam, ensureFilterValueSafe };

            // Assert
            parametersOfGetResourcePool.ShouldNotBeNull();
            parametersOfGetResourcePool.Length.ShouldBe(4);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, parametersOfGetResourcePool, methodGetResourcePoolPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetResourcePool) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourcePool_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourcePoolPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(XmlNodeList), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourcePool, Fixture, methodGetResourcePoolPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourcePoolPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ReadFilterInfoFromXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_ReadFilterInfoFromXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadFilterInfoFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadFilterInfoFromXml, Fixture, methodReadFilterInfoFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFilterInfoFromXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadFilterInfoFromXml_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var ensureFilterValueSafe = CreateType<bool>();
            var arrColumns = CreateType<ArrayList>();
            var filterValue = CreateType<string>();
            var filterField = CreateType<string>();
            var methodReadFilterInfoFromXmlPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(ArrayList), typeof(string), typeof(string) };
            object[] parametersOfReadFilterInfoFromXml = { xml, ensureFilterValueSafe, arrColumns, filterValue, filterField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadFilterInfoFromXml, parametersOfReadFilterInfoFromXml, methodReadFilterInfoFromXmlPrametersTypes);

            // Assert
            parametersOfReadFilterInfoFromXml.ShouldNotBeNull();
            parametersOfReadFilterInfoFromXml.Length.ShouldBe(5);
            methodReadFilterInfoFromXmlPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFilterInfoFromXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_ReadFilterInfoFromXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFilterInfoFromXmlPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(ArrayList), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodReadFilterInfoFromXml, Fixture, methodReadFilterInfoFromXmlPrametersTypes);

            // Assert
            methodReadFilterInfoFromXmlPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceUrl, Fixture, methodGetResourceUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetResourceUrlPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetResourceUrl = { web };

            // Assert
            parametersOfGetResourceUrl.ShouldNotBeNull();
            parametersOfGetResourceUrl.Length.ShouldBe(1);
            methodGetResourceUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceUrl, parametersOfGetResourceUrl, methodGetResourceUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceUrlPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceUrl, Fixture, methodGetResourceUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetResourceUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceUrlPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceUrl, Fixture, methodGetResourceUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetResourceData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceData, Fixture, methodGetResourceDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nodeTeam = CreateType<XmlNodeList>();
            var arrColumns = CreateType<ArrayList>();
            var filterValue = CreateType<string>();
            var filterField = CreateType<string>();
            var resourceUrl = CreateType<string>();
            var methodGetResourceDataPrametersTypes = new Type[] { typeof(XmlNodeList), typeof(ArrayList), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetResourceData = { nodeTeam, arrColumns, filterValue, filterField, resourceUrl };

            // Assert
            parametersOfGetResourceData.ShouldNotBeNull();
            parametersOfGetResourceData.Length.ShouldBe(5);
            methodGetResourceDataPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceData, parametersOfGetResourceData, methodGetResourceDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetResourceData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceDataPrametersTypes = new Type[] { typeof(XmlNodeList), typeof(ArrayList), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceData, Fixture, methodGetResourceDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceDataPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetResourceData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetResourceData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceDataPrametersTypes = new Type[] { typeof(XmlNodeList), typeof(ArrayList), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetResourceData, Fixture, methodGetResourceDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_GetWebGroups_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWebGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, Fixture, methodGetWebGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.GetWebGroups(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetWebGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWebGroups = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWebGroups, methodGetWebGroupsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, Fixture, methodGetWebGroupsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<SPGroup>>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, parametersOfGetWebGroups, methodGetWebGroupsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPITeamInstanceFixture, parametersOfGetWebGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWebGroups.ShouldNotBeNull();
            parametersOfGetWebGroups.Length.ShouldBe(1);
            methodGetWebGroupsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetWebGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWebGroups = { spWeb };

            // Assert
            parametersOfGetWebGroups.ShouldNotBeNull();
            parametersOfGetWebGroups.Length.ShouldBe(1);
            methodGetWebGroupsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<SPGroup>>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, parametersOfGetWebGroups, methodGetWebGroupsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebGroupsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, Fixture, methodGetWebGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebGroupsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebGroupsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodGetWebGroups, Fixture, methodGetWebGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebGroupsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebGroups) (Return Type : List<SPGroup>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_GetWebGroups_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebGroups, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodVerifyProjectTeamWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodVerifyProjectTeamWorkspace, Fixture, methodVerifyProjectTeamWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => APITeam.VerifyProjectTeamWorkspace(web, out itemId, out listId);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var methodVerifyProjectTeamWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(Guid) };
            object[] parametersOfVerifyProjectTeamWorkspace = { web, itemId, listId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodVerifyProjectTeamWorkspace, parametersOfVerifyProjectTeamWorkspace, methodVerifyProjectTeamWorkspacePrametersTypes);

            // Assert
            parametersOfVerifyProjectTeamWorkspace.ShouldNotBeNull();
            parametersOfVerifyProjectTeamWorkspace.Length.ShouldBe(3);
            methodVerifyProjectTeamWorkspacePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodVerifyProjectTeamWorkspace, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodVerifyProjectTeamWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(int), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodVerifyProjectTeamWorkspace, Fixture, methodVerifyProjectTeamWorkspacePrametersTypes);

            // Assert
            methodVerifyProjectTeamWorkspacePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (VerifyProjectTeamWorkspace) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_VerifyProjectTeamWorkspace_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodVerifyProjectTeamWorkspace, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPITeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsProjectCenter) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_IsProjectCenter_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsProjectCenterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsProjectCenter, Fixture, methodIsProjectCenterPrametersTypes);
        }

        #endregion

        #region Method Call : (IsProjectCenter) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_IsProjectCenter_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var methodIsProjectCenterPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfIsProjectCenter = { web, listId };

            // Assert
            parametersOfIsProjectCenter.ShouldNotBeNull();
            parametersOfIsProjectCenter.Length.ShouldBe(2);
            methodIsProjectCenterPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsProjectCenter, parametersOfIsProjectCenter, methodIsProjectCenterPrametersTypes));
        }

        #endregion

        #region Method Call : (IsProjectCenter) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_IsProjectCenter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsProjectCenterPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsProjectCenter, Fixture, methodIsProjectCenterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsProjectCenterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsPfeSite) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APITeam_IsPfeSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsPfeSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsPfeSite, Fixture, methodIsPfeSitePrametersTypes);
        }

        #endregion

        #region Method Call : (IsPfeSite) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_IsPfeSite_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodIsPfeSitePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfIsPfeSite = { web };

            // Assert
            parametersOfIsPfeSite.ShouldNotBeNull();
            parametersOfIsPfeSite.Length.ShouldBe(1);
            methodIsPfeSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsPfeSite, parametersOfIsPfeSite, methodIsPfeSitePrametersTypes));
        }

        #endregion

        #region Method Call : (IsPfeSite) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APITeam_IsPfeSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsPfeSitePrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPITeamInstanceFixture, _aPITeamInstanceType, MethodIsPfeSite, Fixture, methodIsPfeSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsPfeSitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}