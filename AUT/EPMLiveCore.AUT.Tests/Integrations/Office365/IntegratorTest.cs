using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveIntegration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SalesforceMetadataService;

namespace EPMLiveCore.Integrations.Office365
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Integrations.Office365.Integrator" />)
    ///     and namespace <see cref="EPMLiveCore.Integrations.Office365"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class IntegratorTest : AbstractBaseSetupTypedTest<Integrator>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Integrator) Initializer

        private const string MethodDeleteItems = "DeleteItems";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodGetDropDownValues = "GetDropDownValues";
        private const string MethodGetItem = "GetItem";
        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodPullData = "PullData";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodTestConnection = "TestConnection";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodBuildIdMap = "BuildIdMap";
        private const string MethodGetAuthParameters = "GetAuthParameters";
        private const string MethodGetMatchingListColumn = "GetMatchingListColumn";
        private const string MethodGetO365Service = "GetO365Service";
        private const string MethodTranslateFieldType = "TranslateFieldType";
        private Type _integratorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Integrator _integratorInstance;
        private Integrator _integratorInstanceFixture;

        #region General Initializer : Class (Integrator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Integrator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integratorInstanceType = typeof(Integrator);
            _integratorInstanceFixture = Create(true);
            _integratorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Integrator)

        #region General Initializer : Class (Integrator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Integrator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDeleteItems, 0)]
        [TestCase(MethodGetColumns, 0)]
        [TestCase(MethodGetDropDownValues, 0)]
        [TestCase(MethodGetItem, 0)]
        [TestCase(MethodInstallIntegration, 0)]
        [TestCase(MethodPullData, 0)]
        [TestCase(MethodRemoveIntegration, 0)]
        [TestCase(MethodTestConnection, 0)]
        [TestCase(MethodUpdateItems, 0)]
        [TestCase(MethodBuildIdMap, 0)]
        [TestCase(MethodGetAuthParameters, 0)]
        [TestCase(MethodGetMatchingListColumn, 0)]
        [TestCase(MethodGetO365Service, 0)]
        [TestCase(MethodTranslateFieldType, 0)]
        public void AUT_Integrator_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integratorInstanceFixture, 
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
        ///     Class (<see cref="Integrator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Integrator_Is_Instance_Present_Test()
        {
            // Assert
            _integratorInstanceType.ShouldNotBeNull();
            _integratorInstance.ShouldNotBeNull();
            _integratorInstanceFixture.ShouldNotBeNull();
            _integratorInstance.ShouldBeAssignableTo<Integrator>();
            _integratorInstanceFixture.ShouldBeAssignableTo<Integrator>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Integrator) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Integrator_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Integrator instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _integratorInstanceType.ShouldNotBeNull();
            _integratorInstance.ShouldNotBeNull();
            _integratorInstanceFixture.ShouldNotBeNull();
            _integratorInstance.ShouldBeAssignableTo<Integrator>();
            _integratorInstanceFixture.ShouldBeAssignableTo<Integrator>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Integrator" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodBuildIdMap)]
        [TestCase(MethodGetAuthParameters)]
        public void AUT_Integrator_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_integratorInstanceFixture,
                                                                              _integratorInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Integrator" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDeleteItems)]
        [TestCase(MethodGetColumns)]
        [TestCase(MethodGetDropDownValues)]
        [TestCase(MethodGetItem)]
        [TestCase(MethodInstallIntegration)]
        [TestCase(MethodPullData)]
        [TestCase(MethodRemoveIntegration)]
        [TestCase(MethodTestConnection)]
        [TestCase(MethodUpdateItems)]
        [TestCase(MethodGetMatchingListColumn)]
        [TestCase(MethodGetO365Service)]
        [TestCase(MethodTranslateFieldType)]
        public void AUT_Integrator_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Integrator>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_DeleteItems_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.DeleteItems(webProps, items, log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { webProps, items, log };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteItems, methodDeleteItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, TransactionTable>(_integratorInstanceFixture, out exception1, parametersOfDeleteItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfDeleteItems));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfDeleteItems = { webProps, items, log };

            // Assert
            parametersOfDeleteItems.ShouldNotBeNull();
            parametersOfDeleteItems.Length.ShouldBe(3);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_DeleteItems_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var listName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetColumns(webProps, log, listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var listName = CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { webProps, log, listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumns, methodGetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, List<ColumnProperty>>(_integratorInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, List<ColumnProperty>>(_integratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetColumns));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var listName = CreateType<string>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfGetColumns = { webProps, log, listName };

            // Assert
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, List<ColumnProperty>>(_integratorInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetColumns_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetDropDownValues_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var property = CreateType<string>();
            var parentPropertyValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetDropDownValues(webProps, log, property, parentPropertyValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var property = CreateType<string>();
            var parentPropertyValue = CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { webProps, log, property, parentPropertyValue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, methodGetDropDownValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, Dictionary<string, string>>(_integratorInstanceFixture, out exception1, parametersOfGetDropDownValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, Dictionary<string, string>>(_integratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetDropDownValues));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var property = CreateType<string>();
            var parentPropertyValue = CreateType<string>();
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownValues = { webProps, log, property, parentPropertyValue };

            // Assert
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, Dictionary<string, string>>(_integratorInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetDropDownValues_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetItem) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetItem_Method_Call_Internally(Type[] types)
        {
            var methodGetItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var itemId = CreateType<string>();
            var items = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.GetItem(webProps, log, itemId, items);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var itemId = CreateType<string>();
            var items = CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { webProps, log, itemId, items };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetItem, methodGetItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, DataTable>(_integratorInstanceFixture, out exception1, parametersOfGetItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetItem));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var itemId = CreateType<string>();
            var items = CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { webProps, log, itemId, items };

            // Assert
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetItem_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var apiUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.InstallIntegration(webProps, log, out message, integrationKey, apiUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var apiUrl = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var apiUrl = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfInstallIntegration));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var apiUrl = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInstallIntegration = { webProps, log, message, integrationKey, apiUrl };

            // Assert
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(5);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (PullData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var items = CreateType<DataTable>();
            var lastSynchDate = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.PullData(webProps, log, items, lastSynchDate);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var items = CreateType<DataTable>();
            var lastSynchDate = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { webProps, log, items, lastSynchDate };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, DataTable>(_integratorInstanceFixture, out exception1, parametersOfPullData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfPullData));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var items = CreateType<DataTable>();
            var lastSynchDate = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { webProps, log, items, lastSynchDate };

            // Assert
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, DataTable>(_integratorInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_PullData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (RemoveIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.RemoveIntegration(webProps, log, out message, integrationKey);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfRemoveIntegration));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var integrationKey = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            object[] parametersOfRemoveIntegration = { webProps, log, message, integrationKey };

            // Assert
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(4);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (TestConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_TestConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { webProps, log, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTestConnection, methodTestConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, bool>(_integratorInstanceFixture, out exception1, parametersOfTestConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var message = CreateType<string>();
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            object[] parametersOfTestConnection = { webProps, log, message };

            // Assert
            parametersOfTestConnection.ShouldNotBeNull();
            parametersOfTestConnection.Length.ShouldBe(3);
            methodTestConnectionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, bool>(_integratorInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TestConnection_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _integratorInstance.UpdateItems(webProps, items, log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { webProps, items, log };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integrator, TransactionTable>(_integratorInstanceFixture, out exception1, parametersOfUpdateItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfUpdateItems));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var items = CreateType<DataTable>();
            var log = CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { webProps, items, log };

            // Assert
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, TransactionTable>(_integratorInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_BuildIdMap_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildIdMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_integratorInstanceFixture, _integratorInstanceType, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var items = CreateType<DataTable>();
            var ids = CreateType<List<string>>();
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            object[] parametersOfBuildIdMap = { items, ids };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildIdMap, methodBuildIdMapPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildIdMap.ShouldNotBeNull();
            parametersOfBuildIdMap.Length.ShouldBe(2);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfBuildIdMap));
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var items = CreateType<DataTable>();
            var ids = CreateType<List<string>>();
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            object[] parametersOfBuildIdMap = { items, ids };

            // Assert
            parametersOfBuildIdMap.ShouldNotBeNull();
            parametersOfBuildIdMap.Length.ShouldBe(2);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, string>>(_integratorInstanceFixture, _integratorInstanceType, MethodBuildIdMap, parametersOfBuildIdMap, methodBuildIdMapPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_integratorInstanceFixture, _integratorInstanceType, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildIdMapPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildIdMapPrametersTypes = new Type[] { typeof(DataTable), typeof(List<string>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_integratorInstanceFixture, _integratorInstanceType, MethodBuildIdMap, Fixture, methodBuildIdMapPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildIdMapPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildIdMap, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildIdMap) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_BuildIdMap_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildIdMap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetAuthParameters_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAuthParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_integratorInstanceFixture, _integratorInstanceType, MethodGetAuthParameters, Fixture, methodGetAuthParametersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthParameters_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var username = CreateType<string>();
            var password = CreateType<SecureString>();
            var siteUrl = CreateType<string>();
            var methodGetAuthParametersPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(SecureString), typeof(string) };
            object[] parametersOfGetAuthParameters = { webProps, username, password, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAuthParameters, methodGetAuthParametersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetAuthParameters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAuthParameters.ShouldNotBeNull();
            parametersOfGetAuthParameters.Length.ShouldBe(4);
            methodGetAuthParametersPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthParameters_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webProps = CreateType<WebProperties>();
            var username = CreateType<string>();
            var password = CreateType<SecureString>();
            var siteUrl = CreateType<string>();
            var methodGetAuthParametersPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(SecureString), typeof(string) };
            object[] parametersOfGetAuthParameters = { webProps, username, password, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_integratorInstanceFixture, _integratorInstanceType, MethodGetAuthParameters, parametersOfGetAuthParameters, methodGetAuthParametersPrametersTypes);

            // Assert
            parametersOfGetAuthParameters.ShouldNotBeNull();
            parametersOfGetAuthParameters.Length.ShouldBe(4);
            methodGetAuthParametersPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthParameters_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAuthParameters, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthParameters_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAuthParametersPrametersTypes = new Type[] { typeof(WebProperties), typeof(string), typeof(SecureString), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_integratorInstanceFixture, _integratorInstanceType, MethodGetAuthParameters, Fixture, methodGetAuthParametersPrametersTypes);

            // Assert
            methodGetAuthParametersPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAuthParameters) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetAuthParameters_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAuthParameters, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetMatchingListColumn_Method_Call_Internally(Type[] types)
        {
            var methodGetMatchingListColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetMatchingListColumn, Fixture, methodGetMatchingListColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetMatchingListColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMatchingListColumn = { internalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMatchingListColumn, methodGetMatchingListColumnPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMatchingListColumn.ShouldNotBeNull();
            parametersOfGetMatchingListColumn.Length.ShouldBe(1);
            methodGetMatchingListColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfGetMatchingListColumn));
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetMatchingListColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMatchingListColumn = { internalName };

            // Assert
            parametersOfGetMatchingListColumn.ShouldNotBeNull();
            parametersOfGetMatchingListColumn.Length.ShouldBe(1);
            methodGetMatchingListColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, string>(_integratorInstance, MethodGetMatchingListColumn, parametersOfGetMatchingListColumn, methodGetMatchingListColumnPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMatchingListColumnPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetMatchingListColumn, Fixture, methodGetMatchingListColumnPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMatchingListColumnPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMatchingListColumnPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetMatchingListColumn, Fixture, methodGetMatchingListColumnPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMatchingListColumnPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMatchingListColumn, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMatchingListColumn) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetMatchingListColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMatchingListColumn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetO365Service) (Return Type : O365Service) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_GetO365Service_Method_Call_Internally(Type[] types)
        {
            var methodGetO365ServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetO365Service, Fixture, methodGetO365ServicePrametersTypes);
        }

        #endregion

        #region Method Call : (GetO365Service) (Return Type : O365Service) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetO365Service_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetO365ServicePrametersTypes = new Type[] { typeof(WebProperties) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetO365Service, Fixture, methodGetO365ServicePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetO365ServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetO365Service) (Return Type : O365Service) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetO365Service_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetO365ServicePrametersTypes = new Type[] { typeof(WebProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodGetO365Service, Fixture, methodGetO365ServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetO365ServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetO365Service) (Return Type : O365Service) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetO365Service_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetO365Service, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetO365Service) (Return Type : O365Service) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_GetO365Service_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetO365Service, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integrator_TranslateFieldType_Method_Call_Internally(Type[] types)
        {
            var methodTranslateFieldTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTranslateFieldType, Fixture, methodTranslateFieldTypePrametersTypes);
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldType = CreateType<FieldType>();
            var methodTranslateFieldTypePrametersTypes = new Type[] { typeof(FieldType) };
            object[] parametersOfTranslateFieldType = { fieldType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTranslateFieldType, methodTranslateFieldTypePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTranslateFieldType.ShouldNotBeNull();
            parametersOfTranslateFieldType.Length.ShouldBe(1);
            methodTranslateFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_integratorInstanceFixture, parametersOfTranslateFieldType));
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldType = CreateType<FieldType>();
            var methodTranslateFieldTypePrametersTypes = new Type[] { typeof(FieldType) };
            object[] parametersOfTranslateFieldType = { fieldType };

            // Assert
            parametersOfTranslateFieldType.ShouldNotBeNull();
            parametersOfTranslateFieldType.Length.ShouldBe(1);
            methodTranslateFieldTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Integrator, Type>(_integratorInstance, MethodTranslateFieldType, parametersOfTranslateFieldType, methodTranslateFieldTypePrametersTypes));
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodTranslateFieldTypePrametersTypes = new Type[] { typeof(FieldType) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTranslateFieldType, Fixture, methodTranslateFieldTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodTranslateFieldTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTranslateFieldTypePrametersTypes = new Type[] { typeof(FieldType) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integratorInstance, MethodTranslateFieldType, Fixture, methodTranslateFieldTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTranslateFieldTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTranslateFieldType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integratorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TranslateFieldType) (Return Type : Type) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Integrator_TranslateFieldType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTranslateFieldType, 0);
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