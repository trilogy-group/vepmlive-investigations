using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.adsyncadmin" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class AdsyncadminTest : AbstractBaseSetupTypedTest<adsyncadmin>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (adsyncadmin) Initializer

        private const string MethodPage_Init = "Page_Init";
        private const string MethodbtnRunManually_Click = "btnRunManually_Click";
        private const string MethodLoadScheduleStatus = "LoadScheduleStatus";
        private const string MethodInitExclusions = "InitExclusions";
        private const string MethodInitDelete = "InitDelete";
        private const string MethodSaveAll = "SaveAll";
        private const string MethodFinalizeSave = "FinalizeSave";
        private const string MethodGetGroups = "GetGroups";
        private const string MethodGetFieldMappings = "GetFieldMappings";
        private const string MethodSaveJob = "SaveJob";
        private const string MethodGetEntityExclusions = "GetEntityExclusions";
        private const string MethodGetDelete = "GetDelete";
        private const string MethodGetOptions = "GetOptions";
        private const string MethodInitDomain = "InitDomain";
        private const string MethodInitSchedule = "InitSchedule";
        private const string MethodInitResourcePoolFields = "InitResourcePoolFields";
        private const string MethodInitSavedFieldMappings = "InitSavedFieldMappings";
        private const string MethodInitResourceField = "InitResourceField";
        private const string MethodADFields = "ADFields";
        private const string MethodInitGroups = "InitGroups";
        private const string MethodDropDownListScheduleType_SelectedIndexChanged = "DropDownListScheduleType_SelectedIndexChanged";
        private const string MethodSubmit_Click = "Submit_Click";
        private const string MethodPage_LoadComplete = "Page_LoadComplete";
        private const string MethodInitActiveDirectorySizeLimitTextBox = "InitActiveDirectorySizeLimitTextBox";
        private const string MethodGetActiveDirectorySizeLimit = "GetActiveDirectorySizeLimit";
        private const string Fieldlbl_domain = "lbl_domain";
        private const string FieldlblMessages = "lblMessages";
        private const string FieldlblLastRun = "lblLastRun";
        private const string Fieldlb_options = "lb_options";
        private const string Fieldlb_selections = "lb_selections";
        private const string Fieldselections = "selections";
        private const string Fieldpnl_fieldMappings = "pnl_fieldMappings";
        private const string Fieldtbl_fieldMappings = "tbl_fieldMappings";
        private const string FieldtxtArea_entityExclusions = "txtArea_entityExclusions";
        private const string FieldbtnRunManually = "btnRunManually";
        private const string FieldCheckBoxList_days = "CheckBoxList_days";
        private const string FieldcbDelete = "cbDelete";
        private const string FieldFrequencyOptions = "FrequencyOptions";
        private const string FieldFixTimes = "FixTimes";
        private const string FieldDropDownListScheduleType = "DropDownListScheduleType";
        private const string FieldDropDownListDays = "DropDownListDays";
        private const string FieldDropDownListTime = "DropDownListTime";
        private const string Field_adSavedGroups = "_adSavedGroups";
        private const string Field_domain = "_domain";
        private const string Field_resourcePoolFields = "_resourcePoolFields";
        private const string Field_adFields = "_adFields";
        private const string Field_groups = "_groups";
        private const string Field_ExecutionLogs = "_ExecutionLogs";
        private const string Field_SavedFieldMappings = "_SavedFieldMappings";
        private const string Field_ADSync = "_ADSync";
        private const string Field_htDropdownIds = "_htDropdownIds";
        private const string Field_SavedFieldMappingValues = "_SavedFieldMappingValues";
        private Type _adsyncadminInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private adsyncadmin _adsyncadminInstance;
        private adsyncadmin _adsyncadminInstanceFixture;

        #region General Initializer : Class (adsyncadmin) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="adsyncadmin" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adsyncadminInstanceType = typeof(adsyncadmin);
            _adsyncadminInstanceFixture = Create(true);
            _adsyncadminInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (adsyncadmin)

        #region General Initializer : Class (adsyncadmin) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="adsyncadmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Init, 0)]
        [TestCase(MethodbtnRunManually_Click, 0)]
        [TestCase(MethodLoadScheduleStatus, 0)]
        [TestCase(MethodInitExclusions, 0)]
        [TestCase(MethodInitDelete, 0)]
        [TestCase(MethodSaveAll, 0)]
        [TestCase(MethodFinalizeSave, 0)]
        [TestCase(MethodGetGroups, 0)]
        [TestCase(MethodGetFieldMappings, 0)]
        [TestCase(MethodSaveJob, 0)]
        [TestCase(MethodGetEntityExclusions, 0)]
        [TestCase(MethodGetDelete, 0)]
        [TestCase(MethodGetOptions, 0)]
        [TestCase(MethodInitDomain, 0)]
        [TestCase(MethodInitSchedule, 0)]
        [TestCase(MethodInitResourcePoolFields, 0)]
        [TestCase(MethodInitSavedFieldMappings, 0)]
        [TestCase(MethodInitResourceField, 0)]
        [TestCase(MethodADFields, 0)]
        [TestCase(MethodInitGroups, 0)]
        [TestCase(MethodDropDownListScheduleType_SelectedIndexChanged, 0)]
        [TestCase(MethodSubmit_Click, 0)]
        [TestCase(MethodPage_LoadComplete, 0)]
        [TestCase(MethodInitActiveDirectorySizeLimitTextBox, 0)]
        [TestCase(MethodGetActiveDirectorySizeLimit, 0)]
        public void AUT_Adsyncadmin_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adsyncadminInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (adsyncadmin) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="adsyncadmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldlbl_domain)]
        [TestCase(FieldlblMessages)]
        [TestCase(FieldlblLastRun)]
        [TestCase(Fieldlb_options)]
        [TestCase(Fieldlb_selections)]
        [TestCase(Fieldselections)]
        [TestCase(Fieldpnl_fieldMappings)]
        [TestCase(Fieldtbl_fieldMappings)]
        [TestCase(FieldtxtArea_entityExclusions)]
        [TestCase(FieldbtnRunManually)]
        [TestCase(FieldCheckBoxList_days)]
        [TestCase(FieldcbDelete)]
        [TestCase(FieldFrequencyOptions)]
        [TestCase(FieldFixTimes)]
        [TestCase(FieldDropDownListScheduleType)]
        [TestCase(FieldDropDownListDays)]
        [TestCase(FieldDropDownListTime)]
        [TestCase(Field_adSavedGroups)]
        [TestCase(Field_domain)]
        [TestCase(Field_resourcePoolFields)]
        [TestCase(Field_adFields)]
        [TestCase(Field_groups)]
        [TestCase(Field_ExecutionLogs)]
        [TestCase(Field_SavedFieldMappings)]
        [TestCase(Field_ADSync)]
        [TestCase(Field_htDropdownIds)]
        [TestCase(Field_SavedFieldMappingValues)]
        public void AUT_Adsyncadmin_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_adsyncadminInstanceFixture, 
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
        ///     Class (<see cref="adsyncadmin" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Adsyncadmin_Is_Instance_Present_Test()
        {
            // Assert
            _adsyncadminInstanceType.ShouldNotBeNull();
            _adsyncadminInstance.ShouldNotBeNull();
            _adsyncadminInstanceFixture.ShouldNotBeNull();
            _adsyncadminInstance.ShouldBeAssignableTo<adsyncadmin>();
            _adsyncadminInstanceFixture.ShouldBeAssignableTo<adsyncadmin>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (adsyncadmin) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_adsyncadmin_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            adsyncadmin instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _adsyncadminInstanceType.ShouldNotBeNull();
            _adsyncadminInstance.ShouldNotBeNull();
            _adsyncadminInstanceFixture.ShouldNotBeNull();
            _adsyncadminInstance.ShouldBeAssignableTo<adsyncadmin>();
            _adsyncadminInstanceFixture.ShouldBeAssignableTo<adsyncadmin>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="adsyncadmin" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Init)]
        [TestCase(MethodbtnRunManually_Click)]
        [TestCase(MethodLoadScheduleStatus)]
        [TestCase(MethodInitExclusions)]
        [TestCase(MethodInitDelete)]
        [TestCase(MethodSaveAll)]
        [TestCase(MethodFinalizeSave)]
        [TestCase(MethodGetGroups)]
        [TestCase(MethodGetFieldMappings)]
        [TestCase(MethodSaveJob)]
        [TestCase(MethodGetEntityExclusions)]
        [TestCase(MethodGetDelete)]
        [TestCase(MethodGetOptions)]
        [TestCase(MethodInitDomain)]
        [TestCase(MethodInitSchedule)]
        [TestCase(MethodInitResourcePoolFields)]
        [TestCase(MethodInitSavedFieldMappings)]
        [TestCase(MethodInitResourceField)]
        [TestCase(MethodADFields)]
        [TestCase(MethodInitGroups)]
        [TestCase(MethodDropDownListScheduleType_SelectedIndexChanged)]
        [TestCase(MethodSubmit_Click)]
        [TestCase(MethodPage_LoadComplete)]
        [TestCase(MethodInitActiveDirectorySizeLimitTextBox)]
        [TestCase(MethodGetActiveDirectorySizeLimit)]
        public void AUT_Adsyncadmin_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<adsyncadmin>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_Page_Init_Method_Call_Internally(Type[] types)
        {
            var methodPage_InitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_Init_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Init, methodPage_InitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfPage_Init);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_Init_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodPage_Init, parametersOfPage_Init, methodPage_InitPrametersTypes);

            // Assert
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);

            // Assert
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_Init_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRunManually_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodbtnRunManually_Click, Fixture, methodbtnRunManually_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRunManually_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRunManually_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRunManually_Click, methodbtnRunManually_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfbtnRunManually_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRunManually_Click.ShouldNotBeNull();
            parametersOfbtnRunManually_Click.Length.ShouldBe(2);
            methodbtnRunManually_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRunManually_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRunManually_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRunManually_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRunManually_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodbtnRunManually_Click, parametersOfbtnRunManually_Click, methodbtnRunManually_ClickPrametersTypes);

            // Assert
            parametersOfbtnRunManually_Click.ShouldNotBeNull();
            parametersOfbtnRunManually_Click.Length.ShouldBe(2);
            methodbtnRunManually_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRunManually_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRunManually_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRunManually_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRunManually_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodbtnRunManually_Click, Fixture, methodbtnRunManually_ClickPrametersTypes);

            // Assert
            methodbtnRunManually_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRunManually_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_btnRunManually_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRunManually_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScheduleStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_LoadScheduleStatus_Method_Call_Internally(Type[] types)
        {
            var methodLoadScheduleStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodLoadScheduleStatus, Fixture, methodLoadScheduleStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadScheduleStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_LoadScheduleStatus_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadScheduleStatusPrametersTypes = null;
            object[] parametersOfLoadScheduleStatus = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadScheduleStatus, methodLoadScheduleStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfLoadScheduleStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadScheduleStatus.ShouldBeNull();
            methodLoadScheduleStatusPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadScheduleStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_LoadScheduleStatus_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadScheduleStatusPrametersTypes = null;
            object[] parametersOfLoadScheduleStatus = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodLoadScheduleStatus, parametersOfLoadScheduleStatus, methodLoadScheduleStatusPrametersTypes);

            // Assert
            parametersOfLoadScheduleStatus.ShouldBeNull();
            methodLoadScheduleStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScheduleStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_LoadScheduleStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadScheduleStatusPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodLoadScheduleStatus, Fixture, methodLoadScheduleStatusPrametersTypes);

            // Assert
            methodLoadScheduleStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScheduleStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_LoadScheduleStatus_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadScheduleStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitExclusions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitExclusions_Method_Call_Internally(Type[] types)
        {
            var methodInitExclusionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitExclusions, Fixture, methodInitExclusionsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitExclusions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitExclusions_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitExclusionsPrametersTypes = null;
            object[] parametersOfInitExclusions = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitExclusions, methodInitExclusionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitExclusions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitExclusions.ShouldBeNull();
            methodInitExclusionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitExclusions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitExclusions_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitExclusionsPrametersTypes = null;
            object[] parametersOfInitExclusions = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitExclusions, parametersOfInitExclusions, methodInitExclusionsPrametersTypes);

            // Assert
            parametersOfInitExclusions.ShouldBeNull();
            methodInitExclusionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitExclusions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitExclusions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitExclusionsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitExclusions, Fixture, methodInitExclusionsPrametersTypes);

            // Assert
            methodInitExclusionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitExclusions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitExclusions_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitExclusions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitDelete_Method_Call_Internally(Type[] types)
        {
            var methodInitDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitDelete, Fixture, methodInitDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (InitDelete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDelete_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitDeletePrametersTypes = null;
            object[] parametersOfInitDelete = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitDelete, methodInitDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitDelete.ShouldBeNull();
            methodInitDeletePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitDelete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDelete_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitDeletePrametersTypes = null;
            object[] parametersOfInitDelete = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitDelete, parametersOfInitDelete, methodInitDeletePrametersTypes);

            // Assert
            parametersOfInitDelete.ShouldBeNull();
            methodInitDeletePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitDelete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDelete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitDeletePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitDelete, Fixture, methodInitDeletePrametersTypes);

            // Assert
            methodInitDeletePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitDelete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDelete_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitDelete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_SaveAll_Method_Call_Internally(Type[] types)
        {
            var methodSaveAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveAll_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSaveAllPrametersTypes = null;
            object[] parametersOfSaveAll = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveAll, methodSaveAllPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfSaveAll);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveAll.ShouldBeNull();
            methodSaveAllPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveAll_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSaveAllPrametersTypes = null;
            object[] parametersOfSaveAll = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodSaveAll, parametersOfSaveAll, methodSaveAllPrametersTypes);

            // Assert
            parametersOfSaveAll.ShouldBeNull();
            methodSaveAllPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveAll_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSaveAllPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSaveAll, Fixture, methodSaveAllPrametersTypes);

            // Assert
            methodSaveAllPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveAll) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveAll_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveAll, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_FinalizeSave_Method_Call_Internally(Type[] types)
        {
            var methodFinalizeSavePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodFinalizeSave, Fixture, methodFinalizeSavePrametersTypes);
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var groups = CreateType<string>();
            var fieldmappings = CreateType<string>();
            var entityExclusions = CreateType<string>();
            var delete = CreateType<string>();
            var days = CreateType<string>();
            var scheduleType = CreateType<int>();
            var time = CreateType<int>();
            var sizeLimit = CreateType<int>();
            var methodFinalizeSavePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(int) };
            object[] parametersOfFinalizeSave = { groups, fieldmappings, entityExclusions, delete, days, scheduleType, time, sizeLimit };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFinalizeSave, methodFinalizeSavePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, bool>(_adsyncadminInstanceFixture, out exception1, parametersOfFinalizeSave);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodFinalizeSave, parametersOfFinalizeSave, methodFinalizeSavePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFinalizeSave.ShouldNotBeNull();
            parametersOfFinalizeSave.Length.ShouldBe(8);
            methodFinalizeSavePrametersTypes.Length.ShouldBe(8);
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfFinalizeSave));
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var groups = CreateType<string>();
            var fieldmappings = CreateType<string>();
            var entityExclusions = CreateType<string>();
            var delete = CreateType<string>();
            var days = CreateType<string>();
            var scheduleType = CreateType<int>();
            var time = CreateType<int>();
            var sizeLimit = CreateType<int>();
            var methodFinalizeSavePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(int) };
            object[] parametersOfFinalizeSave = { groups, fieldmappings, entityExclusions, delete, days, scheduleType, time, sizeLimit };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFinalizeSave, methodFinalizeSavePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, bool>(_adsyncadminInstanceFixture, out exception1, parametersOfFinalizeSave);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodFinalizeSave, parametersOfFinalizeSave, methodFinalizeSavePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFinalizeSave.ShouldNotBeNull();
            parametersOfFinalizeSave.Length.ShouldBe(8);
            methodFinalizeSavePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodFinalizeSave, parametersOfFinalizeSave, methodFinalizeSavePrametersTypes));
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groups = CreateType<string>();
            var fieldmappings = CreateType<string>();
            var entityExclusions = CreateType<string>();
            var delete = CreateType<string>();
            var days = CreateType<string>();
            var scheduleType = CreateType<int>();
            var time = CreateType<int>();
            var sizeLimit = CreateType<int>();
            var methodFinalizeSavePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(int) };
            object[] parametersOfFinalizeSave = { groups, fieldmappings, entityExclusions, delete, days, scheduleType, time, sizeLimit };

            // Assert
            parametersOfFinalizeSave.ShouldNotBeNull();
            parametersOfFinalizeSave.Length.ShouldBe(8);
            methodFinalizeSavePrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodFinalizeSave, parametersOfFinalizeSave, methodFinalizeSavePrametersTypes));
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFinalizeSavePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(int), typeof(int), typeof(int) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodFinalizeSave, Fixture, methodFinalizeSavePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFinalizeSavePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFinalizeSave, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FinalizeSave) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_FinalizeSave_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFinalizeSave, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetGroups_Method_Call_Internally(Type[] types)
        {
            var methodGetGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetGroups_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            object[] parametersOfGetGroups = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGroups, methodGetGroupsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, string>(_adsyncadminInstanceFixture, out exception1, parametersOfGetGroups);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetGroups, parametersOfGetGroups, methodGetGroupsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGroups.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfGetGroups));
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            object[] parametersOfGetGroups = null; // no parameter present

            // Assert
            parametersOfGetGroups.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetGroups, parametersOfGetGroups, methodGetGroupsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldMappings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetFieldMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetFieldMappings, Fixture, methodGetFieldMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldMappings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetFieldMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFieldMappingsPrametersTypes = null;
            object[] parametersOfGetFieldMappings = null; // no parameter present

            // Assert
            parametersOfGetFieldMappings.ShouldBeNull();
            methodGetFieldMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetFieldMappings, parametersOfGetFieldMappings, methodGetFieldMappingsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldMappings) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetFieldMappings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetFieldMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetFieldMappings, Fixture, methodGetFieldMappingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFieldMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldMappings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetFieldMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFieldMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetFieldMappings, Fixture, methodGetFieldMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (SaveJob) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_SaveJob_Method_Call_Internally(Type[] types)
        {
            var methodSaveJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSaveJob, Fixture, methodSaveJobPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var time = CreateType<int>();
            var scheduleType = CreateType<int>();
            var days = CreateType<string>();
            var methodSaveJobPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfSaveJob = { time, scheduleType, days };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveJob, methodSaveJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, bool>(_adsyncadminInstanceFixture, out exception1, parametersOfSaveJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodSaveJob, parametersOfSaveJob, methodSaveJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveJob.ShouldNotBeNull();
            parametersOfSaveJob.Length.ShouldBe(3);
            methodSaveJobPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfSaveJob));
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var time = CreateType<int>();
            var scheduleType = CreateType<int>();
            var days = CreateType<string>();
            var methodSaveJobPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfSaveJob = { time, scheduleType, days };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveJob, methodSaveJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, bool>(_adsyncadminInstanceFixture, out exception1, parametersOfSaveJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodSaveJob, parametersOfSaveJob, methodSaveJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveJob.ShouldNotBeNull();
            parametersOfSaveJob.Length.ShouldBe(3);
            methodSaveJobPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodSaveJob, parametersOfSaveJob, methodSaveJobPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var time = CreateType<int>();
            var scheduleType = CreateType<int>();
            var days = CreateType<string>();
            var methodSaveJobPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfSaveJob = { time, scheduleType, days };

            // Assert
            parametersOfSaveJob.ShouldNotBeNull();
            parametersOfSaveJob.Length.ShouldBe(3);
            methodSaveJobPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, bool>(_adsyncadminInstance, MethodSaveJob, parametersOfSaveJob, methodSaveJobPrametersTypes));
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveJobPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSaveJob, Fixture, methodSaveJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveJob) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_SaveJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveJob, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_Internally(Type[] types)
        {
            var methodGetEntityExclusionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetEntityExclusions, Fixture, methodGetEntityExclusionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetEntityExclusionsPrametersTypes = null;
            object[] parametersOfGetEntityExclusions = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEntityExclusions, methodGetEntityExclusionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, string>(_adsyncadminInstanceFixture, out exception1, parametersOfGetEntityExclusions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetEntityExclusions, parametersOfGetEntityExclusions, methodGetEntityExclusionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetEntityExclusions.ShouldBeNull();
            methodGetEntityExclusionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfGetEntityExclusions));
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEntityExclusionsPrametersTypes = null;
            object[] parametersOfGetEntityExclusions = null; // no parameter present

            // Assert
            parametersOfGetEntityExclusions.ShouldBeNull();
            methodGetEntityExclusionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetEntityExclusions, parametersOfGetEntityExclusions, methodGetEntityExclusionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetEntityExclusionsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetEntityExclusions, Fixture, methodGetEntityExclusionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEntityExclusionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEntityExclusionsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetEntityExclusions, Fixture, methodGetEntityExclusionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEntityExclusionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEntityExclusions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetEntityExclusions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEntityExclusions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetDelete_Method_Call_Internally(Type[] types)
        {
            var methodGetDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetDelete, Fixture, methodGetDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetDelete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeletePrametersTypes = null;
            object[] parametersOfGetDelete = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDelete, methodGetDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, string>(_adsyncadminInstanceFixture, out exception1, parametersOfGetDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetDelete, parametersOfGetDelete, methodGetDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDelete.ShouldBeNull();
            methodGetDeletePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfGetDelete));
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetDelete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDeletePrametersTypes = null;
            object[] parametersOfGetDelete = null; // no parameter present

            // Assert
            parametersOfGetDelete.ShouldBeNull();
            methodGetDeletePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetDelete, parametersOfGetDelete, methodGetDeletePrametersTypes));
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetDelete_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeletePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetDelete, Fixture, methodGetDeletePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDeletePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetDelete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDeletePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetDelete, Fixture, methodGetDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDeletePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDelete) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetDelete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetOptions_Method_Call_Internally(Type[] types)
        {
            var methodGetOptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetOptions, Fixture, methodGetOptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetOptions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetOptionsPrametersTypes = null;
            object[] parametersOfGetOptions = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptions, methodGetOptionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, string>(_adsyncadminInstanceFixture, out exception1, parametersOfGetOptions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetOptions, parametersOfGetOptions, methodGetOptionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetOptions.ShouldBeNull();
            methodGetOptionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfGetOptions));
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetOptions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetOptionsPrametersTypes = null;
            object[] parametersOfGetOptions = null; // no parameter present

            // Assert
            parametersOfGetOptions.ShouldBeNull();
            methodGetOptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, string>(_adsyncadminInstance, MethodGetOptions, parametersOfGetOptions, methodGetOptionsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetOptions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetOptionsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetOptions, Fixture, methodGetOptionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetOptionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetOptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetOptionsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetOptions, Fixture, methodGetOptionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetOptions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InitDomain) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitDomain_Method_Call_Internally(Type[] types)
        {
            var methodInitDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitDomain, Fixture, methodInitDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (InitDomain) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDomain_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitDomainPrametersTypes = null;
            object[] parametersOfInitDomain = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitDomain, methodInitDomainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitDomain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitDomain.ShouldBeNull();
            methodInitDomainPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitDomain) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDomain_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitDomainPrametersTypes = null;
            object[] parametersOfInitDomain = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitDomain, parametersOfInitDomain, methodInitDomainPrametersTypes);

            // Assert
            parametersOfInitDomain.ShouldBeNull();
            methodInitDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitDomain) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDomain_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitDomainPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitDomain, Fixture, methodInitDomainPrametersTypes);

            // Assert
            methodInitDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitDomain) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitDomain_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitDomain, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSchedule) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitSchedule_Method_Call_Internally(Type[] types)
        {
            var methodInitSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitSchedule, Fixture, methodInitSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (InitSchedule) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSchedule_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitSchedulePrametersTypes = null;
            object[] parametersOfInitSchedule = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitSchedule, methodInitSchedulePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitSchedule);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitSchedule.ShouldBeNull();
            methodInitSchedulePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitSchedule) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSchedule_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitSchedulePrametersTypes = null;
            object[] parametersOfInitSchedule = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitSchedule, parametersOfInitSchedule, methodInitSchedulePrametersTypes);

            // Assert
            parametersOfInitSchedule.ShouldBeNull();
            methodInitSchedulePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSchedule) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitSchedulePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitSchedule, Fixture, methodInitSchedulePrametersTypes);

            // Assert
            methodInitSchedulePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSchedule) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSchedule_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitSchedule, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourcePoolFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitResourcePoolFields_Method_Call_Internally(Type[] types)
        {
            var methodInitResourcePoolFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitResourcePoolFields, Fixture, methodInitResourcePoolFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitResourcePoolFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourcePoolFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitResourcePoolFieldsPrametersTypes = null;
            object[] parametersOfInitResourcePoolFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitResourcePoolFields, methodInitResourcePoolFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitResourcePoolFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitResourcePoolFields.ShouldBeNull();
            methodInitResourcePoolFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitResourcePoolFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourcePoolFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitResourcePoolFieldsPrametersTypes = null;
            object[] parametersOfInitResourcePoolFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitResourcePoolFields, parametersOfInitResourcePoolFields, methodInitResourcePoolFieldsPrametersTypes);

            // Assert
            parametersOfInitResourcePoolFields.ShouldBeNull();
            methodInitResourcePoolFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourcePoolFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourcePoolFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitResourcePoolFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitResourcePoolFields, Fixture, methodInitResourcePoolFieldsPrametersTypes);

            // Assert
            methodInitResourcePoolFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourcePoolFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourcePoolFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitResourcePoolFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_Internally(Type[] types)
        {
            var methodInitSavedFieldMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitSavedFieldMappings, Fixture, methodInitSavedFieldMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldmappings = CreateType<string>();
            var methodInitSavedFieldMappingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitSavedFieldMappings = { fieldmappings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitSavedFieldMappings, methodInitSavedFieldMappingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitSavedFieldMappings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitSavedFieldMappings.ShouldNotBeNull();
            parametersOfInitSavedFieldMappings.Length.ShouldBe(1);
            methodInitSavedFieldMappingsPrametersTypes.Length.ShouldBe(1);
            methodInitSavedFieldMappingsPrametersTypes.Length.ShouldBe(parametersOfInitSavedFieldMappings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldmappings = CreateType<string>();
            var methodInitSavedFieldMappingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitSavedFieldMappings = { fieldmappings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitSavedFieldMappings, parametersOfInitSavedFieldMappings, methodInitSavedFieldMappingsPrametersTypes);

            // Assert
            parametersOfInitSavedFieldMappings.ShouldNotBeNull();
            parametersOfInitSavedFieldMappings.Length.ShouldBe(1);
            methodInitSavedFieldMappingsPrametersTypes.Length.ShouldBe(1);
            methodInitSavedFieldMappingsPrametersTypes.Length.ShouldBe(parametersOfInitSavedFieldMappings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitSavedFieldMappings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitSavedFieldMappingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitSavedFieldMappings, Fixture, methodInitSavedFieldMappingsPrametersTypes);

            // Assert
            methodInitSavedFieldMappingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitSavedFieldMappings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitSavedFieldMappings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitSavedFieldMappings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitResourceField_Method_Call_Internally(Type[] types)
        {
            var methodInitResourceFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitResourceField, Fixture, methodInitResourceFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourceField_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var methodInitResourceFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitResourceField = { fieldname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitResourceField, methodInitResourceFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitResourceField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitResourceField.ShouldNotBeNull();
            parametersOfInitResourceField.Length.ShouldBe(1);
            methodInitResourceFieldPrametersTypes.Length.ShouldBe(1);
            methodInitResourceFieldPrametersTypes.Length.ShouldBe(parametersOfInitResourceField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourceField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var methodInitResourceFieldPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInitResourceField = { fieldname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitResourceField, parametersOfInitResourceField, methodInitResourceFieldPrametersTypes);

            // Assert
            parametersOfInitResourceField.ShouldNotBeNull();
            parametersOfInitResourceField.Length.ShouldBe(1);
            methodInitResourceFieldPrametersTypes.Length.ShouldBe(1);
            methodInitResourceFieldPrametersTypes.Length.ShouldBe(parametersOfInitResourceField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourceField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitResourceField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourceField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitResourceFieldPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitResourceField, Fixture, methodInitResourceFieldPrametersTypes);

            // Assert
            methodInitResourceFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitResourceField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitResourceField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitResourceField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_ADFields_Method_Call_Internally(Type[] types)
        {
            var methodADFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodADFields, Fixture, methodADFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var methodADFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfADFields = { fieldname };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodADFields, methodADFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, DropDownList>(_adsyncadminInstanceFixture, out exception1, parametersOfADFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, DropDownList>(_adsyncadminInstance, MethodADFields, parametersOfADFields, methodADFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfADFields.ShouldNotBeNull();
            parametersOfADFields.Length.ShouldBe(1);
            methodADFieldsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfADFields));
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldname = CreateType<string>();
            var methodADFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfADFields = { fieldname };

            // Assert
            parametersOfADFields.ShouldNotBeNull();
            parametersOfADFields.Length.ShouldBe(1);
            methodADFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, DropDownList>(_adsyncadminInstance, MethodADFields, parametersOfADFields, methodADFieldsPrametersTypes));
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodADFieldsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodADFields, Fixture, methodADFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodADFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodADFieldsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodADFields, Fixture, methodADFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodADFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodADFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ADFields) (Return Type : DropDownList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_ADFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodADFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitGroups) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitGroups_Method_Call_Internally(Type[] types)
        {
            var methodInitGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitGroups, Fixture, methodInitGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitGroups) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitGroups_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitGroupsPrametersTypes = null;
            object[] parametersOfInitGroups = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitGroups, methodInitGroupsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitGroups);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitGroups.ShouldBeNull();
            methodInitGroupsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitGroups) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitGroups_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitGroupsPrametersTypes = null;
            object[] parametersOfInitGroups = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitGroups, parametersOfInitGroups, methodInitGroupsPrametersTypes);

            // Assert
            parametersOfInitGroups.ShouldBeNull();
            methodInitGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGroups) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitGroupsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitGroups, Fixture, methodInitGroupsPrametersTypes);

            // Assert
            methodInitGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitGroups) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitGroups_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitGroups, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodDropDownListScheduleType_SelectedIndexChanged, Fixture, methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDropDownListScheduleType_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDropDownListScheduleType_SelectedIndexChanged, methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfDropDownListScheduleType_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDropDownListScheduleType_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfDropDownListScheduleType_SelectedIndexChanged.Length.ShouldBe(2);
            methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfDropDownListScheduleType_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfDropDownListScheduleType_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodDropDownListScheduleType_SelectedIndexChanged, parametersOfDropDownListScheduleType_SelectedIndexChanged, methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfDropDownListScheduleType_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfDropDownListScheduleType_SelectedIndexChanged.Length.ShouldBe(2);
            methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfDropDownListScheduleType_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDropDownListScheduleType_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodDropDownListScheduleType_SelectedIndexChanged, Fixture, methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes);

            // Assert
            methodDropDownListScheduleType_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DropDownListScheduleType_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_DropDownListScheduleType_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDropDownListScheduleType_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_Submit_Click_Method_Call_Internally(Type[] types)
        {
            var methodSubmit_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSubmit_Click, Fixture, methodSubmit_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Submit_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSubmit_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSubmit_Click, methodSubmit_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfSubmit_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSubmit_Click.ShouldNotBeNull();
            parametersOfSubmit_Click.Length.ShouldBe(2);
            methodSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfSubmit_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Submit_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSubmit_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodSubmit_Click, parametersOfSubmit_Click, methodSubmit_ClickPrametersTypes);

            // Assert
            parametersOfSubmit_Click.ShouldNotBeNull();
            parametersOfSubmit_Click.Length.ShouldBe(2);
            methodSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            methodSubmit_ClickPrametersTypes.Length.ShouldBe(parametersOfSubmit_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Submit_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSubmit_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Submit_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSubmit_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodSubmit_Click, Fixture, methodSubmit_ClickPrametersTypes);

            // Assert
            methodSubmit_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Submit_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Submit_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSubmit_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadCompletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodPage_LoadComplete, Fixture, methodPage_LoadCompletePrametersTypes);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadCompletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_LoadComplete = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_LoadComplete, methodPage_LoadCompletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfPage_LoadComplete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_LoadComplete.ShouldNotBeNull();
            parametersOfPage_LoadComplete.Length.ShouldBe(2);
            methodPage_LoadCompletePrametersTypes.Length.ShouldBe(2);
            methodPage_LoadCompletePrametersTypes.Length.ShouldBe(parametersOfPage_LoadComplete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadCompletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_LoadComplete = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodPage_LoadComplete, parametersOfPage_LoadComplete, methodPage_LoadCompletePrametersTypes);

            // Assert
            parametersOfPage_LoadComplete.ShouldNotBeNull();
            parametersOfPage_LoadComplete.Length.ShouldBe(2);
            methodPage_LoadCompletePrametersTypes.Length.ShouldBe(2);
            methodPage_LoadCompletePrametersTypes.Length.ShouldBe(parametersOfPage_LoadComplete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_LoadComplete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadCompletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodPage_LoadComplete, Fixture, methodPage_LoadCompletePrametersTypes);

            // Assert
            methodPage_LoadCompletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_LoadComplete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_Page_LoadComplete_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_LoadComplete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitActiveDirectorySizeLimitTextBox) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_InitActiveDirectorySizeLimitTextBox_Method_Call_Internally(Type[] types)
        {
            var methodInitActiveDirectorySizeLimitTextBoxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitActiveDirectorySizeLimitTextBox, Fixture, methodInitActiveDirectorySizeLimitTextBoxPrametersTypes);
        }

        #endregion

        #region Method Call : (InitActiveDirectorySizeLimitTextBox) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitActiveDirectorySizeLimitTextBox_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitActiveDirectorySizeLimitTextBoxPrametersTypes = null;
            object[] parametersOfInitActiveDirectorySizeLimitTextBox = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitActiveDirectorySizeLimitTextBox, methodInitActiveDirectorySizeLimitTextBoxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfInitActiveDirectorySizeLimitTextBox);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitActiveDirectorySizeLimitTextBox.ShouldBeNull();
            methodInitActiveDirectorySizeLimitTextBoxPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitActiveDirectorySizeLimitTextBox) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitActiveDirectorySizeLimitTextBox_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitActiveDirectorySizeLimitTextBoxPrametersTypes = null;
            object[] parametersOfInitActiveDirectorySizeLimitTextBox = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_adsyncadminInstance, MethodInitActiveDirectorySizeLimitTextBox, parametersOfInitActiveDirectorySizeLimitTextBox, methodInitActiveDirectorySizeLimitTextBoxPrametersTypes);

            // Assert
            parametersOfInitActiveDirectorySizeLimitTextBox.ShouldBeNull();
            methodInitActiveDirectorySizeLimitTextBoxPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitActiveDirectorySizeLimitTextBox) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitActiveDirectorySizeLimitTextBox_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitActiveDirectorySizeLimitTextBoxPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodInitActiveDirectorySizeLimitTextBox, Fixture, methodInitActiveDirectorySizeLimitTextBoxPrametersTypes);

            // Assert
            methodInitActiveDirectorySizeLimitTextBoxPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitActiveDirectorySizeLimitTextBox) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_InitActiveDirectorySizeLimitTextBox_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitActiveDirectorySizeLimitTextBox, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_Internally(Type[] types)
        {
            var methodGetActiveDirectorySizeLimitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, Fixture, methodGetActiveDirectorySizeLimitPrametersTypes);
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;
            object[] parametersOfGetActiveDirectorySizeLimit = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetActiveDirectorySizeLimit, methodGetActiveDirectorySizeLimitPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<adsyncadmin, int>(_adsyncadminInstanceFixture, out exception1, parametersOfGetActiveDirectorySizeLimit);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, int>(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, parametersOfGetActiveDirectorySizeLimit, methodGetActiveDirectorySizeLimitPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetActiveDirectorySizeLimit.ShouldBeNull();
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, int>(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, parametersOfGetActiveDirectorySizeLimit, methodGetActiveDirectorySizeLimitPrametersTypes));
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;
            object[] parametersOfGetActiveDirectorySizeLimit = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetActiveDirectorySizeLimit, methodGetActiveDirectorySizeLimitPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetActiveDirectorySizeLimit.ShouldBeNull();
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_adsyncadminInstanceFixture, parametersOfGetActiveDirectorySizeLimit));
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;
            object[] parametersOfGetActiveDirectorySizeLimit = null; // no parameter present

            // Assert
            parametersOfGetActiveDirectorySizeLimit.ShouldBeNull();
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<adsyncadmin, int>(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, parametersOfGetActiveDirectorySizeLimit, methodGetActiveDirectorySizeLimitPrametersTypes));
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, Fixture, methodGetActiveDirectorySizeLimitPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, Fixture, methodGetActiveDirectorySizeLimitPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetActiveDirectorySizeLimitPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adsyncadminInstance, MethodGetActiveDirectorySizeLimit, Fixture, methodGetActiveDirectorySizeLimitPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetActiveDirectorySizeLimitPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActiveDirectorySizeLimit) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Adsyncadmin_GetActiveDirectorySizeLimit_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetActiveDirectorySizeLimit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_adsyncadminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}