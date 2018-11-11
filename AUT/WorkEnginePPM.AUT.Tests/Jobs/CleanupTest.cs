using System;
using System.Data;
using System.Data.SqlClient;
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

namespace WorkEnginePPM.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Jobs.Cleanup" />)
    ///     and namespace <see cref="WorkEnginePPM.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CleanupTest : AbstractBaseSetupTypedTest<Cleanup>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Cleanup) Initializer

        private const string Methodexecute = "execute";
        private const string MethodgetPrefix = "getPrefix";
        private const string MethodprocessTimesheets = "processTimesheets";
        private const string MethodGetDataset = "GetDataset";
        private const string MethodprocessItems = "processItems";
        private const string MethodprocessResources = "processResources";
        private const string Fieldcounter = "counter";
        private const string FieldsbErrors = "sbErrors";
        private Type _cleanupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Cleanup _cleanupInstance;
        private Cleanup _cleanupInstanceFixture;

        #region General Initializer : Class (Cleanup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Cleanup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cleanupInstanceType = typeof(Cleanup);
            _cleanupInstanceFixture = Create(true);
            _cleanupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Cleanup)

        #region General Initializer : Class (Cleanup) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Cleanup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodgetPrefix, 0)]
        [TestCase(MethodprocessTimesheets, 0)]
        [TestCase(MethodGetDataset, 0)]
        [TestCase(MethodprocessItems, 0)]
        [TestCase(MethodprocessResources, 0)]
        public void AUT_Cleanup_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cleanupInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Cleanup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Cleanup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldcounter)]
        [TestCase(FieldsbErrors)]
        public void AUT_Cleanup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cleanupInstanceFixture, 
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
        ///     Class (<see cref="Cleanup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Cleanup_Is_Instance_Present_Test()
        {
            // Assert
            _cleanupInstanceType.ShouldNotBeNull();
            _cleanupInstance.ShouldNotBeNull();
            _cleanupInstanceFixture.ShouldNotBeNull();
            _cleanupInstance.ShouldBeAssignableTo<Cleanup>();
            _cleanupInstanceFixture.ShouldBeAssignableTo<Cleanup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Cleanup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Cleanup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Cleanup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cleanupInstanceType.ShouldNotBeNull();
            _cleanupInstance.ShouldNotBeNull();
            _cleanupInstanceFixture.ShouldNotBeNull();
            _cleanupInstance.ShouldBeAssignableTo<Cleanup>();
            _cleanupInstanceFixture.ShouldBeAssignableTo<Cleanup>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Cleanup" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodgetPrefix)]
        [TestCase(MethodprocessTimesheets)]
        [TestCase(MethodGetDataset)]
        [TestCase(MethodprocessItems)]
        [TestCase(MethodprocessResources)]
        public void AUT_Cleanup_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Cleanup>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cleanupInstance.execute(site, web, data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cleanupInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cleanupInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_getPrefix_Method_Call_Internally(Type[] types)
        {
            var methodgetPrefixPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetPrefix, methodgetPrefixPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cleanupInstanceFixture, parametersOfgetPrefix);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Cleanup, string>(_cleanupInstance, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes);

            // Assert
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPrefixPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPrefix, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_getPrefix_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetPrefix, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_processTimesheets_Method_Call_Internally(Type[] types)
        {
            var methodprocessTimesheetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessTimesheets, Fixture, methodprocessTimesheetsPrametersTypes);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processTimesheets_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var cn = CreateType<SqlConnection>();
            var we = CreateType<PortfolioEngineCore.WEIntegration.WEIntegration>();
            var methodprocessTimesheetsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SqlConnection), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };
            object[] parametersOfprocessTimesheets = { site, web, cn, we };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessTimesheets, methodprocessTimesheetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cleanupInstanceFixture, parametersOfprocessTimesheets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessTimesheets.ShouldNotBeNull();
            parametersOfprocessTimesheets.Length.ShouldBe(4);
            methodprocessTimesheetsPrametersTypes.Length.ShouldBe(4);
            methodprocessTimesheetsPrametersTypes.Length.ShouldBe(parametersOfprocessTimesheets.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processTimesheets_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var cn = CreateType<SqlConnection>();
            var we = CreateType<PortfolioEngineCore.WEIntegration.WEIntegration>();
            var methodprocessTimesheetsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SqlConnection), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };
            object[] parametersOfprocessTimesheets = { site, web, cn, we };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cleanupInstance, MethodprocessTimesheets, parametersOfprocessTimesheets, methodprocessTimesheetsPrametersTypes);

            // Assert
            parametersOfprocessTimesheets.ShouldNotBeNull();
            parametersOfprocessTimesheets.Length.ShouldBe(4);
            methodprocessTimesheetsPrametersTypes.Length.ShouldBe(4);
            methodprocessTimesheetsPrametersTypes.Length.ShouldBe(parametersOfprocessTimesheets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processTimesheets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessTimesheets, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processTimesheets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessTimesheetsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SqlConnection), typeof(PortfolioEngineCore.WEIntegration.WEIntegration) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessTimesheets, Fixture, methodprocessTimesheetsPrametersTypes);

            // Assert
            methodprocessTimesheetsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processTimesheets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processTimesheets_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessTimesheets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_GetDataset_Method_Call_Internally(Type[] types)
        {
            var methodGetDatasetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodGetDataset, Fixture, methodGetDatasetPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ds = CreateType<DataSet>();
            var cmd = CreateType<SqlCommand>();
            var methodGetDatasetPrametersTypes = new Type[] { typeof(DataSet), typeof(SqlCommand) };
            object[] parametersOfGetDataset = { ds, cmd };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataset, methodGetDatasetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Cleanup, DataSet>(_cleanupInstanceFixture, out exception1, parametersOfGetDataset);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Cleanup, DataSet>(_cleanupInstance, MethodGetDataset, parametersOfGetDataset, methodGetDatasetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataset.ShouldNotBeNull();
            parametersOfGetDataset.Length.ShouldBe(2);
            methodGetDatasetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ds = CreateType<DataSet>();
            var cmd = CreateType<SqlCommand>();
            var methodGetDatasetPrametersTypes = new Type[] { typeof(DataSet), typeof(SqlCommand) };
            object[] parametersOfGetDataset = { ds, cmd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Cleanup, DataSet>(_cleanupInstance, MethodGetDataset, parametersOfGetDataset, methodGetDatasetPrametersTypes);

            // Assert
            parametersOfGetDataset.ShouldNotBeNull();
            parametersOfGetDataset.Length.ShouldBe(2);
            methodGetDatasetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDatasetPrametersTypes = new Type[] { typeof(DataSet), typeof(SqlCommand) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodGetDataset, Fixture, methodGetDatasetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDatasetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDatasetPrametersTypes = new Type[] { typeof(DataSet), typeof(SqlCommand) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodGetDataset, Fixture, methodGetDatasetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDatasetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataset, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataset) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_GetDataset_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataset, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_processItems_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessItems, Fixture, methodprocessItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processItems_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var dv = CreateType<DataView>();
            var ds = CreateType<DataSet>();
            var pe = CreateType<PortfolioEngineCore.PortfolioItems.PortfolioItems>();
            var methodprocessItemsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(DataView), typeof(DataSet), typeof(PortfolioEngineCore.PortfolioItems.PortfolioItems) };
            object[] parametersOfprocessItems = { site, web, dv, ds, pe };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessItems, methodprocessItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cleanupInstanceFixture, parametersOfprocessItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItems.ShouldNotBeNull();
            parametersOfprocessItems.Length.ShouldBe(5);
            methodprocessItemsPrametersTypes.Length.ShouldBe(5);
            methodprocessItemsPrametersTypes.Length.ShouldBe(parametersOfprocessItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processItems_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var dv = CreateType<DataView>();
            var ds = CreateType<DataSet>();
            var pe = CreateType<PortfolioEngineCore.PortfolioItems.PortfolioItems>();
            var methodprocessItemsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(DataView), typeof(DataSet), typeof(PortfolioEngineCore.PortfolioItems.PortfolioItems) };
            object[] parametersOfprocessItems = { site, web, dv, ds, pe };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cleanupInstance, MethodprocessItems, parametersOfprocessItems, methodprocessItemsPrametersTypes);

            // Assert
            parametersOfprocessItems.ShouldNotBeNull();
            parametersOfprocessItems.Length.ShouldBe(5);
            methodprocessItemsPrametersTypes.Length.ShouldBe(5);
            methodprocessItemsPrametersTypes.Length.ShouldBe(parametersOfprocessItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessItems, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessItemsPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(DataView), typeof(DataSet), typeof(PortfolioEngineCore.PortfolioItems.PortfolioItems) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessItems, Fixture, methodprocessItemsPrametersTypes);

            // Assert
            methodprocessItemsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processItems_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Cleanup_processResources_Method_Call_Internally(Type[] types)
        {
            var methodprocessResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessResources, Fixture, methodprocessResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processResources_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var resWeb = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var resList = CreateType<SPList>();
            var methodprocessResourcesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string), typeof(SPList) };
            object[] parametersOfprocessResources = { site, resWeb, sPrefix, resList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessResources, methodprocessResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cleanupInstanceFixture, parametersOfprocessResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessResources.ShouldNotBeNull();
            parametersOfprocessResources.Length.ShouldBe(4);
            methodprocessResourcesPrametersTypes.Length.ShouldBe(4);
            methodprocessResourcesPrametersTypes.Length.ShouldBe(parametersOfprocessResources.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processResources_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var resWeb = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var resList = CreateType<SPList>();
            var methodprocessResourcesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string), typeof(SPList) };
            object[] parametersOfprocessResources = { site, resWeb, sPrefix, resList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cleanupInstance, MethodprocessResources, parametersOfprocessResources, methodprocessResourcesPrametersTypes);

            // Assert
            parametersOfprocessResources.ShouldNotBeNull();
            parametersOfprocessResources.Length.ShouldBe(4);
            methodprocessResourcesPrametersTypes.Length.ShouldBe(4);
            methodprocessResourcesPrametersTypes.Length.ShouldBe(parametersOfprocessResources.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessResources, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessResourcesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cleanupInstance, MethodprocessResources, Fixture, methodprocessResourcesPrametersTypes);

            // Assert
            methodprocessResourcesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processResources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Cleanup_processResources_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessResources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cleanupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}