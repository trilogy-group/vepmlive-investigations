using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SocialEngine.Core;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SocialEngine
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.SocialEngineProxy" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SocialEngineProxyTest : AbstractBaseSetupTest
    {

        public SocialEngineProxyTest() : base(typeof(SocialEngineProxy))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SocialEngineProxy) Initializer

        private const string MethodClearTransaction = "ClearTransaction";
        private const string MethodGetActivities = "GetActivities";
        private const string MethodGetTransaction = "GetTransaction";
        private const string MethodProcessActivity = "ProcessActivity";
        private const string MethodSetTransaction = "SetTransaction";
        private const string FieldLocker = "Locker";
        private Type _socialEngineProxyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (SocialEngineProxy) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SocialEngineProxy" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _socialEngineProxyInstanceType = typeof(SocialEngineProxy);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SocialEngineProxy)

        #region General Initializer : Class (SocialEngineProxy) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SocialEngineProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodClearTransaction, 0)]
        [TestCase(MethodGetActivities, 0)]
        [TestCase(MethodGetTransaction, 0)]
        [TestCase(MethodProcessActivity, 0)]
        [TestCase(MethodSetTransaction, 0)]
        public void AUT_SocialEngineProxy_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SocialEngineProxy) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SocialEngineProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldLocker)]
        public void AUT_SocialEngineProxy_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="SocialEngineProxy" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SocialEngineProxy_Is_Static_Type_Present_Test()
        {
            // Assert
            _socialEngineProxyInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SocialEngineProxy" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodClearTransaction)]
        [TestCase(MethodGetActivities)]
        [TestCase(MethodGetTransaction)]
        [TestCase(MethodProcessActivity)]
        [TestCase(MethodSetTransaction)]
        public void AUT_SocialEngineProxy_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _socialEngineProxyInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearTransactionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodClearTransaction, Fixture, methodClearTransactionPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var transactionId = CreateType<Guid>();
            var contextWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => SocialEngineProxy.ClearTransaction(transactionId, contextWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var transactionId = CreateType<Guid>();
            var contextWeb = CreateType<SPWeb>();
            var methodClearTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb) };
            object[] parametersOfClearTransaction = { transactionId, contextWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearTransaction, methodClearTransactionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfClearTransaction);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearTransaction.ShouldNotBeNull();
            parametersOfClearTransaction.Length.ShouldBe(2);
            methodClearTransactionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var transactionId = CreateType<Guid>();
            var contextWeb = CreateType<SPWeb>();
            var methodClearTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb) };
            object[] parametersOfClearTransaction = { transactionId, contextWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _socialEngineProxyInstanceType, MethodClearTransaction, parametersOfClearTransaction, methodClearTransactionPrametersTypes);

            // Assert
            parametersOfClearTransaction.ShouldNotBeNull();
            parametersOfClearTransaction.Length.ShouldBe(2);
            methodClearTransactionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearTransaction, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodClearTransaction, Fixture, methodClearTransactionPrametersTypes);

            // Assert
            methodClearTransactionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearTransaction) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ClearTransaction_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearTransaction, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetActivitiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var contextWeb = CreateType<SPWeb>();
            var minDate = CreateType<DateTime?>();
            var maxDate = CreateType<DateTime?>();
            var page = CreateType<int?>();
            var limit = CreateType<int?>();
            var threadId = CreateType<Guid?>();
            Action executeAction = null;

            // Act
            executeAction = () => SocialEngineProxy.GetActivities(contextWeb, minDate, maxDate, page, limit, threadId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var contextWeb = CreateType<SPWeb>();
            var minDate = CreateType<DateTime?>();
            var maxDate = CreateType<DateTime?>();
            var page = CreateType<int?>();
            var limit = CreateType<int?>();
            var threadId = CreateType<Guid?>();
            var methodGetActivitiesPrametersTypes = new Type[] { typeof(SPWeb), typeof(DateTime?), typeof(DateTime?), typeof(int?), typeof(int?), typeof(Guid?) };
            object[] parametersOfGetActivities = { contextWeb, minDate, maxDate, page, limit, threadId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetActivities, methodGetActivitiesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(null, _socialEngineProxyInstanceType, MethodGetActivities, parametersOfGetActivities, methodGetActivitiesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetActivities);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetActivities.ShouldNotBeNull();
            parametersOfGetActivities.Length.ShouldBe(6);
            methodGetActivitiesPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var contextWeb = CreateType<SPWeb>();
            var minDate = CreateType<DateTime?>();
            var maxDate = CreateType<DateTime?>();
            var page = CreateType<int?>();
            var limit = CreateType<int?>();
            var threadId = CreateType<Guid?>();
            var methodGetActivitiesPrametersTypes = new Type[] { typeof(SPWeb), typeof(DateTime?), typeof(DateTime?), typeof(int?), typeof(int?), typeof(Guid?) };
            object[] parametersOfGetActivities = { contextWeb, minDate, maxDate, page, limit, threadId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(null, _socialEngineProxyInstanceType, MethodGetActivities, parametersOfGetActivities, methodGetActivitiesPrametersTypes);

            // Assert
            parametersOfGetActivities.ShouldNotBeNull();
            parametersOfGetActivities.Length.ShouldBe(6);
            methodGetActivitiesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetActivitiesPrametersTypes = new Type[] { typeof(SPWeb), typeof(DateTime?), typeof(DateTime?), typeof(int?), typeof(int?), typeof(Guid?) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetActivitiesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetActivitiesPrametersTypes = new Type[] { typeof(SPWeb), typeof(DateTime?), typeof(DateTime?), typeof(int?), typeof(int?), typeof(Guid?) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetActivities, Fixture, methodGetActivitiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetActivitiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetActivities, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetActivities) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetActivities_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetActivities, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTransactionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetTransaction, Fixture, methodGetTransactionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var contextWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => SocialEngineProxy.GetTransaction(webId, listId, itemId, contextWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var contextWeb = CreateType<SPWeb>();
            var methodGetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(SPWeb) };
            object[] parametersOfGetTransaction = { webId, listId, itemId, contextWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTransaction, methodGetTransactionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetTransaction, Fixture, methodGetTransactionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Guid?>(null, _socialEngineProxyInstanceType, MethodGetTransaction, parametersOfGetTransaction, methodGetTransactionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetTransaction);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTransaction.ShouldNotBeNull();
            parametersOfGetTransaction.Length.ShouldBe(4);
            methodGetTransactionPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var contextWeb = CreateType<SPWeb>();
            var methodGetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(SPWeb) };
            object[] parametersOfGetTransaction = { webId, listId, itemId, contextWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid?>(null, _socialEngineProxyInstanceType, MethodGetTransaction, parametersOfGetTransaction, methodGetTransactionPrametersTypes);

            // Assert
            parametersOfGetTransaction.ShouldNotBeNull();
            parametersOfGetTransaction.Length.ShouldBe(4);
            methodGetTransactionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetTransaction, Fixture, methodGetTransactionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTransactionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodGetTransaction, Fixture, methodGetTransactionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTransactionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTransaction, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTransaction) (Return Type : Guid?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_GetTransaction_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTransaction, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessActivityPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var objectKind = CreateType<ObjectKind>();
            var activityKind = CreateType<ActivityKind>();
            var data = CreateType<Dictionary<string, object>>();
            var contextWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => SocialEngineProxy.ProcessActivity(objectKind, activityKind, data, contextWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var objectKind = CreateType<ObjectKind>();
            var activityKind = CreateType<ActivityKind>();
            var data = CreateType<Dictionary<string, object>>();
            var contextWeb = CreateType<SPWeb>();
            var methodProcessActivityPrametersTypes = new Type[] { typeof(ObjectKind), typeof(ActivityKind), typeof(Dictionary<string, object>), typeof(SPWeb) };
            object[] parametersOfProcessActivity = { objectKind, activityKind, data, contextWeb };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessActivity, methodProcessActivityPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _socialEngineProxyInstanceType, MethodProcessActivity, parametersOfProcessActivity, methodProcessActivityPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfProcessActivity);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProcessActivity.ShouldNotBeNull();
            parametersOfProcessActivity.Length.ShouldBe(4);
            methodProcessActivityPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var objectKind = CreateType<ObjectKind>();
            var activityKind = CreateType<ActivityKind>();
            var data = CreateType<Dictionary<string, object>>();
            var contextWeb = CreateType<SPWeb>();
            var methodProcessActivityPrametersTypes = new Type[] { typeof(ObjectKind), typeof(ActivityKind), typeof(Dictionary<string, object>), typeof(SPWeb) };
            object[] parametersOfProcessActivity = { objectKind, activityKind, data, contextWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _socialEngineProxyInstanceType, MethodProcessActivity, parametersOfProcessActivity, methodProcessActivityPrametersTypes);

            // Assert
            parametersOfProcessActivity.ShouldNotBeNull();
            parametersOfProcessActivity.Length.ShouldBe(4);
            methodProcessActivityPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessActivityPrametersTypes = new Type[] { typeof(ObjectKind), typeof(ActivityKind), typeof(Dictionary<string, object>), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessActivityPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessActivityPrametersTypes = new Type[] { typeof(ObjectKind), typeof(ActivityKind), typeof(Dictionary<string, object>), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessActivityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessActivity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_ProcessActivity_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessActivity, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetTransactionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodSetTransaction, Fixture, methodSetTransactionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var componentName = CreateType<string>();
            var contextWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => SocialEngineProxy.SetTransaction(webId, listId, itemId, componentName, contextWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var componentName = CreateType<string>();
            var contextWeb = CreateType<SPWeb>();
            var methodSetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(SPWeb) };
            object[] parametersOfSetTransaction = { webId, listId, itemId, componentName, contextWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(null, _socialEngineProxyInstanceType, MethodSetTransaction, parametersOfSetTransaction, methodSetTransactionPrametersTypes);

            // Assert
            parametersOfSetTransaction.ShouldNotBeNull();
            parametersOfSetTransaction.Length.ShouldBe(5);
            methodSetTransactionPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodSetTransaction, Fixture, methodSetTransactionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetTransactionPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTransactionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(SPWeb) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _socialEngineProxyInstanceType, MethodSetTransaction, Fixture, methodSetTransactionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetTransactionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTransaction, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetTransaction) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SocialEngineProxy_SetTransaction_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTransaction, 0);
            const int parametersCount = 5;

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