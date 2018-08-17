using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.HtmlControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.UpgradeReportingDBHelper" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UpgradeReportingDBHelperTest : AbstractBaseSetupTypedTest<UpgradeReportingDBHelper>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpgradeReportingDBHelper) Initializer

        private const string MethodUpgrade = "Upgrade";
        private const string MethodUpgradeDatabase = "UpgradeDatabase";
        private const string MethodExecuteUpgradeScripts = "ExecuteUpgradeScripts";
        private const string MethodUpgradeListMappings = "UpgradeListMappings";
        private const string MethodLogError = "LogError";
        private const string MethodLogMessage = "LogMessage";
        private const string MethodSqlConnectionInfoMessage = "SqlConnectionInfoMessage";
        private const string Field_messages = "_messages";
        private Type _upgradeReportingDBHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpgradeReportingDBHelper _upgradeReportingDBHelperInstance;
        private UpgradeReportingDBHelper _upgradeReportingDBHelperInstanceFixture;

        #region General Initializer : Class (UpgradeReportingDBHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpgradeReportingDBHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _upgradeReportingDBHelperInstanceType = typeof(UpgradeReportingDBHelper);
            _upgradeReportingDBHelperInstanceFixture = Create(true);
            _upgradeReportingDBHelperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpgradeReportingDBHelper)

        #region General Initializer : Class (UpgradeReportingDBHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UpgradeReportingDBHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodUpgrade, 0)]
        [TestCase(MethodUpgradeDatabase, 0)]
        [TestCase(MethodExecuteUpgradeScripts, 0)]
        [TestCase(MethodUpgradeListMappings, 0)]
        [TestCase(MethodLogError, 0)]
        [TestCase(MethodLogMessage, 0)]
        [TestCase(MethodSqlConnectionInfoMessage, 0)]
        public void AUT_UpgradeReportingDBHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_upgradeReportingDBHelperInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpgradeReportingDBHelper) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UpgradeReportingDBHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_messages)]
        public void AUT_UpgradeReportingDBHelper_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_upgradeReportingDBHelperInstanceFixture, 
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
        ///     Class (<see cref="UpgradeReportingDBHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UpgradeReportingDBHelper_Is_Instance_Present_Test()
        {
            // Assert
            _upgradeReportingDBHelperInstanceType.ShouldNotBeNull();
            _upgradeReportingDBHelperInstance.ShouldNotBeNull();
            _upgradeReportingDBHelperInstanceFixture.ShouldNotBeNull();
            _upgradeReportingDBHelperInstance.ShouldBeAssignableTo<UpgradeReportingDBHelper>();
            _upgradeReportingDBHelperInstanceFixture.ShouldBeAssignableTo<UpgradeReportingDBHelper>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UpgradeReportingDBHelper) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UpgradeReportingDBHelper_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UpgradeReportingDBHelper instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _upgradeReportingDBHelperInstanceType.ShouldNotBeNull();
            _upgradeReportingDBHelperInstance.ShouldNotBeNull();
            _upgradeReportingDBHelperInstanceFixture.ShouldNotBeNull();
            _upgradeReportingDBHelperInstance.ShouldBeAssignableTo<UpgradeReportingDBHelper>();
            _upgradeReportingDBHelperInstanceFixture.ShouldBeAssignableTo<UpgradeReportingDBHelper>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="UpgradeReportingDBHelper" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpgrade)]
        [TestCase(MethodUpgradeDatabase)]
        [TestCase(MethodExecuteUpgradeScripts)]
        [TestCase(MethodUpgradeListMappings)]
        [TestCase(MethodLogError)]
        [TestCase(MethodLogMessage)]
        [TestCase(MethodSqlConnectionInfoMessage)]
        public void AUT_UpgradeReportingDBHelper_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UpgradeReportingDBHelper>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_Internally(Type[] types)
        {
            var methodUpgradePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgrade, Fixture, methodUpgradePrametersTypes);
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _upgradeReportingDBHelperInstance.Upgrade();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodUpgradePrametersTypes = null;
            object[] parametersOfUpgrade = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpgrade, methodUpgradePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<UpgradeReportingDBHelper, List<HtmlGenericControl>>(_upgradeReportingDBHelperInstanceFixture, out exception1, parametersOfUpgrade);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<UpgradeReportingDBHelper, List<HtmlGenericControl>>(_upgradeReportingDBHelperInstance, MethodUpgrade, parametersOfUpgrade, methodUpgradePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpgrade.ShouldBeNull();
            methodUpgradePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpgradePrametersTypes = null;
            object[] parametersOfUpgrade = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<UpgradeReportingDBHelper, List<HtmlGenericControl>>(_upgradeReportingDBHelperInstance, MethodUpgrade, parametersOfUpgrade, methodUpgradePrametersTypes);

            // Assert
            parametersOfUpgrade.ShouldBeNull();
            methodUpgradePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodUpgradePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgrade, Fixture, methodUpgradePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpgradePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpgradePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgrade, Fixture, methodUpgradePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpgradePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Upgrade) (Return Type : List<HtmlGenericControl>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_Upgrade_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpgrade, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpgradeDatabase) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_UpgradeDatabase_Method_Call_Internally(Type[] types)
        {
            var methodUpgradeDatabasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgradeDatabase, Fixture, methodUpgradeDatabasePrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradeDatabase) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeDatabase_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpgradeDatabasePrametersTypes = null;
            object[] parametersOfUpgradeDatabase = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpgradeDatabase, methodUpgradeDatabasePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_upgradeReportingDBHelperInstanceFixture, parametersOfUpgradeDatabase);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpgradeDatabase.ShouldBeNull();
            methodUpgradeDatabasePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeDatabase) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeDatabase_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpgradeDatabasePrametersTypes = null;
            object[] parametersOfUpgradeDatabase = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodUpgradeDatabase, parametersOfUpgradeDatabase, methodUpgradeDatabasePrametersTypes);

            // Assert
            parametersOfUpgradeDatabase.ShouldBeNull();
            methodUpgradeDatabasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeDatabase) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeDatabase_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpgradeDatabasePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgradeDatabase, Fixture, methodUpgradeDatabasePrametersTypes);

            // Assert
            methodUpgradeDatabasePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeDatabase) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeDatabase_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpgradeDatabase, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_Internally(Type[] types)
        {
            var methodExecuteUpgradeScriptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodExecuteUpgradeScripts, Fixture, methodExecuteUpgradeScriptsPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var epmData = CreateType<EPMData>();
            var siteId = CreateType<Guid>();
            var methodExecuteUpgradeScriptsPrametersTypes = new Type[] { typeof(EPMData), typeof(Guid) };
            object[] parametersOfExecuteUpgradeScripts = { epmData, siteId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteUpgradeScripts, methodExecuteUpgradeScriptsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_upgradeReportingDBHelperInstanceFixture, parametersOfExecuteUpgradeScripts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteUpgradeScripts.ShouldNotBeNull();
            parametersOfExecuteUpgradeScripts.Length.ShouldBe(2);
            methodExecuteUpgradeScriptsPrametersTypes.Length.ShouldBe(2);
            methodExecuteUpgradeScriptsPrametersTypes.Length.ShouldBe(parametersOfExecuteUpgradeScripts.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var epmData = CreateType<EPMData>();
            var siteId = CreateType<Guid>();
            var methodExecuteUpgradeScriptsPrametersTypes = new Type[] { typeof(EPMData), typeof(Guid) };
            object[] parametersOfExecuteUpgradeScripts = { epmData, siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodExecuteUpgradeScripts, parametersOfExecuteUpgradeScripts, methodExecuteUpgradeScriptsPrametersTypes);

            // Assert
            parametersOfExecuteUpgradeScripts.ShouldNotBeNull();
            parametersOfExecuteUpgradeScripts.Length.ShouldBe(2);
            methodExecuteUpgradeScriptsPrametersTypes.Length.ShouldBe(2);
            methodExecuteUpgradeScriptsPrametersTypes.Length.ShouldBe(parametersOfExecuteUpgradeScripts.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteUpgradeScripts, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteUpgradeScriptsPrametersTypes = new Type[] { typeof(EPMData), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodExecuteUpgradeScripts, Fixture, methodExecuteUpgradeScriptsPrametersTypes);

            // Assert
            methodExecuteUpgradeScriptsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteUpgradeScripts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_ExecuteUpgradeScripts_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteUpgradeScripts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeListMappings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_UpgradeListMappings_Method_Call_Internally(Type[] types)
        {
            var methodUpgradeListMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgradeListMappings, Fixture, methodUpgradeListMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradeListMappings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeListMappings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpgradeListMappingsPrametersTypes = null;
            object[] parametersOfUpgradeListMappings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpgradeListMappings, methodUpgradeListMappingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_upgradeReportingDBHelperInstanceFixture, parametersOfUpgradeListMappings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpgradeListMappings.ShouldBeNull();
            methodUpgradeListMappingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeListMappings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeListMappings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpgradeListMappingsPrametersTypes = null;
            object[] parametersOfUpgradeListMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodUpgradeListMappings, parametersOfUpgradeListMappings, methodUpgradeListMappingsPrametersTypes);

            // Assert
            parametersOfUpgradeListMappings.ShouldBeNull();
            methodUpgradeListMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeListMappings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeListMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpgradeListMappingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodUpgradeListMappings, Fixture, methodUpgradeListMappingsPrametersTypes);

            // Assert
            methodUpgradeListMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpgradeListMappings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_UpgradeListMappings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpgradeListMappings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_LogError_Method_Call_Internally(Type[] types)
        {
            var methodLogErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);
        }

        #endregion
        
        #region Method Call : (LogError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_LogError_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogErrorPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogError = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodLogError, parametersOfLogError, methodLogErrorPrametersTypes);

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
        public void AUT_UpgradeReportingDBHelper_LogError_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_UpgradeReportingDBHelper_LogError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogErrorPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);

            // Assert
            methodLogErrorPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_LogError_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogMessage = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogMessage, methodLogMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_upgradeReportingDBHelperInstanceFixture, parametersOfLogMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(1);
            methodLogMessagePrametersTypes.Length.ShouldBe(1);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLogMessage = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodLogMessage, parametersOfLogMessage, methodLogMessagePrametersTypes);

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
        public void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogMessagePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);

            // Assert
            methodLogMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_LogMessage_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_Internally(Type[] types)
        {
            var methodSqlConnectionInfoMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodSqlConnectionInfoMessage, Fixture, methodSqlConnectionInfoMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<SqlInfoMessageEventArgs>();
            var methodSqlConnectionInfoMessagePrametersTypes = new Type[] { typeof(object), typeof(SqlInfoMessageEventArgs) };
            object[] parametersOfSqlConnectionInfoMessage = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSqlConnectionInfoMessage, methodSqlConnectionInfoMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_upgradeReportingDBHelperInstanceFixture, parametersOfSqlConnectionInfoMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSqlConnectionInfoMessage.ShouldNotBeNull();
            parametersOfSqlConnectionInfoMessage.Length.ShouldBe(2);
            methodSqlConnectionInfoMessagePrametersTypes.Length.ShouldBe(2);
            methodSqlConnectionInfoMessagePrametersTypes.Length.ShouldBe(parametersOfSqlConnectionInfoMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<SqlInfoMessageEventArgs>();
            var methodSqlConnectionInfoMessagePrametersTypes = new Type[] { typeof(object), typeof(SqlInfoMessageEventArgs) };
            object[] parametersOfSqlConnectionInfoMessage = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_upgradeReportingDBHelperInstance, MethodSqlConnectionInfoMessage, parametersOfSqlConnectionInfoMessage, methodSqlConnectionInfoMessagePrametersTypes);

            // Assert
            parametersOfSqlConnectionInfoMessage.ShouldNotBeNull();
            parametersOfSqlConnectionInfoMessage.Length.ShouldBe(2);
            methodSqlConnectionInfoMessagePrametersTypes.Length.ShouldBe(2);
            methodSqlConnectionInfoMessagePrametersTypes.Length.ShouldBe(parametersOfSqlConnectionInfoMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSqlConnectionInfoMessage, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSqlConnectionInfoMessagePrametersTypes = new Type[] { typeof(object), typeof(SqlInfoMessageEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgradeReportingDBHelperInstance, MethodSqlConnectionInfoMessage, Fixture, methodSqlConnectionInfoMessagePrametersTypes);

            // Assert
            methodSqlConnectionInfoMessagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SqlConnectionInfoMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpgradeReportingDBHelper_SqlConnectionInfoMessage_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSqlConnectionInfoMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_upgradeReportingDBHelperInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}