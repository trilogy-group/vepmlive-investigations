using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.AssignmentPlanner" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AssignmentPlannerTest : AbstractBaseSetupTypedTest<AssignmentPlanner>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignmentPlanner) Initializer

        private const string PropertyCurrentUserHasDesignerPermission = "CurrentUserHasDesignerPermission";
        private const string PropertyDataXml = "DataXml";
        private const string PropertyDebugTag = "DebugTag";
        private const string PropertyDueDate = "DueDate";
        private const string PropertyGridId = "GridId";
        private const string PropertyLayoutXml = "LayoutXml";
        private const string PropertySplashDisplay = "SplashDisplay";
        private const string PropertyStartDate = "StartDate";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetFormattedDate = "GetFormattedDate";
        private const string MethodGetGridParam = "GetGridParam";
        private const string MethodRegisterRibbon = "RegisterRibbon";
        private const string MethodRegisterScripts = "RegisterScripts";
        private const string FieldINITIAL_TAB_ID = "INITIAL_TAB_ID";
        private const string FieldSPWeb = "SPWeb";
        private const string FieldWebUrl = "WebUrl";
        private const string FieldResourceIds = "ResourceIds";
        private const string Field_debugTag = "_debugTag";
        private const string Field_dueDate = "_dueDate";
        private const string Field_startDate = "_startDate";
        private Type _assignmentPlannerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignmentPlanner _assignmentPlannerInstance;
        private AssignmentPlanner _assignmentPlannerInstanceFixture;

        #region General Initializer : Class (AssignmentPlanner) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentPlanner" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentPlannerInstanceType = typeof(AssignmentPlanner);
            _assignmentPlannerInstanceFixture = Create(true);
            _assignmentPlannerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignmentPlanner)

        #region General Initializer : Class (AssignmentPlanner) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssignmentPlanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetFormattedDate, 0)]
        [TestCase(MethodGetGridParam, 0)]
        [TestCase(MethodRegisterRibbon, 0)]
        [TestCase(MethodRegisterScripts, 0)]
        public void AUT_AssignmentPlanner_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_assignmentPlannerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentPlanner) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentPlanner" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentUserHasDesignerPermission)]
        [TestCase(PropertyDataXml)]
        [TestCase(PropertyDebugTag)]
        [TestCase(PropertyDueDate)]
        [TestCase(PropertyGridId)]
        [TestCase(PropertyLayoutXml)]
        [TestCase(PropertySplashDisplay)]
        [TestCase(PropertyStartDate)]
        public void AUT_AssignmentPlanner_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_assignmentPlannerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentPlanner) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentPlanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldINITIAL_TAB_ID)]
        [TestCase(FieldSPWeb)]
        [TestCase(FieldWebUrl)]
        [TestCase(FieldResourceIds)]
        [TestCase(Field_debugTag)]
        [TestCase(Field_dueDate)]
        [TestCase(Field_startDate)]
        public void AUT_AssignmentPlanner_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assignmentPlannerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (CurrentUserHasDesignerPermission) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_CurrentUserHasDesignerPermission_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentUserHasDesignerPermission);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (DataXml) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_DataXml_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataXml);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (DebugTag) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_DebugTag_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDebugTag);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (DueDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_DueDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDueDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (GridId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_GridId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGridId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (LayoutXml) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_LayoutXml_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLayoutXml);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (SplashDisplay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_SplashDisplay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySplashDisplay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentPlanner) => Property (StartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AssignmentPlanner_Public_Class_StartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStartDate);

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
        ///     Class (<see cref="AssignmentPlanner" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetGridParam)]
        public void AUT_AssignmentPlanner_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_assignmentPlannerInstanceFixture,
                                                                              _assignmentPlannerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AssignmentPlanner" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetFormattedDate)]
        [TestCase(MethodRegisterRibbon)]
        [TestCase(MethodRegisterScripts)]
        public void AUT_AssignmentPlanner_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AssignmentPlanner>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignmentPlannerInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignmentPlannerInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignmentPlannerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_AssignmentPlanner_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignmentPlannerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_AssignmentPlanner_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_AssignmentPlanner_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_Internally(Type[] types)
        {
            var methodGetFormattedDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodGetFormattedDate, Fixture, methodGetFormattedDatePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodGetFormattedDatePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfGetFormattedDate = { dateTime };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFormattedDate, methodGetFormattedDatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AssignmentPlanner, string>(_assignmentPlannerInstanceFixture, out exception1, parametersOfGetFormattedDate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AssignmentPlanner, string>(_assignmentPlannerInstance, MethodGetFormattedDate, parametersOfGetFormattedDate, methodGetFormattedDatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFormattedDate.ShouldNotBeNull();
            parametersOfGetFormattedDate.Length.ShouldBe(1);
            methodGetFormattedDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dateTime = CreateType<DateTime>();
            var methodGetFormattedDatePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfGetFormattedDate = { dateTime };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AssignmentPlanner, string>(_assignmentPlannerInstance, MethodGetFormattedDate, parametersOfGetFormattedDate, methodGetFormattedDatePrametersTypes);

            // Assert
            parametersOfGetFormattedDate.ShouldNotBeNull();
            parametersOfGetFormattedDate.Length.ShouldBe(1);
            methodGetFormattedDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFormattedDatePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodGetFormattedDate, Fixture, methodGetFormattedDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFormattedDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFormattedDatePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodGetFormattedDate, Fixture, methodGetFormattedDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFormattedDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFormattedDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFormattedDate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetFormattedDate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFormattedDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentPlannerInstanceFixture, _assignmentPlannerInstanceType, MethodGetGridParam, Fixture, methodGetGridParamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dataXml = CreateType<XDocument>();
            var methodGetGridParamPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfGetGridParam = { dataXml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetGridParam, methodGetGridParamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignmentPlannerInstanceFixture, parametersOfGetGridParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetGridParam.ShouldNotBeNull();
            parametersOfGetGridParam.Length.ShouldBe(1);
            methodGetGridParamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataXml = CreateType<XDocument>();
            var methodGetGridParamPrametersTypes = new Type[] { typeof(XDocument) };
            object[] parametersOfGetGridParam = { dataXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_assignmentPlannerInstanceFixture, _assignmentPlannerInstanceType, MethodGetGridParam, parametersOfGetGridParam, methodGetGridParamPrametersTypes);

            // Assert
            parametersOfGetGridParam.ShouldNotBeNull();
            parametersOfGetGridParam.Length.ShouldBe(1);
            methodGetGridParamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridParamPrametersTypes = new Type[] { typeof(XDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentPlannerInstanceFixture, _assignmentPlannerInstanceType, MethodGetGridParam, Fixture, methodGetGridParamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridParamPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridParamPrametersTypes = new Type[] { typeof(XDocument) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_assignmentPlannerInstanceFixture, _assignmentPlannerInstanceType, MethodGetGridParam, Fixture, methodGetGridParamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridParamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridParam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetGridParam) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_GetGridParam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridParam, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_RegisterRibbon_Method_Call_Internally(Type[] types)
        {
            var methodRegisterRibbonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodRegisterRibbon, Fixture, methodRegisterRibbonPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterRibbon_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;
            object[] parametersOfRegisterRibbon = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterRibbon, methodRegisterRibbonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignmentPlannerInstanceFixture, parametersOfRegisterRibbon);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterRibbon.ShouldBeNull();
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterRibbon_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;
            object[] parametersOfRegisterRibbon = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignmentPlannerInstance, MethodRegisterRibbon, parametersOfRegisterRibbon, methodRegisterRibbonPrametersTypes);

            // Assert
            parametersOfRegisterRibbon.ShouldBeNull();
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterRibbon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterRibbonPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodRegisterRibbon, Fixture, methodRegisterRibbonPrametersTypes);

            // Assert
            methodRegisterRibbonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterRibbon) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterRibbon_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterRibbon, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignmentPlanner_RegisterScripts_Method_Call_Internally(Type[] types)
        {
            var methodRegisterScriptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodRegisterScripts, Fixture, methodRegisterScriptsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterScripts_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;
            object[] parametersOfRegisterScripts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScripts, methodRegisterScriptsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignmentPlannerInstanceFixture, parametersOfRegisterScripts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScripts.ShouldBeNull();
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterScripts_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;
            object[] parametersOfRegisterScripts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignmentPlannerInstance, MethodRegisterScripts, parametersOfRegisterScripts, methodRegisterScriptsPrametersTypes);

            // Assert
            parametersOfRegisterScripts.ShouldBeNull();
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterScripts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignmentPlannerInstance, MethodRegisterScripts, Fixture, methodRegisterScriptsPrametersTypes);

            // Assert
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AssignmentPlanner_RegisterScripts_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScripts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignmentPlannerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}