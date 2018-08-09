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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.RecentItems" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RecentItemsTest : AbstractBaseSetupTypedTest<RecentItems>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RecentItems) Initializer

        private const string MethodCreate = "Create";
        private const string MethodIsValidList = "IsValidList";
        private const string MethodClearCache = "ClearCache";
        private Type _recentItemsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RecentItems _recentItemsInstance;
        private RecentItems _recentItemsInstanceFixture;

        #region General Initializer : Class (RecentItems) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RecentItems" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _recentItemsInstanceType = typeof(RecentItems);
            _recentItemsInstanceFixture = Create(true);
            _recentItemsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RecentItems)

        #region General Initializer : Class (RecentItems) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RecentItems" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreate, 0)]
        [TestCase(MethodIsValidList, 0)]
        [TestCase(MethodClearCache, 0)]
        public void AUT_RecentItems_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_recentItemsInstanceFixture, 
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
        ///     Class (<see cref="RecentItems" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RecentItems_Is_Instance_Present_Test()
        {
            // Assert
            _recentItemsInstanceType.ShouldNotBeNull();
            _recentItemsInstance.ShouldNotBeNull();
            _recentItemsInstanceFixture.ShouldNotBeNull();
            _recentItemsInstance.ShouldBeAssignableTo<RecentItems>();
            _recentItemsInstanceFixture.ShouldBeAssignableTo<RecentItems>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RecentItems) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RecentItems_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RecentItems instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _recentItemsInstanceType.ShouldNotBeNull();
            _recentItemsInstance.ShouldNotBeNull();
            _recentItemsInstanceFixture.ShouldNotBeNull();
            _recentItemsInstance.ShouldBeAssignableTo<RecentItems>();
            _recentItemsInstanceFixture.ShouldBeAssignableTo<RecentItems>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="RecentItems" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreate)]
        [TestCase(MethodIsValidList)]
        [TestCase(MethodClearCache)]
        public void AUT_RecentItems_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_recentItemsInstanceFixture,
                                                                              _recentItemsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItems_Create_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, Fixture, methodCreatePrametersTypes);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => RecentItems.Create(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodCreatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreate = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreate, methodCreatePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, Fixture, methodCreatePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, parametersOfCreate, methodCreatePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_recentItemsInstanceFixture, parametersOfCreate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(1);
            methodCreatePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodCreatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreate = { xml };

            // Assert
            parametersOfCreate.ShouldNotBeNull();
            parametersOfCreate.Length.ShouldBe(1);
            methodCreatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, parametersOfCreate, methodCreatePrametersTypes));
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreatePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, Fixture, methodCreatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodCreate, Fixture, methodCreatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Create) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_Create_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItems_IsValidList_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsValidListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodIsValidList, Fixture, methodIsValidListPrametersTypes);
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_IsValidList_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodIsValidListPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfIsValidList = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsValidList, methodIsValidListPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsValidList.ShouldNotBeNull();
            parametersOfIsValidList.Length.ShouldBe(1);
            methodIsValidListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_recentItemsInstanceFixture, parametersOfIsValidList));
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_IsValidList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodIsValidListPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfIsValidList = { data };

            // Assert
            parametersOfIsValidList.ShouldNotBeNull();
            parametersOfIsValidList.Length.ShouldBe(1);
            methodIsValidListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodIsValidList, parametersOfIsValidList, methodIsValidListPrametersTypes));
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_IsValidList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsValidListPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodIsValidList, Fixture, methodIsValidListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsValidListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_IsValidList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsValidList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsValidList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_IsValidList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsValidList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RecentItems_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfClearCache = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_recentItemsInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfClearCache = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

            // Assert
            parametersOfClearCache.ShouldNotBeNull();
            parametersOfClearCache.Length.ShouldBe(1);
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_ClearCache_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_ClearCache_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_recentItemsInstanceFixture, _recentItemsInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RecentItems_ClearCache_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_recentItemsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}