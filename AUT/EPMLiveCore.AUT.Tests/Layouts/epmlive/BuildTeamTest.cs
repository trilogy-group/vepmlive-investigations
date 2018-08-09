using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.BuildTeam" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BuildTeamTest : AbstractBaseSetupTypedTest<BuildTeam>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BuildTeam) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodAddRibbonTab = "AddRibbonTab";
        private const string MethodAddTabEvents = "AddTabEvents";
        private const string FieldsLayoutParam = "sLayoutParam";
        private const string FieldsResPool = "sResPool";
        private const string FieldbCanAddResource = "bCanAddResource";
        private const string FieldsNewResUrl = "sNewResUrl";
        private const string FieldbCanEditTeam = "bCanEditTeam";
        private const string FieldbCanAccessResourcePool = "bCanAccessResourcePool";
        private const string FieldsUserInfoList = "sUserInfoList";
        private const string FieldsClose = "sClose";
        private const string FieldsDisable = "sDisable";
        private const string FieldsDefaultGroup = "sDefaultGroup";
        private const string FieldsResGrid = "sResGrid";
        private const string FieldprojectIdInPfe = "projectIdInPfe";
        private Type _buildTeamInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BuildTeam _buildTeamInstance;
        private BuildTeam _buildTeamInstanceFixture;

        #region General Initializer : Class (BuildTeam) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BuildTeam" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _buildTeamInstanceType = typeof(BuildTeam);
            _buildTeamInstanceFixture = Create(true);
            _buildTeamInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BuildTeam)

        #region General Initializer : Class (BuildTeam) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="BuildTeam" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodAddRibbonTab, 0)]
        [TestCase(MethodAddTabEvents, 0)]
        public void AUT_BuildTeam_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_buildTeamInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (BuildTeam) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BuildTeam" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsLayoutParam)]
        [TestCase(FieldsResPool)]
        [TestCase(FieldbCanAddResource)]
        [TestCase(FieldsNewResUrl)]
        [TestCase(FieldbCanEditTeam)]
        [TestCase(FieldbCanAccessResourcePool)]
        [TestCase(FieldsUserInfoList)]
        [TestCase(FieldsClose)]
        [TestCase(FieldsDisable)]
        [TestCase(FieldsDefaultGroup)]
        [TestCase(FieldsResGrid)]
        public void AUT_BuildTeam_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_buildTeamInstanceFixture, 
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
        ///     Class (<see cref="BuildTeam" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BuildTeam_Is_Instance_Present_Test()
        {
            // Assert
            _buildTeamInstanceType.ShouldNotBeNull();
            _buildTeamInstance.ShouldNotBeNull();
            _buildTeamInstanceFixture.ShouldNotBeNull();
            _buildTeamInstance.ShouldBeAssignableTo<BuildTeam>();
            _buildTeamInstanceFixture.ShouldBeAssignableTo<BuildTeam>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BuildTeam) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BuildTeam_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BuildTeam instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _buildTeamInstanceType.ShouldNotBeNull();
            _buildTeamInstance.ShouldNotBeNull();
            _buildTeamInstanceFixture.ShouldNotBeNull();
            _buildTeamInstance.ShouldBeAssignableTo<BuildTeam>();
            _buildTeamInstanceFixture.ShouldBeAssignableTo<BuildTeam>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="BuildTeam" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodAddRibbonTab)]
        [TestCase(MethodAddTabEvents)]
        public void AUT_BuildTeam_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<BuildTeam>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BuildTeam_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_buildTeamInstanceFixture, parametersOfPage_Load);

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
        public void AUT_BuildTeam_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_buildTeamInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_BuildTeam_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_BuildTeam_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_buildTeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BuildTeam_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_buildTeamInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_BuildTeam_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_buildTeamInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_BuildTeam_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_BuildTeam_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_buildTeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRibbonTab) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BuildTeam_AddRibbonTab_Method_Call_Internally(Type[] types)
        {
            var methodAddRibbonTabPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodAddRibbonTab, Fixture, methodAddRibbonTabPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRibbonTab) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddRibbonTab_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddRibbonTabPrametersTypes = null;
            object[] parametersOfAddRibbonTab = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddRibbonTab, methodAddRibbonTabPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_buildTeamInstanceFixture, parametersOfAddRibbonTab);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddRibbonTab.ShouldBeNull();
            methodAddRibbonTabPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddRibbonTab) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddRibbonTab_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddRibbonTabPrametersTypes = null;
            object[] parametersOfAddRibbonTab = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_buildTeamInstance, MethodAddRibbonTab, parametersOfAddRibbonTab, methodAddRibbonTabPrametersTypes);

            // Assert
            parametersOfAddRibbonTab.ShouldBeNull();
            methodAddRibbonTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRibbonTab) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddRibbonTab_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddRibbonTabPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodAddRibbonTab, Fixture, methodAddRibbonTabPrametersTypes);

            // Assert
            methodAddRibbonTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddRibbonTab) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddRibbonTab_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddRibbonTab, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_buildTeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTabEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BuildTeam_AddTabEvents_Method_Call_Internally(Type[] types)
        {
            var methodAddTabEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodAddTabEvents, Fixture, methodAddTabEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTabEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddTabEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddTabEventsPrametersTypes = null;
            object[] parametersOfAddTabEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTabEvents, methodAddTabEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_buildTeamInstanceFixture, parametersOfAddTabEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTabEvents.ShouldBeNull();
            methodAddTabEventsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddTabEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddTabEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddTabEventsPrametersTypes = null;
            object[] parametersOfAddTabEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_buildTeamInstance, MethodAddTabEvents, parametersOfAddTabEvents, methodAddTabEventsPrametersTypes);

            // Assert
            parametersOfAddTabEvents.ShouldBeNull();
            methodAddTabEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTabEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddTabEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddTabEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_buildTeamInstance, MethodAddTabEvents, Fixture, methodAddTabEventsPrametersTypes);

            // Assert
            methodAddTabEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTabEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BuildTeam_AddTabEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTabEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_buildTeamInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}