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

namespace WorkEnginePPM.Layouts.ppm.Admin
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm.Admin.InstallDataSyncEvents" />)
    ///     and namespace <see cref="WorkEnginePPM.Layouts.ppm.Admin"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class InstallDataSyncEventsTest : AbstractBaseSetupTypedTest<InstallDataSyncEvents>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallDataSyncEvents) Initializer

        private const string MethodInstallButtonOnClick = "InstallButtonOnClick";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodSyncLists = "SyncLists";
        private const string MethodSyncListsButtonOnClick = "SyncListsButtonOnClick";
        private const string MethodUnInstallButtonOnClick = "UnInstallButtonOnClick";
        private const string MethodBuildHeading = "BuildHeading";
        private const string MethodBuildMessage = "BuildMessage";
        private const string MethodSyncHolidaySchedules = "SyncHolidaySchedules";
        private const string MethodSyncPersonalItems = "SyncPersonalItems";
        private const string MethodSyncRoles = "SyncRoles";
        private const string MethodSyncWorkHours = "SyncWorkHours";
        private Type _installDataSyncEventsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallDataSyncEvents _installDataSyncEventsInstance;
        private InstallDataSyncEvents _installDataSyncEventsInstanceFixture;

        #region General Initializer : Class (InstallDataSyncEvents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallDataSyncEvents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installDataSyncEventsInstanceType = typeof(InstallDataSyncEvents);
            _installDataSyncEventsInstanceFixture = Create(true);
            _installDataSyncEventsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallDataSyncEvents)

        #region General Initializer : Class (InstallDataSyncEvents) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallDataSyncEvents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstallButtonOnClick, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodSyncLists, 0)]
        [TestCase(MethodSyncListsButtonOnClick, 0)]
        [TestCase(MethodUnInstallButtonOnClick, 0)]
        [TestCase(MethodBuildHeading, 0)]
        [TestCase(MethodBuildMessage, 0)]
        [TestCase(MethodSyncHolidaySchedules, 0)]
        [TestCase(MethodSyncPersonalItems, 0)]
        [TestCase(MethodSyncRoles, 0)]
        [TestCase(MethodSyncWorkHours, 0)]
        public void AUT_InstallDataSyncEvents_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installDataSyncEventsInstanceFixture, 
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
        ///     Class (<see cref="InstallDataSyncEvents" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_InstallDataSyncEvents_Is_Instance_Present_Test()
        {
            // Assert
            _installDataSyncEventsInstanceType.ShouldNotBeNull();
            _installDataSyncEventsInstance.ShouldNotBeNull();
            _installDataSyncEventsInstanceFixture.ShouldNotBeNull();
            _installDataSyncEventsInstance.ShouldBeAssignableTo<InstallDataSyncEvents>();
            _installDataSyncEventsInstanceFixture.ShouldBeAssignableTo<InstallDataSyncEvents>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (InstallDataSyncEvents) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_InstallDataSyncEvents_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            InstallDataSyncEvents instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _installDataSyncEventsInstanceType.ShouldNotBeNull();
            _installDataSyncEventsInstance.ShouldNotBeNull();
            _installDataSyncEventsInstanceFixture.ShouldNotBeNull();
            _installDataSyncEventsInstance.ShouldBeAssignableTo<InstallDataSyncEvents>();
            _installDataSyncEventsInstanceFixture.ShouldBeAssignableTo<InstallDataSyncEvents>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="InstallDataSyncEvents" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInstallButtonOnClick)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodSyncLists)]
        [TestCase(MethodSyncListsButtonOnClick)]
        [TestCase(MethodUnInstallButtonOnClick)]
        [TestCase(MethodBuildHeading)]
        [TestCase(MethodBuildMessage)]
        [TestCase(MethodSyncHolidaySchedules)]
        [TestCase(MethodSyncPersonalItems)]
        [TestCase(MethodSyncRoles)]
        [TestCase(MethodSyncWorkHours)]
        public void AUT_InstallDataSyncEvents_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallDataSyncEvents>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodInstallButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodInstallButtonOnClick, Fixture, methodInstallButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfInstallButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstallButtonOnClick, methodInstallButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfInstallButtonOnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallButtonOnClick.ShouldNotBeNull();
            parametersOfInstallButtonOnClick.Length.ShouldBe(2);
            methodInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodInstallButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfInstallButtonOnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfInstallButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installDataSyncEventsInstance, MethodInstallButtonOnClick, parametersOfInstallButtonOnClick, methodInstallButtonOnClickPrametersTypes);

            // Assert
            parametersOfInstallButtonOnClick.ShouldNotBeNull();
            parametersOfInstallButtonOnClick.Length.ShouldBe(2);
            methodInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodInstallButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfInstallButtonOnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallButtonOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodInstallButtonOnClick, Fixture, methodInstallButtonOnClickPrametersTypes);

            // Assert
            methodInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_InstallButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installDataSyncEventsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_InstallDataSyncEvents_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_InstallDataSyncEvents_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncLists_Method_Call_Internally(Type[] types)
        {
            var methodSyncListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncLists, Fixture, methodSyncListsPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSyncListsPrametersTypes = null;
            object[] parametersOfSyncLists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSyncLists, methodSyncListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallDataSyncEvents, string>(_installDataSyncEventsInstanceFixture, out exception1, parametersOfSyncLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncLists, parametersOfSyncLists, methodSyncListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSyncLists.ShouldBeNull();
            methodSyncListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSyncListsPrametersTypes = null;
            object[] parametersOfSyncLists = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncLists, methodSyncListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncLists.ShouldBeNull();
            methodSyncListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSyncListsPrametersTypes = null;
            object[] parametersOfSyncLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncLists, parametersOfSyncLists, methodSyncListsPrametersTypes);

            // Assert
            parametersOfSyncLists.ShouldBeNull();
            methodSyncListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodSyncListsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncLists, Fixture, methodSyncListsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSyncListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSyncListsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncLists, Fixture, methodSyncListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSyncListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncLists) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodSyncListsButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncListsButtonOnClick, Fixture, methodSyncListsButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSyncListsButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSyncListsButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncListsButtonOnClick, methodSyncListsButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncListsButtonOnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncListsButtonOnClick.ShouldNotBeNull();
            parametersOfSyncListsButtonOnClick.Length.ShouldBe(2);
            methodSyncListsButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodSyncListsButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfSyncListsButtonOnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSyncListsButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSyncListsButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installDataSyncEventsInstance, MethodSyncListsButtonOnClick, parametersOfSyncListsButtonOnClick, methodSyncListsButtonOnClickPrametersTypes);

            // Assert
            parametersOfSyncListsButtonOnClick.ShouldNotBeNull();
            parametersOfSyncListsButtonOnClick.Length.ShouldBe(2);
            methodSyncListsButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodSyncListsButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfSyncListsButtonOnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSyncListsButtonOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSyncListsButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncListsButtonOnClick, Fixture, methodSyncListsButtonOnClickPrametersTypes);

            // Assert
            methodSyncListsButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncListsButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncListsButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncListsButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodUnInstallButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodUnInstallButtonOnClick, Fixture, methodUnInstallButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUnInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUnInstallButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUnInstallButtonOnClick, methodUnInstallButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfUnInstallButtonOnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUnInstallButtonOnClick.ShouldNotBeNull();
            parametersOfUnInstallButtonOnClick.Length.ShouldBe(2);
            methodUnInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodUnInstallButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfUnInstallButtonOnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUnInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUnInstallButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installDataSyncEventsInstance, MethodUnInstallButtonOnClick, parametersOfUnInstallButtonOnClick, methodUnInstallButtonOnClickPrametersTypes);

            // Assert
            parametersOfUnInstallButtonOnClick.ShouldNotBeNull();
            parametersOfUnInstallButtonOnClick.Length.ShouldBe(2);
            methodUnInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodUnInstallButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfUnInstallButtonOnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnInstallButtonOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnInstallButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodUnInstallButtonOnClick, Fixture, methodUnInstallButtonOnClickPrametersTypes);

            // Assert
            methodUnInstallButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_UnInstallButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnInstallButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_Internally(Type[] types)
        {
            var methodBuildHeadingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildHeading, Fixture, methodBuildHeadingPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodBuildHeadingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildHeading = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildHeading, methodBuildHeadingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfBuildHeading);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildHeading.ShouldNotBeNull();
            parametersOfBuildHeading.Length.ShouldBe(1);
            methodBuildHeadingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodBuildHeadingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildHeading = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodBuildHeading, parametersOfBuildHeading, methodBuildHeadingPrametersTypes);

            // Assert
            parametersOfBuildHeading.ShouldNotBeNull();
            parametersOfBuildHeading.Length.ShouldBe(1);
            methodBuildHeadingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildHeadingPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildHeading, Fixture, methodBuildHeadingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildHeadingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildHeadingPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildHeading, Fixture, methodBuildHeadingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildHeadingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildHeading, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildHeading) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildHeading_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildHeading, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_Internally(Type[] types)
        {
            var methodBuildMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildMessage, Fixture, methodBuildMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodBuildMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildMessage = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildMessage, methodBuildMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfBuildMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildMessage.ShouldNotBeNull();
            parametersOfBuildMessage.Length.ShouldBe(1);
            methodBuildMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodBuildMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildMessage = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodBuildMessage, parametersOfBuildMessage, methodBuildMessagePrametersTypes);

            // Assert
            parametersOfBuildMessage.ShouldNotBeNull();
            parametersOfBuildMessage.Length.ShouldBe(1);
            methodBuildMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildMessagePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildMessage, Fixture, methodBuildMessagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildMessagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildMessagePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodBuildMessage, Fixture, methodBuildMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildMessagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildMessage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildMessage) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_BuildMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildMessage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_Internally(Type[] types)
        {
            var methodSyncHolidaySchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncHolidaySchedules, Fixture, methodSyncHolidaySchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSyncHolidaySchedulesPrametersTypes = null;
            object[] parametersOfSyncHolidaySchedules = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSyncHolidaySchedules, methodSyncHolidaySchedulesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallDataSyncEvents, string>(_installDataSyncEventsInstanceFixture, out exception1, parametersOfSyncHolidaySchedules);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncHolidaySchedules, parametersOfSyncHolidaySchedules, methodSyncHolidaySchedulesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSyncHolidaySchedules.ShouldBeNull();
            methodSyncHolidaySchedulesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSyncHolidaySchedulesPrametersTypes = null;
            object[] parametersOfSyncHolidaySchedules = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncHolidaySchedules, methodSyncHolidaySchedulesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncHolidaySchedules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncHolidaySchedules.ShouldBeNull();
            methodSyncHolidaySchedulesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSyncHolidaySchedulesPrametersTypes = null;
            object[] parametersOfSyncHolidaySchedules = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncHolidaySchedules, parametersOfSyncHolidaySchedules, methodSyncHolidaySchedulesPrametersTypes);

            // Assert
            parametersOfSyncHolidaySchedules.ShouldBeNull();
            methodSyncHolidaySchedulesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodSyncHolidaySchedulesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncHolidaySchedules, Fixture, methodSyncHolidaySchedulesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSyncHolidaySchedulesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSyncHolidaySchedulesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncHolidaySchedules, Fixture, methodSyncHolidaySchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSyncHolidaySchedulesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncHolidaySchedules) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncHolidaySchedules_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncHolidaySchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_Internally(Type[] types)
        {
            var methodSyncPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncPersonalItems, Fixture, methodSyncPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSyncPersonalItemsPrametersTypes = null;
            object[] parametersOfSyncPersonalItems = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSyncPersonalItems, methodSyncPersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallDataSyncEvents, string>(_installDataSyncEventsInstanceFixture, out exception1, parametersOfSyncPersonalItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncPersonalItems, parametersOfSyncPersonalItems, methodSyncPersonalItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSyncPersonalItems.ShouldBeNull();
            methodSyncPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSyncPersonalItemsPrametersTypes = null;
            object[] parametersOfSyncPersonalItems = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncPersonalItems, methodSyncPersonalItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncPersonalItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncPersonalItems.ShouldBeNull();
            methodSyncPersonalItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSyncPersonalItemsPrametersTypes = null;
            object[] parametersOfSyncPersonalItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncPersonalItems, parametersOfSyncPersonalItems, methodSyncPersonalItemsPrametersTypes);

            // Assert
            parametersOfSyncPersonalItems.ShouldBeNull();
            methodSyncPersonalItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodSyncPersonalItemsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncPersonalItems, Fixture, methodSyncPersonalItemsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSyncPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSyncPersonalItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncPersonalItems, Fixture, methodSyncPersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSyncPersonalItemsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncPersonalItems) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncPersonalItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncPersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_Internally(Type[] types)
        {
            var methodSyncRolesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncRoles, Fixture, methodSyncRolesPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSyncRolesPrametersTypes = null;
            object[] parametersOfSyncRoles = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSyncRoles, methodSyncRolesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallDataSyncEvents, string>(_installDataSyncEventsInstanceFixture, out exception1, parametersOfSyncRoles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncRoles, parametersOfSyncRoles, methodSyncRolesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSyncRoles.ShouldBeNull();
            methodSyncRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSyncRolesPrametersTypes = null;
            object[] parametersOfSyncRoles = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncRoles, methodSyncRolesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncRoles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncRoles.ShouldBeNull();
            methodSyncRolesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSyncRolesPrametersTypes = null;
            object[] parametersOfSyncRoles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncRoles, parametersOfSyncRoles, methodSyncRolesPrametersTypes);

            // Assert
            parametersOfSyncRoles.ShouldBeNull();
            methodSyncRolesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodSyncRolesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncRoles, Fixture, methodSyncRolesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSyncRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSyncRolesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncRoles, Fixture, methodSyncRolesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSyncRolesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncRoles) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncRoles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncRoles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_Internally(Type[] types)
        {
            var methodSyncWorkHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncWorkHours, Fixture, methodSyncWorkHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSyncWorkHoursPrametersTypes = null;
            object[] parametersOfSyncWorkHours = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSyncWorkHours, methodSyncWorkHoursPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<InstallDataSyncEvents, string>(_installDataSyncEventsInstanceFixture, out exception1, parametersOfSyncWorkHours);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncWorkHours, parametersOfSyncWorkHours, methodSyncWorkHoursPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSyncWorkHours.ShouldBeNull();
            methodSyncWorkHoursPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSyncWorkHoursPrametersTypes = null;
            object[] parametersOfSyncWorkHours = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSyncWorkHours, methodSyncWorkHoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installDataSyncEventsInstanceFixture, parametersOfSyncWorkHours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSyncWorkHours.ShouldBeNull();
            methodSyncWorkHoursPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSyncWorkHoursPrametersTypes = null;
            object[] parametersOfSyncWorkHours = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<InstallDataSyncEvents, string>(_installDataSyncEventsInstance, MethodSyncWorkHours, parametersOfSyncWorkHours, methodSyncWorkHoursPrametersTypes);

            // Assert
            parametersOfSyncWorkHours.ShouldBeNull();
            methodSyncWorkHoursPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodSyncWorkHoursPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncWorkHours, Fixture, methodSyncWorkHoursPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSyncWorkHoursPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSyncWorkHoursPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installDataSyncEventsInstance, MethodSyncWorkHours, Fixture, methodSyncWorkHoursPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSyncWorkHoursPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SyncWorkHours) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallDataSyncEvents_SyncWorkHours_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSyncWorkHours, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_installDataSyncEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}