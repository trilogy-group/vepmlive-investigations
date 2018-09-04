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

namespace OptmizerDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="OptmizerDataCache.clsOptmizerDataCache" />)
    ///     and namespace <see cref="OptmizerDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsOptmizerDataCacheTest : AbstractBaseSetupTypedTest<clsOptmizerDataCache>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsOptmizerDataCache) Initializer

        private const string MethodCaptureOptData = "CaptureOptData";
        private const string MethodGetProjectsGrid = "GetProjectsGrid";
        private const string MethodSetPIStatusModeChange = "SetPIStatusModeChange";
        private const string MethodUpdateFilteredList = "UpdateFilteredList";
        private const string MethodReturnCommitflagName = "ReturnCommitflagName";
        private const string MethodStashViews = "StashViews";
        private const string MethodStashStratagies = "StashStratagies";
        private const string MethodGetListID = "GetListID";
        private const string MethodStripNum = "StripNum";
        private const string Fieldm_ticket = "m_ticket";
        private const string Fieldm_ListID = "m_ListID";
        private const string Fieldm_Pids = "m_Pids";
        private const string Fieldm_viewsxml = "m_viewsxml";
        private const string Fieldm_Stratagiesxml = "m_Stratagiesxml";
        private const string Fieldm_commitflagname = "m_commitflagname";
        private const string Fieldm_curr_pos = "m_curr_pos";
        private const string Fieldm_curr_digits = "m_curr_digits";
        private const string Fieldm_curr_sym = "m_curr_sym";
        private const string Fieldm_fielddef = "m_fielddef";
        private const string Fieldm_PIList = "m_PIList";
        private Type _clsOptmizerDataCacheInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsOptmizerDataCache _clsOptmizerDataCacheInstance;
        private clsOptmizerDataCache _clsOptmizerDataCacheInstanceFixture;

        #region General Initializer : Class (clsOptmizerDataCache) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsOptmizerDataCache" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsOptmizerDataCacheInstanceType = typeof(clsOptmizerDataCache);
            _clsOptmizerDataCacheInstanceFixture = Create(true);
            _clsOptmizerDataCacheInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsOptmizerDataCache)

        #region General Initializer : Class (clsOptmizerDataCache) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="clsOptmizerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCaptureOptData, 0)]
        [TestCase(MethodGetProjectsGrid, 0)]
        [TestCase(MethodSetPIStatusModeChange, 0)]
        [TestCase(MethodUpdateFilteredList, 0)]
        [TestCase(MethodReturnCommitflagName, 0)]
        [TestCase(MethodStashViews, 0)]
        [TestCase(MethodStashStratagies, 0)]
        [TestCase(MethodGetListID, 0)]
        [TestCase(MethodStripNum, 0)]
        public void AUT_ClsOptmizerDataCache_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clsOptmizerDataCacheInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (clsOptmizerDataCache) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsOptmizerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_ticket)]
        [TestCase(Fieldm_ListID)]
        [TestCase(Fieldm_Pids)]
        [TestCase(Fieldm_viewsxml)]
        [TestCase(Fieldm_Stratagiesxml)]
        [TestCase(Fieldm_commitflagname)]
        [TestCase(Fieldm_curr_pos)]
        [TestCase(Fieldm_curr_digits)]
        [TestCase(Fieldm_curr_sym)]
        [TestCase(Fieldm_fielddef)]
        [TestCase(Fieldm_PIList)]
        public void AUT_ClsOptmizerDataCache_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsOptmizerDataCacheInstanceFixture, 
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
        ///     Class (<see cref="clsOptmizerDataCache" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsOptmizerDataCache_Is_Instance_Present_Test()
        {
            // Assert
            _clsOptmizerDataCacheInstanceType.ShouldNotBeNull();
            _clsOptmizerDataCacheInstance.ShouldNotBeNull();
            _clsOptmizerDataCacheInstanceFixture.ShouldNotBeNull();
            _clsOptmizerDataCacheInstance.ShouldBeAssignableTo<clsOptmizerDataCache>();
            _clsOptmizerDataCacheInstanceFixture.ShouldBeAssignableTo<clsOptmizerDataCache>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsOptmizerDataCache) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsOptmizerDataCache_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsOptmizerDataCache instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsOptmizerDataCacheInstanceType.ShouldNotBeNull();
            _clsOptmizerDataCacheInstance.ShouldNotBeNull();
            _clsOptmizerDataCacheInstanceFixture.ShouldNotBeNull();
            _clsOptmizerDataCacheInstance.ShouldBeAssignableTo<clsOptmizerDataCache>();
            _clsOptmizerDataCacheInstanceFixture.ShouldBeAssignableTo<clsOptmizerDataCache>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="clsOptmizerDataCache" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCaptureOptData)]
        [TestCase(MethodGetProjectsGrid)]
        [TestCase(MethodSetPIStatusModeChange)]
        [TestCase(MethodUpdateFilteredList)]
        [TestCase(MethodReturnCommitflagName)]
        [TestCase(MethodStashViews)]
        [TestCase(MethodStashStratagies)]
        [TestCase(MethodGetListID)]
        [TestCase(MethodStripNum)]
        public void AUT_ClsOptmizerDataCache_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<clsOptmizerDataCache>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_Internally(Type[] types)
        {
            var methodCaptureOptDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodCaptureOptData, Fixture, methodCaptureOptDataPrametersTypes);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sxml = CreateType<string>();
            var sticket = CreateType<string>();
            var spids = CreateType<string>();
            var sListID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.CaptureOptData(sxml, sticket, spids, sListID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sxml = CreateType<string>();
            var sticket = CreateType<string>();
            var spids = CreateType<string>();
            var sListID = CreateType<string>();
            var methodCaptureOptDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCaptureOptData = { sxml, sticket, spids, sListID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCaptureOptData, methodCaptureOptDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfCaptureOptData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCaptureOptData.ShouldNotBeNull();
            parametersOfCaptureOptData.Length.ShouldBe(4);
            methodCaptureOptDataPrametersTypes.Length.ShouldBe(4);
            methodCaptureOptDataPrametersTypes.Length.ShouldBe(parametersOfCaptureOptData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sxml = CreateType<string>();
            var sticket = CreateType<string>();
            var spids = CreateType<string>();
            var sListID = CreateType<string>();
            var methodCaptureOptDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCaptureOptData = { sxml, sticket, spids, sListID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsOptmizerDataCacheInstance, MethodCaptureOptData, parametersOfCaptureOptData, methodCaptureOptDataPrametersTypes);

            // Assert
            parametersOfCaptureOptData.ShouldNotBeNull();
            parametersOfCaptureOptData.Length.ShouldBe(4);
            methodCaptureOptDataPrametersTypes.Length.ShouldBe(4);
            methodCaptureOptDataPrametersTypes.Length.ShouldBe(parametersOfCaptureOptData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCaptureOptData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCaptureOptDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodCaptureOptData, Fixture, methodCaptureOptDataPrametersTypes);

            // Assert
            methodCaptureOptDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CaptureOptData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_CaptureOptData_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCaptureOptData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectsGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetProjectsGrid, Fixture, methodGetProjectsGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.GetProjectsGrid();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetProjectsGridPrametersTypes = null;
            object[] parametersOfGetProjectsGrid = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetProjectsGrid, methodGetProjectsGridPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstanceFixture, out exception1, parametersOfGetProjectsGrid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstance, MethodGetProjectsGrid, parametersOfGetProjectsGrid, methodGetProjectsGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetProjectsGrid.ShouldBeNull();
            methodGetProjectsGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetProjectsGridPrametersTypes = null;
            object[] parametersOfGetProjectsGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetProjectsGrid, methodGetProjectsGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfGetProjectsGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProjectsGrid.ShouldBeNull();
            methodGetProjectsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetProjectsGridPrametersTypes = null;
            object[] parametersOfGetProjectsGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstance, MethodGetProjectsGrid, parametersOfGetProjectsGrid, methodGetProjectsGridPrametersTypes);

            // Assert
            parametersOfGetProjectsGrid.ShouldBeNull();
            methodGetProjectsGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetProjectsGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetProjectsGrid, Fixture, methodGetProjectsGridPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetProjectsGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetProjectsGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetProjectsGrid, Fixture, methodGetProjectsGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProjectsGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProjectsGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetProjectsGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProjectsGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_Internally(Type[] types)
        {
            var methodSetPIStatusModeChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var schanged = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.SetPIStatusModeChange(schanged);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var schanged = CreateType<string>();
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetPIStatusModeChange = { schanged };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, methodSetPIStatusModeChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfSetPIStatusModeChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetPIStatusModeChange.ShouldNotBeNull();
            parametersOfSetPIStatusModeChange.Length.ShouldBe(1);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(1);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(parametersOfSetPIStatusModeChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var schanged = CreateType<string>();
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetPIStatusModeChange = { schanged };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsOptmizerDataCacheInstance, MethodSetPIStatusModeChange, parametersOfSetPIStatusModeChange, methodSetPIStatusModeChangePrametersTypes);

            // Assert
            parametersOfSetPIStatusModeChange.ShouldNotBeNull();
            parametersOfSetPIStatusModeChange.Length.ShouldBe(1);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(1);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(parametersOfSetPIStatusModeChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);

            // Assert
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_SetPIStatusModeChange_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFilteredListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sPIList = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.UpdateFilteredList(sPIList);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sPIList = CreateType<string>();
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateFilteredList = { sPIList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, methodUpdateFilteredListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfUpdateFilteredList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateFilteredList.ShouldNotBeNull();
            parametersOfUpdateFilteredList.Length.ShouldBe(1);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(1);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(parametersOfUpdateFilteredList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPIList = CreateType<string>();
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateFilteredList = { sPIList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsOptmizerDataCacheInstance, MethodUpdateFilteredList, parametersOfUpdateFilteredList, methodUpdateFilteredListPrametersTypes);

            // Assert
            parametersOfUpdateFilteredList.ShouldNotBeNull();
            parametersOfUpdateFilteredList.Length.ShouldBe(1);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(1);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(parametersOfUpdateFilteredList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);

            // Assert
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_UpdateFilteredList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_Internally(Type[] types)
        {
            var methodReturnCommitflagNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodReturnCommitflagName, Fixture, methodReturnCommitflagNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.ReturnCommitflagName();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodReturnCommitflagNamePrametersTypes = null;
            object[] parametersOfReturnCommitflagName = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReturnCommitflagName, methodReturnCommitflagNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstanceFixture, out exception1, parametersOfReturnCommitflagName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstance, MethodReturnCommitflagName, parametersOfReturnCommitflagName, methodReturnCommitflagNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfReturnCommitflagName.ShouldBeNull();
            methodReturnCommitflagNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReturnCommitflagNamePrametersTypes = null;
            object[] parametersOfReturnCommitflagName = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReturnCommitflagName, methodReturnCommitflagNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfReturnCommitflagName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReturnCommitflagName.ShouldBeNull();
            methodReturnCommitflagNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReturnCommitflagNamePrametersTypes = null;
            object[] parametersOfReturnCommitflagName = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstance, MethodReturnCommitflagName, parametersOfReturnCommitflagName, methodReturnCommitflagNamePrametersTypes);

            // Assert
            parametersOfReturnCommitflagName.ShouldBeNull();
            methodReturnCommitflagNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodReturnCommitflagNamePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodReturnCommitflagName, Fixture, methodReturnCommitflagNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodReturnCommitflagNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReturnCommitflagNamePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodReturnCommitflagName, Fixture, methodReturnCommitflagNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReturnCommitflagNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReturnCommitflagName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_ReturnCommitflagName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReturnCommitflagName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_StashViews_Method_Call_Internally(Type[] types)
        {
            var methodStashViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.StashViews(sViews);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashViews, methodStashViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfStashViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashViews.ShouldNotBeNull();
            parametersOfStashViews.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(parametersOfStashViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsOptmizerDataCacheInstance, MethodStashViews, parametersOfStashViews, methodStashViewsPrametersTypes);

            // Assert
            parametersOfStashViews.ShouldNotBeNull();
            parametersOfStashViews.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(parametersOfStashViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);

            // Assert
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_Internally(Type[] types)
        {
            var methodStashStratagiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStashStratagies, Fixture, methodStashStratagiesPrametersTypes);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStratagies = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.StashStratagies(sStratagies);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sStratagies = CreateType<string>();
            var methodStashStratagiesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashStratagies = { sStratagies };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashStratagies, methodStashStratagiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfStashStratagies);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashStratagies.ShouldNotBeNull();
            parametersOfStashStratagies.Length.ShouldBe(1);
            methodStashStratagiesPrametersTypes.Length.ShouldBe(1);
            methodStashStratagiesPrametersTypes.Length.ShouldBe(parametersOfStashStratagies.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStratagies = CreateType<string>();
            var methodStashStratagiesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashStratagies = { sStratagies };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clsOptmizerDataCacheInstance, MethodStashStratagies, parametersOfStashStratagies, methodStashStratagiesPrametersTypes);

            // Assert
            parametersOfStashStratagies.ShouldNotBeNull();
            parametersOfStashStratagies.Length.ShouldBe(1);
            methodStashStratagiesPrametersTypes.Length.ShouldBe(1);
            methodStashStratagiesPrametersTypes.Length.ShouldBe(parametersOfStashStratagies.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashStratagies, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashStratagiesPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStashStratagies, Fixture, methodStashStratagiesPrametersTypes);

            // Assert
            methodStashStratagiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashStratagies) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StashStratagies_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashStratagies, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_GetListID_Method_Call_Internally(Type[] types)
        {
            var methodGetListIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetListID, Fixture, methodGetListIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _clsOptmizerDataCacheInstance.GetListID();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetListIDPrametersTypes = null;
            object[] parametersOfGetListID = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListID, methodGetListIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clsOptmizerDataCacheInstanceFixture, parametersOfGetListID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListID.ShouldBeNull();
            methodGetListIDPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListIDPrametersTypes = null;
            object[] parametersOfGetListID = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, string>(_clsOptmizerDataCacheInstance, MethodGetListID, parametersOfGetListID, methodGetListIDPrametersTypes);

            // Assert
            parametersOfGetListID.ShouldBeNull();
            methodGetListIDPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetListIDPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetListID, Fixture, methodGetListIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListIDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListIDPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodGetListID, Fixture, methodGetListIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListIDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListID) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_GetListID_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsOptmizerDataCache_StripNum_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsOptmizerDataCache, int>(_clsOptmizerDataCacheInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, int>(_clsOptmizerDataCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsOptmizerDataCache, int>(_clsOptmizerDataCacheInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, int>(_clsOptmizerDataCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsOptmizerDataCache, int>(_clsOptmizerDataCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsOptmizerDataCacheInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsOptmizerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsOptmizerDataCache_StripNum_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripNum, 0);
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