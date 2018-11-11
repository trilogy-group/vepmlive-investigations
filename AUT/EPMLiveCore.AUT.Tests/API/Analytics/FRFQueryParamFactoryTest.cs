using System;
using System.Collections.Generic;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.FRFQueryParamFactory" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FRFQueryParamFactoryTest : AbstractBaseSetupTest
    {
        public FRFQueryParamFactoryTest() : base(typeof(FRFQueryParamFactory))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FRFQueryParamFactory) Initializer

        private const string MethodGetParam = "GetParam";
        private const string MethodGetFavoriteQueryParams = "GetFavoriteQueryParams";
        private const string MethodGetFrequentQueryParams = "GetFrequentQueryParams";
        private const string MethodGetRecentItemQueryParams = "GetRecentItemQueryParams";
        private const string MethodGetFavWorkspaceQueryParams = "GetFavWorkspaceQueryParams";
        private const string MethodGetFavoriteStatusQueryParams = "GetFavoriteStatusQueryParams";
        private const string MethodGetRemoveFavoriteQueryParams = "GetRemoveFavoriteQueryParams";
        private const string MethodGetCreateFavoriteQueryParams = "GetCreateFavoriteQueryParams";
        private const string MethodGetCreateFrequentQueryParams = "GetCreateFrequentQueryParams";
        private const string MethodGetReadFrequentQueryParams = "GetReadFrequentQueryParams";
        private const string MethodGetUpdateFrequentQueryParams = "GetUpdateFrequentQueryParams";
        private const string MethodGetDeleteFrequentQueryParams = "GetDeleteFrequentQueryParams";
        private const string MethodGetCreateRecentItemQueryParams = "GetCreateRecentItemQueryParams";
        private const string MethodGetCreateFavWorkspaceQueryParams = "GetCreateFavWorkspaceQueryParams";
        private const string MethodGetRemoveFavWorkspaceQueryParams = "GetRemoveFavWorkspaceQueryParams";
        private Type _fRFQueryParamFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (FRFQueryParamFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FRFQueryParamFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fRFQueryParamFactoryInstanceType = typeof(FRFQueryParamFactory);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FRFQueryParamFactory)

        #region General Initializer : Class (FRFQueryParamFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FRFQueryParamFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetParam, 0)]
        [TestCase(MethodGetFavoriteQueryParams, 0)]
        [TestCase(MethodGetFrequentQueryParams, 0)]
        [TestCase(MethodGetRecentItemQueryParams, 0)]
        [TestCase(MethodGetFavWorkspaceQueryParams, 0)]
        [TestCase(MethodGetFavoriteStatusQueryParams, 0)]
        [TestCase(MethodGetRemoveFavoriteQueryParams, 0)]
        [TestCase(MethodGetCreateFavoriteQueryParams, 0)]
        [TestCase(MethodGetCreateFrequentQueryParams, 0)]
        [TestCase(MethodGetReadFrequentQueryParams, 0)]
        [TestCase(MethodGetUpdateFrequentQueryParams, 0)]
        [TestCase(MethodGetDeleteFrequentQueryParams, 0)]
        [TestCase(MethodGetCreateRecentItemQueryParams, 0)]
        [TestCase(MethodGetCreateFavWorkspaceQueryParams, 0)]
        [TestCase(MethodGetRemoveFavWorkspaceQueryParams, 0)]
        public void AUT_FRFQueryParamFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="FRFQueryParamFactory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FRFQueryParamFactory_Is_Static_Type_Present_Test()
        {
            // Assert
            _fRFQueryParamFactoryInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="FRFQueryParamFactory" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetParam)]
        [TestCase(MethodGetFavoriteQueryParams)]
        [TestCase(MethodGetFrequentQueryParams)]
        [TestCase(MethodGetRecentItemQueryParams)]
        [TestCase(MethodGetFavWorkspaceQueryParams)]
        [TestCase(MethodGetFavoriteStatusQueryParams)]
        [TestCase(MethodGetRemoveFavoriteQueryParams)]
        [TestCase(MethodGetCreateFavoriteQueryParams)]
        [TestCase(MethodGetCreateFrequentQueryParams)]
        [TestCase(MethodGetReadFrequentQueryParams)]
        [TestCase(MethodGetUpdateFrequentQueryParams)]
        [TestCase(MethodGetDeleteFrequentQueryParams)]
        [TestCase(MethodGetCreateRecentItemQueryParams)]
        [TestCase(MethodGetCreateFavWorkspaceQueryParams)]
        [TestCase(MethodGetRemoveFavWorkspaceQueryParams)]
        public void AUT_FRFQueryParamFactory_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _fRFQueryParamFactoryInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            Action executeAction = null;

            // Act
            executeAction = () => FRFQueryParamFactory.GetParam(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetParamPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetParam = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetParam, methodGetParamPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, parametersOfGetParam, methodGetParamPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParam.ShouldNotBeNull();
            parametersOfGetParam.Length.ShouldBe(1);
            methodGetParamPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetParamPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetParam = { data };

            // Assert
            parametersOfGetParam.ShouldNotBeNull();
            parametersOfGetParam.Length.ShouldBe(1);
            methodGetParamPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, parametersOfGetParam, methodGetParamPrametersTypes));
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParamPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParamPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParamPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetParam, Fixture, methodGetParamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParam) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetParam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParam, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFavoriteQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, Fixture, methodGetFavoriteQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueryParams, methodGetFavoriteQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, Fixture, methodGetFavoriteQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, parametersOfGetFavoriteQueryParams, methodGetFavoriteQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFavoriteQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetFavoriteQueryParams.Length.ShouldBe(1);
            methodGetFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteQueryParams = { data };

            // Assert
            parametersOfGetFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetFavoriteQueryParams.Length.ShouldBe(1);
            methodGetFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, parametersOfGetFavoriteQueryParams, methodGetFavoriteQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, Fixture, methodGetFavoriteQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteQueryParams, Fixture, methodGetFavoriteQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavoriteQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavoriteQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFrequentQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, Fixture, methodGetFrequentQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFrequentQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFrequentQueryParams, methodGetFrequentQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, Fixture, methodGetFrequentQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, parametersOfGetFrequentQueryParams, methodGetFrequentQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFrequentQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetFrequentQueryParams.Length.ShouldBe(1);
            methodGetFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFrequentQueryParams = { data };

            // Assert
            parametersOfGetFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetFrequentQueryParams.Length.ShouldBe(1);
            methodGetFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, parametersOfGetFrequentQueryParams, methodGetFrequentQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, Fixture, methodGetFrequentQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFrequentQueryParams, Fixture, methodGetFrequentQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFrequentQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFrequentQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFrequentQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFrequentQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFrequentQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRecentItemQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRecentItemQueryParams, Fixture, methodGetRecentItemQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRecentItemQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRecentItemQueryParams, methodGetRecentItemQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRecentItemQueryParams, Fixture, methodGetRecentItemQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRecentItemQueryParams, parametersOfGetRecentItemQueryParams, methodGetRecentItemQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRecentItemQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRecentItemQueryParams.ShouldNotBeNull();
            parametersOfGetRecentItemQueryParams.Length.ShouldBe(1);
            methodGetRecentItemQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRecentItemQueryParams = { data };

            // Assert
            parametersOfGetRecentItemQueryParams.ShouldNotBeNull();
            parametersOfGetRecentItemQueryParams.Length.ShouldBe(1);
            methodGetRecentItemQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRecentItemQueryParams, parametersOfGetRecentItemQueryParams, methodGetRecentItemQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRecentItemQueryParams, Fixture, methodGetRecentItemQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRecentItemQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRecentItemQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRecentItemQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRecentItemQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRecentItemQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFavWorkspaceQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, Fixture, methodGetFavWorkspaceQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavWorkspaceQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavWorkspaceQueryParams, methodGetFavWorkspaceQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, Fixture, methodGetFavWorkspaceQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, parametersOfGetFavWorkspaceQueryParams, methodGetFavWorkspaceQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFavWorkspaceQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavWorkspaceQueryParams = { data };

            // Assert
            parametersOfGetFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, parametersOfGetFavWorkspaceQueryParams, methodGetFavWorkspaceQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, Fixture, methodGetFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavWorkspaceQueryParams, Fixture, methodGetFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavWorkspaceQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavWorkspaceQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavWorkspaceQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFavoriteStatusQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, Fixture, methodGetFavoriteStatusQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteStatusQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteStatusQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavoriteStatusQueryParams, methodGetFavoriteStatusQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, Fixture, methodGetFavoriteStatusQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, parametersOfGetFavoriteStatusQueryParams, methodGetFavoriteStatusQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFavoriteStatusQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavoriteStatusQueryParams.ShouldNotBeNull();
            parametersOfGetFavoriteStatusQueryParams.Length.ShouldBe(1);
            methodGetFavoriteStatusQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteStatusQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteStatusQueryParams = { data };

            // Assert
            parametersOfGetFavoriteStatusQueryParams.ShouldNotBeNull();
            parametersOfGetFavoriteStatusQueryParams.Length.ShouldBe(1);
            methodGetFavoriteStatusQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, parametersOfGetFavoriteStatusQueryParams, methodGetFavoriteStatusQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavoriteStatusQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, Fixture, methodGetFavoriteStatusQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavoriteStatusQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavoriteStatusQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetFavoriteStatusQueryParams, Fixture, methodGetFavoriteStatusQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavoriteStatusQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavoriteStatusQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavoriteStatusQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetFavoriteStatusQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavoriteStatusQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRemoveFavoriteQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, Fixture, methodGetRemoveFavoriteQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavoriteQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQueryParams, methodGetRemoveFavoriteQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, Fixture, methodGetRemoveFavoriteQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, parametersOfGetRemoveFavoriteQueryParams, methodGetRemoveFavoriteQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRemoveFavoriteQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRemoveFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetRemoveFavoriteQueryParams.Length.ShouldBe(1);
            methodGetRemoveFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavoriteQueryParams = { data };

            // Assert
            parametersOfGetRemoveFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetRemoveFavoriteQueryParams.Length.ShouldBe(1);
            methodGetRemoveFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, parametersOfGetRemoveFavoriteQueryParams, methodGetRemoveFavoriteQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRemoveFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, Fixture, methodGetRemoveFavoriteQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRemoveFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRemoveFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavoriteQueryParams, Fixture, methodGetRemoveFavoriteQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRemoveFavoriteQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavoriteQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFavoriteQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, Fixture, methodGetCreateFavoriteQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavoriteQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQueryParams, methodGetCreateFavoriteQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, Fixture, methodGetCreateFavoriteQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, parametersOfGetCreateFavoriteQueryParams, methodGetCreateFavoriteQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateFavoriteQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFavoriteQueryParams.Length.ShouldBe(1);
            methodGetCreateFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavoriteQueryParams = { data };

            // Assert
            parametersOfGetCreateFavoriteQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFavoriteQueryParams.Length.ShouldBe(1);
            methodGetCreateFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, parametersOfGetCreateFavoriteQueryParams, methodGetCreateFavoriteQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, Fixture, methodGetCreateFavoriteQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFavoriteQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFavoriteQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavoriteQueryParams, Fixture, methodGetCreateFavoriteQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFavoriteQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavoriteQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFrequentQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, Fixture, methodGetCreateFrequentQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFrequentQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQueryParams, methodGetCreateFrequentQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, Fixture, methodGetCreateFrequentQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, parametersOfGetCreateFrequentQueryParams, methodGetCreateFrequentQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateFrequentQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFrequentQueryParams.Length.ShouldBe(1);
            methodGetCreateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFrequentQueryParams = { data };

            // Assert
            parametersOfGetCreateFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFrequentQueryParams.Length.ShouldBe(1);
            methodGetCreateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, parametersOfGetCreateFrequentQueryParams, methodGetCreateFrequentQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, Fixture, methodGetCreateFrequentQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFrequentQueryParams, Fixture, methodGetCreateFrequentQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFrequentQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFrequentQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFrequentQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReadFrequentQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, Fixture, methodGetReadFrequentQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFrequentQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQueryParams, methodGetReadFrequentQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, Fixture, methodGetReadFrequentQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, parametersOfGetReadFrequentQueryParams, methodGetReadFrequentQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetReadFrequentQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReadFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetReadFrequentQueryParams.Length.ShouldBe(1);
            methodGetReadFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFrequentQueryParams = { data };

            // Assert
            parametersOfGetReadFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetReadFrequentQueryParams.Length.ShouldBe(1);
            methodGetReadFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, parametersOfGetReadFrequentQueryParams, methodGetReadFrequentQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReadFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, Fixture, methodGetReadFrequentQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReadFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReadFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetReadFrequentQueryParams, Fixture, methodGetReadFrequentQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReadFrequentQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReadFrequentQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetReadFrequentQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdateFrequentQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, Fixture, methodGetUpdateFrequentQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetUpdateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetUpdateFrequentQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQueryParams, methodGetUpdateFrequentQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, Fixture, methodGetUpdateFrequentQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, parametersOfGetUpdateFrequentQueryParams, methodGetUpdateFrequentQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetUpdateFrequentQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUpdateFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetUpdateFrequentQueryParams.Length.ShouldBe(1);
            methodGetUpdateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetUpdateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetUpdateFrequentQueryParams = { data };

            // Assert
            parametersOfGetUpdateFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetUpdateFrequentQueryParams.Length.ShouldBe(1);
            methodGetUpdateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, parametersOfGetUpdateFrequentQueryParams, methodGetUpdateFrequentQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUpdateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, Fixture, methodGetUpdateFrequentQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdateFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUpdateFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetUpdateFrequentQueryParams, Fixture, methodGetUpdateFrequentQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdateFrequentQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetUpdateFrequentQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDeleteFrequentQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, Fixture, methodGetDeleteFrequentQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetDeleteFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetDeleteFrequentQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDeleteFrequentQueryParams, methodGetDeleteFrequentQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, Fixture, methodGetDeleteFrequentQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, parametersOfGetDeleteFrequentQueryParams, methodGetDeleteFrequentQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetDeleteFrequentQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDeleteFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetDeleteFrequentQueryParams.Length.ShouldBe(1);
            methodGetDeleteFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetDeleteFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetDeleteFrequentQueryParams = { data };

            // Assert
            parametersOfGetDeleteFrequentQueryParams.ShouldNotBeNull();
            parametersOfGetDeleteFrequentQueryParams.Length.ShouldBe(1);
            methodGetDeleteFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, parametersOfGetDeleteFrequentQueryParams, methodGetDeleteFrequentQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDeleteFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, Fixture, methodGetDeleteFrequentQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDeleteFrequentQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDeleteFrequentQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetDeleteFrequentQueryParams, Fixture, methodGetDeleteFrequentQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDeleteFrequentQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDeleteFrequentQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDeleteFrequentQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetDeleteFrequentQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDeleteFrequentQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateRecentItemQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, Fixture, methodGetCreateRecentItemQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateRecentItemQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQueryParams, methodGetCreateRecentItemQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, Fixture, methodGetCreateRecentItemQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, parametersOfGetCreateRecentItemQueryParams, methodGetCreateRecentItemQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateRecentItemQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateRecentItemQueryParams.ShouldNotBeNull();
            parametersOfGetCreateRecentItemQueryParams.Length.ShouldBe(1);
            methodGetCreateRecentItemQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateRecentItemQueryParams = { data };

            // Assert
            parametersOfGetCreateRecentItemQueryParams.ShouldNotBeNull();
            parametersOfGetCreateRecentItemQueryParams.Length.ShouldBe(1);
            methodGetCreateRecentItemQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, parametersOfGetCreateRecentItemQueryParams, methodGetCreateRecentItemQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, Fixture, methodGetCreateRecentItemQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateRecentItemQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateRecentItemQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateRecentItemQueryParams, Fixture, methodGetCreateRecentItemQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateRecentItemQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateRecentItemQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFavWorkspaceQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, Fixture, methodGetCreateFavWorkspaceQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavWorkspaceQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkspaceQueryParams, methodGetCreateFavWorkspaceQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, Fixture, methodGetCreateFavWorkspaceQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, parametersOfGetCreateFavWorkspaceQueryParams, methodGetCreateFavWorkspaceQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateFavWorkspaceQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetCreateFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavWorkspaceQueryParams = { data };

            // Assert
            parametersOfGetCreateFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetCreateFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetCreateFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, parametersOfGetCreateFavWorkspaceQueryParams, methodGetCreateFavWorkspaceQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, Fixture, methodGetCreateFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetCreateFavWorkspaceQueryParams, Fixture, methodGetCreateFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkspaceQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetCreateFavWorkspaceQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkspaceQueryParams, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRemoveFavWorkspaceQueryParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, Fixture, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavWorkspaceQueryParams = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkspaceQueryParams, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, Fixture, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, parametersOfGetRemoveFavWorkspaceQueryParams, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRemoveFavWorkspaceQueryParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRemoveFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetRemoveFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetRemoveFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavWorkspaceQueryParams = { data };

            // Assert
            parametersOfGetRemoveFavWorkspaceQueryParams.ShouldNotBeNull();
            parametersOfGetRemoveFavWorkspaceQueryParams.Length.ShouldBe(1);
            methodGetRemoveFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, object>>(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, parametersOfGetRemoveFavWorkspaceQueryParams, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRemoveFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, Fixture, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRemoveFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRemoveFavWorkspaceQueryParamsPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryParamFactoryInstanceType, MethodGetRemoveFavWorkspaceQueryParams, Fixture, methodGetRemoveFavWorkspaceQueryParamsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRemoveFavWorkspaceQueryParamsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkspaceQueryParams, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkspaceQueryParams) (Return Type : Dictionary<string, object>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryParamFactory_GetRemoveFavWorkspaceQueryParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkspaceQueryParams, 0);
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