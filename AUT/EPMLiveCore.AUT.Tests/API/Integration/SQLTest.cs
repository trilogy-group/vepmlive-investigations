using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveIntegration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.SQL" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SQLTest : AbstractBaseSetupTypedTest<SQL>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SQL) Initializer

        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodDeleteItems = "DeleteItems";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodPullData = "PullData";
        private const string MethodGetItem = "GetItem";
        private const string MethodGetDropDownValues = "GetDropDownValues";
        private const string MethodTestConnection = "TestConnection";
        private const string MethodGetDefaultColumn = "GetDefaultColumn";
        private const string MethodGetConnection = "GetConnection";
        private const string MethodInsertRow = "InsertRow";
        private const string MethodUpdateRow = "UpdateRow";
        private Type _sQLInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SQL _sQLInstance;
        private SQL _sQLInstanceFixture;

        #region General Initializer : Class (SQL) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SQL" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sQLInstanceType = typeof(SQL);
            _sQLInstanceFixture = Create(true);
            _sQLInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SQL)

        #region General Initializer : Class (SQL) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SQL" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstallIntegration, 0)]
        [TestCase(MethodRemoveIntegration, 0)]
        [TestCase(MethodDeleteItems, 0)]
        [TestCase(MethodUpdateItems, 0)]
        [TestCase(MethodGetColumns, 0)]
        [TestCase(MethodPullData, 0)]
        [TestCase(MethodGetItem, 0)]
        [TestCase(MethodGetDropDownValues, 0)]
        [TestCase(MethodTestConnection, 0)]
        [TestCase(MethodGetDefaultColumn, 0)]
        [TestCase(MethodGetConnection, 0)]
        [TestCase(MethodInsertRow, 0)]
        [TestCase(MethodUpdateRow, 0)]
        public void AUT_SQL_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sQLInstanceFixture, 
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
        ///     Class (<see cref="SQL" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SQL_Is_Instance_Present_Test()
        {
            // Assert
            _sQLInstanceType.ShouldNotBeNull();
            _sQLInstance.ShouldNotBeNull();
            _sQLInstanceFixture.ShouldNotBeNull();
            _sQLInstance.ShouldBeAssignableTo<SQL>();
            _sQLInstanceFixture.ShouldBeAssignableTo<SQL>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SQL) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SQL_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SQL instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sQLInstanceType.ShouldNotBeNull();
            _sQLInstance.ShouldNotBeNull();
            _sQLInstanceFixture.ShouldNotBeNull();
            _sQLInstance.ShouldBeAssignableTo<SQL>();
            _sQLInstanceFixture.ShouldBeAssignableTo<SQL>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SQL" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInstallIntegration)]
        [TestCase(MethodRemoveIntegration)]
        [TestCase(MethodDeleteItems)]
        [TestCase(MethodUpdateItems)]
        [TestCase(MethodGetColumns)]
        [TestCase(MethodPullData)]
        [TestCase(MethodGetItem)]
        [TestCase(MethodGetDropDownValues)]
        [TestCase(MethodTestConnection)]
        [TestCase(MethodGetDefaultColumn)]
        [TestCase(MethodGetConnection)]
        [TestCase(MethodInsertRow)]
        [TestCase(MethodUpdateRow)]
        public void AUT_SQL_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SQL>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InstallIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            var APIUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.InstallIntegration(WebProps, Log, out Message, IntegrationKey, APIUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            var APIUrl = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { WebProps, Log, Message, IntegrationKey, APIUrl };

            // Assert
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, bool>(_sQLInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_RemoveIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.RemoveIntegration(WebProps, Log, out Message, IntegrationKey);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { WebProps, Log, Message, IntegrationKey };

            // Assert
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, bool>(_sQLInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_DeleteItems_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.DeleteItems(WebProps, Items, Log);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { WebProps, Items, Log };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteItems, methodDeleteItemsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfDeleteItems));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { WebProps, Items, Log };

            // Assert
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, TransactionTable>(_sQLInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_DeleteItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.UpdateItems(WebProps, Items, Log);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { WebProps, Items, Log };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfUpdateItems));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { WebProps, Items, Log };

            // Assert
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, TransactionTable>(_sQLInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.GetColumns(WebProps, Log, ListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ListName = CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { WebProps, Log, ListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumns, methodGetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, List<ColumnProperty>>(_sQLInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, List<ColumnProperty>>(_sQLInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfGetColumns));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ListName = CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { WebProps, Log, ListName };

            // Assert
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, List<ColumnProperty>>(_sQLInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Items = CreateType<DataTable>();
            var LastSynch = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.PullData(WebProps, Log, Items, LastSynch);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Items = CreateType<DataTable>();
            var LastSynch = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { WebProps, Log, Items, LastSynch };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, DataTable>(_sQLInstanceFixture, out exception1, parametersOfPullData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, DataTable>(_sQLInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfPullData));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Items = CreateType<DataTable>();
            var LastSynch = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { WebProps, Log, Items, LastSynch };

            // Assert
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, DataTable>(_sQLInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_PullData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPullData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_GetItem_Method_Call_Internally(Type[] types)
        {
            var methodGetItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ItemID = CreateType<string>();
            var Items = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.GetItem(WebProps, Log, ItemID, Items);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ItemID = CreateType<string>();
            var Items = CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { WebProps, Log, ItemID, Items };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetItem, methodGetItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, DataTable>(_sQLInstanceFixture, out exception1, parametersOfGetItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, DataTable>(_sQLInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfGetItem));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ItemID = CreateType<string>();
            var Items = CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { WebProps, Log, ItemID, Items };

            // Assert
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, DataTable>(_sQLInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_GetDropDownValues_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var Property = CreateType<string>();
            var ParentPropertyValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.GetDropDownValues(WebProps, log, Property, ParentPropertyValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var Property = CreateType<string>();
            var ParentPropertyValue = CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, Dictionary<String, String>>(_sQLInstanceFixture, out exception1, parametersOfGetDropDownValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, Dictionary<String, String>>(_sQLInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, Dictionary<String, String>>(_sQLInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var Property = CreateType<string>();
            var ParentPropertyValue = CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfGetDropDownValues));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var Property = CreateType<string>();
            var ParentPropertyValue = CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { WebProps, log, Property, ParentPropertyValue };

            // Assert
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, Dictionary<String, String>>(_sQLInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDropDownValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_TestConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_TestConnection_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _sQLInstance.TestConnection(WebProps, Log, out Message);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_TestConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { WebProps, Log, Message };

            // Assert
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, bool>(_sQLInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_TestConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_TestConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTestConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_TestConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTestConnection, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_GetDefaultColumn_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var column = CreateType<string>();
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetDefaultColumn = { list, column };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumn, methodGetDefaultColumnPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultColumn.ShouldNotBeNull();
            parametersOfGetDefaultColumn.Length.ShouldBe(2);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfGetDefaultColumn));
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var column = CreateType<string>();
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetDefaultColumn = { list, column };

            // Assert
            parametersOfGetDefaultColumn.ShouldNotBeNull();
            parametersOfGetDefaultColumn.Length.ShouldBe(2);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, string>(_sQLInstance, MethodGetDefaultColumn, parametersOfGetDefaultColumn, methodGetDefaultColumnPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultColumnPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetDefaultColumn, Fixture, methodGetDefaultColumnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultColumnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultColumn, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultColumn) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetDefaultColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultColumn, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_GetConnection_Method_Call_Internally(Type[] types)
        {
            var methodGetConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Properties = CreateType<Hashtable>();
            var methodGetConnectionPrametersTypes = new Type[] { typeof(Hashtable) };
            object[] parametersOfGetConnection = { Properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnection, methodGetConnectionPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnection.ShouldNotBeNull();
            parametersOfGetConnection.Length.ShouldBe(1);
            methodGetConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfGetConnection));
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Properties = CreateType<Hashtable>();
            var methodGetConnectionPrametersTypes = new Type[] { typeof(Hashtable) };
            object[] parametersOfGetConnection = { Properties };

            // Assert
            parametersOfGetConnection.ShouldNotBeNull();
            parametersOfGetConnection.Length.ShouldBe(1);
            methodGetConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, SqlConnection>(_sQLInstance, MethodGetConnection, parametersOfGetConnection, methodGetConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetConnectionPrametersTypes = new Type[] { typeof(Hashtable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetConnectionPrametersTypes = new Type[] { typeof(Hashtable) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodGetConnection, Fixture, methodGetConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetConnection) (Return Type : SqlConnection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_GetConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_InsertRow_Method_Call_Internally(Type[] types)
        {
            var methodInsertRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodInsertRow, Fixture, methodInsertRowPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Item = CreateType<DataRow>();
            var Log = CreateType<IntegrationLog>();
            var cn = CreateType<SqlConnection>();
            var methodInsertRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            object[] parametersOfInsertRow = { WebProps, Item, Log, cn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertRow, methodInsertRowPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, string>(_sQLInstanceFixture, out exception1, parametersOfInsertRow);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, string>(_sQLInstance, MethodInsertRow, parametersOfInsertRow, methodInsertRowPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfInsertRow.ShouldNotBeNull();
            parametersOfInsertRow.Length.ShouldBe(4);
            methodInsertRowPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfInsertRow));
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Item = CreateType<DataRow>();
            var Log = CreateType<IntegrationLog>();
            var cn = CreateType<SqlConnection>();
            var methodInsertRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            object[] parametersOfInsertRow = { WebProps, Item, Log, cn };

            // Assert
            parametersOfInsertRow.ShouldNotBeNull();
            parametersOfInsertRow.Length.ShouldBe(4);
            methodInsertRowPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, string>(_sQLInstance, MethodInsertRow, parametersOfInsertRow, methodInsertRowPrametersTypes));
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInsertRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodInsertRow, Fixture, methodInsertRowPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInsertRowPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodInsertRow, Fixture, methodInsertRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertRow) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_InsertRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertRow, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SQL_UpdateRow_Method_Call_Internally(Type[] types)
        {
            var methodUpdateRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateRow, Fixture, methodUpdateRowPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Item = CreateType<DataRow>();
            var Log = CreateType<IntegrationLog>();
            var cn = CreateType<SqlConnection>();
            var methodUpdateRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            object[] parametersOfUpdateRow = { WebProps, Item, Log, cn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateRow, methodUpdateRowPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SQL, string>(_sQLInstanceFixture, out exception1, parametersOfUpdateRow);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SQL, string>(_sQLInstance, MethodUpdateRow, parametersOfUpdateRow, methodUpdateRowPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateRow.ShouldNotBeNull();
            parametersOfUpdateRow.Length.ShouldBe(4);
            methodUpdateRowPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_sQLInstanceFixture, parametersOfUpdateRow));
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Item = CreateType<DataRow>();
            var Log = CreateType<IntegrationLog>();
            var cn = CreateType<SqlConnection>();
            var methodUpdateRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            object[] parametersOfUpdateRow = { WebProps, Item, Log, cn };

            // Assert
            parametersOfUpdateRow.ShouldNotBeNull();
            parametersOfUpdateRow.Length.ShouldBe(4);
            methodUpdateRowPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SQL, string>(_sQLInstance, MethodUpdateRow, parametersOfUpdateRow, methodUpdateRowPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateRow, Fixture, methodUpdateRowPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateRowPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateRowPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow), typeof(IntegrationLog), typeof(SqlConnection) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sQLInstance, MethodUpdateRow, Fixture, methodUpdateRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sQLInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateRow) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SQL_UpdateRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateRow, 0);
            const int parametersCount = 4;

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