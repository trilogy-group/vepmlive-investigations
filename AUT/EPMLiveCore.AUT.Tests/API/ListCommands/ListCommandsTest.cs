using System;
using System.Collections;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ListCommands" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListCommandsTest : AbstractBaseSetupTypedTest<ListCommands>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListCommands) Initializer

        private const string MethodGetListPlannerInfo = "GetListPlannerInfo";
        private const string MethodiGetListPlannerInfo = "iGetListPlannerInfo";
        private const string MethodGetGridGanttSettings = "GetGridGanttSettings";
        private const string MethodGetRibbonProps = "GetRibbonProps";
        private const string MethodGetAssociatedLists = "GetAssociatedLists";
        private const string MethodiGetAssociatedLists = "iGetAssociatedLists";
        private const string MethodEnableTeamFeatures = "EnableTeamFeatures";
        private const string MethodEnableTimesheets = "EnableTimesheets";
        private const string MethodDisableTimesheets = "DisableTimesheets";
        private const string MethodTryDeleteField = "TryDeleteField";
        private const string MethodTryHideField = "TryHideField";
        private const string MethodTryAddField = "TryAddField";
        private const string MethodInstallListsViewsWebparts = "InstallListsViewsWebparts";
        private const string MethodMapListToReporting = "MapListToReporting";
        private const string MethodSaveIconToReporting = "SaveIconToReporting";
        private const string MethodEnableFancyForms = "EnableFancyForms";
        private Type _listCommandsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListCommands _listCommandsInstance;
        private ListCommands _listCommandsInstanceFixture;

        #region General Initializer : Class (ListCommands) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListCommands" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listCommandsInstanceType = typeof(ListCommands);
            _listCommandsInstanceFixture = Create(true);
            _listCommandsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListCommands)

        #region General Initializer : Class (ListCommands) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListCommands" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetListPlannerInfo, 0)]
        [TestCase(MethodiGetListPlannerInfo, 0)]
        [TestCase(MethodGetGridGanttSettings, 0)]
        [TestCase(MethodGetRibbonProps, 0)]
        [TestCase(MethodGetAssociatedLists, 0)]
        [TestCase(MethodiGetAssociatedLists, 0)]
        [TestCase(MethodEnableTeamFeatures, 0)]
        [TestCase(MethodEnableTimesheets, 0)]
        [TestCase(MethodDisableTimesheets, 0)]
        [TestCase(MethodTryDeleteField, 0)]
        [TestCase(MethodTryHideField, 0)]
        [TestCase(MethodTryAddField, 0)]
        [TestCase(MethodInstallListsViewsWebparts, 0)]
        [TestCase(MethodMapListToReporting, 0)]
        [TestCase(MethodSaveIconToReporting, 0)]
        [TestCase(MethodEnableFancyForms, 0)]
        public void AUT_ListCommands_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listCommandsInstanceFixture, 
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
        ///     Class (<see cref="ListCommands" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListCommands_Is_Instance_Present_Test()
        {
            // Assert
            _listCommandsInstanceType.ShouldNotBeNull();
            _listCommandsInstance.ShouldNotBeNull();
            _listCommandsInstanceFixture.ShouldNotBeNull();
            _listCommandsInstance.ShouldBeAssignableTo<ListCommands>();
            _listCommandsInstanceFixture.ShouldBeAssignableTo<ListCommands>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListCommands) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListCommands_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListCommands instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listCommandsInstanceType.ShouldNotBeNull();
            _listCommandsInstance.ShouldNotBeNull();
            _listCommandsInstanceFixture.ShouldNotBeNull();
            _listCommandsInstance.ShouldBeAssignableTo<ListCommands>();
            _listCommandsInstanceFixture.ShouldBeAssignableTo<ListCommands>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ListCommands" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetListPlannerInfo)]
        [TestCase(MethodiGetListPlannerInfo)]
        [TestCase(MethodGetGridGanttSettings)]
        [TestCase(MethodGetRibbonProps)]
        [TestCase(MethodGetAssociatedLists)]
        [TestCase(MethodiGetAssociatedLists)]
        [TestCase(MethodEnableTeamFeatures)]
        [TestCase(MethodEnableTimesheets)]
        [TestCase(MethodDisableTimesheets)]
        [TestCase(MethodTryDeleteField)]
        [TestCase(MethodTryHideField)]
        [TestCase(MethodTryAddField)]
        [TestCase(MethodInstallListsViewsWebparts)]
        [TestCase(MethodMapListToReporting)]
        [TestCase(MethodSaveIconToReporting)]
        [TestCase(MethodEnableFancyForms)]
        public void AUT_ListCommands_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_listCommandsInstanceFixture,
                                                                              _listCommandsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListPlannerInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, Fixture, methodGetListPlannerInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.GetListPlannerInfo(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListPlannerInfo = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListPlannerInfo, methodGetListPlannerInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, Fixture, methodGetListPlannerInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ListPlannerProps>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, parametersOfGetListPlannerInfo, methodGetListPlannerInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfGetListPlannerInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListPlannerInfo.ShouldNotBeNull();
            parametersOfGetListPlannerInfo.Length.ShouldBe(1);
            methodGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetListPlannerInfo = { list };

            // Assert
            parametersOfGetListPlannerInfo.ShouldNotBeNull();
            parametersOfGetListPlannerInfo.Length.ShouldBe(1);
            methodGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<ListPlannerProps>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, parametersOfGetListPlannerInfo, methodGetListPlannerInfoPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, Fixture, methodGetListPlannerInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetListPlannerInfo, Fixture, methodGetListPlannerInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListPlannerInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListPlannerInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListPlannerInfo) (Return Type : ListPlannerProps) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetListPlannerInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListPlannerInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetListPlannerInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, Fixture, methodiGetListPlannerInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodiGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfiGetListPlannerInfo = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetListPlannerInfo, methodiGetListPlannerInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, Fixture, methodiGetListPlannerInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ListPlannerProps>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, parametersOfiGetListPlannerInfo, methodiGetListPlannerInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfiGetListPlannerInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetListPlannerInfo.ShouldNotBeNull();
            parametersOfiGetListPlannerInfo.Length.ShouldBe(1);
            methodiGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodiGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfiGetListPlannerInfo = { list };

            // Assert
            parametersOfiGetListPlannerInfo.ShouldNotBeNull();
            parametersOfiGetListPlannerInfo.Length.ShouldBe(1);
            methodiGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<ListPlannerProps>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, parametersOfiGetListPlannerInfo, methodiGetListPlannerInfoPrametersTypes));
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, Fixture, methodiGetListPlannerInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetListPlannerInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetListPlannerInfoPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetListPlannerInfo, Fixture, methodiGetListPlannerInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetListPlannerInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetListPlannerInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetListPlannerInfo) (Return Type : ListPlannerProps) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetListPlannerInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetListPlannerInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGridGanttSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, Fixture, methodGetGridGanttSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.GetGridGanttSettings(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetGridGanttSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetGridGanttSettings = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGridGanttSettings, methodGetGridGanttSettingsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, Fixture, methodGetGridGanttSettingsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<GridGanttSettings>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, parametersOfGetGridGanttSettings, methodGetGridGanttSettingsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfGetGridGanttSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGridGanttSettings.ShouldNotBeNull();
            parametersOfGetGridGanttSettings.Length.ShouldBe(1);
            methodGetGridGanttSettingsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetGridGanttSettingsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetGridGanttSettings = { list };

            // Assert
            parametersOfGetGridGanttSettings.ShouldNotBeNull();
            parametersOfGetGridGanttSettings.Length.ShouldBe(1);
            methodGetGridGanttSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<GridGanttSettings>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, parametersOfGetGridGanttSettings, methodGetGridGanttSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridGanttSettingsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, Fixture, methodGetGridGanttSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridGanttSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridGanttSettingsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetGridGanttSettings, Fixture, methodGetGridGanttSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridGanttSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridGanttSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridGanttSettings) (Return Type : GridGanttSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetGridGanttSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridGanttSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_GetRibbonProps_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRibbonPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, Fixture, methodGetRibbonPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.GetRibbonProps(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetRibbonPropsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetRibbonProps = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRibbonProps, methodGetRibbonPropsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, Fixture, methodGetRibbonPropsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<RibbonProperties>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, parametersOfGetRibbonProps, methodGetRibbonPropsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfGetRibbonProps);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRibbonProps.ShouldNotBeNull();
            parametersOfGetRibbonProps.Length.ShouldBe(1);
            methodGetRibbonPropsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetRibbonPropsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetRibbonProps = { list };

            // Assert
            parametersOfGetRibbonProps.ShouldNotBeNull();
            parametersOfGetRibbonProps.Length.ShouldBe(1);
            methodGetRibbonPropsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<RibbonProperties>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, parametersOfGetRibbonProps, methodGetRibbonPropsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRibbonPropsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, Fixture, methodGetRibbonPropsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRibbonPropsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRibbonPropsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetRibbonProps, Fixture, methodGetRibbonPropsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRibbonPropsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRibbonProps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRibbonProps) (Return Type : RibbonProperties) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetRibbonProps_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRibbonProps, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAssociatedListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, Fixture, methodGetAssociatedListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.GetAssociatedLists(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetAssociatedLists = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAssociatedLists, methodGetAssociatedListsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, Fixture, methodGetAssociatedListsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, parametersOfGetAssociatedLists, methodGetAssociatedListsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfGetAssociatedLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAssociatedLists.ShouldNotBeNull();
            parametersOfGetAssociatedLists.Length.ShouldBe(1);
            methodGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetAssociatedLists = { list };

            // Assert
            parametersOfGetAssociatedLists.ShouldNotBeNull();
            parametersOfGetAssociatedLists.Length.ShouldBe(1);
            methodGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, parametersOfGetAssociatedLists, methodGetAssociatedListsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, Fixture, methodGetAssociatedListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodGetAssociatedLists, Fixture, methodGetAssociatedListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAssociatedListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAssociatedLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAssociatedLists) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_GetAssociatedLists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAssociatedLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetAssociatedListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, Fixture, methodiGetAssociatedListsPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodiGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfiGetAssociatedLists = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetAssociatedLists, methodiGetAssociatedListsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, Fixture, methodiGetAssociatedListsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, parametersOfiGetAssociatedLists, methodiGetAssociatedListsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfiGetAssociatedLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetAssociatedLists.ShouldNotBeNull();
            parametersOfiGetAssociatedLists.Length.ShouldBe(1);
            methodiGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodiGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfiGetAssociatedLists = { list };

            // Assert
            parametersOfiGetAssociatedLists.ShouldNotBeNull();
            parametersOfiGetAssociatedLists.Length.ShouldBe(1);
            methodiGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, parametersOfiGetAssociatedLists, methodiGetAssociatedListsPrametersTypes));
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, Fixture, methodiGetAssociatedListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetAssociatedListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetAssociatedListsPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodiGetAssociatedLists, Fixture, methodiGetAssociatedListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetAssociatedListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetAssociatedLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetAssociatedLists) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_iGetAssociatedLists_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetAssociatedLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnableTeamFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, Fixture, methodEnableTeamFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.EnableTeamFeatures(list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableTeamFeatures = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodEnableTeamFeatures, methodEnableTeamFeaturesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, Fixture, methodEnableTeamFeaturesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, parametersOfEnableTeamFeatures, methodEnableTeamFeaturesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfEnableTeamFeatures.ShouldNotBeNull();
            parametersOfEnableTeamFeatures.Length.ShouldBe(1);
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, parametersOfEnableTeamFeatures, methodEnableTeamFeaturesPrametersTypes));
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableTeamFeatures = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableTeamFeatures, methodEnableTeamFeaturesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableTeamFeatures.ShouldNotBeNull();
            parametersOfEnableTeamFeatures.Length.ShouldBe(1);
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfEnableTeamFeatures));
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableTeamFeatures = { list };

            // Assert
            parametersOfEnableTeamFeatures.ShouldNotBeNull();
            parametersOfEnableTeamFeatures.Length.ShouldBe(1);
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, parametersOfEnableTeamFeatures, methodEnableTeamFeaturesPrametersTypes));
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, Fixture, methodEnableTeamFeaturesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, Fixture, methodEnableTeamFeaturesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableTeamFeaturesPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTeamFeatures, Fixture, methodEnableTeamFeaturesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEnableTeamFeaturesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableTeamFeatures, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EnableTeamFeatures) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTeamFeatures_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableTeamFeatures, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_EnableTimesheets_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnableTimesheetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTimesheets, Fixture, methodEnableTimesheetsPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.EnableTimesheets(list, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodEnableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };
            object[] parametersOfEnableTimesheets = { list, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableTimesheets, methodEnableTimesheetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfEnableTimesheets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableTimesheets.ShouldNotBeNull();
            parametersOfEnableTimesheets.Length.ShouldBe(2);
            methodEnableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodEnableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };
            object[] parametersOfEnableTimesheets = { list, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTimesheets, parametersOfEnableTimesheets, methodEnableTimesheetsPrametersTypes);

            // Assert
            parametersOfEnableTimesheets.ShouldNotBeNull();
            parametersOfEnableTimesheets.Length.ShouldBe(2);
            methodEnableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableTimesheets, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableTimesheets, Fixture, methodEnableTimesheetsPrametersTypes);

            // Assert
            methodEnableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableTimesheets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableTimesheets_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableTimesheets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_DisableTimesheets_Static_Method_Call_Internally(Type[] types)
        {
            var methodDisableTimesheetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodDisableTimesheets, Fixture, methodDisableTimesheetsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.DisableTimesheets(list, web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodDisableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };
            object[] parametersOfDisableTimesheets = { list, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableTimesheets, methodDisableTimesheetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfDisableTimesheets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableTimesheets.ShouldNotBeNull();
            parametersOfDisableTimesheets.Length.ShouldBe(2);
            methodDisableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var methodDisableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };
            object[] parametersOfDisableTimesheets = { list, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodDisableTimesheets, parametersOfDisableTimesheets, methodDisableTimesheetsPrametersTypes);

            // Assert
            parametersOfDisableTimesheets.ShouldNotBeNull();
            parametersOfDisableTimesheets.Length.ShouldBe(2);
            methodDisableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableTimesheets, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableTimesheetsPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodDisableTimesheets, Fixture, methodDisableTimesheetsPrametersTypes);

            // Assert
            methodDisableTimesheetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableTimesheets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_DisableTimesheets_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableTimesheets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_TryDeleteField_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryDeleteFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryDeleteField, Fixture, methodTryDeleteFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryDeleteField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var methodTryDeleteFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfTryDeleteField = { list, InternalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryDeleteField, methodTryDeleteFieldPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryDeleteField.ShouldNotBeNull();
            parametersOfTryDeleteField.Length.ShouldBe(2);
            methodTryDeleteFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfTryDeleteField));
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryDeleteField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var methodTryDeleteFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfTryDeleteField = { list, InternalName };

            // Assert
            parametersOfTryDeleteField.ShouldNotBeNull();
            parametersOfTryDeleteField.Length.ShouldBe(2);
            methodTryDeleteFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryDeleteField, parametersOfTryDeleteField, methodTryDeleteFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryDeleteField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryDeleteFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryDeleteField, Fixture, methodTryDeleteFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryDeleteFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryDeleteField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryDeleteField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryDeleteField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryDeleteField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryDeleteField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_TryHideField_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryHideFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryHideField, Fixture, methodTryHideFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryHideField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var methodTryHideFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfTryHideField = { list, InternalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryHideField, methodTryHideFieldPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryHideField.ShouldNotBeNull();
            parametersOfTryHideField.Length.ShouldBe(2);
            methodTryHideFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfTryHideField));
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryHideField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var methodTryHideFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfTryHideField = { list, InternalName };

            // Assert
            parametersOfTryHideField.ShouldNotBeNull();
            parametersOfTryHideField.Length.ShouldBe(2);
            methodTryHideFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryHideField, parametersOfTryHideField, methodTryHideFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryHideField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryHideFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryHideField, Fixture, methodTryHideFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryHideFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryHideField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryHideField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryHideField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryHideField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryHideField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_TryAddField_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryAddFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryAddField, Fixture, methodTryAddFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryAddField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var type = CreateType<SPFieldType>();
            var Title = CreateType<string>();
            var Hidden = CreateType<bool>();
            var methodTryAddFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPFieldType), typeof(string), typeof(bool) };
            object[] parametersOfTryAddField = { list, InternalName, type, Title, Hidden };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryAddField, methodTryAddFieldPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryAddField.ShouldNotBeNull();
            parametersOfTryAddField.Length.ShouldBe(5);
            methodTryAddFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfTryAddField));
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryAddField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var InternalName = CreateType<string>();
            var type = CreateType<SPFieldType>();
            var Title = CreateType<string>();
            var Hidden = CreateType<bool>();
            var methodTryAddFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPFieldType), typeof(string), typeof(bool) };
            object[] parametersOfTryAddField = { list, InternalName, type, Title, Hidden };

            // Assert
            parametersOfTryAddField.ShouldNotBeNull();
            parametersOfTryAddField.Length.ShouldBe(5);
            methodTryAddFieldPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryAddField, parametersOfTryAddField, methodTryAddFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryAddField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryAddFieldPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(SPFieldType), typeof(string), typeof(bool) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodTryAddField, Fixture, methodTryAddFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryAddFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryAddField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryAddField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryAddField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_TryAddField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryAddField, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_Internally(Type[] types)
        {
            var methodInstallListsViewsWebpartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodInstallListsViewsWebparts, Fixture, methodInstallListsViewsWebpartsPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.InstallListsViewsWebparts(spList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodInstallListsViewsWebpartsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfInstallListsViewsWebparts = { spList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstallListsViewsWebparts, methodInstallListsViewsWebpartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfInstallListsViewsWebparts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallListsViewsWebparts.ShouldNotBeNull();
            parametersOfInstallListsViewsWebparts.Length.ShouldBe(1);
            methodInstallListsViewsWebpartsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spList = CreateType<SPList>();
            var methodInstallListsViewsWebpartsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfInstallListsViewsWebparts = { spList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodInstallListsViewsWebparts, parametersOfInstallListsViewsWebparts, methodInstallListsViewsWebpartsPrametersTypes);

            // Assert
            parametersOfInstallListsViewsWebparts.ShouldNotBeNull();
            parametersOfInstallListsViewsWebparts.Length.ShouldBe(1);
            methodInstallListsViewsWebpartsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallListsViewsWebparts, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallListsViewsWebpartsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodInstallListsViewsWebparts, Fixture, methodInstallListsViewsWebpartsPrametersTypes);

            // Assert
            methodInstallListsViewsWebpartsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallListsViewsWebparts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_InstallListsViewsWebparts_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallListsViewsWebparts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_MapListToReporting_Static_Method_Call_Internally(Type[] types)
        {
            var methodMapListToReportingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodMapListToReporting, Fixture, methodMapListToReportingPrametersTypes);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.MapListToReporting(oList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var methodMapListToReportingPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfMapListToReporting = { oList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMapListToReporting, methodMapListToReportingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfMapListToReporting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMapListToReporting.ShouldNotBeNull();
            parametersOfMapListToReporting.Length.ShouldBe(1);
            methodMapListToReportingPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var methodMapListToReportingPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfMapListToReporting = { oList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodMapListToReporting, parametersOfMapListToReporting, methodMapListToReportingPrametersTypes);

            // Assert
            parametersOfMapListToReporting.ShouldNotBeNull();
            parametersOfMapListToReporting.Length.ShouldBe(1);
            methodMapListToReportingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapListToReporting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapListToReportingPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodMapListToReporting, Fixture, methodMapListToReportingPrametersTypes);

            // Assert
            methodMapListToReportingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapListToReporting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_MapListToReporting_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapListToReporting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveIconToReportingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodSaveIconToReporting, Fixture, methodSaveIconToReportingPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.SaveIconToReporting(list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodSaveIconToReportingPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveIconToReporting = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveIconToReporting, methodSaveIconToReportingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfSaveIconToReporting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveIconToReporting.ShouldNotBeNull();
            parametersOfSaveIconToReporting.Length.ShouldBe(1);
            methodSaveIconToReportingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodSaveIconToReportingPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfSaveIconToReporting = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodSaveIconToReporting, parametersOfSaveIconToReporting, methodSaveIconToReportingPrametersTypes);

            // Assert
            parametersOfSaveIconToReporting.ShouldNotBeNull();
            parametersOfSaveIconToReporting.Length.ShouldBe(1);
            methodSaveIconToReportingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveIconToReporting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveIconToReportingPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodSaveIconToReporting, Fixture, methodSaveIconToReportingPrametersTypes);

            // Assert
            methodSaveIconToReportingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveIconToReporting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_SaveIconToReporting_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveIconToReporting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListCommands_EnableFancyForms_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnableFancyFormsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableFancyForms, Fixture, methodEnableFancyFormsPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => ListCommands.EnableFancyForms(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableFancyForms = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, methodEnableFancyFormsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listCommandsInstanceFixture, parametersOfEnableFancyForms);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableFancyForms.ShouldNotBeNull();
            parametersOfEnableFancyForms.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfEnableFancyForms = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableFancyForms, parametersOfEnableFancyForms, methodEnableFancyFormsPrametersTypes);

            // Assert
            parametersOfEnableFancyForms.ShouldNotBeNull();
            parametersOfEnableFancyForms.Length.ShouldBe(1);
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableFancyFormsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_listCommandsInstanceFixture, _listCommandsInstanceType, MethodEnableFancyForms, Fixture, methodEnableFancyFormsPrametersTypes);

            // Assert
            methodEnableFancyFormsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFancyForms) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListCommands_EnableFancyForms_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableFancyForms, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listCommandsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}