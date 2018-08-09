using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.Generic" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GenericTest : AbstractBaseSetupTypedTest<Generic>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Generic) Initializer

        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodDeleteItems = "DeleteItems";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodPullData = "PullData";
        private const string MethodGetItem = "GetItem";
        private const string MethodGetDropDownValues = "GetDropDownValues";
        private const string MethodTestConnection = "TestConnection";
        private const string MethodBuildWSDL = "BuildWSDL";
        private const string MethodGetItemHash = "GetItemHash";
        private const string FieldmethodInfo = "methodInfo";
        private const string Fieldparam = "param";
        private const string Fieldservice = "service";
        private Type _genericInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Generic _genericInstance;
        private Generic _genericInstanceFixture;

        #region General Initializer : Class (Generic) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Generic" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _genericInstanceType = typeof(Generic);
            _genericInstanceFixture = Create(true);
            _genericInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Generic)

        #region General Initializer : Class (Generic) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Generic" />) explore and verify fields for coverage gain.
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
        [TestCase(MethodBuildWSDL, 0)]
        [TestCase(MethodGetItemHash, 0)]
        public void AUT_Generic_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_genericInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Generic) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Generic" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldmethodInfo)]
        [TestCase(Fieldparam)]
        [TestCase(Fieldservice)]
        public void AUT_Generic_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_genericInstanceFixture, 
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
        ///     Class (<see cref="Generic" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Generic_Is_Instance_Present_Test()
        {
            // Assert
            _genericInstanceType.ShouldNotBeNull();
            _genericInstance.ShouldNotBeNull();
            _genericInstanceFixture.ShouldNotBeNull();
            _genericInstance.ShouldBeAssignableTo<Generic>();
            _genericInstanceFixture.ShouldBeAssignableTo<Generic>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Generic) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Generic_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Generic instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _genericInstanceType.ShouldNotBeNull();
            _genericInstance.ShouldNotBeNull();
            _genericInstanceFixture.ShouldNotBeNull();
            _genericInstance.ShouldBeAssignableTo<Generic>();
            _genericInstanceFixture.ShouldBeAssignableTo<Generic>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Generic" />) public, non-public non-static methods exploration for coverage gain.
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
        [TestCase(MethodBuildWSDL)]
        [TestCase(MethodGetItemHash)]
        public void AUT_Generic_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Generic>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Generic_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_InstallIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            var APIUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.InstallIntegration(WebProps, Log, out Message, IntegrationKey, APIUrl);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_RemoveIntegration_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            var IntegrationKey = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.RemoveIntegration(WebProps, Log, out Message, IntegrationKey);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_DeleteItems_Method_Call_Internally(Type[] types)
        {
            var methodDeleteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.DeleteItems(WebProps, Items, Log);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_With_No_Exception_Thrown_Test()
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
            Should.NotThrow(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfDeleteItems));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, TransactionTable>(_genericInstance, MethodDeleteItems, parametersOfDeleteItems, methodDeleteItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDeleteItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodDeleteItems, Fixture, methodDeleteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DeleteItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_DeleteItems_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.UpdateItems(WebProps, Items, Log);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Items = CreateType<DataTable>();
            var Log = CreateType<IntegrationLog>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            object[] parametersOfUpdateItems = { WebProps, Items, Log };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Generic, TransactionTable>(_genericInstanceFixture, out exception1, parametersOfUpdateItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, TransactionTable>(_genericInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(3);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfUpdateItems));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, TransactionTable>(_genericInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes));
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataTable), typeof(IntegrationLog) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ListName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.GetColumns(WebProps, Log, ListName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<Generic, List<ColumnProperty>>(_genericInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, List<ColumnProperty>>(_genericInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(3);
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfGetColumns));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, List<ColumnProperty>>(_genericInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetColumns_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Items = CreateType<DataTable>();
            var LastSynch = CreateType<DateTime>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.PullData(WebProps, Log, Items, LastSynch);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Items = CreateType<DataTable>();
            var LastSynch = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            object[] parametersOfPullData = { WebProps, Log, Items, LastSynch };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfPullData));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, DataTable>(_genericInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(DataTable), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_PullData_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_GetItem_Method_Call_Internally(Type[] types)
        {
            var methodGetItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ItemID = CreateType<string>();
            var Items = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.GetItem(WebProps, Log, ItemID, Items);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_With_Results_Should_Not_Be_Null_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<Generic, DataTable>(_genericInstanceFixture, out exception1, parametersOfGetItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, DataTable>(_genericInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, DataTable>(_genericInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var ItemID = CreateType<string>();
            var Items = CreateType<DataTable>();
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            object[] parametersOfGetItem = { WebProps, Log, ItemID, Items };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetItem, methodGetItemPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetItem.ShouldNotBeNull();
            parametersOfGetItem.Length.ShouldBe(4);
            methodGetItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfGetItem));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, DataTable>(_genericInstance, MethodGetItem, parametersOfGetItem, methodGetItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(DataTable) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItem, Fixture, methodGetItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItem_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_GetDropDownValues_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var log = CreateType<IntegrationLog>();
            var Property = CreateType<string>();
            var ParentPropertyValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.GetDropDownValues(WebProps, log, Property, ParentPropertyValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_With_Results_Should_Not_Be_Null_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<Generic, Dictionary<String, String>>(_genericInstanceFixture, out exception1, parametersOfGetDropDownValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, Dictionary<String, String>>(_genericInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDropDownValues.ShouldNotBeNull();
            parametersOfGetDropDownValues.Length.ShouldBe(4);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, Dictionary<String, String>>(_genericInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_With_No_Exception_Thrown_Test()
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
            Should.NotThrow(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfGetDropDownValues));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, Dictionary<String, String>>(_genericInstance, MethodGetDropDownValues, parametersOfGetDropDownValues, methodGetDropDownValuesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDropDownValuesPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetDropDownValues, Fixture, methodGetDropDownValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDropDownValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownValues) (Return Type : Dictionary<String, String>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetDropDownValues_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Generic_TestConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_TestConnection_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var Message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _genericInstance.TestConnection(WebProps, Log, out Message);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_TestConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
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
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodTestConnection, parametersOfTestConnection, methodTestConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_TestConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTestConnectionPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodTestConnection, Fixture, methodTestConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_TestConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTestConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TestConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_TestConnection_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (BuildWSDL) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Generic_BuildWSDL_Method_Call_Internally(Type[] types)
        {
            var methodBuildWSDLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodBuildWSDL, Fixture, methodBuildWSDLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var methodBuildWSDLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfBuildWSDL = { WebProps, Log };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildWSDL, methodBuildWSDLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Generic, bool>(_genericInstanceFixture, out exception1, parametersOfBuildWSDL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodBuildWSDL, parametersOfBuildWSDL, methodBuildWSDLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfBuildWSDL.ShouldNotBeNull();
            parametersOfBuildWSDL.Length.ShouldBe(2);
            methodBuildWSDLPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfBuildWSDL));
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var methodBuildWSDLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfBuildWSDL = { WebProps, Log };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildWSDL, methodBuildWSDLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Generic, bool>(_genericInstanceFixture, out exception1, parametersOfBuildWSDL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodBuildWSDL, parametersOfBuildWSDL, methodBuildWSDLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfBuildWSDL.ShouldNotBeNull();
            parametersOfBuildWSDL.Length.ShouldBe(2);
            methodBuildWSDLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodBuildWSDL, parametersOfBuildWSDL, methodBuildWSDLPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var Log = CreateType<IntegrationLog>();
            var methodBuildWSDLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            object[] parametersOfBuildWSDL = { WebProps, Log };

            // Assert
            parametersOfBuildWSDL.ShouldNotBeNull();
            parametersOfBuildWSDL.Length.ShouldBe(2);
            methodBuildWSDLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, bool>(_genericInstance, MethodBuildWSDL, parametersOfBuildWSDL, methodBuildWSDLPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildWSDLPrametersTypes = new Type[] { typeof(WebProperties), typeof(IntegrationLog) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodBuildWSDL, Fixture, methodBuildWSDLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildWSDLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildWSDL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildWSDL) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_BuildWSDL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildWSDL, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Generic_GetItemHash_Method_Call_Internally(Type[] types)
        {
            var methodGetItemHashPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItemHash, Fixture, methodGetItemHashPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var drItem = CreateType<DataRow>();
            var methodGetItemHashPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow) };
            object[] parametersOfGetItemHash = { WebProps, drItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetItemHash, methodGetItemHashPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Generic, Hashtable>(_genericInstanceFixture, out exception1, parametersOfGetItemHash);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Generic, Hashtable>(_genericInstance, MethodGetItemHash, parametersOfGetItemHash, methodGetItemHashPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetItemHash.ShouldNotBeNull();
            parametersOfGetItemHash.Length.ShouldBe(2);
            methodGetItemHashPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_genericInstanceFixture, parametersOfGetItemHash));
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WebProps = CreateType<WebProperties>();
            var drItem = CreateType<DataRow>();
            var methodGetItemHashPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow) };
            object[] parametersOfGetItemHash = { WebProps, drItem };

            // Assert
            parametersOfGetItemHash.ShouldNotBeNull();
            parametersOfGetItemHash.Length.ShouldBe(2);
            methodGetItemHashPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Generic, Hashtable>(_genericInstance, MethodGetItemHash, parametersOfGetItemHash, methodGetItemHashPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemHashPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItemHash, Fixture, methodGetItemHashPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemHashPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemHashPrametersTypes = new Type[] { typeof(WebProperties), typeof(DataRow) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_genericInstance, MethodGetItemHash, Fixture, methodGetItemHashPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemHashPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemHash, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_genericInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemHash) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Generic_GetItemHash_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemHash, 0);
            const int parametersCount = 2;

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