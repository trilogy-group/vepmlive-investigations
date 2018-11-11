using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.myworksettings;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.myworksettings" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class MyworksettingsTest : AbstractBaseSetupTypedTest<myworksettings>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (myworksettings) Initializer

        private const string PropertyCurrentlySelectedLists = "CurrentlySelectedLists";
        private const string MethodGetMyWorkListsFromDb = "GetMyWorkListsFromDb";
        private const string MethodbtnAddField_OnClick = "btnAddField_OnClick";
        private const string MethodbtnExcludeList_OnClick = "btnExcludeList_OnClick";
        private const string MethodbtnIncludeList_OnClick = "btnIncludeList_OnClick";
        private const string MethodbtnRefreshField_OnClick = "btnRefreshField_OnClick";
        private const string MethodbtnRemoveField_OnClick = "btnRemoveField_OnClick";
        private const string MethodbtnReset_OnClick = "btnReset_OnClick";
        private const string MethodbtnSave_OnClick = "btnSave_OnClick";
        private const string MethodGvFields_RowDataBound = "GvFields_RowDataBound";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetListsAndFields = "GetListsAndFields";
        private const string MethodGetMyWorkListsAndFields = "GetMyWorkListsAndFields";
        private const string MethodIncludeFixApplied = "IncludeFixApplied";
        private const string MethodListMyWorkFields = "ListMyWorkFields";
        private const string MethodLoadGeneralSettings = "LoadGeneralSettings";
        private const string MethodMyWorkListExists = "MyWorkListExists";
        private const string MethodNewSetup = "NewSetup";
        private const string MethodSaveGeneralSettings = "SaveGeneralSettings";
        private const string MethodSetListsAndFields = "SetListsAndFields";
        private const string MethodDoesListExist = "DoesListExist";
        private const string FieldGENERAL_SETTINGS_WORK_DAY_FILTERS = "GENERAL_SETTINGS_WORK_DAY_FILTERS";
        private const string FieldGENERAL_SETTINGS_NEW_ITEM_INDICATOR = "GENERAL_SETTINGS_NEW_ITEM_INDICATOR";
        private const string FieldGeneralSettingsCrossSiteUrls = "GeneralSettingsCrossSiteUrls";
        private const string FieldGeneralSettingsExcludedMyWorkLists = "GeneralSettingsExcludedMyWorkLists";
        private const string FieldGeneralSettingsListsAndFields = "GeneralSettingsListsAndFields";
        private const string FieldGeneralSettingsMyWorkIncludeFixApplied = "GeneralSettingsMyWorkIncludeFixApplied";
        private const string FieldGeneralSettingsMyWorkListsAndFields = "GeneralSettingsMyWorkListsAndFields";
        private const string FieldGeneralSettingsPerformanceMode = "GeneralSettingsPerformanceMode";
        private const string FieldGeneralSettingsSelectedFields = "GeneralSettingsSelectedFields";
        private const string FieldGeneralSettingsSelectedLists = "GeneralSettingsSelectedLists";
        private const string FieldGeneralSettingsSelectedMyWorkLists = "GeneralSettingsSelectedMyWorkLists";
        private const string FieldMyWorkListServerTemplateId = "MyWorkListServerTemplateId";
        private const string Field_web = "_web";
        private const string FieldFieldLists = "FieldLists";
        private const string FieldListWorkspaces = "ListWorkspaces";
        private const string FieldMyWorkLists = "MyWorkLists";
        private Type _myworksettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private myworksettings _myworksettingsInstance;
        private myworksettings _myworksettingsInstanceFixture;

        #region General Initializer : Class (myworksettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="myworksettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myworksettingsInstanceType = typeof(myworksettings);
            _myworksettingsInstanceFixture = Create(true);
            _myworksettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (myworksettings)

        #region General Initializer : Class (myworksettings) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="myworksettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetMyWorkListsFromDb, 0)]
        [TestCase(MethodbtnAddField_OnClick, 0)]
        [TestCase(MethodbtnExcludeList_OnClick, 0)]
        [TestCase(MethodbtnIncludeList_OnClick, 0)]
        [TestCase(MethodbtnRefreshField_OnClick, 0)]
        [TestCase(MethodbtnRemoveField_OnClick, 0)]
        [TestCase(MethodbtnReset_OnClick, 0)]
        [TestCase(MethodbtnSave_OnClick, 0)]
        [TestCase(MethodGvFields_RowDataBound, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetListsAndFields, 0)]
        [TestCase(MethodGetMyWorkListsAndFields, 0)]
        [TestCase(MethodIncludeFixApplied, 0)]
        [TestCase(MethodListMyWorkFields, 0)]
        [TestCase(MethodLoadGeneralSettings, 0)]
        [TestCase(MethodMyWorkListExists, 0)]
        [TestCase(MethodNewSetup, 0)]
        [TestCase(MethodSaveGeneralSettings, 0)]
        [TestCase(MethodSetListsAndFields, 0)]
        [TestCase(MethodDoesListExist, 0)]
        public void AUT_Myworksettings_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myworksettingsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (myworksettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="myworksettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentlySelectedLists)]
        public void AUT_Myworksettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_myworksettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (myworksettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="myworksettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGENERAL_SETTINGS_WORK_DAY_FILTERS)]
        [TestCase(FieldGENERAL_SETTINGS_NEW_ITEM_INDICATOR)]
        [TestCase(FieldGeneralSettingsCrossSiteUrls)]
        [TestCase(FieldGeneralSettingsExcludedMyWorkLists)]
        [TestCase(FieldGeneralSettingsListsAndFields)]
        [TestCase(FieldGeneralSettingsMyWorkIncludeFixApplied)]
        [TestCase(FieldGeneralSettingsMyWorkListsAndFields)]
        [TestCase(FieldGeneralSettingsPerformanceMode)]
        [TestCase(FieldGeneralSettingsSelectedFields)]
        [TestCase(FieldGeneralSettingsSelectedLists)]
        [TestCase(FieldGeneralSettingsSelectedMyWorkLists)]
        [TestCase(FieldMyWorkListServerTemplateId)]
        [TestCase(Field_web)]
        [TestCase(FieldFieldLists)]
        [TestCase(FieldListWorkspaces)]
        [TestCase(FieldMyWorkLists)]
        public void AUT_Myworksettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_myworksettingsInstanceFixture, 
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
        ///     Class (<see cref="myworksettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Myworksettings_Is_Instance_Present_Test()
        {
            // Assert
            _myworksettingsInstanceType.ShouldNotBeNull();
            _myworksettingsInstance.ShouldNotBeNull();
            _myworksettingsInstanceFixture.ShouldNotBeNull();
            _myworksettingsInstance.ShouldBeAssignableTo<myworksettings>();
            _myworksettingsInstanceFixture.ShouldBeAssignableTo<myworksettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (myworksettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_myworksettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            myworksettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myworksettingsInstanceType.ShouldNotBeNull();
            _myworksettingsInstance.ShouldNotBeNull();
            _myworksettingsInstanceFixture.ShouldNotBeNull();
            _myworksettingsInstance.ShouldBeAssignableTo<myworksettings>();
            _myworksettingsInstanceFixture.ShouldBeAssignableTo<myworksettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (myworksettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertyCurrentlySelectedLists)]
        public void AUT_Myworksettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<myworksettings, T>(_myworksettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (myworksettings) => Property (CurrentlySelectedLists) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Myworksettings_CurrentlySelectedLists_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrentlySelectedLists);
            Action currentAction = () => propertyInfo.SetValue(_myworksettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (myworksettings) => Property (CurrentlySelectedLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Myworksettings_Public_Class_CurrentlySelectedLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentlySelectedLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="myworksettings" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetMyWorkListsFromDb)]
        public void AUT_Myworksettings_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_myworksettingsInstanceFixture,
                                                                              _myworksettingsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="myworksettings" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodbtnAddField_OnClick)]
        [TestCase(MethodbtnExcludeList_OnClick)]
        [TestCase(MethodbtnIncludeList_OnClick)]
        [TestCase(MethodbtnRefreshField_OnClick)]
        [TestCase(MethodbtnRemoveField_OnClick)]
        [TestCase(MethodbtnReset_OnClick)]
        [TestCase(MethodbtnSave_OnClick)]
        [TestCase(MethodGvFields_RowDataBound)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetListsAndFields)]
        [TestCase(MethodGetMyWorkListsAndFields)]
        [TestCase(MethodIncludeFixApplied)]
        [TestCase(MethodListMyWorkFields)]
        [TestCase(MethodLoadGeneralSettings)]
        [TestCase(MethodMyWorkListExists)]
        [TestCase(MethodNewSetup)]
        [TestCase(MethodSaveGeneralSettings)]
        [TestCase(MethodSetListsAndFields)]
        [TestCase(MethodDoesListExist)]
        public void AUT_Myworksettings_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<myworksettings>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkListsFromDbPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, Fixture, methodGetMyWorkListsFromDbPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            Action executeAction = null;

            // Act
            executeAction = () => myworksettings.GetMyWorkListsFromDb(web, archivedWebs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var methodGetMyWorkListsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>) };
            object[] parametersOfGetMyWorkListsFromDb = { web, archivedWebs };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListsFromDb, methodGetMyWorkListsFromDbPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, Fixture, methodGetMyWorkListsFromDbPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<MWList>>(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, parametersOfGetMyWorkListsFromDb, methodGetMyWorkListsFromDbPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfGetMyWorkListsFromDb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkListsFromDb.ShouldNotBeNull();
            parametersOfGetMyWorkListsFromDb.Length.ShouldBe(2);
            methodGetMyWorkListsFromDbPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var archivedWebs = CreateType<List<Guid>>();
            var methodGetMyWorkListsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>) };
            object[] parametersOfGetMyWorkListsFromDb = { web, archivedWebs };

            // Assert
            parametersOfGetMyWorkListsFromDb.ShouldNotBeNull();
            parametersOfGetMyWorkListsFromDb.Length.ShouldBe(2);
            methodGetMyWorkListsFromDbPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<MWList>>(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, parametersOfGetMyWorkListsFromDb, methodGetMyWorkListsFromDbPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyWorkListsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, Fixture, methodGetMyWorkListsFromDbPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkListsFromDbPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyWorkListsFromDbPrametersTypes = new Type[] { typeof(SPWeb), typeof(List<Guid>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myworksettingsInstanceFixture, _myworksettingsInstanceType, MethodGetMyWorkListsFromDb, Fixture, methodGetMyWorkListsFromDbPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkListsFromDbPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListsFromDb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListsFromDb) (Return Type : List<MWList>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsFromDb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyWorkListsFromDb, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnAddField_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnAddField_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnAddField_OnClick, Fixture, methodbtnAddField_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnAddField_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAddField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAddField_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnAddField_OnClick, methodbtnAddField_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnAddField_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnAddField_OnClick.ShouldNotBeNull();
            parametersOfbtnAddField_OnClick.Length.ShouldBe(2);
            methodbtnAddField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnAddField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnAddField_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnAddField_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnAddField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnAddField_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnAddField_OnClick, parametersOfbtnAddField_OnClick, methodbtnAddField_OnClickPrametersTypes);

            // Assert
            parametersOfbtnAddField_OnClick.ShouldNotBeNull();
            parametersOfbtnAddField_OnClick.Length.ShouldBe(2);
            methodbtnAddField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnAddField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnAddField_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnAddField_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnAddField_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnAddField_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnAddField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnAddField_OnClick, Fixture, methodbtnAddField_OnClickPrametersTypes);

            // Assert
            methodbtnAddField_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnAddField_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnAddField_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnAddField_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnExcludeList_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnExcludeList_OnClick, Fixture, methodbtnExcludeList_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnExcludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnExcludeList_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnExcludeList_OnClick, methodbtnExcludeList_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnExcludeList_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnExcludeList_OnClick.ShouldNotBeNull();
            parametersOfbtnExcludeList_OnClick.Length.ShouldBe(2);
            methodbtnExcludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnExcludeList_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnExcludeList_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnExcludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnExcludeList_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnExcludeList_OnClick, parametersOfbtnExcludeList_OnClick, methodbtnExcludeList_OnClickPrametersTypes);

            // Assert
            parametersOfbtnExcludeList_OnClick.ShouldNotBeNull();
            parametersOfbtnExcludeList_OnClick.Length.ShouldBe(2);
            methodbtnExcludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnExcludeList_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnExcludeList_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnExcludeList_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnExcludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnExcludeList_OnClick, Fixture, methodbtnExcludeList_OnClickPrametersTypes);

            // Assert
            methodbtnExcludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnExcludeList_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnExcludeList_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnExcludeList_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnIncludeList_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnIncludeList_OnClick, Fixture, methodbtnIncludeList_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnIncludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnIncludeList_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnIncludeList_OnClick, methodbtnIncludeList_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnIncludeList_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnIncludeList_OnClick.ShouldNotBeNull();
            parametersOfbtnIncludeList_OnClick.Length.ShouldBe(2);
            methodbtnIncludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnIncludeList_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnIncludeList_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnIncludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnIncludeList_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnIncludeList_OnClick, parametersOfbtnIncludeList_OnClick, methodbtnIncludeList_OnClickPrametersTypes);

            // Assert
            parametersOfbtnIncludeList_OnClick.ShouldNotBeNull();
            parametersOfbtnIncludeList_OnClick.Length.ShouldBe(2);
            methodbtnIncludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnIncludeList_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnIncludeList_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnIncludeList_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnIncludeList_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnIncludeList_OnClick, Fixture, methodbtnIncludeList_OnClickPrametersTypes);

            // Assert
            methodbtnIncludeList_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnIncludeList_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnIncludeList_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnIncludeList_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnRefreshField_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnRefreshField_OnClick, Fixture, methodbtnRefreshField_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefreshField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefreshField_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRefreshField_OnClick, methodbtnRefreshField_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnRefreshField_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRefreshField_OnClick.ShouldNotBeNull();
            parametersOfbtnRefreshField_OnClick.Length.ShouldBe(2);
            methodbtnRefreshField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefreshField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefreshField_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefreshField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefreshField_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnRefreshField_OnClick, parametersOfbtnRefreshField_OnClick, methodbtnRefreshField_OnClickPrametersTypes);

            // Assert
            parametersOfbtnRefreshField_OnClick.ShouldNotBeNull();
            parametersOfbtnRefreshField_OnClick.Length.ShouldBe(2);
            methodbtnRefreshField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefreshField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefreshField_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRefreshField_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRefreshField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnRefreshField_OnClick, Fixture, methodbtnRefreshField_OnClickPrametersTypes);

            // Assert
            methodbtnRefreshField_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefreshField_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRefreshField_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRefreshField_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnRemoveField_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnRemoveField_OnClick, Fixture, methodbtnRemoveField_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemoveField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemoveField_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRemoveField_OnClick, methodbtnRemoveField_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnRemoveField_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRemoveField_OnClick.ShouldNotBeNull();
            parametersOfbtnRemoveField_OnClick.Length.ShouldBe(2);
            methodbtnRemoveField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRemoveField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnRemoveField_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRemoveField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRemoveField_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnRemoveField_OnClick, parametersOfbtnRemoveField_OnClick, methodbtnRemoveField_OnClickPrametersTypes);

            // Assert
            parametersOfbtnRemoveField_OnClick.ShouldNotBeNull();
            parametersOfbtnRemoveField_OnClick.Length.ShouldBe(2);
            methodbtnRemoveField_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRemoveField_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnRemoveField_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRemoveField_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRemoveField_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnRemoveField_OnClick, Fixture, methodbtnRemoveField_OnClickPrametersTypes);

            // Assert
            methodbtnRemoveField_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRemoveField_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnRemoveField_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRemoveField_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnReset_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnReset_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnReset_OnClick, Fixture, methodbtnReset_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnReset_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnReset_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnReset_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnReset_OnClick, methodbtnReset_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnReset_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnReset_OnClick.ShouldNotBeNull();
            parametersOfbtnReset_OnClick.Length.ShouldBe(2);
            methodbtnReset_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnReset_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnReset_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnReset_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnReset_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnReset_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnReset_OnClick, parametersOfbtnReset_OnClick, methodbtnReset_OnClickPrametersTypes);

            // Assert
            parametersOfbtnReset_OnClick.ShouldNotBeNull();
            parametersOfbtnReset_OnClick.Length.ShouldBe(2);
            methodbtnReset_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnReset_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnReset_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnReset_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnReset_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnReset_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnReset_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnReset_OnClick, Fixture, methodbtnReset_OnClickPrametersTypes);

            // Assert
            methodbtnReset_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnReset_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnReset_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnReset_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_btnSave_OnClick_Method_Call_Internally(Type[] types)
        {
            var methodbtnSave_OnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnSave_OnClick, Fixture, methodbtnSave_OnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnSave_OnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSave_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSave_OnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnSave_OnClick, methodbtnSave_OnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfbtnSave_OnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnSave_OnClick.ShouldNotBeNull();
            parametersOfbtnSave_OnClick.Length.ShouldBe(2);
            methodbtnSave_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSave_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnSave_OnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnSave_OnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnSave_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnSave_OnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodbtnSave_OnClick, parametersOfbtnSave_OnClick, methodbtnSave_OnClickPrametersTypes);

            // Assert
            parametersOfbtnSave_OnClick.ShouldNotBeNull();
            parametersOfbtnSave_OnClick.Length.ShouldBe(2);
            methodbtnSave_OnClickPrametersTypes.Length.ShouldBe(2);
            methodbtnSave_OnClickPrametersTypes.Length.ShouldBe(parametersOfbtnSave_OnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnSave_OnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnSave_OnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnSave_OnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnSave_OnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodbtnSave_OnClick, Fixture, methodbtnSave_OnClickPrametersTypes);

            // Assert
            methodbtnSave_OnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnSave_OnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_btnSave_OnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnSave_OnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodGvFields_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGvFields_RowDataBound, Fixture, methodGvFields_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvFields_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, methodGvFields_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfGvFields_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGvFields_RowDataBound.ShouldNotBeNull();
            parametersOfGvFields_RowDataBound.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvFields_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<GridViewRowEventArgs>();
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };
            object[] parametersOfGvFields_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodGvFields_RowDataBound, parametersOfGvFields_RowDataBound, methodGvFields_RowDataBoundPrametersTypes);

            // Assert
            parametersOfGvFields_RowDataBound.ShouldNotBeNull();
            parametersOfGvFields_RowDataBound.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfGvFields_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGvFields_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGvFields_RowDataBound, Fixture, methodGvFields_RowDataBoundPrametersTypes);

            // Assert
            methodGvFields_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GvFields_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GvFields_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGvFields_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Myworksettings_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Myworksettings_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Myworksettings_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_GetListsAndFields_Method_Call_Internally(Type[] types)
        {
            var methodGetListsAndFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetListsAndFields, Fixture, methodGetListsAndFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetListsAndFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListsAndFieldsPrametersTypes = null;
            object[] parametersOfGetListsAndFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListsAndFields, methodGetListsAndFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstanceFixture, out exception1, parametersOfGetListsAndFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstance, MethodGetListsAndFields, parametersOfGetListsAndFields, methodGetListsAndFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListsAndFields.ShouldBeNull();
            methodGetListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfGetListsAndFields));
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetListsAndFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListsAndFieldsPrametersTypes = null;
            object[] parametersOfGetListsAndFields = null; // no parameter present

            // Assert
            parametersOfGetListsAndFields.ShouldBeNull();
            methodGetListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstance, MethodGetListsAndFields, parametersOfGetListsAndFields, methodGetListsAndFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetListsAndFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetListsAndFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetListsAndFields, Fixture, methodGetListsAndFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListsAndFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetListsAndFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListsAndFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetListsAndFields, Fixture, methodGetListsAndFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListsAndFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListsAndFields) (Return Type : Dictionary<string, List<string>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetListsAndFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListsAndFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_Internally(Type[] types)
        {
            var methodGetMyWorkListsAndFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetMyWorkListsAndFields, Fixture, methodGetMyWorkListsAndFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMyWorkListsAndFieldsPrametersTypes = null;
            object[] parametersOfGetMyWorkListsAndFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListsAndFields, methodGetMyWorkListsAndFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstanceFixture, out exception1, parametersOfGetMyWorkListsAndFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstance, MethodGetMyWorkListsAndFields, parametersOfGetMyWorkListsAndFields, methodGetMyWorkListsAndFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyWorkListsAndFields.ShouldBeNull();
            methodGetMyWorkListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfGetMyWorkListsAndFields));
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMyWorkListsAndFieldsPrametersTypes = null;
            object[] parametersOfGetMyWorkListsAndFields = null; // no parameter present

            // Assert
            parametersOfGetMyWorkListsAndFields.ShouldBeNull();
            methodGetMyWorkListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, Dictionary<string, List<string>>>(_myworksettingsInstance, MethodGetMyWorkListsAndFields, parametersOfGetMyWorkListsAndFields, methodGetMyWorkListsAndFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMyWorkListsAndFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetMyWorkListsAndFields, Fixture, methodGetMyWorkListsAndFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyWorkListsAndFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMyWorkListsAndFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodGetMyWorkListsAndFields, Fixture, methodGetMyWorkListsAndFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyWorkListsAndFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyWorkListsAndFields) (Return Type : Dictionary<string, List<string>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_GetMyWorkListsAndFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyWorkListsAndFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_IncludeFixApplied_Method_Call_Internally(Type[] types)
        {
            var methodIncludeFixAppliedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodIncludeFixApplied, Fixture, methodIncludeFixAppliedPrametersTypes);
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_IncludeFixApplied_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIncludeFixAppliedPrametersTypes = null;
            object[] parametersOfIncludeFixApplied = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIncludeFixApplied, methodIncludeFixAppliedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfIncludeFixApplied);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodIncludeFixApplied, parametersOfIncludeFixApplied, methodIncludeFixAppliedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIncludeFixApplied.ShouldBeNull();
            methodIncludeFixAppliedPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfIncludeFixApplied));
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_IncludeFixApplied_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIncludeFixAppliedPrametersTypes = null;
            object[] parametersOfIncludeFixApplied = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIncludeFixApplied, methodIncludeFixAppliedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfIncludeFixApplied);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodIncludeFixApplied, parametersOfIncludeFixApplied, methodIncludeFixAppliedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIncludeFixApplied.ShouldBeNull();
            methodIncludeFixAppliedPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodIncludeFixApplied, parametersOfIncludeFixApplied, methodIncludeFixAppliedPrametersTypes));
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_IncludeFixApplied_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIncludeFixAppliedPrametersTypes = null;
            object[] parametersOfIncludeFixApplied = null; // no parameter present

            // Assert
            parametersOfIncludeFixApplied.ShouldBeNull();
            methodIncludeFixAppliedPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodIncludeFixApplied, parametersOfIncludeFixApplied, methodIncludeFixAppliedPrametersTypes));
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_IncludeFixApplied_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIncludeFixAppliedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodIncludeFixApplied, Fixture, methodIncludeFixAppliedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIncludeFixAppliedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IncludeFixApplied) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_IncludeFixApplied_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIncludeFixApplied, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ListMyWorkFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_ListMyWorkFields_Method_Call_Internally(Type[] types)
        {
            var methodListMyWorkFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodListMyWorkFields, Fixture, methodListMyWorkFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ListMyWorkFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_ListMyWorkFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodListMyWorkFieldsPrametersTypes = null;
            object[] parametersOfListMyWorkFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListMyWorkFields, methodListMyWorkFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfListMyWorkFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListMyWorkFields.ShouldBeNull();
            methodListMyWorkFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ListMyWorkFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_ListMyWorkFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodListMyWorkFieldsPrametersTypes = null;
            object[] parametersOfListMyWorkFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodListMyWorkFields, parametersOfListMyWorkFields, methodListMyWorkFieldsPrametersTypes);

            // Assert
            parametersOfListMyWorkFields.ShouldBeNull();
            methodListMyWorkFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListMyWorkFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_ListMyWorkFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodListMyWorkFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodListMyWorkFields, Fixture, methodListMyWorkFieldsPrametersTypes);

            // Assert
            methodListMyWorkFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListMyWorkFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_ListMyWorkFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListMyWorkFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadGeneralSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_LoadGeneralSettings_Method_Call_Internally(Type[] types)
        {
            var methodLoadGeneralSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodLoadGeneralSettings, Fixture, methodLoadGeneralSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadGeneralSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_LoadGeneralSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadGeneralSettingsPrametersTypes = null;
            object[] parametersOfLoadGeneralSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadGeneralSettings, methodLoadGeneralSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfLoadGeneralSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadGeneralSettings.ShouldBeNull();
            methodLoadGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadGeneralSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_LoadGeneralSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadGeneralSettingsPrametersTypes = null;
            object[] parametersOfLoadGeneralSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodLoadGeneralSettings, parametersOfLoadGeneralSettings, methodLoadGeneralSettingsPrametersTypes);

            // Assert
            parametersOfLoadGeneralSettings.ShouldBeNull();
            methodLoadGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadGeneralSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_LoadGeneralSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadGeneralSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodLoadGeneralSettings, Fixture, methodLoadGeneralSettingsPrametersTypes);

            // Assert
            methodLoadGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadGeneralSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_LoadGeneralSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadGeneralSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_MyWorkListExists_Method_Call_Internally(Type[] types)
        {
            var methodMyWorkListExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodMyWorkListExists, Fixture, methodMyWorkListExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_MyWorkListExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodMyWorkListExistsPrametersTypes = null;
            object[] parametersOfMyWorkListExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMyWorkListExists, methodMyWorkListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfMyWorkListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodMyWorkListExists, parametersOfMyWorkListExists, methodMyWorkListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMyWorkListExists.ShouldBeNull();
            methodMyWorkListExistsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfMyWorkListExists));
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_MyWorkListExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodMyWorkListExistsPrametersTypes = null;
            object[] parametersOfMyWorkListExists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMyWorkListExists, methodMyWorkListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfMyWorkListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodMyWorkListExists, parametersOfMyWorkListExists, methodMyWorkListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMyWorkListExists.ShouldBeNull();
            methodMyWorkListExistsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodMyWorkListExists, parametersOfMyWorkListExists, methodMyWorkListExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_MyWorkListExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodMyWorkListExistsPrametersTypes = null;
            object[] parametersOfMyWorkListExists = null; // no parameter present

            // Assert
            parametersOfMyWorkListExists.ShouldBeNull();
            methodMyWorkListExistsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodMyWorkListExists, parametersOfMyWorkListExists, methodMyWorkListExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_MyWorkListExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodMyWorkListExistsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodMyWorkListExists, Fixture, methodMyWorkListExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMyWorkListExistsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MyWorkListExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_MyWorkListExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMyWorkListExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_NewSetup_Method_Call_Internally(Type[] types)
        {
            var methodNewSetupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodNewSetup, Fixture, methodNewSetupPrametersTypes);
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_NewSetup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodNewSetupPrametersTypes = null;
            object[] parametersOfNewSetup = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodNewSetup, methodNewSetupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfNewSetup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodNewSetup, parametersOfNewSetup, methodNewSetupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfNewSetup.ShouldBeNull();
            methodNewSetupPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfNewSetup));
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_NewSetup_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodNewSetupPrametersTypes = null;
            object[] parametersOfNewSetup = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodNewSetup, methodNewSetupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfNewSetup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodNewSetup, parametersOfNewSetup, methodNewSetupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfNewSetup.ShouldBeNull();
            methodNewSetupPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodNewSetup, parametersOfNewSetup, methodNewSetupPrametersTypes));
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_NewSetup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodNewSetupPrametersTypes = null;
            object[] parametersOfNewSetup = null; // no parameter present

            // Assert
            parametersOfNewSetup.ShouldBeNull();
            methodNewSetupPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodNewSetup, parametersOfNewSetup, methodNewSetupPrametersTypes));
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_NewSetup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodNewSetupPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodNewSetup, Fixture, methodNewSetupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodNewSetupPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (NewSetup) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_NewSetup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodNewSetup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveGeneralSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_SaveGeneralSettings_Method_Call_Internally(Type[] types)
        {
            var methodSaveGeneralSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodSaveGeneralSettings, Fixture, methodSaveGeneralSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveGeneralSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SaveGeneralSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSaveGeneralSettingsPrametersTypes = null;
            object[] parametersOfSaveGeneralSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveGeneralSettings, methodSaveGeneralSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfSaveGeneralSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveGeneralSettings.ShouldBeNull();
            methodSaveGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveGeneralSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SaveGeneralSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSaveGeneralSettingsPrametersTypes = null;
            object[] parametersOfSaveGeneralSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodSaveGeneralSettings, parametersOfSaveGeneralSettings, methodSaveGeneralSettingsPrametersTypes);

            // Assert
            parametersOfSaveGeneralSettings.ShouldBeNull();
            methodSaveGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGeneralSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SaveGeneralSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSaveGeneralSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodSaveGeneralSettings, Fixture, methodSaveGeneralSettingsPrametersTypes);

            // Assert
            methodSaveGeneralSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveGeneralSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SaveGeneralSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveGeneralSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListsAndFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_SetListsAndFields_Method_Call_Internally(Type[] types)
        {
            var methodSetListsAndFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodSetListsAndFields, Fixture, methodSetListsAndFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetListsAndFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SetListsAndFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetListsAndFieldsPrametersTypes = null;
            object[] parametersOfSetListsAndFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetListsAndFields, methodSetListsAndFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfSetListsAndFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetListsAndFields.ShouldBeNull();
            methodSetListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetListsAndFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SetListsAndFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetListsAndFieldsPrametersTypes = null;
            object[] parametersOfSetListsAndFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myworksettingsInstance, MethodSetListsAndFields, parametersOfSetListsAndFields, methodSetListsAndFieldsPrametersTypes);

            // Assert
            parametersOfSetListsAndFields.ShouldBeNull();
            methodSetListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListsAndFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SetListsAndFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetListsAndFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodSetListsAndFields, Fixture, methodSetListsAndFieldsPrametersTypes);

            // Assert
            methodSetListsAndFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetListsAndFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_SetListsAndFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetListsAndFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Myworksettings_DoesListExist_Method_Call_Internally(Type[] types)
        {
            var methodDoesListExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodDoesListExist, Fixture, methodDoesListExistPrametersTypes);
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDoesListExistPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoesListExist = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoesListExist, methodDoesListExistPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfDoesListExist);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodDoesListExist, parametersOfDoesListExist, methodDoesListExistPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoesListExist.ShouldNotBeNull();
            parametersOfDoesListExist.Length.ShouldBe(1);
            methodDoesListExistPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_myworksettingsInstanceFixture, parametersOfDoesListExist));
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDoesListExistPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoesListExist = { name };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoesListExist, methodDoesListExistPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<myworksettings, bool>(_myworksettingsInstanceFixture, out exception1, parametersOfDoesListExist);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodDoesListExist, parametersOfDoesListExist, methodDoesListExistPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoesListExist.ShouldNotBeNull();
            parametersOfDoesListExist.Length.ShouldBe(1);
            methodDoesListExistPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodDoesListExist, parametersOfDoesListExist, methodDoesListExistPrametersTypes));
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodDoesListExistPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoesListExist = { name };

            // Assert
            parametersOfDoesListExist.ShouldNotBeNull();
            parametersOfDoesListExist.Length.ShouldBe(1);
            methodDoesListExistPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<myworksettings, bool>(_myworksettingsInstance, MethodDoesListExist, parametersOfDoesListExist, methodDoesListExistPrametersTypes));
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoesListExistPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myworksettingsInstance, MethodDoesListExist, Fixture, methodDoesListExistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoesListExistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoesListExist, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myworksettingsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoesListExist) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Myworksettings_DoesListExist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoesListExist, 0);
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