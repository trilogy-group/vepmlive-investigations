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
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using GridGanttSettings = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.GridGanttSettings" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GridGanttSettingsTest : AbstractBaseSetupTypedTest<GridGanttSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridGanttSettings) Initializer

        private const string MethodSaveSettings = "SaveSettings";
        private const string MethodGetString = "GetString";
        private const string FieldStartDate = "StartDate";
        private const string FieldDueDate = "DueDate";
        private const string FieldProgress = "Progress";
        private const string FieldWBS = "WBS";
        private const string FieldMilestone = "Milestone";
        private const string FieldExecutive = "Executive";
        private const string FieldInformation = "Information";
        private const string FieldItemLink = "ItemLink";
        private const string FieldRibbonBehavior = "RibbonBehavior";
        private const string FieldRollupLists = "RollupLists";
        private const string FieldRollupSites = "RollupSites";
        private const string FieldShowViewToolbar = "ShowViewToolbar";
        private const string FieldHideNewButton = "HideNewButton";
        private const string FieldPerformance = "Performance";
        private const string FieldAllowEdit = "AllowEdit";
        private const string FieldEditDefault = "EditDefault";
        private const string FieldShowInsert = "ShowInsert";
        private const string FieldDisableNewItemMod = "DisableNewItemMod";
        private const string FieldUseNewMenu = "UseNewMenu";
        private const string FieldNewMenuName = "NewMenuName";
        private const string FieldUsePopup = "UsePopup";
        private const string FieldEnableRequests = "EnableRequests";
        private const string FieldEnableAutoCreation = "EnableAutoCreation";
        private const string FieldAutoCreationTemplateId = "AutoCreationTemplateId";
        private const string FieldWorkspaceParentSiteLookup = "WorkspaceParentSiteLookup";
        private const string FieldEnableWorkList = "EnableWorkList";
        private const string FieldEnableFancyForms = "EnableFancyForms";
        private const string FieldSendEmails = "SendEmails";
        private const string FieldDeleteRequest = "DeleteRequest";
        private const string FieldRequestList = "RequestList";
        private const string FieldUseParent = "UseParent";
        private const string FieldLookups = "Lookups";
        private const string FieldSearch = "Search";
        private const string FieldLockSearch = "LockSearch";
        private const string FieldAssociatedItems = "AssociatedItems";
        private const string FieldDisplayFormRedirect = "DisplayFormRedirect";
        private const string FieldListIcon = "ListIcon";
        private const string FieldDisplaySettings = "DisplaySettings";
        private const string FieldEnableResourcePlan = "EnableResourcePlan";
        private const string FieldTotalSettings = "TotalSettings";
        private const string FieldAllGeneral = "AllGeneral";
        private const string FieldBuildTeam = "BuildTeam";
        private const string FieldBuildTeamSecurity = "BuildTeamSecurity";
        private const string FieldBuildTeamPermissions = "BuildTeamPermissions";
        private const string FieldEnableContentReporting = "EnableContentReporting";
        private const string FieldDisableThumbnails = "DisableThumbnails";
        private Type _gridGanttSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridGanttSettings _gridGanttSettingsInstance;
        private GridGanttSettings _gridGanttSettingsInstanceFixture;

        #region General Initializer : Class (GridGanttSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridGanttSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridGanttSettingsInstanceType = typeof(GridGanttSettings);
            _gridGanttSettingsInstanceFixture = Create(true);
            _gridGanttSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridGanttSettings)

        #region General Initializer : Class (GridGanttSettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridGanttSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSaveSettings, 0)]
        [TestCase(MethodGetString, 0)]
        public void AUT_GridGanttSettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridGanttSettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridGanttSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridGanttSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldStartDate)]
        [TestCase(FieldDueDate)]
        [TestCase(FieldProgress)]
        [TestCase(FieldWBS)]
        [TestCase(FieldMilestone)]
        [TestCase(FieldExecutive)]
        [TestCase(FieldInformation)]
        [TestCase(FieldItemLink)]
        [TestCase(FieldRibbonBehavior)]
        [TestCase(FieldRollupLists)]
        [TestCase(FieldRollupSites)]
        [TestCase(FieldShowViewToolbar)]
        [TestCase(FieldHideNewButton)]
        [TestCase(FieldPerformance)]
        [TestCase(FieldAllowEdit)]
        [TestCase(FieldEditDefault)]
        [TestCase(FieldShowInsert)]
        [TestCase(FieldDisableNewItemMod)]
        [TestCase(FieldUseNewMenu)]
        [TestCase(FieldNewMenuName)]
        [TestCase(FieldUsePopup)]
        [TestCase(FieldEnableRequests)]
        [TestCase(FieldEnableAutoCreation)]
        [TestCase(FieldAutoCreationTemplateId)]
        [TestCase(FieldWorkspaceParentSiteLookup)]
        [TestCase(FieldEnableWorkList)]
        [TestCase(FieldEnableFancyForms)]
        [TestCase(FieldSendEmails)]
        [TestCase(FieldDeleteRequest)]
        [TestCase(FieldRequestList)]
        [TestCase(FieldUseParent)]
        [TestCase(FieldLookups)]
        [TestCase(FieldSearch)]
        [TestCase(FieldLockSearch)]
        [TestCase(FieldAssociatedItems)]
        [TestCase(FieldDisplayFormRedirect)]
        [TestCase(FieldListIcon)]
        [TestCase(FieldDisplaySettings)]
        [TestCase(FieldEnableResourcePlan)]
        [TestCase(FieldTotalSettings)]
        [TestCase(FieldAllGeneral)]
        [TestCase(FieldBuildTeam)]
        [TestCase(FieldBuildTeamSecurity)]
        [TestCase(FieldBuildTeamPermissions)]
        [TestCase(FieldEnableContentReporting)]
        [TestCase(FieldDisableThumbnails)]
        public void AUT_GridGanttSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridGanttSettingsInstanceFixture, 
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
        ///     Class (<see cref="GridGanttSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridGanttSettings_Is_Instance_Present_Test()
        {
            // Assert
            _gridGanttSettingsInstanceType.ShouldNotBeNull();
            _gridGanttSettingsInstance.ShouldNotBeNull();
            _gridGanttSettingsInstanceFixture.ShouldNotBeNull();
            _gridGanttSettingsInstance.ShouldBeAssignableTo<GridGanttSettings>();
            _gridGanttSettingsInstanceFixture.ShouldBeAssignableTo<GridGanttSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridGanttSettings) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridGanttSettings_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            GridGanttSettings instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GridGanttSettings(list);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _gridGanttSettingsInstance.ShouldNotBeNull();
            _gridGanttSettingsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<GridGanttSettings>();
        }

        #endregion

        #region General Constructor : Class (GridGanttSettings) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridGanttSettings_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            GridGanttSettings instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new GridGanttSettings(list);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _gridGanttSettingsInstance.ShouldNotBeNull();
            _gridGanttSettingsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridGanttSettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSaveSettings)]
        [TestCase(MethodGetString)]
        public void AUT_GridGanttSettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridGanttSettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridGanttSettings_SaveSettings_Method_Call_Internally(Type[] types)
        {
            var methodSaveSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodSaveSettings, Fixture, methodSaveSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var _list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridGanttSettingsInstance.SaveSettings(_list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var _list = CreateType<SPList>();
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveSettings = { _list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveSettings, methodSaveSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridGanttSettings, bool>(_gridGanttSettingsInstanceFixture, out exception1, parametersOfSaveSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridGanttSettings, bool>(_gridGanttSettingsInstance, MethodSaveSettings, parametersOfSaveSettings, methodSaveSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveSettings.ShouldNotBeNull();
            parametersOfSaveSettings.Length.ShouldBe(1);
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var _list = CreateType<SPList>();
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveSettings = { _list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveSettings, methodSaveSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridGanttSettings, bool>(_gridGanttSettingsInstanceFixture, out exception1, parametersOfSaveSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridGanttSettings, bool>(_gridGanttSettingsInstance, MethodSaveSettings, parametersOfSaveSettings, methodSaveSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveSettings.ShouldNotBeNull();
            parametersOfSaveSettings.Length.ShouldBe(1);
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var _list = CreateType<SPList>();
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveSettings = { _list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveSettings, methodSaveSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridGanttSettingsInstanceFixture, parametersOfSaveSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveSettings.ShouldNotBeNull();
            parametersOfSaveSettings.Length.ShouldBe(1);
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var _list = CreateType<SPList>();
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveSettings = { _list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridGanttSettings, bool>(_gridGanttSettingsInstance, MethodSaveSettings, parametersOfSaveSettings, methodSaveSettingsPrametersTypes);

            // Assert
            parametersOfSaveSettings.ShouldNotBeNull();
            parametersOfSaveSettings.Length.ShouldBe(1);
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodSaveSettings, Fixture, methodSaveSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodSaveSettings, Fixture, methodSaveSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveSettingsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodSaveSettings, Fixture, methodSaveSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridGanttSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SaveSettings) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_SaveSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridGanttSettings_GetString_Method_Call_Internally(Type[] types)
        {
            var methodGetStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_GetString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetStringPrametersTypes = null;
            object[] parametersOfGetString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetString, methodGetStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridGanttSettingsInstanceFixture, parametersOfGetString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetString.ShouldBeNull();
            methodGetStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_GetString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetStringPrametersTypes = null;
            object[] parametersOfGetString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridGanttSettings, string>(_gridGanttSettingsInstance, MethodGetString, parametersOfGetString, methodGetStringPrametersTypes);

            // Assert
            parametersOfGetString.ShouldBeNull();
            methodGetStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_GetString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_GetString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridGanttSettingsInstance, MethodGetString, Fixture, methodGetStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridGanttSettings_GetString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridGanttSettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}