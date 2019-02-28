using System;
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

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Upgraders.WE432Upgrader" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Upgraders"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class WE432UpgraderTest : AbstractBaseSetupTypedTest<WE432Upgrader>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WE432Upgrader) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodUpgradeButtonOnClick = "UpgradeButtonOnClick";
        private const string MethodAddColumns = "AddColumns";
        private const string MethodConfigureMyWorkViews = "ConfigureMyWorkViews";
        private const string MethodGeneralUpgrade = "GeneralUpgrade";
        private const string MethodLogError = "LogError";
        private const string MethodLogHeader = "LogHeader";
        private const string MethodLogMessage = "LogMessage";
        private const string MethodUpdateMyWorkWebPart = "UpdateMyWorkWebPart";
        private const string MethodUpgradeMyWork = "UpgradeMyWork";
        private const string Field_messages = "_messages";
        private Type _wE432UpgraderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WE432Upgrader _wE432UpgraderInstance;
        private WE432Upgrader _wE432UpgraderInstanceFixture;

        #region General Initializer : Class (WE432Upgrader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WE432Upgrader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wE432UpgraderInstanceType = typeof(WE432Upgrader);
            _wE432UpgraderInstanceFixture = Create(true);
            _wE432UpgraderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WE432Upgrader)

        #region General Initializer : Class (WE432Upgrader) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WE432Upgrader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodUpgradeButtonOnClick, 0)]
        [TestCase(MethodAddColumns, 0)]
        [TestCase(MethodConfigureMyWorkViews, 0)]
        [TestCase(MethodGeneralUpgrade, 0)]
        [TestCase(MethodLogError, 0)]
        [TestCase(MethodLogHeader, 0)]
        [TestCase(MethodLogMessage, 0)]
        [TestCase(MethodUpdateMyWorkWebPart, 0)]
        [TestCase(MethodUpgradeMyWork, 0)]
        public void AUT_WE432Upgrader_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wE432UpgraderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WE432Upgrader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WE432Upgrader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_messages)]
        public void AUT_WE432Upgrader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_wE432UpgraderInstanceFixture, 
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
        ///     Class (<see cref="WE432Upgrader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WE432Upgrader_Is_Instance_Present_Test()
        {
            // Assert
            _wE432UpgraderInstanceType.ShouldNotBeNull();
            _wE432UpgraderInstance.ShouldNotBeNull();
            _wE432UpgraderInstanceFixture.ShouldNotBeNull();
            _wE432UpgraderInstance.ShouldBeAssignableTo<WE432Upgrader>();
            _wE432UpgraderInstanceFixture.ShouldBeAssignableTo<WE432Upgrader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WE432Upgrader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WE432Upgrader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WE432Upgrader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _wE432UpgraderInstanceType.ShouldNotBeNull();
            _wE432UpgraderInstance.ShouldNotBeNull();
            _wE432UpgraderInstanceFixture.ShouldNotBeNull();
            _wE432UpgraderInstance.ShouldBeAssignableTo<WE432Upgrader>();
            _wE432UpgraderInstanceFixture.ShouldBeAssignableTo<WE432Upgrader>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WE432Upgrader" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConfigureMyWorkViews)]
        [TestCase(MethodUpdateMyWorkWebPart)]
        public void AUT_WE432Upgrader_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_wE432UpgraderInstanceFixture,
                                                                              _wE432UpgraderInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WE432Upgrader" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodUpgradeButtonOnClick)]
        [TestCase(MethodAddColumns)]
        [TestCase(MethodGeneralUpgrade)]
        [TestCase(MethodLogError)]
        [TestCase(MethodLogHeader)]
        [TestCase(MethodLogMessage)]
        [TestCase(MethodUpgradeMyWork)]
        public void AUT_WE432Upgrader_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WE432Upgrader>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfPage_Load);

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
        public void AUT_WE432Upgrader_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_WE432Upgrader_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_WE432Upgrader_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_Internally(Type[] types)
        {
            var methodUpgradeButtonOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodUpgradeButtonOnClick, Fixture, methodUpgradeButtonOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUpgradeButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUpgradeButtonOnClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpgradeButtonOnClick, methodUpgradeButtonOnClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfUpgradeButtonOnClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpgradeButtonOnClick.ShouldNotBeNull();
            parametersOfUpgradeButtonOnClick.Length.ShouldBe(2);
            methodUpgradeButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodUpgradeButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfUpgradeButtonOnClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodUpgradeButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfUpgradeButtonOnClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodUpgradeButtonOnClick, parametersOfUpgradeButtonOnClick, methodUpgradeButtonOnClickPrametersTypes);

            // Assert
            parametersOfUpgradeButtonOnClick.ShouldNotBeNull();
            parametersOfUpgradeButtonOnClick.Length.ShouldBe(2);
            methodUpgradeButtonOnClickPrametersTypes.Length.ShouldBe(2);
            methodUpgradeButtonOnClickPrametersTypes.Length.ShouldBe(parametersOfUpgradeButtonOnClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpgradeButtonOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpgradeButtonOnClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodUpgradeButtonOnClick, Fixture, methodUpgradeButtonOnClickPrametersTypes);

            // Assert
            methodUpgradeButtonOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeButtonOnClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeButtonOnClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpgradeButtonOnClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_AddColumns_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_AddColumns_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddColumns = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumns, methodAddColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfAddColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(parametersOfAddColumns.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_AddColumns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddColumnsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddColumns = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodAddColumns, parametersOfAddColumns, methodAddColumnsPrametersTypes);

            // Assert
            parametersOfAddColumns.ShouldNotBeNull();
            parametersOfAddColumns.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
            methodAddColumnsPrametersTypes.Length.ShouldBe(parametersOfAddColumns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_AddColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_AddColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodAddColumns, Fixture, methodAddColumnsPrametersTypes);

            // Assert
            methodAddColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_AddColumns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureMyWorkViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_ConfigureMyWorkViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodConfigureMyWorkViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodConfigureMyWorkViews, Fixture, methodConfigureMyWorkViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (ConfigureMyWorkViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_ConfigureMyWorkViews_Static_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodConfigureMyWorkViewsPrametersTypes = null;
            object[] parametersOfConfigureMyWorkViews = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConfigureMyWorkViews, methodConfigureMyWorkViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfConfigureMyWorkViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConfigureMyWorkViews.ShouldBeNull();
            methodConfigureMyWorkViewsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureMyWorkViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_ConfigureMyWorkViews_Static_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodConfigureMyWorkViewsPrametersTypes = null;
            object[] parametersOfConfigureMyWorkViews = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodConfigureMyWorkViews, parametersOfConfigureMyWorkViews, methodConfigureMyWorkViewsPrametersTypes);

            // Assert
            parametersOfConfigureMyWorkViews.ShouldBeNull();
            methodConfigureMyWorkViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureMyWorkViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_ConfigureMyWorkViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodConfigureMyWorkViewsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodConfigureMyWorkViews, Fixture, methodConfigureMyWorkViewsPrametersTypes);

            // Assert
            methodConfigureMyWorkViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureMyWorkViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_ConfigureMyWorkViews_Static_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConfigureMyWorkViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GeneralUpgrade) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_GeneralUpgrade_Method_Call_Internally(Type[] types)
        {
            var methodGeneralUpgradePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodGeneralUpgrade, Fixture, methodGeneralUpgradePrametersTypes);
        }

        #endregion
        
        #region Method Call : (GeneralUpgrade) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_GeneralUpgrade_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var methodGeneralUpgradePrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGeneralUpgrade = { siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodGeneralUpgrade, parametersOfGeneralUpgrade, methodGeneralUpgradePrametersTypes);

            // Assert
            parametersOfGeneralUpgrade.ShouldNotBeNull();
            parametersOfGeneralUpgrade.Length.ShouldBe(1);
            methodGeneralUpgradePrametersTypes.Length.ShouldBe(1);
            methodGeneralUpgradePrametersTypes.Length.ShouldBe(parametersOfGeneralUpgrade.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GeneralUpgrade) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_GeneralUpgrade_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGeneralUpgrade, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GeneralUpgrade) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_GeneralUpgrade_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGeneralUpgradePrametersTypes = new Type[] { typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodGeneralUpgrade, Fixture, methodGeneralUpgradePrametersTypes);

            // Assert
            methodGeneralUpgradePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GeneralUpgrade) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_GeneralUpgrade_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGeneralUpgrade, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_LogError_Method_Call_Internally(Type[] types)
        {
            var methodLogErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);
        }

        #endregion
        
        #region Method Call : (LogError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogError_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogErrorPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogError = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodLogError, parametersOfLogError, methodLogErrorPrametersTypes);

            // Assert
            parametersOfLogError.ShouldNotBeNull();
            parametersOfLogError.Length.ShouldBe(1);
            methodLogErrorPrametersTypes.Length.ShouldBe(1);
            methodLogErrorPrametersTypes.Length.ShouldBe(parametersOfLogError.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogError_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogError, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogErrorPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);

            // Assert
            methodLogErrorPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogError_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogHeader) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_LogHeader_Method_Call_Internally(Type[] types)
        {
            var methodLogHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogHeader, Fixture, methodLogHeaderPrametersTypes);
        }

        #endregion
        
        #region Method Call : (LogHeader) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogHeader_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogHeaderPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogHeader = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodLogHeader, parametersOfLogHeader, methodLogHeaderPrametersTypes);

            // Assert
            parametersOfLogHeader.ShouldNotBeNull();
            parametersOfLogHeader.Length.ShouldBe(1);
            methodLogHeaderPrametersTypes.Length.ShouldBe(1);
            methodLogHeaderPrametersTypes.Length.ShouldBe(parametersOfLogHeader.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogHeader) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogHeader_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogHeader, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogHeader) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogHeaderPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogHeader, Fixture, methodLogHeaderPrametersTypes);

            // Assert
            methodLogHeaderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogHeader) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogHeader_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogHeader, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_LogMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);
        }

        #endregion
        
        #region Method Call : (LogMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogMessage_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogMessage = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodLogMessage, parametersOfLogMessage, methodLogMessagePrametersTypes);

            // Assert
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(1);
            methodLogMessagePrametersTypes.Length.ShouldBe(1);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogMessagePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);

            // Assert
            methodLogMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_LogMessage_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMyWorkWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodUpdateMyWorkWebPart, Fixture, methodUpdateMyWorkWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodUpdateMyWorkWebPartPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfUpdateMyWorkWebPart = { spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkWebPart, methodUpdateMyWorkWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfUpdateMyWorkWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateMyWorkWebPart.ShouldNotBeNull();
            parametersOfUpdateMyWorkWebPart.Length.ShouldBe(1);
            methodUpdateMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodUpdateMyWorkWebPartPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfUpdateMyWorkWebPart = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodUpdateMyWorkWebPart, parametersOfUpdateMyWorkWebPart, methodUpdateMyWorkWebPartPrametersTypes);

            // Assert
            parametersOfUpdateMyWorkWebPart.ShouldNotBeNull();
            parametersOfUpdateMyWorkWebPart.Length.ShouldBe(1);
            methodUpdateMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateMyWorkWebPartPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wE432UpgraderInstanceFixture, _wE432UpgraderInstanceType, MethodUpdateMyWorkWebPart, Fixture, methodUpdateMyWorkWebPartPrametersTypes);

            // Assert
            methodUpdateMyWorkWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyWorkWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpdateMyWorkWebPart_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateMyWorkWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeMyWork) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE432Upgrader_UpgradeMyWork_Method_Call_Internally(Type[] types)
        {
            var methodUpgradeMyWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodUpgradeMyWork, Fixture, methodUpgradeMyWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradeMyWork) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeMyWork_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpgradeMyWorkPrametersTypes = null;
            object[] parametersOfUpgradeMyWork = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpgradeMyWork, methodUpgradeMyWorkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wE432UpgraderInstanceFixture, parametersOfUpgradeMyWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpgradeMyWork.ShouldBeNull();
            methodUpgradeMyWorkPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeMyWork) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeMyWork_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpgradeMyWorkPrametersTypes = null;
            object[] parametersOfUpgradeMyWork = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_wE432UpgraderInstance, MethodUpgradeMyWork, parametersOfUpgradeMyWork, methodUpgradeMyWorkPrametersTypes);

            // Assert
            parametersOfUpgradeMyWork.ShouldBeNull();
            methodUpgradeMyWorkPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeMyWork) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeMyWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpgradeMyWorkPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE432UpgraderInstance, MethodUpgradeMyWork, Fixture, methodUpgradeMyWorkPrametersTypes);

            // Assert
            methodUpgradeMyWorkPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeMyWork) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WE432Upgrader_UpgradeMyWork_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpgradeMyWork, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_wE432UpgraderInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}